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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AddMenuInfo : System.Web.UI.Page
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
                loadMenuInfo();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }


            txtMenuName.Attributes.Add("onkeypress", "return controlEnter('" + txtMenuPath.ClientID + "', event)");
        }

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

        public void searchMenuInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchMenuInfo(txtMenuId.Text, strHeadOfficeId, strBranchOfficeId);

            txtMenuName.Text = objLookUpDTO.FebricName;



        }


        public void loadMenuInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadMenuInfo(strHeadOfficeId,strBranchOfficeId);


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




        public void saveMenuInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.MenuId = txtMenuId.Text;
            objLookUpDTO.MenuName = txtMenuName.Text;
            objLookUpDTO.MenuPath = txtMenuPath.Text;



            objLookUpDTO.UpdateBy = strHeadOfficeId;
            objLookUpDTO.HeadOfficeId = strBranchOfficeId;
            objLookUpDTO.BranchOfficeId = strEmployeeId;

            string strMsg = objLookUpBLL.saveMenuInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }

        public void clearTextBox()
        {
            txtMenuId.Text = "";
            txtMenuName.Text = "";
            txtMenuPath.Text = "";

        }

        #endregion

        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadMenuInfo();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strMenuId = gvUnit.SelectedRow.Cells[0].Text;
            string strMenuName = gvUnit.SelectedRow.Cells[1].Text;
            string strMenuPath = gvUnit.SelectedRow.Cells[2].Text;


            txtMenuId.Text = strMenuId;
            txtMenuName.Text = strMenuName;
            txtMenuPath.Text = strMenuPath;


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
            loadMenuInfo();
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMenuName.Text == "")
            {

                string strMsg = "Please Enter Menu Name!!!";
                txtMenuName.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {

                saveMenuInfo();
                loadMenuInfo();
                clearTextBox();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMenuId.Text == "")
            {

                string strMsg = "Please Enter Menu  Id!!!";
                txtMenuId.Focus();
                MessageBox(strMsg);
                return;

            }
           
            else
            {

                searchMenuInfo();
            }
        }

    }
}