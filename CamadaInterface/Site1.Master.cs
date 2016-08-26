    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CamadaNegocio;
using CamadaMetaDado;
using System.Collections;

namespace CamadaInterface
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NgUsuario objNegocioUsuario = new NgUsuario();
            Usuario1 objUsuario = new Usuario1();

            ArrayList itens = (ArrayList)Session["Lista"];
            string Matricula = itens[0].ToString();
            Label1.Text = Matricula;

            List<Usuario1> objRetConsultaUsuario2 = objNegocioUsuario.NiveldeAcesso(Matricula);

            int NivelDeAcesso = objRetConsultaUsuario2[0].nivel;
            //string urlAcessada = Response.req();
            //if(NivelDeAcesso==1 and Response.Request("CadastroTurma.aspx")==true)
            //{

            //}

            
            if (NivelDeAcesso == 1)
            {
                //Redirecionamento para o aluno
                Menu1.Items[1].Enabled = false;
                Menu1.Items[2].Enabled = false;
                Menu1.Items[3].Enabled = false;
                Menu1.Items[4].Enabled = false;
                Menu1.Items[5].Enabled = false;
                Menu1.Items[6].Enabled = false;
                Menu1.Items[7].Enabled = false;

                
                
            }

            if (NivelDeAcesso == 2)
            {
                //Redirecionamento para o professor
                Menu1.Items[1].Enabled = false;
                Menu1.Items[2].Enabled = false;
                Menu1.Items[3].Enabled = false;
                Menu1.Items[4].Enabled = false;
                Menu1.Items[5].Enabled = false;
                Menu1.Items[6].Enabled = false;
                Menu1.Items[7].Enabled = false;
                
            }

            if (NivelDeAcesso == 3)
            {
                //Redirecionamento para o pedagoga
                Menu1.Items[1].Enabled = false;
                Menu1.Items[2].Enabled = false;
                Menu1.Items[3].Enabled = false;
                Menu1.Items[4].Enabled = false;
                Menu1.Items[5].Enabled = false;
                Menu1.Items[6].Enabled = false;
                Menu1.Items[7].Enabled = false;

            }

            if (NivelDeAcesso == 4)
            {
                //Redirecionamento para o inspetor
                //Total acesso aos itens do menu
            }

            if (NivelDeAcesso == 5)
            {
                //Redirecionamento para o secretária
                Menu1.Items[0].Enabled = false;
                Menu1.Items[1].Enabled = false;
                Menu1.Items[2].Enabled = false;
                Menu1.Items[3].Enabled = false;
                Menu1.Items[4].Enabled = false;
                Menu1.Items[5].Enabled = false;
                Menu1.Items[6].Enabled = false;
                Menu1.Items[7].Enabled = false;
            }
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Response.Redirect("Usuario.aspx");
        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Response.Redirect("Usuario.aspx");
        }

        protected void LinkButtonOpcoesDeConta_Click(object sender, EventArgs e)
        {
            Response.Redirect("OpcaoDeConta.aspx");
        }
    }
}