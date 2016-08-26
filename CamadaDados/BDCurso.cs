using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaMetaDado;

using System.Data;
using System.Data.SqlClient;


namespace CamadaDados
{
    public class BDCurso
    {
        //atributo geral da classe de conexao
        private ConnectionManager objConnManager = new ConnectionManager();

        //Metodo de inclusao - Este metodo vem da camada do Interface
        public bool incluir (Curso p_objCurso) // obtem todos os atributos da classe
        {
            bool blnRetorno = false;

        //string de inserir

        string strSql = "insert into curso(nome,cargaHoraria,codigo) values (@pnome,@pcargaHoraria,@pcodigo)";
        
        List<SqlParameter> objParams = new List<SqlParameter>();
        objParams.Add(new SqlParameter("@pnome", p_objCurso.nomeCurso));
        objParams.Add(new SqlParameter("@pcargaHoraria", p_objCurso.cargaHoraria));
        objParams.Add(new SqlParameter("@pcodigo", p_objCurso.codigo));
        

        blnRetorno = objConnManager.executarComando(strSql, objParams);

        return blnRetorno;

    
        }

        //retornar um determinado curso
        public List<Curso> consultar(string p_codigo)
        {
            //string strSql = "select nome,cargaHoraria,codigo from curso where  order by curso";
            string strSql = "select nome,cargaHoraria,codigo from curso where codigo=@pcodigo";


            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pcodigo", p_codigo));

            DataTable objTbCurso = objConnManager.retornarTabela(strSql, ObjParams, "curso");

            List<Curso> objCursos = new List<Curso>();

            foreach (DataRow row in objTbCurso.Rows)
            {
                Curso objCurso = new Curso();
                objCurso.nomeCurso = (string)row["nome"];
                objCurso.cargaHoraria = (string)row["cargaHoraria"];
                objCurso.codigo = (string)row["codigo"];
                objCursos.Add(objCurso);
            
            
            }

            return objCursos;
        }

        public bool alterar(Curso p_objCurso)
        {
            bool blnRetorno = false;

            string strSql = "UPDATE Curso set nome=@pNome, cargaHoraria=@pCargaHoraria where codigo=@pCodigo";


            List<SqlParameter> ObjParams = new List<SqlParameter>();

            ObjParams.Add(new SqlParameter("@pNome", p_objCurso.nomeCurso));
            ObjParams.Add(new SqlParameter("@pCargaHoraria", p_objCurso.cargaHoraria));
            ObjParams.Add(new SqlParameter("@pCodigo", p_objCurso.codigo));


            blnRetorno = objConnManager.executarComando(strSql, ObjParams);

            return blnRetorno;
        }


        public bool excluir(Curso p_objCurso)
        {
            bool blnRetorno = false;

            string strSql = "DELETE curso where codigo=@pCodigo";

            List<SqlParameter> objParams = new List<SqlParameter>();

            objParams.Add(new SqlParameter("@pCodigo", p_objCurso.codigo));

            blnRetorno = objConnManager.executarComando(strSql, objParams);

            return blnRetorno;
        
        
        
        }
     
        public DataTable retornaDadosTurma()
        {
            StringBuilder sentencaSQL = new StringBuilder();
            sentencaSQL.Append("select codigo from curso");
            //select painel.idturma,turma.nome as Turma from painel,turma where painel.idturma=turma.idturma order by painel.idTurma asc

            try
            {
                DataTable dtTemp; //crio um datatable
                dtTemp = objConnManager.directQuery(sentencaSQL.ToString());

                return dtTemp;
            }
            catch (SqlException ex)
            {
                throw (ex);

            }
            finally
            {
                objConnManager.desconectar();
            }

        }

        public List<Curso> verificarCadastroBD(string p_codigo)
        {
            string strSql = "select codigo from curso where codigo=@pcodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pcodigo", p_codigo));

            DataTable objTbCurso = objConnManager.retornarTabela(strSql, ObjParams, "Curso");

            List<Curso> objCursos = new List<Curso>();

            foreach (DataRow row in objTbCurso.Rows)
            {
                Curso objCurso = new Curso();
                objCurso.codigo = (string)row["codigo"];

                objCursos.Add(objCurso);

            }

            return objCursos;
        }




    }
}
