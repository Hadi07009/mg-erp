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
    public partial class AddSection : System.Web.UI.Page
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
                loadSectionRecord();
                getOfficeName();
                getEmployeeTypeId();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }
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

        public void loadSectionRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadSectionRecord(strHeadOfficeId, strBranchOfficeId);


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

        public void getEmployeeTypeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEmployeeTypeId.DataSource = objLookUpBLL.getEmployeeTypeId();

            ddlEmployeeTypeId.DataTextField = "EMPLOYEE_TYPE_NAME";
            ddlEmployeeTypeId.DataValueField = "EMPLOYEE_TYPE_ID";

            ddlEmployeeTypeId.DataBind();
            if (ddlEmployeeTypeId.Items.Count > 0)
            {

                ddlEmployeeTypeId.SelectedIndex = 0;
            }
        }


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
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

        public void clear()
        {



            txtSectionId.Text = string.Empty;
            txtSectionNameBng.Text = string.Empty;
            txtSectionNameEng.Text = string.Empty;


        }
        public void saveSection()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.SectionId = txtSectionId.Text;
            objLookUpDTO.SectionNameEng = txtSectionNameEng.Text;
            objLookUpDTO.SectionNameBng = txtSectionNameBng.Text;

            if (ddlEmployeeTypeId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.EmployeeTypeId = "";
            }

            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            objLookUpDTO.UpdateBy = strEmployeeId;


            string strMsg = objLookUpBLL.saveSection(objLookUpDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }

        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {

                clear();
            }

            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                saveSection();
                clear();
                loadSectionRecord();
            }

            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
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
            string strSectionId = gvUnit.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strSectionName = gvUnit.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
           
            string employeeTypeId = gvUnit.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");

            string strSectionBng = gvUnit.SelectedRow.Cells[2].Text.Replace("&#168;", "¨").Replace("&#182;", "¶")
                       .Replace("&#214;", "Ö").Replace("&#221;", "Ý").Replace("&#247;", "÷").Replace("&#169;", "©").Replace("&#177;", "±")
                       .Replace("&#172;", "¬").Replace("&#170;", "ª").Replace("&#243;", "ó").Replace("&#164;", "¤").Replace("&#248;", "ø")
                       .Replace("&#250;", "ú").Replace("&#219;", "Û").Replace("&#194;", "Â").Replace("&#196;", "Ä").Replace("&#175;", "¯")
                       .Replace("&amp;", "&").Replace("&#236;", "ì").Replace("&#173;", "­­­­­­­").Replace("&#183;", "­­­­­­­·").Replace("&#191;&#191;&#191;&#191;&#191;&#191;&#191;&#191;", "­­­­­­­¿¿¿¿¿¿¿¿")
                       .Replace("&#191;", "¿");

            txtSectionId.Text = strSectionId;
            txtSectionNameEng.Text = strSectionName;
            txtSectionNameBng.Text = strSectionBng;
            ddlEmployeeTypeId.SelectedValue = employeeTypeId;

            string strMsg = "Row Index: " + strRowId + "\\nSection ID: " + strSectionId + "\\nSection Name : " + strSectionName + "\\nSection Name Bangla : " + strSectionBng;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }


        
    }
}