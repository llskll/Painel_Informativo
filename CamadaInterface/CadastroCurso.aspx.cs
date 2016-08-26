using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CamadaDados;
using CamadaMetaDado;
using CamadaNegocio;
using System.Collections;

namespace CamadaInterface
{
    public partial class CadastroCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NgUsuario objNegocio = new NgUsuario();
            Usuario1 objMetaDados = new Usuario1();
            ArrayList itens = (ArrayList)Session["Lista"];
            string Matricula = itens[0].ToString();

            List<Usuario1> objRetConsultaUsuario2 = objNegocio.NiveldeAcesso(Matricula);

            int NivelDeAcesso = objRetConsultaUsuario2[0].nivel;

            if (NivelDeAcesso == 1 || NivelDeAcesso == 2 || NivelDeAcesso == 3 || NivelDeAcesso == 5)
            {
                string lastURL = String.Empty;

                if (Request.ServerVariables["HTTP_REFERER"] != "Default.aspx")
                {
                    Response.Redirect("VerPainel.aspx");


                }


            }

        }



        protected void ButtonCadastrar_Click1(object sender, EventArgs e)
        {
            try
            {
                NgCurso objNegocio = new NgCurso();
                Curso objCurso = new Curso();
                objCurso.codigo = TextBoxCodigo.Text ;
                limparLabelMsg();

                List<Curso> objRetConsultaCurso = objNegocio.verificarCadastro(objCurso.codigo);
                if (objRetConsultaCurso.Count > 0)
                {
                    LabelMsg.Text = "Curso ja cadastrado.";
                }
                else
                {
                    objCurso.nomeCurso = TextBoxNome.Text;
                    objCurso.cargaHoraria = TextBoxCargaHoraria.Text;
                    objCurso.codigo = TextBoxCodigo.Text;

                    LabelMsg.Text = (objNegocio.incluir(objCurso) ? "Cadastro efetuado com sucesso." : "Erro no cadastro");
                }

            }
            catch (Exception ex)
            {
                LabelMsg.Text = ex.Message;
            }

        }

        protected void ButtonConsultar_Click(object sender, EventArgs e)
        {
                NgCurso objNegocio = new NgCurso();
                Curso objCurso = new Curso();
                limparLabelMsg();
            try
            {
                if (TextBoxCodigo.Text == "")
                {
                    GridView1.DataSource = null; //Remover a datasource
                    GridView1.Columns.Clear(); //Remover as colunas
                    //GridView1.Rows.clear; //Remover as linhas
                    GridView1.DataBind();//Para a grid se actualizar


                    //define que as colunas não serão geradas automaticamente
                    GridView1.AutoGenerateColumns = false;

                    //define e realiza a formatação de cada coluna
                    BoundField coluna1 = new BoundField();

                    coluna1.DataField = "codigo";
                    coluna1.HeaderText = "Código";
                    GridView1.Columns.Add(coluna1);

                    BoundField coluna2 = new BoundField();

                    coluna2.DataField = "nome";
                    coluna2.HeaderText = "Curso";
                    GridView1.Columns.Add(coluna2);

                    populagrid();
                }
                else
                {

                    objCurso.codigo = TextBoxCodigo.Text;

                    List<Curso> objRetConsultaCurso = objNegocio.consulta(objCurso.codigo);
                    if (objRetConsultaCurso.Count > 0)
                    {
                        TextBoxCargaHoraria.Text = objRetConsultaCurso[0].cargaHoraria;
                        TextBoxNome.Text = objRetConsultaCurso[0].nomeCurso;
                    }
                    else
                    {
                        LabelMsg.Text = "Registro não encontrado.";
                    }
                }



            }
            catch (Exception ex)
            {
                LabelMsg.Text = ex.Message;
            }
       }

        private void populagrid()
        {


            BDCurso objDados = new BDCurso();
            ConnectionManager objconexao = new ConnectionManager();

            GridView1.DataSource = objconexao.retornarTabelaPainel("select codigo,nome from curso order by nome");
            GridView1.DataBind();

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            NgCurso objNegocio = new NgCurso();
            Curso objCurso = new Curso();
            limparLabelMsg();

            try
            {
                objCurso.nomeCurso = TextBoxNome.Text;
                objCurso.cargaHoraria = TextBoxCargaHoraria.Text;
                objCurso.codigo = TextBoxCodigo.Text;

                LabelMsg.Text = (objNegocio.alterar(objCurso) ? "Alteração efetuada com sucesso" : "Erro na alteração.");
            }
            catch (Exception ex)
            {
                LabelMsg.Text = ex.Message;
                
            }
        }

        protected void ButtonExcluir_Click(object sender, EventArgs e)
        {
            NgCurso objNegocio = new NgCurso();
            Curso objCurso = new Curso();
            limparLabelMsg();
            NgPainel objNegocioPainel = new NgPainel();

           


            try
            {

                objCurso.codigo = TextBoxCodigo.Text;
                List<Painel> objRetPainel = objNegocioPainel.testeExcluirDisciplina(objCurso.codigo);
                if (objRetPainel.Count > 0)
                {
                    LabelMsg.Text = "Erro na exclusão. Antes de realizar essa operação, voce deve excluir o painel onde este curso se encontra cadastrado.";
                }
                else
                {

                    LabelMsg.Text = (objNegocio.excluir(objCurso) ?
                    "Registro Excluido com sucesso" : "Erro na exclusão. Verifique o codigo ou se este curso se encontra cadastrado nos outros sistemas.");
                }

            }
            catch (Exception ex)
            {
                LabelMsg.Text = ex.Message;
               
            }

        }

        private void limparLabelMsg()
        {
            if (LabelMsg.Text != "")
            {
                LabelMsg.Text = string.Empty;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NgCurso objNegocio = new NgCurso();

            List<Curso> objRetConsultaCurso = objNegocio.consulta(GridView1.SelectedRow.Cells[1].Text);
            if (objRetConsultaCurso.Count > 0)
            {
                TextBoxCodigo.Text = objRetConsultaCurso[0].codigo;
                TextBoxCargaHoraria.Text = objRetConsultaCurso[0].cargaHoraria;
                TextBoxNome.Text = objRetConsultaCurso[0].nomeCurso;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            populagrid();
        }


    }
}