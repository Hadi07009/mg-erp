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
using SINHA.MEDLAR.ERP.BLL.Utility.MessageBLL.EmailBLL;
using SINHA.MEDLAR.ERP.COMMON.Utility.Excel;
using System.IO;


//using OfficeOpenXml.Style;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AddLeaveSetUp : System.Web.UI.Page
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
                getMonthYearForSalary();
                loadLeaveEffectRecord();
                getOfficeName();
                getLeaveId();
               
            }

            if (IsPostBack)
            {

                loadSesscion();

            }
        }


        #region 

      
        public void getMonthYearForSalary()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getYearMonth();

            txtYear.Text = objLookUpDTO.Year;


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

        public void getLeaveId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlLeaveTypeId.DataSource = objLookUpBLL.getLeaveId(strHeadOfficeId, strBranchOfficeId);

            ddlLeaveTypeId.DataTextField = "LEAVE_TYPE_NAME";
            ddlLeaveTypeId.DataValueField = "LEAVE_TYPE_ID";

            ddlLeaveTypeId.DataBind();
            if (ddlLeaveTypeId.Items.Count > 0)
            {

                ddlLeaveTypeId.SelectedIndex = 0;
            }

        }

        public void getLeaveSetupTypeId()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getLeaveSetupTypeId(txtLeaveId.Text, txtYear.Text, strHeadOfficeId, strBranchOfficeId);

            if (objLookUpDTO.LeaveTypeId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlLeaveTypeId.SelectedValue = objLookUpDTO.LeaveTypeId;
            }


        }

        public void loadLeaveEffectRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadLeaveEffectRecord(txtYear.Text, strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                int totalcolums = gvUnit.Rows[0].Cells.Count;
                gvUnit.Rows[0].Cells.Clear();
                gvUnit.Rows[0].Cells.Add(new TableCell());
                gvUnit.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvUnit.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }

        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        public void clearTextBox()
        {
            txtMaxAllow.Text = "";



        }


        #region "Grid Functionality"
        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadLeaveEffectRecord();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvUnit, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strLeaveId = gvUnit.SelectedRow.Cells[0].Text;
            string strLeaveYear = gvUnit.SelectedRow.Cells[1].Text;
           
            string strMaxAllow = gvUnit.SelectedRow.Cells[3].Text;

            txtYear.Text = strLeaveYear;

            txtMaxAllow.Text = strMaxAllow;
            txtLeaveId.Text = strLeaveId;

            getLeaveSetupTypeId();

            //string strMsg = "Row Index: " + strRowId + "\\nUnit ID: " + strUnitId + "\\nUnit Name : " + strUnitName + "\\nUnit Name Bangla : " + strUnitNameBng;
            ////ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }


        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtYear.Text == "")
                {

                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }


                else if (ddlLeaveTypeId.Text == "")
                {

                    string strMsg = "Please Select Leave Type!!!";
                    MessageBox(strMsg);
                    ddlLeaveTypeId.Focus();
                    return;
                }


                else if (txtMaxAllow.Text == string.Empty)
                {

                    string strMsg = "Please Enter Maximum Leave!!!";
                    MessageBox(strMsg);
                    txtMaxAllow.Focus();
                    return;
                }
                else
                {

                    leaveSave();
                    loadLeaveEffectRecord();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : "+ex.Message);

            }
        }

        public void leaveSave()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
                       
            if (ddlLeaveTypeId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.LeaveTypeId = ddlLeaveTypeId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.LeaveTypeId = "";
            }

            objLookUpDTO.LeaveId = txtLeaveId.Text;
            objLookUpDTO.Year = txtYear.Text;
            objLookUpDTO.MaxAllow = txtMaxAllow.Text;

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.leaveSave(objLookUpDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {


            AttendanceDashboardDTO objDashboard = new AttendanceDashboardDTO();
            DashboardBLL objDashboardBLL = new DashboardBLL();

            objDashboard.LogDate = "18/02/2021";
            objDashboard.HeadOfficeId = strHeadOfficeId;
            objDashboard.BranchOfficeId = strBranchOfficeId;

            objDashboard = objDashboardBLL.GetAttendanceDashboard(objDashboard);

            string toAddress = "hadi@sinha-medlar.com";
            string ccAddress = "shahin.alam@sinha-medlar.com";
            string fromDisplayName = "Attendance Summary";
            string subject = "Attendance";
            string actionName = "Action";

            EmailBLL email = new EmailBLL();
            //email.SendAttendanceSummary(toAddress, ccAddress, fromDisplayName, subject, actionName, objDashboard);

            #region Make Attachment

            string fileName = string.Empty;
            string filePath = string.Empty;
            string extention = ".xlsx";
            string downloadFileName = string.Empty;

            System.DateTime moment = DateTime.Now;

            string year = moment.Year.ToString();
            string month = moment.Month.ToString();
            string day = moment.Day.ToString();

            string hour = moment.Hour.ToString();
            string minute = moment.Minute.ToString();
            string second = moment.Second.ToString();

            string dateTime = year + month + day + "_" + hour + minute + second;
            downloadFileName = "dashboard" + "_" + dateTime + extention;
            fileName = downloadFileName;

            string dirPath = Server.MapPath("ExcelFiles");
            fileName = "\\no_punch";
            filePath = dirPath + fileName + extention;
            //ExcelService.ImportExcel(filePath);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.LogDate = "15/02/2021";
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.SittingBranchOfficeId = strBranchOfficeId;

            var data = objEmployeeBLL.GetUnpunchedHomeEmployee(objEmployeeDTO);

            ExcelService.GenerateExcel(data, filePath, "MAL");

            #endregion

            #region Unpunched Data: Don't Remove
            //old
            //string fileName = string.Empty;
            //string filePath = string.Empty;
            //string extention = ".xlsx";
            //string downloadFileName = string.Empty;

            //System.DateTime moment = DateTime.Now;

            //string year = moment.Year.ToString();
            //string month = moment.Month.ToString();
            //string day = moment.Day.ToString();

            //string hour = moment.Hour.ToString();
            //string minute = moment.Minute.ToString();
            //string second = moment.Second.ToString();

            //string dateTime = year + month + day + "_" + hour + minute + second;
            //downloadFileName = "dashboard" + "_" + dateTime + extention;
            //fileName = downloadFileName;

            //string dirPath = Server.MapPath("ExcelFiles");
            //fileName = "\\no_punch";
            //filePath = dirPath + fileName + extention;

            //EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            //EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            //objEmployeeDTO.LogDate = "15/02/2021";
            //objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            //objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            //objEmployeeDTO.SittingBranchOfficeId = strBranchOfficeId;

            //var data = objEmployeeBLL.GetUnpunchedEmployee(objEmployeeDTO);
            #endregion

        }
    }
}