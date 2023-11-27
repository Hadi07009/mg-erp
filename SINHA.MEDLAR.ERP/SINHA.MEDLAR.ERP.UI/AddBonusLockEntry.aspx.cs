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
    public partial class AddBonusLockEntry : System.Web.UI.Page
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
                getMonthYearForTax();
                loadBonusLockSetup();
                getOfficeName();
                getBranchOfficeId();
                getEidTypeId();
                loadBonusLockSetup();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }


            ddlEidTypeId.Attributes.Add("onkeypress", "return controlEnter('" + txtEidYear.ClientID + "', event)");
            txtEidYear.Attributes.Add("onkeypress", "return controlEnter('" + ddlBranchOfficeId.ClientID + "', event)");
            ddlBranchOfficeId.Attributes.Add("onkeypress", "return controlEnter('" + chkActiveYn.ClientID + "', event)");
            chkActiveYn.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    ddlEidTypeId.Focus();
                    MessageBox(strMsg);
                    return;


                }
                else if (txtEidYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Eid Year!!!";
                    txtEidYear.Focus();
                    MessageBox(strMsg);
                    return;


                }

                else if (ddlBranchOfficeId.Text == " ")
                {
                    string strMsg = "Please Select Office Name!!!";
                    ddlBranchOfficeId.Focus();
                    MessageBox(strMsg);
                    return;

                }


                else
                {
                    saveBonusLockSetup();
                    loadBonusLockSetup();
                   
                }



            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {

                clear();

            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

        #region "Function"

        public void getBranchOfficeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBranchOfficeId.DataSource = objLookUpBLL.getAllBranchOfficeId();

            ddlBranchOfficeId.DataTextField = "BRANCH_OFFICE_NAME";
            ddlBranchOfficeId.DataValueField = "BRANCH_OFFICE_ID";

            ddlBranchOfficeId.DataBind();
            if (ddlBranchOfficeId.Items.Count > 0)
            {

                ddlBranchOfficeId.SelectedIndex = 0;
            }

        }

        public void getMonthYearForTax()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtEidYear.Text = objLookUpDTO.Year;

        }
        public void getEidTypeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEidTypeId.DataSource = objLookUpBLL.getEidTypeId();

            ddlEidTypeId.DataTextField = "EID_NAME";
            ddlEidTypeId.DataValueField = "EID_TYPE_ID";

            ddlEidTypeId.DataBind();
            if (ddlEidTypeId.Items.Count > 0)
            {

                ddlEidTypeId.SelectedIndex = 0;
            }

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


        public void loadBonusLockSetup()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            string strEidTypeId;
            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                strEidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {
                strEidTypeId = "";

            }
            dt = objLookUpBLL.loadBonusLockSetup(strEidTypeId, txtEidYear.Text, strHeadOfficeId, strBranchOfficeId);

            gvBonusLock.Columns[1].Visible = true;
            gvBonusLock.Columns[4].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvBonusLock.DataSource = dt;
                gvBonusLock.DataBind();
                gvBonusLock.Columns[1].Visible = false;
                gvBonusLock.Columns[4].Visible = false;
                string strMsg = "TOTAL " + gvBonusLock.Rows.Count + " RECORD FOUND";
             
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvBonusLock.DataSource = dt;
                gvBonusLock.DataBind();
                gvBonusLock.Columns[1].Visible = false;
                gvBonusLock.Columns[4].Visible = false;
                int totalcolums = gvBonusLock.Rows[0].Cells.Count;
                gvBonusLock.Rows[0].Cells.Clear();
                gvBonusLock.Rows[0].Cells.Add(new TableCell());
                gvBonusLock.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvBonusLock.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }

        public void clear()
        {

            ddlEidTypeId.Items.Clear();
            getEidTypeId();
            txtEidYear.Text = string.Empty;
            ddlBranchOfficeId.Items.Clear();
            getBranchOfficeId();
            chkActiveYn.Checked = false;

        }
        public void saveBonusLockSetup()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();



            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.EidTypeId = "";

            }
            objLookUpDTO.Year = txtEidYear.Text;
            
            if (chkActiveYn.Checked == true)
            {

                objLookUpDTO.ActiveYn = "Y";
            }
            else
            {
                objLookUpDTO.ActiveYn = "N";

            }


            if (ddlBranchOfficeId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.BranchOfficeId = ddlBranchOfficeId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.BranchOfficeId = "";

            }


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;


            string strMsg = objLookUpBLL.saveBonusLockSetup(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);



        }
       

        #endregion

        #region "GridView Functionlity"

        protected void gvBonusLock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBonusLock.PageIndex = e.NewPageIndex;
            
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvBonusLock.SelectedRow.RowIndex;

            string strEidId = gvBonusLock.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strEidName = gvBonusLock.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string strtxtEidYear = gvBonusLock.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string strBranchOfficeId = gvBonusLock.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string strBranchOfficeName = gvBonusLock.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string strchkActiveYn = gvBonusLock.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

            if (strEidId != " ")
            {
                ddlEidTypeId.SelectedValue = strEidId;
                ddlEidTypeId.DataBind();
            }
            if (strBranchOfficeId != " ")
            {
                ddlBranchOfficeId.SelectedValue = strBranchOfficeId;
                ddlBranchOfficeId.DataBind();
            }

            txtEidYear.Text = strtxtEidYear;

            if (strchkActiveYn == "ACTIVE")
            {
                chkActiveYn.Checked = true;
            }
            else
            {
                chkActiveYn.Checked = false;
            }
            
        }
        protected void gvBonusLock_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvBonusLock_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBonusLock.EditIndex = e.NewEditIndex;
            loadBonusLockSetup();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvBonusLock, "Select$" + e.Row.RowIndex);
            }
        }

        protected void chkActiveYn_CheckedChanged(object sender, EventArgs e)
        {
            
        }
 

        #endregion

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadBonusLockSetup();
        }
    }
}