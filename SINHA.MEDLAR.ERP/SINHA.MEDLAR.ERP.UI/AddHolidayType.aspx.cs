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
    public partial class AddHolidayType : System.Web.UI.Page
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
            loadHolidayTypeRecord();
        }

        if (IsPostBack)
        {

            loadSesscion();
        }

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


        public void loadHolidayTypeRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadHolidayTypeRecord();


            if (dt.Rows.Count > 0)
            {
                gvHolidayType.DataSource = dt;
                gvHolidayType.DataBind();
                string strMsg = "TOTAL " + gvHolidayType.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvHolidayType.DataSource = dt;
                gvHolidayType.DataBind();
                int totalcolums = gvHolidayType.Rows[0].Cells.Count;
                gvHolidayType.Rows[0].Cells.Clear();
                gvHolidayType.Rows[0].Cells.Add(new TableCell());
                gvHolidayType.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvHolidayType.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clear()
        {
            txtHolidayId.Text = string.Empty;
            txtHolidayName.Text = string.Empty;

        }

        public void saveHolidayTypeInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.HolidayId = txtHolidayId.Text;
            objLookUpDTO.HolidayName = txtHolidayName.Text;



            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            string strMsg = objLookUpBLL.saveHolidayTypeInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }

        public void clearTextBox()
        {
            txtHolidayId.Text = "";
            txtHolidayName.Text = "";

        }


        public void searchHolidayTypeEntry()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();




            objLookUpDTO = objLookUpBLL.searchHolidayTypeEntry(txtHolidayId.Text, strHeadOfficeId, strBranchOfficeId);

            txtHolidayName.Text = objLookUpDTO.HolidayName;



        }


        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtHolidayName.Text == "")
                {

                    string strMsg = "Please Enter Holiday Name!!!";
                    txtHolidayName.Focus();
                    MessageBox(strMsg);
                    return; 
                }
                else
                {
                    saveHolidayTypeInfo();
                    loadHolidayTypeRecord();

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

        protected void gvHolidayType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHolidayType.PageIndex = e.NewPageIndex;
            loadHolidayTypeRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvHolidayType.SelectedRow.RowIndex;
            string strHolidayId = gvHolidayType.SelectedRow.Cells[0].Text;
            string strHolidayName = gvHolidayType.SelectedRow.Cells[1].Text;


            txtHolidayId.Text = strHolidayId;
            txtHolidayName.Text = strHolidayName;

        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvHolidayType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHolidayType.EditIndex = e.NewEditIndex;
            loadHolidayTypeRecord();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvHolidayType, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtHolidayId.Text == "")
            {

                string strMsg = "Please Enter Holiday ID!!!";
                txtHolidayId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {

                searchHolidayTypeEntry();
            }
        }

        #endregion

    }
}