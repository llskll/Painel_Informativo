using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaMetaDado;

using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class BDPainel
    {
        private ConnectionManager objConnManager = new ConnectionManager();

        public bool incluir(Painel p_objPainel)
        {
            bool blnReturn = false;

            string strSql = "insert into painel (idTurma,idSala,idDisc,matricula,idCurso,codigo) " + 
                "values (@pidTurma,@pidSala,@pidDisciplina,@pmatricula,@pidCurso,@pCodigo)";

            List<SqlParameter> objParams = new List<SqlParameter>();
            objParams.Add(new SqlParameter("@pidTurma", p_objPainel.idTurma));
            objParams.Add(new SqlParameter("@pidSala",p_objPainel.idSala));
            objParams.Add(new SqlParameter("@pidDisciplina",p_objPainel.idDisciplina));
            objParams.Add(new SqlParameter("@pmatricula", p_objPainel.idFuncionario));
            objParams.Add(new SqlParameter("@pidCurso", p_objPainel.idCurso));
            objParams.Add(new SqlParameter("@pCodigo",p_objPainel.codigo));

            blnReturn = objConnManager.executarComando(strSql,objParams);

            return blnReturn;


        }

        public bool excluirPainel(Painel p_objPainel)
        {
            bool blnReturn = false;

            string strSql = "delete from painel where idTurma=@pidTurma and idSala=@pidSala and idDisc=@pidDisciplina and matricula=@pmatricula and idCurso@pidCurso and codigo=@pcodigo)";

            List<SqlParameter> objParams = new List<SqlParameter>();
            objParams.Add(new SqlParameter("@pidTurma", p_objPainel.idTurma));
            objParams.Add(new SqlParameter("@pidSala", p_objPainel.idSala));
            objParams.Add(new SqlParameter("@pidDisciplina", p_objPainel.idDisciplina));
            objParams.Add(new SqlParameter("@pmatricula", p_objPainel.idFuncionario));
            objParams.Add(new SqlParameter("@pidCurso", p_objPainel.idCurso));
            objParams.Add(new SqlParameter("@pcodigo",p_objPainel.codigo));

            blnReturn = objConnManager.executarComando(strSql, objParams);


            return blnReturn;


        }

        public List<Painel> testeExcluirSalaBD(string p_codigo)
        {
            string strSql = "SELECT painel.idSala FROM painel,sala where painel.idSala=sala.idSala and sala.codigo=@pCodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pCodigo", p_codigo));

            DataTable ObjTbCurso =
                objConnManager.retornarTabela(strSql, ObjParams, "Painel");

            List<Painel> objPaineis = new List<Painel>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Painel objPainel = new Painel();
                objPainel.idSala = ((int)row["idsala"]).ToString();

                objPaineis.Add(objPainel);
            }
            return objPaineis;
        }

        public List<Painel> testeExcluirFuncionarioBD(string p_matricula)
        {
            string strSql = "SELECT painel.matricula FROM painel,funcionario where painel.matricula=funcionario.matricula and funcionario.matricula=@pMatricula";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pMatricula", p_matricula));

            DataTable ObjTbCurso =
                objConnManager.retornarTabela(strSql, ObjParams, "Painel");

            List<Painel> objPaineis = new List<Painel>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Painel objPainel = new Painel();
                objPainel.idFuncionario = (string)row["matricula"];

                objPaineis.Add(objPainel);
            }
            return objPaineis;
        }

        public List<Painel> testeExcluirDisciplinaBD(string p_codigo)
        {
            string strSql = "SELECT painel.idDisc FROM painel,disciplina where painel.idDisc=disciplina.idDisc and disciplina.codigo=@pCodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pCodigo", p_codigo));

            DataTable ObjTbCurso =
                objConnManager.retornarTabela(strSql, ObjParams, "Painel");

            List<Painel> objPaineis = new List<Painel>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Painel objPainel = new Painel();
                objPainel.idDisciplina = ((int)row["idDisc"]).ToString();

                objPaineis.Add(objPainel);
            }
            return objPaineis;
        }

        public List<Painel> testeExcluirCursoBD(string p_codigo)
        {
            string strSql = "SELECT painel.idCurso FROM painel,curso where painel.idCurso=curso.idCurso and curso.codigo=@pCodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pCodigo", p_codigo));

            DataTable ObjTbCurso =
                objConnManager.retornarTabela(strSql, ObjParams, "Painel");

            List<Painel> objPaineis = new List<Painel>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Painel objPainel = new Painel();
                objPainel.idCurso = ((int)row["idCurso"]).ToString();

                objPaineis.Add(objPainel);
            }
            return objPaineis;
        }

        public List<Painel> testeExcluirTurmaBD(string p_codigo)
        {
            string strSql = "SELECT painel.idTurma FROM painel,turma where painel.idTurma=Turma.idTurma and Turma.codigo=@pCodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pCodigo", p_codigo));

            DataTable ObjTbCurso =
                objConnManager.retornarTabela(strSql, ObjParams, "Painel");

            List<Painel> objPaineis = new List<Painel>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Painel objPainel = new Painel();
                objPainel.idTurma = ((int)row["idTurma"]).ToString();

                objPaineis.Add(objPainel);
            }
            return objPaineis;
        }

        public List<Painel> verificarCadastroBD(string p_codigo)
        {

            string strSql = "select codigo from painel WHERE codigo= @pcodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pcodigo", p_codigo));

            DataTable ObjTbCurso =
                objConnManager.retornarTabela(strSql, ObjParams, "Painel");

            List<Painel> objPaineis = new List<Painel>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Painel objPainel = new Painel();
                objPainel.codigo = (string)row["codigo"];

                objPaineis.Add(objPainel);
            }
            return objPaineis;
        }

        public List<Painel> ConsultarPainel(string p_codigo)
        {

            string strSql = "select codigo, idSala, idTurma, idCurso, idDisc, matricula from painel where codigo=@pCodigo";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pcodigo", p_codigo));

            DataTable ObjTbCurso =
                objConnManager.retornarTabela(strSql, ObjParams, "Painel");

            List<Painel> objPaineis = new List<Painel>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Painel objPainel = new Painel();
                objPainel.codigo = (string)row["codigo"];
                objPainel.idSala = ((int)row["idSala"]).ToString();
                objPainel.idTurma = ((int)row["idTurma"]).ToString();
                objPainel.idCurso = ((int)row["idCurso"]).ToString();
                objPainel.idDisciplina = ((int)row["idDisc"]).ToString();
                objPainel.idFuncionario = (string)row["matricula"];

                objPaineis.Add(objPainel);
            }
            return objPaineis;
        }

        public bool excluirPainelPorCodigo(string p_codigo)
        {
            bool blnReturn = false;

            string strSql = "delete from painel where codigo=@pCodigo";

            List<SqlParameter> objParams = new List<SqlParameter>();
            objParams.Add(new SqlParameter("@pCodigo", p_codigo));
            

            blnReturn = objConnManager.executarComando(strSql, objParams);


            return blnReturn;


        }

        public bool alterarPainel(Painel p_objPainel)
        {
            bool blnReturn = false;

            string strSql = "update painel set idDisc=@pidDisc, matricula=@pMatricula,idCurso=@pidCurso,idSala=@pidSala,idTurma=@pidTurma where codigo=@pCodigo";

            List<SqlParameter> objParams = new List<SqlParameter>();
            objParams.Add(new SqlParameter("@pCodigo", p_objPainel.codigo));
            objParams.Add(new SqlParameter("@pidDisc", p_objPainel.idDisciplina));
            objParams.Add(new SqlParameter("@pMatricula", p_objPainel.idFuncionario));
            objParams.Add(new SqlParameter("@pidCurso", p_objPainel.idCurso));
            objParams.Add(new SqlParameter("@pidSala", p_objPainel.idSala));
            objParams.Add(new SqlParameter("@pidTurma", p_objPainel.idTurma));


            blnReturn = objConnManager.executarComando(strSql, objParams);


            return blnReturn;


        }


    }
}
