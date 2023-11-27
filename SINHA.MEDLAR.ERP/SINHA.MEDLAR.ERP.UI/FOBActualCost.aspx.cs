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
    public partial class FOBActualCost : System.Web.UI.Page
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

                getContractId();
                getPOId();
                getStyleId();


                getSeasonId();
                getCurrentYear();
                getContractPOId();
                getContractStyleId();
                getSeasonIdSearch();
                getContractBuyerId();

                getBuyerId();

            }

            if (IsPostBack)
            {

                loadSesscion();

            }


            gvContractDetails.Columns[12].Visible = false;




        }


        #region "Function"

        public void getContractId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlContractId.DataSource = objLookUpBLL.getContractId(strHeadOfficeId, strBranchOfficeId);

            ddlContractId.DataTextField = "CONTRACT_NO";
            ddlContractId.DataValueField = "CONTRACT_ID";

            ddlContractId.DataBind();
            if (ddlContractId.Items.Count > 0)
            {

                ddlContractId.SelectedIndex = 0;
            }


        }

        public void getPOId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPOId.DataSource = objLookUpBLL.getPOId(strHeadOfficeId, strBranchOfficeId);

            ddlPOId.DataTextField = "PO_NO";
            ddlPOId.DataValueField = "PO_ID";

            ddlPOId.DataBind();
            if (ddlPOId.Items.Count > 0)
            {

                ddlPOId.SelectedIndex = 0;
            }


        }

        public void getStyleId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlStyleId.DataSource = objLookUpBLL.getStyleId(strHeadOfficeId, strBranchOfficeId);

            ddlStyleId.DataTextField = "STYLE_NO";
            ddlStyleId.DataValueField = "STYLE_ID";

            ddlStyleId.DataBind();
            if (ddlStyleId.Items.Count > 0)
            {

                ddlStyleId.SelectedIndex = 0;
            }


        }

        public void getBuyerId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerId.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerId.DataTextField = "BUYER_SHORT_NAME";
            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {

                ddlBuyerId.SelectedIndex = 0;
            }


        }

        public void getCurrentYear()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYear();

            txtYear.Text = objLookUpDTO.Year;




        }


        public void getSeasonId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSeasonId.DataSource = objLookUpBLL.getSeasonId();

            ddlSeasonId.DataTextField = "SEASON_NAME";
            ddlSeasonId.DataValueField = "SEASON_ID";

            ddlSeasonId.DataBind();
            if (ddlSeasonId.Items.Count > 0)
            {

                ddlSeasonId.SelectedIndex = 0;
            }


        }

        public void getSeasonIdSearch()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSeasonIdSearch.DataSource = objLookUpBLL.getSeasonId();

            ddlSeasonIdSearch.DataTextField = "SEASON_NAME";
            ddlSeasonIdSearch.DataValueField = "SEASON_ID";

            ddlSeasonIdSearch.DataBind();
            if (ddlSeasonIdSearch.Items.Count > 0)
            {

                ddlSeasonIdSearch.SelectedIndex = 0;
            }


        }


        public void getContractPOId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPOIdSearch.DataSource = objLookUpBLL.getContractPOId();

            ddlPOIdSearch.DataTextField = "PO_NO";
            ddlPOIdSearch.DataValueField = "PO_ID";

            ddlPOIdSearch.DataBind();
            if (ddlPOIdSearch.Items.Count > 0)
            {

                ddlPOIdSearch.SelectedIndex = 0;
            }


        }

        public void getContractStyleId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlStyleIdSearch.DataSource = objLookUpBLL.getContractStyleId();

            ddlStyleIdSearch.DataTextField = "STYLE_NO";
            ddlStyleIdSearch.DataValueField = "STYLE_ID";

            ddlStyleIdSearch.DataBind();
            if (ddlStyleIdSearch.Items.Count > 0)
            {

                ddlStyleIdSearch.SelectedIndex = 0;
            }


        }

        public void getContractBuyerId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerIdSearch.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerIdSearch.DataTextField = "BUYER_SHORT_NAME";
            ddlBuyerIdSearch.DataValueField = "BUYER_ID";

            ddlBuyerIdSearch.DataBind();
            if (ddlBuyerIdSearch.Items.Count > 0)
            {

                ddlBuyerIdSearch.SelectedIndex = 0;
            }


        }











        private void FirstGridViewRow()
        {



            DataTable dt = new DataTable();
            DataRow dr = null;


            dt.Columns.Add(new DataColumn("fabric_id", typeof(string)));
          
          

            dt.Columns.Add(new DataColumn("SUPPLIER_ID", typeof(string)));

            dt.Columns.Add(new DataColumn("ART_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("BUDGET_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("BUDGET_PRICE", typeof(string)));

            dt.Columns.Add(new DataColumn("BUDGET_VALUE", typeof(string)));


            dt.Columns.Add(new DataColumn("ACTUAL_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("ACTUAL_PRICE", typeof(string)));
            dt.Columns.Add(new DataColumn("ACTUAL_VALUE", typeof(string)));
            dt.Columns.Add(new DataColumn("ACTUAL_VARIANCE", typeof(string)));
            dt.Columns.Add(new DataColumn("PI_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("PI_DATE", typeof(string)));


            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));


            dr = dt.NewRow();


            dr["fabric_id"] = string.Empty;
          


          
            dr["SUPPLIER_ID"] = string.Empty;

            dr["ART_ID"] = string.Empty;
            dr["BUDGET_QUANTITY"] = string.Empty;
            dr["BUDGET_PRICE"] = string.Empty;

            dr["BUDGET_VALUE"] = string.Empty;


            dr["ACTUAL_QUANTITY"] = string.Empty;
            dr["ACTUAL_PRICE"] = string.Empty;
            dr["ACTUAL_VALUE"] = string.Empty;
            dr["ACTUAL_VARIANCE"] = string.Empty;
            dr["PI_NO"] = string.Empty;
            dr["PI_DATE"] = string.Empty;




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

            // dtpIssueDate.Text = objLookUpDTO.AttendenceDate;


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



                        DropDownList ddlFabricId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("ddlFabricId");
                        DropDownList ddlSupplierId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlSupplierId");
                        DropDownList ddlArtId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("ddlArtId");
                        TextBox txtBudgetQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("txtBudgetQuantity");
                        TextBox txtBudgetPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("txtBudgetPrice");
                        TextBox txtBudgetValue = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtBudgetValue");


                        TextBox txtActualQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtActualQuantity");
                        TextBox txtActualPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("txtActualPrice");
                        TextBox txtActualValue = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtActualValue");
                        TextBox txtVariance = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtVariance");
                        TextBox txtPINo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("txtPINo");
                        TextBox txtPIDate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[11].FindControl("txtPIDate");
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[12].FindControl("txtTranId");


                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["fabric_id"] = ddlFabricId.Text;
                        dtCurrentTable.Rows[i - 1]["supplier_id"] = ddlSupplierId.Text;

                        dtCurrentTable.Rows[i - 1]["art_id"] = ddlSupplierId.Text;
                        dtCurrentTable.Rows[i - 1]["BUDGET_QUANTITY"] = txtBudgetQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["BUDGET_PRICE"] = txtBudgetPrice.Text;

                        dtCurrentTable.Rows[i - 1]["BUDGET_VALUE"] = txtBudgetValue.Text;


                        dtCurrentTable.Rows[i - 1]["ACTUAL_QUANTITY"] = txtActualQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["ACTUAL_PRICE"] = txtActualPrice.Text;
                        dtCurrentTable.Rows[i - 1]["ACTUAL_VALUE"] = txtActualValue.Text;
                        dtCurrentTable.Rows[i - 1]["ACTUAL_VARIANCE"] = txtVariance.Text;
                        dtCurrentTable.Rows[i - 1]["PI_NO"] = txtPINo.Text;
                        dtCurrentTable.Rows[i - 1]["PI_DATE"] = txtPIDate.Text;

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

                        DropDownList ddlFabricId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("ddlFabricId");
                        DropDownList ddlSupplierId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlSupplierId");
                        DropDownList ddlArtId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("ddlArtId");
                        TextBox txtBudgetQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("txtBudgetQuantity");
                        TextBox txtBudgetPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("txtBudgetPrice");
                        TextBox txtBudgetValue = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtBudgetValue");

                        TextBox txtActualQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtActualQuantity");
                        TextBox txtActualPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("txtActualPrice");
                        TextBox txtActualValue = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtActualValue");
                        TextBox txtVariance = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtVariance");
                        TextBox txtPINo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("txtPINo");
                        TextBox txtPIDate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[11].FindControl("txtPIDate");
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[12].FindControl("txtTranId");


                        ddlFabricId.Text = dt.Rows[i]["fabric_ID"].ToString();
                        ddlSupplierId.Text = dt.Rows[i]["supplier_id"].ToString();
                        ddlArtId.Text = dt.Rows[i]["art_id"].ToString();
                        txtBudgetQuantity.Text = dt.Rows[i]["BUDGET_QUANTITY"].ToString();
                        txtBudgetPrice.Text = dt.Rows[i]["BUDGET_PRICE"].ToString();
                        txtBudgetValue.Text = dt.Rows[i]["BUDGET_VALUE"].ToString();


                        txtActualQuantity.Text = dt.Rows[i]["ACTUAL_QUANTITY"].ToString();
                        txtActualPrice.Text = dt.Rows[i]["ACTUAL_PRICE"].ToString();
                        txtActualValue.Text = dt.Rows[i]["ACTUAL_VALUE"].ToString();
                        txtVariance.Text = dt.Rows[i]["ACTUAL_VARIANCE"].ToString();
                        txtPINo.Text = dt.Rows[i]["PI_NO"].ToString();
                        txtPIDate.Text = dt.Rows[i]["PI_DATE"].ToString();
                        txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();


                        rowIndex++;
                    }
                }
            }
        }





        public void saveFOBActualCost()
        {



            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();

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


                        DropDownList ddlFabricId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("ddlFabricId");
                        DropDownList ddlSupplierId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlSupplierId");
                        DropDownList ddlArtId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("ddlArtId");
                        TextBox txtBudgetQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("txtBudgetQuantity");
                        TextBox txtBudgetPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("txtBudgetPrice");
                        TextBox txtBudgetValue = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtBudgetValue");


                        TextBox txtActualQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtActualQuantity");
                        TextBox txtActualPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("txtActualPrice");
                        TextBox txtActualValue = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtActualValue");
                        TextBox txtVariance = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtVariance");
                        TextBox txtPINo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("txtPINo");
                        TextBox txtPIDate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[11].FindControl("txtPIDate");
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[12].FindControl("txtTranId");


                        if (ddlFabricId.SelectedValue.ToString() != " ")
                        {
                            objFOBDTO.FabricId = ddlFabricId.SelectedValue.ToString();

                        }
                        else
                        {
                            objFOBDTO.FabricId = "";

                        }


                     

                   
                        objFOBDTO.TranId = txtTranId.Text;
                        if (ddlSupplierId.SelectedValue.ToString() != " ")
                        {
                            objFOBDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();

                        }
                        else
                        {
                            objFOBDTO.SupplierId = "";

                        }

                       
                        objFOBDTO.BudgetValue = txtBudgetValue.Text;
                        objFOBDTO.AmendmentDate = dtpAmendmentDate.Text;


                        objFOBDTO.AcTualQuantity = txtActualQuantity.Text;
                        objFOBDTO.ActualPrice = txtActualPrice.Text;
                        objFOBDTO.ActualValue = txtActualValue.Text;
                        objFOBDTO.ActualVariance = txtVariance.Text;
                        objFOBDTO.PINo = txtPINo.Text;
                        objFOBDTO.PIDate = txtPIDate.Text;


                     
                        if (dtpFOBDate.Text.Length> 6)
                        {
                            objFOBDTO.FOBDate = dtpFOBDate.Text;
                        }
                        else
                        {
                            objFOBDTO.FOBDate = "";

                        }





                        if (ddlContractId.SelectedValue.ToString() != "")
                        {
                            objFOBDTO.ContractId = ddlContractId.SelectedValue.ToString();

                        }
                        else
                        {

                            objFOBDTO.ContractId = "";

                        }


                        if (ddlBuyerId.SelectedValue.ToString() != "")
                        {
                            objFOBDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                        }
                        else
                        {

                            objFOBDTO.BuyerId = "";

                        }


                        if (ddlSeasonId.SelectedValue.ToString() != "")
                        {
                            objFOBDTO.SeasonId = ddlSeasonId.SelectedValue.ToString();

                        }
                        else
                        {

                            objFOBDTO.SeasonId = "";

                        }


                        if (ddlPOId.SelectedValue.ToString() != " ")
                        {
                            objFOBDTO.POId = ddlPOId.SelectedValue.ToString();

                        }
                        else
                        {
                            objFOBDTO.POId = "";

                        }
                        if (ddlStyleId.SelectedValue.ToString() != " ")
                        {
                            objFOBDTO.StyleId = ddlStyleId.SelectedValue.ToString();

                        }
                        else
                        {
                            objFOBDTO.StyleId = "";

                        }



                        objFOBDTO.OrderQuantity = txtOrderQuantity.Text;

                        if (ddlArtId.SelectedValue.ToString() != " ")
                        {
                            objFOBDTO.ArtId = ddlArtId.SelectedValue.ToString();

                        }
                        else
                        {
                            objFOBDTO.ArtId = "";

                        }

                        objFOBDTO.BudgetQuantity = txtBudgetQuantity.Text;
                        objFOBDTO.BudgetPrice = txtBudgetPrice.Text;


                        objFOBDTO.UpdateBy = strEmployeeId;
                        objFOBDTO.HeadOfficeId = strHeadOfficeId;
                        objFOBDTO.BranchOfficeId = strBranchOfficeId;






                        strMsg = objFOBBLL.saveFOBActualCost(objFOBDTO);
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




        public void searchFOBActualCostSheetRecord()
        {



            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();

            DataTable dt = new DataTable();


            if (ddlContractId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.ContractId = ddlContractId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.ContractId = "";

            }

            objFOBDTO.FOBDate = dtpFOBDate.Text;
            objFOBDTO.AmendmentDate = dtpAmendmentDate.Text;

            if (ddlPOId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.POId = ddlPOId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.POId = "";

            }

            if (ddlStyleId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.StyleId = ddlStyleId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.StyleId = "";

            }


            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.BuyerId = "";

            }

            if (ddlSeasonId.Text != " ")
            {

                objFOBDTO.SeasonId = ddlSeasonId.SelectedValue.ToString();

            }
            else
            {

                objFOBDTO.SeasonId = "";

            }




            objFOBDTO.HeadOfficeId = strHeadOfficeId;
            objFOBDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFOBBLL.searchFOBActualCostSheetRecord(objFOBDTO);


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

        public void FOBActualCostSub()
        {



            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();

            DataTable dt = new DataTable();


            if (ddlContractId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.ContractId = ddlContractId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.ContractId = "";

            }

            objFOBDTO.FOBDate = dtpFOBDate.Text;

            if (ddlPOId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.POId = ddlPOId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.POId = "";

            }

            if (ddlStyleId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.StyleId = ddlStyleId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.StyleId = "";

            }

            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.BuyerId = "";

            }



            if (ddlSeasonId.Text != " ")
            {

                objFOBDTO.SeasonId = ddlSeasonId.SelectedValue.ToString();

            }
            else
            {

                objFOBDTO.SeasonId = "";

            }




            objFOBDTO.HeadOfficeId = strHeadOfficeId;
            objFOBDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFOBBLL.FOBActualCostSub(objFOBDTO);


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


        public void searchFOBActualCostMain()
        {
            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();

            string strAmendId = "";


            objFOBDTO = objFOBBLL.searchFOBActualCostMain( ddlContractId.Text, dtpFOBDate.Text, ddlPOId.SelectedValue.ToString(), ddlStyleId.SelectedValue.ToString(), ddlBuyerId.SelectedValue.ToString(), ddlSeasonId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);


            if (objFOBDTO.SeasonId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlSeasonId.SelectedValue = objFOBDTO.SeasonId;
            }

            if (objFOBDTO.OrderQuantity == "0")
            {

                //nothing to do
            }
            else
            {
                txtOrderQuantity.Text = objFOBDTO.OrderQuantity;
            }



            if (objFOBDTO.FOBDate == " ")
            {

                //nothing to do
            }
            else
            {
                dtpFOBDate.Text = objFOBDTO.FOBDate;
            }

            if (objFOBDTO.AmendmentDate == " ")
            {

                //nothing to do
            }
            else
            {
                dtpAmendmentDate.Text = objFOBDTO.AmendmentDate;
            }



        }
        public void FOBActualCostMain()
        {
            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();

            string strAmendId = "";


            objFOBDTO = objFOBBLL.FOBActualCostMain(ddlBuyerId.SelectedValue.ToString(), ddlContractId.SelectedValue.ToString(), dtpFOBDate.Text, strHeadOfficeId, strBranchOfficeId);




            if (objFOBDTO.SeasonId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlSeasonId.SelectedValue = objFOBDTO.SeasonId;
            }



            if (objFOBDTO.FOBDate == " ")
            {

                //nothing to do
            }
            else
            {
                dtpFOBDate.Text = objFOBDTO.FOBDate;
            }


            if (objFOBDTO.POId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlPOId.SelectedValue = objFOBDTO.POId;
            }

            if (objFOBDTO.StyleId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlStyleId.SelectedValue = objFOBDTO.StyleId;
            }


        }



        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlContractId.Text == "")
            {
                string strMsg = "Please Select Contract No!!!";
                MessageBox(strMsg);
                ddlContractId.Focus();
                return;


            }
            else if (dtpFOBDate.Text == "")
            {
                string strMsg = "Please Enter FOB Date!!!";
                MessageBox(strMsg);
                dtpFOBDate.Focus();
                return;


            }
            else if (ddlPOId.Text == "")
            {
                string strMsg = "Please Enter PO No!!!";
                MessageBox(strMsg);
                ddlPOId.Focus();
                return;


            }
            else if (ddlStyleId.Text == "")
            {
                string strMsg = "Please Enter Style No!!!";
                MessageBox(strMsg);
                ddlStyleId.Focus();
                return;


            }
            else if (ddlBuyerId.Text == "")
            {
                string strMsg = "Please Select Buyer Name!!!";
                MessageBox(strMsg);
                ddlBuyerId.Focus();
                return;


            }

            else if (ddlSeasonId.Text == " ")
            {
                string strMsg = "Please Select Season Name!!!";
                MessageBox(strMsg);
                ddlSeasonId.Focus();
                return;


            }




            else
            {

                saveFOBActualCost();
                searchFOBActualCostMain();
                searchFOBActualCostSheetRecord();


            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchFOBActualCostSheetRecord();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (ddlBuyerId.Text == " ")
            {
                string strMsg = "Please Select Buyer Name!!!";
                MessageBox(strMsg);
                ddlBuyerId.Focus();
                return;
            }

            else if (ddlContractId.Text == " ")
            {
                string strMsg = "Please Select Contract No!!!";
                MessageBox(strMsg);
                ddlContractId.Focus();
                return;
            }

            else if(ddlPOId.Text == " ")
            {
                string strMsg = "Please Select PO!!!";
                MessageBox(strMsg);
                ddlPOId.Focus();
                return;
            }

            else if(ddlStyleId.Text == " ")
            {
                string strMsg = "Please Select Style!!!";
                MessageBox(strMsg);
                ddlStyleId.Focus();
                return;
            }


            else
            {
                processFOBActualCostFromFOBBudget();
                searchFOBActualCostMain();
                searchFOBActualCostSheetRecord();


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

            GridViewRow row = (GridViewRow)gvContractDetails.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("TRAN_ID");

            //if (lbldeleteid == null)
            //{

            //    string strMsg = "ID NOT FOUND!!!";
            //    MessageBox(strMsg);
            //    return;
            //}
            //else
            //{

            int stor_id = Convert.ToInt32(gvContractDetails.DataKeys[e.RowIndex].Values["TRAN_ID"].ToString());

            string strTranId = Convert.ToString(stor_id);
            deleteFOBActualCostRecord(strTranId);
            searchFOBActualCostMain();
            searchFOBActualCostSheetRecord();




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


        protected void gvContractDetails_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LookUpBLL objLookUpBLL = new LookUpBLL();


                //int BudgetValue = int.Parse(e.Row.Cells[5].Text);
                //int Actulvalue = int.Parse(e.Row.Cells[8].Text);

                //foreach (TableCell cell in e.Row.Cells)
                //{
                //    if (BudgetValue > Actulvalue)
                //    {
                //        cell.BackColor = System.Drawing.Color.Blue;
                //    }

                //    if (BudgetValue < Actulvalue)
                //    {
                //        cell.BackColor = System.Drawing.Color.Red;
                //    }
                //}



                DropDownList b = (e.Row.FindControl("ddlSupplierId") as DropDownList);


                DataTable dt1 = new DataTable();


                DataRowView dr1 = e.Row.DataItem as DataRowView;


                dt1 = objLookUpBLL.getSupplierId();
                b.DataSource = dt1;
                b.DataBind();
                b.SelectedValue = dr1["SUPPLIER_ID"].ToString();


              


                DataTable dt3 = new DataTable();
                DataRowView dr3 = e.Row.DataItem as DataRowView;
                DropDownList d = (e.Row.FindControl("ddlFabricId") as DropDownList);

                dt3 = objLookUpBLL.getFabricDescriptionId(ddlBuyerId.SelectedValue.ToString(),  strHeadOfficeId,  strBranchOfficeId);
                d.DataSource = dt3;
                d.DataBind();
                d.SelectedValue = dr3["FABRIC_ID"].ToString();


             

            

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



        public void deleteFOBActualCostRecord(string strTranId)
        {


            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();



            if (ddlContractId.Text != " ")
            {
                objFOBDTO.ContactId = ddlContractId.SelectedValue.ToString();
            }
            else
            {
                objFOBDTO.ContactId = "";

            }


            objFOBDTO.FOBDate = dtpFOBDate.Text;
            objFOBDTO.TranId = strTranId;

            if (ddlPOId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.POId = ddlPOId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.POId = "";

            }

            if (ddlStyleId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.StyleId = ddlStyleId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.StyleId = "";

            }

            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.BuyerId = "";

            }

            if (ddlSeasonId.Text != " ")
            {
                objFOBDTO.SeasonId = ddlSeasonId.SelectedValue.ToString();
            }
            else
            {
                objFOBDTO.SeasonId = "";

            }



            objFOBDTO.UpdateBy = strEmployeeId;
            objFOBDTO.HeadOfficeId = strHeadOfficeId;
            objFOBDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objFOBBLL.deleteFOBActualCostRecord(objFOBDTO);
            MessageBox(strMsg);


        }
        public void processFOBActualCostFromFOBBudget()
        {


            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();



           
            objFOBDTO.FOBDate = dtpFOBDate.Text;
            objFOBDTO.AmendmentDate = dtpAmendmentDate.Text;

            if (ddlContractId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.ContractId = ddlContractId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.ContractId = "";

            }


            if (ddlPOId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.POId = ddlPOId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.POId = "";

            }

            if (ddlStyleId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.StyleId = ddlStyleId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.StyleId = "";

            }

            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objFOBDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

            }
            else
            {
                objFOBDTO.BuyerId = "";

            }






            if (ddlSeasonId.Text != " ")
            {
                objFOBDTO.SeasonId = ddlSeasonId.SelectedValue.ToString();
            }
            else
            {
                objFOBDTO.SeasonId = "";

            }



            objFOBDTO.UpdateBy = strEmployeeId;
            objFOBDTO.HeadOfficeId = strHeadOfficeId;
            objFOBDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objFOBBLL.processFOBActualCostFromFOBBudget(objFOBDTO);
            //MessageBox(strMsg);


        }

        protected void txtContractNo_TextChanged(object sender, EventArgs e)
        {
            if (ddlBuyerId.Text == " ")
            {
                string strMsg = "Please Select Buyer Name!!!";
                MessageBox(strMsg);
                ddlBuyerId.Focus();
                return;


            }


            if (ddlContractId.Text == "")
            {
                string strMsg = "Please Select Contract NO!!!";
                ddlContractId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {

                getPOIdContract();

            }
        }

        protected void ddlPOId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuyerId.Text == " ")
            {
                string strMsg = "Please Select Buyer Name!!!";
                MessageBox(strMsg);
                ddlBuyerId.Focus();
                return;


            }


            if (ddlContractId.Text == "")
            {
                string strMsg = "Please Select Contract NO!!!";
                ddlContractId.Focus();
                MessageBox(strMsg);
                return;

            }
            else if (ddlPOId.Text == " ")
            {

                string strMsg = "Please Select PO !!!";
                ddlPOId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {

                getStyleIdContract();

            }
        }

        protected void ddlPOIdLoad_SelectedIndexChanged(object sender, EventArgs e)
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();

            DropDownList tb = (DropDownList)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;

            DropDownList ddlPOIdLoad = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlPOIdLoad");
            DropDownList ddlStyleIdLoad = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlStyleIdLoad");

            ddlStyleIdLoad.DataSource = objLookUpBLL.getStyleIdFOBBudget(ddlPOIdLoad.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);


            ddlStyleIdLoad.DataTextField = "STYLE_NO";
            ddlStyleIdLoad.DataValueField = "STYLE_ID";

            ddlStyleIdLoad.DataBind();
            if (ddlStyleIdLoad.Items.Count > 0)
            {

                ddlStyleIdLoad.SelectedIndex = 0;
            }




        }



        public void getPOIdContract()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPOId.DataSource = objLookUpBLL.getPOIdContract(ddlContractId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);

            ddlPOId.DataTextField = "PO_NO";
            ddlPOId.DataValueField = "PO_ID";

            ddlPOId.DataBind();
            if (ddlPOId.Items.Count > 0)
            {

                ddlPOId.SelectedIndex = 0;
            }


        }

     

        public void getStyleIdContract()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlStyleId.DataSource = objLookUpBLL.getStyleIdContract( ddlContractId.SelectedValue.ToString(), ddlPOId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);

            ddlStyleId.DataTextField = "STYLE_NO";
            ddlStyleId.DataValueField = "STYLE_ID";

            ddlStyleId.DataBind();
            if (ddlStyleId.Items.Count > 0)
            {

                ddlStyleId.SelectedIndex = 0;
            }


        }

        protected void ddlStyleId_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlBuyerId.Text == "")
            {
                string strMsg = "Please Select Buyer Name!!!";
                ddlBuyerId.Focus();
                MessageBox(strMsg);
                return;

            }


            else if (ddlContractId.Text == "")
            {
                string strMsg = "Please Enter Contract NO!!!";
                ddlContractId.Focus();
                MessageBox(strMsg);
                return;

            }
            else if (ddlPOId.Text == " ")
            {

                string strMsg = "Please Select PO !!!";
                ddlPOId.Focus();
                MessageBox(strMsg);
                return;

            }
            else if (ddlStyleId.Text == " ")
            {

                string strMsg = "Please Select Style !!!";
                ddlStyleId.Focus();
                MessageBox(strMsg);
                return;

            }

            else
            {

                searcFOBDate(ddlBuyerId.SelectedValue.ToString(), ddlContractId.SelectedValue.ToString(), ddlPOId.SelectedValue.ToString(), ddlStyleId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);
                searcOrderQuantityBYPOStyle(ddlBuyerId.SelectedValue.ToString(), ddlContractId.SelectedValue.ToString(), ddlPOId.SelectedValue.ToString(), ddlStyleId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);

                processFOBActualCostFromFOBBudget();
                
                searchFOBActualCostSheetRecord();

            }
        }

        public void searcFOBDate(string strBuyerId, string strContractId, string strPOId, string strStyleId, string strHeadOfficeId, string strBranchOfficeId)
        {
            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();
            

            objFOBDTO = objFOBBLL.searcFOBDate(strBuyerId, strContractId, strPOId, strStyleId, strHeadOfficeId, strBranchOfficeId);





            if (objFOBDTO.FOBDate == "0")
            {

                //nothing to do
            }
            else
            {
                dtpFOBDate.Text = objFOBDTO.FOBDate;
            }


           

            if (objFOBDTO.SeasonId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlSeasonId.SelectedValue = objFOBDTO.SeasonId;
            }



        }
        public void searcOrderQuantityBYPOStyle(string strBuyerId, string strContractNo, string strPOId, string strStyleId, string strHeadOfficeId, string strBranchOfficeId)
        {
            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();

            string strAmendId = "";


            objFOBDTO = objFOBBLL.searcOrderQuantityBYPOStyle(strBuyerId, strContractNo, strPOId, strStyleId, strHeadOfficeId, strBranchOfficeId);





            if (objFOBDTO.OrderQuantity == "0")
            {

                txtOrderQuantity.Text = "";
            }
            else
            {
                txtOrderQuantity.Text = objFOBDTO.OrderQuantity;
            }






        }
        public void searchActualCostMainRecord(string strContractNo, string strFOBDate, string strAmmendmentDate, string strPONo, string strStyleNo, string strBuyerName, string strSeasonName, string strHeadOfficeId, string strBranchOfficeId)
        {
            CostingDTO objCostingDTO = new CostingDTO();
            CostingBLL objCostingBLL = new CostingBLL();

            string strAmendId = "";


            objCostingDTO = objCostingBLL.searchActualCostMainRecord(strContractNo, strFOBDate, strAmmendmentDate, strPONo, strStyleNo, strBuyerName, strSeasonName, strHeadOfficeId, strBranchOfficeId);


            if (objCostingDTO.BuyerId == "0")
            {


            }
            else
            {
                ddlBuyerId.Text = objCostingDTO.BuyerId;
            }

            if (objCostingDTO.ContractId == "0")
            {


            }
            else
            {
                ddlContractId.Text = objCostingDTO.ContractId;
            }


            if (objCostingDTO.POId == "0")
            {


            }
            else
            {
                ddlPOId.Text = objCostingDTO.POId;
            }


            if (objCostingDTO.StyleId == "0")
            {


            }
            else
            {
                ddlStyleId.Text = objCostingDTO.StyleId;
            }




            if (objCostingDTO.SeasonId == "0")
            {


            }
            else
            {
                ddlSeasonId.Text = objCostingDTO.SeasonId;
            }

            if (objCostingDTO.OrderQuantity == "0")
            {


            }
            else
            {
                txtOrderQuantity.Text = objCostingDTO.OrderQuantity;
            }


            if (objCostingDTO.AmendmentDate == " ")
            {

                //nothing to do
            }
            else
            {
                dtpAmendmentDate.Text = objCostingDTO.AmendmentDate;
            }


            if (objCostingDTO.CostingDate == " ")
            {

                //nothing to do
            }
            else
            {
                dtpFOBDate.Text = objCostingDTO.CostingDate;
            }


        }
        public void searchFOBActualCost()
        {


            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();


            DataTable dt = new DataTable();


            objFOBDTO.ContactNo = txtContractNoSearch.Text;
            objFOBDTO.FOBDate = dtpIssueDateSearch.Text;
           
            objFOBDTO.Year = txtYear.Text;

            if (ddlPOIdSearch.SelectedValue.ToString() != " ")
            {
                objFOBDTO.POId = ddlPOIdSearch.SelectedValue.ToString();

            }
            else
            {

                objFOBDTO.POId = "";

            }


            if (ddlStyleIdSearch.SelectedValue.ToString() != " ")
            {
                objFOBDTO.StyleId = ddlStyleIdSearch.SelectedValue.ToString();

            }
            else
            {

                objFOBDTO.StyleId = "";

            }


            if (ddlSeasonIdSearch.SelectedValue.ToString() != " ")
            {
                objFOBDTO.SeasonId = ddlSeasonIdSearch.SelectedValue.ToString();

            }
            else
            {

                objFOBDTO.SeasonId = "";

            }

            if (ddlBuyerIdSearch.SelectedValue.ToString() != " ")
            {
                objFOBDTO.BuyerId = ddlBuyerIdSearch.SelectedValue.ToString();

            }
            else
            {

                objFOBDTO.BuyerId = "";

            }



            objFOBDTO.HeadOfficeId = strHeadOfficeId;
            objFOBDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFOBBLL.searchFOBActualCost(objFOBDTO);


            if (dt.Rows.Count > 0)
            {
                gvForeignFabric.DataSource = dt;
                gvForeignFabric.DataBind();

                int count = ((DataTable)gvForeignFabric.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
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
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


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


            string strContracNo = gvForeignFabric.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strFOBDate = gvForeignFabric.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

            string strPONo = gvForeignFabric.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string strStyleNo = gvForeignFabric.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string strBuyerName = gvForeignFabric.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            string strSeasonName = gvForeignFabric.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            string strAmmendmentDate = gvForeignFabric.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

            getContractId();
            getPOId();
            getStyleId();

            searchActualCostMainRecord(strContracNo, strFOBDate, strAmmendmentDate, strPONo, strStyleNo, strBuyerName, strSeasonName, strHeadOfficeId, strBranchOfficeId);
            searchFOBActualCostSheetRecord();
        }
        protected void btnSearchRecord_Click(object sender, EventArgs e)
        {
            searchFOBActualCost();
        }

        protected void gvForeignFabric_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void ddlBuyerId_SelectedIndexChanged(object sender, EventArgs e)
        {
            searcContractId();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            int rowindex = 0;

            DropDownList ddlFabricId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlFabricId");



            ddlFabricId.DataSource = objLookUpBLL.getFabricDescriptionId(ddlBuyerId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);

            ddlFabricId.DataTextField = "FABRIC_NAME";
            ddlFabricId.DataValueField = "FABRIC_ID";

            ddlFabricId.DataBind();
            if (ddlFabricId.Items.Count > 0)
            {
                ddlFabricId.SelectedIndex = 0;


            }
        }

        public void searcContractId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
          
            ddlContractId.DataSource = objLookUpBLL.searcContractId(txtYear.Text, ddlBuyerId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);

            ddlContractId.DataTextField = "CONTRACT_NO";
            ddlContractId.DataValueField = "CONTRACT_ID";

            ddlContractId.DataBind();
            if (ddlContractId.Items.Count > 0)
            {

                ddlContractId.SelectedIndex = 0;
            }



        }

        protected void ddlContractId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBuyerId.Text == "")
            {
                string strMsg = "Please Select Buyer Name!!!";
                ddlBuyerId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {

                getPOIdContract();
            }
        }

        protected void btnSearchContractId_Click(object sender, EventArgs e)
        {
            if (ddlBuyerId.Text == "")
            {
                string strMsg = "Please Select Buyer Name!!!";
                ddlBuyerId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {
                searcContractId();
            }
        }

        protected void btnSearchPOId_Click(object sender, EventArgs e)
        {
            if (ddlBuyerId.Text == "")
            {
                string strMsg = "Please Select Buyer Name!!!";
                ddlBuyerId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {

                getPOIdContract();
            }
        }

        protected void btnSearchStyleId_Click(object sender, EventArgs e)
        {
            if (ddlBuyerId.Text == " ")
            {
                string strMsg = "Please Select Buyer Name!!!";
                MessageBox(strMsg);
                ddlBuyerId.Focus();
                return;


            }


            if (ddlContractId.Text == "")
            {
                string strMsg = "Please Select Contract NO!!!";
                ddlContractId.Focus();
                MessageBox(strMsg);
                return;

            }
            else if (ddlPOId.Text == " ")
            {

                string strMsg = "Please Select PO !!!";
                ddlPOId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {

                getStyleIdContract();

            }
        }

        protected void btnSearchOthers_Click(object sender, EventArgs e)
        {
            if (ddlBuyerId.Text == "")
            {
                string strMsg = "Please Select Buyer Name!!!";
                ddlBuyerId.Focus();
                MessageBox(strMsg);
                return;

            }


            else if (ddlContractId.Text == "")
            {
                string strMsg = "Please Enter Contract NO!!!";
                ddlContractId.Focus();
                MessageBox(strMsg);
                return;

            }
            else if (ddlPOId.Text == " ")
            {

                string strMsg = "Please Select PO !!!";
                ddlPOId.Focus();
                MessageBox(strMsg);
                return;

            }
            else if (ddlStyleId.Text == " ")
            {

                string strMsg = "Please Select Style !!!";
                ddlStyleId.Focus();
                MessageBox(strMsg);
                return;

            }

            else
            {

                searcFOBDate(ddlBuyerId.SelectedValue.ToString(), ddlContractId.SelectedValue.ToString(), ddlPOId.SelectedValue.ToString(), ddlStyleId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);
                searcOrderQuantityBYPOStyle(ddlBuyerId.SelectedValue.ToString(), ddlContractId.SelectedValue.ToString(), ddlPOId.SelectedValue.ToString(), ddlStyleId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);

                processFOBActualCostFromFOBBudget();
              
                searchFOBActualCostSheetRecord();
            }
        }

        //#region "Grid View Functionality"
        //protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvEmployeeList.PageIndex = e.NewPageIndex;

        //}

        //protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        //{



        //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
        //    string strContactNo = gvEmployeeList.SelectedRow.Cells[1].Text;
        //    string strIssueDate = gvEmployeeList.SelectedRow.Cells[2].Text;




        //}


        //protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{


        //}

        //protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        //{

        //}


        //protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
        //{



        //    e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        //    e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");



        //}

        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{



        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
        //        e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

        //        e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);

        //    }


        //}


        //protected void gvEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
        //{

        //}




        //#endregion

        protected void ddlFabricId_SelectedIndexChanged(object sender, EventArgs e)
        {

            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();

            int gvShipmentInfo_CountRow = gvContractDetails.Rows.Count;
            string strAmendId = "";

            for (int i = 0; i < gvShipmentInfo_CountRow; i++)
            {

                DropDownList ddlFabricId = (DropDownList)gvContractDetails.Rows[i].FindControl("ddlFabricId");

                objFOBDTO = objFOBBLL.searcBudgetValue(ddlFabricId.SelectedValue.ToString(), ddlBuyerId.SelectedValue.ToString(), ddlContractId.SelectedValue.ToString(), ddlPOId.SelectedValue.ToString(), ddlStyleId.SelectedValue.ToString(), dtpFOBDate.Text, strHeadOfficeId, strBranchOfficeId);
                TextBox txtBudgetValue = (TextBox)gvContractDetails.Rows[i].FindControl("txtBudgetValue");


                if (objFOBDTO.BudgetValue == "0")
                {

                    txtBudgetValue.Text = "0";
                }
                else
                {

                    txtBudgetValue.Text = objFOBDTO.BudgetValue;
                }



            }

        }


    }
}