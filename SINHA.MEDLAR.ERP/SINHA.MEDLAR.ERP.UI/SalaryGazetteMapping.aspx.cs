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
    public partial class SalaryGazetteMapping : System.Web.UI.Page
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
                LoadSalaryGazetteMapping();
                getMonthId();
                GetGazetteYear();
                getOfficeName();
            }

            if (IsPostBack)
            {
                loadSesscion();
            }
            txtSalaryYear.Attributes.Add("onkeypress", "return controlEnter('" + chkActiveYn.ClientID + "', event)");
           // txtSalaryMonth.Attributes.Add("onkeypress", "return controlEnter('" + chkActiveYn.ClientID + "', event)");
            chkActiveYn.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

        }

        public void getMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSalaryMonthId.DataSource = objLookUpBLL.getFromMonthId();
            ddlSalaryMonthId.DataTextField = "MONTH_NAME";
            ddlSalaryMonthId.DataValueField = "MONTH_ID";

            ddlSalaryMonthId.DataBind();
            if (ddlSalaryMonthId.Items.Count > 0)
            {
                ddlSalaryMonthId.SelectedIndex = 0;
            }
        }
        public void GetGazetteYear()
        {
            GazetteBLL objGazetteBLL = new GazetteBLL();
            var dt = objGazetteBLL.GetGazetteYear();
            UIHelper.PopulateDropdown(ddlGazetteYear, "GAZETTE_YEAR", "TRACER_NO", dt, "Please Select", "", "");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Arrear Year!!!";
                    txtSalaryYear.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (ddlGazetteYear.Text == "")
                {
                    string strMsg = "Please Select Office Name!!!";
                    ddlGazetteYear.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (ddlSalaryMonthId.Text == "0")
                {
                    string strMsg = "Please Select From Month!!!";
                    ddlSalaryMonthId.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else
                {
                    SaveSalaryGazetteMapping();
                    LoadSalaryGazetteMapping();
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


        public void LoadSalaryGazetteMapping()
        {
            GazetteDTO objGazetteDTO = new GazetteDTO();
            GazetteBLL objGazetteBLL = new GazetteBLL();
          
            DataTable dt = new DataTable();
            dt = objGazetteBLL.LoadSalaryGazetteMapping();
            if (dt.Rows.Count > 0)
            {
                gvGazetteSalaryMapping.DataSource = dt;
                gvGazetteSalaryMapping.DataBind();
                string strMsg = "TOTAL " + gvGazetteSalaryMapping.Rows.Count + " RECORD FOUND";            
                lblMsg.Text = strMsg;               
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvGazetteSalaryMapping.DataSource = dt;
                gvGazetteSalaryMapping.DataBind();
                int totalcolums = gvGazetteSalaryMapping.Rows[0].Cells.Count;
                gvGazetteSalaryMapping.Rows[0].Cells.Clear();
                gvGazetteSalaryMapping.Rows[0].Cells.Add(new TableCell());
                gvGazetteSalaryMapping.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvGazetteSalaryMapping.Rows[0].Cells[0].Text = "NO RECORD FOUND";
                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
        }

        public void clear()
        {
            txtSalaryYear.Text = string.Empty;
            ddlGazetteYear.SelectedIndex = 0;
            ddlSalaryMonthId.SelectedIndex = 0;
            chkActiveYn.Checked = false;
            hf_lock_id.Value = string.Empty;
        }
        public void SaveSalaryGazetteMapping( )
        {

            GazetteDTO objGazetteDTO = new GazetteDTO();
            GazetteBLL objGazetteBLL = new GazetteBLL();

            objGazetteDTO.Id = hf_lock_id.Value;
            objGazetteDTO.Year = txtSalaryYear.Text;
            if (ddlSalaryMonthId.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.Month = ddlSalaryMonthId.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.Month = "";
            }
            if (ddlGazetteYear.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.GazetteYear = ddlGazetteYear.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.GazetteYear = "";
            }

            if (chkActiveYn.Checked == true)
            {
                objGazetteDTO.ActiveYn = "Y";
            }
            else
            {
                objGazetteDTO.ActiveYn = "N";
            }
            objGazetteDTO.UpdateBy = strEmployeeId;
            objGazetteDTO.HeadOfficeId = strHeadOfficeId;
            
            string strMsg = objGazetteBLL.SaveSalaryGazetteMapping(objGazetteDTO);

            if(strMsg == "INSERTED SUCCESSFULLY")
            {
                clear();
            }

            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }
     

        #endregion

        #region "GridView Functionlity"

        protected void gvGazetteSalaryMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGazetteSalaryMapping.PageIndex = e.NewPageIndex;    
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            hf_lock_id.Value = string.Empty;
            int strRowId = gvGazetteSalaryMapping.SelectedRow.RowIndex;
            hf_lock_id.Value = gvGazetteSalaryMapping.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string SalaryYear = gvGazetteSalaryMapping.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string MonthName = gvGazetteSalaryMapping.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string MonthId = gvGazetteSalaryMapping.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string GazetteYear = gvGazetteSalaryMapping.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string ActiveYn = gvGazetteSalaryMapping.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            txtSalaryYear.Text = SalaryYear;                      
            ddlSalaryMonthId.SelectedValue = MonthId;
            ddlGazetteYear.SelectedValue = GazetteYear;            
            if (ActiveYn == "Y")
            {
                chkActiveYn.Checked = true;
            }
            else
            {
                chkActiveYn.Checked = false;
            }
        }
        protected void gvGazetteSalaryMapping_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void gvGazetteSalaryMapping_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvGazetteSalaryMapping.EditIndex = e.NewEditIndex;
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvGazetteSalaryMapping, "Select$" + e.Row.RowIndex);
            }
        }
        protected void chkActiveYn_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        #endregion

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadSalaryGazetteMapping();
        }
    }
}