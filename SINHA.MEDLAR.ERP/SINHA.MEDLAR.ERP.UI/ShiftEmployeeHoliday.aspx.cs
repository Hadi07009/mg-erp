using SINHA.MEDLAR.ERP.BLL;
using SINHA.MEDLAR.ERP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ShiftEmployeeHoliday : System.Web.UI.Page
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
                Response.Redirect("Login.aspx", false);
                return;

            }
            if (!IsPostBack)
            {
                loadSesscion();
                loadHolidayRecord();
                getOfficeName();
                getHolidayId();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }
        }

        #region "Function"

        public void getHolidayId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlHolidayTypeId.DataSource = objLookUpBLL.getHolidayId();

            ddlHolidayTypeId.DataTextField = "HOLIDAY_NAME";
            ddlHolidayTypeId.DataValueField = "HOLIDAY_TYPE_ID";

            ddlHolidayTypeId.DataBind();
            if (ddlHolidayTypeId.Items.Count > 0)
            {

                ddlHolidayTypeId.SelectedIndex = 0;
            }

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


        public void loadHolidayRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadHolidayRecord(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
            }


        }

        public void clear()
        {

            txtHolidayId.Text = string.Empty;
            dtpHolidayStartDate.Text = string.Empty;
            dtpHolidayEndDate.Text = string.Empty;
            txtDescription.Text = string.Empty;

        }


        public void searchHolidayInfo(string strHolidayId, string strFromDate, string strToDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchHolidayInfo(strHolidayId, strFromDate, strToDate, strHeadOfficeId, strBranchOfficeId);


            if (objLookUpDTO.HolidayTypeId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlHolidayTypeId.SelectedValue = objLookUpDTO.HolidayTypeId;
            }




            dtpHolidayStartDate.Text = objLookUpDTO.HolidayStartDate;
            dtpHolidayEndDate.Text = objLookUpDTO.HolidayEndDate;


        }

        public void SaveShiftEmployeeHoliday()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.HolidayId = txtHolidayId.Text;
            objLookUpDTO.HolidayStartDate = dtpHolidayStartDate.Text;
            objLookUpDTO.HolidayEndDate = dtpHolidayEndDate.Text;


            if (ddlHolidayTypeId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.HolidayTypeId = ddlHolidayTypeId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.HolidayTypeId = "";

            }

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.SaveShiftEmployeeHoliday(objLookUpDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;
        }
        public void DeleteHoliday()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.HolidayId = txtHolidayId.Text;
            objLookUpDTO.HolidayStartDate = dtpHolidayStartDate.Text;
            objLookUpDTO.HolidayEndDate = dtpHolidayEndDate.Text;


            if (ddlHolidayTypeId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.HolidayTypeId = ddlHolidayTypeId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.HolidayTypeId = "";

            }



            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objLookUpBLL.DeleteHoliday(objLookUpDTO);
            lblMsg.Text = strMsg;

            if (strMsg == "DELETED SUCCESSFULLY")
            {
                MessageBox(strMsg);
                clear();
                getHolidayId();
            }
            else
            {
                MessageBox(strMsg);

            }


        }
        #endregion


        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;

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

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strHolidayId = gvUnit.SelectedRow.Cells[0].Text;
            string strHolidayStartDate = gvUnit.SelectedRow.Cells[1].Text;
            string strEidHolidayEndDate = gvUnit.SelectedRow.Cells[2].Text;
            string strHolidayTypeId = gvUnit.SelectedRow.Cells[3].Text;


            txtHolidayId.Text = strHolidayId;
            dtpHolidayStartDate.Text = strHolidayStartDate;
            dtpHolidayEndDate.Text = strEidHolidayEndDate;


            searchHolidayInfo(strHolidayId, strHolidayStartDate, strEidHolidayEndDate, strHeadOfficeId, strBranchOfficeId);



            //string strMsg = "Row Index: " + strRowId + "\\nHoliday ID: " + strRowId + "\\nHoliday ID : " + strHolidayId + "\\nHoliday Start Date : " + strHolidayStartDate + "\\nHoliday End Date : " + strEidHolidayEndDate + "\\nHoliday Type ID : " + strHolidayTypeId; 
            ////ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }
        //protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        //{
        //    e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        //    e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        //}


        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvUnit, "Select$" + e.Row.RowIndex);
        //        //e.Row.Attributes["style"] = "cursor:pointer";

        //        try
        //        {
        //            switch (e.Row.RowType)
        //            {
        //                case DataControlRowType.Header:
        //                    //...
        //                    break;
        //                case DataControlRowType.DataRow:
        //                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#93A3B0'; this.style.color='White'; this.style.cursor='pointer'");
        //                    if (e.Row.RowState == DataControlRowState.Alternate)
        //                    {
        //                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.AlternatingRowStyle.BackColor.ToKnownColor()));
        //                    }
        //                    else
        //                    {
        //                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.RowStyle.BackColor.ToKnownColor()));
        //                    }
        //                    e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gvUnit, "Select$" + e.Row.RowIndex.ToString()));
        //                    break;
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            throw new Exception("Error : " + ex.Message);
        //        }
        //    }
        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchHolidayInfo(txtHolidayId.Text, dtpHolidayStartDate.Text, dtpHolidayEndDate.Text, strHeadOfficeId, strBranchOfficeId);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlHolidayTypeId.Text == "")
            {
                string strMsg = "Please Select Holiday Type  !!!";
                MessageBox(strMsg);
                ddlHolidayTypeId.Focus();
                return;

            }

            else if (dtpHolidayStartDate.Text.Length < 6)
            {

                string strMsg = "Please Enter Holiday Start Date  !!!";
                MessageBox(strMsg);
                dtpHolidayStartDate.Focus();
                return;
            }
            else if (dtpHolidayEndDate.Text.Length < 6)
            {

                string strMsg = "Please Enter Holiday End Date  !!!";
                MessageBox(strMsg);
                dtpHolidayEndDate.Focus();
                return;
            }
            else
            {


                SaveShiftEmployeeHoliday();
                loadHolidayRecord();

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            if (ddlHolidayTypeId.Text == "")
            {
                string strMsg = "Please Select Holiday Type  !!!";
                MessageBox(strMsg);
                ddlHolidayTypeId.Focus();
                return;

            }

            else if (dtpHolidayStartDate.Text.Length < 6)
            {

                string strMsg = "Please Enter Holiday Start Date  !!!";
                MessageBox(strMsg);
                dtpHolidayStartDate.Focus();
                return;
            }
            else if (dtpHolidayEndDate.Text.Length < 6)
            {

                string strMsg = "Please Enter Holiday End Date  !!!";
                MessageBox(strMsg);
                dtpHolidayEndDate.Focus();
                return;
            }
            else
            {


                DeleteHoliday();
                loadHolidayRecord();

            }
        }
    }
}