using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Data;
using System.Web.Services.Description;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using System.Configuration;
using SINHA.MEDLAR.HR.DTO;
using SINHA.MEDLAR.HR.BLL;
using System.Web.Security;


namespace SINHA.MEDLAR.HR.UI
{


    public partial class CrystalView : System.Web.UI.Page
    {

        string strEmployeeId = "";
        string strSectionId = "";
        string strDepartmentId = "";
        string strDesignationId = "";
        string strUnitId = "";
        string strCatagoryId;
        string strHeadOfficeId = "";
        string strBranchOfficeId = "";
        string strEmployeeTypeId = "";
        string strLoginDay = "";
        string strLoginMonth = "";
        string strLoginDate = "";

        
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        ReportDocument rd = new ReportDocument();

       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;

            }

            if (!IsPostBack)
            {
                loadSesscion();
               
            }
            if (IsPostBack)
            {

                loadSesscion();
            }

            displayReport();


        }

        public void displayReport()
        {
            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();
            ExportFormatType formatType = ExportFormatType.NoFormat;
            string strReportPath = "";
           
            
            strReportPath = Session["strReportPath"].ToString().Trim();
            string strUnitId = Session["strUnitId"].ToString().Trim();
            string strSectionId = Session["strSectionId"].ToString().Trim();
            string strYear = Session["strYear"].ToString().Trim();
            string strMonth = Session["strMonth"].ToString().Trim();
            string strHeadOfficeId = Session["strHeadOfficeId"].ToString().Trim();
           
            
            rd.Load(strReportPath);
           
            rd.SetDatabaseLogon("ERP", "ERP");
            rd.SetDataSource(ds);


            CrystalReportViewer1.ReportSource = rd;
            CrystalReportViewer1.DataBind();



            formatType = ExportFormatType.PortableDocFormat;
            MemoryStream oStream;
            Response.Clear();
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            oStream = (MemoryStream)rd.ExportToStream(formatType);
            Response.ContentType = "application/Pdf";
            //Response.AddHeader("content-disposition", "attachment; filename=" + strReportPath + ".pdf");
            oStream.Seek(0, SeekOrigin.Begin);
            Response.BinaryWrite(oStream.ToArray());
            oStream.Flush();
            oStream.Close();
            oStream.Dispose();
            CrystalReportViewer1.RefreshReport();

            Response.End();



        }
        

        //private void SetTableLocation(Tables tables, string server, string database)
        //{
        //    ConnectionInfo connectionInfo = new ConnectionInfo();

        //    connectionInfo.ServerName = server;
        //    connectionInfo.DatabaseName = database;
        //    connectionInfo.UserID = "erp";
        //    connectionInfo.Password = "erp";

        //    foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
        //    {
        //        TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
        //        tableLogOnInfo.ConnectionInfo = connectionInfo;
        //        table.ApplyLogOnInfo(tableLogOnInfo);
        //    }
        //}

        #region "Function"
        public void loadSesscion()
        {

            strEmployeeId = Session["strEmployeeId"].ToString().Trim();
            strSectionId = Session["strSectionId"].ToString().Trim();

            strDesignationId = Session["strDesignationId"].ToString().Trim();
            strUnitId = Session["strUnitId"].ToString().Trim();
            strCatagoryId = Session["strCatagoryId"].ToString().Trim();
            strHeadOfficeId = Session["strHeadOfficeId"].ToString().Trim();
            strBranchOfficeId = Session["strBranchOfficeId"].ToString().Trim();
            //strEmployeeTypeId = Session["strEmployeeTypeId"].ToString().Trim();
            strLoginDay = Session["strLoginDay"].ToString().Trim();
            strLoginMonth = Session["strLoginMonth"].ToString().Trim();
            strLoginDate = Session["strLoginDate"].ToString().Trim();

        }

        public void sessionEmpty()
        {
            Session["strEmployeeId"] = null;
            Session["strSectionId"] = null;
            Session["strDepartmentId"] = null;
            Session["strDesignationId"] = null;
            Session["strUnitId"] = null;
            Session["strCatagoryId"] = null;
            Session["strHeadOfficeId"] = null;
            Session["strBranchOfficeId"] = null;
            Session["strLoginDay"] = null;
            Session["strLoginMonth"] = null;
            Session["strLoginDate"] = null;
            Session.Clear();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx", true);

        }

        #endregion
        #region "Customized Function"
        protected void Page_UnLoad(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            this.CrystalReportViewer1.Dispose();
            this.CrystalReportViewer1 = null;
            rd.Dispose();
            rd.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {

            this.CrystalReportViewer1.ReportSource = null;

            CrystalReportViewer1.Dispose();

            if (rd != null)
            {

                rd.Close();

                rd.Dispose();

                rd = null;

            }

            GC.Collect();

            GC.WaitForPendingFinalizers();

        }

        #endregion

    }
}