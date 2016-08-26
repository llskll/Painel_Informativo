using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CamadaMetaDado;
using CamadaNegocio;
using CamadaDados;
using System.Collections;

namespace CamadaInterface
{
    public partial class CadastroDisciplina : System.Web.UI.Page
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

        protected void ButtonIncluird_Click(object sender, EventArgs e)
        {
            try
            {
                NgDisciplina objNegocio = new NgDisciplina();
                Disciplina objDisciplina = new Disciplina();
                objDisciplina.codigo = TextBoxCodigo.Text;
                limparLabelMsg();

                List<Disciplina> objRetConsultaDisciplina = objNegocio.verificarCadastro(objDisciplina.codigo);
                if (objRetConsultaDisciplina.Count > 0)
                {
                    LabelMsg.Text = "Disciplina ja cadastrada.";
                }
                else
                {

                objDisciplina.nomeDisciplina = TextBoxNomeDisciplina.Text;
                objDisciplina.codigo = TextBoxCodigo.Text;
                objDisciplina.cargaHoraria = TextBoxCargaHoraria.Text;
                objDisciplina.qntDeAulas = int.Parse(TextBoxQntDeAulas.Text.ToString());
                objDisciplina.idCurso = int.Parse(DropDownListCurso.SelectedValue.ToString());
                             

                LabelMsg.Text = (objNegocio.incluir(objDisciplina) ? "Cadastro efetuado com sucesso." : "Erro no cadastro.");

                }
                

            }
            catch (Exception ex)
            {
                LabelMsg.Text = ex.Message;
            }
            
        }

        protected void ButtonConsultar_Click(object sender, EventArgs e)
        {
            NgDisciplina objNegocio = new NgDisciplina();
            Disciplina objDisciplina = new Disciplina();
            limparLabelMsg();

            try
            {
                
                if (TextBoxCodigo.Text == "")
                {
                    GridView1.DataSource = null; //Remove a datasource
                    GridView1.Columns.Clear(); //Remove as colunas
                    //GridView1.Rows.clear; //Remove as linhas
                     GridView1.DataBind();//Para a grid se atualizar
                    

                    //define que as colunas não serão geradas automaticamente
                    GridView1.AutoGenerateColumns = false;

                    //define e realiza a formatação de cada coluna
                    BoundField coluna1 = new BoundField();

                    coluna1.DataField = "codigo";
                    coluna1.HeaderText = "Código";
                    GridView1.Columns.Add(coluna1);

                    BoundField coluna2 = new BoundField();

                    coluna2.DataField = "nomeDisciplina";
                    coluna2.HeaderText = "Disciplina";
                    GridView1.Columns.Add(coluna2);

                    BoundField coluna3 = new BoundField();

                    coluna3.DataField = "nome";
                    coluna3.HeaderText = "Curso";
                    GridView1.Columns.Add(coluna3);

                   
                    
                    populagrid();
                }
                else
                {
                    objDisciplina.codigo = TextBoxCodigo.Text;

                    List<Disciplina> objRetConsultaDisciplina = objNegocio.consulta(objDisciplina.codigo);

                    if (objRetConsultaDisciplina.Count > 0)
                    {
                        TextBoxNomeDisciplina.Text = objRetConsultaDisciplina[0].nomeDisciplina;
                        TextBoxQntDeAulas.Text = objRetConsultaDisciplina[0].qntDeAulas.ToString();
                        TextBoxCargaHoraria.Text = objRetConsultaDisciplina[0].cargaHoraria;
                        TextBoxCodigo.Text = objRetConsultaDisciplina[0].codigo;
                        DropDownListCurso.SelectedValue = objRetConsultaDisciplina[0].idCurso.ToString();


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

            BDDisciplina objDados = new BDDisciplina();
            ConnectionManager objconexao = new ConnectionManager();

            GridView1.DataSource = objconexao.retornarTabelaPainel("select disciplina.codigo,disciplina.nomeDisciplina,curso.nome from disciplina,curso where disciplina.idCurso=Curso.idCurso");
            GridView1.DataBind();

        }



        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            populagrid();
        }

        protected void ButtonExcluir_Click(object sender, EventArgs e)
        {
            NgDisciplina objNegocio = new NgDisciplina();
            Disciplina objDisciplina = new Disciplina();
            limparLabelMsg();
            NgPainel objNegocioPainel = new NgPainel();

            try
            {
                objDisciplina.codigo = TextBoxCodigo.Text;

                List<Painel> objRetPainel = objNegocioPainel.testeExcluirDisciplina(objDisciplina.codigo);
                if (objRetPainel.Count > 0)
                {
                    LabelMsg.Text = "Erro na exclusão. Antes de realizar essa operação, voce deve excluir o painel onde esta disciplina se encontra cadastrada.";
                }
                else
                {
                    //Operador ternario
                    LabelMsg.Text = (objNegocio.excluir(objDisciplina) ?
                    "Registro Excluido com sucesso." : "Erro na exclusão. Verifique o codigo ou se esta disciplina se encontra cadastrada nos outros sistemas.");
                }

            }
            catch (Exception ex)
            {
                LabelMsg.Text = ex.Message;
                
            }

        }

        protected void ButtonAlterar_Click(object sender, EventArgs e)
        {
            NgDisciplina objNegocio = new NgDisciplina();
            Disciplina objDisciplina = new Disciplina();
            limparLabelMsg();

            try
            {
                objDisciplina.nomeDisciplina = TextBoxNomeDisciplina.Text;
                objDisciplina.qntDeAulas = int.Parse(TextBoxQntDeAulas.Text);
                objDisciplina.cargaHoraria = TextBoxCargaHoraria.Text;
                objDisciplina.codigo = TextBoxCodigo.Text;
                objDisciplina.idCurso = int.Parse(DropDownListCurso.SelectedValue.ToString());

                LabelMsg.Text = (objNegocio.alterar(objDisciplina) ? "Alteração efetuada com sucesso" : "Erro na alteração.");
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
            NgDisciplina objNegocio = new NgDisciplina();

            List<Disciplina> objRetConsultaDisciplina = objNegocio.consulta(GridView1.SelectedRow.Cells[1].Text);

            if (objRetConsultaDisciplina.Count > 0)
            {
                TextBoxNomeDisciplina.Text = objRetConsultaDisciplina[0].nomeDisciplina;
                TextBoxQntDeAulas.Text = objRetConsultaDisciplina[0].qntDeAulas.ToString();
                TextBoxCargaHoraria.Text = objRetConsultaDisciplina[0].cargaHoraria;
                TextBoxCodigo.Text = objRetConsultaDisciplina[0].codigo;
                DropDownListCurso.SelectedValue = objRetConsultaDisciplina[0].idCurso.ToString();


            }
        }

        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            populagrid();
        }

    }
}