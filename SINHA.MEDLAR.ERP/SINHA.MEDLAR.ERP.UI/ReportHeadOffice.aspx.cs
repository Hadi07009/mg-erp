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
using System.Text;
using SINHA.MEDLAR.ERP.BLL.Utility;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ReportHeadOffice : System.Web.UI.Page
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
        ExportFormatType formatType = ExportFormatType.NoFormat;
        string strDefaultName = "Report";
       

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
                //getRequisitionId();
                getEidTypeId();
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

        public void getEidTypeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEidTypeId.DataSource = objLookUpBLL.getEidTypeId();

            ddlEidTypeId.DataTextField = "EID_NAME";
            ddlEidTypeId.DataValueField = "EID_TYPE_ID";

            ddlEidTypeId.DataBind();
            if (ddlEidTypeId.Items.Count > 0)
            {

                ddlEidTypeId.SelectedIndex = 0;
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
            string strReportPath = Session["strReportPath"].ToString().Trim();

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
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();
                //Response.End();


                rd.ExportToHttpResponse
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "report_head_office");
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
                rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, "report_head_office");
                Response.End();  

            }

            if (chkCSV.Checked == true)
            {
                MemoryStream oStream;
                oStream = (MemoryStream)rd.ExportToStream(formatType);
                formatType = ExportFormatType.CharacterSeparatedValues;
                rd.ExportToHttpResponse(formatType, Response, true, strDefaultName);
                oStream.Flush();
                oStream.Close();
                oStream.Dispose();
                CrystalReportViewer1.RefreshReport();
                Response.End();
                
            }

            if (chkText.Checked == true)
            {
                formatType = ExportFormatType.RichText;
                MemoryStream oStream;
                oStream = (MemoryStream)rd.ExportToStream(formatType);
                Response.ContentType = "text/html";
                oStream.Seek(0, SeekOrigin.Begin);
                Response.BinaryWrite(oStream.ToArray());
                oStream.Flush();
                oStream.Close();
                oStream.Dispose();
                CrystalReportViewer1.RefreshReport();
                Response.End();

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

        public void showReport()
        {

            try
            {


                string url = "CrystalView.aspx";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.open('");
                sb.Append(url);
                sb.Append("');");
                sb.Append("</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "script", sb.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("Error : "+ex.Message);

            }

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


                if (rdoMonthlySalarySheetHOByBank.Checked == true)
                {

                    if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter  Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else if (txtMonth.Text == "")
                    {

                        string strMsg = "Please Enter  Month!!!";
                        MessageBox(strMsg);
                        txtMonth.Focus();
                        return;
                    }
                    else
                    {

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;


                        salaryProcessByBank();


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



                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHOByBank.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);

                        //corrected after eveining
                        //rd.SetDataSource(objReportBLL.monthlySalarySheetHOByBank(objReportDTO));
                        //new
                        rd.SetDataSource(objReportBLL.GetBankSalaryDetailHO(objReportDTO));
                        
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


                if (rdoBonusSheetHOByBank.Checked == true)
                {


                    if (ddlEidTypeId.Text == " ")
                    {

                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }


                    else if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }


                    else
                    {


                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;


                        selectBonusBankProcedure();


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



                        if (ddlEidTypeId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.EidTypeId = "";
                        }


                        objReportDTO.Year = txtYear.Text;
                        objReportDTO.Month = txtMonth.Text;



                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetHOByBank.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.bonusSheetHOByBank(objReportDTO));


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
                //rdoBonusCashSheetDirector
                if (rdoBonusCashSheetDirector.Checked == true)
                {

                    if (ddlEidTypeId.Text == " ")
                    {
                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }
                    else if (txtYear.Text == "")
                    {
                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else
                    {
                        bonusCashSheetPro();

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

                        objReportDTO.SectionId = "36";

                        //if (ddlSectionId.SelectedValue.ToString() != " ")
                        //{
                        //    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                        //}
                        //else
                        //{
                        //    objReportDTO.SectionId = "";
                        //}

                        if (ddlEidTypeId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.EidTypeId = "";
                        }

                        objReportDTO.Year = txtYear.Text;
                        objReportDTO.Month = txtMonth.Text;

                        //if (strBranchOfficeId == "106" || strBranchOfficeId == "109")
                        //{
                        //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusCashSheetVERL.rpt"));
                        //    this.Context.Session["strReportPath"] = strPath;
                        //    rd.Load(strPath);
                        //    rd.SetDataSource(objReportBLL.rptCashBonusSheet(objReportDTO));
                        //}
                        //else
                        //{
                            string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusCashSheet.rpt"));
                            this.Context.Session["strReportPath"] = strPath;
                            rd.Load(strPath);
                        //rd.SetDataSource(objReportBLL.bonusCashSheet(objReportDTO));
                        rd.SetDataSource(objReportBLL.GetDirectorCashSheet(objReportDTO));
                        //}

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
                if (rdoBonusCashSheet.Checked == true)
                {

                    if (ddlEidTypeId.Text == " ")
                    {
                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }
                    else if (txtYear.Text == "")
                    {
                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else
                    {
                        bonusCashSheetPro();

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

                        if (ddlEidTypeId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.EidTypeId = "";
                        }

                        objReportDTO.Year = txtYear.Text;
                        objReportDTO.Month = txtMonth.Text;

                        if (strBranchOfficeId == "106" || strBranchOfficeId == "109")
                        {
                            string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusCashSheetVERL.rpt"));
                            this.Context.Session["strReportPath"] = strPath;
                            rd.Load(strPath);
                            rd.SetDataSource(objReportBLL.rptCashBonusSheet(objReportDTO));
                        }
                        else
                        {
                            string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusCashSheet.rpt"));
                            this.Context.Session["strReportPath"] = strPath;
                            rd.Load(strPath);
                            //rd.SetDataSource(objReportBLL.bonusCashSheet(objReportDTO));
                            rd.SetDataSource(objReportBLL.GetNoneDirectorCashSheet(objReportDTO));
                        }

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


                if (rdoBonusMiscellaneousSheet.Checked == true)
                {


                    if (ddlEidTypeId.Text == " ")
                    {

                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }


                    else if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }


                    else
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



                        if (ddlEidTypeId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.EidTypeId = "";
                        }


                        objReportDTO.Year = txtYear.Text;
                        objReportDTO.Month = txtMonth.Text;


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetHOMisc.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rptSecondBonusSheet(objReportDTO));


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




                if (rdoMonthlySalarySheetHOSrStaffs.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    processMonthlySalaryHOSr();

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHOSrStaffs.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalarySheetHOSrStaffs(objReportDTO));


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

                if (rdoMonthlySalarySheetHOFactSrStafss.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    processMonthlySalaryHOFactSr();

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHOFactSrStaffs.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalarySheetHOFactSrStafss(objReportDTO));


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

                if (rdoMonthlySalarySheetHONormal.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    processMonthlySalaryHOSrNoraml();

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHOSrNormal.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalarySheetHONormal(objReportDTO));


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

                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }

                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }

                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
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

                //    //string strUrl = "CrystalView.aspx";
                //    //ClientScript.RegisterStartupScript(this.Page.GetType(), "popupOpener", "var popup=window.open('" + strUrl + "');popup.focus();", true);





                //}


                //if (rdoMonthlyHalfSheetWorker.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;


                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }

                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }
                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }

                //    else
                //    {
                //        objReportDTO.SectionId = "";

                //    }

                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;



                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSheetWorker.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.halfSheetWorker(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();
                //    ReportFormatMaster();





                //}


                //if (rdoMonthlyMiscSheetWorker.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;


                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }

                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }
                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }

                //    else
                //    {
                //        objReportDTO.SectionId = "";

                //    }

                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;



                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetWorkerMisc.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.workerMiscSheet(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();
                //    ReportFormatMaster();





                //}

                //if (rdoMonthlySalarySummeryWorker.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;


                //    if (ddlUnitId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                //    }

                //    else
                //    {
                //        objReportDTO.UnitId = "";

                //    }
                //    if (ddlSectionId.SelectedValue.ToString() != " ")
                //    {
                //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                //    }

                //    else
                //    {
                //        objReportDTO.SectionId = "";

                //    }

                //    objReportDTO.Year = txtYear.Text;
                //    objReportDTO.Month = txtMonth.Text;



                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetWorkerSummery.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.monthlySalarySummeryWorker(objReportDTO));


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


                if (rdoMonthlySalarySheetHOSRMISC.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    salaryProcessMiscHeadOfficeSeniorStaff();




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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHOSeniorMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalarySheetHOSRMISC(objReportDTO));


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


                if (rdoMonthlySalarySheetHOFactSRMISCNormal.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    salaryProcessMiscHeadOfficeNormal();

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHONormalMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalarySheetHOSRMISCNormal(objReportDTO));


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
                if (rdoMonthlySalarySheetHOFactSRMISC.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    salaryProcessMiscHeadOfficeSeniorFactoryStaff();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHOFactSeniorMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalarySheetFactSRMISC(objReportDTO));


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
                    objReportDTO.EmployeeId = strEmployeeId;

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
                    objReportDTO.CardNo = txtCardNo.Text;
                    objReportDTO.EmployeeId = txtEmpId.Text;


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

                if (rdoMonthlySalarySlipHOSrStafss.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processMonthlySalaryHOSr();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySlipHOSr.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalarySlipHOSrStafss(objReportDTO));


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

                if (rdoMonthlySalarySlipHoFactSr.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processMonthlySalaryHOFactSr();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySlipHOFactSr.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalarySlipHoFactSr(objReportDTO));


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

                if (rdoMonthlySalaryPaySlipHONormal.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processMonthlySalaryHOSrNoraml();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySlipHOSrNormal.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalaryPaySlipHONormal(objReportDTO));


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

                if (rdoMonthlySalaryCheckPaySlip.Checked == true)
                {

                    if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter  Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else if (txtMonth.Text == "")
                    {

                        string strMsg = "Please Enter  Month!!!";
                        MessageBox(strMsg);
                        txtMonth.Focus();
                        return;
                    }
                    else
                    {
                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();


                        processMonthlyCashSalarySheet();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;



                        objReportDTO.CardNo = txtCardNo.Text;
                        objReportDTO.EmployeeId = txtEmpId.Text;

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



                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryCashSheetHOSlip.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.monthlySalaryCheckPaySlip(objReportDTO));


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
                    objReportDTO.CardNo = txtCardNo.Text;
                    objReportDTO.EmployeeId = txtEmpId.Text;

                    //FOR INCREMENT
                    //string strPath = string.Empty;
                    //if (objReportDTO.Year == "2022" && objReportDTO.Month == "01" && objReportDTO.BranchOfficeId == "104")
                    //{
                    //    //new: added on 03.03.2022
                    //    strPath = Path.Combine(Server.MapPath("~/Reports/RptSalarySheetPaySlipHOMisc.rpt"));
                    //}
                    //else
                    //{
                    //    //old: commented on 03.03.2022
                    //    strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHOSlipMisc.rpt"));
                    //}

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

                if (rdoMonthlySalarySheetHOMISCPaySlipNormal.Checked == true)
                {


                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    salaryProcessMiscHeadOfficeNormal();

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHOSlipMiscNormal.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalarySheetHOMISCPaySlipNormal(objReportDTO));


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

                if (rdoMonthlySalarySheetHOMISCPaySlipSR.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    salaryProcessMiscHeadOfficeSeniorStaff();

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHOSRSlipMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalarySheetHOMISCPaySlipSR(objReportDTO));


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

                if (rdoMonthlySalarySheetHOMISCPaySlipFactSR.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    salaryProcessMiscHeadOfficeSeniorFactoryStaff();

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetHOFactSRSlipMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalarySheetHOMISCPaySlipFactSR(objReportDTO));


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



                //if (chkEmployeeSalaryListForBank.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

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
                //        objReportDTO.SectionId = ddlUnitId.SelectedValue.ToString();
                //    }
                //    else
                //    {

                //        objReportDTO.SectionId = "";
                //    }



                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryBank.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.salaryListForBank(objReportDTO));


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
                if (rdoEmployeeListHO.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;

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

                    //Condition added by Shahin on 22.12.2018
                    string strPath = string.Empty;
                    if (ddlSectionId.SelectedValue.ToString() != " " && ddlUnitId.SelectedValue.ToString() != " ")
                        strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeList.rpt"));
                    else
                        strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeListSectionWise.rpt"));

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

                if (rdoSalarySummery.Checked == true)
                {


                    if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter  Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else if (txtMonth.Text == "")
                    {

                        string strMsg = "Please Enter  Month!!!";
                        MessageBox(strMsg);
                        txtMonth.Focus();
                        return;
                    }
                    else
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



                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySummeryHO.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.salarySummeryHO(objReportDTO));


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


                if (rdoMonthlySalaryCheckSheet.Checked == true)
                {

                    if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter  Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else if (txtMonth.Text == "")
                    {

                        string strMsg = "Please Enter  Month!!!";
                        MessageBox(strMsg);
                        txtMonth.Focus();
                        return;
                    }
                    else
                    {


                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.CardNo = txtCardNo.Text;
                        objReportDTO.EmployeeId = txtEmpId.Text;

                        processMonthlyCashSalarySheet();

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



                }

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



                if (rdoIncrementProposalHO.Checked == true)
                {


                    //if (chkIncrementProposalHOSheet1.Checked == true)
                    //{
                    //    ReportDTO objReportDTO = new ReportDTO();
                    //    ReportBLL objReportBLL = new ReportBLL();

                    //    objReportDTO.HeadOfficeId = strHeadOfficeId;

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


                    //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalHO.rpt"));
                    //    this.Context.Session["strReportPath"] = strPath;
                    //    rd.Load(strPath);
                    //    rd.SetDataSource(objReportBLL.incrementProposalHOSheet1(objReportDTO));


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

                    //}

                    //else if (chkIncrementProposalHOSheet2.Checked == true)
                    //{

                    //    ReportDTO objReportDTO = new ReportDTO();
                    //    ReportBLL objReportBLL = new ReportBLL();

                    //    objReportDTO.HeadOfficeId = strHeadOfficeId;

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


                    //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalHO.rpt"));
                    //    this.Context.Session["strReportPath"] = strPath;
                    //    rd.Load(strPath);
                    //    rd.SetDataSource(objReportBLL.incrementProposalHOSheet2(objReportDTO));


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

                    //}
                    //else
                    //{
                    //    string strMsg = "Please Select at least One Sheet!!!";
                    //    MessageBox(strMsg);
                    //    return ;
                    //}




                }

                if (rdoTiffinRequisition.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptTiffinRequisition.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.tiffinRequisition(objReportDTO));


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

                if (rdoEmployeeJobHistoryOverall.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptGetEmployeeJobHistory.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetEmployeeJobHistoryOverall(objReportDTO));


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
                if (rdoIncrementSheet.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncremetSheetNormal.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.incrementSheet(objReportDTO));


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

                if (rdoIncrementSlipNormal.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSlipNormal.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.incrementSlipNormal(objReportDTO));


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



                if (rdoArrearSlip.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearSlip.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.arrearSlip(objReportDTO));


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


                if (rdoArrearSheetHOSeniorStaffPayslip.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptHOArrearSlip.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.arrearSlipHO(objReportDTO));


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
                if (rdoArrearSheetFactorySrStaffs.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearSlipHOFactoryStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.arrearSlipHOFactoryStaff(objReportDTO));


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

                if (rdoIncrementSheetHOSeniorStaffPayslip.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptHOIncrementSlip.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.incrementSheetHOSeniorStaffPayslip(objReportDTO));


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




                if (rdoIncrementSheetFactoryStaffIncrementPaySlip.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptStaffsIncrementSlip.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.factoryStaffIncrementSlip(objReportDTO));


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

                if (rdoIncrementSheetFactorySeniorStaff.Checked == true)
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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSheetFactorySenoirStaffs.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.factoryStaff(objReportDTO));


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


                if (rdoIncrementSheetFactorySeniorStaff.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptFactoryStaffs.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.factoryStaff(objReportDTO));


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


                if (rdoIncrementSheetHOSeniorStaff.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSheetHOStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.headOfficeStaf(objReportDTO));


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

                if (rdoArrearSheetHOSeniorStaff.Checked == true)
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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearSheetHOSeniorStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.arrearSheetHOSeniorStaff(objReportDTO));


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

                if (rdoArrearSheetHOFactoryStaff.Checked == true)
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




                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearSheetHOFactSeniorStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.arrearSheetHOFactoryStaff(objReportDTO));


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

                if (rdoArrearSheetNormal.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearSheetHONormal.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.arrearSheetNormal(objReportDTO));


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
                if (rdoIncrementProposalHOAboveOneYear.Checked == true)
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
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSheetHOStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.incrementProposalHOAboveOneYear(objReportDTO));
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
                                
                if (rdoMonthlySalaryRequisitionSFL.Checked == true)
                {

                    if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter  Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else if (txtMonth.Text == "")
                    {

                        string strMsg = "Please Enter  Month!!!";
                        MessageBox(strMsg);
                        txtMonth.Focus();
                        return;
                    }
                    else
                    {

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();


                        processSalaryRequisitionHO();

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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlySalaryRequsitionSFL.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.monthlySalaryRequisitionSFL(objReportDTO));
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


                if (rdoBonusRequisitionSFL.Checked == true)
                {
                    if (ddlEidTypeId.Text == " ")
                    {

                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }


                    else if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }


                    else
                    {


                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();


                        processBonusRequisitionHO();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.Year = txtYear.Text;


                        if (ddlSectionId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.SectionId = "";
                        }

                        if (ddlEidTypeId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.EidTypeId = "";
                        }

                        if (ddlUnitId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.UnitId = "";

                        }


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusRequsitionSFL.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.bonusRequisitionSFL(objReportDTO));
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

                if (rdoBonusRequisitionMAL.Checked == true)
                {

                     if (ddlEidTypeId.Text == " ")
                    {

                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }


                     else if (txtYear.Text == "")
                     {

                         string strMsg = "Please Enter Eid Year!!!";
                         MessageBox(strMsg);
                         txtYear.Focus();
                         return;
                     }


                     else
                     {

                         ReportDTO objReportDTO = new ReportDTO();
                         ReportBLL objReportBLL = new ReportBLL();


                         processBonusRequisitionHO();

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

                         if (ddlEidTypeId.SelectedValue.ToString() != " ")
                         {
                             objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                         }
                         else
                         {

                             objReportDTO.EidTypeId = "";
                         }


                         if (ddlUnitId.SelectedValue.ToString() != " ")
                         {
                             objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                         }
                         else
                         {
                             objReportDTO.UnitId = "";

                         }


                         string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusRequsitionMAL.rpt"));
                         this.Context.Session["strReportPath"] = strPath;
                         rd.Load(strPath);
                         DataSet ds = new DataSet();

                         ds = (objReportBLL.bonusRequisitionMAL(objReportDTO));
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

                if (rdoMonthlySalaryRequisitionMAL.Checked == true)
                {

                    if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter  Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else if (txtMonth.Text == "")
                    {

                        string strMsg = "Please Enter  Month!!!";
                        MessageBox(strMsg);
                        txtMonth.Focus();
                        return;
                    }
                    else
                    {

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();


                        processSalaryRequisitionHO();

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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlySalaryRequsitionMAL.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();
                        //Old
                        //ds = (objReportBLL.monthlySalaryRequisitionMAL(objReportDTO));
                        //rd.SetDataSource(ds);

                        //new
                        rd.SetDataSource(objReportBLL.GetSalaryReruisitionSummaryHO(objReportDTO));
                        //rd.SetDataSource(objReportBLL.GetSalaryReruisitionSummaryHO);

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

                if (rdoMonthlySalaryRequisitionHODetail.Checked == true)
                {

                    if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter  Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else if (txtMonth.Text == "")
                    {

                        string strMsg = "Please Enter  Month!!!";
                        MessageBox(strMsg);
                        txtMonth.Focus();
                        return;
                    }
                    else
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

                }


                if (rdoMonthlySalaryRequisitionHOMISCSFL.Checked == true)
                {
                    if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter  Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else if (txtMonth.Text == "")
                    {

                        string strMsg = "Please Enter  Month!!!";
                        MessageBox(strMsg);
                        txtMonth.Focus();
                        return;
                    }
                    else
                    {


                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();


                        processSalaryRequisitionHOMISC();

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

                        if (ddlEidTypeId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.EidTypeId = "";
                        }


                        if (ddlUnitId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.UnitId = "";

                        }


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlySalaryRequsitionSFLMISC.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.monthlySalaryRequisitionHOMISCSFL(objReportDTO));
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


                if (rdoBonusRequisitionHOMISCMAL.Checked == true)
                {

                    if (ddlEidTypeId.Text == " ")
                    {

                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }


                    else if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }


                    else
                    {

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();


                        processBonusRequisitionHOMISC();

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

                        if (ddlEidTypeId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.EidTypeId = "";
                        }


                        if (ddlUnitId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.UnitId = "";

                        }


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusRequsitionMALMISC.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataTable dt = new DataTable();
                        DataSet ds = new DataSet();

                        dt = (objReportBLL.GetHOEidBonusMiscReqSummary(objReportDTO));             
                        rd.SetDataSource(dt);
                        //DataSet ds = new DataSet();

                        //ds = (objReportBLL.bonusRequisitionHOMISCMAL(objReportDTO));
                        //rd.SetDataSource(ds);
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


                if (rdoBonusRequisitionHOMISCSFL.Checked == true)
                {

                    if (ddlEidTypeId.Text == " ")
                    {

                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }


                    else if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }


                    else
                    {
                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();


                        processBonusRequisitionHOMISC();

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

                        if (ddlEidTypeId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.EidTypeId = "";
                        }



                        if (ddlUnitId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.UnitId = "";

                        }


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusRequsitionSFLMISC.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.bonusRequisitionHOMISCSFL(objReportDTO));
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

                if (rdoHalfSalaryRequisitionHOMISCSFL.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    processHalfSalaryRequisitionHOMISC();

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSalaryRequsitionSFLMISC.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.halfSalaryRequisitionHOMISCSFL(objReportDTO));
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


                if (rdoHalfSalaryRequisitionHOMISCMAL.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    processHalfSalaryRequisitionHOMISC();

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSalaryRequsitionMALMISC.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.halfSalaryRequisitionHOMISCMAL(objReportDTO));
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



                if (rdoMonthlySalaryRequisitionHOMISCMAL.Checked == true)
                {

                    if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter  Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else if (txtMonth.Text == "")
                    {

                        string strMsg = "Please Enter  Month!!!";
                        MessageBox(strMsg);
                        txtMonth.Focus();
                        return;
                    }
                    else
                    {

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();


                        processSalaryRequisitionHOMISC();

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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlySalaryRequsitionMALMISC.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        dt = (objReportBLL.GetSalaryMiscReqSummary(objReportDTO));
                        rd.SetDataSource(dt);
                        //ds = (objReportBLL.monthlySalaryRequisitionHOMISCMAL(objReportDTO));
                        //rd.SetDataSource(ds);
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


                if (rdoMonthlySalaryRequisitionHOMISCDetail.Checked == true)
                {

                    if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter  Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else if (txtMonth.Text == "")
                    {

                        string strMsg = "Please Enter  Month!!!";
                        MessageBox(strMsg);
                        txtMonth.Focus();
                        return;
                    }
                    else
                    {

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();


                        processSalaryRequisitionHOMISCDetail();

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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlySalaryRequsitionHOMISCDetail.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.monthlySalaryRequisitionHOMISCDetail(objReportDTO));
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


                if (rdoMonthlyCashRequisitionDetail.Checked == true)
                {

                    if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter  Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else if (txtMonth.Text == "")
                    {

                        string strMsg = "Please Enter  Month!!!";
                        MessageBox(strMsg);
                        txtMonth.Focus();
                        return;
                    }
                    else
                    {
                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();


                        processSalaryRequisitionCashDetail();

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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyCashRequisitionDetail.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.monthlyCashRequisitionDetail(objReportDTO));
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
                if (rdoMonthlyCashRequisitionSFL.Checked == true)
                {
                    if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter  Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else if (txtMonth.Text == "")
                    {

                        string strMsg = "Please Enter  Month!!!";
                        MessageBox(strMsg);
                        txtMonth.Focus();
                        return;
                    }
                    else
                    {


                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        processMonthlyCashRequisition();

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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyCashRequisitionSFL.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.monthlyCashRequisitionSFL(objReportDTO));
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


                if (rdoBonusCashRequisitionSFL.Checked == true)
                {

                    if (ddlEidTypeId.Text == " ")
                    {

                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }


                    else if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }


                    else
                    {

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        processBonusCashRequisitionHO();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.Year = txtYear.Text;


                        if (ddlSectionId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.SectionId = "";
                        }

                        if (ddlEidTypeId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.EidTypeId = "";
                        }




                        if (ddlUnitId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.UnitId = "";

                        }


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusCashRequisitionSFL.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.bonusCashRequisitionSFL(objReportDTO));
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
                if (rdoBonusCashRequisitionDirectorMAL.Checked == true)
                {
                    if (ddlEidTypeId.Text == " ")
                    {
                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }
                    else if (txtYear.Text == "")
                    {
                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else
                    {

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        // processBonusCashReqDirector();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.Year = txtYear.Text;
                        if (ddlSectionId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.SectionId = "";
                        }

                        if (ddlEidTypeId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.EidTypeId = "";
                        }
                        if (ddlUnitId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.UnitId = "";

                        }
                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusCashRequisitionDirector.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();

                        // ds = (objReportBLL.bonusCashRequisitionDirector(objReportDTO));
                        dt = (objReportBLL.GetEidBonusDirectorCashReq(objReportDTO));

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
                }

                if (rdoBonusCashRequisitionMAL.Checked == true)
                {
                    if (ddlEidTypeId.Text == " ")
                    {

                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }


                    else if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }


                    else
                    {

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        processBonusCashRequisitionHO();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.Year = txtYear.Text;


                        if (ddlSectionId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.SectionId = "";
                        }

                        if (ddlEidTypeId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                        }
                        else
                        {

                            objReportDTO.EidTypeId = "";
                        }




                        if (ddlUnitId.SelectedValue.ToString() != " ")
                        {
                            objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                        }
                        else
                        {
                            objReportDTO.UnitId = "";

                        }


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusCashRequisitionMAL.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.bonusCashRequisitionMAL(objReportDTO));
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




                if (rdoMonthlyCashRequisitionMAL.Checked == true)
                {

                    if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter  Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }
                    else if (txtMonth.Text == "")
                    {

                        string strMsg = "Please Enter  Month!!!";
                        MessageBox(strMsg);
                        txtMonth.Focus();
                        return;
                    }
                    else
                    {

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        processMonthlyCashRequisition();

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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyCashRequisitionMAL.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.monthlyCashRequisitionMAL(objReportDTO));
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
                        reportMaster();
                        //ReportFormatMaster();
                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();


                        //string strPath = Path.Combine(Server.MapPath("~/Reports/RptTaxStatementSummary.rpt"));
                        //this.Context.Session["strReportPath"] = strPath;
                        //rd.Load(strPath);
                        //DataSet ds = new DataSet();
                        //rd.SetDataSource(objReportBLL.GetTaxStatementSummary(objReportDTO));
                        //rd.SetDatabaseLogon("erp", "erp");
                        //CrystalReportViewer1.ReportSource = rd;
                        //CrystalReportViewer1.DataBind();
                        //ReportFormatMaster();
                        //this.CrystalReportViewer1.Dispose();
                        //this.CrystalReportViewer1 = null;
                        //rd.Dispose();
                        //rd.Close();
                        //GC.Collect();
                        //GC.WaitForPendingFinalizers();



                        /*
                        processYearlyTaxStatement();
                        processYearlyTaxSummery();

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

                        //string strPath = Path.Combine(Server.MapPath("~/Reports/rptYearlyTaxStatementSummery.rpt"));
                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptTaxStatementSummary.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();
                        //Asad
                        //ds = (objReportBLL.YearlyTaxSummerySheet(objReportDTO));
                        //New: GetTaxStatementSummary
                        ds = (objReportBLL.YearlyTaxSummerySheet(objReportDTO));

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
                        */
                   // }
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


                    //else
                    //{

                    //Commented
                    //processYearlyTaxStatement();
                    //processYearlyTaxSummeryFB();
                    
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

                        //string strPath = Path.Combine(Server.MapPath("~/Reports/rptYearlyTaxStatementSummeryFB.rpt"));
                        //this.Context.Session["strReportPath"] = strPath;
                        //rd.Load(strPath);
                        //DataSet ds = new DataSet();

                        //ds = (objReportBLL.YearlyTaxSummerySheetFB(objReportDTO));
                        //GetTaxStatement

                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptYearlyTaxStatementSummeryFB.rpt"));
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetTaxStatementDetail(objReportDTO));
                        //rd.SetDataSource(ds);

                        rd.SetDatabaseLogon("erp", "erp");
                        CrystalReportViewer1.ReportSource = rd;
                        CrystalReportViewer1.DataBind();
                        
                        reportMaster();
                        //ReportFormatMaster();

                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    //}


                }



                if (rdoMonthlyArrearInformation.Checked == true)
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


                if (rdoArrearRequisition.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processArrearRequsition();


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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearRequisition.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.arrearRequisition(objReportDTO));
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


                if (rdoHalfSalaryRequisitionSFL.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    processHalfSalaryRequisitionHO();

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSalaryRequsitionSFL.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.halfSalaryRequisitionSFL(objReportDTO));
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

                if (rdoHalfSalaryRequisitionMAL.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    processHalfSalaryRequisitionHO();

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSalaryRequsitionMAL.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.halfSalaryRequisitionMAL(objReportDTO));
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


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;
                    objReportDTO.UpdateBy = strEmployeeId;

                    objReportDTO.FromDate = dtpFromDate.Text;
                    objReportDTO.ToDate = dtpToDate.Text;


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


                if (rdoEmployeJoiningResignInfo.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

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


                if (rdoMonthlyAttendenceSheet.Checked == true)
                {
                    if (txtEmpId.Text == string.Empty)
                    {
                        MessageBox("Enter Employee Id");
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

                    ////COMMENTED: 17.07.2021
                    //objReportBLL.PrepareJobCard(objReportDTO);

                    //new: RptJobCardNew
                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptJobCard.rpt"));
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
                    reportMaster();
                    // ReportFormatMaster();

                    this.CrystalReportViewer1.Dispose();
                    this.CrystalReportViewer1 = null;
                    rd.Dispose();
                    rd.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    // old
                    //ReportDTO objReportDTO = new ReportDTO();
                    //ReportBLL objReportBLL = new ReportBLL();

                    ////processMonthlyAttendenceSheet();


                    //objReportDTO.HeadOfficeId = strHeadOfficeId;
                    //objReportDTO.BranchOfficeId = strBranchOfficeId;
                    //objReportDTO.EmployeeId = txtEmpId.Text;
                    //objReportDTO.UpdateBy = strEmployeeId;


                    //objReportDTO.FromDate = dtpFromDate.Text;
                    //objReportDTO.ToDate = dtpToDate.Text;
                    //objReportDTO.CardNo = txtCardNo.Text;



                    //if (ddlSectionId.SelectedValue.ToString() != " ")
                    //{
                    //    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    //}
                    //else
                    //{

                    //    objReportDTO.SectionId = "";
                    //}


                    //if (ddlUnitId.SelectedValue.ToString() != " ")
                    //{
                    //    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    //}
                    //else
                    //{
                    //    objReportDTO.UnitId = "";

                    //}



                    //string strPath = Path.Combine(Server.MapPath("~/Reports/rpDailyAttendenceSheetMonthlySP.rpt"));
                    //this.Context.Session["strReportPath"] = strPath;
                    //rd.Load(strPath);
                    //rd.SetDataSource(objReportBLL.rptMonthlyAttendenceSheetSP(objReportDTO));


                    //rd.SetDatabaseLogon("erp", "erp");
                    //CrystalReportViewer1.ReportSource = rd;
                    //CrystalReportViewer1.DataBind();

                    //ReportFormatMaster();


                    //this.CrystalReportViewer1.Dispose();
                    //this.CrystalReportViewer1 = null;
                    //rd.Dispose();
                    //rd.Close();
                    //GC.Collect();
                    //GC.WaitForPendingFinalizers();


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


                if (rdoMonthlyAttendenceSheetSummery.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();
                    processMonthlyAttendenceSummerySheet();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.UpdateBy = strEmployeeId;


                    objReportDTO.FromDate = dtpFromDate.Text;
                    objReportDTO.ToDate = dtpToDate.Text;
                    objReportDTO.CardNo = txtCardNo.Text;

                    if (ddlEarlyDepurtureLimit.SelectedItem.Value == "")
                        objReportDTO.EarlyDepurtureLimit = 0;
                    else
                        objReportDTO.EarlyDepurtureLimit = Convert.ToInt32(ddlEarlyDepurtureLimit.SelectedItem.Value);

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


                if (rdoMonthlyAttendenceSheetAll.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    if(strHeadOfficeId =="441")
                    {

                        processMonthlyAttendenceSheetAll();
                    }
                    else
                    {
                        processMonthlyAttendenceSheetHO();

                    }
                   


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
                    else if (ddlSectionId.Text == " ")
                    {
                        string strMsg = "Please Select Section Name!!!";
                        MessageBox(strMsg);
                        ddlSectionId.Focus();
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

                        
                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalAllHO.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.rdoIncrementProposalHOAll(objReportDTO));
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
                if (rdoIncrementSummaryAll.Checked == true)
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

                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSummeryAllHO.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();

                        ds = (objReportBLL.IncrementSummaryAll(objReportDTO));
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
                //.....
                if (rdoIncrementHistory.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    if (dtpFromDate.Text == "")
                    {
                        string strMsg = "Please Enter From Date";
                        MessageBox(strMsg);
                        dtpFromDate.Focus();
                        return;
                    }
                    if (dtpToDate.Text == "")
                    {
                        string strMsg = "Please Enter To Date";
                        MessageBox(strMsg);
                        dtpToDate.Focus();
                        return;
                    }
                    else
                    {
                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;
                        objReportDTO.FromDate = dtpFromDate.Text;
                        objReportDTO.ToDate = dtpToDate.Text;
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
                        string strMsg = objReportBLL.GetCurrectDateRanges(objReportDTO);
                        if (strMsg != "ok")
                        {
                            MessageBox(strMsg);
                            return;
                        }
                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementHistory.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();

                        dt = (objReportBLL.GetIncrementHistory(objReportDTO));
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
                }

                if (rdoAttendencePresentSummerySheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processAttendencePresentSummerySheet();



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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptAttendenceSummerySheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.attendencePresentSummerySheet(objReportDTO));


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


                    if (dtpFromDate.Text == "" && dtpToDate.Text == "")
                    {

                        string strMsg = "Please Enter From Date and To Date!!!";
                        MessageBox(strMsg);
                        return;

                    }
                    else if(txtEmpId.Text == "")
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


                        objReportDTO.FromDate = dtpFromDate.Text;
                        objReportDTO.ToDate = dtpToDate.Text;


                        objReportDTO.FromMonthId = dtpFromDate.Text;
                        objReportDTO.ToMonthId = dtpToDate.Text;



                        objReportDTO.EmployeeId = txtEmpId.Text;
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



                    this.CrystalReportViewer1.Dispose();
                    this.CrystalReportViewer1 = null;
                    rd.Dispose();
                    rd.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

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


#endregion
        #region "Function"

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

        public void processMonthlyAttendenceSummerySheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;
            objReportDTO.EarlyDepurtureTime = txtEarlyDepurtureTime.Text;

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
        public void processTaxSummeryDetail()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.Year = txtYear.Text;


            if (ddlFromMonthId.SelectedValue.ToString() != " ")
            {
                objReportDTO.FromMonth = ddlFromMonthId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.FromMonth = "";
            }



            if (ddlToMonthId.SelectedValue.ToString() != " ")
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





            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processTaxSummeryDetail(objReportDTO);
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
           // MessageBox(strMsg);




        }
        public void processBonusCashRequisitionHO()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.EidTypeId = "";

            }



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processBonusCashRequisitionHO(objReportDTO);
            //MessageBox(strMsg);




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
            //MessageBox(strMsg);




        }
        public void processBonusRequisitionHOMISC()
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

            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.EidTypeId = "";
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

            string strMsg = objReportBLL.processBonusRequisitionHOMISC(objReportDTO);
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
            //MessageBox(strMsg);




        }
        public void processBonusRequisitionHO()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.Year = txtYear.Text;
            

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.SectionId = "";
            }

            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.EidTypeId = "";
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

            string strMsg = objReportBLL.processBonusRequisitionHO(objReportDTO);
           // MessageBox(strMsg);




        }
        public void processHalfSalaryRequisitionHOMISC()
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

            string strMsg = objReportBLL.processHalfSalaryRequisitionHOMISC(objReportDTO);
            //MessageBox(strMsg);




        }

        public void processHalfSalaryRequisitionHO()
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

            string strMsg = objReportBLL.processHalfSalaryRequisitionHO(objReportDTO);
            //MessageBox(strMsg);




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
            MessageBox(strMsg);




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

        public void selectBonusBankProcedure()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();



            objReportDTO.Year = txtYear.Text;


            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.EidTypeId = "";
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


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.selectBonusBankProcedure(objReportDTO);
            MessageBox(strMsg);




        }

        public void processAttendencePresentSummerySheet()
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

            string strMsg = objReportBLL.processAttendencePresentSummerySheet(objReportDTO);




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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void processMonthlyAttendenceSheetHO()
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

            string strMsg = objReportBLL.processMonthlyAttendenceSheetHO(objReportDTO);
            MessageBox(strMsg);




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

        public void bonusCashSheetPro()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();



            objReportDTO.Year = txtYear.Text;


            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.EidTypeId = "";
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


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.bonusCashSheetPro(objReportDTO);
            MessageBox(strMsg);




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


                //Noting to do


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

                chkPDF.AutoPostBack = true; 
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
                chkExcel.AutoPostBack = true; 
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
                chkWord.AutoPostBack = true; 
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
                chkText.AutoPostBack = true; 
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
                chkCSV.AutoPostBack = true; 
                chkPDF.Checked = false;
                chkWord.Checked = false;
                chkExcel.Checked = false;
                chkText.Checked = false;
            }
        }


        #endregion

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
         (CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet_staff");
                Response.End();
                CrystalReportViewer1.RefreshReport();
            }
        }
    }
}