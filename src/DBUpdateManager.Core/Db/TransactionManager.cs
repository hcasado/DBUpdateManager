using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DBUpdateManager.Core.Config;
using System.Data;

namespace DBUpdateManager.Core.Db
{
    public class TransactionManager
    {

        protected SqlConnection _Cnn = null;
        protected SqlTransaction _Tnx = null;
        protected ConfigManager _CnfMgr = null;

        public TransactionManager()
        {

        }

        public void BeginTransaction()
        {
            _CnfMgr = new ConfigManager();
            _Cnn = new SqlConnection(_CnfMgr.ReadConfig().ConnectionString);
            _Cnn.Open();

            //IsolationLevel.ReadUncommitted allows mix DMLs and DDLs into same db script.
            _Tnx = _Cnn.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        public void SaveTransaction(string savePointName)
        {
            _Tnx.Save(savePointName);
        }

        public void CommitTransaction()
        {
            _Tnx.Commit();
            _Cnn.Close();
            _Tnx = null;
            _Cnn = null;
        }

        public void RollbackTransaction()
        {
            _Tnx.Rollback();
            _Cnn.Close();
            _Tnx = null;
            _Cnn = null;
        }


        public void EjecutarSql(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, _Cnn, _Tnx);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
    }
}
