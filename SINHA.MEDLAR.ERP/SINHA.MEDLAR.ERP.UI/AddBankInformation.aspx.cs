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
    public partial class AddBankInformation : System.Web.UI.Page
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

                getOfficeName();
                loadBankRecord();
                lblMsg.Text = string.Empty;
            }

            if (IsPostBack)
            {

                loadSesscion();
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

        public void loadBankRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadBankRecord();


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

            txtBankId.Text = string.Empty;
            txtBankName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            txtAddress.Text = string.Empty;



        }

        public void saveBankInformation()
        {

            BankDTO objBankDTO = new BankDTO();
            BankBLL objBankBLL = new BankBLL();


            objBankDTO.BankId = txtBankId.Text;
            objBankDTO.BankName = txtBankName.Text;
            objBankDTO.BankAddress = txtAddress.Text;
            objBankDTO.MobileNo = txtMobileNo.Text;
            objBankDTO.PhoneNo = txtPhoneNo.Text;
            objBankDTO.FaxNo = txtFaxNo.Text;
            objBankDTO.EmailAddress = txtEmailAddress.Text;
            objBankDTO.SwiftCode= txtSwiftCode.Text;
            objBankDTO.AccountNo = txtAccountNo.Text;

            if (chkActiveYn.Checked == true)
            {

                objBankDTO.ActiveYn = "Y";
            }
            else
            {

                objBankDTO.ActiveYn = "N";
            }


            string strMsg = objBankBLL.saveBankInformation(objBankDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);



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
                throw new Exception("Error : " +ex.Message);

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                saveBankInformation();
                loadBankRecord();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }


        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadBankRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strBankId = gvUnit.SelectedRow.Cells[0].Text;
            string strBankName = gvUnit.SelectedRow.Cells[1].Text;
            string strAccountNo = gvUnit.SelectedRow.Cells[2].Text;
            string strSwiftCode = gvUnit.SelectedRow.Cells[3].Text;
            string strAddress = gvUnit.SelectedRow.Cells[4].Text;
          
            txtBankId.Text = strBankId;
            txtBankName.Text = strBankName;
            txtAccountNo.Text = strAccountNo;
            txtSwiftCode.Text = strSwiftCode;
            txtAddress.Text = strAddress;
          


            string strMsg = "Row Index: " + strRowId + "\\nBank ID : " + strBankId + "\\nBank Name : " + strBankName + "\\nAccount No : " + strAccountNo + "\\nSwift Code : " + strSwiftCode + "\\nAddress : " + strAddress ;
            MessageBox(strMsg);
        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
            loadBankRecord();
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






        #endregion
    }
}