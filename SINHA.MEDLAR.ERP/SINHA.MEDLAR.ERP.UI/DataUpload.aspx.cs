using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.VisualBasic.FileIO;
using System.Data;

using SINHA.MEDLAR.HR.DTO;
using SINHA.MEDLAR.HR.BLL;
using System.IO;
using System.Web.Security;

namespace SINHA.MEDLAR.HR.UI
{
    public partial class DataUpload : System.Web.UI.Page
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
            }

            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
            {
                uploadEmpLogDate();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }
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
            Session.Clear();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx", true);

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


        public void uploadEmpLogDate()
        {

            if (FileUpload1.HasFile)
            {

                string strContentType = FileUpload1.PostedFile.ContentType;
                string strFileName = FileUpload1.FileName;
                if (File.Exists(strFileName))
                {
                    File.Delete(strFileName);
                }
                string strPath = Server.MapPath("~/Data Capture/" + FileUpload1.FileName);
                FileUpload1.SaveAs(strPath);
                txtFilePath.Text = strPath;
                txtFileName.Text = strFileName;
                showTextData(strPath);

            }




        }

        public void showTextData(string strPath)
        {


            string fileName = strPath;
            //- Set the line counter
            int lineNumber = 0;

            //- Write initial text to the console
            lblMsg.Text = "Please Wait...";

            //- Open the text file
            using (StreamReader sr = new StreamReader(fileName))
            {
                //- Initialize name variables
                string strEmployeeCode = "";
                string strLogCount = "";
                string strLogData = "";
                string alName = "";
                string line;    //- Holds the entire line

                //- Cycle thru the text file 1 line at a time pulling
                //- substrings into the variables initialized above
                while ((line = sr.ReadLine()) != null)
                {
                    lineNumber++;

                    //- Pulling substrings.  If there is a problem
                    //- with the start index and/or the length values
                    //- an exception is thrown
                    try
                    {
                        strEmployeeCode = line.Substring(0, 10).Trim();
                        strLogCount = line.Substring(11, 13).Trim();
                        strLogData = line.Substring(22, 25).Trim();
                        alName = line.Substring(47, 17).Trim();
                    }

                    catch (Exception ex)
                    {
                        Console.Write(ex.ToString());
                    }

                   
                }
                sr.Close();
            }

        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
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

        public void uploadEmpLogData()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();



            objEmployeeDTO.FileName = txtFileName.Text;
            objEmployeeDTO.FilePath = txtFilePath.Text;



            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.uploadEmpLogData(objEmployeeDTO);
            MessageBox(strMsg);


        }

        #endregion

        protected void btnProcess_Click(object sender, EventArgs e)
        {

        }
    }
}