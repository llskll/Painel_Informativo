using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaMetaDado
{
    public class Turma
    {
        public string codigo  { get; set; }
        public string turno  { get; set; } 
        public int qntDeAlunos { get; set; } 
        public int idCurso { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public string diaDaSemana { get; set; }

        

        public Turma()
        {
            this.codigo = string.Empty;
            this.turno = string.Empty;
            this.qntDeAlunos = int.MinValue;
            this.idCurso = int.MinValue;
            this.dataFim = DateTime.MinValue;
            this.dataInicio = DateTime.MinValue;
            this.diaDaSemana = string.Empty;
        }
    }
}
