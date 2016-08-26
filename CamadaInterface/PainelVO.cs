using System.Configuration;

using System.Web;

using System.Web.Security;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Web.UI.WebControls.WebParts;

using System.Web.UI.HtmlControls;
using System;


namespace CamadaInterface
{
    [Serializable]
    public class PainelVO
    {
        private string codigo;
        private string idDISCIPLINA;
        private string idTURMA;
        private string idSALA;
        private string idFUNCIONARIO;
        private string idCURSO;
      
        private string turno;
        private string dSemana;

        public string cod
        {

            get { return codigo; }
            set { codigo = value; }

        }

        public string idDisc
        {

            get { return idDISCIPLINA; }
            set { idDISCIPLINA = value; }

        }

        public string idTur
        {

            get { return idTURMA; }
            set { idTURMA = value; }

        }

        public string idSal
        {

            get { return idSALA; }
            set { idSALA = value; }

        }

        public string idFun
        {

            get { return idFUNCIONARIO; }
            set { idFUNCIONARIO = value; }

        }

        public string idCur
        {

            get { return idCURSO; }
            set { idCURSO = value; }

        }

      
        public string turn
        {
            get { return turno; }
            set { turno = value; }
        }
        public string dSem
        {
            get { return dSemana; }
            set { dSemana = value; }
        }



        public PainelVO()
        {
            this.codigo = string.Empty;
            this.idDISCIPLINA = string.Empty;
            this.idTURMA = string.Empty;
            this.idSALA = string.Empty;
            this.idFUNCIONARIO = string.Empty;
            this.idCURSO = string.Empty;
           
            this.turno = string.Empty;
            this.dSemana = string.Empty;   
        
        }
        
    }

    

   
    
}