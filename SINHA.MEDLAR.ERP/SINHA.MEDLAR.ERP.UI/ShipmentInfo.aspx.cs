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
using System.Web.Services;
using System.Web.Script.Services;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ShipmentInfo : System.Web.UI.Page
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
                FirstGridViewRow();
                getBuyerIdSearch();
                getBuyerId();

                txtInvoiceNo.Focus();
               
            }

            if (IsPostBack)
            {

                loadSesscion();

            }


            txtInvoiceNo.Attributes.Add("onkeypress", "return controlEnter('" + ddlBuyerId.ClientID + "', event)");
            ddlBuyerId.Attributes.Add("onkeypress", "return controlEnter('" + dtpInvoiceDate.ClientID + "', event)");
            dtpInvoiceDate.Attributes.Add("onkeypress", "return controlEnter('" + dtpShipDate.ClientID + "', event)");
            dtpShipDate.Attributes.Add("onkeypress", "return controlEnter('" + txtRemarks.ClientID + "', event)");

            btnDelete.OnClientClick = "return isDelete();";


        }


        #region "Function"

        ////  ........... AutoCompleteType Fill Textbox ............
        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public static List<string> GetInvoiceNo(string InvoiceNo)
        //{
        //    ShipmentInfoBLL objShipmentInfoBLL = new ShipmentInfoBLL();

        //    List<string> allInvoiceNo = new List<string>();

        //    string strBuyerId = "";
        //    if (System.Web.HttpContext.Current.Session["BuyerId"].ToString() != " ")
        //    {
        //        strBuyerId = System.Web.HttpContext.Current.Session["BuyerId"].ToString();
        //    }
        //    else
        //    {
        //        strBuyerId = "";
        //    }
        //    allInvoiceNo = objShipmentInfoBLL.SearchInvoiceNo(InvoiceNo, strBuyerId);

        //    return allInvoiceNo;
        //}


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
                System.IO.Stream oStream = null;
                byte[] byteArray = null;

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                oStream = rd.ExportToStream(formatType);
                byteArray = new byte[oStream.Length];
                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(byteArray);
                Response.Flush();
                Response.Close();
                rd.Close();
                rd.Dispose();
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

        public void getBuyerIdSearch()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerSearchId.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerSearchId.DataTextField = "BUYER_SHORT_NAME";
            ddlBuyerSearchId.DataValueField = "BUYER_ID";

            ddlBuyerSearchId.DataBind();
            if (ddlBuyerSearchId.Items.Count > 0)
            {

                ddlBuyerSearchId.SelectedIndex = 0;
            }


        }

        public void getBuyerId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerId.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId,strBranchOfficeId);

            ddlBuyerId.DataTextField = "BUYER_SHORT_NAME";
            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {

                ddlBuyerId.SelectedIndex = 0;
            }


        }
        

        private void FirstGridViewRow()
        {


          
            DataTable dt = new DataTable();
            DataRow dr = null;
           

            dt.Columns.Add(new DataColumn("PO_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("STYLE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("RATE", typeof(string)));
            dt.Columns.Add(new DataColumn("QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("AMOUNT", typeof(string)));
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));


            dr = dt.NewRow();
          

            dr["PO_NO"] = string.Empty;
            dr["STYLE_ID"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["QUANTITY"] = string.Empty;
            dr["AMOUNT"] = string.Empty;
            dr["TRAN_ID"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvShipmentInfo.DataSource = dt;
            gvShipmentInfo.DataBind();
            gvShipmentInfo.Columns[5].Visible = false;

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
            getBuyerId();
            dtpInvoiceDate.Text = "";
            dtpShipDate.Text = "";
            txtRemarks.Text = "";


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
                        

                        TextBox txtPONo = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[0].FindControl("txtPONo");
                        DropDownList ddlStyleId = (DropDownList)gvShipmentInfo.Rows[rowIndex].Cells[1].FindControl("ddlStyleId");                      
                        TextBox txtRate = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[2].FindControl("txtRate");
                        TextBox txtQuantity = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[3].FindControl("txtQuantity");
                        TextBox txtAmount = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[4].FindControl("txtAmount");
                        TextBox txtTranId = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[5].FindControl("txtTranId");



                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["PO_NO"] = txtPONo.Text;
                        dtCurrentTable.Rows[i - 1]["STYLE_ID"] = ddlStyleId.Text;
                        dtCurrentTable.Rows[i - 1]["RATE"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["QUANTITY"] = txtQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["AMOUNT"] = txtAmount.Text;
                        dtCurrentTable.Rows[i - 1]["TRAN_ID"] = txtTranId.Text;
                     


                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvShipmentInfo.DataSource = dtCurrentTable;
                    gvShipmentInfo.DataBind();
                    for (int i = 0; i <= rowIndex; i++)
                    {
                        TextBox Amount = (TextBox)gvShipmentInfo.Rows[i].FindControl("txtAmount");
                        Amount.Attributes.Add("readonly", "readonly");
                    }

                    TextBox strtxtPONo = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[0].FindControl("txtPONo");
                    strtxtPONo.Focus();

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


                        TextBox txtPONo = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[0].FindControl("txtPONo");
                        DropDownList ddlStyleId = (DropDownList)gvShipmentInfo.Rows[rowIndex].Cells[1].FindControl("ddlStyleId");
                        TextBox txtRate = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[2].FindControl("txtRate");
                        TextBox txtQuantity = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[3].FindControl("txtQuantity");
                        TextBox txtAmount = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[4].FindControl("txtAmount");
                        TextBox txtTranId = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[5].FindControl("txtTranId");

                        txtPONo.Text = dt.Rows[i]["PO_NO"].ToString();
                        ddlStyleId.Text = dt.Rows[i]["STYLE_ID"].ToString();
                        txtRate.Text = dt.Rows[i]["RATE"].ToString();
                        txtQuantity.Text = dt.Rows[i]["QUANTITY"].ToString();
                        txtAmount.Text = dt.Rows[i]["AMOUNT"].ToString();
                        txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();

                        rowIndex++;
                    }
                }
            }
        }
        public void saveShipmentInfo()
        {


            ShipmentInfoDTO objShipmentInfoDTO = new ShipmentInfoDTO();
            ShipmentInfoBLL objShipmentInfoBLL = new ShipmentInfoBLL();

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
                        TextBox txtPONo = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[0].FindControl("txtPONo");
                        DropDownList ddlStyleId = (DropDownList)gvShipmentInfo.Rows[rowIndex].Cells[1].FindControl("ddlStyleId");
                        TextBox txtRate = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[2].FindControl("txtRate");
                        TextBox txtQuantity = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[3].FindControl("txtQuantity");
                        TextBox txtAmount = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[4].FindControl("txtAmount");
                        TextBox txtTranId = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[5].FindControl("txtTranId");

                        if (txtTranId.Text == "")
                        {
                            objShipmentInfoDTO.TranId = null;
                        }
                        else 
                        {
                            objShipmentInfoDTO.TranId = txtTranId.Text;

                        }
                        objShipmentInfoDTO.InvoiceNo = txtInvoiceNo.Text;
                        
                        if (dtpInvoiceDate.Text == "")
                        {
                            objShipmentInfoDTO.InvoiceDate = null;
                        }
                        else
                        {
                            objShipmentInfoDTO.InvoiceDate = dtpInvoiceDate.Text;

                        }


                        if (dtpShipDate.Text == "")
                        {
                            objShipmentInfoDTO.ShipDate = "";
                        }
                        else
                        {
                            objShipmentInfoDTO.ShipDate = dtpShipDate.Text;

                        }
                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objShipmentInfoDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                        }
                        else
                        {

                            objShipmentInfoDTO.BuyerId = "";

                        }

                        objShipmentInfoDTO.Remarks = txtRemarks.Text;


                       
                        if (txtPONo.Text != "")
                        {
                            objShipmentInfoDTO.PONo = txtPONo.Text; ;

                        }
                        else
                        {
                            objShipmentInfoDTO.PONo = "";

                        }

                        if (ddlStyleId.SelectedValue != "")
                        {
                            objShipmentInfoDTO.StyleId = ddlStyleId.SelectedValue;

                        }
                        else
                        {
                            objShipmentInfoDTO.StyleId = "";

                        }

                        objShipmentInfoDTO.Rate = txtRate.Text;
                        objShipmentInfoDTO.Quantity = txtQuantity.Text;

                        if (txtAmount.Text == "")
                        {
                            objShipmentInfoDTO.Amount = "";
                        }
                        else
                        {
                            objShipmentInfoDTO.Amount = txtAmount.Text;

                        }
  
                        objShipmentInfoDTO.TranId = txtTranId.Text;


                        objShipmentInfoDTO.UpdateBy = strEmployeeId;
                        objShipmentInfoDTO.HeadOfficeId = strHeadOfficeId;
                        objShipmentInfoDTO.BranchOfficeId = strBranchOfficeId;


                        if (ddlStyleId.SelectedValue == " ")
                        {
                            string strMsgstyle = "Please Select Style NO!!!";
                            MessageBox(strMsgstyle);
                            return;
                        }

                        if (txtPONo.Text != "")
                        {
                            strMsg = objShipmentInfoBLL.saveShipmentInfo(objShipmentInfoDTO);
                            //MessageBox(strMsg);
                            lblMsg.Text = strMsg;
                        }

                        rowIndex++;                      

                    }
                    if (strMsg == "THIS PO DOES NOT BELONG TO THIS BUYER!!!")
                    {
                        MessageBox(strMsg);
                        return;
                    }
                }                           
                MessageBox(strMsg);

              
            }
            LoadShipmentInfoSub();
            TotalCalculation();
        }

        public void LoadShipmentInfoSub()
        {

            ShipmentInfoDTO objShipmentInfoDTO = new ShipmentInfoDTO();
            ShipmentInfoBLL objShipmentInfoBLL = new ShipmentInfoBLL();

            DataTable dt = new DataTable();


            objShipmentInfoDTO.InvoiceNo = txtInvoiceNo.Text;
            if (dtpInvoiceDate.Text != "")
            {
                objShipmentInfoDTO.InvoiceDate = dtpInvoiceDate.Text;
            }
            else
            {
                objShipmentInfoDTO.InvoiceDate = "";
            }
            
            if (dtpShipDate.Text != "")
            {
                objShipmentInfoDTO.ShipDate = dtpShipDate.Text;
            }
            else
            {
                objShipmentInfoDTO.ShipDate = "";
            }
            if (ddlBuyerId.SelectedValue != "")
            {
                objShipmentInfoDTO.BuyerId = ddlBuyerId.SelectedValue;
            }
            else
            {
                objShipmentInfoDTO.BuyerId = "";
            }

            objShipmentInfoDTO.HeadOfficeId = strHeadOfficeId;
            objShipmentInfoDTO.BranchOfficeId = strBranchOfficeId;

            dt = objShipmentInfoBLL.LoadShipmentInfoSub(objShipmentInfoDTO);

            gvShipmentInfo.Columns[5].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvShipmentInfo.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvShipmentInfo.DataBind();
                gvShipmentInfo.Columns[5].Visible = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox Amount = (TextBox)gvShipmentInfo.Rows[i].FindControl("txtAmount");
                    Amount.Attributes.Add("readonly", "readonly");
                }
                int count = ((DataTable)gvShipmentInfo.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;

            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvShipmentInfo.DataSource = dt;
                gvShipmentInfo.DataBind();
                gvShipmentInfo.Columns[5].Visible = false;
                //int totalcolums = gvShipmentInfo.Rows[0].Cells.Count;
                //gvShipmentInfo.Rows[0].Cells.Clear();
                //gvShipmentInfo.Rows[0].Cells.Add(new TableCell());
                //gvShipmentInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                //gvShipmentInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }


        }

        public void searchShipmentInfoMain()
        {
            ShipmentInfoDTO objShipmentInfoDTO = new ShipmentInfoDTO();
            ShipmentInfoBLL objShipmentInfoBLL = new ShipmentInfoBLL();

            string strInvoiceNo = "";
            if (txtInvoiceNo.Text != "")
            {
                strInvoiceNo = txtInvoiceNo.Text;
            }
            else
            {
                strInvoiceNo = "";
            }

            objShipmentInfoDTO = objShipmentInfoBLL.searchShipmentInfoMain(strInvoiceNo, strHeadOfficeId, strBranchOfficeId);


            if (objShipmentInfoDTO.InvoiceDate == "0")
            {
                dtpInvoiceDate.Text = "";
            }
            else
            {
                dtpInvoiceDate.Text = objShipmentInfoDTO.InvoiceDate;

            }
            if (objShipmentInfoDTO.ShipDate == "0")
            {
                dtpShipDate.Text = "";
            }
            else
            {
                dtpShipDate.Text = objShipmentInfoDTO.ShipDate;

            }
            if (objShipmentInfoDTO.BuyerId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlBuyerId.SelectedValue = objShipmentInfoDTO.BuyerId;
            }

            if (objShipmentInfoDTO.Remarks == "0")
            {

                txtRemarks.Text = "";
            }
            else
            {
                txtRemarks.Text = objShipmentInfoDTO.Remarks;
            }

        }

        protected void getDdlByBuyerId()
        {
            //LookUpBLL objLookUpBLL = new LookUpBLL();

            //int i = gvShipmentInfo.Rows.Count;
            //if (i == 1)
            //{
            //    DropDownList b = (gvShipmentInfo.Rows[i - 1].FindControl("ddlPOId") as DropDownList);

            //    DataTable dt2 = new DataTable();
            //    DataRowView dr2 = gvShipmentInfo.Rows[i - 1].DataItem as DataRowView;

            //    string strBuyerId = "";
            //    if (ddlBuyerId.SelectedValue != " ")
            //    {
            //        strBuyerId = ddlBuyerId.SelectedValue;
            //    }
            //    else
            //    {
            //        strBuyerId = "";
            //    }

            //    dt2 = objLookUpBLL.getPONo(strBuyerId);
            //    b.DataSource = dt2;
            //    b.DataBind();



            //    DropDownList c = (gvShipmentInfo.Rows[i - 1].FindControl("ddlStyleId") as DropDownList);

            //    DataTable dt3 = new DataTable();
            //    DataRowView dr3 = gvShipmentInfo.Rows[i - 1].DataItem as DataRowView;

            //    dt3 = objLookUpBLL.getStyleId(strBuyerId, strHeadOfficeId, strBranchOfficeId);
            //    c.DataSource = dt3;
            //    c.DataBind();
            //}
        }

        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpInvoiceDate.Text == "")
            {
                string strMsg = "Please Enter Invoice Date!!!";
                MessageBox(strMsg);
                dtpInvoiceDate.Focus();
                return;


            }
            else if (dtpShipDate.Text == " ")
            {
                string strMsg = "Please Enter Ship Date Type!!!";
                MessageBox(strMsg);
                dtpShipDate.Focus();
                return;


            }
            else if (ddlBuyerId.Text == " ")
            {
                string strMsg = "Please Select Buyer Name!!!";
                MessageBox(strMsg);
                ddlBuyerId.Focus();
                return;


            }

            else
            {
                saveShipmentInfo();
               
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtInvoiceNo.Text == "")
            {
                string strMsg = "Please Enter Invoice No!!!";
                MessageBox(strMsg);
                txtInvoiceNo.Focus();
                return;
            }
            else
            {              
                searchShipmentInfoMain();
                LoadShipmentInfoSub();
                TotalCalculation();
            }

        }




        #region "Grid View Functionality"
        protected void gvShipmentInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShipmentInfo.PageIndex = e.NewPageIndex;

        }

      


        protected void gvShipmentInfo_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }
        protected void gvShipmentInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)gvShipmentInfo.Rows[e.RowIndex];
                Label lbldeleteid = (Label)row.FindControl("TRAN_ID");

                //if (lbldeleteid == null)
                //{

                //    string strMsg = "ID NOT FOUND!!!";
                //    MessageBox(strMsg);
                //    return;
                //}
                //else
                //{


                int stor_id = Convert.ToInt32(gvShipmentInfo.DataKeys[e.RowIndex].Value.ToString());
                string strTarnId = Convert.ToString(stor_id);

                deleteShipmentInfoSubRecord(strTarnId);
                searchShipmentInfoMain();
                LoadShipmentInfoSub();
                TotalCalculation();


            }
            catch
            {
                MessageBox("It haven't any ID to delete");
            }
        }
        public void deleteShipmentInfoSubRecord(string strTarnId)
        {
            ShipmentInfoDTO objShipmentInfoDTO = new ShipmentInfoDTO();
            ShipmentInfoBLL objShipmentInfoBLL = new ShipmentInfoBLL();

            objShipmentInfoDTO.TranId = strTarnId;
            objShipmentInfoDTO.InvoiceNo = txtInvoiceNo.Text;
            objShipmentInfoDTO.InvoiceDate = dtpInvoiceDate.Text;

            if (ddlBuyerId.SelectedValue.ToString() != "")
            {
                objShipmentInfoDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
            }
            else
            {
                objShipmentInfoDTO.BuyerId = "";
            }



            objShipmentInfoDTO.UpdateBy = strEmployeeId;
            objShipmentInfoDTO.HeadOfficeId = strHeadOfficeId;
            objShipmentInfoDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objShipmentInfoBLL.deleteShipmentInfoSubRecord(objShipmentInfoDTO);
            MessageBox(strMsg);
        }
        protected void gvShipmentInfo_RowCommand(object sender, GridViewCommandEventArgs e)
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


        protected void gvShipmentInfo_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
                try
                {

                    LookUpBLL objLookUpBLL = new LookUpBLL();

                    string strBuyerId;
                    if (ddlBuyerId.SelectedValue != "")
                    {
                        strBuyerId = ddlBuyerId.SelectedValue;
                    }
                    else
                    {
                        strBuyerId = "";
                    }
                    TextBox txtPONo = (e.Row.FindControl("txtPONo") as TextBox);


                    DropDownList b = (e.Row.FindControl("ddlStyleId") as DropDownList);

                    DataTable dt = new DataTable();
                    DataRowView dr = e.Row.DataItem as DataRowView;

                    dt = objLookUpBLL.getStyleIdByPO(strBuyerId, txtPONo.Text, strHeadOfficeId, strBranchOfficeId);
                    b.DataSource = dt;
                    b.DataBind();
                    b.SelectedValue = dr["STYLE_ID"].ToString();



                }
                catch (Exception ex)
                {

                }         
        }
        #endregion
        protected void btnForPO_Click(object sender, EventArgs e)
        {
            getPOWiseDate();
            // Nothing to do but it's need for Auto post back ....
        }

        protected void btnForQuantity_Click(object sender, EventArgs e)
        {
            getPOWiseDate();
            // Nothing to do but it's need for Auto post back ....
        }
        protected void txtPONo_TextChanged(object sender, EventArgs e)
        {
            ShipmentInfoDTO objShipmentInfoDTO = new ShipmentInfoDTO();
            ShipmentInfoBLL objShipmentInfoBLL = new ShipmentInfoBLL();

            TextBox tb = (TextBox)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;

            TextBox txtPONo = (TextBox)gvShipmentInfo.Rows[rowindex].FindControl("txtPONo");

            string strPONo = txtPONo.Text;
            string strBuyerId = "";

            if (ddlBuyerId.SelectedValue == " ")
            {

                string strMsg = "Please Select Buyer Name!!!";
                MessageBox(strMsg);
                ddlBuyerId.Focus();
                return;

            }
            else
            {
                strBuyerId = ddlBuyerId.SelectedValue;

                objShipmentInfoDTO = objShipmentInfoBLL.chkPONo(strPONo, strBuyerId, strHeadOfficeId, strBranchOfficeId);

                if (objShipmentInfoDTO.ChkYN == "Y")
                {
                    txtPONo.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    txtPONo.BackColor = System.Drawing.Color.Red;
                }
                DropDownList ddlStyleId = (DropDownList)gvShipmentInfo.Rows[0].FindControl("ddlStyleId");
                ddlStyleId.Focus();
            }


            LookUpBLL objLookUpBLL = new LookUpBLL();

            DropDownList b = (DropDownList)gvShipmentInfo.Rows[rowindex].FindControl("ddlStyleId");

            DataTable dt = new DataTable();
            DataRowView dr = gvShipmentInfo.Rows[rowindex].DataItem as DataRowView;

            dt = objLookUpBLL.getStyleIdByPO(strBuyerId, strPONo, strHeadOfficeId, strBranchOfficeId);
            b.DataSource = dt;
            b.DataBind();

        }
        //protected void txtStyleNo_TextChanged(object sender, EventArgs e)
        //{
        //    ShipmentInfoDTO objShipmentInfoDTO = new ShipmentInfoDTO();
        //    ShipmentInfoBLL objShipmentInfoBLL = new ShipmentInfoBLL();

        //    TextBox tb = (TextBox)sender;
        //    GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
        //    int rowindex = gvr.RowIndex;

        //    TextBox txtStyleNo = (TextBox)gvShipmentInfo.Rows[rowindex].FindControl("txtStyleNo");

        //    string strStyleNo = txtStyleNo.Text;

        //    if (ddlBuyerId.SelectedValue == " ")
        //    {

        //        string strMsg = "Please Select Buyer Name!!!";
        //        MessageBox(strMsg);
        //        ddlBuyerId.Focus();
        //        return;

        //    }
        //    else
        //    {
        //        string strBuyerId = ddlBuyerId.SelectedValue;

        //        objShipmentInfoDTO = objShipmentInfoBLL.chkStyleNo(strStyleNo, strBuyerId, strHeadOfficeId, strBranchOfficeId);

        //        if (objShipmentInfoDTO.ChkYN == "Y")
        //        {
        //            txtStyleNo.BackColor = System.Drawing.Color.Green;
        //        }
        //        else
        //        {
        //            txtStyleNo.BackColor = System.Drawing.Color.Red;
        //        }
        //        TextBox txtRate = (TextBox)gvShipmentInfo.Rows[rowindex].FindControl("txtRate");
        //        txtRate.Focus();
        //    }
        //}

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            ShipmentInfoDTO objShipmentInfoDTO = new ShipmentInfoDTO();
            ShipmentInfoBLL objShipmentInfoBLL = new ShipmentInfoBLL();

            objShipmentInfoDTO.InvoiceNo = txtInvoiceNo.Text;
            if (dtpInvoiceDate.Text != "")
            {
                objShipmentInfoDTO.InvoiceDate = dtpInvoiceDate.Text;
            }
            else
            {
                objShipmentInfoDTO.InvoiceDate = "";
            }

            if (ddlBuyerId.SelectedValue.ToString() != "")
            {
                objShipmentInfoDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
            }
            else
            {
                objShipmentInfoDTO.BuyerId = "";
            }



            objShipmentInfoDTO.UpdateBy = strEmployeeId;
            objShipmentInfoDTO.HeadOfficeId = strHeadOfficeId;
            objShipmentInfoDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objShipmentInfoBLL.deleteShipmentInfoRecord(objShipmentInfoDTO);
            MessageBox(strMsg);

            searchShipmentInfoMain();

            LoadShipmentInfoSub();
            TotalCalculation();
            clearTextBox();
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

        protected void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceNo.Text == "")
                {

                    string strMsg = "Please Enter Invoice NO!!!";
                    MessageBox(strMsg);
                    txtInvoiceNo.Focus();
                    return;
                }

                else if (dtpInvoiceDate.Text == " ")
                {

                    string strMsg = "Please Enter Invoice Date!!!";
                    MessageBox(strMsg);
                    dtpInvoiceDate.Focus();
                    return;
                }
                else
                {

                    dailyShipmentSheet();

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



        public void dailyShipmentSheet()
        {

            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                if (ddlBuyerId.SelectedValue.ToString() != "")
                {
                    objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.BuyerId = "";
                }



                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.InvoiceNo = txtInvoiceNo.Text;
               


                objReportDTO.FromDate = dtpInvoiceDate.Text;
                objReportDTO.ToDate = dtpInvoiceDate.Text;


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyShipmentInfo.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.dailyShipmentSheet(objReportDTO));


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

        public void getPOId()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            string strPOId = "";



            strPOId = txtPONo.Text;


            objLookUpDTO = objLookUpBLL.getPOId(strPOId, strHeadOfficeId, strBranchOfficeId);

            if (objLookUpDTO.POId != null)
            {
                txtPOId.Text = objLookUpDTO.POId;
            }
            else
            {
                txtPOId.Text = "";

            }






        }

        protected void btnReportByPOWise_Click(object sender, EventArgs e)
        {
            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();



            if (dtpFromDate.Text == "")
            {
                string strMsg = "Please Enter From Date!!!";
                dtpFromDate.Focus();
                MessageBox(strMsg);
                return;

            }
            else if (dtpToDate.Text == "")
            {
                string strMsg = "Please Enter To Date!!!";
                dtpToDate.Focus();
                MessageBox(strMsg);
                return;

            }

            else if (txtPONo.Text == "")
            {
                string strMsg = "Please Select PO!!!";
                txtPONo.Focus();
                MessageBox(strMsg);
                return;

            }
            else if (ddlBuyerSearchId.Text == " ")
            {
                string strMsg = "Please Select Buyer Name!!!";
                ddlBuyerSearchId.Focus();
                MessageBox(strMsg);
                return;

            }


            else
            {

                getPOId();

                shipmentProcessByPO();



                objReportDTO.LineId = "";
                
                if (ddlBuyerId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
                }
                else
                {
                    objReportDTO.BuyerId = "";
                }
                if (txtPONo.Text != "")
                {
                    objReportDTO.POId = txtPOId.Text;
                }
                else
                {
                    objReportDTO.POId = "";
                }


                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptProductionShipmentSheetByPODetail.rpt"));
                
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rdoProductionShipmentSheetByPODetail(objReportDTO));


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
        }

        public void shipmentProcessByPO()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;




            objReportDTO.LineId = "";

            if (ddlBuyerSearchId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerSearchId.SelectedValue;
            }
            else
            {
                objReportDTO.BuyerId = "";
            }
            if (txtPONo.Text != "")
            {
                objReportDTO.POId = txtPOId.Text;
            }
            else
            {
                objReportDTO.POId = "";
            }





            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.shipmentProcessByPO(objReportDTO);





        }
        public void ProductionAndShipmentSheetByBuyer()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;



           
            objReportDTO.LineId = "";
            
            if (ddlBuyerSearchId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerSearchId.SelectedValue;
            }
            else
            {
                objReportDTO.BuyerId = "";
            }
            if (txtPONo.Text != "")
            {
                objReportDTO.POId = txtPOId.Text;
            }
            else
            {
                objReportDTO.POId = "";
            }





            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.ProductionAndShipmentSheetByBuyer(objReportDTO);





        }
        public void ProductionAndShipmentSheetUpdate()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;



          
            objReportDTO.LineId = "";
            
            if (ddlBuyerSearchId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerSearchId.SelectedValue;
            }
            else
            {
                objReportDTO.BuyerId = "";
            }
            if (txtPONo.Text != "")
            {
                objReportDTO.POId = txtPOId.Text;
            }
            else
            {
                objReportDTO.POId = "";
            }





            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.ProductionAndShipmentSheetUpdate(objReportDTO);





        }


        public void getPOWiseDate()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            string strPONo = "";



            strPONo = txtPONo.Text;


            objLookUpDTO = objLookUpBLL.getPOWiseDate(strPONo, strHeadOfficeId, strBranchOfficeId);

            if (objLookUpDTO.PODate != null || objLookUpDTO.PODate != "")
            {
                dtpFromDate.Text = objLookUpDTO.PODate;
                dtpToDate.Text = objLookUpDTO.ToDate;
            }
            else
            {
                dtpFromDate.Text = "";
                dtpToDate.Text = "";

            }
            if (objLookUpDTO.BuyerId != null || objLookUpDTO.BuyerId != "")
            {
                ddlBuyerSearchId.SelectedValue = objLookUpDTO.BuyerId;
            }
            else
            {
                getBuyerIdSearch();
            }
        }

        protected void btnDateSrc_Click(object sender, EventArgs e)
        {
            getPOWiseDate();
        }
        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            TotalCalculation();
        }           
        public void TotalCalculation()
        {
            txtTotalQuantity.Text = "0";
            txtTotalAmount.Text = "0";
            int gvShipmentInfo_CountRow = gvShipmentInfo.Rows.Count;
            for (int i = 0; i < gvShipmentInfo_CountRow; i++)
            {
                TextBox txtQuantity = (TextBox)gvShipmentInfo.Rows[i].FindControl("txtQuantity");

                if (txtQuantity.Text == "" || txtQuantity.Text==null)
                {
                    txtQuantity.Text = "0";
                }
                txtTotalQuantity.Text = Convert.ToString(Convert.ToDouble(txtTotalQuantity.Text) + Convert.ToDouble(txtQuantity.Text));

                //Total Amount              
                TextBox txtAmount = (TextBox)gvShipmentInfo.Rows[i].FindControl("txtAmount");

                if (txtAmount.Text == "" || txtAmount.Text == null)
                {
                    txtAmount.Text = "0";
                }
                txtTotalAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(txtAmount.Text));
            }
        }



    }
}