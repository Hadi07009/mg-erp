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

namespace SINHA.MEDLAR.ERP.UI.Reports
{
    public partial class ReportBasic : System.Web.UI.Page
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


                loadSession();
                getUnitId();
                getEmployeeTypeId();
                getSectionId();
                getOccurenceTypeId();
                //getRequisitionId();
                getEidTypeId();
                getOfficeName();
                //getPermission();

            }
            if (IsPostBack)
            {
                loadSession();

            }




        }

        #region "Load ComboBox"

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


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        public void getPermission()
        {


            string strEmpId = strEmployeeId;

            if ((strEmpId == "121") || (strEmpId == "100") || (strEmpId == "995") || (strEmpId == "992") || (strEmpId == "997") || (strEmpId == "103"))
            {
                rdoMonthlySalaryStatement.Visible = true;

            }
            else
            {
                rdoMonthlySalaryStatement.Visible = false;
            }

            if ((strEmpId == "121") || (strEmpId == "100") || (strEmpId == "995") || (strEmpId == "992") || (strEmpId == "997") || (strEmpId == "103"))
            {
                rdoMonthlyStatementSP.Visible = true;
            }
            else
            {
                rdoMonthlyStatementSP.Visible = false;
            }

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
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "report_worker");
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
                rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, "report_worker");
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
                Response.ContentType = "text/richtext";
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


        #region "Report View Functionality"
        protected void btnView_Click(object sender, EventArgs e)
        {

            try
            {
                if (!IsValidateRadio())
                {
                    //MessageBox("Please Select One Report");
                    return;
                }

                if (rdoEmployeeBasicInformation.Checked == true)
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

                    if (ddlEmployeeTypeId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.EmployeeTypeId = "";
                    }


                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitId = "";

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


                if (rdoEmployeeInsurenceInfo.Checked == true)
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

                    if (ddlEmployeeTypeId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.EmployeeTypeId = "";
                    }


                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitId = "";

                    }
                    objReportDTO.FromDate = dtpFromDate.Text;
                    objReportDTO.ToDate = dtpToDate.Text;



                    string strPath = Path.Combine(Server.MapPath("~/Reports/EmployeeBasicInfoForInsurence.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.employeeBasicInformaitonForInsurence(objReportDTO));
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

                if (rdoEmployeeSalaryRange.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;

                    objReportDTO.UpdateBy = strEmployeeId;
                    objReportDTO.SalaryRange = txtSalaryRange.Text;


                    if (ddlSectionId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.SectionId = "";
                    }

                    if (ddlEmployeeTypeId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.EmployeeTypeId = "";
                    }


                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitId = "";

                    }




                    string strPath = Path.Combine(Server.MapPath("~/Reports/EmployeeSalaryRange.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.employeeSalaryRange(objReportDTO));
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
                    if (ddlUnitGroupId.SelectedValue.ToString() != "")
                    {
                        objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitGroupId = "";
                    }


                   


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeListNewWorker.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    
                    DataTable dt= new DataTable();
                    dt = (objReportBLL.NewEmployeeListJoiningBasis(objReportDTO));
                    rd.SetDataSource(dt);
                    //DataSet ds = new DataSet();
                    //ds = (objReportBLL.newEmployeeListWorker(objReportDTO));
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
                if (rdoNewEmpListBeforeSalarySet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    string strMsg = "";


                    if (dtpFromDate.Text == "")
                    {
                        strMsg = "Please Enter From Date";
                        ddlEmployeeTypeId.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    if (dtpToDate.Text == "")
                    {
                        strMsg = "Please Enter Todate";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
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

                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmpListBeforeSalarySet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataTable dt = new DataTable();

                    dt = (objReportBLL.GetEmpListBeforeSalarySet(objReportDTO));
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

                if (rdoWorkerSalaryRange.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processWorkerSalaryRange();


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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRangeWorker.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.workerSalaryRange(objReportDTO));
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

                if (rdoWorkerSalaryRangeSummery.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processWorkerSalaryRange();
                    processWorkerSalaryRangeSummery();

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRangeWorkerSummery.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.workerSalaryRangeSummery(objReportDTO));
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



                //if (rdoEmployeeDetailInformation.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                //    objReportDTO.BranchOfficeId = strBranchOfficeId;
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





                //    string strPath = Path.Combine(Server.MapPath("~/Reports/EmployeeDetailInformation.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.employeeDetailInformaiton(objReportDTO));


                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();



                //    ReportFormatMaster();

                //}


                if (rdoMonthlySalarySheetStaff.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;



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



                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;




                    if (strHeadOfficeId == "331" && strBranchOfficeId == "110")
                    {
                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaffForBP.rpt"));
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.SalarySheetStaff(objReportDTO));

                    }
                    else
                    {
                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaff.rpt"));
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.SalarySheetStaff(objReportDTO));
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



                if (rdoMonthlyPaySlipStaff.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

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



                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

                    if (strHeadOfficeId == "331" && strBranchOfficeId == "110")
                    {

                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipStaffForBP.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.paySlipStaff(objReportDTO));

                    }
                    else
                    {

                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipStaff.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.paySlipStaff(objReportDTO));
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


                if (rdoWorkerTransferSheet.Checked == true)
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



                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptTransferSheetWorker.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.workerTransferSheet(objReportDTO));


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




                if (rdoMonthlySalarySheetStaffMisc.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

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



                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaffMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalarySheetStaffMisc(objReportDTO));


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

                if (rdoMonthlyPaySlipStaffMisc.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

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



                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipStaffMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlyPaySlipStaffMisc(objReportDTO));


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


                if (rdoMonthlyHalfSheetStaff.Checked == true)
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


                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSheetStaffMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.halfSheetStaff(objReportDTO));


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


                if (rdoMonthlySalarySheetWorker.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;


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


                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;


                    if (strHeadOfficeId == "331" && strBranchOfficeId == "110")
                    {

                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetWorkerForBP.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.salarySheetWorker(objReportDTO));


                    }
                    else
                    {

                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetWorker.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.salarySheetWorker(objReportDTO));

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

                if (rdoMonthlyPaySlipWorker.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

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



                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

                    if (strHeadOfficeId == "331" && strBranchOfficeId == "110")
                    {

                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipWorkerForBP.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.paySlipWorker(objReportDTO));

                    }
                    else
                    {

                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipWorker.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.paySlipWorker(objReportDTO));

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


                if (rdoMonthlyWorkingDayList.Checked == true)
                {


                    processMonthlyWorkingDayList();

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





                if (rdoMonthlyHalfSheetWorker.Checked == true)
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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSheetWorker.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.halfSheetWorker(objReportDTO));


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
                if (rdoEmployeeListByGrade.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmpListByGrade.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.EmployeeListByGrade(objReportDTO));
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


                if (rdoMonthlyMiscSheetWorker.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    monthlyWorkerSalaryMisc();

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetWorkerMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.workerMiscSheet(objReportDTO));


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

                if (rdoMonthlyPaySlipStaff.Checked == true)
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



                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.paySlipStaff(objReportDTO));


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


                if (rdoMonthlyHalfSheetStaff.Checked == true)
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


                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSheetStaffMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.halfSheetStaff(objReportDTO));


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


                if (rdoMonthlySalarySummeryWorker.Checked == true)
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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetWorkerSummery.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalarySummeryWorker(objReportDTO));


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

                if (rdoIncrementProposalWorkerAboveOneYear.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.HeadOfficeId = strHeadOfficeId;
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



                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitId = "";

                    }


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerAboveOneYear.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.incrementProposalWorkerAboveOneYear(objReportDTO));


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


                if (rdoIncrementProposalWorkerBellowOneYear.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerBellowOneYear.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.incrementProposalWorkerBellowOneYear(objReportDTO));


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


                if (rdoIncrementProposalStaff.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

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



                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitId = "";

                    }


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.incrementProposalStaff(objReportDTO));


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
                    objReportDTO.UpdateBy = strEmployeeId;


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


                //if (rdoSalaryCertificate.Checked == true)
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


                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryCertificate.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    DataSet ds = new DataSet();

                //    ds = (objReportBLL.salaryCertificate(objReportDTO));
                //    rd.SetDataSource(ds);
                //    rd.SetDatabaseLogon("erp", "erp");
                //    CrystalReportViewer1.ReportSource = rd;
                //    CrystalReportViewer1.DataBind();




                //    ReportFormatMaster();

                //}

                if (rdoMonthlyTiffinSheetWorker.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptTiffinSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.monthlyTiffinSheetWorker(objReportDTO));
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

                if (rdoMonthlyTiffinSheetWorkerRequisition.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptTiffinRequisitionSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.monthlyTiffinSheetWorkerRequisition(objReportDTO));
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

                if (rdoMonthlySalaryRequisitionSheetWorker.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlySalaryRequisitionSheetWorker.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.monthlySalaryRequisitionSheetWorker(objReportDTO));
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


                if (rdoHalfSalarySheetRequisitionWorker.Checked == true)
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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfRequisitionSheetWorker.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.halfSalarySheetRequisitionWorker(objReportDTO));
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


                if (rdoEmployeeListHO.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;
                    objReportDTO.ToDate = dtpToDate.Text==string.Empty?null: dtpToDate.Text;


                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;

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

                    if (ddlUnitGroupId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitGroupId = "";

                    }



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeListWorker.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.employeeListWorker(objReportDTO));


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


                if (rdoMonthlyTiffinRequisition.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processTiffinRequisition();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptTiffinRequisition.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlyTiffinRequisition(objReportDTO));


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


                if (rdoMonthlyOverTimeSheetWorker.Checked == true)
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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptOverTimeSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlyOverTimeSheetWorker(objReportDTO));


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



                if (rdoMonthlyOverTimeRequisition.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processOverTimeRequisition();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptOverTimeRequisition.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlyOverTimeRequisition(objReportDTO));


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


                if (rdoMonthlySalaryRequisitionFactoryStaff.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processSalaryRequisitionFactoryStaff();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRequisitionFactoryStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalaryRequisitionFactoryStaff(objReportDTO));


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

                if (rdoMonthlyOtRequisition.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processMonthlyOTRequisition();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyOTRequisition.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlyOTRequisition(objReportDTO));


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


                if (rdoMonthlySalaryRequisitionFactoryStaffMisc.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processSalaryRequisitionFactoryStaffMisc();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRequisitionFactoryStaffMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalaryRequisitionFactoryStaffMisc(objReportDTO));


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

                if (rdoMonthlySalaryRequisitionWorker.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processSalaryRequisitionWoker();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRequisitionWorker.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalaryRequisitionWorker(objReportDTO));


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


                if (rdoLeaveSheetStaff.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    processLeaveStaff();

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptLeaveSheetStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.leaveSheetStaff(objReportDTO));


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



                if (rdoMonthlyAttendenceSheetAllWorker.Checked == true)
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



                if (rdoLeaveSheetStaffMisc.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    processLeaveStaffMisc();

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptLeaveSheetStaffMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.leaveSheetStaffMisc(objReportDTO));


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

                if (rdoLeaveSheetWorker.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    processLeaveWorker();

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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptLeaveSheetWorker.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.leaveSheetWorker(objReportDTO));


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


                if (rdoMonthlySalaryRequisition.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processSalaryRequisitionAll();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRequisitionAll.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalaryRequisition(objReportDTO));


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

                if (rdoIncrementProposalAuto.Checked == true)
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
                    if (txtMonth.Text == "")
                    {
                        string strMsg = "Please Enter Month!!!";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                   
                    objReportDTO.UpdateBy = strEmployeeId;
                    objReportDTO.IncrementAmount = txtExtraAmount.Text;
                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;
                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalAuto.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetIncrementProposalAuto(objReportDTO));

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

                if (rdoLeaveRequisitionStaff.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processLeaveRequisitionFactoryStaff();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptLeaveRequisitionStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.LeaveRequisitionStaff(objReportDTO));


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


                if (rdoLeaveRequisitionWorker.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processLeaveRequisitionFactoryWorker();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptLeaveRequisitionWorker.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.LeaveRequisitionWorker(objReportDTO));


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

                if (rdoLeaveRequisitionAll.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processLeaveRequisitionAll();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptLeaveRequisitionAll.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.leaveRequisitionAll(objReportDTO));


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



                if (rdoDailyAttendenceTopSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processAttendenceTopSheet();


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

                if (rptDailyAttendenceLateSheet.Checked == true)
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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAbsenceSheet.rpt"));
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

                if (rptMonthlyAttendenceAbsenceSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


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



                        string strPath = Path.Combine(Server.MapPath("~/Reports/rpMonthlyAttendenceClosingSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.DailyAttendenceClosingSheet(objReportDTO));


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

                if (rdoAllActiveEmployee.Checked == true)
                {


                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeTypeId = "";
                    objReportDTO.Year = txtYear.Text.Trim();
                    objReportDTO.Month = txtMonth.Text.Trim();
                    objReportDTO.UpdateBy = strEmployeeId;



                    //string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
                    //this.Context.Session["strReportPath"] = strPath;
                    //rd.Load(strPath);
                    //rd.SetDataSource(objReportBLL.GetWalletSheet(objReportDTO));

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptAllEmployeeActiveList.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetActiveEmployeeList(objReportDTO));


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


                        objReportDTO.FromDate = dtpFromDate.Text;
                        objReportDTO.ToDate = dtpToDate.Text;

                        objReportDTO.CardNo = txtCardNo.Text;
                        objReportDTO.EmployeeId = txtEmpId.Text;

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


                if (rdoEmployeeMaleFemaleInfo.Checked == true)
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







                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeGenderInfo.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.EmployeeMaleFemaleInfo(objReportDTO));


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



                if (rdoMonthlySalaryApproveSheet.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();
                    
                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.UpdateBy = strEmployeeId;


                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;
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

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryApproveSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.rptSalaryApproveSheet(objReportDTO));

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

                    if(txtEmpId.Text == string.Empty)
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

                    //COMMENTED: 17.07.2021
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
                     //rd.SetDataSource(objReportBLL.rptMonthlyAttendenceSheetWorker(objReportDTO));

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

                }



                //if (rdoMonthlyAttendenceSheet.Checked == true)
                //{

                //    ReportDTO objReportDTO = new ReportDTO();
                //    ReportBLL objReportBLL = new ReportBLL();

                //    processMonthlyAttendenceSheetWorker();

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
                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rpDailyAttendenceSheetMonthlyWorker.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.rptMonthlyAttendenceSheetWorker(objReportDTO));
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


                if (rdoBonusProposalForBellow6Month.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    if (ddlEidTypeId.Text == " ")
                    {

                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }
                    else if (txtYear.Text == " ")
                    {

                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }

                    else
                    {


                        processBonusProposalWorker();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.Year = txtYear.Text;


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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusProposalWorkerBellowSixMonth.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.BonusProposalForBellow6Month(objReportDTO));


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


                if (rdoBonusProposalForBellow1Year.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    if (ddlEidTypeId.Text == " ")
                    {

                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }
                    else if (txtYear.Text == " ")
                    {

                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }

                    else
                    {



                        processBonusProposalWorker();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.Year = txtYear.Text;


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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusProposalWorkerBellowOneYear.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.BonusProposalForBellowOneYear(objReportDTO));


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

                if (rdoBonusSheetForWorker12Month.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    if (ddlEidTypeId.Text == " ")
                    {

                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }
                    else if (txtYear.Text == " ")
                    {

                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }

                    else
                    {



                        processBonusProposalWorker11to12Month();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.Year = txtYear.Text;


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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusProposalWorker11to12Month.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.BonusProposalWorker11to12Month(objReportDTO));


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

                if (rdoBonusSheetForStaff12Month.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    if (ddlEidTypeId.Text == " ")
                    {

                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }
                    else if (txtYear.Text == " ")
                    {

                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }

                    else
                    {



                        processBonusProposalStaff11to12Month();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.Year = txtYear.Text;


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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusProposalStaff11to12Month.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rdoBonusProposalForStaff11to12Month(objReportDTO));


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



                if (rdoBonusProposalForBellow6MonthForStaff.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    if (ddlEidTypeId.Text == " ")
                    {

                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }
                    else if (txtYear.Text == " ")
                    {

                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }

                    else
                    {



                        ProcessBonusProposalStaff();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.Year = txtYear.Text;


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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusProposalStaffBellowSixMonth.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rdoBonusProposalForBellow6MonthForStaff(objReportDTO));


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


                if (rdoBonusProposalForStaffBellow1Year.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    if (ddlEidTypeId.Text == " ")
                    {

                        string strMsg = "Please Select Eid Name!!!";
                        MessageBox(strMsg);
                        ddlEidTypeId.Focus();
                        return;
                    }
                    else if (txtYear.Text == " ")
                    {

                        string strMsg = "Please Enter Eid Year!!!";
                        MessageBox(strMsg);
                        txtYear.Focus();
                        return;
                    }

                    else
                    {



                        ProcessBonusProposalStaff();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.Year = txtYear.Text;


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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusProposalStaffBellowOneYear.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rdoBonusProposalForStaffBellow1Year(objReportDTO));


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


                if (rdoSalaryRangeInformation.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;

                    objReportDTO.SalaryRange = txtSalaryRange.Text;

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptStaffSalaryRangeInformation.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.SalaryRangeInformation(objReportDTO));


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

                if (rdoMonthlyStatementSP.Checked == true)
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
                        //old
                        //rd.SetDataSource(objReportBLL.MonthlySalaryStatement(objReportDTO));
                        //new
                        rd.SetDataSource(objReportBLL.GetMonthlyStatement(objReportDTO));


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
                                                
                        ReportFormatMaster();
                        
                        this.CrystalReportViewer1.Dispose();
                        this.CrystalReportViewer1 = null;
                        rd.Dispose();
                        rd.Close();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }

                if (rdoIncrementSummeryStatement.Checked == true)
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

                        processYearlyWorkerIncrementStatement();

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;







                        objReportDTO.Year = txtYear.Text;





                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSheetWorkerSummery.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rdoIncrementSummeryStatement(objReportDTO));


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

                if (rdoIncSummeryStatement.Checked == true)
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

                        processYearlyWorkerIncrementStatement();
                        processYearlyWorkerIncrementSummeryStatement();

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;







                        objReportDTO.Year = txtYear.Text;





                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSheetWorkerSummeryStatement.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rdoIncSummeryStatement(objReportDTO));


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


                if (rdoIncSummeryStatementOneYear.Checked == true)
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

                        processYearlyWorkerIncrementStatement();
                        processYearlyWorkerIncrementSummeryStatement();
                        processYearlyWorkerIncSummeryStatement();

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;







                        objReportDTO.Year = txtYear.Text;





                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSumStatement.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rdoIncSummeryStatementOneYear(objReportDTO));


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


                if (rdoMonthlyRevenueRequisition.Checked == true)
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



                        monthlySalaryRevenue();



                        objReportDTO.Year = txtYear.Text;
                        objReportDTO.Month = txtMonth.Text;




                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptRevenueRequisitionForBP.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rptmonthlySalaryRevenue(objReportDTO));


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


                if (rdoLateSheetSummery.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    lateSheetSummery();

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






                if (rdoMonthlyIncrementList.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;

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


                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSheetMonthlyWorker.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlyIncrementList(objReportDTO));


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



                if (rdoSalaryInfoByGrade.Checked == true)
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


                        processSalaryByGrade();

                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;
                        objReportDTO.Year = txtYear.Text;
                        objReportDTO.Month = txtMonth.Text;


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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeSalaryInfoByGrade.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rdoSalaryInfoByGrade(objReportDTO));


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


                if (rdoSalarySummeryInfoByGrade.Checked == true)
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

                        processSalaryByGrade();


                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;

                        objReportDTO.Year = txtYear.Text;
                        objReportDTO.Month = txtMonth.Text;


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


                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySummeryByGrade.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rdoSalarySummeryInfoByGrade(objReportDTO));


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


                if (rdoGradeAdjustIncrementYearly.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    if (ddlUnitGroupId.SelectedItem.Value == "")
                    {
                        if (ddlUnitId.Text == " ")
                        {
                            string strMsg = "Please Select Unit Name!!!";
                            MessageBox(strMsg);
                            ddlUnitId.Focus();
                            return;
                        }
                        if (ddlSectionId.Text == " ")
                        {
                            string strMsg = "Please Select Section Name!!!";
                            MessageBox(strMsg);
                            ddlUnitId.Focus();
                            return;
                        }
                    }
                    else
                    {
                        if (ddlUnitId.Text != " ")
                        {
                            if (ddlSectionId.Text == " ")
                            {
                                string strMsg = "Please Select Section Name!!!";
                                MessageBox(strMsg);
                                ddlUnitId.Focus();
                                return;
                            }
                        }
                    }
                    if (txtYear.Text == "")
                    {

                        string strMsg = "Please Enter Year!!!";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    if (txtMonth.Text == "")
                    {
                        string strMsg = "Please Enter Month!!!";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    //processGradeAdjustIncrementYearly();
                    ProcessSalaryGradeAdjustment();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;
                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;                                        
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;
                    if (ddlUnitGroupId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitGroupId = "";
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

                    string strPath = string.Empty;

                    if (chkIncrementYn.Checked == true)
                        strPath = Path.Combine(Server.MapPath("~/Reports/rptGradeAdjustSheetYearly.rpt"));
                    else
                        strPath = Path.Combine(Server.MapPath("~/Reports/rptGradeAdjustSheetYearlyWithoutIncr.rpt"));

                    //VEW_SALARY_GRADE_ADJUST_YEARLY
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetSalaryGradeAdjustment_W(objReportDTO));

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


                    /*
                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();
                    if (txtYear.Text == "")
                    {
                        string strMsg = "Please Enter Year!!!";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    if (ddlUnitId.Text == " ")
                    {
                        string strMsg = "Please Select Unit Name!!!";
                        ddlUnitId.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    if (ddlSectionId.Text == " ")
                    {
                        string strMsg = "Please Select Section Name!!!";
                        ddlSectionId.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    else
                    {
                        processGradeAdjustIncrementYearly();
                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.UpdateBy = strEmployeeId;
                        objReportDTO.Year = txtYear.Text;
                        objReportDTO.Month = txtMonth.Text;
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
                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptGradeAdjustSheetYearly.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rdoGradeAdjustIncrementYearly(objReportDTO));

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
                    */
                }

                if (rdoSalaryAdjustSumAccordingGazette.Checked == true)
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

                    if (txtMonth.Text == "")
                    {
                        string strMsg = "Please Enter Month!!!";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }

                    if (ddlUnitGroupId.SelectedValue.ToString() != " ")
                        objReportDTO.UnitGroupId = ddlUnitGroupId.Text;
                    else
                        objReportDTO.UnitGroupId = "";

                    if (chkIncrementYn.Checked == true)
                        objReportDTO.IncrementYn = "Y";
                    else
                        objReportDTO.IncrementYn = "N";

                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;
                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    string strPath = string.Empty;

                    if(chkIncrementYn.Checked == true)
                        strPath = Path.Combine(Server.MapPath("~/Reports/RptSalaryAdjustmentSummary.rpt"));
                    else
                        strPath = Path.Combine(Server.MapPath("~/Reports/RptSalaryAdjustmentSummaryWithoutIncr.rpt"));

                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.SalaryAdjustSummaryAccordingToGazette(objReportDTO));

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


                if (rdoGradeAdjustIncrementRequisitionYearly.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();
                   
                    if (ddlSectionId.Text != " ")
                    {
                        if (ddlUnitId.Text == " ")
                        {
                            string strMsg = "Please Select Unit Name!!!";
                            MessageBox(strMsg);
                            ddlUnitId.Focus();
                            return;
                        }
                    }

                    if (txtYear.Text == "")
                    {
                        string strMsg = "Please Enter Year!!!";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                    if (txtMonth.Text == "")
                    {
                        string strMsg = "Please Enter Month!!!";
                        txtYear.Focus();
                        MessageBox(strMsg);
                        return;
                    }

                    if (chkIncrementYn.Checked == true)
                        objReportDTO.IncrementYn = "Y";
                    else
                        objReportDTO.IncrementYn = "N";

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;
                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;
                    objReportDTO.EmployeeId = txtEmpId.Text;
                    objReportDTO.CardNo = txtCardNo.Text;

                    if (ddlUnitGroupId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitGroupId = "";
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

                    string strPath = string.Empty;
                    if(chkIncrementYn.Checked == true)
                        strPath = Path.Combine(Server.MapPath("~/Reports/RptSalaryAdjustmentRequisition.rpt"));
                    else
                        strPath = Path.Combine(Server.MapPath("~/Reports/RptSalaryAdjustmentRequisitionWithoutIncr.rpt"));

                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.SalaryAdjustRequisitionAccordingToGazette(objReportDTO));

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
                   
                    //ReportDTO objReportDTO = new ReportDTO();
                    //ReportBLL objReportBLL = new ReportBLL();
                    //if (txtYear.Text == "")
                    //{
                    //    string strMsg = "Please Enter Year!!!";
                    //    txtYear.Focus();
                    //    MessageBox(strMsg);
                    //    return;
                    //}
                    //if (ddlUnitId.Text == " ")
                    //{
                    //    string strMsg = "Please Select Unit Name!!!";
                    //    ddlUnitId.Focus();
                    //    MessageBox(strMsg);
                    //    return;
                    //}
                    //else
                    //{
                    //    processGradeAdjustIncrementRequiYearly();
                    //    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    //    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    //    objReportDTO.UpdateBy = strEmployeeId;
                    //    objReportDTO.Year = txtYear.Text;
                    //    objReportDTO.Month = txtMonth.Text;
                    //    objReportDTO.EmployeeId = txtEmpId.Text;
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
                    //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptGradeAdjustIncrementRequisitionYearly.rpt"));
                    //    this.Context.Session["strReportPath"] = strPath;
                    //    rd.Load(strPath);
                    //    rd.SetDataSource(objReportBLL.rdoGradeAdjustIncrementRequisitionYearly(objReportDTO));
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



                if (rdoMonthlySalaryRequisitionFactoryStaffGross.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    processSalaryRequisitionFactoryStaffGross();


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



                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRequisitionFactoryStaffGross.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.monthlySalaryRequisitionFactoryStaffGross(objReportDTO));


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

                if (rdoMonthlySalaryRequisitionWorkerGross.Checked == true)
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
                        processSalaryRequisitionWokerGross();


                        //   objReportDTO.HeadOfficeId = strHeadOfficeId;
                        //  objReportDTO.BranchOfficeId = strBranchOfficeId;
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



                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptGrossSummeryWorkerSal.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.monthlySalaryRequisitionWorkerGross(objReportDTO));


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
                }


                if (rptDailyAttendenceSheetInOut.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();




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


                if (rdoEmployeeListAboveOneYear.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();



                    if (dtpLimitDate.Text == "")
                    {

                        string strMsg = "Please Enter Limit Date!!!";
                        MessageBox(strMsg);
                        return;
                    }
                    else
                    {

                        processEmployeeYearList();


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



                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeYearList.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.EmployeeListAboveOneYear(objReportDTO));


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


                if (rdoEmployeeListBellowOneYear.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();

                    if (dtpLimitDate.Text == "")
                    {

                        string strMsg = "Please Enter Limit Date!!!";
                        MessageBox(strMsg);
                        return;
                    }
                    else
                    {

                        processEmployeeYearList();


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



                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeYearList.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.EmployeeListBellowOneYear(objReportDTO));


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





                if (rdoIncrementYearlyProposalStaff.Checked == true)
                {


                    if (txtYear.Text == "")

                    {

                        string strMSg = "Please Enter Year!!!";
                        MessageBox(strMSg);
                        txtYear.Focus();
                        return;

                    }
                    else if (dtpLimitDate.Text == "")
                    {

                        string strMSg = "Please Enter Limit Date!!!";
                        MessageBox(strMSg);
                        dtpLimitDate.Focus();
                        return;

                    }
                    else
                    {

                        ReportDTO objReportDTO = new ReportDTO();
                        ReportBLL objReportBLL = new ReportBLL();




                        objReportDTO.HeadOfficeId = strHeadOfficeId;
                        objReportDTO.BranchOfficeId = strBranchOfficeId;
                        objReportDTO.EmployeeId = txtEmpId.Text;
                        objReportDTO.UpdateBy = strEmployeeId;
                        objReportDTO.Year = txtYear.Text;

                        objReportDTO.LimitDate = dtpLimitDate.Text;

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



                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementYearlyProposalSheetStaff.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.rptIncrementYearlyProposalSheetStaff(objReportDTO));


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
        public void processWorkerSalaryRange()
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

            string strMsg = objReportBLL.processWorkerSalaryRange(objReportDTO);




        }
        public void processWorkerSalaryRangeSummery()
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

            string strMsg = objReportBLL.processWorkerSalaryRangeSummery(objReportDTO);




        }
        public void processTiffinRequisition()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
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



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processTiffinRequisition(objReportDTO);




        }
        public void processOverTimeRequisition()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
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



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processOverTimeRequisition(objReportDTO);




        }
        public void processSalaryRequisitionFactoryStaff()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
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


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processSalaryRequisitionFactoryStaff(objReportDTO);




        }
        public void processMonthlyOTRequisition()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
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



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            string strMsg = objReportBLL.processMonthlyOTRequisition(objReportDTO);




        }
        public void processSalaryRequisitionFactoryStaffMisc()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
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


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processSalaryRequisitionFactoryStaffMisc(objReportDTO);




        }
        public void processLeaveRequisitionFactoryStaff()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
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


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processLeaveRequisitionFactoryStaff(objReportDTO);




        }
        public void processLeaveRequisitionFactoryWorker()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
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



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            string strMsg = objReportBLL.processLeaveRequisitionFactoryWorker(objReportDTO);




        }
        public void processLeaveRequisitionAll()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
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


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processLeaveRequisitionAll(objReportDTO);




        }
        public void processSalaryRequisitionWoker()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
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



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processSalaryRequisitionWoker(objReportDTO);




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
        public void processSalaryRequisitionAll()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
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



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            string strMsg = objReportBLL.processSalaryRequisitionAll(objReportDTO);




        }
        public void processLeaveStaff()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            objSalaryDTO.Year = txtYear.Text;



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.SectionId = "";

            }



            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;


            string strMsg = objSalaryBLL.processLeaveStaff(objSalaryDTO);




        }
        public void processLeaveStaffMisc()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            objSalaryDTO.Year = txtYear.Text;



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.SectionId = "";

            }



            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;


            string strMsg = objSalaryBLL.processLeaveStaffMisc(objSalaryDTO);





        }
        public void processLeaveWorker()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            objSalaryDTO.Year = txtYear.Text;



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.SectionId = "";

            }



            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;


            string strMsg = objSalaryBLL.processLeaveWorker(objSalaryDTO);





        }
        public void monthlyWorkerSalaryMisc()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
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



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            string strMsg = objReportBLL.processSalaryRequisitionAll(objReportDTO);






        }
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


        public void processBonusProposalStaff11to12Month()
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

            string strMsg = objReportBLL.processBonusProposalStaff11to12Month(objReportDTO);




        }
        public void processBonusProposalWorker11to12Month()
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

            string strMsg = objReportBLL.processBonusProposalWorker11to12Month(objReportDTO);




        }
        public void processBonusProposalWorker()
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

            string strMsg = objReportBLL.ProcessBonusProposalForBellow6Month(objReportDTO);




        }
        public void ProcessBonusProposalStaff()
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

            string strMsg = objReportBLL.ProcessBonusProposalStaff(objReportDTO);
            
        }

        public void processMonthlyAttendenceSheetWorker()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;
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
            
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processMonthlyAttendenceSheetWorker(objReportDTO);
            
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
        public void processYearlyWorkerIncrementStatement()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();
            
            objReportDTO.Year = txtYear.Text;
            
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            
            string strMsg = objReportBLL.processYearlyWorkerIncrementStatement(objReportDTO);
        }
        public void processYearlyWorkerIncSummeryStatement()
        {
            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();
            objReportDTO.Year = txtYear.Text;
            
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            
            string strMsg = objReportBLL.processYearlyWorkerIncSummeryStatement(objReportDTO);
        }
        public void processYearlyWorkerIncrementSummeryStatement()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();
            
            objReportDTO.Year = txtYear.Text;
            
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            
            string strMsg = objReportBLL.processYearlyWorkerIncrementSummeryStatement(objReportDTO);
            
        }
        public void monthlySalaryRevenue()
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
            
            string strMsg = objReportBLL.monthlySalaryRevenue(objReportDTO);
            
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

        public void processSalaryRequisitionFactoryStaffGross()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
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


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processSalaryRequisitionFactoryStaffGross(objReportDTO);




        }

        public void processGradeAdjustIncrementRequiYearly()
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


            objReportDTO.UpdateBy = strEmployeeId;
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objReportBLL.processGradeAdjustIncrementRequiYearly(objReportDTO);




        }

        public void processGradeAdjustIncrementYearly()
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

            objReportDTO.UpdateBy = strEmployeeId;
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objReportBLL.processGradeAdjustIncrementYearly(objReportDTO);
        }
        public void ProcessSalaryGradeAdjustment()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.Year = txtYear.Text;
            objReportDTO.Month = txtMonth.Text;

            if (chkIncrementYn.Checked == true)
                objReportDTO.IncrementYn = "Y";
            else
                objReportDTO.IncrementYn = "N";

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

            string strMsg = objReportBLL.ProcessSalaryGradeAdjustment(objReportDTO);
        }


        public void processSalaryByGrade()
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


            objReportDTO.UpdateBy = strEmployeeId;
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objReportBLL.processSalaryByGrade(objReportDTO);




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

        public void processSalaryRequisitionWokerGross()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
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



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processSalaryRequisitionWokerGross(objReportDTO);




        }
        public void processEmployeeYearList()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();





            objReportDTO.LimitDate = dtpLimitDate.Text;



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


            string strMsg = objReportBLL.processEmployeeYearList(objReportDTO);




        }
        #endregion

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

        #region "Crystal Report Functionality"
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
        protected void rdoLateSheetSummery_CheckedChanged(object sender, EventArgs e)
        {
        }

        private bool IsValidateRadio()
        {
            int counter = 0;
            if (rptDailyAttendenceSheet.Checked == true)
                counter = counter + 1;
            if (rptDailyAttendenceSheetInOut.Checked == true)
                counter = counter + 1;
            if (rptDailyAttendenceLateSheet.Checked == true)
                counter = counter + 1;
            if (rptDailyAttendenceSheetInOut.Checked == true)
                counter = counter + 1;

            if (rptDailyAttendenceAbsenceSheet.Checked == true) //5
                counter = counter + 1;

            if (rptMonthlyAttendenceAbsenceSheet.Checked == true)
                counter = counter + 1;

            if (rdoMonthlyAttendenceSheet.Checked == true)
                counter = counter + 1;
            if (rdoMonthlyAttendenceSheetSummery.Checked == true)
                counter = counter + 1;


            if (rdoMonthlyAttendenceSheetAllWorker.Checked == true)
                counter = counter + 1;
            if (rdoDailyAttendenceTopSheet.Checked == true) //10
                counter = counter + 1;
            if (rdoAttendencePresentSummerySheet.Checked == true)
                counter = counter + 1;

            if (rdoDailyAttendenceOpeningSheet.Checked == true)
                counter = counter + 1;
            if (rdoDailyAttendenceClosingSheet.Checked == true)
                counter = counter + 1;
            
             if (rdoAllActiveEmployee.Checked == true)
                counter = counter + 1;
            if (rdoBonusProposalForBellow6Month.Checked == true)
                counter = counter + 1;


            if (rdoBonusProposalForBellow1Year.Checked == true) //15
                counter = counter + 1;
            if (rdoBonusProposalForBellow6MonthForStaff.Checked == true)
                counter = counter + 1;
            if (rdoBonusProposalForStaffBellow1Year.Checked == true)
                counter = counter + 1;


            if (rdoBonusSheetForWorker12Month.Checked == true)
                counter = counter + 1;
            if (rdoBonusSheetForStaff12Month.Checked == true)
                counter = counter + 1;
            if (rdoDesignationList.Checked == true) //20
                counter = counter + 1;

            if (rdoEmployeeJobHistory.Checked == true)
                counter = counter + 1;
            if (rdoEmployeeListHO.Checked == true)
                counter = counter + 1;
            if (rdoEmployeeJobYearMonthHistory.Checked == true)
                counter = counter + 1;

            if (rdoEmployeeJoiningInfo.Checked == true)
                counter = counter + 1;
            if (rdoEmployeeBasicInformation.Checked == true) //25
                counter = counter + 1;
            if (rdoEmployeJoiningResignInfo.Checked == true)
                counter = counter + 1;
            if (rdoEmployeeListByGrade.Checked == true)
                counter = counter + 1;
            if (rdoEmployeeListAboveOneYear.Checked == true)
                counter = counter + 1;
            if (rdoEmployeeListBellowOneYear.Checked == true)
                counter = counter + 1;
            if (rdoEmployeeSalaryRange.Checked == true)
                counter = counter + 1;

            if (rdoEmployeeInsurenceInfo.Checked == true) //30
                counter = counter + 1;
            if (rdoEmployeeMaleFemaleInfo.Checked == true)
                counter = counter + 1;
            if (rdoMonthlySalaryApproveSheet.Checked == true)
                counter = counter + 1;

            if (rdoSalaryInfoByGrade.Checked == true)
                counter = counter + 1;
            if (rdoGradeAdjustIncrementYearly.Checked == true)
                counter = counter + 1;
            if (rdoSalarySummeryInfoByGrade.Checked == true) //35
                counter = counter + 1;
            if (rdoMonthlySalaryRequisitionWorkerGross.Checked == true)
                counter = counter + 1;
            if (rdoSalaryAdjustSumAccordingGazette.Checked == true)
                counter = counter + 1;

            if (rdoGradeAdjustIncrementRequisitionYearly.Checked == true)
                counter = counter + 1;
            if (rdoMonthlyHalfSheetStaff.Checked == true)
                counter = counter + 1;
            if (rdoMonthlyHalfSheetWorker.Checked == true)
                counter = counter + 1;

            if (rdoHalfSalarySheetRequisitionWorker.Checked == true)
                counter = counter + 1;
            if (rdoInactiveEmployeeList.Checked == true)
                counter = counter + 1;
            if (rdoIncrementProposalWorkerAboveOneYear.Checked == true)
                counter = counter + 1;


            if (rdoIncrementProposalWorkerBellowOneYear.Checked == true)
                counter = counter + 1;
            if (rdoIncrementProposalStaff.Checked == true)
                counter = counter + 1;
            if (rdoIncrementYearlyProposalStaff.Checked == true)
                counter = counter + 1;


            if (rdoIncrementSummeryStatement.Checked == true)
                counter = counter + 1;
            if (rdoIncSummeryStatement.Checked == true)
                counter = counter + 1;
            if (rdoIncSummeryStatementOneYear.Checked == true)
                counter = counter + 1;


            if (rdoMonthlyIncrementList.Checked == true)
                counter = counter + 1;
            if (rdoLateSheetSummery.Checked == true)
                counter = counter + 1;
            if (rdoLeaveSheetStaff.Checked == true)
                counter = counter + 1;

            if (rdoLeaveSheetStaffMisc.Checked == true)
                counter = counter + 1;
            if (rdoLeaveSheetWorker.Checked == true)
                counter = counter + 1;
            if (rdoLeaveRequisitionStaff.Checked == true)
                counter = counter + 1;

            if (rdoLeaveRequisitionWorker.Checked == true)
                counter = counter + 1;
            if (rdoLeaveRequisitionAll.Checked == true)
                counter = counter + 1;
            if (rdoMonthlyMiscSheetWorker.Checked == true)
                counter = counter + 1;

            if (rdoNewEmployeeList.Checked == true)
                counter = counter + 1;

            if (rdoNewEmpListBeforeSalarySet.Checked == true)
                counter = counter + 1;
            
            if (rdoMonthlyOtRequisition.Checked == true)
                counter = counter + 1;
            if (rdoMonthlyOverTimeSheetWorker.Checked == true)
                counter = counter + 1;

            if (rdoMonthlyOverTimeRequisition.Checked == true)
                counter = counter + 1;
            if (rdoMonthlyPaySlipStaff.Checked == true)
                counter = counter + 1;
            if (rdoMonthlyPaySlipStaffMisc.Checked == true)
                counter = counter + 1;

            if (rdoMonthlyPaySlipWorker.Checked == true)
                counter = counter + 1;
            if (rdoMonthlyRevenueRequisition.Checked == true)
                counter = counter + 1;
            if (rdoSalaryHistory.Checked == true)
                counter = counter + 1;

            if (rdoWorkerSalaryRange.Checked == true)
                counter = counter + 1;
            if (rdoWorkerSalaryRangeSummery.Checked == true)
                counter = counter + 1;
            if (rdoMonthlySalarySheetStaff.Checked == true)
                counter = counter + 1;

            if (rdoMonthlySalarySheetStaffMisc.Checked == true)
                counter = counter + 1;
            if (rdoMonthlySalaryRequisitionFactoryStaff.Checked == true)
                counter = counter + 1;
            if (rdoSalaryRangeInformation.Checked == true)
                counter = counter + 1;

            if (rdoMonthlyStatementSP.Checked == true)
                counter = counter + 1;

            if (rdoMonthlySalaryStatement.Checked == true)
                counter = counter + 1;
            if (rdoYearlySalaryStatement.Checked == true)
                counter = counter + 1;
            if (rdoMonthlySalaryRequisitionFactoryStaffMisc.Checked == true)
                counter = counter + 1;

            if (rdoMonthlySalarySheetWorker.Checked == true)
                counter = counter + 1;
            if (rdoMonthlySalaryRequisitionWorker.Checked == true)
                counter = counter + 1;
            if (rdoMonthlySalaryRequisition.Checked == true)
                counter = counter + 1;

            if (rdoMonthlySalarySummeryWorker.Checked == true)
                counter = counter + 1;
            if (rdoMonthlySalaryRequisitionSheetWorker.Checked == true)
                counter = counter + 1;
            if (rdoMonthlyTiffinSheetWorker.Checked == true)
                counter = counter + 1;


            if (rdoMonthlyTiffinSheetWorkerRequisition.Checked == true)
                counter = counter + 1;
            if (rdoMonthlyTiffinRequisition.Checked == true)
                counter = counter + 1;
            if (rdoWorkerTransferSheet.Checked == true)
                counter = counter + 1;

            if (rdoMonthlyWorkingDayList.Checked == true)
                counter = counter + 1;

            if (rdoIncrementProposalAuto.Checked == true)
                counter = counter + 1;
            if (rdoTaxSummerySheet.Checked == true)
                counter = counter + 1;
           
            return counter > 0;
        }
    }
}