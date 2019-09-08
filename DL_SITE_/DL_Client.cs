using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFF_SITE_;

namespace DL_SITE_
{
    public class DL_Client
    {
        #region INSERT METHODS

        public void Insert(REF_Client oREF_Client, DB_Handle oDB_Handle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;

            try
            {
                sqlQuery = "SP_ADD_Client";
                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@CLIENT_ID", oREF_Client.CLIENT_ID);
                oSqlCommand.Parameters.AddWithValue("@CLIENT_NAME", oREF_Client.CLIENT_NAME);
                oSqlCommand.Parameters.AddWithValue("@CAR_NAME", oREF_Client.CAR_NAME);
                oSqlCommand.Parameters.AddWithValue("@DATE", oREF_Client.DATE);

                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.Connection = oDB_Handle.GetConnection();
                oSqlCommand.Transaction = oDB_Handle.GetTransaction();
                oSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region SELECT METHODS
        public DataTable Select(DB_Handle oDB_Handle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            DataTable oDataTable = new DataTable();
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SP_GET_Client";
                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Connection = oDB_Handle.GetConnection();
                oSqlCommand.Transaction = oDB_Handle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectOne(string _id, DB_Handle oDB_Handle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            SqlDataAdapter oSqlDataAdapter;
            DataTable oDataTable2 = new DataTable();

            try
            {
                sqlQuery = "SP_GET_UserByUid";
                oSqlCommand = new SqlCommand();
                oSqlCommand.Parameters.AddWithValue("@userid", _id);
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Connection = oDB_Handle.GetConnection();
                oSqlCommand.Transaction = oDB_Handle.GetTransaction();

                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable2);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oDataTable2;
        }

        public DataTable SelectCar(DB_Handle oDB_Handle)
        {
            string sqlQuery;
            SqlCommand oSqlCommand;
            DataTable oDataTable = new DataTable();
            SqlDataAdapter oSqlDataAdapter;
            try
            {
                sqlQuery = "SP_GET_Car";
                oSqlCommand = new SqlCommand();
                oSqlCommand.CommandText = sqlQuery;
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Connection = oDB_Handle.GetConnection();
                oSqlCommand.Transaction = oDB_Handle.GetTransaction();
                oSqlDataAdapter = new SqlDataAdapter(oSqlCommand);
                oSqlDataAdapter.Fill(oDataTable);
                return oDataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
