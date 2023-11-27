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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class EmployeeSpecialShiftMapping : System.Web.UI.Page
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
                GetSpecialShift();               
                getUnitId();
                getSectionId();
                clearMsg();
                getOfficeName();
                btnSearch.Focus();

            }
            if (IsPostBack)
            {
                loadSesscion();
            }

            //gvOfficeShiftTime.Columns[5].Visible = false;
        }

        #region "Function"

        public void getDate()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getDate();
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



        public void clearMsg()
        {
            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
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

        public void getShiftTypeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSpecialShift.DataSource = objLookUpBLL.getShiftTypeId(strHeadOfficeId, strBranchOfficeId);

            ddlSpecialShift.DataTextField = "SHIFT_TYPE_NAME";
            ddlSpecialShift.DataValueField = "SHIFT_TYPE_ID";

            ddlSpecialShift.DataBind();
            if (ddlSpecialShift.Items.Count > 0)
            {
                ddlSpecialShift.SelectedIndex = 0;
            }
        }

        public void GetSpecialShift()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSpecialShift.DataSource = objLookUpBLL.GetSpecialShift();

            ddlSpecialShift.DataTextField = "SHIFT_NAME";
            ddlSpecialShift.DataValueField = "SHIFT_ID";

            ddlSpecialShift.DataBind();
            ddlSpecialShift.Items.Insert(0, new ListItem("Please Select One", ""));
        }
        public void getUnitId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlUnitId.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlUnitId.DataTextField = "UNIT_NAME";
            ddlUnitId.DataValueField = "UNIT_ID";

            ddlUnitId.DataBind();
            if (ddlUnitId.Items.Count > 0)
            {
                ddlUnitId.SelectedValue = "37";
            }
        }

        public void getSectionId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSectionId.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

            ddlSectionId.DataTextField = "SECTION_NAME";
            ddlSectionId.DataValueField = "SECTION_ID";

            ddlSectionId.DataBind();
            if (ddlSectionId.Items.Count > 0)
            {
                ddlSectionId.SelectedValue = "14";
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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void GetSpecialEmployeeShiftMapping()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                        
            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";
            }
            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";
            }
            objEmployeeDTO.EffectiveDate = txtEffdate.Text;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;

            dt = objEmployeeBLL.GetSpecialEmployeeShiftMapping(objEmployeeDTO);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

                // getFirstIndex();
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
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
        }

        public void clearMessage()
        {
            lblMsg.Text = string.Empty;
        }
        #endregion

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                //loadOfficeShiftTime();
                GetSpecialEmployeeShiftMapping();
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                searchEmployeeInfo();
                GetSpecialEmployeeShiftMapping();
                //GetEmployeeShiftMapping();
                //loadOfficeShiftTime();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        public void searchEmployeeInfo()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";
            }

            objEmployeeDTO.ShiftId = string.Empty;

            //objEmployeeDTO.EffectiveDate = txtEffdate.Text;
            objEmployeeDTO.EmployeeId = txtEmpId.Text; ;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            dt = objEmployeeBLL.GetEmployeeBasicInfo(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                gvOfficeShiftTime.DataSource = dt;
                gvOfficeShiftTime.DataBind();

                int count = ((DataTable)gvOfficeShiftTime.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                //gvEmployeeList.Columns[2].Visible = false;
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvOfficeShiftTime.DataSource = dt;
                gvOfficeShiftTime.DataBind();
                int totalcolums = gvOfficeShiftTime.Rows[0].Cells.Count;
                gvOfficeShiftTime.Rows[0].Cells.Clear();
                gvOfficeShiftTime.Rows[0].Cells.Add(new TableCell());
                gvOfficeShiftTime.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvOfficeShiftTime.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                //gvEmployeeList.Columns[2].Visible = false;
                lblMsgRecord.Text = strMsg;
            }
        }
                
        #region "Grid View Functionality"
        protected void gvOfficeShiftTime_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOfficeShiftTime.PageIndex = e.NewPageIndex;
        }
        #endregion


        protected void gvOfficeShiftTime_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvOfficeShiftTime_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        public void deleteOfficeShiftTimeRecord(string strEmpId)
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.EmpId = strEmpId;

            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.deleteOfficeShiftTimeRecord(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }

        public void saveOfficeShiftTime()
        {
            string status = string.Empty;

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";

            try
            {
                if (!string.IsNullOrEmpty(ddlSpecialShift.SelectedItem.Value))
                {
                    objEmployeeDTO.ShiftTypeId = ddlSpecialShift.SelectedItem.Value;
                }
                else
                    objEmployeeDTO.ShiftTypeId = "";
                    
                strMsg = objEmployeeBLL.SaveEmployeeShiftMapping(objEmployeeDTO, out status);
                lblMsg.Text = strMsg;
                MessageBox(strMsg);
            }
            catch(Exception ex)
            {

            }
        }
        public string SaveSpecialEmployeeShiftMapping()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";

            try
            {

                if (hf_mapping_id.Value == string.Empty)
                    objEmployeeDTO.MappingId = 0;
                else
                    objEmployeeDTO.MappingId = Convert.ToDecimal(hf_mapping_id.Value);

                objEmployeeDTO.EmployeeId = txtEmployeeId.Text;

                if (string.IsNullOrEmpty(ddlSpecialShift.SelectedItem.Value))
                    objEmployeeDTO.ShiftId = string.Empty;
                else
                    objEmployeeDTO.ShiftId = ddlSpecialShift.SelectedItem.Value;

                if (string.IsNullOrEmpty(dtpEffectDate.Text))
                    objEmployeeDTO.EffectiveDate = string.Empty;
                else
                    objEmployeeDTO.EffectiveDate = dtpEffectDate.Text;

                objEmployeeDTO.ActiveYn = chkActiveYn.Checked == true ? "Y" : "N";

                objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                objEmployeeDTO.CreateBy = strEmployeeId;

                strMsg = objEmployeeBLL.SaveSpecialEmployeeShiftMapping(objEmployeeDTO);
                                
                if (hf_mapping_id.Value == string.Empty)
                {
                    ClearAfterSave();
                }
               
            }
            catch (Exception ex)
            {
            }
            return strMsg;
        }

        //
        protected void gvOfficeShiftTime_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void gvOfficeShiftTime_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void gvOfficeShiftTime_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvOfficeShiftTime.SelectedRow.RowIndex;

            txtCardNo.Text = gvOfficeShiftTime.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            txtEmployeeName.Text = gvOfficeShiftTime.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            txtDesignationName.Text = gvOfficeShiftTime.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            txtEmployeeId.Text = gvOfficeShiftTime.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

            //GetSpecialEmployeeShiftMapping();
            ClearAfterSave();
            hf_mapping_id.Value = string.Empty;

        }
        protected void gvOfficeShiftTime_OnRowDataBound(object sender, EventArgs e)
        {
        }

        protected void gvOfficeShiftTime_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int stor_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"].ToString());
            string strEmpId = Convert.ToString(stor_id);

            deleteOfficeShiftTimeRecord(strEmpId);
            GetSpecialEmployeeShiftMapping();
            //loadOfficeShiftTime();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            hf_mapping_id.Value = string.Empty;
            int strRowId = GridView1.SelectedRow.RowIndex;

            //< asp:BoundField DataField = "SL" HeaderText = "SL" />
   
            //                                               < asp:BoundField DataField = "MAPPING_ID" HeaderText = "MAPPING" HeaderStyle - CssClass = "hideGridColumn" ItemStyle - CssClass = "hideGridColumn" />
            
            //                                                        < asp:BoundField DataField = "SHIFT_ID" HeaderText = "SHIFT" HeaderStyle - CssClass = "hideGridColumn" ItemStyle - CssClass = "hideGridColumn" />
                     
            //                                                                 < asp:BoundField DataField = "CARD_NO" HeaderText = "CARD NO" />
                        
            //                                                                    < asp:BoundField DataField = "EMPLOYEE_NAME" HeaderText = "NAME" />
                           
            //                                                                       < asp:BoundField DataField = "DESIGNATION_NAME" HeaderText = "DESIGNATION" />
                              
            //                                                                          < asp:BoundField DataField = "SHIFT_NAME" HeaderText = "SHIFT" />
                                 
            //                                                                             < asp:BoundField DataField = "EFFECT_DATE" HeaderText = "EFFECT DATE" />
                                    
            //                                                                                < asp:BoundField DataField = "ACTIVE_YN" HeaderText = "ACTIVE" />
                                       
            //                                                                                   < asp:BoundField DataField = "EMPLOYEE_ID" HeaderText = "ID" />
            
            string mappingId = GridView1.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            
            string shiftId = GridView1.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string cardNo = GridView1.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

            string employeeName = GridView1.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string designationName = GridView1.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");

            string shiftName = GridView1.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

            string effectDate = GridView1.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            string activeYn = GridView1.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

            string employeeId = GridView1.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            
            hf_mapping_id.Value = mappingId;

            dtpEffectDate.Text = effectDate;
            if (activeYn == "Yes")
                chkActiveYn.Checked = true;
            else
                chkActiveYn.Checked = false;

            txtEmployeeId.Text = employeeId;
            ddlSpecialShift.SelectedValue = shiftId;
            txtCardNo.Text = cardNo;
            txtEmployeeName.Text = employeeName;
            txtDesignationName.Text = designationName;
        }

        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void GridView1_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }

        protected void ddlShifyTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlSpecialShift.SelectedItem.Value == string.Empty)
            {
                string strMsg = "Please Select Shift";
                ddlSpecialShift.Focus();
                MessageBox(strMsg);
                return;
            }
            if (dtpEffectDate.Text == string.Empty)
            {
                string strMsg = "Please Enter Effect Date";
                dtpEffectDate.Focus();
                MessageBox(strMsg);
                return;
            }

           string messgae = SaveSpecialEmployeeShiftMapping();
           lblMsg.Text = messgae;
           MessageBox(messgae);

           GetSpecialEmployeeShiftMapping();
        }

        protected void ddlRosterId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearAfterSave()
        {
            ddlSpecialShift.SelectedValue = string.Empty;
            dtpEffectDate.Text = string.Empty;
            chkActiveYn.Checked = false;
        }

        private void ClearAfterBasicSelection()
        {
            ClearAfterSave();
            txtCardNo.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtDesignationName.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAfterBasicSelection();
            hf_mapping_id.Value = string.Empty;
        }
    }
}