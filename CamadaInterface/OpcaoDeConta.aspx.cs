using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaMetaDado;
using CamadaNegocio;
using System.Collections;

namespace CamadaInterface
{
    public partial class OpcaoDeConta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonTrocarSenha_Click(object sender, EventArgs e)
        {
            NgUsuario objNegocio = new NgUsuario();
            Usuario1 objMetaDados = new Usuario1();
            ArrayList itens = (ArrayList)Session["Lista"];
            string Matricula = itens[0].ToString();

            objMetaDados.login = Matricula;
            objMetaDados.senha = TextBoxAtual.Text;



            try
            {

                List<Usuario1> objRetornaUsuario = objNegocio.VerificarSenha(objMetaDados.login, objMetaDados.senha);
                if (objRetornaUsuario.Count > 0)
                {
                    //alterar
                    objMetaDados.senha = TextBoxNovaSenha.Text;
                    LabelMsg.Text = (objNegocio.alterar(objMetaDados) ? "Senha Alterada com sucesso" : "Erro na alteração");
                    

                    
                }
                else
                {
                    LabelMsg.Text = "Senha atual incorreta";
                }

            }
            catch(Exception ex)
            {
                LabelMsg.Text = ex.Message;
            }
        }
    }
}