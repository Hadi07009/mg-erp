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
    public partial class ShiftTimeMapping : System.Web.UI.Page
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
                //GetShiftTimeMapping();
                GetShift();
                GetEmptyTime();
                //GetTime();
                getOfficeName();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
            ddlShift.Attributes.Add("onkeypress", "return controlEnter('" + ddlTimeId.ClientID + "', event)");
            ddlTimeId.Attributes.Add("onkeypress", "return controlEnter('" + dtpEffectDate.ClientID + "', event)");
            dtpEffectDate.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");
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
        public void GetShift()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlShift.DataSource = objLookUpBLL.GetShift(strBranchOfficeId);

            ddlShift.DataTextField = "SHIFT_NAME";
            ddlShift.DataValueField = "SHIFT_ID";
            ddlShift.DataBind();
            if (ddlShift.Items.Count > 0)
            {
                ddlShift.SelectedIndex = 0;
            }
        }
        public void GetTime()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();

            ddlTimeId.DataSource = objLookUpBLL.GetTime(ddlShift.SelectedItem.Value, strHeadOfficeId, strBranchOfficeId);

            ddlTimeId.DataTextField = "TIME_NAME";
            ddlTimeId.DataValueField = "TIME_ID";

            ddlTimeId.DataBind();
            if (ddlTimeId.Items.Count > 0)
            {
                ddlTimeId.SelectedIndex = 0;
            }
        }


        public void GetEmptyTime()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();

            //ddlTimeId.DataSource = objLookUpBLL.GetTime(ddlShift.SelectedItem.Value, strHeadOfficeId, strBranchOfficeId);

            ddlTimeId.Items.Insert(0, new ListItem("Please Select One", ""));

            ddlTimeId.DataTextField = "TIME_NAME";
            ddlTimeId.DataValueField = "TIME_ID";

            ddlTimeId.DataBind();
            if (ddlTimeId.Items.Count > 0)
            {
                ddlTimeId.SelectedIndex = 0;
            }
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
        public void GetShiftTimeMapping()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.GetShiftTimeMapping(ddlShift.SelectedItem.Value, strHeadOfficeId, strBranchOfficeId);

            if (dt.Rows.Count > 0)
            {
                gvShiftMapping.DataSource = dt;
                gvShiftMapping.DataBind();
                string strMsg = "TOTAL " + gvShiftMapping.Rows.Count + " RECORD FOUND";
                lblMsg.Text = strMsg;
            }
            else
            {
                //dt.Rows.Add(dt.NewRow());
                gvShiftMapping.DataSource = dt;
                gvShiftMapping.DataBind();
                //int totalcolums = gvShiftMapping.Rows[0].Cells.Count;
                //gvShiftMapping.Rows[0].Cells.Clear();
                //gvShiftMapping.Rows[0].Cells.Add(new TableCell());
                //gvShiftMapping.Rows[0].Cells[0].ColumnSpan = totalcolums;
                //gvShiftMapping.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }
        }
        public void Reset()
        {
            txtMappingId.Text = string.Empty;
            ddlShift.SelectedIndex = 0;
            ddlTimeId.Items.Clear();
            GetEmptyTime();
            //ddlTimeId.DataBind();
            dtpEffectDate.Text = string.Empty;
            gvShiftMapping.DataSource = null;
            gvShiftMapping.DataBind();
            
        }

        #endregion
        #region "Gridview Functionality"
        protected void gvShiftMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShiftMapping.PageIndex = e.NewPageIndex;
            GetShiftTimeMapping();
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
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
                int strRowId = gvShiftMapping.SelectedRow.RowIndex;
                string slNo = gvShiftMapping.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
                string effectDate = gvShiftMapping.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                string shiftId = gvShiftMapping.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                string timeId = gvShiftMapping.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                string mappingId = gvShiftMapping.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

                ddlShift.SelectedValue = shiftId;
                ddlTimeId.SelectedValue = timeId;
                dtpEffectDate.Text = effectDate;
                txtMappingId.Text = mappingId;
            
        }
        public void SaveShiftTimeMapping()
        {
            OfficeTimeDTO objOfficeTimeDTO = new OfficeTimeDTO();
            OfficeTimeBLL objOfficeTimeBLL = new OfficeTimeBLL();

            string strMsg = "";

            objOfficeTimeDTO.MappingId = txtMappingId.Text;
            objOfficeTimeDTO.TimeId = ddlTimeId.SelectedValue;
            objOfficeTimeDTO.ShiftId = ddlShift.SelectedValue;
            objOfficeTimeDTO.EffectDate = dtpEffectDate.Text;
            objOfficeTimeDTO.CreateBy = strEmployeeId;
            objOfficeTimeDTO.HeadOfficeId = strHeadOfficeId;
            objOfficeTimeDTO.BranchOfficeId = strBranchOfficeId;

            strMsg = objOfficeTimeBLL.SaveShiftTimeMapping(objOfficeTimeDTO);
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
                    if (ddlTimeId.SelectedValue.ToString() == string.Empty)
                    {
                        string strMsg = "Please Select Unit";
                        MessageBox(strMsg);
                        ddlTimeId.Focus();
                        return;
                    }
                     if (ddlShift.SelectedValue.ToString() == string.Empty)
                    {
                        string strMsg = "Please Select Shift";
                        MessageBox(strMsg);
                        ddlShift.Focus();
                        return;
                    }
                    if (dtpEffectDate.Text == string.Empty)
                    {
                        string strMsg = "Please Insert Effect Date";
                        MessageBox(strMsg);
                        dtpEffectDate.Focus();
                        return;
                    }
                   SaveShiftTimeMapping();
                   Reset();
                   GetShiftTimeMapping();  
                }            
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {           
        }

        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlShift.SelectedItem.Text == string.Empty)
            {
                ddlShift.SelectedIndex = 0;
                ddlTimeId.SelectedIndex = 0;
                dtpEffectDate.Text = string.Empty;
                gvShiftMapping.DataSource = null;
                gvShiftMapping.DataBind();
            }

            if (ddlShift.SelectedItem.Text != string.Empty)
            {
                GetTime();
                GetShiftTimeMapping();
            }
        }
    }
}