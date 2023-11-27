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
    public partial class AddDepartment : System.Web.UI.Page
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
                loadDepartmentRecord();
                clearMsg();
            }
            if (IsPostBack)
            {
                
                loadSesscion();
                
            }
        }

        #region "Function"

        public void clearMsg()
        {

            lblMsg.Text = "";

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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        private void AlertMessage(string message)
        {
            string alertScript = @"<script language=""javascript""> ";
            alertScript += "alert('" + message + "');";
            alertScript += "</script" + ">";

            if (!ClientScript.IsStartupScriptRegistered("alert"))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "alert", alertScript);
            }
        }

        public void loadDepartmentRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadDepartmentRecord(strHeadOfficeId, strBranchOfficeId);


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

        public void saveDepartment()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.DepartmentId = txtDepartmentId.Text;
            objLookUpDTO.DepartmentNameEng = txtDepartmentEng.Text;
            objLookUpDTO.DepartmentNameBng = txtDepartmentNameBng.Text;


            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            objLookUpDTO.UpdateBy = strEmployeeId;

            string strMsg = objLookUpBLL.saveDepartment(objLookUpDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;
        }

        public void searchDepartment()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO = objLookUpBLL.searchDepartment(txtDepartmentId.Text);

            txtDepartmentId.Text = txtDepartmentId.Text;
             txtDepartmentEng.Text = objLookUpDTO.DepartmentNameEng;
            txtDepartmentNameBng.Text =  objLookUpDTO.DepartmentNameBng;

        }

        public void clear()
        {
            txtDepartmentId.Text = string.Empty;
            txtDepartmentEng.Text = string.Empty;
            txtDepartmentNameBng.Text = string.Empty;

        }

        #endregion

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadDepartmentRecord();
        }

        protected void gvUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strUnitId = gvUnit.SelectedRow.RowIndex;
            string strDepartmentId = gvUnit.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strDepartmentName = gvUnit.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
           

            string strDepartmentNameBng = gvUnit.SelectedRow.Cells[2].Text.Replace("&#168;", "¨").Replace("&#182;", "¶")
                .Replace("&#214;", "Ö").Replace("&#221;", "Ý").Replace("&#247;", "÷").Replace("&#169;", "©").Replace("&#177;", "±")
                .Replace("&#172;", "¬").Replace("&#170;", "ª").Replace("&#243;", "ó").Replace("&#164;", "¤").Replace("&#248;", "ø")
                .Replace("&#250;", "ú").Replace("&#219;", "Û").Replace("&#194;", "Â").Replace("&#196;", "Ä").Replace("&#175;", "¯")
                .Replace("&amp;", "&").Replace("&#236;", "ì").Replace("&#173;", "­­­­­­­").Replace("&#183;", "­­­­­­­·").Replace("&#191;&#191;&#191;&#191;&#191;&#191;&#191;&#191;", "­­­­­­­¿¿¿¿¿¿¿¿")
                .Replace("&#191;", "¿");

            txtDepartmentId.Text = strDepartmentId;
            txtDepartmentEng.Text = strDepartmentName;
            txtDepartmentNameBng.Text = strDepartmentNameBng;

            searchDepartment();
            //string strMsg = "Row Index: " + strUnitId + "\\nUnit Name: " + strUnitName + "\\nUnit Name Bangla: " + strUnitNameBangla;
            //MessageBox(strMsg);
        }
        //protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        //{
        //    e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        //    e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        //}


        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvUnit, "Select$" + e.Row.RowIndex);
            }
            
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDepartmentEng.Text == string.Empty && txtDepartmentNameBng.Text == string.Empty)
                {

                    string strMsg = "Please Enter Department Name in English!!!";
                    txtDepartmentEng.Focus();
                    AlertMessage(strMsg);
                    return;
                }
               
                else
                {
                    saveDepartment();
                    loadDepartmentRecord();
                }
            }

            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }

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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                searchDepartment();
            }

            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }
    }
}