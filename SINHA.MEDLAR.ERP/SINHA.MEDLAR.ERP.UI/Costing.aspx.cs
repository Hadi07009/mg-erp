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
    public partial class Costing : System.Web.UI.Page
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
                getSeasonIdSearch();
                getStyleSearch();
                getPoIdSearch();
                getBuyerId();
                getBuyerIdSearch();



            }

            if (IsPostBack)
            {

                loadSesscion();

            }


            gvContractDetails.Columns[10].Visible = false;
            //textbox1.Attribute.Add("onblur", "updateValue()");
            //textbox2.Attribute.Add("onblur", "updateValue()");



        }


        #region "Function"

        public void getCurrentYear()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYear();

            txtYear.Text = objLookUpDTO.Year;




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



        public void getBuyerIdSearch()
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

        public void getStyleSearch()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlStyleIdSearch.DataSource = objLookUpBLL.getStyleIdContract();

            ddlStyleIdSearch.DataTextField = "STYLE_NO";
            ddlStyleIdSearch.DataValueField = "STYLE_ID";

            ddlStyleIdSearch.DataBind();
            if (ddlStyleIdSearch.Items.Count > 0)
            {

                ddlStyleIdSearch.SelectedIndex = 0;
            }
        }
        public void getPoIdSearch()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPOIdSearch.DataSource = objLookUpBLL.getPOIdContract();

            ddlPOIdSearch.DataTextField = "PO_NO";
            ddlPOIdSearch.DataValueField = "PO_ID";

            ddlPOIdSearch.DataBind();
            if (ddlPOIdSearch.Items.Count > 0)
            {

                ddlPOIdSearch.SelectedIndex = 0;
            }
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




        public void getPOIdContract()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPOId.DataSource = objLookUpBLL.getPOIdContract(ddlContractId.SelectedValue.ToString(),  strHeadOfficeId, strBranchOfficeId);

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
            ddlStyleId.DataSource = objLookUpBLL.getStyleIdContract(ddlContractId.SelectedValue.ToString(), ddlPOId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);

            ddlStyleId.DataTextField = "STYLE_NO";
            ddlStyleId.DataValueField = "STYLE_ID";

            ddlStyleId.DataBind();
            if (ddlStyleId.Items.Count > 0)
            {

                ddlStyleId.SelectedIndex = 0;
            }


        }



        private void FirstGridViewRow()
        {



            DataTable dt = new DataTable();
            DataRow dr = null;


            dt.Columns.Add(new DataColumn("fabric_id", typeof(string)));
      
            dt.Columns.Add(new DataColumn("ART_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("CONSTRUCTION", typeof(string)));
             dt.Columns.Add(new DataColumn("COLOR_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("SIZE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("CONSUMPTION", typeof(string)));
            dt.Columns.Add(new DataColumn("QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("UNIT_ID", typeof(string)));

            dt.Columns.Add(new DataColumn("UNIT_PRICE", typeof(string)));
            dt.Columns.Add(new DataColumn("TOTAL_PRICE", typeof(string)));
          
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));


            dr = dt.NewRow();


            dr["fabric_id"] = string.Empty;

            dr["ART_ID"] = string.Empty;
            dr["CONSTRUCTION"] = string.Empty;
            dr["COLOR_ID"] = string.Empty;
            dr["SIZE_ID"] = string.Empty;
            dr["CONSUMPTION"] = string.Empty;
            dr["QUANTITY"] = string.Empty;
            dr["UNIT_ID"] = string.Empty;


            dr["UNIT_PRICE"] = string.Empty;
            dr["TOTAL_PRICE"] = string.Empty;

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

                        DropDownList ddlArtId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlArtId");
                        TextBox txtConstruction = (TextBox)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("txtConstruction");
                        DropDownList ddlColorId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                        DropDownList ddlSizeId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("ddlSizeId");
                        TextBox txtConsumption = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtConsumption");
                        TextBox txtQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtQuantity");

                        DropDownList ddlUnitId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("ddlUnitId");
                        TextBox txtUnitPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtUnitPrice");
                        TextBox txtTotalPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtTotalPrice");
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("txtTranId");


                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["fabric_id"] = ddlFabricId.Text;
                      


                      
                        dtCurrentTable.Rows[i - 1]["ART_ID"] = ddlArtId.Text;
                        dtCurrentTable.Rows[i - 1]["CONSTRUCTION"] = ddlArtId.Text;
                        dtCurrentTable.Rows[i - 1]["COLOR_ID"] = ddlSizeId.Text;
                        dtCurrentTable.Rows[i - 1]["SIZE_ID"] = ddlSizeId.Text;
                        dtCurrentTable.Rows[i - 1]["CONSUMPTION"] = txtConsumption.Text;
                        dtCurrentTable.Rows[i - 1]["QUANTITY"] = txtQuantity.Text;

                        dtCurrentTable.Rows[i - 1]["UNIT_ID"] = ddlUnitId.Text;
                        dtCurrentTable.Rows[i - 1]["UNIT_PRICE"] = txtUnitPrice.Text;
                        dtCurrentTable.Rows[i - 1]["TOTAL_PRICE"] = txtTotalPrice.Text;
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

                        DropDownList ddlArtId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlArtId");
                        TextBox txtConstruction = (TextBox)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("txtConstruction");
                        DropDownList ddlColorId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                        DropDownList ddlSizeId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("ddlSizeId");
                        TextBox txtConsumption = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtConsumption");
                        TextBox txtQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtQuantity");

                        DropDownList ddlUnitId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("ddlUnitId");
                        TextBox txtUnitPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtUnitPrice");
                        TextBox txtTotalPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtTotalPrice");
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("txtTranId");



                        ddlFabricId.Text = dt.Rows[i]["fabric_ID"].ToString();
                        ddlArtId.Text = dt.Rows[i]["ART_ID"].ToString();
                        txtConstruction.Text = dt.Rows[i]["CONSTRUCTION"].ToString();
                        ddlSizeId.Text = dt.Rows[i]["SIZE_ID"].ToString();
                       
                        ddlColorId.Text = dt.Rows[i]["COLOR_ID"].ToString();
                        ddlSizeId.Text = dt.Rows[i]["SIZE_ID"].ToString();
                        txtConsumption.Text = dt.Rows[i]["CONSUMPTION"].ToString();
                        txtQuantity.Text = dt.Rows[i]["QUANTITY"].ToString();
                        ddlUnitId.Text = dt.Rows[i]["UNIT_ID"].ToString();

                        txtUnitPrice.Text = dt.Rows[i]["UNIT_PRICE"].ToString();
                        txtTotalPrice.Text = dt.Rows[i]["TOTAL_PRICE"].ToString();
                      

                        txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();


                        rowIndex++;
                    }
                }
            }
        }





        

        public void saveCostingInfo()
        {


            CostingDTO objCostingDTO = new CostingDTO();
            CostingBLL objCostingBLL = new CostingBLL();

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

                        DropDownList ddlArtId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlArtId");
                        TextBox txtConstruction = (TextBox)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("txtConstruction");
                        DropDownList ddlColorId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                        DropDownList ddlSizeId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("ddlSizeId");
                        TextBox txtConsumption = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtConsumption");
                        TextBox txtQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtQuantity");

                        DropDownList ddlUnitId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("ddlUnitId");
                        TextBox txtUnitPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtUnitPrice");
                        TextBox txtTotalPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtTotalPrice");
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("txtTranId");



                        if (ddlFabricId.SelectedValue.ToString() != " ")
                        {
                            objCostingDTO.FabricId = ddlFabricId.SelectedValue.ToString();

                        }
                        else
                        {
                            objCostingDTO.FabricId = "";

                        }






                       


                        if (ddlArtId.SelectedValue.ToString() != " ")
                        {
                            objCostingDTO.ArtId = ddlArtId.SelectedValue.ToString();

                        }
                        else
                        {
                            objCostingDTO.ArtId = "";

                        }

                        objCostingDTO.Construction = txtConstruction.Text;

                        if (ddlColorId.SelectedValue.ToString() != " ")
                        {
                            objCostingDTO.ColorId = ddlColorId.SelectedValue.ToString();

                        }
                        else
                        {
                            objCostingDTO.ColorId = "";

                        }


                        if (ddlSizeId.SelectedValue.ToString() != " ")
                        {
                            objCostingDTO.SizeId = ddlSizeId.SelectedValue.ToString();

                        }
                        else
                        {
                            objCostingDTO.SizeId = "";

                        }


                        if (ddlUnitId.SelectedValue.ToString() != " ")
                        {
                            objCostingDTO.UnitId = ddlUnitId.SelectedValue.ToString();

                        }
                        else
                        {
                            objCostingDTO.UnitId = "";

                        }


                        objCostingDTO.Consumption = txtConsumption.Text;
                        objCostingDTO.Quantity = txtQuantity.Text;
                        objCostingDTO.UnitPrice = txtUnitPrice.Text;
                        objCostingDTO.TotalPrice = txtTotalPrice.Text;
                        objCostingDTO.TranId = txtTranId.Text;

                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objCostingDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                        }
                        else
                        {
                            objCostingDTO.BuyerId = "";

                        }

                       

                       
                        if (dtpCostingDate.Text == "")
                        {
                            objCostingDTO.CostingDate = "";
                        }
                        else
                        {
                            objCostingDTO.CostingDate = dtpCostingDate.Text;

                        }

                        if (ddlContractId.SelectedValue.ToString() != " ")
                        {
                            objCostingDTO.ContractId = ddlContractId.SelectedValue.ToString();

                        }
                        else
                        {
                            objCostingDTO.ContractId = "";

                        }

                        if (ddlPOId.SelectedValue.ToString() != " ")
                        {
                            objCostingDTO.POId = ddlPOId.SelectedValue.ToString();

                        }
                        else
                        {
                            objCostingDTO.POId = "";

                        }

                        if (ddlStyleId.SelectedValue.ToString() != " ")
                        {
                            objCostingDTO.StyleId = ddlStyleId.SelectedValue.ToString();

                        }
                        else
                        {
                            objCostingDTO.StyleId = "";

                        }







                        if (ddlSeasonId.SelectedValue.ToString() != "")
                        {
                            objCostingDTO.SeasonId = ddlSeasonId.SelectedValue.ToString();

                        }
                        else
                        {

                            objCostingDTO.SeasonId = "";

                        }

                        objCostingDTO.OrderQuantity = txtOrderQuantity.Text;

                        objCostingDTO.AmendmentDate = dtpAmendmentDate.Text;

                        objCostingDTO.UpdateBy = strEmployeeId;
                        objCostingDTO.HeadOfficeId = strHeadOfficeId;
                        objCostingDTO.BranchOfficeId = strBranchOfficeId;
                       




                        strMsg = objCostingBLL.saveCostingInfo(objCostingDTO);
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




      

        public void searchCostingSubRecord()
        {



            CostingDTO objCostingDTO = new CostingDTO();
            CostingBLL objCostingBLL = new CostingBLL();

            DataTable dt = new DataTable();



            objCostingDTO.CostingDate = dtpCostingDate.Text;

            if (ddlContractId.Text != " ")
            {

                objCostingDTO.ContractId = ddlContractId.SelectedValue.ToString();

            }
            else
            {

                objCostingDTO.ContractId = "";

            }


            if (ddlBuyerId.Text != " ")
            {

                objCostingDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

            }
            else
            {

                objCostingDTO.BuyerId = "";

            }



            if (ddlPOId.Text != " ")
            {

                objCostingDTO.POId = ddlPOId.SelectedValue.ToString();

            }
            else
            {

                objCostingDTO.POId = "";

            }


            if (ddlStyleId.Text != " ")
            {

                objCostingDTO.StyleId = ddlStyleId.SelectedValue.ToString();

            }
            else
            {

                objCostingDTO.StyleId = "";

            }





            if (ddlSeasonId.Text != " ")
            {

                objCostingDTO.SeasonId = ddlSeasonId.SelectedValue.ToString();

            }
            else
            {

                objCostingDTO.SeasonId = "";

            }

            if (dtpAmendmentDate.Text.Length > 6)
            {

                objCostingDTO.AmendmentDate = dtpAmendmentDate.Text;

            }
            else
            {

                objCostingDTO.AmendmentDate = "";

            }




            objCostingDTO.HeadOfficeId = strHeadOfficeId;
            objCostingDTO.BranchOfficeId = strBranchOfficeId;

            dt = objCostingBLL.searchCostingSubRecord(objCostingDTO);


            if (dt.Rows.Count > 0)
            {
                gvContractDetails.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvContractDetails.DataBind();



                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox txtTotalPrice = (TextBox)gvContractDetails.Rows[i].FindControl("txtTotalPrice");
                    txtTotalPrice.Attributes.Add("readonly", "readonly");

                    //TextBox txtBudgetValue = (TextBox)gvContractDetails.Rows[i].FindControl("txtBudgetValue");
                    //txtBudgetValue.Attributes.Add("readonly", "readonly");




                }

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





        public void searchCostingMain()
        {
            CostingDTO objCostingDTO = new CostingDTO();
            CostingBLL objCostingBLL = new CostingBLL();

            string strAmendId = "";


            objCostingDTO = objCostingBLL.searchCostingMain(ddlContractId.SelectedValue.ToString(), dtpCostingDate.Text, dtpAmendmentDate.Text, ddlPOId.SelectedValue.ToString(), ddlStyleId.SelectedValue.ToString(), ddlBuyerId.SelectedValue.ToString(), ddlSeasonId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);

          

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
                dtpCostingDate.Text = objCostingDTO.CostingDate;
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

        public void searcPOId()
        {
            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();

            string strAmendId = "";


            objFOBDTO = objFOBBLL.searcPOId(ddlContractId.Text, strHeadOfficeId, strBranchOfficeId);





            if (objFOBDTO.POId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlPOId.SelectedValue = objFOBDTO.POId;
            }


 



        }
        public void searcFOBDate(string strBuyerId, string strContractNo, string strPOId,string strStyleId, string strHeadOfficeId, string strBranchOfficeId)
        {
            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();

            string strAmendId = "";


            objFOBDTO = objFOBBLL.searcFOBDateCosting(strBuyerId, strContractNo, strPOId, strStyleId, strHeadOfficeId, strBranchOfficeId);





            if (objFOBDTO.FOBDate == "0")
            {

                //nothing to do
            }
            else
            {
                dtpCostingDate.Text = objFOBDTO.FOBDate;
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


            if (objFOBDTO.OrderQuantityForBig == "0")
            {

                txtOrderQuantityForBig.Text = "";
            }
            else
            {
                txtOrderQuantityForBig.Text = objFOBDTO.OrderQuantityForBig;
            }


            if (objFOBDTO.OrderQuantityForReg == "0")
            {

                txtOrderQuantityForRegular.Text = "";
            }
            else
            {
                txtOrderQuantityForRegular.Text = objFOBDTO.OrderQuantityForReg;
            }


            if (objFOBDTO.OrderQuantityForTall == "0")
            {

                txtOrderQuantityForTall.Text = "";
            }
            else
            {
                txtOrderQuantityForTall.Text = objFOBDTO.OrderQuantityForTall;
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
            else if (dtpCostingDate.Text == "")
            {
                string strMsg = "Please Enter FOB Date!!!";
                MessageBox(strMsg);
                dtpCostingDate.Focus();
                return;


            }
            else if (ddlPOId.Text == " ")
            {
                string strMsg = "Please Select PO!!!";
                MessageBox(strMsg);
                ddlPOId.Focus();
                return;


            }
            else if (ddlStyleId.Text == " ")
            {
                string strMsg = "Please Select Style!!!";
                MessageBox(strMsg);
                ddlStyleId.Focus();
                return;


            }
            else if (ddlBuyerId.Text == " ")
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

                saveCostingInfo();
                searchCostingMain();
                searchCostingSubRecord();


            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchCostingSubRecord();
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

            else if (ddlPOId.Text == " ")
            {
                string strMsg = "Please Enter PO NO!!!";
                MessageBox(strMsg);
                ddlPOId.Focus();
                return;
            }

            else if (ddlStyleId.Text == " ")
            {
                string strMsg = "Please Enter Style NO!!!";
                MessageBox(strMsg);
                ddlStyleId.Focus();
                return;
            }


            else
            {
                
                searchCostingMain();
                searchCostingSubRecord();


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


            int stor_id = Convert.ToInt32(gvContractDetails.DataKeys[e.RowIndex].Values["TRAN_ID"].ToString());

            string strTranId = Convert.ToString(stor_id);
            deletePerCostSheetRecord(strTranId);
            searchCostingMain();
            searchCostingSubRecord();

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

                DropDownList a = (e.Row.FindControl("ddlSizeId") as DropDownList);


                DataTable dt = new DataTable();


                DataRowView dr = e.Row.DataItem as DataRowView;


                dt = objLookUpBLL.getSizeId();
                a.DataSource = dt;
                a.DataBind();
                a.SelectedValue = dr["SIZE_ID"].ToString();





                DropDownList c = (e.Row.FindControl("ddlArtId") as DropDownList);


                DataTable dt2 = new DataTable();


                DataRowView dr2 = e.Row.DataItem as DataRowView;


                dt2 = objLookUpBLL.getArtId();
                c.DataSource = dt2;
                c.DataBind();
                c.SelectedValue = dr2["ART_ID"].ToString();



                DataTable dt3 = new DataTable();
                DataRowView dr3 = e.Row.DataItem as DataRowView;
                DropDownList d = (e.Row.FindControl("ddlFabricId") as DropDownList);

                dt3 = objLookUpBLL.getFabricDescriptionId(ddlBuyerId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);
                d.DataSource = dt3;
                d.DataBind();
                d.SelectedValue = dr3["FABRIC_ID"].ToString();


              


                DataTable dt5 = new DataTable();
                DataRowView dr5 = e.Row.DataItem as DataRowView;
                DropDownList h = (e.Row.FindControl("ddlColorId") as DropDownList);

                dt5 = objLookUpBLL.getColorIdContract();
                h.DataSource = dt5;
               h.DataBind();
               h.SelectedValue = dr5["COLOR_ID"].ToString();


                DataTable dt6 = new DataTable();
                DataRowView dr6 = e.Row.DataItem as DataRowView;
                DropDownList u = (e.Row.FindControl("ddlUnitId") as DropDownList);

                dt6 = objLookUpBLL.getUnitIdStore(strHeadOfficeId, strBranchOfficeId);
                u.DataSource = dt6;
                u.DataBind();
                u.SelectedValue = dr6["UNIT_ID"].ToString();





                //for (int i = 0; i < gvContractDetails.Rows.Count; i++)
                //{
                //    int qty = Convert.ToInt32(txtOrderQuantity.Text);
                //    int consumption = Convert.ToInt32(gvContractDetails.Rows[i].Cells[5].ToString());

                //    int total = qty * qty;
                //    gvContractDetails.Rows[i].Cells[6].Text = total.ToString();

                //}




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


        public void searchCostingMainRecord(string strContractNo,string strFOBDate,string strAmmendmentDate,string strPONo, string strStyleNo, string strBuyerName,string strSeasonName, string strHeadOfficeId, string strBranchOfficeId)
        {
            CostingDTO objCostingDTO = new CostingDTO();
            CostingBLL objCostingBLL = new CostingBLL();

            string strAmendId = "";


            objCostingDTO = objCostingBLL.searchCostingMainRecord(strContractNo, strFOBDate, strAmmendmentDate, strPONo, strStyleNo, strBuyerName, strSeasonName, strHeadOfficeId, strBranchOfficeId);


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


            if (objCostingDTO.OrderQuantity == "0")
            {


            }
            else
            {
                txtOrderQuantity.Text = objCostingDTO.OrderQuantity;
            }

            if (objCostingDTO.SeasonId == "0")
            {


            }
            else
            {
                ddlSeasonId.Text = objCostingDTO.SeasonId;
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
                dtpCostingDate.Text = objCostingDTO.CostingDate;
            }


        }

        public void deletePerCostSheetRecord(string strTranId)
        {


            CostingDTO objCostingDTO = new CostingDTO();
            CostingBLL objCostingBLL = new CostingBLL();


            if (ddlContractId.Text != " ")
            {
                objCostingDTO.ContractId = ddlContractId.SelectedValue.ToString();
            }
            else
            {
                objCostingDTO.ContractId = "";

            }



            objCostingDTO.CostingDate = dtpCostingDate.Text;
            objCostingDTO.TranId = strTranId;
            if (ddlPOId.Text != " ")
            {
                objCostingDTO.POId = ddlPOId.SelectedValue.ToString();
            }
            else
            {
                objCostingDTO.POId = "";

            }


            if (ddlStyleId.Text != " ")
            {
                objCostingDTO.StyleId = ddlStyleId.SelectedValue.ToString();
            }
            else
            {
                objCostingDTO.StyleId = "";

            }


            if (ddlBuyerId.Text != " ")
            {
                objCostingDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
            }
            else
            {
                objCostingDTO.BuyerId = "";

            }


            if (ddlSeasonId.Text != " ")
            {
                objCostingDTO.SeasonId = ddlSeasonId.SelectedValue.ToString();
            }
            else
            {
                objCostingDTO.SeasonId = "";

            }



            objCostingDTO.UpdateBy = strEmployeeId;
            objCostingDTO.HeadOfficeId = strHeadOfficeId;
            objCostingDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objCostingBLL.deletePerCostingRecord(objCostingDTO);
            MessageBox(strMsg);


        }

        protected void btnSearchPOId_Click(object sender, EventArgs e)
        {
            if(ddlContractId.Text =="")
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


        protected void txtConsumption_TextChanged(object sender, EventArgs e)
        {

            TextBox tb = (TextBox)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;


            DropDownList ddlFabricId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlFabricId");
            DropDownList ddlSizeId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlSizeId");


            TextBox txtConsumption = (TextBox)gvContractDetails.Rows[rowindex].FindControl("txtConsumption");
            txtConsumption.Attributes.Add("readonly", "readonly");

            TextBox txtQuantity = (TextBox)gvContractDetails.Rows[rowindex].FindControl("txtQuantity");
            txtQuantity.Attributes.Add("readonly", "readonly");

            if(ddlFabricId.SelectedValue =="15")
            {
                if(ddlSizeId.SelectedValue == "1")
                {
                    Double totalQTY = Convert.ToDouble(txtConsumption.Text) * Convert.ToDouble(txtOrderQuantityForRegular.Text);
                    txtQuantity.Text = Convert.ToString(totalQTY);

                }

                if (ddlSizeId.SelectedValue == "2")
                {
                    Double totalQTY = Convert.ToDouble(txtConsumption.Text) * Convert.ToDouble(txtOrderQuantityForTall.Text);
                    txtQuantity.Text = Convert.ToString(totalQTY);

                }


                if (ddlSizeId.SelectedValue == "3")
                {

                    Double totalQTY = Convert.ToDouble(txtConsumption.Text) * Convert.ToDouble(txtOrderQuantityForBig.Text);
                    txtQuantity.Text = Convert.ToString(totalQTY);
                }



            }
            else
            {
                Double totalQTY = Convert.ToDouble(txtConsumption.Text) * Convert.ToDouble(txtOrderQuantity.Text);
                txtQuantity.Text = Convert.ToString(totalQTY);

            }







        }

        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {

            TextBox tb = (TextBox)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;


            TextBox txtUnitPrice = (TextBox)gvContractDetails.Rows[rowindex].FindControl("txtUnitPrice");
            txtUnitPrice.Attributes.Add("readonly", "readonly");

            TextBox txtQuantity = (TextBox)gvContractDetails.Rows[rowindex].FindControl("txtQuantity");
            txtQuantity.Attributes.Add("readonly", "readonly");

            TextBox txtTotalPrice = (TextBox)gvContractDetails.Rows[rowindex].FindControl("txtTotalPrice");
            txtTotalPrice.Attributes.Add("readonly", "readonly");

            Double totalPrice = Convert.ToDouble(txtUnitPrice.Text) * Convert.ToDouble(txtQuantity.Text);
            txtTotalPrice.Text = Convert.ToString(totalPrice);

        }












        protected void ddlFabricId_SelectedIndexChanged(object sender, EventArgs e)
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DropDownList tb = (DropDownList)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;

            DropDownList ddlFabricId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlFabricId");
           // DropDownList ddlFabricSymbolicId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlFabricSymbolicId");

          
            //ddlFabricSymbolicId.DataSource = objLookUpBLL.getFabricDescriptionSymbolicId(ddlFabricId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);

            //ddlFabricSymbolicId.DataTextField = "FABRIC_SYMBOLIC_NAME";
            //ddlFabricSymbolicId.DataValueField = "FABRIC_SYMBOLIC_ID";

            //ddlFabricSymbolicId.DataBind();
            //if (ddlFabricSymbolicId.Items.Count > 0)
            //{

            //    ddlFabricSymbolicId.SelectedIndex = 0;
            //}










        }

       

        public void searchCostingInfo()
        {


            CostingDTO objCostingDTO = new CostingDTO();
            CostingBLL objCostingBLL = new CostingBLL();

            DataTable dt = new DataTable();


            objCostingDTO.ContactNo = txtContractNoSearch.Text;
            objCostingDTO.CostingDate = dtpIssueDateSearch.Text;

            objCostingDTO.AmendmentDate = dtpAmendmentDateSearch.Text;


            objCostingDTO.Year = txtYear.Text;

            if (ddlPOIdSearch.SelectedValue.ToString() != "0")
            {
                objCostingDTO.POId = ddlPOIdSearch.SelectedValue.ToString();

            }
            else
            {

                objCostingDTO.POId = "";

            }


            if (ddlStyleIdSearch.SelectedValue.ToString() != "0")
            {
                objCostingDTO.StyleId = ddlStyleIdSearch.SelectedValue.ToString();

            }
            else
            {

                objCostingDTO.StyleId = "";

            }


            if (ddlSeasonIdSearch.SelectedValue.ToString() != " ")
            {
                objCostingDTO.SeasonId = ddlSeasonIdSearch.SelectedValue.ToString();

            }
            else
            {

                objCostingDTO.SeasonId = "";

            }

            if (ddlBuyerIdSearch.SelectedValue.ToString() != " ")
            {
                objCostingDTO.BuyerId = ddlBuyerIdSearch.SelectedValue.ToString();

            }
            else
            {

                objCostingDTO.BuyerId = "";

            }

            objCostingDTO.HeadOfficeId = strHeadOfficeId;
            objCostingDTO.BranchOfficeId = strBranchOfficeId;

            dt = objCostingBLL.searchCostingInfo(objCostingDTO);


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
        protected void btnSearchRecord_Click(object sender, EventArgs e)
        {
            searchCostingInfo();
        }








        #region "gridview"
        protected void gvForeignFabric_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvForeignFabric_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        protected void gvForeignFabric_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int strRowId = gvForeignFabric.SelectedRow.RowIndex + 1;


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

            searchCostingMainRecord(strContracNo, strFOBDate, strAmmendmentDate, strPONo, strStyleNo, strBuyerName, strSeasonName, strHeadOfficeId, strBranchOfficeId);
            searchCostingSubRecord();
        }
        #endregion

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



        protected void ddlSeasonId_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void btnSearchOthers_Click(object sender, EventArgs e)
        {
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

                searchCostingSubRecord();
            }
        }

        protected void btnSearchStyleId_Click(object sender, EventArgs e)
        {
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

        protected void ddlContractId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlContractId_SelectedIndexChanged1(object sender, EventArgs e)
        {
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
            if (ddlContractId.Text == "")
            {
                string strMsg = "Please Select Contract NO!!!";
                ddlContractId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {

                getStyleIdContract();

            }
        }

        protected void ddlStyleId_SelectedIndexChanged(object sender, EventArgs e)
        {
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

                searchCostingSubRecord();
            }
        }
    }
}