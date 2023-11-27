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
using System.Diagnostics;
using System.IO;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class DatabaseBackup : System.Web.UI.Page
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
                getOfficeName();
                loadUserPassSchma();
            }

            if (IsPostBack)
            {

                loadSesscion();

            }


           
        }

        #region "Function"

        public void loadUserPassSchma()
        {

            txtUserName.Text = "ERP";
            txtUserPass.Text = "ERP";
            txtSchema.Text = "ORCL";

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



        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnBackup_Click(object sender, EventArgs e)
        {
            //## Settings
            //Path to store the oracle dump

            DateTime Time = DateTime.Now;
            int year = Time.Year;
            int month = Time.Month;
            int day = Time.Day;
            int hour = Time.Hour;
            int min = Time.Minute;
            int second = Time.Second;
            int millisecond = Time.Millisecond;

            string path = txtFilePath.Text;
            path = path + day + "-" + month + "-" + year + "-" + hour + "-" + min + "-" + second + "-" + millisecond;

            //your ORACLE_HOME enviroment variable must be setted or you need to set the path here:
            string oracleHome = Environment.GetEnvironmentVariable("ORACLE_HOME");
            string oracleUser = txtUserName.Text;
            string oraclePassword = txtUserPass.Text;
            string oracleSID = txtSchema.Text;
            //###

            ProcessStartInfo psi = new ProcessStartInfo();
            //psi.FileName = "C:/oracle/product/10.2.0/db_1/BIN/exp.exe";
            //psi.RedirectStandardInput = false;
            //psi.RedirectStandardOutput = true;

            //psi.Arguments = string.Format( oracleUser + "/" + oraclePassword + "@" + oracleSID + " FULL=y FILE=" + path + ".dmp");

            ////psi.Arguments = string.Format("exp USERID=ERP/ERP  FULL=y FILE=" + path + ".dmp CONSISTENT=y GRANTS=y BUFFER=100000 rows = Yes");
            ////psi.Arguments = string.Format("exp USERID=gams/gams@XE  FILE=" + path + ".dmp TABLES=(t)");
            //psi.UseShellExecute = false;

            //Process process = Process.Start(psi);
            //process.WaitForExit();
            //process.Close();
            //MessageBox("Database Backup Completed Successfully");




            //Exp is the tool used to export data.
            //this tool is inside $ORACLE_HOME\bin directory
            psi.FileName = Path.Combine(oracleHome, "bin", "exp");
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            string dumpFile = Path.Combine(path + ".dmp");
            //The command line is: exp user/password@database file=backupname.dmp [OPTIONS....]
            psi.Arguments = string.Format(oracleUser + "/" + oraclePassword + "@" + oracleSID + " FULL=y FILE=" + dumpFile);
            psi.UseShellExecute = false;

            Process process = Process.Start(psi);
            process.WaitForExit();
            process.Close();
            MessageBox("Database Backup Completed Successfully");
           
        }
    }
}