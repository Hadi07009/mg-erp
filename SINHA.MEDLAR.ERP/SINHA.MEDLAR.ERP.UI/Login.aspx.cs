using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.Diagnostics;
using System.Web.Security;
using System.Globalization;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                getDate();
                getSoftwareVersion();
                txtEmployeeName.Focus();
            }
            if (Page.IsPostBack == false)
            {
                sessionEmpty();
            }
            txtEmployeeName.Attributes.Add("onkeypress", "return controlEnter('" + txtPassword.ClientID + "', event)");
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
            Session["strSoftId"] = null;
        }

        public void ClearSession(string _suffix)
        {
            Session["strEmployeeId" + _suffix] = null;
            Session["strSectionId" + _suffix] = null;
            Session["strDepartmentId" + _suffix] = null;
            Session["strDesignationId" + _suffix] = null;
            Session["strUnitId" + _suffix] = null;
            Session["strCatagoryId" + _suffix] = null;
            Session["strHeadOfficeId" + _suffix] = null;
            Session["strBranchOfficeId" + _suffix] = null;
            Session["strLoginDay" + _suffix] = null;
            Session["strLoginMonth" + _suffix] = null;
            Session["strLoginDate" + _suffix] = null;
            Session["strSoftId" + _suffix] = null;
        }

        public void getSoftwareVersion()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            objLookUpDTO = objLookUpBLL.getSoftwareVersion();
            lblSoftwareVersion.Text = "Version : "  + objLookUpDTO.VersionCode;
        }
      
        public void getDate()
        {
            lblDate.Text = System.DateTime.Today.ToString("dd-MMM-yyyy");
        }
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        #endregion
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmployeeName.Text == string.Empty)
            {
                string strMsg = "Please Enter Employee Name!!!";
                MessageBox(strMsg);
                txtEmployeeName.Focus();
                return; 
            }
            else if (txtPassword.Text == string.Empty)
            {
                string strMsg = "Please Enter Employee Password!!!";
                MessageBox(strMsg);
                txtPassword.Focus();
                return;
            }
            else
            {
                checkValidUser();
            }
        }

        //Original
        public void checkValidUser()
        {

            LoginDTO objLoginDTO = new LoginDTO();
            LoginBLL objLoginBLL = new LoginBLL();
            string strEmployeeName = "";
            string strEmployeePass = "";
            string strSoftId = "";

            strEmployeeName = txtEmployeeName.Text;
            strEmployeePass = txtPassword.Text;
            string roles = string.Empty;
            getClientIP();
            objLoginDTO = objLoginBLL.checkValidUser(strEmployeeName, strEmployeePass, txtIpAddress.Text);

            if (objLoginDTO.Message.Equals("TRUE"))
            {
                this.Context.Session["strEmployeeId"] = (string)objLoginDTO.EmployeeId;
                this.Context.Session["strSectionId"] = (string)objLoginDTO.SectionId;

                this.Context.Session["strDesignationId"] = (string)objLoginDTO.DesignationId;
                this.Context.Session["strUnitId"] = (string)objLoginDTO.UnitId;
                this.Context.Session["strCatagoryId"] = (string)objLoginDTO.CatagoryId;
                this.Context.Session["strHeadOfficeId"] = (string)objLoginDTO.HeadOfficeId;
                this.Context.Session["strBranchOfficeId"] = (string)objLoginDTO.BranchOfficeId;
                this.Context.Session["strEmployeeTypeId"] = (string)objLoginDTO.EmployeeTypeId;
                this.Context.Session["strLoginDay"] = (string)objLoginDTO.LoginDay;
                this.Context.Session["strLoginMonth"] = (string)objLoginDTO.LoginMonth;
                this.Context.Session["strLoginYear"] = (string)objLoginDTO.LoginYear;
                this.Context.Session["strLoginDate"] = (string)objLoginDTO.LoginDate;
                this.Context.Session["strHeadOfficeName"] = (string)objLoginDTO.HeadOfficeName;
                this.Context.Session["strBranchOfficeName"] = (string)objLoginDTO.BranchOfficeName;
                this.Context.Session["strSoftId"] = (string)objLoginDTO.SoftId;

                this.Context.Session["strEmployeeName"] = strEmployeeName;
                this.Context.Session["strEmployeePass"] = strEmployeePass;
                if (chkRemember.Checked == true)
                {
                    Response.Cookies["strEmployeeName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["strEmployeePass"].Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    Response.Cookies["strEmployeeName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["strEmployeePass"].Expires = DateTime.Now.AddDays(-1);
                }
                Response.Cookies["strEmployeeName"].Value = txtEmployeeName.Text.Trim();
                Response.Cookies["strEmployeePass"].Value = txtPassword.Text.Trim();
                Server.Transfer("Index.aspx", false);
            }
            else
            {
                string strMsg = "EMPLOYEE NAME OR PASSWORD IS INVALID, PLEASE TRY AGAIN!!!";
                txtPassword.Focus();
                MessageBox(strMsg);
            }
        }

        //Newly Added for Session
        //public void checkValidUser()
        //{
        //    LoginDTO objLoginDTO = new LoginDTO();
        //    LoginBLL objLoginBLL = new LoginBLL();

        //    string strEmployeeName = "";
        //    string strEmployeePass = "";

        //    strEmployeeName = txtEmployeeName.Text;
        //    strEmployeePass = txtPassword.Text;
        //    string roles = string.Empty;

        //    getClientIP();
        //    objLoginDTO = objLoginBLL.checkValidUser(strEmployeeName, strEmployeePass, txtIpAddress.Text);

        //    if (objLoginDTO.Message.Equals("TRUE"))
        //    {
        //        string suffix = "_" + objLoginDTO.BranchOfficeId;

        //        ClearSession(suffix);
        //        HttpCookie cookie = new HttpCookie("eid");
        //        cookie.Value = objLoginDTO.EmployeeId;
        //        cookie.Expires = DateTime.Now.AddHours(1);

        //        this.Context.Session["strEmployeeId" + suffix] = (string)objLoginDTO.EmployeeId;
        //        this.Context.Session["strSectionId" + suffix] = (string)objLoginDTO.SectionId;
                
        //        this.Context.Session["strDesignationId" + suffix] = (string)objLoginDTO.DesignationId;
        //        this.Context.Session["strUnitId" + suffix] = (string)objLoginDTO.UnitId;
        //        this.Context.Session["strCatagoryId" + suffix] = (string)objLoginDTO.CatagoryId;
        //        this.Context.Session["strHeadOfficeId" + suffix] = (string)objLoginDTO.HeadOfficeId;
        //        this.Context.Session["strBranchOfficeId" + suffix] = (string)objLoginDTO.BranchOfficeId;
        //        this.Context.Session["strEmployeeTypeId" + suffix] = (string)objLoginDTO.EmployeeTypeId;
        //        this.Context.Session["strLoginDay" + suffix] = (string)objLoginDTO.LoginDay;
        //        this.Context.Session["strLoginMonth" + suffix] = (string)objLoginDTO.LoginMonth;
        //        this.Context.Session["strLoginYear" + suffix] = (string)objLoginDTO.LoginYear;
        //        this.Context.Session["strLoginDate" + suffix] = (string)objLoginDTO.LoginDate;

        //        this.Context.Session["strHeadOfficeName" + suffix] = (string)objLoginDTO.HeadOfficeName;
        //        this.Context.Session["strBranchOfficeName" + suffix] = (string)objLoginDTO.BranchOfficeName;
        //        this.Context.Session["strSoftId" + suffix] = (string)objLoginDTO.SoftId;

        //        this.Context.Session["strEmployeeName" + suffix] = strEmployeeName;
        //        this.Context.Session["strEmployeePass" + suffix] = strEmployeePass;
                
        //        if (chkRemember.Checked == true)
        //        {                  
        //            Response.Cookies["strEmployeeName" + suffix].Expires = DateTime.Now.AddDays(30);
        //            Response.Cookies["strEmployeePass" + suffix].Expires = DateTime.Now.AddDays(30);
        //        }
        //        else
        //        {
        //            Response.Cookies["strEmployeeName" + suffix].Expires = DateTime.Now.AddDays(-1);
        //            Response.Cookies["strEmployeePass" + suffix].Expires = DateTime.Now.AddDays(-1);
        //        }

        //        Response.Cookies["strEmployeeName" + suffix].Value = txtEmployeeName.Text.Trim();
        //        Response.Cookies["strEmployeePass" + suffix].Value = txtPassword.Text.Trim();

        //       Server.Transfer("Index.aspx", false);            
        //    }
        //    else
        //    {
        //        string strMsg = "EMPLOYEE NAME OR PASSWORD IS INVALID, PLEASE TRY AGAIN!!!";
        //        txtPassword.Focus();
        //        MessageBox(strMsg);
        //    }
        //}

        public void getLanIPAddress()
        {
            String ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            string strIPAddress = ip.Replace("::ffff:", "");
            txtIpAddress.Text = strIPAddress;
        }

        protected void getClientIP()
        {
            string VisitorsIPAddr = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }
            txtIpAddress.Text = VisitorsIPAddr;
        }

        public string GetMacAddress(string IPAddress)
        {
            string strMacAddress = string.Empty;
            try
            {
                string strTempMacAddress = string.Empty;
                ProcessStartInfo objProcessStartInfo = new ProcessStartInfo();
                Process objProcess = new Process();
                objProcessStartInfo.FileName = "nbtstat";
                objProcessStartInfo.RedirectStandardInput = false;
                objProcessStartInfo.RedirectStandardOutput = true;
                objProcessStartInfo.Arguments = "-A " + IPAddress;
                objProcessStartInfo.UseShellExecute = false;
                objProcess = Process.Start(objProcessStartInfo);
                int Counter = -1;
                while (Counter <= -1)
                {
                    Counter = strTempMacAddress.Trim().ToLower().IndexOf("mac address", 0);
                    if (Counter > -1)
                    {
                        break;
                    }
                    strTempMacAddress = objProcess.StandardOutput.ReadLine();
                }
                objProcess.WaitForExit();
                strMacAddress = strTempMacAddress.Trim();
            }
            catch (Exception Ex)
            {
            }
            return strMacAddress;
        }

        public string getclientIPAddress()
        {
            string result = string.Empty;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                result = ipRange[0];
                txtIpAddress.Text = result;
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                txtIpAddress.Text = result;
            }
            return result;
        }

        protected void tmrUpdate_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("T");
        }
        
        public void getClientIPAddress()
        {
            String UserIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(UserIP))
            {
                lblCountryCode.Text = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
        }
        
    public static CultureInfo ResolveCulture()
        {
            string[] languages = HttpContext.Current.Request.UserLanguages;
            if (languages == null || languages.Length == 0)
                return null;
            try
            {
                string language = languages[0].ToLowerInvariant().Trim();
                return CultureInfo.CreateSpecificCulture(language);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        public static RegionInfo ResolveCountry()
        {
            CultureInfo culture = ResolveCulture();
            if (culture != null)
                return new RegionInfo(culture.LCID);
            return null;
        }
    }
}