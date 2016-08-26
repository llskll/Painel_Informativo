using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaMetaDado;

using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class BDDisciplina
    {
        private ConnectionManager objConnManager = new ConnectionManager();

        public bool incluir(Disciplina p_objDisciplina)
        {
            bool blnRetorno = false;

            string strSql = "insert into disciplina(nomeDisciplina,codigo,qntDeAulas,cargaHoraria,idCurso) values (@pnomeDisciplina,@pcodigo,@pqntDeAulas,@pcargaHoraria,@pidCurso)";

            List<SqlParameter> objParams = new List<SqlParameter>();
            objParams.Add(new SqlParameter("@pnomeDisciplina", p_objDisciplina.nomeDisciplina));
            objParams.Add(new SqlParameter("@pcodigo", p_objDisciplina.codigo));
            objParams.Add(new SqlParameter("@pqntDeAulas", p_objDisciplina.qntDeAulas));
            objParams.Add(new SqlParameter("@pcargaHoraria", p_objDisciplina.cargaHoraria));
            objParams.Add(new SqlParameter("@pidCurso", p_objDisciplina.idCurso));

            blnRetorno = objConnManager.executarComando(strSql, objParams);

            return blnRetorno;
        }

        public List<Disciplina> consultar(string p_codigo)
        {

            string strSql = "select qntDeAulas,nomeDisciplina,codigo,cargaHoraria,idCurso from disciplina WHERE codigo=@pcodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pcodigo", p_codigo));
            

            DataTable ObjTbDisciplina = objConnManager.retornarTabela(strSql,ObjParams,"Disciplina");

            List<Disciplina> ObjDisciplinas = new List<Disciplina>();

            foreach (DataRow row in ObjTbDisciplina.Rows)
            {
                Disciplina objDisciplina = new Disciplina();
                objDisciplina.qntDeAulas = (int)row["qntDeAulas"];
                objDisciplina.nomeDisciplina = (string)row["nomeDisciplina"];
                objDisciplina.codigo = (string)row["codigo"];
                objDisciplina.cargaHoraria = (string)row["cargaHoraria"];
                objDisciplina.idCurso = (int)row["idCurso"];
                objDisciplina.codigo = (string)row["codigo"];

                ObjDisciplinas.Add(objDisciplina);
            }
            return ObjDisciplinas;
        
        
        }

        public bool Alterar(Disciplina p_objDisciplina)
        {
            bool blnRetorno = false;

            string strSql = " UPDATE Disciplina set qntDeAulas=@pqntDeAulas,nomeDisciplina=@pNome,cargaHoraria=@pCargaHoraria,idCurso=@pidCurso WHERE codigo=@pcodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();

            ObjParams.Add(new SqlParameter("@pqntDeAulas", p_objDisciplina.qntDeAulas));
            ObjParams.Add(new SqlParameter("@pNome", p_objDisciplina.nomeDisciplina));
            ObjParams.Add(new SqlParameter("@pCargaHoraria", p_objDisciplina.cargaHoraria));
            ObjParams.Add(new SqlParameter("@pidCurso", p_objDisciplina.idCurso));
            ObjParams.Add(new SqlParameter("@pcodigo", p_objDisciplina.codigo));

            blnRetorno = objConnManager.executarComando(strSql, ObjParams);
            return blnRetorno;


        }

        public bool Excluir(Disciplina p_objDisciplina)
        {
            bool blnRetorno = false;

            string strSql = "DELETE Disciplina WHERE codigo=@pcodigo";

            List<SqlParameter> objParams = new List<SqlParameter>();

            objParams.Add(new SqlParameter("@pCodigo", p_objDisciplina.codigo));

            blnRetorno = objConnManager.executarComando(strSql, objParams);
            return blnRetorno;
        }

        


        public DataTable retornaDadosTurma()
        {
            StringBuilder sentencaSQL = new StringBuilder();
            sentencaSQL.Append("select codigo from disciplina");
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

        public List<Disciplina> verificarCadastroBD(string p_codigo)
        {

            string strSql = "select codigo from disciplina WHERE codigo= @pcodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pcodigo", p_codigo));

            DataTable ObjTbCurso =
                objConnManager.retornarTabela(strSql, ObjParams, "Turma");

            List<Disciplina> objDisciplinas = new List<Disciplina>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Disciplina objDisciplina = new Disciplina();
                objDisciplina.codigo = (string)row["codigo"];

                objDisciplinas.Add(objDisciplina);
            }
            return objDisciplinas;
        }


    }
}
