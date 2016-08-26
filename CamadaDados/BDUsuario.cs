using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaMetaDado;

using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class BDUsuario
    {
        private ConnectionManager objConnManager = new ConnectionManager();

        public bool incluirFuncionario(Usuario1 p_objUsuario) // obtem todos os atributos da classe
        {
            bool blnRetorno = false;

            //string de inserir
            string strSql = "insert into Usuario (login,senha,nivel,matricula) values (@pLogin, @pSenha, @pNivel, @pMatricula)";

            List<SqlParameter> objParams = new List<SqlParameter>();
            objParams.Add(new SqlParameter("@pLogin", p_objUsuario.login));
            objParams.Add(new SqlParameter("@pSenha", p_objUsuario.senha));
            objParams.Add(new SqlParameter("@pNivel", p_objUsuario.nivel));
            objParams.Add(new SqlParameter("@pMatricula", p_objUsuario.matricula));



            blnRetorno = objConnManager.executarComando(strSql, objParams);


            return blnRetorno;


        }

        public bool incluirAluno(Usuario1 p_objUsuario) 
        {
            bool blnRetorno = false;

            //string de inserir
            string strSql = "insert into Usuario (login,senha,nivel,idaluno) values (@pLogin, @pSenha, @pNivel,@pidAluno)";

            List<SqlParameter> objParams = new List<SqlParameter>();
            objParams.Add(new SqlParameter("@pLogin", p_objUsuario.login));
            objParams.Add(new SqlParameter("@pSenha", p_objUsuario.senha));
            objParams.Add(new SqlParameter("@pNivel", p_objUsuario.nivel));
            objParams.Add(new SqlParameter("@pidAluno", p_objUsuario.idAluno));



            blnRetorno = objConnManager.executarComando(strSql, objParams);


            return blnRetorno;


        }

        public List<Usuario1> verificarCadastroBD(string p_codigo)
        {

            string strSql = "select login from usuario WHERE login= @pLogin";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pLogin", p_codigo));

            DataTable ObjTbCurso =
                objConnManager.retornarTabela(strSql, ObjParams, "Usuario");

            List<Usuario1> objUsuarios = new List<Usuario1>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Usuario1 objUsuario = new Usuario1();
                objUsuario.login = (string)row["login"];

                objUsuarios.Add(objUsuario);
            }
            return objUsuarios;
        }

        public List<Usuario1> logarBD(string p_login,int p_senha)
        {

            string strSql = "select login,senha,nivel from usuario WHERE login= @pLogin and senha=@pSenha";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pLogin", p_login));
            ObjParams.Add(new SqlParameter("@pSenha", p_senha));

            DataTable ObjTbCurso = objConnManager.retornarTabela(strSql, ObjParams, "Usuario");

            List<Usuario1> objUsuarios = new List<Usuario1>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Usuario1 objUsuario = new Usuario1();
                objUsuario.login = (string)row["login"];
                objUsuario.senha = (string)row["senha"];
                objUsuario.nivel = (int)row["nivel"];

                objUsuarios.Add(objUsuario);
            }
            return objUsuarios;
        }

        public List<Usuario1> VerificarNiveldeAcesso(string p_login)
        {

            string strSql = "select nivel from usuario WHERE login= @pLogin";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pLogin", p_login));

            DataTable ObjTbCurso = objConnManager.retornarTabela(strSql, ObjParams, "Usuario");

            List<Usuario1> objUsuarios = new List<Usuario1>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Usuario1 objUsuario = new Usuario1();
                objUsuario.nivel = (int)row["nivel"];

                objUsuarios.Add(objUsuario);
            }
            return objUsuarios;
        }

        public List<Usuario1> VerificarSenha(string p_login, string p_senha)
        {

            string strSql = "select login,senha from usuario WHERE login= @pLogin and senha=@pSenha";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pLogin", p_login));
            ObjParams.Add(new SqlParameter("@pSenha", p_senha));

            DataTable ObjTbCurso = objConnManager.retornarTabela(strSql, ObjParams, "Usuario");

            List<Usuario1> objUsuarios = new List<Usuario1>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Usuario1 objUsuario = new Usuario1();
                objUsuario.login = (string)row["login"];
                objUsuario.senha = (string)row["senha"];

                objUsuarios.Add(objUsuario);
            }
            return objUsuarios;
        }

        public bool Alterar(Usuario1 p_objUsuario)
        {
            bool blnRetorno = false;

            string strSql = " UPDATE usuario set senha=@pSenha WHERE login=@pLogin";

            List<SqlParameter> ObjParams = new List<SqlParameter>();

            ObjParams.Add(new SqlParameter("@pLogin", p_objUsuario.login));
            ObjParams.Add(new SqlParameter("@pSenha", p_objUsuario.senha));

            blnRetorno = objConnManager.executarComando(strSql, ObjParams);
            return blnRetorno;


        }
    }
}
