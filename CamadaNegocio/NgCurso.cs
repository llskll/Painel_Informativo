using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaMetaDado;
using CamadaDados;

namespace CamadaNegocio
{
    public class NgCurso
    {
        public bool incluir(Curso p_objCurso)
        {

          
            #region validação dos campos obrigatorios

                if (p_objCurso.nomeCurso == string.Empty)
                {
                    throw new Exception("Campo nome obrigatorio");
                }

                if (p_objCurso.codigo == string.Empty)
                {
                    throw new Exception("Campo codigo obrigatorio");
                }

                if (p_objCurso.cargaHoraria == string.Empty)
                {
                    throw new Exception("Campo carga horária obrigatorio");
                }


                #endregion

            BDCurso objDados = new BDCurso();
            return objDados.incluir(p_objCurso);
        }

        public List<Curso> consulta(string p_codigo)
        {
            if (p_codigo == string.Empty)
            {
                throw new Exception("Campo codigo obrigatorio");
            }

            BDCurso objDados = new BDCurso();
            return objDados.consultar(p_codigo);
        }

        public bool alterar(Curso p_objCurso)
        {
            if (p_objCurso.nomeCurso == string.Empty)
	        {
                throw new Exception("Campo nome obrigatório");

	        }
            if (p_objCurso.cargaHoraria == string.Empty)
            {
                throw new Exception("Campo Carga Horária obrigatório");

            }

            BDCurso objDados = new BDCurso();
            return objDados.alterar(p_objCurso);
     
        }

        public bool excluir(Curso p_objCurso)
        {
            if (p_objCurso.codigo == string.Empty)
	        {
                throw new Exception("Campo codigo obrigatório");
		 
	        }

           BDCurso objDados = new BDCurso();
            return objDados.excluir(p_objCurso);
        }

        public List<Curso> verificarCadastro(string p_codigo)
        {
            if (p_codigo == string.Empty)
            {
                throw new Exception("Campo código obrigatorio");
            }

            BDCurso objDados = new BDCurso();
            return objDados.verificarCadastroBD(p_codigo);
        }


    }
}
