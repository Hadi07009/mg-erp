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
    public partial class ADDProductPrice : System.Web.UI.Page
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
                loadProductInfo();
                getOfficeName();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }
            txtDevicePrice.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtProductName.Text == string.Empty || txtDeviceName.Text == string.Empty || txtDevicePrice.Text == string.Empty)
            {

                string strMsg = "Please Enter The Product Name , Device Name and Price!!!";
                MessageBox(strMsg);
                txtProductName.Focus();
                return ;
            }
            else
            {
                saveProductInfo();
                loadProductInfo();
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
        public void saveProductInfo()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.ProductTranId = txtProductTranId.Text;
            objLookUpDTO.ProductName = txtProductName.Text;
            objLookUpDTO.DeviceName = txtDeviceName.Text;
            objLookUpDTO.DevicePrice = txtDevicePrice.Text;


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.saveProductInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void searchProductInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchProductInfo(txtProductTranId.Text);

            txtProductTranId.Text = objLookUpDTO.ProductTranId;
            txtProductName.Text = objLookUpDTO.ProductName;
            txtDeviceName.Text = objLookUpDTO.DeviceName;
            txtDevicePrice.Text = objLookUpDTO.DevicePrice;

        }

        public void loadProductInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadProductInfo(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvProductPrice.DataSource = dt;
                gvProductPrice.DataBind();
                string strMsg = "TOTAL " + gvProductPrice.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvProductPrice.DataSource = dt;
                gvProductPrice.DataBind();
                int totalcolums = gvProductPrice.Rows[0].Cells.Count;
                gvProductPrice.Rows[0].Cells.Clear();
                gvProductPrice.Rows[0].Cells.Add(new TableCell());
                gvProductPrice.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvProductPrice.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtProductTranId.Text = "";
            txtProductName.Text = "";
            txtDeviceName.Text = "";
            txtDevicePrice.Text = "";
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtProductTranId.Text == string.Empty)
            {

                string strMsg = "Please Enter Product Tran ID!!!";
                MessageBox(strMsg);
                txtProductTranId.Focus();
                return;
            }
            else
            {
                searchProductInfo();

            }
        }

        protected void gvProductPrice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductPrice.PageIndex = e.NewPageIndex;
            loadProductInfo();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvProductPrice, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvProductPrice.SelectedRow.RowIndex;
            string strProductTranId = gvProductPrice.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strProductName = gvProductPrice.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strDeviceName = gvProductPrice.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string strDevicePrice = gvProductPrice.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");


            txtProductTranId.Text = strProductTranId;
            txtProductName.Text = strProductName;
            txtDeviceName.Text = strDeviceName;
            txtDevicePrice.Text = strDevicePrice;
            
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