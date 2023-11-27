using System;
using System.Web;
using System.Data;
using System.IO;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;

namespace SINHA.MEDLAR.ERP.UI
{
    /// <summary>
    /// Summary description for ImageDownload1
    /// </summary>
    public class ImageDownload1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            

            string strEmployeeId = context.Request.QueryString["employee_id"];

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.EmployeeId = strEmployeeId;


            objEmployeeDTO.UpdateBy = strEmployeeId;

            DataTable dt = new DataTable();
            dt = objEmployeeBLL.DownloadImgEmployee(objEmployeeDTO);

            context.Response.Clear();
            string name = dt.Rows[(0)]["FILE_NAME"].ToString();
            byte[] documentBytes = (byte[])dt.Rows[(0)]["EMPLOYEE_PIC"];
            context.Response.ContentType = "application/JPG";
            context.Response.AddHeader("content-disposition", "attachment; filename=\"" + name + ".jpg\"");
            context.Response.AddHeader("Content-Length", documentBytes.ToString());
            context.Response.BinaryWrite(documentBytes);
            //context.Response.Flush();
            //context.Response.Close();
            context.Response.End();
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