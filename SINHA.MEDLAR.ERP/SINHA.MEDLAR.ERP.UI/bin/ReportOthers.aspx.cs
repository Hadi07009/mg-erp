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
using System.Drawing;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ReportOthers : System.Web.UI.Page
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
                getEmployeeTypeId();
                getSectionId();
                getOccurenceTypeId();
                //getRequisitionId();

                getOfficeName();


            }
            if (IsPostBack)
            {
                loadSession();

            }
        }


        #region "Load ComboBox"

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


        public void getEmployeeTypeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEmployeeTypeId.DataSource = objLookUpBLL.getEmployeeTypeId();

            ddlEmployeeTypeId.DataTextField = "EMPLOYEE_TYPE_NAME";
            ddlEmployeeTypeId.DataValueField = "EMPLOYEE_TYPE_ID";

            ddlEmployeeTypeId.DataBind();
            if (ddlEmployeeTypeId.Items.Count > 0)
            {

                ddlEmployeeTypeId.SelectedIndex = 0;
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
        public void getOccurenceTypeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlOccurenceTypeId.DataSource = objLookUpBLL.getOccurenceTypeId();

            ddlOccurenceTypeId.DataTextField = "OCCURENCE_TYPE_NAME";
            ddlOccurenceTypeId.DataValueField = "OCCURENCE_TYPE_ID";

            ddlOccurenceTypeId.DataBind();
            if (ddlOccurenceTypeId.Items.Count > 0)
            {

                ddlOccurenceTypeId.SelectedIndex = 0;
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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
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


                    if (ddlEmployeeTypeId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.EmployeeTypeId = "";

                    }



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeBasicInfo.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.employeeBasicInformaiton(objReportDTO));
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

                if (rdoNewEmployeeList.Checked == true)
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
                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

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

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptNewEmployeeList.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataTable dt = new DataTable();

                    dt = (objReportBLL.NewEmployeeListJoiningBasis(objReportDTO));
                    rd.SetDataSource(dt);
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
                if (rdoNewRecruitmentEmpListBP.Checked == true)
                {


                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeTypeId = "";
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
                    if (ddlOccurenceTypeId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.OccurrenceType = ddlOccurenceTypeId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.OccurrenceType = "";
                    }
                    if (ddlApproveId.SelectedValue.ToString() != "")
                    {
                        objReportDTO.ApproveYn = ddlApproveId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.ApproveYn = "";
                    }
                    objReportDTO.Year = txtYear.Text.Trim();
                    objReportDTO.Month = txtMonth.Text.Trim();
                    objReportDTO.UpdateBy = strEmployeeId;

                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptNewRecruitmentEmpList.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetNewRecruitmentListBP(objReportDTO));


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
                if (rdoInactiveEmployeeSheetMonthly.Checked == true)
                {
                    try {

                        EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                        EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                        DataTable dt = new DataTable();

                        objEmployeeDTO.CardNo = txtCardNo.Text;
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
                        objEmployeeDTO.Year = txtYear.Text;
                        objEmployeeDTO.Month = txtMonth.Text;
                        objEmployeeDTO.StatusId = null;


                        objEmployeeDTO.CreateBy = strEmployeeId;
                        objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                        objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                        string message;
                        if (objEmployeeDTO.CardNo != "")
                        {
                            message = objEmployeeBLL.chkEmployeeActivation(objEmployeeDTO);
                            if (message != "OK")
                            {
                                MessageBox(message);
                                return;
                            }
                        }
                        string strPath = Path.Combine(Server.MapPath("~/Reports/RptResignEmployeeSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objEmployeeBLL.GetMonthlyInactiveSheet(objEmployeeDTO));

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
                    catch(Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                    }
        }


                if (rdoInactiveEmployeeList.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmployeeId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;
                    objReportDTO.UpdateBy = strEmployeeId;

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text; ;


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
                    
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeInactiveList.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.inactiveEmployeeList(objReportDTO));
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


                if (rptDailyAttendenceSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    //processDailyAttendenceSheet();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmployeeId.Text;
                    objReportDTO.UpdateBy = strEmployeeId;

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


                if (rptDailyAttendenceSheetInOut.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                 

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmployeeId.Text;
                    objReportDTO.UpdateBy = strEmployeeId;

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAttendenceSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.dailyAttendenceSheetInOut(objReportDTO));


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

                if (rdoDailyAttendenceTopSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processAttendenceTopSheet();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmployeeId.Text;
                    objReportDTO.UpdateBy = strEmployeeId;

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAttendenceTopSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.dailyAttendenceTopSheet(objReportDTO));


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


                if (rptDailyAttendenceLateSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    //processDailyAttendenceSheet();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAttendenceLateSheet.rpt"));
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


                if (rptDailyAttendenceAbsenceSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    processDailyAbsenceSheet();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmployeeId.Text;
                    objReportDTO.UpdateBy = strEmployeeId;
                    objReportDTO.CardNo = txtCardNo.Text;
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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAbsenceSheet.rpt.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.dailyAbsenceSheet(objReportDTO));


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


                if (rptMonthlyAttendenceAbsenceSheet.Checked == true)
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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyOverTimeSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.rptWorkerOverTimeSheet(objReportDTO));


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
                if (rdoOverTimeAnalysis.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmployeeId.Text;
                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;
                    objReportDTO.UpdateBy = strEmployeeId;

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

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyOverTimeSummary.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetOverTimeAnalyzeSheet(objReportDTO));

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


                if (rdoLateSheetSummery.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    lateSheetSummery();

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptLateSheetSummery.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.rptlateSheetSummery(objReportDTO));


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

                if (rdoLateSheet.Checked == true)
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
                    objReportDTO.LateMinute = txtLateMinute.Text;
                    if (ddlEmployeeTypeId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.EmployeeTypeId = "";
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptLateLoginSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetLoginLateSheet(objReportDTO));


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


                    if(txtEmployeeId.Text == string.Empty)
                    {
                        MessageBox("Please enter Employee Id.");
                        return;
                    }

                    //old: commented on 15.07.2021
                    //processMonthlyAttendenceSheetWorker();
                    
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

                    //COMMENTED: 17.07.2021
                    //objReportBLL.PrepareJobCard(objReportDTO);

                    //new
                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptJobCard.rpt"));
                    //old
                    //string strPath = Path.Combine(Server.MapPath("~/Reports/rpDailyAttendenceSheetMonthlyWorker.rpt"));

                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);

                    //new: added on 15.07.2021
                    rd.SetDataSource(objReportBLL.GetJobCard(objReportDTO));
                    //old: commented on 15.07.2021
                    //rd.SetDataSource(objReportBLL.rptMonthlyAttendenceSheetWorker(objReportDTO));


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
                if (rdoOverTimeAnalysisbyBetDateRange.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();



                    objReportDTO.FromDate = dtpFromDate.Text;
                    objReportDTO.ToDate = dtpToDate.Text;
                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;


                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptOverTimeSummaryVF.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetOverTimeAnalyzeBetDateRange(objReportDTO));

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
                if (rdoWHBetDateRange.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();



                    objReportDTO.FromDate = dtpFromDate.Text;
                    objReportDTO.ToDate = dtpToDate.Text;
                    objReportDTO.WHRangeId = ddlWHRangeId.SelectedValue.ToString();
                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;


                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptGetEmpListByWorkingHourRange.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetEmpListBetWHRange(objReportDTO));

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
                if (rdoEmployeeStatus.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    string strMsg = "";
                    if (ddlEmployeeTypeId.Text == "")
                    {
                        strMsg = "Please Select Employee Type";
                        ddlEmployeeTypeId.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    if (txtMonth.Text == "")
                    {
                        strMsg = "Please Enter Month";
                        ddlEmployeeTypeId.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    if (txtYear.Text == "")
                    {
                        strMsg = "Please Enter Year";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    else
                    {
                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;

                        objReportDTO.Year = txtYear.Text.Trim();
                        objReportDTO.Month = txtMonth.Text.Trim();
                        objReportDTO.UpdateBy = strEmployeeId;
                        objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedItem.Value.Trim();

                        string strPath = Path.Combine(Server.MapPath("~/Reports/RptTempSheetSummary.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetTempSheet(objReportDTO));


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
                if (rdoGetEmpWhoWdayLessThanXDays.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    string strMsg = "";

                    if (txtWDay.Text == "")
                    {
                        strMsg = "Please Enter Working Day";
                        txtWDay.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    if (txtYear.Text == "")
                    {
                        strMsg = "Please Enter Salary Year";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    if (txtMonth.Text == "")
                    {
                        strMsg = "Please Enter Salary Month";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;
                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;
                    objReportDTO.WorkingDay = txtWDay.Text;
                    objReportDTO.EmployeeId = txtEmployeeId.Text;

                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmpWhoseWDayLessThanXDays.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetEmpWhoseWDayLessThanXDays(objReportDTO));

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
                if (rdoDailyAttendenceOpeningSheet.Checked == true)
                {

                    string strMsg = "";
                    if (dtpFromDate.Text == "")
                    {

                        strMsg = "Please Enter From Date!!!";
                        dtpFromDate.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    else if (dtpToDate.Text == "")
                    {

                        strMsg = "Please Enter From Date!!!";
                        dtpToDate.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    else
                    {

                        processAttendenceOpeningSheet();

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



                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptAttendenceOpeningSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.DailyAttendenceOpeningSheet(objReportDTO));


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


                if (rdoDailyAttendenceClosingSheet.Checked == true)
                {

                    string strMsg = "";
                    if (dtpFromDate.Text == "")
                    {

                        strMsg = "Please Enter From Date!!!";
                        dtpFromDate.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    else if (dtpToDate.Text == "")
                    {

                        strMsg = "Please Enter From Date!!!";
                        dtpToDate.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    else
                    {

                        processAttendenceClosingSheet();

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



                        //new
                        string strPath = Path.Combine(Server.MapPath("~/Reports/RptDayClosingSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetDayClosingSheet(objReportDTO));

                        //old
                        //string strPath = Path.Combine(Server.MapPath("~/Reports/rpMonthlyAttendenceClosingSheet.rpt"));
                        //this.Context.Session["strReportPath"] = strPath;
                        //rd.Load(strPath);
                        //rd.SetDataSource(objReportBLL.DailyAttendenceClosingSheet(objReportDTO));

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
                if (rdoDisposableSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    string strMsg = "";

                    if (txtMonth.Text == "")
                    {
                        strMsg = "Please Enter Month";
                        ddlEmployeeTypeId.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    if (txtYear.Text == "")
                    {
                        strMsg = "Please Enter Year";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    else
                    {
                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;

                        objReportDTO.Year = txtYear.Text.Trim();
                        objReportDTO.Month = txtMonth.Text.Trim();
                        objReportDTO.UpdateBy = strEmployeeId;
                        objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedItem.Value.Trim();

                        string strPath = Path.Combine(Server.MapPath("~/Reports/RptDisposalSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetDisposableSheet(objReportDTO));


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

                #region Gender Status
                if (rdoGenderStatusBasedOnSalary.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    if (txtYear.Text == "")
                    {
                        string strMsg = "Please Enter Year!!!";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    else if (txtMonth.Text == "")
                    {
                        string strMsg = "Please Enter MOnth!!!";
                        txtMonth.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    else
                    {
                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;


                        objReportDTO.Year = txtYear.Text;
                        objReportDTO.Month = txtMonth.Text;
                        if (ddlEmployeeTypeId.SelectedValue.ToString() != "")
                        {
                            objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.EmployeeTypeId = "";
                        }
                        string strPath = Path.Combine(Server.MapPath("~/Reports/RptCountGerderBasedOnSalary.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetGenderBasedOnSalary(objReportDTO));

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
                #endregion

                if (rdoDisposableSheetStaff.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    string strMsg = "";

                    if (txtMonth.Text == "")
                    {
                        strMsg = "Please Enter Month";
                        ddlEmployeeTypeId.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    if (txtYear.Text == "")
                    {
                        strMsg = "Please Enter Year";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    else
                    {
                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;

                        objReportDTO.Year = txtYear.Text.Trim();
                        objReportDTO.Month = txtMonth.Text.Trim();
                        objReportDTO.UpdateBy = strEmployeeId;
                        objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedItem.Value.Trim();
                                            
                        string strPath = Path.Combine(Server.MapPath("~/Reports/RptDisposalSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetDisposableSheetStaff(objReportDTO));


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

                if (rdoMonthlyWorkingDayList.Checked == true)
                {
                    processMonthlyWorkingDayList();

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();
                    
                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmployeeId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;
                    objReportDTO.UpdateBy = strEmployeeId;

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
                                        
                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;
                    
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyWorkingDayList.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlyWorkingDayList(objReportDTO));
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
                if (rdoInactiveEmpProposalSheet.Checked == true)
                {
                    try
                    {
                        EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                        EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                        DataTable dt = new DataTable();

                        objEmployeeDTO.CardNo = txtCardNo.Text;
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
                        objEmployeeDTO.Year = txtYear.Text;
                        objEmployeeDTO.Month = txtMonth.Text;

                        objEmployeeDTO.CreateBy = strEmployeeId;
                        objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                        objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                        string message;
                        if (objEmployeeDTO.CardNo != "")
                        {
                            message = objEmployeeBLL.chkEmployeeActivation(objEmployeeDTO);
                            if (message != "OK")
                            {
                                MessageBox(message);
                                return;
                            }
                        }

                        string strPath = Path.Combine(Server.MapPath("~/Reports/RptResignEmployeeSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objEmployeeBLL.GetEmployeeForInActive(objEmployeeDTO));

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

                #region Attendance Register
                //sp_create_attendance_register
                //Next
                if (rdoAttendanceRegisterNext.Checked == true)
                {
                    //processMonthlyWorkingDayList();
                    //VW_DM_ATTENDANCE_REGISTER

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmployeeId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;
                    objReportDTO.UpdateBy = strEmployeeId;

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

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptAttendanceRegisterNext.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetAttendanceRegisterNext(objReportDTO));
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


                if (rdoAttendanceRegister.Checked == true)
                {
                    //processMonthlyWorkingDayList();
                    //VW_DM_ATTENDANCE_REGISTER

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmployeeId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;
                    objReportDTO.UpdateBy = strEmployeeId;

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

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

                    //old
                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptAttendanceRegister_10R.rpt"));
                    //new
                    //string strPath = Path.Combine(Server.MapPath("~/Reports/RptAttendanceRegister.rpt"));

                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetAttendanceRegister(objReportDTO));
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
                #endregion

                #region WH Summary 

                if (rdoWorkingHourSummary.Checked == true)
                {
                    //processMonthlyWorkingDayList();

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmployeeId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;
                    objReportDTO.UpdateBy = strEmployeeId;

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

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

                    objReportDTO.FromDate = dtpFromDate.Text;
                    objReportDTO.ToDate = dtpFromDate.Text;

                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptIndividualWorkingHourSummary.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetWorkingHourSummary(objReportDTO));
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
                #endregion

                #region OT Summary

                if (rdoOTSummary.Checked == true)
                {
                    //processMonthlyWorkingDayList();

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmployeeId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;
                    objReportDTO.UpdateBy = strEmployeeId;

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

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

                    objReportDTO.FromDate = dtpFromDate.Text;
                    objReportDTO.ToDate = dtpFromDate.Text;

                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptIndividualOTSummary.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetOTSummary(objReportDTO));
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
                #endregion



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

        public void processMonthlyWorkingDayList()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;


            objReportDTO.Year = txtYear.Text;
            objReportDTO.Month = txtMonth.Text;


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

        public void processMonthlyAttendenceSheetWorker()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;
            objReportDTO.EmployeeId = txtEmployeeId.Text;
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





            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processMonthlyAttendenceSheetWorker(objReportDTO);




        }

        public void processAttendenceOpeningSheet()
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

            string strMsg = objReportBLL.processAttendenceOpeningSheet(objReportDTO);




        }
        public void processAttendenceClosingSheet()
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

            string strMsg = objReportBLL.processAttendenceClosingSheet(objReportDTO);




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

        protected void rdoEmployeeBasicInformation_CheckedChanged(object sender, EventArgs e)
        {
            ddlUnitId.BackColor = Color.YellowGreen;
            ddlSectionId.BackColor = Color.YellowGreen;
            txtCardNo.BackColor = Color.Empty;
            ddlEmployeeTypeId.BackColor = Color.Empty;
            txtEmployeeId.BackColor = Color.Empty;
            dtpFromDate.BackColor = Color.Empty;
            dtpToDate.BackColor = Color.Empty;
            txtYear.BackColor = Color.Empty;
            txtMonth.BackColor = Color.Empty;   
        }

        protected void rdoInactiveEmployeeList_CheckedChanged(object sender, EventArgs e)
        {
            ddlUnitId.BackColor = Color.YellowGreen;
            ddlSectionId.BackColor = Color.YellowGreen;
            txtCardNo.BackColor = Color.Empty;
            ddlEmployeeTypeId.BackColor = Color.Empty;
            txtEmployeeId.BackColor = Color.Empty;
            dtpFromDate.BackColor = Color.Empty;
            dtpToDate.BackColor = Color.Empty;
            txtYear.BackColor = Color.Empty;
            txtMonth.BackColor = Color.Empty;
        }

        protected void rptDailyAttendenceSheet_CheckedChanged(object sender, EventArgs e)
        {
            ddlUnitId.BackColor = Color.Empty;
            ddlSectionId.BackColor = Color.Empty;
            txtCardNo.BackColor = Color.Empty;
            ddlEmployeeTypeId.BackColor = Color.Empty;
            txtEmployeeId.BackColor = Color.Empty;
            dtpFromDate.BackColor = Color.YellowGreen;
            dtpToDate.BackColor = Color.YellowGreen;
            txtYear.BackColor = Color.Empty;
            txtMonth.BackColor = Color.Empty;
        }

        protected void rptDailyAttendenceLateSheet_CheckedChanged(object sender, EventArgs e)
        {
            ddlUnitId.BackColor = Color.Empty;
            ddlSectionId.BackColor = Color.Empty;
            txtCardNo.BackColor = Color.Empty;
            ddlEmployeeTypeId.BackColor = Color.Empty;
            txtEmployeeId.BackColor = Color.Empty;
            dtpFromDate.BackColor = Color.YellowGreen;
            dtpToDate.BackColor = Color.YellowGreen;
            txtYear.BackColor = Color.Empty;
            txtMonth.BackColor = Color.Empty;
        }

        protected void rdoLateSheetSummery_CheckedChanged(object sender, EventArgs e)
        {
            ddlUnitId.BackColor = Color.YellowGreen;
            ddlSectionId.BackColor = Color.YellowGreen;
            txtCardNo.BackColor = Color.YellowGreen;
            ddlEmployeeTypeId.BackColor = Color.Empty;
            txtEmployeeId.BackColor = Color.Empty;
            dtpFromDate.BackColor = Color.YellowGreen;
            dtpToDate.BackColor = Color.YellowGreen;
            txtYear.BackColor = Color.Empty;
            txtMonth.BackColor = Color.Empty;
        }

        protected void rptDailyAttendenceAbsenceSheet_CheckedChanged(object sender, EventArgs e)
        {
            ddlUnitId.BackColor = Color.Empty;
            ddlSectionId.BackColor = Color.Empty;
            txtCardNo.BackColor = Color.Empty;
            ddlEmployeeTypeId.BackColor = Color.Empty;
            txtEmployeeId.BackColor = Color.Empty;
            dtpFromDate.BackColor = Color.YellowGreen;
            dtpToDate.BackColor = Color.YellowGreen;
            txtYear.BackColor = Color.Empty;
            txtMonth.BackColor = Color.Empty;
        }

        protected void rptMonthlyAttendenceAbsenceSheet_CheckedChanged(object sender, EventArgs e)
        {
            ddlUnitId.BackColor = Color.YellowGreen;
            ddlSectionId.BackColor = Color.YellowGreen;
            txtCardNo.BackColor = Color.YellowGreen;
            ddlEmployeeTypeId.BackColor = Color.Empty;
            txtEmployeeId.BackColor = Color.YellowGreen;
            dtpFromDate.BackColor = Color.YellowGreen;
            dtpToDate.BackColor = Color.YellowGreen;
            txtYear.BackColor = Color.Empty;
            txtMonth.BackColor = Color.Empty;
        }

        protected void rdoMonthlyAttendenceSheet_CheckedChanged(object sender, EventArgs e)
        {
            ddlUnitId.BackColor = Color.YellowGreen;
            ddlSectionId.BackColor = Color.YellowGreen;
            txtCardNo.BackColor = Color.YellowGreen;
            ddlEmployeeTypeId.BackColor = Color.Empty;
            txtEmployeeId.BackColor = Color.Empty;
            dtpFromDate.BackColor = Color.YellowGreen;
            dtpToDate.BackColor = Color.YellowGreen;
            txtYear.BackColor = Color.Empty;
            txtMonth.BackColor = Color.Empty;  
        }

        protected void rdoDailyAttendenceTopSheet_CheckedChanged(object sender, EventArgs e)
        {
            ddlUnitId.BackColor = Color.YellowGreen;
            ddlSectionId.BackColor = Color.YellowGreen;
            txtCardNo.BackColor = Color.YellowGreen;
            ddlEmployeeTypeId.BackColor = Color.Empty;
            txtEmployeeId.BackColor = Color.Empty;
            dtpFromDate.BackColor = Color.YellowGreen;
            dtpToDate.BackColor = Color.YellowGreen;
            txtYear.BackColor = Color.Empty;
            txtMonth.BackColor = Color.Empty;
        }

        protected void rdoMonthlyWorkingDayList_CheckedChanged(object sender, EventArgs e)
        {
            ddlUnitId.BackColor = Color.Empty;
            ddlSectionId.BackColor = Color.Empty;
            txtCardNo.BackColor = Color.Empty;
            ddlEmployeeTypeId.BackColor = Color.Empty;
            txtEmployeeId.BackColor = Color.Empty;
            dtpFromDate.BackColor = Color.Empty;
            dtpToDate.BackColor = Color.Empty;
            txtYear.BackColor = Color.YellowGreen;
            txtMonth.BackColor = Color.YellowGreen;
            
        }


    }
}