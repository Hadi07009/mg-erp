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
    public partial class ProductQuantity : System.Web.UI.Page
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
                getProductCategory();
                loadRequisitionInfo();
                getOfficeName();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }
            txtTotalPrice.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtRequisitionDate.Text == string.Empty || ddlProductId.SelectedValue == string.Empty || txtQuantity.Text == string.Empty)
            {

                string strMsg = "Please Enter The Requisition Date, Product Name and Quantity!!!";
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                txtRequisitionDate.Focus();
                return ;
            }
            else
            {
                saveRequisitionInfo();
                loadRequisitionInfo();

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

        public void getProductCategory()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();

            ddlProductId.DataSource = objLookUpBLL.getProductCategory(strHeadOfficeId, strBranchOfficeId);

            ddlProductId.DataTextField = "PRODUCT_NAME";
            ddlProductId.DataValueField = "PRODUCT_ID";
            ddlProductId.DataBind();
            if (ddlProductId.Items.Count > 0)
            {

                ddlProductId.SelectedIndex = 0;
            }

        }


        public void getDeviceInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            string strProductId = "";

            if (ddlProductId.SelectedValue.ToString() != " ")
            {

                strProductId = ddlProductId.SelectedValue.ToString();

            }
            else
            {

                strProductId = "";
            }


            objLookUpDTO = objLookUpBLL.getDeviceInfo(strProductId, strHeadOfficeId, strBranchOfficeId);

            txtDeviceName.Text = objLookUpDTO.DeviceName;
            txtDevicePrice.Text = objLookUpDTO.DevicePrice;


        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        public void saveRequisitionInfo()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            if (ddlProductId.SelectedValue.ToString() != " ")
            {

                objLookUpDTO.ProductTranId = ddlProductId.SelectedValue.ToString();

            }
            else
            {

                objLookUpDTO.ProductTranId = "";
            }

         
            objLookUpDTO.DeviceName = txtDeviceName.Text;
            objLookUpDTO.DevicePrice = txtDevicePrice.Text;
            objLookUpDTO.RequisitionDate = txtRequisitionDate.Text;
            objLookUpDTO.Quantity = txtQuantity.Text;
            objLookUpDTO.RequisitionQuantity = txtRequisitionQuantity.Text;

          


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.saveRequiusitionInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void searchRequisitionInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchRequisitionInfo(txtTranId.Text);

            txtTranId.Text = objLookUpDTO.ProductTranId;
            txtRequisitionDate.Text = objLookUpDTO.RequisitionDate;
            ddlProductId.SelectedValue = objLookUpDTO.ProductName;
            txtDeviceName.Text = objLookUpDTO.DeviceName;
            txtQuantity.Text = objLookUpDTO.Quantity;
            txtDevicePrice.Text = objLookUpDTO.DevicePrice;
            txtTotalPrice.Text = objLookUpDTO.DevicesTotalPrice;

        }

        public void loadRequisitionInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadRequisitionInfo(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvPruductRequisition.DataSource = dt;
                gvPruductRequisition.DataBind();
                string strMsg = "TOTAL " + gvPruductRequisition.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPruductRequisition.DataSource = dt;
                gvPruductRequisition.DataBind();
                int totalcolums = gvPruductRequisition.Rows[0].Cells.Count;
                gvPruductRequisition.Rows[0].Cells.Clear();
                gvPruductRequisition.Rows[0].Cells.Add(new TableCell());
                gvPruductRequisition.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPruductRequisition.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtTranId.Text = "";
            txtRequisitionDate.Text = "";

            txtRequisitionQuantity.Text = "";
            txtDeviceName.Text = "";
            txtDevicePrice.Text = "";
            txtQuantity.Text = "";
            txtTotalPrice.Text = "";
            getProductCategory();
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtTranId.Text == string.Empty)
            {

                string strMsg = "Please Enter Requisition ID!!!";
                MessageBox(strMsg);
                txtTranId.Focus();
                return;
            }
            else
            {
                searchRequisitionInfo();

            }
        }

        protected void gvPruductRequisition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPruductRequisition.PageIndex = e.NewPageIndex;
            loadRequisitionInfo();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPruductRequisition, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvPruductRequisition.SelectedRow.RowIndex;
            string strTranId = gvPruductRequisition.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strProductName = gvPruductRequisition.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strDeviceName = gvPruductRequisition.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string strRequisitionDate = gvPruductRequisition.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

            string strRequsitionQuantity = gvPruductRequisition.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string strQuantity = gvPruductRequisition.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string strDevicePrice = gvPruductRequisition.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            string strTotalPrice = gvPruductRequisition.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");


            txtTranId.Text = strTranId;     
           
            txtDeviceName.Text = strDeviceName;
            txtRequisitionDate.Text = strRequisitionDate;
            txtDevicePrice.Text = strDevicePrice;
            txtQuantity.Text = strQuantity;
            txtTotalPrice.Text = strTotalPrice;
            txtRequisitionQuantity.Text = strRequsitionQuantity;
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

        protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            getDeviceInfo();
        }

        protected void btnSheet_Click(object sender, EventArgs e)
        {

        }
    }
}