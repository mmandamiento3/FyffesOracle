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
            //Variables
            string Ingresos = "IngresosModifPersonal_";
            string Permisos = "Permisos_";
            string SaldoVac = "SaldoVacaciones_";
            string Sindicatos = "Sindicatos_";
            string Vacaciones = "Vacaciones_";
            string Ausencias = "Ausencias_";
            string Ceses = "CesesPersonales_";


            //DirectoryInfo directorio = new DirectoryInfo(@"C:\Users\Christian.morales\Desktop\Requerimiento");
            string DirectorioArchivos = ConfigurationManager.AppSettings["RutaArchivo"].ToString();
            DirectoryInfo directorio = new DirectoryInfo(DirectorioArchivos);
            FileInfo[] Archivos = directorio.GetFiles("*.txt");

            if (String.IsNullOrEmpty(DirectorioArchivos)) throw new Exception("No se encuentra el directorio");

            if (Archivos.Length != 0) //Ob tenemos solo los archivos con extension .txt
            {
                foreach (FileInfo archivo in Archivos) //Recorremos los archivos .txt
                {
                    if (archivo.FullName.Contains(Ausencias))
                    {
                        mListarAusencias(archivo);
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
            //Console.WriteLine(model);
            //Console.ReadKey();

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
                            FechaInicio = Convert.ToDateTime(item.FechaInicio),
                            FechaFin = Convert.ToDateTime(item.FechaFin),
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

                    BLClass.mInsertarArchivo(ListaAusencias);
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


