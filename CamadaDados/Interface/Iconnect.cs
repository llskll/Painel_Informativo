using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
      
//referencias SQL
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Interface
{
   public interface Iconnect
    {
      //Responsavel pelos acessos ao BD
    
   
        bool conectar();
        bool desconectar();

        // p_strSql - comando do sql
        // SQLParameter - List de parametros

        //Consulta
        DataTable retornarTabela(string p_strSQL, List<SqlParameter> p_objParams, string p_strNomeTabelaRetorno);

       //Inclusão,alteração e exclusão
        bool executarComando(string p_strSql, List<SqlParameter> p_objParams);


    }
}
