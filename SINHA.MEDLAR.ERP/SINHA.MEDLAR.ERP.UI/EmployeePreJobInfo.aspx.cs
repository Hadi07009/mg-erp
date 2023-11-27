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
    public partial class EmployeePreJobInfo : System.Web.UI.Page
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
        string strID = "";
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;
            }

            if (!IsPostBack)
            {


                //load DropDown List
                loadSesscion();
               

                //getDepartmentId();
                getSectionId();
                //getDesignationId();
                getUnitId();
                getOfficeName();
                clearMessage();
                btnSearch.Focus();

            }
            if (IsPostBack)
            {

                loadSesscion();
            }
        }


        #region "Function"
        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;

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

        public void searchEmployeePreJobInfo(string strEmployeeId, string strJoiningDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();


            objEmployeeDTO = objEmployeeBLL.searchEmployeePreJobInfo(strEmployeeId, strJoiningDate, strHeadOfficeId, strBranchOfficeId);

            if (objEmployeeDTO.OrganizationName == "N/A" || objEmployeeDTO.OrganizationName == null)
            {

                txtOrganizationName.Text = "";
            }
            else
            {

                txtOrganizationName.Text = objEmployeeDTO.OrganizationName;
            }
             
             dtpPreJoiningDate.Text = objEmployeeDTO.JoiningDate;
             if (objEmployeeDTO.SectionName == "N/A" || objEmployeeDTO.SectionName == null)
             {

                 txtSectionName.Text = "";
             }
             else
             {

                 txtSectionName.Text = objEmployeeDTO.SectionName;
             }


             if (objEmployeeDTO.DesignationName == "N/A" || objEmployeeDTO.DesignationName == null)
             {

                 txtDesignationName.Text = "";
             }
             else
             {

                 txtDesignationName.Text = objEmployeeDTO.DesignationName;
             }


             if (objEmployeeDTO.PreSalary == "0" || objEmployeeDTO.PreSalary == null)
             {

                 txtPreviousSalary.Text = "";
             }
             else
             {

                 txtPreviousSalary.Text = objEmployeeDTO.PreSalary;
             }


             if (objEmployeeDTO.YearOfExperience == "0" || objEmployeeDTO.YearOfExperience == null)
             {

                 txtYearOfExperience.Text = "";
             }
             else
             {

                 txtYearOfExperience.Text = objEmployeeDTO.YearOfExperience;
             }

             if (objEmployeeDTO.WorkingDuration == "0" || objEmployeeDTO.WorkingDuration == null)
             {

                 txtWorkingDuration.Text = "";
             }
             else
             {

                 txtWorkingDuration.Text = objEmployeeDTO.WorkingDuration;
             }
             if (objEmployeeDTO.LeaveDate == null)
             {

                 dtpLeaveDate.Text = "";
             }
             else
             {
                 dtpLeaveDate.Text = objEmployeeDTO.LeaveDate;

             }
             
             if (objEmployeeDTO.LeavingReson == "N/A"  || objEmployeeDTO.WorkingDuration == null)
             {

                 txtLeavingReson.Text = "";
             }
             else
             {

                 txtLeavingReson.Text = objEmployeeDTO.LeavingReson;
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

        //public void getDepartmentId()
        //{

        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlDepartmentId.DataSource = objLookUpBLL.getSectionId();

        //    ddlDepartmentId.DataTextField = "SECTION_NAME";
        //    ddlDepartmentId.DataValueField = "SECTION_ID";

        //    ddlDepartmentId.DataBind();
        //    if (ddlDepartmentId.Items.Count > 0)
        //    {

        //        ddlDepartmentId.SelectedIndex = 0;
        //    }



        //}

        //public void getDesignationId()
        //{

        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlDesignationId.DataSource = objLookUpBLL.getDesignationId();

        //    ddlDesignationId.DataTextField = "DESIGNATION_NAME";
        //    ddlDesignationId.DataValueField = "DESIGNATION_ID";

        //    ddlDesignationId.DataBind();
        //    if (ddlDesignationId.Items.Count > 0)
        //    {

        //        ddlDesignationId.SelectedIndex = 0;
        //    }

        //}

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

        //public void loadYear()
        //{

        //    for (int i = 2000; i <= 2080; i++)
        //    {
        //        ddlLeaveYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        //    }
        //}


        public void saveEmployeePreJobInfo()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
            objEmployeeDTO.OrganizationName = txtOrganizationName.Text;
            objEmployeeDTO.JoiningDate = dtpPreJoiningDate.Text;

            objEmployeeDTO.DesignationName = txtDesignationName.Text;
            objEmployeeDTO.SectionName = txtSectionName.Text;


            objEmployeeDTO.JoiningDate = dtpPreJoiningDate.Text;
            objEmployeeDTO.PreSalary = txtPreviousSalary.Text;
            objEmployeeDTO.WorkingDuration = txtWorkingDuration.Text;
            objEmployeeDTO.YearOfExperience = txtYearOfExperience.Text;
            objEmployeeDTO.LeaveDate = dtpLeaveDate.Text;

            objEmployeeDTO.LeavingReson = txtLeavingReson.Text;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.UpdateBy = strEmployeeId;

            string strMsg = objEmployeeBLL.saveEmployeePreJobInfo(objEmployeeDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;


        }

        public void searchEmployeeRecord()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            string strActiveYn = "";

            objEmployeeDTO.EmployeeActiveYn = "Y";

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            

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





            dt = objEmployeeBLL.searchEmployeeRecordForPreJobInfo(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;

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

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }

        }
        public void searchEmployeeEntryRecord()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            string strActiveYn = "";

            objEmployeeDTO.EmployeeActiveYn = "Y";

            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;



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





            dt = objEmployeeBLL.searchEmployeeEntryRecord(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

                // getFirstIndex();
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
            }

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
            l = gvEmployeeList.SelectedRow.RowIndex;
            if (l != 0)
            {

                int strId = gvEmployeeList.SelectedRow.RowIndex + 1;
                int strRowCount = strId;
                int intCount = gvEmployeeList.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                    return;

                }
                else
                {
                    gvEmployeeList.SelectedIndex += 1;
                    result = gvEmployeeList.SelectedRow.RowIndex + k;

                }

            }
            if (l == 0)
            {

                int intCount = gvEmployeeList.Rows.Count;
                int intCountRow = gvEmployeeList.Rows.Count;
                int p = intCountRow - 1;
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
                        gvEmployeeList.SelectedIndex = 0;
                        result = gvEmployeeList.SelectedRow.RowIndex + k;
                        txtSLNew.Text = "1";
                    }
                    else
                    {
                        gvEmployeeList.SelectedIndex += 1;
                        result = gvEmployeeList.SelectedRow.RowIndex + k;
                    }

                }

            }


            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignation.Text = strDesignation;
        }

        public void goToPreviousRecord()
        {
            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            //gvIncrementList.SelectedIndex = 1;


            int l;
            l = gvEmployeeList.SelectedRow.RowIndex;
            if (l != 0)
            {
                int strId = gvEmployeeList.SelectedRow.RowIndex - 1;
                int strRowCount = strId;
                int intCount = gvEmployeeList.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    return;

                }
                else
                {
                    gvEmployeeList.SelectedIndex -= 1;
                    result = gvEmployeeList.SelectedRow.RowIndex - k;
                }
            }
            if (l == 0)
            {

                int intCountRow = gvEmployeeList.Rows.Count;
                int p = intCountRow;
                if (intCountRow == p)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    return;

                }

                else
                {

                    l = 1;
                    gvEmployeeList.SelectedIndex = l;
                    result = gvEmployeeList.SelectedRow.RowIndex - k;

                }

            }

            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;

            //int strRowCount = strRowId - 1;
            //int intCount = gvIncrementList.Rows.Count;
            //if (intCount == strRowCount)
            //{
            //    string strMsg = "Entry Completed";
            //    MessageBox(strMsg);
            //    return;

            //}
            //else
            //{




            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignation.Text = strDesignation;
            // }

        }

        public void clearTextBox()
        {
            txtLeavingReson.Text = string.Empty;
            txtOrganizationName.Text = string.Empty;
            txtPreviousSalary.Text = string.Empty;
            txtWorkingDuration.Text = string.Empty;
            txtYearOfExperience.Text = string.Empty;
            txtLeavingReson.Text = string.Empty;
            dtpPreJoiningDate.Text = string.Empty;
            txtDesignationName.Text = string.Empty;
            dtpLeaveDate.Text = string.Empty;
            txtSectionName.Text = string.Empty;

            getSectionId();
         


        }

        public void clearYellowTextBox()
        {
            txtCardNo.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtSL.Text = string.Empty;
            txtSLNew.Text = string.Empty;

        }

        #endregion
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearTextBox();

            }
            catch (Exception ex)
            {
                throw new Exception("Error : " +ex.Message);

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
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

                else if (txtEmployeeId.Text == string.Empty)
                {
                    string strMsg = "Please Click in the Gridview";
                    //txtEmployeeId.Focus();
                    MessageBox(strMsg);
                    return;

                }

                else if (txtOrganizationName.Text == string.Empty)
                {
                    string strMsg = "Please Enter Organization Name!!!";
                    MessageBox(strMsg);
                    txtOrganizationName.Focus();
                    return; 

                }
                else if (dtpPreJoiningDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter Previous Joining Date!!!";
                    MessageBox(strMsg);
                    dtpPreJoiningDate.Focus();
                    return; 

                }

                else if (txtSectionName.Text == string.Empty)
                {
                    string strMsg = "Please Enter Previous Department!!!";
                    MessageBox(strMsg);
                    txtSectionName.Focus();
                    return; 

                }

                else if (txtDesignationName.Text == string.Empty)
                {
                    string strMsg = "Please Enter Previous Designation!!!";
                    MessageBox(strMsg);
                    txtDesignationName.Focus();
                    return;

                }



                else
                {

                    saveEmployeePreJobInfo();
                    searchEmployeeEntryRecord();
                    //clearTextBox();
                    //goToNextRecord();
                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error : " +ex.Message);
            }
        }


        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
            searchEmployeeRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;



            //string strMsg = "Row Index: " + strRowId + "\\SL: " + strSLNo + "\\CARD NO: " + strCardNo + "\\nEmployee ID : " + strEmployeeId + "\\nName: " + strEmployeeName +
            //    "\\nDesignation: " + strDesignation;

            // MessageBox(strMsg);

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignation.Text = strDesignation;

            //searchEmployeePreJobInfo();

            txtOrganizationName.Focus();

        }




        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }


        protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);
            }
        }

        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvUnit, "Select$" + e.Row.RowIndex);
        //        //e.Row.Attributes["style"] = "cursor:pointer";

        //        try
        //        {
        //            switch (e.Row.RowType)
        //            {
        //                case DataControlRowType.Header:
        //                    //...
        //                    break;
        //                case DataControlRowType.DataRow:
        //                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#93A3B0'; this.style.color='White'; this.style.cursor='pointer'");
        //                    if (e.Row.RowState == DataControlRowState.Alternate)
        //                    {
        //                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.AlternatingRowStyle.BackColor.ToKnownColor()));
        //                    }
        //                    else
        //                    {
        //                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.RowStyle.BackColor.ToKnownColor()));
        //                    }
        //                    e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gvUnit, "Select$" + e.Row.RowIndex.ToString()));
        //                    break;
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            throw new Exception("Error : " + ex.Message);
        //        }
        //    }
        //}




        protected void gvEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadEmployeeRecord();


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
            }
            if (dt != null)
            {
                DataView dataView = new DataView(dt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                gvEmployeeList.DataSource = dataView;
                gvEmployeeList.DataBind();
            }
        }

        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }

        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            switch (GridViewSortDirection)
            {
                case "ASC":
                    GridViewSortDirection = "DESC";
                    break;

                case "DESC":
                    GridViewSortDirection = "ASC";
                    break;
            }

            return GridViewSortDirection;
        }


        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

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
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[2].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[3].Text;
            string strDesignation = GridView1.SelectedRow.Cells[4].Text;
            string strJoiningDate = GridView1.SelectedRow.Cells[6].Text;


            //string strMsg = "Row Index: " + strRowId + "\\SL: " + strSLNo + "\\CARD NO: " + strCardNo + "\\nEmployee ID : " + strEmployeeId + "\\nName: " + strEmployeeName +
            //    "\\nDesignation: " + strDesignation;

            // MessageBox(strMsg);

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignation.Text = strDesignation;


            txtOrganizationName.Focus();


            searchEmployeePreJobInfo(strEmployeeId, strJoiningDate, strHeadOfficeId, strBranchOfficeId);

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

        #endregion

        protected void btnNext_Click(object sender, EventArgs e)
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

                   
                        clearTextBox();
                        goToNextRecord();
                        searchEmployeeEntryRecord();
                        clearMessage();
                        //searchEmployeePreJobInfo();

                    

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

                if (gvEmployeeList.Rows.Count == 0)
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
                        searchEmployeeEntryRecord();
                        clearMessage();
                        //searchEmployeePreJobInfo();
                    

                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {


                searchEmployeeRecord();
               
                clearYellowTextBox();
                gvEmployeeList.SelectedIndex = 0;
                goToNextRecord();
                searchEmployeeEntryRecord();

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


                searchEmployeeEntryRecord();


            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }
    }
}