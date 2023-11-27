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
    public partial class EmployeeSkill : System.Web.UI.Page
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

        ReportDocument rd = new ReportDocument();
        ExportFormatType formatType = ExportFormatType.NoFormat;
        string strDefaultName = "Report";
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
                // GetShift();
                GetSkillLevelId();
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

        public void GetSkillLevelId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSkillkLevelId.DataSource = objLookUpBLL.GetSkillLevelId();

            ddlSkillkLevelId.DataTextField = "SKILL_LEVEL_NAME";
            ddlSkillkLevelId.DataValueField = "SKILL_LEVEL_ID";

            ddlSkillkLevelId.DataBind();
            if (ddlSkillkLevelId.Items.Count > 0)
            {
                ddlSkillkLevelId.SelectedIndex = 0;
            }
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

                ddlUnitId.SelectedIndex = 0;
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
                ddlSectionId.SelectedIndex = 0;
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

        public void clearMessage()
        {
            lblMsg.Text = string.Empty;
        }
        #endregion
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetEmployeeSkillBasicInfo();
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
        public void GetEmployeeSkillBasicInfo()
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
            if (objEmployeeDTO.EffectiveDate!= "")
            {
                objEmployeeDTO.EffectiveDate = dtpFromDate.Text;
            }
            else
            {
                objEmployeeDTO.EffectiveDate = "";
            }
            objEmployeeDTO.EmployeeId = txtEmpId.Text; ;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            var basicInfo = objEmployeeBLL.GetEmployeeSkillBasicInfo(objEmployeeDTO);

            int counter = 0;
            foreach(var item in basicInfo)
            {
                counter = counter + 1;
                item.SLNo = counter.ToString();
            }

            if (basicInfo.Count > 0)
            {
                gvEmployeeSkill.DataSource = basicInfo;
                gvEmployeeSkill.DataBind();

                int count = basicInfo.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvEmployeeSkill.DataSource = basicInfo;
                gvEmployeeSkill.DataBind();
                string strMsg = "NO RECORD FOUND!!!";
                lblMsgRecord.Text = strMsg;
            }    
        }

        #region "Grid View Functionality"
        protected void gvEmployeeSkill_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeSkill.PageIndex = e.NewPageIndex;
        }        
        protected void gvEmployeeSkill_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvEmployeeSkill_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["SKILL_ID"].ToString());
            string SkillId = Convert.ToString(id);

            DeleteEmployeeSkillRecord(SkillId);
            GetEmployeeSkill();
            GetEmployeeSkillBasicInfo();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }
        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Visible = false;

            hf_skill_id.Value = string.Empty;
            int strRowId = GridView1.SelectedRow.RowIndex;
            string effectDate = GridView1.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string SkillId = GridView1.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string Skilllevelid = GridView1.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            hf_skill_id.Value = SkillId;
            dtpEffectDate.Text = effectDate;
            ddlSkillkLevelId.SelectedValue = Skilllevelid;
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

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        #endregion
        public void DeleteEmployeeSkillRecord(string skillId)
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.SkillId = Convert.ToDecimal(skillId);

            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.DeleteEmployeeSkillRecord(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }
        public string EmployeeSkillSave()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";

            int recordCounter = 0;


            try
            {                
                string status = string.Empty;

                foreach (GridViewRow row in gvEmployeeSkill.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                        if (chkEmployee.Checked)
                        {
                            recordCounter = recordCounter + 1;

                            TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
                            
                            if (hf_skill_id.Value == string.Empty)
                                objEmployeeDTO.SkillId = 0;
                            else
                                objEmployeeDTO.SkillId = Convert.ToDecimal(hf_skill_id.Value);

                            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;

                            if (string.IsNullOrEmpty(ddlSkillkLevelId.SelectedItem.Value))
                                objEmployeeDTO.SkillLevelId = string.Empty;
                            else
                                objEmployeeDTO.SkillLevelId = ddlSkillkLevelId.SelectedItem.Value;

                            if (string.IsNullOrEmpty(dtpEffectDate.Text))
                                objEmployeeDTO.EffectiveDate = string.Empty;
                            else
                                objEmployeeDTO.EffectiveDate = dtpEffectDate.Text;
                            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                            objEmployeeDTO.CreateBy = strEmployeeId;

                             strMsg = objEmployeeBLL.EmployeeSkillSave(objEmployeeDTO);
                          
                        }
                    }
                }
              
                ClearAfterSave();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strMsg;
        }

        protected void gvEmployeeSkill_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void gvEmployeeSkill_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void gvEmployeeSkill_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Visible = true;

            int strRowId = gvEmployeeSkill.SelectedRow.RowIndex;

            txtCardNo.Text = gvEmployeeSkill.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            txtEmployeeName.Text = gvEmployeeSkill.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            txtDesignationName.Text = gvEmployeeSkill.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            txtEmployeeId.Text = gvEmployeeSkill.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            dtpEffectDate.Text= gvEmployeeSkill.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            string SkillkLevelId = gvEmployeeSkill.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            if (SkillkLevelId != "")
                ddlSkillkLevelId.SelectedValue = SkillkLevelId;
            else
                ddlSkillkLevelId.SelectedValue = "0";

            GetEmployeeSkill();
            hf_skill_id.Value = string.Empty;

        }
        protected void gvEmployeeSkill_OnRowDataBound(object sender, EventArgs e)
        {
        }

        protected void gvEmployeeSkill_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void ddlShifyTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            if (ddlSkillkLevelId.SelectedItem.Value == "0")
            {
                string strMsg = "Please Select Skill Level";
                ddlSkillkLevelId.Focus();
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

           string messgae = EmployeeSkillSave();
           lblMsg.Text = messgae;
           MessageBox(messgae);
           GetEmployeeSkillBasicInfo();
           GetEmployeeSkill();
        }

        protected void ddlRosterId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void GetEmployeeSkill()
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

            dt = objEmployeeBLL.GetEmployeeSkill(objEmployeeDTO);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
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
        public void DailyAttendenceSheetForEmployeeSkill()
            {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.EmployeeId = txtEmpId.Text;
            objReportDTO.UpdateBy = strEmployeeId;
            objReportDTO.FromDate = dtpFromDate.Text;

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.SectionId = "";
            }
            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.UnitId = "";
            }
            //vw_dm_skill_employee_sheet
            string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAttendenceSheetForEmpSkill.rpt"));
            this.Context.Session["strReportPath"] = strPath;
            rd.Load(strPath);
            rd.SetDataSource(objReportBLL.DailyAttendenceSheetForEmployeeSkill(objReportDTO));


            rd.SetDatabaseLogon("erp", "erp");
            CrystalReportViewer1.ReportSource = rd;
            CrystalReportViewer1.DataBind();

            reportMaster();

            this.CrystalReportViewer1.Dispose();
            this.CrystalReportViewer1 = null;
            rd.Dispose();
            rd.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            }
        private void ClearAfterSave()
        {
            ddlSkillkLevelId.SelectedValue ="0";
            dtpEffectDate.Text = string.Empty;
           
        }

        private void ClearAfterBasicSelection()
        {
            ClearAfterSave();
            txtCardNo.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtDesignationName.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;

            btnSave.Visible = true;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAfterBasicSelection();
                hf_skill_id.Value = string.Empty;
            }
            catch(Exception exp)
            {
                throw exp;
            }
        }

        

       

        public void reportMaster()
        {

            if (chkPDF.Checked == true)
            {

                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                ReportDocument crReportDocument = new ReportDocument();
                Response.Clear();
                Response.Buffer = true;

                formatType = ExportFormatType.PortableDocFormat;
                System.IO.Stream oStream = null;
                byte[] byteArray = null;

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                oStream = rd.ExportToStream(formatType);
                byteArray = new byte[oStream.Length];
                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(byteArray);
                Response.Flush();
                Response.Close();
                rd.Close();
                rd.Dispose();
            }
            if (chkExcel.Checked == true)
            {

                //CrystalReportViewer1.ReportSource = rd;
                //CrystalReportViewer1.DataBind();

                //formatType = ExportFormatType.Excel;
                //MemoryStream oStream;
                //Response.Clear();
                //Response.Buffer = false;
                //Response.ClearContent();
                //Response.ClearHeaders();

                //oStream = (MemoryStream)rd.ExportToStream(formatType);
                //Response.ContentType = "application/vnd.ms-excel";
                //oStream.Seek(0, SeekOrigin.Begin);
                //Response.BinaryWrite(oStream.ToArray());
                ////Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();

                rd.ExportToHttpResponse
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "tax_sheet");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }
        }
        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {
                chkPDF.AutoPostBack = true;
                chkExcel.Checked = false;

            }
        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkExcel.AutoPostBack = true;
                chkPDF.Checked = false;


            }
        }
        protected void btnSheet_Click(object sender, EventArgs e)
        {
            if (dtpFromDate.Text == string.Empty)
            {
                string strMsg = "Please Enter Date";
                dtpEffectDate.Focus();
                MessageBox(strMsg);
                return;
            }
            if (ddlUnitId.SelectedValue == " ")
            {
                string strMsg = "Please Select Unit";
                ddlUnitId.Focus();
                MessageBox(strMsg);
                return;
            }
            if (ddlSectionId.SelectedValue == " ")
            {
                string strMsg = "Please Select Section";
                ddlSectionId.Focus();
                MessageBox(strMsg);
                return;
            }

            DailyAttendenceSheetForEmployeeSkill();
        }
        #region "Crystal Report Functionality"

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            this.CrystalReportViewer1.Dispose();
            this.CrystalReportViewer1 = null;
            rd.Dispose();
            rd.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {

            this.CrystalReportViewer1.ReportSource = null;

            CrystalReportViewer1.Dispose();

            if (rd != null)
            {

                rd.Close();
                rd.Dispose();
                rd = null;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        #endregion

    }
}