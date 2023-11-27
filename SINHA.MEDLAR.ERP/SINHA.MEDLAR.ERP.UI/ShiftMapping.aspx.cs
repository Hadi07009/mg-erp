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
    public partial class ShiftMapping : System.Web.UI.Page
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
                GetShiftMapping();
                GetShift();
                GetUnitSection();

                getOfficeName();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
            ddlShift.Attributes.Add("onkeypress", "return controlEnter('" + dtpEffectDate.ClientID + "', event)");
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

            //dutyTypeId
            LookUpBLL objLookUpBLL = new LookUpBLL();
            //ddlShift.DataSource = objLookUpBLL.GetGeneralShift();
            ddlShift.DataSource = objLookUpBLL.GetShiftByDutyType("1", strBranchOfficeId);

            ddlShift.DataTextField = "SHIFT_NAME";
            ddlShift.DataValueField = "SHIFT_ID";

            ddlShift.DataBind();
            if (ddlShift.Items.Count > 0)
            {
                ddlShift.SelectedIndex = 0;
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
        public void GetShiftMapping()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.GetShiftMapping(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvShiftMapping.DataSource = dt;
                gvShiftMapping.DataBind();
                string strMsg = "TOTAL " + gvShiftMapping.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
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

                //string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                //lblMsg.Text = strMsg;

            }
        }
        public void GetUnitSection()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.GetUnitSection(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                string strMsg = "TOTAL " + GridView1.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int totalcolums = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridView1.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }
        }

        public void Reset()
        {
            txtMappingId.Text = string.Empty;
            ddlShift.SelectedIndex = 0;
            dtpEffectDate.Text = string.Empty;
        }

        #endregion
        #region "Gridview Functionality"
        protected void gvShiftMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShiftMapping.PageIndex = e.NewPageIndex;
            GetShiftMapping();
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
                string effectDate = gvShiftMapping.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                string unitId = gvShiftMapping.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                string sectionId = gvShiftMapping.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
                string shiftId = gvShiftMapping.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
             
                string mappingId = gvShiftMapping.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
                ddlShift.SelectedValue = shiftId;
                txtUnitId.Text = unitId;
                txtSectionId.Text = sectionId;

                dtpEffectDate.Text = effectDate;
                txtMappingId.Text = mappingId;                

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetUnitSection();
        }


        
        public void SaveShiftMapping()
        {
            OfficeTimeDTO objOfficeTimeDTO = new OfficeTimeDTO();
            OfficeTimeBLL objOfficeTimeBLL = new OfficeTimeBLL();
            string strMsg = "";

            if (txtMappingId.Text!="")
            {

                objOfficeTimeDTO.MappingId = txtMappingId.Text;
                objOfficeTimeDTO.UnitId = txtUnitId.Text;
                objOfficeTimeDTO.SectionId = txtSectionId.Text;
                objOfficeTimeDTO.ShiftId = ddlShift.SelectedValue;
                objOfficeTimeDTO.EffectDate = dtpEffectDate.Text;
                objOfficeTimeDTO.CreateBy = strEmployeeId;
                objOfficeTimeDTO.HeadOfficeId = strHeadOfficeId;
                objOfficeTimeDTO.BranchOfficeId = strBranchOfficeId;

                strMsg = objOfficeTimeBLL.SaveShiftMapping(objOfficeTimeDTO);
                MessageBox(strMsg);
            }

            else
            {

                int recordCounter = 0;
                try
                {
                    string status = string.Empty;

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkUnitSection = (CheckBox)row.FindControl("chkList");
                            if (chkUnitSection.Checked)
                            {
                                recordCounter = recordCounter + 1;
                                TextBox txtUnitId = (TextBox)row.FindControl("txtUnitId");
                                TextBox txtSectionId = (TextBox)row.FindControl("txtSectionId");

                                objOfficeTimeDTO.MappingId = txtMappingId.Text;
                                objOfficeTimeDTO.UnitId = txtUnitId.Text;
                                objOfficeTimeDTO.SectionId = txtSectionId.Text;
                                objOfficeTimeDTO.ShiftId = ddlShift.SelectedValue;
                                objOfficeTimeDTO.EffectDate = dtpEffectDate.Text;
                                objOfficeTimeDTO.CreateBy = strEmployeeId;
                                objOfficeTimeDTO.HeadOfficeId = strHeadOfficeId;
                                objOfficeTimeDTO.BranchOfficeId = strBranchOfficeId;

                                strMsg = objOfficeTimeBLL.SaveShiftMapping(objOfficeTimeDTO);
                            }
                            chkUnitSection.Checked = false;
                        }
                    }

                    MessageBox(strMsg);

                }

                catch (Exception ex)
                {
                }
            }
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
                   SaveShiftMapping();
                   Reset();
                   GetShiftMapping();  
                }            
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
        }
    }
}