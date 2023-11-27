using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.IO;

using Oracle.ManagedDataAccess.Client;

namespace SINHA.MEDLAR.ERP.UI
{
    /// <summary>
    /// Summary description for LeaveHandler
    /// </summary>
    public class LeaveHandler : IHttpHandler
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
            string strFromDate = context.Request.QueryString["LEAVE_START_DATE"];
            string strToDate = context.Request.QueryString["LEAVE_END_DATE"];
            string strLeaveYear = context.Request.QueryString["LEAVE_YEAR"];

            if (strEmployee_id != null)
            {


                byte[] bytes;
                string fileName;

                using (OracleConnection strConn = GetConnection())
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.CommandText = "SELECT FILE_NAME, FILE_SIZE FROM employee_leave_file_upload WHERE EMPLOYEE_ID ='" + strEmployee_id + "' AND  leave_start_date = to_Date('" + strFromDate + "', 'dd/mm/yyyy') AND leave_end_date = to_Date('" + strToDate + "', 'dd/mm/yyyy') AND leave_year = '"+strLeaveYear+"' ";

                        cmd.Parameters.Add("@EMPLOYEE_ID", strEmployee_id);
                        cmd.Parameters.Add("@leave_start_date", strFromDate);
                        cmd.Parameters.Add("@leave_end_date", strToDate);
                        cmd.Parameters.Add("@leave_year", strLeaveYear);
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