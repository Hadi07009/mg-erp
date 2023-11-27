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


using System.IO;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ForeignFabricReceive : System.Web.UI.Page
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
                FirstGridViewRow();
                getBuyerId();
                getBuyerIdSearch();
                getSupplierId();
                getSupplierIdSearch();
                getImporterId();
                getImporterIdSearch();
                getShipmentTypeId();
                getShipmentTypeIdSearch();
                getBranchOfficeName();
                getCurrentYear();


            }

            if (IsPostBack)
            {

                loadSesscion();

            }



            gvContractDetails.Columns[12].Visible = false;



        }


        #region "Function"

        public void getCurrentYear()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYear();

            txtYear.Text = objLookUpDTO.Year;




        }

        public void getBranchOfficeName()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBranchOfficeId.DataSource = objLookUpBLL.getBranchOfficeId(strHeadOfficeId);
            ddlBranchOfficeId.DataTextField = "BRANCH_OFFICE_NAME";
            ddlBranchOfficeId.DataValueField = "BRANCH_OFFICE_ID";
            ddlBranchOfficeId.DataBind();
            if (ddlBranchOfficeId.Items.Count > 0)
            {
                ddlBranchOfficeId.SelectedIndex = 0;
            }
        }

        public void getBuyerId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerId.DataSource = objLookUpBLL.getBuyerIdStore(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerId.DataTextField = "BUYER_NAME";
            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {

                ddlBuyerId.SelectedIndex = 0;
            }


        }

        public void getBuyerIdSearch()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerIdSearch.DataSource = objLookUpBLL.getBuyerIdSearch(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerIdSearch.DataTextField = "BUYER_NAME";
            ddlBuyerIdSearch.DataValueField = "BUYER_ID";

            ddlBuyerIdSearch.DataBind();
            if (ddlBuyerIdSearch.Items.Count > 0)
            {

                ddlBuyerIdSearch.SelectedIndex = 0;
            }


        }
        public void getSupplierId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSupplierId.DataSource = objLookUpBLL.getSupplierId();

            ddlSupplierId.DataTextField = "SUPPLIER_NAME";
            ddlSupplierId.DataValueField = "SUPPLIER_ID";

            ddlSupplierId.DataBind();
            if (ddlSupplierId.Items.Count > 0)
            {

                ddlSupplierId.SelectedIndex = 0;
            }


        }

        public void getSupplierIdSearch()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSupplierIdSearch.DataSource = objLookUpBLL.getSupplierIdSearch(strHeadOfficeId, strBranchOfficeId);

            ddlSupplierIdSearch.DataTextField = "SUPPLIER_NAME";
            ddlSupplierIdSearch.DataValueField = "SUPPLIER_ID";

            ddlSupplierIdSearch.DataBind();
            if (ddlSupplierIdSearch.Items.Count > 0)
            {

                ddlSupplierIdSearch.SelectedIndex = 0;
            }


        }


        public void getImporterId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlImporterId.DataSource = objLookUpBLL.getImporterId();

            ddlImporterId.DataTextField = "IMPORTER_NAME";
            ddlImporterId.DataValueField = "IMPORTER_ID";

            ddlImporterId.DataBind();
            if (ddlImporterId.Items.Count > 0)
            {

                ddlImporterId.SelectedIndex = 0;
            }


        }

        public void getImporterIdSearch()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlImporterIdSearch.DataSource = objLookUpBLL.getImporterIdSearch(strHeadOfficeId, strBranchOfficeId);

            ddlImporterIdSearch.DataTextField = "IMPORTER_NAME";
            ddlImporterIdSearch.DataValueField = "IMPORTER_ID";

            ddlImporterIdSearch.DataBind();
            if (ddlImporterIdSearch.Items.Count > 0)
            {

                ddlImporterIdSearch.SelectedIndex = 0;
            }


        }

        public void getShipmentTypeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlShipmentTypeId.DataSource = objLookUpBLL.getShipTypeId();

            ddlShipmentTypeId.DataTextField = "SHIPMENT_TYPE_NAME";
            ddlShipmentTypeId.DataValueField = "SHIPMENT_TYPE_ID";

            ddlShipmentTypeId.DataBind();
            if (ddlShipmentTypeId.Items.Count > 0)
            {

                ddlShipmentTypeId.SelectedIndex = 0;
            }


        }

        public void getShipmentTypeIdSearch()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlShipmentTypeIdSearch.DataSource = objLookUpBLL.getShipmentTypeIdSearch(strHeadOfficeId, strBranchOfficeId);

            ddlShipmentTypeIdSearch.DataTextField = "SHIPMENT_TYPE_NAME";
            ddlShipmentTypeIdSearch.DataValueField = "SHIPMENT_TYPE_ID";

            ddlShipmentTypeIdSearch.DataBind();
            if (ddlShipmentTypeIdSearch.Items.Count > 0)
            {

                ddlShipmentTypeIdSearch.SelectedIndex = 0;
            }


        }

        private void FirstGridViewRow()
        {



            DataTable dt = new DataTable();
            DataRow dr = null;


            dt.Columns.Add(new DataColumn("PROGRAMME_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("FABRIC_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("FABRIC_CONSTRUCTION_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("STYLE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("COLOR_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("ART_ID", typeof(string)));

            dt.Columns.Add(new DataColumn("UNIT_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("CURRENCY_ID", typeof(string)));


            dt.Columns.Add(new DataColumn("RATE", typeof(string)));
            dt.Columns.Add(new DataColumn("WIDTH", typeof(string)));
            dt.Columns.Add(new DataColumn("NUM_OF_ROLL", typeof(string)));
            dt.Columns.Add(new DataColumn("RECEIVE_QUANTITY", typeof(string)));

            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));


            dr = dt.NewRow();


            dr["PROGRAMME_ID"] = string.Empty;
            dr["FABRIC_ID"] = string.Empty;
            dr["FABRIC_CONSTRUCTION_ID"] = string.Empty;
            dr["STYLE_ID"] = string.Empty;
            dr["COLOR_ID"] = string.Empty;
            dr["ART_ID"] = string.Empty;

            dr["UNIT_ID"] = string.Empty;
            dr["CURRENCY_ID"] = string.Empty;


            dr["RATE"] = string.Empty;
            dr["WIDTH"] = string.Empty;
            dr["NUM_OF_ROLL"] = string.Empty;
            dr["RECEIVE_QUANTITY"] = string.Empty;

            dr["TRAN_ID"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvContractDetails.DataSource = dt;
            gvContractDetails.DataBind();

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
            lblMsgRecord.Text = string.Empty;
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

            //dtpReceiveDate.Text = objLookUpDTO.AttendenceDate;


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


        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        DropDownList ddlprogrammeId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("ddlprogrammeId");
                        DropDownList ddlFabricId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlFabricId");
                        DropDownList ddlFabricConstructionId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("ddlFabricConstructionId");
                        DropDownList ddlStyleId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlStyleId");
                        DropDownList ddlColorId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("ddlColorId");
                        DropDownList ddlArtId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("ddlArtId");



                        DropDownList ddlUnitId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("ddlUnitId");
                        DropDownList ddlCurrencyId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("ddlCurrencyId");

                        TextBox txtRate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtRate");
                        TextBox txtWidth = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtWidth");

                        TextBox txtNumberOfRoll = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("txtNumberOfRoll");
                        TextBox txtReceiveQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[11].FindControl("txtReceiveQuantity");

                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[12].FindControl("txtTranId");



                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["PROGRAMME_ID"] = ddlprogrammeId.Text;
                        dtCurrentTable.Rows[i - 1]["FABRIC_ID"] = ddlFabricId.Text;
                        dtCurrentTable.Rows[i - 1]["FABRIC_CONSTRUCTION_ID"] = ddlFabricConstructionId.Text;
                        dtCurrentTable.Rows[i - 1]["STYLE_ID"] = ddlStyleId.Text;
                        dtCurrentTable.Rows[i - 1]["COLOR_ID"] = ddlColorId.Text;
                        dtCurrentTable.Rows[i - 1]["ART_ID"] = ddlArtId.Text;




                        dtCurrentTable.Rows[i - 1]["UNIT_ID"] = ddlUnitId.Text;
                        dtCurrentTable.Rows[i - 1]["CURRENCY_ID"] = ddlCurrencyId.Text;

                        dtCurrentTable.Rows[i - 1]["RATE"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["WIDTH"] = txtWidth.Text;
                        dtCurrentTable.Rows[i - 1]["NUM_OF_ROLL"] = txtNumberOfRoll.Text;

                        dtCurrentTable.Rows[i - 1]["RECEIVE_QUANTITY"] = txtReceiveQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["TRAN_ID"] = txtTranId.Text;


                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvContractDetails.DataSource = dtCurrentTable;
                    gvContractDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }


        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        DropDownList ddlprogrammeId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("ddlprogrammeId");
                        DropDownList ddlFabricId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlFabricId");
                        DropDownList ddlFabricConstructionId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("ddlFabricConstructionId");
                        DropDownList ddlStyleId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlStyleId");
                        DropDownList ddlColorId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("ddlColorId");
                        DropDownList ddlArtId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("ddlArtId");



                        DropDownList ddlUnitId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("ddlUnitId");
                        DropDownList ddlCurrencyId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("ddlCurrencyId");

                        TextBox txtRate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtRate");
                        TextBox txtWidth = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtWidth");

                        TextBox txtNumberOfRoll = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("txtNumberOfRoll");
                        TextBox txtReceiveQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[11].FindControl("txtReceiveQuantity");

                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[12].FindControl("txtTranId");



                        ddlprogrammeId.Text = dt.Rows[i]["PROGRAMME_ID"].ToString();
                        ddlFabricId.Text = dt.Rows[i]["FABRIC_ID"].ToString();
                        ddlFabricConstructionId.Text = dt.Rows[i]["FABRIC_CONSTRUCTION_ID"].ToString();
                        ddlStyleId.Text = dt.Rows[i]["STYLE_ID"].ToString();
                        ddlColorId.Text = dt.Rows[i]["COLOR_ID"].ToString();
                        ddlArtId.Text = dt.Rows[i]["ART_ID"].ToString();

                        ddlUnitId.Text = dt.Rows[i]["UNIT_ID"].ToString();
                        ddlCurrencyId.Text = dt.Rows[i]["CURRENCY_ID"].ToString();
                        txtRate.Text = dt.Rows[i]["RATE"].ToString();
                        txtWidth.Text = dt.Rows[i]["WIDTH"].ToString();
                        txtNumberOfRoll.Text = dt.Rows[i]["NUM_OF_ROLL"].ToString();
                        txtReceiveQuantity.Text = dt.Rows[i]["RECEIVE_QUANTITY"].ToString();


                        txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();


                        rowIndex++;
                    }
                }
            }
        }






        public void saveForeignFabricReceiveInfo()
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveBLL objForeignFabricReceiveBLL = new ForeignFabricReceiveBLL();


            int rowIndex = 0;
            string strMsg = "";

            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {


                        DropDownList ddlprogrammeId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("ddlprogrammeId");
                        DropDownList ddlFabricId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlFabricId");
                        DropDownList ddlFabricConstructionId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("ddlFabricConstructionId");
                        DropDownList ddlStyleId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlStyleId");
                        DropDownList ddlColorId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("ddlColorId");
                        DropDownList ddlArtId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("ddlArtId");



                        DropDownList ddlUnitId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("ddlUnitId");
                        DropDownList ddlCurrencyId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("ddlCurrencyId");

                        TextBox txtRate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtRate");
                        TextBox txtWidth = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtWidth");

                        TextBox txtNumberOfRoll = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("txtNumberOfRoll");
                        TextBox txtReceiveQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[11].FindControl("txtReceiveQuantity");

                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[12].FindControl("txtTranId");



                        objForeignFabricReceiveDTO.TranId = txtTranId.Text;
                        if (ddlprogrammeId.SelectedValue.ToString() != " ")
                        {
                            objForeignFabricReceiveDTO.ProgrammeId = ddlprogrammeId.SelectedValue.ToString();

                        }
                        else
                        {
                            objForeignFabricReceiveDTO.ProgrammeId = "";

                        }

                        if (ddlFabricId.SelectedValue.ToString() != " ")
                        {
                            objForeignFabricReceiveDTO.FabricId = ddlFabricId.SelectedValue.ToString();

                        }
                        else
                        {
                            objForeignFabricReceiveDTO.FabricId = "";

                        }

                        if (ddlFabricConstructionId.SelectedValue.ToString() != " ")
                        {
                            objForeignFabricReceiveDTO.FabricConstructionId = ddlFabricConstructionId.SelectedValue.ToString();

                        }
                        else
                        {
                            objForeignFabricReceiveDTO.FabricConstructionId = "";

                        }




                        if (ddlStyleId.SelectedValue.ToString() != " ")
                        {
                            objForeignFabricReceiveDTO.StyleId = ddlStyleId.SelectedValue.ToString();

                        }
                        else
                        {
                            objForeignFabricReceiveDTO.StyleId = "";

                        }

                        if (ddlColorId.SelectedValue.ToString() != " ")
                        {
                            objForeignFabricReceiveDTO.ColorId = ddlColorId.SelectedValue.ToString();

                        }
                        else
                        {
                            objForeignFabricReceiveDTO.ColorId = "";

                        }

                        if (ddlArtId.SelectedValue.ToString() != " ")
                        {
                            objForeignFabricReceiveDTO.ArtId = ddlArtId.SelectedValue.ToString();

                        }
                        else
                        {
                            objForeignFabricReceiveDTO.ArtId = "";

                        }




                        if (ddlBranchOfficeId.SelectedValue.ToString() != " ")
                        {
                            objForeignFabricReceiveDTO.StoreId = ddlBranchOfficeId.SelectedValue.ToString();

                        }
                        else
                        {
                            objForeignFabricReceiveDTO.StoreId = "";

                        }

                        if (ddlUnitId.SelectedValue.ToString() != " ")
                        {
                            objForeignFabricReceiveDTO.UnitId = ddlUnitId.SelectedValue.ToString();

                        }
                        else
                        {
                            objForeignFabricReceiveDTO.UnitId = "";

                        }

                        if (ddlCurrencyId.SelectedValue.ToString() != " ")
                        {
                            objForeignFabricReceiveDTO.CurrencyId = ddlCurrencyId.SelectedValue.ToString();

                        }
                        else
                        {
                            objForeignFabricReceiveDTO.CurrencyId = "";

                        }

                        objForeignFabricReceiveDTO.Rate = txtRate.Text;

                        objForeignFabricReceiveDTO.Width = txtWidth.Text;
                        objForeignFabricReceiveDTO.NumberOfRoll = txtNumberOfRoll.Text;
                        objForeignFabricReceiveDTO.Quantity = txtReceiveQuantity.Text;




                        objForeignFabricReceiveDTO.InvoiceNo = txtInvoiceNo.Text;

                        objForeignFabricReceiveDTO.LCNo = txtLCNo.Text;

                        if (dtpReceiveDate.Text == "")
                        {
                            objForeignFabricReceiveDTO.ReceiveDate = "";
                        }
                        else
                        {
                            objForeignFabricReceiveDTO.ReceiveDate = dtpReceiveDate.Text;

                        }

                        if (ddlBuyerId.SelectedValue.ToString() != "")
                        {
                            objForeignFabricReceiveDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                        }
                        else
                        {

                            objForeignFabricReceiveDTO.BuyerId = "";

                        }

                        if (ddlSupplierId.SelectedValue.ToString() != "")
                        {
                            objForeignFabricReceiveDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();

                        }
                        else
                        {

                            objForeignFabricReceiveDTO.SupplierId = "";

                        }


                        if (ddlImporterId.SelectedValue.ToString() != "")
                        {
                            objForeignFabricReceiveDTO.ImporterId = ddlImporterId.SelectedValue.ToString();

                        }
                        else
                        {

                            objForeignFabricReceiveDTO.ImporterId = "";

                        }

                        objForeignFabricReceiveDTO.ShipmentNo = txtShipmentNo.Text;


                        if (ddlShipmentTypeId.SelectedValue.ToString() != "")
                        {
                            objForeignFabricReceiveDTO.ShipmentId = ddlShipmentTypeId.SelectedValue.ToString();

                        }
                        else
                        {

                            objForeignFabricReceiveDTO.ShipmentId = "";

                        }





                        objForeignFabricReceiveDTO.UpdateBy = strEmployeeId;
                        objForeignFabricReceiveDTO.HeadOfficeId = strHeadOfficeId;
                        objForeignFabricReceiveDTO.BranchOfficeId = strBranchOfficeId;






                        strMsg = objForeignFabricReceiveBLL.saveForeignFabricReceiveInfo(objForeignFabricReceiveDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;

                        rowIndex++;



                    }

                    if (strMsg == "INSERTED SUCCESSFULLY" || strMsg == "UPDATED SUCCESSFULLY")
                    {
                        MessageBox(strMsg);

                    }






                }


            }





        }






        public void searcForeignFabricReceiveSub()
        {



            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveBLL objForeignFabricReceiveBLL = new ForeignFabricReceiveBLL();

            DataTable dt = new DataTable();


            objForeignFabricReceiveDTO.InvoiceNo = txtInvoiceNo.Text;
            objForeignFabricReceiveDTO.ReceiveDate = dtpReceiveDate.Text;






            objForeignFabricReceiveDTO.HeadOfficeId = strHeadOfficeId;
            objForeignFabricReceiveDTO.BranchOfficeId = strBranchOfficeId;

            dt = objForeignFabricReceiveBLL.searcForeignFabricReceiveSub(objForeignFabricReceiveDTO);


            if (dt.Rows.Count > 0)
            {
                gvContractDetails.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvContractDetails.DataBind();

                int count = ((DataTable)gvContractDetails.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvContractDetails.DataSource = dt;
                gvContractDetails.DataBind();
                int totalcolums = gvContractDetails.Rows[0].Cells.Count;
                gvContractDetails.Rows[0].Cells.Clear();
                gvContractDetails.Rows[0].Cells.Add(new TableCell());
                gvContractDetails.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvContractDetails.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }




        public void searcForeignFabricReceiveMain()
        {
            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveBLL objForeignFabricReceiveBLL = new ForeignFabricReceiveBLL();




            objForeignFabricReceiveDTO = objForeignFabricReceiveBLL.searcForeignFabricReceiveMain(txtInvoiceNo.Text, dtpReceiveDate.Text, strHeadOfficeId, strBranchOfficeId);







            if (objForeignFabricReceiveDTO.LCNo == " ")
            {

                //nothing to do
            }
            else
            {
                txtLCNo.Text = objForeignFabricReceiveDTO.LCNo;
            }


            if (objForeignFabricReceiveDTO.BuyerId == " ")
            {

                //nothing to do
            }
            else
            {
                ddlBuyerId.SelectedValue = objForeignFabricReceiveDTO.BuyerId;
            }


            if (objForeignFabricReceiveDTO.SupplierId == " ")
            {

                //nothing to do
            }
            else
            {
                ddlSupplierId.SelectedValue = objForeignFabricReceiveDTO.SupplierId;
            }


            if (objForeignFabricReceiveDTO.ImporterId == " ")
            {

                //nothing to do
            }
            else
            {
                ddlImporterId.SelectedValue = objForeignFabricReceiveDTO.ImporterId;
            }


            if (objForeignFabricReceiveDTO.ShipmentNo == " ")
            {

                //nothing to do
            }
            else
            {
                txtShipmentNo.Text = objForeignFabricReceiveDTO.ShipmentNo;
            }

            if (objForeignFabricReceiveDTO.ShipmentId == " ")
            {

                //nothing to do
            }
            else
            {
                ddlShipmentTypeId.SelectedValue = objForeignFabricReceiveDTO.ShipmentId;
            }

            if (objForeignFabricReceiveDTO.StoreId == "0")
            {

                getBranchOfficeName();
            }
            else
            {
                ddlBranchOfficeId.SelectedValue = objForeignFabricReceiveDTO.StoreId;
            }



        }




        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtInvoiceNo.Text == "")
            {
                string strMsg = "Please Enter Invoice No!!!";
                MessageBox(strMsg);
                txtInvoiceNo.Focus();
                return;


            }
            else if (dtpReceiveDate.Text == "")
            {
                string strMsg = "Please Enter Receive Date!!!";
                MessageBox(strMsg);
                dtpReceiveDate.Focus();
                return;


            }




            else
            {

                saveForeignFabricReceiveInfo();
                searcForeignFabricReceiveMain();
                searcForeignFabricReceiveSub();
                searchQty(txtInvoiceNo.Text, strHeadOfficeId, strBranchOfficeId);

            }
        }

        public void searchQty(string strInvoiceNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveBLL objForeignFabricReceiveBLL = new ForeignFabricReceiveBLL();

            objForeignFabricReceiveDTO = objForeignFabricReceiveBLL.searchTotalForeignRcvQty(strInvoiceNo, strHeadOfficeId, strBranchOfficeId);

            txtTotalReceiveQuantity.Text = objForeignFabricReceiveDTO.TotalQuantity;



        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            searcForeignFabricReceiveSub();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtInvoiceNo.Text == "")
            {
                string strMsg = "Please Enter Contract No!!!";
                MessageBox(strMsg);
                txtInvoiceNo.Focus();
                return;
            }

            if (dtpReceiveDate.Text == "")
            {
                string strMsg = "Please Enter Receive Date!!!";
                MessageBox(strMsg);
                dtpReceiveDate.Focus();
                return;
            }


            else
            {
                searcForeignFabricReceiveMain();
                searcForeignFabricReceiveSub();
                searchQty(txtInvoiceNo.Text, strHeadOfficeId, strBranchOfficeId);

            }

        }

        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {

        }


        #region "Grid View Functionality"
        protected void gvContractDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvContractDetails.PageIndex = e.NewPageIndex;

        }

        protected void gvContractDetails_OnSelectedIndexChanged(object sender, EventArgs e)
        {



        }




        protected void gvContractDetails_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void gvContractDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int stor_id = Convert.ToInt32(gvContractDetails.DataKeys[e.RowIndex].Values["TRAN_ID"].ToString());


            string strTranId = Convert.ToString(stor_id);
            deleteForeignFabricReceiveRecord(strTranId);
            searcForeignFabricReceiveMain();
            searcForeignFabricReceiveSub();


        }

        protected void gvContractDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{
            //    int strRowId = GridView1.SelectedRow.RowIndex + 1;
            //    string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            //    string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            //    string strEmployeeId = GridView1.SelectedRow.Cells[9].Text;
            //    string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            //    string strDesignation = GridView1.SelectedRow.Cells[3].Text;


            //    txtSL.Text = Convert.ToString(strRowId);
            //    txtCardNo.Text = strCardNo;
            //    txtEmployeeId.Text = strEmployeeId;
            //    txtEmployeeName.Text = strEmployeeName;
            //    txtDesignationName.Text = strDesignation;

            //    searchMiscEntryWorker();

            //    txtWorkingDay.Focus();
            //}
            //if (e.CommandName == "Edit")
            //{
            //}
            //if (e.CommandName == "Delete")
            //{

            //}




            //int selectedRowIndex = GridView1.SelectedRow.RowIndex;
            //GridView1.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }

        protected void gvContractDetails_Sorting(object sender, GridViewSortEventArgs e)
        {


        }


        protected void gvForeignFabric_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvForeignFabric.PageIndex = e.NewPageIndex;

        }
        protected void gvForeignFabric_SelectedIndexChanged(object sender, EventArgs e)
        {


            string strInvoiceNo = gvForeignFabric.SelectedRow.Cells[0].Text;
            string strReciveDate = gvForeignFabric.SelectedRow.Cells[1].Text;

            txtInvoiceNo.Text = strInvoiceNo;
            dtpReceiveDate.Text = strReciveDate;



            searcForeignFabricReceiveMain();
            searcForeignFabricReceiveSub();
            searchQty(txtInvoiceNo.Text, strHeadOfficeId, strBranchOfficeId);
        }



        protected void gvForeignFabric_RowCommand(object sender, EventArgs e)
        {


        }
        protected void gvContractDetails_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LookUpBLL objLookUpBLL = new LookUpBLL();

                DropDownList a = (e.Row.FindControl("ddlProgrammeId") as DropDownList);


                DataTable dt = new DataTable();


                DataRowView dr = e.Row.DataItem as DataRowView;


                dt = objLookUpBLL.getProgrammeId();
                a.DataSource = dt;
                a.DataBind();
                a.SelectedValue = dr["PROGRAMME_ID"].ToString();


                DropDownList b = (e.Row.FindControl("ddlFabricId") as DropDownList);


                DataTable dt1 = new DataTable();


                DataRowView dr1 = e.Row.DataItem as DataRowView;


                dt1 = objLookUpBLL.getFabricId();
                b.DataSource = dt1;
                b.DataBind();
                b.SelectedValue = dr1["FABRIC_ID"].ToString();


                DropDownList c = (e.Row.FindControl("ddlFabricConstructionId") as DropDownList);


                DataTable dt2 = new DataTable();


                DataRowView dr2 = e.Row.DataItem as DataRowView;


                dt2 = objLookUpBLL.getConstructionId();
                c.DataSource = dt2;
                c.DataBind();
                c.SelectedValue = dr2["FABRIC_CONSTRUCTION_ID"].ToString();


                DropDownList d = (e.Row.FindControl("ddlStyleId") as DropDownList);


                DataTable dt3 = new DataTable();


                DataRowView dr3 = e.Row.DataItem as DataRowView;


                dt3 = objLookUpBLL.getStyleIdStore();
                d.DataSource = dt3;
                d.DataBind();
                d.SelectedValue = dr3["STYLE_ID"].ToString();

                DropDownList f = (e.Row.FindControl("ddlColorId") as DropDownList);


                DataTable dt4 = new DataTable();


                DataRowView dr4 = e.Row.DataItem as DataRowView;


                dt4 = objLookUpBLL.getColorIdStore();
                f.DataSource = dt4;
                f.DataBind();
                f.SelectedValue = dr4["COLOR_ID"].ToString();

                DropDownList g = (e.Row.FindControl("ddlArtId") as DropDownList);


                DataTable dt5 = new DataTable();


                DataRowView dr5 = e.Row.DataItem as DataRowView;


                dt5 = objLookUpBLL.getArtId();
                g.DataSource = dt5;
                g.DataBind();
                g.SelectedValue = dr5["ART_ID"].ToString();





                DropDownList j = (e.Row.FindControl("ddlUnitId") as DropDownList);


                DataTable dt7 = new DataTable();


                DataRowView dr7 = e.Row.DataItem as DataRowView;


                dt7 = objLookUpBLL.getUnitIdStore(strHeadOfficeId, strBranchOfficeId);
                j.DataSource = dt7;
                j.DataBind();
                j.SelectedValue = dr7["UNIT_ID"].ToString();



                DropDownList k = (e.Row.FindControl("ddlCurrencyId") as DropDownList);


                DataTable dt8 = new DataTable();


                DataRowView dr8 = e.Row.DataItem as DataRowView;


                dt8 = objLookUpBLL.getCurrencyId(strHeadOfficeId, strBranchOfficeId);
                k.DataSource = dt8;
                k.DataBind();
                k.SelectedValue = dr8["CURRENCY_ID"].ToString();


            }






        }


        #endregion



        protected void ddlAmendmentId_SelectedIndexChanged(object sender, EventArgs e)
        {

            //searchContactRecord();
            //searcContactMain();

        }

        protected void btnSearchAmmendMent_Click(object sender, EventArgs e)
        {

            // searchContactRecord();
            //searcContactMain();
        }





        public void deleteForeignFabricReceiveRecord(string strTranId)
        {



            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveBLL objForeignFabricReceiveBLL = new ForeignFabricReceiveBLL();




            objForeignFabricReceiveDTO.InvoiceNo = txtInvoiceNo.Text;
            objForeignFabricReceiveDTO.ReceiveDate = dtpReceiveDate.Text;
            objForeignFabricReceiveDTO.TranId = strTranId;





            objForeignFabricReceiveDTO.UpdateBy = strEmployeeId;
            objForeignFabricReceiveDTO.HeadOfficeId = strHeadOfficeId;
            objForeignFabricReceiveDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objForeignFabricReceiveBLL.deleteForeignFabricReceiveRecord(objForeignFabricReceiveDTO);
            MessageBox(strMsg);


        }

        public void SearchForeignFabricReceive()
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveBLL objForeignFabricReceiveBLL = new ForeignFabricReceiveBLL();





            DataTable dt = new DataTable();

            objForeignFabricReceiveDTO.InvoiceNo = txtInvoiceNoSearch.Text;
            objForeignFabricReceiveDTO.Year = txtYear.Text;
            objForeignFabricReceiveDTO.LCNo = txtLCNoSearch.Text;


            if (ddlBuyerIdSearch.Text != " ")
            {
                objForeignFabricReceiveDTO.BuyerId = ddlBuyerIdSearch.SelectedValue;
            }
            else
            {
                objForeignFabricReceiveDTO.BuyerId = "";
            }


            if (ddlImporterIdSearch.Text != " ")
            {
                objForeignFabricReceiveDTO.ImporterId = ddlImporterIdSearch.SelectedValue;
            }
            else
            {
                objForeignFabricReceiveDTO.ImporterId = "";
            }

            if (ddlSupplierIdSearch.Text != " ")
            {
                objForeignFabricReceiveDTO.SupplierId = ddlSupplierIdSearch.SelectedValue;
            }
            else
            {
                objForeignFabricReceiveDTO.SupplierId = "";
            }

            objForeignFabricReceiveDTO.ShipmentNo = txtShipmentNo.Text;

            if (ddlShipmentTypeIdSearch.Text != " ")
            {
                objForeignFabricReceiveDTO.ShipmentId = ddlShipmentTypeIdSearch.SelectedValue;
            }
            else
            {
                objForeignFabricReceiveDTO.ShipmentId = "";
            }







            objForeignFabricReceiveDTO.UpdateBy = strEmployeeId;
            objForeignFabricReceiveDTO.HeadOfficeId = strHeadOfficeId;
            objForeignFabricReceiveDTO.BranchOfficeId = strBranchOfficeId;


            dt = objForeignFabricReceiveBLL.SearchForeignFabricReceive(objForeignFabricReceiveDTO);


            if (dt.Rows.Count > 0)
            {
                gvForeignFabric.DataSource = dt;
                gvForeignFabric.DataBind();



                string strMsg = "TOTAL " + gvForeignFabric.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvForeignFabric.DataSource = dt;
                gvForeignFabric.DataBind();
                int totalcolums = gvForeignFabric.Rows[0].Cells.Count;
                gvForeignFabric.Rows[0].Cells.Clear();
                gvForeignFabric.Rows[0].Cells.Add(new TableCell());
                gvForeignFabric.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvForeignFabric.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }


        }
        protected void btnSearchRecord_Click(object sender, EventArgs e)
        {
            SearchForeignFabricReceive();
        }

        protected void txtInvoiceNoSearch_TextChanged(object sender, EventArgs e)
        {

        }


        protected void ddlProgrammeId_SelectedIndexChanged(object sender, EventArgs e)
        {


            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();

            DropDownList tb = (DropDownList)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;

            DropDownList ddlProgrammeId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlProgrammeId");

            string strProgrammeId = ddlProgrammeId.SelectedValue;

            if (ddlSupplierId.SelectedValue == " ")
            {

                string strMsg = "Please Select Supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;

            }
            else
            {



                LookUpBLL objLookUpBLL = new LookUpBLL();





                DropDownList ddlFabricId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlFabricId");
                ddlFabricId.DataSource = objLookUpBLL.getFabricIdFromPOAssign(ddlSupplierId.SelectedValue.ToString(), strProgrammeId, strHeadOfficeId, strBranchOfficeId);


                ddlFabricId.DataTextField = "FABRIC_NAME";
                ddlFabricId.DataValueField = "FABRIC_ID";

                ddlFabricId.DataBind();
                if (ddlFabricId.Items.Count > 0)
                {

                    ddlFabricId.SelectedIndex = 0;
                }



                DropDownList ddlFabricConstructionId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlFabricConstructionId");
                ddlFabricConstructionId.DataSource = objLookUpBLL.getFabricConstructionIdFromPOAssign(ddlSupplierId.SelectedValue.ToString(), strProgrammeId, strHeadOfficeId, strBranchOfficeId);


                ddlFabricConstructionId.DataTextField = "FABRIC_CONSTRUCTION_NAME";
                ddlFabricConstructionId.DataValueField = "FABRIC_CONSTRUCTION_ID";

                ddlFabricConstructionId.DataBind();
                if (ddlFabricConstructionId.Items.Count > 0)
                {

                    ddlFabricConstructionId.SelectedIndex = 0;
                }


                DropDownList ddlStyleId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlStyleId");
                ddlStyleId.DataSource = objLookUpBLL.getStyleIdFromPOAssign(ddlSupplierId.SelectedValue.ToString(), strProgrammeId, strHeadOfficeId, strBranchOfficeId);


                ddlStyleId.DataTextField = "STYLE_NO";
                ddlStyleId.DataValueField = "STYLE_ID";

                ddlStyleId.DataBind();
                if (ddlStyleId.Items.Count > 0)
                {

                    ddlStyleId.SelectedIndex = 0;
                }


                DropDownList ddlArtId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlArtId");
                ddlArtId.DataSource = objLookUpBLL.getArtIdFromPOAssign(ddlSupplierId.SelectedValue.ToString(), strProgrammeId, strHeadOfficeId, strBranchOfficeId);


                ddlArtId.DataTextField = "ART_NO";
                ddlArtId.DataValueField = "ART_ID";

                ddlArtId.DataBind();
                if (ddlArtId.Items.Count > 0)
                {

                    ddlArtId.SelectedIndex = 0;
                }


                DropDownList ddlColorId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlColorId");
                ddlColorId.DataSource = objLookUpBLL.getColorIdFromPOAssign(ddlSupplierId.SelectedValue.ToString(), strProgrammeId, strHeadOfficeId, strBranchOfficeId);


                ddlColorId.DataTextField = "COLOR_NAME";
                ddlColorId.DataValueField = "COLOR_ID";

                ddlColorId.DataBind();
                if (ddlColorId.Items.Count > 0)
                {

                    ddlColorId.SelectedIndex = 0;
                }



                DropDownList ddlUnitId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlUnitId");
                ddlUnitId.DataSource = objLookUpBLL.getUnitIdFromPOAssign(ddlSupplierId.SelectedValue.ToString(), strProgrammeId, strHeadOfficeId, strBranchOfficeId);


                ddlUnitId.DataTextField = "UNIT_NAME";
                ddlUnitId.DataValueField = "UNIT_ID";

                ddlUnitId.DataBind();
                if (ddlUnitId.Items.Count > 0)
                {

                    ddlUnitId.SelectedIndex = 0;
                }



                DropDownList ddlCurrencyId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlCurrencyId");
                ddlCurrencyId.DataSource = objLookUpBLL.getCurrencyIdFromPOAssign(ddlSupplierId.SelectedValue.ToString(), strProgrammeId, strHeadOfficeId, strBranchOfficeId);


                ddlCurrencyId.DataTextField = "CURRENCY_NAME";
                ddlCurrencyId.DataValueField = "CURRENCY_ID";

                ddlCurrencyId.DataBind();
                if (ddlCurrencyId.Items.Count > 0)
                {

                    ddlCurrencyId.SelectedIndex = 0;
                }



            }

        }
    }

}