using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;


using System.Web.UI.HtmlControls;
using System.Collections;
using System.Drawing.Printing;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ShareDistribution : System.Web.UI.Page
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
        string strDefaultName = "Report";
        ExportFormatType formatType = ExportFormatType.NoFormat;
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
                getOfficeName();
                GetCompanyId();
                GetShareHolderId();
                GetNomineeId();
                GetShareDistribution();
            }

            if (IsPostBack)
            {

                loadSesscion();

            }

            lblMsg.Text = "";

            //txtFabricId.Attributes.Add("onkeypress", "return controlEnter('" + txtFabricConstructionId.ClientID + "', event)");
            //txtFabricConstructionId.Attributes.Add("onkeypress", "return controlEnter('" + txtArtId.ClientID + "', event)");
            //txtArtId.Attributes.Add("onkeypress", "return controlEnter('" + txtStyleId.ClientID + "', event)");
            //txtStyleId.Attributes.Add("onkeypress", "return controlEnter('" + txtColorId.ClientID + "', event)");
            //txtColorId.Attributes.Add("onkeypress", "return controlEnter('" + txtUnitId.ClientID + "', event)");
            //txtUnitId.Attributes.Add("onkeypress", "return controlEnter('" + txtCurrencyId.ClientID + "', event)");

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveShareDistribution();
                GetShareDistribution();
                clearTextBox();
            }
            catch(Exception ex)
            {
            }
        }
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
        public void GetCompanyId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            //ddlCompanyId.DataSource = objLookUpBLL.GetCompanyId();
            ddlCompanyId.DataSource = objLookUpBLL.GetCompanyId();

            ddlCompanyId.DataTextField = "SHARE_HOLDER_NAME";
            ddlCompanyId.DataValueField = "SHARE_HOLDER_ID";

            ddlCompanyId.DataBind();
            if (ddlCompanyId.Items.Count > 0)
            {
                ddlCompanyId.SelectedIndex = 0;
            }
        }
        public void GetNomineeId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlNomineeId.DataSource = objLookUpBLL.GetNomineeId();

            ddlNomineeId.DataTextField = "NOMINEE_NAME";
            ddlNomineeId.DataValueField = "NOMINEE_ID";

            ddlNomineeId.DataBind();
            if (ddlNomineeId.Items.Count > 0)
            {
                ddlNomineeId.SelectedIndex = 0;
            }
        }
        public void GetShareHolderId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlShareHolderId.DataSource = objLookUpBLL.GetShareHolderId();

            ddlShareHolderId.DataTextField = "SHARE_HOLDER_NAME";
            ddlShareHolderId.DataValueField = "SHARE_HOLDER_ID";

            ddlShareHolderId.DataBind();
            if (ddlShareHolderId.Items.Count > 0)
            {
                ddlShareHolderId.SelectedIndex = 0;
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
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        public void SaveShareDistribution()
        {

            ShareDistributionDTO objShareDistributionDTO = new ShareDistributionDTO();
            ShareDistributionBLL objShareDistributionBLL = new ShareDistributionBLL();


            if (ddlCompanyId.SelectedValue.ToString() != "")
            {
                objShareDistributionDTO.CompanyId = ddlCompanyId.SelectedValue.ToString();
            }
            else
            {
                objShareDistributionDTO.CompanyId = "";
            }
            if (ddlShareHolderId.SelectedValue.ToString() != "")
            {
                objShareDistributionDTO.ShareHolderId = ddlShareHolderId.SelectedValue.ToString();
            }
            else
            {
                objShareDistributionDTO.ShareHolderId = "";
            }
            if (ddlNomineeId.SelectedValue.ToString() != "")
            {
                objShareDistributionDTO.NomineeId = ddlNomineeId.SelectedValue.ToString();
            }
            else
            {
                objShareDistributionDTO.NomineeId = "";
            }
            objShareDistributionDTO.NoOfShare = txtNoOfShare.Text;
            objShareDistributionDTO.FaceValue = txtFaceValue.Text;

            objShareDistributionDTO.DistributionId = distribution_id.Value;
            objShareDistributionDTO.DisplayOrder = txtDisplayOrder.Text;

            objShareDistributionDTO.UpdateBy = strEmployeeId;
            string strMsg = objShareDistributionBLL.SaveShareDistribution(objShareDistributionDTO);

            distribution_id.Value = string.Empty;
            lblMsgRecord.Text = strMsg;
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }
        public void CalculateShare()
        {

            ShareDistributionDTO objShareDistributionDTO = new ShareDistributionDTO();
            ShareDistributionBLL objShareDistributionBLL = new ShareDistributionBLL();

            string strMsg = objShareDistributionBLL.CalculateShare(objShareDistributionDTO);
            lblMsgRecord.Text = strMsg;
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }
        public void GetShareDistribution()
        {

            ShareDistributionDTO objShareDistributionDTO = new ShareDistributionDTO();
            ShareDistributionBLL objShareDistributionBLL = new ShareDistributionBLL();

            DataTable dt = new DataTable();

            dt = objShareDistributionBLL.GetShareDistribution();

            if (dt.Rows.Count > 0)
            {
                gvShareDistribution.DataSource = dt;
                gvShareDistribution.DataBind();
                string strMsg = "TOTAL " + gvShareDistribution.Rows.Count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvShareDistribution.DataSource = dt;
                gvShareDistribution.DataBind();
                int totalcolums = gvShareDistribution.Rows[0].Cells.Count;
                gvShareDistribution.Rows[0].Cells.Clear();
                gvShareDistribution.Rows[0].Cells.Add(new System.Web.UI.WebControls.TableCell());
                gvShareDistribution.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvShareDistribution.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;
                lblMsgRecord.Text = strMsg;
            }
        }
        public void clearTextBox()
        {
            distribution_id.Value = string.Empty;
            ddlNomineeId.SelectedIndex = 0;
            ddlCompanyId.SelectedIndex = 0;
            ddlShareHolderId.SelectedIndex = 0;
            txtNoOfShare.Text = "";
            txtFaceValue.Text = "";
            txtPaidUpCapital.Text = "";
            txtSharePercent.Text = "";
            txtDisplayOrder.Text = "";
        }

        #endregion
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetShareDistribution();
        }
        protected void gvShareDistribution_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShareDistribution.PageIndex = e.NewPageIndex;

        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvShareDistribution, "Select$" + e.Row.RowIndex);
            }
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvShareDistribution.SelectedRow.RowIndex;

            distribution_id.Value = gvShareDistribution.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            string NoOfShare = gvShareDistribution.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string FaceValue = gvShareDistribution.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string PaidUpCapital = gvShareDistribution.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string SharePercent = gvShareDistribution.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            string companyId = gvShareDistribution.SelectedRow.Cells[7].Text.Replace("&nbsp;", "0");

            string ShareHolderId = gvShareDistribution.SelectedRow.Cells[8].Text.Replace("&nbsp;", "0");
            string NomineeId = gvShareDistribution.SelectedRow.Cells[9].Text.Replace("&nbsp;", "0");
            string DisplayOrder = gvShareDistribution.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            //distribution_id. = Convert.ToDecimal(DistributionId);
            ddlCompanyId.Text = companyId;
            ddlShareHolderId.Text = ShareHolderId;
            ddlNomineeId.Text = NomineeId;
            txtNoOfShare.Text = NoOfShare;
            txtFaceValue.Text = FaceValue;
            txtPaidUpCapital.Text = PaidUpCapital;
            txtSharePercent.Text = SharePercent;
            txtDisplayOrder.Text = DisplayOrder;


            //searchFabricAssign(txtTranId.Text, strHeadOfficeId, strBranchOfficeId);


        }
        protected void gvShareDistribution_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ShareDistributionDTO objShareDistributionDTO = new ShareDistributionDTO();
            ShareDistributionBLL objShareDistributionBLL = new ShareDistributionBLL();

            string Distribution_Id = Convert.ToString(gvShareDistribution.DataKeys[e.RowIndex].Values["DISTRIBUTION_ID"]);

            objShareDistributionDTO.DistributionId = Distribution_Id;
            objShareDistributionDTO.UpdateBy = strEmployeeId;
            string MSG = objShareDistributionBLL.DeleteShare(objShareDistributionDTO);
            lblMsg.Text = MSG;
            GetShareDistribution();
        }
        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {
                chkPDF.AutoPostBack = true;
                chkExcel.Checked = false;

            }
        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkExcel.AutoPostBack = true;
                chkPDF.Checked = false;


            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearTextBox();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
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
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet_worker");
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
        protected void btnShow_Click(object sender, EventArgs e)
        {
            GetShareDistribution();
        }

        protected void BtnSHareCalculation_Click(object sender, EventArgs e)
        {
            CalculateShare();
        }

        protected void BtnSHarePercent_Click(object sender, EventArgs e)
        {
            try
            {
                GetSharePercent();
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
        public void GetSharePercent()
        {
            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                string strPath = Path.Combine(Server.MapPath("~/Reports/RptSharePercent.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetSharePercent(objReportDTO));

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
}