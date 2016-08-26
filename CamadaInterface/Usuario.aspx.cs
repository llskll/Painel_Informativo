using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocio;
using CamadaMetaDado;
using CamadaDados;
using System.Web.Security;
using System.Collections;

namespace CamadaInterface
{
    public partial class Usuario : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            
            

            
        }



        protected void ButtonIncluir_Click(object sender, EventArgs e)
        {
                try
                {
                    NgAluno objNegocioAluno = new NgAluno();
                    Aluno objAluno = new Aluno();

                    NGFuncionario objNegocioFuncionario = new NGFuncionario();
                    Funcionario objFuncionario = new Funcionario();

                    NgUsuario objNegocioUsuario = new NgUsuario();
                    Usuario1 objUsuario = new Usuario1();

                    if (DropDownListTipoDeUsuario.SelectedValue.ToString() == "Aluno")
                    {
                        objAluno.matricula = TextBoxMatricula.Text;
                        List<Aluno> objRetornaConsultaAluno = objNegocioAluno.consulta(objAluno.matricula);
                        if (objRetornaConsultaAluno.Count > 0)
                        {
                                LabelNome.Text = objRetornaConsultaAluno[0].nome;
                                objUsuario.login = TextBoxMatricula.Text;
                                objUsuario.senha = TextBoxSenha.Text;
                                objUsuario.idAluno = objRetornaConsultaAluno[0].idAluno;
                                objUsuario.nivel = 1;
                                


                                List<Usuario1> objRetornaConsultaUsuario = objNegocioUsuario.verificarCadastro(objUsuario.login);
                                if (objRetornaConsultaUsuario.Count > 0)
                                {
                                    LabelMsg.Text = "Usuario ja cadastrado";
                                    LabelNomeCompleto.Text = "Nome Completo";
                                }
                                else
                                {
                                    LabelMsg.Text = (objNegocioUsuario.IncluirAluno(objUsuario) ? "Cadastro efetuado com sucesso." : "Erro no Cadastro");
                                    labelLoginENome();
                                }
                            

                        }
                        else
                        {
                            LabelMsg.Text = "Matricula não encontrada.";
                        }

                    }
                    if (DropDownListTipoDeUsuario.SelectedValue.ToString() == "Professor")
                    {
                        objFuncionario.matricula = TextBoxMatricula.Text;
                        List<Funcionario> objRetornaConsultaFuncionario = objNegocioFuncionario.consulta(objFuncionario.matricula);
                        if (objRetornaConsultaFuncionario.Count > 0)
                        {

                            if (DropDownListTipoDeUsuario.SelectedValue.ToString() != objRetornaConsultaFuncionario[0].cargo)
                            {
                                LabelMsg.Text = "Verifique o tipo de usuário";
                            }
                            else
                            {
                                LabelNome.Text = objRetornaConsultaFuncionario[0].nome;
                                objUsuario.login = TextBoxMatricula.Text;
                                objUsuario.senha = TextBoxSenha.Text;
                                objUsuario.matricula = objRetornaConsultaFuncionario[0].matricula;
                                objUsuario.nivel = 2;


                                List<Usuario1> objRetornaConsultaUsuario = objNegocioUsuario.verificarCadastro(objUsuario.login);
                                if (objRetornaConsultaUsuario.Count > 0)
                                {
                                    LabelMsg.Text = "Usuario ja cadastrado";

                                    LabelNomeCompleto.Text = "Nome Completo";
                                }
                                else
                                {
                                    LabelMsg.Text = (objNegocioUsuario.IncluirFuncionario(objUsuario) ? "Cadastro efetuado com sucesso." : "Erro no Cadastro");
                                    labelLoginENome();
                                }

                            }

                        }
                        else
                        {
                            LabelMsg.Text = "Matricula não encontrada.";
                        }

                    }

                    if (DropDownListTipoDeUsuario.SelectedValue.ToString() == "Pedagoga")
                    {
                        objFuncionario.matricula = TextBoxMatricula.Text;
                        List<Funcionario> objRetornaConsultaFuncionario = objNegocioFuncionario.consulta(objFuncionario.matricula);
                        if (objRetornaConsultaFuncionario.Count > 0)
                        {
                            if (DropDownListTipoDeUsuario.SelectedValue.ToString() != objRetornaConsultaFuncionario[0].cargo)
                            {

                                LabelMsg.Text = "Verifique o tipo de usuário";
                                
                            }
                            else
                            {
                                LabelNome.Text = objRetornaConsultaFuncionario[0].nome;
                                objUsuario.login = TextBoxMatricula.Text;
                                objUsuario.senha = TextBoxSenha.Text;
                                objUsuario.matricula = objRetornaConsultaFuncionario[0].matricula;
                                objUsuario.nivel = 3;

                                List<Usuario1> objRetornaConsultaUsuario = objNegocioUsuario.verificarCadastro(objUsuario.login);
                                if (objRetornaConsultaUsuario.Count > 0)
                                {
                                    LabelMsg.Text = "Usuario ja cadastrado";
                                    LabelNomeCompleto.Text = "Nome Completo";
                                }
                                else
                                {
                                    LabelMsg.Text = (objNegocioUsuario.IncluirFuncionario(objUsuario) ? "Cadastro efetuado com sucesso." : "Erro no Cadastro");
                                    labelLoginENome();
                                    
                                }

                            }
                        }
                        else
                        {
                            LabelMsg.Text = "Matricula não encontrada.";
                        }

                    }

                    if (DropDownListTipoDeUsuario.SelectedValue.ToString() == "Inspetor")
                    {
                        objFuncionario.matricula = TextBoxMatricula.Text;
                        List<Funcionario> objRetornaConsultaFuncionario = objNegocioFuncionario.consulta(objFuncionario.matricula);
                        if (objRetornaConsultaFuncionario.Count > 0)
                        {
                            if (DropDownListTipoDeUsuario.SelectedValue.ToString() != objRetornaConsultaFuncionario[0].cargo)
                            {
                                LabelMsg.Text = "Verifique o tipo de usuário";
                            }
                            else
                            {
                                LabelNome.Text = objRetornaConsultaFuncionario[0].nome;
                                LabelLogin.Text = objRetornaConsultaFuncionario[0].matricula;
                                objUsuario.login = TextBoxMatricula.Text;
                                objUsuario.senha = TextBoxSenha.Text;
                                objUsuario.matricula = objRetornaConsultaFuncionario[0].matricula;
                                objUsuario.nivel = 4;

                                List<Usuario1> objRetornaConsultaUsuario = objNegocioUsuario.verificarCadastro(objUsuario.login);
                                if (objRetornaConsultaUsuario.Count > 0)
                                {
                                    LabelMsg.Text = "Usuario ja cadastrado";
                                    LabelNomeCompleto.Text = "Nome Completo";
                                }
                                else
                                {
                                    LabelMsg.Text = (objNegocioUsuario.IncluirFuncionario(objUsuario) ? "Cadastro efetuado com sucesso." : "Erro no Cadastro");
                                    labelLoginENome();
                                }

                            }
                        }
                        else
                        {
                            LabelMsg.Text = "Matricula não encontrada.";
                        }

                    }

                    if (DropDownListTipoDeUsuario.SelectedValue.ToString() == "Secretária")
                    {
                        objFuncionario.matricula = TextBoxMatricula.Text;
                        List<Funcionario> objRetornaConsultaFuncionario = objNegocioFuncionario.consulta(objFuncionario.matricula);
                        if (objRetornaConsultaFuncionario.Count > 0)
                        {
                            if (DropDownListTipoDeUsuario.SelectedValue.ToString() != objRetornaConsultaFuncionario[0].cargo)
                            {

                                LabelMsg.Text = "Verifique o tipo de usuário";

                            }
                            else
                            {
                                LabelNome.Text = objRetornaConsultaFuncionario[0].nome;
                                objUsuario.login = TextBoxMatricula.Text;
                                objUsuario.senha = TextBoxSenha.Text;
                                objUsuario.matricula = objRetornaConsultaFuncionario[0].matricula;
                                objUsuario.nivel = 5;

                                List<Usuario1> objRetornaConsultaUsuario = objNegocioUsuario.verificarCadastro(objUsuario.login);
                                if (objRetornaConsultaUsuario.Count > 0)
                                {
                                    LabelMsg.Text = "Usuario ja cadastrado";
                                    LabelNomeCompleto.Text = "Nome Completo";
                                }
                                else
                                {
                                    LabelMsg.Text = (objNegocioUsuario.IncluirFuncionario(objUsuario) ? "Cadastro efetuado com sucesso." : "Erro no Cadastro");
                                    labelLoginENome();

                                }

                            }
                        }
                        else
                        {
                            LabelMsg.Text = "Matricula não encontrada.";
                        }

                    }


                }
                catch (Exception ex)
                {
                    LabelMsg.Text = ex.Message;
                }

            }     

            


    


        protected void ButtonValidar_Click(object sender, EventArgs e)
        {
            
        }

        protected void labelLoginENome()
        {
            LabelNomeCompleto.Text = "Nome Completo";
            Label2.Text = "Login";
            
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            try
            {
                NgUsuario objNegocioUsuario = new NgUsuario();
                Usuario1 objUsuario = new Usuario1();

                List<Usuario1> objRetConsultaUsuario = objNegocioUsuario.logarBD(Login1.UserName, int.Parse(Login1.Password));
                
                //Código para passar a matrícula para a MasterPage
                ArrayList itens = new ArrayList();
                itens.Add(Login1.UserName);
                Session["Lista"] = itens;
                //Fim do código


                if (objRetConsultaUsuario.Count > 0)
                {
                    e.Authenticated = true;
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                    Response.Redirect("VerPainel.aspx");
                }
                else
                {
                    e.Authenticated = false;
                }

            }
            catch (Exception ex)
            {

            }


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton1.Text = "Caso você seja o Usuário do tipo Inspetor,Professor ou Secretária,entre em contato com a Pedagoga.Caso seja Aluno, entre em contato com a Secretária.";
            
        }

    }
}