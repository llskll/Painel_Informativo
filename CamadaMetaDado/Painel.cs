using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaMetaDado
{
    public class Painel
    {
        public string codigo;
        public string idDisciplina;
        public string idTurma;
        public string idSala;
        public string idFuncionario;
        public string idCurso;
        
        public string turno;
        private string dSemana;



        public Painel()
        {
            this.codigo = string.Empty;
            this.idDisciplina = string.Empty;
            this.idTurma = string.Empty;
            this.idSala = string.Empty;
            this.idFuncionario = string.Empty;
            this.idCurso = string.Empty;
           
            this.turno = string.Empty;
            this.dSemana = string.Empty; 
        }
    }
}
