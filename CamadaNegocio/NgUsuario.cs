using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaMetaDado;
using CamadaDados;

namespace CamadaNegocio
{
    public class NgUsuario
    {
        public bool IncluirAluno(Usuario1 p_objUsuario)
        {
            //Campos Obrigatorios
            #region Validação dos campos obrigatorios

            if (p_objUsuario.login == string.Empty)
            {
                throw new Exception("Campo matricula obrigatório.");
            }

            if (p_objUsuario.senha == string.Empty)
            {
                throw new Exception("Campo senha obrigatório.");
            }





            #endregion

            BDUsuario objDados = new BDUsuario();
            return objDados.incluirAluno(p_objUsuario);
        }

        public bool IncluirFuncionario(Usuario1 p_objUsuario)
        {
            //Campos Obrigatorios
            #region Validação dos campos obrigatorios

            if (p_objUsuario.login == string.Empty)
            {
                throw new Exception("Campo matricula obrigatório.");
            }

            if (p_objUsuario.senha == string.Empty)
            {
                throw new Exception("Campo senha obrigatório.");
            }

            if (p_objUsuario.matricula == string.Empty)
            {
                throw new Exception("Campo matricula obrigatório.");
            }



            #endregion

            BDUsuario objDados = new BDUsuario();
            return objDados.incluirFuncionario(p_objUsuario);
        }

        public List<Usuario1> verificarCadastro(string p_login)
        {
            if (p_login == string.Empty)
            {
                throw new Exception("Campo matricula obrigatório.");
            }
            BDUsuario objDados = new BDUsuario();
            return objDados.verificarCadastroBD(p_login);
        }

        public List<Usuario1> logarBD(string p_login,int p_senha)
        {
            if (p_login == string.Empty)
            {
                throw new Exception("Campo login obrigatório.");
            }
            if (p_senha == int.MinValue)
            {
                throw new Exception("Campo senha obrigatório.");
            }

            BDUsuario objDados = new BDUsuario();
            return objDados.logarBD(p_login,p_senha);
        }

        public List<Usuario1> NiveldeAcesso(string p_login)
        {
            BDUsuario objDados = new BDUsuario();
            return objDados.VerificarNiveldeAcesso(p_login);
        }

        public List<Usuario1> VerificarSenha(string p_login,string p_senha)
        {
            if (p_senha == string.Empty)
            {
                throw new Exception("Campo senha atual obrigatório.");
            }

            BDUsuario objDados = new BDUsuario();
            return objDados.VerificarSenha(p_login,p_senha);
        }

        public bool alterar(Usuario1 p_objUsuario)
        {
            if (p_objUsuario.senha == string.Empty)
            {
                throw new Exception("Campo nova senha obrigatório.");


            }
            BDUsuario objDados = new BDUsuario();
            return objDados.Alterar(p_objUsuario);


        }

    }
}
