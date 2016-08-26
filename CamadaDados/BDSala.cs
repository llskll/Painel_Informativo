using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaMetaDado;

using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class BDSala
    {
        private ConnectionManager objConnManager = new ConnectionManager();

        public bool incluir(Sala p_objSala)
        {
            bool blnRetorno = false;

            string strSql = "insert into sala(nome,codigo) values (@pNome,@pCodigo)";

            List<SqlParameter> objParams = new List<SqlParameter>();

            objParams.Add(new SqlParameter("@pNome", p_objSala.nomeSala));
            objParams.Add(new SqlParameter("@pCodigo", p_objSala.codigo));

            blnRetorno = objConnManager.executarComando(strSql, objParams);

            return blnRetorno;
        }

        public List<Sala> consultar(string p_codigo)
        {
 
          string strSql = "select nome,codigo from Sala where codigo=@pCodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pCodigo", p_codigo));

            DataTable ObjTbSala = objConnManager.retornarTabela(strSql,ObjParams,"Sala");

            List<Sala> ObjSalas = new List<Sala>();

            foreach (DataRow row in ObjTbSala.Rows)
            {
                Sala objSala = new Sala();
                objSala.nomeSala  = (string)row["nome"];
                objSala.codigo = (string)row["codigo"];

                ObjSalas.Add(objSala);
            }
            return ObjSalas;
        
        
        }

        public bool Alterar(Sala p_objSala)
        {
            bool blnRetorno = false;

            string strSql = " UPDATE Sala set nome=@pNome WHERE codigo=@pCodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();

            ObjParams.Add(new SqlParameter("@pCodigo", p_objSala.codigo));
            ObjParams.Add(new SqlParameter("@pNome", p_objSala.nomeSala));

            blnRetorno = objConnManager.executarComando(strSql, ObjParams);
            return blnRetorno;


        }

        public bool Excluir(Sala p_objSala)
        {
            bool blnRetorno = false;

            string strSql = "DELETE Sala WHERE codigo=@pCodigo";

            List<SqlParameter> objParams = new List<SqlParameter>();

            objParams.Add(new SqlParameter("@pCodigo", p_objSala.codigo));

            blnRetorno = objConnManager.executarComando(strSql, objParams);
            return blnRetorno;
        }


        public DataTable retornaDadosTurma()
        {
            StringBuilder sentencaSQL = new StringBuilder();
            sentencaSQL.Append("select nome from sala");
            

            try
            {
                DataTable dtTemp; //cria um datatable
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

        public List<Sala> verificarCadastroBD(string p_codigo)
        {

            string strSql = "select codigo from sala WHERE codigo= @pCodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pCodigo", p_codigo));

            DataTable ObjTbCurso =
                objConnManager.retornarTabela(strSql, ObjParams, "Sala");

            List<Sala> objSalas = new List<Sala>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Sala objSala = new Sala();
                objSala.codigo = (string)row["codigo"];

                objSalas.Add(objSala);
            }
            return objSalas;
        }


    }
}

