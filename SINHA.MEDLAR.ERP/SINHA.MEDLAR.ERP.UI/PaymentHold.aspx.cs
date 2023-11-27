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
    public partial class PaymentHold : System.Web.UI.Page
    {
        private string paymentTypeId = string.Empty;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");
            paymentTypeId = Request.QueryString["paymentTypeId"];


            if(paymentTypeId == "1")
            {
                lgPaymentHold.InnerText = "Payment Hold- Monthly Salary";
            }
            if (paymentTypeId == "2")
            {
                lgPaymentHold.InnerText = "Payment Hold- Half Salary";
            }
            if (paymentTypeId == "3")
            {
                lgPaymentHold.InnerText = "Payment Hold- Eid Bonus";
            }
            if (paymentTypeId == "4")
            {
                lgPaymentHold.InnerText = "Payment Hold- Leave Encashment";
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
                GetEidType();
                //GetPaymentType();
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

        ////new
        //public void SaveHoldPayment()
        //{

        //    EmployeeDTO objEmployeeDTO = new EmployeeDTO();
        //    EmployeeBLL objEmployeeBLL = new EmployeeBLL();

        //    objEmployeeDTO.HoldId = null;
        //    objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
        //    objEmployeeDTO.Year = txtPaymentYear.Text;
        //    objEmployeeDTO.Month = txtPaymentMonth.Text;

        //    if (ddlPaymentType.SelectedValue.ToString() != "")
        //    {
        //        objEmployeeDTO.PaymentTypeId = ddlPaymentType.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objEmployeeDTO.PaymentTypeId = "";
        //    }

        //    objEmployeeDTO.PaymentYn = "N";
        //    objEmployeeDTO.CreateBy = strEmployeeId;
        //    objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
        //    objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

        //    string strMsg = objEmployeeBLL.SavePaymentHoldEmployee(objEmployeeDTO);
        //    clear();
        //    MessageBox(strMsg);

        //}

        //new
        public void AddHoldEmployee()
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

                            TextBox txtPayTypeId = (TextBox)row.FindControl("txtPayTypeId");
                            TextBox txtEidTypeId = (TextBox)row.FindControl("txtEidTypeId");
                            
                            TextBox txtPayYear = (TextBox)row.FindControl("txtPayYear");
                            TextBox txtPayMonth = (TextBox)row.FindControl("txtPayMonth");
                            
                            objEmployeeDTO.HoldId = null;
                            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                            objEmployeeDTO.Year = txtPayYear.Text;

                            //old
                            //objEmployeeDTO.PaymentTypeId = txtPayTypeId.Text;
                            //new
                            objEmployeeDTO.PaymentTypeId = paymentTypeId;
                            if (paymentTypeId == "1" || paymentTypeId == "2")
                            {
                                objEmployeeDTO.Month = txtPayMonth.Text;
                            }
                            else
                            {
                                objEmployeeDTO.Month = null;
                            }

                            if (paymentTypeId == "3")
                            {
                                objEmployeeDTO.EidTypeId = txtEidTypeId.Text;
                            }
                            else
                            {
                                objEmployeeDTO.EidTypeId = null;
                            }

                            objEmployeeDTO.PaymentYn = "N";
                            objEmployeeDTO.CreateBy = strEmployeeId;
                            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                            chkEmployee.Checked = false;
                            strMsg = objEmployeeBLL.SavePaymentHoldEmployee(objEmployeeDTO);
                        }
                    }
                }
                MessageBox(strMsg);
            }
            catch (Exception ex)
            {
            }
            

            //old
            //EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            //EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            //objEmployeeDTO.HoldId = null;
            //objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
            //objEmployeeDTO.Year = txtPaymentYear.Text;
            //objEmployeeDTO.Month = txtPaymentMonth.Text;

            //if (ddlPaymentType.SelectedValue.ToString() != "")
            //{
            //    objEmployeeDTO.PaymentTypeId = ddlPaymentType.SelectedValue.ToString();
            //}
            //else
            //{
            //    objEmployeeDTO.PaymentTypeId = "";
            //}

            //objEmployeeDTO.PaymentYn = "N";
            //objEmployeeDTO.CreateBy = strEmployeeId;
            //objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            //objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            //string strMsg = objEmployeeBLL.SavePaymentHoldEmployee(objEmployeeDTO);
            //clear();
            //MessageBox(strMsg);

        }


        //old
        //public void SavePaymentHoldEmployee()
        //{

        //    EmployeeDTO objEmployeeDTO = new EmployeeDTO();
        //    EmployeeBLL objEmployeeBLL = new EmployeeBLL();

        //    objEmployeeDTO.HoldId = null;
        //    objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
        //    objEmployeeDTO.Year = txtPaymentYear.Text;
        //    objEmployeeDTO.Month = txtPaymentMonth.Text;

        //    if (ddlPaymentType.SelectedValue.ToString() != "")
        //    {
        //        objEmployeeDTO.PaymentTypeId = ddlPaymentType.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objEmployeeDTO.PaymentTypeId = "";
        //    }

        //    objEmployeeDTO.PaymentYn = "N";
        //    objEmployeeDTO.CreateBy = strEmployeeId;
        //    objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
        //    objEmployeeDTO.BranchOfficeId = strBranchOfficeId;                      
                       
        //    string strMsg = objEmployeeBLL.SavePaymentHoldEmployee(objEmployeeDTO);
        //    clear();
        //    MessageBox(strMsg);

        //}

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

                if(txtPaymentYear.Text == string.Empty)
                {
                    MessageBox("Enter Payment Year");
                    return;
                }

                if(paymentTypeId == "1" || paymentTypeId == "2")
                {
                    if (txtPaymentMonth.Text == string.Empty)
                    {
                        MessageBox("Enter Payment Month");
                        return;
                    }
                }

                if (paymentTypeId == "3")
                {
                    if (ddlEidTypeId.SelectedValue == " ")
                    {
                        MessageBox("Select Eid Type");
                        return;
                    }                 
                }

                GetPaymentHoldEmployee();

                if(ddlUnitId.SelectedValue != " ")
                {
                    if(ddlSectionId.SelectedValue != " ")
                    {
                        GetEmployeeForPaymentHold();
                    }
                }
            }
            catch (Exception ex)
            {
              //  throw new Exception("Error : " + ex.Message);
            }
        }

        public void GetEmployeeForPaymentHold()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            
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

            //old
            //if (ddlPaymentType.SelectedValue.ToString() != "")
            //{
            //    objEmployeeDTO.PaymentTypeId = ddlPaymentType.SelectedValue.ToString();
            //}
            //else
            //{
            //    objEmployeeDTO.PaymentTypeId = "";
            //}

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

            //old
            //if(ddlPaymentType.SelectedValue=="1")
            //{ 
            //dt = objEmployeeBLL.GetEmployeeForPaymentHold(objEmployeeDTO);
            //}

            dt = objEmployeeBLL.GetEmployeeForPaymentHold(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                GvPayableEmployeeList.DataSource = dt;
                GvPayableEmployeeList.DataBind();

                int count = ((DataTable)GvPayableEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
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
        public void GetPaymentHoldEmployee()
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

            //if (ddlPaymentType.SelectedValue.ToString() != "")
            //{
            //    objEmployeeDTO.PaymentTypeId = ddlPaymentType.SelectedValue.ToString();
            //}
            //else
            //{
            //    objEmployeeDTO.PaymentTypeId = "";
            //}

            objEmployeeDTO.PaymentTypeId = paymentTypeId;
            if (paymentTypeId == "3")
            {
                objEmployeeDTO.EidTypeId = ddlEidTypeId.SelectedValue;
            }
            else
            {
                objEmployeeDTO.EidTypeId = null;
            }

            dt = objEmployeeBLL.GetPaymentHoldEmployee(objEmployeeDTO);

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

       
        protected void btnHold_Click(object sender, EventArgs e)
        {
            try
            {
                if (paymentTypeId == "1" || paymentTypeId == "2")
                {
                    if (txtPaymentYear.Text == string.Empty)
                    {
                        MessageBox("Enter Payment Year.");
                        return;
                    }

                    if (txtPaymentMonth.Text == string.Empty)
                    {
                        MessageBox("Enter Payment Month.");
                        return;
                    }
                }
                
                if (paymentTypeId == "3" || paymentTypeId == "4")
                {
                    if (txtPaymentYear.Text == string.Empty)
                    {
                        MessageBox("Enter Payment Year.");
                        return;
                    }
                }
                
                int count = 0;
                foreach (GridViewRow row in GvPayableEmployeeList.Rows)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployeeList");
                    if(chkEmployee.Checked)
                    {
                        count = count + 1;
                    }
                }

                if(count == 0)
                {
                    MessageBox("Please check at least one to hold");
                    return;
                }
                
                AddHoldEmployee();
                GetPaymentHoldEmployee();
            }
            catch (Exception ex)
            {
                throw new Exception("Error :" + ex.Message);
            }
        }
        
        //old
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        {
        //            if (txtEmployeeId.Text == string.Empty)
        //            {
        //                string strMsg = "Please Select employee to hold";
        //                MessageBox(strMsg);
        //                txtEmployeeId.Focus();
        //                return;
        //            }

        //            if (ddlPaymentType.SelectedValue.ToString() == "")
        //            {
        //                string strMsg = "Please Select Payment Type";
        //                MessageBox(strMsg);
        //                ddlPaymentType.Focus();
        //                return;
        //            }
                    

        //            if (txtPaymentYear.Text == string.Empty)
        //            {
        //                string strMsg = "Please Enter Salary Year";
        //                MessageBox(strMsg);
        //                txtPaymentYear.Focus();
        //                return;
        //            }
        //            if (txtPaymentMonth.Text == string.Empty)
        //            {
        //                string strMsg = "Please Enter Salary Month";
        //                MessageBox(strMsg);
        //                txtPaymentMonth.Focus();
        //                return;
        //            }
        //            SavePaymentHoldEmployee();
        //            GetPaymentHoldEmployee();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error :" + ex.Message);
        //    }
        //}


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

                    if (EmployeeId == txtEmployeeId.Text)
                    {
                        TextBox txtHoldId = (TextBox)row.FindControl("txtHoldId");
                        TextBox txtPatmentTypeId = (TextBox)row.FindControl("txtPatmentTypeId");
                        TextBox txtEidTypeId = (TextBox)row.FindControl("txtEidTypeId");

                        objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                        objEmployeeDTO.HoldId = txtHoldId.Text;

                        objEmployeeDTO.PaymentTypeId = txtPatmentTypeId.Text;

                        if (txtPatmentTypeId.Text == "3")
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

                        strMsg = objEmployeeBLL.DeleteEmpFromPaymentHold(objEmployeeDTO);
                    }
                }
            }
            MessageBox(strMsg);
            GetPaymentHoldEmployee();
            GetEmployeeForPaymentHold();

        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //GvEmployeeCache.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

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
                if (paymentTypeId == "1" || paymentTypeId == "2")
                {
                    if (txtPaymentYear.Text == string.Empty)
                    {
                        MessageBox("Enter Payment Year.");
                        return;
                    }

                    if (txtPaymentMonth.Text == string.Empty)
                    {
                        MessageBox("Enter Payment Month.");
                        return;
                    }
                }

                if (paymentTypeId == "3" || paymentTypeId == "4")
                {
                    if (txtPaymentYear.Text == string.Empty)
                    {
                        MessageBox("Enter Payment Year.");
                        return;
                    }
                }

                //int count = 0;
                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployeeList");
                //    if (chkEmployee.Checked)
                //    {
                //        count = count + 1;
                //    }
                //}

                //if (count == 0)
                //{
                //    MessageBox("Please check at least one to hold");
                //    return;
                //}

                GetHoldEmployeeSheet();
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
        public void GetHoldEmployeeSheet()
        {

            try
            {

                EmployeeBLL objEmployeeBLL = new EmployeeBLL();
                EmployeeDTO objEmployeeDTO = new EmployeeDTO();

                objEmployeeDTO.EmployeeId = txtEmpId.Text;
                objEmployeeDTO.CardNo = txtEmpCardNo.Text;

                //if (ddlPaymentType.SelectedValue.ToString() != "")
                //{
                //    objEmployeeDTO.PaymentTypeId = ddlPaymentType.SelectedValue.ToString();
                //}
                //else
                //{
                //    objEmployeeDTO.PaymentTypeId = "";
                //}

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
                
                string strPath = Path.Combine(Server.MapPath("~/Reports/RptPaymentHoldEmployeeSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objEmployeeBLL.GetPaymentHoldEmployee(objEmployeeDTO));

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
        //public void goToNextRecord()
        //{
        //    if (txtSL.Text == string.Empty)
        //    {
        //        txtSL.Text = "1";
        //    }

        //    int i = 1, j, k, result;
        //    j = Convert.ToInt32(txtSL.Text);
        //    k = j;
        //    //gvIncrementList.SelectedIndex = 1;


        //    int l;
        //    l = GvPayableEmployeeList.SelectedRow.RowIndex;
        //    if (l != 0)
        //    {

        //        int strId = GvPayableEmployeeList.SelectedRow.RowIndex + 1;
        //        int strRowCount = strId;
        //        int intCount = GvPayableEmployeeList.Rows.Count;
        //        if (intCount == strRowCount)
        //        {
        //            string strMsg = "There is no Data for the Next Record!!!";
        //            MessageBox(strMsg);
        //            return;
        //        }
        //        else
        //        {
        //            GvPayableEmployeeList.SelectedIndex += 1;
        //            result = GvPayableEmployeeList.SelectedRow.RowIndex + k;
        //        }

        //    }
        //    if (l == 0)
        //    {

        //        int intCount = GvPayableEmployeeList.Rows.Count;
        //        int intCountRow = GvPayableEmployeeList.Rows.Count;
        //        if (intCountRow == 1)
        //        {
        //            intCountRow = 2;
        //        }

        //        int p = intCountRow - 1;
        //        //int p = intCountRow;
        //        if (l == p)
        //        {
        //            string strMsg = "There is no Data for the Next Record!!!";
        //            MessageBox(strMsg);
        //            return;
        //        }

        //        else
        //        {
        //            l = 1;

        //            if (txtSL.Text == "1" && txtSLNew.Text == "")
        //            {
        //                GvPayableEmployeeList.SelectedIndex = 0;
        //                result = GvPayableEmployeeList.SelectedRow.RowIndex + k;
        //                txtSLNew.Text = "1";

        //            }
        //            else
        //            {

        //                int intC = GvPayableEmployeeList.Rows.Count;
        //                int intCo = GvPayableEmployeeList.Rows.Count;
        //                int ll = 0;

        //                int pp = intCo - 1;
        //                if (ll == pp)
        //                {
        //                    string strMsg = "There is no Data for the Next Record!!!";
        //                    MessageBox(strMsg);
        //                    return;
        //                }
        //                else
        //                {
        //                    GvPayableEmployeeList.SelectedIndex += 1;
        //                    result = GvPayableEmployeeList.SelectedRow.RowIndex + k;
        //                }
        //            }
        //        }
        //    }

        //    int strRowId = GvPayableEmployeeList.SelectedRow.RowIndex + 1;
        //    string strSLNo = GvPayableEmployeeList.SelectedRow.Cells[0].Text;
        //    if (strSLNo == "NO RECORD FOUND")
        //    {
        //        string strMsg = "NO RECORD FOUND!!!";
        //        MessageBox(strMsg);
        //        return;
        //    }
        //    else
        //    {

        //        string CardNo = GvPayableEmployeeList.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        //        string EmpId = GvPayableEmployeeList.SelectedRow.Cells[2].Text;

        //        string EmpName = GvPayableEmployeeList.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
        //        string Designation = GvPayableEmployeeList.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");

        //        txtSL.Text = Convert.ToString(strRowId);
        //        txtCardNo.Text = CardNo;
        //        txtEmployeeId.Text = EmpId;
        //        txtEmployeeName.Text = EmpName;
        //        txtDesignationName.Text = Designation;

        //    }
        //}

        //public void goToPreviousRecord()
        //{
        //    int i = 1, j, k, result;
        //    j = Convert.ToInt32(txtSL.Text);
        //    k = j;
        //    //gvIncrementList.SelectedIndex = 1;

        //    int l;
        //    l = GvPayableEmployeeList.SelectedRow.RowIndex;
        //    if (l != 0)
        //    {
        //        int strId = GvPayableEmployeeList.SelectedRow.RowIndex - 1;
        //        int strRowCount = strId;
        //        int intCount = GvPayableEmployeeList.Rows.Count;
        //        if (intCount == strRowCount)
        //        {
        //            string strMsg = "There is no Data for the Previous Record!!!";
        //            MessageBox(strMsg);
        //            //txtInsideDay.Focus();
        //            return;
        //        }
        //        else
        //        {
        //            GvPayableEmployeeList.SelectedIndex -= 1;
        //            result = GvPayableEmployeeList.SelectedRow.RowIndex - k;
        //        }
        //    }
        //    if (l == 0)
        //    {
        //        int intCountRow = GvPayableEmployeeList.Rows.Count;
        //        int p = intCountRow;
        //        if (intCountRow == p)
        //        {
        //            string strMsg = "There is no Data for the Previous Record!!!";
        //            MessageBox(strMsg);
        //           // txtInsideDay.Focus();
        //            return;
        //        }
        //        else
        //        {
        //            l = 1;
        //            GvPayableEmployeeList.SelectedIndex = l;
        //            result = GvPayableEmployeeList.SelectedRow.RowIndex - k;
        //        }
        //    }

        //    int strRowId = GvPayableEmployeeList.SelectedRow.RowIndex + 1;

        //    string strSLNo = GvPayableEmployeeList.SelectedRow.Cells[0].Text;
        //    string CardNo = GvPayableEmployeeList.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
        //    string EmpId = GvPayableEmployeeList.SelectedRow.Cells[2].Text;

        //    string EmpName = GvPayableEmployeeList.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
        //    string Designation = GvPayableEmployeeList.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");

        //    txtSL.Text = Convert.ToString(strRowId);
        //    txtCardNo.Text = CardNo;
        //    txtEmployeeId.Text = EmpId;
        //    txtEmployeeName.Text = EmpName;
        //    txtDesignationName.Text = Designation;
        //   // txtInsideDay.Focus();
        //}
        public void GetResignEmployeeSheet()
        {

            try
            {
                //ReportDTO objReportDTO = new ReportDTO();
                //ReportBLL objReportBLL = new ReportBLL();
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();
                EmployeeDTO objEmployeeDTO = new EmployeeDTO();

                objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
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

              
                objEmployeeDTO.CreateBy = strEmployeeId;


                string strPath = Path.Combine(Server.MapPath("~/Reports/RptResignEmployeeSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objEmployeeBLL.GetResignEmployee(objEmployeeDTO));

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

        protected void btnBkashTemplateByPhase_Click(object sender, EventArgs e)
        {

            if (paymentTypeId == "1" || paymentTypeId == "2")
            {
                if (txtPaymentYear.Text == string.Empty)
                {
                    MessageBox("Enter Payment Year.");
                    return;
                }

                if (txtPaymentMonth.Text == string.Empty)
                {
                    MessageBox("Enter Payment Month.");
                    return;
                }
            }

            if (paymentTypeId == "3" || paymentTypeId == "4")
            {
                if (txtPaymentYear.Text == string.Empty)
                {
                    MessageBox("Enter Payment Year.");
                    return;
                }
            }

            int count = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                if (chkEmployee.Checked)
                {
                    count = count + 1;
                }
            }

            if (count == 0)
            {
                MessageBox("Please check at least one to hold");
                return;
            }

            GetHoldTemplateByEmployee();
        }
        public void GetHoldBkashTemplate(List<MfsTemplate> objTemplateList)
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.Year = txtPaymentYear.Text.Trim();
                objReportDTO.Month = txtPaymentMonth.Text.Trim();
                
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objTemplateList);
                
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
        
        public void GetHoldTemplateByEmployee()
        {
            int count = 0;
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            ReportBLL objReportBLL = new ReportBLL();
            MfsTemplate objTemplate = new MfsTemplate();
            List<MfsTemplate> objTemplateList = new List<MfsTemplate>();

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {
                        TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
                        TextBox txtPatmentTypeId = (TextBox)row.FindControl("txtPatmentTypeId");
                        TextBox txtEidTypeId = (TextBox)row.FindControl("txtEidTypeId");

                        objEmployeeDTO.Year = txtPaymentYear.Text.Trim();
                        if (txtPatmentTypeId.Text == "1" || txtPatmentTypeId.Text == "2")
                        {
                            objEmployeeDTO.Month = txtPaymentMonth.Text.Trim();
                        }
                        else
                        {
                            objEmployeeDTO.Month = null;
                        }
                        objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                        objEmployeeDTO.PaymentTypeId = txtPatmentTypeId.Text;

                        if (txtPatmentTypeId.Text == "3")
                        {
                            objEmployeeDTO.EidTypeId = txtEidTypeId.Text;
                        }
                        else
                        {
                            objEmployeeDTO.EidTypeId = null;
                        }

                        objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                        objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                        objEmployeeDTO.UpdateBy = strEmployeeId;

                        objTemplate = new MfsTemplate();
                        objTemplate = objReportBLL.GetHoldBkashTemplate(objEmployeeDTO);
                        objTemplateList.Add(objTemplate);
                        count = count + 1;
                    }
                }
            }
            GetHoldBkashTemplate(objTemplateList);
            //MessageBox(count.ToString() + " Record(s) Added.");
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (paymentTypeId == "1" || paymentTypeId == "2")
                {
                    if (txtPaymentYear.Text == string.Empty)
                    {
                        MessageBox("Enter Payment Year.");
                        return;
                    }

                    if (txtPaymentMonth.Text == string.Empty)
                    {
                        MessageBox("Enter Payment Month.");
                        return;
                    }
                }

                if (paymentTypeId == "3" || paymentTypeId == "4")
                {
                    if (txtPaymentYear.Text == string.Empty)
                    {
                        MessageBox("Enter Payment Year.");
                        return;
                    }
                }

                int count = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {
                        count = count + 1;
                    }
                }

                if (count == 0)
                {
                    MessageBox("Please check at least one to hold");
                    return;
                }

                MakeHoldPayment();
                GetPaymentHoldEmployee(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error :" + ex.Message);
            }
        }
        public string MakeHoldPayment()
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";

            int recordCounter = 0;
            try
            {
                string status = string.Empty;

                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");

                        if (chkEmployee.Checked)
                        {
                        recordCounter = recordCounter + 1;

                        TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
                        TextBox txtHoldId = (TextBox)row.FindControl("txtHoldId");
                        TextBox txtPatmentTypeId = (TextBox)row.FindControl("txtPatmentTypeId");
                        TextBox txtEidTypeId = (TextBox)row.FindControl("txtEidTypeId");

                        objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                        objEmployeeDTO.HoldId = txtHoldId.Text;
                        objEmployeeDTO.PaymentTypeId = txtPatmentTypeId.Text;

                        if (txtPatmentTypeId.Text == "3")
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

                        strMsg = objEmployeeBLL.MakeHoldPayment(objEmployeeDTO);
                        }
                    }
                }
                MessageBox(strMsg);
            }
            catch (Exception ex)
            {
            }
            return strMsg;

        }

        protected void btnUnpaid_Click(object sender, EventArgs e)
        {
            try
            {
                if (paymentTypeId == "1" || paymentTypeId == "2")
                {
                    if (txtPaymentYear.Text == string.Empty)
                    {
                        MessageBox("Enter Payment Year.");
                        return;
                    }

                    if (txtPaymentMonth.Text == string.Empty)
                    {
                        MessageBox("Enter Payment Month.");
                        return;
                    }
                }

                if (paymentTypeId == "3" || paymentTypeId == "4")
                {
                    if (txtPaymentYear.Text == string.Empty)
                    {
                        MessageBox("Enter Payment Year.");
                        return;
                    }
                }

                int count = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {
                        count = count + 1;
                    }
                }

                if (count == 0)
                {
                    MessageBox("Please check at least one to hold");
                    return;
                }

               HoldPayment();
               GetPaymentHoldEmployee();
                   
            }
            catch (Exception ex)
            {
                throw new Exception("Error :" + ex.Message);
            }
        }
        public string HoldPayment()
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";

            int recordCounter = 0;
            try
            {
                string status = string.Empty;

                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");

                        if (chkEmployee.Checked)
                        {
                            recordCounter = recordCounter + 1;

                            TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
                            TextBox txtHoldId = (TextBox)row.FindControl("txtHoldId");
                            TextBox txtPatmentTypeId = (TextBox)row.FindControl("txtPatmentTypeId");
                            TextBox txtEidTypeId = (TextBox)row.FindControl("txtEidTypeId");

                            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                            objEmployeeDTO.HoldId = txtHoldId.Text;
                            objEmployeeDTO.PaymentTypeId = txtPatmentTypeId.Text;

                            if (txtPatmentTypeId.Text == "3")
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

                            strMsg = objEmployeeBLL.HoldPayment(objEmployeeDTO);
                        }
                    }
                }
                MessageBox(strMsg);
            }
            catch (Exception ex)
            {
            }
            return strMsg;
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