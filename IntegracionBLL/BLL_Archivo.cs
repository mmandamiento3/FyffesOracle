using IntegracionBEL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegracionDAL;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace IntegracionBLL
{
    public class BLL_Archivo
    {

        public void mInsertarArchivoAusencias(List<BE_Ausencias> Ausencia)
        {
            try
            {
                 new DA_Integracion().mInsertarArchivoAusenciasBD(Ausencia);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Exception Policy");
                throw ex;
            }
            
        }


        public void mInsertarArchivoCeses(List<BE_Ceses> Ceses)
        {
            try
            {
                new DA_Integracion().mInsertarArchivoCesesBD(Ceses);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Exception Policy");
                throw ex;
            }

        }

        public void mInsertarArchivoIngresos(List<BE_Ingresos> Ingresos)
        {
            try
            {
                new DA_Integracion().mInsertarArchivoIngresoBD(Ingresos);
            }

            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Exception Policy");
                throw ex;
            }

        }


        public void mInsertarArchivoPermisos(List<BE_Permisos>Permisos)
        {
            try
            {
                new DA_Integracion().mInsertarArchivoPermisosBD(Permisos);
            }

            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Exception Policy");
                throw ex;
            }
        }

        public void mInsertarArchivoSaldoVacaciones(List<BE_SaldoVacaciones> Saldos)
        {
            try
            {
                new DA_Integracion().mInsertarArchivoSaldosVacBD(Saldos);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Exception Policy");
                throw ex;
            }
        }

        public void mInsertarArchivoSindicatos(List<BE_Sindicatos>Sindicatos)
        {
            try
            {
                new DA_Integracion().mInsertarArchivoSindicatoBD(Sindicatos);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Exception Policy");
                throw ex;
            }
        }

        public void mInsertarArchivoVacaciones(List<BE_Vacaciones> Vacaciones)
        {
            try
            {
                new DA_Integracion().mInsertarArchivoVacacionesBD(Vacaciones);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Exception Policy");
                throw ex;
            }
        }

    }
}