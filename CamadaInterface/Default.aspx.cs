using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CamadaDados;
using CamadaMetaDado;
using CamadaNegocio;

using System.Collections;
using System.Data.SqlClient;
using System.Data;
using CamadaInterface;
using System.Text;

namespace Grid_View
{
    public partial class Default : System.Web.UI.Page
    {
        
        private SqlConnection con = new SqlConnection("Data Source=ALU14024\\SQLEXPRESS;Initial Catalog=SYSO;Persist Security Info=True;User ID=sa;Password=alunolab");
        
       

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

        private ArrayList Paineis
        {

            get
            {

                Object value = this.ViewState["Paineis"];

                if (value == null)
                {

                    value = new ArrayList();

                    this.ViewState["Paineis"] = value;

                }

                return (ArrayList)this.ViewState["Paineis"];

            }

            set
            {

                this.ViewState["Paineis"] = value;

            }

        }

        private ArrayList PaineilValue
        {

            get
            {

                Object value = this.ViewState["PaineilValue"];

                if (value == null)
                {

                    value = new ArrayList();

                    this.ViewState["PaineilValue"] = value;

                }

                return (ArrayList)this.ViewState["PaineilValue"];

            }

            set
            {

                this.ViewState["PaineilValue"] = value;

            }

        }


        private void carregarGridPainel()
        {

            GridView1.DataSource = Paineis;

            GridView1.DataBind();

            

        }

        protected void btAddRecord_Click(object sender, EventArgs e)
        {
            NgPainel objNegocio = new NgPainel();
            Painel objMetaDados = new Painel();
            LabelMsg.Text = string.Empty;
            objMetaDados.codigo = TextBoxCodigo.Text;
            List<Painel> objRetornaPainel = objNegocio.VerificarCadastroBD(objMetaDados.codigo);
            if (objRetornaPainel.Count > 0)
            {
                LabelMsg.Text = "Codigo já cadastrado.";
            }
            else
            {


                //Cria um novo registro

                PainelVO registro = new PainelVO();
                PainelVO painelValor = new PainelVO();
                //atribuiu os valores digitados 

                registro.cod = Convert.ToString(TextBoxCodigo.Text);
                registro.idDisc = Convert.ToString(DropDownDisciplina.SelectedItem);
                registro.idTur = Convert.ToString(DropDownTurma.SelectedItem);
                registro.idCur = Convert.ToString(DropDownCurso.SelectedItem);
                registro.idFun = Convert.ToString(DropDownProfessor.SelectedItem);
                registro.idSal = Convert.ToString(DropDownSala.SelectedItem);
                registro.turn = Convert.ToString(DropDownTurno.SelectedItem);
                registro.dSem = Convert.ToString(DropDownDsemana.SelectedItem);

                painelValor.cod = Convert.ToString(TextBoxCodigo.Text);
                painelValor.idDisc = Convert.ToString(DropDownDisciplina.SelectedValue);
                painelValor.idTur = Convert.ToString(DropDownTurma.SelectedValue);
                painelValor.idCur = Convert.ToString(DropDownCurso.SelectedValue);
                painelValor.idFun = Convert.ToString(DropDownProfessor.SelectedValue);
                painelValor.idSal = Convert.ToString(DropDownSala.SelectedValue);
                painelValor.turn = Convert.ToString(DropDownTurno.SelectedItem);
                painelValor.dSem = Convert.ToString(DropDownDsemana.SelectedItem);
               






                ArrayList _listRegitros = new ArrayList();

                _listRegitros.Add(registro);

                //Percorre todos os items ja adicionados
                //na propriedade paineis para verificar se o registro ja foi adicionado

                for (int i = 0; i <= (Paineis.Count - 1); i++)
                {

                    PainelVO registro1 = (PainelVO)Paineis[i];

                    if (registro.cod.Equals(registro1.cod) && (registro.idDisc.Equals(registro1.idDisc)
                          && (registro.idTur.Equals(registro1.idTur) && (registro.idCur.Equals(registro1.idCur)
                          && (registro.idFun.Equals(registro1.idFun) && (registro.idSal.Equals(registro1.idSal)
                          && (registro.dSem.Equals(registro1.dSem) && (registro.turn.Equals(registro1.turn)))))))))
                    {

                        // Se sim limpa a lista e sai do for.

                        _listRegitros.Clear();

                        break;

                    }
                }

                // Verifica se a list está não está vazia

                if (_listRegitros.Count != 0)
                {

                    // Se sim adiciona o telefone a propriedade

                    // ViewState e carrega o GridTel.

                    Paineis.Add(registro);

                    PaineilValue.Add(painelValor);

                    carregarGridPainel();



                }

                else
                {

                    // Se não mostra mensagem

                    String _message = "window.alert(Telefone já Adicionado.);";

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", _message, true);

                }

                string conex = "Data Source=ALU14024\\SQLEXPRESS;Initial Catalog=SYSO;Persist Security Info=True;User ID=sa;Password=alunolab";
                SqlConnection con = new SqlConnection(conex);

                con.Open();

                // Cria a Transaction

                SqlTransaction tn = con.BeginTransaction();

                int p = 0;

                // Percorre todos os telefones informados e salva um por um

                try
                {


                    SqlCommand cmmd = new SqlCommand();



                    ConnectionManager objConnManager = new ConnectionManager();


                    StringBuilder insertSQL = new StringBuilder();

                    //DropDownSala.SelectedValue = insertSQL.ToString();
                    //DropDownCurso.SelectedValue = insertSQL.ToString();
                    //DropDownTurma.SelectedValue = insertSQL.ToString();
                    //DropDownDisciplina.SelectedValue = insertSQL.ToString();
                    //DropDownProfessor.SelectedValue = insertSQL.ToString();
                    //TextBoxCodigo.Text = insertSQL.ToString();
                    #region comentario insertSQL.Append

                    //insertSQL.Append("insert into painel (idSala,idTurma,idCurso,idDisc,matricula,codigo) values ");

                    //insertSQL.Append("(" + pan.idSal.ToString() + ",");
                    //insertSQL.Append("" + pan.idTur.ToString() + ", ");
                    //insertSQL.Append("" + pan.idCur.ToString() + ", ");
                    //insertSQL.Append("" + pan.idDisc.ToString() + ", ");
                    //insertSQL.Append("" + pan.idFun.ToString() + ", ");
                    //insertSQL.Append("" + pan.cod + " )");

                    //// Adicionas os parâmetros da variávl comando



                    //cmmd.CommandText = insertSQL.ToString();


                    //cmmd.CommandType = CommandType.Text;

                    //cmmd.Connection = con;

                    //cmmd.Transaction = tn;

                    //// Executa o comando

                    //i = cmmd.ExecuteNonQuery();
                    #endregion

                    string strSql = "insert into painel (idTurma,idSala,idDisc,matricula,idCurso,codigo,data,turno) " +
                "values (@pidTurma,@pidSala,@pidDisciplina,@pmatricula,@pidCurso,@pCodigo,@pData,@pTurno)";

                    List<SqlParameter> objParams = new List<SqlParameter>();
                    objParams.Add(new SqlParameter("@pidTurma", DropDownTurma.SelectedValue));
                    objParams.Add(new SqlParameter("@pidSala", DropDownSala.SelectedValue));
                    objParams.Add(new SqlParameter("@pidDisciplina", DropDownDisciplina.SelectedValue));
                    objParams.Add(new SqlParameter("@pmatricula", DropDownProfessor.SelectedValue));
                    objParams.Add(new SqlParameter("@pidCurso", DropDownCurso.SelectedValue));
                    objParams.Add(new SqlParameter("@pCodigo", TextBoxCodigo.Text));
                    objParams.Add(new SqlParameter("@pData",DropDownDsemana.SelectedValue));
                    objParams.Add(new SqlParameter("@pTurno", DropDownTurno.SelectedValue));


                    objConnManager.executarComando(strSql, objParams);


                }

                catch
                {

                    tn.Rollback();

                    con.Close();



                }



                if (p > 0)
                {

                    tn.Commit();

                    con.Close();

                    String _message = "window.alert(Linha Adicionad com Sucesso.);";

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", _message, true);


                }
            }

              }

      

        protected void ButtonSalvar_Click(object sender, EventArgs e)
        {
            string conex = "Data Source=ALU14024\\SQLEXPRESS;Initial Catalog=SYSO;Persist Security Info=True;User ID=sa;Password=alunolab";
            SqlConnection con = new SqlConnection(conex);

            con.Open();

            // Cria a Transaction

            SqlTransaction tn = con.BeginTransaction();

            int i = 0;

            // Percorre todos os telefones informados e salva um por um
            foreach (PainelVO pan in PaineilValue)
            {

                try
                {


                    SqlCommand cmmd = new SqlCommand();



                    ConnectionManager objConnManager = new ConnectionManager();


                    StringBuilder insertSQL = new StringBuilder();

                    //DropDownSala.SelectedValue = insertSQL.ToString();
                    //DropDownCurso.SelectedValue = insertSQL.ToString();
                    //DropDownTurma.SelectedValue = insertSQL.ToString();
                    //DropDownDisciplina.SelectedValue = insertSQL.ToString();
                    //DropDownProfessor.SelectedValue = insertSQL.ToString();
                    //TextBoxCodigo.Text = insertSQL.ToString();
                    #region comentario insertSQL.Append

                    //insertSQL.Append("insert into painel (idSala,idTurma,idCurso,idDisc,matricula,codigo) values ");

                    //insertSQL.Append("(" + pan.idSal.ToString() + ",");
                    //insertSQL.Append("" + pan.idTur.ToString() + ", ");
                    //insertSQL.Append("" + pan.idCur.ToString() + ", ");
                    //insertSQL.Append("" + pan.idDisc.ToString() + ", ");
                    //insertSQL.Append("" + pan.idFun.ToString() + ", ");
                    //insertSQL.Append("" + pan.cod + " )");

                    //// Adicionas os parâmetros da variávl comando



                    //cmmd.CommandText = insertSQL.ToString();


                    //cmmd.CommandType = CommandType.Text;

                    //cmmd.Connection = con;

                    //cmmd.Transaction = tn;

                    //// Executa o comando

                    //i = cmmd.ExecuteNonQuery();
                    #endregion

                    string strSql = "insert into painel (idTurma,idSala,idDisc,matricula,idCurso,codigo) " +
                "values (@pidTurma,@pidSala,@pidDisciplina,@pmatricula,@pidCurso,@pCodigo)";

                    List<SqlParameter> objParams = new List<SqlParameter>();
                    objParams.Add(new SqlParameter("@pidTurma", pan.idTur));
                    objParams.Add(new SqlParameter("@pidSala", pan.idSal));
                    objParams.Add(new SqlParameter("@pidDisciplina", pan.idDisc));
                    objParams.Add(new SqlParameter("@pmatricula", pan.idFun));
                    objParams.Add(new SqlParameter("@pidCurso", pan.idCur));
                    objParams.Add(new SqlParameter("@pCodigo", pan.cod));

                    objConnManager.executarComando(strSql, objParams);


                }

                catch
                {

                    tn.Rollback();

                    con.Close();

                    break;

                }

            }

            if (i > 0)
            {

                tn.Commit();

                con.Close();

                String _message = "window.alert(Linha Adicionad com Sucesso.);";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", _message, true);


            }
        }

       

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {

            

           
            #region teste2
            ImageButton imageButton = sender as ImageButton;

            GridViewRow gvrow = imageButton.NamingContainer as GridViewRow;

            con.Open();
            string nomeArq = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();

            SqlCommand cmd = new SqlCommand("DELETE FROM painel  WHERE codigo = '" + nomeArq + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();

           
            TableCell cell = new TableCell(); //Cria um objeto do tipo TableCell

            cell = (TableCell)imageButton.Parent; //Resgata a célula da tabela do gridview onde esta localizado o controle linkbutton.

            GridViewRow row = (GridViewRow)cell.Parent; //Resgata a linha do gridview onde esta localizado o controle linkbutton

            int index = row.RowIndex; //Resgata o indice da linha selecionada


            #endregion



            Paineis.RemoveAt(index);
            carregarGridPainel();

        }

       

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            #region teste2
            ImageButton imageButton = sender as ImageButton;

            GridViewRow gvrow = imageButton.NamingContainer as GridViewRow;

            con.Open();
            string nomeArq = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();

            SqlCommand cmd = new SqlCommand("DELETE FROM painel  WHERE codigo = '" + nomeArq + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();

            TableCell cell = new TableCell(); //Cria um objeto do tipo TableCell

            cell = (TableCell)imageButton.Parent; //Resgata a célula da tabela do gridview onde esta localizado o controle linkbutton.

            GridViewRow row = (GridViewRow)cell.Parent; //Resgata a linha do gridview onde esta localizado o controle linkbutton

            int index = row.RowIndex; //Resgata o indice da linha selecionada

            

            #endregion



            Paineis.RemoveAt(index);
            PaineilValue.RemoveAt(index);
            carregarGridPainel();
        }

     

        protected void ButtonRegistro_Click(object sender, EventArgs e)
        {
            string conex = "Data Source=ALU14024\\SQLEXPRESS;Initial Catalog=SYSO;Persist Security Info=True;User ID=sa;Password=alunolab";
            SqlConnection con = new SqlConnection(conex);

            con.Open();

            // Cria a Transaction

            SqlTransaction tn = con.BeginTransaction();

            int p = 0;

            // Percorre todos os telefones informados e salva um por um

            try
            {


                SqlCommand cmmd = new SqlCommand();



                ConnectionManager objConnManager = new ConnectionManager();



              
             

                string strSql = "insert into painel (idTurma,idSala,idDisc,matricula,idCurso,codigo) " +
            "values (@pidTurma,@pidSala,@pidDisciplina,@pmatricula,@pidCurso,@pCodigo)";

                List<SqlParameter> objParams = new List<SqlParameter>();
                objParams.Add(new SqlParameter("@pidTurma", DropDownTurma.SelectedValue));
                objParams.Add(new SqlParameter("@pidSala", DropDownSala.SelectedValue));
                objParams.Add(new SqlParameter("@pidDisciplina", DropDownDisciplina.SelectedValue));
                objParams.Add(new SqlParameter("@pmatricula", DropDownProfessor.SelectedValue));
                objParams.Add(new SqlParameter("@pidCurso", DropDownCurso.SelectedValue));
                objParams.Add(new SqlParameter("@pCodigo", TextBoxCodigo.Text));

                objConnManager.executarComando(strSql, objParams);


            }

            catch
            {

                tn.Rollback();

                con.Close();



            }



            if (p > 0)
            {

                tn.Commit();

                con.Close();

                String _message = "window.alert(Linha Adicionad com Sucesso.);";

                Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", _message, true);


            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            carregarGridPainel();
        }

       

        

    
              


            
        }


    }

