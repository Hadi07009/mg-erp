using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Web.Security;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ChangePass : System.Web.UI.Page
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
                clearMsg();

                lblMsg.Text = string.Empty;
                txtNewPassword.Focus();
            }
            if (IsPostBack)
            {

                loadSesscion();
            }

            
            txtNewPassword.Attributes.Add("onkeypress", "return controlEnter('" + txtConfirmPassword.ClientID + "', event)");
        }

        #region "FUNCTION"



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


        public void clearMsg()
        {

            //lblMsg.Text = string.Empty;
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


        //static string EncodePassword(string pass, string salt)
        //{
        //    byte[] bytes = Encoding.Unicode.GetBytes(pass);
        //    byte[] src = Convert.FromBase64String(salt);
        //    byte[] dst = new byte[src.Length + bytes.Length];
        //    Buffer.BlockCopy(src, 0, dst, 0, src.Length);
        //    Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
        //    HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
        //    byte[] inArray = algorithm.ComputeHash(dst);
        //    return Convert.ToBase64String(inArray);
        //}

        public void encryptPass(string strPassword)
        {

            string pass = strPassword;
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(bytes);
            string hash = Convert.ToBase64String(inArray);
            txtNewPassword.Text = hash;

        }

        public void submitPassword()
        {

            if (txtNewPassword.Text.Length != txtConfirmPassword.Text.Length && txtNewPassword.Text != txtConfirmPassword.Text)
            {

                string strMsg = "New Password & Confirm Password is not same!!!";
                MessageBox(strMsg);
                return;
            }
            else
            {

                LoginDTO objLoginDTO = new LoginDTO();
                LoginBLL objLoginBLL = new LoginBLL();

                //string strNewPassword = txtNewPassword.Text.Replace("", "");
                //string strConfirmPassword = txtConfirmPassword.Text.Replace("", "");

                objLoginDTO.EmployeeId = strEmployeeId;
                objLoginDTO.EmployeePass = txtNewPassword.Text;


                objLoginDTO.UpdateBy = strEmployeeId;
                objLoginDTO.HeadOfficeId = strHeadOfficeId;
                objLoginDTO.BranchOfficeId = strBranchOfficeId;



                string strMsg = objLoginBLL.submitPassword(objLoginDTO);
                MessageBox(strMsg);
                lblMsg.Text = strMsg;
                if (strMsg == "PASSWORD SUCCESSFULLY CHANGED!!!")
                {

                    sessionEmpty();
                }

            }

        }

        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == string.Empty)
            {
                string strMsg = "Please Enter New Password!!!";
                MessageBox(strMsg);
                txtNewPassword.Focus();
                return;

            }

            else if (txtConfirmPassword.Text == string.Empty)
            {
                string strMsg = "Please Enter Confirm Password!!!";
                MessageBox(strMsg);
                txtConfirmPassword.Focus();
                return;

            }

            else
            {
                submitPassword();

            }
        }
    }
}