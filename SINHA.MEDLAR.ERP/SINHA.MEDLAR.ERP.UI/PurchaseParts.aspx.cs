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
using System.Collections.Specialized;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class PurchaseParts : System.Web.UI.Page
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
        string strReport = "";
        bool status;


        ReportDocument rd = new ReportDocument();

        string strDefaultName = "Report";
        ExportFormatType formatType = ExportFormatType.NoFormat;


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
                clearMsg();
                getOfficeName();
                getCurrentDate();

                //Commented by Asad
                //FirstGridViewRow();
                //BindParchaseList(null);
                CreateEmptyRow();

                getMachineIdParts();
                getSupplierInfo();
                getSupplierInfoSearch();
                getMachineIdPartsSearch();
                getEquipementId();
                loadPartsRecordSubAll();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
        }


        #region "Function"

        public void getEquipementId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEquipementId.DataSource = objLookUpBLL.getEquipementId(strHeadOfficeId, strBranchOfficeId);

            ddlEquipementId.DataTextField = "EQUIPMENT_NAME";
            ddlEquipementId.DataValueField = "EQUIPMENT_ID";

            ddlEquipementId.DataBind();
            if (ddlEquipementId.Items.Count > 0)
            {
                ddlEquipementId.SelectedIndex = 0;
            }
        }

        public void getMachineIdPartsSearch()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlMachineIdSearch.DataSource = objLookUpBLL.getMachineIdParts(strHeadOfficeId, strBranchOfficeId);

            ddlMachineIdSearch.DataTextField = "MACHINE_NAME";
            ddlMachineIdSearch.DataValueField = "MACHINE_ID";

            ddlMachineIdSearch.DataBind();
            if (ddlMachineIdSearch.Items.Count > 0)
            {
                ddlMachineIdSearch.SelectedIndex = 0;
            }

        }

        public void getMachineIdParts()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlMachineId.DataSource = objLookUpBLL.getMachineIdParts(strHeadOfficeId, strBranchOfficeId);

            ddlMachineId.DataTextField = "MACHINE_NAME";
            ddlMachineId.DataValueField = "MACHINE_ID";

            ddlMachineId.DataBind();
            if (ddlMachineId.Items.Count > 0)
            {
                ddlMachineId.SelectedIndex = 0;
            }
        }


        public void getSupplierInfoSearch()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSupplierIdSearch.DataSource = objLookUpBLL.getSupplierInfo(strHeadOfficeId, strBranchOfficeId);

            ddlSupplierIdSearch.DataTextField = "SUPPLIER_NAME";
            ddlSupplierIdSearch.DataValueField = "SUPPLIER_ID";

            ddlSupplierIdSearch.DataBind();
            if (ddlSupplierIdSearch.Items.Count > 0)
            {
                ddlSupplierIdSearch.SelectedIndex = 0;
            }
        }

        public void getSupplierInfo()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSupplierId.DataSource = objLookUpBLL.getSupplierInfo(strHeadOfficeId, strBranchOfficeId);

            ddlSupplierId.DataTextField = "SUPPLIER_NAME";
            ddlSupplierId.DataValueField = "SUPPLIER_ID";

            ddlSupplierId.DataBind();
            if (ddlSupplierId.Items.Count > 0)
            {
                ddlSupplierId.SelectedIndex = 0;
            }
        }


        //Commented by Asad
        private void CreateEmptyRow()
        {
               
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("rownum", typeof(string)));
            dt.Columns.Add(new DataColumn("PART_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("PARTICULAR_NAME", typeof(string)));

            dt.Columns.Add(new DataColumn("purchase_quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("unit_price", typeof(string)));
            dt.Columns.Add(new DataColumn("total_price", typeof(string)));

            dt.Columns.Add(new DataColumn("PO_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("CURRENCY_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("tran_id", typeof(string)));

            dt.Columns.Add(new DataColumn("currency_id", typeof(string)));
            dt.Columns.Add(new DataColumn("requisition_no", typeof(string)));
            dr = dt.NewRow();

            dr["rownum"] = string.Empty;
            dr["PART_NO"] = string.Empty;
            dr["PARTICULAR_NAME"] = string.Empty;

            dr["purchase_quantity"] = string.Empty;
            dr["unit_price"] = string.Empty;
            dr["total_price"] = string.Empty;

            dr["PO_NO"] = string.Empty;
            dr["CURRENCY_NAME"] = string.Empty;
            dr["TRAN_ID"] = string.Empty;

            dr["currency_id"] = string.Empty;
            dr["requisition_no"] = string.Empty;

            dt.Rows.Add(dr);

            gvPurchasePartsList.DataSource = dt;
            gvPurchasePartsList.DataBind();
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

        public void clearMessage()
        {
            lblMsg.Text = string.Empty;
        }
        public void clearTextBox()
        {
        }

        public void clearMsg()
        {
            lblMsg.Text = string.Empty;
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

        public void getCurrentDate()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            objLookUpDTO = objLookUpBLL.getCurrentDate();
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


        public void searchPurchasePartsMain()
        {
            PurchasePartsDTO objPurchaseDTO = new PurchasePartsDTO();
            PurchasePartsBLL objPurchaseBLL = new PurchasePartsBLL();

            DataTable dt = new DataTable();
            
            objPurchaseDTO = objPurchaseBLL.searchPurchasePartsMain(txtRefNo.Text, txtTranId.Text, ddlMachineId.SelectedValue.ToString(), ddlSupplierId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);
            
            if (objPurchaseDTO.MachineId != "0")
            {
                ddlMachineId.SelectedValue = objPurchaseDTO.MachineId;
            }
            else
            {
                getMachineIdParts();
            }

            if (objPurchaseDTO.SupplierId != "0")
            {
                ddlSupplierId.SelectedValue = objPurchaseDTO.SupplierId;
            }
            else
            {
                getSupplierInfo();
            }
        }

        //Commented by Asad
        //private void AddNewRow()
        //{
        //    int rowIndex = 0;

        //    if (ViewState["CurrentTable"] != null)
        //    {
        //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        //        DataRow drCurrentRow = null;
        //        if (dtCurrentTable.Rows.Count > 0)
        //        {
        //            for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
        //            {

        //                TextBox txtPartNo = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[1].FindControl("txtPartNo");
        //                TextBox txtPartName = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[2].FindControl("txtPartName");

        //                TextBox txtQuantity = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[3].FindControl("txtQuantity");
        //                TextBox txtUnitPrice = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[4].FindControl("txtUnitPrice");
        //                TextBox txtTotalPrice = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[5].FindControl("txtTotalPrice");
        //                TextBox txtPONo = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[6].FindControl("txtPONo");
        //                DropDownList ddlCurrencyId = (DropDownList)gvPoRequisition.Rows[rowIndex].Cells[7].FindControl("ddlCurrencyId");
        //                TextBox txtTranId = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[8].FindControl("txtTranId");



        //                drCurrentRow = dtCurrentTable.NewRow();
        //                //drCurrentRow["RowNumber"] = i + 1;
        //                dtCurrentTable.Rows[i - 1]["PART_NO"] = txtPartNo.Text;
        //                dtCurrentTable.Rows[i - 1]["PARTICULAR_NAME"] = txtPartName.Text;
        //                dtCurrentTable.Rows[i - 1]["purchase_quantity"] = txtQuantity.Text;
        //                dtCurrentTable.Rows[i - 1]["unit_price"] = txtUnitPrice.Text;
        //                dtCurrentTable.Rows[i - 1]["total_price"] = txtTotalPrice.Text;
        //                dtCurrentTable.Rows[i - 1]["PO_NO"] = txtPONo.Text;
        //                dtCurrentTable.Rows[i - 1]["CURRENCY_ID"] = ddlCurrencyId.Text;

        //                dtCurrentTable.Rows[i - 1]["TRAN_ID"] = dtCurrentTable.Rows[i - 1]["TRAN_ID"];

        //                rowIndex++;
        //            }
        //            dtCurrentTable.Rows.Add(drCurrentRow);
        //            ViewState["CurrentTable"] = dtCurrentTable;
        //            gvPoRequisition.DataSource = dtCurrentTable;
        //            gvPoRequisition.DataBind();

        //            TextBox strtxtPartNo = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[1].FindControl("txtPartNo");
        //            strtxtPartNo.Focus();
        //        }
        //    }
        //    else
        //    {
        //        Response.Write("ViewState is null");
        //    }
        //    //SetPreviousData();
        //}

        //Commented by Asad
        //private void SetPreviousData()
        //{
        //    int rowIndex = 0;
        //    if (ViewState["CurrentTable"] != null)
        //    {
        //        DataTable dt = (DataTable)ViewState["CurrentTable"];
        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {


        //                TextBox txtPartNo = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[1].FindControl("txtPartNo");
        //                TextBox txtPartName = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[2].FindControl("txtPartName");

        //                TextBox txtQuantity = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[3].FindControl("txtQuantity");
        //                TextBox txtUnitPrice = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[4].FindControl("txtUnitPrice");
        //                TextBox txtTotalPrice = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[5].FindControl("txtTotalPrice");
        //                TextBox txtPONo = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[6].FindControl("txtPONo");
        //                DropDownList ddlCurrencyId = (DropDownList)gvPoRequisition.Rows[rowIndex].Cells[7].FindControl("ddlCurrencyId");
        //                TextBox txtTranId = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[8].FindControl("txtTranId");


        //                txtPartNo.Text = dt.Rows[i]["PART_NO"].ToString();
        //                txtPartName.Text = dt.Rows[i]["PARTICULAR_NAME"].ToString();
        //                txtQuantity.Text = dt.Rows[i]["purchase_quantity"].ToString();
        //                txtUnitPrice.Text = dt.Rows[i]["unit_price"].ToString();
        //                txtTotalPrice.Text = dt.Rows[i]["total_price"].ToString();
        //                txtPONo.Text = dt.Rows[i]["PO_NO"].ToString();
        //                ddlCurrencyId.Text = dt.Rows[i]["CURRENCY_ID"].ToString();

        //                txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();

        //                rowIndex++;

        //            }
        //        }
        //    }
        //}

        public void deletePurchasePartsRecordAll()
        {
            
            PurchasePartsDTO objPurchasePartsDTO = new PurchasePartsDTO();
            PurchasePartsBLL objPurchasePartsBLL = new PurchasePartsBLL();
            
            if (ddlMachineId.Text != " ")
            {
                objPurchasePartsDTO.MachineId = ddlMachineId.SelectedValue.ToString();
            }
            else
            {
                objPurchasePartsDTO.MachineId = "";
            }

            if (ddlSupplierId.Text != " ")
            {
                objPurchasePartsDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objPurchasePartsDTO.SupplierId = "";
            }
            
            objPurchasePartsDTO.UpdateBy = strEmployeeId;
            objPurchasePartsDTO.HeadOfficeId = strHeadOfficeId;
            objPurchasePartsDTO.BranchOfficeId = strBranchOfficeId;
            string strMsg = objPurchasePartsBLL.deletePurchasePartsRecord(objPurchasePartsDTO);
            MessageBox(strMsg);
        }

             //<asp:BoundField DataField = "rownum" HeaderText="SL" HeaderStyle-Width="5%" ItemStyle-Width="5%"/>
             //<asp:BoundField DataField = "PART_NO" HeaderText="PART NUMBER" HeaderStyle-Width="12%" ItemStyle-Width="12%"/>
             //<asp:BoundField DataField = "PARTICULAR_NAME" HeaderText="PARTICULARS" HeaderStyle-Width="20%" ItemStyle-Width="20%"/>
             //<asp:BoundField DataField = "purchase_quantity" HeaderText="QUANTITY" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
             //<asp:BoundField DataField = "unit_price" HeaderText="UNIT PRICE" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
             //<asp:BoundField DataField = "total_price" HeaderText="TOTAL PRICE" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
             //<asp:BoundField DataField = "PO_NO" HeaderText="PO NO" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
             //<asp:BoundField DataField = "CURRENCY_NAME" HeaderText="CURRENCY" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
             //<asp:BoundField DataField = "TRAN_ID" HeaderText="TRX ID" HeaderStyle-Width="7%" ItemStyle-Width="7%"/>
             //<asp:BoundField DataField = "currency_id" HeaderText="currency_id" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn"/> 


        private void SavePurchaseParts()
        {
            PurchasePartsDTO objPurchaseDTO = new PurchasePartsDTO();
            PurchasePartsBLL objPurchaseBLL = new PurchasePartsBLL();

            int rowIndex = 0;
            string strMsg = "";

            StringCollection sc = new StringCollection();
           
                if (gvPurchasePartsList.Rows.Count > 0)
                {
                    for (int i = 1; i <= gvPurchasePartsList.Rows.Count; i++)
                    {
                        string txtPartNo = gvPurchasePartsList.Rows[rowIndex].Cells[1].Text;
                        string txtPartName = gvPurchasePartsList.Rows[rowIndex].Cells[2].Text;
                        string txtQuantity = gvPurchasePartsList.Rows[rowIndex].Cells[3].Text;
                        string txtUnitPrice = gvPurchasePartsList.Rows[rowIndex].Cells[4].Text;
                        string txtTotalPrice = gvPurchasePartsList.Rows[rowIndex].Cells[5].Text;
                        string txtPONo = gvPurchasePartsList.Rows[rowIndex].Cells[6].Text;
                        string currencyId = gvPurchasePartsList.Rows[rowIndex].Cells[9].Text;
                        string txtTranId = gvPurchasePartsList.Rows[rowIndex].Cells[8].Text;
                        string requisitionNo = gvPurchasePartsList.Rows[rowIndex].Cells[10].Text;
                    

                        objPurchaseDTO.PartNo = txtPartNo;
                        objPurchaseDTO.RequisitionNo = requisitionNo;
                        objPurchaseDTO.ParticularName = txtPartName;
                        objPurchaseDTO.PurchaseQuantity = txtQuantity;
                        objPurchaseDTO.UnitPrice = txtUnitPrice;
                        objPurchaseDTO.TotalPrice = txtTotalPrice;
                        objPurchaseDTO.PONo = txtPONo;
                        objPurchaseDTO.TranId = txtTranId;
                        objPurchaseDTO.CurrencyId = currencyId;

                        objPurchaseDTO.RefNo = txtRefNo.Text;

                        
                        if (ddlSupplierId.SelectedValue.ToString() != "")
                        {
                            objPurchaseDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
                        }
                        else
                        {
                            objPurchaseDTO.SupplierId = "";
                        }

                        if (ddlMachineId.SelectedValue.ToString() != "")
                        {
                            objPurchaseDTO.MachineId = ddlMachineId.SelectedValue.ToString();
                        }
                        else
                        {
                            objPurchaseDTO.MachineId = "";
                        }

                        objPurchaseDTO.UpdateBy = strEmployeeId;
                        objPurchaseDTO.HeadOfficeId = strHeadOfficeId;
                        objPurchaseDTO.BranchOfficeId = strBranchOfficeId;
                        strMsg = objPurchaseBLL.savePurchasePartsRecord(objPurchaseDTO);
                        lblMsg.Text = strMsg;
                        rowIndex++;
                    }
                    string input = strMsg;
                    string subStr = input.Substring(22);
                    txtRefNo.Text = subStr;

                    String substring = strMsg.Substring(0, 21);
                    MessageBox(substring);
                }
            
        }

        //Commented by Asad
        //public void savePurchasePartsRecord()
        //{
        //    PurchasePartsDTO objPurchaseDTO = new PurchasePartsDTO();
        //    PurchasePartsBLL objPurchaseBLL = new PurchasePartsBLL();

        //    int rowIndex = 0;
        //    string strMsg = "";

        //    StringCollection sc = new StringCollection();
        //    if (ViewState["CurrentTable"] != null)
        //    {
        //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        //        if (dtCurrentTable.Rows.Count > 0)
        //        {
        //            for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
        //            {
        //                TextBox txtPartNo = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[1].FindControl("txtPartNo");
        //                TextBox txtPartName = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[2].FindControl("txtPartName");

        //                TextBox txtQuantity = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[3].FindControl("txtQuantity");
        //                TextBox txtUnitPrice = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[4].FindControl("txtUnitPrice");
        //                TextBox txtTotalPrice = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[5].FindControl("txtTotalPrice");
        //                TextBox txtPONo = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[6].FindControl("txtPONo");
        //                DropDownList ddlCurrencyId = (DropDownList)gvPoRequisition.Rows[rowIndex].Cells[7].FindControl("ddlCurrencyId");
        //                TextBox txtTranId = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[8].FindControl("txtTranId");

        //                objPurchaseDTO.PONo = txtPONo.Text;
        //                objPurchaseDTO.TranId = txtTranId.Text;
        //                objPurchaseDTO.PartNo = txtPartNo.Text;
        //                objPurchaseDTO.ParticularName = txtPartName.Text;
        //                objPurchaseDTO.PurchaseQuantity = txtQuantity.Text;
        //                objPurchaseDTO.UnitPrice = txtUnitPrice.Text;
        //                objPurchaseDTO.TotalPrice = txtTotalPrice.Text;
        //                objPurchaseDTO.PONo = txtPONo.Text;
        //                objPurchaseDTO.RefNo = txtRefNo.Text;

        //                if (ddlCurrencyId.SelectedValue.ToString() != " ")
        //                {
        //                    objPurchaseDTO.CurrencyId = ddlCurrencyId.SelectedValue.ToString();
        //                }
        //                else
        //                {
        //                    objPurchaseDTO.CurrencyId = "";
        //                }

        //                if (ddlSupplierId.SelectedValue.ToString() != "")
        //                {
        //                    objPurchaseDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
        //                }
        //                else
        //                {
        //                    objPurchaseDTO.SupplierId = "";
        //                }

        //                if (ddlMachineId.SelectedValue.ToString() != "")
        //                {
        //                    objPurchaseDTO.MachineId = ddlMachineId.SelectedValue.ToString();
        //                }
        //                else
        //                {
        //                    objPurchaseDTO.MachineId = "";
        //                }

        //                objPurchaseDTO.UpdateBy = strEmployeeId;
        //                objPurchaseDTO.HeadOfficeId = strHeadOfficeId;
        //                objPurchaseDTO.BranchOfficeId = strBranchOfficeId;
        //                strMsg = objPurchaseBLL.savePurchasePartsRecord(objPurchaseDTO);
        //                //MessageBox(strMsg);
        //                lblMsg.Text = strMsg;
        //                rowIndex++;
        //            }
        //            string input = strMsg;
        //            string subStr = input.Substring(22);
        //            txtRefNo.Text = subStr;

        //            String substring = strMsg.Substring(0, 21);
        //            MessageBox(substring);
        //        }
        //    }
        //}

        //Commented by Asad
        //public void loadPartsRecordSub()
        //{

        //    PurchasePartsDTO objPurchasePartsDTO = new PurchasePartsDTO();
        //    PurchasePartsBLL objPurchasePartsBLL = new PurchasePartsBLL();

        //    DataTable dt = new DataTable();

        //    if (ddlMachineId.Text != " ")
        //    {
        //        objPurchasePartsDTO.MachineId = ddlMachineId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objPurchasePartsDTO.MachineId = "";
        //    }

        //    if (ddlSupplierId.Text != " ")
        //    {
        //        objPurchasePartsDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objPurchasePartsDTO.SupplierId = "";
        //    }

        //    objPurchasePartsDTO.RefNo = txtRefNo.Text;
        //    objPurchasePartsDTO.TranId = txtTranId.Text;

        //    objPurchasePartsDTO.HeadOfficeId = strHeadOfficeId;
        //    objPurchasePartsDTO.BranchOfficeId = strBranchOfficeId;
        //    dt = objPurchasePartsBLL.loadPartsRecordSub(objPurchasePartsDTO);

        //    if (dt.Rows.Count > 0)
        //    {
        //        gvPoRequisition.DataSource = dt;
        //        ViewState["CurrentTable"] = dt;
        //        gvPoRequisition.DataBind();
        //    }
        //    else
        //    {
        //        dt.Rows.Add(dt.NewRow());
        //        gvPoRequisition.DataSource = dt;
        //        gvPoRequisition.DataBind();

        //        //int totalcolums = gvPoRequisition2.Rows[0].Cells.Count;
        //        gvPoRequisition.Rows[0].Cells.Clear();
        //        gvPoRequisition.Rows[0].Cells.Add(new TableCell());
        //        //gvPoRequisition.Rows[0].Cells[0].ColumnSpan = totalcolums;
        //        gvPoRequisition.Rows[0].Cells[0].Text = "NO RECORD FOUND";

        //        string strMsg = "NO RECORD FOUND!!!";
        //        lblMsg.Text = strMsg;
        //    }
        //}
        public void loadPartsRecordSubAll()
        {
            PurchasePartsDTO objPurchasePartsDTO = new PurchasePartsDTO();
            PurchasePartsBLL objPurchasePartsBLL = new PurchasePartsBLL();

            DataTable dt = new DataTable();
            if (ddlMachineIdSearch.Text != " ")
            {
                objPurchasePartsDTO.MachineId = ddlMachineIdSearch.SelectedValue.ToString();
            }
            else
            {
                objPurchasePartsDTO.MachineId = "";
            }

            if (ddlEquipementId.Text != " ")
            {
                objPurchasePartsDTO.EquipmentId = ddlEquipementId.SelectedValue.ToString();
            }
            else
            {
                objPurchasePartsDTO.EquipmentId = "";
            }
            
            if (ddlSupplierIdSearch.Text != " ")
            {
                objPurchasePartsDTO.SupplierId = ddlSupplierIdSearch.SelectedValue.ToString();
            }
            else
            {
                objPurchasePartsDTO.SupplierId = "";
            }
            
            objPurchasePartsDTO.PartNo = txtPartNo.Text;
            objPurchasePartsDTO.PONo = txtPONo.Text;
            objPurchasePartsDTO.HeadOfficeId = strHeadOfficeId;
            objPurchasePartsDTO.BranchOfficeId = strBranchOfficeId;
            dt = objPurchasePartsBLL.loadPartsRecordSubAll(objPurchasePartsDTO);
            
            if (dt.Rows.Count > 0)
            {
                gvForeignFabric.Columns[11].Visible = true;
                gvForeignFabric.Visible = true;
                gvForeignFabric.DataSource = dt;
                gvForeignFabric.DataBind();
                gvForeignFabric.Columns[11].Visible = false;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvForeignFabric.DataSource = dt;
                gvForeignFabric.DataBind();

                //int totalcolums = gvPoRequisition2.Rows[0].Cells.Count;
                gvForeignFabric.Rows[0].Cells.Clear();
                gvForeignFabric.Rows[0].Cells.Add(new TableCell());
                //gvPoRequisition.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvForeignFabric.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                lblMsg.Text = strMsg;
            }
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlMachineId.Text == " ")
            {
                string strMsg = "Please Select Machine Name!!!";
                ddlMachineId.Focus();
                MessageBox(strMsg);
                return;
            }

            else if (ddlSupplierId.Text == " ")
            {
                string strMsg = "Please Select Supplier Name!!!";
                ddlSupplierId.Focus();
                MessageBox(strMsg);
                return;
            }
            else
            {
                //Commented by Asad
                //loadPartsRecordSub();


            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Commented by Asad
            //AddNewRow();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlMachineId.Text == " ")
            {
                string strMsg = "Please Select Machine Name!!!";
                ddlMachineId.Focus();
                MessageBox(strMsg);
                return;
            }

            else if (ddlSupplierId.Text == " ")
            {
                string strMsg = "Please Select Supplier Name!!!";
                ddlSupplierId.Focus();
                MessageBox(strMsg);
                return;
            }
            else
            {
                //Commented by Asad and USE FOR NEXT VERSION
                //savePurchasePartsRecord();

                SavePurchaseParts();

                clear();
                txtTranId.Text = "";
                loadPartsRecordSubAll();
            }
        }

        public void clear()
        {
            //Commented by Asad
            //int rowIndex = 0;            
            //TextBox txtPartNo = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[1].FindControl("txtPartNo");
            //TextBox txtPartName = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[2].FindControl("txtPartName");
            //TextBox txtQuantity = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[3].FindControl("txtQuantity");
            //TextBox txtUnitPrice = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[4].FindControl("txtUnitPrice");
            //TextBox txtTotalPrice = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[5].FindControl("txtTotalPrice");
            //TextBox txtPONo = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[6].FindControl("txtPONo");
            //DropDownList ddlCurrencyId = (DropDownList)gvPoRequisition.Rows[rowIndex].Cells[7].FindControl("ddlCurrencyId");
            //TextBox txtTranId = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[8].FindControl("txtTranId");

            //Commented by Asad
            //txtPartName.Text = "";
            //txtQuantity.Text = "";
            //txtUnitPrice.Text = "";
            //txtTotalPrice.Text = "";

            txtPONo.Text = "";
            txtPartNo.Text = "";
            txtTranId.Text = "";
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
        }
        //protected void btnDelete_Click(object sender, EventArgs e)
        //{

        //    if (ddlMachineId.Text == "")
        //    {
        //        string strMsg = "Please Select Machine Name!!!";
        //        ddlMachineId.Focus();
        //        MessageBox(strMsg);
        //        return;
        //    }

        //    else if (ddlSupplierId.Text == "")
        //    {
        //        string strMsg = "Please Select Supplier Name!!!";
        //        ddlSupplierId.Focus();
        //        MessageBox(strMsg);
        //        return;
        //    }
        //    else
        //    {
        //        deletePurchasePartsRecordAll();
        //        searchPurchasePartsMain();
        //        //Commented by Asad
        //        //loadPartsRecordSub();
        //    }
        //}
        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {

        }


        #region "Grid View Functionality"
        //Commented by Asad
        //protected void gvPoRequisition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvPoRequisition.PageIndex = e.NewPageIndex;
        //}

        //Commented by Asad
        //protected void gvPoRequisition_OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    PoRequisitionDTO objPoRequisitionDTO = new PoRequisitionDTO();
        //    PoRequisitionBLL objPoRequisitionBLL = new PoRequisitionBLL();

        //    TextBox txtPartNo = (TextBox)gvPoRequisition.SelectedRow.FindControl("txtPartNo");

        //    lblCountgvRow.Text = gvPoRequisition.SelectedIndex.ToString();

        //    DataTable dt = new DataTable();

        //    objPoRequisitionDTO.PartNo = txtPartNo.Text; ;
        //    objPoRequisitionDTO.HeadOfficeId = strHeadOfficeId;
        //    objPoRequisitionDTO.BranchOfficeId = strBranchOfficeId;

        //    dt = objPoRequisitionBLL.LoadPartNo(objPoRequisitionDTO);
        //    if (dt.Rows.Count > 0)
        //    {
        //        gvPoRequisition2.Visible = true;
        //        gvPoRequisition2.DataSource = dt;
        //        gvPoRequisition2.DataBind();
        //    }
        //    else
        //    {
        //        dt.Rows.Add(dt.NewRow());
        //        gvPoRequisition2.DataSource = dt;
        //        gvPoRequisition2.DataBind();
        //        int totalcolums = gvPoRequisition2.Rows[0].Cells.Count;
        //        gvPoRequisition2.Rows[0].Cells.Clear();
        //        gvPoRequisition2.Rows[0].Cells.Add(new TableCell());
        //        gvPoRequisition2.Rows[0].Cells[0].ColumnSpan = totalcolums;
        //        gvPoRequisition2.Rows[0].Cells[0].Text = "NO RECORD FOUND";

        //        string strMsg = "NO RECORD FOUND!!!";
        //        //MessageBox(strMsg);
        //        lblMsg.Text = strMsg;
        //    }
        //}
        protected void gvPoRequisition_OnRowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvPoRequisition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void gvPoRequisition_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                try
                {

                    LookUpBLL objLookUpBLL = new LookUpBLL();

                    DropDownList b = (e.Row.FindControl("ddlCurrencyId") as DropDownList);

                    DataTable dt = new DataTable();
                    DataRowView dr = e.Row.DataItem as DataRowView;

                    dt = objLookUpBLL.getCurrencyId(strHeadOfficeId, strBranchOfficeId);
                    b.DataSource = dt;
                    b.DataBind();
                    b.SelectedValue = dr["CURRENCY_ID"].ToString();
                }
                catch (Exception ex)
                {

                }
        }


        #endregion


        protected void btnSearchRecord_Click(object sender, EventArgs e)
        {
            loadPartsRecordSubAll();
        }
        protected void gvPoRequisition_OnSelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
        }


        protected void gvSrcPoRequisition_OnSelectedIndexChanged(object sender, EventArgs e)
        {


        }

        //Commented by Asad
        //protected void gvPoRequisition_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{

        //    int stor_id = Convert.ToInt32(gvPoRequisition.DataKeys[e.RowIndex].Value.ToString());
        //    string strSlNoId = Convert.ToString(stor_id);

        //    deletePoRequisitionSubRecord(strSlNoId);
        //    searchPurchasePartsMain();
        //    loadPartsRecordSub();
        //    loadPartsRecordSubAll();
        //}
        public void deletePoRequisitionSubRecord(string strSlNoId)
        {

            PurchasePartsDTO objPurchasePartsDTO = new PurchasePartsDTO();
            PurchasePartsBLL objPurchasePartsBLL = new PurchasePartsBLL();

            objPurchasePartsDTO.RefNo = txtRefNo.Text;
            objPurchasePartsDTO.TranId = strSlNoId;

            if (ddlSupplierId.SelectedValue.ToString() != "")
            {
                objPurchasePartsDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objPurchasePartsDTO.SupplierId = "";
            }

            if (ddlMachineId.SelectedValue.ToString() != "")
            {
                objPurchasePartsDTO.MachineId = ddlMachineId.SelectedValue.ToString();
            }
            else
            {
                objPurchasePartsDTO.MachineId = "";
            }

            objPurchasePartsDTO.UpdateBy = strEmployeeId;
            objPurchasePartsDTO.HeadOfficeId = strHeadOfficeId;
            objPurchasePartsDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objPurchasePartsBLL.deletePurchasePartsRecordById(objPurchasePartsDTO);
            MessageBox(strMsg);
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            //try
            //{


            //    rptPoRequisition();


            //}
            //catch (Exception ex)
            //{

            //    this.CrystalReportViewer1.Dispose();
            //    this.CrystalReportViewer1 = null;
            //    rd.Dispose();
            //    rd.Close();
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();


            //}
        }

        //Commented by Asad
        //protected void gvPoRequisition2_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
        //        e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

        //        e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPoRequisition2, "Select$" + e.Row.RowIndex);
        //    }
        //}


        //Commented by Asad
        //public void gvPoRequisition2_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    string txtSearchPartNo = gvPoRequisition2.SelectedRow.Cells[0].Text;
        //    string txtSrcPartName = gvPoRequisition2.SelectedRow.Cells[1].Text;

        //    int CountgvRow = Convert.ToInt32(lblCountgvRow.Text);

        //    TextBox txtPartNo = (TextBox)gvPoRequisition.Rows[CountgvRow].FindControl("txtPartNo");
        //    TextBox txtPartName = (TextBox)gvPoRequisition.Rows[CountgvRow].FindControl("txtPartName");


        //    txtPartNo.Text = txtSearchPartNo;
        //    txtPartName.Text = txtSrcPartName;

        //    TextBox strtxtPresentStock = (TextBox)gvPoRequisition.Rows[CountgvRow].FindControl("txtQuantity");
        //    strtxtPresentStock.Focus();

        //    gvPoRequisition2.Visible = false;


        //}


        protected void gvPoRequisition3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[0].BackColor = Color.FromName("#BAD7E6");

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPoRequisition3, "Select$" + e.Row.RowIndex);
            }
        }
        protected void gvPoRequisition3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void gvForeignFabric_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvForeignFabric_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        protected void gvForeignFabric_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvForeignFabric.SelectedRow.RowIndex + 1;
            string strRefNo = gvForeignFabric.SelectedRow.Cells[10].Text;
            string strTranId = gvForeignFabric.SelectedRow.Cells[11].Text;

            txtRefNo.Text = strRefNo;
            txtTranId.Text = strTranId;

            searchPurchasePartsMain();
            //Commented by Asad
            //loadPartsRecordSub();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtTranId.Text = "";
        }

        protected void btnClear_Click1(object sender, EventArgs e)
        {
            clear();
            txtTranId.Text = "";
        }

        protected void gvPurchasePartsList_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvPurchasePartsList_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //    try
            //    {

            //        LookUpBLL objLookUpBLL = new LookUpBLL();
            //        DropDownList b = (e.Row.FindControl("ddlCurrencyId") as DropDownList);
            //        DataTable dt = new DataTable();
            //        DataRowView dr = e.Row.DataItem as DataRowView;

            //        dt = objLookUpBLL.getCurrencyId(strHeadOfficeId, strBranchOfficeId);
            //        b.DataSource = dt;
            //        b.DataBind();
            //        b.SelectedValue = dr["CURRENCY_ID"].ToString();
            //    }
            //    catch (Exception ex)
            //    {
            //    }
        }
        protected void gvPurchasePartsList_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void btnSearchPoRequisitionNo_Click(object sender, EventArgs e)
        {
            try
            {
                PoOrderDTO objPoOrderDTO = new PoOrderDTO();
                PoOrderBLL objPoOrderBLL = new PoOrderBLL();

                DataTable dt = new DataTable();
                dt = objPoOrderBLL.GetRequisitionInfo(txtPoRequisitionNo.Text, strEmployeeId, strHeadOfficeId, strBranchOfficeId);
                BindParchaseList(dt);
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnPoList_Click(object sender, EventArgs e)
        {
            try
            {
                PoOrderDTO objPoOrderDTO = new PoOrderDTO();
                PoOrderBLL objPoOrderBLL = new PoOrderBLL();

                DataTable dt = new DataTable();
                dt = objPoOrderBLL.GetOrderByOrderId(txtPoNumber.Text, strEmployeeId, strHeadOfficeId, strBranchOfficeId);
                BindParchaseList(dt);
            }
            catch (Exception ex)
            {
            }
        }

        private void BindParchaseList(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                gvPurchasePartsList.DataSource = dt;
                gvPurchasePartsList.DataBind();

                int count = ((DataTable)gvPurchasePartsList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPurchasePartsList.DataSource = dt;
                gvPurchasePartsList.DataBind();
                int totalcolums = gvPurchasePartsList.Rows[0].Cells.Count;
                gvPurchasePartsList.Rows[0].Cells.Clear();
                gvPurchasePartsList.Rows[0].Cells.Add(new TableCell());
                gvPurchasePartsList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPurchasePartsList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                lblMsg.Text = strMsg;
            }
        }

        protected void txtPoRequisitionNo_TextChanged(object sender, EventArgs e)
        {

            //lblPoRequisitionNo.Style["margin-top"] = "-31px";
            //lblPoRequisitionNo.Style["position"] = "absolute";
            //lblPoRequisitionNo.Style["margin-left"] = "-90px";

            //PoOrderBLL objPoTrackingBLL = new PoOrderBLL();

            //DataTable dt = new DataTable();
            //string PoRequisitionNo = "";
            //PoRequisitionNo = txtPoRequisitionNo.Text;

            //dt = objPoTrackingBLL.SearchPoRequisitionNo(PoRequisitionNo, strHeadOfficeId, strBranchOfficeId);


            //if (dt.Rows.Count > 0)
            //{
            //    gvPoOrderSearch1.Visible = true;

            //    gvPoOrderSearch1.DataSource = dt;
            //    ViewState["CurrentTable"] = dt;

            //    gvPoOrderSearch1.DataBind();

            //}
            //else
            //{
            //    dt.Rows.Add(dt.NewRow());
            //    gvPoOrderSearch1.DataSource = dt;
            //    gvPoOrderSearch1.DataBind();
            //    int totalcolums = gvPoOrderSearch1.Rows[0].Cells.Count;
            //    gvPoOrderSearch1.Rows[0].Cells.Clear();
            //    gvPoOrderSearch1.Rows[0].Cells.Add(new TableCell());
            //    gvPoOrderSearch1.Rows[0].Cells[0].ColumnSpan = totalcolums;
            //    gvPoOrderSearch1.Rows[0].Cells[0].Text = "NO RECORD FOUND";

            //    string strMsg = "NO RECORD FOUND!!!";
            //    lblMsg.Text = strMsg;
            //}
        }

        protected void txtPoNumber_TextChanged(object sender, EventArgs e)
        {
            //txtPoNumber.Focus();

            //lblPoNo.Style["margin-top"] = "-31px";
            //lblPoNo.Style["position"] = "absolute";
            //lblPoNo.Style["margin-left"] = "-90px";

            //PoOrderBLL objPoTrackingBLL = new PoOrderBLL();

            //DataTable dt = new DataTable();
            //string PoNo = "";
            //PoNo = txtPoNumber.Text;

            //dt = objPoTrackingBLL.SearchPoNo(PoNo, strHeadOfficeId, strBranchOfficeId);


            //if (dt.Rows.Count > 0)
            //{
            //    gvPoOrderSearch2.Visible = true;

            //    gvPoOrderSearch2.DataSource = dt;
            //    ViewState["CurrentTable"] = dt;
            //    gvPoOrderSearch2.DataBind();

            //}
            //else
            //{
            //    dt.Rows.Add(dt.NewRow());
            //    gvPoOrderSearch2.DataSource = dt;
            //    gvPoOrderSearch2.DataBind();
            //    int totalcolums = gvPoOrderSearch2.Rows[0].Cells.Count;
            //    gvPoOrderSearch2.Rows[0].Cells.Clear();
            //    gvPoOrderSearch2.Rows[0].Cells.Add(new TableCell());
            //    gvPoOrderSearch2.Rows[0].Cells[0].ColumnSpan = totalcolums;
            //    gvPoOrderSearch2.Rows[0].Cells[0].Text = "NO RECORD FOUND";

            //    string strMsg = "NO RECORD FOUND!!!";
            //    lblMsg.Text = strMsg;
            //}
        }

    }
}