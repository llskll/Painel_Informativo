using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaMetaDado
{
    public class Aluno : Usuario1
    {
        public string matricula { get; set; }
        public string nome { get; set; }
        public string status { get; set; }

        public Aluno()
        {
            this.matricula = string.Empty;
            this.nome = string.Empty;
            this.status = string.Empty;
        }
    }
}
