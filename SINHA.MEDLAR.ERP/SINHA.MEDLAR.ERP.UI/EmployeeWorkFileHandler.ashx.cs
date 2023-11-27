using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINHA.MEDLAR.ERP.UI
{
    /// <summary>
    /// Summary description for EmployeeWorkFileHandler
    /// </summary>
    public class EmployeeWorkFileHandler : IHttpHandler
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
            string strEmployee_id = context.Request.QueryString["EMPLOYEE_ID"];


            if (strEmployee_id != null)
            {


                byte[] bytes;
                string fileName;

                using (OracleConnection strConn = GetConnection())
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.CommandText = "SELECT FILE_NAME, FILE_SIZE FROM employee_work_file_upload WHERE EMPLOYEE_ID ='" + strEmployee_id + "' ";


                        cmd.Parameters.Add("@EMPLOYEE_ID", strEmployee_id);

                        cmd.Connection = strConn;
                        strConn.Open();
                        using (OracleDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            bytes = (byte[])sdr["FILE_SIZE"];
                            fileName = sdr["FILE_NAME"].ToString();
                        }
                        strConn.Close();
                    }
                }

                context.Response.Buffer = true;
                context.Response.Charset = "";
                if (context.Request.QueryString["download"] == "1")
                {
                    context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                }
                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                context.Response.ContentType = "application/pdf";
                context.Response.BinaryWrite(bytes);
                context.Response.Flush();
                context.Response.End();

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