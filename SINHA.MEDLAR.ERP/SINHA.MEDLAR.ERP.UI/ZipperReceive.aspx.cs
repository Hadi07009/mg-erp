﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.Web.Security;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Specialized;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ZipperReceive : System.Web.UI.Page
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
        ReportDocument rd = new ReportDocument();

        string strDefaultName = "Report";
        ExportFormatType formatType = ExportFormatType.NoFormat;
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
               
                getSupplierId();
              
                getBuyerId();
                getStoreId();
               
                getImporter();
              
                //getCurrentDate();
                FirstGridViewRow();

            }

            if (IsPostBack)
            {

                loadSesscion();

            }

            //txtPO.Attributes.Add("onkeypress", "return controlEnter('" + txtPI.ClientID + "', event)");
            //txtPI.Attributes.Add("onkeypress", "return controlEnter('" + dtpReceiveDate.ClientID + "', event)");
            
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
        private void FirstGridViewRow()
        {


            //if (ViewState["CurrentTable"] != null)
            //{
            DataTable dt = new DataTable();
            DataRow dr = null;
            // dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("PROGRAMME_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("STYLE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("COLOR_ID", typeof(string)));


            dt.Columns.Add(new DataColumn("ZIPPER_LENGTH", typeof(string)));
            dt.Columns.Add(new DataColumn("MEASURE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("QUANTITY", typeof(string)));

            dt.Columns.Add(new DataColumn("ZIPPER_RATE", typeof(string)));
            dt.Columns.Add(new DataColumn("CURRENCY_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("ART_NO", typeof(string)));


            dr = dt.NewRow();
            // dr["RowNumber"] = 1;
            dr["PROGRAMME_ID"] = string.Empty;
            dr["STYLE_ID"] = string.Empty;
            dr["COLOR_ID"] = string.Empty;

            dr["ZIPPER_LENGTH"] = string.Empty;
            dr["MEASURE_ID"] = string.Empty;
            dr["QUANTITY"] = string.Empty;

            dr["ZIPPER_RATE"] = string.Empty;
            dr["CURRENCY_ID"] = string.Empty;
            dr["ART_NO"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvFabricDetails.DataSource = dt;
            gvFabricDetails.DataBind();
            // }
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

            dtpReceiveDate.Text = objLookUpDTO.AttendenceDate;


        }

        public void getImporter()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlImporterId.DataSource = objLookUpBLL.getImporter();

            ddlImporterId.DataTextField = "IMPORTER_NAME";
            ddlImporterId.DataValueField = "IMPORTER_ID";

            ddlImporterId.DataBind();
            if (ddlImporterId.Items.Count > 0)
            {

                ddlImporterId.SelectedIndex = 0;
            }


        }





        public void getStoreId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlStoreId.DataSource = objLookUpBLL.getStoreId();

            ddlStoreId.DataTextField = "STORE_NAME";
            ddlStoreId.DataValueField = "STORE_ID";

            ddlStoreId.DataBind();
            if (ddlStoreId.Items.Count > 0)
            {

                ddlStoreId.SelectedIndex = 0;
            }


        }



        public void getBuyerId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerId.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerId.DataTextField = "BUYER_NAME";
            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {

                ddlBuyerId.SelectedIndex = 0;
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

                        DropDownList ddlProgrammeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("ddlProgrammeId");
                        DropDownList ddlStyleId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("ddlStyleId");
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlColorId");
                        DropDownList ddlSizeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlSizeId");
                        TextBox txtArtNo = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("txtArtNo");

                        TextBox txtZipperLength = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("txtZipperLength");
                        TextBox txtQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtQuantity");
                        TextBox txtRate = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtRate");
                        DropDownList ddlCurrencyId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("ddlCurrencyId");



                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["PROGRAMME_ID"] = ddlProgrammeId.Text;
                        dtCurrentTable.Rows[i - 1]["STYLE_ID"] = ddlStyleId.Text;
                        dtCurrentTable.Rows[i - 1]["COLOR_ID"] = ddlColorId.Text;


                        dtCurrentTable.Rows[i - 1]["ART_NO"] = txtArtNo.Text;
                        dtCurrentTable.Rows[i - 1]["ZIPPER_LENGTH"] = txtZipperLength.Text;
                        dtCurrentTable.Rows[i - 1]["MEASURE_ID"] = ddlSizeId.Text;
                        dtCurrentTable.Rows[i - 1]["QUANTITY"] = txtQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["ZIPPER_RATE"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["CURRENCY_ID"] = ddlCurrencyId.Text;
                        

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gvFabricDetails.DataSource = dtCurrentTable;
                    gvFabricDetails.DataBind();
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
                        DropDownList ddlProgrammeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("ddlProgrammeId");
                        DropDownList ddlStyleId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("ddlStyleId");
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlColorId");
                        DropDownList ddlSizeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlSizeId");
                        TextBox txtArtNo = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("txtArtNo");

                        TextBox txtZipperLength = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("txtZipperLength");
                        TextBox txtQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtQuantity");
                        TextBox txtRate = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtRate");
                        DropDownList ddlCurrencyId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("ddlCurrencyId");



                        ddlProgrammeId.Text = dt.Rows[i]["PROGRAMME_ID"].ToString();
                        ddlStyleId.Text = dt.Rows[i]["STYLE_ID"].ToString();
                        ddlColorId.Text = dt.Rows[i]["COLOR_ID"].ToString();
                        txtArtNo.Text = dt.Rows[i]["ART_NO"].ToString();
                        txtZipperLength.Text = dt.Rows[i]["ZIPPER_LENGTH"].ToString();
                        ddlSizeId.Text = dt.Rows[i]["MEASURE_ID"].ToString();
                        txtQuantity.Text = dt.Rows[i]["QUANTITY"].ToString();
                        txtRate.Text = dt.Rows[i]["ZIPPER_RATE"].ToString();
                        ddlCurrencyId.Text = dt.Rows[i]["CURRENCY_ID"].ToString();



                        rowIndex++;
                    }
                }
            }
        }


        public void saveZipperReceive()
        {
            int rowIndex = 0;
            string strMsg = "";

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();

            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList ddlProgrammeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("ddlProgrammeId");
                        DropDownList ddlStyleId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("ddlStyleId");
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlColorId");
                        DropDownList ddlSizeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlSizeId");
                        TextBox txtArtNo = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("txtArtNo");

                        TextBox txtZipperLength = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("txtZipperLength");
                        TextBox txtQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtQuantity");
                        TextBox txtRate = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtRate");
                        DropDownList ddlCurrencyId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("ddlCurrencyId");



                        objFabricIssueDTO.Length = txtZipperLength.Text;
                        objFabricIssueDTO.ParticularName = txtParticularName.Text;
                        objFabricIssueDTO.InvoiceNo = txtInvoiceNo.Text;
                        objFabricIssueDTO.ReceiveDate = dtpReceiveDate.Text;
                        objFabricIssueDTO.ContactNo = txtContactNo.Text;
                        objFabricIssueDTO.AirChallanNo = txtAirChallanNo.Text;
                        objFabricIssueDTO.LcNo = txtBackToBackLCNo.Text;

                        if (chkHandCarryYn.Checked == true)
                        {
                            objFabricIssueDTO.HandCarryYn = "Y";

                        }
                        else
                        {
                            objFabricIssueDTO.HandCarryYn = "N";


                        }


                        objFabricIssueDTO.Quantity = txtQuantity.Text;
                        objFabricIssueDTO.Rate = txtRate.Text;




                        if (ddlProgrammeId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.ProgrammeId = ddlProgrammeId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.ProgrammeId = "";

                        }


                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.BuyerId = "";

                        }

                        if (ddlStyleId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.StyleId = ddlStyleId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.StyleId = "";

                        }




                        objFabricIssueDTO.ArtNo = txtArtNo.Text;

                        if (ddlStoreId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.StoreId = ddlStoreId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.StoreId = "";

                        }

                        if (ddlSupplierId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.SupplierId = "";

                        }


                     
                        if (ddlColorId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.ColorId = ddlColorId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.ColorId = "";

                        }



                        if (ddlSizeId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.SizeId = ddlSizeId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.SizeId = "";

                        }

                        if (ddlCurrencyId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.CurrencyId = ddlCurrencyId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.CurrencyId = "";

                        }

                        if (ddlImporterId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.ImporterId = ddlImporterId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.ImporterId = "";

                        }


                      
                        objFabricIssueDTO.ReceiveDate = dtpReceiveDate.Text;

                        objFabricIssueDTO.Rate = txtRate.Text;
                        
                        objFabricIssueDTO.Quantity = txtQuantity.Text;

                        objFabricIssueDTO.UpdateBy = strEmployeeId;
                        objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
                        objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;
                     
     
                       

                        if (ddlSupplierId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.SupplierId = "";

                        }




                        strMsg = objFabricIssueBLL.saveZipperReceive(objFabricIssueDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;

                        rowIndex++;

                    }
                    if (strMsg == "INSERTED SUCCESSFULLY")
                    {
                        MessageBox(strMsg);
                       
                    }
                   
                   

                }
            }


        }

        public void deleteZipperReceive()
        {
            
            string strMsg = "";

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();




          
            objFabricIssueDTO.InvoiceNo = txtInvoiceNo.Text;
            objFabricIssueDTO.ReceiveDate = dtpReceiveDate.Text;

                      
            objFabricIssueDTO.UpdateBy = strEmployeeId;
            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;


            strMsg = objFabricIssueBLL.deleteZipperReceive(objFabricIssueDTO);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;

    
            


        }


        public void searchZipperReceiveEntryRecord()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();
            DataTable dt = new DataTable();


            objFabricIssueDTO.InvoiceNo = txtInvoiceNo.Text;
            objFabricIssueDTO.ReceiveDate = dtpReceiveDate.Text;







            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFabricIssueBLL.searchZipperReceiveEntryRecord(objFabricIssueDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
                int totalcolums = gvEmployeeList.Rows[0].Cells.Count;
                gvEmployeeList.Rows[0].Cells.Clear();
                gvEmployeeList.Rows[0].Cells.Add(new TableCell());
                gvEmployeeList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvEmployeeList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }


        public void searchZipperReceiveRecord()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();


            objFabricIssueDTO = objFabricIssueBLL.searchZipperReceiveRecord(txtInvoiceNo.Text, dtpReceiveDate.Text, strHeadOfficeId, strBranchOfficeId);

           

            if (objFabricIssueDTO.BuyerId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlBuyerId.SelectedValue = objFabricIssueDTO.BuyerId;
            }
            if (objFabricIssueDTO.ImporterId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlImporterId.SelectedValue = objFabricIssueDTO.ImporterId;
            }
            if (objFabricIssueDTO.StoreId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlStoreId.SelectedValue = objFabricIssueDTO.StoreId;
            }

          

           

           

            if (objFabricIssueDTO.SupplierId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlSupplierId.SelectedValue = objFabricIssueDTO.SupplierId;
            }



            if (objFabricIssueDTO.ReceiveDate == "0")
            {

                //nothing to do
            }
            else
            {
                dtpReceiveDate.Text = objFabricIssueDTO.ReceiveDate;
            }


            txtAirChallanNo.Text = objFabricIssueDTO.AirChallanNo;
            txtBackToBackLCNo.Text = objFabricIssueDTO.LcNo;
            txtContactNo.Text = objFabricIssueDTO.ContactNo;
            txtParticularName.Text = objFabricIssueDTO.ParticularName;

        }


        public void searchZipperReceiveSub()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();
            DataTable dt = new DataTable();


          

            objFabricIssueDTO.InvoiceNo = txtInvoiceNo.Text;
            objFabricIssueDTO.ReceiveDate = dtpReceiveDate.Text;





            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFabricIssueBLL.searchZipperReceiveSub(objFabricIssueDTO);


            if (dt.Rows.Count > 0)
            {
                gvFabricDetails.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvFabricDetails.DataBind();

                int count = ((DataTable)gvFabricDetails.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvFabricDetails.DataSource = dt;
                gvFabricDetails.DataBind();
                int totalcolums = gvFabricDetails.Rows[0].Cells.Count;
                gvFabricDetails.Rows[0].Cells.Clear();
                gvFabricDetails.Rows[0].Cells.Add(new TableCell());
                gvFabricDetails.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvFabricDetails.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }
        public void ZipperReceiveSheet()
        {

            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;





                objReportDTO.InvoiceNo = txtInvoiceNoSearch.Text;

                objReportDTO.FromDate = dtpFromDateSearch.Text;
                objReportDTO.ToDate = dtpToDateSearch.Text;




                string strPath = Path.Combine(Server.MapPath("~/Reports/rptZippeReceiveSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.ZipperReceiveSheet(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                //Queue reportQueue = new Queue();
                ////75 is my print job limit.
                //if (reportQueue.Count > 75)
                //{
                //    ((ReportClass)reportQueue.Dequeue()).Dispose();
                //    //reportView.ReportSource = null;


                //}

                reportMaster();


                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

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


        #endregion


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtInvoiceNo.Text == " ")
            {

                string strMsg = "Please Enter Invoice No!!!";
                MessageBox(strMsg);
                txtInvoiceNo.Focus();
                return;
            }


            else if (dtpReceiveDate.Text == " ")
            {

                string strMsg = "Please Enter Receive Date!!!";
                MessageBox(strMsg);
                dtpReceiveDate.Focus();
                return;
            }

            else if (ddlSupplierId.Text == " ")
            {

                string strMsg = "Please Select Supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;
            }

            else
            {
                deleteZipperReceive();
                saveZipperReceive();
                searchZipperReceiveEntryRecord();
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
             if (txtInvoiceNo.Text == " ")
            {

                string strMsg = "Please Enter Invoice No!!!";
                MessageBox(strMsg);
                txtInvoiceNo.Focus();
                return;
             }
             else if(dtpReceiveDate.Text == " ")
             {

                 string strMsg = "Please Enter Receive Date!!!";
                 MessageBox(strMsg);
                 dtpReceiveDate.Focus();
                 return;

             }

           

            else
            {

                deleteZipperReceive();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

      

        protected void btnSalaryProcess_Click(object sender, EventArgs e)
        {

        }

        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {
                chkPDF.AutoPostBack = true;
                chkExcel.Checked = false;

            }
        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkExcel.AutoPostBack = true;
                chkPDF.Checked = false;


            }
        }


        #region "Grid View Functionality"
        protected void gvFabricDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFabricDetails.PageIndex = e.NewPageIndex;

        }

        protected void gvFabricDetails_OnSelectedIndexChanged(object sender, EventArgs e)
        {



        }




        protected void gvFabricDetails_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void gvFabricDetails_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void gvFabricDetails_Sorting(object sender, GridViewSortEventArgs e)
        {


        }


        protected void gvFabricDetails_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LookUpBLL objLookUpBLL = new LookUpBLL();

                DropDownList a = (e.Row.FindControl("ddlStyleId") as DropDownList);
                DropDownList b = (e.Row.FindControl("ddlProgrammeId") as DropDownList);
                DropDownList c = (e.Row.FindControl("ddlColorId") as DropDownList);

                DropDownList f = (e.Row.FindControl("ddlSizeId") as DropDownList);
                DropDownList g = (e.Row.FindControl("ddlCurrencyId") as DropDownList);

                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();

                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();

                DataRowView dr = e.Row.DataItem as DataRowView;


                dt1 = objLookUpBLL.getMeasureId();
                f.DataSource = dt1;
                f.DataBind();
                f.SelectedValue = dr["MEASURE_ID"].ToString();


                dt2 = objLookUpBLL.getCurrencyId(strHeadOfficeId, strBranchOfficeId);
                g.DataSource = dt2;
                g.DataBind();
                g.SelectedValue = dr["CURRENCY_ID"].ToString();

                dt3 = objLookUpBLL.getStyleId();
                a.DataSource = dt3;
                a.DataBind();
                a.SelectedValue = dr["STYLE_ID"].ToString();

                dt4 = objLookUpBLL.getProgrammeId();
                b.DataSource = dt4;
                b.DataBind();
                b.SelectedValue = dr["PROGRAMME_ID"].ToString();

                dt5 = objLookUpBLL.getColorId();
                c.DataSource = dt5;
                c.DataBind();
                c.SelectedValue = dr["COLOR_ID"].ToString();

            }
        }

        
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                searchZipperReceiveRecord();
                searchZipperReceiveSub();
                searchZipperReceiveEntryRecord();
               
            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        protected void txtParticularName_TextChanged(object sender, EventArgs e)
        {

        }

        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;

        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {



            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strInvoiceNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strInvoiceDate = gvEmployeeList.SelectedRow.Cells[2].Text;


            txtInvoiceNo.Text = strInvoiceNo;
            dtpReceiveDate.Text = strInvoiceDate;



            searchZipperReceiveRecord();
            searchZipperReceiveSub();


        }


        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

        }


        protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
        {



            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");



        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {



            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);

            }


        }


        protected void gvEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
        {

        }




        #endregion

        protected void btnSearchZipperReceive_Click(object sender, EventArgs e)
        {
            searchZipperReceiveRecord();
            searchZipperReceiveSub();
            searchZipperReceiveEntryRecord();
        }

        protected void btnSheet_Click(object sender, EventArgs e)
        {
            try
            {
                

                  ZipperReceiveSheet();

                
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

        protected void btnSearchZipperRecord_Click(object sender, EventArgs e)
        {
            searchZipperReceiveRecord();
            searchZipperReceiveSub();
            searchZipperReceiveEntryRecord();
        }

    }
}