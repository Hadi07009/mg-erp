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
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
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
            string strEmployeeId = context.Request.QueryString["employee_id"];

            if (strEmployeeId != null)
            {
                MemoryStream memoryStream = new MemoryStream();

                string sql = "SELECT " +


                      "EMPLOYEE_PIC " +




                      "FROM EMPLOYEE_IMAGE WHERE EMPLOYEE_ID = '" + strEmployeeId + "'";




                OracleCommand objCommand = new OracleCommand(sql);
                OracleDataReader objDataReader;

                using (OracleConnection strConn = GetConnection())
                {

                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataReader = objCommand.ExecuteReader();
                    if (objDataReader.Read())
                    {
                        //objDataReader.Read();
                        //context.Response.BinaryWrite((Byte[])objDataReader[0]);
                        //context.Response.ContentType = "image/JPEG";
                        //context.Response.End();


                        //byte[] imgData = (byte[])objDataReader["EMPLOYEE_PIC"];
                        byte[] imgData = objDataReader["EMPLOYEE_PIC"] == DBNull.Value ? null : (byte[])objDataReader["EMPLOYEE_PIC"];

                        //context.Response.ContentType = objDataReader["ImgType"].ToString();
                        context.Response.Buffer = true;
                        context.Response.Charset = "";
                        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        context.Response.ContentType = "image/JPG";

                        context.Response.BinaryWrite(imgData);
                        //context.Response.OutputStream.Write(imgData, 0, imgData.Length);
                    }



                }

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