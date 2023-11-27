using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SINHA.MEDLAR.ERP.DTO;

using SINHA.MEDLAR.ERP.BLL;


using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Script.Services;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ReportProduction : System.Web.UI.Page
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

        ReportDocument rd = new ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;

            }

            if (!IsPostBack)
            {


                loadSession();
                //getUnitId();
                //getSectionId();              
                getOfficeName();
                getBuyerId();
                getLineId();

                Session["BuyerId"] = "";


            }
            if (IsPostBack)
            {
                loadSession();

            }
        }


        #region "Load ComboBox"


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
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

        //public void getSectionId()
        //{


        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlSectionId.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

        //    ddlSectionId.DataTextField = "SECTION_NAME";
        //    ddlSectionId.DataValueField = "SECTION_ID";

        //    ddlSectionId.DataBind();
        //    if (ddlSectionId.Items.Count > 0)
        //    {

        //        ddlSectionId.SelectedIndex = 0;
        //    }



        //}

        //public void getRequisitionId()
        //{


        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlSalaryRequisitionId.DataSource = objLookUpBLL.getRequisitionId();

        //    ddlSalaryRequisitionId.DataTextField = "SALARY_REQUISITION_NAME";
        //    ddlSalaryRequisitionId.DataValueField = "SALARY_REQUISITION_ID";

        //    ddlSalaryRequisitionId.DataBind();
        //    if (ddlSalaryRequisitionId.Items.Count > 0)
        //    {

        //        ddlSalaryRequisitionId.SelectedIndex = 0;
        //    }



        //}


        //public void getUnitId()
        //{


        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlUnitId.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

        //    ddlUnitId.DataTextField = "UNIT_NAME";
        //    ddlUnitId.DataValueField = "UNIT_ID";

        //    ddlUnitId.DataBind();
        //    if (ddlUnitId.Items.Count > 0)
        //    {

        //        ddlUnitId.SelectedIndex = 0;
        //    }

        //}




        #endregion

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
        public void loadSession()
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
        public void generatePopUp()
        {
            DateTime now = DateTime.Now;
            string date = now.Year.ToString() + now.Month.ToString() +
                          now.Day.ToString() + now.Hour.ToString() +
                          now.Minute.ToString() + now.Second.ToString();


            string javascript = "window.open('CrystalView.aspx'," +
                                "'" + date + "'" +
                                ",'location=0, status=0, scrollbars= 0," +
                                "width=800, height=600');";

            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(this.Page.GetType(), date, javascript, true);

        }


        #region "Export Convert Function"
        public void ReportFormatMaster()
        {
            //Export the report in different format
            string strDefaultName = "Report";
            ExportFormatType formatType = ExportFormatType.NoFormat;
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
                //Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();


                rd.ExportToHttpResponse
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "report_other");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }

            if (chkWord.Checked == true)
            {
                //formatType = ExportFormatType.WordForWindows;
                //MemoryStream oStream;
                //oStream = (MemoryStream)rd.ExportToStream(formatType);
                //Response.ContentType = "application/vnd.ms-word";
                //oStream.Seek(0, SeekOrigin.Begin);
                //Response.BinaryWrite(oStream.ToArray());
                //Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();


                Response.ClearContent();
                Response.ClearHeaders();
                rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, "report_other");
                Response.End();   

            }

            if (chkCSV.Checked == true)
            {
                formatType = ExportFormatType.CharacterSeparatedValues;
                rd.ExportToHttpResponse(formatType, Response, true, strDefaultName);
                Response.End();
                CrystalReportViewer1.RefreshReport();
            }

            if (chkText.Checked == true)
            {
                formatType = ExportFormatType.RichText;
                MemoryStream oStream;
                oStream = (MemoryStream)rd.ExportToStream(formatType);
                Response.ContentType = "text/html";
                oStream.Seek(0, SeekOrigin.Begin);
                Response.BinaryWrite(oStream.ToArray());
                Response.End();
                oStream.Flush();
                oStream.Close();
                oStream.Dispose();
                CrystalReportViewer1.RefreshReport();
            }


            //switch (rbFormat.SelectedItem.Value)
            //{
            //    case "Word":
            //        formatType = ExportFormatType.WordForWindows;
            //        break;
            //    case "PDF":
            //        formatType = ExportFormatType.PortableDocFormat;
            //        break;
            //    case "Excel":
            //        formatType = ExportFormatType.Excel;
            //        break;
            //    case "CSV":
            //        formatType = ExportFormatType.CharacterSeparatedValues;
            //        break;
            //}

            //rd.ExportToHttpResponse(formatType, Response, true, strDefaultName );
            //Response.End();
            //CrystalReportViewer1.RefreshReport();





        }



        #endregion


        #region "Export PDF/EXCEL/WORD"
        public void exportReport()
        {
            if (chkExcel.Checked == true)
            {
                string attachment = "attachment; filename=Export.xls";
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                HtmlForm frm = new HtmlForm();
                //gv.Parent.Controls.Add(frm);
                //frm.Attributes["runat"] = "server";
                //frm.Controls.Add(gv);
                frm.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
            }
            if (chkWord.Checked == true)
            {
                Response.AddHeader("content-disposition", "attachment;filename=Export.doc");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.word";

                StringWriter stringWrite = new StringWriter();
                HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

                HtmlForm frm = new HtmlForm();
                //gv.Parent.Controls.Add(frm);
                //frm.Attributes["runat"] = "server";
                //frm.Controls.Add(gv);
                //frm.RenderControl(htmlWrite);

                Response.Write(stringWrite.ToString());
                Response.End();
            }
            if (chkPDF.Checked == true)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Export.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                HtmlForm frm = new HtmlForm();
                //gv.Parent.Controls.Add(frm);
                //frm.Attributes["runat"] = "server";
                //frm.Controls.Add(gv);
                frm.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                //pdfDoc.Open();
                //htmlparser.Parse(sr);
                //pdfDoc.Close();
                //Response.Write(pdfDoc);
                Response.End();
            }


        }

        #endregion

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {

                getPOId();

                //if (rdoProductionSheet.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                  
                //    if (dtpFromDate.Text == "")
                //    {
                //        string strMsg = "Please Enter From Date!!!";
                //        dtpFromDate.Focus();
                //        MessageBox(strMsg);
                //        return;

                //    }
                //    else if (dtpToDate.Text == "")
                //    {
                //        string strMsg = "Please Enter To Date!!!";
                //        dtpToDate.Focus();
                //        MessageBox(strMsg);
                //        return;

                //    }

                //    else
                //    {

                        
                //        processProductionDetail();


                //        if (ddlLineId.SelectedValue.ToString() != " ")
                //        {
                //            objReportDTO.LineId = ddlLineId.SelectedValue;
                //        }
                //        else
                //        {
                //            objReportDTO.LineId = "";
                //        }
                //        if (ddlBuyerId.SelectedValue.ToString() != " ")
                //        {
                //            objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
                //        }
                //        else
                //        {
                //            objReportDTO.BuyerId = "";
                //        }
                //        if (txtPOId.Text != "")
                //        {
                //            objReportDTO.POId = txtPOId.Text;
                //        }
                //        else
                //        {
                //            objReportDTO.POId = "";
                //        }
                        
                       
                //        objReportDTO.FromDate = dtpFromDate.Text;
                //        objReportDTO.ToDate = dtpToDate.Text;

                //        objReportDTO.HeadOfficeId = strHeadOfficeId;
                //        objReportDTO.BranchOfficeId = strBranchOfficeId;
                //        objReportDTO.UpdateBy = strEmployeeId;


                //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptProductionSheet.rpt"));
                //        this.Context.Session["strReportPath"] = strPath;
                //        rd.Load(strPath);
                //        rd.SetDataSource(objReportBLL.rptProductionSheet(objReportDTO));


                //        rd.SetDatabaseLogon("erp", "erp");
                //        CrystalReportViewer1.ReportSource = rd;
                //        CrystalReportViewer1.DataBind();

                //        ReportFormatMaster();


                //        this.CrystalReportViewer1.Dispose();
                //        this.CrystalReportViewer1 = null;
                //        rd.Dispose();
                //        rd.Close();
                //        GC.Collect();
                //        GC.WaitForPendingFinalizers();

                //    }

                //}




                if (rdoProductionSheetByBuyer.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    if (ddlBuyerId.SelectedValue ==" ")
                    {
                        string strMsg = "Please Select Buyer!!!";
                        ddlBuyerId.Focus();
                        MessageBox(strMsg);
                        return;

                    }
                    else if (dtpFromDate.Text == "")
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

                    else
                    {

                        processProductionDetailByBuyer();

                       
                        if (ddlLineId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.LineId = ddlLineId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.LineId = "";
                        }
                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.BuyerId = "";
                        }
                        if (txtPOId.Text != "")
                        {
                            objReportDTO.POId = txtPOId.Text;
                        }
                        else
                        {
                            objReportDTO.POId = "";
                        }


                        objReportDTO.FromDate = dtpFromDate.Text;
                        objReportDTO.ToDate = dtpToDate.Text;
                        objReportDTO.PoStatus = ddlPoStatus.SelectedItem.Value;

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;


                        //string strPath = Path.Combine(Server.MapPath("~/Reports/rptProductionSheetByBuyer.rpt"));

                        string strPath = string.Empty;
                        if (objReportDTO.PoStatus == "1")
                        {
                            strPath = Path.Combine(Server.MapPath("~/Reports/DailyProductionOpen.rpt"));
                        }
                        if (objReportDTO.PoStatus == "2")
                        {
                            strPath = Path.Combine(Server.MapPath("~/Reports/DailyProductionOpenClose.rpt"));
                        }

                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetProductionSheet(objReportDTO));
                        
                        rd.SetDatabaseLogon("erp", "erp");
                        CrystalReportViewer1.ReportSource = rd;
                        CrystalReportViewer1.DataBind();

                        ReportFormatMaster();


                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }

                }


                if (rdoProductionSheetByBuyerAndFactory.Checked == true)
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

                    else
                    {

                        processProductionDetail();

                       
                        if (ddlLineId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.LineId = ddlLineId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.LineId = "";
                        }
                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.BuyerId = "";
                        }
                        if (txtPOId.Text != "")
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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptProductionSheetByBuyerAndFactory.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rptProductionSheetByBuyerAndFactory(objReportDTO));


                        rd.SetDatabaseLogon("erp", "erp");
                        CrystalReportViewer1.ReportSource = rd;
                        CrystalReportViewer1.DataBind();

                        ReportFormatMaster();


                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }

                }


                if (rdProductionDetailSheet.Checked == true)
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

                    else
                    {

                        ProcessdailyProduction();


                       
                        if (ddlLineId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.LineId = ddlLineId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.LineId = "";
                        }
                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.BuyerId = "";
                        }
                        if (txtPOId.Text != "")
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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptProductionDetailSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rptProductionDetailSheet(objReportDTO));


                        rd.SetDatabaseLogon("erp", "erp");
                        CrystalReportViewer1.ReportSource = rd;
                        CrystalReportViewer1.DataBind();

                        ReportFormatMaster();


                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }

                }


                if (rdoMonthlyProductionSheet.Checked == true)
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

                    else
                    {

                        monthlyProductionSheet();



                        if (ddlLineId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.LineId = ddlLineId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.LineId = "";
                        }
                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.BuyerId = "";
                        }
                        if (txtPOId.Text != "")
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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyProductionSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rptMonthlyProductionSheetOnlyFinalized(objReportDTO));


                        rd.SetDatabaseLogon("erp", "erp");
                        CrystalReportViewer1.ReportSource = rd;
                        CrystalReportViewer1.DataBind();

                        ReportFormatMaster();


                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }

                }





                if (rdoProductionSheetByPODetail.Checked == true)
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

                    else if (txtPOId.Text == "")
                    {
                        string strMsg = "Please Select PO!!!";
                        txtPOId.Focus();
                        MessageBox(strMsg);
                        return;

                    }


                    else
                    {
                        ProductionSheetByPODetail();
                        
                        if (ddlLineId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.LineId = ddlLineId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.LineId = "";
                        }
                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.BuyerId = "";
                        }
                        if (txtPOId.Text != "")
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
                        
                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptProductionSheetByPODetail.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rdoProductionSheetByPODetail(objReportDTO));
                        
                        rd.SetDatabaseLogon("erp", "erp");
                        CrystalReportViewer1.ReportSource = rd;
                        CrystalReportViewer1.DataBind();

                        ReportFormatMaster();
                        
                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
                

                if (rdoMonthlyProductionSheetByPO.Checked == true)
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

                    else
                    {

                        processProductionSummery();


                       
                        if (ddlLineId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.LineId = ddlLineId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.LineId = "";
                        }
                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.BuyerId = "";
                        }


                        if (txtPOId.Text != "")
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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptProductionSheetByPO.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rptMonthlyProductionSheetByPO(objReportDTO));


                        rd.SetDatabaseLogon("erp", "erp");
                        CrystalReportViewer1.ReportSource = rd;
                        CrystalReportViewer1.DataBind();

                        ReportFormatMaster();


                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }

                }

                if (rdoPoWiseProductionShipment.Checked == true)
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

                    else if (txtPOId.Text == "")
                    {
                        string strMsg = "Please Select PO!!!";
                        txtPOId.Focus();
                        MessageBox(strMsg);
                        return;

                    }
                    else if (ddlBuyerId.Text == " ")
                    {
                        string strMsg = "Please Select Buyer Name!!!";
                        ddlBuyerId.Focus();
                        MessageBox(strMsg);
                        return;

                    }


                    else
                    {

                        //ProductionAndShipmentSheetByBuyer();
                        //ProductionAndShipmentSheetUpdate();
                        shipmentProcessByPO();


                        if (ddlLineId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.LineId = ddlLineId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.LineId = "";
                        }
                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.BuyerId = "";
                        }
                        if (txtPOId.Text != "")
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

                        ReportFormatMaster();


                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }

                }



                if (rdoShipmentStatementByBuyer.Checked == true)
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
                    
                    else if (ddlBuyerId.Text == " ")
                    {
                        string strMsg = "Please Select Buyer Name!!!";
                        ddlBuyerId.Focus();
                        MessageBox(strMsg);
                        return;

                    }


                    else
                    {

                        ProductionAndShipmentSheetByBuyer();
                        //ProductionAndShipmentSheetUpdate();


                       
                        if (ddlLineId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.LineId = ddlLineId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.LineId = "";
                        }
                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
                        }
                        else
                        {
                            objReportDTO.BuyerId = "";
                        }
                        if (txtPOId.Text != "")
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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptShipmentStatementByBuyer.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rdoProductionShipmentSheetByBuyerFactory(objReportDTO));


                        rd.SetDatabaseLogon("erp", "erp");
                        CrystalReportViewer1.ReportSource = rd;
                        CrystalReportViewer1.DataBind();

                        ReportFormatMaster();


                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }

                }

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
        protected void btnDateSrc_Click(object sender, EventArgs e)
        {
            getPOWiseDate();
        }

        #region "Function"
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
            if(objLookUpDTO.BuyerId !=null || objLookUpDTO.BuyerId != "")
            {
                ddlBuyerId.SelectedValue = objLookUpDTO.BuyerId;
            }
            else
            {
                getBuyerId();
            }
        }
//  ........... AutoCompleteType Fill Textbox ............
//[WebMethod]
//[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
//public static List<string> GetPONo(string PONo)
//{
//    ReportBLL objReportBLL = new ReportBLL();

//    List<string> allPONo = new List<string>();

//    string strBuyerId = "";
//    if (System.Web.HttpContext.Current.Session["BuyerId"].ToString() != " ")
//    {
//        strBuyerId = System.Web.HttpContext.Current.Session["BuyerId"].ToString();
//    }
//    else
//    {
//        strBuyerId = "";
//    }
//    allPONo = objReportBLL.SearchPONo(PONo, strBuyerId);

//    return allPONo;
//}



public void getPOId()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            string strPOId = "";



            strPOId = txtPONo.Text;


            objLookUpDTO = objLookUpBLL.getPOId(strPOId,strHeadOfficeId,strBranchOfficeId);

            if (objLookUpDTO.POId != null )
            {
                txtPOId.Text = objLookUpDTO.POId;
            }
            else
            {
                txtPOId.Text = "";

            }
           





        }

        public void getBuyerId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            string strLineId = "";

           

            ddlBuyerId.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerId.DataTextField = "BUYER_SHORT_NAME";
            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {

                ddlBuyerId.SelectedIndex = 0;
            }


        }
        public void getLineId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();

             string strLineId = "";

          
            ddlLineId.DataSource = objLookUpBLL.getLineId(strHeadOfficeId, strBranchOfficeId);

            ddlLineId.DataTextField = "LINE_NAME";
            ddlLineId.DataValueField = "LINE_ID";

            ddlLineId.DataBind();
            if (ddlLineId.Items.Count > 0)
            {

                ddlLineId.SelectedIndex = 0;
            }


        }


        public void processProductionSummery()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;



            if (ddlLineId.SelectedValue.ToString() != " ")
            {
                objReportDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objReportDTO.LineId = "";
            }
            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
            }
            else
            {
                objReportDTO.BuyerId = "";
            }
            if (txtPOId.Text != "")
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

            string strMsg = objReportBLL.processProductionSummery(objReportDTO);





        }

        public void processProductionDetail()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;



            if (ddlLineId.SelectedValue.ToString() != " ")
            {
                objReportDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objReportDTO.LineId = "";
            }
            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
            }
            else
            {
                objReportDTO.BuyerId = "";
            }
            if (txtPOId.Text != "")
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

             string strMsg = objReportBLL.processProductionDetail(objReportDTO);





        }

        public void processProductionDetailByBuyer()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;



            if (ddlLineId.SelectedValue.ToString() != " ")
            {
                objReportDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objReportDTO.LineId = "";
            }
            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
            }
            else
            {
                objReportDTO.BuyerId = "";
            }
            if (txtPOId.Text != "")
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

            string strMsg = objReportBLL.processProductionDetailByBuyer(objReportDTO);





        }

        public void dailyProductionDetail()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;



            if (ddlLineId.SelectedValue.ToString() != " ")
            {
                objReportDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objReportDTO.LineId = "";
            }
            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
            }
            else
            {
                objReportDTO.BuyerId = "";
            }
            if (txtPOId.Text != "")
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

            string strMsg = objReportBLL.dailyProductionDetail(objReportDTO);





        }

        public void monthlyProductionSheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;



            if (ddlLineId.SelectedValue.ToString() != " ")
            {
                objReportDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objReportDTO.LineId = "";
            }
            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
            }
            else
            {
                objReportDTO.BuyerId = "";
            }
            if (txtPOId.Text != "")
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

            string strMsg = objReportBLL.monthlyProductionSheet(objReportDTO);





        }

        public void ProcessdailyProduction()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;



            if (ddlLineId.SelectedValue.ToString() != " ")
            {
                objReportDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objReportDTO.LineId = "";
            }
            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
            }
            else
            {
                objReportDTO.BuyerId = "";
            }
            if (txtPOId.Text != "")
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

            string strMsg = objReportBLL.ProcessdailyProduction(objReportDTO);





        }
        public void ProductionSheetByPODetail()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;


           
            if (ddlLineId.SelectedValue.ToString() != " ")
            {
                objReportDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objReportDTO.LineId = "";
            }
            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
            }
            else
            {
                objReportDTO.BuyerId = "";
            }
            if (txtPOId.Text != "")
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

            string strMsg = objReportBLL.ProductionSheetByPODetail(objReportDTO);





        }
        public void ProductionAndShipmentSheetByBuyer()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;


         
            if (ddlLineId.SelectedValue.ToString() != " ")
            {
                objReportDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objReportDTO.LineId = "";
            }
            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
            }
            else
            {
                objReportDTO.BuyerId = "";
            }
            if (txtPOId.Text != "")
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
        public void shipmentProcessByPO()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;



            if (ddlLineId.SelectedValue.ToString() != " ")
            {
                objReportDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objReportDTO.LineId = "";
            }
            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
            }
            else
            {
                objReportDTO.BuyerId = "";
            }
            if (txtPOId.Text != "")
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
        public void ProductionAndShipmentSheetUpdate()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;


          
            if (ddlLineId.SelectedValue.ToString() != " ")
            {
                objReportDTO.LineId = ddlLineId.SelectedValue;
            }
            else
            {
                objReportDTO.LineId = "";
            }
            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerId.SelectedValue;
            }
            else
            {
                objReportDTO.BuyerId = "";
            }
            if (txtPOId.Text != "")
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


      

        #endregion
        #region "Crystal Report Functionality"

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {




            }

            else if (chkWord.Checked == true)
            {




            }

            else
            {

                ReportDocument rd = new ReportDocument();
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null; 
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

        }

        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {

            this.CrystalReportViewer1.ReportSource = null;

            CrystalReportViewer1.Dispose();

            if (rd != null)
            {

                rd.Close();

                rd.Dispose();

                rd = null;

            }

            GC.Collect();

            GC.WaitForPendingFinalizers();

        }

        #endregion

        protected void ddlBuyerId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["BuyerId"] = ddlBuyerId.SelectedValue;
        }

        protected void ddlFactoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            getLineId();
        }

        
    }
}