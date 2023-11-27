using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;

using System.Configuration;
using System.Web.Security;
using System.Data;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class TransferProcess : System.Web.UI.Page
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
                //getUnitIdTo();
               
               
                getOfficeIdTo();
                //getCatagoryId();
                //getSectionIdFrom();
                //getSectionIdTo();
                getEmployeeId();
                clearMsg();
                getMonthYearForTax();
                getOfficeName();
                getUnitId();
                getSectionId();
                getUnitIdTo();
                getSectionIdTo();

            }
            if (IsPostBack)
            {

                loadSesscion();
               
            }
        }

        #region "FUNCTION"




        public void getUnitIdToByOfficeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();

            string strBranchOfficeId = "";
            if (ddlOfficeIdTo.SelectedValue.ToString() != " ")
            {
                strBranchOfficeId = ddlOfficeIdTo.SelectedValue.ToString();
            }
            else
            {
                strBranchOfficeId = "";

            }

            ddlUnitIdTo.DataSource = objLookUpBLL.getUnitIdToByOfficeId(strBranchOfficeId);

            ddlUnitIdTo.DataTextField = "UNIT_NAME";
            ddlUnitIdTo.DataValueField = "UNIT_ID";

            ddlUnitIdTo.DataBind();
            if (ddlUnitIdTo.Items.Count > 0)
            {

                ddlUnitIdTo.SelectedIndex = 0;
            }

        }

        public void getUnitIdTo()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();

         

            ddlUnitIdTo.DataSource = objLookUpBLL.getUnitIdTo(strHeadOfficeId);

            ddlUnitIdTo.DataTextField = "UNIT_NAME";
            ddlUnitIdTo.DataValueField = "UNIT_ID";

            ddlUnitIdTo.DataBind();
            if (ddlUnitIdTo.Items.Count > 0)
            {

                ddlUnitIdTo.SelectedIndex = 0;
            }

        }

        public void getSectionIdTo()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSectionIdTo.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

            ddlSectionIdTo.DataTextField = "SECTION_NAME";
            ddlSectionIdTo.DataValueField = "SECTION_ID";

            ddlSectionIdTo.DataBind();
            if (ddlSectionIdTo.Items.Count > 0)
            {

                ddlSectionIdTo.SelectedIndex = 0;
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


        public void getMonthYearForTax()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForTax();

            txtYear.Text = objLookUpDTO.Year;
            txtMonth.Text = objLookUpDTO.Month;

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
        public void clearMsg()
        {

           lblMsg.Text = string.Empty;
           lblMsgRecord.Text = string.Empty;
        }
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        public void employeeTransferProcess()
        {

            TransferDTO objTransferDTO = new TransferDTO();
            TransferBLL objTransferBLL = new TransferBLL();
                        
            objTransferDTO.BranchOfficeIdTo = ddlOfficeIdTo.SelectedValue.ToString();
            
            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objTransferDTO.UnitIdFrom = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objTransferDTO.UnitIdFrom = "";
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objTransferDTO.SectionIdFrom = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objTransferDTO.SectionIdFrom = "";
            }
            
            if (ddlUnitIdTo.SelectedValue.ToString() != " ")
            {
                objTransferDTO.UnitIdTo = ddlUnitIdTo.SelectedValue.ToString();
            }
            else
            {
                objTransferDTO.UnitIdTo = "";
            }

            if (ddlSectionIdTo.SelectedValue.ToString() != " ")
            {
                objTransferDTO.SectionIdTo = ddlSectionIdTo.SelectedValue.ToString();
            }
            else
            {
                objTransferDTO.SectionIdTo = "";
            }
            
            objTransferDTO.Year = txtYear.Text;
            objTransferDTO.Month = txtMonth.Text;
                    
            objTransferDTO.EffectiveDate = dtpEfectiveDate.Text;
            objTransferDTO.ApprovedBy = ddlApprovedById.SelectedValue.ToString();
            
            objTransferDTO.UpdateBy = strEmployeeId;
            objTransferDTO.HeadOfficeId = strHeadOfficeId;
            objTransferDTO.BranchOfficeId = strBranchOfficeId;
            
            string strMsg = objTransferBLL.employeeTransferProcess(objTransferDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }
        public void getEmployeeId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlApprovedById.DataSource = objLookUpBLL.getApprovedId();

            ddlApprovedById.DataTextField = "EMPLOYEE_NAME";
            ddlApprovedById.DataValueField = "EMPLOYEE_ID";

            ddlApprovedById.DataBind();
            if (ddlApprovedById.Items.Count > 0)
            {

                ddlApprovedById.SelectedIndex = 0;
            }
        }
           
        public void getOfficeIdTo()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlOfficeIdTo.DataSource = objLookUpBLL.getBranchOfficeId(strHeadOfficeId );

            ddlOfficeIdTo.DataTextField = "BRANCH_OFFICE_NAME";
            ddlOfficeIdTo.DataValueField = "BRANCH_OFFICE_ID";

            ddlOfficeIdTo.DataBind();
            if (ddlOfficeIdTo.Items.Count > 0)
            {

                ddlOfficeIdTo.SelectedIndex = 0;
            }

        }

        //public void getCatagoryId()
        //{

        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlCatagoryId.DataSource = objLookUpBLL.getCatagoryId();

        //    ddlCatagoryId.DataTextField = "CATAGORY_NAME";
        //    ddlCatagoryId.DataValueField = "CATAGORY_ID";

        //    ddlCatagoryId.DataBind();
        //    if (ddlCatagoryId.Items.Count > 0)
        //    {

        //        ddlCatagoryId.SelectedIndex = 0;
        //    }

        //}

       

        //public void getSectionIdFrom()
        //{

        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlSectionIdFrom.DataSource = objLookUpBLL.getSectionId();

        //    ddlSectionIdFrom.DataTextField = "SECTION_NAME";
        //    ddlSectionIdFrom.DataValueField = "SECTION_ID";

        //    ddlSectionIdFrom.DataBind();
        //    if (ddlSectionIdFrom.Items.Count > 0)
        //    {

        //        ddlSectionIdFrom.SelectedIndex = 0;
        //    }

        //}

        //public void getSectionIdTo()
        //{

        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlSectionIdTo.DataSource = objLookUpBLL.getSectionId();

        //    ddlSectionIdTo.DataTextField = "SECTION_NAME";
        //    ddlSectionIdTo.DataValueField = "SECTION_ID";

        //    ddlSectionIdTo.DataBind();
        //    if (ddlSectionIdTo.Items.Count > 0)
        //    {

        //        ddlSectionIdTo.SelectedIndex = 0;
        //    }

        //}


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

        public void searchEmployeeRecordforTransfer()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



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





            dt = objEmployeeBLL.employeeRecordforTransfer(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
              

            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
                int totalcolums = gvEmployeeList.Rows[0].Cells.Count;
                gvEmployeeList.Rows[0].Cells.Clear();
                gvEmployeeList.Rows[0].Cells.Add(new TableCell());
                gvEmployeeList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvEmployeeList.Rows[0].Cells[0].Text = "NO RECORD FOUND";
                //gvEmployeeList.Columns[2].Visible = false;
                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }

        }


        public void addEmployeeTransfer()
        {


            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "";

            string strCount = gvEmployeeList.Rows.Count.ToString();

            foreach (GridViewRow row in gvEmployeeList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {

                        string strId = (row.FindControl("lblEmployeeId") as Label).Text;

                        objSalaryDTO.EmployeeId = strId;

                        if (ddlSectionId.SelectedValue.ToString() != " ")
                        {
                            objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                        }
                        else
                        {

                            objSalaryDTO.SectionId = "";
                        }


                        if (ddlUnitId.SelectedValue.ToString() != " ")
                        {
                            objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                        }
                        else
                        {
                            objSalaryDTO.UnitId = "";

                        }


  
                     
                        objSalaryDTO.Year = txtYear.Text;
                        objSalaryDTO.Month = txtMonth.Text;

                        objSalaryDTO.UpdateBy = strEmployeeId;
                        objSalaryDTO.HeadOfficeId = strHeadOfficeId;
                        objSalaryDTO.BranchOfficeId = strBranchOfficeId;


                        strMsg = objSalaryBLL.employeeTransferAdd(objSalaryDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;
                    }
                }
            }
            if (strMsg == "ADDED SUCCESSFULLY")
            {
                MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
        }

    



        #endregion

       

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

               
                 if(ddlOfficeIdTo.Text == " ")
                {

                    string strMsg = "Please Select To Office!!!";
                    MessageBox(strMsg);
                    ddlOfficeIdTo.Focus();
                    return;
                }

                 else if (ddlUnitIdTo.Text == " ")
                 {

                     string strMsg = "Please Select Unit To!!!";
                     MessageBox(strMsg);
                     ddlUnitIdTo.Focus();
                     return;
                 }

                 else if (ddlSectionIdTo.Text == " ")
                 {

                     string strMsg = "Please Select Section To!!!";
                     MessageBox(strMsg);
                     ddlSectionIdTo.Focus();
                     return;
                 }


                else if (ddlApprovedById.Text == " ")
                {
                    string strMsg = "Please Select Approved Employee Name!!!";
                    MessageBox(strMsg);
                    ddlApprovedById.Focus();
                    return;

                }

               

                else if (dtpEfectiveDate.Text == " ")
                {
                    string strMsg = "Please Enter Effective Date!!!";
                    MessageBox(strMsg);
                    dtpEfectiveDate.Focus();
                    return;

                }

                else
                {

                    employeeTransferProcess();

                }
            }

            catch (Exception ex)
            {

                throw new Exception("Error : " +ex.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlUnitId.Text == " ")
                {

                    string strMsg = "Please Select Unit Name!!!";
                    MessageBox(strMsg);
                    ddlUnitId.Focus();
                    return;
                }
                else if (ddlUnitId.Text == " ")
                {

                    string strMsg = "Please Select Unit Name!!!";
                    MessageBox(strMsg);
                    ddlUnitId.Focus();
                    return;
                }

                else if (ddlSectionId.Text == " ")
                {

                    string strMsg = "Please Select Section Name!!!";
                    MessageBox(strMsg);
                    ddlSectionId.Focus();
                    return;
                }


                else if (ddlSectionId.Text == " ")
                {

                    string strMsg = "Please Select Section Name!!!";
                    MessageBox(strMsg);
                    ddlSectionId.Focus();
                    return;
                }
                else
                {

                    searchEmployeeRecordforTransfer();

                }

            }

            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else
                {

                    addEmployeeTransfer();

                }

            }

            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void ddlOfficeIdTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            getUnitIdToByOfficeId();
        }

       

   
    }
}