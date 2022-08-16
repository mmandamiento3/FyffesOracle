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
    public class DA_Integracion
    {

        private string ConexionCRI = ConfigurationManager.AppSettings["DBConnectionString_CRI"].ToString();
        private string ConexionGTM = ConfigurationManager.AppSettings["DBConnectionString_GTM"].ToString();
        private string ConexionHND = ConfigurationManager.AppSettings["DBConnectionString_HND"].ToString();
        private string ConexionECU = ConfigurationManager.AppSettings["DBConnectionString_ECU"].ToString();
        private string ConexionBZE = ConfigurationManager.AppSettings["DBConnectionString_BZE"].ToString();

        string strPaisCRI = ConfigurationManager.AppSettings["CodCostaRica"].ToString();
        string strPaisGTM = ConfigurationManager.AppSettings["CodGuatemala"].ToString();
        string strPaisHND = ConfigurationManager.AppSettings["CodHonduras"].ToString();
        string strPasiECU = ConfigurationManager.AppSettings["CodEcuador"].ToString();
        string strPaisBZE = ConfigurationManager.AppSettings["CodBelize"].ToString();

        public void mInsertarArchivoAusenciasBD (List<BE_Ausencias> archivos)
        {
            List<BE_Ausencias> ListaFiltradaCRI = archivos.Where(x => x.CodigoPais== strPaisCRI).ToList(); //Obtenemos todos los registros por CRI
            List<BE_Ausencias> ListaFiltradaGTM = archivos.Where(x => x.CodigoPais == strPaisGTM).ToList();
            List<BE_Ausencias> ListaFiltradaHND = archivos.Where(x => x.CodigoPais == strPaisHND).ToList();
            List<BE_Ausencias> ListaFiltradaECU = archivos.Where(x => x.CodigoPais == strPasiECU).ToList();
            List<BE_Ausencias> ListaFiltradaBZE = archivos.Where(x => x.CodigoPais == strPaisBZE).ToList();

            //hacemos la conexión para que vayan a la Bd de CRI
            //contamos que hayan registros para el país

            if (ListaFiltradaCRI.Count>0)
            {
                mInsertarAusenciasBD(ListaFiltradaCRI,ConexionCRI);
            }

            if (ListaFiltradaGTM.Count>0)
            {
                mInsertarAusenciasBD(ListaFiltradaGTM,ConexionGTM);
            }
            if (ListaFiltradaHND.Count > 0)
            {
                mInsertarAusenciasBD(ListaFiltradaHND,ConexionHND);
            }
            if (ListaFiltradaECU.Count > 0)
            {
                mInsertarAusenciasBD(ListaFiltradaECU, ConexionECU);
            }
            if (ListaFiltradaBZE.Count > 0)
            {
                mInsertarAusenciasBD(ListaFiltradaBZE, ConexionBZE);
            }




        }

        public void mInsertarArchivoCesesBD (List<BE_Ceses> archivos)
        {
            List<BE_Ceses> ListaFiltradaCRI = archivos.Where(x => x.CodigoPais == strPaisCRI).ToList(); //Obtenemos todos los registros por CRI
            List<BE_Ceses> ListaFiltradaGTM = archivos.Where(x => x.CodigoPais == strPaisGTM).ToList();
            List<BE_Ceses> ListaFiltradaHND = archivos.Where(x => x.CodigoPais == strPaisHND).ToList();
            List<BE_Ceses> ListaFiltradaECU = archivos.Where(x => x.CodigoPais == strPasiECU).ToList();
            List<BE_Ceses> ListaFiltradaBZE = archivos.Where(x => x.CodigoPais == strPaisBZE).ToList();

            if (ListaFiltradaCRI.Count > 0)
            {
                mInsertarCesesBD(ListaFiltradaCRI, ConexionCRI);
            }

            if (ListaFiltradaGTM.Count > 0)
            {
                mInsertarCesesBD(ListaFiltradaGTM, ConexionGTM);
            }
            if (ListaFiltradaHND.Count > 0)
            {
                mInsertarCesesBD(ListaFiltradaHND, ConexionHND);
            }
            if (ListaFiltradaECU.Count > 0)
            {
                mInsertarCesesBD(ListaFiltradaECU, ConexionECU);
            }
            if (ListaFiltradaBZE.Count > 0)
            {
                mInsertarCesesBD(ListaFiltradaBZE, ConexionBZE);
            }
        }

        public void mInsertarArchivoIngresoBD(List<BE_Ingresos> archivos)
        {
            List<BE_Ingresos> ListaFiltradaCRI = archivos.Where(x => x.CodigoPais == strPaisCRI).ToList(); //Obtenemos todos los registros por CRI
            List<BE_Ingresos> ListaFiltradaGTM = archivos.Where(x => x.CodigoPais == strPaisGTM).ToList();
            List<BE_Ingresos> ListaFiltradaHND = archivos.Where(x => x.CodigoPais == strPaisHND).ToList();
            List<BE_Ingresos> ListaFiltradaECU = archivos.Where(x => x.CodigoPais == strPasiECU).ToList();
            List<BE_Ingresos> ListaFiltradaBZE = archivos.Where(x => x.CodigoPais == strPaisBZE).ToList();

            if (ListaFiltradaCRI.Count > 0)
            {
                mInsertarIngresosBD(ListaFiltradaCRI, ConexionCRI);
            }

            if (ListaFiltradaGTM.Count > 0)
            {
                mInsertarIngresosBD(ListaFiltradaGTM, ConexionGTM);
            }
            if (ListaFiltradaHND.Count > 0)
            {
                mInsertarIngresosBD(ListaFiltradaHND, ConexionHND);
            }
            if (ListaFiltradaECU.Count > 0)
            {
                mInsertarIngresosBD(ListaFiltradaECU, ConexionECU);
            }
            if (ListaFiltradaBZE.Count > 0)
            {
                mInsertarIngresosBD(ListaFiltradaBZE, ConexionBZE);
            }
        }

        public void mInsertarArchivoPermisosBD(List<BE_Permisos> archivos)
        {
            List<BE_Permisos> ListaFiltradaCRI = archivos.Where(x => x.CodigoPais == strPaisCRI).ToList(); //Obtenemos todos los registros por CRI
            List<BE_Permisos> ListaFiltradaGTM = archivos.Where(x => x.CodigoPais == strPaisGTM).ToList();
            List<BE_Permisos> ListaFiltradaHND = archivos.Where(x => x.CodigoPais == strPaisHND).ToList();
            List<BE_Permisos> ListaFiltradaECU = archivos.Where(x => x.CodigoPais == strPasiECU).ToList();
            List<BE_Permisos> ListaFiltradaBZE = archivos.Where(x => x.CodigoPais == strPaisBZE).ToList();

            if (ListaFiltradaCRI.Count > 0)
            {
                mInsertarPermisosBD(ListaFiltradaCRI, ConexionCRI);
            }

            if (ListaFiltradaGTM.Count > 0)
            {
                mInsertarPermisosBD(ListaFiltradaGTM, ConexionGTM);
            }
            if (ListaFiltradaHND.Count > 0)
            {
                mInsertarPermisosBD(ListaFiltradaHND, ConexionHND);
            }
            if (ListaFiltradaECU.Count > 0)
            {
                mInsertarPermisosBD(ListaFiltradaECU, ConexionECU);
            }
            if (ListaFiltradaBZE.Count > 0)
            {
                mInsertarPermisosBD(ListaFiltradaBZE, ConexionBZE);
            }
        }

        //public void mInsertarArchivoSaldosVacBD(List<BE_SaldoVacaciones> archivos)
        //{
        //    List<BE_SaldoVacaciones> ListaFiltradaCRI = archivos.Where(x => x.CodigoPais == strPaisCRI).ToList(); //Obtenemos todos los registros por CRI
        //    List<BE_SaldoVacaciones> ListaFiltradaGTM = archivos.Where(x => x.CodigoPais == strPaisGTM).ToList();
        //    List<BE_SaldoVacaciones> ListaFiltradaHND = archivos.Where(x => x.CodigoPais == strPaisHND).ToList();
        //    List<BE_SaldoVacaciones> ListaFiltradaECU = archivos.Where(x => x.CodigoPais == strPasiECU).ToList();
        //    List<BE_SaldoVacaciones> ListaFiltradaBZE = archivos.Where(x => x.CodigoPais == strPaisBZE).ToList();

        //    //hacemos la conexión para que vayan a la Bd de CRI
        //    //contamos que hayan registros para el país

        //    if (ListaFiltradaCRI.Count > 0)
        //    {
        //        mInsertarSaldosBD(ListaFiltradaCRI, ConexionCRI);
        //    }

        //    if (ListaFiltradaGTM.Count > 0)
        //    {
        //        mInsertarSaldosBD(ListaFiltradaGTM, ConexionGTM);
        //    }
        //    if (ListaFiltradaHND.Count > 0)
        //    {
        //        mInsertarSaldosBD(ListaFiltradaHND, ConexionHND);
        //    }
        //    if (ListaFiltradaECU.Count > 0)
        //    {
        //        mInsertarSaldosBD(ListaFiltradaECU, ConexionECU);
        //    }
        //    if (ListaFiltradaBZE.Count > 0)
        //    {
        //        mInsertarSaldosBD(ListaFiltradaBZE, ConexionBZE);
        //    }

        //}

        public void mInsertarArchivoSindicatoBD(List<BE_Sindicatos> archivos)
        {
            List<BE_Sindicatos> ListaFiltradaCRI = archivos.Where(x => x.CodigoPais == strPaisCRI).ToList(); //Obtenemos todos los registros por CRI
            List<BE_Sindicatos> ListaFiltradaGTM = archivos.Where(x => x.CodigoPais == strPaisGTM).ToList();
            List<BE_Sindicatos> ListaFiltradaHND = archivos.Where(x => x.CodigoPais == strPaisHND).ToList();
            List<BE_Sindicatos> ListaFiltradaECU = archivos.Where(x => x.CodigoPais == strPasiECU).ToList();
            List<BE_Sindicatos> ListaFiltradaBZE = archivos.Where(x => x.CodigoPais == strPaisBZE).ToList();

            //hacemos la conexión para que vayan a la Bd de CRI
            //contamos que hayan registros para el país

            if (ListaFiltradaCRI.Count > 0)
            {
                mInsertarSindicatosBD(ListaFiltradaCRI, ConexionCRI);
            }

            if (ListaFiltradaGTM.Count > 0)
            {
                mInsertarSindicatosBD(ListaFiltradaGTM, ConexionGTM);
            }
            if (ListaFiltradaHND.Count > 0)
            {
                mInsertarSindicatosBD(ListaFiltradaHND, ConexionHND);
            }
            if (ListaFiltradaECU.Count > 0)
            {
                mInsertarSindicatosBD(ListaFiltradaECU, ConexionECU);
            }
            if (ListaFiltradaBZE.Count > 0)
            {
                mInsertarSindicatosBD(ListaFiltradaBZE, ConexionBZE);
            }

        }

        public void mInsertarArchivoVacacionesBD(List<BE_Vacaciones> archivos)
        {
            List<BE_Vacaciones> ListaFiltradaCRI = archivos.Where(x => x.CodigoPais == strPaisCRI).ToList(); //Obtenemos todos los registros por CRI
            List<BE_Vacaciones> ListaFiltradaGTM = archivos.Where(x => x.CodigoPais == strPaisGTM).ToList();
            List<BE_Vacaciones> ListaFiltradaHND = archivos.Where(x => x.CodigoPais == strPaisHND).ToList();
            List<BE_Vacaciones> ListaFiltradaECU = archivos.Where(x => x.CodigoPais == strPasiECU).ToList();
            List<BE_Vacaciones> ListaFiltradaBZE = archivos.Where(x => x.CodigoPais == strPaisBZE).ToList();

            //hacemos la conexión para que vayan a la Bd de CRI
            //contamos que hayan registros para el país

            if (ListaFiltradaCRI.Count > 0)
            {
                mInsertarVacacionesBD(ListaFiltradaCRI, ConexionCRI);
            }

            if (ListaFiltradaGTM.Count > 0)
            {
                mInsertarVacacionesBD(ListaFiltradaGTM, ConexionGTM);
            }
            if (ListaFiltradaHND.Count > 0)
            {
                mInsertarVacacionesBD(ListaFiltradaHND, ConexionHND);
            }
            if (ListaFiltradaECU.Count > 0)
            {
                mInsertarVacacionesBD(ListaFiltradaECU, ConexionECU);
            }
            if (ListaFiltradaBZE.Count > 0)
            {
                mInsertarVacacionesBD(ListaFiltradaBZE, ConexionBZE);
            }
        }




        protected void mInsertarAusenciasBD(List<BE_Ausencias> ListAusencias,string ConexionPais)
        {            
            using (SqlConnection connection = new SqlConnection(ConexionPais))
            {                
                try
                {
                    foreach (var item in ListAusencias)
                    {

                        SqlCommand cmd = new SqlCommand("FINT_SP_INSERTA_INFO_ORACLE_AUSENCIAS", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 10000;
                        connection.Open();               

                        cmd.Parameters.AddWithValue("@VC_CODIGO_PAIS", item.CodigoPais.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_COMPANIA", item.CodigoCompania.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_EMPLEADO_FRACTAL", item.CodigoEmpleadoFRACTAL.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_EMPLEADO_ORACLE", item.CodigoEmpleadoOracle.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_TIPO_DOC_IDENTIDAD", item.CodigoTipoDocIdentidad.ToString());
                        cmd.Parameters.AddWithValue("@VC_NRO_DOC_IDENTIDAD", item.NroDocIdentidad.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_INICIO",item.FechaInicio.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_FIN", item.FechaFin.ToString());
                        cmd.Parameters.AddWithValue("@VC_NUMERO_DIAS", item.NumeroDias.ToString());
                        cmd.Parameters.AddWithValue("@VC_MOTIVO_LICENCIA", item.MotivoLicencia.ToString());                        
                        cmd.Parameters.AddWithValue("@VC_TIPO_PAGO_LICENCIA", item.TipoPagoLicencia.ToString());
                        cmd.Parameters.AddWithValue("@VC_SITUACION_OPERACION", item.SituacionOperacion.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_HORA_OPERACION_REGISTRO_ORACLE", item.FechaHoraOperacionRegistroOracle.ToString());
                        cmd.Parameters.AddWithValue("@VC_IDENTIFICADOR_ULTIMO_USUARIO", item.IdentificadorUltimoUsuario.ToString());
                        cmd.Parameters.AddWithValue("@VC_CORREO_ULTIMO_USUARIO", item.CorreoUltimoUsuario.ToString());
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

        protected void mInsertarCesesBD(List<BE_Ceses>ListCeses, string ConexionPais)
        {
            using (SqlConnection connection = new SqlConnection(ConexionPais))
            {
                try
                {
                    foreach (var item in ListCeses)
                    {

                        SqlCommand cmd = new SqlCommand("FINT_SP_INSERTA_INFO_ORACLE_DESVINCULACION", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 10000;
                        connection.Open();

                        cmd.Parameters.AddWithValue("@VC_CODIGO_PAIS", item.CodigoPais.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_COMPANIA", item.CodigoCompania.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_EMPLEADO_FRACTAL", item.CodigoEmpleadoFRACTAL.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_EMPLEADO_ORACLE", item.CodigoEmpleadoOracle.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_TIPO_DOC_IDENTIDAD", item.CodigoTipoDocIdentidad.ToString());
                        cmd.Parameters.AddWithValue("@VC_NRO_DOC_IDENTIDAD", item.NroDocIdentidad.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_CESE", item.FechaCese.ToString());
                        cmd.Parameters.AddWithValue("@VC_MOTIVO_CESE", item.MotivoCese.ToString());
                        cmd.Parameters.AddWithValue("@VC_MOTIVO_BBSS", item.MotivoBBSS.ToString());
                        cmd.Parameters.AddWithValue("@VC_INDICADOR_INDEMNIZACION", item.IndicadorIndemnizacion.ToString());
                        cmd.Parameters.AddWithValue("@VC_INDICADOR_PREAVISO", item.IndicadorPreaviso.ToString());
                        cmd.Parameters.AddWithValue("@VC_FORMA_PAGO", item.FormaPago.ToString());
                        cmd.Parameters.AddWithValue("@VC_SITUACION_OPERACION", item.SituacionOperacion.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHAHORA_OPERACION_REGISTRO_ORACLE", item.FechaHoraOperacionRegistroOracle.ToString());
                        cmd.Parameters.AddWithValue("@VC_IDENTIFICADOR_ULTIMO_USUARIO", item.IdentificadorUltimoUsuario.ToString());
                        cmd.Parameters.AddWithValue("@VC_CORREO_ULTIMO_USUARIO", item.CorreoUltimoUsuario.ToString());
                        
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
        protected void mInsertarIngresosBD(List<BE_Ingresos>ListIngresos,string ConexionPais)
        {
            using (SqlConnection connection = new SqlConnection(ConexionPais))
            {
                try
                {
                    foreach (var item in ListIngresos)
                    {

                        SqlCommand cmd = new SqlCommand("FINT_SP_INSERTA_INFO_ORACLE_INGRESO_ACTUALIZA_PERSONAL", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 10000;
                        connection.Open();

                        cmd.Parameters.AddWithValue("@VC_TIPO_OPERACION", item.TipoOperacion.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_PAIS", item.CodigoPais.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_COMPANIA", item.CodigoCompania.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_EMPLEADO_FRACTAL", item.CodigoEmpleadoFRACTAL.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_EMPLEADO_ORACLE", item.CodigoEmpleadoOracle.ToString());
                        cmd.Parameters.AddWithValue("@VC_APELLIDO_PATERNO", item.ApellidoPaterno.ToString());
                        cmd.Parameters.AddWithValue("@VC_APELLIDO_MATERNO", item.ApellidoMaterno.ToString());
                        cmd.Parameters.AddWithValue("@VC_NOMBRES", item.Nombres.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_SEXO", item.CodigoSexo.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_ESTADO_CIVIL", item.CodigoEstadoCivil.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_NACIONALIDAD", item.CodigoNacionalidad.ToString());
                        cmd.Parameters.AddWithValue("@VC_TIPO_NACIONALIDAD", item.TipoNacionalidad.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_TIPO_DOC_IDENTIDAD", item.CodigoTipoDocIdentidad.ToString());
                        cmd.Parameters.AddWithValue("@VC_NRO_DOC_IDENTIDAD", item.NroDocIdentidad.ToString());
                        cmd.Parameters.AddWithValue("@VC_LUGAR_EMISION", item.LugarEmision.ToString());
                        cmd.Parameters.AddWithValue("@VC_NRO_SEGURO_SOCIAL", item.NroSeguroSocial.ToString());
                        cmd.Parameters.AddWithValue("@VC_NRO_IDENTIFICACION_TRIBUTARIA", item.NroIdentificacionTributaria.ToString());
                        cmd.Parameters.AddWithValue("@VC_NOMBRE_SEGURO_SOCIAL", item.NombreSeguroSocial.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_NACIMIENTO", item.FechaNacimiento.ToString());
                        cmd.Parameters.AddWithValue("@VC_LUGAR_NACIMIENTO", item.LugarNacimiento.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_LUGAR_NACIMIENTO", item.CodigoLugarNacimiento.ToString());
                        cmd.Parameters.AddWithValue("@VC_DIRECCION_DOMICILIO", item.DireccionDomicilio.ToString());
                        cmd.Parameters.AddWithValue("@VC_NUMERO_TELEFONO", item.NumeroTelefono.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_INICIO_LABORES", item.FechaInicioLabores.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_TIPO_EMPLEADO", item.CodigoTipoEmpleado.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_CLASIFICACION_EMPLEADO", item.CodigoClasificacionEmpleado.ToString());
                        cmd.Parameters.AddWithValue("@VC_IDALTERNATIVO", item.IdAlternativo.ToString());
                        cmd.Parameters.AddWithValue("@VC_REINGRESANTE", item.Reingresante.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_REINGRESO", item.FechaReingreso.ToString());
                        cmd.Parameters.AddWithValue("@VC_SINDICALIZADO", item.Sindicalizado.ToString());
                        cmd.Parameters.AddWithValue("@VC_ULTIMO_SINDICATO", item.UltimoSindicato.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_AREA", item.CodigoArea.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_SEDE", item.CodigoSede.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_PUESTO", item.CodigoPuesto.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_ACTIVIDAD", item.CodigoActividad.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_CATEGORIA_OCUPACIONAL", item.CodigoCategoriaOcupacional.ToString());
                        cmd.Parameters.AddWithValue("@VC_NUMERO_CONTRATO", item.NumeroContrato.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_MODALIDAD_CONTRATO", item.CodigoModalidadContrato.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_TERMINO_CONTRATO", item.FechaTerminoContrato.ToString());
                        cmd.Parameters.AddWithValue("@VC_NRO_TARJETA_FOTOCHECK", item.NroTarjetaFotocheck.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_JORNADA", item.CodigoJornada.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_TIPO_VACACION", item.CodigoTipoVacacion.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_TIPO_PLANILLA", item.CodigoTipoPlanilla.ToString());
                        cmd.Parameters.AddWithValue("@VC_ENVIO_CORREO_PERSONAL", item.EnvioCorreoPersonal.ToString());
                        cmd.Parameters.AddWithValue("@VC_ENVIO_CORREO_ORGANIZACION", item.EnvioCorreoOrganizacion.ToString());
                        cmd.Parameters.AddWithValue("@VC_CORREO_PERSONAL", item.CorreoPersonal.ToString());
                        cmd.Parameters.AddWithValue("@VC_CORREO_EMPRESA", item.CorreoEmpresa.ToString());
                        cmd.Parameters.AddWithValue("@VC_INDICADOR_BOLETA_INGLES", item.IndicadorBoletaIngles.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_GRADO_ACADEMICO", item.CodigoGradoAcademico.ToString());
                        cmd.Parameters.AddWithValue("@VC_CAPACIDADES_ESPECIALES", item.CapacidadesEspeciales.ToString());
                        cmd.Parameters.AddWithValue("@VC_TIPO_CAPACIDAD_ESPECIAL", item.TipoCapacidadEspecial.ToString());
                        cmd.Parameters.AddWithValue("@VC_TIPO_DISCAPACIDAD_GENERAL", item.TipoDiscapacidadGeneral.ToString());
                        cmd.Parameters.AddWithValue("@VC_PROFESION", item.Profesion.ToString());
                        cmd.Parameters.AddWithValue("@VC_ASOCIACION_SOLIDARISMO", item.AsociacionSolidarismo.ToString());
                        cmd.Parameters.AddWithValue("@VC_PADRE_FAMILIA_CORPORACION", item.PadreFamiliaCorporacion.ToString());
                        cmd.Parameters.AddWithValue("@VC_DIA_DESCANSO", item.DiaDescanso.ToString());
                        cmd.Parameters.AddWithValue("@VC_NRO_EXPEDIENTE_PAIS_EXTRANJERO", item.NroExpedientePaisExtranjero.ToString());
                        cmd.Parameters.AddWithValue("@VC_LUGAR_NACIMIENTO_MUNICIPIO", item.LugarNacimientoMunicipio.ToString());
                        cmd.Parameters.AddWithValue("@VC_PUEBLO_PERTENENCIA", item.PuebloPertenencia.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_BANCO", item.CodigoBanco.ToString());
                        cmd.Parameters.AddWithValue("@VC_NUMERO_CUENTA", item.NumeroCuenta.ToString());
                        cmd.Parameters.AddWithValue("@VC_MONEDA_CUENTA", item.MonedaCuenta.ToString());
                        cmd.Parameters.AddWithValue("@VC_TIPO_CUENTA", item.TipoCuenta.ToString());
                        cmd.Parameters.AddWithValue("@VC_SUELDO", item.Sueldo.ToString());
                        cmd.Parameters.AddWithValue("@VC_MONEDA_SUELDO", item.MonedaSueldo.ToString());                        
                        cmd.Parameters.AddWithValue("@VC_CODIGO_REGIMEN_SALARIAL", item.CodigoRegimenSalarial.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_FORMA_PAGO", item.CodigoFormaPago.ToString());
                        cmd.Parameters.AddWithValue("@VC_TIPO_PAGO", item.TipoPago.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_PERIODICIDAD_PAGO", item.CodigoPeriodicidadPago.ToString());
                        cmd.Parameters.AddWithValue("@VC_NUMERO_HIJOS", item.NumeroHijos.ToString());
                        cmd.Parameters.AddWithValue("@VC_INDICADOR_CONYUGE", item.IndicadorConyuge.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_HORA_OPERACION_REGISTRO_ORACLE", item.FechaHoraOperacionRegistroOracle.ToString());
                        cmd.Parameters.AddWithValue("@VC_NUMERO_OPERACION_ORACLE", item.NumeroOperacionOracle.ToString());
                        cmd.Parameters.AddWithValue("@VC_IDENTIFICADOR_ULTIMO_USUARIO", item.IdentificadorUltimoUsuario.ToString());
                        cmd.Parameters.AddWithValue("@VC_CORREO_ULTIMO_USUARIO", item.CorreoUltimoUsuario.ToString());

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
        protected void mInsertarPermisosBD(List<BE_Permisos>ListPermisos, string ConexionPais)
        {
            using (SqlConnection connection = new SqlConnection(ConexionPais))
            {
                try
                {
                    foreach (var item in ListPermisos)
                    {

                        SqlCommand cmd = new SqlCommand("FINT_SP_INSERTA_INFO_ORACLE_PERMISOS", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 10000;
                        connection.Open();

                        cmd.Parameters.AddWithValue("@VC_CODIGO_PAIS", item.CodigoPais.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_COMPANIA", item.CodigoCompania.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_EMPLEADO_FRACTAL", item.CodigoEmpleadoFRACTAL.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_EMPLEADO_ORACLE", item.CodigoEmpleadoOracle.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_TIPO_DOC_IDENTIDAD", item.CodigoTipoDocIdentidad.ToString());
                        cmd.Parameters.AddWithValue("@VC_NRO_DOC_IDENTIDAD", item.NroDocIdentidad.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_ASISTENCIA", item.FechaAsistencia.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_INICIO_PERMISO", item.FechaInicioPermiso.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_FIN_PERMISO", item.FechaFinPermiso.ToString());
                        cmd.Parameters.AddWithValue("@VC_NUMERO_MINUTOS", item.NumeroMinutos.ToString());
                        cmd.Parameters.AddWithValue("@VC_MOTIVO_PERMISO", item.MotivoPermiso.ToString());
                        cmd.Parameters.AddWithValue("@VC_INDICADOR_PAGO", item.IndicadorPago.ToString());
                        cmd.Parameters.AddWithValue("@VC_SITUACION_OPERACION", item.SituacionOperacion.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_HORA_OPERACION_REGISTRO_ORACLE", item.FechaHoraOperacionRegistroOracle.ToString());
                        cmd.Parameters.AddWithValue("@VC_IDENTIFICADOR_ULTIMO_USUARIO", item.IdentificadorUltimoUsuario.ToString());
                        cmd.Parameters.AddWithValue("@VC_CORREO_ULTIMO_USUARIO", item.CorreoUltimoUsuario.ToString());

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
        //protected void mInsertarSaldosBD(List<BE_SaldoVacaciones>ListSaldos, string ConexionPais)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConexionPais))
        //    {
        //        try
        //        {
        //            foreach (var item in ListSaldos)
        //            {

        //                SqlCommand cmd = new SqlCommand("FINT_SP_INSERTA_INFO_ORACLE_SALDO_VACACIONES", connection);
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandTimeout = 10000;
        //                connection.Open();

        //                cmd.Parameters.AddWithValue("@VC_CODIGO_PAIS", item.CodigoPais.ToString());
        //                cmd.Parameters.AddWithValue("@VC_CODIGO_COMPANIA", item.CodigoCompania.ToString());
        //                cmd.Parameters.AddWithValue("@VC_CODIGO_EMPLEADO_FRACTAL", item.CodigoEmpleadoFRACTAL.ToString());
        //                cmd.Parameters.AddWithValue("@VC_CODIGO_EMPLEADO_ORACLE", item.CodigoEmpleadoOracle.ToString());
        //                cmd.Parameters.AddWithValue("@VC_CODIGO_TIPO_DOC_IDENTIDAD", item.CodigoTipoDocIdentidad.ToString());
        //                cmd.Parameters.AddWithValue("@VC_NRO_DOC_IDENTIDAD", item.NroDocIdentidad.ToString());
        //                cmd.Parameters.AddWithValue("@VC_FECHA_INICIO", item.FechaInicio.ToString());
        //                cmd.Parameters.AddWithValue("@VC_FECHA_FIN", item.FechaFin.ToString());
        //                cmd.Parameters.AddWithValue("@VC_NUMERO_DIAS", item.NumeroDias.ToString());
        //                cmd.Parameters.AddWithValue("@VC_MOTIVO_LICENCIA", item.MotivoLicencia.ToString());
        //                cmd.Parameters.AddWithValue("@VC_GRUPO_LICENCIA", item.GrupoLicencia.ToString());
        //                cmd.Parameters.AddWithValue("@VC_TIPO_PAGO_LICENCIA", item.TipoPagoLicencia.ToString());
        //                cmd.Parameters.AddWithValue("@VC_SITUACION_OPERACION", item.SituacionOperacion.ToString());
        //                cmd.Parameters.AddWithValue("@VC_FECHA_HORA_OPERACION_REGISTRO_ORACLE", item.FechaHoraOperacionRegistroOracle.ToString());
        //                cmd.Parameters.AddWithValue("@VC_IDENTIFICADOR_ULTIMO_USUARIO", item.IdentificadorUltimoUsuario.ToString());
        //                cmd.Parameters.AddWithValue("@VC_CORREO_ULTIMO_USUARIO", item.CorreoUltimoUsuario.ToString());
        //                cmd.ExecuteNonQuery();

        //                connection.Close();
        //            }


        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //    }
        //}
        protected void mInsertarSindicatosBD(List<BE_Sindicatos>ListSindicatos, string ConexionPais)
        {
            using (SqlConnection connection = new SqlConnection(ConexionPais))
            {
                try
                {
                    foreach (var item in ListSindicatos)
                    {

                        SqlCommand cmd = new SqlCommand("FINT_SP_INSERTA_INFO_ORACLE_SINDICATOS", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 10000;
                        connection.Open();

                        cmd.Parameters.AddWithValue("@VC_CODIGO_PAIS", item.CodigoPais.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_COMPANIA", item.CodigoCompania.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_EMPLEADO_FRACTAL", item.CodigoEmpleadoFRACTAL.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_EMPLEADO_ORACLE", item.CodigoEmpleadoOracle.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_TIPO_DOC_IDENTIDAD", item.CodigoTipoDocIdentidad.ToString());
                        cmd.Parameters.AddWithValue("@VC_NRO_DOC_IDENTIDAD", item.NroDocIdentidad.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_SINDICATO", item.CodigoSindicato.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_INICIO", item.FechaInicio.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_FIN", item.FechaFin.ToString());
                        cmd.Parameters.AddWithValue("@VC_SITUACION_OPERACION", item.SituacionOperacion.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_HORA_OPERACION_REGISTRO_ORACLE", item.FechaHoraOperacionRegistroOracle.ToString());
                        cmd.Parameters.AddWithValue("@VC_IDENTIFICADOR_ULTIMO_USUARIO", item.IdentificadorUltimoUsuario.ToString());
                        cmd.Parameters.AddWithValue("@VC_CORREO_ULTIMO_USUARIO", item.CorreoUltimoUsuario.ToString());
                        
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

        protected void mInsertarVacacionesBD(List<BE_Vacaciones>ListVacaciones, string ConexionPais)
        {
            using (SqlConnection connection = new SqlConnection(ConexionPais))
            {
                try
                {
                    foreach (var item in ListVacaciones)
                    {

                        SqlCommand cmd = new SqlCommand("FINT_SP_INSERTA_INFO_ORACLE_VACACIONES", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 10000;
                        connection.Open();

                        cmd.Parameters.AddWithValue("@VC_CODIGO_PAIS", item.CodigoPais.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_COMPANIA", item.CodigoCompania.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_EMPLEADO_FRACTAL", item.CodigoEmpleadoFRACTAL.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_EMPLEADO_ORACLE", item.CodigoEmpleadoOracle.ToString());
                        cmd.Parameters.AddWithValue("@VC_CODIGO_TIPO_DOC_IDENTIDAD", item.CodigoTipoDocIdentidad.ToString());
                        cmd.Parameters.AddWithValue("@VC_NRO_DOC_IDENTIDAD", item.NroDocIdentidad.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_INICIO", item.FechaInicio.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_FIN", item.FechaFin.ToString());
                        cmd.Parameters.AddWithValue("@VC_NUMERO_DIAS", item.NumeroDias.ToString());
                        cmd.Parameters.AddWithValue("@VC_TIPO_GOCE_VACACIONAL", item.TipoGoceVacacional.ToString());                       
                        cmd.Parameters.AddWithValue("@VC_FECHA_REGISTRO_VACACION", item.FechaRegistroVacacion.ToString());
                        cmd.Parameters.AddWithValue("@VC_SITUACION_OPERACION", item.SituacionOperacion.ToString());
                        cmd.Parameters.AddWithValue("@VC_FECHA_HORA_OPERACION_REGISTRO_ORACLE", item.FechaHoraOperacionRegistroOracle.ToString());
                        cmd.Parameters.AddWithValue("@VC_IDENTIFICADOR_ULTIMO_USUARIO", item.IdentificadorUltimoUsuario.ToString());
                        cmd.Parameters.AddWithValue("@VC_CORREO_ULTIMO_USUARIO", item.CorreoUltimoUsuario.ToString());
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
