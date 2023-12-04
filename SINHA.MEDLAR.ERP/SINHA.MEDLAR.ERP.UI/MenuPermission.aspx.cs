﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.Web.Security;

using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class MenuPermission : System.Web.UI.Page
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
        string strSoftId = "";
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
                getLoginEmpId();
                getSoftwareId();
                getMenuName();
                getBranchOfficeId();
                clearMsg();
                getOfficeName();
                LoadMenuOperationInfo();
            }
            if (IsPostBack)
            {

                loadSesscion();
            }
        }

        #region "FUNCTION"
        public void getBranchOfficeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBranchOfficeId.DataSource = objLookUpBLL.getAllBranchOfficeId();

            ddlBranchOfficeId.DataTextField = "BRANCH_OFFICE_NAME";
            ddlBranchOfficeId.DataValueField = "BRANCH_OFFICE_ID";

            ddlBranchOfficeId.DataBind();
            if (ddlBranchOfficeId.Items.Count > 0)
            {

                ddlBranchOfficeId.SelectedIndex = 0;
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
            Session["strSoftId"] = null;
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

        public void getLoginEmpId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEmployeeId.DataSource = objLookUpBLL.getLoginEmpId(strHeadOfficeId, strBranchOfficeId);

            ddlEmployeeId.DataTextField = "EMPLOYEE_NAME";
            ddlEmployeeId.DataValueField = "EMPLOYEE_ID";

            ddlEmployeeId.DataBind();
            if (ddlEmployeeId.Items.Count > 0)
            {

                ddlEmployeeId.SelectedIndex = 0;
            }

        }
        public void getSoftwareId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSoftwareId.DataSource = objLookUpBLL.getSoftwareId(strHeadOfficeId, strBranchOfficeId);

            ddlSoftwareId.DataTextField = "SOFTWARE_NAME";
            ddlSoftwareId.DataValueField = "SOFTWARE_ID";

            ddlSoftwareId.DataBind();
            if (ddlSoftwareId.Items.Count > 0)
            {

                ddlSoftwareId.SelectedIndex = 0;
            }

        }
        public void getMenuName()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlMenuName.DataSource = objLookUpBLL.getMenuName(strHeadOfficeId, strBranchOfficeId);

            ddlMenuName.DataTextField = "MENU_NAME";
            ddlMenuName.DataValueField = "MENU_ID";

            ddlMenuName.DataBind();
            if (ddlMenuName.Items.Count > 0)
            {

                ddlMenuName.SelectedIndex = 0;
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
            strSoftId = Session["strSoftId"].ToString().Trim();
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

        protected void gvEmployeeList_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                if (ddlEmployeeId.Text == " ")
                {

                    string strMsg = "Please Select User Name!!!";
                    MessageBox(strMsg);
                    ddlEmployeeId.Focus();
                    return;
                }

                else if (ddlSoftwareId.Text == " ")
                {

                    string strMsg = "Please Select Software Name!!!";
                    MessageBox(strMsg);
                    ddlSoftwareId.Focus();
                    return;
                }
                else if (ddlBranchOfficeId.Text == " ")
                {

                    string strMsg = "Please Select Office Name!!!";
                    MessageBox(strMsg);
                    ddlBranchOfficeId.Focus();
                    return;
                }
                else
                {

                    string strMenuId = gvEmployeeList.DataKeys[e.RowIndex].Values["MENU_ID"].ToString();
                    deleteEmployeeMenuFromGrid(strMenuId);
                    searchMenuInfoEntry();


                }

              



            }
            catch
            {
                MessageBox("It haven't any ID to delete");
            }
        }

        public void searchMenuInfoEntry()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            string strEmpId = "", strSoftId = "" ;


            if (ddlEmployeeId.SelectedValue.ToString() != " ")
            {
                strEmpId = ddlEmployeeId.SelectedValue.ToString();
            }
            else
            {

                strEmpId = "";
            }

            if (ddlSoftwareId.SelectedValue.ToString() != " ")
            {
                strSoftId = ddlSoftwareId.SelectedValue.ToString();
            }
            else
            {

                strSoftId = "";
            }

            if (ddlBranchOfficeId.SelectedValue.ToString() != " ")
            {
                strBranchOfficeId = ddlBranchOfficeId.SelectedValue.ToString();
            }
            else
            {

                strBranchOfficeId = "";
            }





            dt = objLookUpBLL.searchMenuInfoEntry(strEmpId, strSoftId, strHeadOfficeId, strBranchOfficeId);
          


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
                string strMsg = "TOTAL " + gvEmployeeList.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
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
                lblMsg.Text = strMsg;
            }

        }
        public void LoadMenuOperationInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();

            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            

            dt = objLookUpBLL.searchMenuInfoEntryRecord(strSoftId, strHeadOfficeId,strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
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
                lblMsgRecord.Text = strMsg;
            }

        }


        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
 
        public void addMenuInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            string strMsg = "";
            string strCount = GridView1.Rows.Count.ToString();

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkMenuId = (CheckBox)row.FindControl("chkMenuId");
                    if (chkMenuId.Checked)
                    {
                      //  string strId = (row.FindControl("lblEmployeeId") as Label).Text;

                       
                        string strMenuId = (row.FindControl("lblMenuId") as Label).Text;
                        string strMenuName = (row.FindControl("lblMenuName") as Label).Text;
                        string strMenuPath = (row.FindControl("lblMenuPath") as Label).Text;
                        //objLookUpDTO.EmployeeId = strId;
                        if (ddlEmployeeId.SelectedValue.ToString() != " ")
                        {
                            objLookUpDTO.EmployeeId = ddlEmployeeId.SelectedValue.ToString();
                        }
                        else
                        {

                            objLookUpDTO.EmployeeId = "";
                        }


                        objLookUpDTO.MenuId = strMenuId;
                        objLookUpDTO.MenuName = strMenuName;
                        objLookUpDTO.MenuPath = strMenuPath;




                        if (ddlSoftwareId.SelectedValue.ToString() != " ")
                        {
                            objLookUpDTO.SoftId = ddlSoftwareId.SelectedValue.ToString();
                        }
                        else
                        {

                            objLookUpDTO.SoftId = "";
                        }


                        if (ddlMenuName.SelectedValue.ToString() != " ")
                        {
                            objLookUpDTO.MenuPosition = ddlMenuName.SelectedValue.ToString();
                        }
                        else
                        {

                            objLookUpDTO.MenuPosition = "";
                        }



                        if (ddlBranchOfficeId.SelectedValue.ToString() != " ")
                        {
                            objLookUpDTO.BranchOfficeId = ddlBranchOfficeId.SelectedValue.ToString();
                        }
                        else
                        {

                            objLookUpDTO.BranchOfficeId = "";
                        }


                        objLookUpDTO.UpdateBy = strEmployeeId;
                        objLookUpDTO.HeadOfficeId = strHeadOfficeId;
                      


                        strMsg = objLookUpBLL.addMenuInfo(objLookUpDTO);

                    }

                }
            }

            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }
       
        public void deleteEmployeeMenuFromGrid(string strMenuId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();



            if (ddlEmployeeId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.EmployeeId = ddlEmployeeId.SelectedValue.ToString();
            }
            else
            {

                objLookUpDTO.EmployeeId = "";
            }

            if (ddlSoftwareId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.SoftId = ddlSoftwareId.SelectedValue.ToString();
            }
            else
            {

                objLookUpDTO.SoftId = "";
            }


            if (ddlBranchOfficeId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.BranchOfficeId = ddlBranchOfficeId.SelectedValue.ToString();
            }
            else
            {

                objLookUpDTO.BranchOfficeId = "";
            }



            objLookUpDTO.MenuId = strMenuId;


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
           


            string strMsg = objLookUpBLL.deleteEmployeeMenuFromGrid(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }
        public void searchLoginEmployeeName(string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchLoginEmployeeName(strEmployeeId, strHeadOfficeId, strBranchOfficeId);

            txtEmployeeFullName.Text = objLookUpDTO.EmployeeName;
            if (objLookUpDTO.BranchOfficeId == "0")
            {
                getBranchOfficeId();
            }
            else
            {

                ddlBranchOfficeId.SelectedValue = objLookUpDTO.BranchOfficeId;
            }

            if (objLookUpDTO.SoftId == "0")
            {
                getSoftwareId();
            }
            else
            {

                ddlSoftwareId.SelectedValue = objLookUpDTO.SoftId;
            }



        }

        #endregion

        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
            
        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //string strEmployeeId = gvEmployeeList.SelectedRow.Cells[1].Text;
            //string strMenuId = gvEmployeeList.SelectedRow.Cells[2].Text;


            //txtEmployeeId.Text = strEmployeeId;
            //txtMenuId.Text = strMenuId;




        }

        protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }

        protected void gvEmployeeList_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);
            }
        }

        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }

        #endregion
        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {

          


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

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        } 

        #endregion

       
       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
              {
                if (ddlEmployeeId.Text == " ")
                {

                    string strMsg = "Please Select User Name!!!";
                    MessageBox(strMsg);
                    ddlEmployeeId.Focus();
                    return;
                }

                else if (ddlSoftwareId.Text == " ")
                {

                    string strMsg = "Please Select Software Name!!!";
                    MessageBox(strMsg);
                    ddlSoftwareId.Focus();
                    return;
                }
                else if (ddlBranchOfficeId.Text == " ")
                {

                    string strMsg = "Please Select Office Name!!!";
                    MessageBox(strMsg);
                    ddlBranchOfficeId.Focus();
                    return;
                }

                else if (ddlMenuName.Text == " ")
                {

                    string strMsg = "Please Select Menu Position!!!";
                    MessageBox(strMsg);
                    ddlMenuName.Focus();
                    return;
                }



                else
                {
                    addMenuInfo();
                    searchMenuInfoEntry();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void ddlEmployeeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmployeeId.Text != " ")
            {

                searchLoginEmployeeName(ddlEmployeeId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);
                searchMenuInfoEntry();

            }
            else
            {
                //searchMenuInfoEntry();

            }
        }



        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchMenuInfoEntry();
           
        }

    
    }
}