using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaMetaDado
{
    public class Curso
    {
        public string nomeCurso { get; set; }
        public string codigo { get; set; }
        public string cargaHoraria { get; set; }

        public Curso()
        {
            this.nomeCurso = string.Empty;
            this.codigo = string.Empty;
            this.cargaHoraria = string.Empty;
        }
    }
}
