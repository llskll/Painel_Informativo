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
    public partial class CadastroSala : System.Web.UI.Page
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

        protected void ButtonIncluirsala_Click(object sender, EventArgs e)
        {
            limparLabelMsg();

            try
            {
            NgSala objNegocio = new NgSala();
            Sala objSala = new Sala();
            objSala.nomeSala = TextBoxNomeSala.Text;
            objSala.codigo = TextBoxCodigo.Text;


            List<Sala> objRetConsultaSala = objNegocio.verificarCadastro(objSala.codigo);
            if (objRetConsultaSala.Count > 0)
            {
                LabelMsg.Text = "Sala ja cadastrada.";
            }
            else
            {
                objSala.nomeSala = TextBoxNomeSala.Text;
                objSala.codigo = TextBoxCodigo.Text;

                LabelMsg.Text = (objNegocio.incluir(objSala) ? "Cadastro efetuado com sucesso" : "Erro no cadastro");
            }

          

            }
            catch(Exception ex)
            {
                LabelMsg.Text = ex.Message;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            NgSala objNegocio = new NgSala();
            Sala objSala = new Sala();
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
                    coluna1.HeaderText = "Codigo";
                    GridView1.Columns.Add(coluna1);

                    BoundField coluna2 = new BoundField();

                    coluna2.DataField = "nome";
                    coluna2.HeaderText = "Sala";
                    GridView1.Columns.Add(coluna2);



                    populagrid();

                }
                else
                {
                    objSala.codigo = TextBoxCodigo.Text;

                    List<Sala> objRetConsultaSala = objNegocio.consulta(objSala.codigo);
                    if (objRetConsultaSala.Count > 0)
                    {
                        TextBoxNomeSala.Text = objRetConsultaSala[0].nomeSala;
                        TextBoxCodigo.Text = objRetConsultaSala[0].codigo;

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

            BDSala objDados = new BDSala();
            ConnectionManager objconexao = new ConnectionManager();

            GridView1.DataSource = objconexao.retornarTabelaPainel("select codigo,nome from sala order by nome");
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            populagrid();
        }

        protected void ButtonAlterar_Click(object sender, EventArgs e)
        {
            NgSala objNegocio = new NgSala();
            Sala objSala = new Sala();
            limparLabelMsg();

            try
            {
                objSala.codigo = TextBoxCodigo.Text;
                objSala.nomeSala = TextBoxNomeSala.Text;

                LabelMsg.Text = (objNegocio.alterar(objSala) ? "Alteração efetuada com sucesso" : "Erro na alteração.");


            }
            catch (Exception ex)
            {
                LabelMsg.Text = ex.Message;
                
            }
        }

        protected void ButtonExcluir_Click(object sender, EventArgs e)
        {
            limparLabelMsg();
            NgSala objNegocio = new NgSala();
            Sala objSala = new Sala();
            NgPainel objNegocioPainel = new NgPainel();


            try
            {
                objSala.codigo = TextBoxCodigo.Text;

                List<Painel> objRetPainel = objNegocioPainel.testeExcluirSala(objSala.codigo);
                if (objRetPainel.Count > 0)
                {
                    LabelMsg.Text = "Erro na exclusão. Antes de realizar essa operação, voce deve excluir o painel onde esta sala se encontra cadastrada.";
                }
                else
                {


                    LabelMsg.Text = (objNegocio.excluir(objSala) ? "Registro Excluido com sucesso" : "Erro na exclusão. Verifique o código ou se esta sala se encontra cadastrada nos outros sistemas.");
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
            NgSala objNegocio = new NgSala();
            Sala objSala = new Sala();

                     
            List<Sala> objRetConsultaSala = objNegocio.consulta(GridView1.SelectedRow.Cells[1].Text);
            if (objRetConsultaSala.Count > 0)
            {
                
                TextBoxCodigo.Text = objRetConsultaSala[0].codigo;
                TextBoxNomeSala.Text = objRetConsultaSala[0].nomeSala;

            }

        }

      
   
    
    
    }
}