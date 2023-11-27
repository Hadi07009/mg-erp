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
using SINHA.MEDLAR.ERP.BLL.Utility.MessageBLL.EmailBLL;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class HearingInfo : System.Web.UI.Page
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
                GetCaseStatusId();
                GetCaseId();
                GetCaseIdSearch();
                GetDefendantIdSearch();
                GetComplaintantIdSearch();
                //GetHearingInfo();
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
           // txtCaseId.Value = "";
            ddlCaseId.Text = " ";
            ddlCaseStatussId.Text = " ";
            txtRemarks.Text = string.Empty;
            dtpIssueDate.Text = string.Empty;
            txtHearingId.Text = string.Empty;
            txtComplaintant.Text = string.Empty;
            txtDefendant.Text = string.Empty;
        }
    
        public void GetCaseStatusId()
        {
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            ddlCaseStatussId.DataSource = objCaseInfoBLL.GetCaseStatusId();

            ddlCaseStatussId.DataTextField = "CASE_STATUS";
            ddlCaseStatussId.DataValueField = "CASE_STATUS_ID";

            ddlCaseStatussId.DataBind();
            if (ddlCaseStatussId.Items.Count > 0)
            {
                ddlCaseStatussId.SelectedIndex = 0;
            }
        }
        public void GetCaseId()
        {
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            ddlCaseId.DataSource = objCaseInfoBLL.GetCaseId(strHeadOfficeId,strBranchOfficeId);

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
        //[System.Web.Services.WebMethod]
        //public static List<CaseInfornation> GetCaseNoByCaseID()
        //{
        //    CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
        //    DataTable dt = new DataTable();

        //    string caseNo = HttpContext.Current.Request.QueryString["prefix"];
        //    List<CaseInfornation> objCaseInfo = objCaseInfoBLL.GetCaseNoByCaseID(caseNo);

        //    var caseItems = (from item in objCaseInfo
        //                     where item.CASE_NO.StartsWith(caseNo)
        //                     select new CaseInfornation
        //                     {
        //                         CASE_ID = item.CASE_ID,
        //                         CASE_NO = item.CASE_NO.ToString()
        //                     }).ToList();


        //    return caseItems;
        //}


        #region "Grid View GridViewHearingInfo"
        protected void GridViewHearingInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewHearingInfo.PageIndex = e.NewPageIndex;

        }
        protected void GridViewHearingInfo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = GridViewHearingInfo.SelectedRow.RowIndex + 1;
            string caseNo = GridViewHearingInfo.SelectedRow.Cells[0].Text;
            
            string Defendant = GridViewHearingInfo.SelectedRow.Cells[1].Text;
            string Complaintant = GridViewHearingInfo.SelectedRow.Cells[2].Text;
            string IssueSate = GridViewHearingInfo.SelectedRow.Cells[3].Text;
            string Remarks = GridViewHearingInfo.SelectedRow.Cells[5].Text;
            string caseId = GridViewHearingInfo.SelectedRow.Cells[6].Text;
            string CaseStatusId = GridViewHearingInfo.SelectedRow.Cells[7].Text;
            string HearingId = GridViewHearingInfo.SelectedRow.Cells[8].Text;

            dtpIssueDate.Text = IssueSate;
            if (CaseStatusId == "&nbsp;")
                ddlCaseStatussId.Text = " ";
            else
                ddlCaseStatussId.Text = CaseStatusId;
            if (caseId == "&nbsp;")
                ddlCaseId.Text = " ";
            else
                ddlCaseId.Text = caseId;

            //txtCaseId.Value = caseId;
            //txtCaseNo.Text = caseNo;
            txtComplaintant.Text = Complaintant;
            txtDefendant.Text = Defendant;
            txtRemarks.Text = Remarks;
            txtHearingId.Text = HearingId;

        }
        protected void GridViewHearingInfo_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void GridViewHearingInfo_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GridViewHearingInfo_RowCommand(object sender, GridViewCommandEventArgs e)
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
        protected void GridViewHearingInfo_Sorting(object sender, GridViewSortEventArgs e)
        {
        }
        protected void GridViewHearingInfo_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridViewHearingInfo, "Select$" + e.Row.RowIndex);
            }
        }

        protected void GridViewHearingInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
       
        public void SaveHearingInfo()
        {
            CaseInfoDTO objCaseInfoDTO = new CaseInfoDTO();
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();

            objCaseInfoDTO.HearingId = txtHearingId.Text;
            objCaseInfoDTO.IssueDate = dtpIssueDate.Text;

            if (ddlCaseId.SelectedValue.ToString() != " ")
            {
                objCaseInfoDTO.CaseId = ddlCaseId.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.CaseId = "";
            }

            //objCaseInfoDTO.CaseId = txtCaseId.Value;

            if (ddlCaseStatussId.SelectedValue.ToString() != " ")
            {
                objCaseInfoDTO.CaseStatusId = ddlCaseStatussId.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.CaseStatusId = "";
            }
          
            objCaseInfoDTO.Remarks = txtRemarks.Text;
            objCaseInfoDTO.CreateBy = strEmployeeId;
            objCaseInfoDTO.HeadOfficeId = strHeadOfficeId;
            objCaseInfoDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objCaseInfoBLL.SaveHearingInfo(objCaseInfoDTO);
            lblMsg.Text = strMsg;


        }
       
        public void GetHearingInfo()
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
            objCaseInfoDTO.FromDate = dtpFromHearingDateSearch.Text;
            objCaseInfoDTO.Todate = dtpToHearingDateSearch.Text;

            objCaseInfoDTO.UpdateBy = strEmployeeId;
            objCaseInfoDTO.HeadOfficeId = strHeadOfficeId;
            objCaseInfoDTO.BranchOfficeId = strBranchOfficeId;


            DataTable dt = objCaseInfoBLL.GetHearingInfo(objCaseInfoDTO);


            if (dt.Rows.Count > 0)
            {
                GridViewHearingInfo.DataSource = dt;
                GridViewHearingInfo.DataBind();

                int count = ((DataTable)GridViewHearingInfo.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridViewHearingInfo.DataSource = dt;
                GridViewHearingInfo.DataBind();
                int totalcolums = GridViewHearingInfo.Rows[0].Cells.Count;
                GridViewHearingInfo.Rows[0].Cells.Clear();
                GridViewHearingInfo.Rows[0].Cells.Add(new TableCell());
                GridViewHearingInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridViewHearingInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";
            }
        }
        #endregion

        protected void BtnSaveHearingInfo_Click(object sender, EventArgs e)
        {
            SaveHearingInfo();
            GetHearingInfo();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(ddlCaseId.Text=="")
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
            GetHearingInfo();
        }

        protected void btnReminder_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "There is no hearing for reminder";
                EmailBLL objEmailBLL = new EmailBLL();

                CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
                string hearingDate = DateTime.Now == null ? null : String.Format("{0:d/M/yyyy}", DateTime.Now);
                List<CaseInfoDTO> objCaseInfoList = objCaseInfoBLL.GetHearingReminder(hearingDate);
                if (objCaseInfoList.Count() > 0)
                {
                    result = objEmailBLL.SendMailTest("ehteshamul.haque@sinha-medlar.com", "shahin.alam@sinha-medlar.com", "ERP- Medlar Apparels Limited", "Hearing Reminder- (Human Generated)", "You are requested to follow the bellow reminder-", objCaseInfoList);
                }

                //objEmailBLL.SendMail("asadur.rahman@sinha-medlar.com", "Administrator", "Hearing Reminder", "You are requested to follow the bellow reminder-", "CaseNo", "Defendant", "Complaintant", "HearingDate", "CaseStatus");
                MessageBox(result);
            }
            catch (Exception ex)
            {
                //MessageBox(ex.Message);
                MessageBox("Unable to sent mail.");
            }
        }
    }
}