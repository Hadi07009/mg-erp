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
    public partial class IncrementLetter : System.Web.UI.Page
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

                getYearForIncrementProposal();
                getSectionId();
                getLetterTypeId();
                clearMsg();
                getOfficeName();
                getApprovedId();
                btnSearch.Focus();


            }
            if (IsPostBack)
            {

                loadSesscion();

            }

        }

        #region "Function"

        public void getApprovedId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlApprovedById.DataSource = objLookUpBLL.getApprovedId();

            ddlApprovedById.DataTextField = "EMPLOYEE_NAME";
            ddlApprovedById.DataValueField = "EMPLOYEE_ID";

            ddlApprovedById.DataBind();
            if (ddlApprovedById.Items.Count > 0)
            {

                ddlApprovedById.SelectedIndex = 0;
            }

        }
    
        public void getYearForIncrementProposal()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getYearForIncrementYear(strHeadOfficeId, strBranchOfficeId);

            txtYear.Text = objLookUpDTO.Year;



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

        public void getLetterTypeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlLetterTypeId.DataSource = objLookUpBLL.getLetterTypeId(strHeadOfficeId, strBranchOfficeId);

            ddlLetterTypeId.DataTextField = "LETTER_TYPE_NAME";
            ddlLetterTypeId.DataValueField = "LETTER_TYPE_ID";

            ddlLetterTypeId.DataBind();
            if (ddlLetterTypeId.Items.Count > 0)
            {

                ddlLetterTypeId.SelectedIndex = 0;
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

        public void searchIncEmployeeList()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.Year = txtYear.Text;
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





            dt = objEmployeeBLL.searchIncEmployeeList(objEmployeeDTO);


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

        public void saveIncrementLetter()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            //int counter = 0;
            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {
            //        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
            //        if (chkEmployee.Checked)
            //        {
            //            counter = counter + 1;
            //        }
            //    }
            //}

            //if(counter == 0)
            //{
            //    MessageBox("Please select at least one record,");
            //    return;
            //}
            
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

                        if (ddlApprovedById.SelectedValue.ToString() != " ")
                        {
                            objEmployeeDTO.ApprovedBY = ddlApprovedById.SelectedValue.ToString();
                        }
                        else
                        {
                            objEmployeeDTO.ApprovedBY = "";

                        }


                        objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                        objEmployeeDTO.Year = txtYear.Text;


                        objEmployeeDTO.UpdateBy = strEmployeeId;
                        objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                        objEmployeeDTO.BranchOfficeId = strBranchOfficeId;


                        string strMsg = objEmployeeBLL.saveIncrementLetter(objEmployeeDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;
                    }
                }
            }
        }
        public void deleteIncrementLetter()
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
            
            objEmployeeDTO.Year = txtYear.Text;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            
            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            
            string strMsg = objEmployeeBLL.deleteIncrementLetter(objEmployeeDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;
            
        }

        public void GetAppraisalLetter()
        {
            try
            {
                string strPath = "";
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;
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

                //New: 10.04.2022
                strPath = Path.Combine(Server.MapPath("~/Reports/RptAppraisalLetter.rpt"));
                //strPath = Path.Combine(Server.MapPath("~/Reports/rptLetterOfIncrement.rpt"));
                

                //Old: 10.04.2022
                //if (ddlLetterTypeId.SelectedValue == "1")
                //{
                //    strPath = Path.Combine(Server.MapPath("~/Reports/rptLetterOfIncrementBangla.rpt"));
                //}
                //else
                //{
                //    strPath = Path.Combine(Server.MapPath("~/Reports/rptLetterOfIncrement.rpt"));
                //}

                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);

                //New: 10.04.2022
                rd.SetDataSource(objReportBLL.GetAppraisalLetter(objReportDTO));
                

                //old: 10.04.2022
                //if (ddlLetterTypeId.SelectedValue == "1")
                //{
                //    rd.SetDataSource(objReportBLL.IncrementLetterSheetBangla(objReportDTO));
                //}
                //else
                //{
                //    rd.SetDataSource(objReportBLL.IncrementLetterSheet(objReportDTO));
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


        public void IncrementLetterSheet()
        {
            try
            {
                string strPath = "";
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;
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


                if (ddlLetterTypeId.SelectedValue == "1")
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptLetterOfIncrementBangla.rpt"));
                }
                else
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptLetterOfIncrement.rpt"));
                }
                                
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);

                if (ddlLetterTypeId.SelectedValue == "1")
                {
                    rd.SetDataSource(objReportBLL.IncrementLetterSheetBangla(objReportDTO));
                }
                else
                {
                    rd.SetDataSource(objReportBLL.IncrementLetterSheet(objReportDTO));
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
        public void ConfirmLetterSheet()
        {

            try
            {

                string strPath = "";
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;
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


                if (ddlLetterTypeId.SelectedValue == "1")
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptLetterOfConfirmationBangla.rpt"));
                }
                else
                {


                    strPath = Path.Combine(Server.MapPath("~/Reports/rptLetterOfConfirmation.rpt"));

                }

                //if ((strHeadOfficeId == "331" && strBranchOfficeId == "104") )
                //{
                //    strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeIdCardHO.rpt"));

                //}
                //else if (strHeadOfficeId == "441")
                //{
                //    strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeIdCardPower.rpt"));

                //}
                //else
                //{
                //     strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeIdCard.rpt"));
                //}

                if (ddlLetterTypeId.SelectedValue == "1")
                {
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    //rd.SetDataSource(objReportBLL.ConfirmLetterSheet(objReportDTO));
                    rd.SetDataSource(objReportBLL.ConfirmLetterSheetBangla(objReportDTO));

                }
                else
                {

                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.ConfirmLetterSheet(objReportDTO));
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
        public void PromotionLetterSheet()
        {

            try
            {

                string strPath = "";
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;
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


                if (ddlLetterTypeId.SelectedValue == "1")
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptLetterOfPromotionBangla.rpt"));
                }
                else
                {


                    strPath = Path.Combine(Server.MapPath("~/Reports/rptLetterOfPromotion.rpt"));

                }

                //if ((strHeadOfficeId == "331" && strBranchOfficeId == "104") )
                //{
                //    strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeIdCardHO.rpt"));

                //}
                //else if (strHeadOfficeId == "441")
                //{
                //    strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeIdCardPower.rpt"));

                //}
                //else
                //{
                //     strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeIdCard.rpt"));
                //}
                if (ddlLetterTypeId.SelectedValue == "1")
                {


                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.PromotionLetterSheetBangla(objReportDTO));

                }

                else
                {
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.PromotionLetterSheet(objReportDTO));


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
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {


                searchIncEmployeeList();



            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
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
                rd.ExportToHttpResponse
                (CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet_worker");
                Response.End();
                CrystalReportViewer1.RefreshReport();
            }
            if (chkWord.Checked == true)
            {
                rd.ExportToHttpResponse
                (CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "increment_letter");
                Response.End();
                CrystalReportViewer1.RefreshReport();
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

        protected void chkWord_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWord.Checked == true)
            {
                chkWord.AutoPostBack = true;
                chkPDF.Checked = false;
                chkExcel.Checked = false;
            }

        }



        #region "Grid View Functionality2"
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

            //    searchMiscEntryWorker();

            //    txtWorkingDay.Focus();
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

        protected void btnIncrementLetter_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlLetterTypeId.Text == " ")
                {

                    string strMsg = "Please Select Letter Type!!!";
                    MessageBox(strMsg);
                    ddlLetterTypeId.Focus();
                    return;
                }

                else if (ddlApprovedById.Text == " ")
                {

                    string strMsg = "Please Select Approved Employee Name!!!";
                    MessageBox(strMsg);
                    ddlApprovedById.Focus();
                    return;
                }
                else
                {


                    deleteIncrementLetter();
                    saveIncrementLetter();
                    IncrementLetterSheet();

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

        protected void btnPromotionLetter_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlLetterTypeId.Text == " ")
                {

                    string strMsg = "Please Select Letter Type!!!";
                    MessageBox(strMsg);
                    ddlLetterTypeId.Focus();
                    return;
                }

                else if (ddlApprovedById.Text == " ")
                {

                    string strMsg = "Please Select Approved Employee Name!!!";
                    MessageBox(strMsg);
                    ddlApprovedById.Focus();
                    return;
                }
                else
                {


                    deleteIncrementLetter();
                    saveIncrementLetter();
                    PromotionLetterSheet();

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

        protected void btnConfirmationLetter_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlLetterTypeId.Text == " ")
                {

                    string strMsg = "Please Select Letter Type!!!";
                    MessageBox(strMsg);
                    ddlLetterTypeId.Focus();
                    return;
                }

                else if (ddlApprovedById.Text == " ")
                {

                    string strMsg = "Please Select Approved Employee Name!!!";
                    MessageBox(strMsg);
                    ddlApprovedById.Focus();
                    return;
                }
                else
                {


                    deleteIncrementLetter();
                    saveIncrementLetter();
                    ConfirmLetterSheet();

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

        protected void btnAppraisalLetter_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ddlLetterTypeId.Text == " ")
                //{
                //    string strMsg = "Please Select Letter Type!!!";
                //    MessageBox(strMsg);
                //    ddlLetterTypeId.Focus();
                //    return;
                //}
                //else 

                if (ddlApprovedById.Text == " ")
                {
                    string strMsg = "Please Select Approved Employee Name!!!";
                    MessageBox(strMsg);
                    ddlApprovedById.Focus();
                    return;
                }

                int counter = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                        if (chkEmployee.Checked)
                        {
                            counter = counter + 1;
                        }
                    }
                }

                if (counter == 0)
                {
                    MessageBox("Please select at least one record,");
                    return;
                }


                deleteIncrementLetter();
                saveIncrementLetter();
                GetAppraisalLetter();
               
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