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
    public partial class ReportOthersPower : System.Web.UI.Page
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
                getUnitId();

                getSectionId();
                //getRequisitionId();

                getOfficeName();


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

        public void getSectionId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSectionId.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

            ddlSectionId.DataTextField = "SECTION_NAME";
            ddlSectionId.DataValueField = "SECTION_ID";

            ddlSectionId.DataBind();
            if (ddlSectionId.Items.Count > 0)
            {

                ddlSectionId.SelectedIndex = 0;
            }



        }

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


        public void getUnitId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlUnitId.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlUnitId.DataTextField = "UNIT_NAME";
            ddlUnitId.DataValueField = "UNIT_ID";

            ddlUnitId.DataBind();
            if (ddlUnitId.Items.Count > 0)
            {

                ddlUnitId.SelectedIndex = 0;
            }

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

                if (rdoEmployeeBasicInformation.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    objReportDTO.EmployeeId = txtEmployeeId.Text;

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


                    objReportDTO.EmployeeTypeId = "";




                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeBasicCV.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.employeeBasicInformaitonCV(objReportDTO));
                    rd.SetDataSource(ds);
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




                if (rdoMonthlyAttendenceSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                      if (dtpFromDate.Text == "" )
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


                          processMonthlyAttendenceSheet();


                          objReportDTO.HeadOfficeId = strHeadOfficeId;
                          objReportDTO.BranchOfficeId = strBranchOfficeId;
                          objReportDTO.EmployeeId = txtEmployeeId.Text;
                          objReportDTO.UpdateBy = strEmployeeId;


                          objReportDTO.FromDate = dtpFromDate.Text;
                          objReportDTO.ToDate = dtpToDate.Text;
                          objReportDTO.CardNo = txtCardNo.Text;



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



                          string strPath = Path.Combine(Server.MapPath("~/Reports/rpDailyAttendenceSheetMonthlySP.rpt"));
                          this.Context.Session["strReportPath"] = strPath;
                          rd.Load(strPath);
                          rd.SetDataSource(objReportBLL.rptMonthlyAttendenceSheetSP(objReportDTO));


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


                if (rdoMonthlyAttendenceSheetAll.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    
                     if (dtpFromDate.Text == "" )
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

                         processMonthlyAttendenceSheetAll();


                         objReportDTO.HeadOfficeId = strHeadOfficeId;
                         objReportDTO.BranchOfficeId = strBranchOfficeId;
                         objReportDTO.EmployeeId = txtEmployeeId.Text;
                         objReportDTO.UpdateBy = strEmployeeId;


                         objReportDTO.FromDate = dtpFromDate.Text;
                         objReportDTO.ToDate = dtpToDate.Text;
                         objReportDTO.CardNo = txtCardNo.Text;



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



                         string strPath = Path.Combine(Server.MapPath("~/Reports/rpMonthlyAttendenceSheetSP.rpt"));
                         this.Context.Session["strReportPath"] = strPath;
                         rd.Load(strPath);
                         rd.SetDataSource(objReportBLL.rptMonthlyAttendenceSheetSPAll(objReportDTO));


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


                if (rdoEmployeeLateSheet.Checked == true)
                {


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


                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();


                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;


                        objReportDTO.FromDate = dtpFromDate.Text;
                        objReportDTO.ToDate = dtpToDate.Text;




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



                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptAttendenceLateSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.dailyAttendenceLateSheet(objReportDTO));



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


                if (rdoMonthlyAttendenceSheetSummery.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    processMonthlyAttendenceSummerySheet();


                    


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmployeeId.Text;
                    objReportDTO.UpdateBy = strEmployeeId;


                    objReportDTO.FromDate = dtpFromDate.Text;
                    objReportDTO.ToDate = dtpToDate.Text;
                    objReportDTO.CardNo = txtCardNo.Text;



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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rpDailyAttendenceSummerySheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.rptMonthlyAttendenceSummerySheet(objReportDTO));


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



                if (rdoAttendenceSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                  


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmployeeId.Text;
                    objReportDTO.UpdateBy = strEmployeeId;


                    objReportDTO.FromDate = dtpFromDate.Text;
                    objReportDTO.ToDate = dtpToDate.Text;
                    objReportDTO.CardNo = txtCardNo.Text;



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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAttendenceSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.dailyAttendenceSheet(objReportDTO));


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


        #region "Function"

        public void processMonthlyAttendenceSummerySheetPower()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;


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





            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processMonthlyAttendenceSummerySheetPower(objReportDTO);
            //MessageBox(strMsg);




        }


        public void processMonthlyAttendenceSummerySheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;


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





            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processMonthlyAttendenceSummerySheet(objReportDTO);
            //MessageBox(strMsg);




        }
        public void processMonthlyAttendenceSheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;
            objReportDTO.EmployeeId = txtEmployeeId.Text;


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





            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processMonthlyAttendenceSheet(objReportDTO);
           




        }

        public void processMonthlyWorkingDayList()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;



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



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            string strMsg = objReportBLL.processMonthlyWorkingDayList(objReportDTO);






        }

        public void processDailyAttendenceSheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();





            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;


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


            objReportDTO.UpdateBy = strEmployeeId;
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objReportBLL.processDailyAttendenceSheet(objReportDTO);




        }

        public void processMonthlyAttendenceSheetAll()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;
            objReportDTO.EmployeeId = txtEmployeeId.Text;


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





            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processMonthlyAttendenceSheetAll(objReportDTO);
            //MessageBox(strMsg);




        }

        public void processAttendenceTopSheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();



            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;


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


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processAttendenceTopSheet(objReportDTO);




        }
        public void processDailyAbsenceSheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();





            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;


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


            objReportDTO.UpdateBy = strEmployeeId;
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objReportBLL.processDailyAbsenceSheet(objReportDTO);




        }


        public void lateSheetSummery()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();





            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;


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


            objReportDTO.UpdateBy = strEmployeeId;
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objReportBLL.lateSheetSummery(objReportDTO);




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


    }
}