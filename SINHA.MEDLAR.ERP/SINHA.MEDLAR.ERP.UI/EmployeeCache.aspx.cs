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
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;
using System.Web.UI.HtmlControls;
using CrystalDecisions.Web;
using SINHA.MEDLAR.ERP.COMMON.Utility.Image;
using System.Web.Services;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class EmployeeCache : System.Web.UI.Page
    {
        string strEmployeeId = "";
        string strSectionId = "";
        string strDepartmentId = "";
        string strDesignationId = "";
        string strUnitId = "";
        string strCatagoryId;
        private static string strHeadOfficeId = "";
        private static string strBranchOfficeId = "";
        string strEmployeeTypeId = "";
        string strLoginDay = "";
        string strLoginMonth = "";
        string strLoginDate = "";
        string strID = "";
        ReportDocument rd = new ReportDocument();
        string strDefaultName = "Report";
        ExportFormatType formatType = ExportFormatType.NoFormat;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");

            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;
            }

            if (!IsPostBack)
            {
                
                loadSesscion();
                getGenderId();
                //getMaritalStatusId();
                //getReligionId();
                //getBloodGroupId();
                getUnitIdForEmployee();
                getSectionIdForEmployee();
                getUnitId();
                getSectionId();
                getEmployeeTypeId();
                getJoiningDesignationId();
                //getNationalityId();
                geTitleId();
                //getDivisionId();
                //getDistrictId();
                //GetGrade();
                getReligionId();
                getOfficeName();
        
                //getDepartmentId();
                lblMsg.Text = string.Empty;
                //GetSittingBranchOfficeId();
                //getId();
                
            }
            if (IsPostBack)
            {
                loadSesscion();
                Session["strID"] = null;
            }
        }
        #region "Load Drop Down List"

     
        #region "Encrypt"
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
                
        #endregion
        
        public void getEmployeeTypeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEmployeeTypeId.DataSource = objLookUpBLL.getEmployeeTypeId();

            ddlEmployeeTypeId.DataTextField = "EMPLOYEE_TYPE_NAME";
            ddlEmployeeTypeId.DataValueField = "EMPLOYEE_TYPE_ID";

            ddlEmployeeTypeId.DataBind();
            if (ddlEmployeeTypeId.Items.Count > 0)
            {

                ddlEmployeeTypeId.SelectedIndex = 0;
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
            strLoginDay = Session["strLoginDay"].ToString().Trim();
            strLoginMonth = Session["strLoginMonth"].ToString().Trim();
            strLoginDate = Session["strLoginDate"].ToString().Trim();

            if (Session["strID"] != null)
            {
                strID = Session["strID"].ToString().Trim();
            }
        }
        public void CreateSession()
        {
            string employeeId = "_" + Request.Cookies["eid"].Value.ToString();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            var employee = objEmployeeBLL.GetEmployeeById(employeeId);
            string suffix = "_" + (string)employee.Rows[0]["BRANCH_OFFICE_ID"];

            strEmployeeId = Session["strEmployeeId" + suffix].ToString().Trim();
            strSectionId = Session["strSectionId" + suffix].ToString().Trim();
            strDesignationId = Session["strDesignationId" + suffix].ToString().Trim();
            strUnitId = Session["strUnitId" + suffix].ToString().Trim();
            strCatagoryId = Session["strCatagoryId" + suffix].ToString().Trim();
            strHeadOfficeId = Session["strHeadOfficeId" + suffix].ToString().Trim();
            strBranchOfficeId = Session["strBranchOfficeId" + suffix].ToString().Trim();
            strLoginDay = Session["strLoginDay" + suffix].ToString().Trim();
            strLoginMonth = Session["strLoginMonth" + suffix].ToString().Trim();
            strLoginDate = Session["strLoginDate" + suffix].ToString().Trim();
            if (Session["strID" + suffix] != null)
            {
                strID = Session["strID" + suffix].ToString().Trim();
            }
        }
        public void ClearSession()
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
       
        public void getGenderId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlGenderId.DataSource = objLookUpBLL.getGenderId();

            ddlGenderId.DataTextField = "Gender_Name";
            ddlGenderId.DataValueField = "Gender_ID";

            ddlGenderId.DataBind();
            if (ddlGenderId.Items.Count > 0)
            {
                ddlGenderId.SelectedIndex = 0;
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
        
        public void getUnitIdForEmployee()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEmpUnitId.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlEmpUnitId.DataTextField = "UNIT_NAME";
            ddlEmpUnitId.DataValueField = "UNIT_ID";

            ddlEmpUnitId.DataBind();
            if (ddlEmpUnitId.Items.Count > 0)
            {
                ddlEmpUnitId.SelectedIndex = 0;
            }
        }
        public void getSectionIdForEmployee()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();

            ddlEmpSectionId.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

            ddlEmpSectionId.DataTextField = "SECTION_NAME";
            ddlEmpSectionId.DataValueField = "SECTION_ID";

            ddlEmpSectionId.DataBind();
            if (ddlEmpSectionId.Items.Count > 0)
            {
                ddlEmpSectionId.SelectedIndex = 0;
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
        public void getJoiningDesignationId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlJoiningDesignationId.DataSource = objLookUpBLL.getDesignationId(strHeadOfficeId, strBranchOfficeId);

            ddlJoiningDesignationId.DataTextField = "DESIGNATION_NAME";
            ddlJoiningDesignationId.DataValueField = "DESIGNATION_ID";

            ddlJoiningDesignationId.DataBind();
            if (ddlJoiningDesignationId.Items.Count > 0)
            {
                ddlJoiningDesignationId.SelectedIndex = 0;
            }
        }

        public void getReligionId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlReligionId.DataSource = objLookUpBLL.getReligionId();

            ddlReligionId.DataTextField = "RELIGION_NAME";
            ddlReligionId.DataValueField = "RELIGION_ID";

            ddlReligionId.DataBind();
            if (ddlReligionId.Items.Count > 0)
            {
                ddlReligionId.SelectedIndex = 0;
            }
        }

        public void geTitleId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlTitleId.DataSource = objLookUpBLL.geTitleId();

            ddlTitleId.DataTextField = "TITLE_NAME";
            ddlTitleId.DataValueField = "TITLE_ID";

            ddlTitleId.DataBind();
            if (ddlTitleId.Items.Count > 0)
            {
                ddlTitleId.SelectedIndex = 0;
            }
        }
       
        #endregion
        #region "Function"

        public void goToNextRecord()
        {

            if (txtSL.Text == string.Empty)
            {
                txtSL.Text = "1";
            }

            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            
            int l;
            l = GvEmployeeCache.SelectedRow.RowIndex;
            if (l != 0)
            {

                int strId = GvEmployeeCache.SelectedRow.RowIndex + 1;
                int strRowCount = strId;
                int intCount = GvEmployeeCache.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                    txtEmployeeId.Focus();
                    clear();
                    return;

                }
                else
                {
                    GvEmployeeCache.SelectedIndex += 1;
                    result = GvEmployeeCache.SelectedRow.RowIndex + k;

                }

            }
            if (l == 0)
            {

                int intCount = GvEmployeeCache.Rows.Count;
                int intCountRow = GvEmployeeCache.Rows.Count;
                if (intCountRow == 1)
                {
                    intCountRow = 2;

                }

                int p = intCountRow - 1;
                //int p = intCountRow;
                if (l == p)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                    txtEmployeeId.Focus();
                    clear();
                    return;
                }
                else
                {
                    l = 1;

                    if (txtSL.Text == "1" && txtSLNew.Text == "")
                    {
                        GvEmployeeCache.SelectedIndex = 0;
                        result = GvEmployeeCache.SelectedRow.RowIndex + k;
                        txtSLNew.Text = "1";

                    }
                    else
                    {

                        int intC = GvEmployeeCache.Rows.Count;
                        int intCo = GvEmployeeCache.Rows.Count;
                        int ll = 0;

                        int pp = intCo - 1;
                        //int p = intCountRow;
                        if (ll == pp)
                        {
                            string strMsg = "There is no Data for the Next Record!!!";
                            MessageBox(strMsg);
                            txtEmployeeId.Focus();
                            return;

                        }
                        else
                        {
                            GvEmployeeCache.SelectedIndex += 1;
                            result = GvEmployeeCache.SelectedRow.RowIndex + k;
                        }
                    }
                }
            }

            int strRowId = GvEmployeeCache.SelectedRow.RowIndex + 1;
            string strSLNo = GvEmployeeCache.SelectedRow.Cells[0].Text;
            if (strSLNo == "NO RECORD FOUND")
            {
                clear();
                loadCombo();
            }
            else
            {
                string strCardNo = GvEmployeeCache.SelectedRow.Cells[1].Text;
                string strEmployeeId = GvEmployeeCache.SelectedRow.Cells[2].Text;
                string strEmployeeName = GvEmployeeCache.SelectedRow.Cells[3].Text;
                string strDesignation = GvEmployeeCache.SelectedRow.Cells[4].Text;
                
                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;
                //searchEmployeeInfo();
                txtEmployeeId.Focus();
            }
        }
        public void goToPreviousRecord()
        {
            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            //gvIncrementList.SelectedIndex = 1;


            int l;
            l = GvEmployeeCache.SelectedRow.RowIndex;
            if (l != 0)
            {
                int strId = GvEmployeeCache.SelectedRow.RowIndex - 1;
                int strRowCount = strId;
                int intCount = GvEmployeeCache.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    txtEmployeeId.Focus();
                    return;

                }
                else
                {
                    GvEmployeeCache.SelectedIndex -= 1;
                    result = GvEmployeeCache.SelectedRow.RowIndex - k;
                }
            }
            if (l == 0)
            {

                int intCountRow = GvEmployeeCache.Rows.Count;
                int p = intCountRow;
                if (intCountRow == p)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    txtEmployeeId.Focus();
                    return;
                }
                else
                {
                    l = 1;
                    GvEmployeeCache.SelectedIndex = l;
                    result = GvEmployeeCache.SelectedRow.RowIndex - k;
                }
            }
            int strRowId = GvEmployeeCache.SelectedRow.RowIndex + 1;
            string strSLNo = GvEmployeeCache.SelectedRow.Cells[0].Text;
            string strCardNo = GvEmployeeCache.SelectedRow.Cells[1].Text;
            string strEmployeeId = GvEmployeeCache.SelectedRow.Cells[2].Text;
            string strEmployeeName = GvEmployeeCache.SelectedRow.Cells[3].Text;
            string strDesignation = GvEmployeeCache.SelectedRow.Cells[4].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            
            txtEmployeeId.Focus();

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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void passValue(string strEmployeeId, string strHeadOfficeId)
        {
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeId.Text = Session["strID"].ToString().Trim();
            //searchEmployeeInfo();

        }
        #endregion
        #region "DML"

        public void SaveEmployeeInCache()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string EmpId = string.Empty;

            if (txtCacheId.Text=="")
            {
                objEmployeeDTO.CacheId = null;
            }
            else
            {
                objEmployeeDTO.CacheId = txtCacheId.Text;
            }
            
            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;

            objEmployeeDTO.CardNo = txtCardNo.Text;
            objEmployeeDTO.EmployeeName = txtEmployeeName.Text;
            objEmployeeDTO.EmployeeNameBangla = txtEmployeeNameBangla.Text;
                   
            if (ddlJoiningDesignationId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.DesignationId = ddlJoiningDesignationId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.DesignationId = "";
            } 
                  
            if (ddlGenderId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.GenderId = ddlGenderId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.GenderId = "";
            }
            if (ddlEmployeeTypeId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.EmployeeTypeId = "";
            }
           
              objEmployeeDTO.NIDNo = txtNidNo.Text;
            
            if (ddlTitleId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.TitleId = ddlTitleId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.TitleId = "";
            }

            if (ddlReligionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.ReligionId = ddlReligionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.ReligionId = "";
            }

            objEmployeeDTO.EmployeeActiveYn = "Y";
            
            //if (chkAcftiveYn.Checked == true)
            //{
            //    objEmployeeDTO.EmployeeActiveYn = "Y";
            //}
            //else
            //{
            //    objEmployeeDTO.EmployeeActiveYn = "N";
            //}

            objEmployeeDTO.JoiningDate = dtpJoiningDate.Text;    
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
            
            objEmployeeDTO.PunchCode = txtPunchCode.Text;

            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;                      
                       
            string msg = objEmployeeBLL.SaveEmployeeInCache(objEmployeeDTO);

            if (msg == "OK")
            {
                clear();
                msg = "SUCCESSFULLY DONE";
                lblMsg.Text = msg;
                MessageBox(msg);
            }
            else {
                lblMsg.Text = msg;
                MessageBox(msg);
            }
        }

        public void clear()
        {
            lblMsg.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            ddlTitleId.SelectedIndex = 0;
            txtCardNo.Text = string.Empty;
            txtPunchCode.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtEmployeeNameBangla.Text = string.Empty;

            dtpJoiningDate.Text = string.Empty;
            ddlEmployeeTypeId.SelectedIndex = 0;
            ddlJoiningDesignationId.SelectedIndex = 0;
            txtGradeNo.Text = string.Empty;
            ddlUnitId.SelectedIndex = 0;
            ddlSectionId.SelectedIndex = 0;
            txtNidNo.Text = string.Empty;
            ddlGenderId.SelectedIndex = 0;
            ddlReligionId.SelectedIndex = 0;
            txtCacheId.Text = string.Empty;
            txtCardNo.Focus();
        }

        public void loadCombo()
        {
            getGenderId();            
            getUnitId();
            getSectionId();           
            geTitleId();          
            getJoiningDesignationId();
        }
               
        public void GetEmployeeCacheByCacheId(string cacheId)
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
                        
            objEmployeeDTO = objEmployeeBLL.GetEmployeeCacheByCacheId(cacheId);

            //txtEmployeeId.Text = objEmployeeDTO.EmployeeId;
            if (objEmployeeDTO.EmployeeId == "N/A")
            {
                txtEmployeeId.Text = string.Empty;
            }
            else
            {
                txtEmployeeId.Text = objEmployeeDTO.EmployeeId;
            }
            txtCardNo.Text = objEmployeeDTO.CardNo;
            txtEmployeeName.Text = objEmployeeDTO.EmployeeName;


            if (objEmployeeDTO.EmployeeNameBangla == "N/A")
            {
                txtEmployeeNameBangla.Text = string.Empty;
            }
            else
            {
                txtEmployeeNameBangla.Text = objEmployeeDTO.EmployeeNameBangla;
            }
            dtpJoiningDate.Text = objEmployeeDTO.JoiningDate;
            
            if (objEmployeeDTO.GenderId == "0")
            {
                getGenderId();
            }
            else
            {
                ddlGenderId.SelectedValue = objEmployeeDTO.GenderId;
            }

            if (objEmployeeDTO.EmployeeTypeId == "0")
            {
                getEmployeeTypeId();
            }
            else
            {
                ddlEmployeeTypeId.SelectedValue = objEmployeeDTO.EmployeeTypeId;
            }

            if (objEmployeeDTO.NIDNo == "")
                txtNidNo.Text = "";
            else
                txtNidNo.Text = objEmployeeDTO.NIDNo;
                  
            if (objEmployeeDTO.TitleId == "0")
            {
                geTitleId();
            }
            else
            {
                ddlTitleId.SelectedValue = objEmployeeDTO.TitleId;
            }
                        
            if (objEmployeeDTO.UnitId == "0")
            {
                getUnitId();
            }
            else
            {
                ddlUnitId.SelectedValue = objEmployeeDTO.UnitId;
            }
            if (objEmployeeDTO.SectionId == "0")
            {
                getSectionId();
            }
            else
            {
                ddlSectionId.SelectedValue = objEmployeeDTO.SectionId;
            }
            
            if (objEmployeeDTO.DesignationId == "0")
            {
                getJoiningDesignationId();

            }
            else
            {
                ddlJoiningDesignationId.SelectedValue = objEmployeeDTO.DesignationId;
            }
            txtGradeNo.Text = objEmployeeDTO.GradeNo;

            if (objEmployeeDTO.ReligionId == "0")
            {
                getReligionId();

            }
            else
            {
                ddlReligionId.SelectedValue = objEmployeeDTO.ReligionId;
            }

            dtpJoiningDate.Text = objEmployeeDTO.JoiningDate;

            //if (objEmployeeDTO.EmployeeActiveYn == "Y")
            //{
            //    chkAcftiveYn.Checked = true;
            //}
            //else
            //{
            //    chkAcftiveYn.Checked = false;
            //}
            if (objEmployeeDTO.PunchCode == "0")
            {
                txtPunchCode.Text = string.Empty;
            }
            else
            {
                txtPunchCode.Text = objEmployeeDTO.PunchCode;
            }

        }


        public void searchEmployeeStatus()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strEmpId = "";
            objEmployeeDTO = objEmployeeBLL.searchEmployeeStatus(txtEmployeeId.Text, txtCardNo.Text, strHeadOfficeId, strBranchOfficeId, strEmpId);
            lblMsg.Text = objEmployeeDTO.Msg;
        }
        #endregion
        protected void ddlGenderId_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void txtEmployeeName2_TextChanged(object sender, EventArgs e)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadEmployeeCache();
            }
            catch (Exception ex)
            {
              //  throw new Exception("Error : " + ex.Message);
            }
        }

        public void LoadEmployeeCache()
        {
            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            if (ddlEmpUnitId.SelectedValue.ToString() != " ")
            {
                objReportDTO.UnitId = ddlEmpUnitId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.UnitId = "";
            }
            if (ddlEmpSectionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.SectionId = ddlEmpSectionId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.SectionId = "";
            }

            objReportDTO.EmployeeId = txtEmpId.Text;
            objReportDTO.CardNo = txtEmpCardNo.Text;
            objReportDTO.FromCreateDate = txtFromDate.Text;
            objReportDTO.ToCreateDate = txtToDate.Text;
            objReportDTO.ApproveYn = ddlApproved.SelectedValue.ToString();
            objReportDTO.Delete_Yn = "N";

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;

            DataTable dt = objReportBLL.GetEmployeeCache(objReportDTO);

            if (dt.Rows.Count > 0)
            {
                GvEmployeeCache.DataSource = dt;
                GvEmployeeCache.DataBind();

                int count = ((DataTable)GvEmployeeCache.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GvEmployeeCache.DataSource = dt;
                GvEmployeeCache.DataBind();
                int totalcolums = GvEmployeeCache.Rows[0].Cells.Count;
                GvEmployeeCache.Rows[0].Cells.Clear();
                GvEmployeeCache.Rows[0].Cells.Add(new TableCell());
                GvEmployeeCache.Rows[0].Cells[0].ColumnSpan = totalcolums;
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    if (ddlTitleId.Text == " ")
                    {
                        string strMsg = "Please Select Title!!!";
                        MessageBox(strMsg);
                        ddlTitleId.Focus();
                        return;
                    }
                    if (txtCardNo.Text == "")
                    {
                        string strMsg = "Please Enter Card No!!!";
                        MessageBox(strMsg);
                        txtCardNo.Focus();
                        return;
                    }                   
                   if (txtEmployeeName.Text == "")
                    {
                        string strMsg = "Please Enter Employee Name!!!";
                        MessageBox(strMsg);
                        txtEmployeeName.Focus();
                        return;
                    }
                    if (txtEmployeeNameBangla.Text == "")
                    {
                        string strMsg = "Please Enter Employee Name Bangla!!!";
                        MessageBox(strMsg);
                        txtEmployeeNameBangla.Focus();
                        return;
                    }
                    if (dtpJoiningDate.Text == "")
                    {
                        string strMsg = "Please Enter Joinig Date!!!";
                        MessageBox(strMsg);
                        dtpJoiningDate.Focus();
                        return;
                    }
                    if (ddlEmployeeTypeId.Text == " ")
                    {
                        string strMsg = "Please Select Employee Type!!!";
                        MessageBox(strMsg);
                        ddlEmployeeTypeId.Focus();
                        return;
                    }
                    if (ddlJoiningDesignationId.Text == " ")
                    {
                        string strMsg = "Please Select Designation Name!!!";
                        MessageBox(strMsg);
                        ddlJoiningDesignationId.Focus();
                        return;
                    }
                    if (ddlUnitId.Text == " ")
                    {
                        string strMsg = "Please Select Unit Name!!!";
                        MessageBox(strMsg);
                        ddlUnitId.Focus();
                        return;
                    }
                   if (ddlSectionId.Text == " ")
                    {
                        string strMsg = "Please Select Section Name!!!";
                        MessageBox(strMsg);
                        ddlSectionId.Focus();
                        return;
                    }
                    
                    //if (txtNidNo.Text == "")
                    //{
                    //    string strMsg = "Please Enter NID!!!";
                    //    MessageBox(strMsg);
                    //    txtNidNo.Focus();
                    //    return;
                    //}

                    if (ddlGenderId.Text == " ")
                    {
                        string strMsg = "Please Select Gender!!!";
                        MessageBox(strMsg);
                        ddlGenderId.Focus();
                        return;
                    }
                    if (ddlReligionId.Text == " ")
                    {
                        string strMsg = "Please Select Religion!!!";
                        MessageBox(strMsg);
                        ddlReligionId.Focus();
                        return;
                    }
                    SaveEmployeeInCache();
                                       
                }
            }
            catch (Exception ex)
            {
               // throw new Exception("Error :" + ex.Message);
            }
        }

        private void saveImage()
        {
           // saveImage(FileUpload1);
        }
        #region "saveImage"
        public void saveImage(HtmlInputFile file)
        {
            try
            {
                string strMsg = string.Empty;

                EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                HttpPostedFile imgFile = file.PostedFile;
                DateTime dt = DateTime.UtcNow.Date;
                string currentDate = Convert.ToString(DateTime.Now.ToShortDateString());
                string strFileName = file.PostedFile.FileName;
                string strImageExtension = Path.GetExtension(file.PostedFile.FileName);

                FileInfo fi = new System.IO.FileInfo(file.PostedFile.FileName);

                string fileName = fi.Name;
                BinaryReader b = new BinaryReader(imgFile.InputStream);
                byte[] employeePic = b.ReadBytes(imgFile.ContentLength);

                string fileSize = Convert.ToBase64String(employeePic);

                if (file.PostedFile != null && file.PostedFile.ContentLength > 0)
                {
                    objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                    objEmployeeDTO.UpdateBy = strEmployeeId;
                    objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                    objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                    if (file.ID == "FileUpload1")
                    {
                        objEmployeeDTO.EmployeePic = ImageCompression.Resize(employeePic, 160, 196, 144, 144);
                        objEmployeeDTO.FileName = strFileName;
                        objEmployeeDTO.ImageType = strImageExtension;
                        strMsg = objEmployeeBLL.SaveImage(objEmployeeDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                file.Dispose();
                file.PostedFile.InputStream.Close();
                file.PostedFile.InputStream.Dispose();
                lblMsg.Text = ex.Message;
            }            
        }

        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            
            clear();
            //loadCombo();
            Session["strID"] = null;
            //txtFirstSalary.ReadOnly = false;

        }

        #region "Grid View Functionality"
        protected void GvEmployeeCache_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvEmployeeCache.PageIndex = e.NewPageIndex;
            //searchEmployeeInfo();
        }

        protected void GvEmployeeCache_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
            //getGradeNo();
            int strRowId = GvEmployeeCache.SelectedRow.RowIndex + 1;
            string cacheId = GvEmployeeCache.SelectedRow.Cells[0].Text;
            string approveYn = GvEmployeeCache.SelectedRow.Cells[10].Text;
            txtCacheId.Text = cacheId;
            if (approveYn == "Yes")
            {
                lblMsg.Text = "Already Approved.";
                MessageBox("Already Approved.");
            }
            else
            {
                string strSLNo = GvEmployeeCache.SelectedRow.Cells[0].Text;
                txtSL.Text = Convert.ToString(strRowId);              
                GetEmployeeCacheByCacheId(cacheId);
            }
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GvEmployeeCache_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GvEmployeeCache, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GvEmployeeCache_Sorting(object sender, GridViewSortEventArgs e)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadEmployeeRecord();

            if (dt.Rows.Count > 0)
            {
                GvEmployeeCache.DataSource = dt;
                GvEmployeeCache.DataBind();
            }
            if (dt != null)
            {
                DataView dataView = new DataView(dt);
                GvEmployeeCache.DataSource = dataView;
                GvEmployeeCache.DataBind();
            }
        }

        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }
        protected void GvEmployeeCache_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //GvEmployeeCache.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }

        #endregion
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (GvEmployeeCache.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    //btnSearchEmployee.Focus();
                    return;
                }
                else
                {
                    goToNextRecord();
                    //imgEmployee.ImageUrl = "ImageHandler.ashx?employee_id=" + txtEmployeeId.Text;                
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (GvEmployeeCache.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    //btnSearchEmployee.Focus();
                    return;
                }
                else
                {
                    goToPreviousRecord();
                   // imgEmployee.ImageUrl = "ImageHandler.ashx?employee_id=" + txtEmployeeId.Text;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                this.Context.Session["strID"] = txtEmployeeId.Text;
                string strURL = "Picture.aspx";
                string strNewWindow = "window.open('" + strURL + "')";
                ClientScript.RegisterStartupScript(this.GetType(), "pop", strNewWindow, true);                
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }        
              
        public void reportMaster()
        {

            if (chkPDF.Checked == true)
            {

                //CrystalReportViewer1.ReportSource = rd;
                //CrystalReportViewer1.DataBind();

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
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "employee_report");
                Response.End();
                //CrystalReportViewer1.RefreshReport();

            }
        }


        #region "Crystal Report Functionality"

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            //CrystalReportViewer1.Dispose();
            //CrystalReportViewer1 = null;
            rd.Dispose();
            rd.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {
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

            try
            {
                if (ddlApproved.SelectedValue == string.Empty)
                {
                    string msg = "Please Select Approved";
                    MessageBox(msg);
                    ddlApproved.Focus();
                    return;
                }
                GetEmploymentApprovalSheet();

            }
            catch (Exception ex)
            {

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

        }
        
        public void GetDeletedApprovalEmpSheet()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.EmployeeId = txtEmployeeId.Text;
                objReportDTO.CardNo = txtCardNo.Text;
                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();
                objReportDTO.ApproveYn = ddlApproved.SelectedValue.ToString();
                objReportDTO.Delete_Yn = "Y";
                objReportDTO.FromCreateDate = txtFromDate.Text;
                objReportDTO.ToCreateDate = txtToDate.Text;
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptDeletedApprovalEmpSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetDeletedApprovalEmpSheet(objReportDTO));
                
                

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
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        public void GetEmploymentApprovalSheet()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.EmployeeId = txtEmployeeId.Text;
                objReportDTO.CardNo = txtCardNo.Text;
                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();
                objReportDTO.ApproveYn = ddlApproved.SelectedValue.ToString();
                objReportDTO.Delete_Yn = "N";
                objReportDTO.FromCreateDate = txtFromDate.Text;
                objReportDTO.ToCreateDate = txtToDate.Text;
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;



                if (objReportDTO.ApproveYn == "Y") //Approved
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmploymentApprovalSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetEmploymentApprovalSheet(objReportDTO));
                }
                if (objReportDTO.ApproveYn == "N") //Not Approved
                {
                    string strPath = string.Empty;
                    {
                        strPath = Path.Combine(Server.MapPath("~/Reports/RptEmploymentApprovalSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetEmploymentNotApprovalSheet(objReportDTO));
                    }
                }

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
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        #region "Encrypt/Decrypt"
        private string Encrypt(string clearText)
        {

            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public string EncryptBp(string strGrossSalary)
        {

            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(strGrossSalary);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    strGrossSalary = Convert.ToBase64String(ms.ToArray());
                }
            }
            return strGrossSalary;
        }

        public string DecryptBP(string strGrossSalary)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            strGrossSalary = strGrossSalary.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(strGrossSalary);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    strGrossSalary = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return strGrossSalary;          
        }          
        #endregion
                      
        [System.Web.Services.WebMethod]
        public static string GetGradeByDesignationId(string designationId)
        {
            string grade_id = "";

            if (strBranchOfficeId == "103")
            {
                if (designationId != " ")
                {
                    LookUpDTO objLookUpDTO = new LookUpDTO();
                    LookUpBLL objLookUpBLL = new LookUpBLL();
                    DataTable Grades = objLookUpBLL.GetGradeByDesignationId(designationId, strHeadOfficeId, strBranchOfficeId);

                    foreach (DataRow row in Grades.Rows)
                    {
                        grade_id = row["grade_id"].ToString();
                    }
                }
            }
            else
                grade_id = "-1";
            return grade_id;
        }

        protected void btnDeletedEmpSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFromDate.Text == string.Empty)
                {
                    string msg = "Please Insert From Date";
                    MessageBox(msg);
                    txtFromDate.Focus();
                    return;
                }
                if (txtToDate.Text == string.Empty)
                {
                    string msg = "Please Insert To Date";
                    MessageBox(msg);
                    txtToDate.Focus();
                    return;
                }

                GetDeletedApprovalEmpSheet();

            }
            catch (Exception ex)
            {

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}