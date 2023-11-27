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
using SINHA.MEDLAR.ERP.UI.Utility;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AddUnitInfo : System.Web.UI.Page
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
            try
            {
                if (Session["strEmployeeId"] == null)
                {
                    sessionEmpty();
                    return;
                }
                if (!IsPostBack)
                {
                    loadSesscion();
                 
                    loadUnitRecord();
                    getUnitGroupId();
                    GetFloorDropdown();
                    getOfficeName();
                }

                if (IsPostBack)
                {
                    loadSesscion();
                }
            }
            catch(Exception ex)
            {
                MessageBox(ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtUnitNameEng.Text == string.Empty)
            {

                string strMsg = "Please Enter Unit Name!!!";
                MessageBox(strMsg);
                //ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Enter Unit Name');", true);
                txtUnitNameEng.Focus();
                return ;
            }
            if (ddlUnitGroupId.Text == string.Empty)
            {

                string strMsg = "Please Enter Group Name!!!";
                MessageBox(strMsg);
                
                return;
            }
            else
            {
                saveUnitInfo();
                loadUnitRecord();

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

        public void getUnitGroupId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();

            var dt = objLookUpBLL.GetSalaryByUnitGroup_Test(strHeadOfficeId, strBranchOfficeId);
            UIHelper.PopulateDropdown(ddlUnitGroupId, "UNIT_GROUP_NAME", "UNIT_GROUP_ID", dt, "Please Select", "", "");
        }
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void saveUnitInfo()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            if (ddlUnitGroupId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.UnitGroupId = "";
            }
            if (ddlFloor.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.FloorId = ddlFloor.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.FloorId = "";
            }
            objLookUpDTO.UnitId = txtUnitId.Text;
            objLookUpDTO.UnitName = txtUnitNameEng.Text;
            objLookUpDTO.UnitNameBangla = txtUnitNameBng.Text;


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.saveUnitInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void searchUnitInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchUnitInfo(txtUnitId.Text);

            txtUnitNameEng.Text = objLookUpDTO.UnitName;
            txtUnitNameBng.Text = objLookUpDTO.UnitNameBangla;


        }

        public void loadUnitRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadUnitRecord(strHeadOfficeId, strBranchOfficeId);


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
            txtUnitId.Text = "";
            txtUnitNameBng.Text = "";
            txtUnitNameEng.Text = "";
            ddlFloor.SelectedValue = "";
            ddlUnitGroupId.SelectedValue = "";


        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtUnitId.Text == string.Empty)
            {

                string strMsg = "Please Enter Unit ID!!!";
                MessageBox(strMsg);
                txtUnitId.Focus();
                return;
            }
            else
            {
                searchUnitInfo();

            }
        }

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadUnitRecord();
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

            string unitGroupId = gvUnit.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string FloorId = gvUnit.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            ddlUnitGroupId.SelectedValue = unitGroupId;
            ddlFloor.SelectedValue = FloorId;

            string strUnitNameBng = gvUnit.SelectedRow.Cells[2].Text.Replace("&#168;", "¨").Replace("&#182;", "¶")
                       .Replace("&#214;", "Ö").Replace("&#221;", "Ý").Replace("&#247;", "÷").Replace("&#169;", "©").Replace("&#177;", "±")
                       .Replace("&#172;", "¬").Replace("&#170;", "ª").Replace("&#243;", "ó").Replace("&#164;", "¤").Replace("&#248;", "ø")
                       .Replace("&#250;", "ú").Replace("&#219;", "Û").Replace("&#194;", "Â").Replace("&#196;", "Ä").Replace("&#175;", "¯")
                       .Replace("&amp;", "&").Replace("&#236;", "ì").Replace("&#173;", "­­­­­­­").Replace("&#183;", "­­­­­­­·").Replace("&#191;&#191;&#191;&#191;&#191;&#191;&#191;&#191;", "­­­­­­­¿¿¿¿¿¿¿¿")
                       .Replace("&#191;", "¿");
           // string strGroupUnitName = gvUnit.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            txtUnitId.Text = strUnitId;
            txtUnitNameEng.Text = strUnitName;
            txtUnitNameBng.Text = strUnitNameBng;
            //ddlUnitGroupId.SelectedValue = strGroupUnitName;



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