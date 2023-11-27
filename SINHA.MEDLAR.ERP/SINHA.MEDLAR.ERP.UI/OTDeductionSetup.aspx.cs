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
    public partial class OTDeductionSetup : System.Web.UI.Page
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
                GetPurpose();
                GetOTDeductionSetup();
                getOfficeName();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
            dtpLogDate.Attributes.Add("onkeypress", "return controlEnter('" + txtOTDeductionStartTime.ClientID + "', event)");
            txtOTDeductionStartTime.Attributes.Add("onkeypress", "return controlEnter('" + txtOTDeductionEndTime.ClientID + "', event)");
            txtOTDeductionEndTime.Attributes.Add("onkeypress", "return controlEnter('" + ddlPurpose.ClientID + "', event)");
            ddlPurpose.Attributes.Add("onkeypress", "return controlEnter('" + BtnSave.ClientID + "', event)");
        }
        #region "Function"
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
        
        public void GetPurpose()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPurpose.DataSource = objLookUpBLL.GetPurpose();

            ddlPurpose.DataTextField = "PURPOSE_NAME";
            ddlPurpose.DataValueField = "PURPOSE_ID";
            ddlPurpose.DataBind();
            if (ddlPurpose.Items.Count > 0)
            {
                ddlPurpose.SelectedIndex = 0;
            }
        }
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        public void GetOTDeductionSetup()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.GetOTDeductionSetup(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                GvOTDeductionSetup.DataSource = dt;
                GvOTDeductionSetup.DataBind();
                string strMsg = "TOTAL " + GvOTDeductionSetup.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
               // dt.Rows.Add(dt.NewRow());
                GvOTDeductionSetup.DataSource = dt;
                GvOTDeductionSetup.DataBind();
                //int totalcolums = GvOTDeductionSetup.Rows[0].Cells.Count;
                //GvOTDeductionSetup.Rows[0].Cells.Clear();
                //GvOTDeductionSetup.Rows[0].Cells.Add(new TableCell());
                //GvOTDeductionSetup.Rows[0].Cells[0].ColumnSpan = totalcolums;
                //GvOTDeductionSetup.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                //string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                //lblMsg.Text = strMsg;

            }
        }
        public void clearTextBox()
        {
            txtOTDeductionStartTime.Text = string.Empty;
            txtOTDeductionEndTime.Text = string.Empty;
            dtpLogDate.Text = string.Empty;
            ddlPurpose.SelectedIndex=0;
            txtSetupId.Text = string.Empty;

        }

        public void Reset()
        {
            txtSetupId.Text = string.Empty;
            txtOTDeductionStartTime.Text = string.Empty;
            txtOTDeductionEndTime.Text = string.Empty;
            dtpLogDate.Text = string.Empty;
            ddlPurpose.SelectedIndex = 0;
        }

        #endregion
        #region "Gridview Functionality"
        protected void GvOTDeductionSetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvOTDeductionSetup.PageIndex = e.NewPageIndex;
            GetOTDeductionSetup();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
            //    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

            //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvUnit, "Select$" + e.Row.RowIndex);
            //}
            
        }
        protected void GvOTDeductionSetup_OnSelectedIndexChanged(object sender, EventArgs e)
        {
                int strRowId = GvOTDeductionSetup.SelectedRow.RowIndex;
                string slNo = GvOTDeductionSetup.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
                string DtpLogDate = GvOTDeductionSetup.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
                string OTDeductionStartTime = GvOTDeductionSetup.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                string OTDeductionEndTime = GvOTDeductionSetup.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                string setupId = GvOTDeductionSetup.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                string PurposeId = GvOTDeductionSetup.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
                

                dtpLogDate.Text = DtpLogDate;
                txtOTDeductionStartTime.Text = OTDeductionStartTime;
                txtOTDeductionEndTime.Text = OTDeductionEndTime;
                ddlPurpose.SelectedValue = PurposeId;
                txtSetupId.Text = setupId;
        }
       
        public void SaveOTDeductionSetup()
        {
            OfficeTimeDTO objOfficeTimeDTO = new OfficeTimeDTO();
            OfficeTimeBLL objOfficeTimeBLL = new OfficeTimeBLL();

            string strMsg = "";

            objOfficeTimeDTO.LogDate = dtpLogDate.Text.Trim();
            objOfficeTimeDTO.OTDeductionStartTime = txtOTDeductionStartTime.Text.Trim();
            objOfficeTimeDTO.OTDeductionEndTime = txtOTDeductionEndTime.Text.Trim();
            objOfficeTimeDTO.PurposeId = ddlPurpose.SelectedValue.Trim();
            objOfficeTimeDTO.SetupId = txtSetupId.Text.Trim();
            objOfficeTimeDTO.CreateBy = strEmployeeId;
            objOfficeTimeDTO.HeadOfficeId = strHeadOfficeId;
            objOfficeTimeDTO.BranchOfficeId = strBranchOfficeId;

            strMsg = objOfficeTimeBLL.SaveOTDeductionSetup(objOfficeTimeDTO);
            MessageBox(strMsg);  
        }
      
        #endregion
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Reset();
            }
            catch (Exception ex)
            {
                //throw new Exception("Error : " +ex.Message);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPurpose.SelectedValue == "")
                {
                    string strMsg = "Please Select Shift";
                    MessageBox(strMsg);
                    ddlPurpose.Focus();
                    return;
                }
                if (txtOTDeductionStartTime.Text.Trim() == string.Empty)
                    {
                        string strMsg = "Please Insert OT Deduction Start Time";
                        MessageBox(strMsg);
                        txtOTDeductionStartTime.Focus();
                        return;
                    }
                    if (txtOTDeductionEndTime.Text.Trim() == string.Empty)
                    {
                        string strMsg = "Please Insert OT Deduction End Time";
                        MessageBox(strMsg);
                        txtOTDeductionEndTime.Focus();
                        return;
                    }
                    if (dtpLogDate.Text.Trim() == string.Empty)
                    {
                        string strMsg = "Please Insert Log Date";
                        MessageBox(strMsg);
                        dtpLogDate.Focus();
                        return;
                    }

                   SaveOTDeductionSetup();
                   Reset();
                  GetOTDeductionSetup();  
                }            
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
       
    }
}