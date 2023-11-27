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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Collections;

using System.Data;



using System.Net;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class PurchaseEntry : System.Web.UI.Page
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
                getUnitId();
                getProductIdSearch();
                getProductId();
                getSectionId();
                clearMsg();
                getOfficeName();
               
                btnSearch.Focus();


            }

            if (IsPostBack)
            {

                loadSesscion();

            }


           

            txtLedgerNo.Attributes.Add("onkeypress", "return controlEnter('" + txtSerialNo.ClientID + "', event)");
            txtSerialNo.Attributes.Add("onkeypress", "return controlEnter('" + txtRequisitionNo.ClientID + "', event)");
            txtRequisitionNo.Attributes.Add("onkeypress", "return controlEnter('" + dtpRequisitionDate.ClientID + "', event)");
            dtpRequisitionDate.Attributes.Add("onkeypress", "return controlEnter('" + txtMRRNo.ClientID + "', event)");
            txtMRRNo.Attributes.Add("onkeypress", "return controlEnter('" + dtpMRRDate.ClientID + "', event)");
            dtpMRRDate.Attributes.Add("onkeypress", "return controlEnter('" + dtpPurchaseDate.ClientID + "', event)");
            dtpPurchaseDate.Attributes.Add("onkeypress", "return controlEnter('" + ddlProductId.ClientID + "', event)");
            ddlProductId.Attributes.Add("onkeypress", "return controlEnter('" + txtPurchaseQuantity.ClientID + "', event)");

            txtPurchaseQuantity.Attributes.Add("onkeypress", "return controlEnter('" + txtPrice.ClientID + "', event)");
            txtPrice.Attributes.Add("onkeypress", "return controlEnter('" + txtSupplierName.ClientID + "', event)");
            txtSupplierName.Attributes.Add("onkeypress", "return controlEnter('" + txtWarranty.ClientID + "', event)");
            txtWarranty.Attributes.Add("onkeypress", "return controlEnter('" + txtProductDescription.ClientID + "', event)");
            txtProductDescription.Attributes.Add("onkeypress", "return controlEnter('" + txtRemarks.ClientID + "', event)");

        }


        #region "Function"
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

        public void clearYellowTextBox()
        {
           
            txtEmployeeId.Text = string.Empty;
            txtEmployeeDesignation.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
           

        }

        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
        public void clearTextBox()
        {
            txtSerialNo.Text = "";
            txtRequisitionNo.Text = "";
            txtPrice.Text = "";
            txtEmployeeId.Text = string.Empty;
            txtEmployeeDesignation.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtMRRNo.Text = "";
            dtpMRRDate.Text = "";
            dtpPurchaseDate.Text = "";
            dtpRequisitionDate.Text = "";
            txtWarranty.Text = "";
            txtSupplierName.Text = "";
            txtPurchaseQuantity.Text = "";
            txtInvoiceNo.Text = "";
            txtProductDescription.Text = "";
            txtRemarks.Text = "";
            txtLedgerNo.Text = "";
            txtTranId.Text = "";
            txtEmpName.Text = "";
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



        public void searchInvoiceInfo()
        {

            PurchaseDTO objPurchaseDTO = new PurchaseDTO ();
            PurchaseBLL objPurchaseBLL = new PurchaseBLL ();


            objPurchaseDTO = objPurchaseBLL.searchInvoiceInfo(txtInvoiceNo.Text, txtTranId.Text);


            if (objPurchaseDTO.SLNo == "0")
            {
                txtSerialNo.Text = "";
            }
            else
            {

                txtSerialNo.Text = objPurchaseDTO.SLNo;
            }

            if (objPurchaseDTO.ProductId == "0")
            {
                getProductId();
            }
            else
            {

                ddlProductId.SelectedValue = objPurchaseDTO.ProductId;
            }


            if (objPurchaseDTO.LedgerNo == "0")
            {
                txtLedgerNo.Text = "";
            }
            else
            {

                txtLedgerNo.Text = objPurchaseDTO.LedgerNo;
            }


           
            txtRequisitionNo.Text = objPurchaseDTO.RequisitionNo;
            dtpRequisitionDate.Text = objPurchaseDTO.RequisitionDate;


            if (objPurchaseDTO.CardNo == "0")
            {
                txtCardNo.Text = "";
            }
            else
            {
                txtCardNo.Text = objPurchaseDTO.CardNo;

            }

            if (objPurchaseDTO.EmployeeId == "0")
            {
                txtEmployeeId.Text = "";
            }
            else
            {
                txtEmployeeId.Text = objPurchaseDTO.EmployeeId;

            }
            if (objPurchaseDTO.EmployeeName == "N/A")
            {
                txtEmployeeName.Text = "";
            }
            else
            {
                txtEmployeeName.Text = objPurchaseDTO.EmployeeName;

            }


            if (objPurchaseDTO.DesignationName == "N/A")
            {
                txtEmployeeDesignation.Text = "";
            }
            else
            {
                txtEmployeeDesignation.Text = objPurchaseDTO.DesignationName;

            }


            if (objPurchaseDTO.MRRNo == "0")
            {
                txtMRRNo.Text = "";
            }
            else
            {

                txtMRRNo.Text = objPurchaseDTO.MRRNo;
            }
           
            dtpMRRDate.Text = objPurchaseDTO.MRRDate;
            dtpPurchaseDate.Text = objPurchaseDTO.PurchaseDate;

            if (objPurchaseDTO.Quantity == "0")
            {
                txtPurchaseQuantity.Text = "";
            }
            else
            {

                txtPurchaseQuantity.Text = objPurchaseDTO.Quantity;
            }

            if (objPurchaseDTO.Price == "0")
            {
                txtPrice.Text = "";
            }
            else
            {

                txtPrice.Text = objPurchaseDTO.Price;
            }
          
            txtWarranty.Text = objPurchaseDTO.WarrantyPeriod;
            txtSupplierName.Text = objPurchaseDTO.SupplierName;
            txtProductDescription.Text = objPurchaseDTO.ProductionDescription;
            txtRemarks.Text = objPurchaseDTO.Remarks;


            if (objPurchaseDTO.EmpName == "N/A")
            {
                txtEmpName.Text = "";
            }
            else
            {
                txtEmpName.Text = objPurchaseDTO.EmpName;

            }




        }
        public void chkPDFFileExist()
        {

            PurchaseDTO objPurchaseDTO = new PurchaseDTO();
            PurchaseBLL objPurchaseBLL = new PurchaseBLL();


            objPurchaseDTO = objPurchaseBLL.chkPDFFileExist(txtInvoiceNo.Text, txtRequisitionNo.Text);

            if (objPurchaseDTO.FileExistsYn == "Y")
            {
                savePurchaseInfo();
               
            }
            else
            {
                chkPDFFile();

            }
         




        }
        public void getUnitId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlUnitId.DataSource = objLookUpBLL.getUnitIdForPurchase();

            ddlUnitId.DataTextField = "UNIT_NAME";
            ddlUnitId.DataValueField = "UNIT_ID";

            ddlUnitId.DataBind();
            if (ddlUnitId.Items.Count > 0)
            {

                ddlUnitId.SelectedIndex = 0;
            }

        }


        public void getProductIdSearch()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlProductIdSearch.DataSource = objLookUpBLL.getProductId();

            ddlProductIdSearch.DataTextField = "PRODUCT_NAME";
            ddlProductIdSearch.DataValueField = "PRODUCT_ID";

            ddlProductIdSearch.DataBind();
            if (ddlProductIdSearch.Items.Count > 0)
            {

                ddlProductIdSearch.SelectedIndex = 0;
            }

        }

        public void getProductId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlProductId.DataSource = objLookUpBLL.getProductId();

            ddlProductId.DataTextField = "PRODUCT_NAME";
            ddlProductId.DataValueField = "PRODUCT_ID";

            ddlProductId.DataBind();
            if (ddlProductId.Items.Count > 0)
            {

                ddlProductId.SelectedIndex = 0;
            }

        }

        public void getSectionId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSectionId.DataSource = objLookUpBLL.getSectionIdForPurchase();

            ddlSectionId.DataTextField = "SECTION_NAME";
            ddlSectionId.DataValueField = "SECTION_ID";

            ddlSectionId.DataBind();
            if (ddlSectionId.Items.Count > 0)
            {

                ddlSectionId.SelectedIndex = 0;
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


        public void searchEmployeeRecordforPurchaseEntry()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;

           

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";

            }





            dt = objEmployeeBLL.searchEmployeeRecordforPurchaseEntry(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

               

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
                //gvEmployeeList.Columns[2].Visible = false;
                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }

        }
        public void searchPurchaseEntryRecord()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;

            objEmployeeDTO.EmployeeName = txtEmpNameSearch.Text;

            objEmployeeDTO.FromDate = dtpPurchaseDateFrom.Text;
            objEmployeeDTO.ToDate = dtpPurchaseDateTo.Text;

            objEmployeeDTO.SLNo = txtSLNoSearch.Text;
            objEmployeeDTO.RequisitionNo = txtRequisitionSearch.Text;

            objEmployeeDTO.SupplierName = txtSupplierNameSearch.Text;


            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";

            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";

            }


            if (ddlProductIdSearch.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.ProductId = ddlProductIdSearch.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.ProductId = "";

            }





            dt = objEmployeeBLL.searchPurchaseEntryRecord(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
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
                //gvEmployeeList.Columns[2].Visible = false;
                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }

        }

        public void savePurchaseInfo()
        {

            PurchaseDTO objPurchaseDTO = new PurchaseDTO();
            PurchaseBLL objPurchaseBLL = new PurchaseBLL();


            objPurchaseDTO.InvoiceNo = txtInvoiceNo.Text;
            objPurchaseDTO.LedgerNo = txtLedgerNo.Text;
            objPurchaseDTO.SLNo = txtSerialNo.Text;
            objPurchaseDTO.RequisitionNo = txtRequisitionNo.Text;
            objPurchaseDTO.RequisitionDate = dtpRequisitionDate.Text;
            objPurchaseDTO.MRRNo = txtMRRNo.Text;
            objPurchaseDTO.MRRDate = dtpMRRDate.Text;
            objPurchaseDTO.PurchaseDate = dtpPurchaseDate.Text;
            objPurchaseDTO.TranId = txtTranId.Text;

            objPurchaseDTO.Quantity = txtPurchaseQuantity.Text;
            objPurchaseDTO.Price = txtPrice.Text;
            objPurchaseDTO.WarrantyPeriod = txtWarranty.Text;
            objPurchaseDTO.SupplierName = txtSupplierName.Text;
            objPurchaseDTO.Remarks = txtRemarks.Text;
            objPurchaseDTO.ProductionDescription = txtProductDescription.Text;

            objPurchaseDTO.EmployeeId = txtEmployeeId.Text;


            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objPurchaseDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objPurchaseDTO.UnitId = "";

            }

            if (ddlProductId.SelectedValue.ToString() != " ")
            {
                objPurchaseDTO.ProductId = ddlProductId.SelectedValue.ToString();
            }
            else
            {
                objPurchaseDTO.ProductId = "";

            }



            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objPurchaseDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objPurchaseDTO.SectionId = "";

            }


            objPurchaseDTO.EmployeeName = txtEmpName.Text;


            objPurchaseDTO.UpdateBy = strEmployeeId;
            objPurchaseDTO.HeadOfficeId = strHeadOfficeId;
            objPurchaseDTO.BranchOfficeId = strBranchOfficeId;




            string strMsg = objPurchaseBLL.savePurchaseInfo(objPurchaseDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


            if (strMsg == "PRODUCT SERIAL NO ALREADY EXISTS!!!" )
            {
                MessageBox(strMsg);
                return;

            }

            if (strMsg != "UPDATED SUCCESSFULLY" && strMsg != "" && strMsg != null)
            {

                uploadFile();
                searchPurchaseEntryRecord();

                string input = strMsg;
                string subStr = input.Substring(41);
                txtInvNo.Text = subStr;

               

            }
          

           

        }

        public void chkPDFFile()
        {

            string fileName = Server.HtmlEncode(FileUpload1.FileName);
            string extension = System.IO.Path.GetExtension(fileName);
            // Allow only files with .doc or .xls extensions
            // to be uploaded.




            if (extension == ".pdf")
            {
                savePurchaseInfo();
                uploadFile();
                searchPurchaseEntryRecord();
            }
            else
            {

                string strMsg = "Only PDF file is Allow!!!";
                MessageBox(strMsg);
                return;



            }



        }



        public void PurchaseSheet()
        {

            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;


                objReportDTO.ProductSLNo = txtSLNoSearch.Text;
                objReportDTO.RequisitionNo = txtRequisitionNo.Text;
                objReportDTO.FromDate = dtpPurchaseDateFrom.Text;
                objReportDTO.ToDate = dtpPurchaseDateTo.Text;


                if (ddlProductIdSearch.SelectedValue.ToString() != " ")
                {
                    objReportDTO.ProductId = ddlProductIdSearch.SelectedValue.ToString();
                }
                else
                { 

                    objReportDTO.ProductId = "";
                }


                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {

                    objReportDTO.SectionId = "";
                }



                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";

                }







                string strPath = Path.Combine(Server.MapPath("~/Reports/rptPurchaseInfo.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.PurchaseSheet(objReportDTO));


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


        public void uploadFile()
        {
            try
            {


                    if (FileUpload1.HasFile)
                    {
                        PurchaseDTO objPurchaseDTO = new PurchaseDTO();
                        PurchaseBLL objPurchaseBLL = new PurchaseBLL();



                        HttpPostedFile imgFile = FileUpload1.PostedFile;

                        string strContentType = FileUpload1.PostedFile.ContentType;

                        string strFileName = FileUpload1.PostedFile.FileName;
                        string strFileNamePath = Path.GetFileName(strFileName);
                        string ext = Path.GetExtension(strFileNamePath);
                        txtFileName.Text = FileUpload1.FileName; ;



                        FileInfo fi = new System.IO.FileInfo(FileUpload1.PostedFile.FileName);

                        string fileName = fi.Name;
                        BinaryReader b = new BinaryReader(imgFile.InputStream);
                        byte[] byteArray = b.ReadBytes(imgFile.ContentLength);
                        string fileSize = Convert.ToBase64String(byteArray);

                        if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
                        {



                            objPurchaseDTO.InvoiceNo = txtInvoiceNo.Text;
                            objPurchaseDTO.RequisitionNo = txtRequisitionNo.Text;
                            objPurchaseDTO.EmployeeId = txtEmployeeId.Text;
                            objPurchaseDTO.FileName = txtFileName.Text;
                            objPurchaseDTO.FileSize = fileSize;







                            objPurchaseDTO.UpdateBy = strEmployeeId;
                            objPurchaseDTO.HeadOfficeId = strHeadOfficeId;
                            objPurchaseDTO.BranchOfficeId = strBranchOfficeId;

                            string strMsg = objPurchaseBLL.PurchaseFileSave(objPurchaseDTO);
                            //MessageBox(strMsg);







                        }



                       

                    }

                }


            

            catch (Exception ex)
            {

                FileUpload1.Dispose();
                FileUpload1.FileContent.Dispose();
                FileUpload1.PostedFile.InputStream.Close();
                FileUpload1.PostedFile.InputStream.Dispose();
                lblMsg.Text = ex.Message;

            }


            //Response.Redirect(Request.Url.AbsoluteUri);

        }

        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
            getProductId();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
             if (dtpPurchaseDate.Text == "")
            {

                string strMsg = "Please Enter Purchase Date!!!";
                MessageBox(strMsg);
                dtpPurchaseDate.Focus();
                return;
            }

            else if (txtPurchaseQuantity.Text == "")
            {

                string strMsg = "Please Enter Purchase Quantity!!!";
                MessageBox(strMsg);
                txtPurchaseQuantity.Focus();
                return;
            }


            else if (txtPrice.Text == "")
            {

                string strMsg = "Please Enter Product Price!!!";
                MessageBox(strMsg);
                txtPrice.Focus();
                return;
            }

            else if (txtEmpName.Text == "")
            {

                string strMsg = "Please Enter Employee Name!!!";
                MessageBox(strMsg);
                txtEmpName.Focus();
                return;
            }


            else
            {
                chkPDFFileExist();

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchPurchaseEntryRecord();
        }

        protected void btnSheet_Click(object sender, EventArgs e)
        {
            try
            {

                PurchaseSheet();

                
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

                searchInvoiceInfo();

            }
        }

        protected void btnSearchEmployeeRecrod_Click(object sender, EventArgs e)
        {

           
                searchEmployeeRecordforPurchaseEntry();
                searchPurchaseEntryRecord();

            
        }



        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
           
        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {


            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtEmployeeDesignation.Text = strDesignation;

            


        }


        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{

            //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            //    string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            //    string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            //    string strEmployeeId = gvEmployeeList.SelectedRow.Cells[5].Text;
            //    string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            //    string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


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

            //int selectedRowIndex = gvEmployeeList.SelectedRow.RowIndex;
            //gvEmployeeList.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

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
        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {


            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strInvoiceNo = GridView1.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string strEmployeeId = GridView1.SelectedRow.Cells[5].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[3].Text;
            string strDesignation = GridView1.SelectedRow.Cells[4].Text;
            string strTranId = GridView1.SelectedRow.Cells[23].Text.Replace("&nbsp;", "");

            txtSL.Text = Convert.ToString(strRowId);

            txtInvoiceNo.Text = strInvoiceNo;
            txtInvNo.Text = strInvoiceNo;
            txtTranId.Text = strTranId;


            searchInvoiceInfo();

        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{

            //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            //    string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            //    string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            //    string strEmployeeId = gvEmployeeList.SelectedRow.Cells[5].Text;
            //    string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            //    string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


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

            //int selectedRowIndex = gvEmployeeList.SelectedRow.RowIndex;
            //gvEmployeeList.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }

        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {

        }


        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {



            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");



        }

        protected void GridView1_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {



            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);

            }


        }


        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }




        #endregion

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

        protected void btnView_Click(object sender, EventArgs e)
        {
            if (txtInvoiceNo.Text == " ")
            {

                string strMsg = "Please Enter Invoice No!!!";
                MessageBox(strMsg);
                txtInvoiceNo.Focus();
                return;
            }
            else
            {


                Response.Redirect(String.Format("PurchaseHandler.ashx?REQUISITION_NO={0}", Server.UrlEncode(txtRequisitionNo.Text)));
            }
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {

        }
    }
}