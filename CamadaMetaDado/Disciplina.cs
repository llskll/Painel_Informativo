using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaMetaDado
{
    public class Disciplina
    {
        public string nomeDisciplina { get; set; }
        public string codigo  { get; set; }
        public int qntDeAulas { get; set; }
        public string cargaHoraria { get; set; }
        public int idCurso { get; set; }

        public Disciplina()
        {
            this.nomeDisciplina = string.Empty;
            this.codigo = string.Empty;
            this.qntDeAulas = int.MinValue;
            this.cargaHoraria = string.Empty;
            this.idCurso = int.MinValue;
        }

    }
}
