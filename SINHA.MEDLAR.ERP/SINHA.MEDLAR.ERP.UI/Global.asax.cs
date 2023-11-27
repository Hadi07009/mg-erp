using FluentScheduler;
using SINHA.MEDLAR.ERP.UI.FluentSchedulers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SINHA.MEDLAR.ERP.UI
{
    public class Global : System.Web.HttpApplication
    {
                
        protected void Application_Start(object sender, EventArgs e)
        {
           // Application["hits"] = 0;

            FluentRegistry myRegistry = new FluentRegistry();
            JobManager.Initialize(myRegistry);
            

        }

        protected void Session_Start(object sender, EventArgs e)
        {
           // Application["hits"] = Int32.Parse(Application["hits"].ToString()) + 1;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext currentContext = (sender as HttpApplication).Context;
           
           
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

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
            Response.Redirect("Login.aspx");
        }

        public static string FooterText()
        {
            string ss = "SINHA_MEDLAR ERP";
            return ss;
        }
        public static string DateAndTimeDisplay()
        {
            string ss = System.DateTime.Now.ToString("dddd, MMMM dd, yyyy");
            return ss;
        }

      

        #endregion
    }
}