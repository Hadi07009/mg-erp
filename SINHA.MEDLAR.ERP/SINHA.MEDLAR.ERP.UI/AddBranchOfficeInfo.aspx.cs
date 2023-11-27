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
    public partial class AddBranchOfficeInfo : System.Web.UI.Page
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
               
                loadBranchOfficeRecord();
               // loadUnitRecord();
                getOfficeName();
                getHeadOfficeId();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtBranchOfficeNameEng.Text == string.Empty)
            {

                string strMsg = "Please Enter The Branch Office Name!!!";
                MessageBox(strMsg);
                txtBranchOfficeNameEng.Focus();
                return ;
            }
            else if (txtBranchOfficeNameBng.Text == string.Empty)
            {

                string strMsg = "Please Enter The Branch Office Name Bangla!!!";
                MessageBox(strMsg);
                txtBranchOfficeNameBng.Focus();
                return;
            }
            else if (txtBranchOfficeAddress.Text == string.Empty)
            {

                string strMsg = "Please Enter The Branch Office Address!!!";
                MessageBox(strMsg);
                txtBranchOfficeAddress.Focus();
                return;
            }

            else
            {
                saveBranchOfficeInfo();
                loadBranchOfficeRecord();
              
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

        public void getHeadOfficeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlHeadOfficeName.DataSource = objLookUpBLL.getHeadOfficeId(strHeadOfficeId);

            ddlHeadOfficeName.DataTextField = "HEAD_OFFICE_NAME";
            ddlHeadOfficeName.DataValueField = "HEAD_OFFICE_ID";

            ddlHeadOfficeName.DataBind();
            if (ddlHeadOfficeName.Items.Count > 0)
            {

                ddlHeadOfficeName.SelectedIndex = 0;
            }

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


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        public void saveBranchOfficeInfo()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.BranchOfficeIdNo = txtBranchOfficeId.Text;
            objLookUpDTO.HeadOfficeId = ddlHeadOfficeName.SelectedValue;
            objLookUpDTO.BranchOfficeName = txtBranchOfficeNameEng.Text;
            objLookUpDTO.BranchOfficeNameBng = txtBranchOfficeNameBng.Text;
            objLookUpDTO.BranchOfficeAddress = txtBranchOfficeAddress.Text;
            objLookUpDTO.BranchOfficeMobileNo = txtPersonMobileNo.Text;
            objLookUpDTO.BranchOfficePhoneNo = txtPersonPhoneNo.Text;
            objLookUpDTO.BranchOfficeFaxNo = txtPersonFaxNo.Text;

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.saveBranchOfficeInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void searchBranchOfficeInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchBranchOfficeInfo(txtBranchOfficeId.Text);

            txtBranchOfficeNameEng.Text = objLookUpDTO.BranchOfficeName;
            txtBranchOfficeNameBng.Text = objLookUpDTO.BranchOfficeNameBng;
            txtBranchOfficeAddress.Text = objLookUpDTO.BranchOfficeAddress;
            txtPersonMobileNo.Text = objLookUpDTO.BranchOfficeMobileNo;
            txtPersonPhoneNo.Text = objLookUpDTO.BranchOfficePhoneNo;
            txtPersonFaxNo.Text = objLookUpDTO.BranchOfficeFaxNo;

        }

        public void loadBranchOfficeRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadBranchOfficeRecord(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvBranchOffice.DataSource = dt;
                gvBranchOffice.DataBind();
                string strMsg = "TOTAL " + gvBranchOffice.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvBranchOffice.DataSource = dt;
                gvBranchOffice.DataBind();
                int totalcolums = gvBranchOffice.Rows[0].Cells.Count;
                gvBranchOffice.Rows[0].Cells.Clear();
                gvBranchOffice.Rows[0].Cells.Add(new TableCell());
                gvBranchOffice.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvBranchOffice.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtBranchOfficeId.Text = "";
            txtBranchOfficeNameEng.Text = "";
            txtBranchOfficeNameBng.Text = "";
            txtBranchOfficeAddress.Text = "";
            txtPersonMobileNo.Text = "";
            txtPersonPhoneNo.Text = "";
            txtPersonFaxNo.Text = "";
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtBranchOfficeId.Text == string.Empty)
            {

                string strMsg = "Please Enter Branch Office ID!!!";
                MessageBox(strMsg);
                txtBranchOfficeId.Focus();
                return;
            }
            else
            {
                searchBranchOfficeInfo();

            }
        }

        protected void gvBranchOffice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBranchOffice.PageIndex = e.NewPageIndex;
            loadBranchOfficeRecord();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvBranchOffice, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvBranchOffice.SelectedRow.RowIndex;
            string strBranchOfficeId = gvBranchOffice.SelectedRow.Cells[0].Text;
            string strBranchOfficeName = gvBranchOffice.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strBranchOfficeNameBng = gvBranchOffice.SelectedRow.Cells[2].Text.Replace("&#168;", "¨").Replace("&#182;", "¶")
                .Replace("&#214;", "Ö").Replace("&#221;", "Ý").Replace("&#247;", "÷").Replace("&#169;", "©").Replace("&#177;", "±")
                .Replace("&#172;", "¬").Replace("&#170;", "ª").Replace("&#243;", "ó").Replace("&#164;", "¤").Replace("&#248;", "ø")
                .Replace("&#250;", "ú").Replace("&#219;", "Û").Replace("&#194;", "Â").Replace("&#196;", "Ä").Replace("&#175;", "¯")
                .Replace("&amp;", "&").Replace("&#236;", "ì").Replace("&#173;", "­­­­­­­").Replace("&#183;", "­­­­­­­·").Replace("&#191;&#191;&#191;&#191;&#191;&#191;&#191;&#191;", "­­­­­­­¿¿¿¿¿¿¿¿").Replace("&#191;", "¿")
                .Replace("&#230;", "æ"); ;
            string strBranchOfficeAddress = gvBranchOffice.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string strBranchOfficeMobileNo = gvBranchOffice.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string strBranchOfficePhoneNo = gvBranchOffice.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string strBranchOfficeFaxNo = gvBranchOffice.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

            txtBranchOfficeId.Text = strBranchOfficeId;
            txtBranchOfficeNameEng.Text = strBranchOfficeName;
            txtBranchOfficeNameBng.Text = strBranchOfficeNameBng;
            txtBranchOfficeAddress.Text = strBranchOfficeAddress;
            txtPersonMobileNo.Text = strBranchOfficeMobileNo;
            txtPersonPhoneNo.Text = strBranchOfficePhoneNo;
            txtPersonFaxNo.Text = strBranchOfficeFaxNo;
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