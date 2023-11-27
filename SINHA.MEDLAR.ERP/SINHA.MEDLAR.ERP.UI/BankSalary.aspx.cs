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
namespace SINHA.MEDLAR.ERP.UI
{
    public partial class BankSalary : System.Web.UI.Page
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
                getOfficeName();
                getUnitId();
                getSectionId();
                //getIncrementProcessTypeId();
                clearMsg();
                getMonthYearForSalary();
                lblMsg.Text = string.Empty;
                btnSearch.Focus();
            }
            if (IsPostBack)
            {

                loadSesscion();
            }
        }
        #region "FUNCTION"
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

        public void getFirstIndex()
        {
            var rowCount = gvIncrementList.Rows.Count;


            int rowIndex = 1;
            if (gvIncrementList.SelectedIndex == -1)
            {


                rowIndex = 0;
                GridViewRow row = gvIncrementList.Rows[rowIndex];
                //int strRowId = gvIncrementList.SelectedRow.RowIndex;




                string strEmployeeName = row.Cells[3].Text;
                string strEmployeeId = row.Cells[1].Text;
                string strDesignation = row.Cells[4].Text;
                string strCardNo = row.Cells[2].Text;
                string strGrossSalary = row.Cells[6].Text;


                txtName.Text = strEmployeeName;
                txtEmployeeId.Text = strEmployeeId;
                txtDesignation.Text = strDesignation;
                txtCardNo.Text = strCardNo;
                txtCurrentSalary.Text = strGrossSalary;
                txtSL.Text = "1";

                rowIndex = 1;


            }



        }


        public void getMonthYearForSalary()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtYear.Text = objLookUpDTO.Year;
            txtMonth.Text = objLookUpDTO.Month;
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


        public void getFirstSalary()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO = objSalaryBLL.getFirstSalary(txtYear.Text, txtMonth.Text, txtEmployeeId.Text, strHeadOfficeId, strBranchOfficeId);

            txtFirstSalary.Text = objSalaryDTO.FirstSalary;


        }




        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

     

        public void clearYellowTextBox()
        {
            txtCardNo.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            txtName.Text = string.Empty;
            txtSL.Text = string.Empty;
            txtFirstSalary.Text = string.Empty;
            txtCurrentSalary.Text = string.Empty;
            
        }



        public void goToNextRecord()
        {

            if (txtSL.Text == string.Empty)
            {
                txtSL.Text = "1";
            }

            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            //gvIncrementList.SelectedIndex = 1;


            int l;
            l = gvIncrementList.SelectedRow.RowIndex;
            if (l != 0)
            {

                int strId = gvIncrementList.SelectedRow.RowIndex + 1;
                int strRowCount = strId;
                int intCount = gvIncrementList.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                    return;

                }
                else
                {
                    gvIncrementList.SelectedIndex += 1;
                    result = gvIncrementList.SelectedRow.RowIndex + k;

                }

            }
            if (l == 0)
            {

                int intCount = gvIncrementList.Rows.Count;
                int intCountRow = gvIncrementList.Rows.Count;
                if (intCountRow == 1)
                {
                    intCountRow = 2;

                }

                int p = intCountRow - 1;
                //int p = intCountRow;
                if (l == p)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                    return;

                }

                else
                {
                    l = 1;

                    if (txtSL.Text == "1" && txtSLNew.Text == "")
                    {
                        gvIncrementList.SelectedIndex = 0;
                        result = gvIncrementList.SelectedRow.RowIndex + k;
                        txtSLNew.Text = "1";

                    }
                    else
                    {

                        int intC = gvIncrementList.Rows.Count;
                        int intCo = gvIncrementList.Rows.Count;
                        int ll = 0;

                        int pp = intCo - 1;
                        //int p = intCountRow;
                        if (ll == pp)
                        {
                            string strMsg = "There is no Data for the Next Record!!!";
                            MessageBox(strMsg);

                            return;

                        }
                        else
                        {

                            gvIncrementList.SelectedIndex += 1;
                            result = gvIncrementList.SelectedRow.RowIndex + k;

                        }

                    }


                }

            }


            int strRowId = gvIncrementList.SelectedRow.RowIndex + 1;
            string strSLNo = gvIncrementList.SelectedRow.Cells[0].Text;
            if (strSLNo == "NO RECORD FOUND")
            {
                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                return;
            }
            else
            {


                string strCardNo = gvIncrementList.SelectedRow.Cells[1].Text;
                string strEmployeeName = gvIncrementList.SelectedRow.Cells[2].Text;
                string strDesignation = gvIncrementList.SelectedRow.Cells[3].Text;
                string strGrossSalary = gvIncrementList.SelectedRow.Cells[4].Text;
                string strBankSalary = gvIncrementList.SelectedRow.Cells[5].Text;
                string strEmployeeId = gvIncrementList.SelectedRow.Cells[6].Text;

                txtName.Text = strEmployeeName;
                txtEmployeeId.Text = strEmployeeId;
                txtDesignation.Text = strDesignation;
                txtCardNo.Text = strCardNo;
                txtCurrentSalary.Text = strGrossSalary;
                txtSL.Text = Convert.ToString(strRowId);
                txtBankSalary.Text = strBankSalary;
                txtFirstSalary.Focus();

            }
           
        }

        public void goToPreviousRecord()
        {
            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            //gvIncrementList.SelectedIndex = 1;


            int l;
            l = gvIncrementList.SelectedRow.RowIndex;
            if (l != 0)
            {
                int strId = gvIncrementList.SelectedRow.RowIndex - 1;
                int strRowCount = strId;
                int intCount = gvIncrementList.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    txtFirstSalary.Focus();
                    return;

                }
                else
                {
                    gvIncrementList.SelectedIndex -= 1;
                    result = gvIncrementList.SelectedRow.RowIndex - k;
                }
            }
            if (l == 0)
            {

                int intCountRow = gvIncrementList.Rows.Count;
                int p = intCountRow;
                if (intCountRow == p)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    txtFirstSalary.Focus();
                    return;

                }

                else
                {

                    l = 1;
                    gvIncrementList.SelectedIndex = l;
                    result = gvIncrementList.SelectedRow.RowIndex - k;

                }

            }

            int strRowId = gvIncrementList.SelectedRow.RowIndex + 1;





            string strCardNo = gvIncrementList.SelectedRow.Cells[1].Text;
            string strEmployeeName = gvIncrementList.SelectedRow.Cells[2].Text;
            string strDesignation = gvIncrementList.SelectedRow.Cells[3].Text;
            string strGrossSalary = gvIncrementList.SelectedRow.Cells[4].Text;
            string strBankSalary = gvIncrementList.SelectedRow.Cells[5].Text;
            string strEmployeeId = gvIncrementList.SelectedRow.Cells[6].Text;

            txtName.Text = strEmployeeName;
            txtEmployeeId.Text = strEmployeeId;
            txtDesignation.Text = strDesignation;
            txtCardNo.Text = strCardNo;
            txtCurrentSalary.Text = strGrossSalary;
            txtSL.Text = Convert.ToString(strRowId);
            txtBankSalary.Text = strBankSalary;


            txtFirstSalary.Focus();
           
        }
        public void clearTextBox()
        {

          
            txtFirstSalary.Text = string.Empty;

        }

        public void searchEmployeeBankSalary()
        {

            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();
            DataTable dt = new DataTable();


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objIncrementDTO.SectionId = "";
            }



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objIncrementDTO.UnitId = "";

            }
            objIncrementDTO.Year = txtYear.Text;
            objIncrementDTO.BranchOfficeId = strBranchOfficeId;
            objIncrementDTO.HeadOfficeId = strHeadOfficeId;
            objIncrementDTO.EmployeeId = txtEmpId.Text;
            objIncrementDTO.CardNo = txtEmpCardNo.Text;

            dt = objIncrementBLL.searchEmployeeBankSalary(objIncrementDTO);


            if (dt.Rows.Count > 0)
            {
                gvIncrementList.DataSource = dt;
                gvIncrementList.DataBind();
                string strMsg = "TOTAL " + gvIncrementList.Rows.Count + " RECORD FOUND";
                lblMsg.Text = strMsg;
                //gvIncrementList.Columns[1].Visible = false;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvIncrementList.DataSource = dt;
                gvIncrementList.DataBind();
                int totalcolums = gvIncrementList.Rows[0].Cells.Count;
                gvIncrementList.Rows[0].Cells.Clear();
                gvIncrementList.Rows[0].Cells.Add(new TableCell());
                gvIncrementList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvIncrementList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                //gvIncrementList.Columns[1].Visible = false;

            }



        }
        public void searchBankSalaryEntry()
        {

            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();
            DataTable dt = new DataTable();


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objIncrementDTO.SectionId = "";
            }



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objIncrementDTO.UnitId = "";

            }
            objIncrementDTO.Year = txtYear.Text;
            objIncrementDTO.Month = txtMonth.Text;
            objIncrementDTO.EmployeeId = txtEmployeeId.Text;


            objIncrementDTO.BranchOfficeId = strBranchOfficeId;
            objIncrementDTO.HeadOfficeId = strHeadOfficeId;
            objIncrementDTO.EmployeeId = txtEmpId.Text;
            objIncrementDTO.CardNo = txtEmpCardNo.Text;

            dt = objIncrementBLL.searchBankSalaryEntry(objIncrementDTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                string strMsg = "TOTAL " + GridView1.Rows.Count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
                //GridView1.Columns[1].Visible = false;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int totalcolums = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridView1.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
               // GridView1.Columns[1].Visible = false;

            }



        }
        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
        }

        public void saveBankSalary()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO.FirstSalary = txtFirstSalary.Text;
            objSalaryDTO.EmployeeId = txtEmployeeId.Text;
            objSalaryDTO.Year = txtYear.Text;
            objSalaryDTO.Month = txtMonth.Text;

            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objSalaryBLL.saveBankSalary(objSalaryDTO);
            lblMsg.Text = strMsg;
            if (strMsg == "FIRST SALARY IS GREATER THAN GROSS SALARY")
            {
                MessageBox(strMsg);
                return;
            }
           



        }


        public void procesFirstSalaryForBank()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

           
            objSalaryDTO.Year = txtYear.Text;
            objSalaryDTO.Month = txtMonth.Text;

            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objSalaryBLL.procesFirstSalaryForBank(objSalaryDTO);
            lblMsg.Text = strMsg;




        }



        #endregion
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvIncrementList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else if (txtEmployeeId.Text == string.Empty)
                {

                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;

                }
                else if (txtFirstSalary.Text == string.Empty)
                {

                    goToNextRecord();
                    getFirstSalary();

                }
                else
                {
                    saveBankSalary();
                    clearTextBox();
                    goToNextRecord();
                    getFirstSalary();
                    searchBankSalaryEntry();
                   
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error : "+ex.Message);

            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
            
            if (gvIncrementList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else
                {

                        clearTextBox();
                        goToNextRecord();
                        clearMessage();
                        getFirstSalary();

                    

                }
            }
        

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {

                if (gvIncrementList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else
                {

                    clearTextBox();
                    goToPreviousRecord();
                    clearMessage();
                    getFirstSalary();



                }
            }


            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                searchBankSalaryEntry();

            }

            catch (Exception ex)
            {
                throw new Exception("Error : " +ex.Message);

            }
        }

        protected void txtCardNo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                searchEmployeeBankSalary();
                clearYellowTextBox();
                gvIncrementList.SelectedIndex = 0;
                goToNextRecord();
                getFirstSalary();
                searchBankSalaryEntry();
            }

            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }

           
        }


        #region "Grid View Functionality"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvIncrementList.PageIndex = e.NewPageIndex;
           
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvIncrementList.SelectedRow.RowIndex + 1;
            string strCardNo = gvIncrementList.SelectedRow.Cells[1].Text;
            string strEmployeeName = gvIncrementList.SelectedRow.Cells[2].Text;
            string strDesignation = gvIncrementList.SelectedRow.Cells[3].Text;
            
            string strGrossSalary = gvIncrementList.SelectedRow.Cells[4].Text;
            string strBankSalary = gvIncrementList.SelectedRow.Cells[5].Text;
            string strEmployeeId = gvIncrementList.SelectedRow.Cells[6].Text;

            txtName.Text = strEmployeeName;
            txtEmployeeId.Text = strEmployeeId;
            txtDesignation.Text = strDesignation;
            txtCardNo.Text = strCardNo;
            txtCurrentSalary.Text = strGrossSalary;
            txtSL.Text = Convert.ToString(strRowId);
            txtBankSalary.Text = strBankSalary;

            getFirstSalary();

            txtFirstSalary.Focus();
        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvIncrementList.EditIndex = e.NewEditIndex;
            searchEmployeeBankSalary();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvIncrementList, "Select$" + e.Row.RowIndex);
            }
        }
        protected void gvIncrementList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //gvIncrementList.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";
        }


        #endregion


        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //searchIncrementHoldInfo();
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;
            string strGrossSalary = GridView1.SelectedRow.Cells[4].Text;
            string strBankSalary = GridView1.SelectedRow.Cells[5].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[6].Text;

            txtName.Text = strEmployeeName;
            txtEmployeeId.Text = strEmployeeId;
            txtDesignation.Text = strDesignation;
            txtCardNo.Text = strCardNo;
            txtCurrentSalary.Text = strGrossSalary;
            txtSL.Text = Convert.ToString(strRowId);
            txtBankSalary.Text = strBankSalary;

   

            getFirstSalary();
            txtFirstSalary.Focus();


        }

        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }







        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //GridView1.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";
        }

        #endregion

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {


                procesFirstSalaryForBank();


            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }

        }

    }
}