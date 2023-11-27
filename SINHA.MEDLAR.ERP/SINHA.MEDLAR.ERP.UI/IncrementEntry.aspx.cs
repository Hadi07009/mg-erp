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

using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class IncrementEntry : System.Web.UI.Page
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
                loadSesscion();
                getOfficeName();
                getUnitId();
                getSectionId();
                getSupervisorId();
                //getIncrementProcessTypeId();
                clearMsg();
              
                getYearForIncrementProposal();
                lblMsg.Text = string.Empty;
                btnSearch.Focus();
            }
            if (IsPostBack)
            {

                loadSesscion();
            }

            gvIncrementList.Columns[7].Visible = false; 


        }

        #region "FUNCTION"


        public void getYearForIncrementProposal()
        {
            //new: added on 14.02.2022
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            objLookUpDTO = objLookUpBLL.getYearForIncrementProposal(strHeadOfficeId, strBranchOfficeId);
            txtYear.Text = objLookUpDTO.Year;
            
            //old: commented on 14.02.2022
            //LookUpDTO objLookUpDTO = new LookUpDTO();
            //LookUpBLL objLookUpBLL = new LookUpBLL();
            //objLookUpDTO = objLookUpBLL.getYearForIncrementYear(strHeadOfficeId, strBranchOfficeId);
            //txtYear.Text = objLookUpDTO.Year;
        }
        

        public void getIncrementEffectDate()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getIncrementEffectDate(txtYear.Text, strHeadOfficeId, strBranchOfficeId);

            dtpEffectDate.Text = objLookUpDTO.EffectDate;



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

        public void getFirstIndex()
        {
            var rowCount = gvIncrementList.Rows.Count;


            int rowIndex = 1;
            if (gvIncrementList.SelectedIndex == -1)
            {


                rowIndex = 0;
                GridViewRow row = gvIncrementList.Rows[rowIndex];
                //int strRowId = gvIncrementList.SelectedRow.RowIndex;

                


                string strEmployeeName = row.Cells[3].Text;
                string strEmployeeId = row.Cells[1].Text;
                string strDesignation = row.Cells[4].Text;
                string strCardNo = row.Cells[2].Text;
                string strGrossSalary = row.Cells[6].Text;


                txtName.Text = strEmployeeName;
                txtEmployeeId.Text = strEmployeeId;
                txtDesignation.Text = strDesignation;
                txtCardNo.Text = strCardNo;
                txtCurrentSalary.Text = strGrossSalary;
                txtSL.Text = "1";

                rowIndex = 1;
                

            }
           


        }


        public void getMonthYearForSalary()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYear();

            txtYear.Text = objLookUpDTO.Year;
           

        }
        //public void getIncrementProcessTypeId()
        //{

        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlIncrementTypeId.DataSource = objLookUpBLL.getIncrementProcessTypeId();

        //    ddlIncrementTypeId.DataTextField = "INCREMENT_PROCESS_TYPE_NAME";
        //    ddlIncrementTypeId.DataValueField = "INCREMENT_PROCESS_TYPE_ID";

        //    ddlIncrementTypeId.DataBind();
        //    if (ddlIncrementTypeId.Items.Count > 0)
        //    {

        //        ddlIncrementTypeId.SelectedIndex = 0;
        //    }

        //}

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


        public void getSupervisorId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSupervisorId.DataSource = objLookUpBLL.getSupervisorId();

            ddlSupervisorId.DataTextField = "SUPERVISOR_NAME";
            ddlSupervisorId.DataValueField = "SUPERVISOR_ID";

            ddlSupervisorId.DataBind();
            if (ddlSupervisorId.Items.Count > 0)
            {

                ddlSupervisorId.SelectedIndex = 0;
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

        public void processIncrement()
        {

            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objIncrementDTO.SectionId = "";
            }

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {

                objIncrementDTO.UnitId = "";
            }

           
            objIncrementDTO.Year = txtYear.Text;
            
           
            objIncrementDTO.HeadOfficeId = strHeadOfficeId;
            objIncrementDTO.BranchOfficeId = strBranchOfficeId;
            objIncrementDTO.UpdateBy = strEmployeeId;

            string strMsg = objIncrementBLL.processIncrement(objIncrementDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }


        public void processIncrementOption()
        {


            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objIncrementDTO.SectionId = "";
            }

            //if (ddlIncrementTypeId.SelectedValue.ToString() != " ")
            //{

            //    objIncrementDTO.IncrementTypeId = ddlIncrementTypeId.SelectedValue.ToString();
            //}
            //else
            //{

            //    objIncrementDTO.IncrementTypeId = "";
            //}

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objIncrementDTO.UnitId = "";

            }
            objIncrementDTO.Year = txtYear.Text;
        

            objIncrementDTO.HeadOfficeId = strHeadOfficeId;
            objIncrementDTO.BranchOfficeId = strBranchOfficeId;
            objIncrementDTO.UpdateBy = strEmployeeId;

            string strMsg = objIncrementBLL.processIncrementOption(objIncrementDTO);
            MessageBox(strMsg);
            //lblMsg.Text = strMsg;

        }

        public void saveIncrememntAmount(string strId, string strCardno, string strIncrementAmount, string strSectionId, string strUnitId, string strYear)
        {

            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();



            objIncrementDTO.EmployeeId = strId;
            objIncrementDTO.UnitId = strUnitId;
            objIncrementDTO.SectionId = strSectionId;
            objIncrementDTO.Year = strYear;
            objIncrementDTO.IncrementAmount = strIncrementAmount;



            objIncrementDTO.UpdateBy = strEmployeeId;
            objIncrementDTO.HeadOfficeId = strHeadOfficeId;
            objIncrementDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objIncrementBLL.saveIncrememntAmount(objIncrementDTO);
            MessageBox(strMsg);
            gvIncrementList.EditIndex = -1;

        }

        public void saveIncrementHO()
        {

            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();


            objIncrementDTO.EmployeeId = txtEmployeeId.Text;
            objIncrementDTO.CardNo = txtCardNo.Text;
            objIncrementDTO.IncrementAmount = txtIncrementAmount.Text;
            objIncrementDTO.FirstSalary = txtFirstSalary.Text;
            objIncrementDTO.EffectDate = dtpEffectDate.Text;
            objIncrementDTO.GrossSalary = txtGrossSalary.Text;
            

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {

                objIncrementDTO.UnitId = "";
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objIncrementDTO.SectionId = "";
            }
            
            objIncrementDTO.Year = txtYear.Text;
            objIncrementDTO.UpdateBy = strEmployeeId;
            objIncrementDTO.HeadOfficeId = strHeadOfficeId;
            objIncrementDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objIncrementBLL.saveIncrementHO(objIncrementDTO);
            //MessageBox(strMsg);
            
            if (strMsg == "INCREMENT ENTRY HAS BEEN LOCKED!!!")
            {
                lblMsg.Text = strMsg;
                MessageBox(strMsg);
                return;
            }
            if (strMsg == "PLEASE LOCK INCREMENT PROPOSAL!!!")
            {
                lblMsg.Text = strMsg;
                MessageBox(strMsg);
                return;
            }
            else
            {
                lblMsg.Text = strMsg;
                clearTextBox();
                goToNextRecord();
                searchIncrementAmountInfo();
                searchIncrementEntryHO();
            }  
        }

        public void clearYellowTextBox()
        {
            txtCardNo.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            txtName.Text = string.Empty;
            txtSL.Text = string.Empty;
            txtFirstSalary.Text = string.Empty;
            txtCurrentSalary.Text = string.Empty;
            txtIncrementAmount.Text = string.Empty;
        }


        public void searchIncrementAmountInfo()
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();


            objIncrementDTO = objIncrementBLL.searchIncrementAmountInfo(txtEmployeeId.Text,txtYear.Text,  strHeadOfficeId, strBranchOfficeId);

            if (objIncrementDTO.IncrementAmount == string.Empty || objIncrementDTO.IncrementAmount == null || objIncrementDTO.IncrementAmount == "0") 
            {

                txtIncrementAmount.Text = "";
            }
            else
            {

                txtIncrementAmount.Text = objIncrementDTO.IncrementAmount;
            }

            if (objIncrementDTO.FirstSalary == string.Empty || objIncrementDTO.FirstSalary == "0")
            {
                txtFirstSalary.Text = "";

            }
            else
            {
                txtFirstSalary.Text = objIncrementDTO.FirstSalary;

            }



            if (objIncrementDTO.EffectDate == string.Empty || objIncrementDTO.EffectDate == null)
            {
                getIncrementEffectDate();

            }
            else
            {
                dtpEffectDate.Text = objIncrementDTO.EffectDate;

            }


        }
        public void searchGrossSalaryForIncrement()
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();

            objIncrementDTO = objIncrementBLL.searchGrossSalaryForIncrement(txtEmployeeId.Text, txtYear.Text, strHeadOfficeId, strBranchOfficeId);

            if (objIncrementDTO.GrossSalary == string.Empty || objIncrementDTO.GrossSalary == "0")
            {
                txtGrossSalary.Text = "";
            }
            else
            {
                txtGrossSalary.Text = objIncrementDTO.GrossSalary;
            }
           txtFirstSalaryCurrent.Text = objIncrementDTO.FirstSalaryCurrent;
            
        }

        public void searchMaxGrossSalary()
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();


            objIncrementDTO = objIncrementBLL.searchMaxGrossSalary(txtEmployeeId.Text, txtYear.Text, strHeadOfficeId, strBranchOfficeId);


            if (objIncrementDTO.GrossSalary == string.Empty || objIncrementDTO.GrossSalary == "0")
            {
                txtCurrentSalary.Text = "";

            }
            else
            {
                txtCurrentSalary.Text = objIncrementDTO.GrossSalary;

            }



        }


        public void searchIncrementProposalInfoHO()
        {
            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();


            objIncrementDTO = objIncrementBLL.searchIncrementProposalInfoHO(txtEmployeeId.Text, txtYear.Text, strHeadOfficeId, strBranchOfficeId);


            if (objIncrementDTO.Score == string.Empty || objIncrementDTO.Score == "0")
            {
                txtScore.Text = "";

            }
            else
            {
                txtScore.Text = objIncrementDTO.Score;

            }

            if (objIncrementDTO.Remarks == string.Empty || objIncrementDTO.Remarks == "N/A")
            {
                txtRemarks.Text = "";

            }
            else
            {
                txtRemarks.Text = objIncrementDTO.Remarks;

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
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "increment_sheet");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }
            



        }

        #endregion

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

                processIncrement();
            }

            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }


        //#region "Grid View Functionality"

        //protected void gvIncrementList_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    DataTable dataTable = Session["dt"] as DataTable;
        //    if (dataTable != null)
        //    {
        //        DataView dataView = new DataView(dataTable);
        //        dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
        //        gvIncrementList.DataSource = dataView;
        //        gvIncrementList.DataBind();
        //    }
        //}
        //private string ConvertSortDirectionToSql(SortDirection sortDireciton)
        //{
        //    string newSortDirection = String.Empty;
        //    switch (sortDireciton)
        //    {
        //        case SortDirection.Ascending:
        //            newSortDirection = "ASC";
        //            break;
        //        case SortDirection.Descending:
        //            newSortDirection = "DESC";
        //            break;
        //    }
        //    return newSortDirection;
        //}



        //protected void gvIncrementList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{



        //    GridViewRow row = gvIncrementList.Rows[e.RowIndex];
        //    TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
        //    TextBox txtCardNo = (TextBox)row.FindControl("txtCardNo");
        //    TextBox txtIncrementAmount = (TextBox)row.FindControl("txtIncrementAmount");


        //    string strSection = "";
        //    string strUnit = "";

        //    if (ddlSectionId.SelectedValue.ToString() != " ")
        //    {
        //        strSection = ddlSectionId.SelectedValue.ToString();
        //    }
        //    else
        //    {

        //        strSection = "";
        //    }



        //    if (ddlUnitId.SelectedValue.ToString() != " ")
        //    {
        //        strUnit = ddlUnitId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        strUnit = "";

        //    }

        //    string strYear = txtYear.Text;




        //    saveIncrememntAmount(txtEmployeeId.Text, txtCardNo.Text, txtIncrementAmount.Text, strSection, strUnit, strYear);
        //    gvIncrementList.EditIndex = -1;
        //    //searchIncrementRecord();
        //}


        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvIncrementList, "Edit$" + e.Row.RowIndex);
        //        e.Row.Attributes["style"] = "cursor:pointer";
        //    }
        //}

        //protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    gvIncrementList.EditIndex = e.NewEditIndex;
        //    this.searchIncrementRecord();
        //    gvIncrementList.Columns[2].Visible = true;
        //}
        //protected void gvIncrementList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    gvIncrementList.EditIndex = -1;
        //    this.searchIncrementRecord();

        //}
        //protected void OnUpdate(object sender, EventArgs e)
        //{
        //    GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
        //    string strEmployeeId = (row.Cells[1].Controls[0] as TextBox).Text;
        //    string strWorkingDay = (row.Cells[5].Controls[0] as TextBox).Text;
        //    string strAllowenceAmount = (row.Cells[6].Controls[0] as TextBox).Text;
        //    string strAttendenceBonus = (row.Cells[7].Controls[0] as TextBox).Text;




        //    gvIncrementList.EditIndex = -1;
        //    //this.searchIncrementRecord();
        //}

        //protected void OnCancel(object sender, EventArgs e)
        //{
        //    gvIncrementList.EditIndex = -1;
        //    this.searchIncrementRecord();
        //}

        //#endregion


        //added on 14.02.2022
        public void GetIncrementProposalHO()
        {

            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();
            DataTable dt = new DataTable();


            if (txtYear.Text != string.Empty)
            {
                objIncrementDTO.Year = txtYear.Text.Trim();
            }
            else
            {

                objIncrementDTO.Year = string.Empty;
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objIncrementDTO.SectionId = "";
            }

            if (ddlSupervisorId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.SupervisorId = ddlSupervisorId.SelectedValue.ToString();
            }
            else
            {

                objIncrementDTO.SupervisorId = "";
            }


            //if (ddlIncrementTypeId.SelectedValue.ToString() != " ")
            //{

            //    objIncrementDTO.IncrementTypeId = ddlIncrementTypeId.SelectedValue.ToString();
            //}
            //else
            //{

            //    objIncrementDTO.IncrementTypeId = "";
            //}

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objIncrementDTO.UnitId = "";

            }
            objIncrementDTO.Year = txtYear.Text;
            objIncrementDTO.BranchOfficeId = strBranchOfficeId;
            objIncrementDTO.HeadOfficeId = strHeadOfficeId;
            objIncrementDTO.EmployeeId = txtEmpId.Text;
            objIncrementDTO.CardNo = txtEmpCardNo.Text;

            dt = objIncrementBLL.GetIncrementProposalHO(objIncrementDTO);

            if (dt.Rows.Count > 0)
            {
                gvIncrementList.DataSource = dt;
                gvIncrementList.DataBind();
                string strMsg = "TOTAL " + gvIncrementList.Rows.Count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
                //gvIncrementList.Columns[1].Visible = false;
                addIncrementHO();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvIncrementList.DataSource = dt;
                gvIncrementList.DataBind();
                int totalcolums = gvIncrementList.Rows[0].Cells.Count;
                gvIncrementList.Rows[0].Cells.Clear();
                gvIncrementList.Rows[0].Cells.Add(new TableCell());
                gvIncrementList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvIncrementList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                //gvIncrementList.Columns[1].Visible = false;
                lblMsgRecord.Text = strMsg;

            }
            
        }

        //old: used before 14.02.2022
        public void searchIncrementRecord()
        {

            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();
            DataTable dt = new DataTable();


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objIncrementDTO.SectionId = "";
            }

            if (ddlSupervisorId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.SupervisorId = ddlSupervisorId.SelectedValue.ToString();
            }
            else
            {

                objIncrementDTO.SupervisorId = "";
            }


            //if (ddlIncrementTypeId.SelectedValue.ToString() != " ")
            //{

            //    objIncrementDTO.IncrementTypeId = ddlIncrementTypeId.SelectedValue.ToString();
            //}
            //else
            //{

            //    objIncrementDTO.IncrementTypeId = "";
            //}

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objIncrementDTO.UnitId = "";

            }
            objIncrementDTO.Year = txtYear.Text;
            objIncrementDTO.BranchOfficeId = strBranchOfficeId;
            objIncrementDTO.HeadOfficeId = strHeadOfficeId;
            objIncrementDTO.EmployeeId = txtEmpId.Text;
            objIncrementDTO.CardNo = txtEmpCardNo.Text;
                           
            dt = objIncrementBLL.searchIncrementRecord(objIncrementDTO);

            if (dt.Rows.Count > 0)
            {
                gvIncrementList.DataSource = dt;
                gvIncrementList.DataBind();
                string strMsg = "TOTAL " + gvIncrementList.Rows.Count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
                //gvIncrementList.Columns[1].Visible = false;
                addIncrementHO();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvIncrementList.DataSource = dt;
                gvIncrementList.DataBind();
                int totalcolums = gvIncrementList.Rows[0].Cells.Count;
                gvIncrementList.Rows[0].Cells.Clear();
                gvIncrementList.Rows[0].Cells.Add(new TableCell());
                gvIncrementList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvIncrementList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                //gvIncrementList.Columns[1].Visible = false;
                lblMsgRecord.Text = strMsg;

            }



        }

        

        public void searchIncrementEntryHO()
        {

            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();
            DataTable dt = new DataTable();


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objIncrementDTO.SectionId = "";
            }

            //if (ddlIncrementTypeId.SelectedValue.ToString() != " ")
            //{

            //    objIncrementDTO.IncrementTypeId = ddlIncrementTypeId.SelectedValue.ToString();
            //}
            //else
            //{

            //    objIncrementDTO.IncrementTypeId = "";
            //}

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objIncrementDTO.UnitId = "";

            }
            objIncrementDTO.Year = txtYear.Text;
            objIncrementDTO.BranchOfficeId = strBranchOfficeId;
            objIncrementDTO.HeadOfficeId = strHeadOfficeId;

            objIncrementDTO.EmployeeId = txtEmpId.Text;
            objIncrementDTO.CardNo = txtEmpCardNo.Text;

            dt = objIncrementBLL.searchIncrementEntryHO(objIncrementDTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                string strMsg = "TOTAL " + GridView1.Rows.Count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
                //GridView1.Columns[1].Visible = false;
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
                //GridView1.Columns[1].Visible = false;
                lblMsgRecord.Text = strMsg;

            }



        }


        public void addIncrementHO()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "";
            string strCount = gvIncrementList.Rows.Count.ToString();

            foreach (GridViewRow row in gvIncrementList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    string strId = (row.FindControl("lblEmployeeId") as Label).Text;

                    objSalaryDTO.EmployeeId = strId;

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

                    objSalaryDTO.UpdateBy = strEmployeeId;
                    objSalaryDTO.HeadOfficeId = strHeadOfficeId;
                    objSalaryDTO.BranchOfficeId = strBranchOfficeId;

                    strMsg = objSalaryBLL.addIncrementHO(objSalaryDTO);
                }
            }
        }


        public void IncrementHOAddUpdate()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "";

            objSalaryDTO.EmployeeId = txtEmployeeId.Text;
            objSalaryDTO.Year = txtYear.Text;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.GrossSalary = txtGrossSalary.Text;
            objSalaryDTO.FirstSalaryCurrent = txtFirstSalaryCurrent.Text;

            objSalaryDTO.UpdateBy = strEmployeeId;
            
            strMsg = objSalaryBLL.IncrementHOAddUpdate(objSalaryDTO);
        }

        #region "Grid View Functionality"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvIncrementList.PageIndex = e.NewPageIndex;
            searchIncrementRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvIncrementList.SelectedRow.RowIndex + 1;
            string strCardNo = gvIncrementList.SelectedRow.Cells[1].Text;
            string strEmployeeName = gvIncrementList.SelectedRow.Cells[2].Text;
            string strDesignation = gvIncrementList.SelectedRow.Cells[3].Text;
            string strGrossSalary = gvIncrementList.SelectedRow.Cells[5].Text;
            string strJoiningDate = gvIncrementList.SelectedRow.Cells[4].Text;
            string strEmployeeId = gvIncrementList.SelectedRow.Cells[6].Text;

            dtpJoiningDate.Text = strJoiningDate;
            txtName.Text = strEmployeeName;
            txtEmployeeId.Text = strEmployeeId;
            txtDesignation.Text = strDesignation;
            txtCardNo.Text = strCardNo;
           
            txtSL.Text =Convert.ToString( strRowId);

            searchMaxGrossSalary();
            searchGrossSalaryForIncrement();
            searchIncrementAmountInfo();
            searchIncrementProposalInfoHO();
            txtIncrementAmount.Focus();

            //string strMsg = "Row Index: " + strRowId + "\\nDesignation ID: " + strDesignationId + "\\nDesignation Name : " + strDesignationName;
            ////ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvIncrementList.EditIndex = e.NewEditIndex;
            searchIncrementRecord();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvIncrementList, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvIncrementList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //gvIncrementList.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";
        }


       

        #endregion

        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
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
            l = gvIncrementList.SelectedRow.RowIndex;
            if (l != 0)
            {

                int strId = gvIncrementList.SelectedRow.RowIndex + 1;
                int strRowCount = strId;
                int intCount = gvIncrementList.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                    return;

                }
                else
                {
                    gvIncrementList.SelectedIndex += 1;
                    result = gvIncrementList.SelectedRow.RowIndex + k;

                }

            }
            if (l == 0)
            {

                int intCount = gvIncrementList.Rows.Count;
                int intCountRow = gvIncrementList.Rows.Count;
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
                        gvIncrementList.SelectedIndex = 0;
                        result = gvIncrementList.SelectedRow.RowIndex + k;
                        txtSLNew.Text = "1";

                    }
                    else
                    {

                        int intC = gvIncrementList.Rows.Count;
                        int intCo = gvIncrementList.Rows.Count;
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

                            gvIncrementList.SelectedIndex += 1;
                            result = gvIncrementList.SelectedRow.RowIndex + k;

                        }

                    }


                }

            }


            int strRowId = gvIncrementList.SelectedRow.RowIndex + 1;
            string strSLNo = gvIncrementList.SelectedRow.Cells[0].Text;
            if (strSLNo == "NO RECORD FOUND")
            {
                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                return;
            }
            else
            {


                string strCardNo = gvIncrementList.SelectedRow.Cells[1].Text;
                string strEmployeeName = gvIncrementList.SelectedRow.Cells[2].Text;

                string strDesignation = gvIncrementList.SelectedRow.Cells[3].Text;
                string strJoiningDate = gvIncrementList.SelectedRow.Cells[4].Text;
                string strGrossSalary = gvIncrementList.SelectedRow.Cells[5].Text;
                string strEmployeeId = gvIncrementList.SelectedRow.Cells[6].Text;

                txtName.Text = strEmployeeName;
                txtEmployeeId.Text = strEmployeeId;
                txtDesignation.Text = strDesignation;
                txtCardNo.Text = strCardNo;
                txtCurrentSalary.Text = strGrossSalary;
                txtSL.Text = Convert.ToString(strRowId);

                dtpJoiningDate.Text = strJoiningDate;
                txtIncrementAmount.Focus();

            }

        }

        public void goToPreviousRecord()
        {
            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            //gvIncrementList.SelectedIndex = 1;


            int l;
            l = gvIncrementList.SelectedRow.RowIndex;
            if (l != 0)
            {
                int strId = gvIncrementList.SelectedRow.RowIndex - 1;
                int strRowCount = strId;
                int intCount = gvIncrementList.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    txtIncrementAmount.Focus();
                    return;

                }
                else
                {
                    gvIncrementList.SelectedIndex -= 1;
                    result = gvIncrementList.SelectedRow.RowIndex - k;
                }
            }
            if (l == 0)
            {

                int intCountRow = gvIncrementList.Rows.Count;
                int p = intCountRow;
                if (intCountRow == p)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    txtIncrementAmount.Focus();
                    return;

                }

                else
                {

                    l = 1;
                    gvIncrementList.SelectedIndex = l;
                    result = gvIncrementList.SelectedRow.RowIndex - k;

                }

            }

            int strRowId = gvIncrementList.SelectedRow.RowIndex + 1;

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


            string strCardNo = gvIncrementList.SelectedRow.Cells[1].Text;
            string strEmployeeName = gvIncrementList.SelectedRow.Cells[2].Text;

            string strDesignation = gvIncrementList.SelectedRow.Cells[3].Text;
            string strJoiningDate = gvIncrementList.SelectedRow.Cells[4].Text;
            string strGrossSalary = gvIncrementList.SelectedRow.Cells[5].Text;
            string strEmployeeId = gvIncrementList.SelectedRow.Cells[6].Text;

            txtName.Text = strEmployeeName;
            txtEmployeeId.Text = strEmployeeId;
            txtDesignation.Text = strDesignation;
            txtCardNo.Text = strCardNo;
            txtCurrentSalary.Text = strGrossSalary;
            txtSL.Text = Convert.ToString(strRowId);
            dtpJoiningDate.Text = strJoiningDate;


            txtIncrementAmount.Focus();
            // }

        }

        public void clearTextBox()
        {

            txtIncrementAmount.Text = string.Empty;
            txtFirstSalary.Text = string.Empty;
           // dtpEffectDate.Text = string.Empty;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (gvIncrementList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }

                else  if (txtIncrementAmount.Text == string.Empty && txtFirstSalary.Text == string.Empty )
                    {
                        clearTextBox();
                        goToNextRecord();
                        clearMessage();
                        searchIncrementAmountInfo();
                    }
                    else
                    {
                        if (txtIncrementAmount.Text == string.Empty)
                        {

                            string strMsg = "Please Enter Increment Amount!!!";
                            MessageBox(strMsg);
                            txtIncrementAmount.Focus();
                            return;
                        }
                        else
                        {
                            saveIncrementHO();  
                        } 
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
                if (gvIncrementList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else
                {

                        clearTextBox();
                        goToNextRecord();
                        clearMessage();
                    searchMaxGrossSalary();
                    searchGrossSalaryForIncrement();
                        searchIncrementAmountInfo();
                        searchIncrementProposalInfoHO();
                    

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
                if (gvIncrementList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else
                {

                   

                        clearTextBox();
                        goToPreviousRecord();
                        clearMessage();
                        searchGrossSalaryForIncrement();
                    searchMaxGrossSalary();
                    searchIncrementAmountInfo();
                        searchIncrementProposalInfoHO();
                    


                }
               
            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }



        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //searchIncrementHoldInfo();
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;
            string strJoiningDate = GridView1.SelectedRow.Cells[6].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[8].Text;
          


            txtName.Text = strEmployeeName;
            txtEmployeeId.Text = strEmployeeId;
            txtDesignation.Text = strDesignation;
            txtCardNo.Text = strCardNo;
           
            txtSL.Text = Convert.ToString(strRowId);
            dtpJoiningDate.Text = strJoiningDate;

            searchMaxGrossSalary();
            searchGrossSalaryForIncrement();
            searchIncrementAmountInfo();
            searchIncrementProposalInfoHO();

            txtIncrementAmount.Focus();


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //GridView1.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";
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

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                searchIncrementEntryHO();


            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            } 
        }

        protected void btnIncrementSheet_Click(object sender, EventArgs e)
        {
            try
            {

                
                //if (ddlUnitId.Text == " ")
                //{

                //    string strMsg = "Please Select Unit Name!!!";
                //    MessageBox(strMsg);
                //    ddlUnitId.Focus();
                //    return;
                //}

                //else
                //{

                    incrementSheet();

                //}

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



        public void incrementSheet()
        {

            try
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

                if (strHeadOfficeId == "441")
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncremetSheetAllPower.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.incrementSheetAll(objReportDTO));

                }
                else
                {

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncremetSheetAll.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.incrementSheetAll(objReportDTO));

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

        public void AllIncrementSummarySheet()
        {

            try
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

                if (strHeadOfficeId == "441")
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncremetSheetAllPower.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.AllIncrementSummarySheet(objReportDTO));

                }
                else
                {

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSummeryAllHO.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.AllIncrementSummarySheet(objReportDTO));

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

        protected void btnIncrementSlip_Click(object sender, EventArgs e)
        {
            try
            {

                //if (ddlUnitId.Text == " ")
                //{

                //    string strMsg = "Please Select Unit Name!!!";
                //    MessageBox(strMsg);
                //    ddlUnitId.Focus();
                //    return;
                //}

                //else
                //{


                    incrementSlip();

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


        public void incrementSlip()
        {
            try
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


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSlipAll.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.incrementSlipAll(objReportDTO));


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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtYear.Text == string.Empty)
                {
                    MessageBox("Please enter increment year.");
                    return;
                }

                //added on 14.02.2022
                GetIncrementProposalHO();
                //commented on 14.02.2022
                //searchIncrementRecord();

                clearYellowTextBox();
                gvIncrementList.SelectedIndex = 0;
                goToNextRecord();
                searchGrossSalaryForIncrement();
                searchMaxGrossSalary();
                searchIncrementAmountInfo();
                searchIncrementEntryHO();
                searchIncrementProposalInfoHO();
            }

            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            
            }
        }

        protected void btnIncrementSummarySheet_Click(object sender, EventArgs e)
        {
            try
            {


                //if (ddlUnitId.Text == " ")
                //{

                //    string strMsg = "Please Select Unit Name!!!";
                //    MessageBox(strMsg);
                //    ddlUnitId.Focus();
                //    return;
                //}

                //else
                //{

                AllIncrementSummarySheet();

                //}

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

        protected void btnSynchronize_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(txtEmployeeId.Text))
            {
                string strMsg = "Select one from Increment List";
                MessageBox(strMsg);
                return;
            }
            if (string.IsNullOrEmpty(txtYear.Text))
            {
                string strMsg = "Enter Year";
                MessageBox(strMsg);
                return;
            }
            if (string.IsNullOrEmpty(txtGrossSalary.Text))
            {
                string strMsg = "Enter Gross Salary";
                MessageBox(strMsg);
                return;
            }
            if (string.IsNullOrEmpty(txtFirstSalaryCurrent.Text))
            {
                string strMsg = "Select one from Increment List";
                MessageBox(strMsg);
                return;
            }

            IncrementHOAddUpdate();
        }

        protected void btnIncrementByMultiYrs_Click(object sender, EventArgs e)
        {
            GetIncrementByMultipleYears();
        }

        public void GetIncrementByMultipleYears()
        {

            try
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

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptIncrementHOByMultiYears.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetIncrementByMultipleYears(objReportDTO));


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