using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionBEL
{
    public class BE_Permisos
    {
        public String CodigoPais { get; set; }
        public String CodigoCompania { get; set; }
        public String CodigoEmpleadoFRACTAL { get; set; }
        public String CodigoEmpleadoOracle { get; set; }
        public String CodigoTipoDocIdentidad { get; set; }
        public String NroDocIdentidad { get; set; }
        public String FechaAsistencia { get; set; }
        public String FechaInicioPermiso { get; set; }
        public String FechaFinPermiso { get; set; }
        public String NumeroMinutos { get; set; }
        public String MotivoPermiso { get; set; }
        public String IndicadorPago { get; set; }
        public String SituacionOperacion { get; set; }
        public String FechaHoraOperacionRegistroOracle { get; set; }
        public String IdentificadorUltimoUsuario { get; set; }
        public String CorreoUltimoUsuario { get; set; }

    }
}
