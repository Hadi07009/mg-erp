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
    public partial class CaseHistory : System.Web.UI.Page
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
                GetActivityType();
                GetCaseIdSearch();
                
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
            txtHistoryId.Text = string.Empty;
            ddlCaseId.SelectedValue = "";
            ddlCaseStatussId.SelectedValue = "";
            ddlCaseMode.SelectedValue = "";
            txtRemarks.Text = string.Empty;
            dtpHistoryDate.Text = string.Empty;
            ddlActivityType.SelectedValue = "";
            txtDefendantName.Text = string.Empty;
            txtComplaintantName.Text = string.Empty;
            ChkAppearedYn.Checked = false;
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
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
        public void GetActivityType()
        {
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            ddlActivityType.DataSource = objCaseInfoBLL.GetActivityType();

            ddlActivityType.DataTextField = "activity_name";
            ddlActivityType.DataValueField = "activity_type_id";

            ddlActivityType.DataBind();
            if (ddlActivityType.Items.Count > 0)
            {
                ddlActivityType.SelectedIndex = 0;
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


        //public void GetDefendantIdSearch()
        //{
        //    CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
        //    ddlDefendantIdSearch.DataSource = objCaseInfoBLL.GetDefendantId();

        //    ddlDefendantIdSearch.DataTextField = "DEFENDANT_NAME";
        //    ddlDefendantIdSearch.DataValueField = "DEFENDANT_ID";

        //    ddlDefendantIdSearch.DataBind();
        //    if (ddlDefendantIdSearch.Items.Count > 0)
        //    {
        //        ddlDefendantIdSearch.SelectedIndex = 0;
        //    }
        //}
        //public void GetComplaintantIdSearch()
        //{
        //    CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
        //    ddlComplaintantIdSearch.DataSource = objCaseInfoBLL.GetComplaintantId();

        //    ddlComplaintantIdSearch.DataTextField = "COMPLAINTANT_NAME";
        //    ddlComplaintantIdSearch.DataValueField = "COMPLAINTANT_ID";

        //    ddlComplaintantIdSearch.DataBind();
        //    if (ddlComplaintantIdSearch.Items.Count > 0)
        //    {
        //        ddlComplaintantIdSearch.SelectedIndex = 0;
        //    }
        //}
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
        protected void gvCaseHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCaseHistory.PageIndex = e.NewPageIndex;

        }
        protected void gvCaseHistory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvCaseHistory.SelectedRow.RowIndex + 1;
            string caseNo = gvCaseHistory.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            
            string Defendant = gvCaseHistory.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string Complaintant = gvCaseHistory.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string Date = gvCaseHistory.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string CaseMode = gvCaseHistory.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            string Appeared = gvCaseHistory.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            string Remarks = gvCaseHistory.SelectedRow.Cells[8].Text.Replace("&nbsp;","");
            string caseId = gvCaseHistory.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            string CaseStatusId = gvCaseHistory.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            string HistoryId = gvCaseHistory.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            string ActivityTypeId = gvCaseHistory.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");

            dtpHistoryDate.Text = Date;
            ddlCaseStatussId.Text = CaseStatusId;
            ddlCaseId.Text = caseId;
            ddlActivityType.SelectedValue = ActivityTypeId;
            txtDefendantName.Text = Defendant;
            txtComplaintantName.Text = Complaintant;
            if (CaseMode == "Close")
                ddlCaseMode.Text = "C";
            else
                ddlCaseMode.Text = "O";
            //ddlCaseMode.Text = CaseMode;
            if (Appeared == "Y")
                ChkAppearedYn.Checked = true;
            else
                ChkAppearedYn.Checked = false;
            txtRemarks.Text = Remarks;
            txtHistoryId.Text = HistoryId;

        }
        protected void gvCaseHistory_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvCaseHistory_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void gvCaseHistory_RowCommand(object sender, GridViewCommandEventArgs e)
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
        protected void gvCaseHistory_Sorting(object sender, GridViewSortEventArgs e)
        {
        }
        protected void gvCaseHistory_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvCaseHistory, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvCaseHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CaseInfoDTO objCaseInfoDTO = new CaseInfoDTO();
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();

            string historyId = Convert.ToString(gvCaseHistory.DataKeys[e.RowIndex].Values["history_id"]);
            string caseId = Convert.ToString(gvCaseHistory.DataKeys[e.RowIndex].Values["CASE_ID"]);

            objCaseInfoDTO.CaseHistoryId = historyId;
            objCaseInfoDTO.CaseId = caseId;
            objCaseInfoDTO.HeadOfficeId = strHeadOfficeId;
            objCaseInfoDTO.BranchOfficeId = strBranchOfficeId;
            objCaseInfoDTO.CreateBy = strEmployeeId;
            string Msg = objCaseInfoBLL.DeleteCaseHistory(objCaseInfoDTO);
            GetCaseHistory();
            Clear();
            MessageBox(Msg);
        }


        #endregion
        #region Case         
       
        public void SaveCaseHistory()
        {
            CaseInfoDTO objCaseInfoDTO = new CaseInfoDTO();
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();

            objCaseInfoDTO.CaseHistoryId = txtHistoryId.Text;
            objCaseInfoDTO.Date = dtpHistoryDate.Text;

            if (ddlCaseId.SelectedValue.ToString() != "")
            {
                objCaseInfoDTO.CaseId = ddlCaseId.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.CaseId = "";
            }
            if (ddlCaseStatussId.SelectedValue.ToString() != "")
            {
                objCaseInfoDTO.CaseStatusId = ddlCaseStatussId.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.CaseStatusId = "";
            }
            if (ddlCaseMode.SelectedValue.ToString() != "")
            {
                objCaseInfoDTO.Mode = ddlCaseMode.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.Mode = "";
            }
            if (ddlActivityType.SelectedValue.ToString() != "")
            {
                objCaseInfoDTO.ActivityTypeId = ddlActivityType.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.ActivityTypeId = "";
            }

            if (ChkAppearedYn.Checked==true)            
                objCaseInfoDTO.ChkAppearedYn = "Y";
            else
                objCaseInfoDTO.ChkAppearedYn = "N";

            objCaseInfoDTO.Remarks = txtRemarks.Text;
            objCaseInfoDTO.CreateBy = strEmployeeId;
            objCaseInfoDTO.HeadOfficeId = strHeadOfficeId;
            objCaseInfoDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objCaseInfoBLL.SaveCaseHistory(objCaseInfoDTO);
            MessageBox(strMsg);


        }
       
        public void GetCaseHistory()
        {
            CaseInfoDTO objCaseInfoDTO = new CaseInfoDTO();
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();


            if (ddlCaseIdSearch.SelectedValue.ToString() != "")
            {
                objCaseInfoDTO.CaseId = ddlCaseIdSearch.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.CaseId = "";
            }
           
            objCaseInfoDTO.FromDate = dtpFromHistoryDate.Text;
            objCaseInfoDTO.Todate = dtpToHistoryDate.Text;

            objCaseInfoDTO.UpdateBy = strEmployeeId;
            objCaseInfoDTO.HeadOfficeId = strHeadOfficeId;
            objCaseInfoDTO.BranchOfficeId = strBranchOfficeId;


            DataTable dt = objCaseInfoBLL.GetCaseHistory(objCaseInfoDTO);


            if (dt.Rows.Count > 0)
            {
                gvCaseHistory.DataSource = dt;
                gvCaseHistory.DataBind();

                int count = ((DataTable)gvCaseHistory.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvCaseHistory.DataSource = dt;
                gvCaseHistory.DataBind();
                int totalcolums = gvCaseHistory.Rows[0].Cells.Count;
                gvCaseHistory.Rows[0].Cells.Clear();
                gvCaseHistory.Rows[0].Cells.Add(new TableCell());
                gvCaseHistory.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvCaseHistory.Rows[0].Cells[0].Text = "NO RECORD FOUND";
            }
        }
        #endregion

        protected void BtnSaveCaseHistory_Click(object sender, EventArgs e)
        {
            if (ddlCaseId.SelectedValue == string.Empty)
            {
                string msg = "Please Select Case No";
                MessageBox(msg);
                ddlCaseId.Focus();
                return;
            }
            if (ddlActivityType.SelectedValue == string.Empty)
            {
                string msg = "Please Select Activity Type";
                MessageBox(msg);
                ddlActivityType.Focus();
                return;
            }
            if (dtpHistoryDate.Text == string.Empty)
            {
                string msg = "Please Enter  Date";
                MessageBox(msg);
                dtpHistoryDate.Focus();
                return;
            }
            SaveCaseHistory();
            GetCaseHistory();
            Clear();
        }

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    if(ddlCaseId.Text=="")
        //    {
        //        string strMsg = "Please Select Case_no";
        //        ddlCaseId.Focus();
        //        MessageBox(strMsg);
        //        return;
        //    }
        //    GetComplaintatnDefendantNameByCaseNo();
        //}
        public void GetComplaintatnDefendantNameByCaseNo()
        {

            CaseInfoDTO objCaseInfoDTO = new CaseInfoDTO();
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            if (ddlCaseId.Text != "")
            {
                objCaseInfoDTO.CaseId = ddlCaseId.SelectedValue.ToString();
            }
            else
            {
                objCaseInfoDTO.CaseId = "";
            }
            objCaseInfoDTO = objCaseInfoBLL.GetComplaintatnDefendantNameByCaseNo(objCaseInfoDTO);
            txtComplaintantName.Text = objCaseInfoDTO.Defendant;
            txtDefendantName.Text = objCaseInfoDTO.Complaintant;

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetCaseHistory();
        }

        protected void ddlCaseId_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetComplaintatnDefendantNameByCaseNo();
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            try
            {
                string emailAddressTo = txtEmailAddress.Text.Trim();
                string CCAddress = txtCCAddress.Text.Trim();
                
                //new
                string enquiryDate = string.Empty;
                enquiryDate = dtpEnquiryDate.Text.Trim();
                if (string.IsNullOrEmpty(enquiryDate))
                {
                    enquiryDate = DateTime.Now == null ? null : String.Format("{0:d/M/yyyy}", DateTime.Now);
                }

                //old
                //string inquiryDate = DateTime.Now == null ? null : String.Format("{0:d/M/yyyy}", DateTime.Now);

                if (string.IsNullOrEmpty(emailAddressTo))
                {
                    MessageBox("Please enter Email To Address");
                    return;
                }

                objEmployeeBLL.LogSchedule("DB Entry", "Success");
                EmailBLL objEmailBLL = new EmailBLL();
                CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
                
                List<CaseInfoDTO> objCaseInfoList = objCaseInfoBLL.GetCaseReminder(enquiryDate);
                if (objCaseInfoList.Count() > 0)
                {
                    objEmailBLL.SendCaseReminder(emailAddressTo , CCAddress, "ERP- SINHA MEDLAR GROUP", "Human Triggered System Generated Report for Case reminders", "You are requested to follow the bellow reminder-", objCaseInfoList);
                    MessageBox("Successful Email");
                }
            }
            catch (Exception ex)
            {
                objEmployeeBLL.LogSchedule("Mail Failure", ex.Message);
                MessageBox("Unable to send mail..");
            }
        }
    }
}