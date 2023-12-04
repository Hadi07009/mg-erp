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
    public partial class CourtInfo : System.Web.UI.Page
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
                GetCourtInfo();
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

            if (txtCourtName.Text == string.Empty)
            {
                string strMsg = "Please Enter Case Type Name";
                MessageBox(strMsg);
                txtCourtName.Focus();
                return;
            }

                SaveCourtInfo();
                clearTextBox();
                GetCourtInfo();

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
        public void SaveCourtInfo()
        {
            CaseInfoDTO objCaseInfoDTO = new CaseInfoDTO();
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();
            objCaseInfoDTO.CourtId = txtCourtId.Text;
            objCaseInfoDTO.CourtName = txtCourtName.Text;
            objCaseInfoDTO.CreateBy = strEmployeeId;

            string strMsg = objCaseInfoBLL.SaveCourtInfo(objCaseInfoDTO);
            lblMsgRecord.Text = strMsg;
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }

        //public void searchBuyerRecord()
        //{
        //    BuyerDTO objBuyerDTO = new BuyerDTO();
        //    BuyerBLL objBuyerBLL = new BuyerBLL();

        //    objBuyerDTO = objBuyerBLL.searchBuyerRecord(txtBuyerId.Text);
        //    txtBuyerName.Text = objBuyerDTO.BuyerName;
        //}
        public void GetCourtInfo()
        {
            CaseInfoDTO objCaseInfoDTO = new CaseInfoDTO();
            CaseInfoBLL objCaseInfoBLL = new CaseInfoBLL();

            DataTable dt = new DataTable();
            dt = objCaseInfoBLL.GetCourtInfo();


            if (dt.Rows.Count > 0)
            {
                gvCourtInfo.DataSource = dt;
                gvCourtInfo.DataBind();
                string strMsg = "TOTAL " + gvCourtInfo.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvCourtInfo.DataSource = dt;
                gvCourtInfo.DataBind();
                int totalcolums = gvCourtInfo.Rows[0].Cells.Count;
                gvCourtInfo.Rows[0].Cells.Clear();
                gvCourtInfo.Rows[0].Cells.Add(new TableCell());
                gvCourtInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvCourtInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;
                lblMsgRecord.Text = strMsg;
            }
        }
        public void clearTextBox()
        {
            txtCourtId.Text = "";
            txtCourtName.Text = "";
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //if (txtDefendantId.Text == string.Empty)
            //{

            //    string strMsg = "Please Enter Color ID!!!";
            //    MessageBox(strMsg);
            //    txtDefendantId.Focus();
            //    return;
            //}
            //else
            //{
            //    searchBuyerRecord();

            //}
        }
        protected void gvCourtInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCourtInfo.PageIndex = e.NewPageIndex;
        }

        protected void gvCourtInfo_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvCourtInfo, "Select$" + e.Row.RowIndex);
            }
        }
        protected void gvCourtInfo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvCourtInfo.SelectedRow.RowIndex;
            string CourtName = gvCourtInfo.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string CourtId = gvCourtInfo.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");

            txtCourtId.Text = CourtId;
            txtCourtName.Text = CourtName;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearTextBox();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
    }
}