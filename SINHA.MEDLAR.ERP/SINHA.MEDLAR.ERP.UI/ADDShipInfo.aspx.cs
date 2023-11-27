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
    public partial class ADDShipInfo : System.Web.UI.Page
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
                loadShipInfo();
                getOfficeName();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }
            txtPhoneNo.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtShipName.Text == string.Empty || txtShipAddress.Text == string.Empty)
            {

                string strMsg = "Please Enter The Ship Name and Address!!!";
                MessageBox(strMsg);
                txtShipName.Focus();
                return ;
            }
            else
            {
                saveShipInfo();
                loadShipInfo();
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
        public void saveShipInfo()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.ShipId = txtShipId.Text;
            objLookUpDTO.ShipName = txtShipName.Text;
            objLookUpDTO.ShipAddress = txtShipAddress.Text;
            objLookUpDTO.EmailAddress = txtEmail.Text;
            objLookUpDTO.PhoneNo = txtPhoneNo.Text;


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.saveShipInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void searchShipInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchShipInfo(txtShipId.Text);

            txtShipId.Text = objLookUpDTO.ShipId;
            txtShipName.Text = objLookUpDTO.ShipName;
            txtShipAddress.Text = objLookUpDTO.ShipAddress;
            txtEmail.Text = objLookUpDTO.EmailAddress;
            txtPhoneNo.Text = objLookUpDTO.PhoneNo;

        }

        public void loadShipInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadShipInfo(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvShipInfo.DataSource = dt;
                gvShipInfo.DataBind();
                string strMsg = "TOTAL " + gvShipInfo.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvShipInfo.DataSource = dt;
                gvShipInfo.DataBind();
                int totalcolums = gvShipInfo.Rows[0].Cells.Count;
                gvShipInfo.Rows[0].Cells.Clear();
                gvShipInfo.Rows[0].Cells.Add(new TableCell());
                gvShipInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvShipInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtShipId.Text = "";
            txtShipName.Text = "";
            txtShipAddress.Text = "";
            txtEmail.Text = "";
            txtPhoneNo.Text = "";
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtShipId.Text == string.Empty)
            {

                string strMsg = "Please Enter Ship ID!!!";
                MessageBox(strMsg);
                txtShipId.Focus();
                return;
            }
            else
            {
                searchShipInfo();

            }
        }

        protected void gvShipInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShipInfo.PageIndex = e.NewPageIndex;
            loadShipInfo();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvShipInfo, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvShipInfo.SelectedRow.RowIndex;
            string strShipId = gvShipInfo.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strShipName = gvShipInfo.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strShipAddress = gvShipInfo.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string strEmail = gvShipInfo.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string strPhoneNo = gvShipInfo.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");


            txtShipId.Text = strShipId;
            txtShipName.Text = strShipName;
            txtShipAddress.Text = strShipAddress;
            txtEmail.Text = strEmail;
            txtPhoneNo.Text = strPhoneNo;
            
        }

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
    
    }
}