using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaMetaDado
{
    public class Usuario1
    {
        public string login { get; set; }
        public string senha { get; set; }
        public int nivel { get; set; }
        public string matricula { get; set; }
        public int idAluno { get; set; }

        public Usuario1()
        {
            this.login = string.Empty;
            this.senha = string.Empty;
            this.nivel = int.MinValue;
            this.matricula = string.Empty;
            this.idAluno = int.MinValue;

        }
    }
}
