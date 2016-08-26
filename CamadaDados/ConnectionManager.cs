using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaDados.Interface;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class ConnectionManager : Iconnect
    {
        //string de conexao
        private string strConnStr = "Data Source=ALU14024\\SQLEXPRESS;Initial Catalog=SYSO;Persist Security Info=True;User ID=sa;Password=alunolab";

        SqlConnection objConn = null;

        public bool conectar()
        {
            objConn = new SqlConnection(strConnStr);

            try 
	     {	 
                objConn.Open();
        
	    	
	     }
	        catch
	    {
                return false;
		
		
	    }
            return true;
        
        
        }

        public bool desconectar()
        {
            try 
	    {	
                if (objConn.State != ConnectionState.Closed)
	            {
                    objConn.Close();
                    objConn.Dispose();
		 
	             }
		
	    }
	        catch (Exception)
	    {
        return false;

		
		
	    }
            return true;
        
        
     }
        public DataTable retornarTabela(string p_strSql, List<SqlParameter> p_objParams, string p_strNomeTabelaRetorno)
        {
            if (!this.conectar())
	        {
                return null;
		 
	        }

            SqlCommand objCmd = new SqlCommand(p_strSql, objConn);

            //os dados ficam armazenados na memoria
            //e para um é adicionado pelo foreach

            foreach (SqlParameter param in p_objParams)
	        {
                objCmd.Parameters.Add(param);
		 
	        }

            SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);

            //representa os dados na memoria

            DataTable ds = new DataTable();

            try 
	        {
	            objAdp.Fill(ds);
            }
	        catch (Exception)
	        {
		
		        return null;
	        }

            //utilizando o dss nao é necessario estar conectador ao banco

            this.desconectar();
            return ds;
        
        }

        public bool executarComando(string p_strSql, List<SqlParameter> p_objParams)
        {
            bool blnResult = false;

            if (!this.conectar())
	        {
                return false;

		 
	        }

            SqlCommand objCmd = new SqlCommand(p_strSql, objConn);

            foreach (SqlParameter param in p_objParams)
	        {
                objCmd.Parameters.Add(param);
		 
	        }

            try 
	        {
	            //condicao = verdadeira ou false
                //operador ternario = se for>0 ? verdadeiro
                blnResult = (objCmd.ExecuteNonQuery() > 0 ? true : false);

		
	        }
	        catch (Exception)
	        {
                blnResult = false;
		
		
	        }
            this.desconectar();
            return blnResult;
        
        }

        public DataTable retornarTabelaPainel(string p_strSql)
        {
            if (!this.conectar())
            {
                return null;

            }

            SqlCommand objCmd = new SqlCommand(p_strSql, objConn);

            //os dados ficam armazenados na memoria
            //e para um é adicionado pelo foreach



            SqlDataAdapter objAdp = new SqlDataAdapter(objCmd);

            //representa os dados na memoria

            DataTable ds = new DataTable();

            try
            {
                objAdp.Fill(ds);
            }
            catch (Exception)
            {

                return null;
            }

            //utilizando o dss nao é necessario estar conectador ao banco

            this.desconectar();
            return ds;

        }

        public DataTable directQuery(string p_strSql)
        {
            if (!this.conectar())
            {
                return null;

            }

            DataTable data = new DataTable("Turma"); // Cria table com os dados vindos do BD
            try
            {
                try
                {
                    SqlCommand objCmd = new SqlCommand(p_strSql, objConn);

                    // objCmd.Open(); // Abre a conexão com BD

                    SqlDataAdapter adaptador = new SqlDataAdapter(objCmd);

                    adaptador.Fill(data); // Preenche a tabela
                }
                catch { }
            }
            finally
            {
                this.desconectar(); // Fecha conexão
            }
            return data; // Retorna um datatable com todos dados      
        }

    }
}
