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


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class JobCardWH : System.Web.UI.Page
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
                loadSesscion();
                GetUnitBySittingOffice();
                GetSectionBySittingOffice();
                clearMsg();
                getOfficeName();
                btnSearch.Focus();
            }
            if (IsPostBack)
            {

                loadSesscion();
            }
        }

        #region "Function"

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
        public void GetUnitBySittingOffice()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlUnitId.DataSource = objLookUpBLL.GetUnitBySittingOffice(strBranchOfficeId);
            ddlUnitId.DataTextField = "UNIT_NAME";
            ddlUnitId.DataValueField = "UNIT_ID";

            ddlUnitId.DataBind();
            if (ddlUnitId.Items.Count > 0)
            {
               ddlUnitId.SelectedIndex = 0;
            }
        }
        public void GetSectionBySittingOffice()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSectionId.DataSource = objLookUpBLL.GetSectionBySittingOffice(strBranchOfficeId);

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



        public void GetEmployeeInformatiom()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

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
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            dt = objEmployeeBLL.GetEmployeeInformatiom(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
                // getFirstIndex();
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

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
            }
        }
        public void saveEmployeeCard()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();


            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {
                        TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
                        TextBox txtCardNo = (TextBox)row.FindControl("txtCardNo");

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
                        objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                        objEmployeeDTO.UpdateBy = strEmployeeId;
                        objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                        objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                        string strMsg = objEmployeeBLL.saveEmployeeCard(objEmployeeDTO);
                        lblMsg.Text = strMsg;
                    }
                }
            }
        }
        #endregion
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetEmployeeInformatiom();
            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {

                chkExcel.Checked = false;
            }
            else
            {
                chkPDF.Checked = true;

            }
        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkPDF.Checked = false;
            }
            else
            {
                chkExcel.Checked = true;
            }
        }

        protected void btnActiveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                saveEmployeeCard();
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
        #region Grid View Functionality2
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }
        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //int strRowId = GridView1.SelectedRow.RowIndex + 1;
            //string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            //string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            //string strEmployeeId = GridView1.SelectedRow.Cells[9].Text;
            //string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            //string strDesignation = GridView1.SelectedRow.Cells[3].Text;

        }

        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = GridView1.Rows[index];

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            if (dtpFromCreateDate.Text == string.Empty)
            {
                string Msg = "Please Enter From Date";
                lblMsg.Text = Msg;
                MessageBox(Msg);
                return;
             }

            if (dtpToCreateDate.Text == string.Empty)
            {
                string Msg = "Please Enter To Date";
                lblMsg.Text = Msg;
                MessageBox(Msg);
                return;
            }

            TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
            TextBox txtBranchOfficeId = (TextBox)row.FindControl("txtBranchOfficeId");
            TextBox txtHeadOfficeId = (TextBox)row.FindControl("txtHeadOfficeId");

            objReportDTO.EmployeeId = txtEmployeeId.Text;
            objReportDTO.HeadOfficeId = txtHeadOfficeId.Text;
            objReportDTO.BranchOfficeId = txtBranchOfficeId.Text;
            objReportDTO.UpdateBy = strEmployeeId;

            objReportDTO.FromDate = dtpFromCreateDate.Text;
            objReportDTO.ToDate = dtpToCreateDate.Text;
            objReportDTO.CardNo = "";

            
             objReportDTO.SectionId = "";
             objReportDTO.UnitId = "";

            //COMMENTED: 17.07.2021
            //objReportBLL.PrepareJobCard(objReportDTO);

            //new: RptJobCardNew
            //string strPath = Path.Combine(Server.MapPath("~/Reports/RptJobCard.rpt"));
            //this.Context.Session["strReportPath"] = strPath;
            //rd.Load(strPath);

            //new
            DataTable dtWH = new DataTable();
            dtWH = objReportBLL.GetJobCardWH(objReportDTO);
            grdWorkingHours.DataSource = null;
            grdWorkingHours.DataBind();
            grdWorkingHours.DataSource = dtWH;
            grdWorkingHours.DataBind();

            //reportMaster();
            //old
            //rd.SetDataSource(objReportBLL.rptMonthlyAttendenceSheetWorker(objReportDTO));

            //uncomment before live 27.05.2019
            //rd.SetDatabaseLogon("erp", "erp");
            //CrystalReportViewer1.ReportSource = rd;
            //CrystalReportViewer1.DataBind();
            //reportMaster();
            // ReportFormatMaster();

            //this.CrystalReportViewer1.Dispose();
            //this.CrystalReportViewer1 = null;
            //rd.Dispose();
            //rd.Close();
            //GC.Collect();
            //GC.WaitForPendingFinalizers();

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
        }

        protected void GridView1_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }

        #endregion
        
    }
}