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
    public partial class AddBuyerInfo : System.Web.UI.Page
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
                loadBuyerRecord();
                getOfficeName();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }

            txtBuyerShortName.Attributes.Add("onkeypress", "return controlEnter('" + txtBuyerFullName.ClientID + "', event)");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtBuyerShortName.Text == string.Empty)
            {
                string strMsg = "Please Enter Buyer Short Name!!!";
                MessageBox(strMsg);
                txtBuyerShortName.Focus();
                return ;
            }

            else if (txtBuyerFullName.Text == string.Empty)
            {
                string strMsg = "Please Enter Buyer Full Name!!!";
                MessageBox(strMsg);
                txtBuyerFullName.Focus();
                return;
            }
            else
            {
                SaveBuyerInfo();
                loadBuyerRecord();

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

        public void SaveBuyerInfo()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.BuyerId = txtBuyerId.Text;
            objLookUpDTO.BuyerShortName = txtBuyerShortName.Text;
            objLookUpDTO.BuyerFullName = txtBuyerFullName.Text;


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.SaveBuyerInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void searchBuyerInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchBuyerInfo(txtBuyerId.Text);

            txtBuyerShortName.Text = objLookUpDTO.BuyerShortName;
            txtBuyerFullName.Text = objLookUpDTO.BuyerFullName;


        }

        public void loadBuyerRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadBuyerRecord(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvBuyerInfo.DataSource = dt;
                gvBuyerInfo.DataBind();
                string strMsg = "TOTAL " + gvBuyerInfo.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvBuyerInfo.DataSource = dt;
                gvBuyerInfo.DataBind();
                int totalcolums = gvBuyerInfo.Rows[0].Cells.Count;
                gvBuyerInfo.Rows[0].Cells.Clear();
                gvBuyerInfo.Rows[0].Cells.Add(new TableCell());
                gvBuyerInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvBuyerInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtBuyerId.Text = "";
            txtBuyerShortName.Text = "";
            txtBuyerFullName.Text = "";


        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtBuyerId.Text == string.Empty)
            {

                string strMsg = "Please Enter Unit ID!!!";
                MessageBox(strMsg);
                txtBuyerId.Focus();
                return;
            }
            else
            {
                searchBuyerInfo();

            }
        }

        protected void gvBuyerInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBuyerInfo.PageIndex = e.NewPageIndex;           
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvBuyerInfo, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvBuyerInfo.SelectedRow.RowIndex;
            string strBuyerId = gvBuyerInfo.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strBuyerShortName = gvBuyerInfo.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strBuyerFullName = gvBuyerInfo.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

            txtBuyerId.Text = strBuyerId;
            txtBuyerShortName.Text = strBuyerShortName;
            txtBuyerFullName.Text = strBuyerFullName;

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