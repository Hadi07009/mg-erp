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
using CrystalDecisions.Shared;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class IncrementArrearStaff : System.Web.UI.Page
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

                getSectionId();
                getUnitId();
                GetMonth();
                GetFromMonth();
                GetToMonth();
                clearMsg();
                getOfficeName();
                //getMonthYearForInactive();
            }
            if (IsPostBack)
            {

                loadSesscion();
            }
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

        //public void getMonthYearForInactive()
        //{

        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    objLookUpDTO = objLookUpBLL.getMonthYearForInactive();

        //    txtYear.Text = objLookUpDTO.Year;
        //   // txtMonth.Text = objLookUpDTO.Month;

        //}



        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
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
        public void GetMonth()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlMonthId.DataSource = objLookUpBLL.getMonthId();

            ddlMonthId.DataTextField = "MONTH_NAME";
            ddlMonthId.DataValueField = "MONTH_ID";

            ddlMonthId.DataBind();
            if (ddlMonthId.Items.Count > 0)
            {
                ddlMonthId.SelectedIndex = 0;
            }


        }
        public void GetFromMonth()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlArrearFromMonth.DataSource = objLookUpBLL.getMonthId();

            ddlArrearFromMonth.DataTextField = "MONTH_NAME";
            ddlArrearFromMonth.DataValueField = "MONTH_ID";

            ddlArrearFromMonth.DataBind();
            if (ddlArrearFromMonth.Items.Count > 0)
            {
                ddlArrearFromMonth.SelectedIndex = 0;
            }
        }
        public void GetToMonth()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlArrearToMonth.DataSource = objLookUpBLL.getMonthId();

            ddlArrearToMonth.DataTextField = "MONTH_NAME";
            ddlArrearToMonth.DataValueField = "MONTH_ID";

            ddlArrearToMonth.DataBind();
            if (ddlArrearToMonth.Items.Count > 0)
            {
                ddlArrearToMonth.SelectedIndex = 0;
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

        public void ProcessIncrementArrearStaff()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.Year = txtIncrementYear.Text;
            if (ddlMonthId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.Month = ddlMonthId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.Month = "";
            }
            objEmployeeDTO.FromYear = txtArrearFromYear.Text;
            objEmployeeDTO.ToYear = txtArrearToYear.Text;

            if (ddlArrearFromMonth.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.FromMonthId = ddlArrearFromMonth.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.FromMonthId = "";
            }
            if (ddlArrearToMonth.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.ToMonthId = ddlArrearToMonth.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.ToMonthId = "";
            }

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

           

            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.ProcessIncrementArrearStaff(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }

       public void Clear()
        {
            
            ddlMonthId.SelectedIndex = 0;
            ddlArrearToMonth.SelectedIndex = 0;
            ddlArrearFromMonth.SelectedIndex = 0;
            txtIncrementYear.Text = string.Empty;
            txtArrearFromYear.Text = string.Empty;
            txtArrearToYear.Text = string.Empty;
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


  

        #endregion 

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtIncrementYear.Text == string.Empty)
                {
                    string strMsg = "Please Increment Year";
                    MessageBox(strMsg);
                    txtIncrementYear.Focus();
                    return; 
                }
                if (ddlMonthId.SelectedValue== string.Empty)
                {
                    string strMsg = "Please Select Increment Month";
                    MessageBox(strMsg);
                    ddlMonthId.Focus();
                    return;
                }
                if (txtArrearFromYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Arrear From Year";
                    MessageBox(strMsg);
                    txtArrearFromYear.Focus();
                    return;
                }
                if (txtArrearToYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Arrear To Year";
                    MessageBox(strMsg);
                    txtArrearToYear.Focus();
                    return;
                }
                if (ddlArrearFromMonth.SelectedValue == string.Empty)
                {
                    string strMsg = "Please Select Arrear From Month";
                    MessageBox(strMsg);
                    ddlArrearFromMonth.Focus();
                    return;
                }
                if (ddlArrearToMonth.SelectedValue == string.Empty)
                {
                    string strMsg = "Please Select Arrear To Month";
                    MessageBox(strMsg);
                    ddlArrearToMonth.Focus();
                    return;
                }

                ProcessIncrementArrearStaff();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
              
        protected void ddlOfficeId_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }



        //#region "Grid View Functionality"
        //protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvEmployeeList.PageIndex = e.NewPageIndex;

        //}

        //protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        //{



        //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
        //    string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
        //    string EmpId = gvEmployeeList.SelectedRow.Cells[2].Text;
        //    string Unit = gvEmployeeList.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
        //    string Section = gvEmployeeList.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
        //    string ResignDate = gvEmployeeList.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
        //    string ResignCause = gvEmployeeList.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
   
        //    ddlUnitId.SelectedValue = Unit;
        //    ddlSectionId.SelectedValue = Section;
        //    dtpResignDate.Text = ResignDate;
        //   // txtResignCause.Text = ResignCause;





        //}




        //protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        //{




        //}


        //protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
        //{
        //    e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        //    e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        //}

        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
        //        e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

        //        e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);
        //    }
        //}





        ////protected void gvEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
        ////{

        ////    LookUpDTO objLookUpDTO = new LookUpDTO();
        ////    LookUpBLL objLookUpBLL = new LookUpBLL();

        ////    DataTable dt = new DataTable();
        ////    dt = objLookUpBLL.loadEmployeeRecord();


        ////    if (dt.Rows.Count > 0)
        ////    {
        ////        gvEmployeeList.DataSource = dt;
        ////        gvEmployeeList.DataBind();
        ////    }
        ////    if (dt != null)
        ////    {
        ////        DataView dataView = new DataView(dt);
        ////        dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

        ////        gvEmployeeList.DataSource = dataView;
        ////        gvEmployeeList.DataBind();
        ////    }
        ////}

        //private string GridViewSortDirection
        //{
        //    get { return ViewState["SortDirection"] as string ?? "DESC"; }
        //    set { ViewState["SortDirection"] = value; }
        //}

        ////private string ConvertSortDirectionToSql(SortDirection sortDirection)
        ////{
        ////    switch (GridViewSortDirection)
        ////    {
        ////        case "ASC":
        ////            GridViewSortDirection = "DESC";
        ////            break;

        ////        case "DESC":
        ////            GridViewSortDirection = "ASC";
        ////            break;
        ////    }

        ////    return GridViewSortDirection;
        ////}


        //protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //}

        //#endregion

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

                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet_worker");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }
        }

        protected void btnArrearSheetStaff_Click(object sender, EventArgs e)
        {
            rptArrearSheetStaff();
        }

        public void rptArrearSheetStaff()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;


                //objReportDTO.EmployeeId = txtEmpId.Text;
                //objReportDTO.CardNo = txtEmpCardNo.Text;


                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {

                    objReportDTO.SectionId = "";
                }



                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";

                }


                if (ddlMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.Month = ddlMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.Month = "";

                }


                objReportDTO.Year = txtIncrementYear.Text;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearSheetStaff.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptArrearSheetStaff(objReportDTO));


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
    }
}