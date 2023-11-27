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
    public partial class ReportProductionBasic : System.Web.UI.Page
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

        ReportDocument rd = new ReportDocument();
        ExportFormatType formatType = ExportFormatType.NoFormat;
        string strDefaultName = "Report";

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
                getUnitId();
                getLineId();
                getOfficeName();


            }
            if (IsPostBack)
            {
                loadSession();

            }

        }


        #region "Function"
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

        public void getUnitId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlUnitId.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlUnitId.DataTextField = "UNIT_NAME";
            ddlUnitId.DataValueField = "UNIT_ID";

            ddlUnitId.DataBind();
            if (ddlUnitId.Items.Count > 0)
            {

                ddlUnitId.SelectedIndex = 0;
            }

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

        public void getLineId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlLineId.DataSource = objLookUpBLL.getLineId(strHeadOfficeId, strBranchOfficeId);

            ddlLineId.DataTextField = "LINE_NAME";
            ddlLineId.DataValueField = "LINE_ID";

            ddlLineId.DataBind();
            if (ddlLineId.Items.Count > 0)
            {

                ddlLineId.SelectedIndex = 0;
            }

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


        #region "Export Convert Function"
        public void ReportFormatMaster()
        {
            //Export the report in different format
            string strDefaultName = "Report";
            ExportFormatType formatType = ExportFormatType.NoFormat;
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
                //Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();

                rd.ExportToHttpResponse
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "report_power");
                Response.End();
                CrystalReportViewer1.RefreshReport();


            }

            if (chkWord.Checked == true)
            {
                formatType = ExportFormatType.WordForWindows;
                MemoryStream oStream;
                oStream = (MemoryStream)rd.ExportToStream(formatType);
                Response.ContentType = "application/vnd.ms-word";
                oStream.Seek(0, SeekOrigin.Begin);
                Response.BinaryWrite(oStream.ToArray());
                Response.End();
                oStream.Flush();
                oStream.Close();
                oStream.Dispose();
                CrystalReportViewer1.RefreshReport();

            }

            if (chkCSV.Checked == true)
            {
                formatType = ExportFormatType.CharacterSeparatedValues;
                rd.ExportToHttpResponse(formatType, Response, true, strDefaultName);
                Response.End();
                CrystalReportViewer1.RefreshReport();
            }

            if (chkText.Checked == true)
            {
                formatType = ExportFormatType.RichText;
                MemoryStream oStream;
                oStream = (MemoryStream)rd.ExportToStream(formatType);
                Response.ContentType = "text/richtext";
                oStream.Seek(0, SeekOrigin.Begin);
                Response.BinaryWrite(oStream.ToArray());
                Response.End();
                oStream.Flush();
                oStream.Close();
                oStream.Dispose();
                CrystalReportViewer1.RefreshReport();
            }


            //switch (rbFormat.SelectedItem.Value)
            //{
            //    case "Word":
            //        formatType = ExportFormatType.WordForWindows;
            //        break;
            //    case "PDF":
            //        formatType = ExportFormatType.PortableDocFormat;
            //        break;
            //    case "Excel":
            //        formatType = ExportFormatType.Excel;
            //        break;
            //    case "CSV":
            //        formatType = ExportFormatType.CharacterSeparatedValues;
            //        break;
            //}

            //rd.ExportToHttpResponse(formatType, Response, true, strDefaultName );
            //Response.End();
            //CrystalReportViewer1.RefreshReport();





        }

        #endregion

        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {

                chkPDF.AutoPostBack = true;
                chkExcel.Checked = false;
                chkText.Checked = false;
                chkWord.Checked = false;
                chkCSV.Checked = false;
            }
        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkExcel.AutoPostBack = true;
                chkPDF.Checked = false;
                chkText.Checked = false;
                chkWord.Checked = false;
                chkCSV.Checked = false;
            }
        }

        protected void chkWord_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWord.Checked == true)
            {
                chkWord.AutoPostBack = true;
                chkPDF.Checked = false;
                chkText.Checked = false;
                chkExcel.Checked = false;
                chkCSV.Checked = false;
            }
        }

        protected void chkText_CheckedChanged(object sender, EventArgs e)
        {
            if (chkText.Checked == true)
            {
                chkText.AutoPostBack = true;
                chkPDF.Checked = false;
                chkWord.Checked = false;
                chkExcel.Checked = false;
                chkCSV.Checked = false;
            }
        }

        protected void chkCSV_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCSV.Checked == true)
            {
                chkCSV.AutoPostBack = true;
                chkPDF.Checked = false;
                chkWord.Checked = false;
                chkExcel.Checked = false;
                chkText.Checked = false;
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoQuantityDefectPermissible.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    defectPermissibleProcess();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.FromDate = dtpFromDate.Text;
                    objReportDTO.ToDate = dtpToDate.Text;
                    objReportDTO.PunchCode = txtPunchCode.Text;

                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitId = "";

                    }

                    if (ddlLineId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.LineId = ddlLineId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.LineId = "";

                    }




                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptQuantityDefectPermissible.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.QuantityDefectPermissible(objReportDTO));
                    rd.SetDataSource(ds);
                    rd.SetDatabaseLogon("erp", "erp");
                    CrystalReportViewer1.ReportSource = rd;
                    CrystalReportViewer1.DataBind();




                    ReportFormatMaster();

                    this.CrystalReportViewer1.Dispose();
                    this.CrystalReportViewer1 = null;
                    rd.Dispose();
                    rd.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
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
        }



        #region "Function"
        public void defectPermissibleProcess()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;
            objReportDTO.PunchCode = txtPunchCode.Text;

            if (ddlLineId.SelectedValue.ToString() != " ")
            {
                objReportDTO.LineId = ddlLineId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.LineId = "";
            }



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.UnitId = "";

            }


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.defectPermissibleProcess(objReportDTO);



        }


        #endregion

        #region "Crystal Report Functionality"

        protected void Page_UnLoad(object sender, EventArgs e)
        {

            if (chkExcel.Checked == true)
            {


                //Noting to do


            }
            else
            {
                ReportDocument rd = new ReportDocument();
                this.CrystalReportViewer1.Dispose();
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


    }
}