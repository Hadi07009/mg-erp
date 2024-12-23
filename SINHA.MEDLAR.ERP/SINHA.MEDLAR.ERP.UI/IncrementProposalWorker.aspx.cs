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
    public partial class IncrementProposalWorker : System.Web.UI.Page
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
                getYearForIncrementProposal();
                btnSearch.Focus();
            }
            if (IsPostBack)
            {

                loadSesscion();
            }


            gvEmployeeList.Columns[5].Visible = false; 
           
        }

        #region "FUNCTION"

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

        public void getYearForIncrementProposal()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            string employeeTypeId = "2";

            objLookUpDTO = objLookUpBLL.GetLastIncrementProposal(employeeTypeId, strHeadOfficeId, strBranchOfficeId);
            //objLookUpDTO = objLookUpBLL.getYearForIncrementProposal(employeeTypeId, strHeadOfficeId, strBranchOfficeId);
                       

            txtIncrementYear.Text = objLookUpDTO.Year;


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

     

        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
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

        public void searchEmployeeRecordforIncrementProposal()
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();

            DataTable dt = new DataTable();



            objTiffinDTO.HeadOfficeId = strHeadOfficeId;
            objTiffinDTO.BranchOfficeId = strBranchOfficeId;
            objTiffinDTO.EmployeeId = txtEmpId.Text;
            objTiffinDTO.CardNo = txtEmpCardNo.Text;



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.SectionId = "";

            }
            
            dt = objTiffinBLL.searchEmployeeRecordforIncrementProposal(objTiffinDTO);
            
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
                //gvEmployeeList.Columns[2].Visible = false;
                lblMsg.Text = strMsg;
            }

        }
        public void searchIncrementProposalEntry()
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();

            DataTable dt = new DataTable();
            
            objTiffinDTO.HeadOfficeId = strHeadOfficeId;
            objTiffinDTO.BranchOfficeId = strBranchOfficeId;
            objTiffinDTO.EmployeeId = txtEmpId.Text;
            objTiffinDTO.CardNo = txtEmpCardNo.Text;
            objTiffinDTO.Year = txtIncrementYear.Text;
        
            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.UnitId = "";
            }
            
            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.SectionId = "";
            }
                        
            dt = objTiffinBLL.searchIncrementProposalEntry(objTiffinDTO);
            
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
        public void searchIncrementProposalEntryAll()
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();

            DataTable dt = new DataTable();



            objTiffinDTO.HeadOfficeId = strHeadOfficeId;
            objTiffinDTO.BranchOfficeId = strBranchOfficeId;
            objTiffinDTO.EmployeeId = txtEmpId.Text;
            objTiffinDTO.CardNo = txtEmpCardNo.Text;
            objTiffinDTO.Year = txtIncrementYear.Text;



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.SectionId = "";

            }





            dt = objTiffinBLL.searchIncrementProposalEntryAll(objTiffinDTO);


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

                SalaryDTO objSalaryDTO = new SalaryDTO();
                objSalaryDTO.EmployeeId = txtEmployeeId.Text;
                objSalaryDTO.Year = txtIncrementYear.Text;
                objSalaryDTO.Month = txtMonth.Text;
                objSalaryDTO.BranchOfficeId = strBranchOfficeId;
                objSalaryDTO.HeadOfficeId = strHeadOfficeId;

                SalaryBLL objSalaryBLL = new SalaryBLL();

                string autoIncrAmount = objSalaryBLL.GetWorkerAutoIncrementAmount(objSalaryDTO);

                decimal incrAmount = 0;
                incrAmount = autoIncrAmount == "" ? 0 : Convert.ToDecimal(autoIncrAmount);
                if (incrAmount > 0)
                    ChkIndividualAutoIncrYn.Checked = true;
                else
                    ChkAllowGeneralIncrement.Checked = false;

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





        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
        public void saveWorkerIncrementProposal()
        {


            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();



            objTiffinDTO.EmployeeId = txtEmployeeId.Text;
            objTiffinDTO.Year = txtIncrementYear.Text;
          
           

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.SectionId = "";

            }


            objTiffinDTO.UpdateBy = strEmployeeId;
            objTiffinDTO.HeadOfficeId = strHeadOfficeId;
            objTiffinDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objTiffinBLL.saveWorkerIncrementProposal(objTiffinDTO);
            lblMsg.Text = strMsg;
            //MessageBox(strMsg);
           

            




        }
        public void processIncrementProposalAll()
        {


            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();




            objTiffinDTO.Year = txtIncrementYear.Text;


            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.SectionId = "";

            }


            objTiffinDTO.UpdateBy = strEmployeeId;
            objTiffinDTO.HeadOfficeId = strHeadOfficeId;
            objTiffinDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objTiffinBLL.processIncrementProposalAll(objTiffinDTO);
            //lblMsg.Text = strMsg;
            //MessageBox(strMsg);







        }
        public void processIncrementProposal()
        {


            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();


            //Asad
            if (ChkAllowGeneralIncrement.Checked)
                objTiffinDTO.AllowGeneralIncrement = "Y";
            else
                objTiffinDTO.AllowGeneralIncrement = "N";

            objTiffinDTO.Year = txtIncrementYear.Text;
            objTiffinDTO.Month = txtMonth.Text;

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.UnitId = "";
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.SectionId = "";
            }

            if (ddlUnitGroupId.SelectedValue.ToString() != "")
            {
                objTiffinDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.UnitGroupId = "";
            }

            objTiffinDTO.UpdateBy = strEmployeeId;
            objTiffinDTO.HeadOfficeId = strHeadOfficeId;
            objTiffinDTO.BranchOfficeId = strBranchOfficeId;
            string strMsg = objTiffinBLL.processIncrementProposal(objTiffinDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }
        public void processIncrementProposalSummery()
        {            
            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();
                      

            objTiffinDTO.Year = txtIncrementYear.Text;

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.UnitId = "";
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.SectionId = "";
            }

            objTiffinDTO.UpdateBy = strEmployeeId;
            objTiffinDTO.HeadOfficeId = strHeadOfficeId;
            objTiffinDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objTiffinBLL.processIncrementProposalSummery(objTiffinDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }


        public void processIncrementProposalSummeryLOne()
        {
            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();


            objTiffinDTO.Year = txtIncrementYear.Text;

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.UnitId = "";
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.SectionId = "";
            }

            objTiffinDTO.UpdateBy = strEmployeeId;
            objTiffinDTO.HeadOfficeId = strHeadOfficeId;
            objTiffinDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objTiffinBLL.processIncrementProposalSummeryLOne(objTiffinDTO);
            lblMsg.Text = strMsg;
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
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "increment_proposal_sheet_worker");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }




        }
        
        public void addWorkerIncrementProposal()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "";

            //Asad
            if (ChkAllowGeneralIncrement.Checked)
                objSalaryDTO.AllowGeneralIncrement = "Y";
            else
                objSalaryDTO.AllowGeneralIncrement = "N";

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
            
            objSalaryDTO.Year = txtIncrementYear.Text;
            objSalaryDTO.Month = txtMonth.Text;

            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            strMsg = objSalaryBLL.addWorkerIncrementProposal(objSalaryDTO);
            MessageBox(strMsg);
        }

        public void addWorkerIncrementProposalLessOne()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "";

            //Asad
            if (ChkAllowGeneralIncrement.Checked)
                objSalaryDTO.AllowGeneralIncrement = "Y";
            else
                objSalaryDTO.AllowGeneralIncrement = "N";

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

            objSalaryDTO.Year = txtIncrementYear.Text;
            objSalaryDTO.Month = txtMonth.Text;

            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            strMsg = objSalaryBLL.addWorkerIncrementProposalLessOne(objSalaryDTO);
            MessageBox(strMsg);
        }

        //new for individual auto incr
        public string ApplyIndividualWorkerAutoIncr()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            int recordCounter = 0;
            //int successCounter = 0;
            string strMsg = "";

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {
                        recordCounter = recordCounter + 1;

                        TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");

                        objSalaryDTO.EmployeeId = txtEmployeeId.Text;

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

                        objSalaryDTO.Year = txtIncrementYear.Text;
                        objSalaryDTO.Month = txtMonth.Text;

                        if (ChkIndividualAutoIncrYn.Checked)
                            objSalaryDTO.IndividualAutoIncrYn = "Y";
                        else
                            objSalaryDTO.IndividualAutoIncrYn = "N";

                        objSalaryDTO.UpdateBy = strEmployeeId;
                        objSalaryDTO.HeadOfficeId = strHeadOfficeId;
                        objSalaryDTO.BranchOfficeId = strBranchOfficeId;
                        strMsg = objSalaryBLL.ApplyIndividualWorkerAutoIncr(objSalaryDTO);
                        
                    }
                }
            }
            return strMsg;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {


            if (gvEmployeeList.Rows.Count == 0)
            {
                string strMsg = "Please click searh Button!!!";
                MessageBox(strMsg);
                clearMessage();
                btnSearch.Focus();

                return;
            }
            else
            {


                addWorkerIncrementProposal();


            }
        }



        //public void searchWorkerIncProposalEntry()
        //{
        //    SalaryDTO objSalaryDTO = new SalaryDTO();
        //    SalaryBLL objSalaryBLL = new SalaryBLL();


        //    string strUnitId = "";
        //    string strSectionId = "";

        //    if (ddlUnitId.SelectedValue.ToString() != " ")
        //    {
        //        strUnitId = ddlUnitId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        strUnitId = "";

        //    }


        //    if (ddlSectionId.SelectedValue.ToString() != " ")
        //    {
        //        strSectionId = ddlSectionId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        strSectionId = "";

        //    }





        //    objSalaryDTO = objSalaryBLL.searchWorkerIncProposalEntry(txtEmployeeId.Text, txtIncrementYear.Text, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);







        //}

        public void incrementSheetAboveOneYearAll()
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

                objReportDTO.Year = txtIncrementYear.Text;

                objReportDTO.EmployeeTypeId = "2";
                objReportDTO.PreIncrementYear = objReportBLL.GetPreIncrementYear(objReportDTO);

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerAboveOneYearAll.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);

                rd.SetDataSource(objReportBLL.incrementProposalWorkerAboveOneYearAll(objReportDTO));

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
        public void incrementSheetAboveOneYear()
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

                objReportDTO.Year = txtIncrementYear.Text;

                //string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerAboveOneYear.rpt"));
                //this.Context.Session["strReportPath"] = strPath;
                //rd.Load(strPath);
                string strPath;
                if (strBranchOfficeId == "110")
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerAboveOneYearForBP.rpt"));
                }
                else
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerAboveOneYear.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);


                rd.SetDataSource(objReportBLL.incrementProposalWorkerAboveOneYear(objReportDTO));

              


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
        public void incGradeAdjustmentSheetAboveOneYear()
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


                objReportDTO.Year = txtIncrementYear.Text;





                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncGradeAdjustmentWorkerAboveOneYear.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);


                rd.SetDataSource(objReportBLL.incGradeAdjustmentSheetAboveOneYear(objReportDTO));




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
        public void incrementSheetBellowOneYear()
        {

            try
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


                objReportDTO.Year = txtIncrementYear.Text;





                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerBellowOneYear.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.incrementProposalWorkerBellowOneYear(objReportDTO));


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
      
        public void incrementProposalSheetWorkerSummery()
        {

            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                processIncrementProposalSummery();

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


                objReportDTO.Year = txtIncrementYear.Text;





                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerSummery.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.incrementProposalSheetWorkerSummery(objReportDTO));


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
        public void GetIncrementProposalWorkerByUnitGroup()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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
                                
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.Year = txtIncrementYear.Text;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                string strPath;

                //XXXXXXXXXX:21.12.2021
                //if (strBranchOfficeId=="110")
                //{
                //strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerAboveOneYearForBP.rpt"));
                //}
                //else
                //strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerAboveOneYear.rpt"));

                //YYYYYYYYYY:21.12.2021
                strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerAboveOneYear.rpt"));
                
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);


                rd.SetDataSource(objReportBLL.GetIncrementProposalWorkerByUnitGroup(objReportDTO));

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

        public void GetIncrementProposalWorkerLessOne()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.Year = txtIncrementYear.Text;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                string strPath;

                //XXXXXXXXXX:21.12.2021
                //if (strBranchOfficeId=="110")
                //{
                //strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerAboveOneYearForBP.rpt"));
                //}
                //else
                //strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerAboveOneYear.rpt"));

                //YYYYYYYYYY:21.12.2021
                strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerLessOneYear.rpt"));

                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);


                rd.SetDataSource(objReportBLL.GetIncrementProposalWorkerLessOne(objReportDTO));

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

        

        public void incrementProposalSheetWorkerSummeryEng()
        {
            try
            {                
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                
                processIncrementProposalSummery();

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

                objReportDTO.Year = txtIncrementYear.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerSummeryEnglish.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.incrementProposalSheetWorkerSummeryEng(objReportDTO));

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

        public void incrementProposalSheetWorkerSEngLOne()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                processIncrementProposalSummeryLOne();      //here

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

                objReportDTO.Year = txtIncrementYear.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerSummeryEnglishLOne.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.incrementProposalSheetWorkerSELOne(objReportDTO));

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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                    searchEmployeeRecordforIncrementProposal();
                    clearYellowTextBox();
                  
                    gvEmployeeList.SelectedIndex = 0;
                    goToNextRecord();
                    searchIncrementProposalEntry();
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


            //searchWorkerIncProposalEntry();

            



        }
        protected void gvEmployeeList_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }

        protected void gvEmployeeList_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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

        }
        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }
        
        #endregion

        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            decimal IncrementAmount = 0;

            int strRowId = GridView1.SelectedRow.RowIndex + 1;

            string strSLNo = GridView1.SelectedRow.Cells[1].Text;
            string strCardNo = GridView1.SelectedRow.Cells[2].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[3].Text;
            string strDesignation = GridView1.SelectedRow.Cells[4].Text;

            string Incr5Percent = GridView1.SelectedRow.Cells[9].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[10].Text; //Index changed from 8 to 9
            

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            IncrementAmount = Incr5Percent == "" ? 0 : Convert.ToDecimal(Incr5Percent);
            if (IncrementAmount > 0)
                ChkIndividualAutoIncrYn.Checked = true;
            else
                ChkIndividualAutoIncrYn.Checked = false;
        }

        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
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
                    //searchWorkerIncProposalEntry();
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
                    //searchWorkerIncProposalEntry();
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
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    clearMessage();
                    btnSearch.Focus();

                    return;
                }
                else if (txtEmployeeId.Text == string.Empty)
                {
                    string strMsg = "Please click in the Gridview!!!";
                    MessageBox(strMsg);
                    clearMessage();
                    return;

                }



              


                else
                {
                    saveWorkerIncrementProposal();
                    goToNextRecord();
                    searchIncrementProposalEntry();
                    //searchWorkerIncProposalEntry();

                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }





        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchIncrementProposalEntry();
        }

        protected void btnSheetAboveOneYear_Click(object sender, EventArgs e)
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
                    //NEW
                    GetIncrementProposalWorkerByUnitGroup();
                    //OLD
                    //incrementSheetAboveOneYear();
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

                    GetIncrementProposalWorkerByUnitGroup();
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

        protected void btnSheetBellowOneYear_Click(object sender, EventArgs e)
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

                    incrementSheetBellowOneYear();

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

        protected void btnSummerySheet_Click(object sender, EventArgs e)
        {
            incrementProposalSheetWorkerSummery();
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                    addWorkerIncrementProposal();
                    //Commented on 19.12.2021
                    //processIncrementProposal();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : "+ex.Message);
            }
        }

        //new
        protected void BtnSaveAutoIncr_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = ApplyIndividualWorkerAutoIncr();
                searchIncrementProposalEntry();
                MessageBox(msg);
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnSummerySheetEnglish_Click(object sender, EventArgs e)
        {
            incrementProposalSheetWorkerSummeryEng();
        }

        protected void btnSheetAboveOneYearAll_Click(object sender, EventArgs e)
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
                    incrementSheetAboveOneYearAll();
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

        protected void btnGradeAdjustmentAboveOneYear_Click(object sender, EventArgs e)
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


                    incGradeAdjustmentSheetAboveOneYear();

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

        protected void btnSummerySheetEnglishByUnitGroup_Click(object sender, EventArgs e)
        {

            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.Year = txtIncrementYear.Text;
                objReportDTO.Month = txtMonth.Text;
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWorkerIncrementProposalSheetByUnitGroup.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetWorkerIncrementProposalSheetByUnitGroup(objReportDTO));
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

        protected void BtnProposalReqSummary_Click(object sender, EventArgs e)
        {
            IncrementProposalReqSummary();
        }
        public void IncrementProposalReqSummary()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                ProcessIncrementProposalReqSummary();

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
                objReportDTO.Year = txtIncrementYear.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptIncrementProposalReqSummary.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.IncrementProposalReqSummary(objReportDTO));
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

        public void IncrementProposalReqSLessOne()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                ProcessIncrementProposalReqSLOne();   //here

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
                objReportDTO.Year = txtIncrementYear.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptIncrementProposalReqSummaryLOne.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.IncrementProposalReqSLessOne(objReportDTO));
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

        public void ProcessIncrementProposalReqSummary()
        {


            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();




            objTiffinDTO.Year = txtIncrementYear.Text;


            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.SectionId = "";

            }

            if (ddlUnitGroupId.SelectedValue.ToString() != "")
            {
                objTiffinDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.UnitGroupId = "";
            }
            objTiffinDTO.UpdateBy = strEmployeeId;
            objTiffinDTO.HeadOfficeId = strHeadOfficeId;
            objTiffinDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objTiffinBLL.ProcessIncrementProposalReqSummary(objTiffinDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }

        public void ProcessIncrementProposalReqSLOne()
        {


            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();




            objTiffinDTO.Year = txtIncrementYear.Text;


            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.SectionId = "";

            }

            if (ddlUnitGroupId.SelectedValue.ToString() != "")
            {
                objTiffinDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.UnitGroupId = "";
            }
            objTiffinDTO.UpdateBy = strEmployeeId;
            objTiffinDTO.HeadOfficeId = strHeadOfficeId;
            objTiffinDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objTiffinBLL.ProcessIncrementProposalReqSLOne(objTiffinDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }


        protected void btnAboveOneYearExcelSheet_Click(object sender, EventArgs e)
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
                    GetIncrementProposalWorkerByUnitGroup();
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

                    GetIncrementProposalWorkerForExcelView();
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
        public void GetIncrementProposalWorkerForExcelView()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                chkExcel.Checked = true;

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

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.Year = txtIncrementYear.Text;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                string strPath;

                strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementProposalWorkerAboveOneYearForExcel.rpt"));

                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);


                rd.SetDataSource(objReportBLL.GetIncrementProposalWorkerByUnitGroup(objReportDTO));

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

        protected void btnProcessLessOne_Click(object sender, EventArgs e)
        {
            try
            {
                addWorkerIncrementProposalLessOne();
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnSheetLessOne_Click(object sender, EventArgs e)
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
                    //NEW
                    GetIncrementProposalWorkerLessOne();
                    //OLD
                    //incrementSheetAboveOneYear();
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

                    GetIncrementProposalWorkerLessOne();
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

        protected void btnRSummaryLessOne_Click(object sender, EventArgs e)
        {
            IncrementProposalReqSLessOne();
        }

        protected void btnSummaryEngLOne_Click(object sender, EventArgs e)
        {
            incrementProposalSheetWorkerSEngLOne();
        }
    }
}