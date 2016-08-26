using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaMetaDado;
using CamadaDados;

namespace CamadaNegocio
{
    public class NgTurma
    {
        public bool incluir(Turma p_objTurma)
        {
            #region Validação dos campos obrigatorios

            if (p_objTurma.codigo == string.Empty)
            {
                throw new Exception("Campo nome obrigatorio");
            }

            if (p_objTurma.turno == string.Empty)
            {
                throw new Exception("Campo turno obrigatorio");
            }

            if (p_objTurma.qntDeAlunos == int.MinValue)
            {
                throw new Exception("Campo quantidade de alunos obrigatorio");
            }

            if (p_objTurma.idCurso == int.MinValue)
            {
                throw new Exception("Campo curso obrigatorio");
            }

            if (p_objTurma.dataInicio == DateTime.MinValue)
            {
                throw new Exception("Campo data inicio obrigatorio");
            }

            if (p_objTurma.dataFim == DateTime.MinValue)
            {
                throw new Exception("Campo data fim obrigatorio");
            }
            #endregion

            BDTurma objDados = new BDTurma();
            return objDados.incluir(p_objTurma);
        }

        public List<Turma> consulta(string p_codigo)
        {
            if (p_codigo == string.Empty)
            {
                throw new Exception("Campo codigo obrigatorio");
            }
            BDTurma objDados = new BDTurma();
            return objDados.consultar(p_codigo);
        }

        public bool alterar(Turma p_objTurma)
        {
            if (p_objTurma.codigo == string.Empty)
            {
                throw new Exception("Campo codigo obrigatorio");
            }

            if (p_objTurma.turno == string.Empty)
            {
                throw new Exception("Campo turno obrigatorio");
            }

            if (p_objTurma.qntDeAlunos == int.MinValue)
            {
                throw new Exception("Campo quantidade de alunos obrigatorio");
            }

            if (p_objTurma.idCurso == int.MinValue)
            {
                throw new Exception("Campo curso obrigatorio");
            }

            if (p_objTurma.dataInicio == DateTime.MinValue)
            {
                throw new Exception("Campo data inicio obrigatorio");
            }

            if (p_objTurma.dataFim == DateTime.MinValue)
            {
                throw new Exception("Campo data fim obrigatorio");
            }
            if (p_objTurma.diaDaSemana == string.Empty)
            {
                throw new Exception("Campo turno obrigatorio");
            }

            BDTurma objDados = new BDTurma();
            return objDados.Alterar(p_objTurma);
        }


        public bool excluir(Turma p_objTurma)
        {
            if (p_objTurma.codigo == string.Empty)
            {
                throw new Exception("Campo Código obrigatório.");
            }

            BDTurma objDados = new BDTurma();
            return objDados.Excluir(p_objTurma);

        }


        public List<Turma> verificarCadastro(string p_codigo)
        {
            if (p_codigo == string.Empty)
            {
                throw new Exception("Campo codigo obrigatorio");
            }
            BDTurma objDados = new BDTurma();
            return objDados.verificarCadastroBD(p_codigo);
        }
    }
}
