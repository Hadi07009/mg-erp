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
    public partial class AddMachineModelMainta : System.Web.UI.Page
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
                loadMachineModelInfo();
                getOfficeName();
                getMachineId();

                //getLine();


            }

            if (IsPostBack)
            {

                loadSesscion();
            }



            ddlMachineId.Attributes.Add("onkeypress", "return controlEnter('" + txtMachineModel.ClientID + "', event)");
            txtMachineModel.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlMachineId.SelectedValue == string.Empty || txtMachineModel.Text == string.Empty)
                {
                    string strMsg = "Please Fill All The Field!!!";
                    txtMachineModel.Focus();
                    MessageBox(strMsg);
                    return;


                }

                else
                {
                    saveMachineModelInfo();
                    loadMachineModelInfo();

                }



            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {

                clear();

            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

        //public void searchDefectNameEntry()
        //{

        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    objLookUpDTO = objLookUpBLL.searchDefectNameEntry(txtSewingDefectNameId.Text, strHeadOfficeId, strBranchOfficeId);

        //    if (objLookUpDTO.SewingDefectCategoryId == "0")
        //    {

        //       //nothing
        //    }
        //    else
        //    {
        //        ddlDefectCategoryId.SelectedValue = objLookUpDTO.SewingDefectCategoryId;
        //    }

        //    txtDefectName.Text = objLookUpDTO.SewingDefectName;




        //}


        #region "Function"







        public void getMachineId()
        {

            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();
            ddlMachineId.DataSource = objMaintenanceBLL.getMachineId(strHeadOfficeId, strBranchOfficeId);

            ddlMachineId.DataTextField = "MACHINE_NAME";

            ddlMachineId.DataValueField = "MACHINE_ID";

            ddlMachineId.DataBind();
            if (ddlMachineId.Items.Count > 0)
            {

                ddlMachineId.SelectedIndex = 0;
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


        public void loadMachineModelInfo()
        {
            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            DataTable dt = new DataTable();
            dt = objMaintenanceBLL.loadMachineModelInfo(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";

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

        public void clear()
        {
            txtMachineModelId.Text = "";

            ddlMachineId.Items.Clear();
            txtMachineModel.Text = "";
            loadMachineModelInfo();
            getMachineId();

        }
        public void saveMachineModelInfo()
        {

            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            objMaintenanceDTO.MachineModelId = txtMachineModelId.Text;
            objMaintenanceDTO.MachinelId = ddlMachineId.SelectedValue.ToString();
            objMaintenanceDTO.MachineModelName = txtMachineModel.Text;


            objMaintenanceDTO.UpdateBy = strEmployeeId;
            objMaintenanceDTO.HeadOfficeId = strHeadOfficeId;
            objMaintenanceDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objMaintenanceBLL.saveMachineModelInfo(objMaintenanceDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
            //getSewingDefectCategoryId();
            txtMachineModel.Text = "";
        }

        public void searchMachineModelEntry()
        {


            MaintenanceDTO objMaintenanceDTO = new MaintenanceDTO();
            MaintenanceBLL objMaintenanceBLL = new MaintenanceBLL();

            objMaintenanceDTO = objMaintenanceBLL.searchMachineModelEntry(txtMachineModelId.Text, strHeadOfficeId, strBranchOfficeId);

            if (objMaintenanceDTO.MachinelId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlMachineId.SelectedValue = objMaintenanceDTO.MachinelId;
            }

            txtMachineModel.Text = objMaintenanceDTO.MachineModelName;


        }


        #endregion

        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;

        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;

            string strMachineModeltNameId = gvUnit.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");

            //  string strMachineId = gvUnit.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            //  string strMachineModelName = gvUnit.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");


            txtMachineModelId.Text = strMachineModeltNameId;
            //   ddlMachineId.SelectedValue = strMachineId;
            //   txtMachineModel.Text = strMachineModelName;
            searchMachineModelEntry();
        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
            loadMachineModelInfo();
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

        protected void chkActiveYn_CheckedChanged(object sender, EventArgs e)
        {

        }






        #endregion
    }
}