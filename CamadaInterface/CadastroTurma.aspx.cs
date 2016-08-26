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
    public partial class CadastroTurma : System.Web.UI.Page
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

        protected void ButtonIncluirturma_Click(object sender, EventArgs e)
        {
            try
            {
                NgTurma objNegocio = new NgTurma();
                Turma objTurma = new Turma();
                objTurma.codigo = TextBoxCodigo.Text;
                limparLabelMsg();

                List<Turma> objRetConsultaTurma = objNegocio.consulta(objTurma.codigo);
                if (objRetConsultaTurma.Count > 0)
                {
                    LabelMsg.Text = "Turma ja cadastrada.";
                }
                else
                {
                    objTurma.codigo = TextBoxCodigo.Text;
                    objTurma.turno = DropDownListTurno.SelectedValue.ToString();
                    objTurma.qntDeAlunos = int.Parse(TextBoxQuantAlunos.Text);
                    objTurma.idCurso = int.Parse(DropDownListCurso.SelectedValue.ToString());
                    objTurma.dataInicio = DateTime.Parse(TextBoxDataInicio.Text);
                    objTurma.dataFim = DateTime.Parse(TextBoxDataFim.Text);
                    objTurma.diaDaSemana = DropDownListDiaDaSemana.SelectedValue;

                    LabelMsg.Text = (objNegocio.incluir(objTurma) ? "Cadastro efetuado com sucesso" : "Erro no cadastro.");
                }
               
            }
            catch (Exception ex)
            {
                LabelMsg.Text = ex.Message;
            }
        }

        protected void ButtonAlterar_Click(object sender, EventArgs e)
        {
            NgTurma objNegocio = new NgTurma();
            Turma objTurma = new Turma();
            limparLabelMsg();

            try
            {
                objTurma.codigo = TextBoxCodigo.Text;
                objTurma.turno = DropDownListTurno.SelectedValue.ToString();
                objTurma.qntDeAlunos = int.Parse(TextBoxQuantAlunos.Text);
                objTurma.idCurso = int.Parse(DropDownListCurso.SelectedValue.ToString());
                objTurma.dataInicio = DateTime.Parse(TextBoxDataInicio.Text);
                objTurma.dataFim = DateTime.Parse(TextBoxDataFim.Text);
                objTurma.diaDaSemana = DropDownListDiaDaSemana.SelectedValue;

                LabelMsg.Text = (objNegocio.alterar(objTurma) ? "Alteração efetuada com sucesso" : "Erro na alteração.");
            }
            catch(Exception ex)
                {
                    LabelMsg.Text = ex.Message;
                }
        }

        protected void ButtonConsultar_Click(object sender, EventArgs e)
        {
            NgTurma objNegocio = new NgTurma();
            Turma objTurma = new Turma();
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

                    coluna2.DataField = "nome";
                    coluna2.HeaderText = "Curso";
                    GridView1.Columns.Add(coluna2);

                    BoundField coluna3 = new BoundField();

                    coluna2.DataField = "turno";
                    coluna2.HeaderText = "Turno";
                    GridView1.Columns.Add(coluna3);
                    
                    populagrid();
                }
                else
                {

                    objTurma.codigo = TextBoxCodigo.Text;

                    List<Turma> objRetConsultaTurma = objNegocio.consulta(objTurma.codigo);
                    if (objRetConsultaTurma.Count > 0)
                    {
                        
                        DropDownListTurno.SelectedValue = objRetConsultaTurma[0].turno;
                        DropDownListCurso.SelectedValue = objRetConsultaTurma[0].idCurso.ToString();
                        TextBoxQuantAlunos.Text = objRetConsultaTurma[0].qntDeAlunos.ToString();
                        string x = objRetConsultaTurma[0].dataInicio.ToString();
                        string y = objRetConsultaTurma[0].dataFim.ToString();
                        string auxInicio = x.Substring(0, 10);
                        string auxFim = y.Substring(0, 10);
                        TextBoxDataInicio.Text = auxInicio;
                        TextBoxDataFim.Text = auxFim;
                        DropDownListDiaDaSemana.SelectedValue = objRetConsultaTurma[0].diaDaSemana;
                    }
                    else
                    {
                        LabelMsg.Text = "Registro não encontrado.";
                    }
                }
            }
            catch(Exception ex)
            {
                LabelMsg.Text = ex.Message; 
            }
        }


        private void populagrid()
        {
            
            BDTurma objDados = new BDTurma();
            ConnectionManager objconexao = new ConnectionManager();

            GridView1.DataSource = objconexao.retornarTabelaPainel("select turma.codigo,curso.nome,turma.turno from turma,curso where turma.idCurso=Curso.idCurso");
            GridView1.DataBind();

        }



        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            populagrid();
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            limparLabelMsg();
            NgTurma objNegocio = new NgTurma();
            
            List<Turma> objRetConsultaTurma = objNegocio.consulta(GridView1.SelectedRow.Cells[1].Text);
            if (objRetConsultaTurma.Count > 0)
            {
                TextBoxCodigo.Text = objRetConsultaTurma[0].codigo;
                DropDownListTurno.SelectedValue = objRetConsultaTurma[0].turno;
                DropDownListCurso.SelectedValue = objRetConsultaTurma[0].idCurso.ToString();
                TextBoxQuantAlunos.Text = objRetConsultaTurma[0].qntDeAlunos.ToString();
                string x = objRetConsultaTurma[0].dataInicio.ToString();
                string y = objRetConsultaTurma[0].dataFim.ToString();
                string auxInicio = x.Substring(0, 10);
                string auxFim = y.Substring(0, 10);
                TextBoxDataInicio.Text = auxInicio;
                TextBoxDataFim.Text = auxFim;
                DropDownListDiaDaSemana.SelectedValue = objRetConsultaTurma[0].diaDaSemana;
            }
        }

        protected void ButtonExcluir_Click(object sender, EventArgs e)
        {
            NgTurma objNegocios = new NgTurma();
            Turma objTurma = new Turma();
            limparLabelMsg();
            NgPainel objNegocioPainel = new NgPainel();

            try
            {
                objTurma.codigo = TextBoxCodigo.Text;
                List<Painel> objRetPainel = objNegocioPainel.testeExcluirTurma(objTurma.codigo);
                if (objRetPainel.Count > 0)
                {
                    LabelMsg.Text = "Erro na exclusão. Antes de realizar essa operação, voce deve excluir o painel onde esta turma se encontra cadastrada.";
                }
                else
                {
                    //Operador ternario
                    LabelMsg.Text = (objNegocios.excluir(objTurma) ?
                    "Registro Excluido com sucesso" : "Erro na exclusão. Verifique o codigo ou se esta turma se encontra cadastrada nos outros sistemas.");
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
        

    }
}