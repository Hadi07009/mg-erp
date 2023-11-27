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
using SINHA.MEDLAR.ERP.BLL.Utility;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ReportHeadOfficePower : System.Web.UI.Page
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
                getFromMonthId();
                getToMonthId();
                getSectionId();
                getDepartmentId();
                getOfficeName();
            }
            if (IsPostBack)
            {
                loadSession();
            }
        }
               
        private void Page_PreInit(object sender, EventArgs e)
        {
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

        public void getDepartmentId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlDepartmentId.DataSource = objLookUpBLL.getDepartmentId(strHeadOfficeId, strBranchOfficeId);

            ddlDepartmentId.DataTextField = "DEPARTMENT_NAME";
            ddlDepartmentId.DataValueField = "DEPARTMENT_ID";

            ddlDepartmentId.DataBind();
            if (ddlDepartmentId.Items.Count > 0)
            {

                ddlDepartmentId.SelectedIndex = 0;
            }



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
        public void getFromMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlFromMonthId.DataSource = objLookUpBLL.getFromMonthId();

            ddlFromMonthId.DataTextField = "MONTH_NAME";
            ddlFromMonthId.DataValueField = "MONTH_ID";

            ddlFromMonthId.DataBind();
            if (ddlFromMonthId.Items.Count > 0)
            {
                ddlFromMonthId.SelectedIndex = 0;
            }
        }


        public void getToMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlToMonthId.DataSource = objLookUpBLL.getFromMonthId();

            ddlToMonthId.DataTextField = "MONTH_NAME";
            ddlToMonthId.DataValueField = "MONTH_ID";

            ddlToMonthId.DataBind();
            if (ddlToMonthId.Items.Count > 0)
            {

                ddlToMonthId.SelectedIndex = 0;
            }
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
                //formatType = ExportFormatType.ExcelRecord;
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


                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "report_head_office_power");
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
                rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, "report_head_office_power");
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

        protected void btnView_Click(object sender, EventArgs e)
        {

            try
            {


                #region "Report Viewing Fuctionality"
                if (rdoEmployeeBasicInformation.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    objReportDTO.EmployeeId = txtEmpId.Text;

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

                if (rdoSalaryCertificate.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

                    objReportDTO.EmployeeId = txtEmpId.Text;

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryCertificate.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.salaryCertificate(objReportDTO));
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


                if (rdoInactiveEmployeeList.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.UpdateBy = strEmployeeId;
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


                if (rdoEmployeeDetailInformation.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;

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





                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeCV.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.employeeDetailInformaiton(objReportDTO));


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


                if (rdoEmployeeDetailList.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.UpdateBy = strEmployeeId;


                    if (ddlSectionId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.SectionId = "";
                    }

                    if (ddlDepartmentId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.DepartmentId = ddlDepartmentId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.DepartmentId = "";
                    }




                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitId = "";

                    }





                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeInformation.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.employeeDetailList(objReportDTO));


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


                if (rdoEmployeeDetailListAll.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.UpdateBy = strEmployeeId;


                    if (ddlSectionId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.SectionId = "";
                    }

                    if (ddlDepartmentId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.DepartmentId = ddlDepartmentId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.DepartmentId = "";
                    }




                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitId = "";

                    }





                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeInformation.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.EmployeeDetailListAll(objReportDTO));


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



                //if (chkEmployeeSalarySlip.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;


                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }



                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }



                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;


                //    string strPath = Path.Combine(Server.MapPath("~/Reports/EmployeeSalarySlip.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.employeeSalarySlip(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();

                //    //rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "ERP");

                //    MemoryStream oStream;
                //    Response.Clear();
                //    Response.Buffer = false;
                //    Response.ClearContent();
                //    Response.ClearHeaders();

                //    oStream = (MemoryStream)rd.ExportToStream(ExportFormatType.PortableDocFormat);
                //    Response.ContentType = "application/Pdf";
                //    oStream.Seek(0, SeekOrigin.Begin);
                //    Response.BinaryWrite(oStream.ToArray());
                //    Response.End();
                //    oStream.Flush();
                //    oStream.Close();
                //    oStream.Dispose();
                //    CrystalReportViewer1.RefreshReport();

                //    //string strUrl = "Report.aspx";
                //    //ClientScript.RegisterStartupScript(this.Page.GetType(), "popupOpener", "var popup=window.open('" + strUrl + "');popup.focus();", true);




                //}



                //if (chkEmployeeSalarySheet.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;



                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }



                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }



                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;



                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheet.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.employeeSalarySheet(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();

                //    //rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "ERP");

                //    MemoryStream oStream;
                //    Response.Clear();
                //    Response.Buffer = false;
                //    Response.ClearContent();
                //    Response.ClearHeaders();

                //    oStream = (MemoryStream)rd.ExportToStream(ExportFormatType.PortableDocFormat);
                //    Response.ContentType = "application/Pdf";
                //    oStream.Seek(0, SeekOrigin.Begin);
                //    Response.BinaryWrite(oStream.ToArray());
                //    Response.End();
                //    oStream.Flush();
                //    oStream.Close();
                //    oStream.Dispose();
                //    CrystalReportViewer1.RefreshReport();

                //    //string strUrl = "CrystalView.aspx";
                //    //ClientScript.RegisterStartupScript(this.Page.GetType(), "popupOpener", "var popup=window.open('" + strUrl + "');popup.focus();", true);





                //}

                //if (rdoMonthlySalarySheetStaff.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;


                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }


                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }



                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;



                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaff.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.SalarySheetStaff(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();

                //    ReportFormatMaster();





                //}


                //if (rdoMonthlySalarySheetWorker.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;


                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }



                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }


                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;



                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetWorker.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.salarySheetWorker(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();
                //    ReportFormatMaster();





                //}


                //if (rdoMonthlyPaySlipWorker.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;


                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }


                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }



                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;



                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipWorker.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.paySlipWorker(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();
                //    ReportFormatMaster();





                //}

                //if (rdoMonthlyPaySlipStaff.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;


                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }



                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }



                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;



                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipStaff.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.paySlipStaff(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();
                //    ReportFormatMaster();





                //}

                //if (rdoMonthlyHalfSheetStaff.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;


                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }



                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }


                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;



                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSheetStaffMisc.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.halfSheetStaff(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();

                //    ReportFormatMaster();





                //}

                if (rdoMonthlySalarySheetHO.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;




                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitId = "";

                    }


                    if (ddlSectionId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.SectionId = "";
                    }

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHO.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.salarySheetHO(objReportDTO));


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






                if (rdoMonthlySalarySheetHO.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;




                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitId = "";

                    }


                    if (ddlSectionId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.SectionId = "";
                    }

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHO.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.salarySheetHO(objReportDTO));


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
                if (rdoMonthlySalarySheetHOMISC.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;

                    objReportDTO.UpdateBy = strEmployeeId;

                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }

                    else
                    {
                        objReportDTO.UnitId = "";

                    }

                    if (ddlSectionId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.SectionId = "";
                    }

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHOMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.salarySheetHOMisc(objReportDTO));


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




                if (rdoMonthlySalarySheetHOPaySlip.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }

                    else
                    {
                        objReportDTO.UnitId = "";

                    }

                    if (ddlSectionId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.SectionId = "";
                    }


                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHOSlip.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.salarySlipHO(objReportDTO));
                    
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
                  
                if (rdoTaxSummerySheetFirstSalary.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();
                    
                    if (dtpFromDate.Text == "" || dtpToDate.Text == "")

                    {
                        string strMsg = "Please Enter From Date and To Date!!!";
                        MessageBox(strMsg);
                        return;
                    }
                    string result = Validation.IsValidFiscalYear(dtpFromDate.Text, dtpToDate.Text);
                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageBox(result);
                        return;
                    }        

                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;

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
                    
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptYearlyTaxStatementSummeryFB.rpt"));
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetTaxStatementDetail(objReportDTO));
                    
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

                if (rdoTaxSummerySheet.Checked == true)
                {
                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    if (dtpFromDate.Text == "" || dtpToDate.Text == "")

                    {
                        string strMsg = "Please Enter From Date and To Date!!!";
                        MessageBox(strMsg);
                        return;
                    }
                    string result = Validation.IsValidFiscalYear(dtpFromDate.Text, dtpToDate.Text);
                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageBox(result);
                        return;
                    }
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;

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

                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptTaxStatementSummary.rpt"));
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetTaxStatementSummary(objReportDTO));

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
                
                if (rdoMonthlySalarySheetHOMISC.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }

                    else
                    {
                        objReportDTO.UnitId = "";
                    }

                    if (ddlSectionId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.SectionId = "";
                    }

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHOMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.salarySheetHOMisc(objReportDTO));

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
                
                if (rdoMonthlySalarySheetHOMISCPaySlip.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;

                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitId = "";
                    }

                    if (ddlSectionId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.SectionId = "";
                    }
                    
                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;
                    
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHOSlipMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.salarySlipHOMisc(objReportDTO));
                    
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
                
                if (rdoEmployeeListHO.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.UpdateBy = strEmployeeId;

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
                    
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeList.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.employeeList(objReportDTO));
                    
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

                if (rdoEmployeeJobYearMonthHistory.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;
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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeJobYear.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.employeeJobYearMonthHistory(objReportDTO));


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
                    objReportDTO.EmployeeId = txtEmpId.Text;
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


                //if (rdoAttendenceSheet.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;


                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;




                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }


                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }


                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAttendenceSheet.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.attendenceSheet(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();
                //    ReportFormatMaster();





                //}








                if (rdoMontlyBankSalaryList.Checked == true)
                {




                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    selectBankSalaryProcedure();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyBankSalarySheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.montlyBankSalaryList(objReportDTO));


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


                if (rdoHalfCashSalaryRequisition.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    cashHalfSalaryRequisitionProcedure();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSalaryCashRequisitionHO.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.rptHalfCashSalaryRequisitionHO(objReportDTO));
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



                //if (rdoMontlyBankListSPGCL.Checked == true)
                //{




                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;


                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;


                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }


                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }


                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryBankSheetSPGCL.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.salaryListBankSPGCL(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();

                //    ReportFormatMaster();





                //}

                //if (rdoSPEL.Checked == true)
                //{




                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;


                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;


                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }


                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }


                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryBankSheetSPEL.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.salaryListBankSPEL(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();

                //    ReportFormatMaster();





                //}


                //if (rdoMontlyBankListVerl.Checked == true)
                //{




                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;


                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;


                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }


                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }


                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryBankSheetVERL.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.salaryListBankVERL(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();

                //    ReportFormatMaster();





                //}



                //if (rdoSalaryRequisition.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();


                //    objReportDTO.BranchOfficeId = strBranchOfficeId;
                //    objReportDTO.HeadOfficeId = strHeadOfficeId;

                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;


                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }



                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }



                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRequisition.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.salaryRequisition(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();
                //    ReportFormatMaster();

                //}


                //if (rdoIncrementProposalWorkerAboveOneYear.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();


                //    objReportDTO.BranchOfficeId = strBranchOfficeId;
                //    objReportDTO.HeadOfficeId = strHeadOfficeId;

                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;

                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }



                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }


                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerAboveOneYear.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.incrementProposalWorkerAboveOneYear(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();


                //    ReportFormatMaster();
                //}

                //if (rdoIncrementProposalWorkerBellowOneYear.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;


                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;

                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }



                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }


                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerBellowOneYear.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.incrementProposalWorkerBellowOneYear(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();


                //    ReportFormatMaster();
                //}


                //if (rdoIncrementProposalStaff.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;


                //    objReportDTO.Year = txtYear.Text;


                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }



                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }


                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalStaff.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.incrementProposalStaff(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();

                //    ReportFormatMaster();

                //}





                if (rdoEmployeeJobHistory.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;
                    objReportDTO.UpdateBy = strEmployeeId;

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeJobHistory.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.employeeJobHistory(objReportDTO));


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



                if (rdoIncrementSheetAll.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncremetSheetAll.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.incrementSheetAll(objReportDTO));


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

                if (rdoArrearSheetAll.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

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

                    if (ddlFromMonthId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.FromMonthId = "";

                    }

                    if (ddlToMonthId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.ToMonthId = "";

                    }


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearSheetAll.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.arrearSheetAll(objReportDTO));


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


                if (rdoSalaryHistory.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    if(dtpFromDate.Text =="" && dtpToDate.Text =="" )
                    {

                        string strMsg = "Please Enter From Date and To Date!!!";
                        MessageBox(strMsg);
                        return;

                    }
                    else if (txtEmpId.Text == "")
                    {
                        string strMsg = "Please Enter Employee ID!!!";
                        MessageBox(strMsg);
                        return;

                    }

                    else
                    {

                        processSalaryHistory();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;



                        objReportDTO.FromDate = dtpFromDate.Text;
                        objReportDTO.ToDate = dtpToDate.Text;


                        objReportDTO.FromMonthId = dtpFromDate.Text;
                        objReportDTO.ToMonthId = dtpToDate.Text;


                        objReportDTO.EmployeeId = txtEmpId.Text;
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

                        //if (ddlFromMonthId.SelectedValue.ToString() != " ")
                        //{
                        //    objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
                        //}
                        //else
                        //{
                        //    objReportDTO.FromMonthId = "";

                        //}

                        //if (ddlToMonthId.SelectedValue.ToString() != " ")
                        //{
                        //    objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
                        //}
                        //else
                        //{
                        //    objReportDTO.ToMonthId = "";

                        //}


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHistory.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.salaryHistory(objReportDTO));


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


                if (rdoArrearSlipAll.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

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

                    if (ddlFromMonthId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.FromMonthId = "";

                    }
                    if (ddlToMonthId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.ToMonthId = "";

                    }


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearSlipAll.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.arrearSlipAll(objReportDTO));


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


                if (rdoIncrementSlipAll.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSlipAll.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.incrementSlipAll(objReportDTO));


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



                if (rdoSalaryCertificateList.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

                    objReportDTO.EmployeeId = txtEmpId.Text;


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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryCertificateList.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.salaryCertificateList(objReportDTO));
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



                if (rdoMonthlyBankCashStatement.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

                    objReportDTO.EmployeeId = txtEmpId.Text;


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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyBankCashStatement.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.monthlyBankCashStatement(objReportDTO));
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

                //if (rdoMonthlyAdvanceTaxInformation.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();


                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;

                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;

                //    objReportDTO.EmployeeId = txtEmpId.Text;


                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }



                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }


                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyAdvanceTaxInformation.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    DataSet ds = new DataSet();

                //    ds = (objReportBLL.monthlyAdvanceTaxInformation(objReportDTO));
                //    rd.SetDataSource(ds);
                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();




                //    ReportFormatMaster();

                //}



                //if (rdoYearlyAdvanceTaxHistory.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();


                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;

                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;

                //    objReportDTO.EmployeeId = txtEmpId.Text;


                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }



                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }


                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptYearlyAdvanceTaxHistory.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    DataSet ds = new DataSet();

                //    ds = (objReportBLL.yearlyAdvanceTaxHistory(objReportDTO));
                //    rd.SetDataSource(ds);
                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();




                //    ReportFormatMaster();

                //}


                //if (rdoYearlyAdvanceTaxSummery.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();


                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;

                //    objReportDTO.FromDate = dtpFromDate.Text;
                //    objReportDTO.ToDate = dtpToDate.Text;

                //    objReportDTO.EmployeeId = txtEmpId.Text;


                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }



                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }


                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptYearlyAdvanceTaxSummery.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    DataSet ds = new DataSet();

                //    ds = (objReportBLL.yearlyAdvanceTaxSummery(objReportDTO));
                //    rd.SetDataSource(ds);
                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();




                //    ReportFormatMaster();

                //}








                if (rdoMonthlyAdvanceInformation.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyAdvanceInformation.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.monthlyAdvanceInformation(objReportDTO));
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



                if (rdoMonthlyTaxInformation.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.UpdateBy = strEmployeeId;
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyTaxInformation.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.monthlyTaxInformation(objReportDTO));
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

                if (rdoMonthlyArrearInformation.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.UpdateBy = strEmployeeId;
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyArrearInformation.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.monthlyArrearInformation(objReportDTO));
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


                if (rdoMonthlyAATInformation.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.UpdateBy = strEmployeeId;
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyAdvanceArrearTaxInformation.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.monthlyAdvanceArrearInformation(objReportDTO));
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

                if (rdoMonthlySalaryCheckSheet.Checked == true)
                {




                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    processMonthlyCashSalarySheet();


                    objReportDTO.CardNo = txtCardNo.Text;
                    objReportDTO.EmployeeId = txtEmpId.Text;

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryCashSheetHO.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalaryCheckSheet(objReportDTO));


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


                if (rdoDesignationList.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();



                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
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




                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptDesignationList.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.designationList(objReportDTO));
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

                    objReportDTO.UpdateBy = strEmployeeId;
                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;
                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeListNew.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.newEmployeeList(objReportDTO));
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



                if (rdoMonthlySalaryRequisitionHODetail.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    processSalaryRequisitionHODetail();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlySalaryRequsitionHODetail.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.monthlySalaryRequisitionHODetail(objReportDTO));
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



                if (rdoIncrementProposal.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    if (txtYear.Text == "")
                    {
                        string strMsg = "Please Enter Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else
                    {


                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.CardNo = txtCardNo.Text;
                        objReportDTO.EmployeeId = txtEmpId.Text;
                        objReportDTO.Year = txtYear.Text;

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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposal.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.rdoIncrementProposal(objReportDTO));
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

                }



                if (rdoIncrementProposalAll.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();



                    if (txtYear.Text == "")
                    {
                        string strMsg = "Please Enter Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else
                    {


                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.CardNo = txtCardNo.Text;
                        objReportDTO.EmployeeId = txtEmpId.Text;
                        objReportDTO.Year = txtYear.Text;

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


                        //string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalAll.rpt"));
                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalAllSP.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.rdoIncrementProposalAll(objReportDTO));
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

                }


                if (rdoEmployeJobConfiramtionSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;
                    objReportDTO.UpdateBy = strEmployeeId;
                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

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



                    if (ddlFromMonthId.SelectedValue.ToString() != "0")
                    {
                        objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.FromMonthId = "";
                    }


                    if (ddlToMonthId.SelectedValue.ToString() != "0")
                    {
                        objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.ToMonthId = "";
                    }




                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitId = "";

                    }


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeConfirmationSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.EmployeJobConfiramtionSheet(objReportDTO));
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

                if (rdoHalfSalarySheetByBank.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    selectBankHalfSalaryProcedure();
                    objReportDTO = objReportBLL.checkAdvanceSalary(txtYear.Text, txtMonth.Text, strHeadOfficeId, strBranchOfficeId);



                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

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



                    if (objReportDTO.Msg == "Y")
                    {
                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSheetHOByBank.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                    }

                    else
                    {

                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSheetHOByBankByPercentage.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);


                    }
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.rptHalfSalarySheetByBankHO(objReportDTO));
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
                    if (txtEmpId.Text == string.Empty)
                    {
                        MessageBox("Enter Employee Id");
                        return;
                    }
                    if (dtpFromDate.Text == "")
                    {
                        string strMsg = "Please Enter From Date!!!";
                        dtpFromDate.Focus();
                        MessageBox(strMsg);
                        return;

                    }
                    if (dtpToDate.Text == "")
                    {
                        string strMsg = "Please Enter To Date!!!";
                        dtpToDate.Focus();
                        MessageBox(strMsg);
                        return;

                    }
                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    //old
                    //processMonthlyAttendenceSheetWorker();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
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

                    objReportBLL.PrepareJobCard(objReportDTO);

                    //new: RptJobCardNew
                    string strPath = Path.Combine(Server.MapPath("~/Reports/CrystalReport1.rpt"));
                    //old
                    //string strPath = Path.Combine(Server.MapPath("~/Reports/rpDailyAttendenceSheetMonthlyWorker.rpt"));

                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);

                    //new
                    rd.SetDataSource(objReportBLL.GetJobCard(objReportDTO));
                    //old
                    // rd.SetDataSource(objReportBLL.rptMonthlyAttendenceSheetWorker(objReportDTO));

                    //uncomment before live 27.05.2019
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
                    //old
                    //if (dtpFromDate.Text == "" )
                    //{
                    //    string strMsg = "Please Enter From Date!!!";
                    //    dtpFromDate.Focus();
                    //    MessageBox(strMsg);
                    //    return; 

                    //}
                    //else if (dtpToDate.Text == "")
                    //{
                    //    string strMsg = "Please Enter To Date!!!";
                    //    dtpToDate.Focus();
                    //    MessageBox(strMsg);
                    //    return;

                    //}
                    //else if (txtEmpId.Text == "")
                    //{

                    //    string strMsg = "Please Enter Employee ID!!!";
                    //    txtEmpId.Focus();
                    //    MessageBox(strMsg);
                    //    return;

                    //}

                    //else
                    //{

                    //    ReportDTO objReportDTO = new ReportDTO();
                    //    ReportBLL objReportBLL = new ReportBLL();

                    //    processMonthlyAttendenceSheet();


                    //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    //    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    //    objReportDTO.EmployeeId = txtEmpId.Text;
                    //    objReportDTO.UpdateBy = strEmployeeId;


                    //    objReportDTO.FromDate = dtpFromDate.Text;
                    //    objReportDTO.ToDate = dtpToDate.Text;
                    //    objReportDTO.CardNo = txtCardNo.Text;



                    //    if (ddlSectionId.SelectedValue.ToString() != " ")
                    //    {
                    //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    //    }
                    //    else
                    //    {

                    //        objReportDTO.SectionId = "";
                    //    }


                    //    if (ddlUnitId.SelectedValue.ToString() != " ")
                    //    {
                    //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    //    }
                    //    else
                    //    {
                    //        objReportDTO.UnitId = "";

                    //    }



                    //    string strPath = Path.Combine(Server.MapPath("~/Reports/rpDailyAttendenceSheetMonthlySP.rpt"));
                    //    this.Context.Session["strReportPath"] = strPath;
                    //    rd.Load(strPath);
                    //    rd.SetDataSource(objReportBLL.rptMonthlyAttendenceSheetSP(objReportDTO));


                    //    rd.SetDatabaseLogon("erp", "erp");
                    //    CrystalReportViewer1.ReportSource = rd;
                    //    CrystalReportViewer1.DataBind();

                    //    ReportFormatMaster();


                    //    this.CrystalReportViewer1.Dispose();
                    //    this.CrystalReportViewer1 = null;
                    //    rd.Dispose();
                    //    rd.Close();
                    //    GC.Collect();
                    //    GC.WaitForPendingFinalizers();

                    //}


                }


                if (rdoMonthlyAttendenceSheetAll.Checked == true)
                {


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


                         ReportDTO objReportDTO = new ReportDTO();
                         ReportBLL objReportBLL = new ReportBLL();

                         processMonthlyAttendenceSheetAll();


                         objReportDTO.HeadOfficeId = strHeadOfficeId;
                         objReportDTO.BranchOfficeId = strBranchOfficeId;
                         objReportDTO.EmployeeId = txtEmpId.Text;
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


                        string strPath = "";

                        if (strHeadOfficeId == "441")
                        {

                            strPath = Path.Combine(Server.MapPath("~/Reports/rpMonthlyAttendenceSheetSP.rpt"));

                        }
                        else
                        {

                            strPath = Path.Combine(Server.MapPath("~/Reports/rpMonthlyAttendenceSheetHO.rpt"));

                        }

                        
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




                if (rdoMonthlySalarySheetHOByBank.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;


                    selectBankSalaryProcedure();


                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitId = "";

                    }


                    if (ddlSectionId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.SectionId = "";
                    }

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBankSalarySheetSP.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalarySheetSPByBank(objReportDTO));


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

                if (rdoEmployeeLeaveSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;


                    objReportDTO.FromDate = dtpFromDate.Text;
                    objReportDTO.ToDate = dtpToDate.Text;

                    objReportDTO.CardNo = txtCardNo.Text;
                    objReportDTO.EmployeeId = txtEmpId.Text;

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





                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeLeave.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.employeeLeaveSheet(objReportDTO));


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

                    ReportFormatMaster();


                    this.CrystalReportViewer1.Dispose();
                    this.CrystalReportViewer1 = null;
                    rd.Dispose();
                    rd.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                }


                if (rdoEmployeeBasicInformationPower.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    objReportDTO.EmployeeId = txtEmpId.Text;

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





                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeBasicInfo.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.employeeBasicInformaiton(objReportDTO));
                    rd.SetDataSource(ds);
                    rd.SetDatabaseLogon("erp", "erp");
                    CrystalReportViewer1.ReportSource = rd;
                    CrystalReportViewer1.DataBind();


                    //string url = "CrystalView.aspx?ID=" + "324rsjfaiosafd";
                    //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=600,width=900,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true);



                    ReportFormatMaster();
                    this.CrystalReportViewer1.Dispose();
                    this.CrystalReportViewer1 = null;
                    rd.Dispose();
                    rd.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();


                }



                if (rdoMonthlyAttendenceSheetSummery.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();



                    processMonthlyAttendenceSummerySheetPower();


                    


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
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


                if (rdoTaxStatement.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    if (ddlFromMonthId.Text == "0" || ddlFromMonthId.Text == "0")

                    {

                        string strMsg = "Please select From month and To Month!!!";
                        MessageBox(strMsg);
                        return;

                    }
                    else
                    {


                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.Year = txtYear.Text;


                        if (ddlFromMonthId.Text != "0")
                        {
                            objReportDTO.FromMonth = ddlFromMonthId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.FromMonth = "";
                        }

                        if (ddlToMonthId.Text != "0")
                        {
                            objReportDTO.ToMonth = ddlToMonthId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.ToMonth = "";
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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptTaxStatementDetail.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.taxStatement(objReportDTO));
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


                }


                if (rdoTaxSummerySheetDetail.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    if (dtpFromDate.Text == "" || dtpToDate.Text == "")

                    {

                        string strMsg = "Please Enter From Date and To Date!!!";
                        MessageBox(strMsg);
                        return;

                    }
                    else
                    {

                        processYearlyTaxStatement();



                        objReportDTO.EmployeeId = txtEmpId.Text;
                        objReportDTO.CardNo = txtCardNo.Text;

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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptYearlyTaxStatement.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.YearlyTaxSummerySheetDetail(objReportDTO));
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


                }

                if (rdoEmployeeJoiningInfo.Checked == true)
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

                        strMsg = "Please Enter To Date!!!";
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
                        objReportDTO.UpdateBy = strEmployeeId;
                        objReportDTO.EmployeeTypeId = "";

                        objReportDTO.FromDate = dtpFromDate.Text;
                        objReportDTO.ToDate = dtpToDate.Text;

                        objReportDTO.CardNo = txtCardNo.Text;
                        objReportDTO.EmployeeId = txtEmpId.Text;

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







                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeJoiningInfo.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.EmployeJoiningInfo(objReportDTO));


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

                        ReportFormatMaster();


                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }

                }


                if (rdoMonthlySalaryStatement.Checked == true)
                {

                    if (txtYear.Text == "")
                    {
                        string strMsg = "Please Enter Year!!!";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }

                    else if (txtMonth.Text == "")
                    {
                        string strMsg = "Please Enter Month!!!";
                        txtMonth.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    else
                    {

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;



                        MonthlySalaryStatementprocess();



                        objReportDTO.Year = txtYear.Text;
                        objReportDTO.Month = txtMonth.Text;




                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlySalaryStatement.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.MonthlySalaryStatement(objReportDTO));


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

                        ReportFormatMaster();


                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }

                }

                if (rdoYearlySalaryStatement.Checked == true)
                {


                    if (txtYear.Text == "")
                    {
                        string strMsg = "Please Enter Year!!!";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    else
                    {


                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;



                        YearlySalaryStatementprocess();



                        objReportDTO.Year = txtYear.Text;





                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptYearlySalaryStatement.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rptYearlySalaryStatementprocess(objReportDTO));


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

                        ReportFormatMaster();


                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }

                }


                if (rdoEmployeJoiningResignInfo.Checked == true)
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


                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;


                        objReportDTO.FromDate = dtpFromDate.Text;
                        objReportDTO.ToDate = dtpToDate.Text;

                        objReportDTO.CardNo = txtCardNo.Text;
                        objReportDTO.EmployeeId = txtEmpId.Text;

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





                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeJRInfo.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.EmployeJoiningResignInfo(objReportDTO));


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

                        ReportFormatMaster();


                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }

                }


                if (rdoEmployeResignInfo.Checked == true)
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


                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;


                        objReportDTO.FromDate = dtpFromDate.Text;
                        objReportDTO.ToDate = dtpToDate.Text;

                        objReportDTO.CardNo = txtCardNo.Text;
                        objReportDTO.EmployeeId = txtEmpId.Text;

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





                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeResignedSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.EmployeeResignInfo(objReportDTO));


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




#endregion
        #region "Function"

        public void processMonthlyAttendenceSheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;
            objReportDTO.EmployeeId = txtEmpId.Text;


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
            //MessageBox(strMsg);




        }


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

        public void processMonthlyAttendenceSheetAll()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;
            objReportDTO.EmployeeId = txtEmpId.Text;


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


        public void processArrearRequsition()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            if (ddlFromMonthId.SelectedValue.ToString() != " ")
            {
                objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.FromMonthId = "";

            }

            if (ddlToMonthId.SelectedValue.ToString() != " ")
            {
                objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ToMonthId = "";

            }



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processArrearRequsition(objReportDTO);
            MessageBox(strMsg);




        }
        public void processMonthlyCashSalarySheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.processMonthlyCashSalarySheet(objReportDTO);
            MessageBox(strMsg);




        }

        public void processSalaryRequisitionHOMISCDetail()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.processSalaryRequisitionHOMISCDetail(objReportDTO);
            MessageBox(strMsg);




        }
        public void processSalaryRequisitionHODetail()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.processSalaryRequisitionHODetail(objReportDTO);
            MessageBox(strMsg);




        }
        public void processSalaryRequisitionCashDetail()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.processSalaryRequisitionCashDetail(objReportDTO);
            MessageBox(strMsg);




        }
        public void processMonthlyCashRequisition()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.processMonthlyCashRequisition(objReportDTO);
            MessageBox(strMsg);




        }
        public void processSalaryRequisitionHOMISC()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.processSalaryRequisitionHOMISC(objReportDTO);
            MessageBox(strMsg);




        }
        public void processSalaryRequisitionHO()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.processSalaryRequisitionHO(objReportDTO);
            MessageBox(strMsg);




        }

        public void processMonthlyBankSalaryMAL()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.processMonthlyBankSalaryMAL(objReportDTO);
            MessageBox(strMsg);




        }


        public void selectBankSalaryProcedure()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.selectBankSalaryProcedure(objReportDTO);
            //MessageBox(strMsg);




        }

        public void salaryProcessByBank()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.salaryProcessByBank(objReportDTO);
            MessageBox(strMsg);




        }


        public void processMonthlyBankSalarySFL()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.processMonthlyBankSalarySFL(objReportDTO);
            MessageBox(strMsg);




        }
        public void processMonthlySalaryHOSr()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.processMonthlySalaryHOSr(objReportDTO);
            MessageBox(strMsg);




        }

        public void cashHalfSalaryRequisitionProcedure()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.cashHalfSalaryRequisitionProcedure(objReportDTO);
            MessageBox(strMsg);




        }
        public void processMonthlySalaryHOFactSr()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.processMonthlySalaryHOFactSr(objReportDTO);
            MessageBox(strMsg);




        }
        public void processMonthlySalaryHOSrNoraml()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.processMonthlySalaryHOSrNoraml(objReportDTO);
            MessageBox(strMsg);




        }

        public void processSalaryHistory()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;
            objReportDTO.EmployeeId = txtEmpId.Text;


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

            string strMsg = objReportBLL.processSalaryHistory(objReportDTO);


        }

        public void salaryProcessMiscHeadOfficeSeniorStaff()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.salaryProcessMiscHeadOfficeSeniorStaff(objReportDTO);
            MessageBox(strMsg);




        }
        public void salaryProcessMiscHeadOfficeSeniorFactoryStaff()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.salaryProcessMiscHeadOfficeSeniorFactoryStaff(objReportDTO);
            MessageBox(strMsg);




        }
        public void salaryProcessMiscHeadOfficeNormal()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.salaryProcessMiscHeadOfficeNormal(objReportDTO);
            MessageBox(strMsg);




        }

        public void enableDisableRadio()
        {

            if (rdoEmployeeBasicInformation.Checked == true)
            {

                rdoEmployeeJobHistory.Checked = false; 
            }
            else
            {

                rdoEmployeeJobHistory.Checked = true; 
            }

            if (rdoEmployeeJobHistory.Checked == true)
            {

                rdoEmployeeBasicInformation.Checked = false;
            }

            else
            {
                rdoEmployeeBasicInformation.Checked = true ;

            }


        }



        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        public void processSalarySummeryHO()
        {
            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            

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

            string strMsg = objReportBLL.processSalarySummeryHO(objReportDTO);




        }

        public void selectBankHalfSalaryProcedure()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.selectBankHalfSalaryProcedure(objReportDTO);
            MessageBox(strMsg);




        }


        public void MonthlySalaryStatementprocess()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();




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






            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;


            string strMsg = objReportBLL.MonthlySalaryStatementprocess(objReportDTO);






        }

        public void YearlySalaryStatementprocess()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();




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







            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;


            string strMsg = objReportBLL.YearlySalaryStatementprocess(objReportDTO);






        }


        public void processYearlyTaxStatement()
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

            string strMsg = objReportBLL.processYearlyTaxStatement(objReportDTO);
            //MessageBox(strMsg);




        }

        public void processYearlyTaxSummeryFB()
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

            string strMsg = objReportBLL.processYearlyTaxSummeryFB(objReportDTO);
            //MessageBox(strMsg);




        }
        public void processYearlyTaxSummery()
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

            string strMsg = objReportBLL.processYearlyTaxSummery(objReportDTO);
            //MessageBox(strMsg);




        }


        //public void processSalaryRequisition()
        //{


        //    ReportDTO objReportDTO = new ReportDTO();
        //    ReportBLL objReportBLL = new ReportBLL();


        //    if (ddlSectionId.SelectedValue.ToString() != " ")
        //    {
        //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
        //    }
        //    else
        //    {

        //        objReportDTO.SectionId = "";
        //    }

        //    if (ddlSalaryRequisitionId.SelectedValue.ToString() != " ")
        //    {

        //        objReportDTO.RequisitionId = ddlSalaryRequisitionId.SelectedValue.ToString();
        //    }
        //    else
        //    {

        //        objReportDTO.RequisitionId = "";
        //    }

        //    if (ddlUnitId.SelectedValue.ToString() != " ")
        //    {
        //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objReportDTO.UnitId = "";

        //    }
        //    objReportDTO.Year = txtYear.Text;
        //    objReportDTO.Month = txtMonth.Text;

        //    objReportDTO.HeadOfficeId = strHeadOfficeId;
        //    objReportDTO.BranchOfficeId = strBranchOfficeId;
        //    objReportDTO.UpdateBy = strEmployeeId;

        //    string strMsg = objReportBLL.processSalaryRequisition(objReportDTO);


        //}



        #endregion

        #region "Export PDF/EXCEL/WORD"
        public void exportReport()
        {
             if (chkExcel.Checked == true )
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
                if (chkPDF.Checked == true )
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


        protected void chkEmployeeSalarySlip_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        protected void chkEmployeeBasicInformationByOffiwise_CheckedChanged(object sender, EventArgs e)
        {



        }

      

        protected void chkEmployeeList_CheckedChanged(object sender, EventArgs e)
        {

        }

       
        protected void chkEmployeeSalarySheet_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chkPaySlipStaff_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chkEmployeeSalarySheetStaff_CheckedChanged(object sender, EventArgs e)
        {

        }


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

       
       



        //protected void rdoMonthlyBankList_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (rdoMonthlyBankList.Checked == true)
        //        {
        //            rdoEmployeeBasicInformation.Checked = false;
        //            rdoEmployeeJobHistory.Checked = false;
        //            rdoEmployeeListHO.Checked = false;
        //            rdoMonthlySalarySheetHO.Checked = false;
        //            rdoMonthlySalarySheetHOMISC.Checked = false;
        //            rdoMonthlySalarySheetHOMISCPaySlip.Checked = false;
        //            rdoMonthlySalarySheetHOPaySlip.Checked = false;
        //            rdoMonthlySalarySheetStaff.Checked = false;
        //            rdoMonthlyPaySlipStaff.Checked = false;
        //            rdoMonthlyHalfSheetStaff.Checked = false;
        //            rdoMonthlyPaySlipWorker.Checked = false;

        //            rdoMonthlyHalfSheetWorker.Checked = false;
        //            rdoSalaryRequisition.Checked = false;
        //            rdoSalarySummery.Checked = false;
        //            rdoIncrementProposalWorker.Checked = false;
        //            rdoIncrementProposalWorker.Checked = false;
        //            rdoIncrementProposalHO.Checked = false;
        //            rdoIncrementSheetHOSeniorStaff.Checked = false;
        //            rdoIncrementSheetHOSeniorStaffPayslip.Checked = false;
        //            rdoIncrementSheetFactorySeniorStaff.Checked = false;
        //            rodIncrementSheetFactoryStaffArrearPaySlip.Checked = false;
        //            rdoIncrementSheet.Checked = false;
        //            rdoArrearSlip.Checked = false;
        //            rdoTiffinRequisition.Checked = false;
        //            rdoAttendenceSheet.Checked = false;
        //            rdoAdvanceAmountInformation.Checked = false;
        //            rdoMonthlyMiscSheetWorker.Checked = false;
        //        }
               

        //    }

        //    catch (Exception ex)
        //    {

        //        throw new Exception("Error : " + ex.Message);
        //    }
        //}

      

        #region "Check Box Region"
        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {

              
                chkExcel.Checked = false;
                chkText.Checked = false;
                chkWord.Checked = false;
                chkCSV.Checked = false;
            }
        }

       

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
             
                chkPDF.Checked = false;
                chkText.Checked = false;
                chkWord.Checked = false;
                chkCSV.Checked = false;
            }
        }

        protected void chkWord_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWord.Checked == true)
            {
              
                chkPDF.Checked = false;
                chkText.Checked = false;
                chkExcel.Checked = false;
                chkCSV.Checked = false;
            }
        }

        protected void chkText_CheckedChanged(object sender, EventArgs e)
        {
            if (chkText.Checked == true)
            {
               
                chkPDF.Checked = false;
                chkWord.Checked = false;
                chkExcel.Checked = false;
                chkCSV.Checked = false;
            }
        }

        protected void chkCSV_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCSV.Checked == true)
            {
               
                chkPDF.Checked = false;
                chkWord.Checked = false;
                chkExcel.Checked = false;
                chkText.Checked = false;
            }
        }


        #endregion




       
      



    }
}