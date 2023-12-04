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
    public partial class AddBuyerStore : System.Web.UI.Page
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
                loadBuyerEntry();
                getOfficeName();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }


            lblMsg.Text = "";

            
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtBuyerName.Text == string.Empty)
            {

                string strMsg = "Please Enter Buyer Name!!!";
                MessageBox(strMsg);
                txtBuyerName.Focus();
                return ;
            }
            else
            {
                saveBuyerEntryRecord();
                clearTextBox();
                loadBuyerEntry();
                
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

      
     
    
        public void saveBuyerEntryRecord()
        {
            BuyerDTO objBuyerDTO = new BuyerDTO();
            BuyerBLL objBuyerBLL = new BuyerBLL();
            objBuyerDTO.BuyerId = txtBuyerId.Text;
            objBuyerDTO.BuyerName = txtBuyerName.Text;
            objBuyerDTO.UpdateBy = strEmployeeId;
            objBuyerDTO.HeadOfficeId = strHeadOfficeId;
            objBuyerDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objBuyerBLL.saveBuyerEntryRecord(objBuyerDTO);
            lblMsgRecord.Text = strMsg;
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }




      
        public void searchBuyerRecord()
        {
            BuyerDTO objBuyerDTO = new BuyerDTO();
            BuyerBLL objBuyerBLL = new BuyerBLL();

            objBuyerDTO = objBuyerBLL.searchBuyerRecord(txtBuyerId.Text);


            txtBuyerName.Text = objBuyerDTO.BuyerName;



        }


        public void loadBuyerEntry()
        {
            BuyerDTO objBuyerDTO = new BuyerDTO();
            BuyerBLL objBuyerBLL = new BuyerBLL();

            DataTable dt = new DataTable();
            dt = objBuyerBLL.loadBuyerEntry(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvBuyerEntry.DataSource = dt;
                gvBuyerEntry.DataBind();
                string strMsg = "TOTAL " + gvBuyerEntry.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);

                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvBuyerEntry.DataSource = dt;
                gvBuyerEntry.DataBind();
                int totalcolums = gvBuyerEntry.Rows[0].Cells.Count;
                gvBuyerEntry.Rows[0].Cells.Clear();
                gvBuyerEntry.Rows[0].Cells.Add(new TableCell());
                gvBuyerEntry.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvBuyerEntry.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;
                lblMsgRecord.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtBuyerId.Text = "";
            txtBuyerName.Text = "";
           


        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtBuyerId.Text == string.Empty)
            {

                string strMsg = "Please Enter Color ID!!!";
                MessageBox(strMsg);
                txtBuyerId.Focus();
                return;
            }
            else
            {
                searchBuyerRecord();

            }
        }

        protected void gvBuyerEntry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBuyerEntry.PageIndex = e.NewPageIndex;
            
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvBuyerEntry, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvBuyerEntry.SelectedRow.RowIndex;
            string strBuyerId = gvBuyerEntry.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strBuyerName = gvBuyerEntry.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
           
           

            txtBuyerId.Text = strBuyerId;
            txtBuyerName.Text = strBuyerName;
            

           

            
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