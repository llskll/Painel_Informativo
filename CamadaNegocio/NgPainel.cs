using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaMetaDado;
using CamadaDados;

namespace CamadaNegocio
{
    public class NgPainel
    {
        public List<Painel> testeExcluirSala(string p_codigo)
        {
            if (p_codigo == string.Empty)
            {
                throw new Exception("Campo código obrigatório.");
            }

            BDPainel objDados = new BDPainel();
            return objDados.testeExcluirSalaBD(p_codigo);
        }

        public List<Painel> testeExcluirFuncionario(string p_matricula)
        {
            if (p_matricula == string.Empty)
            {
                throw new Exception("Campo matricula obrigatório.");
            }

            BDPainel objDados = new BDPainel();
            return objDados.testeExcluirFuncionarioBD(p_matricula);
        }

        public List<Painel> testeExcluirDisciplina(string p_codigo)
        {
            if (p_codigo == string.Empty)
            {
                throw new Exception("Campo código obrigatório.");
            }

            BDPainel objDados = new BDPainel();
            return objDados.testeExcluirDisciplinaBD(p_codigo);
        }

        public List<Painel> testeExcluirCurso(string p_codigo)
        {
            if (p_codigo == string.Empty)
            {
                throw new Exception("Campo código obrigatório.");
            }

            BDPainel objDados = new BDPainel();
            return objDados.testeExcluirCursoBD(p_codigo);
        }

        public List<Painel> testeExcluirTurma(string p_codigo)
        {
            if (p_codigo == string.Empty)
            {
                throw new Exception("Campo código obrigatório.");
            }

            BDPainel objDados = new BDPainel();
            return objDados.testeExcluirTurmaBD(p_codigo);
        }

        public bool excluir(Painel p_objPainel)
        {
           

            BDPainel objDados = new BDPainel();
            return objDados.excluirPainel(p_objPainel);



        }

        public List<Painel> VerificarCadastroBD(string p_codigo)
        {
            if (p_codigo == string.Empty)
            {
                throw new Exception("Campo codigo obrigatório.");
            }

            BDPainel objDados = new BDPainel();
            return objDados.verificarCadastroBD(p_codigo);

        }

        public List<Painel> consultarPainel(string codigo)
        {
            BDPainel objDados = new BDPainel();
            return objDados.ConsultarPainel(codigo);
        }

        public bool excluirPainelCodigo(string p_codigo)
        {

            if (p_codigo == string.Empty)
            {
                throw new Exception("Campo codigo obrigatório.");
            }

            BDPainel objDados = new BDPainel();
            return objDados.excluirPainelPorCodigo(p_codigo);



        }

        public bool alterarPainel(Painel p_objPainel)
        {
            if (p_objPainel.codigo == string.Empty)
            {
                throw new Exception("Campo codigo obrigatório.");
            }

            BDPainel objDados = new BDPainel();
            return objDados.alterarPainel(p_objPainel);



        }
    }
}
