using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaMetaDado;
using CamadaDados;

namespace CamadaNegocio
{
    public class NgAluno
    {
        public bool Incluir(Aluno p_objAluno)
        {
            //Campos Obrigatorios
            #region Validação dos campos obrigatorios

            if (p_objAluno.login == string.Empty)
            {
                throw new Exception("Campo login obrigatório.");
            }

            if (p_objAluno.senha == string.Empty)
            {
                throw new Exception("Campo senha obrigatório.");
            }

            if (p_objAluno.nome == String.Empty)
            {
                throw new Exception("Campo nome obrigatório.");
            }

            if (p_objAluno.matricula == string.Empty)
            {
                throw new Exception("Campo matricula obrigatório.");
            }

            #endregion

            BDAluno objDados = new BDAluno();
            return objDados.incluir(p_objAluno);
        }

        public List<Aluno> consulta(string p_matricula)
        {
            BDAluno objDados = new BDAluno();
            return objDados.consultar(p_matricula);
        }

        public List<Usuario1> alterar(string p_senha)
        {
            if (p_senha == string.Empty)
            {
                throw new Exception("Campo Senha Obrigatório.");

            }

            BDAluno objDados = new BDAluno();
            
            return objDados.Alterar(p_senha);
 
        }

        public bool excluir(Aluno p_objAluno)
        {
            if (p_objAluno.matricula == string.Empty)
            {
                throw new Exception("Campo matricula obrigatório.");
                
            }

            BDAluno objDados = new BDAluno();
            return objDados.excluir(p_objAluno);

        }


    }
}
