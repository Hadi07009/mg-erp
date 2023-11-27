using System;
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
    public partial class AddDeliverToInfo : System.Web.UI.Page
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
                loadDeliverRecord();
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
            txtMailAddress.Attributes.Add("onkeypress", "return controlEnter('" + txtReceivedBy.ClientID + "', event)");



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


        public void loadDeliverRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadDeliverRecord();


            if (dt.Rows.Count > 0)
            {
                gvDeliverToInfo.DataSource = dt;
                gvDeliverToInfo.DataBind();
                string strMsg = "TOTAL " + gvDeliverToInfo.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvDeliverToInfo.DataSource = dt;
                gvDeliverToInfo.DataBind();
                int totalcolums = gvDeliverToInfo.Rows[0].Cells.Count;
                gvDeliverToInfo.Rows[0].Cells.Clear();
                gvDeliverToInfo.Rows[0].Cells.Add(new TableCell());
                gvDeliverToInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvDeliverToInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";

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
            txtReceivedBy.Text = "";

        }

        public void saveDeliverInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.OfficeId = txtOfficeId.Text;
            objLookUpDTO.OfficeName = txtOfficeName.Text;
            objLookUpDTO.OfficeAddress = txtOfficeAddress.Text;
            objLookUpDTO.BINNo = txtBINNo.Text;
            objLookUpDTO.MobileNo = txtMobileNo.Text;
            objLookUpDTO.TelephoneNo = txtTelephoneNo.Text;
            objLookUpDTO.FaxNo = txtFaxNo.Text;
            objLookUpDTO.MailAddress = txtMailAddress.Text;
            objLookUpDTO.ReceivedBy = txtReceivedBy.Text;


            objLookUpDTO.UpdateBy = strHeadOfficeId;
            objLookUpDTO.HeadOfficeId = strBranchOfficeId;
            objLookUpDTO.BranchOfficeId = strEmployeeId;
            string strMsg = objLookUpBLL.saveDeliverInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }

        public void clearTextBox()
        {
            txtOfficeId.Text = "";
            txtOfficeName.Text = "";
            txtOfficeAddress.Text = "";
            txtBINNo.Text = "";
            txtMobileNo.Text = "";
            txtTelephoneNo.Text = "";
            txtFaxNo.Text = "";
            txtMailAddress.Text = "";
            txtReceivedBy.Text = "";

        }


        public void searchDeliverToEntry()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO = objLookUpBLL.searchDeliverToEntry(txtOfficeId.Text, strHeadOfficeId, strBranchOfficeId);

            txtOfficeName.Text = objLookUpDTO.OfficeName;
            txtOfficeAddress.Text = objLookUpDTO.OfficeAddress;
            txtMobileNo.Text = objLookUpDTO.MobileNo;
            txtTelephoneNo.Text = objLookUpDTO.TelephoneNo;
            txtFaxNo.Text = objLookUpDTO.FaxNo;
            txtMailAddress.Text = objLookUpDTO.MailAddress;
            txtReceivedBy.Text = objLookUpDTO.ReceivedBy;



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
                    saveDeliverInfo();
                    loadDeliverRecord();

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

                throw new Exception("Error : " + ex.Message);
            }
        }


        #region "GridView Functionlity"

        protected void gvDeliverToInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDeliverToInfo.PageIndex = e.NewPageIndex;
            loadDeliverRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvDeliverToInfo.SelectedRow.RowIndex;
            string strOfficeId = gvDeliverToInfo.SelectedRow.Cells[0].Text;
            string strOfficeName = gvDeliverToInfo.SelectedRow.Cells[1].Text;
            string strOfficeAddress = gvDeliverToInfo.SelectedRow.Cells[2].Text;
            string BINNo = gvDeliverToInfo.SelectedRow.Cells[3].Text;
            string strMobileNo = gvDeliverToInfo.SelectedRow.Cells[4].Text;
            string strTelephoneNo = gvDeliverToInfo.SelectedRow.Cells[5].Text;
            string strFaxNo = gvDeliverToInfo.SelectedRow.Cells[6].Text;
            string strMailAddress = gvDeliverToInfo.SelectedRow.Cells[7].Text;
            string strReceivedBy = gvDeliverToInfo.SelectedRow.Cells[8].Text;


            txtOfficeId.Text = strOfficeId;
            txtOfficeName.Text = strOfficeName;
            txtOfficeAddress.Text = strOfficeAddress;
            txtBINNo.Text = BINNo;
            txtMobileNo.Text = strMobileNo;
            txtTelephoneNo.Text = strTelephoneNo;
            txtFaxNo.Text = strFaxNo;
            txtMailAddress.Text = strMailAddress;
            txtReceivedBy.Text = strReceivedBy;


            //string strMsg = "Row Index: " + strRowId + "\\nSubject ID: " + strCourseId + "\\nSubject Name : " + strcourseName;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvDeliverToInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDeliverToInfo.EditIndex = e.NewEditIndex;
            loadDeliverRecord();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvDeliverToInfo, "Select$" + e.Row.RowIndex);
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

                searchDeliverToEntry();
            }
        }



        #endregion

    }
}