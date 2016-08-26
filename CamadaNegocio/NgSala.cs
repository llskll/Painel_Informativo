using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaMetaDado;
using CamadaDados;

namespace CamadaNegocio
{
    public class NgSala
    {
        public bool incluir(Sala p_objSala)
        {
            #region Validação de campos obrigatorios

            if (p_objSala.nomeSala == string.Empty)
            {
                throw new Exception("Campo nome obrigatório.");
            }

            if (p_objSala.codigo == string.Empty)
            {
                throw new Exception("Campo codigo obrigatório.");
            }

            #endregion

            BDSala objDados = new BDSala();
            return objDados.incluir(p_objSala);
        }


            
        public List<Sala> consulta(string p_codigo)
         {
            if (p_codigo == string.Empty)
                {
                throw new Exception("Campo nome obrigatorio");
        
                }

                   BDSala objDados = new BDSala();
                   return objDados.consultar(p_codigo);
               }

        public bool alterar(Sala p_objSala) 
        {
            if (p_objSala.codigo == string.Empty)
            {
                throw new Exception("Campo codigo obtrigatório.");

                
            }
            BDSala objDados = new BDSala();
            return objDados.Alterar(p_objSala);

        
        }

        public bool excluir(Sala p_objSala) 
        {
            if (p_objSala.codigo == string.Empty)
            {
                throw new Exception("Campo Codigo Obrigatório.");
            
            }

            BDSala objDados = new BDSala();
            return objDados.Excluir(p_objSala);

        
        
        }

        public List<Sala> verificarCadastro(string p_nome)
        {
            if (p_nome == string.Empty)
            {
                throw new Exception("Campo codigo obrigatorio");
            }
            BDSala objDados = new BDSala();
            return objDados.verificarCadastroBD(p_nome);
        }




    }
}
