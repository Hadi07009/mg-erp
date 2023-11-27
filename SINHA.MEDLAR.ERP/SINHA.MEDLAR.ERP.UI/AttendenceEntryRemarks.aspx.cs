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
using SINHA.MEDLAR.ERP.UI.Utility;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AttendenceEntryRemarks : System.Web.UI.Page
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
        //private const string uiCode = "0002";
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
                GetFloorDropdown();
                getUnitId();
                
                getSectionId();
                GetShift();
                clearMsg();
                getOfficeName();
              
                getCurrentDate();
                btnSearch.Focus();
                //UIHelper.SetSucureEvents(this, strEmployeeId, uiCode, strBranchOfficeId, strHeadOfficeId);
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
            
            txtFirstInTime.Attributes.Add("onkeypress", "return controlEnter('" + txtLunchOutTime.ClientID + "', event)");
            txtLunchOutTime.Attributes.Add("onkeypress", "return controlEnter('" + txtLunchInTime.ClientID + "', event)");
            txtLunchInTime.Attributes.Add("onkeypress", "return controlEnter('" + txtFinalTimeOut.ClientID + "', event)");
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
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "attendence_report");
                Response.End();
                CrystalReportViewer1.RefreshReport();

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
        //public void GetEventPermission()
        //{
        //    EventPermissionDTO objEventPermissionDTO = new EventPermissionDTO();
        //    EmployeeBLL objEmployeeBLL = new EmployeeBLL();
        //    DataTable dt = new DataTable();
        //    objEventPermissionDTO.UpdateBy = strEmployeeId;
        //    objEventPermissionDTO.MenuCode = "0002";
        //    objEventPermissionDTO.HeadOfficeId = strHeadOfficeId;
        //    objEventPermissionDTO.BranchOfficeId = strBranchOfficeId;
        //    var basicInfo = objEmployeeBLL.GetEventPermission(objEventPermissionDTO);
        //    if (basicInfo.DisableProcess == "1")
        //        btnProcess.Visible = false;
        //    if (basicInfo.DisableSave == "1")
        //        btnSave.Visible = false;
        //    if (basicInfo.DisaleDelete == "1")
        //        btnDelete.Visible = false;
        //}
        public void getCurrentDate()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getCurrentDate();

            dtpAttendenceDate.Text = objLookUpDTO.AttendenceDate;



        }
        public void clearYellowTextBox()
        {
            txtCardNo.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            txtDesignationName.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtSL.Text = string.Empty;
            txtSLNew.Text = string.Empty;
        }
        public void clearTextBox()
        {
            txtFirstInTime.Text = "";
            txtLunchOutTime.Text = "";
            txtLunchInTime.Text = "";
            txtFinalTimeOut.Text = "";
            dtpFinalOutDate.Text = "";
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
        public void GetFloorDropdown()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlFloor.DataSource = objLookUpBLL.GetFloorDropdown(strHeadOfficeId, strBranchOfficeId);

            ddlFloor.DataTextField = "FLOOR_NAME";
            ddlFloor.DataValueField = "FLOOR_ID";

            ddlFloor.DataBind();
            if (ddlFloor.Items.Count > 0)
            {
                ddlFloor.SelectedIndex = 0;
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

        //public void searchMonthlySalaryInfo()
        //{
        //    SalaryDTO objSalaryDTO = new SalaryDTO();
        //    SalaryBLL objSalaryBLL = new SalaryBLL();



        //    if (ddlSectionId.SelectedValue.ToString() != " ")
        //    {
        //        objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
        //    }
        //    else
        //    {

        //        objSalaryDTO.SectionId = "";
        //    }



        //    if (ddlUnitId.SelectedValue.ToString() != " ")
        //    {
        //        objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objSalaryDTO.UnitId = "";

        //    }

        //    objSalaryDTO.Year = txtSalaryYear.Text;
        //    objSalaryDTO.Month = txtsalaryMonth.Text;


        //    ddlEmployeeId.DataSource = objSalaryBLL.getStaffIdForSalary(objSalaryDTO);

        //    ddlEmployeeId.DataTextField = "EMPLOYEE_NAME";
        //    ddlEmployeeId.DataValueField = "EMPLOYEE_ID";

        //    ddlEmployeeId.DataBind();
        //    if (ddlEmployeeId.Items.Count > 0)
        //    {

        //        ddlEmployeeId.SelectedIndex = 0;

        //    }
        //    else
        //    {
        //        string strMsg = "NO RECORD FOUND!!!";
        //        MessageBox(strMsg);


        //    }


        //}


     


        public void searchEmployeeRecordforAttendenceEntry()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.FromDate = dtpAttendenceDate.Text;
            objEmployeeDTO.ToDate = dtpAttendenceDate.Text;
            
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

            objEmployeeDTO.ShiftId = ddlShiftId.SelectedItem.Value;
            
            dt = objEmployeeBLL.searchEmployeeRecordForAttendence(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;

                // getFirstIndex();
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

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }

        }
        public void searchEmployeeAllforAttendenceEntry()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.FromDate = dtpAttendenceDate.Text;
            objEmployeeDTO.ToDate = dtpAttendenceDate.Text;


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
            objEmployeeDTO.ShiftId = ddlShiftId.SelectedItem.Value;

            dt = objEmployeeBLL.searchEmployeeAllforAttendenceEntry(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;

                // getFirstIndex();
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

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }

        }
        public void searchEmpRecordAttendence()
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





            dt = objEmployeeBLL.searchEmpRecordAttendence(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;

                // getFirstIndex();
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

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }

        }
        public void searchEmployeeRecordLastOutIsNull()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.LogDate = dtpAttendenceDate.Text;


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





            dt = objEmployeeBLL.searchEmployeeRecordLastOutIsNull(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;

                // getFirstIndex();
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

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }

        }
        public void searchAttendenceEntry()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.LogDate = dtpAttendenceDate.Text;
            
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

            objEmployeeDTO.ShiftId = ddlShiftId.SelectedItem.Value;

            dt = objEmployeeBLL.searchAttendenceEntry(objEmployeeDTO);
                        
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

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
            }

        }


        public void getEmployeeInformation()
        {


            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            objSalaryDTO = objSalaryBLL.getEmployeeInformation(txtCardNo.Text, strHeadOfficeId, ddlUnitId.SelectedValue.ToString(), ddlSectionId.SelectedValue.ToString());

            txtDesignationName.Text = objSalaryDTO.DesginationName;
            txtEmployeeId.ID = objSalaryDTO.EmployeeId;
            txtEmployeeName.Text = objSalaryDTO.EmployeeName;




        }

        public void getFirstIndex()
        {
            //var rowCount = gvEmployeeList.Rows.Count;


            //int rowIndex = 1;
            //if (gvEmployeeList.SelectedIndex == 0)
            //{


            //    rowIndex = 0;
            //    GridViewRow row = gvEmployeeList.Rows[rowIndex];
            //    txtCardNo.Text = row.Cells[1].Text;
            //    txtDesignationName.Text = row.Cells[4].Text;
            //    txtEmployeeName.Text = row.Cells[3].Text;
            //    txtEmployeeId.Text = row.Cells[2].Text;


            //}
            //else
            //{

            //    GridViewRow row = gvEmployeeList.Rows[rowIndex];
            //    txtCardNo.Text = row.Cells[1].Text;
            //    txtDesignationName.Text = row.Cells[4].Text;
            //    txtEmployeeName.Text = row.Cells[3].Text;
            //    txtEmployeeId.Text = row.Cells[2].Text;

            //    rowIndex = rowIndex + 1;

            //}


            int nRow = gvEmployeeList.SelectedIndex;

            if (nRow == -1)
            {
                int rowIndex = 0;
                GridViewRow row = gvEmployeeList.Rows[rowIndex];
                txtCardNo.Text = row.Cells[1].Text;
                txtDesignationName.Text = row.Cells[4].Text;
                txtEmployeeName.Text = row.Cells[3].Text;
                txtEmployeeId.Text = row.Cells[2].Text;

                int l;
                l = gvEmployeeList.SelectedRow.RowIndex + 1;
                txtSL.Text = Convert.ToString(l);
            }
            int courow = gvEmployeeList.Rows.Count - 1;
            {


            }



        }

        public void goToNextRecord()
        {

            if (txtSL.Text == string.Empty)
            {
                txtSL.Text = "1";
            }

            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            //gvIncrementList.SelectedIndex = 1;


            int l = 0;

            if (gvEmployeeList.Rows.Count > 0)
            {
                l = gvEmployeeList.SelectedRow.RowIndex;
            }

            if (l != 0)
            {

                int strId = gvEmployeeList.SelectedRow.RowIndex + 1;
                int strRowCount = strId;
                int intCount = gvEmployeeList.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                   
                    return;

                }
                else
                {
                    gvEmployeeList.SelectedIndex += 1;
                    result = gvEmployeeList.SelectedRow.RowIndex + k;

                }

            }
            if (l == 0)
            {

                int intCount = gvEmployeeList.Rows.Count;
                int intCountRow = gvEmployeeList.Rows.Count;
                if (intCountRow == 1)
                {
                    intCountRow = 2;

                }

                int p = intCountRow - 1;
                //int p = intCountRow;
                if (l == p)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                    
                    return;

                }

                else
                {
                    l = 1;

                    if (txtSL.Text == "1" && txtSLNew.Text == "")
                    {
                        gvEmployeeList.SelectedIndex = 0;

                        if (gvEmployeeList.Rows.Count > 0)
                        {
                            result = gvEmployeeList.SelectedRow.RowIndex + k;
                            txtSLNew.Text = "1";
                        }

                    }
                    else
                    {

                        int intC = gvEmployeeList.Rows.Count;
                        int intCo = gvEmployeeList.Rows.Count;
                        int ll = 0;

                        int pp = intCo - 1;
                        //int p = intCountRow;
                        if (ll == pp)
                        {
                            string strMsg = "There is no Data for the Next Record!!!";
                            MessageBox(strMsg);
                           
                            return;

                        }
                        else
                        {

                            gvEmployeeList.SelectedIndex += 1;
                            if (gvEmployeeList.Rows.Count > 0)
                            {
                                result = gvEmployeeList.SelectedRow.RowIndex + k;
                            }

                        }

                    }


                }

            }


            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            if (strSLNo == "NO RECORD FOUND")
            {
                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                return;
            }
            else
            {
                string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
                string strEmployeeId = gvEmployeeList.SelectedRow.Cells[2].Text;
                string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
                string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;


                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;


            }

        }

        public void goToPreviousRecord()
        {
            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            //gvIncrementList.SelectedIndex = 1;


            int l;
            l = gvEmployeeList.SelectedRow.RowIndex;
            if (l != 0)
            {
                int strId = gvEmployeeList.SelectedRow.RowIndex - 1;
                int strRowCount = strId;
                int intCount = gvEmployeeList.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                   
                    return;

                }
                else
                {
                    gvEmployeeList.SelectedIndex -= 1;
                    result = gvEmployeeList.SelectedRow.RowIndex - k;
                }
            }
            if (l == 0)
            {

                int intCountRow = gvEmployeeList.Rows.Count;
                int p = intCountRow;
                if (intCountRow == p)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                   
                    return;

                }

                else
                {

                    l = 1;
                    gvEmployeeList.SelectedIndex = l;
                    result = gvEmployeeList.SelectedRow.RowIndex - k;

                }

            }

            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;

            //int strRowCount = strRowId - 1;
            //int intCount = gvIncrementList.Rows.Count;
            //if (intCount == strRowCount)
            //{
            //    string strMsg = "Entry Completed";
            //    MessageBox(strMsg);
            //    return;

            //}
            //else
            //{




            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            
        }



        public void saveEmployeeAttendence()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;

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

            if (ChkAllActive.Checked == true)
            {
                objEmployeeDTO.ActiveYn = "Y";
            }
            else
            {
                objEmployeeDTO.ActiveYn = "N";
            }

            if (chkAllUnit.Checked == true)
            {
                objEmployeeDTO.AllUnitYn = "Y";
            }
            else
            {
                objEmployeeDTO.AllUnitYn = "N";
            }

            objEmployeeDTO.LogDate = dtpAttendenceDate.Text;

            if(string.IsNullOrEmpty(dtpFinalOutDate.Text))
            {
                objEmployeeDTO.FinalOutDate = dtpAttendenceDate.Text;
            }
            else
            {
                objEmployeeDTO.FinalOutDate = dtpFinalOutDate.Text;
            }

            objEmployeeDTO.Remark = txtRemarks.Text;

            objEmployeeDTO.LogInTime = txtFirstInTime.Text;
            objEmployeeDTO.FinalOutTime = txtFinalTimeOut.Text;
            objEmployeeDTO.LunchInTime = txtLunchInTime.Text;
            objEmployeeDTO.LunchOutTime = txtLunchOutTime.Text;

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.UpdateBy = strEmployeeId;

            string strMsg = objEmployeeBLL.saveEmployeeAttendence(objEmployeeDTO);
            lblMsg.Text = strMsg;
        }
        public void searchAttendenceRecord()
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            
            objEmployeeDTO = objEmployeeBLL.searchAttendenceRecord(dtpAttendenceDate.Text, txtEmployeeId.Text, strHeadOfficeId, strBranchOfficeId);

            if (objEmployeeDTO.LogInTime == "0" || objEmployeeDTO.LogInTime == null)
            {
                searchAttendenceRecordFromAttenSearchIn();
            }
            else
            {
                txtFirstInTime.Text = objEmployeeDTO.LogInTime;
            }

            if (objEmployeeDTO.LunchOutTime == "0" || objEmployeeDTO.LunchOutTime == null)
            {
                searchAttendenceRecordFromAttenSearchLunchOut();
            }
            else
            {
                txtLunchOutTime.Text = objEmployeeDTO.LunchOutTime;
            }
            if (objEmployeeDTO.LunchInTime == "0" || objEmployeeDTO.LunchInTime == null)
            {
                searchAttendenceRecordFromAttenSearchLunchIn();
            }
            else
            {
                txtLunchInTime.Text = objEmployeeDTO.LunchInTime;
            }

            if (objEmployeeDTO.FinalOutTime == "0" || objEmployeeDTO.FinalOutTime == null)
            {
                searchAttendenceRecordFromAttenSearchFinalOut();
            }
            else
            {
                txtFinalTimeOut.Text = objEmployeeDTO.FinalOutTime;
            }

            if (objEmployeeDTO.FinalOutDate != "0")
            {
                dtpFinalOutDate.Text = objEmployeeDTO.FinalOutDate;
            }
            else
            {
                dtpFinalOutDate.Text = "";
            }

            if (objEmployeeDTO.Remark == "0" || objEmployeeDTO.Remark == null)
            {
                txtRemarks.Text = "";

            }
            else
            {
                txtRemarks.Text = objEmployeeDTO.Remark;

            }


        }
        public void searchAttendenceRecordFromAttenSearchIn()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();


            objEmployeeDTO = objEmployeeBLL.searchAttendenceRecordFromAttenSearchIn(dtpAttendenceDate.Text, txtEmployeeId.Text, strHeadOfficeId, strBranchOfficeId);

            if (objEmployeeDTO.LogInTime == "0" || objEmployeeDTO.LogInTime == null)
            {

                txtFirstInTime.Text = "";
            }
            else
            {
                txtFirstInTime.Text = objEmployeeDTO.LogInTime;

            }

          




        }
        public void searchAttendenceRecordFromAttenSearchLunchIn()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();


            objEmployeeDTO = objEmployeeBLL.searchAttendenceRecordFromAttenSearchLunchIn(dtpAttendenceDate.Text, txtEmployeeId.Text, strHeadOfficeId, strBranchOfficeId);

           

            if (objEmployeeDTO.LunchInTime == "0" || objEmployeeDTO.LunchInTime == null)
            {
                txtLunchInTime.Text = "";

            }
            else
            {
                txtLunchInTime.Text = objEmployeeDTO.LunchInTime;

            }

           


        }
        public void searchAttendenceRecordFromAttenSearchLunchOut()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();


            objEmployeeDTO = objEmployeeBLL.searchAttendenceRecordFromAttenSearchLunchOut(dtpAttendenceDate.Text, txtEmployeeId.Text, strHeadOfficeId, strBranchOfficeId);

          
            if (objEmployeeDTO.LunchOutTime == "0" || objEmployeeDTO.LunchOutTime == null)
            {
                txtLunchOutTime.Text = "";

            }
            else
            {
                txtLunchOutTime.Text = objEmployeeDTO.LunchOutTime;

            }
         
           

        }
        public void searchAttendenceRecordFromAttenSearchFinalOut()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();


            objEmployeeDTO = objEmployeeBLL.searchAttendenceRecordFromAttenSearchFinalOut(dtpAttendenceDate.Text, txtEmployeeId.Text, strHeadOfficeId, strBranchOfficeId);


            if (objEmployeeDTO.FinalOutTime == "0" || objEmployeeDTO.FinalOutTime == null)
            {
                txtFinalTimeOut.Text = "";

            }
            else
            {
                txtFinalTimeOut.Text = objEmployeeDTO.FinalOutTime;

            }




        }
        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }


        public void processManualAttendenceSheetSearch()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();


            objEmployeeDTO.FromDate = dtpAttendenceDate.Text;
            objEmployeeDTO.ToDate = dtpAttendenceDate.Text;

          

            if (chkAll.Checked == true)
            {
                objEmployeeDTO.ChkeckYn = "Y";
            }
            else
            {
                objEmployeeDTO.ChkeckYn = "N";
            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objEmployeeDTO.SectionId = "";
            }



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";

            }


            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objEmployeeBLL.processManualAttendenceSheetSearch(objEmployeeDTO);




        }
        #endregion

        public void GetShift()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            var data = objLookUpBLL.GetShift(strBranchOfficeId);

            ddlShiftId.DataSource = data;
            ddlShiftId.DataTextField = "SHIFT_NAME";
            ddlShiftId.DataValueField = "SHIFT_ID";

            ddlShiftId.DataBind();
            if (ddlShiftId.Items.Count > 0)
            {
                ddlShiftId.SelectedIndex = 0;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else
                {



                    goToNextRecord();
                    searchAttendenceRecord();
                    clearMessage();


                }


            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {

                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else
                {
                    goToPreviousRecord();
                    searchAttendenceRecord();
                    clearMessage();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpAttendenceDate.Text == "")
                {
                    string strMsg = "Please Enter Date!!";
                    dtpAttendenceDate.Focus();
                    MessageBox(strMsg);
                    return;
                }             
                else
                {
                    FetchData();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        private void FetchData()
        {
            if (chkAll.Checked == true)
            {
                processManualAttendenceSheetSearch();
                searchEmployeeAllforAttendenceEntry();
                searchAttendenceEntry();
                clearYellowTextBox();
                clearTextBox();
                gvEmployeeList.SelectedIndex = 0;
                goToNextRecord();
                searchAttendenceRecord();

            }
            else
            {

                processManualAttendenceSheetSearch();
                searchEmployeeRecordforAttendenceEntry();
                searchAttendenceEntry();
                clearYellowTextBox();
                clearTextBox();
                gvEmployeeList.SelectedIndex = 0;
                goToNextRecord();
                searchAttendenceRecord();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int emptyCounter = 0;

                if(string.IsNullOrEmpty(txtFirstInTime.Text))
                {
                    emptyCounter = emptyCounter + 1;
                }
                if (string.IsNullOrEmpty(txtLunchOutTime.Text))
                {
                    emptyCounter = emptyCounter + 1;
                }
                if (string.IsNullOrEmpty(txtLunchInTime.Text))
                {
                    emptyCounter = emptyCounter + 1;
                }
                if (string.IsNullOrEmpty(txtFinalTimeOut.Text))
                {
                    emptyCounter = emptyCounter + 1;
                }
                                
                if (dtpAttendenceDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter Attendence Date!!!";
                    MessageBox(strMsg);
                    dtpAttendenceDate.Focus();
                    return;
                }
                else
                {
                    if (strBranchOfficeId == "102" || strBranchOfficeId == "103" || strBranchOfficeId == "110")
                    {
                        if (emptyCounter > 2)
                        {
                            goToNextRecord();
                            searchAttendenceRecord();
                        }
                        else
                        {
                            saveEmployeeAttendence();
                            searchAttendenceEntry();
                            goToNextRecord();
                            searchAttendenceRecord();
                        }
                    }
                    else
                    {
                        saveEmployeeAttendence();
                        searchAttendenceEntry();
                        goToNextRecord();
                        searchAttendenceRecord();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
          
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[9].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;
            
            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            
            searchAttendenceRecord();
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

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }

        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvUnit, "Select$" + e.Row.RowIndex);
        //        //e.Row.Attributes["style"] = "cursor:pointer";

        //        try
        //        {
        //            switch (e.Row.RowType)
        //            {
        //                case DataControlRowType.Header:
        //                    //...
        //                    break;
        //                case DataControlRowType.DataRow:
        //                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#93A3B0'; this.style.color='White'; this.style.cursor='pointer'");
        //                    if (e.Row.RowState == DataControlRowState.Alternate)
        //                    {
        //                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.AlternatingRowStyle.BackColor.ToKnownColor()));
        //                    }
        //                    else
        //                    {
        //                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.RowStyle.BackColor.ToKnownColor()));
        //                    }
        //                    e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gvUnit, "Select$" + e.Row.RowIndex.ToString()));
        //                    break;
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            throw new Exception("Error : " + ex.Message);
        //        }
        //    }
        //}







        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        #endregion
        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
            
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;
                                    
            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            
            searchAttendenceRecord();
    
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

        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvUnit, "Select$" + e.Row.RowIndex);
        //        //e.Row.Attributes["style"] = "cursor:pointer";

        //        try
        //        {
        //            switch (e.Row.RowType)
        //            {
        //                case DataControlRowType.Header:
        //                    //...
        //                    break;
        //                case DataControlRowType.DataRow:
        //                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#93A3B0'; this.style.color='White'; this.style.cursor='pointer'");
        //                    if (e.Row.RowState == DataControlRowState.Alternate)
        //                    {
        //                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.AlternatingRowStyle.BackColor.ToKnownColor()));
        //                    }
        //                    else
        //                    {
        //                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.RowStyle.BackColor.ToKnownColor()));
        //                    }
        //                    e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gvUnit, "Select$" + e.Row.RowIndex.ToString()));
        //                    break;
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            throw new Exception("Error : " + ex.Message);
        //        }
        //    }
        //}






        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        #endregion

        protected void btnProcess_Click(object sender, EventArgs e)
        {

            if (dtpAttendenceDate.Text == string.Empty)
            {
                string strMsg = "Please Enter Attendence Date!!!";
                MessageBox(strMsg);
                dtpAttendenceDate.Focus();
                return;
            }
            else
            {
                processManualAttendence();
                FetchData();
            }
        }

        public void employeeLogDataProcess()
        {


            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


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


            objSalaryDTO.FromDate = dtpAttendenceDate.Text;
            objSalaryDTO.ToDate = dtpAttendenceDate.Text;

            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objSalaryBLL.employeeLogDataProcess(objSalaryDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }
        public void processManualAttendence()
        {
                        
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();         

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
            
            objEmployeeDTO.FromDate = dtpAttendenceDate.Text;
            objEmployeeDTO.ToDate = dtpAttendenceDate.Text; 
            
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.UpdateBy = strEmployeeId;
            
            string strMsg = objEmployeeBLL.processManualAttendence(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
            
        }

        public void deleteManualAttendence()
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            
            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;

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



            objEmployeeDTO.AttendenceDate = dtpAttendenceDate.Text;
          


            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.UpdateBy = strEmployeeId;


            string strMsg = objEmployeeBLL.deleteManualAttendence(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);




        }


        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
               if (dtpAttendenceDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter Attendence Date!!!";
                    MessageBox(strMsg);
                    dtpAttendenceDate.Focus();
                    return;
                }
                else
                {
                    searchAttendenceEntry();
                }

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

        protected void btnAttendenceSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpAttendenceDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter Attendence Date!!";
                    dtpAttendenceDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
              
                rptAttendenceSheet();
                
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

        public void rptAttendenceSheet()
        {
            try
            {
                
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.FromDate = dtpAttendenceDate.Text;
                objReportDTO.ToDate = dtpAttendenceDate.Text;

                if (ddlSittingType.SelectedValue.ToString() != "")
                {
                    objReportDTO.SittingTypeId = ddlSittingType.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SittingTypeId = "";
                }
                if (ddlFloor.SelectedValue.ToString() != "")
                {
                    objReportDTO.FloorId = ddlFloor.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.FloorId = "";
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
               
                objReportDTO.ShiftId = ddlShiftId.SelectedItem.Value;
                objReportDTO.OTMunite = txtOTHourMinute.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAttendenceSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.dailyAttendenceSheet(objReportDTO));


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
        public void GetManualAttendanceSheet()
        {
            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;
                objReportDTO.ToDate = dtpAttendenceDate.Text;
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
                if (ddlUnitGroupId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
                }

                objReportDTO.ShiftId = ddlShiftId.SelectedItem.Value;


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyManualAttendenceSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetManualAttendanceSheet(objReportDTO));


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

        public void rptAttendenceSheetWOLogIn(ReportDTO objReportDTO)
        {
            try
            {
                
                //ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.FromDate = dtpAttendenceDate.Text;
                objReportDTO.ToDate = dtpAttendenceDate.Text;
                
                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
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
                rd.SetDataSource(objReportBLL.dailyAttendenceSheetWOLogIn(objReportDTO));


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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtpAttendenceDate.Text == string.Empty)
            {
                string strMsg = "Please Enter Attendence Date!!";
                dtpAttendenceDate.Focus();
                MessageBox(strMsg);
                return;
            }

            if (txtEmployeeId.Text == string.Empty)
            {
                string strMsg = "Please Select Employee!!";
                MessageBox(strMsg);
                return;
            }


            else
            {

                deleteManualAttendence();
                searchAttendenceEntry();
                goToNextRecord();
                searchAttendenceRecord();
            }
        }

        protected void btnAbsenceSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpAttendenceDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter Date!!";
                    dtpAttendenceDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                rptAbsenceSheet();
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
        public void rptAbsenceSheet()
        {
            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                processDailyAbsenceSheet();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.CardNo = txtCardNo.Text;

                objReportDTO.FromDate = dtpAttendenceDate.Text;
                objReportDTO.ToDate = dtpAttendenceDate.Text;
                if (ddlSittingType.SelectedValue.ToString() != "")
                {
                    objReportDTO.SittingTypeId = ddlSittingType.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SittingTypeId = "";
                }
                if (ddlFloor.SelectedValue.ToString() != "")
                {
                    objReportDTO.FloorId = ddlFloor.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.FloorId = "";
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
                
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAbsenceSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.dailyAbsenceSheet(objReportDTO));


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
        public void processDailyAbsenceSheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.FromDate = dtpAttendenceDate.Text;
            objReportDTO.ToDate = dtpAttendenceDate.Text;


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.SectionId = "";
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
        protected void btnWOLogInSheet_Click(object sender, EventArgs e)
        {
            try
            {

                //if (ddlSectionId.SelectedItem.Value == " " && ddlUnitId.SelectedItem.Value == " ")
                //{
                //    if (ddlUnitId.SelectedItem.Value == " ")
                //    {
                //        string strMsg = "Please Select Unit and Section";
                //        ddlUnitId.Focus();
                //        MessageBox(strMsg);
                //        return;
                //    }
                //}

                //if (ddlSectionId.SelectedItem.Value != " " && ddlUnitId.SelectedItem.Value == " ")
                //{
                //    string strMsg = "Please Select Unit";
                //    ddlUnitId.Focus();
                //    MessageBox(strMsg);
                //    return;
                //}


                if (dtpAttendenceDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter Attendence Date!!";
                    dtpAttendenceDate.Focus();
                    MessageBox(strMsg);
                    return;
                }

                ReportDTO objReportDTO = new ReportDTO();
                objReportDTO.NVL = 1;
                rptAttendenceSheetWOLogIn(objReportDTO);
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
        protected void btnWOLastOutSheet_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ddlSectionId.SelectedItem.Value == " " && ddlUnitId.SelectedItem.Value == " ")
                //{
                //    if (ddlUnitId.SelectedItem.Value == " ")
                //    {
                //        string strMsg = "Please Select Unit and Section";
                //        ddlUnitId.Focus();
                //        MessageBox(strMsg);
                //        return;
                //    }
                //}

                //if (ddlSectionId.SelectedItem.Value != " " && ddlUnitId.SelectedItem.Value == " ")
                //{
                //    string strMsg = "Please Select Unit";
                //    ddlUnitId.Focus();
                //    MessageBox(strMsg);
                //    return;
                //}


                if (dtpAttendenceDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter Attendence Date!!";
                    dtpAttendenceDate.Focus();
                    MessageBox(strMsg);
                    return;
                }

                ReportDTO objReportDTO = new ReportDTO();
                objReportDTO.NVL = 2;
                rptAttendenceSheetWOLogIn(objReportDTO);
                
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

        protected void btnManualAttendanceSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpAttendenceDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter Attendence Date!!";
                    dtpAttendenceDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                GetManualAttendanceSheet();
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