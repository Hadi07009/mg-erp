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
    public partial class CaseInfo : System.Web.UI.Page
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
                GetCaseTypeId();
                GetDefendantId();
                GetComplaintantId();
                //GetCaseId();
                // LoadCaseInfoGrid();
                GetCaseTypeIdSearch();
                GetDefendantIdSearch();
                GetComplaintantIdSearch();
                GetCourtId();
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
        //        public void reportMaster()
        //        {

        //            if (chkPDF.Checked == true)
        //            {

        //                CrystalReportViewer1.ReportSource = rd;
        //                CrystalReportViewer1.DataBind();
        //                ReportDocument crReportDocument = new ReportDocument();
        //                Response.Clear();
        //                Response.Buffer = true;

        //                formatType = ExportFormatType.PortableDocFormat;
        //                System.IO.Stream oStream = null;
        //                byte[] byteArray = null;

        //                Response.Buffer = false;
        //                Response.ClearContent();
        //                Response.ClearHeaders();

        //                oStream = rd.ExportToStream(formatType);
        //                byteArray = new byte[oStream.Length];
        //                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
        //                Response.ClearContent();
        //                Response.ClearHeaders();
        //                Response.ContentType = "application/pdf";
        //                Response.BinaryWrite(byteArray);
        //                Response.Flush();
        //                Response.Close();
        //                rd.Close();
        //                rd.Dispose();

        //                //CrystalReportViewer1.ReportSource = rd;
        //                //CrystalReportViewer1.DataBind();
        //                //ReportDocument crReportDocument = new ReportDocument();
        //                //Response.Clear();
        //                //Response.Buffer = true;

        //                //formatType = ExportFormatType.PortableDocFormat;
        //                //System.IO.Stream oStream = null;
        //                //byte[] byteArray = null;

        //                //Response.Buffer = false;
        //                //Response.ClearContent();
        //                //Response.ClearHeaders();

        //                //oStream = rd.ExportToStream(formatType);
        //                //byteArray = new byte[oStream.Length];
        //                //oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
        //                //Response.ClearContent();
        //                //Response.ClearHeaders();
        //                //Response.ContentType = "application/pdf";
        //                //Response.BinaryWrite(byteArray);
        //                //Response.Flush();
        //                //Response.Close();
        //                //rd.Close();
        //                //rd.Dispose();
        //            }
        //            if (chkExcel.Checked == true)
        //            {

        //                //CrystalReportViewer1.ReportSource = rd;
        //                //CrystalReportViewer1.DataBind();

        //                //formatType = ExportFormatType.Excel;
        //                //MemoryStream oStream;
        //                //Response.Clear();
        //                //Response.Buffer = false;
        //                //Response.ClearContent();
        //                //Response.ClearHeaders();

        //                //oStream = (MemoryStream)rd.ExportToStream(formatType);
        //                //Response.ContentType = "application/vnd.ms-excel";
        //                //oStream.Seek(0, SeekOrigin.Begin);
        //                //Response.BinaryWrite(oStream.ToArray());
        //                ////Response.End();
        //                //oStream.Flush();
        //                //oStream.Close();
        //                //oStream.Dispose();
        //                //CrystalReportViewer1.RefreshReport();

        //                rd.ExportToHttpResponse
        //(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet_worker");
        //                Response.End();
        //                CrystalReportViewer1.RefreshReport();
        //            }
        //            //else
        //            //{

        //            //    CrystalReportViewer1.ReportSource = rd;
        //            //    CrystalReportViewer1.DataBind();

        //            //    formatType = ExportFormatType.PortableDocFormat;
        //            //    MemoryStream oStream;
        //            //    Response.Clear();
        //            //    Response.Buffer = false;
        //            //    Response.ClearContent();
        //            //    Response.ClearHeaders();

        //            //    oStream = (MemoryStream)rd.ExportToStream(formatType);
        //            //    Response.ContentType = "application/Pdf";
        //            //    oStream.Seek(0, SeekOrigin.Begin);
        //            //    Response.BinaryWrite(oStream.ToArray());
        //            //    //Response.End();
        //            //    oStream.Flush();
        //            //    oStream.Close();
        //            //    oStream.Dispose();
        //            //    CrystalReportViewer1.RefreshReport();

        //            //}
        //        }
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
        public void Clear()
        {
            txtCaseNo.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            ddlCaseTypeId.Text = "";
            ddlDefendantId.Text = "";
            ddlComplaintantId.Text = "";
            ddlCourtId.Text = "";
            //ddlCaseMode.SelectedItem.Value = "";
            ddlCaseMode.SelectedIndex = 0;
            txtAmount.Text = string.Empty;
            dtpIssueDate.Text = string.Empty;
            txtCaseId.Text = string.Empty;
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        //public void GetCaseId()
        //{
        //    CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
        //    ddlSourceCaseId.DataSource = objCaseInfoBLL.GetCaseId();

        //    ddlSourceCaseId.DataTextField = "CASE_NO";
        //    ddlSourceCaseId.DataValueField = "CASE_ID";

        //    ddlSourceCaseId.DataBind();
        //    if (ddlSourceCaseId.Items.Count > 0)
        //    {
        //        ddlSourceCaseId.SelectedIndex = 0;
        //    }
        //}
        //public void GetInactiveSourceCase(string defendantId, string complainantId)
        //{
        //    CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
        //    ddlSourceCaseId.DataSource = objCaseInfoBLL.GetInactiveSourceCase(defendantId, complainantId);

        //    ddlSourceCaseId.DataTextField = "CASE_NO";
        //    ddlSourceCaseId.DataValueField = "CASE_ID";

        //    ddlSourceCaseId.DataBind();
        //    if (ddlSourceCaseId.Items.Count > 0)
        //    {
        //        ddlSourceCaseId.SelectedIndex = 0;
        //    }
        //}

        public void GetCaseTypeId()
        {
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            ddlCaseTypeId.DataSource = objCaseInfoBLL.GetCaseTypeId();

            ddlCaseTypeId.DataTextField = "CASE_TYPE_NAME";
            ddlCaseTypeId.DataValueField = "CASE_TYPE_ID";

            ddlCaseTypeId.DataBind();
            if (ddlCaseTypeId.Items.Count > 0)
            {
                ddlCaseTypeId.SelectedIndex = 0;
            }
        }
        public void GetDefendantId()
        {
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            ddlDefendantId.DataSource = objCaseInfoBLL.GetDefendantId();

            ddlDefendantId.DataTextField = "DEFENDANT_NAME";
            ddlDefendantId.DataValueField = "DEFENDANT_ID";

            ddlDefendantId.DataBind();
            if (ddlDefendantId.Items.Count > 0)
            {
                ddlDefendantId.SelectedIndex = 0;
            }
        }
        public void GetComplaintantId()
        {
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            ddlComplaintantId.DataSource = objCaseInfoBLL.GetComplaintantId();

            ddlComplaintantId.DataTextField = "COMPLAINTANT_NAME";
            ddlComplaintantId.DataValueField = "COMPLAINTANT_ID";

            ddlComplaintantId.DataBind();
            if (ddlComplaintantId.Items.Count > 0)
            {
                ddlComplaintantId.SelectedIndex = 0;
            }
        }
        public void GetCaseTypeIdSearch()
        {
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            ddlCaseTypeIdSearch.DataSource = objCaseInfoBLL.GetCaseTypeId();

            ddlCaseTypeIdSearch.DataTextField = "CASE_TYPE_NAME";
            ddlCaseTypeIdSearch.DataValueField = "CASE_TYPE_ID";

            ddlCaseTypeIdSearch.DataBind();
            if (ddlCaseTypeIdSearch.Items.Count > 0)
            {
                ddlCaseTypeIdSearch.SelectedIndex = 0;
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
        public void GetCourtId()
        {
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            ddlCourtId.DataSource = objCaseInfoBLL.GetCourtId();

            ddlCourtId.DataTextField = "COURT_NAME";
            ddlCourtId.DataValueField = "COURT_ID";

            ddlCourtId.DataBind();
            if (ddlCourtId.Items.Count > 0)
            {
                ddlCourtId.SelectedIndex = 0;
            }
        }

        #region "Grid View GridViewCaseInfo"

        protected void GridViewCaseInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCaseInfo.PageIndex = e.NewPageIndex;

        }
        protected void GridViewCaseInfo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = GridViewCaseInfo.SelectedRow.RowIndex + 1;
            //string strSLNo = GridViewCaseInfo.SelectedRow.Cells[0].Text;
            string CaseNo = GridViewCaseInfo.SelectedRow.Cells[0].Text;
            string IssueDate = GridViewCaseInfo.SelectedRow.Cells[4].Text;
            string CaseMode = GridViewCaseInfo.SelectedRow.Cells[6].Text;

            string Amount = GridViewCaseInfo.SelectedRow.Cells[7].Text;
            string Remarks = GridViewCaseInfo.SelectedRow.Cells[8].Text;
            string CaseTypeId = GridViewCaseInfo.SelectedRow.Cells[9].Text;
            string DefenntId = GridViewCaseInfo.SelectedRow.Cells[10].Text;
            string ComplaintantId = GridViewCaseInfo.SelectedRow.Cells[11].Text;
            string CaseId = GridViewCaseInfo.SelectedRow.Cells[12].Text;
            string CourtId = GridViewCaseInfo.SelectedRow.Cells[13].Text;
            //string SourseCaseId = GridViewCaseInfo.SelectedRow.Cells[15].Text;

            //GetInactiveSourceCase(DefenntId, ComplaintantId);

            txtCaseNo.Text = CaseNo;
            dtpIssueDate.Text = IssueDate;
            if (CaseTypeId == "&nbsp;")
                ddlCaseTypeId.Text = "";
            else
                ddlCaseTypeId.Text = CaseTypeId;
            if (DefenntId == "&nbsp;")
                ddlDefendantId.Text = "";
            else
                ddlDefendantId.Text = DefenntId;
            if (ComplaintantId == "&nbsp;")
                ddlComplaintantId.Text = "";
            else
                ddlComplaintantId.Text = ComplaintantId;
            if (CourtId == "&nbsp;")
                ddlCourtId.Text = "";
            else
                ddlCourtId.Text = CourtId;
            if(CaseMode=="Open")
               ddlCaseMode.SelectedValue = "O";
            else
                ddlCaseMode.SelectedValue = "C";
            if (Amount == "&nbsp;")
                txtAmount.Text = "";
            else
                txtAmount.Text = Amount;
            if (Remarks == "&nbsp;")
                txtRemarks.Text = "";
            else
                txtRemarks.Text = Remarks;
            txtCaseId.Text = CaseId;


        }
        protected void GridViewCaseInfo_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void GridViewCaseInfo_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GridViewCaseInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{
            //    int strRowId = GridView1.SelectedRow.RowIndex + 1;
            //    string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            //    string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            //    string strEmployeeId = GridView1.SelectedRow.Cells[9].Text;
            //    string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            //    string strDesignation = GridView1.SelectedRow.Cells[3].Text;


            //    txtSL.Text = Convert.ToString(strRowId);
            //    txtCardNo.Text = strCardNo;
            //    txtEmployeeId.Text = strEmployeeId;
            //    txtEmployeeName.Text = strEmployeeName;
            //    txtDesignationName.Text = strDesignation;

            //    searchMiscEntryWorker();

            //    txtWorkingDay.Focus();
            //}
            //if (e.CommandName == "Edit")
            //{
            //}
            //if (e.CommandName == "Delete")
            //{

            //}
            //int selectedRowIndex = GridView1.SelectedRow.RowIndex;
            //GridView1.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }
        protected void GridViewCaseInfo_Sorting(object sender, GridViewSortEventArgs e)
        {
        }
        protected void GridViewCaseInfo_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridViewCaseInfo, "Select$" + e.Row.RowIndex);
            }
        }

        protected void GridViewCaseInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //try
            //{
            //    EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            //    string employeeId = Convert.ToString(GridViewCaseInfo.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"]);
            //    string msg = objEmployeeBLL.RemoveCase(employeeId);
            //    MessageBox(msg);
            //    LoadCaseInfoGrid();
            //}
            //catch
            //{
            //    MessageBox("Unable To Remove Case");
            //}                      
        }


        #endregion
        #region Case         

        public void SaveCaseInfo()
        {
            CaseInfoDTO objCaseInfoDTO = new CaseInfoDTO();
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            objCaseInfoDTO.CaseId = txtCaseId.Text;
            objCaseInfoDTO.CaseNo = txtCaseNo.Text;
            objCaseInfoDTO.IssueDate = dtpIssueDate.Text;
            if (ddlCaseTypeId.SelectedValue.ToString() != "")
            {
                objCaseInfoDTO.CaseTypeId = ddlCaseTypeId.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.CaseTypeId = "";
            }
            if (ddlDefendantId.SelectedValue.ToString() != "")
            {
                objCaseInfoDTO.DefendantId = ddlDefendantId.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.DefendantId = "";
            }
            if (ddlComplaintantId.SelectedValue.ToString() != "")
            {
                objCaseInfoDTO.ComplaintantId = ddlComplaintantId.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.ComplaintantId = "";
            }
            if (ddlCourtId.SelectedValue.ToString() != "")
            {
                objCaseInfoDTO.CourtId = ddlCourtId.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.CourtId = "";
            }
            if (ddlCaseMode.SelectedValue.ToString() != "")
            {
                objCaseInfoDTO.Mode = ddlCaseMode.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.Mode = "";
            }
            
            objCaseInfoDTO.Amount = txtAmount.Text;
            objCaseInfoDTO.Remarks = txtRemarks.Text;
            objCaseInfoDTO.CreateBy = strEmployeeId;
            objCaseInfoDTO.HeadOfficeId = strHeadOfficeId;
            objCaseInfoDTO.BranchOfficeId = strBranchOfficeId;
            
            string strMsg = objCaseInfoBLL.SaveCaseInfo(objCaseInfoDTO);
            string[] message = strMsg.Split(':');
            if(message[0]!="N")
            {
                Clear();
            }
            MessageBox(message[1]);
        }

        public void LoadCaseInfoGrid(string caseNo)
        {
            CaseInfoDTO objCaseInfoDTO = new CaseInfoDTO();
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            
            objCaseInfoDTO.CaseNo = caseNo;
            objCaseInfoDTO.FromDate = dtpFromDate.Text;
            objCaseInfoDTO.Todate = dtpToDate.Text;
            if (ddlCaseTypeIdSearch.SelectedValue.ToString() != "")
            {
                objCaseInfoDTO.CaseTypeId = ddlCaseTypeIdSearch.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.CaseTypeId = "";
            }
            if (ddlDefendantIdSearch.SelectedValue.ToString() != "")
            {
                objCaseInfoDTO.DefendantId = ddlDefendantIdSearch.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.DefendantId = "";
            }
            if (ddlComplaintantIdSearch.SelectedValue.ToString() != "")
            {
                objCaseInfoDTO.ComplaintantId = ddlComplaintantIdSearch.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.ComplaintantId = "";
            }
            objCaseInfoDTO.CreateBy = strEmployeeId;
            objCaseInfoDTO.HeadOfficeId = strHeadOfficeId;
            objCaseInfoDTO.BranchOfficeId = strBranchOfficeId;

            DataTable dt = objCaseInfoBLL.LoadCaseInfoGrid(objCaseInfoDTO);
            
            if (dt.Rows.Count > 0)
            {
                GridViewCaseInfo.DataSource = dt;
                GridViewCaseInfo.DataBind();

                int count = ((DataTable)GridViewCaseInfo.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridViewCaseInfo.DataSource = dt;
                GridViewCaseInfo.DataBind();
                int totalcolums = GridViewCaseInfo.Rows[0].Cells.Count;
                GridViewCaseInfo.Rows[0].Cells.Clear();
                GridViewCaseInfo.Rows[0].Cells.Add(new TableCell());
                GridViewCaseInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
               // GridViewCaseInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";
            }
        }
        #endregion

        protected void BtnSaveCaseInfo_Click(object sender, EventArgs e)
        {
            if (txtCaseNo.Text == string.Empty)
            {
                string msg = "Please Enter Case No";
                MessageBox(msg);
                txtCaseNo.Focus();
                return;
            }
            if (ddlCaseTypeId.SelectedValue == string.Empty)
            {
                string msg = "Please Select Case Type";
                MessageBox(msg);
                ddlCaseTypeId.Focus();
                return;
            }
            if (ddlDefendantId.SelectedValue == string.Empty)
            {
                string msg = "Please Select Defendant";
                MessageBox(msg);
                ddlCaseTypeId.Focus();
                return;
            }
            if (ddlComplaintantId.SelectedValue == string.Empty)
            {
                string msg = "Please Select Complaintant";
                MessageBox(msg);
                ddlComplaintantId.Focus();
                return;
            }
            if (dtpIssueDate.Text == string.Empty)
            {
                string msg = "Please Enter Issue Date";
                MessageBox(msg);
                dtpIssueDate.Focus();
                return;
            }
            if (ddlCourtId.SelectedValue == string.Empty)
            {
                string msg = "Please Select Court";
                MessageBox(msg);
                ddlCourtId.Focus();
                return;
            }
            if (ddlCaseMode.SelectedValue.ToString() == string.Empty)
            {
                string msg = "Please Select Case Mode";
                MessageBox(msg);
                ddlCaseMode.Focus();
                return;
            }
            SaveCaseInfo();
            LoadCaseInfoGrid(txtCaseNo.Text);
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCaseInfoGrid(txtCaseNoSearch.Text);
        }

        protected void ddlDefendantId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlDefendantId.SelectedItem.Value != string.Empty && ddlComplaintantId.SelectedItem.Value != string.Empty)
            //{
            //    GetInactiveSourceCase(ddlDefendantId.SelectedValue, ddlComplaintantId.SelectedValue);
            //}
        }

        protected void ddlComplaintantId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlDefendantId.SelectedItem.Value != string.Empty && ddlComplaintantId.SelectedItem.Value != string.Empty)
            //{
            //    GetInactiveSourceCase(ddlDefendantId.SelectedValue, ddlComplaintantId.SelectedValue);
            //}
        }

    }
}