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
    public partial class AddPurchaseInfo : System.Web.UI.Page
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
            loadPurchaseRecord();
        }

        if (IsPostBack)
        {

            loadSesscion();
        }

        txtOfficeName.Attributes.Add("onkeypress", "return controlEnter('" + txtOfficeAddress.ClientID + "', event)");
        txtOfficeAddress.Attributes.Add("onkeypress", "return controlEnter('" + txtMobileNo.ClientID + "', event)");
        txtMobileNo.Attributes.Add("onkeypress", "return controlEnter('" + txtTelephoneNo.ClientID + "', event)");
        txtTelephoneNo.Attributes.Add("onkeypress", "return controlEnter('" + txtFaxNo.ClientID + "', event)");
        txtFaxNo.Attributes.Add("onkeypress", "return controlEnter('" + txtMailAddress.ClientID + "', event)");
        txtMailAddress.Attributes.Add("onkeypress", "return controlEnter('" + txtIssuedBy.ClientID + "', event)");


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


        public void loadPurchaseRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadPurchaseRecord();


            if (dt.Rows.Count > 0)
            {
                gvPurchaseInfo.DataSource = dt;
                gvPurchaseInfo.DataBind();
                string strMsg = "TOTAL " + gvPurchaseInfo.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPurchaseInfo.DataSource = dt;
                gvPurchaseInfo.DataBind();
                int totalcolums = gvPurchaseInfo.Rows[0].Cells.Count;
                gvPurchaseInfo.Rows[0].Cells.Clear();
                gvPurchaseInfo.Rows[0].Cells.Add(new TableCell());
                gvPurchaseInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPurchaseInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clear()
        {
            txtOfficeId.Text = "";
            txtOfficeName.Text = "";
            txtOfficeAddress.Text = "";
            txtMobileNo.Text = "";
            txtTelephoneNo.Text = "";
            txtFaxNo.Text = "";
            txtMailAddress.Text = "";
            txtIssuedBy.Text = "";

        }

        public void savePurchaseInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.OfficeId = txtOfficeId.Text;
            objLookUpDTO.OfficeName = txtOfficeName.Text;
            objLookUpDTO.OfficeAddress = txtOfficeAddress.Text;
            objLookUpDTO.MobileNo = txtMobileNo.Text;
            objLookUpDTO.TelephoneNo = txtTelephoneNo.Text;
            objLookUpDTO.FaxNo = txtFaxNo.Text;
            objLookUpDTO.MailAddress = txtMailAddress.Text;
            objLookUpDTO.IssuedBy = txtIssuedBy.Text;


            objLookUpDTO.UpdateBy = strHeadOfficeId;
            objLookUpDTO.HeadOfficeId = strBranchOfficeId;
            objLookUpDTO.BranchOfficeId = strEmployeeId;
            string strMsg = objLookUpBLL.savePurchaseInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }

        public void clearTextBox()
        {
            txtOfficeId.Text = "";
            txtOfficeName.Text = "";
            txtOfficeAddress.Text = "";
            txtMobileNo.Text = "";
            txtTelephoneNo.Text = "";
            txtFaxNo.Text = "";
            txtMailAddress.Text = "";
            txtIssuedBy.Text = "";

        }


        public void searchPurchaseEntry()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO = objLookUpBLL.searchPurchaseEntry(txtOfficeId.Text, strHeadOfficeId, strBranchOfficeId);

            txtOfficeName.Text = objLookUpDTO.OfficeName;
            txtOfficeAddress.Text = objLookUpDTO.OfficeAddress;
            txtMobileNo.Text = objLookUpDTO.MobileNo;
            txtTelephoneNo.Text = objLookUpDTO.TelephoneNo;
            txtFaxNo.Text = objLookUpDTO.FaxNo;
            txtMailAddress.Text = objLookUpDTO.MailAddress;
            txtIssuedBy.Text = objLookUpDTO.IssuedBy;



        }


        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtOfficeName.Text == "")
                {

                    string strMsg = "Please Enter Office Name!!!";
                    txtOfficeName.Focus();
                    MessageBox(strMsg);
                    return; 
                }
                else if (txtOfficeAddress.Text == "")
                {

                    string strMsg = "Please Enter Office Address!!!";
                    txtOfficeAddress.Focus();
                    MessageBox(strMsg);
                    return;
                }

                else
                {
                    savePurchaseInfo();
                    loadPurchaseRecord();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
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


        #region "GridView Functionlity"

        protected void gvPurchaseInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPurchaseInfo.PageIndex = e.NewPageIndex;
            loadPurchaseRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvPurchaseInfo.SelectedRow.RowIndex;
            string strOfficeId = gvPurchaseInfo.SelectedRow.Cells[0].Text;
            string strOfficeName = gvPurchaseInfo.SelectedRow.Cells[1].Text;
            string strOfficeAddress = gvPurchaseInfo.SelectedRow.Cells[2].Text;
            string strMobileNo = gvPurchaseInfo.SelectedRow.Cells[3].Text;
            string strTelephoneNo = gvPurchaseInfo.SelectedRow.Cells[4].Text;
            string strFaxNo = gvPurchaseInfo.SelectedRow.Cells[5].Text;
            string strMailAddress = gvPurchaseInfo.SelectedRow.Cells[6].Text;
            string strIssuedBy = gvPurchaseInfo.SelectedRow.Cells[7].Text;


            txtOfficeId.Text = strOfficeId;
            txtOfficeName.Text = strOfficeName;
            txtOfficeAddress.Text = strOfficeAddress;
            txtMobileNo.Text = strMobileNo;
            txtTelephoneNo.Text = strTelephoneNo;
            txtFaxNo.Text = strFaxNo;
            txtMailAddress.Text = strMailAddress;
            txtIssuedBy.Text = strIssuedBy;


            //string strMsg = "Row Index: " + strRowId + "\\nSubject ID: " + strCourseId + "\\nSubject Name : " + strcourseName;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvPurchaseInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPurchaseInfo.EditIndex = e.NewEditIndex;
            loadPurchaseRecord();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPurchaseInfo, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtOfficeId.Text == "")
            {

                string strMsg = "Please Enter Office ID!!!";
                txtOfficeId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {

                searchPurchaseEntry();
            }
        }


        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvUnit, "Select$" + e.Row.RowIndex);
        //    //e.Row.Attributes["style"] = "cursor:pointer";

        //    try
        //    {
        //        switch (e.Row.RowType)
        //        {
        //            case DataControlRowType.Header:
        //                //...
        //                break;
        //            case DataControlRowType.DataRow:
        //                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#93A3B0'; this.style.color='White'; this.style.cursor='pointer'");
        //                if (e.Row.RowState == DataControlRowState.Alternate)
        //                {
        //                    e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.AlternatingRowStyle.BackColor.ToKnownColor()));
        //                }
        //                else
        //                {
        //                    e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.RowStyle.BackColor.ToKnownColor()));
        //                }
        //                e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gvUnit, "Select$" + e.Row.RowIndex.ToString()));
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception("Error : " + ex.Message);
        //    }
        //}
        //}

        #endregion

    }
}