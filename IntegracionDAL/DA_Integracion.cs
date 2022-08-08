using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionBEL;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace IntegracionDAL
{
    public class DA_Integracion: DA_Base
    {

        private string ConexionCRI = ConfigurationManager.AppSettings["DBConnectionString_CRI"].ToString();
        private string ConexionGTM = ConfigurationManager.AppSettings["DBConnectionString_GTM"].ToString();
        private string ConexionHND = ConfigurationManager.AppSettings["DBConnectionString_HND"].ToString();

        public void mInsertarArchivoBD (List<BE_Ausencias> archivos)
        {
            string strPaisCRI = ConfigurationManager.AppSettings["CodCostaRica"].ToString();
            string strPaisGTM = ConfigurationManager.AppSettings["CodGuatemala"].ToString();
            string strPaisHND = ConfigurationManager.AppSettings["CodHonduras"].ToString();

            List<BE_Ausencias> ListaFiltradaCRI = archivos.Where(x => x.CodigoPais== strPaisCRI).ToList(); //Obtenemos todos los registros por CRI
            List<BE_Ausencias> ListaFiltradaGTM = archivos.Where(x => x.CodigoPais == strPaisGTM).ToList();
            List<BE_Ausencias> ListaFiltradaHND = archivos.Where(x => x.CodigoPais == strPaisHND).ToList();

            //hacemos la conexión para que vayan a la Bd de CRI
            //contamos que hayan registros para el país

            if (ListaFiltradaCRI.Count >0)
            {
                mInsertarAusenciasBD(ListaFiltradaCRI);
            }

        }
            

        protected void mInsertarAusenciasBD(List<BE_Ausencias> ListAusencias)
        {
            using (SqlConnection connection = new SqlConnection(ConexionCRI))
            {                
                try
                {
                    foreach (var item in ListAusencias)
                    {

                        SqlCommand cmd = new SqlCommand("FPER_SP_INSERTAR_AUSENCIAS_ORACLE", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 10000;
                        connection.Open();               

                        cmd.Parameters.AddWithValue("@CODIGO_PAIS", item.CodigoPais.ToString());
                        cmd.Parameters.AddWithValue("@CODIGO_COMPANIA", item.CodigoCompania.ToString());
                        cmd.Parameters.AddWithValue("@EMPLEADO_FRACTAL", item.CodigoEmpleadoFRACTAL.ToString());
                        cmd.Parameters.AddWithValue("@EMPLEADO_ORCALE", item.CodigoEmpleadoOracle.ToString());
                        cmd.Parameters.AddWithValue("@DOCUMENTO_ID", item.NroDocIdentidad.ToString());
                        cmd.Parameters.AddWithValue("@NRO_DNI", item.NroDocIdentidad.ToString());
                        cmd.Parameters.AddWithValue("@FECHA_INICIO", Convert.ToDateTime(item.FechaInicio));
                        cmd.Parameters.AddWithValue("@FECHA_FIN", Convert.ToDateTime(item.FechaFin));
                        cmd.Parameters.AddWithValue("@NRO_DIAS", item.NumeroDias.ToString());
                        cmd.Parameters.AddWithValue("@MOTIVO_LICENCIA", item.MotivoLicencia.ToString());
                        cmd.Parameters.AddWithValue("@GRUPO_LIC", item.GrupoLicencia.ToString());
                        cmd.Parameters.AddWithValue("@TIPO_PAGO", item.TipoPagoLicencia.ToString());
                        cmd.Parameters.AddWithValue("@SITUACION_OP", item.SituacionOperacion.ToString());
                        cmd.Parameters.AddWithValue("@FE_OPERACION_ORACLE", item.FechaHoraOperacionRegistroOracle.ToString());
                        cmd.Parameters.AddWithValue("@ID_ULTIMO_USU", item.IdentificadorUltimoUsuario.ToString());
                        cmd.Parameters.AddWithValue("@CORREO", item.CorreoUltimoUsuario.ToString());
                        cmd.ExecuteNonQuery();

                        connection.Close();
                    }
                   
                    
                }
                catch (Exception ex)
                {

                    throw ex;
                }             
            }

        }
    }
}
