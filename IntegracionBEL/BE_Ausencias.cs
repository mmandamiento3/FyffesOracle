using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionBEL
{
    public class BE_Ausencias
    {
        public String CodigoPais { get; set; }
        public String CodigoCompania { get; set; }
        public String CodigoEmpleadoFRACTAL { get; set; }
        public String CodigoEmpleadoOracle { get; set; }
        public String CodigoTipoDocIdentidad { get; set; }
        public String NroDocIdentidad { get; set; }
        public String FechaInicio { get; set; }
        public String FechaFin { get; set; }
        public String NumeroDias { get; set; }
        public String MotivoLicencia { get; set; }        
        public String TipoPagoLicencia { get; set; }
        public String SituacionOperacion { get; set; }
        public String FechaHoraOperacionRegistroOracle { get; set; }
        public String IdentificadorUltimoUsuario { get; set; }
        public String CorreoUltimoUsuario { get; set; }

    }
}
