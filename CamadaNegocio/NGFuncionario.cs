using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CamadaMetaDado;
using CamadaDados;

namespace CamadaNegocio
{
    public class NGFuncionario
    {

        public bool incluir(Funcionario p_objFuncionario) 
        {
            #region Validação dos campos obrigatorios

            if (p_objFuncionario.RG == string.Empty)
            {
                throw new Exception("Campo RG obrigatorio");
            }

            if (p_objFuncionario.telefone == string.Empty)
            {
                throw new Exception("Campo telefone obrigatorio");
            }

            if (p_objFuncionario.endereco == string.Empty)
            {
                throw new Exception("Campo endereço obrigatorio");
            }

            if (p_objFuncionario.nome == string.Empty)
            {
                throw new Exception("Campo nome obrigatorio");
            }

            if (p_objFuncionario.sexo == string.Empty)
            {
                throw new Exception("Campo sexo obrigatorio");
            }

            if (p_objFuncionario.email == string.Empty)
            {
                throw new Exception("Campo e-mail  obrigatorio");
            }

            if (p_objFuncionario.matricula == string.Empty)
            {
                throw new Exception("Campo matricula obrigatorio");
            }

            if (p_objFuncionario.CPF == string.Empty)
            {
                throw new Exception("Campo CPF obrigatorio");
            }

            if (p_objFuncionario.turno == string.Empty)
            {
                throw new Exception("Campo turno obrigatorio");
            }

            if (p_objFuncionario.cargo == string.Empty)
            {
                throw new Exception("Campo cargo obrigatorio");
            }

            #endregion

            BDFuncionario objDados = new BDFuncionario();
            return objDados.incluir(p_objFuncionario);
        }

        
        public List<Funcionario> verificarCadastro(string p_matricula)
        {
            if (p_matricula == string.Empty)
            {
                throw new Exception("Campo matricula obrigatorio");
            }
            BDFuncionario objDados = new BDFuncionario();
            return objDados.verificarCadastroBD(p_matricula);
        }

        public List<Funcionario> consulta(string p_matricula)
        {
            if (p_matricula == string.Empty)
            {
                throw new Exception("Campo matricula obrigatorio");
            }
            BDFuncionario objDados = new BDFuncionario();
            return objDados.consultar(p_matricula);
        }

        public bool Alterar(Funcionario p_objFuncionario)
        {
            #region Validação dos campos obrigatorios

            if (p_objFuncionario.RG == string.Empty)
            {
                throw new Exception("Campo RG obrigatorio");
            }

            if (p_objFuncionario.telefone == string.Empty)
            {
                throw new Exception("Campo telefone obrigatorio");
            }

            if (p_objFuncionario.endereco == string.Empty)
            {
                throw new Exception("Campo endereço obrigatorio");
            }

            if (p_objFuncionario.nome == string.Empty)
            {
                throw new Exception("Campo nome obrigatorio");
            }

            if (p_objFuncionario.sexo == string.Empty)
            {
                throw new Exception("Campo sexo obrigatorio");
            }

            if (p_objFuncionario.email == string.Empty)
            {
                throw new Exception("Campo e-mail  obrigatorio");
            }

            if (p_objFuncionario.matricula == string.Empty)
            {
                throw new Exception("Campo matricula obrigatorio");
            }

            if (p_objFuncionario.CPF == string.Empty)
            {
                throw new Exception("Campo CPF obrigatorio");
            }

            if (p_objFuncionario.turno == string.Empty)
            {
                throw new Exception("Campo turno obrigatorio");
            }

            if (p_objFuncionario.cargo == string.Empty)
            {
                throw new Exception("Campo cargo obrigatorio");
            }

            #endregion

            BDFuncionario objDados = new BDFuncionario();
            return objDados.Alterar(p_objFuncionario);
        }


        public bool Excluir(Funcionario p_objFuncionario)
        {
            if (p_objFuncionario.matricula == string.Empty)
            {
                throw new Exception("Campo matricula obrigatorio");
            }
            BDFuncionario objDados = new BDFuncionario();
            return objDados.Excluir(p_objFuncionario);
        }


    }
}
