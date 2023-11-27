using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Oracle.DataAccess;
using Oracle.DataAccess.Client;

using System.Configuration;

namespace SINHA.MEDLAR.ERP.DBMANAGER
{
    public class DBManager
    {
        public System.Data.IDbConnection IDisconnection;
        private string strConnectionString;
        private bool mblnTransactionStart;
        public OracleConnection con;
        //private SqlConnection mySqlConnection;
        private string _ConStr;


        public DBManager()
        {
            //
            // TODO: Add constructor logic here
            //


        }
        public string ConnStr
        {
            get { return this._ConStr; }
            set { this._ConStr = value; }
        }
        public DBManager(string ConStr)
        {
            try
            {

                ConnStr = ConStr;
            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }
        public void DBOpen()
        {
            try
            {
                string c = "Data Source=orcl;User ID=ERP;Password=ERP;Persist Security Info=True;";
                con = new OracleConnection(c);
                con.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DBClose()
        {
            try
            {
                con.Close();
                //mySqlConnection.Close();
            }
            catch (OracleException ex)
            {
                throw ex;
            }
        }
        public void Command(string OracleCmd)
        {
            try
            {
                DBOpen();
                OracleCommand comand = new OracleCommand(OracleCmd, con);
                comand.ExecuteNonQuery();
                DBClose();
            }
            catch (OracleException exception)
            {
                throw exception;
            }

            finally
            {
            }
        }

    }
}
