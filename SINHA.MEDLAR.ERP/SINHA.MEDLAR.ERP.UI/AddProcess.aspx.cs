using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;


using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AddProcess : System.Web.UI.Page
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
                loadTopRecord();
                getOfficeName();
                getSectionProcessId();
                getCategoryId();
                getMachineId();
                getMainProcessId();
                lblMsg.Text = string.Empty;
            }

            if (IsPostBack)
            {

                loadSesscion();
            }

            txtProcessName.Attributes.Add("onkeypress", "return controlEnter('" + txtProcessTime.ClientID + "', event)");
            txtProcessTime.Attributes.Add("onkeypress", "return controlEnter('" + txtStitchLength.ClientID + "', event)");
            txtStitchLength.Attributes.Add("onkeypress", "return controlEnter('" + txtHigestCapacity.ClientID + "', event)");

        }

     

        #region "Function"

        public void getMachineId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlMachineId.DataSource = objLookUpBLL.getMachineId(strHeadOfficeId, strBranchOfficeId);

            ddlMachineId.DataTextField = "MACHINE_NAME";
            ddlMachineId.DataValueField = "MACHINE_ID";

            ddlMachineId.DataBind();
            if (ddlMachineId.Items.Count > 0)
            {

                ddlMachineId.SelectedIndex = 0;
            }


        }


        public void getMainProcessId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlProcessId.DataSource = objLookUpBLL.getMainProcessId(strHeadOfficeId, strBranchOfficeId);

            ddlProcessId.DataTextField = "MAIN_PROCESS_NAME";
            ddlProcessId.DataValueField = "MAIN_PROCESS_ID";

            ddlProcessId.DataBind();
            if (ddlProcessId.Items.Count > 0)
            {

                ddlProcessId.SelectedIndex = 0;
            }


        }

        public void getSectionProcessId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();

            string strProcessId = "";
            if (ddlProcessId.SelectedValue.ToString() != " ")
            {
                strProcessId = ddlProcessId.SelectedValue.ToString();
            }
            else
            {
                strProcessId = "";

            }

            ddlSectionProcessId.DataSource = objLookUpBLL.getSectionProcessId(strProcessId, strHeadOfficeId, strBranchOfficeId);

            ddlSectionProcessId.DataTextField = "SECTION_NAME";
            ddlSectionProcessId.DataValueField = "SECTION_ID";

            ddlSectionProcessId.DataBind();
            if (ddlSectionProcessId.Items.Count > 0)
            {

                ddlSectionProcessId.SelectedIndex = 0;
            }

        }

        public void getCategoryId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            string strSectionId = "";
            if (ddlSectionProcessId.SelectedValue.ToString() != " ")
            {
                strSectionId = ddlSectionProcessId.SelectedValue.ToString();
            }
            else
            {
                strSectionId = "";

            }


            ddlCategoryId.DataSource = objLookUpBLL.getCategoryId(strSectionId, strHeadOfficeId, strBranchOfficeId);

            ddlCategoryId.DataTextField = "CATEGORY_NAME";
            ddlCategoryId.DataValueField = "CATEGORY_ID";

            ddlCategoryId.DataBind();
            if (ddlCategoryId.Items.Count > 0)
            {

                ddlCategoryId.SelectedIndex = 0;
            }

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

        public void loadTopRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadTopRecord();


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
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
                lblMsgRecord.Text = strMsg;

            }


        }

        public void clear()
        {

            txtTopId.Text = "";
            txtProcessName.Text = "";
            txtProcessTime.Text = "";
            txtStitchLength.Text = "";
            txtHigestCapacity.Text = "";
            txtTargetValue.Text = "";
            txtProcessCode.Text = "";
        }
        public void saveTopInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.TopId = txtTopId.Text;
            objLookUpDTO.TopName = txtProcessName.Text;




            if (ddlCategoryId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.CatagoryId = ddlCategoryId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.CatagoryId = "";

            }

            if (ddlSectionProcessId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.SectionId = ddlSectionProcessId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.SectionId = "";

            }

            if (ddlProcessId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.ProcessId = ddlProcessId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.ProcessId = "";

            }

            if (ddlMachineId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.MachineId = ddlMachineId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.MachineId = "";

            }

            objLookUpDTO.ProcessCode = txtProcessCode.Text;
            objLookUpDTO.StichLength = txtStitchLength.Text;
            objLookUpDTO.HigestCapactiy = txtHigestCapacity.Text;


            objLookUpDTO.ProcessTime = txtProcessTime.Text;
            objLookUpDTO.TargetValue = txtTargetValue.Text;

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;





            string strMsg = objLookUpBLL.saveTopInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }


        public void deleteTopInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.TopId = txtTopId.Text;


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;





            string strMsg = objLookUpBLL.deleteTopInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }

        public void searchProcessEntry()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO = objLookUpBLL.searchProcessEntry(txtTopId.Text,  strHeadOfficeId, strBranchOfficeId);

            if (objLookUpDTO.TopId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlProcessId.SelectedValue = objLookUpDTO.TopId;
            }

            if (objLookUpDTO.SectionId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlSectionProcessId.SelectedValue = objLookUpDTO.SectionId;
            }


            if (objLookUpDTO.CatagoryId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlCategoryId.SelectedValue = objLookUpDTO.CatagoryId;
            }


            txtProcessName.Text = objLookUpDTO.ProcessName;
            txtProcessTime.Text = objLookUpDTO.ProcessTime;
            txtTargetValue.Text = objLookUpDTO.TargetValue;
            
            txtHigestCapacity.Text = objLookUpDTO.HigestCapactiy;
            txtStitchLength.Text = objLookUpDTO.StichLength;
            txtProcessCode.Text = objLookUpDTO.ProcessCode;

        }


      



        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
        public void clearTextBox()
        {

          

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
        //    l = gvEmployeeList.SelectedRow.RowIndex;
        //    if (l != 0)
        //    {

        //        int strId = gvEmployeeList.SelectedRow.RowIndex + 1;
        //        int strRowCount = strId;
        //        int intCount = gvEmployeeList.Rows.Count;
        //        if (intCount == strRowCount)
        //        {
        //            string strMsg = "There is no Data for the Next Record!!!";
        //            MessageBox(strMsg);
        //            return;

        //        }
        //        else
        //        {
        //            gvEmployeeList.SelectedIndex += 1;
        //            result = gvEmployeeList.SelectedRow.RowIndex + k;

        //        }

        //    }
        //    if (l == 0)
        //    {

        //        int intCount = gvEmployeeList.Rows.Count;
        //        int intCountRow = gvEmployeeList.Rows.Count;
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
        //                gvEmployeeList.SelectedIndex = 0;
        //                result = gvEmployeeList.SelectedRow.RowIndex + k;
        //                txtSLNew.Text = "1";

        //            }
        //            else
        //            {

        //                int intC = gvEmployeeList.Rows.Count;
        //                int intCo = gvEmployeeList.Rows.Count;
        //                int ll = 0;

        //                int pp = intCo - 1;
        //                //int p = intCountRow;
        //                if (ll == pp)
        //                {
        //                    string strMsg = "There is no Data for the Next Record!!!";
        //                    MessageBox(strMsg);

        //                    return;

        //                }
        //                else
        //                {

        //                    gvEmployeeList.SelectedIndex += 1;
        //                    result = gvEmployeeList.SelectedRow.RowIndex + k;

        //                }

        //            }


        //        }

        //    }


        //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
        //    string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
        //    if (strSLNo == "NO RECORD FOUND")
        //    {
        //        string strMsg = "NO RECORD FOUND!!!";
        //        MessageBox(strMsg);
        //        return;
        //    }
        //    else
        //    {

        //        string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
        //        string strEmployeeId = gvEmployeeList.SelectedRow.Cells[5].Text;
        //        string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
        //        string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


        //        txtSL.Text = Convert.ToString(strRowId);
        //        txtCardNo.Text = strCardNo;
        //        txtEmployeeId.Text = strEmployeeId;
        //        txtEmployeeName.Text = strEmployeeName;
        //        txtDesignation.Text = strDesignation;

               
        //    }
        //}

        //public void goToPreviousRecord()
        //{
        //    int i = 1, j, k, result;
        //    j = Convert.ToInt32(txtSL.Text);
        //    k = j;
        //    //gvIncrementList.SelectedIndex = 1;


        //    int l;
        //    l = gvEmployeeList.SelectedRow.RowIndex;
        //    if (l != 0)
        //    {
        //        int strId = gvEmployeeList.SelectedRow.RowIndex - 1;
        //        int strRowCount = strId;
        //        int intCount = gvEmployeeList.Rows.Count;
        //        if (intCount == strRowCount)
        //        {
        //            string strMsg = "There is no Data for the Previous Record!!!";
        //            MessageBox(strMsg);
                   
        //            return;

        //        }
        //        else
        //        {
        //            gvEmployeeList.SelectedIndex -= 1;
        //            result = gvEmployeeList.SelectedRow.RowIndex - k;
        //        }
        //    }
        //    if (l == 0)
        //    {

        //        int intCountRow = gvEmployeeList.Rows.Count;
        //        int p = intCountRow;
        //        if (intCountRow == p)
        //        {
        //            string strMsg = "There is no Data for the Previous Record!!!";
        //            MessageBox(strMsg);
                   
        //            return;

        //        }

        //        else
        //        {

        //            l = 1;
        //            gvEmployeeList.SelectedIndex = l;
        //            result = gvEmployeeList.SelectedRow.RowIndex - k;

        //        }

        //    }

        //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;

        //    //int strRowCount = strRowId - 1;
        //    //int intCount = gvIncrementList.Rows.Count;
        //    //if (intCount == strRowCount)
        //    //{
        //    //    string strMsg = "Entry Completed";
        //    //    MessageBox(strMsg);
        //    //    return;

        //    //}
        //    //else
        //    //{




        //    string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
        //    string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
        //    string strEmployeeId = gvEmployeeList.SelectedRow.Cells[5].Text;
        //    string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
        //    string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


        //    txtSL.Text = Convert.ToString(strRowId);
        //    txtCardNo.Text = strCardNo;
        //    txtEmployeeId.Text = strEmployeeId;
        //    txtEmployeeName.Text = strEmployeeName;
        //    txtDesignation.Text = strDesignation;


        //}
        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            getCategoryId();
            getMainProcessId();
            getSectionProcessId();
            getMachineId();

           // clearYellowTextBox();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (ddlProcessId.Text == " ")
            {
                string strMsg = "Please Select Item Name!!!";
                ddlProcessId.Focus();
                MessageBox(strMsg);
                return;


            }

            else if (txtProcessName.Text == string.Empty)
            {
                string strMsg = "Please Enter Process Name!!!";
                txtProcessName.Focus();
                MessageBox(strMsg);
                return;


            }



            else
            {
                saveTopInfo();
                loadTopRecord();
                clear();


            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtTopId.Text == string.Empty)
            {
                string strMsg = "Please Enter Process ID!!!";
                txtTopId.Focus();
                MessageBox(strMsg);
                return;


            }
            else
            {
                deleteTopInfo();
                getCategoryId();
                getMainProcessId();
                getSectionProcessId();
                loadTopRecord();
                clear();


            }
        }


        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadTopRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strCourseId = gvUnit.SelectedRow.Cells[0].Text;
            string strcourseName = gvUnit.SelectedRow.Cells[4].Text;
            string strProcessTime = gvUnit.SelectedRow.Cells[5].Text;
            string strTargetValue = gvUnit.SelectedRow.Cells[6].Text;

            txtTopId.Text = strCourseId;
            //txtProcessName.Text = strcourseName;

            //txtProcessTime.Text = strProcessTime;
            //txtTargetValue.Text = strTargetValue;


            searchProcessEntry();

            //string strMsg = "Row Index: " + strRowId + "\\nSubject ID: " + strCourseId + "\\nSubject Name : " + strcourseName;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
            loadTopRecord();
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




        #endregion

        protected void ddlProcessId_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSectionProcessId();
        }

        protected void ddlSectionProcessId_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCategoryId();
        }






      

       


        //#region "Grid View Functionality"
        //protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvEmployeeList.PageIndex = e.NewPageIndex;
           
        //}

        //protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        //{


        //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
        //    string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
        //    string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
        //    string strEmployeeId = gvEmployeeList.SelectedRow.Cells[5].Text;
        //    string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
        //    string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


        //    txtSL.Text = Convert.ToString(strRowId);
        //    txtCardNo.Text = strCardNo;
        //    txtEmployeeId.Text = strEmployeeId;
        //    txtEmployeeName.Text = strEmployeeName;
        //    txtDesignation.Text = strDesignation;

        //    searchProcessEntry();
            

        //}


        //protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    //if (e.CommandName == "Select")
        //    //{

        //    //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
        //    //    string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
        //    //    string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
        //    //    string strEmployeeId = gvEmployeeList.SelectedRow.Cells[5].Text;
        //    //    string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
        //    //    string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


        //    //    txtSL.Text = Convert.ToString(strRowId);
        //    //    txtCardNo.Text = strCardNo;
        //    //    txtEmployeeId.Text = strEmployeeId;
        //    //    txtEmployeeName.Text = strEmployeeName;
        //    //    txtDesignationName.Text = strDesignation;

        //    //    searchMiscEntryWorker();
        //    //    txtWorkingDay.Focus();

        //    //}
        //    //if (e.CommandName == "Edit")
        //    //{
        //    //}
        //    //if (e.CommandName == "Delete")
        //    //{

        //    //}

        //    //int selectedRowIndex = gvEmployeeList.SelectedRow.RowIndex;
        //    //gvEmployeeList.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        //}

        //protected void gvEmployeeList_OnRowEditing(object sender, GridViewEditEventArgs e)
        //{

        //}


        //protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
        //{



        //    e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        //    e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");



        //}

        //protected void gvEmployeeList_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{



        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
        //        e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

        //        e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);

        //    }


        //}


        //protected void gvEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
        //{

        //}




        //#endregion

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadTopRecord();
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchProcessEntry();
        }

        protected void btnSearchProcessRecord_Click(object sender, EventArgs e)
        {
            loadTopRecordByName();
        }

        public void loadTopRecordByName()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadTopRecordByName(txtProcessNameSearch.Text);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
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
                lblMsgRecord.Text = strMsg;

            }


        }
    }
}