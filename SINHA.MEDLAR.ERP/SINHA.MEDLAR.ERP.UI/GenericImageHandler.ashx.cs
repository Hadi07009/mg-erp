using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SINHA.MEDLAR.ERP.UI
{
    /// <summary>
    /// Summary description for GenericImageHandler
    /// </summary>
    public class GenericImageHandler : IHttpHandler
    {
        #region "Oracle Connection Function"
        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }
        #endregion
        public void ProcessRequest(HttpContext context)
        {
            string employeeId = context.Request.QueryString["employee_id"];
            string nvl = context.Request.QueryString["nvl"];

            if (nvl == "1")
            {
                if (employeeId != null)//START
                {
                    try
                    {
                        MemoryStream memoryStream = new MemoryStream();

                        string sql = "SELECT SIGNATURE FROM EMPLOYEE_IMAGE WHERE EMPLOYEE_ID = '" + employeeId + "'";

                        OracleCommand objCommand = new OracleCommand(sql);
                        OracleDataReader objDataReader;

                        using (OracleConnection strConn = GetConnection())
                        {
                            objCommand.Connection = strConn;
                            strConn.Open();
                            objDataReader = objCommand.ExecuteReader();
                            if (objDataReader.Read())
                            {
                                if (objDataReader["SIGNATURE"] != null)
                                {
                                    //byte[] imgData = (byte[])objDataReader["SIGNATURE"];
                                    byte[] imgData = objDataReader["SIGNATURE"] == DBNull.Value ? null : (byte[])objDataReader["SIGNATURE"];
                                    context.Response.Buffer = true;
                                    context.Response.Charset = "";
                                    context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                                    context.Response.ContentType = "image/JPG";
                                    context.Response.BinaryWrite(imgData);
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                    }
                }//END


            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}