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
    public partial class ContractBooking : System.Web.UI.Page
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
             
               
                getCurrentYear();


            }

            if (IsPostBack)
            {

                loadSesscion();

            }

            gvContractDetails.Columns[6].Visible = false;






        }


        #region "Function"



        public void getCurrentYear()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYear();

          //  txtYear.Text = objLookUpDTO.Year;




        }

    



        private void FirstGridViewRow()
        {


          
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("MODEL_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("PO_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("STYLE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("COLOR_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("ORDER_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("SHIPPING_DATE", typeof(string)));
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));


            dr = dt.NewRow();

            dr["MODEL_NO"] = string.Empty;
            dr["PO_ID"] = string.Empty;
            dr["STYLE_ID"] = string.Empty;
            dr["COLOR_ID"] = string.Empty;
            dr["ORDER_QUANTITY"] = string.Empty;
            dr["SHIPPING_DATE"] = string.Empty;
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


                        TextBox txtModelNo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("txtModelNo");
                        DropDownList ddlPoId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlPoId");
                        DropDownList ddlStyleId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("ddlStyleId");
                        DropDownList ddlColorId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                        TextBox txtOrderQTY = (TextBox)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("txtOrderQTY");
                        TextBox dtpShippingDate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("dtpShippingDate");
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtTranId");


                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["MODEL_NO"] = txtModelNo.Text;
                        dtCurrentTable.Rows[i - 1]["PO_ID"] = ddlPoId.Text;
                        dtCurrentTable.Rows[i - 1]["STYLE_ID"] = ddlStyleId.Text;
                        dtCurrentTable.Rows[i - 1]["COLOR_ID"] = ddlColorId.Text;
                        dtCurrentTable.Rows[i - 1]["ORDER_QUANTITY"] = txtOrderQTY.Text;
                        dtCurrentTable.Rows[i - 1]["TRAN_ID"] = txtTranId.Text;


                        dtCurrentTable.Rows[i - 1]["SHIPPING_DATE"] = dtpShippingDate.Text;
                       


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


                        TextBox txtModelNo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("txtModelNo");
                        DropDownList ddlPoId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlPoId");
                        DropDownList ddlStyleId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("ddlStyleId");
                        DropDownList ddlColorId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                        TextBox txtOrderQTY = (TextBox)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("txtOrderQTY");
                        TextBox dtpShippingDate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("dtpShippingDate");
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtTranId");


                        txtModelNo.Text = dt.Rows[i]["MODEL_NO"].ToString();
                        ddlPoId.Text = dt.Rows[i]["PO_ID"].ToString();
                        ddlStyleId.Text = dt.Rows[i]["STYLE_ID"].ToString();
                        ddlColorId.Text = dt.Rows[i]["COLOR_ID"].ToString();
                        txtOrderQTY.Text = dt.Rows[i]["ORDER_QUANTITY"].ToString();
                        dtpShippingDate.Text = dt.Rows[i]["SHIPPING_DATE"].ToString();
                        txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();


                        rowIndex++;
                    }
                }
            }
        }

        public void deleteContractInfo(string strTranId)
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();



            //objContractDTO.ContactNo = txtContractNo.Text;
            //objContractDTO.IssueDate = dtpIssueDate.Text;
            //objContractDTO.AmendMentDate = dtpAmendmentDate.Text;
            //objContractDTO.TranId = strTranId;
            



            objContractDTO.UpdateBy = strEmployeeId;
            objContractDTO.HeadOfficeId = strHeadOfficeId;
            objContractDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objContractBLL.deleteContractInfo(objContractDTO);
            MessageBox(strMsg);


        }


        public void saveContractBooking()
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();

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
                        TextBox txtModelNo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("txtModelNo");
                        DropDownList ddlPoId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlPoId");
                        DropDownList ddlStyleId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("ddlStyleId");
                        DropDownList ddlColorId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                        TextBox txtOrderQTY = (TextBox)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("txtOrderQTY");

                        TextBox dtpShippingDate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("dtpShippingDate");
                       
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtTranId");



                        objContractDTO.TranId = txtTranId.Text;
                        objContractDTO.OrderQty = txtOrderQTY.Text;



                        objContractDTO.ModelNo = txtModelNo.Text;
                        if (ddlPoId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.POId = ddlPoId.SelectedValue.ToString();

                        }
                        else
                        {
                            objContractDTO.POId = "";

                        }

                        if (ddlStyleId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.StyleId = ddlStyleId.SelectedValue.ToString();

                        }
                        else
                        {
                            objContractDTO.StyleId = "";

                        }
                        if (ddlColorId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.ColorId = ddlColorId.SelectedValue.ToString();

                        }
                        else
                        {
                            objContractDTO.ColorId = "";

                        }
                       
                     
                        objContractDTO.ShippingDate = dtpShippingDate.Text;




                        objContractDTO.ContactNo = txtContractNo.Text;
                     

                        objContractDTO.UpdateBy = strEmployeeId;
                        objContractDTO.HeadOfficeId = strHeadOfficeId;
                        objContractDTO.BranchOfficeId = strBranchOfficeId;






                        strMsg = objContractBLL.saveContractBooking(objContractDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;

                        rowIndex++;



                    }

                    if (strMsg == "INSERTED SUCCESSFULLY" || strMsg == "UPDATED SUCCESSFULLY" || strMsg == "PLEASE CHECK AMMENDMENT DATE!!!" || strMsg == "PLEASE CREATE NEW AMMENDMENT!!!")
                    {
                        MessageBox(strMsg);

                    }

                    




                }


            }





        }

        //public void saveContractInfoTemp()
        //{


        //    ContractDTO objContractDTO = new ContractDTO();
        //    ContractBLL objContractBLL = new ContractBLL();

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
        //                TextBox txtPONo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("txtPONo");
        //                TextBox txtStyleNo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("txtStyleNo");
        //                TextBox txtItemName = (TextBox)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("txtItemName");
        //                DropDownList ddlSizeId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlSizeId");
        //                TextBox txtOrderQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("txtOrderQuantity");
        //                TextBox txtPOPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtPOPrice");
        //                TextBox txtHangerCostPerUnit = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtHangerCostPerUnit");
        //                TextBox txtUnitCost = (TextBox)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("txtUnitCost");
        //                TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtTotalAmount");
        //                TextBox txtShipingAddress = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtShipingAddress");
        //                TextBox dtpDeliveryDate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("dtpDeliveryDate");
        //                TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[11].FindControl("txtTranId");



        //                objContractDTO.TranId = txtTranId.Text;
        //                objContractDTO.AmendMentDate = dtpAmendmentDate.Text;
        //                objContractDTO.PONo = txtPONo.Text;
        //                objContractDTO.StyleNo = txtStyleNo.Text;
        //                objContractDTO.ItemName = txtItemName.Text;
        //                if (ddlSizeId.SelectedValue.ToString() != " ")
        //                {
        //                    objContractDTO.SizeId = ddlSizeId.SelectedValue.ToString();

        //                }
        //                else
        //                {
        //                    objContractDTO.SizeId = "";

        //                }
        //                objContractDTO.OrderQty = txtOrderQuantity.Text;
        //                objContractDTO.POPrice = txtPOPrice.Text;
        //                objContractDTO.HangerCostPerUnit = txtHangerCostPerUnit.Text;
        //                objContractDTO.UnitCost = txtUnitCost.Text;
        //                objContractDTO.TotalAmountInUSD = txtTotalAmount.Text;
        //                objContractDTO.ShippingAddress = txtShipingAddress.Text;
        //                objContractDTO.DeliveryDate = dtpDeliveryDate.Text;




        //                objContractDTO.ContactNo = txtContractNo.Text;
        //                objContractDTO.IssueDate = dtpIssueDate.Text;
        //                if (ddlVendorId.SelectedValue.ToString() != " ")
        //                {
        //                    objContractDTO.VendorId = ddlVendorId.SelectedValue.ToString();

        //                }
        //                else
        //                {

        //                    objContractDTO.VendorId = "";

        //                }

        //                if (ddlVendorBankId.SelectedValue.ToString() != " ")
        //                {
        //                    objContractDTO.VendorBankId = ddlVendorBankId.SelectedValue.ToString();

        //                }
        //                else
        //                {

        //                    objContractDTO.VendorBankId = "";

        //                }



        //                if (ddlManufacturerId.SelectedValue.ToString() != " ")
        //                {
        //                    objContractDTO.ManufactureId = ddlManufacturerId.SelectedValue.ToString();

        //                }
        //                else
        //                {

        //                    objContractDTO.ManufactureId = "";

        //                }

        //                if (ddlManufacturerBankId.SelectedValue.ToString() != " ")
        //                {
        //                    objContractDTO.ManufactureBankId = ddlManufacturerBankId.SelectedValue.ToString();

        //                }
        //                else
        //                {

        //                    objContractDTO.ManufactureBankId = "";

        //                }

        //                if (ddlShipId.SelectedValue.ToString() != " ")
        //                {
        //                    objContractDTO.ShipId = ddlShipId.SelectedValue.ToString();

        //                }
        //                else
        //                {

        //                    objContractDTO.ShipId = "";

        //                }


        //                if (ddlShipTypeId.SelectedValue.ToString() != " ")
        //                {
        //                    objContractDTO.ShipTypeId = ddlShipTypeId.SelectedValue.ToString();

        //                }
        //                else
        //                {

        //                    objContractDTO.ShipTypeId = "";

        //                }


        //                if (ddlPaymentTermId.SelectedValue.ToString() != " ")
        //                {
        //                    objContractDTO.PaymentTermId = ddlPaymentTermId.SelectedValue.ToString();

        //                }
        //                else
        //                {

        //                    objContractDTO.PaymentTermId = "";

        //                }


        //                objContractDTO.UltimateConsigneeId = "";

        //                objContractDTO.UpdateBy = strEmployeeId;
        //                objContractDTO.HeadOfficeId = strHeadOfficeId;
        //                objContractDTO.BranchOfficeId = strBranchOfficeId;






        //                strMsg = objContractBLL.saveContractInfoTemp(objContractDTO);
        //                //MessageBox(strMsg);
        //                lblMsg.Text = strMsg;

        //                rowIndex++;



        //            }


        //        }


        //    }





        //}

        //public void searchContactRecordSub()
        //{

        //    ContractDTO objContractDTO = new ContractDTO();
        //    ContractBLL objContractBLL = new ContractBLL();

        //    DataTable dt = new DataTable();


        //    objContractDTO.ContactNo = txtContractNo.Text;
        //    objContractDTO.IssueDate = dtpIssueDate.Text;
        //    objContractDTO.AmendMentDate = dtpAmendmentDate.Text;
        //    objContractDTO.IssueYear = txtYear.Text;

        //    if (ddlPOIdSearch.SelectedValue.ToString() != "0")
        //    {
        //        objContractDTO.POId = ddlPOIdSearch.SelectedValue.ToString();

        //    }
        //    else
        //    {

        //        objContractDTO.POId = "";

        //    }


        //    if (ddlStyleIdSearch.SelectedValue.ToString() != "0")
        //    {
        //        objContractDTO.StyleId = ddlStyleIdSearch.SelectedValue.ToString();

        //    }
        //    else
        //    {

        //        objContractDTO.StyleId = "";

        //    }





        //    objContractDTO.HeadOfficeId = strHeadOfficeId;
        //    objContractDTO.BranchOfficeId = strBranchOfficeId;

        //    dt = objContractBLL.searchContactRecordSub(objContractDTO);


        //    if (dt.Rows.Count > 0)
        //    {
        //        gvForeignFabric.DataSource = dt;
        //        gvForeignFabric.DataBind();

        //        int count = ((DataTable)gvForeignFabric.DataSource).Rows.Count;
        //        string strMsg = " TOTAL " + count + " RECORD FOUND";
        //        // MessageBox(strMsg);
        //        lblMsg.Text = strMsg;
        //        //gvEmployeeList.Columns[2].Visible = false;
        //        // getFirstIndex();
        //    }
        //    else
        //    {
        //        dt.Rows.Add(dt.NewRow());
        //        gvForeignFabric.DataSource = dt;
        //        gvForeignFabric.DataBind();
        //        int totalcolums = gvForeignFabric.Rows[0].Cells.Count;
        //        gvForeignFabric.Rows[0].Cells.Clear();
        //        gvForeignFabric.Rows[0].Cells.Add(new TableCell());
        //        gvForeignFabric.Rows[0].Cells[0].ColumnSpan = totalcolums;
        //        gvForeignFabric.Rows[0].Cells[0].Text = "NO RECORD FOUND";

        //        string strMsg = "NO RECORD FOUND!!!";
        //        //MessageBox(strMsg);
        //        lblMsg.Text = strMsg;
        //        //gvEmployeeList.Columns[2].Visible = false;
        //    }


        //}

        public void searchContactBookingRecord()
        {

            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();

            DataTable dt = new DataTable();


            objContractDTO.ContactNo = txtContractNo.Text;
            

            objContractDTO.HeadOfficeId = strHeadOfficeId;
            objContractDTO.BranchOfficeId = strBranchOfficeId;

            dt = objContractBLL.searchContactBookingRecord(objContractDTO);

            gvContractDetails.Columns[6].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvContractDetails.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvContractDetails.DataBind();
                gvContractDetails.Columns[6].Visible = false;

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    TextBox txtUnitCost = (TextBox)gvContractDetails.Rows[i].FindControl("txtUnitCost");
                //    txtUnitCost.Attributes.Add("readonly", "readonly");

                //    TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[i].FindControl("txtTotalAmount");
                //    txtTotalAmount.Attributes.Add("readonly", "readonly");




                //}



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
                gvContractDetails.Columns[6].Visible = false;
                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }

        //public void searcContactMain()
        //{
        //    ContractDTO objContractDTO = new ContractDTO();
        //    ContractBLL objContractBLL = new ContractBLL();

        //    string strAmendId = "";


        //    objContractDTO = objContractBLL.searcContactMain(txtContractNo.Text, dtpIssueDate.Text,dtpAmendmentDate.Text, strHeadOfficeId, strBranchOfficeId);


        //    if (objContractDTO.IssueDate == "0")
        //    {
        //        dtpIssueDate.Text = "";
        //    }
        //    else
        //    {
        //        dtpIssueDate.Text = objContractDTO.IssueDate;

        //    }





        //    if (objContractDTO.VendorId == "0")
        //    {

        //        //nothing to do
        //    }
        //    else
        //    {
        //        ddlVendorId.SelectedValue = objContractDTO.VendorId;
        //    }


        //    if (objContractDTO.VendorBankId == "0")
        //    {

        //        //nothing to do
        //    }
        //    else
        //    {
        //        ddlVendorBankId.SelectedValue = objContractDTO.VendorBankId;
        //    }


        //    if (objContractDTO.ManufactureId == "0")
        //    {

        //        //nothing to do
        //    }
        //    else
        //    {
        //        ddlManufacturerId.SelectedValue = objContractDTO.ManufactureId;
        //    }


        //    if (objContractDTO.ManufactureBankId == "0")
        //    {

        //        //nothing to do
        //    }
        //    else
        //    {
        //        ddlManufacturerBankId.SelectedValue = objContractDTO.ManufactureBankId;
        //    }


        //    if (objContractDTO.ShipId == "0")
        //    {

        //        //nothing to do
        //    }
        //    else
        //    {
        //        ddlShipId.SelectedValue = objContractDTO.ShipId;
        //    }


        //    if (objContractDTO.ShipTypeId == "0")
        //    {

        //        //nothing to do
        //    }
        //    else
        //    {
        //        ddlShipTypeId.SelectedValue = objContractDTO.ShipTypeId;
        //    }

        //    if (objContractDTO.PaymentTermId == "0")
        //    {

        //        //nothing to do
        //    }
        //    else
        //    {
        //        ddlPaymentTermId.SelectedValue = objContractDTO.PaymentTermId;
        //    }

        //    if (objContractDTO.ContactNo == "0")
        //    {
        //        txtContractNo.Text = "";
        //    }
        //    else
        //    {
        //        txtContractNo.Text = objContractDTO.ContactNo;
        //    }



        //}







        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtContractNo.Text == "")
            {
                string strMsg = "Please Enter Contract No!!!";
                MessageBox(strMsg);
                txtContractNo.Focus();
                return;


            }
           

            else
            {
             
                saveContractBooking();
                searchContactBookingRecord();


            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtContractNo.Text == "")
            {
                string strMsg = "Please Enter Contract No!!!";
                MessageBox(strMsg);
                txtContractNo.Focus();
                return;
            }
           
            else
            {
                // searcContactMain(); 
                searchContactBookingRecord();
               
               


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


            if (lbldeleteid == null)
            {

                string strMsg = "ID NOT FOUND!!!";
                MessageBox(strMsg);
                return;
            }
            else
            {


                int stor_id = Convert.ToInt32(gvContractDetails.DataKeys[e.RowIndex].Value.ToString());
                string strTranId = Convert.ToString(stor_id);


                deleteContractBooking(strTranId);
                searchContactBookingRecord();
                //searcContactMain();


            }




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
                LookUpDTO objLookupDTO = new LookUpDTO();

                DropDownList a = (e.Row.FindControl("ddlPoId") as DropDownList);
             

                DataTable dt1 = new DataTable();


                DataRowView dr = e.Row.DataItem as DataRowView;


                dt1 = objLookUpBLL.getPONo(txtContractNo.Text,  strHeadOfficeId, strBranchOfficeId);
                a.DataSource = dt1;
                a.DataBind();
                a.SelectedValue = dr["PO_ID"].ToString();


                DropDownList b = (e.Row.FindControl("ddlStyleId") as DropDownList);


                DataTable dt2 = new DataTable();


                DataRowView dr2 = e.Row.DataItem as DataRowView;


                dt2 = objLookUpBLL.getStyleNo(txtContractNo.Text, b.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);
                b.DataSource = dt2;
                b.DataBind();
               b.SelectedValue = dr["STYLE_ID"].ToString();


                DropDownList c = (e.Row.FindControl("ddlColorId") as DropDownList);


                DataTable dt3 = new DataTable();


                DataRowView dr3 = e.Row.DataItem as DataRowView;


                dt3 = objLookUpBLL.getColorName();
                c.DataSource = dt3;
                c.DataBind();
                c.SelectedValue = dr["COLOR_ID"].ToString();

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
         
            //searchContactRecord();
            //searcContactMain();
        }

        

        public void deleteContractBooking(string strTranId)
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();



            objContractDTO.ContactNo = txtContractNo.Text;
           
            objContractDTO.TranId = strTranId;
            



            objContractDTO.UpdateBy = strEmployeeId;
            objContractDTO.HeadOfficeId = strHeadOfficeId;
            objContractDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objContractBLL.deleteContractBooking(objContractDTO);
            MessageBox(strMsg);


        }

        public void updateContractInfo()
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();



            objContractDTO.ContactNo = txtContractNo.Text;
            //objContractDTO.IssueDate = dtpIssueDate.Text;
            //objContractDTO.AmendMentDate = dtpAmendmentDate.Text;
            




            objContractDTO.UpdateBy = strEmployeeId;
            objContractDTO.HeadOfficeId = strHeadOfficeId;
            objContractDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objContractBLL.updateContractInfo(objContractDTO);
            //MessageBox(strMsg);


        }

        protected void ddlManufacturerId_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void txtOrderQuantity_TextChanged(object sender, EventArgs e)
        {

            TextBox tb = (TextBox)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;

            TextBox txtUnitCost = (TextBox)gvContractDetails.Rows[rowindex].FindControl("txtUnitCost");
            txtUnitCost.Attributes.Add("readonly", "readonly");

            TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[rowindex].FindControl("txtTotalAmount");
           
            txtTotalAmount.Attributes.Add("readonly", "readonly");

         


        }

        protected void txtPOPrice_TextChanged(object sender, EventArgs e)
        {

            TextBox tb = (TextBox)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;

            TextBox txtUnitCost = (TextBox)gvContractDetails.Rows[rowindex].FindControl("txtUnitCost");
            txtUnitCost.Attributes.Add("readonly", "readonly");

            TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[rowindex].FindControl("txtTotalAmount");

            txtTotalAmount.Attributes.Add("readonly", "readonly");




        }

        protected void ddlPoId_SelectedIndexChanged(object sender, EventArgs e)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            if (txtContractNo.Text == "")
            {
                string strMsg = "Please Enter Contract NO!!!";
                txtContractNo.Focus();
                MessageBox(strMsg);
                return;

            }
           

            else
            {
                DropDownList tb = (DropDownList)sender;

                GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
                int rowindex = gvr.RowIndex;

                DropDownList ddlPoId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlPoId");
                DropDownList ddlStyleId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlStyleId");



                ddlStyleId.DataSource = objLookUpBLL.getStyleNo(txtContractNo.Text, ddlPoId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);

                ddlStyleId.DataTextField = "STYLE_NO";
                ddlStyleId.DataValueField = "STYLE_ID";

                ddlStyleId.DataBind();
                if (ddlStyleId.Items.Count > 0)
                {

                    ddlStyleId.SelectedIndex = 0;
                }




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


        #region gridviewEvent

        protected void gvForeignFabric_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvForeignFabric_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        //protected void gvForeignFabric_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int strRowId = gvForeignFabric.SelectedRow.RowIndex + 1;


        //    string strChallanNo = gvForeignFabric.SelectedRow.Cells[1].Text.Replace("&nbsp;", ""); ;
        //    string strIssueDate = gvForeignFabric.SelectedRow.Cells[2].Text.Replace("&nbsp;", ""); ;
        //    string strAmendmentDate = gvForeignFabric.SelectedRow.Cells[3].Text.Replace("&nbsp;", ""); ;
        //    string strPONo = gvForeignFabric.SelectedRow.Cells[4].Text.Replace("&nbsp;", ""); ;
        //    string strStyleNO = gvForeignFabric.SelectedRow.Cells[5].Text.Replace("&nbsp;", ""); ;

        //    //txtContractNo.Text = strChallanNo;
        //    //dtpIssueDate.Text = strIssueDate;
        //    //dtpAmendmentDate.Text = strAmendmentDate;

        //    //searcContactMain();
        //    //searchContactRecord();

        //}
























        #endregion

        protected void btnSearchRecord_Click(object sender, EventArgs e)
        {
          //  searchContactRecordSub();
        }

        protected void txtContractNo_TextChanged(object sender, EventArgs e)
        {
         
            LookUpBLL objLookUpBLL = new LookUpBLL();
            DataTable dt = new DataTable();
            int rowindex = 0;


            DropDownList ddlPoId = (DropDownList)gvContractDetails.Rows[rowindex].FindControl("ddlPoId");
            ddlPoId.DataSource = objLookUpBLL.getPONo(txtContractNo.Text, strHeadOfficeId, strBranchOfficeId);

           
                ddlPoId.DataTextField = "PO_NO";
                ddlPoId.DataValueField = "PO_ID";
             
                ddlPoId.DataBind();
                if (ddlPoId.Items.Count > 0)
                {

                    ddlPoId.SelectedIndex = 0;
                }


           

        }
    }
}