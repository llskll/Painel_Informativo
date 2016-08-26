using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaMetaDado
{
    public class Funcionario : Usuario1
    {
        public string nome { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string endereco { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string sexo { get; set; }
        public string matricula { get; set; }
        public string turno { get; set; }
        public string cargo { get; set; }

        public Funcionario()
        {
            this.nome = string.Empty;
            this.telefone = string.Empty;
            this.email = string.Empty;
            this.endereco = string.Empty;
            this.RG = string.Empty;
            this.CPF = string.Empty;
            this.sexo = string.Empty;
            this.matricula = string.Empty;
        }
    }
}
