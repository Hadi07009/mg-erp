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
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;
using System.Web.UI.HtmlControls;
using CrystalDecisions.Web;
using SINHA.MEDLAR.ERP.COMMON.Utility.Image;
using System.Web.Services;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class IndividualPaymentPhase : System.Web.UI.Page
    {
        string strEmployeeId = "";
        string strSectionId = "";
        string strDepartmentId = "";
        string strDesignationId = "";
        string strUnitId = "";
        string strCatagoryId;
        private static string strHeadOfficeId = "";
        private static string strBranchOfficeId = "";
        string strEmployeeTypeId = "";
        string strLoginDay = "";
        string strLoginMonth = "";
        string strLoginDate = "";
        string strID = "";
        ReportDocument rd = new ReportDocument();
        string strDefaultName = "Report";
        ExportFormatType formatType = ExportFormatType.NoFormat;

        private string paymentTypeId = string.Empty;
        //private string eidTypeId = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            paymentTypeId = Request.QueryString["paymentTypeId"];
            //eidTypeId = Request.QueryString["eidTypeId"];


            if (paymentTypeId == "1")
            {
                lgIndividualPayment.InnerText = "Individual Payment- Monthly Salary";
            }
            if (paymentTypeId == "2")
            {
                lgIndividualPayment.InnerText = "Individual Payment- Half Salary";
            }
            if (paymentTypeId == "3")
            {
                lgIndividualPayment.InnerText = "Individual Payment- Eid Bomus";
            }
            if (paymentTypeId == "4")
            {
                lgIndividualPayment.InnerText = "Individual Payment- Leave Encashment";
            }


            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;
            }

            if (!IsPostBack)
            {
                loadSesscion();
                GetMonthYearForIndPhase();
                getUnitId();
                getSectionId();
                GetDesignation();
                GetEidType();
                GetEidTypeForSearching();
                //GetPaymentType();
                GetPaymentPhase();
                //GetPaymentTypeSearch();
                GetPaymentPhaseSearch();
                getOfficeName();
                lblMsg.Text = string.Empty;
                
            }
            if (IsPostBack)
            {
                loadSesscion();
                Session["strID"] = null;
            }
            //txtInsideDay.Attributes.Add("onkeypress", "return controlEnter('" + txtOutSideDay.ClientID + "', event)");
            //txtOutSideDay.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");
        }
        #region "Load Drop Down List"


        #region "Encrypt"
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
                
        #endregion
        public void loadSesscion()
        {
            strEmployeeId = Session["strEmployeeId"].ToString().Trim();
            strSectionId = Session["strSectionId"].ToString().Trim();
            strDesignationId = Session["strDesignationId"].ToString().Trim();
            strUnitId = Session["strUnitId"].ToString().Trim();
            strCatagoryId = Session["strCatagoryId"].ToString().Trim();
            strHeadOfficeId = Session["strHeadOfficeId"].ToString().Trim();
            strBranchOfficeId = Session["strBranchOfficeId"].ToString().Trim();
            strLoginDay = Session["strLoginDay"].ToString().Trim();
            strLoginMonth = Session["strLoginMonth"].ToString().Trim();
            strLoginDate = Session["strLoginDate"].ToString().Trim();

            if (Session["strID"] != null)
            {
                strID = Session["strID"].ToString().Trim();
            }
        }
        public void CreateSession()
        {
            string employeeId = "_" + Request.Cookies["eid"].Value.ToString();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            var employee = objEmployeeBLL.GetEmployeeById(employeeId);
            string suffix = "_" + (string)employee.Rows[0]["BRANCH_OFFICE_ID"];

            strEmployeeId = Session["strEmployeeId" + suffix].ToString().Trim();
            strSectionId = Session["strSectionId" + suffix].ToString().Trim();
            strDesignationId = Session["strDesignationId" + suffix].ToString().Trim();
            strUnitId = Session["strUnitId" + suffix].ToString().Trim();
            strCatagoryId = Session["strCatagoryId" + suffix].ToString().Trim();
            strHeadOfficeId = Session["strHeadOfficeId" + suffix].ToString().Trim();
            strBranchOfficeId = Session["strBranchOfficeId" + suffix].ToString().Trim();
            strLoginDay = Session["strLoginDay" + suffix].ToString().Trim();
            strLoginMonth = Session["strLoginMonth" + suffix].ToString().Trim();
            strLoginDate = Session["strLoginDate" + suffix].ToString().Trim();
            if (Session["strID" + suffix] != null)
            {
                strID = Session["strID" + suffix].ToString().Trim();
            }
        }
        public void ClearSession()
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

        public void GetMonthYearForIndPhase()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            if (paymentTypeId == "1" || paymentTypeId == "2" || paymentTypeId == "3")
            {
                txtPaymentYear.Text = objLookUpDTO.Year;
            }

            if (paymentTypeId == "4")
            {
                txtPaymentYear.Text = Convert.ToString(Convert.ToInt32(objLookUpDTO.Year) - 1);
            }
           
            if (paymentTypeId == "1" || paymentTypeId == "2")
            {
                txtPaymentMonth.Text = objLookUpDTO.Month;
            }
            else
            {
                txtPaymentMonth.Text = "";
            }

        }


        //public void GetMonthYearForSalary()
        //{

        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

        //    txtPaymentYear.Text = objLookUpDTO.Year;
        //    txtPaymentMonth.Text = objLookUpDTO.Month;

        //}

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
        
      
        public void getSectionId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSectionId.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);
            ddlSectionId.DataTextField = "SECTION_NAME";
            ddlSectionId.DataValueField = "SECTION_ID";

            ddlSectionId.DataBind();
            if (ddlSectionId.Items.Count > 0)
            {
                ddlSectionId.SelectedIndex = 0;
            }
        }
        //public void GetPaymentType()
        //{

        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlPaymentType.DataSource = objLookUpBLL.GetPaymentType();
        //    ddlPaymentType.DataTextField = "PAYMENT_TYPE_NAME";
        //    ddlPaymentType.DataValueField = "PAYMENT_TYPE_ID";

        //    ddlPaymentType.DataBind();
        //    if (ddlPaymentType.Items.Count > 0)
        //    {
        //        ddlPaymentType.SelectedIndex = 0;
        //    }
        //}
        public void GetPaymentPhase()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPaymentPhase.DataSource = objLookUpBLL.GetPaymentPhase();
            ddlPaymentPhase.DataTextField = "PHASE_NAME";
            ddlPaymentPhase.DataValueField = "PAYMENT_PHASE_ID";

            ddlPaymentPhase.DataBind();
            if (ddlPaymentPhase.Items.Count > 0)
            {
                ddlPaymentPhase.SelectedIndex = 0;
            }
        }
        public void GetDesignation()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlDesignation.DataSource = objLookUpBLL.getDesignationId(strHeadOfficeId,strBranchOfficeId);
            ddlDesignation.DataTextField = "DESIGNATION_NAME";
            ddlDesignation.DataValueField = "DESIGNATION_ID";

            ddlDesignation.DataBind();
            if (ddlDesignation.Items.Count > 0)
            {
                ddlDesignation.SelectedIndex = 0;
            }
        }

        public void GetEidType()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEidTypeId.DataSource = objLookUpBLL.getEidTypeId();
            ddlEidTypeId.DataTextField = "EID_NAME";
            ddlEidTypeId.DataValueField = "EID_TYPE_ID";

            ddlEidTypeId.DataBind();
            if (ddlEidTypeId.Items.Count > 0)
            {
                ddlEidTypeId.SelectedIndex = 0;
            }
        }

        public void GetEidTypeForSearching()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEidTypeIdSearch.DataSource = objLookUpBLL.getEidTypeId();
            ddlEidTypeIdSearch.DataTextField = "EID_NAME";
            ddlEidTypeIdSearch.DataValueField = "EID_TYPE_ID";

            ddlEidTypeIdSearch.DataBind();
            if (ddlEidTypeIdSearch.Items.Count > 0)
            {
                ddlEidTypeIdSearch.SelectedIndex = 0;
            }
        }



        //public void GetPaymentTypeSearch()
        //{

        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlPaymentTypeSearch.DataSource = objLookUpBLL.GetPaymentType();
        //    ddlPaymentTypeSearch.DataTextField = "PAYMENT_TYPE_NAME";
        //    ddlPaymentTypeSearch.DataValueField = "PAYMENT_TYPE_ID";

        //    ddlPaymentTypeSearch.DataBind();
        //    if (ddlPaymentTypeSearch.Items.Count > 0)
        //    {
        //        ddlPaymentTypeSearch.SelectedIndex = 0;
        //    }
        //}
        public void GetDesignationSearch()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlDesignation.DataSource = objLookUpBLL.getDesignationId(strHeadOfficeId, strBranchOfficeId);
            ddlDesignation.DataTextField = "DESIGNATION_NAME";
            ddlDesignation.DataValueField = "DESIGNATION_ID";

            ddlDesignation.DataBind();
            if (ddlDesignation.Items.Count > 0)
            {
                ddlDesignation.SelectedIndex = 0;
            }
        }

        public void GetPaymentPhaseSearch()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPaymentPhaseSearch.DataSource = objLookUpBLL.GetPaymentPhase();
            ddlPaymentPhaseSearch.DataTextField = "PHASE_NAME";
            ddlPaymentPhaseSearch.DataValueField = "PAYMENT_PHASE_ID";

            ddlPaymentPhaseSearch.DataBind();
            if (ddlPaymentPhaseSearch.Items.Count > 0)
            {
                ddlPaymentPhaseSearch.SelectedIndex = 0;
            }
        }
        #endregion
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

        //public void passValue(string strEmployeeId, string strHeadOfficeId)
        //{
        //    txtEmployeeId.Text = strEmployeeId;
        //    txtEmployeeId.Text = Session["strID"].ToString().Trim();
        //    //searchEmployeeInfo();

        //}
        #endregion
        #region "DML"

   
        public void CreateIndividualPaymentPhase()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";

            int recordCounter = 0;
            try
            {
                string status = string.Empty;

                foreach (GridViewRow row in GvPayableEmployeeList.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployeeList");
                        if (chkEmployee.Checked)
                        {
                            recordCounter = recordCounter + 1;
                            TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");

                            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                            objEmployeeDTO.Year = txtPaymentYear.Text;

                            if (paymentTypeId == "1" || paymentTypeId == "2")
                            {
                                objEmployeeDTO.Month = txtPaymentMonth.Text;
                            }
                            else
                            {
                                objEmployeeDTO.Month = null;
                            }

                            objEmployeeDTO.PhaseId = ddlPaymentPhase.SelectedValue.ToString();
                                                        
                            objEmployeeDTO.PaymentTypeId = paymentTypeId;
                            
                            if (paymentTypeId == "3") //eid bonus
                            {
                                objEmployeeDTO.EidTypeId = ddlEidTypeId.SelectedValue;
                            }
                            else
                            {
                                objEmployeeDTO.EidTypeId = null;
                            }

                            objEmployeeDTO.CreateBy = strEmployeeId;
                            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                            chkEmployee.Checked = false;
                            strMsg = objEmployeeBLL.CreateIndividualPaymentPhase(objEmployeeDTO);
                        }
                    }
                }
                MessageBox(strMsg);
            }
            catch (Exception ex)
            {
            }
        }


        public void clear()
        {
            //txtEmployeeId.Text = string.Empty;
            //txtCardNo.Text = string.Empty;
            //txtEmployeeName.Text = string.Empty;
            //txtDesignationName.Text = string.Empty;
        }

        public void loadCombo()
        {           
            getUnitId();
            getSectionId();                  
        }
        #endregion
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetIndividualPaidEmployee();
                GetEmployeeForIndividualPayment();
            }
            catch (Exception ex)
            {
              //  throw new Exception("Error : " + ex.Message);
            }
        }

        public void GetEmployeeForIndividualPayment()
        {
            if (ddlUnitId.SelectedItem.Value == " "
                   && ddlSectionId.SelectedItem.Value == " "
                   && ddlDesignation.SelectedItem.Value == " ")
            {
                MessageBox("please select Unit or Section or Designation.");
                return;
            }

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;

           
            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";
            }
            if (ddlDesignation.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.DesignationId = ddlDesignation.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.DesignationId = "";
            }
            objEmployeeDTO.PhaseId = ddlPaymentPhase.SelectedValue.ToString();
            
            objEmployeeDTO.PaymentTypeId = paymentTypeId;
                                   
            objEmployeeDTO.Year = txtPaymentYear.Text;
            
            if (paymentTypeId == "1" || paymentTypeId == "2")
            {
                objEmployeeDTO.Month = txtPaymentMonth.Text;
            }
            else
            {
                objEmployeeDTO.Month = null;
            }

            if (paymentTypeId == "3")
            {
                objEmployeeDTO.EidTypeId = ddlEidTypeIdSearch.SelectedValue;
            }
            else
            {
                objEmployeeDTO.EidTypeId = null;
            }

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            dt = objEmployeeBLL.GetEmployeeForIndividualPayment(objEmployeeDTO);
            

            if (dt.Rows.Count > 0)
            {
                GvPayableEmployeeList.DataSource = dt;
                GvPayableEmployeeList.DataBind();

                int count = ((DataTable)GvPayableEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GvPayableEmployeeList.DataSource = dt;
                GvPayableEmployeeList.DataBind();
                int totalcolums = GvPayableEmployeeList.Rows[0].Cells.Count;
                GvPayableEmployeeList.Rows[0].Cells.Clear();
                GvPayableEmployeeList.Rows[0].Cells.Add(new TableCell());
                GvPayableEmployeeList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GvPayableEmployeeList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }
        public void GetIndividualPaidEmployee()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;

            objEmployeeDTO.Year = txtPaymentYear.Text;
            if (paymentTypeId == "1" || paymentTypeId == "2")
            {
                objEmployeeDTO.Month = txtPaymentMonth.Text;
            }
            else
            {
                objEmployeeDTO.Month = null;
            }
                        
            objEmployeeDTO.PaymentTypeId = paymentTypeId;
            if (paymentTypeId == "3")
            {
                objEmployeeDTO.EidTypeId = ddlEidTypeIdSearch.SelectedValue;
            }
            else
            {
                objEmployeeDTO.EidTypeId = null;
            }
                        
            if (ddlPaymentPhaseSearch.SelectedValue.ToString() != "0")
            {
                objEmployeeDTO.PhaseId = ddlPaymentPhaseSearch.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.PhaseId = null;
            }


            dt = objEmployeeBLL.GetIndividualPaidEmployee(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsg.Text = strMsg;
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string strMsg = "NO RECORD FOUND!!!";
                lblMsg.Text = strMsg;
            }

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {   
                if (txtPaymentYear.Text == string.Empty)
                {
                    string strMsg = "Enter Payment Year";
                    MessageBox(strMsg);
                    return;
                }

                if (paymentTypeId == "1" || paymentTypeId == "2")
                {
                    if (txtPaymentMonth.Text == string.Empty)
                    {
                        string strMsg = "Enter Payment Month";
                        MessageBox(strMsg);
                        return;
                    }
                }

                if (paymentTypeId == "3")
                {
                    if(ddlEidTypeId.SelectedValue == " ")
                    {
                        MessageBox("Select Eid Type.");
                        return;
                    }
                }

                if (ddlPaymentPhase.Text == string.Empty)
                {
                    string strMsg = "Select Payment Phase";
                    MessageBox(strMsg);
                    return;
                }

                int count = 0;
                foreach (GridViewRow row in GvPayableEmployeeList.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployeeList");
                        if (chkEmployee.Checked)
                        {
                            count = count + 1;
                        }
                    }
                }

                if(count==0)
                {
                    MessageBox("Select one or more row(s).");
                    return;
                }

                CreateIndividualPaymentPhase();
                GetIndividualPaidEmployee();
            }
            catch (Exception ex)
            {
                throw new Exception("Error :" + ex.Message);
            }
        }    

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        #region "Grid View Functionality"
        protected void GvPayableEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvPayableEmployeeList.PageIndex = e.NewPageIndex;
        }

        protected void GvPayableEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //clear();

            //int strRowId = GvPayableEmployeeList.SelectedRow.RowIndex + 1;
            //string strSLNo = GvPayableEmployeeList.SelectedRow.Cells[0].Text;
            //string CardNo = GvPayableEmployeeList.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            //string EmpId = GvPayableEmployeeList.SelectedRow.Cells[2].Text;
            
            //string EmpName = GvPayableEmployeeList.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            //string Designation = GvPayableEmployeeList.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");

            //txtCardNo.Text = CardNo;
            //txtEmployeeId.Text = EmpId;
            //txtEmployeeName.Text = EmpName;
            //txtDesignationName.Text = Designation;

        }
        protected void GvPayableEmployeeList_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GvPayableEmployeeList, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GvPayableEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
        {           
        }

        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }
        protected void GvPayableEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //GvEmployeeCache.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }





        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
            //int strRowId = GridView1.SelectedRow.RowIndex + 1;
            //string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            //string CardNo = GridView1.SelectedRow.Cells[1].Text;
            //string EmpId = GridView1.SelectedRow.Cells[2].Text;
            //string EmpName = GridView1.SelectedRow.Cells[3].Text;
            //string Designation = GridView1.SelectedRow.Cells[4].Text;
            //string holdId = GridView1.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            
            //txtEmployeeId.Text = EmpId;
            //txtCardNo.Text = CardNo;
            //txtEmployeeName.Text = EmpName;
            //txtDesignationName.Text = Designation;
            //txtHoldId.Text = holdId;
           
        }
        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void GridView1_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";
            string status = string.Empty;

            string EmployeeId = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"]);

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {                    
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
                                        
                    TextBox txtPatmentPhaseId = (TextBox)row.FindControl("txtPatmentPhaseId");
                    TextBox txtPatmentTypeId = (TextBox)row.FindControl("txtPatmentTypeId");
                    TextBox txtEidTypeId = (TextBox)row.FindControl("txtEidTypeId");

                    if (EmployeeId == txtEmployeeId.Text)
                    {                     
                        objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                        objEmployeeDTO.PhaseId = txtPatmentPhaseId.Text; //ddlPaymentPhase.SelectedValue.ToString();
                        
                        objEmployeeDTO.PaymentTypeId = txtPatmentTypeId.Text;

                        if(txtPatmentTypeId.Text == "3")
                        {
                            objEmployeeDTO.EidTypeId = txtEidTypeId.Text;
                        }
                        else
                        {
                            objEmployeeDTO.EidTypeId = null;
                        }

                        objEmployeeDTO.Year = txtPaymentYear.Text;
                        if (txtPatmentTypeId.Text == "1" || txtPatmentTypeId.Text == "2")
                        {
                            objEmployeeDTO.Month = txtPaymentMonth.Text;
                        }
                        else
                        {
                            objEmployeeDTO.Month = null;
                        }
                        
                        objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                        objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                        objEmployeeDTO.CreateBy = strEmployeeId;

                        strMsg = objEmployeeBLL.DeleteEmpFromIndividualPayment(objEmployeeDTO);
                    }
                }
            }
            MessageBox(strMsg);
            GetIndividualPaidEmployee();
            GetEmployeeForIndividualPayment();

        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
        #endregion
        public void reportMaster()
        {

            if (chkPDF.Checked == true)
            {

                //CrystalReportViewer1.ReportSource = rd;
                //CrystalReportViewer1.DataBind();

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
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "employee_report");
                Response.End();
                //CrystalReportViewer1.RefreshReport();

            }
        }


        #region "Crystal Report Functionality"

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            //CrystalReportViewer1.Dispose();
            //CrystalReportViewer1 = null;
            rd.Dispose();
            rd.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {
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

        protected void btnSheet_Click(object sender, EventArgs e)
        {
            try
            {
                GetIndividualPaymentSheet();
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
        public void GetIndividualPaymentSheet()
        {
            try
            {

                EmployeeBLL objEmployeeBLL = new EmployeeBLL();
                EmployeeDTO objEmployeeDTO = new EmployeeDTO();

                objEmployeeDTO.EmployeeId = txtEmpId.Text;
                objEmployeeDTO.CardNo = txtEmpCardNo.Text;
                                
                objEmployeeDTO.PaymentTypeId = paymentTypeId;
                                
                if (paymentTypeId == "3")
                {
                    objEmployeeDTO.EidTypeId = ddlEidTypeId.SelectedValue;
                }
                else
                {
                    objEmployeeDTO.EidTypeId = null;
                }

                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objEmployeeDTO.UnitId = "";
                }

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objEmployeeDTO.SectionId = "";
                }
                objEmployeeDTO.Year = txtPaymentYear.Text;


                if (paymentTypeId == "1" || paymentTypeId == "2")
                {
                    objEmployeeDTO.Month = txtPaymentMonth.Text;
                }
                else
                {
                    objEmployeeDTO.Month = null;
                }
                
                objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                objEmployeeDTO.CreateBy = strEmployeeId;
                
                string strPath = Path.Combine(Server.MapPath("~/Reports/RptIndividualPaymentSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objEmployeeBLL.GetIndividualPaymentSheet(objEmployeeDTO));

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

        protected void BtnMFSTemplate_Click(object sender, EventArgs e)
        {
            if (paymentTypeId == "1")
            {
                Response.Redirect("MFSTemplate.aspx");
            }
            if (paymentTypeId == "2")
            {
                Response.Redirect("MFSTemplateHalfSalary.aspx");
            }
            if (paymentTypeId == "3")
            {
                Response.Redirect("MFSTemplateEidBomus.aspx");
            }
            if (paymentTypeId == "4")
            {
                Response.Redirect("MFSTemplateLeaveEncashment.aspx");
            }
        }
    }
}