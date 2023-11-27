using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Web.Security;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class PurchaseOrderEntry: System.Web.UI.Page
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
                getSizeIdForPOPrice();
                getSizeIdForQuantity();
                getShippingId();
                getItemId();
                getOfficeName();
                getPercentAmount();
                clearMsg();
              
                getStyle();
                txtPrice.Attributes.Add("onKeyPress",
                  "doClick('" + btnCalculate.ClientID + "',event)");
            }

            if (IsPostBack)
            {

                loadSesscion();
            }

          

            txtPONo.Attributes.Add("onkeypress", "return controlEnter('" + txtStyleNo.ClientID + "', event)");
            txtStyleNo.Attributes.Add("onkeypress", "return controlEnter('" + dtpDeliveryDate.ClientID + "', event)");
            dtpDeliveryDate.Attributes.Add("onkeypress", "return controlEnter('" + txtQuantity.ClientID + "', event)");
            txtQuantity.Attributes.Add("onkeypress", "return controlEnter('" + txtPrice.ClientID + "', event)");
            txtPrice.Attributes.Add("onkeypress", "return controlEnter('" + txtHangerCostPrice.ClientID + "', event)");
         

        }


        #region "Function"
        public void SetInputFocus()
        {
            TextBox tbox = this.FindControl("txtPONo") as TextBox;
            if (tbox != null)
            {
                ScriptManager.GetCurrent(this.Page).SetFocus(tbox);
            }
        }

        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;


        }
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


        public void getSizeIdForQuantity()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();



            ddlSizeIdForQuantity.DataSource = objLookUpBLL.getSizeId();

            ddlSizeIdForQuantity.DataTextField = "SIZE_NAME";
            ddlSizeIdForQuantity.DataValueField = "SIZE_ID";

            ddlSizeIdForQuantity.DataBind();
            if (ddlSizeIdForQuantity.Items.Count > 0)
            {

                ddlSizeIdForQuantity.SelectedIndex = 0;
            }


        }

        public void getSizeIdForPOPrice()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();



            ddlSizeIdForPOPrice.DataSource = objLookUpBLL.getSizeId();

            ddlSizeIdForPOPrice.DataTextField = "SIZE_NAME";
            ddlSizeIdForPOPrice.DataValueField = "SIZE_ID";

            ddlSizeIdForPOPrice.DataBind();
            if (ddlSizeIdForPOPrice.Items.Count > 0)
            {

                ddlSizeIdForPOPrice.SelectedIndex = 0;
            }


        }
        public void getShippingId()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();



            ddlShipingAddressId.DataSource = objLookUpBLL.getShippingId();

            ddlShipingAddressId.DataTextField = "SHIPPING_ADDRESS";
            ddlShipingAddressId.DataValueField = "SHIPPING_ID";

            ddlShipingAddressId.DataBind();
            if (ddlShipingAddressId.Items.Count > 0)
            {

                ddlShipingAddressId.SelectedIndex = 0;
            }


        }


        public void getItemId()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();



            ddlItemDescriptionId.DataSource = objLookUpBLL.getItemId();

            ddlItemDescriptionId.DataTextField = "ITEM_NAME";
            ddlItemDescriptionId.DataValueField = "ITEM_ID";

            ddlItemDescriptionId.DataBind();
            if (ddlItemDescriptionId.Items.Count > 0)
            {

                ddlItemDescriptionId.SelectedIndex = 0;
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



        public void getPercentAmount()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getPercentAmount(strHeadOfficeId, strBranchOfficeId);

            txtPercentAmount.Text = objLookUpDTO.PercentAmount;



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




        public void clear()
        {
            txtPONo.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
           
            dtpDeliveryDate.Text = string.Empty;
            txtHangerCostPrice.Text = string.Empty;
            txtUnitCost.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
           
         


        }

        public void calculatetTotalAmount()
        {
            if (txtQuantity.Text == string.Empty)
            {
                txtQuantity.Text = "0";
            }
            if (txtUnitCost.Text == string.Empty)
            {
                txtUnitCost.Text = "0";

            }


            txtTotalAmount.Text = Convert.ToString(Convert.ToInt32(txtQuantity.Text) * Convert.ToInt32(txtUnitCost.Text));


        }
        public void calculateUnitCostPrice()
        {

            if (txtPrice.Text == string.Empty)
            {
                txtPrice.Text = "0";

            }
            if (txtPercentAmount.Text == string.Empty)
            {
                txtPercentAmount.Text = "0";

            }


            txtUnitCost.Text = Convert.ToString((Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(txtPercentAmount.Text)) / 100);


        }

        public void saveContactEntrySheet()
        {

            PurchaseOrderDTO objPurchaseOrderDTO = new PurchaseOrderDTO();
            PurchaseOrderBLL objPurchaseOrderBLL = new PurchaseOrderBLL();


            objPurchaseOrderDTO.PONo = txtPONo.Text;
            objPurchaseOrderDTO.StyleNo = txtStyleNo.Text;
            objPurchaseOrderDTO.DeliveryDate = dtpDeliveryDate.Text;
            objPurchaseOrderDTO.Quantity = txtQuantity.Text;
            objPurchaseOrderDTO.Price = txtPrice.Text;

            if (ddlSizeIdForPOPrice.SelectedValue.ToString() != " ")
            {
                objPurchaseOrderDTO.sizeIdForQuantity = ddlSizeIdForQuantity.SelectedValue.ToString();

            }
            else
            {

                objPurchaseOrderDTO.sizeIdForQuantity = "";

            }


            if (ddlSizeIdForPOPrice.SelectedValue.ToString() != " ")
            {
                objPurchaseOrderDTO.SizeIdForPOPrice = ddlSizeIdForPOPrice.SelectedValue.ToString();

            }
            else
            {

                objPurchaseOrderDTO.SizeIdForPOPrice = "";

            }

            if (ddlItemDescriptionId.SelectedValue.ToString() != " ")
            {
                objPurchaseOrderDTO.ItemDesciptionId = ddlItemDescriptionId.SelectedValue.ToString();

            }
            else
            {

                objPurchaseOrderDTO.ItemDesciptionId = "";

            }

            if (ddlShipingAddressId.SelectedValue.ToString() != " ")
            {
                objPurchaseOrderDTO.ShippingAddressId = ddlShipingAddressId.SelectedValue.ToString();

            }
            else
            {

                objPurchaseOrderDTO.ShippingAddressId = "";

            }




            objPurchaseOrderDTO.HangerCost = txtHangerCostPrice.Text;
            objPurchaseOrderDTO.UnitCost = txtUnitCost.Text;
            objPurchaseOrderDTO.Amount = txtTotalAmount.Text;




            objPurchaseOrderDTO.UpdateBy = strEmployeeId;
            objPurchaseOrderDTO.HeadOfficeId = strHeadOfficeId;
            objPurchaseOrderDTO.BranchOfficeId = strBranchOfficeId;



            string strMsg = objPurchaseOrderBLL.purchasOrderSave(objPurchaseOrderDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);




        }


        public void searchPOInfo()
        {

            //POEntryDTO objPOEntryDTO = new POEntryDTO();
            //POEntryBLL objPOEntryBLL = new POEntryBLL();

            //DataTable dt = new DataTable();

            //objPOEntryDTO.PONo = txtPO.Text;
            

            //if (ddlStyle.SelectedValue.ToString() != " ")
            //{
            //    objPOEntryDTO.StyleNo = ddlStyle.SelectedValue.ToString();
            //}
            //else
            //{
            //    objPOEntryDTO.StyleNo = "";

            //}

            //objPOEntryDTO.POFromDate = dtpPOFromDate.Text;
            //objPOEntryDTO.POToDate = dtpPOToDate.Text;

            //objPOEntryDTO.UpdateBy = strEmployeeId;
            //objPOEntryDTO.HeadOfficeId = strHeadOfficeId;
            //objPOEntryDTO.BranchOfficeId = strBranchOfficeId;

            //dt = objPOEntryBLL.searchPOInfo(objPOEntryDTO);


            //if (dt.Rows.Count > 0)
            //{
            //    gvUnit.DataSource = dt;
            //    gvUnit.DataBind();
            //    string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
            //    //MessageBox(strMsg);
            //    lblMsg.Text = strMsg;
            //}
            //else
            //{
            //    dt.Rows.Add(dt.NewRow());
            //    gvUnit.DataSource = dt;
            //    gvUnit.DataBind();
            //    int totalcolums = gvUnit.Rows[0].Cells.Count;
            //    gvUnit.Rows[0].Cells.Clear();
            //    gvUnit.Rows[0].Cells.Add(new TableCell());
            //    gvUnit.Rows[0].Cells[0].ColumnSpan = totalcolums;
            //    gvUnit.Rows[0].Cells[0].Text = "NO RECORD FOUND";

            //    string strMsg = "NO RECORD FOUND!!!";
            //    MessageBox(strMsg);
            //    lblMsg.Text = strMsg;

            //}






        }


      

        public void getStyle()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            string strBuyerId = "";
            if (ddlStyle.SelectedValue.ToString() != " ")
            {

                strBuyerId = ddlStyle.SelectedValue.ToString();

            }
            else
            {

                strBuyerId = "";


            }
            ddlStyle.DataSource = objLookUpBLL.getStyleId();

            ddlStyle.DataTextField = "STYLE_NO";
            ddlStyle.DataValueField = "STYLE_ID";

            ddlStyle.DataBind();
            if (ddlStyle.Items.Count > 0)
            {

                ddlStyle.SelectedIndex = 0;
            }


        }


        public void searchPurchaseOrderEntry()
        {



            PurchaseOrderDTO objPurchaseOrderDTO = new PurchaseOrderDTO();
            PurchaseOrderBLL objPurchaseOrderBLL = new PurchaseOrderBLL();
            DataTable dt = new DataTable();


            objPurchaseOrderDTO.PONo = txtPONo.Text;
            objPurchaseOrderDTO.HeadOfficeId = strHeadOfficeId;
            objPurchaseOrderDTO.BranchOfficeId = strBranchOfficeId;

            dt = objPurchaseOrderBLL.searchPurchaseOrderEntry(objPurchaseOrderDTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                string strMsg = "TOTAL " + GridView1.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int totalcolums = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridView1.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }




        }

        #endregion


        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPONo.Text == string.Empty)
                {
                    string strMsg = "Please Enter PO NO!!!";
                    txtPONo.Focus();
                    MessageBox(strMsg);
                    return; 

                }
                else if (txtStyleNo.Text == string.Empty)
                {
                    string strMsg = "Please Enter Style NO!!!";
                    txtStyleNo.Focus();
                    MessageBox(strMsg);
                    return;


                }

                else if (ddlSizeIdForQuantity.Text == " ")
                {
                    string strMsg = "Please Enter Size for Quantity!!!";
                    ddlSizeIdForQuantity.Focus();
                    MessageBox(strMsg);
                    return;


                }

                else if (ddlSizeIdForPOPrice.Text == " ")
                {
                    string strMsg = "Please Enter Size for PO Price!!!";
                    ddlSizeIdForPOPrice.Focus();
                    MessageBox(strMsg);
                    return;


                }

                else
                {


                    saveContactEntrySheet();
                    searchPurchaseOrderEntry();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {


                searchPurchaseOrderEntry();

                

            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                calculateUnitCostPrice();
                calculatetTotalAmount();

            }
            catch (Exception ex)
            {

                throw new Exception("Error : " +ex.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                searchPOInfo();
               
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }




        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            searchPOInfo();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strPONo = gvUnit.SelectedRow.Cells[1].Text;


            txtPONo.Text = strPONo;


        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
            // loadLineRecord();
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

     

        #endregion

        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //searchIncrementHoldInfo();
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //int strRowId = GridView1.SelectedRow.RowIndex;
            //string strPONo = GridView1.SelectedRow.Cells[1].Text;
            //string strPODate = GridView1.SelectedRow.Cells[2].Text;
            //string strPOType = GridView1.SelectedRow.Cells[3].Text;
            //string strBuyerName = GridView1.SelectedRow.Cells[4].Text;
            //string strStyleNo = GridView1.SelectedRow.Cells[5].Text;
            //string strColorName = GridView1.SelectedRow.Cells[6].Text;
            //string strUnitRate = GridView1.SelectedRow.Cells[7].Text;
            //string strQuantity = GridView1.SelectedRow.Cells[8].Text;
            //string strRemarks = GridView1.SelectedRow.Cells[9].Text;

            //txtPONo.Text = strPONo;
            //dtpPODate.Text = strPODate;
            //txtUnitRate.Text = strUnitRate;
            //txtQuantity.Text = strQuantity;
            //txtReamrks.Text = strRemarks;






        }

        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }







        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }



        protected void GridView1_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }

        #endregion

        protected void btnContactSheet_Click(object sender, EventArgs e)
        {

        }

    }
}