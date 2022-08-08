using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracionDAL
{
    public class DA_Base
    {
      
        protected IDbConnection mconnection { get; set; }
        protected IDbTransaction mtransaction { get; set; } 
        protected Database mdb { get; set; }



        protected void mIniciarTransaccion()
        {
            mdb = DatabaseFactory.CreateDatabase();
            //mconnection = mdb.GetConnection();
            mconnection.Open();
            mtransaction = mconnection.BeginTransaction();
        }

        protected void mCommitTransaccion()
        {
            mtransaction.Commit();
            mtransaction.Dispose();
            mtransaction = null;
            mconnection.Close();
            mconnection.Dispose();
            mconnection = null;
            mdb = null;
        }

        protected void mRollbackTransaccion()
        {
            mtransaction.Rollback();
            mtransaction.Dispose();
            mtransaction = null;
            mconnection.Close();
            mconnection.Dispose();
            mconnection = null;
            mdb = null;
        }


    }
}
