using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;


using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Text;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ReportMaintenanceStore : System.Web.UI.Page
    {
        private string strEmployeeId = "";
        private string strSectionId = "";
        private string strDepartmentId = "";
        private string strDesignationId = "";
        private string strUnitId = "";
        private string strCatagoryId;
        private string strHeadOfficeId = "";
        private string strBranchOfficeId = "";
        private string strEmployeeTypeId = "";
        private string strLoginDay = "";
        private string strLoginMonth = "";
        private string strLoginDate = "";

        private ReportDocument rd = new ReportDocument();
        private ExportFormatType formatType = ExportFormatType.NoFormat;
        private string strDefaultName = "Report";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;

            }

            if (!IsPostBack)
            {


                loadSession();
                getDepartmentId();
                getOfficeName();


            }
            if (IsPostBack)
            {
                loadSession();

            }
        }

        #region "Function"

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


        public void loadSession()
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


        public void getOfficeName()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getHeadOfficeName(strHeadOfficeId, strBranchOfficeId);

            lblHeadOfficeName.Text = objLookUpDTO.HeadOfficeName;
            lblHeadOfficeAddress.Text = objLookUpDTO.HeadOfficeAddress;
            lblBranchOfficeName.Text = objLookUpDTO.BranchOfficeName;
            lblBranchOfficeAddress.Text = objLookUpDTO.BranchOfficeAddress;

        }

        public void getDepartmentId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlDepartmentId.DataSource = objLookUpBLL.getDepartmentId(strHeadOfficeId, strBranchOfficeId);

            ddlDepartmentId.DataTextField = "DEPARTMENT_NAME";
            ddlDepartmentId.DataValueField = "DEPARTMENT_ID";

            ddlDepartmentId.DataBind();
            if (ddlDepartmentId.Items.Count > 0)
            {

                ddlDepartmentId.SelectedIndex = 0;
            }

        }

        #endregion

        public void reportMaster()
        {

            if (chkPDF.Checked == true)
            {

                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                ReportDocument crReportDocument = new ReportDocument();
                Response.Clear();
                Response.Buffer = true;

                formatType = ExportFormatType.PortableDocFormat;
                System.IO.Stream oStream = null;
                byte[] byteArray = null;

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                oStream = rd.ExportToStream(formatType);
                byteArray = new byte[oStream.Length];
                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(byteArray);
                Response.Flush();
                Response.Close();
                rd.Close();
                rd.Dispose();
            }
            if (chkExcel.Checked == true)
            {

                //CrystalReportViewer1.ReportSource = rd;
                //CrystalReportViewer1.DataBind();

                //formatType = ExportFormatType.Excel;
                //MemoryStream oStream;
                //Response.Clear();
                //Response.Buffer = false;
                //Response.ClearContent();
                //Response.ClearHeaders();

                //oStream = (MemoryStream)rd.ExportToStream(formatType);
                //Response.ContentType = "application/vnd.ms-excel";
                //oStream.Seek(0, SeekOrigin.Begin);
                //Response.BinaryWrite(oStream.ToArray());
                ////Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();

                rd.ExportToHttpResponse
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "Report_Skill_Verification");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }
            //else
            //{

            //    CrystalReportViewer1.ReportSource = rd;
            //    CrystalReportViewer1.DataBind();

            //    formatType = ExportFormatType.PortableDocFormat;
            //    MemoryStream oStream;
            //    Response.Clear();
            //    Response.Buffer = false;
            //    Response.ClearContent();
            //    Response.ClearHeaders();

            //    oStream = (MemoryStream)rd.ExportToStream(formatType);
            //    Response.ContentType = "application/Pdf";
            //    oStream.Seek(0, SeekOrigin.Begin);
            //    Response.BinaryWrite(oStream.ToArray());
            //    //Response.End();
            //    oStream.Flush();
            //    oStream.Close();
            //    oStream.Dispose();
            //    CrystalReportViewer1.RefreshReport();

            //}



        }

        protected void btnView_Click(object sender, EventArgs e)
        {

            try
            {










                if (rdoMaintenancePartsReceive.Checked == true)
                {
                    try
                    {


                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;


                        if (ddlDepartmentId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.DepartmentId = ddlDepartmentId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.DepartmentId = "";

                        }


                        objReportDTO.FromDate = dtpFromDate.Text;
                        objReportDTO.ToDate = dtpToDate.Text;

                        objReportDTO.MrNo = txtMrNo.Text;


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptMaintenanceReceive.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.MaintenancePartsReceieveSummary(objReportDTO));


                        rd.SetDatabaseLogon("erp", "erp");
                        CrystalReportViewer1.ReportSource = rd;
                        CrystalReportViewer1.DataBind();



                        reportMaster();


                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }


                    catch (Exception ex)
                    {


                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }


                }















            }

            catch (Exception ex)
            {


                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();


            }


            //new 
  
        }

        #region "Crystal Report Functionality"

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {

            }

            else if (chkWord.Checked == true)
            {


            }

            else
            {

                ReportDocument rd = new ReportDocument();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

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

        #region "Function"

        

       

  

     

        #endregion

        protected void rdoProductionEfficiencyDetail_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}