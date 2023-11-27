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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class GazetteInfo : System.Web.UI.Page
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
                getGradeId();
                loadGazetteInfo();
                //   getUnitId();
                //  getSectionId();
                // getOfficeName();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }



        }



        #region "Function"

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


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        public void loadGazetteInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadGazetteInfo();


            if (dt.Rows.Count > 0)
            {
                gvGazette.DataSource = dt;
                gvGazette.DataBind();
                string strMsg = "TOTAL " + gvGazette.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                //lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvGazette.DataSource = dt;
                gvGazette.DataBind();
                int totalcolums = gvGazette.Rows[0].Cells.Count;
                gvGazette.Rows[0].Cells.Clear();
                gvGazette.Rows[0].Cells.Add(new TableCell());
                gvGazette.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvGazette.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                //string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                //lblMsg.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            ddlSchedule.Text = " ";
            ddlGrade.Text = " ";
            txtMedicalFee.Text = "";
            txtConveyanceFee.Text = "";
            txtExtraFoodFee.Text = "";
            txtFoodFee.Text = "";
            txtPublishYear.Text = "";
            txtGrossSalary.Text = "";

        }
        public void getUnitId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSchedule.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlSchedule.DataTextField = "UNIT_NAME";
            ddlSchedule.DataValueField = "UNIT_ID";

            ddlSchedule.DataBind();
            if (ddlSchedule.Items.Count > 0)
            {

                ddlSchedule.SelectedIndex = 0;
            }

        }
        public void getGradeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlGrade.DataSource = objLookUpBLL.getGradeId(strHeadOfficeId, strBranchOfficeId);

            ddlGrade.DataTextField = "GRADE_NO";
            ddlGrade.DataValueField = "GRADE_ID";

            ddlGrade.DataBind();
            if (ddlGrade.Items.Count > 0)
            {

                ddlGrade.SelectedIndex = 0;
            }

        }
      

        public void getSectionId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlGrade.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

            ddlGrade.DataTextField = "SECTION_NAME";
            ddlGrade.DataValueField = "SECTION_ID";

            ddlGrade.DataBind();
            if (ddlGrade.Items.Count > 0)
            {

                ddlGrade.SelectedIndex = 0;
            }


        }

        #endregion


        #region "Gridview Functionality"
        protected void gvGazette_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGazette.PageIndex = e.NewPageIndex;
            loadGazetteInfo();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvGazette, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvGazette.SelectedRow.RowIndex;
            string strPublishYear = gvGazette.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strScheduleId = gvGazette.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strGradeId = gvGazette.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string strGrossSalary = gvGazette.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string strMedicalFee = gvGazette.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            string strConvinceFee = gvGazette.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            string strFoodFee = gvGazette.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            string strExtrafoodfee = gvGazette.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            string activeYn = gvGazette.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            string strGazetteId = gvGazette.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");

            if (strScheduleId == "")
                strScheduleId = " ";
            if (strGradeId == "")
                strGradeId = " ";

            txtPublishYear.Text = strPublishYear;
            
            ddlSchedule.SelectedValue = strScheduleId;
            ddlGrade.SelectedValue= strGradeId;
            txtGrossSalary.Text = strGrossSalary;
            txtMedicalFee.Text = strMedicalFee;
            txtConveyanceFee.Text = strConvinceFee;
            txtFoodFee.Text = strFoodFee;
            txtExtraFoodFee.Text = strExtrafoodfee;
            chkActive.Checked = activeYn == "Y" ? true : false;
            txtGazatteId.Text = strGazetteId;
        }


        public void SaveGazetteInfo()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            if (ddlSchedule.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.ScheduleId = ddlSchedule.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.ScheduleId = "";
            }
            if (ddlGrade.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.GradeId = ddlGrade.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.GradeId = "";
            }
            objSalaryDTO.GrossSalary = txtGrossSalary.Text;
            objSalaryDTO.MedicalFee = txtMedicalFee.Text;
            objSalaryDTO.ConvenceFee = txtConveyanceFee.Text;
            objSalaryDTO.FoodAllowance = txtFoodFee.Text;
            objSalaryDTO.ExtraFoodFee = txtExtraFoodFee.Text;
            objSalaryDTO.Year = txtPublishYear.Text;
            if (chkActive.Checked == true)
            {
                objSalaryDTO.ChkActive = "Y";
            }
            else
            {
                objSalaryDTO.ChkActive = "N";
            }
            objSalaryDTO.GazetteId = txtGazatteId.Text;
            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objSalaryBLL.SaveGazetteInfo(objSalaryDTO);
            //lblMsg.Text = strMsg;
            MessageBox(strMsg);

            if (strMsg == "INSERTED SUCCESSFULLY")
            {
                clearTextBox();
            }
        }

        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearTextBox();

            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkActive.Checked == true)
                {

                    SaveGazetteInfo();
                    loadGazetteInfo();

                }
                else
                {

                    if (ddlSchedule.Text == " ")
                    {

                        string strMsg = "Please Select Unit Name!!!";
                        MessageBox(strMsg);
                        ddlSchedule.Focus();
                        return;
                    }

                    else if (ddlGrade.Text == " ")
                    {

                        string strMsg = "Please Select Section Name!!!";
                        MessageBox(strMsg);
                        ddlGrade.Focus();
                        return;
                    }

                    else
                    {
                        SaveGazetteInfo();
                        loadGazetteInfo();

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }
       
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPublishYear.Text == " ")
            {

                string strMsg = "Please Select Publish Year!!!";
                MessageBox(strMsg);                
                return;
            }
            else
            {

                   loadGazetteInfo();

            }

        }
    }
}