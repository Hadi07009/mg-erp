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
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Globalization;
using CrystalDecisions.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using SINHA.MEDLAR.ERP.COMMON.Utility.Image;
using System.Web.Services;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class EmployeeInfoUpdate : System.Web.UI.Page
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
                getMaritalStatusId();
                getReligionId();
                getBloodGroupId();
                getUnitIdForEmployee();
                getSectionIdForEmployee();
                getJobId();
                GetAllBank();
                getUnitId();
                getSectionId();
                getDesignationId();
                getJoiningDesignationId();
                getCatagoryId();
                getEmpId();
                getEmpTypeId();
                getNationalityId();
                geTitleId();
                getSupervisorId();
                getJobLocationId();
                getEmployeeTypeId();
                getPeriodtId();
                getShiftId();
                getPaymentTypeId();
                getOccurenceTypeId();
                getDivisionId();
                getDistrictId();
                getBloodGroupIdForSearch();
                GetGrade();
                getOfficeName();
                getApprovedId();
                getDepartmentId();
                lblMsg.Text = string.Empty;
                GetSittingBranchOfficeId();
                GetCompanyId();
                //Keep bellow method named as "getId()" in the bottom
                getId();
                
            }
            if (IsPostBack)
            {
                loadSesscion();
                Session["strID"] = null;
            }
        }

        #region "Load Drop Down List"

        public void disableText()
        {

            if (txtEmployeeId.Text != "" && (strBranchOfficeId == "103" || strBranchOfficeId == "110") && (strDesignationId == "5" || strDesignationId == "5"))
            {

                txtGrossSalary.Text = Encrypt(txtGrossSalary.Text);
                txtJoiningSalary.Text = Encrypt(txtJoiningSalary.Text);
                txtFirstSalary.Text = Encrypt(txtFirstSalary.Text);

            }
            else
            {

            }

        }

        #region "Encrypt"
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");







        #endregion

        public void getBloodGroupIdForSearch()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBloodGroupIdForSearch.DataSource = objLookUpBLL.getBloodGroupId(strHeadOfficeId, strBranchOfficeId);

            ddlBloodGroupIdForSearch.DataTextField = "BLOOD_GROUP_NAME";
            ddlBloodGroupIdForSearch.DataValueField = "BLOOD_GROUP_ID";

            ddlBloodGroupIdForSearch.DataBind();
            if (ddlBloodGroupIdForSearch.Items.Count > 0)
            {

                ddlBloodGroupIdForSearch.SelectedIndex = 0;
            }

        }
        public void getGradeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlGradeId.DataSource = objLookUpBLL.getGradeId(strHeadOfficeId, strBranchOfficeId);

            ddlGradeId.DataTextField = "GRADE_NO";
            ddlGradeId.DataValueField = "GRADE_ID";

            ddlGradeId.DataBind();
            if (ddlGradeId.Items.Count > 0)
            {

                ddlGradeId.SelectedIndex = 0;
            }

        }
        public void getGradeNo()
        {
            ddlGradeNo.Items.Clear();

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlGradeNo.DataSource = objLookUpBLL.getGradeId(strHeadOfficeId, strBranchOfficeId);

            ddlGradeNo.DataTextField = "GRADE_NO";
            ddlGradeNo.DataValueField = "GRADE_ID";

            ddlGradeNo.DataBind();
            if (ddlGradeNo.Items.Count > 0)
            {
                ddlGradeNo.SelectedIndex = 0;
            }
        }
        public void GetGrade()
        {
            ddlGradeNo.Items.Clear();

            LookUpBLL objLookUpBLL = new LookUpBLL();
            var data = objLookUpBLL.GetGrade(strHeadOfficeId, strBranchOfficeId);

            ddlGradeNo.DataSource = data; 
            ddlGradeNo.DataTextField = "GRADE_NO";
            ddlGradeNo.DataValueField = "GRADE_ID";

            ddlGradeNo.DataBind();
            if (ddlGradeNo.Items.Count > 0)
            {
                ddlGradeNo.SelectedIndex = 0;
            }

            //------------------------------------------------
            ddlGradeId.Items.Clear();
            ddlGradeId.DataSource = data;
            ddlGradeId.DataTextField = "GRADE_NO";
            ddlGradeId.DataValueField = "GRADE_ID";

            ddlGradeId.DataBind();
            if (ddlGradeId.Items.Count > 0)
            {

                ddlGradeId.SelectedIndex = 0;
            }
        }
        public void getId()
        {

            if (strID.Length > 0)
            {
                txtEmployeeId.Text = strID;
                searchEmployeeInfo();
                ReadOnlyYn();
                searchEmployeeSummeryInformation();
                imgEmployee.ImageUrl = "ImageHandler.ashx?employee_id=" + txtEmployeeId.Text;
                ImgSignature.ImageUrl = "GenericImageHandler.ashx?employee_id=" + txtEmployeeId.Text + "&nvl=1";
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

        public void GetAllBank()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBank.DataSource = objLookUpBLL.GetAllBank();

            ddlBank.DataTextField = "BANK_NAME";
            ddlBank.DataValueField = "BANK_ID";

            ddlBank.DataBind();
            if (ddlBank.Items.Count > 0)
            {
                ddlBank.SelectedIndex = 0;
            }
        }

        public void getMaritalStatusId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlMaritalStatusId.DataSource = objLookUpBLL.getMaritalStatusId();

            ddlMaritalStatusId.DataTextField = "MARITAL_STATUS_NAME";
            ddlMaritalStatusId.DataValueField = "MARITAL_STATUS_ID";

            ddlMaritalStatusId.DataBind();
            if (ddlMaritalStatusId.Items.Count > 0)
            {

                ddlMaritalStatusId.SelectedIndex = 0;
            }

        }
        public void getApprovedId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlApprovedBy.DataSource = objLookUpBLL.getApprovedId();

            ddlApprovedBy.DataTextField = "EMPLOYEE_NAME";
            ddlApprovedBy.DataValueField = "EMPLOYEE_ID";

            ddlApprovedBy.DataBind();
            if (ddlApprovedBy.Items.Count > 0)
            {

                ddlApprovedBy.SelectedIndex = 0;
            }

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
        public void getBloodGroupId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBloodGroupId.DataSource = objLookUpBLL.getBloodGroupId();

            ddlBloodGroupId.DataTextField = "BLOOD_GROUP_NAME";
            ddlBloodGroupId.DataValueField = "BLOOD_GROUP_ID";

            ddlBloodGroupId.DataBind();
            if (ddlBloodGroupId.Items.Count > 0)
            {

                ddlBloodGroupId.SelectedIndex = 0;
            }

        }
        public void getJobId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlJobTypeId.DataSource = objLookUpBLL.getJobId();

            ddlJobTypeId.DataTextField = "JOB_TYPE_NAME";
            ddlJobTypeId.DataValueField = "JOB_TYPE_ID";

            ddlJobTypeId.DataBind();
            if (ddlJobTypeId.Items.Count > 0)
            {

                ddlJobTypeId.SelectedIndex = 0;
            }

        }
        public void getSupervisorId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSupervisorId.DataSource = objLookUpBLL.getSupervisorId();

            ddlSupervisorId.DataTextField = "supervisor_name";
            ddlSupervisorId.DataValueField = "supervisor_id";

            ddlSupervisorId.DataBind();
            if (ddlSupervisorId.Items.Count > 0)
            {

                ddlSupervisorId.SelectedIndex = 0;
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
        public void getDepartmentId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlDepartmentId.DataSource = objLookUpBLL.getDepartmentId(strHeadOfficeId, strBranchOfficeId);

            ddlDepartmentId.DataTextField = "DEPARTMENT_NAME";
            ddlDepartmentId.DataValueField = "DEPARTMENT_ID";

            ddlDepartmentId.DataBind();
            if (ddlDepartmentId.Items.Count > 0)
            {

                ddlDepartmentId.SelectedIndex = 0;
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
        public void getDesignationId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlDesignationId.DataSource = objLookUpBLL.getDesignationId(strHeadOfficeId, strBranchOfficeId);

            ddlDesignationId.DataTextField = "DESIGNATION_NAME";
            ddlDesignationId.DataValueField = "DESIGNATION_ID";

            ddlDesignationId.DataBind();
            if (ddlDesignationId.Items.Count > 0)
            {

                ddlDesignationId.SelectedIndex = 0;
            }

        }
        public void getCatagoryId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlCatagoryId.DataSource = objLookUpBLL.getCatagoryId();

            ddlCatagoryId.DataTextField = "CATAGORY_NAME";
            ddlCatagoryId.DataValueField = "CATAGORY_ID";

            ddlCatagoryId.DataBind();
            if (ddlCatagoryId.Items.Count > 0)
            {

                ddlCatagoryId.SelectedIndex = 0;
            }

        }
        public void getNationalityId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlNationalityId.DataSource = objLookUpBLL.getNationalityId();

            ddlNationalityId.DataTextField = "NATIONALITY_NAME";
            ddlNationalityId.DataValueField = "NATIONALITY_ID";

            ddlNationalityId.DataBind();
            if (ddlNationalityId.Items.Count > 0)
            {

                ddlNationalityId.SelectedIndex = 0;
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
        public void getJobLocationId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlJobLocationId.DataSource = objLookUpBLL.getJobLocationId();

            ddlJobLocationId.DataTextField = "JOB_LOCATION_NAME";
            ddlJobLocationId.DataValueField = "JOB_LOCATION_ID";

            ddlJobLocationId.DataBind();
            if (ddlJobLocationId.Items.Count > 0)
            {

                ddlJobLocationId.SelectedIndex = 0;
            }
        }

        public void getEmpTypeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEmpTypeId.DataSource = objLookUpBLL.getEmployeeTypeId();

            ddlEmpTypeId.DataTextField = "EMPLOYEE_TYPE_NAME";
            ddlEmpTypeId.DataValueField = "EMPLOYEE_TYPE_ID";

            ddlEmpTypeId.DataBind();
            if (ddlEmpTypeId.Items.Count > 0)
            {

                ddlEmpTypeId.SelectedIndex = 0;
            }
        }
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
        public void getPaymentTypeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPaymentTypeId.DataSource = objLookUpBLL.getPaymentTypeId();

            ddlPaymentTypeId.DataTextField = "PAYMENT_TYPE_NAME";
            ddlPaymentTypeId.DataValueField = "PAYMENT_TYPE_ID";

            ddlPaymentTypeId.DataBind();
            if (ddlPaymentTypeId.Items.Count > 0)
            {

                ddlPaymentTypeId.SelectedIndex = 0;
            }
        }
        public void getShiftId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlShiftId.DataSource = objLookUpBLL.getShiftId();

            ddlShiftId.DataTextField = "SHIFT_NAME";
            ddlShiftId.DataValueField = "SHIFT_ID";

            ddlShiftId.DataBind();
            if (ddlShiftId.Items.Count > 0)
            {

                ddlShiftId.SelectedIndex = 0;
            }
        }
        public void getPeriodtId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlTrainingPeriodId.DataSource = objLookUpBLL.getPeriodtId();

            ddlTrainingPeriodId.DataTextField = "TRAINING_PERIOD_NAME";
            ddlTrainingPeriodId.DataValueField = "TRAINING_PERIOD_ID";

            ddlTrainingPeriodId.DataBind();
            if (ddlTrainingPeriodId.Items.Count > 0)
            {

                ddlTrainingPeriodId.SelectedIndex = 0;
            }
        }
        public void getOccurenceTypeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlOccurenceTypeId.DataSource = objLookUpBLL.getOccurenceTypeId();

            ddlOccurenceTypeId.DataTextField = "OCCURENCE_TYPE_NAME";
            ddlOccurenceTypeId.DataValueField = "OCCURENCE_TYPE_ID";

            ddlOccurenceTypeId.DataBind();
            if (ddlOccurenceTypeId.Items.Count > 0)
            {

                ddlOccurenceTypeId.SelectedIndex = 0;
            }
        }
        public void getDivisionId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlDivisionId.DataSource = objLookUpBLL.getDivisionId();

            ddlDivisionId.DataTextField = "DIVISION_NAME";
            ddlDivisionId.DataValueField = "DIVISION_ID";

            ddlDivisionId.DataBind();
            if (ddlDivisionId.Items.Count > 0)
            {

                ddlDivisionId.SelectedIndex = 0;
            }
        }
        public void getDistrictId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlDistrictId.DataSource = objLookUpBLL.getDistrictId();

            ddlDistrictId.DataTextField = "DISTRICT_NAME";
            ddlDistrictId.DataValueField = "DISTRICT_ID";

            ddlDistrictId.DataBind();
            if (ddlDistrictId.Items.Count > 0)
            {

                ddlDistrictId.SelectedIndex = 0;
            }
        }
        public void getEmpId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEmpId.DataSource = objLookUpBLL.getEmpId(strHeadOfficeId, strBranchOfficeId);

            ddlEmpId.DataTextField = "EMPLOYEE_NAME";
            ddlEmpId.DataValueField = "EMPLOYEE_ID";

            ddlEmpId.DataBind();
            if (ddlEmpId.Items.Count > 0)
            {

                ddlEmpId.SelectedIndex = 0;
            }
        }

        public void GetSittingBranchOfficeId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSittingBranchOfficeId.DataSource = objLookUpBLL.getAllBranchOfficeId();

            ddlSittingBranchOfficeId.DataTextField = "BRANCH_OFFICE_NAME";
            ddlSittingBranchOfficeId.DataValueField = "BRANCH_OFFICE_ID";

            ddlSittingBranchOfficeId.DataBind();
            if (ddlSittingBranchOfficeId.Items.Count > 0)
            {
                ddlSittingBranchOfficeId.SelectedIndex = 0;
            }
        }
        public void GetCompanyId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlCompanyId.DataSource = objLookUpBLL.getAllBranchOfficeId();

            ddlCompanyId.DataTextField = "BRANCH_OFFICE_NAME";
            ddlCompanyId.DataValueField = "BRANCH_OFFICE_ID";

            ddlCompanyId.DataBind();
            if (ddlCompanyId.Items.Count > 0)
            {
                ddlCompanyId.SelectedIndex = 0;
            }
        }

        #endregion
        #region "Function"

        public void ReadOnlyYn()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            string strEmpId = txtEmployeeId.Text;


            string strMonth = DateTime.Now.ToString("MM");
            string strYear = DateTime.Now.Year.ToString();
            

            objEmployeeDTO = objEmployeeBLL.ReadOnlyYn(strEmpId, strMonth, strYear, strHeadOfficeId, strBranchOfficeId);
            if (objEmployeeDTO.LockYn == "Y")
            {

                txtJoiningSalary.ReadOnly = false;
                txtGrossSalary.ReadOnly = false;
                txtFirstSalary.ReadOnly = false;


                ddlUnitId.Enabled = false;
                ddlSectionId.Enabled = false;
            }
            else
            {


                objEmployeeDTO = objEmployeeBLL.PermissionYn(strEmployeeId, strHeadOfficeId, strBranchOfficeId);
                if (objEmployeeDTO.PermissionYn == "Y")
                {
                    txtJoiningSalary.Text = EncryptBp(txtJoiningSalary.Text);
                    txtGrossSalary.Text = EncryptBp(txtGrossSalary.Text);
                    txtFirstSalary.Text = EncryptBp(txtFirstSalary.Text);

                    txtJoiningSalary.ReadOnly = true;
                    txtGrossSalary.ReadOnly = true;
                    txtFirstSalary.ReadOnly = true;


                    ddlUnitId.Enabled = false;
                    ddlSectionId.Enabled = false;





                }
                else
                {

                    txtJoiningSalary.ReadOnly = false;
                    txtGrossSalary.ReadOnly = false;
                    txtFirstSalary.ReadOnly = false;


                    ddlUnitId.Enabled = false;
                    ddlSectionId.Enabled = false;
                }




            }




        }

        public void searchEmployeeInformation()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();


            string strActiveYn = "";
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.PunchCode = txtEmpPunchCode.Text;
            objEmployeeDTO.EmployeeName = txtEmpName.Text;

            if (chkActiveYn.Checked == true)
            {
                objEmployeeDTO.EmployeeActiveYn = "N";
            }
            else
            {
                objEmployeeDTO.EmployeeActiveYn = "Y";
            }

            if (ddlEmpUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlEmpUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";
            }


            if (ddlEmpId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.EmpId = ddlEmpId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.EmpId = "";

            }


            if (ddlEmpSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlEmpSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";

            }
            

            if (ddlBloodGroupIdForSearch.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.BloodGroupId = ddlBloodGroupIdForSearch.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.BloodGroupId = "";

            }

            if (ddlGradeId.SelectedValue.ToString() != "")
            {
                objEmployeeDTO.GradeNo = ddlGradeId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.GradeNo = "";
            }

            if (ddlEmpTypeId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.EmployeeTypeId = ddlEmpTypeId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.EmployeeTypeId = "";

            }


            objEmployeeDTO.FromConfirmDate = dtpFromConfirmDate.Text;
            objEmployeeDTO.ToConfirmDate = dtpToConfirmDate.Text;


            dt = objEmployeeBLL.searchEmployeeInformation(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
                int totalcolums = gvEmployeeList.Rows[0].Cells.Count;
                gvEmployeeList.Rows[0].Cells.Clear();
                gvEmployeeList.Rows[0].Cells.Add(new TableCell());
                gvEmployeeList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvEmployeeList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }
        
        //security log
     
                
        public void searchEmployeeSummeryInformation()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();


            string strActiveYn = "";
            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            dt = objEmployeeBLL.searchEmployeeSummeryInformation(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
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
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }



        }

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
            l = gvEmployeeList.SelectedRow.RowIndex;
            if (l != 0)
            {

                int strId = gvEmployeeList.SelectedRow.RowIndex + 1;
                int strRowCount = strId;
                int intCount = gvEmployeeList.Rows.Count;
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
                    gvEmployeeList.SelectedIndex += 1;
                    result = gvEmployeeList.SelectedRow.RowIndex + k;

                }

            }
            if (l == 0)
            {

                int intCount = gvEmployeeList.Rows.Count;
                int intCountRow = gvEmployeeList.Rows.Count;
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
                        gvEmployeeList.SelectedIndex = 0;
                        result = gvEmployeeList.SelectedRow.RowIndex + k;
                        txtSLNew.Text = "1";

                    }
                    else
                    {

                        int intC = gvEmployeeList.Rows.Count;
                        int intCo = gvEmployeeList.Rows.Count;
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
                            gvEmployeeList.SelectedIndex += 1;
                            result = gvEmployeeList.SelectedRow.RowIndex + k;
                        }
                    }
                }
            }


            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            if (strSLNo == "NO RECORD FOUND")
            {
                clear();
                loadCombo();
            }
            else
            {
                string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
                string strEmployeeId = gvEmployeeList.SelectedRow.Cells[2].Text;
                string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
                string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;
                
                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;

                searchEmployeeInfo();
                searchEmployeeSummeryInformation();
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
            l = gvEmployeeList.SelectedRow.RowIndex;
            if (l != 0)
            {
                int strId = gvEmployeeList.SelectedRow.RowIndex - 1;
                int strRowCount = strId;
                int intCount = gvEmployeeList.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    txtEmployeeId.Focus();
                    return;

                }
                else
                {
                    gvEmployeeList.SelectedIndex -= 1;
                    result = gvEmployeeList.SelectedRow.RowIndex - k;
                }
            }
            if (l == 0)
            {

                int intCountRow = gvEmployeeList.Rows.Count;
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
                    gvEmployeeList.SelectedIndex = l;
                    result = gvEmployeeList.SelectedRow.RowIndex - k;

                }

            }

            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;

            //int strRowCount = strRowId - 1;
            //int intCount = gvIncrementList.Rows.Count;
            //if (intCount == strRowCount)
            //{
            //    string strMsg = "Entry Completed";
            //    MessageBox(strMsg);
            //    return;

            //}
            //else
            //{




            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            searchEmployeeInfo();
            searchEmployeeSummeryInformation();
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

        //public void loadYear()
        //{

        //    for(int i=2000;i<=2080;i++)

        //       // ddlLeaveYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        //}



        public void passValue(string strEmployeeId, string strHeadOfficeId)
        {
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeId.Text = Session["strID"].ToString().Trim();
            searchEmployeeInfo();

        }
        #endregion
        #region "DML"

        public void UpdateEmployeeInfo()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            string EmpId = string.Empty;
            
            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
            if (ddlTitleId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.TitleId = ddlTitleId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.TitleId = "";
            }
            objEmployeeDTO.EmployeeNameBangla = txtEmployeeNameBangla.Text;
            objEmployeeDTO.FatherName = txtFatherName.Text;
            objEmployeeDTO.MotherName = txtMotherName.Text;
            objEmployeeDTO.DateOfBirth = dtpDateOfBirth.Text;
            objEmployeeDTO.HusbandName = txtHusbandName.Text;
            objEmployeeDTO.HusbandOccupation = txtHusbandOccupation.Text;
            if (ddlGenderId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.GenderId = ddlGenderId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.GenderId = "";
            }

            if (ddlMaritalStatusId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.MaritalStatusId = ddlMaritalStatusId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.MaritalStatusId = "";
            }

            if (ddlReligionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.ReligionId = ddlReligionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.ReligionId = "";
            }
            if (ddlNationalityId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.NationaLityId = ddlNationalityId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.NationaLityId = "";
            }
            if (ddlBloodGroupId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.BloodGroupId = ddlBloodGroupId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.BloodGroupId = "";
            }
            if (ddlDistrictId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.DistrictId = ddlDistrictId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.DistrictId = "";
            }
            if (ddlDivisionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.DivisionId = ddlDivisionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.DivisionId = "";
            }
            objEmployeeDTO.PresentAddress = txtPresentAddress.Text;
            objEmployeeDTO.PermanentAddress = txtPermanentAddress.Text;
            objEmployeeDTO.PresentAddressBangla = txtPresentAddressBangla.Text;
            objEmployeeDTO.PermanentAddressBangla = txtPermanentAddressBangla.Text;
            objEmployeeDTO.TinNo = txtTinNo.Text;
            objEmployeeDTO.MobileNo = txtMobileNo.Text;
            objEmployeeDTO.PhoneNo = txtPhoneNo.Text;
            objEmployeeDTO.EmailAddress = txtEmailAddress.Text;
            objEmployeeDTO.EmergencyContactNo = txtEmergencyContactNo.Text;
            objEmployeeDTO.NIDNo = txtNIDNo.Text; 
            objEmployeeDTO.BirthRegistrationNo = txtBirthRegistrationNo.Text;        
            objEmployeeDTO.FatherNameBangla = txtFatherNameBangla.Text;
            objEmployeeDTO.MotherNameBangla = txtMotherNameBangla.Text;

            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.UpdateEmployeeInfo(objEmployeeDTO);
            //txtEmployeeId.Text = EmpId;
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }
        
        public void clear()
        {
            lblMsg.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            txtAccountNo.Text = string.Empty;
            txtJoiningSalary.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtMotherName.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtMotherName.Text = string.Empty;

            txtPermanentAddress.Text = string.Empty;
            txtHusbandName.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtGrossSalary.Text = string.Empty;

            txtPresentAddress.Text = string.Empty;
            txtPresentAddressBangla.Text = string.Empty;
            txtPermanentAddressBangla.Text = string.Empty;
            txtTinNo.Text = string.Empty;
            txtReferenceName.Text = string.Empty;
            txtEmployeeNameBangla.Text = string.Empty;
            dtpResignDate.Text = string.Empty;
            txtCardNo.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            txtFirstSalary.Text = string.Empty;


            dtpDateOfBirth.Text = string.Empty;
            dtpEffectiveDate.Text = string.Empty;
            dtpJoiningDate.Text = string.Empty;
            dtpOrderDate.Text = string.Empty;
            txtGrossSalary.Text = string.Empty;
            txtEmergencyContactNo.Text = string.Empty;
            txtAllowanceFee.Text = string.Empty;

            if (chkAcftiveYn.Checked == true)
            {
                chkAcftiveYn.Checked = false;
            }

            if (ChkPaymentYn.Checked == true)
            {
                ChkPaymentYn.Checked = false;
            }

            txtPunchCode.Text = string.Empty;
            imgEmployee.ImageUrl = "";
            ImgSignature.ImageUrl = "";
            dtpConfirmDate.Text = "";
            txtBirthRegistrationNo.Text = "";
            txtNIDNo.Text = "";
            txtBKashNo.Text = "";
            txtRocketNo.Text = "";
            txtFatherNameBangla.Text = string.Empty;
            txtMotherNameBangla.Text = string.Empty;
        }

        public void loadCombo()
        {

            getGenderId();
            getMaritalStatusId();
            getReligionId();
            getBloodGroupId();

            getJobId();
            getUnitId();
            getSectionId();
            getDesignationId();
            getCatagoryId();

            //getDepartmentId();
            getNationalityId();
            geTitleId();

            getJobLocationId();
            getEmployeeTypeId();
            getPeriodtId();
            getShiftId();
            getPaymentTypeId();
            getOccurenceTypeId();
            getDivisionId();
            getDistrictId();
            getApprovedId();
            getJoiningDesignationId();
            //com: 25.02.2020
            //getGradeNo();
            //add: 25.02.2020
            GetGrade();
            getSupervisorId();
            getDepartmentId();
            getCatagoryId();
        }


        public void searchEmployeeInfo()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strEmpId = "";

            if (ddlEmpId.SelectedValue.ToString() != " ")
            {
                strEmpId = ddlEmpId.SelectedValue.ToString();
            }
            else
            {
                strEmpId = "";
            }

            objEmployeeDTO = objEmployeeBLL.searchEmployeeInfo(txtEmployeeId.Text, txtCardNo.Text, strHeadOfficeId, strBranchOfficeId, strEmpId);
                        
            txtEmployeeId.Text = objEmployeeDTO.EmployeeId;
            txtCardNo.Text = objEmployeeDTO.CardNo;
            txtEmployeeName.Text = objEmployeeDTO.EmployeeName;
            txtEmployeeNameBangla.Text = objEmployeeDTO.EmployeeNameBangla;
            txtFatherName.Text = objEmployeeDTO.FatherName;
            txtMotherName.Text = objEmployeeDTO.MotherName;
            dtpDateOfBirth.Text = objEmployeeDTO.DateOfBirth;
            dtpJoiningDate.Text = objEmployeeDTO.JoiningDate;
            dtpOrderDate.Text = objEmployeeDTO.OrderDate;
            
            if (objEmployeeDTO.AccountNo == "0")
            {
                txtAccountNo.Text = "";
            }
            else
            {
                txtAccountNo.Text = objEmployeeDTO.AccountNo;
            }
            
            //bank
            if (objEmployeeDTO.BankId == "0")
            {
                //getGenderId();
                ddlBank.SelectedValue = "";
            }
            else
            {
                ddlBank.SelectedValue = objEmployeeDTO.BankId;
            }
            
            txtTinNo.Text = objEmployeeDTO.TinNo;

            txtJoiningSalary.Text = objEmployeeDTO.JoiningSalary;


            if (objEmployeeDTO.GenderId == "0")
            {
                getGenderId();
            }
            else
            {
                ddlGenderId.SelectedValue = objEmployeeDTO.GenderId;
            }

            if (objEmployeeDTO.MaritalStatusId == "0")
            {
                getMaritalStatusId();

            }
            else
            {
                ddlMaritalStatusId.SelectedValue = objEmployeeDTO.MaritalStatusId;

            }

            if (objEmployeeDTO.DepartmentId == "0")
            {
                getDepartmentId();

            }
            else
            {
                ddlDepartmentId.SelectedValue = objEmployeeDTO.DepartmentId;
            }

            if (objEmployeeDTO.ReligionId == "0")
            {
                getReligionId();
            }
            else
            {
                ddlReligionId.SelectedValue = objEmployeeDTO.ReligionId;

            }
            if (objEmployeeDTO.BloodGroupId == "0")
            {
                getBloodGroupId();
            }
            else
            {
                ddlBloodGroupId.SelectedValue = objEmployeeDTO.BloodGroupId;
            }
            
            txtHusbandName.Text = objEmployeeDTO.HusbandName;
            if (objEmployeeDTO.MobileNo == "0")
                txtMobileNo.Text = "";
            else
                txtMobileNo.Text = objEmployeeDTO.MobileNo;
            if (objEmployeeDTO.PhoneNo == "0")
                txtPhoneNo.Text = "";
            else
                txtPhoneNo.Text = objEmployeeDTO.PhoneNo;
            txtEmailAddress.Text = objEmployeeDTO.EmailAddress;

            if (objEmployeeDTO.NationaLityId == "0")
            {
                getNationalityId();
            }
            else
            {
                ddlNationalityId.SelectedValue = objEmployeeDTO.NationaLityId;
            }

            if (objEmployeeDTO.TitleId == "0")
            {
                geTitleId();
            }
            else
            {
                ddlTitleId.SelectedValue = objEmployeeDTO.TitleId;
            }

            if (objEmployeeDTO.DistrictId == "0")
            {
                getDistrictId();
            }
            else
            {
                ddlDistrictId.SelectedValue = objEmployeeDTO.DistrictId;
            }

            if (objEmployeeDTO.DivisionId == "0")
            {
                getDivisionId();
            }
            else
            {
                ddlDivisionId.SelectedValue = objEmployeeDTO.DivisionId;
            }

            txtPresentAddress.Text = objEmployeeDTO.PresentAddress;
            txtPermanentAddress.Text = objEmployeeDTO.PermanentAddress;
            if (objEmployeeDTO.PresentAddressBangla == "N/A")
                txtPresentAddressBangla.Text = "";
            else
                txtPresentAddressBangla.Text = objEmployeeDTO.PresentAddressBangla;

            if (objEmployeeDTO.PermanentAddressBangla == "N/A")
                txtPermanentAddressBangla.Text = "";
            else
                txtPermanentAddressBangla.Text = objEmployeeDTO.PermanentAddressBangla;

            txtTinNo.Text = objEmployeeDTO.TinNo;
           
            if (objEmployeeDTO.JobTypeId == "0")
            {
                getJobId();
            }
            else
            {
                ddlJobTypeId.SelectedValue = objEmployeeDTO.JobTypeId;

            }

            dtpEffectiveDate.Text = objEmployeeDTO.EffectiveDate;
            dtpOrderDate.Text = objEmployeeDTO.OrderDate;

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
                getDesignationId();
            }
            else
            {
                ddlDesignationId.SelectedValue = objEmployeeDTO.DesignationId;
            }

            if (objEmployeeDTO.GradeNo == "0")
            {               
                    ddlGradeNo.SelectedValue = "";               
            }
            else
            {               
                    ddlGradeNo.SelectedValue = objEmployeeDTO.GradeNo;               
            }

            if (objEmployeeDTO.JoiningDesignationId == "0")
            {
                getJoiningDesignationId();

            }
            else
            {
                ddlJoiningDesignationId.SelectedValue = objEmployeeDTO.JoiningDesignationId;
            }
            
            if (objEmployeeDTO.CatagoryId == "0")
            {
                getCatagoryId();

            }
            else
            {
                ddlCatagoryId.SelectedValue = objEmployeeDTO.CatagoryId;
            }
            
            txtGrossSalary.Text = objEmployeeDTO.GrossSalary;

            if (objEmployeeDTO.PaymentTypeId == "0")
            {
                getPaymentTypeId();
            }
            else
            {
                ddlPaymentTypeId.SelectedValue = objEmployeeDTO.PaymentTypeId;
            }

            if (objEmployeeDTO.OccurenceTypeId == "0")
            {
                getOccurenceTypeId();
            }
            else
            {
                ddlOccurenceTypeId.SelectedValue = objEmployeeDTO.OccurenceTypeId;
            }

            if (objEmployeeDTO.ReportingTo == "0")
            {
                getSupervisorId();
            }
            else
            {
                ddlSupervisorId.SelectedValue = objEmployeeDTO.ReportingTo;
            }

            dtpResignDate.Text = objEmployeeDTO.ResignDate;
            ddlShiftId.SelectedValue = objEmployeeDTO.ShiftId;

            if (objEmployeeDTO.ApprovedBY == "0")
            {
                getApprovedId();
            }
            else
            {
                ddlApprovedBy.SelectedValue = objEmployeeDTO.ApprovedBY;
            }
            if (objEmployeeDTO.JobLocationId == "0")
            {
                getJobLocationId();
            }
            else
            {
                ddlJobLocationId.SelectedValue = objEmployeeDTO.JobLocationId;
            }
            
            txtReferenceName.Text = objEmployeeDTO.ReferenceBy;
            txtFirstSalary.Text = objEmployeeDTO.FirstSalary;
            
            dtpOrderDate.Text = objEmployeeDTO.OrderDate;
            dtpJoiningDate.Text = objEmployeeDTO.JoiningDate;
            dtpEffectiveDate.Text = objEmployeeDTO.EffectiveDate;

            ddlDesignationId.Text = objEmployeeDTO.DesignationId;

            if (objEmployeeDTO.LeaveYear == "0")
            {
            }
            else
            {
            }

            if (objEmployeeDTO.YearOfExperience == "0")
            {
                //nothing to do
            }
            else
            {
            }
            
            if (objEmployeeDTO.LeaveMonth == "0")
            {
                //nothing to do
            }
            else
            {
            }
            
            if (objEmployeeDTO.EmployeeActiveYn == "Y")
            {
                chkAcftiveYn.Checked = true;
            }
            else
            {
                chkAcftiveYn.Checked = false;
            }

            if (objEmployeeDTO.PaymentYn == "Y")
            {
                ChkPaymentYn.Checked = true;
            }
            else
            {
                ChkPaymentYn.Checked = false;
            }

            if (objEmployeeDTO.OccurenceTypeId == "0")
            {
                getOccurenceTypeId();
            }
            else
            {
                ddlOccurenceTypeId.SelectedValue = objEmployeeDTO.OccurenceTypeId;
            }
            
            txtEmergencyContactNo.Text = objEmployeeDTO.EmergencyContactNo;
            txtAllowanceFee.Text = objEmployeeDTO.AllowanceAmount;
            txtPunchCode.Text = objEmployeeDTO.PunchCode;
                        
            if (objEmployeeDTO.EmployeeTypeId == "0")
            {
                getEmployeeTypeId();
            }
            else
            {
                ddlEmployeeTypeId.SelectedValue = objEmployeeDTO.EmployeeTypeId;
            }


            if (objEmployeeDTO.TrainingPeriodId == "0")
            {
                getPeriodtId();
            }
            else
            {
                ddlTrainingPeriodId.SelectedValue = objEmployeeDTO.TrainingPeriodId;
            }


            if (objEmployeeDTO.PaymentTypeId == "0")
            {
                getPaymentTypeId();
            }
            else
            {
                ddlPaymentTypeId.SelectedValue = objEmployeeDTO.PaymentTypeId;
            }

            if (objEmployeeDTO.ApprovedBY == "0")
            {
                getApprovedId();
            }
            else
            {
                ddlApprovedBy.SelectedValue = objEmployeeDTO.ApprovedBY;
            }
            
            dtpConfirmDate.Text = objEmployeeDTO.ConfirmDate;
            txtResignCause.Text = objEmployeeDTO.ResignCasuse;
            if (objEmployeeDTO.NIDNo == "0")
                txtNIDNo.Text = "";
            else
                txtNIDNo.Text = objEmployeeDTO.NIDNo;
            if (objEmployeeDTO.BirthRegistrationNo == "0")
                txtBirthRegistrationNo.Text = "";
            else
                txtBirthRegistrationNo.Text = objEmployeeDTO.BirthRegistrationNo;
            if (objEmployeeDTO.BirthRegistrationNo == "0")
                txtBirthRegistrationNo.Text = "";
            else
                txtBirthRegistrationNo.Text = objEmployeeDTO.BirthRegistrationNo;
            if (objEmployeeDTO.BKashNo == "0")
                txtBKashNo.Text = "";
            else
                txtBKashNo.Text = objEmployeeDTO.BKashNo;
            if (objEmployeeDTO.RocketNo == "0")
                txtRocketNo.Text = "";
            else
                txtRocketNo.Text = objEmployeeDTO.RocketNo;
            if (objEmployeeDTO.FatherNameBangla == "0")
                txtFatherNameBangla.Text = "";
            else
                txtFatherNameBangla.Text = objEmployeeDTO.FatherNameBangla;
            if (objEmployeeDTO.MotherNameBangla == "0")
                txtMotherNameBangla.Text = "";
            else
                txtMotherNameBangla.Text = objEmployeeDTO.MotherNameBangla;

            if (objEmployeeDTO.SittingBranchOfficeId == "0")
            {
                GetSittingBranchOfficeId();
            }
            else
            {
                ddlSittingBranchOfficeId.SelectedValue = objEmployeeDTO.SittingBranchOfficeId;
            }
            txtIdCardNo.Text = objEmployeeDTO.IdCardNo;
            if (objEmployeeDTO.CompanyId == "0")
            {
                GetCompanyId();
            }
            else
            {
                ddlCompanyId.SelectedValue = objEmployeeDTO.CompanyId;
            }
        }
        public void searchEmployeeStatus()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strEmpId = "";

            if (ddlEmpId.SelectedValue.ToString() != " ")
            {
                strEmpId = ddlEmpId.SelectedValue.ToString();
            }
            else
            {
                strEmpId = "";
            }
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
                if (txtEmployeeId.Text == string.Empty)
                {

                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearchEmployee.Focus();
                    return;

                }
                else
                {
                    searchEmployeeInfo();
                    ReadOnlyYn();
                    imgEmployee.ImageUrl = "ImageHandler.ashx?employee_id=" + txtEmployeeId.Text;
                    ImgSignature.ImageUrl = "GenericImageHandler.ashx?employee_id=" + txtEmployeeId.Text + "&nvl=1";
                    searchEmployeeSummeryInformation();
                    
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }
                
        protected void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEmployee();
        }
        public void UpdateEmployee()
        {
            try
            {
                if (strHeadOfficeId == "441")
                {
                    if (ddlGenderId.Text == "")
                    {
                        string strMsg = "Please Select Employee Gender !!!";
                        MessageBox(strMsg);
                        ddlTitleId.Focus();
                        return;
                    }

                    else if (ddlTitleId.Text == "")
                    {
                        string strMsg = "Please Select Employee Title !!!";
                        MessageBox(strMsg);
                        ddlTitleId.Focus();
                        return;
                    }

                    else if (txtEmployeeName.Text == "")
                    {
                        string strMsg = "Please Enter Employee Name!!!";
                        MessageBox(strMsg);
                        txtEmployeeName.Focus();
                        return;
                    }
                    else if (dtpJoiningDate.Text == "")
                    {

                        string strMsg = "Please Enter Joinig Date!!!";
                        MessageBox(strMsg);
                        dtpJoiningDate.Focus();
                        return;
                    }

                    else if (ddlUnitId.Text == " ")
                    {

                        string strMsg = "Please Select Unit Name!!!";
                        MessageBox(strMsg);
                        ddlUnitId.Focus();
                        return;
                    }

                    else if (ddlSectionId.Text == " ")
                    {

                        string strMsg = "Please Select Section Name!!!";
                        MessageBox(strMsg);
                        ddlSectionId.Focus();
                        return;
                    }

                    else if (ddlCatagoryId.Text == " ")
                    {

                        string strMsg = "Please Select Catagory Name!!!";
                        MessageBox(strMsg);
                        ddlCatagoryId.Focus();
                        return;
                    }

                    else if (ddlDesignationId.Text == " ")
                    {

                        string strMsg = "Please Select Designation Name!!!";
                        MessageBox(strMsg);
                        ddlDesignationId.Focus();
                        return;
                    }
                    else if (dtpJoiningDate.Text == string.Empty)
                    {
                        string strMsg = "Please Enter Joining Date!!!";
                        MessageBox(strMsg);
                        dtpJoiningDate.Focus();
                        return;
                    }

                    else if (dtpEffectiveDate.Text == string.Empty)
                    {
                        string strMsg = "Please Enter Effective Date!!!";
                        MessageBox(strMsg);
                        dtpEffectiveDate.Focus();
                        return;
                    }

                    else if (dtpOrderDate.Text == string.Empty)
                    {
                        string strMsg = "Please Enter Order Date!!!";
                        MessageBox(strMsg);
                        dtpOrderDate.Focus();
                        return;
                    }
                    else if (ddlCompanyId.Text == " ")
                    {
                        string strMsg = "Please Select Company";
                        MessageBox(strMsg);
                        ddlCompanyId.Focus();
                        return;
                    }
                    else if (txtPunchCode.Text == string.Empty && (strBranchOfficeId == "103" || strBranchOfficeId == "101" || strBranchOfficeId == "102"))
                    {
                        string strMsg = "Please Enter Employee Punch Code!!!";
                        MessageBox(strMsg);
                        txtPunchCode.Focus();
                        return;
                    }
                    else if (ddlSittingBranchOfficeId.Text == " ")
                    {
                        string strMsg = "Please Select Sitting Branch!!!";
                        MessageBox(strMsg);
                        ddlSittingBranchOfficeId.Focus();
                        return;
                    }
                    else
                    {
                        //Confirmation date calculation
                        if (!string.IsNullOrEmpty(dtpJoiningDate.Text) && string.IsNullOrEmpty(dtpConfirmDate.Text))
                        {
                            CultureInfo MyCulture = new CultureInfo("bn-BD");
                            DateTime joingDate = DateTime.Parse(dtpJoiningDate.Text, MyCulture);
                            DateTime confirmDate = joingDate.AddMonths(6);
                            dtpConfirmDate.Text = confirmDate.ToString("dd/MM/yyyy");
                        }
                        //end

                        UpdateEmployeeInfo();
                        saveImage();
                        if (strHeadOfficeId == "441")
                        {
                            chkPDFFile();
                        }
                        searchEmployeeInfo();
                    }
                }

                else
                {
                    if (txtCardNo.Text == "")
                    {
                        string strMsg = "Please Enter Card No!!!";
                        MessageBox(strMsg);
                        txtCardNo.Focus();
                        return;
                    }

                    else if (ddlGenderId.Text == " ")
                    {
                        string strMsg = "Please Select Employee Gender !!!";
                        MessageBox(strMsg);
                        ddlTitleId.Focus();
                        return;

                    }

                    else if (ddlTitleId.Text == " ")
                    {
                        string strMsg = "Please Select Employee Title !!!";
                        MessageBox(strMsg);
                        ddlTitleId.Focus();
                        return;
                    }

                    else if (txtEmployeeName.Text == "")
                    {
                        string strMsg = "Please Enter Employee Name!!!";
                        MessageBox(strMsg);
                        txtEmployeeName.Focus();
                        return;
                    }
                    else if (dtpJoiningDate.Text == "")
                    {

                        string strMsg = "Please Enter Joinig Date!!!";
                        MessageBox(strMsg);
                        dtpJoiningDate.Focus();
                        return;
                    }

                    else if (ddlUnitId.Text == " ")
                    {

                        string strMsg = "Please Select Unit Name!!!";
                        MessageBox(strMsg);
                        ddlUnitId.Focus();
                        return;
                    }

                    else if (ddlSectionId.Text == " ")
                    {

                        string strMsg = "Please Select Section Name!!!";
                        MessageBox(strMsg);
                        ddlSectionId.Focus();
                        return;
                    }

                    else if (ddlCatagoryId.Text == " ")
                    {

                        string strMsg = "Please Select Catagory Name!!!";
                        MessageBox(strMsg);
                        ddlCatagoryId.Focus();
                        return;
                    }

                    else if (ddlDesignationId.Text == " ")
                    {

                        string strMsg = "Please Select Designation Name!!!";
                        MessageBox(strMsg);
                        ddlDesignationId.Focus();
                        return;
                    }

                    else if (txtJoiningSalary.Text == string.Empty)
                    {
                        string strMsg = "Please Enter Joining Salary!!!";
                        MessageBox(strMsg);
                        txtJoiningSalary.Focus();
                        return;
                    }

                    else if (txtGrossSalary.Text == string.Empty)
                    {
                        string strMsg = "Please Enter Gross Salary!!!";
                        MessageBox(strMsg);
                        txtGrossSalary.Focus();
                        return;
                    }
                    else if (dtpJoiningDate.Text == string.Empty)
                    {
                        string strMsg = "Please Enter Joining Date!!!";
                        MessageBox(strMsg);
                        dtpJoiningDate.Focus();
                        return;
                    }

                    else if (dtpEffectiveDate.Text == string.Empty)
                    {
                        string strMsg = "Please Enter Effective Date!!!";
                        MessageBox(strMsg);
                        dtpEffectiveDate.Focus();
                        return;
                    }

                    else if (dtpOrderDate.Text == string.Empty)
                    {
                        string strMsg = "Please Enter Order Date!!!";
                        MessageBox(strMsg);
                        dtpOrderDate.Focus();
                        return;
                    }

                    else if (ddlOccurenceTypeId.Text == " ")
                    {
                        string strMsg = "Please Select Occurence Type!!!";
                        MessageBox(strMsg);
                        ddlOccurenceTypeId.Focus();
                        return;
                    }
                    else if (txtPunchCode.Text == string.Empty && (strBranchOfficeId == "103" || strBranchOfficeId == "101" || strBranchOfficeId == "102"))
                    {
                        string strMsg = "Please Enter Employee Punch Code!!!";
                        MessageBox(strMsg);
                        txtPunchCode.Focus();
                        return;
                    }
                    else if (ddlSittingBranchOfficeId.Text == " ")
                    {
                        string strMsg = "Please Select Sitting Branch!!!";
                        MessageBox(strMsg);
                        ddlSittingBranchOfficeId.Focus();
                        return;
                    }
                    else if (ddlCompanyId.Text == " ")
                    {
                        string strMsg = "Please Select Company";
                        MessageBox(strMsg);
                        ddlCompanyId.Focus();
                        return;
                    }
                    else
                    {
                        UpdateEmployeeInfo();
                        saveImage();
                        searchEmployeeInfo();
                    }
                }
                ImgSignature.ImageUrl = "GenericImageHandler.ashx?employee_id=" + txtEmployeeId.Text + "&nvl=1";
            }
            catch (Exception ex)
            {
                throw new Exception("Error :" + ex.Message);
            }
        }

        private void saveImage()
        {
            saveImage(FileUpload1);
            saveImage(FileSignature);
        }

        public void chkPDFFile()
        {

            string fileName = Server.HtmlEncode(FileUpload2.FileName);
            string extension = System.IO.Path.GetExtension(fileName);
            // Allow only files with .doc or .xls extensions
            // to be uploaded.
            if (extension == ".pdf")
            {
                uploadEmployeeDesFile();

            }
            else
            {
            }
        }


        public void uploadEmployeeDesFile()
        {
            try
            {

                if (txtEmployeeId.Text == " ")
                {
                    string strMsg = "Please Select Employee From The GridView!!!";
                    txtEmployeeId.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else
                {

                    EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                    EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                    HttpPostedFile imgFile = FileUpload2.PostedFile;

                    string strContentType = FileUpload2.PostedFile.ContentType;

                    string strFileName = FileUpload2.PostedFile.FileName;
                    string strFileNamePath = Path.GetFileName(strFileName);
                    string ext = Path.GetExtension(strFileNamePath);
                    txtFileName.Text = FileUpload2.FileName;


                    FileInfo fi = new System.IO.FileInfo(FileUpload2.PostedFile.FileName);

                    string fileName = fi.Name;
                    BinaryReader b = new BinaryReader(imgFile.InputStream);
                    byte[] byteArray = b.ReadBytes(imgFile.ContentLength);


                    string fileSize = Convert.ToBase64String(byteArray);
                    if (FileUpload2.PostedFile != null && FileUpload2.PostedFile.ContentLength > 0)
                    {


                        objEmployeeDTO.EmployeeId = txtEmployeeId.Text;

                        objEmployeeDTO.FileName = strFileName;
                        objEmployeeDTO.FileSize = fileSize;

                        objEmployeeDTO.UpdateBy = strEmployeeId;
                        objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                        objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                        string strMsg = objEmployeeBLL.uploadEmployeeDesFile(objEmployeeDTO);
                        //MessageBox(strMsg);
                    }
                }

            }

            catch (Exception ex)
            {

                FileUpload2.Dispose();
                FileUpload2.FileContent.Dispose();
                FileUpload2.PostedFile.InputStream.Close();
                FileUpload2.PostedFile.InputStream.Dispose();
                lblMsg.Text = ex.Message;

            }

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
                    if (file.ID == "FileSignature")
                    {
                        objEmployeeDTO.Signature = fileSize.ToString();
                        objEmployeeDTO.SignatureImageName = strFileName;
                        objEmployeeDTO.SignatureImageType = strImageExtension;
                        strMsg = objEmployeeBLL.SaveSignatureImage(objEmployeeDTO);
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
            loadCombo();
            searchEmployeeSummeryInformation();
            Session["strID"] = null;
            txtFirstSalary.ReadOnly = false;
            txtGrossSalary.ReadOnly = false;
            txtJoiningSalary.ReadOnly = false;
            txtIdCardNo.Text = string.Empty;

        }

        //protected void ddlSectionId_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}


        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
            searchEmployeeInfo();
        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //getGradeNo();
            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text.Replace("&#168;", "¨").Replace("&#182;", "¶")
                    .Replace("&#214;", "Ö").Replace("&#221;", "Ý").Replace("&#247;", "÷").Replace("&#169;", "©").Replace("&#177;", "±")
                    .Replace("&#172;", "¬").Replace("&#170;", "ª").Replace("&#243;", "ó").Replace("&#164;", "¤").Replace("&#248;", "ø")
                    .Replace("&#250;", "ú").Replace("&#219;", "Û").Replace("&#194;", "Â").Replace("&#196;", "Ä").Replace("&#175;", "¯")
                    .Replace("&amp;", "&").Replace("&#236;", "ì").Replace("&#173;", "­­­­­­­").Replace("&#183;", "­­­­­­­·").Replace("&#191;&#191;&#191;&#191;&#191;&#191;&#191;&#191;", "­­­­­­­¿¿¿¿¿¿¿¿")
                    .Replace("&#191;", "¿");

            string designationId = gvEmployeeList.SelectedRow.Cells[5].Text;
            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            
            searchEmployeeInfo();
            ReadOnlyYn();
            searchEmployeeSummeryInformation();
            imgEmployee.ImageUrl = "ImageHandler.ashx?EMPLOYEE_ID=" + txtEmployeeId.Text;
            ImgSignature.ImageUrl = "GenericImageHandler.ashx?employee_id=" + txtEmployeeId.Text + "&nvl=1";
            txtEmployeeId.Focus();

            //SetGrade(designationId);
        }




        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);
            }
        }
        protected void gvEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadEmployeeRecord();

            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
            }
            if (dt != null)
            {
                DataView dataView = new DataView(dt);
                // dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                gvEmployeeList.DataSource = dataView;
                gvEmployeeList.DataBind();
            }
        }

        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }

      

        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        #endregion
        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            searchEmployeeSummeryInformation();
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {


            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;

            string strEmployeeId = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string strDesignation = GridView1.SelectedRow.Cells[4].Text.Replace("&#168;", "¨").Replace("&#182;", "¶")
                    .Replace("&#214;", "Ö").Replace("&#221;", "Ý").Replace("&#247;", "÷").Replace("&#169;", "©").Replace("&#177;", "±")
                    .Replace("&#172;", "¬").Replace("&#170;", "ª").Replace("&#243;", "ó").Replace("&#164;", "¤").Replace("&#248;", "ø")
                    .Replace("&#250;", "ú").Replace("&#219;", "Û").Replace("&#194;", "Â").Replace("&#196;", "Ä").Replace("&#175;", "¯")
                    .Replace("&amp;", "&").Replace("&#236;", "ì").Replace("&#173;", "­­­­­­­").Replace("&#183;", "­­­­­­­·").Replace("&#191;&#191;&#191;&#191;&#191;&#191;&#191;&#191;", "­­­­­­­¿¿¿¿¿¿¿¿")
                    .Replace("&#191;", "¿");

            txtSL.Text = Convert.ToString(strRowId);
            txtEmployeeId.Text = strEmployeeId;



            searchEmployeeInfo();
            ReadOnlyYn();
            txtEmployeeId.Focus();
            imgEmployee.ImageUrl = "ImageHandler.ashx?employee_id=" + txtEmployeeId.Text;
            ImgSignature.ImageUrl = "GenericImageHandler.ashx?employee_id=" + txtEmployeeId.Text + "&nvl=1";

            //disableText();
        }




        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }


        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

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





        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

            //LookUpDTO objLookUpDTO = new LookUpDTO();
            //LookUpBLL objLookUpBLL = new LookUpBLL();

            //DataTable dt = new DataTable();
            //dt = objLookUpBLL.loadEmployeeRecord();


            //if (dt.Rows.Count > 0)
            //{
            //    GridView1.DataSource = dt;
            //    GridView1.DataBind();
            //}
            //if (dt != null)
            //{
            //    DataView dataView = new DataView(dt);
            //    // dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            //    GridView1.DataSource = dataView;
            //    GridView1.DataBind();
            //}
        }

        //private string GridViewSortDirection
        //{
        //    get { return ViewState["SortDirection"] as string ?? "DESC"; }
        //    set { ViewState["SortDirection"] = value; }
        //}

        //private string ConvertSortDirectionToSql(SortDirection sortDirection)
        //{
        //    switch (GridViewSortDirection)
        //    {
        //        case "ASC":
        //            GridViewSortDirection = "DESC";
        //            break;

        //        case "DESC":
        //            GridViewSortDirection = "ASC";
        //            break;
        //    }

        //    return GridViewSortDirection;
        //}


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //gvEmployeeList.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }

        #endregion
     
        protected void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                GvSecurityLog.DataSource = null;
                GvSecurityLog.DataBind();

                searchEmployeeInformation();
                gvEmployeeList.SelectedIndex = 0;
                goToNextRecord();
                
                ReadOnlyYn();
                imgEmployee.ImageUrl = "ImageHandler.ashx?EMPLOYEE_ID=" + txtEmployeeId.Text;
                ImgSignature.ImageUrl = "GenericImageHandler.ashx?employee_id=" + txtEmployeeId.Text + "&nvl=1";
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
        
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {

                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearchEmployee.Focus();
                    return;
                }
                else
                {

                    goToNextRecord();
                    ReadOnlyYn();
                    imgEmployee.ImageUrl = "ImageHandler.ashx?employee_id=" + txtEmployeeId.Text;
                    ImgSignature.ImageUrl = "GenericImageHandler.ashx?employee_id=" + txtEmployeeId.Text + "&nvl=1";

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

                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearchEmployee.Focus();
                    return;
                }
                else
                {

                    goToPreviousRecord();
                    ReadOnlyYn();
                    imgEmployee.ImageUrl = "ImageHandler.ashx?employee_id=" + txtEmployeeId.Text;
                    ImgSignature.ImageUrl = "GenericImageHandler.ashx?employee_id=" + txtEmployeeId.Text + "&nvl=1";
                    //disableText();

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
        
   
        public void employeeSlipBng()
        {

            CrystalReportViewer CrystalReportViewer1 = new CrystalReportViewer();
            CrystalReportViewer1.AutoDataBind = true;

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.EmployeeId = txtEmpId.Text;

                if (ddlEmpSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlEmpSectionId.SelectedValue.ToString();
                }
                else
                {

                    objReportDTO.SectionId = "";
                }



                if (ddlEmpUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlEmpUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";

                }



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeSlipBng.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                DataSet ds = new DataSet();

                ds = (objReportBLL.employeeSlipBng(objReportDTO));
                rd.SetDataSource(ds);
                rd.SetDatabaseLogon("erp", "erp");
                                
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                //string url = "CrystalView.aspx?ID=" + "324rsjfaiosafd";
                //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "NewWindow", "window.open('" + url + "','_blank','height=600,width=900,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no' );", true);



                reportMaster();
                CrystalReportViewer1.Dispose();
                CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
            catch (Exception ex)
            {

                CrystalReportViewer1.Dispose();
                CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

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

            //this.CrystalReportViewer1.ReportSource = null;
            //CrystalReportViewer1.Dispose();

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

        protected void btnSlipBng_Click(object sender, EventArgs e)
        {
            try
            {
                employeeSlipBng();
            }
            catch (Exception ex)
            {
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

            //int len = strGrossSalary.Length;
            //byte[] cipherBytes = Convert.FromBase64String(strGrossSalary);

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

        protected void ddlJobLocationId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
 
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

   

      

       

        protected void GvSecurityLog_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //1
                
                TableCell cell_designation_id_chg = e.Row.Cells[6];
                int designation_id_chg = int.Parse(cell_designation_id_chg.Text);

                if (designation_id_chg == 1)
                {
                    TableCell DESIGNATION_NAME = e.Row.Cells[21];
                    DESIGNATION_NAME.BackColor = Color.LightBlue;
                }

                //2
                TableCell cell_grade_id_chg = e.Row.Cells[7];
                int grade_id_chg = int.Parse(cell_grade_id_chg.Text);

                if (grade_id_chg == 1)
                {
                    TableCell GRADE_NO = e.Row.Cells[22];
                    GRADE_NO.BackColor = Color.LightBlue;
                }

                //3
                TableCell cell_first_salary_chg = e.Row.Cells[11];
                int first_salary_chg = int.Parse(cell_first_salary_chg.Text);

                if (first_salary_chg == 1)
                {
                    TableCell first_salary = e.Row.Cells[23];
                    first_salary.BackColor = Color.LightBlue;
                }

                //4
                TableCell cell_gross_salary_chg = e.Row.Cells[12];
                int gross_salary_chg = int.Parse(cell_gross_salary_chg.Text);

                if (gross_salary_chg == 1)
                {
                    TableCell gross_salary = e.Row.Cells[24];
                    gross_salary.BackColor = Color.LightBlue;
                }

                //5
                TableCell cell_joining_date_chg = e.Row.Cells[8];
                int joining_date_chg = int.Parse(cell_joining_date_chg.Text);

                if (joining_date_chg == 1)
                {
                    TableCell JOINING_DATE = e.Row.Cells[25];
                    JOINING_DATE.BackColor = Color.LightBlue;
                }

                //5
                TableCell cell_account_no_chg = e.Row.Cells[4];
                int account_no_chg = int.Parse(cell_account_no_chg.Text);

                if (account_no_chg == 1)
                {
                    TableCell ACCOUNT_NO = e.Row.Cells[26];
                    ACCOUNT_NO.BackColor = Color.LightBlue;
                }

                //5
                TableCell cell_bkash_no_chg = e.Row.Cells[5];
                int bkash_no_chg = int.Parse(cell_bkash_no_chg.Text);

                if (bkash_no_chg == 1)
                {
                    TableCell bkash_no = e.Row.Cells[27];
                    bkash_no.BackColor = Color.LightBlue;
                }
            }
        }

      

     

        [WebMethod]
        public static void BrowserCloseMethod()
        {
            try
            {
                HttpContext.Current.Session["strEmployeeId"] = null;

                HttpContext.Current.Session["strSectionId"] = null;
                HttpContext.Current.Session["strDepartmentId"] = null;
                HttpContext.Current.Session["strDesignationId"] = null;
                HttpContext.Current.Session["strUnitId"] = null;
                HttpContext.Current.Session["strCatagoryId"] = null;
                HttpContext.Current.Session["strHeadOfficeId"] = null;
                HttpContext.Current.Session["strBranchOfficeId"] = null;
                HttpContext.Current.Session["strLoginDay"] = null;
                HttpContext.Current.Session["strLoginMonth"] = null;
                HttpContext.Current.Session["strLoginDate"] = null;

                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Session.RemoveAll();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.Cache.SetNoStore();
                FormsAuthentication.SignOut();

            }

            catch (Exception ex)
            {
                //throw new Exception("Error : " + ex.Message);
            }
        }

        protected void BtnUpdateEmployeeInfo1_Click(object sender, EventArgs e)
        {
            UpdateEmployee();
        }
    }
}