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

        public void mInsertarArchivo(List<BE_Ausencias> Ausencia)
        {
            try
            {
                 new DA_Integracion().mInsertarArchivoBD(Ausencia);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex, "Exception Policy");
                throw ex;
            }
            
        }


    }
}