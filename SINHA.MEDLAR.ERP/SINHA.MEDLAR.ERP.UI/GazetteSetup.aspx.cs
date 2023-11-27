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
    public partial class GazetteSetup : System.Web.UI.Page
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
                getMonthId();
                LoadGazetteSetup();
                getOfficeName();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtGazetteYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Salary Year!!!";
                    txtGazetteYear.Focus();
                    MessageBox(strMsg);
                    return;


                }
                else if (ddlGazetteMonth.Text == " ")
                {
                    string strMsg = "Please Select Office Name!!!";
                    ddlGazetteMonth.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else
                {
                    SaveGazetteSetup();
                    LoadGazetteSetup();                  
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
        public void getMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlGazetteMonth.DataSource = objLookUpBLL.getMonthId();

            ddlGazetteMonth.DataTextField = "MONTH_NAME";
            ddlGazetteMonth.DataValueField = "MONTH_ID";

            ddlGazetteMonth.DataBind();
            if (ddlGazetteMonth.Items.Count > 0)
            {

                ddlGazetteMonth.SelectedIndex = 0;
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


        public void LoadGazetteSetup()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            GazetteBLL objGazetteBLL = new GazetteBLL();

            DataTable dt = new DataTable();
            dt = objGazetteBLL.LoadGazetteSetup(txtGazetteYear.Text, ddlGazetteMonth.Text, strHeadOfficeId, strBranchOfficeId);

           // gvUnit.Columns[1].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
               // gvUnit.Columns[1].Visible = false;
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";

                lblMsg.Text = strMsg;

            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
               // gvUnit.Columns[1].Visible = false;
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
            txtGazetteYear.Text = string.Empty;
            ddlGazetteMonth.SelectedValue = "0";
            chkFinalizedYn.Checked = false;
            chkAnalysisYn.Checked =false;
            chkAnalysisLock.Checked = false;
            chkFinalizedLock.Checked = false;
        }
        public void SaveGazetteSetup( )
        {


            GazetteDTO objGazetteDTO = new GazetteDTO();
            GazetteBLL objGazetteBLL = new GazetteBLL();

            objGazetteDTO.Year = txtGazetteYear.Text;
            if (ddlGazetteMonth.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.Month = ddlGazetteMonth.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.Month = "";
            }
            if (chkFinalizedYn.Checked == true)
            {
                objGazetteDTO.FinalizedYn = "Y";
            }
            else
            {
                objGazetteDTO.FinalizedYn = "N";
            }
            if (chkFinalizedLock.Checked == true)
            {
                objGazetteDTO.FinalizedLock = "Y";
            }
            else
            {
                objGazetteDTO.FinalizedLock = "N";
            }
            if (chkAnalysisYn.Checked == true)
            {
                objGazetteDTO.AnalysisYn = "Y";
            }
            else
            {
                objGazetteDTO.AnalysisYn = "N";
            }
            if (chkAnalysisLock.Checked == true)
            {
                objGazetteDTO.AnalysisLock = "Y";
            }
            else
            {
                objGazetteDTO.AnalysisLock = "N";
            }
            objGazetteDTO.UpdateBy = strEmployeeId;
            objGazetteDTO.HeadOfficeId = strHeadOfficeId;
            objGazetteDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objGazetteBLL.SaveGazetteSetup(objGazetteDTO);
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

            string GazetteYear = gvUnit.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string GazetteMonthId = gvUnit.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string Analysis = gvUnit.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string AnalysisLock = gvUnit.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string FinalizedYn = gvUnit.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");  
            string FinalizedLock = gvUnit.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");

            txtGazetteYear.Text = GazetteYear;
            if (GazetteMonthId != "")
            {
                ddlGazetteMonth.SelectedValue = GazetteMonthId;
                ddlGazetteMonth.DataBind();
            }
            if (Analysis == "ACTIVE")
            {
                chkAnalysisYn.Checked = true;
            }
            else
            {
                chkAnalysisYn.Checked = false;
            }
            if (AnalysisLock == "LOCK")
            {
                chkAnalysisLock.Checked = true;
            }
            else
            {
                chkAnalysisLock.Checked = false;
            }
            if (FinalizedYn == "ACTIVE")
            {
                chkFinalizedYn.Checked = true;
            }
            else
            {
                chkFinalizedYn.Checked = false;
            }
            if (FinalizedLock == "LOCK")
            {
                chkFinalizedLock.Checked = true;
            }
            else
            {
                chkFinalizedLock.Checked = false;
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
        protected void chkLockYn_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadGazetteSetup();
        }
    }
}