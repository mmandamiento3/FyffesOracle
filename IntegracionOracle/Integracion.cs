using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionBLL;
using IntegracionBEL;
using System.IO;

namespace IntegracionOracle
{
    class Integracion
    {
        static void Main(string[] args)
        {
            CargarArchivo();

        }

        public static void CargarArchivo()
        {
            //Variables de los documentos
            string Ausencias = ConfigurationManager.AppSettings["Ausencias"].ToString();
            string Ceses = ConfigurationManager.AppSettings["Ceses"].ToString();
            string Ingresos = ConfigurationManager.AppSettings["Ingresos"].ToString();            
            string Permisos = ConfigurationManager.AppSettings["Permisos"].ToString();            
            string Saldo = ConfigurationManager.AppSettings["Saldo"].ToString();            
            string Sindicatos = ConfigurationManager.AppSettings["Sindicatos"].ToString();            
            string Vacaciones = ConfigurationManager.AppSettings["Vacaciones"].ToString();            
                       
                       

            //DirectoryInfo directorio = new DirectoryInfo(@"C:\Users\Christian.morales\Desktop\Requerimiento");
            string DirectorioArchivos = ConfigurationManager.AppSettings["RutaArchivo"].ToString();
            DirectoryInfo directorio = new DirectoryInfo(DirectorioArchivos);
            FileInfo[] Archivos = directorio.GetFiles("*.txt");

            if (String.IsNullOrEmpty(DirectorioArchivos)) throw new Exception("No se encuentra el directorio");

            if (Archivos.Length != 0) //Ob tenemos solo los archivos con extension .txt
            {
                foreach (FileInfo archivo in Archivos) //Recorremos los archivos .txt
                {
                    if (archivo.Name.StartsWith(Ausencias))
                    {
                        mListarAusencias(archivo);
                    }
                    if (archivo.Name.StartsWith(Ceses))
                    {
                        mListarCese(archivo);
                    }
                    if (archivo.Name.StartsWith(Ingresos))
                    {
                        mListarIngresos(archivo);
                    }
                    if (archivo.Name.StartsWith(Permisos))
                    {
                        mListarPermisos(archivo);
                    }
                    if (archivo.Name.StartsWith(Saldo))
                    {
                        mListarSaldoVacaciones(archivo);
                    }
                    if (archivo.Name.StartsWith(Sindicatos))
                    {
                        mListarSindicatos(archivo);
                    }
                    if (archivo.Name.StartsWith(Vacaciones))
                    {
                        mListarVacaciones(archivo);
                    }
                }
            }
        }

        static void mListarAusencias(FileInfo txt)
        {
            BLL_Archivo BLClass = new BLL_Archivo();
            char separador = '|';
            string[] texto = File.ReadAllLines(txt.FullName);

            var model = texto.Select(p => new
            {
                CodigoPais = p.Split(separador)[0],
                CodigoCompania = p.Split(separador)[1],
                CodigoEmpleadoFRACTAL = p.Split(separador)[2],
                CodigoEmpleadoOracle = p.Split(separador)[3],
                CodigoTipoDocIdentidad = p.Split(separador)[4],
                NroDocIdentidad = p.Split(separador)[5],
                FechaInicio = p.Split(separador)[6],
                FechaFin = p.Split(separador)[7],
                NumeroDias = p.Split(separador)[8],
                MotivoLicencia = p.Split(separador)[9],
                GrupoLicencia = p.Split(separador)[10],
                TipoPagoLicencia = p.Split(separador)[11],
                SituacionOperacion = p.Split(separador)[12],
                FechaHoraOperacionRegistroOracle = p.Split(separador)[13],
                IdentificadorUltimoUsuario = p.Split(separador)[14],
                CorreoUltimoUsuario = p.Split(separador)[15]
            });
        

            List<BE_Ausencias> ListaAusencias = new List<BE_Ausencias>();
            try
            {
                if (model.Count() > 0) //validamos que hayan registros
                {
                    foreach (var item in model.Where((item, index) => index != 0)) //Quitamos el primer registro (cabecera)
                    {
                        //Insertamos en la LISTA
                        ListaAusencias.Add(new BE_Ausencias
                        {
                            CodigoPais = item.CodigoPais.ToString(),
                            CodigoCompania = item.CodigoCompania.ToString(),
                            CodigoEmpleadoFRACTAL = item.CodigoEmpleadoFRACTAL.ToString(),
                            CodigoEmpleadoOracle = item.CodigoEmpleadoOracle.ToString(),
                            CodigoTipoDocIdentidad = item.CodigoTipoDocIdentidad.ToString(),
                            NroDocIdentidad = item.NroDocIdentidad.ToString(),
                            FechaInicio = item.FechaInicio.ToString(),
                            FechaFin = item.FechaFin.ToString(),
                            NumeroDias = item.NumeroDias.ToString(),
                            MotivoLicencia = item.MotivoLicencia.ToString(),
                            GrupoLicencia = item.GrupoLicencia.ToString(),
                            TipoPagoLicencia = item.TipoPagoLicencia.ToString(),
                            SituacionOperacion = item.SituacionOperacion.ToString(),
                            FechaHoraOperacionRegistroOracle = item.FechaHoraOperacionRegistroOracle.ToString(),
                            IdentificadorUltimoUsuario = item.IdentificadorUltimoUsuario.ToString(),
                            CorreoUltimoUsuario = item.CorreoUltimoUsuario.ToString()
                        });
                    }

                    BLClass.mInsertarArchivoAusencias(ListaAusencias);
                }
                else
                {
                    Console.WriteLine("No se encontraron registros");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        static void mListarCese(FileInfo txt)
        {
            BLL_Archivo BLClass = new BLL_Archivo();
            char separador = '|';
            string[] texto = File.ReadAllLines(txt.FullName);

            var model = texto.Select(p => new
            {
                CodigoPais = p.Split(separador)[0],
                CodigoCompania = p.Split(separador)[1],
                CodigoEmpleadoFRACTAL = p.Split(separador)[2],
                CodigoEmpleadoOracle = p.Split(separador)[3],
                CodigoTipoDocIdentidad = p.Split(separador)[4],
                NroDocIdentidad = p.Split(separador)[5],
                FechaCese = p.Split(separador)[6],
                MotivoCese = p.Split(separador)[7],
                IndicadorIndemnizacion = p.Split(separador)[8],
                IndicadorPreaviso = p.Split(separador)[9],
                FormaPago = p.Split(separador)[10],
                SituacionOperacion = p.Split(separador)[11],
                FechaHoraOperacionRegistroOracle = p.Split(separador)[12],
                IdentificadorUltimoUsuario = p.Split(separador)[13],
                CorreoUltimoUsuario = p.Split(separador)[14],
               
            });


            List<BE_Ceses> ListaCeses = new List<BE_Ceses>();
            try
            {
                if (model.Count() > 0) //validamos que hayan registros
                {
                    foreach (var item in model.Where((item, index) => index != 0)) //Quitamos el primer registro (cabecera)
                    {
                        //Insertamos en la LISTA
                        ListaCeses.Add(new BE_Ceses
                        {
                            CodigoPais = item.CodigoPais.ToString(),
                            CodigoCompania = item.CodigoCompania.ToString(),
                            CodigoEmpleadoFRACTAL = item.CodigoEmpleadoFRACTAL.ToString(),
                            CodigoEmpleadoOracle = item.CodigoEmpleadoOracle.ToString(),
                            CodigoTipoDocIdentidad = item.CodigoTipoDocIdentidad.ToString(),
                            NroDocIdentidad = item.NroDocIdentidad.ToString(),
                            FechaCese = item.FechaCese.ToString(),
                            MotivoCese = item.MotivoCese.ToString(),
                            IndicadorIndemnizacion = item.IndicadorIndemnizacion.ToString(),
                            IndicadorPreaviso = item.IndicadorPreaviso.ToString(),
                            FormaPago = item.FormaPago.ToString(),
                            SituacionOperacion = item.SituacionOperacion.ToString(),
                            FechaHoraOperacionRegistroOracle = item.SituacionOperacion.ToString(),
                            IdentificadorUltimoUsuario = item.FechaHoraOperacionRegistroOracle.ToString(),
                            CorreoUltimoUsuario = item.IdentificadorUltimoUsuario.ToString(),
                            
                        });
                    }

                    BLClass.mInsertarArchivoCeses(ListaCeses);
                }
                else
                {
                    Console.WriteLine("No se encontraron registros");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        static void mListarIngresos(FileInfo txt)
        {
            BLL_Archivo BLClass = new BLL_Archivo();
            char separador = '|';
            string[] texto = File.ReadAllLines(txt.FullName);

            var model = texto.Select(p => new 
            {
                TipoOperacion = p.Split(separador)[0],
                CodigoPais = p.Split(separador)[1],
                CodigoCompania = p.Split(separador)[2],
                CodigoEmpleadoFRACTAL = p.Split(separador)[3],
                CodigoEmpleadoOracle = p.Split(separador)[4],
                ApellidoPaterno = p.Split(separador)[5],
                ApellidoMaterno = p.Split(separador)[6],
                Nombres = p.Split(separador)[7],
                CodigoSexo = p.Split(separador)[8],
                CodigoEstadoCivil = p.Split(separador)[9],
                CodigoNacionalidad = p.Split(separador)[10],
                TipoNacionalidad = p.Split(separador)[11],
                CodigoTipoDocIdentidad = p.Split(separador)[12],
                NroDocIdentidad = p.Split(separador)[13],
                LugarEmision = p.Split(separador)[14],
                NroSeguroSocial = p.Split(separador)[15],
                NroIdentificacionTributaria = p.Split(separador)[16],
                NombreSeguroSocial = p.Split(separador)[17],
                FechaNacimiento = p.Split(separador)[18],
                LugarNacimiento = p.Split(separador)[19],
                CodigoLugarNacimiento = p.Split(separador)[20],
                DireccionDomicilio = p.Split(separador)[21],
                NumeroTelefono = p.Split(separador)[22],
                FechaInicioLabores = p.Split(separador)[23],
                CodigoTipoEmpleado = p.Split(separador)[24],
                CodigoClasificacionEmpleado = p.Split(separador)[25],
                IdAlternativo = p.Split(separador)[26],
                Reingresante = p.Split(separador)[27],
                FechaReingreso = p.Split(separador)[28],
                Sindicalizado = p.Split(separador)[29],
                UltimoSindicato = p.Split(separador)[30],
                CodigoArea = p.Split(separador)[31],
                CodigoSede = p.Split(separador)[32],
                CodigoPuesto = p.Split(separador)[33],
                CodigoActividad = p.Split(separador)[34],
                CodigoCategoriaOcupacional = p.Split(separador)[35],
                NumeroContrato = p.Split(separador)[36],
                CodigoModalidadContrato = p.Split(separador)[37],
                FechaTerminoContrato = p.Split(separador)[38],
                NroTarjetaFotocheck = p.Split(separador)[39],
                CodigoJornada = p.Split(separador)[40],
                CodigoTipoVacacion = p.Split(separador)[41],
                CodigoTipoPlanilla = p.Split(separador)[42],
                EnvioCorreoPersonal = p.Split(separador)[43],
                EnvioCorreoOrganizacion  = p.Split(separador)[44],
                CorreoPersonal = p.Split(separador)[45],
                CorreoEmpresa = p.Split(separador)[46],
                IndicadorBoletaIngles = p.Split(separador)[47],
                CodigoGradoAcademico = p.Split(separador)[48],
                CapacidadesEspeciales = p.Split(separador)[49],
                TipoCapacidadEspecial = p.Split(separador)[50],
                TipoDiscapacidadGeneral = p.Split(separador)[51],
                Profesion = p.Split(separador)[52],
                AsociacionSolidarismo = p.Split(separador)[53],
                PadreFamiliaCorporacion = p.Split(separador)[54],
                DiaDescanso = p.Split(separador)[55],
                NroExpedientePaisExtranjero = p.Split(separador)[56],
                LugarNacimientoMunicipio = p.Split(separador)[57],
                PuebloPertenencia = p.Split(separador)[58],
                CodigoBanco = p.Split(separador)[59],
                NumeroCuenta = p.Split(separador)[60],
                Moneda = p.Split(separador)[61],
                TipoCuenta = p.Split(separador)[62],
                Sueldo = p.Split(separador)[63],
                CodigoRegimenSalarial = p.Split(separador)[64],
                CodigoFormaPago = p.Split(separador)[65],
                TipoPago = p.Split(separador)[66],
                CodigoPeriodicidadPago = p.Split(separador)[67],
                NumeroHijos = p.Split(separador)[68],
                IndicadorConyuge = p.Split(separador)[69],
                FechaHoraOperacionRegistroOracle = p.Split(separador)[70],
                NumeroOperacionOracle = p.Split(separador)[71],
                IdentificadorUltimoUsuario = p.Split(separador)[72],
                CorreoUltimoUsuario = p.Split(separador)[73],               

            });

            List<BE_Ingresos> ListaIngresos = new List<BE_Ingresos>();
            try
            {
                if (model.Count() > 0) //validamos que hayan registros
                {
                    foreach (var item in model.Where((item, index) => index != 0)) //Quitamos el primer registro (cabecera)
                    {
                        //Insertamos en la LISTA
                        ListaIngresos.Add(new BE_Ingresos
                        {
                            TipoOperacion                     =   item.TipoOperacion.ToString(),
                            CodigoPais                        =   item.CodigoPais.ToString(),
                            CodigoCompania                    =   item.CodigoCompania.ToString(),
                            CodigoEmpleadoFRACTAL             =   item.CodigoEmpleadoFRACTAL.ToString(),
                            CodigoEmpleadoOracle              =   item.CodigoEmpleadoOracle.ToString(),                            
                            ApellidoPaterno                   =   item.ApellidoPaterno.ToString(),
                            ApellidoMaterno                   =   item.ApellidoMaterno.ToString(),
                            Nombres                           =   item.Nombres.ToString(),
                            CodigoSexo                        =   item.CodigoSexo.ToString(),
                            CodigoEstadoCivil                 =   item.CodigoEstadoCivil.ToString(),  
                            CodigoNacionalidad                =   item.CodigoNacionalidad.ToString(),
                            TipoNacionalidad                  =   item.TipoNacionalidad.ToString(),
                            CodigoTipoDocIdentidad            =   item.CodigoTipoDocIdentidad.ToString(),
                            NroDocIdentidad                   =   item.NroDocIdentidad.ToString(),
                            LugarEmision                      =   item.LugarEmision.ToString(),
                            NroSeguroSocial                   =   item.NroSeguroSocial.ToString(),
                            NroIdentificacionTributaria       =   item.NroIdentificacionTributaria.ToString(),
                            NombreSeguroSocial                =   item.NroSeguroSocial.ToString(),
                            FechaNacimiento                   =   item.FechaNacimiento.ToString(),
                            LugarNacimiento                   =   item.LugarNacimiento.ToString(),
                            CodigoLugarNacimiento             =   item.CodigoLugarNacimiento.ToString(),
                            DireccionDomicilio                =   item.DireccionDomicilio.ToString(),
                            NumeroTelefono                    =   item.NumeroTelefono.ToString(),
                            FechaInicioLabores                =   item.FechaInicioLabores.ToString(),
                            CodigoTipoEmpleado                =   item.CodigoTipoEmpleado.ToString(),
                            CodigoClasificacionEmpleado       =   item.CodigoClasificacionEmpleado.ToString(),
                            IdAlternativo                     =   item.IdAlternativo.ToString(),
                            Reingresante                      =   item.Reingresante.ToString(),
                            FechaReingreso                    =   item.FechaReingreso.ToString(),
                            Sindicalizado                     =   item.Sindicalizado.ToString(),
                            UltimoSindicato                   =   item.UltimoSindicato.ToString(),
                            CodigoArea                        =   item.CodigoArea.ToString(),
                            CodigoSede                        =   item.CodigoSede.ToString(),
                            CodigoPuesto                      =   item.CodigoPuesto.ToString(),
                            CodigoActividad                   =   item.CodigoActividad.ToString(),
                            CodigoCategoriaOcupacional        =   item.CodigoCategoriaOcupacional.ToString(),
                            NumeroContrato                    =   item.NumeroContrato.ToString(),
                            CodigoModalidadContrato           =   item.CodigoModalidadContrato.ToString(),
                            FechaTerminoContrato              =   item.FechaTerminoContrato.ToString(),
                            NroTarjetaFotocheck               =   item.NroTarjetaFotocheck.ToString(),
                            CodigoJornada                     =   item.CodigoJornada.ToString(),
                            CodigoTipoVacacion                =   item.CodigoTipoVacacion.ToString(),
                            CodigoTipoPlanilla                =   item.CodigoTipoPlanilla.ToString(),
                            EnvioCorreoPersonal               =   item.EnvioCorreoPersonal.ToString(),
                            EnvioCorreoOrganizacion           =   item.EnvioCorreoOrganizacion.ToString(),
                            CorreoPersonal                    =   item.CorreoPersonal.ToString(),
                            CorreoEmpresa                     =   item.CorreoEmpresa.ToString(),
                            IndicadorBoletaIngles             =   item.IndicadorBoletaIngles.ToString(),
                            CodigoGradoAcademico              =   item.CodigoGradoAcademico.ToString(),
                            CapacidadesEspeciales             =   item.CapacidadesEspeciales.ToString(),
                            TipoCapacidadEspecial             =   item.TipoCapacidadEspecial.ToString(),                            
                            TipoDiscapacidadGeneral           =   item.TipoDiscapacidadGeneral.ToString(),
                            Profesion                         =   item.Profesion.ToString(),
                            AsociacionSolidarismo             =   item.AsociacionSolidarismo.ToString(),
                            PadreFamiliaCorporacion           =   item.PadreFamiliaCorporacion.ToString(),                           
                            DiaDescanso                       =   item.DiaDescanso.ToString(),
                            NroExpedientePaisExtranjero       =   item.NroExpedientePaisExtranjero.ToString(),
                            LugarNacimientoMunicipio          =   item.LugarNacimientoMunicipio.ToString(),
                            PuebloPertenencia                 =   item.PuebloPertenencia.ToString(),
                            CodigoBanco                       =   item.CodigoBanco.ToString(),
                            NumeroCuenta                      =   item.NumeroCuenta.ToString(),
                            Moneda                            =   item.Moneda.ToString(),
                            TipoCuenta                        =   item.TipoCuenta.ToString(),
                            Sueldo                            =   item.Sueldo.ToString(),
                            CodigoRegimenSalarial             =   item.CodigoRegimenSalarial.ToString(),
                            CodigoFormaPago                   =   item.CodigoFormaPago.ToString(),
                            TipoPago                          =   item.TipoPago.ToString(),
                            CodigoPeriodicidadPago            =   item.CodigoPeriodicidadPago.ToString(),
                            NumeroHijos                       =   item.NumeroHijos.ToString(),
                            IndicadorConyuge                  =   item.IndicadorConyuge.ToString(),
                            FechaHoraOperacionRegistroOracle  =   item.FechaHoraOperacionRegistroOracle.ToString(),
                            NumeroOperacionOracle             =   item.NumeroOperacionOracle.ToString(),
                            IdentificadorUltimoUsuario        =   item.IdentificadorUltimoUsuario.ToString(),
                            CorreoUltimoUsuario               =   item.CorreoUltimoUsuario.ToString()
                                                              

                        }); 
                    }

                    BLClass.mInsertarArchivoIngresos(ListaIngresos);
                }
                else
                {
                    Console.WriteLine("No se encontraron registros");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        static void mListarPermisos(FileInfo txt)
        {
            BLL_Archivo BLClass = new BLL_Archivo();
            char separador = '|';
            string[] texto = File.ReadAllLines(txt.FullName);

            var model = texto.Select(p => new
            {
                CodigoPais = p.Split(separador)[0],
                CodigoCompania = p.Split(separador)[1],
                CodigoEmpleadoFRACTAL = p.Split(separador)[2],
                CodigoEmpleadoOracle = p.Split(separador)[3],
                CodigoTipoDocIdentidad = p.Split(separador)[4],
                NroDocIdentidad = p.Split(separador)[5],
                FechaAsistencia = p.Split(separador)[6],
                FechaInicioPermiso = p.Split(separador)[7],
                FechaFinPermiso = p.Split(separador)[8],
                NumeroMinutos = p.Split(separador)[9],
                MotivoPermiso = p.Split(separador)[10],
                IndicadorPago = p.Split(separador)[11],
                SituacionOperacion = p.Split(separador)[12],
                FechaHoraOperacionRegistroOracle = p.Split(separador)[13],
                IdentificadorUltimoUsuario = p.Split(separador)[14],
                CorreoUltimoUsuario = p.Split(separador)[15]
            });

            List<BE_Permisos> ListaPermisos = new List<BE_Permisos>();
            try
            {
                if (model.Count() > 0) //validamos que hayan registros
                {
                    foreach (var item in model.Where((item, index) => index != 0)) //Quitamos el primer registro (cabecera)
                    {
                        //Insertamos en la LISTA
                        ListaPermisos.Add(new BE_Permisos
                        {
                            CodigoPais = item.CodigoPais.ToString(),
                            CodigoCompania = item.CodigoCompania.ToString(),
                            CodigoEmpleadoFRACTAL = item.CodigoEmpleadoFRACTAL.ToString(),
                            CodigoEmpleadoOracle = item.CodigoEmpleadoOracle.ToString(),
                            CodigoTipoDocIdentidad = item.CodigoTipoDocIdentidad.ToString(),
                            NroDocIdentidad = item.NroDocIdentidad.ToString(),
                            FechaAsistencia = item.FechaAsistencia.ToString(),
                            FechaInicioPermiso = item.FechaInicioPermiso.ToString(),
                            FechaFinPermiso = item.FechaFinPermiso.ToString(),
                            NumeroMinutos = item.NumeroMinutos.ToString(),
                            MotivoPermiso = item.MotivoPermiso.ToString(),
                            IndicadorPago = item.IndicadorPago.ToString(),
                            SituacionOperacion = item.SituacionOperacion.ToString(),
                            FechaHoraOperacionRegistroOracle = item.FechaHoraOperacionRegistroOracle.ToString(),
                            IdentificadorUltimoUsuario = item.IdentificadorUltimoUsuario.ToString(),
                            CorreoUltimoUsuario = item.CorreoUltimoUsuario.ToString()
                        });
                    }

                    BLClass.mInsertarArchivoPermisos(ListaPermisos);
                }
                else
                {
                    Console.WriteLine("No se encontraron registros");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        static void mListarSaldoVacaciones(FileInfo txt)
        {
            BLL_Archivo BLClass = new BLL_Archivo();
            char separador = '|';
            string[] texto = File.ReadAllLines(txt.FullName);

            var model = texto.Select(p => new
            {
                CodigoPais = p.Split(separador)[0],
                CodigoCompania = p.Split(separador)[1],
                CodigoEmpleadoFRACTAL = p.Split(separador)[2],
                CodigoEmpleadoOracle = p.Split(separador)[3],
                CodigoTipoDocIdentidad = p.Split(separador)[4],
                NroDocIdentidad = p.Split(separador)[5],
                FechaInicio = p.Split(separador)[6],
                FechaFin = p.Split(separador)[7],
                NumeroDias = p.Split(separador)[8],
                MotivoLicencia = p.Split(separador)[9],
                GrupoLicencia = p.Split(separador)[10],
                TipoPagoLicencia = p.Split(separador)[11],
                SituacionOperacion = p.Split(separador)[12],
                FechaHoraOperacionRegistroOracle = p.Split(separador)[13],
                IdentificadorUltimoUsuario = p.Split(separador)[14],
                CorreoUltimoUsuario = p.Split(separador)[15]
            });


            List<BE_SaldoVacaciones> ListaSaldoVacaciones = new List<BE_SaldoVacaciones>();
            try
            {
                if (model.Count() > 0) //validamos que hayan registros
                {
                    foreach (var item in model.Where((item, index) => index != 0)) //Quitamos el primer registro (cabecera)
                    {
                        //Insertamos en la LISTA
                        ListaSaldoVacaciones.Add(new BE_SaldoVacaciones
                        {
                            CodigoPais = item.CodigoPais.ToString(),
                            CodigoCompania = item.CodigoCompania.ToString(),
                            CodigoEmpleadoFRACTAL = item.CodigoEmpleadoFRACTAL.ToString(),
                            CodigoEmpleadoOracle = item.CodigoEmpleadoOracle.ToString(),
                            CodigoTipoDocIdentidad = item.CodigoTipoDocIdentidad.ToString(),
                            NroDocIdentidad = item.NroDocIdentidad.ToString(),
                            FechaInicio = item.FechaInicio.ToString(),
                            FechaFin = item.FechaFin.ToString(),
                            NumeroDias = item.NumeroDias.ToString(),
                            MotivoLicencia = item.MotivoLicencia.ToString(),
                            GrupoLicencia = item.GrupoLicencia.ToString(),
                            TipoPagoLicencia = item.TipoPagoLicencia.ToString(),
                            SituacionOperacion = item.SituacionOperacion.ToString(),
                            FechaHoraOperacionRegistroOracle = item.FechaHoraOperacionRegistroOracle.ToString(),
                            IdentificadorUltimoUsuario = item.IdentificadorUltimoUsuario.ToString(),
                            CorreoUltimoUsuario = item.CorreoUltimoUsuario.ToString()
                        });
                    }

                    BLClass.mInsertarArchivoSaldoVacaciones(ListaSaldoVacaciones);
                }
                else
                {
                    Console.WriteLine("No se encontraron registros");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        static void mListarSindicatos (FileInfo txt)
        {
            BLL_Archivo BLClass = new BLL_Archivo();
            char separador = '|';
            string[] texto = File.ReadAllLines(txt.FullName);

            var model = texto.Select(p => new
            {
                CodigoPais = p.Split(separador)[0],
                CodigoCompania = p.Split(separador)[1],
                CodigoEmpleadoFRACTAL = p.Split(separador)[2],
                CodigoEmpleadoOracle = p.Split(separador)[3],
                CodigoTipoDocIdentidad = p.Split(separador)[4],
                NroDocIdentidad = p.Split(separador)[5],
                CodigoSindicato = p.Split(separador)[6],
                PorcentajeSindicato = p.Split(separador)[7],
                MontoSindicato = p.Split(separador)[8],
                SituacionOperacion = p.Split(separador)[9],
                FechaHoraOperacionRegistroOracle = p.Split(separador)[10],
                IdentificadorUltimoUsuario = p.Split(separador)[11],
                CorreoUltimoUsuario = p.Split(separador)[12]
               
            });


            List<BE_Sindicatos> ListaSindicatos = new List<BE_Sindicatos>();
            try
            {
                if (model.Count() > 0) //validamos que hayan registros
                {
                    foreach (var item in model.Where((item, index) => index != 0)) //Quitamos el primer registro (cabecera)
                    {
                        //Insertamos en la LISTA
                        ListaSindicatos.Add(new BE_Sindicatos
                        {
                            CodigoPais = item.CodigoPais.ToString(),
                            CodigoCompania = item.CodigoCompania.ToString(),
                            CodigoEmpleadoFRACTAL = item.CodigoEmpleadoFRACTAL.ToString(),
                            CodigoEmpleadoOracle = item.CodigoEmpleadoOracle.ToString(),
                            CodigoTipoDocIdentidad = item.CodigoTipoDocIdentidad.ToString(),
                            NroDocIdentidad = item.NroDocIdentidad.ToString(),
                            CodigoSindicato = item.CodigoSindicato.ToString(),
                            PorcentajeSindicato = item.PorcentajeSindicato.ToString(),
                            MontoSindicato = item.MontoSindicato.ToString(),
                            SituacionOperacion = item.SituacionOperacion.ToString(),
                            FechaHoraOperacionRegistroOracle = item.FechaHoraOperacionRegistroOracle.ToString(),
                            IdentificadorUltimoUsuario = item.IdentificadorUltimoUsuario.ToString(),
                            CorreoUltimoUsuario = item.CorreoUltimoUsuario.ToString()
                            
                        });
                    }

                    BLClass.mInsertarArchivoSindicatos(ListaSindicatos);
                }
                else
                {
                    Console.WriteLine("No se encontraron registros");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }

        static void mListarVacaciones(FileInfo txt)
        {
            BLL_Archivo BLClass = new BLL_Archivo();
            char separador = '|';
            string[] texto = File.ReadAllLines(txt.FullName);

            var model = texto.Select(p => new
            {
                CodigoPais = p.Split(separador)[0],
                CodigoCompania = p.Split(separador)[1],
                CodigoEmpleadoFRACTAL = p.Split(separador)[2],
                CodigoEmpleadoOracle = p.Split(separador)[3],
                CodigoTipoDocIdentidad = p.Split(separador)[4],
                NroDocIdentidad = p.Split(separador)[5],
                FechaInicio = p.Split(separador)[6],
                FechaFin = p.Split(separador)[7],
                NumeroDias = p.Split(separador)[8],
                TipoGoceVacacional = p.Split(separador)[9],
                FechaInicioPeriodoVacacional = p.Split(separador)[10],
                FechaFinPeriodoVacacional = p.Split(separador)[11],
                AnhioPeriodoVacacional = p.Split(separador)[12],
                RegimenTipoVacacion = p.Split(separador)[13],
                FechaRegistroVacacion = p.Split(separador)[14],
                SituacionOperacion = p.Split(separador)[15],
                FechaHoraOperacionRegistroOracle = p.Split(separador)[16],
                IdentificadorUltimoUsuario = p.Split(separador)[17],
                CorreoUltimoUsuario = p.Split(separador)[18]
            });


            List<BE_Vacaciones> ListaVacaciones = new List<BE_Vacaciones>();
            try
            {
                if (model.Count() > 0) //validamos que hayan registros
                {
                    foreach (var item in model.Where((item, index) => index != 0)) //Quitamos el primer registro (cabecera)
                    {
                        //Insertamos en la LISTA
                        ListaVacaciones.Add(new BE_Vacaciones
                        {
                            CodigoPais = item.CodigoPais.ToString(),
                            CodigoCompania = item.CodigoCompania.ToString(),
                            CodigoEmpleadoFRACTAL = item.CodigoEmpleadoFRACTAL.ToString(),
                            CodigoEmpleadoOracle = item.CodigoEmpleadoOracle.ToString(),
                            CodigoTipoDocIdentidad = item.CodigoTipoDocIdentidad.ToString(),
                            NroDocIdentidad = item.NroDocIdentidad.ToString(),
                            FechaInicio = item.FechaInicio.ToString(),
                            FechaFin = item.FechaFin.ToString(),
                            NumeroDias = item.NumeroDias.ToString(),
                            TipoGoceVacacional = item.TipoGoceVacacional.ToString(),
                            FechaInicioPeriodoVacacional = item.FechaInicioPeriodoVacacional.ToString(),
                            FechaFinPeriodoVacacional = item.FechaFinPeriodoVacacional.ToString(),
                            AnhioPeriodoVacacional = item.AnhioPeriodoVacacional.ToString(),
                            RegimenTipoVacacion = item.RegimenTipoVacacion.ToString(),
                            FechaRegistroVacacion = item.FechaRegistroVacacion.ToString(),
                            SituacionOperacion = item.SituacionOperacion.ToString(),
                            FechaHoraOperacionRegistroOracle = item.FechaHoraOperacionRegistroOracle.ToString(),
                            IdentificadorUltimoUsuario = item.IdentificadorUltimoUsuario.ToString(),
                            CorreoUltimoUsuario = item.CorreoUltimoUsuario.ToString()
                        }) ;
                    }

                    BLClass.mInsertarArchivoVacaciones(ListaVacaciones);
                }
                else
                {
                    Console.WriteLine("No se encontraron registros");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
    }
}


