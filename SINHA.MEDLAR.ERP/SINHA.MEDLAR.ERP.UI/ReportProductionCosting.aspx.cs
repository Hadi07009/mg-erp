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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ReportProductionCosting : System.Web.UI.Page
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
                getOfficeName();
                getBuyerId();
                getCurrentYear();

            }
            if (IsPostBack)
            {
                loadSession();

            }
        }


        #region "Load ComboBox"
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


                if (rdoContractSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

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

                   
                    else if (dtpIssueDate.Text == "")
                    {
                        string strMsg = "Please Enter Issue Date!!!";
                        dtpIssueDate.Focus();
                        MessageBox(strMsg);
                        return;

                    }


                    else
                    {

                        processsDailyContractInfo();



                        if (ddlBuyerId.Text != "")
                        {

                            objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.BuyerId = "";

                        }


                        if (ddlContractId.Text != "")
                        {

                            objReportDTO.ContractId = ddlContractId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.ContractId = "";

                        }

                        if (ddlAmendmentId.Text != "0")
                        {

                            objReportDTO.AmendmentId = ddlAmendmentId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.AmendmentId = "";

                        }


                        if (ddlPOId.Text != " ")
                        {

                            objReportDTO.POId = ddlPOId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.POId = "";

                        }



                        if (ddlStyleId.Text != " ")
                        {

                            objReportDTO.StyleId = ddlStyleId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.StyleId = "";

                        }



                        objReportDTO.IssueDate = dtpIssueDate.Text;
                        objReportDTO.AmendDate = dtpAmendmentDate.Text;

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

                        ReportFormatMaster();


                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }

                }

                if (rdoCostingSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

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


                    else if (dtpIssueDate.Text == "")
                    {
                        string strMsg = "Please Enter Issue Date!!!";
                        dtpIssueDate.Focus();
                        MessageBox(strMsg);
                        return;

                    }


                    else if (ddlPOId.Text == "")
                    {
                        string strMsg = "Please Select PO NO!!!";
                        ddlPOId.Focus();
                        MessageBox(strMsg);
                        return;

                    }

                    else if (ddlStyleId.Text == "")
                    {
                        string strMsg = "Please Select Style NO!!!";
                        ddlStyleId.Focus();
                        MessageBox(strMsg);
                        return;

                    }



                    else
                    {

                      



                        if (ddlBuyerId.Text != "")
                        {

                            objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.BuyerId = "";

                        }


                        if (ddlContractId.Text != "")
                        {

                            objReportDTO.ContractId = ddlContractId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.ContractId = "";

                        }

                        if (ddlAmendmentId.Text != "0")
                        {

                            objReportDTO.AmendmentId = ddlAmendmentId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.AmendmentId = "";

                        }


                        if (ddlPOId.Text != " ")
                        {

                            objReportDTO.POId = ddlPOId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.POId = "";

                        }



                        if (ddlStyleId.Text != " ")
                        {

                            objReportDTO.StyleId = ddlStyleId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.StyleId = "";

                        }




                        objReportDTO.FOBDate = dtpFOBDate.Text;
                        objReportDTO.IssueDate = dtpIssueDate.Text;
                        objReportDTO.AmendDate = dtpAmendmentDate.Text;

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptCostingSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rptCostingSheet(objReportDTO));


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



                if (rdoCostSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

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


                    if (ddlPOId.Text == " ")
                    {
                        string strMsg = "Please Select PO!!!";
                        ddlPOId.Focus();
                        MessageBox(strMsg);
                        return;

                    }

                    if (ddlStyleId.Text == " ")
                    {
                        string strMsg = "Please Select Style!!!";
                        ddlStyleId.Focus();
                        MessageBox(strMsg);
                        return;

                    }


                    else if (dtpFOBDate.Text == "")
                    {
                        string strMsg = "Please Enter FOB Date!!!";
                        dtpIssueDate.Focus();
                        MessageBox(strMsg);
                        return;

                    }

                    if (ddlBuyerId.Text == "")
                    {
                        string strMsg = "Please Select Buyer!!!";
                        ddlBuyerId.Focus();
                        MessageBox(strMsg);
                        return;

                    }

                    if (ddlSeasonId.Text == "")
                    {
                        string strMsg = "Please Select Season!!!";
                        ddlSeasonId.Focus();
                        MessageBox(strMsg);
                        return;

                    }




                    else
                    {

                        if (ddlBuyerId.Text != "")
                        {

                            objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.BuyerId = "";

                        }


                        if (ddlContractId.Text != "")
                        {

                            objReportDTO.ContractId = ddlContractId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.ContractId = "";

                        }


                        if (ddlPOId.Text != " ")
                        {

                            objReportDTO.POId = ddlPOId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.POId = "";

                        }


                        if (ddlStyleId.Text != "")
                        {

                            objReportDTO.StyleId = ddlStyleId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.StyleId = "";

                        }

                        if (ddlSeasonId.Text != "")
                        {

                            objReportDTO.SeasonId = ddlSeasonId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.SeasonId = "";

                        }



                        objReportDTO.FOBDate = dtpFOBDate.Text;

                     


                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptCostSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rptCostSheet(objReportDTO));


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


        #region "Function"

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
            ddlStyleId.DataSource = objLookUpBLL.getStyleIdContract(ddlContractId.SelectedValue.ToString(), ddlPOId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);

            ddlStyleId.DataTextField = "STYLE_NO";
            ddlStyleId.DataValueField = "STYLE_ID";

            ddlStyleId.DataBind();
            if (ddlStyleId.Items.Count > 0)
            {

                ddlStyleId.SelectedIndex = 0;
            }


        }

        public void getBuyerIdContract()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerId.DataSource = objLookUpBLL.getBuyerIdContract(ddlContractId.SelectedValue.ToString(), ddlPOId.SelectedValue.ToString(), ddlStyleId.SelectedValue.ToString(), dtpFOBDate.Text, strHeadOfficeId, strBranchOfficeId);

            ddlBuyerId.DataTextField = "BUYER_NAME";
            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {

                ddlBuyerId.SelectedIndex = 0;
            }


        }


        public void getSeasonIdContract()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSeasonId.DataSource = objLookUpBLL.getSeasonIdContract(ddlContractId.SelectedValue.ToString(), ddlPOId.SelectedValue.ToString(), ddlStyleId.SelectedValue.ToString(), dtpFOBDate.Text, strHeadOfficeId, strBranchOfficeId);

            ddlSeasonId.DataTextField = "season_name";
            ddlSeasonId.DataValueField = "SEASON_ID";

            ddlSeasonId.DataBind();
            if (ddlSeasonId.Items.Count > 0)
            {

                ddlSeasonId.SelectedIndex = 0;
            }


        }




        public void searcFOBDate(string strBuyerId, string strContractNo, string strPOId, string strStyleId, string strHeadOfficeId, string strBranchOfficeId)
        {
            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();

            string strAmendId = "";


            objFOBDTO = objFOBBLL.searcFOBDate(strBuyerId, strContractNo, strPOId, strStyleId, strHeadOfficeId, strBranchOfficeId);





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
        public void searcIssueDate(string strBuyerId, string strContractNo, string strHeadOfficeId, string strBranchOfficeId)
        {
            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();

            string strAmendId = "";


            objFOBDTO = objFOBBLL.searcIssueDate(strBuyerId, strContractNo, strHeadOfficeId, strBranchOfficeId);


            if (objFOBDTO.IssueDate == "0")
            {

                //nothing to do
            }
            else
            {
                dtpIssueDate.Text = objFOBDTO.IssueDate;
            }



        }

        public void searcAmendmentDate(string strContractId, string strAmendmentId, string strHeadOfficeId, string strBranchOfficeId)
        {
            FOBDTO objFOBDTO = new FOBDTO();
            FOBBLL objFOBBLL = new FOBBLL();

            string strAmendId = "";


            objFOBDTO = objFOBBLL.searcAmendmentDate(strContractId, strAmendmentId, strHeadOfficeId, strBranchOfficeId);


            if (objFOBDTO.AmendmentDate == "0")
            {

                //nothing to do
            }
            else
            {
                dtpAmendmentDate.Text = objFOBDTO.AmendmentDate;
            }



        }


        public void processsDailyContractInfo()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            if(ddlContractId.Text !="0")
            {
                objReportDTO.ContractId = ddlContractId.SelectedValue.ToString(); ;

            }
            else
            {
                objReportDTO.ContractId ="";
            }

            if (ddlBuyerId.Text != "0")
            {
                objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString(); ;

            }
            else
            {
                objReportDTO.BuyerId = "";
            }

            if (ddlAmendmentId.Text != "0")
            {
                objReportDTO.AmendmentId = ddlAmendmentId.SelectedValue.ToString(); ;

            }
            else
            {
                objReportDTO.AmendmentId = "";
            }



            objReportDTO.IssueDate = dtpIssueDate.Text;
            objReportDTO.AmendDate = dtpAmendmentDate.Text;


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;


            string strMsg = objReportBLL.processsDailyContractInfo(objReportDTO);

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

        protected void rdoAttendenceSheet_CheckedChanged(object sender, EventArgs e)
        {

        }

      

      

      

        protected void btnSearch_Click(object sender, EventArgs e)
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

        protected void btnSearchAll_Click(object sender, EventArgs e)
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

                searcFOBDate( ddlBuyerId.SelectedValue.ToString(),ddlContractId.SelectedValue.ToString(),  ddlPOId.SelectedValue.ToString(), ddlStyleId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);
                getSeasonIdContract();
            }
        }

        protected void ddlBuyerId_SelectedIndexChanged(object sender, EventArgs e)
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


        #region "Function"

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

        #endregion

        protected void ddlContractId_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void btnSearchPOId_Click(object sender, EventArgs e)
        {
            if (ddlBuyerId.Text == "")
            {
                string strMsg = "Please Select Buyer Name!!!";
                ddlBuyerId.Focus();
                MessageBox(strMsg);
                return;

            }

            else if (ddlContractId.Text == " ")
            {
                string strMsg = "Please Select Contract NO!!!";
                ddlContractId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {
                getAmendmentId();
                searcAmendmentDate(ddlContractId.SelectedValue.ToString(), ddlAmendmentId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);
                searcIssueDate(ddlBuyerId.SelectedValue.ToString(), ddlContractId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);
                getPOIdContract();

            }



        }

        public void getAmendmentId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlAmendmentId.DataSource = objLookUpBLL.getAmendmentId(ddlContractId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);

            ddlAmendmentId.DataTextField = "AMENDMENT_NAME";
            ddlAmendmentId.DataValueField = "AMENDMENT_ID";

            ddlAmendmentId.DataBind();
            if (ddlAmendmentId.Items.Count > 0)
            {

                ddlAmendmentId.SelectedIndex = 0;
            }


        }

        protected void btnSearchContractId_Click(object sender, EventArgs e)
        {
            if (ddlBuyerId.Text == " ")
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
    }
}