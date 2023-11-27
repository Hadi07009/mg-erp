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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class BonusProcessStaff : System.Web.UI.Page
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
                getEidTypeId();


            }
            if (IsPostBack)
            {

                loadSesscion();

            }
            gvEmployeeList.Columns[5].Visible = false;
            if (strBranchOfficeId == "110")
            {
                btnBonusPaySlipStaffFirst.Visible = false;
                btnSecondSheet.Visible = false;
                btnBonusPaySlipStaffSecond.Visible = false;
                btnSummery.Visible = false;
            }
            if (strBranchOfficeId == "103" || strBranchOfficeId == "102" )
            {
                BtnBankDetailSheet.Visible = false;
                BtnSheetAll.Visible = false;
                btnBankSheet.Visible = false;
                btnBankBonusRequisitionStaff.Visible = false;
                BtnProcessRequisitionAll.Visible = false;
            }
            //txtBonusAmount.Attributes.Add("onkeypress", "return controlEnter('" + txtSecondBonusAmount.ClientID + "', event)");
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
        public void getMonthYearForTax()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtYear.Text = objLookUpDTO.Year;
     

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
                string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
                string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
                string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;

                txtBonusAmount.Focus();

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
                    txtBonusAmount.Focus();
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
                    txtBonusAmount.Focus();
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
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            txtBonusAmount.Focus();
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
            else if (chkExcel.Checked == true)
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
            else
            {

                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                formatType = ExportFormatType.PortableDocFormat;
                MemoryStream oStream;
                Response.Clear();
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                oStream = (MemoryStream)rd.ExportToStream(formatType);
                Response.ContentType = "application/Pdf";
                oStream.Seek(0, SeekOrigin.Begin);
                Response.BinaryWrite(oStream.ToArray());
                //Response.End();
                oStream.Flush();
                oStream.Close();
                oStream.Dispose();
                CrystalReportViewer1.RefreshReport();

            }



        }

        public void saveBonusStaff()
        {


            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            
                    //if (ddlSectionId.SelectedValue.ToString() != " ")
                    //{
                    //    objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    //}
                    //else
                    //{
                    //    objSalaryDTO.SectionId = "";
                    //}
                    
                    //if (ddlUnitId.SelectedValue.ToString() != " ")
                    //{
                    //    objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    //}
                    //else
                    //{
                    //    objSalaryDTO.UnitId = "";
                    //}
                    //if (ddlUnitGroupId.SelectedValue.ToString() != "")
                    //{
                    //    objSalaryDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                    //}
                    //else
                    //{
                    //    objSalaryDTO.UnitGroupId = "";
                    //}

                    objSalaryDTO.Year = txtYear.Text;

                    if (ddlEidTypeId.SelectedValue.ToString() != " ")
                    {
                        objSalaryDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                    }
                    else
                    {
                        objSalaryDTO.EidTypeId = "";
                    }
                    
                    objSalaryDTO.HeadOfficeId = strHeadOfficeId;
                    objSalaryDTO.BranchOfficeId = strBranchOfficeId;
                    objSalaryDTO.UpdateBy = strEmployeeId;

                    string strMsg = objSalaryBLL.saveBonusStaff(objSalaryDTO);
                    
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

        protected void btnProcess_Click(object sender, EventArgs e)
        {


            if (ddlEidTypeId.Text == " ")
            {

                string strMsg = "Please Select Eid Name!!!";
                MessageBox(strMsg);
                ddlEidTypeId.Focus();
                return;
            }
             if (txtYear.Text == " ")
             {

                 string strMsg = "Please Enter Eid Year!!!";
                 MessageBox(strMsg);
                 txtYear.Focus();
                 return;
             }

            else
            {
                //ADDED ON 103.07.2021
                //saveBonusStaff();

                processBonusStaff();
                //commented on 10.07.2021
                if (ddlUnitGroupId.SelectedValue == "" && ddlUnitId.SelectedValue != " " && ddlSectionId.SelectedValue != " ")
                {
                    searchStaffBonusEntry();
                }

                //searchBonusEntryStaff();

            }
        }


        public void processBonusStaff()
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
            if (ddlUnitGroupId.SelectedValue.ToString() != "")
            {
                objSalaryDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.UnitGroupId = "";
            }
            objSalaryDTO.Year = txtYear.Text;

            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.EidTypeId = "";

            }


            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;

            string strMsg = objSalaryBLL.BonusProcessStaff(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;
            
        }
        public void bonusSummeryStaff()
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
            objSalaryDTO.Year = txtYear.Text;

            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {

                objSalaryDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();

            }
            else
            {
                objSalaryDTO.EidTypeId = "";

            }


            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;

            string strMsg = objSalaryBLL.bonusSummeryStaff(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }
        public void saveBonusProcessStaff()
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
            objSalaryDTO.Year = txtYear.Text;

            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {

                objSalaryDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();

            }
            else
            {
                objSalaryDTO.EidTypeId = "";

            }

            objSalaryDTO.EmployeeId = txtEmployeeId.Text;
            objSalaryDTO.Year = txtYear.Text;
            objSalaryDTO.Bonus = txtBonusAmount.Text;
            objSalaryDTO.SecondBonus = txtSecondBonusAmount.Text;


            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;

            string strMsg = objSalaryBLL.saveBonusProcessStaff(objSalaryDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchStaffBonusEntry();
        }

        public void searchBonusEntryStaff()
        {


            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            string strUnitId = "";
            string strSectionId = "";
            string strEidTypeId = "";

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

            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                strEidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {
                strEidTypeId = "";

            }



            objSalaryDTO = objSalaryBLL.searchBonusEntryStaff(txtEmployeeId.Text, strEidTypeId, txtYear.Text, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);

            if (objSalaryDTO.Bonus == null || objSalaryDTO.Bonus == "0")
            {

                txtBonusAmount.Text = "0";

            }
            else
            {

                txtBonusAmount.Text = objSalaryDTO.Bonus;
            }

            if (objSalaryDTO.SecondBonus == null || objSalaryDTO.SecondBonus == "0")
            {

                txtSecondBonusAmount.Text = "0";

            }
            else
            {

                txtSecondBonusAmount.Text = objSalaryDTO.SecondBonus;
            }

           
            


            txtBonusAmount.Focus();






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


        #region "Grid View Functionality"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
           
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {


            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[10].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            searchBonusEntryStaff();

            txtBonusAmount.Focus();



        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{

            //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            //    string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            //    string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            //    string strEmployeeId = gvEmployeeList.SelectedRow.Cells[5].Text;
            //    string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            //    string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


            //    txtSL.Text = Convert.ToString(strRowId);
            //    txtCardNo.Text = strCardNo;
            //    txtEmployeeId.Text = strEmployeeId;
            //    txtEmployeeName.Text = strEmployeeName;
            //    txtDesignationName.Text = strDesignation;

            //    searchMiscEntryWorker();
            //    txtWorkingDay.Focus();

            //}
            //if (e.CommandName == "Edit")
            //{
            //}
            //if (e.CommandName == "Delete")
            //{

            //}

            //int selectedRowIndex = gvEmployeeList.SelectedRow.RowIndex;
            //gvEmployeeList.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }

        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {

        }


        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {



            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");



        }




        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }


        public void searchStaffBonusEntry()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.Year = txtYear.Text;
           

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


            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.EidTypeId = "";

            }


            dt = objEmployeeBLL.searchStaffBonusEntry(objEmployeeDTO);


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

        #endregion


        //New
        public void FirstBonusSheetStaff(ReportDTO objReport)
        {

            try
            {
                ReportDTO objReportDTO = objReport;
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
                
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
                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";
                }
                objReportDTO.Year = txtYear.Text;

                if (strBranchOfficeId == "110")
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffBP.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.bonusSheetStaff(objReportDTO));
                }
                else
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.FirstBonusSheetStaff(objReportDTO));
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

        //New
        //GetBankBonusSheetStaff
        public void GetBankBonusSheetStaff()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

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
                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";
                }
                objReportDTO.Year = txtYear.Text;

                if (strBranchOfficeId == "110")
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffBP.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetBankBonusSheetStaff(objReportDTO));
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

        public void GetAllBonusSheetStaff()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

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
                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";
                }
                objReportDTO.Year = txtYear.Text;

                if (strBranchOfficeId == "110")
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffBP.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetAllBonusSheetStaff(objReportDTO));
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

        //Old
        public void bonusSheetStaff()
        {

            try
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";

                }


                objReportDTO.Year = txtYear.Text;


                if(strBranchOfficeId == "110")
                {

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffBP.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.bonusSheetStaff(objReportDTO));
                }
                else
                {

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.bonusSheetStaff(objReportDTO));

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
        public void bonusPaySlipStaffFirst()
        {

            try
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";

                }


                objReportDTO.Year = txtYear.Text;


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusPaySlipStaff.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.bonusPaySlipStaffFirst(objReportDTO));


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
        public void bonusPaySlipStaffMisc()
        {

            try
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";

                }


                objReportDTO.Year = txtYear.Text;


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusPaySlipStaffMisc.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.bonusPaySlipStaffMisc(objReportDTO));


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

        //New
        public void SecondBonusSheetStaff()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                //New
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
                
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";
                }
                objReportDTO.Year = txtYear.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffMisc.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.SecondBonusSheetStaff(objReportDTO));

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


        //Old
        public void bonusSheetStaffMisc()
        {

            try
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";

                }


                objReportDTO.Year = txtYear.Text;

               
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffMisc.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.bonusSheetStaffMisc(objReportDTO));

                



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


        public void StaffBonusSummerySheet()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";
                }
                objReportDTO.Year = txtYear.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSummeryStaff.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.StaffBonusSummerySheet(objReportDTO));

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


        //Old
        public void bonusSummerySheetStaff()
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

            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.EidTypeId = "";

            }


            objReportDTO.Year = txtYear.Text;


            string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSummeryStaff.rpt"));
            this.Context.Session["strReportPath"] = strPath;
            rd.Load(strPath);
            rd.SetDataSource(objReportBLL.bonusSummerySheetStaff(objReportDTO));


            rd.SetDatabaseLogon("erp", "erp");
            CrystalReportViewer1.ReportSource = rd;
            CrystalReportViewer1.DataBind();

            reportMaster();



        }
                        
        protected void btnSecondSheet_Click(object sender, EventArgs e)
        {
            try
            {

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
                //if (ddlEmployeeTypeId.SelectedItem.Value == "")
                //{
                //    string strMsg = "Please Select Employee Type!!!";
                //    MessageBox(strMsg);
                //    ddlEmployeeTypeId.Focus();
                //    return;
                //}

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                if (txtYear.Text == "")
                {

                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                SecondBonusSheetStaff();
                
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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click Process Button!!!";
                    MessageBox(strMsg);
                    btnProcess.Focus();
                    return;
                }

                else if (txtEmployeeId.Text == "")
                {
                    string strMsg = "Please Click in the Gridview!!!";
                    MessageBox(strMsg);
                 
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

                    goToNextRecord();
                    searchBonusEntryStaff();
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
                    string strMsg = "Please click Process Button!!!";
                    MessageBox(strMsg);
                    btnProcess.Focus();
                    return;
                }
                else if (txtEmployeeId.Text == "")
                {
                    string strMsg = "Please Click in the Gridview!!!";
                    MessageBox(strMsg);

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

                    goToPreviousRecord();
                    searchBonusEntryStaff();
                    clearMessage();


                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click Process Button!!!";
                    MessageBox(strMsg);
                    clearMessage();
                    btnProcess.Focus();

                    return;
                }
                else if (txtEmployeeId.Text == string.Empty)
                {
                    string strMsg = "Please click in the Gridview!!!";
                    MessageBox(strMsg);
                    clearMessage();
                    return;

                }



                else if (txtBonusAmount.Text == "" || txtBonusAmount.Text == string.Empty)
                {
                    saveBonusProcessStaff();
                    goToNextRecord();
                    searchBonusEntryStaff();
                    clearMessage();
                }



                else
                {

                    saveBonusProcessStaff();
                    //processBonusStaff();
                    searchStaffBonusEntry();
                    goToNextRecord();
                    searchBonusEntryStaff();
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        public void searchStaffRecordforBonus()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;

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





            dt = objEmployeeBLL.searchStaffRecordforBonus(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
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
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }



        protected void btnSummery_Click(object sender, EventArgs e)
        {
            try
            {

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
                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                bonusSummeryStaff();
                StaffBonusSummerySheet();
                //bonusSummerySheetStaff();


                //    if (ddlUnitId.Text == " ")
                //    {
                //        string strMsg = "Please Select Unit Name!!!";
                //        MessageBox(strMsg);
                //        ddlUnitId.Focus();
                //        return;
                //    }
                //    else if (ddlSectionId.Text == " ")
                //    {
                //        string strMsg = "Please Select Section Name!!!";
                //        MessageBox(strMsg);
                //        ddlSectionId.Focus();
                //        return;
                //    }
                //    else if (ddlEidTypeId.Text == " ")
                //    {
                //        string strMsg = "Please Select Eid Name!!!";
                //        MessageBox(strMsg);
                //        ddlEidTypeId.Focus();
                //        return;
                //    }
                //    else
                //    {
                //        bonusSummeryStaff();
                //        bonusSummerySheetStaff();
                //    }
            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }


        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;

        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {


            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            searchBonusEntryStaff();

            txtBonusAmount.Focus();




        }




        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void gvEmployeeList_OnRowEditing(object sender, GridViewEditEventArgs e)
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


        protected void gvEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
        {

        }


       
        #endregion

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvEmployeeList.Rows.Count == 0)
            {
                string strMsg = "Please click searh Button!!!";
                MessageBox(strMsg);
                btnProcess.Focus();
                return;
            }

            else if (txtEmployeeId.Text == "")
            {
                string strMsg = "Please Click in the Gridview!!!";
                MessageBox(strMsg);
                gvEmployeeList.Focus();
                return;

            }
            else
            {


                deleteBonusStaff();
                searchStaffBonusEntry();
                goToNextRecord();
                searchBonusEntryStaff();
                
            }
        }

        public void deleteBonusAddStaff()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
           
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
            string strMsg = objReportBLL.deleteBonusAddStaff(objReportDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }

        public void deleteBonusStaff()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.EmployeeId = txtEmployeeId.Text;
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
            string strMsg = objReportBLL.deleteBonusStaff(objReportDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }

        protected void btnBonusPaySlipStaffFirst_Click(object sender, EventArgs e)
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

                else if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }

                else
                {

                    bonusPaySlipStaffFirst();

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

        protected void btnBonusPaySlipStaffSecond_Click(object sender, EventArgs e)
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

                else if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }

                else
                {

                    bonusPaySlipStaffMisc();

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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }

                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }

                //deleteBonusAddStaff();
                saveBonusStaff();

                //if (gvEmployeeList.Rows.Count == 0)
                //{
                //    string strMsg = "Please click Search Button!!!";
                //    MessageBox(strMsg);
                //    clearMessage();
                //    btnSearch.Focus();
                //    return;
                //}

                //else if (ddlUnitId.Text == " ")
                //{

                //    string strMsg = "Please Select Unit Name!!!";
                //    MessageBox(strMsg);
                //    ddlUnitId.Focus();
                //    return;
                //}

                //else if (ddlSectionId.Text == " ")
                //{

                //    string strMsg = "Please Select Section Name!!!";
                //    MessageBox(strMsg);
                //    ddlSectionId.Focus();
                //    return;
                //}

                //else if (ddlEidTypeId.Text == " ")
                //{

                //    string strMsg = "Please Select Eid Name!!!";
                //    MessageBox(strMsg);
                //    ddlEidTypeId.Focus();
                //    return;
                //}
                //else
                //{
                //    deleteBonusAddStaff();
                //    saveBonusStaff();
                //}
            }
            catch (Exception ex)
            {

                throw new Exception("Error : "+ ex.Message);
            }
        }

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

                    searchStaffRecordforBonus();
                    clearYellowTextBox();
                    gvEmployeeList.SelectedIndex = 0;
                    goToNextRecord();

                    searchStaffBonusEntry();
                    searchBonusEntryStaff();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnBankSheet_Click(object sender, EventArgs e)
        {
            try
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

                    selectBonusBankProcedure();
                    bankBonusSheet();

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
        public void bonusRequisitionStaff()
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

            string strMsg = objReportBLL.bonusRequisitionStaff(objReportDTO);
            MessageBox(strMsg);




        }
        public void bonusBankRequisitionStaff()
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

            string strMsg = objReportBLL.bonusBankRequisitionStaff(objReportDTO);
            MessageBox(strMsg);




        }


        public void bankBonusSheet()
        {

            try
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";

                }


                objReportDTO.Year = txtYear.Text;

                if (strBranchOfficeId == "106" || strBranchOfficeId == "109")
                {

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusBankSheetVERL.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.rptBankBonusSheet(objReportDTO));

                }
                else
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetBank.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.bankBonusSheet(objReportDTO));

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

        public void bonusRequisitionSheetStaff()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                bonusRequisitionStaff();

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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";

                }


                objReportDTO.Year = txtYear.Text;

              

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusRequisitionStaff.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.bonusRequisitionSheetStaff(objReportDTO));


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
        public void bonusRequisitionBankSheetStaff()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                bonusBankRequisitionStaff();
                //ProcessEidBonusRequisitionStaff();

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
                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";
                }
                objReportDTO.Year = txtYear.Text;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusBankRequisitionStaff.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.bonusRequisitionBankSheetStaff(objReportDTO));


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


        public void ProcessEidBonusRequisitionStaff(ReportDTO obj)
        {
            try
            {
                ReportDTO objReportDTO = obj;
                ReportBLL objReportBLL = new ReportBLL();
                
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
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
                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";
                }
                objReportDTO.Year = txtYear.Text;

                string message = objReportBLL.ProcessEidBonusRequisitionStaff(objReportDTO);
                                
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusRequisitionStaff.rpt"));
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEidBonusRequisitionStaff(objReportDTO));


                //Old Code
                //strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusRequisitionStaff.rpt"));
                //this.Context.Session["strReportPath"] = strPath;
                //rd.Load(strPath);
                //rd.SetDataSource(objReportBLL.bonusRequisitionSheetStaff(objReportDTO));

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
        
        //new
        public void ProcessAllBonusRequisitionStaff()
        {

            try
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";
                }
                objReportDTO.Year = txtYear.Text;

                objReportBLL.ProcessAllBonusRequisitionStaff(objReportDTO);
                
                                
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusBankRequisitionStaff.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.bonusRequisitionBankSheetStaff(objReportDTO));


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

        //public void bonusBankRequisitionStaff()
        //{

        //    ReportDTO objReportDTO = new ReportDTO();
        //    ReportBLL objReportBLL = new ReportBLL();



        //    objReportDTO.Year = txtYear.Text;


        //    if (ddlEidTypeId.SelectedValue.ToString() != " ")
        //    {
        //        objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
        //    }
        //    else
        //    {

        //        objReportDTO.EidTypeId = "";
        //    }


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


        //    objReportDTO.HeadOfficeId = strHeadOfficeId;
        //    objReportDTO.BranchOfficeId = strBranchOfficeId;
        //    objReportDTO.UpdateBy = strEmployeeId;

        //    string strMsg = objReportBLL.ProcessAllBonusRequisitionStaff(objReportDTO);
        //    MessageBox(strMsg);

        //}


        protected void btnBonusRequisitionStaff_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;

                }

                ReportDTO objReportDTO = new ReportDTO();
                objReportDTO.accountYn = "N";
                ProcessEidBonusRequisitionStaff(objReportDTO);

                //else
                //{
                //    bonusRequisitionSheetStaff();
                //}
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

        protected void btnBankBonusRequisitionStaff_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }

                if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }

                ReportDTO objReportDTO = new ReportDTO();
                objReportDTO.accountYn = "Y";
                ProcessEidBonusRequisitionStaff(objReportDTO);

                //else
                //{
                //    //bonusRequisitionBankSheetStaff();

                //}
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

        protected void BtnBankDetailSheet_Click(object sender, EventArgs e)
        {
            try
            {
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
                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }

                ReportDTO objReportDTO = new ReportDTO();
                objReportDTO.accountYn = "Y";
                //GetEidBonusStaff(objReportDTO);
                GetStaffBankBonus(objReportDTO);


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

        protected void BtnSheetAll_Click(object sender, EventArgs e)
        {
            try
            {
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
                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }

                ReportDTO objReportDTO = new ReportDTO();
                objReportDTO.accountYn = string.Empty;
                GetEidBonusStaff(objReportDTO);

                //GetAllBonusSheetStaff();
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

        protected void BtnProcessRequisitionAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }

                ReportDTO objReportDTO = new ReportDTO();
                objReportDTO.accountYn = string.Empty;
                ProcessEidBonusRequisitionStaff(objReportDTO);

                //else
                //{
                //    ProcessAllBonusRequisitionStaff();
                //}
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


        public void GetStaff(ReportDTO obj)
        {

            try
            {
                ReportDTO objReportDTO = obj;
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
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
                objReportDTO.Year = txtYear.Text;
                objReportDTO.payment_mode = 3;

                //start: new code
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaff.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetStaffBkashSheet(objReportDTO));


                //old code fron cash sheet
                //if (strBranchOfficeId == "110")
                //{
                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffBP.rpt"));
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.GetEidBonusStaff(objReportDTO));
                //}
                //else
                //{
                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaff.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.FirstBonusSheetStaff(objReportDTO));
                //}

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

        public void GetStaffBkashBonus(ReportDTO obj)
        {

            try
            {
                ReportDTO objReportDTO = obj;
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
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
                objReportDTO.Year = txtYear.Text;
                objReportDTO.payment_mode = 2;

                //start: new code
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffBkash.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetStaffEidBonus(objReportDTO));
                
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

            //try
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

            //    if (ddlUnitId.SelectedValue.ToString() != " ")
            //    {
            //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            //    }
            //    else
            //    {
            //        objReportDTO.UnitId = "";
            //    }
            //    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
            //    objReportDTO.EmployeeId = txtEmpId.Text;
            //    objReportDTO.CardNo = txtEmpCardNo.Text;

            //    objReportDTO.Year = txtSalaryYear.Text;
            //    objReportDTO.Month = txtsalaryMonth.Text;

            //    objReportDTO.HeadOfficeId = strHeadOfficeId;
            //    objReportDTO.BranchOfficeId = strBranchOfficeId;
            //    objReportDTO.UpdateBy = strEmployeeId;

            //    if (strBranchOfficeId == "110")
            //    {
            //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaffBP.rpt"));
            //        rd.Load(strPath);
            //        //rd.SetDataSource(objReportBLL.SalarySheetStaff(objReportDTO));
            //        rd.SetDataSource(objReportBLL.GetStaffSalarySheetAsCash(objReportDTO));
            //    }
            //    else
            //    {
            //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaff.rpt"));
            //        rd.Load(strPath);
            //        rd.SetDataSource(objReportBLL.GetStaffSalarySheet(objReportDTO));
            //    }
            //    rd.SetDatabaseLogon("erp", "erp");
            //    CrystalReportViewer1.ReportSource = rd;
            //    CrystalReportViewer1.DataBind();
            //    reportMaster();
            //    this.CrystalReportViewer1.Dispose();
            //    this.CrystalReportViewer1 = null;
            //    rd.Dispose();
            //    rd.Close();
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}

            //catch (Exception ex)
            //{
            //    this.CrystalReportViewer1.Dispose();
            //    this.CrystalReportViewer1 = null;
            //    rd.Dispose();
            //    rd.Close();
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}
        }
        public void GetStaffBankBonus(ReportDTO obj)
        {

            try
            {
                ReportDTO objReportDTO = obj;
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
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
                objReportDTO.Year = txtYear.Text;
                objReportDTO.payment_mode = 1;

                //start: new code
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffBkash.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetStaffEidBonus(objReportDTO));


                //old code fron cash sheet
                //if (strBranchOfficeId == "110")
                //{
                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffBP.rpt"));
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.GetEidBonusStaff(objReportDTO));
                //}
                //else
                //{
                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaff.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.FirstBonusSheetStaff(objReportDTO));
                //}

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

            //try
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

            //    if (ddlUnitId.SelectedValue.ToString() != " ")
            //    {
            //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            //    }
            //    else
            //    {
            //        objReportDTO.UnitId = "";
            //    }
            //    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
            //    objReportDTO.EmployeeId = txtEmpId.Text;
            //    objReportDTO.CardNo = txtEmpCardNo.Text;

            //    objReportDTO.Year = txtSalaryYear.Text;
            //    objReportDTO.Month = txtsalaryMonth.Text;

            //    objReportDTO.HeadOfficeId = strHeadOfficeId;
            //    objReportDTO.BranchOfficeId = strBranchOfficeId;
            //    objReportDTO.UpdateBy = strEmployeeId;

            //    if (strBranchOfficeId == "110")
            //    {
            //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaffBP.rpt"));
            //        rd.Load(strPath);
            //        //rd.SetDataSource(objReportBLL.SalarySheetStaff(objReportDTO));
            //        rd.SetDataSource(objReportBLL.GetStaffSalarySheetAsCash(objReportDTO));
            //    }
            //    else
            //    {
            //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaff.rpt"));
            //        rd.Load(strPath);
            //        rd.SetDataSource(objReportBLL.GetStaffSalarySheet(objReportDTO));
            //    }
            //    rd.SetDatabaseLogon("erp", "erp");
            //    CrystalReportViewer1.ReportSource = rd;
            //    CrystalReportViewer1.DataBind();
            //    reportMaster();
            //    this.CrystalReportViewer1.Dispose();
            //    this.CrystalReportViewer1 = null;
            //    rd.Dispose();
            //    rd.Close();
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}

            //catch (Exception ex)
            //{
            //    this.CrystalReportViewer1.Dispose();
            //    this.CrystalReportViewer1 = null;
            //    rd.Dispose();
            //    rd.Close();
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}
        }

        public void GetStaffCashBonus(ReportDTO obj)
        {

            try
            {
                ReportDTO objReportDTO = obj;
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
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
                objReportDTO.Year = txtYear.Text;
                objReportDTO.payment_mode = 3;

                //start: new code
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaff.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetStaffEidBonus(objReportDTO));


                //old code fron cash sheet
                //if (strBranchOfficeId == "110")
                //{
                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffBP.rpt"));
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.GetEidBonusStaff(objReportDTO));
                //}
                //else
                //{
                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaff.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.FirstBonusSheetStaff(objReportDTO));
                //}

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

            //try
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

            //    if (ddlUnitId.SelectedValue.ToString() != " ")
            //    {
            //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            //    }
            //    else
            //    {
            //        objReportDTO.UnitId = "";
            //    }
            //    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
            //    objReportDTO.EmployeeId = txtEmpId.Text;
            //    objReportDTO.CardNo = txtEmpCardNo.Text;

            //    objReportDTO.Year = txtSalaryYear.Text;
            //    objReportDTO.Month = txtsalaryMonth.Text;

            //    objReportDTO.HeadOfficeId = strHeadOfficeId;
            //    objReportDTO.BranchOfficeId = strBranchOfficeId;
            //    objReportDTO.UpdateBy = strEmployeeId;

            //    if (strBranchOfficeId == "110")
            //    {
            //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaffBP.rpt"));
            //        rd.Load(strPath);
            //        //rd.SetDataSource(objReportBLL.SalarySheetStaff(objReportDTO));
            //        rd.SetDataSource(objReportBLL.GetStaffSalarySheetAsCash(objReportDTO));
            //    }
            //    else
            //    {
            //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaff.rpt"));
            //        rd.Load(strPath);
            //        rd.SetDataSource(objReportBLL.GetStaffSalarySheet(objReportDTO));
            //    }
            //    rd.SetDatabaseLogon("erp", "erp");
            //    CrystalReportViewer1.ReportSource = rd;
            //    CrystalReportViewer1.DataBind();
            //    reportMaster();
            //    this.CrystalReportViewer1.Dispose();
            //    this.CrystalReportViewer1 = null;
            //    rd.Dispose();
            //    rd.Close();
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}

            //catch (Exception ex)
            //{
            //    this.CrystalReportViewer1.Dispose();
            //    this.CrystalReportViewer1 = null;
            //    rd.Dispose();
            //    rd.Close();
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}
        }


        protected void btnCashSheet_Click(object sender, EventArgs e)
        {
            try
            {

                //New
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
                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }

                ReportDTO objReportDTO = new ReportDTO();
                objReportDTO.accountYn = "N";
                GetStaffCashBonus(objReportDTO);

                //FirstBonusSheetStaff(objReportDTO);
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

        protected void btnBkashSheet_Click(object sender, EventArgs e)
        {
            try
            {

                //New
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
                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }

                ReportDTO objReportDTO = new ReportDTO();
                objReportDTO.accountYn = "N";

                GetStaffBkashBonus(objReportDTO);

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

        public void GetEidBonusStaff(ReportDTO obj)
        {

            try
            {
                ReportDTO objReportDTO = obj;
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                //objReportDTO.accountYn = "N";
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
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
                objReportDTO.Year = txtYear.Text;
                objReportDTO.PaymentMode = "1";

                if (strBranchOfficeId == "110")
                {
                    //string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffBP.rpt"));
                    //this.Context.Session["strReportPath"] = strPath;
                    //rd.Load(strPath);
                    //rd.SetDataSource(objReportBLL.bonusSheetStaff(objReportDTO));

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffBP.rpt"));
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetEidBonusStaff(objReportDTO));

                }
                else
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.FirstBonusSheetStaff(objReportDTO));
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

            //try
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

            //    if (ddlUnitId.SelectedValue.ToString() != " ")
            //    {
            //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            //    }
            //    else
            //    {
            //        objReportDTO.UnitId = "";
            //    }
            //    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
            //    objReportDTO.EmployeeId = txtEmpId.Text;
            //    objReportDTO.CardNo = txtEmpCardNo.Text;

            //    objReportDTO.Year = txtSalaryYear.Text;
            //    objReportDTO.Month = txtsalaryMonth.Text;

            //    objReportDTO.HeadOfficeId = strHeadOfficeId;
            //    objReportDTO.BranchOfficeId = strBranchOfficeId;
            //    objReportDTO.UpdateBy = strEmployeeId;

            //    if (strBranchOfficeId == "110")
            //    {
            //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaffBP.rpt"));
            //        rd.Load(strPath);
            //        //rd.SetDataSource(objReportBLL.SalarySheetStaff(objReportDTO));
            //        rd.SetDataSource(objReportBLL.GetStaffSalarySheetAsCash(objReportDTO));
            //    }
            //    else
            //    {
            //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaff.rpt"));
            //        rd.Load(strPath);
            //        rd.SetDataSource(objReportBLL.GetStaffSalarySheet(objReportDTO));
            //    }
            //    rd.SetDatabaseLogon("erp", "erp");
            //    CrystalReportViewer1.ReportSource = rd;
            //    CrystalReportViewer1.DataBind();
            //    reportMaster();
            //    this.CrystalReportViewer1.Dispose();
            //    this.CrystalReportViewer1 = null;
            //    rd.Dispose();
            //    rd.Close();
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}

            //catch (Exception ex)
            //{
            //    this.CrystalReportViewer1.Dispose();
            //    this.CrystalReportViewer1 = null;
            //    rd.Dispose();
            //    rd.Close();
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}
        }

        protected void BtnBkashWalletSheetStaff_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }

                GetBonusSheetStaffAsBKashWallet();

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
        public void GetBonusSheetStaffAsBKashWallet()
        {


            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                if (ddlUnitGroupId.SelectedValue.ToString() != "")
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
                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";
                }
                objReportDTO.Year = txtYear.Text;
                objReportDTO.EmployeeTypeId = "1";
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetBkashWallet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetBonusSheetStaffWorkerAsBKashWallet(objReportDTO));

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

        protected void btnEidBonusStaffBkashReq_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                else if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }

                else
                {
                    EidBonusStaffBkashReq();
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
        public void EidBonusStaffBkashReq()
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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
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
                objReportDTO.EmployeeTypeId = "1";

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptEidBonusBKashReqPart.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEidBonusBKashReq(objReportDTO));


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

        protected void btnEidBonusStaffReq_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                else if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }

                else
                {
                    EidBonusStaffCashReq();
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

        //misc
        public void GetEidBonusStaffMiscReq()
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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
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
                objReportDTO.EmployeeTypeId = "1";

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptEidBonusStaffCashReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEidBonusStaffMiscReq(objReportDTO));


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

        public void EidBonusStaffCashReq()
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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
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
                objReportDTO.EmployeeTypeId = "1";

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptEidBonusStaffCashReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEidBonusStaffCashReq(objReportDTO));


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

        protected void btnBkashSheetPart_Click(object sender, EventArgs e)
        {
            try
            {

                //New
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
                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                if (ddlPhaseId.Text == "")
                {
                    string strMsg = "Please Select Phase";
                    MessageBox(strMsg);
                    ddlPhaseId.Focus();
                    return;
                }

                ReportDTO objReportDTO = new ReportDTO();
                objReportDTO.accountYn = "N";

                GetStaffBkashBonusPart(objReportDTO);

                //GetEidBonusStaff(objReportDTO);

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
        public void GetStaffBkashBonusPart(ReportDTO obj)
        {

            try
            {
                ReportDTO objReportDTO = obj;
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
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
                objReportDTO.Year = txtYear.Text;
                objReportDTO.payment_mode = 2;
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                //start: new code
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffBkashPart.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetStaffEidBonusPart(objReportDTO));


                //old code fron cash sheet
                //if (strBranchOfficeId == "110")
                //{
                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffBP.rpt"));
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.GetEidBonusStaff(objReportDTO));
                //}
                //else
                //{
                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaff.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.FirstBonusSheetStaff(objReportDTO));
                //}

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

            //try
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

            //    if (ddlUnitId.SelectedValue.ToString() != " ")
            //    {
            //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            //    }
            //    else
            //    {
            //        objReportDTO.UnitId = "";
            //    }
            //    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
            //    objReportDTO.EmployeeId = txtEmpId.Text;
            //    objReportDTO.CardNo = txtEmpCardNo.Text;

            //    objReportDTO.Year = txtSalaryYear.Text;
            //    objReportDTO.Month = txtsalaryMonth.Text;

            //    objReportDTO.HeadOfficeId = strHeadOfficeId;
            //    objReportDTO.BranchOfficeId = strBranchOfficeId;
            //    objReportDTO.UpdateBy = strEmployeeId;

            //    if (strBranchOfficeId == "110")
            //    {
            //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaffBP.rpt"));
            //        rd.Load(strPath);
            //        //rd.SetDataSource(objReportBLL.SalarySheetStaff(objReportDTO));
            //        rd.SetDataSource(objReportBLL.GetStaffSalarySheetAsCash(objReportDTO));
            //    }
            //    else
            //    {
            //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaff.rpt"));
            //        rd.Load(strPath);
            //        rd.SetDataSource(objReportBLL.GetStaffSalarySheet(objReportDTO));
            //    }
            //    rd.SetDatabaseLogon("erp", "erp");
            //    CrystalReportViewer1.ReportSource = rd;
            //    CrystalReportViewer1.DataBind();
            //    reportMaster();
            //    this.CrystalReportViewer1.Dispose();
            //    this.CrystalReportViewer1 = null;
            //    rd.Dispose();
            //    rd.Close();
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}

            //catch (Exception ex)
            //{
            //    this.CrystalReportViewer1.Dispose();
            //    this.CrystalReportViewer1 = null;
            //    rd.Dispose();
            //    rd.Close();
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}
        }

        protected void btnCashSheetPart_Click(object sender, EventArgs e)
        {
            try
            {

                //New
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
                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                if (ddlPhaseId.Text == "")
                {
                    string strMsg = "Please Select Phase";
                    MessageBox(strMsg);
                    ddlPhaseId.Focus();
                    return;
                }
                ReportDTO objReportDTO = new ReportDTO();
                objReportDTO.accountYn = "N";
                GetStaffCashBonusPart(objReportDTO);

                //FirstBonusSheetStaff(objReportDTO);
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
        public void GetStaffCashBonusPart(ReportDTO obj)
        {

            try
            {
                ReportDTO objReportDTO = obj;
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
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
                objReportDTO.Year = txtYear.Text;
                objReportDTO.payment_mode = 3;
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                //start: new code
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffPart.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetStaffEidBonusPart(objReportDTO));


                //old code fron cash sheet
                //if (strBranchOfficeId == "110")
                //{
                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffBP.rpt"));
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.GetEidBonusStaff(objReportDTO));
                //}
                //else
                //{
                //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaff.rpt"));
                //    this.Context.Session["strReportPath"] = strPath;
                //    rd.Load(strPath);
                //    rd.SetDataSource(objReportBLL.FirstBonusSheetStaff(objReportDTO));
                //}

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

        protected void btnEidBonusStaffBkashReqPartt_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                else if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                if (ddlPhaseId.Text == "")
                {

                    string strMsg = "Please Select Phase";
                    MessageBox(strMsg);
                    ddlPhaseId.Focus();
                    return;
                }
                else
                {
                    EidBonusStaffBkashReqPart();
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
        public void EidBonusStaffBkashReqPart()
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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
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
                objReportDTO.EmployeeTypeId = "1";
                if (ddlPhaseId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptEidBonusBKashReqPart.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.EidBonusWorkerBkashReqPart(objReportDTO));


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

        protected void btnEidBonusCashReqStaffPart_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                else if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                if (ddlPhaseId.Text == "")
                {

                    string strMsg = "Please Select Phase!";
                    MessageBox(strMsg);
                    ddlPhaseId.Focus();
                    return;
                }

                else
                {
                    EidBonusStaffCashReqPart();
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
        public void EidBonusStaffCashReqPart()
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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
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
                objReportDTO.EmployeeTypeId = "1";
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptEidBonusStaffCashReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEidBonusStaffCashReqPart(objReportDTO));


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

        protected void btnSecondSheetpart_Click(object sender, EventArgs e)
        {
            try
            {

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

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                if (txtYear.Text == "")
                {

                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                if (ddlPhaseId.Text == "")
                {

                    string strMsg = "Please Select Phase";
                    MessageBox(strMsg);
                    ddlPhaseId.Focus();
                    return;
                }
                SecondBonusSheetStaffPart();

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
        public void SecondBonusSheetStaffPart()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                //New
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";
                }
                objReportDTO.Year = txtYear.Text;

                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetStaffMisc.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.SecondBonusSheetStaffPart(objReportDTO));

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

        protected void btnMasterSheet_Click(object sender, EventArgs e)
        {
            try
            {

                //New
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
                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                GetEibBonusMasterSheet();
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
        public void GetEibBonusMasterSheet()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                if (ddlUnitGroupId.SelectedValue.ToString() != "")
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
                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";
                }
                objReportDTO.Year = txtYear.Text;
                objReportDTO.EmployeeTypeId = "1";
                objReportDTO.PaymentMode = "";

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerBkash.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEibBonusMasterSheet(objReportDTO));

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

        protected void btnMiscelennaousReqSummary_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }

                if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                EidBonusStaffMisceSalaryReq();
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
        public void EidBonusStaffMisceSalaryReq()
        {
            try
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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
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

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptEidBonusSecondSheetSummary.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.EidBonusStaffMisceSalaryReq(objReportDTO));

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

        protected void BtnEidBonusMiscReq_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                else if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }

                else
                {
                    GetEidBonusStaffMiscReq();
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
    }
}