using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionBEL
{
    public class BE_Ceses
    {
        public String CodigoPais { get; set; }
        public String CodigoCompania { get; set; }
        public String CodigoEmpleadoFRACTAL { get; set; }
        public String CodigoEmpleadoOracle { get; set; }
        public String CodigoTipoDocIdentidad { get; set; }
        public String NroDocIdentidad { get; set; }       
        public String FechaCese { get; set; }           
        public String MotivoCese { get; set; }
        public String MotivoBBSS { get; set; }
        public String IndicadorIndemnizacion { get; set; }
        public String IndicadorPreaviso { get; set; }
        public String FormaPago { get; set; }
        public String SituacionOperacion { get; set; }
        public String FechaHoraOperacionRegistroOracle { get; set; }
        public String IdentificadorUltimoUsuario { get; set; }
        public String CorreoUltimoUsuario { get; set; }
    }
}
