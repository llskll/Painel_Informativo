using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaDados;
using CamadaMetaDado;

namespace CamadaNegocio
{
    public class NgDisciplina
    {
        public bool incluir(Disciplina p_objDisciplina)
        {
            #region Validação dos campos obrigatorios

            if (p_objDisciplina.nomeDisciplina == string.Empty)
            {
                throw new Exception("Campo nome obrigatório");
            }

            if (p_objDisciplina.codigo == string.Empty)
            {
                throw new Exception("Campo codigo obrigatório");
            }

            if (p_objDisciplina.cargaHoraria == string.Empty)
            {
                throw new Exception("Campo carga horária obrigatório");
            }

            if (p_objDisciplina.qntDeAulas == int.MinValue)
            {
                throw new Exception("Campo quantidade de aulas obrigatório");
            }

            if (p_objDisciplina.idCurso == int.MinValue)
            {
                throw new Exception("Campo curso obrigatório");
            }
            #endregion

            BDDisciplina objDados = new BDDisciplina();
            return objDados.incluir(p_objDisciplina);
        }
        public List<Disciplina> consulta(string p_codigo)
        {
            if (p_codigo == string.Empty)
            {
                throw new Exception("Campo codigo obrigatorio");
            }

            BDDisciplina objDados = new BDDisciplina();
            return objDados.consultar(p_codigo);
        }

        public bool alterar(Disciplina p_objDisciplina) 
        {
            if (p_objDisciplina.nomeDisciplina == string.Empty)
            {
                throw new Exception("Campo Nome obtrigatório.");

                
            }
            if (p_objDisciplina.codigo == string.Empty)
            {
                throw new Exception("Campo codigo obrigatório");
            }

            if (p_objDisciplina.cargaHoraria == string.Empty)
            {
                throw new Exception("Campo carga horária obrigatório");
            }

            if (p_objDisciplina.qntDeAulas == int.MinValue)
            {
                throw new Exception("Campo quantidade de aulas obrigatório");
            }

            if (p_objDisciplina.idCurso == int.MinValue)
            {
                throw new Exception("Campo curso obrigatório");

            }
                
                BDDisciplina objDados = new BDDisciplina();
                return objDados.Alterar(p_objDisciplina);

            
        
        }

        public bool excluir(Disciplina p_objDisciplina) 
        {
            if (p_objDisciplina.codigo == string.Empty)
            {
                throw new Exception("Campo Codigo Obrigatório.");
            
            }

            BDDisciplina objDados = new BDDisciplina();
            return objDados.Excluir(p_objDisciplina);

        
        
        }

        public List<Disciplina> verificarCadastro(string p_codigo)
        {
            if (p_codigo == string.Empty)
            {
                throw new Exception("Campo codigo obrigatorio");
            }
            BDDisciplina objDados = new BDDisciplina();
            return objDados.verificarCadastroBD(p_codigo);
        }


    }
}
