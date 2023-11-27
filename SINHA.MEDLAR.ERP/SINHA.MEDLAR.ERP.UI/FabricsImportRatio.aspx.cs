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


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class FabricsImportRatio : System.Web.UI.Page
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
                FirstGridViewRow();
                getBuyerId();
                getSeasonId();
            }

            if (IsPostBack)
            {

                loadSesscion();

            }

            gvFabricsImportInfo.Columns[4].Visible = false;
           
        }


        #region "Function"
        public void reportMaster()
        {

            if (chkPDF.Checked == true)
            {

                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                ReportDocument crReportDocument = new ReportDocument();
                Response.Clear();
                Response.Buffer = true;

                formatType = ExportFormatType.PortableDocFormat;
                MemoryStream oStream;


                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                oStream = (MemoryStream)rd.ExportToStream(formatType);
                Response.ContentType = "application/Pdf";
                crReportDocument.Close();
                crReportDocument.Dispose();

                oStream.Seek(0, SeekOrigin.Begin);
                try
                {

                    Response.BinaryWrite(oStream.ToArray());
                    Response.End();

                }

                catch (System.Threading.ThreadAbortException lException)
                {

                    //do nothing

                }

                finally
                {
                    Response.End();
                    oStream.Flush();
                    oStream.Close();
                    oStream.Dispose();
                    crReportDocument.Close();
                    crReportDocument.Dispose();
                    this.CrystalReportViewer1.Dispose();
                    this.CrystalReportViewer1 = null;

                }
            }
            if (chkExcel.Checked == true)
            {

                //CrystalReportViewer1.ReportSource = rd;
                //CrystalReportViewer1.DataBind();

                //formatType = ExportFormatType.Excel;
                //MemoryStream oStream;
                //Response.Clear();
                //Response.Buffer = false;
                //Response.ClearContent();
                //Response.ClearHeaders();

                //oStream = (MemoryStream)rd.ExportToStream(formatType);
                //Response.ContentType = "application/vnd.ms-excel";
                //oStream.Seek(0, SeekOrigin.Begin);
                //Response.BinaryWrite(oStream.ToArray());
                ////Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();

                rd.ExportToHttpResponse
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet_worker");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }
            //else
            //{

            //    CrystalReportViewer1.ReportSource = rd;
            //    CrystalReportViewer1.DataBind();

            //    formatType = ExportFormatType.PortableDocFormat;
            //    MemoryStream oStream;
            //    Response.Clear();
            //    Response.Buffer = false;
            //    Response.ClearContent();
            //    Response.ClearHeaders();

            //    oStream = (MemoryStream)rd.ExportToStream(formatType);
            //    Response.ContentType = "application/Pdf";
            //    oStream.Seek(0, SeekOrigin.Begin);
            //    Response.BinaryWrite(oStream.ToArray());
            //    //Response.End();
            //    oStream.Flush();
            //    oStream.Close();
            //    oStream.Dispose();
            //    CrystalReportViewer1.RefreshReport();

            //}



        }

        public void getBuyerId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerId.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId,strBranchOfficeId);

            ddlBuyerId.DataTextField = "BUYER_NAME";
            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {

                ddlBuyerId.SelectedIndex = 0;
            }


        }

        //public void getAmendmentId()
        //{


        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlAmendmentId.DataSource = objLookUpBLL.getAmendmentId(txtContractNo.Text, txtIssueDate.Text, dt strHeadOfficeId, strBranchOfficeId);

        //    ddlAmendmentId.DataTextField = "AMENDMENT_NAME";
        //    ddlAmendmentId.DataValueField = "AMENDMENT_ID";

        //    ddlAmendmentId.DataBind();
        //    if (ddlAmendmentId.Items.Count > 0)
        //    {

        //        ddlAmendmentId.SelectedIndex = 0;
        //    }


        //}



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


        private void FirstGridViewRow()
        {


          
            DataTable dt = new DataTable();
            DataRow dr = null;
           

          
            dt.Columns.Add(new DataColumn("SIZE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("ORDER_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("FABRIC_YARD", typeof(string)));
            dt.Columns.Add(new DataColumn("TOTAL_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));

            dr = dt.NewRow();
          


            dr["SIZE_ID"] = string.Empty;
            dr["ORDER_QUANTITY"] = string.Empty;
            dr["FABRIC_YARD"] = string.Empty;
            dr["TOTAL_QUANTITY"] = string.Empty;
            dr["TRAN_ID"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvFabricsImportInfo.DataSource = dt;
            gvFabricsImportInfo.DataBind();
         
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


                        DropDownList ddlSizeId = (DropDownList)gvFabricsImportInfo.Rows[rowIndex].Cells[0].FindControl("ddlSizeId");
                        TextBox txtOrderQuantity = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[1].FindControl("txtOrderQuantity");
                        TextBox txtFabricYard = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[2].FindControl("txtFabricYard");
                        TextBox txtTotalQuantity = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[3].FindControl("txtTotalQuantity");
                        TextBox txtTranId = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[4].FindControl("txtTranId");
                       


                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                       
                        dtCurrentTable.Rows[i - 1]["SIZE_ID"] = ddlSizeId.Text;
                        dtCurrentTable.Rows[i - 1]["ORDER_QUANTITY"] = txtOrderQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["FABRIC_YARD"] = txtFabricYard.Text;
                        dtCurrentTable.Rows[i - 1]["TOTAL_QUANTITY"] = txtTotalQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["TRAN_ID"] = txtTranId.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvFabricsImportInfo.DataSource = dtCurrentTable;
                    gvFabricsImportInfo.DataBind();
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


                        DropDownList ddlSizeId = (DropDownList)gvFabricsImportInfo.Rows[rowIndex].Cells[0].FindControl("ddlSizeId");
                        TextBox txtOrderQuantity = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[1].FindControl("txtOrderQuantity");
                        TextBox txtFabricYard = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[2].FindControl("txtFabricYard");
                        TextBox txtTotalQuantity = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[3].FindControl("txtTotalQuantity");
                        TextBox txtTranId = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[4].FindControl("txtTranId");



                        ddlSizeId.Text = dt.Rows[i]["SIZE_ID"].ToString();
                        txtOrderQuantity.Text = dt.Rows[i]["ORDER_QUANTITY"].ToString();
                        txtFabricYard.Text = dt.Rows[i]["FABRIC_YARD"].ToString();
                        txtTotalQuantity.Text = dt.Rows[i]["TOTAL_QUANTITY"].ToString();
                        txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();


                        rowIndex++;
                    }
                }
            }
        }

        public void deleteFabricsImportRatioInfo()
        {

            FabricsImportRatioDTO objFabricsRatioDTO = new FabricsImportRatioDTO();
            FabricsImportRatioBLL objFabricsImportRatioBLL = new FabricsImportRatioBLL();


            objFabricsRatioDTO.ContactNo = txtContractNo.Text;
            objFabricsRatioDTO.FobDate = dtpFobDate.Text;
            objFabricsRatioDTO.FobOrginalDate = dtpFobOrginalDate.Text;

            objFabricsRatioDTO.UpdateBy = strEmployeeId;
            objFabricsRatioDTO.HeadOfficeId = strHeadOfficeId;
            objFabricsRatioDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objFabricsImportRatioBLL.deleteFabricsImportRatioInfo(objFabricsRatioDTO);
            


        }


        public void saveFabricsImportRatioInfo()
        {

            FabricsImportRatioDTO objFabricsRatioDTO = new FabricsImportRatioDTO();
            FabricsImportRatioBLL objFabricsImportRatioBLL = new FabricsImportRatioBLL();


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
                        DropDownList ddlSizeId = (DropDownList)gvFabricsImportInfo.Rows[rowIndex].Cells[0].FindControl("ddlSizeId");
                        TextBox txtOrderQuantity = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[1].FindControl("txtOrderQuantity");
                        TextBox txtFabricYard = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[2].FindControl("txtFabricYard");
                        TextBox txtTotalQuantity = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[3].FindControl("txtTotalQuantity");
                        TextBox txtTranId = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[4].FindControl("txtTranId");

                        objFabricsRatioDTO.ContactNo = txtContractNo.Text;
                        objFabricsRatioDTO.FobDate = dtpFobDate.Text;
                        objFabricsRatioDTO.FobOrginalDate = dtpFobOrginalDate.Text;
                        objFabricsRatioDTO.PONo = txtPONo.Text;
                        objFabricsRatioDTO.StyleNo = txtStyleNo.Text;
                        
                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objFabricsRatioDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                        }
                        else
                        {

                            objFabricsRatioDTO.BuyerId = "";

                        }

                        if (ddlSeasonId.SelectedValue.ToString() != " ")
                        {
                            objFabricsRatioDTO.SeasonId = ddlSeasonId.SelectedValue.ToString();

                        }
                        else
                        {

                            objFabricsRatioDTO.SeasonId = "";

                        }
                        if (ddlSizeId.SelectedValue.ToString() != " ")
                        {
                            objFabricsRatioDTO.SizeId = ddlSizeId.SelectedValue.ToString();

                        }
                        else
                        {
                            objFabricsRatioDTO.SizeId = "";

                        }

                        objFabricsRatioDTO.OrderQuantity = txtOrderQuantity.Text;
                        objFabricsRatioDTO.FabricYard = txtFabricYard.Text;
                        objFabricsRatioDTO.TotalQty = txtTotalQuantity.Text;
                        objFabricsRatioDTO.TranId = txtTranId.Text;

                        objFabricsRatioDTO.UpdateBy = strEmployeeId;
                        objFabricsRatioDTO.HeadOfficeId = strHeadOfficeId;
                        objFabricsRatioDTO.BranchOfficeId = strBranchOfficeId;


                        strMsg = objFabricsImportRatioBLL.saveFabricsImportRatioInfo(objFabricsRatioDTO);
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
        //                TextBox txtPONo = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[0].FindControl("txtPONo");
        //                TextBox txtStyleNo = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[1].FindControl("txtStyleNo");
        //                TextBox txtItemName = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[2].FindControl("txtItemName");
        //                DropDownList ddlSizeId = (DropDownList)gvFabricsImportInfo.Rows[rowIndex].Cells[3].FindControl("ddlSizeId");
        //                TextBox txtOrderQuantity = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[4].FindControl("txtOrderQuantity");
        //                TextBox txtPOPrice = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[5].FindControl("txtPOPrice");
        //                TextBox txtHangerCostPerUnit = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[6].FindControl("txtHangerCostPerUnit");
        //                TextBox txtUnitCost = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[7].FindControl("txtUnitCost");
        //                TextBox txtTotalAmount = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[8].FindControl("txtTotalAmount");
        //                TextBox txtShipingAddress = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[9].FindControl("txtShipingAddress");
        //                TextBox dtpDeliveryDate = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[10].FindControl("dtpDeliveryDate");
        //                TextBox txtTranId = (TextBox)gvFabricsImportInfo.Rows[rowIndex].Cells[11].FindControl("txtTranId");



        //                objContractDTO.TranId = txtTranId.Text;
        //                objContractDTO.AmendMentDate = txtIssueDate.Text;
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

        public void searchFabricsImportRatioRecord()
        {
            FabricsImportRatioDTO objFabricsImportRatioDTO = new FabricsImportRatioDTO();
            FabricsImportRatioBLL objFabricsImportRatioBLL = new FabricsImportRatioBLL();

            DataTable dt = new DataTable();


            objFabricsImportRatioDTO.ContactNo = txtContractNo.Text;
            objFabricsImportRatioDTO.FobDate = dtpFobDate.Text;
            objFabricsImportRatioDTO.FobOrginalDate = dtpFobOrginalDate.Text;
            objFabricsImportRatioDTO.PONo = txtPONo.Text;
            objFabricsImportRatioDTO.StyleNo = txtStyleNo.Text;


            objFabricsImportRatioDTO.HeadOfficeId = strHeadOfficeId;
            objFabricsImportRatioDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFabricsImportRatioBLL.searchFabricsImportRatioRecord(objFabricsImportRatioDTO);


            if (dt.Rows.Count > 0)
            {
                gvFabricsImportInfo.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvFabricsImportInfo.DataBind();

                int count = ((DataTable)gvFabricsImportInfo.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvFabricsImportInfo.DataSource = dt;
                gvFabricsImportInfo.DataBind();
                int totalcolums = gvFabricsImportInfo.Rows[0].Cells.Count;
                gvFabricsImportInfo.Rows[0].Cells.Clear();
                gvFabricsImportInfo.Rows[0].Cells.Add(new TableCell());
                gvFabricsImportInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvFabricsImportInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }

        public void searchFabImportRatioMain()
        {
            FabricsImportRatioDTO objFabricsImportRatioDTO = new FabricsImportRatioDTO();
            FabricsImportRatioBLL objFabricsImportRatioBLL = new FabricsImportRatioBLL();


            objFabricsImportRatioDTO = objFabricsImportRatioBLL.searchFabImportRatioMain(txtContractNo.Text,txtPONo.Text, txtStyleNo.Text,  dtpFobDate.Text, dtpFobOrginalDate.Text, strHeadOfficeId, strBranchOfficeId);



            if (objFabricsImportRatioDTO.BuyerId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlBuyerId.SelectedValue = objFabricsImportRatioDTO.BuyerId;
            }


            if (objFabricsImportRatioDTO.SeasonId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlSeasonId.SelectedValue = objFabricsImportRatioDTO.SeasonId;
            }



            if (objFabricsImportRatioDTO.FobDate == "0" || objFabricsImportRatioDTO.FobDate == null)
            {

                //nothing to do
            }
            else
            {
                dtpFobDate.Text = objFabricsImportRatioDTO.FobDate;
            }

            if (objFabricsImportRatioDTO.FobOrginalDate == "0" || objFabricsImportRatioDTO.FobOrginalDate == null)
            {

                //nothing to do
            }
            else
            {
                dtpFobOrginalDate.Text = objFabricsImportRatioDTO.FobOrginalDate;
            }


            if (objFabricsImportRatioDTO.FobDate == "0" || objFabricsImportRatioDTO.FobDate == null)
            {

                //nothing to do
            }
            else
            {
                dtpFobDate.Text = objFabricsImportRatioDTO.FobDate;
            }



            if (objFabricsImportRatioDTO.PONo == "0" || objFabricsImportRatioDTO.PONo == null)
            {

                //nothing to do
            }
            else
            {
                txtPONo.Text = objFabricsImportRatioDTO.PONo;
            }


            if (objFabricsImportRatioDTO.StyleNo == "0" || objFabricsImportRatioDTO.StyleNo == null)
            {

                //nothing to do
            }
            else
            {
                txtStyleNo.Text = objFabricsImportRatioDTO.StyleNo;
            }



        }
        
        public void rptContractSheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            processsDailyContractInfo();


          
           
            objReportDTO.ContractNo = txtContractNo.Text;


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;



            string strPath = Path.Combine(Server.MapPath("~/Reports/rptContractInfo.rpt"));
            this.Context.Session["strReportPath"] = strPath;
            rd.Load(strPath);
            rd.SetDataSource(objReportBLL.rptContractSheet(objReportDTO));


            rd.SetDatabaseLogon("erp", "erp");
            CrystalReportViewer1.ReportSource = rd;
            CrystalReportViewer1.DataBind();

            reportMaster();

            this.CrystalReportViewer1.Dispose();
            this.CrystalReportViewer1 = null;
            rd.Dispose();
            rd.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();



        }

        public void processsDailyContractInfo()
        {
            
            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


          


            objReportDTO.ContractNo = txtContractNo.Text;
            objReportDTO.IssueDate = dtpFobDate.Text;
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;


            string strMsg = objReportBLL.processsDailyContractInfo(objReportDTO);

        }


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
            else if (txtPONo.Text == "")
            {
                string strMsg = "Please Enter P.O No!!!";
                MessageBox(strMsg);
                txtPONo.Focus();
                return;


            }
            else if (txtStyleNo.Text == "")
            {
                string strMsg = "Please Enter Style No!!!";
                MessageBox(strMsg);
                txtStyleNo.Focus();
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
                //deleteFabricsImportRatioInfo();
                saveFabricsImportRatioInfo();
                searchFabricsImportRatioRecord();
                
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchFabricsImportRatioRecord();
            searchFabImportRatioMain();
           
        }

        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {

        }


        #region "Grid View Functionality"
        protected void gvFabricsImportInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFabricsImportInfo.PageIndex = e.NewPageIndex;

        }

        protected void gvFabricsImportInfo_OnSelectedIndexChanged(object sender, EventArgs e)
        {



        }




        protected void gvFabricsImportInfo_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void gvFabricsImportInfo_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void gvFabricsImportInfo_Sorting(object sender, GridViewSortEventArgs e)
        {


        }


        protected void gvFabricsImportInfo_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LookUpBLL objLookUpBLL = new LookUpBLL();

                DropDownList a = (e.Row.FindControl("ddlSizeId") as DropDownList);


                DataTable dt1 = new DataTable();


                DataRowView dr = e.Row.DataItem as DataRowView;


                dt1 = objLookUpBLL.getSizeId();
                a.DataSource = dt1;
                a.DataBind();
                a.SelectedValue = dr["SIZE_ID"].ToString();



            }



        }


        protected void gvFabricsImportInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvFabricsImportInfo.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("TRAN_ID");

            int stor_id = Convert.ToInt32(gvFabricsImportInfo.DataKeys[e.RowIndex].Value.ToString());
            string strTranId = Convert.ToString(stor_id);





            deleteFabImportInfoRecord(strTranId);
            searchFabricsImportRatioRecord();
            //searcAmendDate();
            //searchContactRecord();
            //searcContactMain();
            //getAmendmentId();






        }


        #endregion

        protected void btnSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContractNo.Text == " ")
                {

                    string strMsg = "Please Enter Contract No!!!";
                    MessageBox(strMsg);
                    txtContractNo.Focus();
                    return;
                }

              
                {

                  //  rptContractSheet();

                }
            }
            catch (Exception ex)
            {

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();


            }
        }

        protected void ddlAmendmentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchFabricsImportRatioRecord();
            searchFabImportRatioMain();
            
        }

        protected void btnSearchAmmendMent_Click(object sender, EventArgs e)
        {
            searchFabricsImportRatioRecord();
            searchFabImportRatioMain();
        }

        
        public void deleteFabImportInfoRecord(string strTranId)
        {


            FabricsImportRatioDTO objFabricsImportRatioDTO = new FabricsImportRatioDTO();
            FabricsImportRatioBLL objFabricsImportRatioBLL = new FabricsImportRatioBLL();


            objFabricsImportRatioDTO.TranId = strTranId;
            objFabricsImportRatioDTO.ContactNo = txtContractNo.Text;
            objFabricsImportRatioDTO.ContactNo = txtContractNo.Text;
            objFabricsImportRatioDTO.FobDate = dtpFobDate.Text;
            objFabricsImportRatioDTO.FobOrginalDate = dtpFobOrginalDate.Text;
            objFabricsImportRatioDTO.PONo = txtPONo.Text;
            objFabricsImportRatioDTO.StyleNo = txtStyleNo.Text;
                        

            



            objFabricsImportRatioDTO.UpdateBy = strEmployeeId;
            objFabricsImportRatioDTO.HeadOfficeId = strHeadOfficeId;
            objFabricsImportRatioDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objFabricsImportRatioBLL.deleteFabImportInfoRecord(objFabricsImportRatioDTO);
            MessageBox(strMsg);


        }

    }
}