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
    public partial class AddSupplierInfo : System.Web.UI.Page
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
            loadPoSupplierRecord();
        }

        if (IsPostBack)
        {

            loadSesscion();
        }


        txtSupplierName.Attributes.Add("onkeypress", "return controlEnter('" + txtSupplierAddress.ClientID + "', event)");
        txtSupplierAddress.Attributes.Add("onkeypress", "return controlEnter('" + txtMobileNo.ClientID + "', event)");
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


        public void loadPoSupplierRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadPoSupplierRecord(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvSupplierInfo.DataSource = dt;
                gvSupplierInfo.DataBind();
                string strMsg = "TOTAL " + gvSupplierInfo.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvSupplierInfo.DataSource = dt;
                gvSupplierInfo.DataBind();
                int totalcolums = gvSupplierInfo.Rows[0].Cells.Count;
                gvSupplierInfo.Rows[0].Cells.Clear();
                gvSupplierInfo.Rows[0].Cells.Add(new TableCell());
                gvSupplierInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvSupplierInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clear()
        {
            txtSupplierId.Text = "";
            txtSupplierName.Text = "";
            txtSupplierAddress.Text = "";
            txtMobileNo.Text = "";
            txtTelephoneNo.Text = "";
            txtFaxNo.Text = "";
            txtMailAddress.Text = "";
            txtIssuedBy.Text = "";

        }

        public void saveSupplierInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.SupplierId = txtSupplierId.Text;
            objLookUpDTO.SupplierName = txtSupplierName.Text;
            objLookUpDTO.SupplierAddress = txtSupplierAddress.Text;
            objLookUpDTO.MobileNo = txtMobileNo.Text;
            objLookUpDTO.TelephoneNo = txtTelephoneNo.Text;
            objLookUpDTO.FaxNo = txtFaxNo.Text;
            objLookUpDTO.MailAddress = txtMailAddress.Text;
            objLookUpDTO.IssuedBy = txtIssuedBy.Text;


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            string strMsg = objLookUpBLL.saveSupplierInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }

        public void clearTextBox()
        {
            txtSupplierId.Text = "";
            txtSupplierName.Text = "";
            txtSupplierAddress.Text = "";
            txtMobileNo.Text = "";
            txtTelephoneNo.Text = "";
            txtFaxNo.Text = "";
            txtMailAddress.Text = "";
            txtIssuedBy.Text = "";

        }


        public void searchSupplierEntry()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO = objLookUpBLL.searchSupplierEntry(txtSupplierId.Text, strHeadOfficeId, strBranchOfficeId);

            txtSupplierName.Text = objLookUpDTO.SupplierName;
            txtSupplierAddress.Text = objLookUpDTO.SupplierAddress;
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

                if (txtSupplierName.Text == "")
                {

                    string strMsg = "Please Enter Supplier Name!!!";
                    txtSupplierName.Focus();
                    MessageBox(strMsg);
                    return; 
                }
                else if (txtSupplierAddress.Text == "")
                {

                    string strMsg = "Please Enter Supplier Address!!!";
                    txtSupplierAddress.Focus();
                    MessageBox(strMsg);
                    return;
                }
                
              
                else
                {
                    saveSupplierInfo();
                    loadPoSupplierRecord();

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

        protected void gvSupplierInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSupplierInfo.PageIndex = e.NewPageIndex;
            loadPoSupplierRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvSupplierInfo.SelectedRow.RowIndex;
            string strSupplierId = gvSupplierInfo.SelectedRow.Cells[0].Text;
            string strSupplierName = gvSupplierInfo.SelectedRow.Cells[1].Text.Replace("&nbsp;", "").Replace("&amp;", "").Replace("nbsp;", "");
            string strSupplierAddress = gvSupplierInfo.SelectedRow.Cells[2].Text.Replace("&nbsp;", "").Replace("&amp;", "").Replace("nbsp;", "");
            string strMobileNo = gvSupplierInfo.SelectedRow.Cells[3].Text.Replace("&nbsp;", "").Replace("&amp;", "").Replace("nbsp;", "");
            string strTelephoneNo = gvSupplierInfo.SelectedRow.Cells[4].Text.Replace("&nbsp;", "").Replace("&amp;", "").Replace("nbsp;", "");
            string strFaxNo = gvSupplierInfo.SelectedRow.Cells[5].Text.Replace("&nbsp;", "").Replace("&amp;", "").Replace("nbsp;", "");
            string strMailAddress = gvSupplierInfo.SelectedRow.Cells[6].Text.Replace("&nbsp;", "").Replace("&amp;", "").Replace("nbsp;", "");

            string strIssuedBy = gvSupplierInfo.SelectedRow.Cells[7].Text.Replace("&nbsp;", "").Replace("&amp;", "").Replace("nbsp;", "");


            txtSupplierId.Text = strSupplierId;
            txtSupplierName.Text = strSupplierName;
            txtSupplierAddress.Text = strSupplierAddress;
            txtMobileNo.Text = strMobileNo;
            txtTelephoneNo.Text = strTelephoneNo;
            txtFaxNo.Text = strFaxNo;
            txtMailAddress.Text = strMailAddress;
            txtIssuedBy.Text = strIssuedBy;

        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvSupplierInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSupplierInfo.EditIndex = e.NewEditIndex;
            loadPoSupplierRecord();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvSupplierInfo, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSupplierId.Text == "")
            {

                string strMsg = "Please Enter Supplier ID!!!";
                txtSupplierId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {

                searchSupplierEntry();
            }
        }

        #endregion

    }
}