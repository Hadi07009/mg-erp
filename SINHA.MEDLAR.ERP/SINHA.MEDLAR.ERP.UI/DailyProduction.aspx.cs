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
using System.Drawing;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class DailyProduction : System.Web.UI.Page
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
                getLineId();

               
                //getLineId();
                //getStyleId();
                //getColorId();
                dtpProductionDate.Text = DateTime.Now.ToString("dd/MM/yyyy");     

            }

            if (IsPostBack)
            {

                loadSesscion();
                

            }


            
            Session["BuyerId"] = ddlLineId.SelectedValue;

        }


        #region "Function"

        //  ........... AutoCompleteType Fill Textbox ............
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<string> GetPONo(string PONo)
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();

            List<string> allPONo = new List<string>();

            string strBuyerId = "";
            if (System.Web.HttpContext.Current.Session["BuyerId"].ToString() != " ")
            {
                strBuyerId = System.Web.HttpContext.Current.Session["BuyerId"].ToString();
            }
            else
            {
                strBuyerId = "";
            }
            allPONo = objLookUpBLL.SearchPONo(PONo, strBuyerId);

            return allPONo;
        }


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





        public void getLineId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
           

           


            ddlLineId.DataSource = objLookUpBLL.getLineId(strHeadOfficeId,  strBranchOfficeId);

            ddlLineId.DataTextField = "LINE_NAME";
            ddlLineId.DataValueField = "LINE_ID";

            ddlLineId.DataBind();
            if (ddlLineId.Items.Count > 0)
            {

                ddlLineId.SelectedIndex = 0;
            }


        }
        

        private void FirstGridViewRow()
        {


          
            DataTable dt = new DataTable();
            DataRow dr = null;
           

            dt.Columns.Add(new DataColumn("PO_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("STYLE_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("ORDER_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("CUTTING_ISSUED_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("CUTTING_DELIVERY_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("SEWING_INPUT_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("SEWING_OUTPUT_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("WASH_SEND_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("WASH_RECEIVED_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("FINISHING_POLY_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("FINISHING_CARTON_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("BUYER_NAME", typeof(string)));

            dr = dt.NewRow();
          

            dr["PO_NO"] = string.Empty;
            dr["STYLE_NO"] = string.Empty;
            dr["ORDER_QUANTITY"] = string.Empty;
            dr["CUTTING_ISSUED_QUANTITY"] = string.Empty;
            dr["CUTTING_DELIVERY_QUANTITY"] = string.Empty;
            dr["SEWING_INPUT_QUANTITY"] = string.Empty;
            dr["SEWING_OUTPUT_QUANTITY"] = string.Empty;
            dr["WASH_SEND_QUANTITY"] = string.Empty;
            dr["WASH_RECEIVED_QUANTITY"] = string.Empty;
            dr["FINISHING_POLY_QUANTITY"] = string.Empty;
            dr["FINISHING_CARTON_QUANTITY"] = string.Empty;
            dr["TRAN_ID"] = string.Empty;
            dr["BUYER_NAME"] = string.Empty;
            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvDailyProduction.DataSource = dt;
            gvDailyProduction.DataBind();
            gvDailyProduction.Columns[12].Visible = false;
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


                        TextBox txtPONo = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[0].FindControl("txtPONo");
                        TextBox txtStyleNo = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[1].FindControl("txtStyleNo");
                        TextBox txtOrderQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[2].FindControl("txtOrderQty");
                        TextBox txtCuttingIssuedQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[3].FindControl("txtCuttingIssuedQty");
                        TextBox txtCuttingDeliveyQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[4].FindControl("txtCuttingDeliveyQty");
                        TextBox txtSewingInputQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[5].FindControl("txtSewingInputQty");
                        TextBox txtSewingOutputQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[6].FindControl("txtSewingOutputQty");
                        TextBox txtWashSentQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[7].FindControl("txtWashSentQty");
                        TextBox txtWashReceivedQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[8].FindControl("txtWashReceivedQty");
                        TextBox txtFinishingPolyQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[9].FindControl("txtFinishingPolyQty");
                        TextBox txtFinishingCartonQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[10].FindControl("txtFinishingCartonQty");
                        TextBox txtTranId = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[11].FindControl("txtTranId");



                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["PO_NO"] = txtPONo.Text;
                        dtCurrentTable.Rows[i - 1]["STYLE_NO"] = txtStyleNo.Text;
                        dtCurrentTable.Rows[i - 1]["ORDER_QUANTITY"] = txtOrderQty.Text;
                        dtCurrentTable.Rows[i - 1]["CUTTING_ISSUED_QUANTITY"] = txtCuttingIssuedQty.Text;
                        dtCurrentTable.Rows[i - 1]["CUTTING_DELIVERY_QUANTITY"] = txtCuttingDeliveyQty.Text;
                        dtCurrentTable.Rows[i - 1]["SEWING_INPUT_QUANTITY"] = txtSewingInputQty.Text;
                        dtCurrentTable.Rows[i - 1]["SEWING_OUTPUT_QUANTITY"] = txtSewingOutputQty.Text;
                        dtCurrentTable.Rows[i - 1]["WASH_SEND_QUANTITY"] = txtWashSentQty.Text;
                        dtCurrentTable.Rows[i - 1]["WASH_RECEIVED_QUANTITY"] = txtWashReceivedQty.Text;
                        dtCurrentTable.Rows[i - 1]["FINISHING_POLY_QUANTITY"] = txtFinishingPolyQty.Text;
                        dtCurrentTable.Rows[i - 1]["FINISHING_CARTON_QUANTITY"] = txtFinishingCartonQty.Text;
                        dtCurrentTable.Rows[i - 1]["TRAN_ID"] = txtTranId.Text;

                        rowIndex++;
                     
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvDailyProduction.DataSource = dtCurrentTable;
                    gvDailyProduction.DataBind();

                    for (int i = 0; i <= rowIndex; i++)
                    {
                        TextBox txtPONo = (TextBox)gvDailyProduction.Rows[i].FindControl("txtPONo");
                        TextBox txtStyleNo = (TextBox)gvDailyProduction.Rows[i].FindControl("txtStyleNo");
                        TextBox txtOrderQty = (TextBox)gvDailyProduction.Rows[i].FindControl("txtOrderQty");
                        txtPONo.Attributes.Add("readonly", "readonly");
                        txtStyleNo.Attributes.Add("readonly", "readonly");
                        txtOrderQty.Attributes.Add("readonly", "readonly");
                    }
                    TextBox txtCuttingIssuedQtyFocus = (TextBox)gvDailyProduction.Rows[rowIndex].FindControl("txtCuttingIssuedQty");
                    txtCuttingIssuedQtyFocus.Focus();
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


                        TextBox txtPONo = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[0].FindControl("txtPONo");
                        TextBox txtStyleNo = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[1].FindControl("txtStyleNo");
                        TextBox txtOrderQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[2].FindControl("txtOrderQty");
                        TextBox txtCuttingIssuedQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[3].FindControl("txtCuttingIssuedQty");
                        TextBox txtCuttingDeliveyQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[4].FindControl("txtCuttingDeliveyQty");
                        TextBox txtSewingInputQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[5].FindControl("txtSewingInputQty");
                        TextBox txtSewingOutputQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[6].FindControl("txtSewingOutputQty");
                        TextBox txtWashSentQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[7].FindControl("txtWashSentQty");
                        TextBox txtWashReceivedQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[8].FindControl("txtWashReceivedQty");
                        TextBox txtFinishingPolyQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[9].FindControl("txtFinishingPolyQty");
                        TextBox txtFinishingCartonQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[10].FindControl("txtFinishingCartonQty");
                        TextBox txtTranId = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[11].FindControl("txtTranId");

                        txtPONo.Text = dt.Rows[i]["PO_NO"].ToString();
                        txtStyleNo.Text = dt.Rows[i]["STYLE_NO"].ToString();
                        txtOrderQty.Text = dt.Rows[i]["ORDER_QUANTITY"].ToString();
                        txtCuttingIssuedQty.Text = dt.Rows[i]["CUTTING_ISSUED_QUANTITY"].ToString();
                        txtCuttingDeliveyQty.Text = dt.Rows[i]["CUTTING_DELIVERY_QUANTITY"].ToString();
                        txtSewingInputQty.Text = dt.Rows[i]["SEWING_INPUT_QUANTITY"].ToString();
                        txtSewingOutputQty.Text = dt.Rows[i]["SEWING_OUTPUT_QUANTITY"].ToString();
                        txtWashSentQty.Text = dt.Rows[i]["WASH_SEND_QUANTITY"].ToString();
                        txtWashReceivedQty.Text = dt.Rows[i]["WASH_RECEIVED_QUANTITY"].ToString();
                        txtFinishingPolyQty.Text = dt.Rows[i]["FINISHING_POLY_QUANTITY"].ToString();
                        txtFinishingCartonQty.Text = dt.Rows[i]["FINISHING_CARTON_QUANTITY"].ToString();
                        txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        public void addPORecord()
        {

            DailyProductionDTO objDailyProductionDTO = new DailyProductionDTO();
            DailyProductionBLL objDailyProductionBLL = new DailyProductionBLL();
            
            objDailyProductionDTO.LineId = ddlLineId.SelectedValue.ToString();
            objDailyProductionDTO.ProductionDate = dtpProductionDate.Text;
                        
            objDailyProductionDTO.UpdateBy = strEmployeeId;
            objDailyProductionDTO.HeadOfficeId = strHeadOfficeId;
            objDailyProductionDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objDailyProductionBLL.addPORecord(objDailyProductionDTO);
           
        }

        public void saveDailyProductionInfo()
        {
            
            DailyProductionDTO objDailyProductionDTO = new DailyProductionDTO();
            DailyProductionBLL objDailyProductionBLL = new DailyProductionBLL();

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
                        TextBox txtPONo = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[0].FindControl("txtPONo");
                        TextBox txtStyleNo = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[1].FindControl("txtStyleNo");
                        TextBox txtOrderQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[2].FindControl("txtOrderQty");
                        TextBox txtCuttingIssuedQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[3].FindControl("txtCuttingIssuedQty");
                        TextBox txtCuttingDeliveyQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[4].FindControl("txtCuttingDeliveyQty");
                        TextBox txtSewingInputQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[5].FindControl("txtSewingInputQty");
                        TextBox txtSewingOutputQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[6].FindControl("txtSewingOutputQty");
                        TextBox txtWashSentQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[7].FindControl("txtWashSentQty");
                        TextBox txtWashReceivedQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[8].FindControl("txtWashReceivedQty");
                        TextBox txtFinishingPolyQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[9].FindControl("txtFinishingPolyQty");
                        TextBox txtFinishingCartonQty = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[10].FindControl("txtFinishingCartonQty");
                        TextBox txtTranId = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[11].FindControl("txtTranId");
                        TextBox txtBuyerShortName = (TextBox)gvDailyProduction.Rows[rowIndex].Cells[11].FindControl("txtBuyerShortName");


                        if (ddlLineId.SelectedValue.ToString() != " ")
                        {
                            objDailyProductionDTO.LineId = ddlLineId.SelectedValue.ToString();
                        }
                        else
                        {

                            objDailyProductionDTO.LineId = "";
                        }
                        
                        if (dtpProductionDate.Text == "")
                        {
                            objDailyProductionDTO.ProductionDate = null;
                        }
                        else
                        {
                            objDailyProductionDTO.ProductionDate = dtpProductionDate.Text;

                        }

                        if (txtPONo.Text == "")
                        {
                            objDailyProductionDTO.PONo = "";                           
                        }
                        else
                        {
                            objDailyProductionDTO.PONo = txtPONo.Text;
                        }


                        if (txtStyleNo.Text == "")
                        {
                            objDailyProductionDTO.StyleNo = null;
                        }
                        else
                        {
                            objDailyProductionDTO.StyleNo = txtStyleNo.Text;

                        }
                        if (txtOrderQty.Text == "")
                        {
                            objDailyProductionDTO.OrderQty = "";
                        }
                        else
                        {
                            objDailyProductionDTO.OrderQty = txtOrderQty.Text;
                        }
                        
                        objDailyProductionDTO.CuttingIssuedQty = txtCuttingIssuedQty.Text;

                        objDailyProductionDTO.CuttingDeliveyQty = txtCuttingDeliveyQty.Text;
                        objDailyProductionDTO.SewingInputQty = txtSewingInputQty.Text;
                        objDailyProductionDTO.SewingOutputQty = txtSewingOutputQty.Text;

                        objDailyProductionDTO.WashSentQty = txtWashSentQty.Text;
                        objDailyProductionDTO.WashReceivedQty = txtWashReceivedQty.Text;
                        objDailyProductionDTO.FinishingPolyQty = txtFinishingPolyQty.Text;
                        objDailyProductionDTO.FinishingCartonQty = txtFinishingCartonQty.Text;

                        objDailyProductionDTO.TranId = txtTranId.Text;
                        objDailyProductionDTO.BuyerName = txtBuyerShortName.Text;

                        objDailyProductionDTO.UpdateBy = strEmployeeId;
                        objDailyProductionDTO.HeadOfficeId = strHeadOfficeId;
                        objDailyProductionDTO.BranchOfficeId = strBranchOfficeId;

                        strMsg = objDailyProductionBLL.saveDailyProductionInfo(objDailyProductionDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;
                        rowIndex++;

                    }

                    
                      

                }

                if (strMsg == "INSERTED SUCCESSFULLY" || strMsg == "UPDATED SUCCESSFULLY")
                {
                    MessageBox(strMsg);

                }
            }

        }

        public void LoadDailyProductionInfoSub()
        {

            DailyProductionDTO objDailyProductionDTO = new DailyProductionDTO();
            DailyProductionBLL objDailyProductionBLL = new DailyProductionBLL();

            DataTable dt = new DataTable();



          
            if (ddlLineId.Text != "")
            {
                objDailyProductionDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objDailyProductionDTO.LineId = "";
            }
            if (dtpProductionDate.Text != "")
            {
                objDailyProductionDTO.ProductionDate = dtpProductionDate.Text;
            }
            else
            {
                objDailyProductionDTO.ProductionDate = "";
            }

            objDailyProductionDTO.HeadOfficeId = strHeadOfficeId;
            objDailyProductionDTO.BranchOfficeId = strBranchOfficeId;

            dt = objDailyProductionBLL.LoadDailyProductionInfoSub(objDailyProductionDTO);

            gvDailyProduction.Columns[12].Visible = true;

            if (dt.Rows.Count > 0)
            {
                gvDailyProduction.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvDailyProduction.DataBind();
                gvDailyProduction.Columns[12].Visible = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox txtPONo = (TextBox)gvDailyProduction.Rows[i].FindControl("txtPONo");
                    TextBox txtStyleNo = (TextBox)gvDailyProduction.Rows[i].FindControl("txtStyleNo");
                    TextBox txtOrderQty = (TextBox)gvDailyProduction.Rows[i].FindControl("txtOrderQty");
                    txtPONo.Attributes.Add("readonly", "readonly");
                    txtStyleNo.Attributes.Add("readonly", "readonly");
                    txtOrderQty.Attributes.Add("readonly", "readonly");
                }
                int count = ((DataTable)gvDailyProduction.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                TextBox txtCuttingIssuedQty = (TextBox)gvDailyProduction.Rows[0].FindControl("txtCuttingIssuedQty");
                txtCuttingIssuedQty.Focus();

            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvDailyProduction.DataSource = dt;
                gvDailyProduction.DataBind();
                gvDailyProduction.Columns[12].Visible = false;
                int totalcolums = gvDailyProduction.Rows[0].Cells.Count;
                gvDailyProduction.Rows[0].Cells.Clear();
                gvDailyProduction.Rows[0].Cells.Add(new TableCell());
                gvDailyProduction.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvDailyProduction.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }


        }

        public void LoadDailyProductionFinalizedRecord()
        {

            DailyProductionDTO objDailyProductionDTO = new DailyProductionDTO();
            DailyProductionBLL objDailyProductionBLL = new DailyProductionBLL();

            DataTable dt = new DataTable();




            if (ddlLineId.Text != "")
            {
                objDailyProductionDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objDailyProductionDTO.LineId = "";
            }
            if (dtpProductionDate.Text != "")
            {
                objDailyProductionDTO.ProductionDate = dtpProductionDate.Text;
            }
            else
            {
                objDailyProductionDTO.ProductionDate = "";
            }

            objDailyProductionDTO.HeadOfficeId = strHeadOfficeId;
            objDailyProductionDTO.BranchOfficeId = strBranchOfficeId;

            dt = objDailyProductionBLL.LoadDailyProductionFinalizedRecord(objDailyProductionDTO);


            if (dt.Rows.Count > 0)
            {
                gvDailyProduction.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvDailyProduction.DataBind();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox txtPONo = (TextBox)gvDailyProduction.Rows[i].FindControl("txtPONo");
                    TextBox txtStyleNo = (TextBox)gvDailyProduction.Rows[i].FindControl("txtStyleNo");
                    TextBox txtOrderQty = (TextBox)gvDailyProduction.Rows[i].FindControl("txtOrderQty");
                    txtPONo.Attributes.Add("readonly", "readonly");
                    txtStyleNo.Attributes.Add("readonly", "readonly");
                    txtOrderQty.Attributes.Add("readonly", "readonly");
                }
                int count = ((DataTable)gvDailyProduction.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                TextBox txtCuttingIssuedQty = (TextBox)gvDailyProduction.Rows[0].FindControl("txtCuttingIssuedQty");
                txtCuttingIssuedQty.Focus();

            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvDailyProduction.DataSource = dt;
                gvDailyProduction.DataBind();
                int totalcolums = gvDailyProduction.Rows[0].Cells.Count;
                gvDailyProduction.Rows[0].Cells.Clear();
                gvDailyProduction.Rows[0].Cells.Add(new TableCell());
                gvDailyProduction.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvDailyProduction.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }


        }


        public void searcDailyProductionInfoMain()
        {
            DailyProductionDTO objDailyProductionDTO = new DailyProductionDTO();
            DailyProductionBLL objDailyProductionBLL = new DailyProductionBLL();

            string strFactoryId = "";
            string strLineId = "";
            string strProductionDate = "";

           

            if (ddlLineId.Text != "")
            {
                strLineId = ddlLineId.SelectedValue;
            }
            else
            {
                strLineId = "";
            }
            if (dtpProductionDate.Text != "")
            {
                strProductionDate = dtpProductionDate.Text;
            }
            else
            {
                strProductionDate = "";
            }

            objDailyProductionDTO = objDailyProductionBLL.searcDailyProductionInfoMain(strLineId, strProductionDate, strHeadOfficeId, strBranchOfficeId);


            if (objDailyProductionDTO.ProductionDate == "0")
            {
                dtpProductionDate.Text = "";
            }
            else
            {
                dtpProductionDate.Text = objDailyProductionDTO.ProductionDate;

            }          

        }

        //protected void getDdlByBuyerId()
        //{
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    int i = gvDailyProduction.Rows.Count;
        //    if (i == 1)
        //    {
        //        DropDownList a = (gvDailyProduction.Rows[0].FindControl("ddlStyleId") as DropDownList);

        //        DataTable dt1 = new DataTable();
        //        DataRowView dr1 = gvDailyProduction.Rows[0].DataItem as DataRowView;

        //        string strBuyerId = "";
        //        if (ddlLineId.SelectedValue != " ")
        //        {
        //            strBuyerId = ddlLineId.SelectedValue;
        //        }
        //        else
        //        {
        //            strBuyerId = "";
        //        }
        //        dt1 = objLookUpBLL.getStyleId(strBuyerId);
        //        a.DataSource = dt1;
        //        a.DataBind();

        //        DropDownList b = (gvDailyProduction.Rows[0].FindControl("ddlColorId") as DropDownList);

        //        DataTable dt2 = new DataTable();
        //        DataRowView dr2 = gvDailyProduction.Rows[0].DataItem as DataRowView;

        //        dt2 = objLookUpBLL.getColorId(strBuyerId);
        //        b.DataSource = dt2;
        //        b.DataBind();
        //    }
        //}

        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlLineId.Text == " ")
            {
                string strMsg = "Please Select Line Name!!!";
                MessageBox(strMsg);
                ddlLineId.Focus();
                return;


            }


            else if (dtpProductionDate.Text == " ")
            {
                string strMsg = "Please Enter Production Date!!!";
                MessageBox(strMsg);
                dtpProductionDate.Focus();
                return;


            }

            else
            {
                //searcDailyProductionInfoMain();
                LoadDailyProductionFinalizedRecord();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            if (ddlLineId.Text == " ")
            {
                string strMsg = "Please Select Line Name!!!";
                MessageBox(strMsg);
                ddlLineId.Focus();
                return;
                
            }
            else
            {
                saveDailyProductionInfo();
                LoadDailyProductionFinalizedRecord();
                // LoadDailyProductionInfoSub();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (ddlLineId.Text == " ")
            {
                string strMsg = "Please Select Line Name!!!";
                MessageBox(strMsg);
                ddlLineId.Focus();
                return;
            }
            else if (dtpProductionDate.Text == " ")
            {
                string strMsg = "Please Enter Production Date!!!";
                MessageBox(strMsg);
                dtpProductionDate.Focus();
                return;
            }
            else
            {
                addPORecord();
                LoadDailyProductionInfoSub();
            }
        }





        #region "Grid View Functionality"
        protected void gvDailyProduction_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDailyProduction.PageIndex = e.NewPageIndex;

        }

        protected void gvDailyProduction_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }




        protected void gvDailyProduction_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void gvDailyProduction_RowCommand(object sender, GridViewCommandEventArgs e)
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


        protected void gvDailyProduction_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
              


            }

        }


        #endregion

        protected void txtFinishingCartonQty_TextChanged(object sender, EventArgs e)
        {
            try
            {

                TextBox tb = (TextBox)sender;
                GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
                int rowindex = gvr.RowIndex;

                TextBox txtCuttingIssuedQty = (TextBox)gvDailyProduction.Rows[rowindex + 1].FindControl("txtCuttingIssuedQty");

                txtCuttingIssuedQty.Focus();
            }
            catch
            {
                MessageBox("Next Row not Found");
            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlLineId.Text == " ")
                {

                    string strMsg = "Please Select Line Name!!!";
                    MessageBox(strMsg);
                    ddlLineId.Focus();
                    return;
                }

                else if (dtpProductionDate.Text == " ")
                {

                    string strMsg = "Please Select Production Date!!!";
                    MessageBox(strMsg);
                    dtpProductionDate.Focus();
                    return;
                }
                else
                {
                    ProductionSummerySheet();

                    


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



        public void ProductionSummerySheet()
        {

            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                processDailyProductionSum();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;



                if (ddlLineId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.LineId = ddlLineId.SelectedValue.ToString();
                }
                else
                {

                    objReportDTO.LineId = "";
                }

                objReportDTO.FromDate = dtpProductionDate.Text;
                objReportDTO.ToDate = dtpProductionDate.Text;


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptProductionSummerySheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.ProductionSummerySheet(objReportDTO));


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


        public void processDailyProductionSum()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpProductionDate.Text;
            objReportDTO.ToDate = dtpProductionDate.Text;



            if (ddlLineId.SelectedValue.ToString() != " ")
            {
                objReportDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objReportDTO.LineId = "";
            }
           
                
          
            objReportDTO.BuyerId = "";
            objReportDTO.POId = "";
           





            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processDailyProductionSum(objReportDTO);





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

        protected void gvDailyProduction_RowCreated(object sender, GridViewRowEventArgs e)
        {
            string rowID = String.Empty;

            if (e.Row.RowType == DataControlRowType.DataRow)

            {

                rowID = "row" + e.Row.RowIndex;

                e.Row.Attributes.Add("id", "row" + e.Row.RowIndex);

                e.Row.Attributes.Add("onclick", "ChangeRowColor(" + "'" + rowID + "'" + ")");

            }
        }

        protected void ddlLineId_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvDailyProduction.DataSource = null;
            gvDailyProduction.DataBind();
        }

        protected void dtpProductionDate_TextChanged(object sender, EventArgs e)
        {
            gvDailyProduction.DataSource = null;
            gvDailyProduction.DataBind();
        }
    }
}