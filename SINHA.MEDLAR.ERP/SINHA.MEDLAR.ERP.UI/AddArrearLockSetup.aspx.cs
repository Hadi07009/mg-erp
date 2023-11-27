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
    public partial class AddArrearLockSetup : System.Web.UI.Page
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
                getYearForIncrementProposal();
                loadArrearLockSetup();
                getFromMonthId();
                getToMonthId();
                getOfficeName();
                getBranchOfficeId();
                

            }

            if (IsPostBack)
            {

                loadSesscion();
            }


            txtArrearYear.Attributes.Add("onkeypress", "return controlEnter('" + chkActiveYn.ClientID + "', event)");
           // txtSalaryMonth.Attributes.Add("onkeypress", "return controlEnter('" + chkActiveYn.ClientID + "', event)");
            chkActiveYn.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtArrearYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Arrear Year!!!";
                    txtArrearYear.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (ddlBranchOfficeId.Text == "")
                {
                    string strMsg = "Please Select Office Name!!!";
                    ddlBranchOfficeId.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (ddlFromMonthId.Text == "0")
                {
                    string strMsg = "Please Select From Month!!!";
                    ddlFromMonthId.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (ddlToMonthId.Text == "0")
                {
                    string strMsg = "Please Select To Month!!!";
                    ddlToMonthId.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else
                {
                    saveArrearLockSetup();
                    loadArrearLockSetup();
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

        public void getYearForIncrementProposal()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getYearForIncrementYear(strHeadOfficeId, strBranchOfficeId);

            txtArrearYear.Text = objLookUpDTO.Year;



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


        public void loadArrearLockSetup()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadArrearLockSetup( txtArrearYear.Text,  strHeadOfficeId, strBranchOfficeId);

            gvUnit.Columns[1].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                gvUnit.Columns[1].Visible = false;
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
             
                lblMsg.Text = strMsg;
                
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                gvUnit.Columns[1].Visible = false;
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

        public void clear()
        {
            txtArrearYear.Text = string.Empty;
            ddlBranchOfficeId.SelectedIndex = 0;
            ddlFromMonthId.SelectedIndex = 0;
            ddlToMonthId.SelectedIndex = 0;
            chkActiveYn.Checked = false;
            hf_lock_id.Value = string.Empty;
        }
        public void saveArrearLockSetup( )
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            if (string.IsNullOrEmpty(hf_lock_id.Value))
                objLookUpDTO.lock_id = 0;
            else
                objLookUpDTO.lock_id = Convert.ToInt32(hf_lock_id.Value);


            objLookUpDTO.Year = txtArrearYear.Text;
            
            
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
            if (ddlFromMonthId.SelectedValue !="0")
            {
                objLookUpDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.FromMonthId = "0";
            }
            if (ddlToMonthId.SelectedValue.ToString() != "0")
            {
                objLookUpDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.ToMonthId = "0";
            }

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            
            string strMsg = objLookUpBLL.saveArrearLockSetup(objLookUpDTO);

            if(strMsg == "INSERTED SUCCESSFULLY")
            {
                clear();
            }

            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }
       

        #endregion

        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;

            string strBranchOfficeId = gvUnit.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strArrearYear = gvUnit.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

            

            string strLockYn = gvUnit.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            txtArrearYear.Text = strArrearYear;

            hf_lock_id.Value = gvUnit.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            string fromMonthId = gvUnit.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            string toMonthId = gvUnit.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");

            ddlFromMonthId.SelectedValue = fromMonthId;
            ddlToMonthId.SelectedValue = toMonthId;

            if (strBranchOfficeId != "")
            {
                ddlBranchOfficeId.SelectedValue = strBranchOfficeId;
                ddlBranchOfficeId.DataBind();
            }
            if (strLockYn == "LOCK")
            {
                chkActiveYn.Checked = true;
            }
            else
            {
                chkActiveYn.Checked = false;
            }



        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
           
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

        protected void chkActiveYn_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        


    

        #endregion

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadArrearLockSetup();
        }
    }
}