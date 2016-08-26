using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaMetaDado;

using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class BDTurma
    {
        private ConnectionManager objConnManager = new ConnectionManager();

        public bool incluir(Turma p_objTurma)
        {
            bool blnRetorno = false;

            string strSql = "insert into Turma(qntDeAlunos,turno,codigo,dataInicio,dataFim,idCurso,diasDaSemana) values (@pqntDeAlunos,@pTurno,@pCodigo,@pdataInicio,@pdataFim,@pidCurso,@pdiasDaSemana)";

            List<SqlParameter> objParams = new List<SqlParameter>();

            objParams.Add(new SqlParameter("@pqntDeAlunos", p_objTurma.qntDeAlunos));
            objParams.Add(new SqlParameter("@pTurno", p_objTurma.turno));
            objParams.Add(new SqlParameter("@pCodigo", p_objTurma.codigo));
            objParams.Add(new SqlParameter("@pdataInicio", p_objTurma.dataInicio));
            objParams.Add(new SqlParameter("@pdataFim", p_objTurma.dataFim));
            objParams.Add(new SqlParameter("@pidCurso", p_objTurma.idCurso));
            objParams.Add(new SqlParameter("pdiasDaSemana", p_objTurma.diaDaSemana));

            blnRetorno = objConnManager.executarComando(strSql, objParams);

            return blnRetorno;
        }

        public List<Turma> consultar(string p_codigo)
        {

            string strSql = "select codigo,qntDeAlunos,turno,dataInicio,dataFim,idCurso,diasDaSemana from turma WHERE codigo= @pcodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pcodigo", p_codigo));

            DataTable ObjTbCurso = 
                objConnManager.retornarTabela(strSql,ObjParams,"Turma");
            
            List<Turma> objCursos = new List<Turma>();

            foreach (DataRow row in  ObjTbCurso.Rows)
            {
                Turma objTurma = new Turma();
                objTurma.codigo = (string)row["codigo"];
                objTurma.qntDeAlunos = (int)row["qntDeAlunos"];
                objTurma.turno = (string)row["turno"];
                objTurma.idCurso = (int)row["idCurso"];
                objTurma.dataInicio = (DateTime)row["dataInicio"];
                objTurma.dataFim = (DateTime)row["dataFim"];
                objTurma.diaDaSemana = (string)row["diasDaSemana"];

                objCursos.Add(objTurma);
            }
            return objCursos;
        }


        

        public bool Alterar(Turma p_objTurma)
        {
            bool blnRetorno = false;

            string strSql = "UPDATE turma set qntDeAlunos=@pqntDeAlunos, turno=@pturno, dataInicio=@pdataInicio, dataFim=@pdataFim, idCurso=@pidCurso, diasDaSemana=@pdiasDaSemana WHERE codigo=@pcodigo";

            List<SqlParameter> objParams = new List<SqlParameter>();

            objParams.Add(new SqlParameter("@pqntDeAlunos", p_objTurma.qntDeAlunos));
            objParams.Add(new SqlParameter("@pTurno", p_objTurma.turno));
            objParams.Add(new SqlParameter("@pdataInicio", p_objTurma.dataInicio));
            objParams.Add(new SqlParameter("@pdataFim", p_objTurma.dataFim));
            objParams.Add(new SqlParameter("@pidCurso", p_objTurma.idCurso));
            objParams.Add(new SqlParameter("@pCodigo", p_objTurma.codigo));
            objParams.Add(new SqlParameter("@pdiasDaSemana", p_objTurma.diaDaSemana));

            blnRetorno = objConnManager.executarComando(strSql, objParams);

            return blnRetorno;


        }

        public bool Excluir(Turma p_objTurma)
        {
            bool blnRetorno = false;

            string strSql = "DELETE from Turma where codigo=@pCodigo";

            List<SqlParameter> objParams = new List<SqlParameter>();
            objParams.Add(new SqlParameter("@pCodigo", p_objTurma.codigo));

            blnRetorno = objConnManager.executarComando(strSql, objParams);

            return blnRetorno;
   
        }

        public DataTable retornaDadosTurma()
        {
            StringBuilder sentencaSQL = new StringBuilder();
            sentencaSQL.Append("select codigo from turma");
           

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

        public List<Turma> verificarCadastroBD(string p_codigo)
        {

            string strSql = "select codigo from turma WHERE codigo= @pcodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pcodigo", p_codigo));

            DataTable ObjTbCurso =
                objConnManager.retornarTabela(strSql, ObjParams, "Turma");

            List<Turma> objCursos = new List<Turma>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Turma objTurma = new Turma();
                objTurma.codigo = (string)row["codigo"];

                objCursos.Add(objTurma);
            }
            return objCursos;
        }




    }
}
