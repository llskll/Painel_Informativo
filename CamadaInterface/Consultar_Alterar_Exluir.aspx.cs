using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaDados;
using System.Data;
using System.Data.SqlClient;
using CamadaMetaDado;
using CamadaNegocio;
using System.Collections;

namespace CamadaInterface
{
    public partial class Consultar_Alterar_Exluir : System.Web.UI.Page
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

        protected void ButtonConsultar_Click(object sender, EventArgs e)
        {
            limparLabelMsg();
           
            string y = DropDownDsemana.SelectedValue;
            


          
            #region METODO SEM TURNO
            //if (DropDownTurno.SelectedValue == null || DropDownTurno.SelectedValue == "")
            //{
            //    GridView1.DataSource = null; //Remove a datasource
            //    GridView1.Columns.Clear(); //Remove as colunas
            //    //GridView1.Rows.clear; //Remove as linhas
            //    GridView1.DataBind();//Para a grid se atualizar


            //    //define que as colunas não serão geradas automaticamente
            //    GridView1.AutoGenerateColumns = false;

            //    //define e realiza a formatação de cada coluna
            //    BoundField coluna1 = new BoundField();

            //    coluna1.DataField = "painel";
            //    coluna1.HeaderText = "Código";
            //    GridView1.Columns.Add(coluna1);

            //    BoundField coluna2 = new BoundField();

            //    coluna2.DataField = "sala";
            //    coluna2.HeaderText = "Sala";
            //    GridView1.Columns.Add(coluna2);

            //    BoundField coluna3 = new BoundField();

            //    coluna3.DataField = "turma";
            //    coluna3.HeaderText = "Turma";
            //    GridView1.Columns.Add(coluna3);

            //    BoundField coluna4 = new BoundField();

            //    coluna4.DataField = "professor";
            //    coluna4.HeaderText = "Professor";
            //    GridView1.Columns.Add(coluna4);

            //    BoundField coluna5 = new BoundField();

            //    coluna5.DataField = "curso";
            //    coluna5.HeaderText = "Curso";
            //    GridView1.Columns.Add(coluna5);

            //    BoundField coluna6 = new BoundField();

            //    coluna6.DataField = "disciplina";
            //    coluna6.HeaderText = "Disciplina";
            //    GridView1.Columns.Add(coluna6);

                
            //    BoundField coluna7 = new BoundField();

            //    coluna7.DataField = "turno";
            //    coluna7.HeaderText = "Turno";
            //    GridView1.Columns.Add(coluna7);

            //    populagridComData(auxFim);

            //}
            #endregion
                GridView1.DataSource = null; //Remove a datasource
                GridView1.Columns.Clear(); //Remove as colunas
                //GridView1.Rows.clear; //Remove as linhas
                GridView1.DataBind();//Para a grid se atualizar


                //define que as colunas não serão geradas automaticamente
                GridView1.AutoGenerateColumns = true;


                populagridComDataETurno(y, DropDownTurno.SelectedValue);
                
            
        }


        #region METODO SEM TURNO
        //private void populagridComData(string data)
        //{
        //    BDPainel objDados = new BDPainel();
        //    ConnectionManager objconexao = new ConnectionManager();

        //    GridView1.DataSource = objconexao.retornarTabelaPainel("select painel.codigo as painel, sala.nome as sala, turma.codigo as turma, painel.turno as turno, curso.nome as curso, disciplina.nomeDisciplina as disciplina, funcionario.nome as professor from painel,sala,turma,curso,disciplina,funcionario where painel.data='" + data + "' and painel.idSala=sala.idsala and painel.idTurma=turma.idTurma and painel.idCurso=curso.idCurso and painel.idDisc=disciplina.idDisc and painel.matricula=funcionario.matricula");
        //    GridView1.DataBind();

        //    //if (dados == null)
        //    //{
        //    //    LabelMsg.Text = "Nenhum painel cadastrado no dia " + data + ".";
          
        //    //}
        //    //else
        //    //{
                
        //    //    
        //    //}

        //}
        #endregion

        private void populagridComDataETurno(string data, string turno)
        {
           
            ConnectionManager objconexao = new ConnectionManager();
            DataTable dt = new DataTable();
            
            dt = objconexao.retornarTabelaPainel("select painel.codigo as Painel, sala.nome as Sala, turma.codigo as Turma, curso.nome as Curso, disciplina.nomeDisciplina as Disciplina, funcionario.nome as Professor from painel,sala,turma,curso,disciplina,funcionario where painel.data='" + data + "' and painel.idSala=sala.idsala and painel.idTurma=turma.idTurma and painel.idCurso=curso.idCurso and painel.idDisc=disciplina.idDisc and painel.matricula=funcionario.matricula and painel.turno='" + turno + "'");
            GridView1.DataSource = dt;
            GridView1.DataBind();

            if (dt.Rows.Count>0)
            {
                limparLabelMsg();
               
            }
            else
            {
                LabelMsg.Text = "Nenhum painel cadastrado nessa data e turno.";
                
            }
            

           

        }

       

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataBind();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
           GridView1.EditIndex = -1;
           GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            string y = DropDownDsemana.SelectedValue;
           
            string turno = DropDownTurno.SelectedValue;

            populagridComDataETurno(y, turno);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Painel objMetaDados = new Painel();
            NgPainel objNegocios = new NgPainel();

            objMetaDados.codigo = GridView1.SelectedRow.Cells[1].Text;

            List<Painel> objRetornaConsulta = objNegocios.consultarPainel(objMetaDados.codigo);
            if (objRetornaConsulta.Count > 0)
            {
                TextBoxCodigo.Text = objRetornaConsulta[0].codigo;
                DropDownListSala.SelectedValue = objRetornaConsulta[0].idSala;
                DropDownListTurma.SelectedValue = objRetornaConsulta[0].idTurma;
                DropDownListCurso.SelectedValue = objRetornaConsulta[0].idCurso;
                DropDownListDisciplina.SelectedValue = objRetornaConsulta[0].idDisciplina;
                DropDownListProfessor.SelectedValue = objRetornaConsulta[0].idFuncionario;
            }
            

        }

        protected void ButtonAlterar_Click(object sender, EventArgs e)
        {
            NgPainel objNegocio = new NgPainel();
            Painel objMetaDados = new Painel();

            try
            {
                objMetaDados.codigo = TextBoxCodigo.Text;
                objMetaDados.idSala = DropDownListSala.SelectedValue;
                objMetaDados.idFuncionario = DropDownListProfessor.SelectedValue;
                objMetaDados.idDisciplina = DropDownListDisciplina.SelectedValue;
                objMetaDados.idTurma = DropDownListTurma.SelectedValue;
                objMetaDados.idCurso = DropDownListCurso.SelectedValue;

                LabelMsg.Text = objNegocio.alterarPainel(objMetaDados) ? "Alteração efetuada com sucesso." : "Erro na alteração.";



            }
            catch (Exception ex)
            {
                LabelMsg.Text = ex.Message;
            }
        }


        protected void ButtonExcluir_Click(object sender, EventArgs e)
        {
            Painel objMetaDados = new Painel();
            NgPainel objNegocio = new NgPainel();

            try
            {

                objMetaDados.codigo = TextBoxCodigo.Text;

                LabelMsg.Text = objNegocio.excluirPainelCodigo(objMetaDados.codigo) ? "Registro Excluido com sucesso." : "Erro na exclusão. Verifique o codigo.";
            }
            catch(Exception ex)
            {
                LabelMsg.Text = ex.Message;
            }


        }

        public void limparLabelMsg()
        {
            if (LabelMsg.Text != "")
            {
                LabelMsg.Text = string.Empty;
            }
        }

      


        
        

    }
}