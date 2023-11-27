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
    public partial class AddHeadOfficeInfo : System.Web.UI.Page
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
                loadHeadOfficeRecord();
               // loadUnitRecord();
                getOfficeName();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }


            txtHeadOfficeNameEng.Attributes.Add("onkeypress", "return controlEnter('" + txtHeadOfficeNameBng.ClientID + "', event)");
            txtHeadOfficeNameBng.Attributes.Add("onkeypress", "return controlEnter('" + txtHeadOfficeAddress.ClientID + "', event)");
            txtHeadOfficeAddress.Attributes.Add("onkeypress", "return controlEnter('" + txtPersonMobileNo.ClientID + "', event)");
            txtPersonMobileNo.Attributes.Add("onkeypress", "return controlEnter('" + txtPersonPhoneNo.ClientID + "', event)");
            txtPersonPhoneNo.Attributes.Add("onkeypress", "return controlEnter('" + txtPersonFaxNo.ClientID + "', event)");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtHeadOfficeNameEng.Text == string.Empty )
            {

                string strMsg = "Please Enter Head Office Name!!!";
                MessageBox(strMsg);
                txtHeadOfficeNameEng.Focus();
                return ;
            }
            else if (txtHeadOfficeNameBng.Text == string.Empty)
            {

                string strMsg = "Please Enter Head Office Name Bangla!!!";
                MessageBox(strMsg);
                txtHeadOfficeNameBng.Focus();
                return;
            }

            else if (txtHeadOfficeAddress.Text == string.Empty)
            {

                string strMsg = "Please Enter Head Office Name Address!!!";
                MessageBox(strMsg);
                txtHeadOfficeAddress.Focus();
                return;
            }


            else
            {
                saveHeadOfficeInfo();
                loadHeadOfficeRecord();
               

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


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void saveHeadOfficeInfo()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.HeadOfficeIdNo = txtHeadOfficeId.Text;
            objLookUpDTO.HeadOfficeName = txtHeadOfficeNameEng.Text;
            objLookUpDTO.HeadOfficeNameBangla = txtHeadOfficeNameBng.Text;
            objLookUpDTO.HeadOfficeAddress = txtHeadOfficeAddress.Text;
            objLookUpDTO.HeadOfficeMobileNo = txtPersonMobileNo.Text;
            objLookUpDTO.HeadOfficePhoneNo = txtPersonPhoneNo.Text;
            objLookUpDTO.HeadOfficeFaxNo = txtPersonFaxNo.Text;

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.saveHeadOfficeInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void searchHeadOfficeInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchHeadOfficeInfo(txtHeadOfficeId.Text);

            txtHeadOfficeNameEng.Text = objLookUpDTO.HeadOfficeName;
            txtHeadOfficeNameBng.Text = objLookUpDTO.HeadOfficeNameBangla;
            txtHeadOfficeAddress.Text = objLookUpDTO.HeadOfficeAddress;
            txtPersonMobileNo.Text = objLookUpDTO.HeadOfficeMobileNo;
            txtPersonPhoneNo.Text = objLookUpDTO.HeadOfficePhoneNo;
            txtPersonFaxNo.Text = objLookUpDTO.HeadOfficeFaxNo;

        }

        public void loadHeadOfficeRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadHeadOfficeRecord(strHeadOfficeId,strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvHeadOffice.DataSource = dt;
                gvHeadOffice.DataBind();
                string strMsg = "TOTAL " + gvHeadOffice.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvHeadOffice.DataSource = dt;
                gvHeadOffice.DataBind();
                int totalcolums = gvHeadOffice.Rows[0].Cells.Count;
                gvHeadOffice.Rows[0].Cells.Clear();
                gvHeadOffice.Rows[0].Cells.Add(new TableCell());
                gvHeadOffice.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvHeadOffice.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtHeadOfficeId.Text = "";
            txtHeadOfficeNameEng.Text = "";
            txtHeadOfficeNameBng.Text = "";
            txtHeadOfficeAddress.Text = "";
            txtPersonMobileNo.Text = "";
            txtPersonPhoneNo.Text = "";
            txtPersonFaxNo.Text = "";
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtHeadOfficeId.Text == string.Empty)
            {

                string strMsg = "Please Enter Head Office ID!!!";
                MessageBox(strMsg);
                txtHeadOfficeId.Focus();
                return;
            }
            else
            {
                searchHeadOfficeInfo();

            }
        }

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHeadOffice.PageIndex = e.NewPageIndex;
            loadHeadOfficeRecord();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvHeadOffice, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvHeadOffice.SelectedRow.RowIndex;
            string strHeadOfficeId = gvHeadOffice.SelectedRow.Cells[0].Text;
            string strHeadOfficeName = gvHeadOffice.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strHeadOfficeNameBng = gvHeadOffice.SelectedRow.Cells[2].Text.Replace("&#168;", "¨").Replace("&#182;", "¶")
                .Replace("&#214;", "Ö").Replace("&#221;", "Ý").Replace("&#247;", "÷").Replace("&#169;", "©").Replace("&#177;", "±")
                .Replace("&#172;", "¬").Replace("&#170;", "ª").Replace("&#243;", "ó").Replace("&#164;", "¤").Replace("&#248;", "ø")
                .Replace("&#250;", "ú").Replace("&#219;", "Û").Replace("&#194;", "Â").Replace("&#196;", "Ä").Replace("&#175;", "¯")
                .Replace("&amp;", "&").Replace("&#236;", "ì").Replace("&#173;", "­­­­­­­").Replace("&#183;", "­­­­­­­·").Replace("&#191;&#191;&#191;&#191;&#191;&#191;&#191;&#191;", "­­­­­­­¿¿¿¿¿¿¿¿").Replace("&#191;", "¿")
                .Replace("&#230;", "æ"); ;
            string strHeadOfficeAddress = gvHeadOffice.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string strHeadOfficeMobileNo = gvHeadOffice.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string strHeadOfficePhoneNo = gvHeadOffice.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string strHeadOfficeFaxNo = gvHeadOffice.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

            txtHeadOfficeId.Text = strHeadOfficeId;
            txtHeadOfficeNameEng.Text = strHeadOfficeName;
            txtHeadOfficeNameBng.Text = strHeadOfficeNameBng;
            txtHeadOfficeAddress.Text = strHeadOfficeAddress;
            txtPersonMobileNo.Text = strHeadOfficeMobileNo;
            txtPersonPhoneNo.Text = strHeadOfficePhoneNo;
            txtPersonFaxNo.Text = strHeadOfficeFaxNo;
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