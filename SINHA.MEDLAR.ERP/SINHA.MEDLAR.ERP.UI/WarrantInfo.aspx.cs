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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class WarrantInfo : System.Web.UI.Page
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
                GetCaseId();
                GetCaseIdSearch();
                GetDefendantIdSearch();
                GetComplaintantIdSearch();
                //GetWarrantInfo();
                //clearMsg();
                getOfficeName();
            }
            if (IsPostBack)
            {

                loadSesscion();

            }
        }
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
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

                //CrystalReportViewer1.ReportSource = rd;
                //CrystalReportViewer1.DataBind();
                //ReportDocument crReportDocument = new ReportDocument();
                //Response.Clear();
                //Response.Buffer = true;

                //formatType = ExportFormatType.PortableDocFormat;
                //System.IO.Stream oStream = null;
                //byte[] byteArray = null;

                //Response.Buffer = false;
                //Response.ClearContent();
                //Response.ClearHeaders();

                //oStream = rd.ExportToStream(formatType);
                //byteArray = new byte[oStream.Length];
                //oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                //Response.ClearContent();
                //Response.ClearHeaders();
                //Response.ContentType = "application/pdf";
                //Response.BinaryWrite(byteArray);
                //Response.Flush();
                //Response.Close();
                //rd.Close();
                //rd.Dispose();
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

        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {
                chkExcel.Checked = false;
            }
            else
            {
                chkPDF.Checked = true;
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
        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkPDF.Checked = false;
            }
            else
            {
                chkExcel.Checked = true;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlCaseId.Text = " ";
            dtpIssueDate.Text = string.Empty;
            txtWarrantId.Text = string.Empty;
            txtComplaintant.Text = string.Empty;
            txtDefendant.Text = string.Empty;
        }
        public void GetCaseId()
        {
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            ddlCaseId.DataSource = objCaseInfoBLL.GetCaseId(strHeadOfficeId, strBranchOfficeId);

            ddlCaseId.DataTextField = "CASE_NO";
            ddlCaseId.DataValueField = "CASE_ID";

            ddlCaseId.DataBind();
            if (ddlCaseId.Items.Count > 0)
            {
                ddlCaseId.SelectedIndex = 0;
            }
        }
        public void GetCaseIdSearch()
        {
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            ddlCaseIdSearch.DataSource = objCaseInfoBLL.GetCaseId(strHeadOfficeId, strBranchOfficeId);

            ddlCaseIdSearch.DataTextField = "CASE_NO";
            ddlCaseIdSearch.DataValueField = "CASE_ID";

            ddlCaseIdSearch.DataBind();
            if (ddlCaseIdSearch.Items.Count > 0)
            {
                ddlCaseIdSearch.SelectedIndex = 0;
            }
        }


        public void GetDefendantIdSearch()
        {
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            ddlDefendantIdSearch.DataSource = objCaseInfoBLL.GetDefendantId();

            ddlDefendantIdSearch.DataTextField = "DEFENDANT_NAME";
            ddlDefendantIdSearch.DataValueField = "DEFENDANT_ID";

            ddlDefendantIdSearch.DataBind();
            if (ddlDefendantIdSearch.Items.Count > 0)
            {
                ddlDefendantIdSearch.SelectedIndex = 0;
            }
        }
        public void GetComplaintantIdSearch()
        {
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            ddlComplaintantIdSearch.DataSource = objCaseInfoBLL.GetComplaintantId();

            ddlComplaintantIdSearch.DataTextField = "COMPLAINTANT_NAME";
            ddlComplaintantIdSearch.DataValueField = "COMPLAINTANT_ID";

            ddlComplaintantIdSearch.DataBind();
            if (ddlComplaintantIdSearch.Items.Count > 0)
            {
                ddlComplaintantIdSearch.SelectedIndex = 0;
            }
        }

        #region "Grid View GridViewWarrantInfo"
        protected void GridViewWarrantInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewWarrantInfo.PageIndex = e.NewPageIndex;

        }
        protected void GridViewWarrantInfo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = GridViewWarrantInfo.SelectedRow.RowIndex + 1;
            //string strSLNo = GridViewWarrantInfo.SelectedRow.Cells[0].Text;          
            string Defendant = GridViewWarrantInfo.SelectedRow.Cells[1].Text;
            string Complaintant = GridViewWarrantInfo.SelectedRow.Cells[2].Text;
            string IssueDate = GridViewWarrantInfo.SelectedRow.Cells[3].Text;          
            string CaseId = GridViewWarrantInfo.SelectedRow.Cells[4].Text;
            string WarrantId = GridViewWarrantInfo.SelectedRow.Cells[5].Text;

            dtpIssueDate.Text = IssueDate;
            if (CaseId == "&nbsp;")
                ddlCaseId.Text = " ";
            else
                ddlCaseId.Text = CaseId;
            //txtCaseNo.Text = CaseId;
            txtWarrantId.Text = WarrantId;
            txtComplaintant.Text = Complaintant;
            txtDefendant.Text = Defendant;


        }
        protected void GridViewWarrantInfo_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void GridViewWarrantInfo_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }      
        protected void GridViewWarrantInfo_Sorting(object sender, GridViewSortEventArgs e)
        {
        }
        protected void GridViewWarrantInfo_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridViewWarrantInfo, "Select$" + e.Row.RowIndex);
            }
        }

        protected void GridViewWarrantInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }
      

        #endregion
        #region Case         

        public void SaveWarrantInfo()
        {
            CaseInfoDTO objCaseInfoDTO = new CaseInfoDTO();
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();

            objCaseInfoDTO.WarrantId = txtWarrantId.Text;
            objCaseInfoDTO.IssueDate = dtpIssueDate.Text;
            //objCaseInfoDTO.CaseNo = txtCaseNo.Text;

            if (ddlCaseId.SelectedValue.ToString() != " ")
            {
                objCaseInfoDTO.CaseId = ddlCaseId.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.CaseId = "";
            }
            objCaseInfoDTO.CreateBy = strEmployeeId;
            objCaseInfoDTO.HeadOfficeId = strHeadOfficeId;
            objCaseInfoDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objCaseInfoBLL.SaveWarrantInfo(objCaseInfoDTO);
            lblMsg.Text = strMsg;


        }
       
        public void GetWarrantInfo()
        {
            CaseInfoDTO objCaseInfoDTO = new CaseInfoDTO();
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();

            if (ddlCaseIdSearch.SelectedValue.ToString() != " ")
            {
                objCaseInfoDTO.CaseId = ddlCaseIdSearch.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.CaseId = "";
            }
            if (ddlDefendantIdSearch.SelectedValue.ToString() != " ")
            {
                objCaseInfoDTO.DefendantId = ddlDefendantIdSearch.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.DefendantId = "";
            }
            if (ddlComplaintantIdSearch.SelectedValue.ToString() != " ")
            {
                objCaseInfoDTO.ComplaintantId = ddlComplaintantIdSearch.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.ComplaintantId = "";
            }
            objCaseInfoDTO.FromDate = dtpFromWarrantDateSearch.Text;
            objCaseInfoDTO.Todate = dtpToWarrantDateSearch.Text;


            objCaseInfoDTO.UpdateBy = strEmployeeId;
            objCaseInfoDTO.HeadOfficeId = strHeadOfficeId;
            objCaseInfoDTO.BranchOfficeId = strBranchOfficeId;

            DataTable dt = objCaseInfoBLL.GetWarrantInfo(objCaseInfoDTO);

            if (dt.Rows.Count > 0)
            {
                GridViewWarrantInfo.DataSource = dt;
                GridViewWarrantInfo.DataBind();

                int count = ((DataTable)GridViewWarrantInfo.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridViewWarrantInfo.DataSource = dt;
                GridViewWarrantInfo.DataBind();
                int totalcolums = GridViewWarrantInfo.Rows[0].Cells.Count;
                GridViewWarrantInfo.Rows[0].Cells.Clear();
                GridViewWarrantInfo.Rows[0].Cells.Add(new TableCell());
                GridViewWarrantInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridViewWarrantInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";
            }
        }
        #endregion

        protected void BtnSaveWarrantInfo_Click(object sender, EventArgs e)
        {
            SaveWarrantInfo();
            GetWarrantInfo();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlCaseId.Text == "")
            {
                string strMsg = "Please Select Case_no";
                ddlCaseId.Focus();
                MessageBox(strMsg);
                return;
            }
            GetComplaintatnDefendantNameByCaseNo();
        }
        public void GetComplaintatnDefendantNameByCaseNo()
        {

            CaseInfoDTO objCaseInfoDTO = new CaseInfoDTO();
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();

            if (ddlCaseId.Text != " ")
            {
                objCaseInfoDTO.CaseId = ddlCaseId.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.CaseId = "";
            }
            objCaseInfoDTO = objCaseInfoBLL.GetComplaintatnDefendantNameByCaseNo(objCaseInfoDTO);
            txtDefendant.Text = objCaseInfoDTO.Defendant;
            txtComplaintant.Text = objCaseInfoDTO.Complaintant;
        }

        protected void btnSearchHearing_Click(object sender, EventArgs e)
        {
            GetWarrantInfo();
        }
    }
}