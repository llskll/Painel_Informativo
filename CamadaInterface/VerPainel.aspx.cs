using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaDados;
using CamadaNegocio;
using CamadaMetaDado;
using System.Collections;

namespace CamadaInterface
{
    public partial class VerPainel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NgUsuario objNegocio = new NgUsuario();
            Usuario1 objMetaDados = new Usuario1();
            ArrayList itens = (ArrayList)Session["Lista"];
            string Matricula = itens[0].ToString();

            List<Usuario1> objRetConsultaUsuario2 = objNegocio.NiveldeAcesso(Matricula);

            int NivelDeAcesso = objRetConsultaUsuario2[0].nivel;

            if(NivelDeAcesso==5)
            {
                ButtonCarregarPainel.Visible=false;

                DropDownListData.Visible = false;
                DropDownTurno.Visible = false;

            }

           
        }
     

       

      

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            

            string y = DropDownListData.SelectedValue;
        


          
         
            GridView1.DataSource = null; //Remove a datasource
            GridView1.Columns.Clear(); //Remove as colunas
            //GridView1.Rows.clear; //Remove as linhas
            GridView1.DataBind();//Para a grid se atualizar


            //define que as colunas não serão geradas automaticamente
            GridView1.AutoGenerateColumns = false;

           

            BoundField coluna2 = new BoundField();

            coluna2.DataField = "sala";
            coluna2.HeaderText = "Sala";
            GridView1.Columns.Add(coluna2);

            BoundField coluna3 = new BoundField();

            coluna3.DataField = "turma";
            coluna3.HeaderText = "Turma";
            GridView1.Columns.Add(coluna3);


            BoundField coluna5 = new BoundField();

            coluna5.DataField = "curso";
            coluna5.HeaderText = "Curso";
            GridView1.Columns.Add(coluna5);

            BoundField coluna6 = new BoundField();

            coluna6.DataField = "disciplina";
            coluna6.HeaderText = "Disciplina";
            GridView1.Columns.Add(coluna6);

            BoundField coluna7 = new BoundField();

            coluna7.DataField = "professor";
            coluna7.HeaderText = "Professor";
            GridView1.Columns.Add(coluna7);

            populagridComDataETurno(y, DropDownTurno.SelectedValue);
        }

        private void populagridComDataETurno(string data, string turno)
        {

            ConnectionManager objconexao = new ConnectionManager();

            GridView1.DataSource = objconexao.retornarTabelaPainel("select  sala.nome as sala, turma.codigo as turma, curso.nome as curso, disciplina.nomeDisciplina as disciplina, funcionario.nome as professor from painel,sala,turma,curso,disciplina,funcionario where painel.data='" + data + "' and painel.idSala=sala.idsala and painel.idTurma=turma.idTurma and painel.idCurso=curso.idCurso and painel.idDisc=disciplina.idDisc and painel.matricula=funcionario.matricula and painel.turno='" + turno + "'");
            GridView1.DataBind();

          

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            string y = DropDownListData.SelectedValue;
            
            string turno = DropDownTurno.SelectedValue;
            ConnectionManager objconexao = new ConnectionManager();

            GridView1.DataSource = objconexao.retornarTabelaPainel("select  sala.nome as sala, turma.codigo as turma, curso.nome as curso, disciplina.nomeDisciplina as disciplina, funcionario.nome as professor from painel,sala,turma,curso,disciplina,funcionario where painel.data='" + y + "' and painel.idSala=sala.idsala and painel.idTurma=turma.idTurma and painel.idCurso=curso.idCurso and painel.idDisc=disciplina.idDisc and painel.matricula=funcionario.matricula and painel.turno='" + turno + "'");
            GridView1.DataBind();
        }

       
    }
}