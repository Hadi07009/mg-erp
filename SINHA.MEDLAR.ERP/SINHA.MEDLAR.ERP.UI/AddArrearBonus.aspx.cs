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
    public partial class AddArrearBonus : System.Web.UI.Page
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
                getArrearYear();
                getFromMonthId();
                getToMonthId();
                loadArrearBonusRecord();
                getOfficeName();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }


            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (ddlFromMonthId.Text == "0")
            {
                string strMsg = "Please select From Month!!!";
                MessageBox(strMsg);
                ddlFromMonthId.Focus();
                return;


            }
            else if (ddlToMonthId.Text == "0")
            {
                string strMsg = "Please select To Month!!!";
                MessageBox(strMsg);
                ddlToMonthId.Focus();
                return;

            }

            else if (txtYear.Text == "")
            {
                string strMsg = "Please Enter Year!!!";
                MessageBox(strMsg);
                txtYear.Focus();
                return;

            }

            else if (txtTotalArrearBounsMonth.Text == "")
            {
                string strMsg = "Please Enter Total Bonus Month!!!";
                MessageBox(strMsg);
                txtTotalArrearBounsMonth.Focus();
                return;

            }
            else
            {
                saveArrearBonusInfo();
                loadArrearBonusRecord();



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
        public void getArrearYear()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForTax();

            txtYear.Text = objLookUpDTO.Year;


        }
        public void getFromMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlFromMonthId.DataSource = objLookUpBLL.getFromMonthId();

            ddlFromMonthId.DataTextField = "MONTH_NAME";
            ddlFromMonthId.DataValueField = "MONTH_ID";

            ddlFromMonthId.DataBind();
            if (ddlFromMonthId.Items.Count > 0)
            {

                ddlFromMonthId.SelectedIndex = 0;
            }
        }


        public void getToMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlToMonthId.DataSource = objLookUpBLL.getFromMonthId();

            ddlToMonthId.DataTextField = "MONTH_NAME";
            ddlToMonthId.DataValueField = "MONTH_ID";

            ddlToMonthId.DataBind();
            if (ddlToMonthId.Items.Count > 0)
            {

                ddlToMonthId.SelectedIndex = 0;
            }
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

        public void saveArrearBonusInfo()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();



            objLookUpDTO.ArrearBonusId = txtArrearBonusId.Text;
            objLookUpDTO.Year = txtYear.Text;

            objLookUpDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
            objLookUpDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
            objLookUpDTO.TotalMonth = txtTotalArrearBounsMonth.Text;
          

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.saveArrearBonusInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void searchArrearBonusInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchArrearBonusInfo(txtArrearBonusId.Text, strHeadOfficeId, strBranchOfficeId);

            if (objLookUpDTO.FromMonthId!= "0")
            {
                ddlFromMonthId.SelectedValue = objLookUpDTO.FromMonthId;
            }
            else
            {
                getFromMonthId();

            }


            if (objLookUpDTO.ToMonthId != "0")
            {
                ddlToMonthId.SelectedValue = objLookUpDTO.ToMonthId;
            }
            else
            {
                getToMonthId();

            }
            if (objLookUpDTO.TotalMonth != "0")
            {
                txtTotalArrearBounsMonth.Text = objLookUpDTO.TotalMonth;
            }
            else
            {
                txtTotalArrearBounsMonth.Text = "";

            }

        }

        public void loadArrearBonusRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadArrearBonusRecord(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                int totalcolums = gvUnit.Rows[0].Cells.Count;
                gvUnit.Rows[0].Cells.Clear();
                gvUnit.Rows[0].Cells.Add(new TableCell());
                gvUnit.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvUnit.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
           

        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtArrearBonusId.Text == string.Empty)
            {

                string strMsg = "Please Enter  ID!!!";
                MessageBox(strMsg);
                txtArrearBonusId.Focus();
                return;
            }
            else
            {
                searchArrearBonusInfo();

            }
        }

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
           
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvUnit, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strUnitId = gvUnit.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strUnitName = gvUnit.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
           
            string strUnitNameBng = gvUnit.SelectedRow.Cells[2].Text.Replace("&#168;", "¨").Replace("&#182;", "¶")
                       .Replace("&#214;", "Ö").Replace("&#221;", "Ý").Replace("&#247;", "÷").Replace("&#169;", "©").Replace("&#177;", "±")
                       .Replace("&#172;", "¬").Replace("&#170;", "ª").Replace("&#243;", "ó").Replace("&#164;", "¤").Replace("&#248;", "ø")
                       .Replace("&#250;", "ú").Replace("&#219;", "Û").Replace("&#194;", "Â").Replace("&#196;", "Ä").Replace("&#175;", "¯")
                       .Replace("&amp;", "&").Replace("&#236;", "ì").Replace("&#173;", "­­­­­­­").Replace("&#183;", "­­­­­­­·").Replace("&#191;&#191;&#191;&#191;&#191;&#191;&#191;&#191;", "­­­­­­­¿¿¿¿¿¿¿¿")
                       .Replace("&#191;", "¿");

            txtArrearBonusId.Text = strUnitId;


            searchArrearBonusInfo();

            //string strMsg = "Row Index: " + strRowId + "\\nUnit ID: " + strUnitId + "\\nUnit Name : " + strUnitName + "\\nUnit Name Bangla : " + strUnitNameBng ;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearTextBox();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " +ex.Message);
            }
        }

    
    }
}