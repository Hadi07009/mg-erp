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

using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Drawing;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AppoinmentApprovalEntry : System.Web.UI.Page
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
                getUnitId();
                getSectionId();
                clearMsg();
                getOfficeName();
                getMonthYearForTax();
                btnSearch.Focus();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
            txtFirstSalary.Attributes.Add("onkeypress", "return controlEnter('" + txtGrossSalary.ClientID + "', event)");
            gvEmployeeList.Columns[7].Visible = false;
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

            txtGrossSalary.Text = string.Empty;
            txtFirstSalary.Text = string.Empty;


        }

        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
        }
        public void getMonthYearForTax()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtSalaryYear.Text = objLookUpDTO.Year;
            txtsalaryMonth.Text = objLookUpDTO.Month;

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


        public void saveTaxInfo()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objSalaryDTO.SectionId = "";
            }

            objSalaryDTO.Year = txtSalaryYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;
            objSalaryDTO.EmployeeId = txtEmployeeId.Text;



            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;



            string strMsg = objSalaryBLL.saveTaxInfo(objSalaryDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;






        }


        public void addWorkerSalary()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "";
            string strCount = gvEmployeeList.Rows.Count.ToString();

            foreach (GridViewRow row in gvEmployeeList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    string strId = (row.FindControl("lblEmployeeId") as Label).Text;

                    objSalaryDTO.EmployeeId = strId;



                    objSalaryDTO.Year = txtSalaryYear.Text;
                    objSalaryDTO.Month = txtsalaryMonth.Text;

                    objSalaryDTO.UpdateBy = strEmployeeId;
                    objSalaryDTO.HeadOfficeId = strHeadOfficeId;
                    objSalaryDTO.BranchOfficeId = strBranchOfficeId;


                    strMsg = objSalaryBLL.addWorkerSalary(objSalaryDTO);


                }


            }



        }

        public void searchSalaryApproveEntryRecord()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            // objEmployeeDTO.FirstSalary = txtFirstSalary.Text;
            //objEmployeeDTO.GrossSalary = txtGrossSalary.Text;


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





            dt = objEmployeeBLL.searchSalaryApproveEntryRecord(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();



                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //addWorkerSalary();

                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
                //addWorkerSalary();
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
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }
        public void loadSalaryApproveEntryRecord()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.Year = txtSalaryYear.Text;
            objEmployeeDTO.Month = txtsalaryMonth.Text;


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





            dt = objEmployeeBLL.loadSalaryApproveEntryRecord(objEmployeeDTO);


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


            int l;
            l = gvEmployeeList.SelectedRow.RowIndex;
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
                        result = gvEmployeeList.SelectedRow.RowIndex + k;
                        txtSLNew.Text = "1";

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
                            result = gvEmployeeList.SelectedRow.RowIndex + k;

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

                string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
                string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;

                string strFirstSalaryPrevious = gvEmployeeList.SelectedRow.Cells[4].Text;
                string strGrossSalaryPrevious = gvEmployeeList.SelectedRow.Cells[5].Text;
                string strEmployeeId = gvEmployeeList.SelectedRow.Cells[6].Text;

                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;

                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;

                txtFirstSalaryPrevious.Text = strFirstSalaryPrevious;
                txtGrossSalaryPrevious.Text = strGrossSalaryPrevious;

                txtFirstSalary.Focus();
                txtEmployeeId.Text = strEmployeeId;


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




            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;

            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;

            string strFirstSalaryPrevious = gvEmployeeList.SelectedRow.Cells[4].Text;
            string strGrossSalaryPrevious = gvEmployeeList.SelectedRow.Cells[5].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[6].Text;

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;

            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            txtFirstSalaryPrevious.Text = strFirstSalaryPrevious;
            txtFirstSalaryPrevious.Text = strGrossSalaryPrevious;

            txtFirstSalary.Focus();
            txtEmployeeId.Text = strEmployeeId;
            // }

            txtFirstSalary.Focus();

        }
        //Increment
        public void AppoinmentApprovalRequest()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO.EmployeeId = txtEmployeeId.Text;
            objSalaryDTO.Year = txtSalaryYear.Text.Trim();
            objSalaryDTO.Month = txtsalaryMonth.Text.Trim();
            objSalaryDTO.GrossSalary = txtGrossSalary.Text.Trim();

            objSalaryDTO.FirstSalary = txtFirstSalary.Text.Trim();
            objSalaryDTO.PreviousFirstSalary = txtFirstSalaryPrevious.Text.Trim();
            objSalaryDTO.PreviousGrossSalary = txtGrossSalaryPrevious.Text.Trim();
            objSalaryDTO.OccurrenceTypeId = 1;

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


            string strMsg = objSalaryBLL.AppoinmentApprovalRequest(objSalaryDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;
            txtGrossSalary.Focus();
            if (strMsg == "ALREAD APPROVED!!!" || strMsg == "PLEASE CHANGE EITHER FIRST OR GROSS SALARY!!!")
            {
                MessageBox(strMsg);
                clearMessage();
                return;
            }
            else
            {
                clearTextBox();
                goToNextRecord();
                searchSalaryEmployee();
                loadSalaryApproveEntryRecord();
            }
        }

        public void searchSalaryEmployee()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            string strUnitId = "";
            string strSectionId = "";

            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;

            objSalaryDTO.EmployeeId = txtEmpId.Text;
            objSalaryDTO.CardNo = txtEmpCardNo.Text;

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                strUnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                strUnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                strSectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                strSectionId = "";

            }





            objSalaryDTO = objSalaryBLL.searchSalaryEmployee(txtEmployeeId.Text, strUnitId, txtCardNo.Text, strSectionId, txtSalaryYear.Text, txtsalaryMonth.Text, strHeadOfficeId, strBranchOfficeId);


            if (objSalaryDTO.GrossSalary == null || objSalaryDTO.GrossSalary == "0")
            {

                txtGrossSalary.Text = "";
            }
            else
            {

                txtGrossSalary.Text = objSalaryDTO.GrossSalary;
            }



            if (objSalaryDTO.FirstSalary == null || objSalaryDTO.FirstSalary == "0")
            {

                txtFirstSalary.Text = "";
            }
            else
            {

                txtFirstSalary.Text = objSalaryDTO.FirstSalary;
            }


            if (objSalaryDTO.PreviousGrossSalary == null || objSalaryDTO.PreviousGrossSalary == "0")
            {

                txtGrossSalaryPrevious.Text = "0";
            }
            else
            {

                txtGrossSalaryPrevious.Text = objSalaryDTO.PreviousGrossSalary;
            }



            if (objSalaryDTO.PreviousFirstSalary == null || objSalaryDTO.PreviousFirstSalary == "0")
            {

                txtFirstSalaryPrevious.Text = "0";
            }
            else
            {

                txtFirstSalaryPrevious.Text = objSalaryDTO.PreviousFirstSalary;
            }



        }
        public void loadSalaryEmployee()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            string strUnitId = "";
            string strSectionId = "";

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                strUnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                strUnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                strSectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                strSectionId = "";

            }





            objSalaryDTO = objSalaryBLL.loadSalaryEmployee(txtEmployeeId.Text, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);

            if (objSalaryDTO.GrossSalary == null || objSalaryDTO.GrossSalary == "0")
            {

                txtGrossSalary.Text = "";
            }
            else
            {

                txtGrossSalary.Text = objSalaryDTO.GrossSalary;
            }



            if (objSalaryDTO.FirstSalary == null || objSalaryDTO.FirstSalary == "0")
            {

                txtFirstSalary.Text = "";
            }
            else
            {

                txtFirstSalary.Text = objSalaryDTO.FirstSalary;
            }

        }



        //public void searchMonthLoanEntryWorker()
        //{
        //    SalaryDTO objSalaryDTO = new SalaryDTO();
        //    SalaryBLL objSalaryBLL = new SalaryBLL();

        //    objSalaryDTO = objSalaryBLL.searchMonthLoanEntryStaff(txtEmployeeId.Text, txtSalaryYear.Text, txtsalaryMonth.Text, strHeadOfficeId, strBranchOfficeId);

        //    if (objSalaryDTO.LoanAmount == null || objSalaryDTO.LoanAmount == "0")
        //    {

        //        txtLoanAmount.Text = "";
        //    }
        //    else
        //    {

        //        txtLoanAmount.Text = objSalaryDTO.LoanAmount;
        //    }





        //}


        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }









        public void processSalaryStaff()
        {


            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objSalaryDTO.SectionId = "";
            }



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.UnitId = "";

            }
            objSalaryDTO.Year = txtSalaryYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;

            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;

            string strMsg = objSalaryBLL.processSalaryStaff(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }
        public void HalfSalaryStaff()
        {


            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objSalaryDTO.SectionId = "";
            }



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.UnitId = "";

            }
            objSalaryDTO.Year = txtSalaryYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;

            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;

            string strMsg = objSalaryBLL.HalfSalaryStaff(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }

        public void empSalaryApproveSheet()
        {
            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();




                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.UpdateBy = strEmployeeId;


                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;
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


        public void monthlyStaffSalaryPaySlip()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;


                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;


                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {

                    objReportDTO.SectionId = "";
                }


                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";

                }



                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

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
        public void halfSheetStaff()
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



            objReportDTO.Year = txtSalaryYear.Text;
            objReportDTO.Month = txtsalaryMonth.Text;



            string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSheetStaff.rpt"));
            this.Context.Session["strReportPath"] = strPath;
            rd.Load(strPath);
            rd.SetDataSource(objReportBLL.rptHalfSheetStaff(objReportDTO));


            rd.SetDatabaseLogon("erp", "erp");
            CrystalReportViewer1.ReportSource = rd;
            CrystalReportViewer1.DataBind();

            reportMaster();


        }










        public void monthlySalaryRequisitionHOStaff()
        {

            try
            {

                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

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


                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRequisitionHOStaff.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.monthlySalaryRequisitionHOStaff(objReportDTO));


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

        public void monthlySalaryRequisitionBankStaff()
        {

            try
            {

                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

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


                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyBankSalaryRequisitionStaff.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.monthlySalaryRequisitionBankStaff(objReportDTO));


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

        public void processSalaryRequisitionHoBankStaff()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.EmployeeId = txtEmpId.Text;

            objReportDTO.Year = txtSalaryYear.Text;
            objReportDTO.Month = txtsalaryMonth.Text;


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.SectionId = "";
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
            string strMsg = objReportBLL.processSalaryRequisitionHoBankStaff(objReportDTO);




        }

        public void processSalaryRequisitionHoStaff()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.EmployeeId = txtEmpId.Text;

            objReportDTO.Year = txtSalaryYear.Text;
            objReportDTO.Month = txtsalaryMonth.Text;


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.SectionId = "";
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
            string strMsg = objReportBLL.processSalaryRequisitionHoStaff(objReportDTO);




        }


        public void processWorkingDayStaff()
        {


            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objSalaryDTO.SectionId = "";
            }



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.UnitId = "";

            }
            objSalaryDTO.Year = txtSalaryYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;

            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;

            string strMsg = objSalaryBLL.processWorkingDayStaff(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }




        #endregion



        protected void btnSave_Click(object sender, EventArgs e)
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
                else if (txtEmployeeId.Text == string.Empty)
                {
                    string strMsg = "Please click in the Gridview!!!";
                    MessageBox(strMsg);
                    return;
                }

                else if (txtGrossSalary.Text == string.Empty && txtFirstSalary.Text == string.Empty)
                {
                    goToNextRecord();
                    searchSalaryEmployee();
                    clearMessage();
                }
                else
                {
                  AppoinmentApprovalRequest();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }

        //protected void btnNext_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (gvEmployeeList.Rows.Count == 0)
        //        {
        //            string strMsg = "Please click searh Button!!!";
        //            MessageBox(strMsg);
        //            btnSearch.Focus();
        //            return;
        //        }
        //        else if (ddlUnitId.Text == " ")
        //        {

        //            string strMsg = "Please Select Unit Name!!!";
        //            MessageBox(strMsg);
        //            ddlUnitId.Focus();
        //            return;
        //        }

        //        else if (ddlSectionId.Text == " ")
        //        {

        //            string strMsg = "Please Select Section Name!!!";
        //            MessageBox(strMsg);
        //            ddlSectionId.Focus();
        //            return;
        //        }

        //        else
        //        {

        //            goToNextRecord();
        //            searchMiscEntryStaff();
        //            searchMonthLoanEntryWorker();
        //            clearMessage();


        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error " + ex.Message);

        //    }
        //}

        //protected void btnPrevious_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (gvEmployeeList.Rows.Count == 0)
        //        {
        //            string strMsg = "Please click searh Button!!!";
        //            MessageBox(strMsg);
        //            btnSearch.Focus();
        //            return;
        //        }
        //        else if (ddlUnitId.Text == " ")
        //        {

        //            string strMsg = "Please Select Unit Name!!!";
        //            MessageBox(strMsg);
        //            ddlUnitId.Focus();
        //            return;
        //        }

        //        else if (ddlSectionId.Text == " ")
        //        {

        //            string strMsg = "Please Select Section Name!!!";
        //            MessageBox(strMsg);
        //            ddlSectionId.Focus();
        //            return;
        //        }


        //        else
        //        {

        //            if (txtEmployeeId.Text == string.Empty)
        //            {
        //                string strMsg = "Please click in the Gridview!!!";
        //                MessageBox(strMsg);
        //                return;
        //            }
        //            else
        //            {

        //                goToPreviousRecord();
        //                searchMiscEntryStaff();
        //                searchMonthLoanEntryWorker();
        //                clearMessage();
        //            }


        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error " + ex.Message);

        //    }
        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnitId.Text == " ")
                {

                    string strMsg = "Please Select Unit Name!!!";
                    MessageBox(strMsg);
                    ddlUnitId.Focus();
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

                    searchSalaryApproveEntryRecord();
                    clearYellowTextBox();
                    clearTextBox();
                    gvEmployeeList.SelectedIndex = 0;
                    goToNextRecord();
                    searchSalaryEmployee();
                    loadSalaryApproveEntryRecord();


                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void txtEmployeeId_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtArrearFee_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                //searchSalaryInfoStaff();

            }

            catch (Exception ex)
            {
                throw new Exception("Error :" + ex.Message);

            }
        }

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
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[6].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strFirstSalary = gvEmployeeList.SelectedRow.Cells[4].Text;
            string strGrossSalary = gvEmployeeList.SelectedRow.Cells[5].Text;

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            txtFirstSalary.Text = strFirstSalary;
            txtGrossSalary.Text = strGrossSalary;
            searchSalaryEmployee();
            // searchMonthLoanEntryWorker();
            txtGrossSalary.Focus();

        }


        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }


        protected void gvEmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //if (e.CommandName == "Select")
            //{

            //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            //    string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            //    string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            //    string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
            //    string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            //    string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


            //    txtSL.Text = Convert.ToString(strRowId);
            //    txtCardNo.Text = strCardNo;
            //    txtEmployeeId.Text = strEmployeeId;
            //    txtEmployeeName.Text = strEmployeeName;
            //    txtDesignationName.Text = strDesignation;

            //    searchMiscEntryStaff();
            //    txtAdvanceFee.Focus();

            //}
            //if (e.CommandName == "Edit")
            //{
            //}
            //if (e.CommandName == "Delete")
            //{

            //}


            //int selectedRowIndex = gvEmployeeList.SelectedRow.RowIndex;
            //gvEmployeeList.Rows[selectedRowIndex].Cells[1].Attributes["style"] += "background-color:Red;";


        }

        #endregion
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
            string strFirstSalary = GridView1.SelectedRow.Cells[6].Text;
            string strGrossSalary = GridView1.SelectedRow.Cells[7].Text;

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            txtFirstSalary.Text = strFirstSalary;
            txtGrossSalary.Text = strGrossSalary;


            searchSalaryEmployee();
            //searchMonthLoanEntryWorker();
            txtGrossSalary.Focus();


        }



        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{

            //    int strRowId = GridView1.SelectedRow.RowIndex + 1;
            //    string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            //    string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            //    string strEmployeeId = GridView1.SelectedRow.Cells[9].Text;
            //    string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            //    string strDesignation = GridView1.SelectedRow.Cells[3].Text;



            //    txtSL.Text = Convert.ToString(strRowId);
            //    txtCardNo.Text = strCardNo;
            //    txtEmployeeId.Text = strEmployeeId;
            //    txtEmployeeName.Text = strEmployeeName;
            //    txtDesignationName.Text = strDesignation;


            //    searchMiscEntryStaff();

            //    txtAdvanceFee.Focus();

            //}
            //if (e.CommandName == "Edit")
            //{
            //}
            //if (e.CommandName == "Delete")
            //{

            //}




            //int selectedRowIndex = GridView1.SelectedRow.RowIndex;
            //GridView1.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }
        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
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

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;

                }

                else if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;

                }



                else
                {
                    processSalaryStaff();
                    loadSalaryApproveEntryRecord();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }



        protected void btnMonthlyStaffSalarySheet_Click(object sender, EventArgs e)
        {
            try
            {


                empSalaryApproveSheet();





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





        protected void btnMonthlyStaffPaySlip_Click(object sender, EventArgs e)
        {

            try
            {

                if (ddlUnitId.Text == " ")
                {

                    string strMsg = "Please Select Unit Name!!!";
                    MessageBox(strMsg);
                    ddlUnitId.Focus();
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
                    monthlyStaffSalaryPaySlip();

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



        #region "Crystal Report Functionality"

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            this.CrystalReportViewer1.Dispose();
            this.CrystalReportViewer1 = null;
            rd.Dispose();
            rd.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();

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

        protected void btnHalfSheetStaff_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlUnitId.Text == " ")
                {

                    string strMsg = "Please Select Unit Name!!!";
                    MessageBox(strMsg);
                    ddlUnitId.Focus();
                    return;
                }

                else if (ddlSectionId.Text == " ")
                {

                    string strMsg = "Please Select Section Name!!!";
                    MessageBox(strMsg);
                    ddlSectionId.Focus();
                    return;
                }

                else if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;

                }

                else if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;

                }



                else
                {
                    HalfSalaryStaff();
                    halfSheetStaff();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }

        protected void btnSalaryRequisitionHOStaff_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;

                }

                else if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;

                }

                else
                {

                    processSalaryRequisitionHoStaff();
                    monthlySalaryRequisitionHOStaff();

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

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        if (gvEmployeeList.Rows.Count == 0)
        //        {
        //            string strMsg = "Please click searh Button!!!";
        //            MessageBox(strMsg);
        //            clearMessage();
        //            btnSearch.Focus();

        //            return;
        //        }


        //        else if (txtSalaryYear.Text == string.Empty)
        //        {
        //            string strMsg = "Please Enter Year!!!";
        //            MessageBox(strMsg);
        //            txtSalaryYear.Focus();
        //            return;

        //        }

        //        if (txtsalaryMonth.Text == string.Empty)
        //        {
        //            string strMsg = "Please Enter Month!!!";
        //            MessageBox(strMsg);
        //            txtsalaryMonth.Focus();
        //            return;

        //        }



        //        else
        //        {
        //            processWorkingDayStaff();
        //            searchSalaryInfoStaff();
        //            searchMiscEntryStaff();
        //            searchMonthLoanEntryWorker();



        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error " + ex.Message);

        //    }
        //}

        protected void btnBankSheet_Click(object sender, EventArgs e)
        {

            if (txtSalaryYear.Text == string.Empty)
            {
                string strMsg = "Please Enter Year!!!";
                MessageBox(strMsg);
                txtSalaryYear.Focus();
                return;

            }

            else if (txtsalaryMonth.Text == string.Empty)
            {
                string strMsg = "Please Enter Month!!!";
                MessageBox(strMsg);
                txtsalaryMonth.Focus();
                return;

            }


            else
            {

                monthlyBankSheet();

            }
        }

        public void monthlyBankSheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            selectBankSalaryProcedure();


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            objReportDTO.Year = txtSalaryYear.Text;
            objReportDTO.Month = txtsalaryMonth.Text;


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.SectionId = "";
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

            reportMaster();

        }



        public void selectBankSalaryProcedure()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.Year = txtSalaryYear.Text;
            objReportDTO.Month = txtsalaryMonth.Text;

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.SectionId = "";
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

        protected void btnBankRequisitionSheet_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;

                }

                else if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;

                }

                else
                {

                    processSalaryRequisitionHoBankStaff();
                    monthlySalaryRequisitionBankStaff();

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
                else if (ddlUnitId.Text == " ")
                {

                    string strMsg = "Please Select Unit Name!!!";
                    MessageBox(strMsg);
                    ddlUnitId.Focus();
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
                    clearTextBox();
                    goToPreviousRecord();
                    searchSalaryEmployee();
                    clearMessage();


                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

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
                else if (ddlUnitId.Text == " ")
                {

                    string strMsg = "Please Select Unit Name!!!";
                    MessageBox(strMsg);
                    ddlUnitId.Focus();
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

                    clearTextBox();
                    goToNextRecord();
                    searchSalaryEmployee();
                    clearMessage();


                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        protected void btnShow_Click1(object sender, EventArgs e)
        {
            loadSalaryApproveEntryRecord();
        }
    }
}