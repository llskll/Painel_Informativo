using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CamadaMetaDado;
using CamadaDados;
using CamadaNegocio;
using System.Collections;

namespace CamadaInterface
{
    public partial class CadastroProfessor : System.Web.UI.Page
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

        protected void ButtonIncluir_Click(object sender, EventArgs e)
        {
            try
            {

                NGFuncionario objNegocio = new NGFuncionario();
                Funcionario objFuncionario = new Funcionario();
                limparLabelMsg();

                objFuncionario.matricula = TextBoxMatricula.Text;
                List<Funcionario> objRetConsultaFuncionario = objNegocio.consulta(objFuncionario.matricula);

                if (objRetConsultaFuncionario.Count > 0)
                {
                    LabelMsg.Text = "Funcionario ja cadastrado.";
                }

                else
                {
                    objFuncionario.nome = TextBoxNomeFuncionario.Text;
                    objFuncionario.matricula = TextBoxMatricula.Text;
                    objFuncionario.cargo = DropDownListCargo.Text;
                    objFuncionario.turno = DropDownListTurno.Text;
                    objFuncionario.telefone = TextBoxTelefone.Text;
                    objFuncionario.email = TextBoxEmail.Text;
                    objFuncionario.endereco = TextBoxEndereco.Text;
                    objFuncionario.RG = TextBoxRG.Text;
                    objFuncionario.CPF = TextBoxCPF.Text;
                    objFuncionario.sexo = DropDownListSexo.Text;

                    LabelMsg.Text = (objNegocio.incluir(objFuncionario) ? "Cadastro efetuado com sucesso" : "Erro no cadastro.");
                }




            }

            catch (Exception ex)
            {
                LabelMsg.Text = ex.Message;

            }
        }

        protected void ButtonConsultar_Click(object sender, EventArgs e)
        {
            NGFuncionario objNegocio = new NGFuncionario();
            Funcionario objFuncionario = new Funcionario();
            limparLabelMsg();
            try
            {

                if (TextBoxMatricula.Text == "")
                {
                    GridView1.DataSource = null; //Remove a datasource
                    GridView1.Columns.Clear(); //Remove as colunas
                    //GridView1.Rows.clear; //Remove as linhas
                    GridView1.DataBind();//Para a grid se atualizar


                    //define que as colunas não serão geradas automaticamente
                    GridView1.AutoGenerateColumns = false;

                    //define e realiza a formatação de cada coluna
                    BoundField coluna1 = new BoundField();

                    coluna1.DataField = "matricula";
                    coluna1.HeaderText = "Matricula";
                    GridView1.Columns.Add(coluna1);

                    BoundField coluna2 = new BoundField();

                    coluna2.DataField = "nome";
                    coluna2.HeaderText = "Nome";
                    GridView1.Columns.Add(coluna2);

                    BoundField coluna3 = new BoundField();

                    coluna3.DataField = "cargo";
                    coluna3.HeaderText = "Cargo";
                    GridView1.Columns.Add(coluna3);



                    populagrid();
                }
                else
                {
                    objFuncionario.matricula = TextBoxMatricula.Text;

                    List<Funcionario> objRetConsultaFuncionario = objNegocio.consulta(objFuncionario.matricula);

                    if (objRetConsultaFuncionario.Count > 0)
                    {
                        TextBoxNomeFuncionario.Text = objRetConsultaFuncionario[0].nome;
                        DropDownListCargo.SelectedValue = objRetConsultaFuncionario[0].cargo;
                        DropDownListTurno.SelectedValue = objRetConsultaFuncionario[0].turno;
                        TextBoxTelefone.Text = objRetConsultaFuncionario[0].telefone;
                        TextBoxEmail.Text = objRetConsultaFuncionario[0].email;
                        TextBoxEndereco.Text = objRetConsultaFuncionario[0].endereco;
                        TextBoxRG.Text = objRetConsultaFuncionario[0].RG;
                        TextBoxCPF.Text = objRetConsultaFuncionario[0].CPF;
                        DropDownListSexo.SelectedValue = objRetConsultaFuncionario[0].sexo;

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

            BDFuncionario objDados = new BDFuncionario();
            ConnectionManager objconexao = new ConnectionManager();

            GridView1.DataSource = objconexao.retornarTabelaPainel("select matricula,nome,cargo from funcionario");
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            populagrid();
        }

        protected void ButtonAlterar_Click(object sender, EventArgs e)
        {
            NGFuncionario objNegocio = new NGFuncionario();
            Funcionario objFuncionario = new Funcionario();
            limparLabelMsg();

            try
            {
                objFuncionario.matricula = TextBoxMatricula.Text;
                objFuncionario.nome = TextBoxNomeFuncionario.Text;
                objFuncionario.cargo = DropDownListCargo.SelectedValue;
                objFuncionario.turno = DropDownListTurno.SelectedValue;
                objFuncionario.telefone = TextBoxTelefone.Text;
                objFuncionario.email = TextBoxEmail.Text;
                objFuncionario.endereco = TextBoxEndereco.Text;
                objFuncionario.RG = TextBoxRG.Text;
                objFuncionario.CPF = TextBoxCPF.Text;
                objFuncionario.sexo = DropDownListSexo.SelectedValue;


                LabelMsg.Text = (objNegocio.Alterar(objFuncionario) ? "Alteração efetuada com sucesso" : "Erro na alteração.");
            }
            catch (Exception ex)
            {
                LabelMsg.Text = ex.Message;

            }
        }

        protected void ButtonExcluir_Click(object sender, EventArgs e)
        {
            NGFuncionario objNegocio = new NGFuncionario();
            Funcionario objFuncionario = new Funcionario();
            limparLabelMsg();
            NgPainel objNegocioPainel = new NgPainel();

            try
            {
                objFuncionario.matricula = TextBoxMatricula.Text;

                List<Painel> objRetPainel = objNegocioPainel.testeExcluirFuncionario(objFuncionario.matricula);
                if (objRetPainel.Count > 0)
                {
                    LabelMsg.Text = "Erro na exclusão. Antes de realizar essa operação, voce deve excluir o painel onde este funcionário se encontra cadastrado.";
                }
                else
                {
                    LabelMsg.Text = (objNegocio.Excluir(objFuncionario) ? "Registro excluido com sucesso." : "Erro na exclusão. Verifique a matricula ou se este funcionario se encontra cadastrado nos outros sistemas.");
          
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
            limparLabelMsg();
            NGFuncionario objNegocio = new NGFuncionario();

            List<Funcionario> objRetConsultaFuncionario = objNegocio.consulta(GridView1.SelectedRow.Cells[1].Text);

            if (objRetConsultaFuncionario.Count > 0)
            {
                TextBoxMatricula.Text = objRetConsultaFuncionario[0].matricula;
                TextBoxNomeFuncionario.Text = objRetConsultaFuncionario[0].nome;
                DropDownListCargo.SelectedValue = objRetConsultaFuncionario[0].cargo;
                DropDownListTurno.SelectedValue = objRetConsultaFuncionario[0].turno;
                TextBoxTelefone.Text = objRetConsultaFuncionario[0].telefone;
                TextBoxEmail.Text = objRetConsultaFuncionario[0].email;
                TextBoxEndereco.Text = objRetConsultaFuncionario[0].endereco;
                TextBoxRG.Text = objRetConsultaFuncionario[0].RG;
                TextBoxCPF.Text = objRetConsultaFuncionario[0].CPF;
                DropDownListSexo.SelectedValue = objRetConsultaFuncionario[0].sexo;
            }

        }

        protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            populagrid();
        }
    }
}
        
   

