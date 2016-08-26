using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaMetaDado;

using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class BDFuncionario
    {
        private ConnectionManager objConnManager = new ConnectionManager();

        public bool incluir(Funcionario p_objFuncionario) 
        {
            bool blnRetorno = false;

            string strSql = "insert into Funcionario(rg,telefone,endereco,nome,sexo,email,matricula,cpf,turno,cargo) values (@pRg,@pTelefone,@pEndereco,@pNome,@pSexo,@pEmail,@pMatricula,@pCpf,@pTurno,@pCargo)";


            List<SqlParameter> objParams = new List<SqlParameter>();

           


            objParams.Add(new SqlParameter("@pRg", p_objFuncionario.RG));
            objParams.Add(new SqlParameter("@pTelefone", p_objFuncionario.telefone));
            objParams.Add(new SqlParameter("@pEndereco", p_objFuncionario.endereco));
            objParams.Add(new SqlParameter("@pNome", p_objFuncionario.nome));
            objParams.Add(new SqlParameter("@pSexo", p_objFuncionario.sexo));
            objParams.Add(new SqlParameter("@pEmail", p_objFuncionario.email));
            objParams.Add(new SqlParameter("@pMatricula", p_objFuncionario.matricula));
            objParams.Add(new SqlParameter("@pCpf", p_objFuncionario.CPF));
            objParams.Add(new SqlParameter("@pTurno", p_objFuncionario.turno));
            objParams.Add(new SqlParameter("@pCargo", p_objFuncionario.cargo));


            blnRetorno = objConnManager.executarComando(strSql, objParams);

            return blnRetorno;
        }


        public List<Funcionario> verificarCadastroBD(string p_matricula)
        {

            string strSql = "select matricula from funcionario WHERE matricula= @pmatricula";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pmatricula", p_matricula));

            DataTable ObjTbCurso =
                objConnManager.retornarTabela(strSql, ObjParams, "Funcionario");

            List<Funcionario> objCursos = new List<Funcionario>();

            foreach (DataRow row in ObjTbCurso.Rows)
            {
                Funcionario objFuncionario = new Funcionario();
                objFuncionario.matricula = (string)row["matricula"];

                objCursos.Add(objFuncionario);
            }
            return objCursos;
        }


        public List<Funcionario> consultar(string p_matricula)
        {

            string strSql = "select matricula,rg,telefone,endereco,nome,sexo,email,matricula,cpf,turno,cargo from funcionario WHERE matricula= @pmatricula";

            List<SqlParameter> ObjParams = new List<SqlParameter>();
            ObjParams.Add(new SqlParameter("@pmatricula", p_matricula));

            DataTable ObjTbFuncionario =
                objConnManager.retornarTabela(strSql, ObjParams, "Funcionario");

            List<Funcionario> objCursos = new List<Funcionario>();

            foreach (DataRow row in ObjTbFuncionario.Rows)
            {
                Funcionario objFuncionariro = new Funcionario();
                objFuncionariro.RG = (string)row["rg"];
                objFuncionariro.telefone = (string)row["telefone"];
                objFuncionariro.endereco = (string)row["endereco"];
                objFuncionariro.nome = (string)row["nome"];
                objFuncionariro.sexo = (string)row["sexo"];
                objFuncionariro.email = (string)row["email"];
                objFuncionariro.matricula = (string)row["matricula"];
                objFuncionariro.CPF = (string)row["cpf"];
                objFuncionariro.turno = (string)row["turno"];
                objFuncionariro.cargo = (string)row["cargo"];

                objCursos.Add(objFuncionariro);
            }
            return objCursos;
        }


        public DataTable retornaDadosTurma()
        {
            StringBuilder sentencaSQL = new StringBuilder();
            sentencaSQL.Append("select matricula from funcionario");


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

        public bool Alterar(Funcionario p_objFuncionario)
        {
            bool blnRetorno = false;

            string strSql = " UPDATE funcionario set nome=@pNome,Rg=@pRg,Telefone=@pTelefone,endereco=@pEndereco, sexo=@pSexo, email=@pEmail, cpf=@pCpf, turno=@pTurno, cargo=@pCargo where matricula=@pMatricula";

            List<SqlParameter> ObjParams = new List<SqlParameter>();

            ObjParams.Add(new SqlParameter("@pNome", p_objFuncionario.nome));
            ObjParams.Add(new SqlParameter("@pRg", p_objFuncionario.RG));
            ObjParams.Add(new SqlParameter("@pTelefone", p_objFuncionario.telefone));
            ObjParams.Add(new SqlParameter("@pEndereco", p_objFuncionario.endereco));
            ObjParams.Add(new SqlParameter("@pSexo", p_objFuncionario.sexo));
            ObjParams.Add(new SqlParameter("@pEmail", p_objFuncionario.email));
            ObjParams.Add(new SqlParameter("@pCpf", p_objFuncionario.CPF));
            ObjParams.Add(new SqlParameter("@pTurno", p_objFuncionario.turno));
            ObjParams.Add(new SqlParameter("@pCargo", p_objFuncionario.cargo));
            ObjParams.Add(new SqlParameter("@pMatricula", p_objFuncionario.matricula));

            blnRetorno = objConnManager.executarComando(strSql, ObjParams);
            return blnRetorno;


        }

        public bool Excluir(Funcionario p_objFuncionario)
        {
            bool blnRetorno = false;

            string strSql = "DELETE funcionario WHERE matricula=@pMatricula";

            List<SqlParameter> objParams = new List<SqlParameter>();

            objParams.Add(new SqlParameter("@pMatricula", p_objFuncionario.matricula));

            blnRetorno = objConnManager.executarComando(strSql, objParams);
            return blnRetorno;
        }
    }
}
