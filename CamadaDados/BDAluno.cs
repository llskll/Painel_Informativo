using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaMetaDado;

using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class BDAluno
    {
        //atributo geral da classe de conexao
        private ConnectionManager objConnManager = new ConnectionManager();

        //Metodo de inclusao - Este metodo vem da camada do Interface
        public bool incluir(Aluno p_objAluno) // obtem todos os atributos da classe
        {
            bool blnRetorno = false;

            //string de inserir
            string strSql = "insert into Usuario (login,senha) values (@pLogin, @pSenha)";

            List<SqlParameter> objParams = new List<SqlParameter>();
            objParams.Add(new SqlParameter("@pLogin", p_objAluno.login));
            objParams.Add(new SqlParameter("@pSenha", p_objAluno.senha));

            blnRetorno = objConnManager.executarComando(strSql, objParams);


            return blnRetorno;


        }

        //Validar
        public List<Aluno> consultar(string p_matricula)
        {
            string strSql = "select nome,idAluno from aluno where matricula=@p_matricula";

            List<SqlParameter> objParams = new List<SqlParameter>();

            objParams.Add(new SqlParameter("@p_matricula", p_matricula));

            DataTable objTbAluno = objConnManager.retornarTabela(strSql, objParams, "Aluno");

            List<Aluno> objAlunos = new List<Aluno>();

            foreach (DataRow row in objTbAluno.Rows)
            {

                Aluno objAluno = new Aluno();
                objAluno.nome = (string)row["nome"];
                objAluno.idAluno = (int)row["idAluno"];

                objAlunos.Add(objAluno);

            }

            return objAlunos;

        }

        public List<Aluno> consultarNomeMatricula(string p_matricula)
        {
            string strSql = "select matricula, nome from aluno order by idAluno";

            List<SqlParameter> objParams = new List<SqlParameter>();

            DataTable objTbAluno = objConnManager.retornarTabela(strSql, objParams, "Aluno");

            List<Aluno> objAlunos = new List<Aluno>();

            foreach (DataRow row in objTbAluno.Rows)
            {
                Aluno objAluno = new Aluno();

                objAluno.matricula = (string)row["matricula"];
                objAluno.nome = (string)row["nome"];
                objAlunos.Add(objAluno);




            }

            return objAlunos;

        }

        public List<Usuario1> Alterar(string senha)
        {
            string strSql = "update usuario set senha=@p_senha where senha=@p_senha";

            List<SqlParameter> objParams = new List<SqlParameter>();

            objParams.Add(new SqlParameter("@p_nome", senha));

            DataTable objTbAluno = objConnManager.retornarTabela(strSql, objParams, "Aluno");

            List<Usuario1> objAlunos = new List<Usuario1>();

            foreach (DataRow row in objTbAluno.Rows)
            {
                Aluno objaluno = new Aluno();

                objaluno.nome = (string)row["nome"];

                objAlunos.Add(objaluno);
            }

            return objAlunos;

        }

        public bool excluir(Aluno p_objAluno)
        {
            bool blnRetorno = false;

            string strSql = "DELETE Aluno where matricula=@pmatricula";
                
            List<SqlParameter> objParams= new List<SqlParameter>();

            objParams.Add(new SqlParameter("@pMatricula", p_objAluno.matricula));

            blnRetorno = objConnManager.executarComando(strSql, objParams);

            return blnRetorno;
        
        
        
        }


     
    }
}
