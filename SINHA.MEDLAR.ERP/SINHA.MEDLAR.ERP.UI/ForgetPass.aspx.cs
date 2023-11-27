using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.Text;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ForgetPass : System.Web.UI.Page
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
            getDate();
            //if (Session["strEmployeeId"] == null)
            //{
            //    Response.Redirect("Login.aspx");

            //}
            //if (IsPostBack)
            //{

            //    loadSesscion();
            //}
           
            
           
           

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

        public void sendeEmployeePass()
        {
            ForgetPassDTO objForgetPassDTO = new ForgetPassDTO();
            ForgetPassBLL objForgetPassBLL = new ForgetPassBLL();


            string strMsg = objForgetPassBLL.sendeEmployeePass(txtEmailAddress.Text);
            MessageBox(strMsg);
        }

        #endregion

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmailAddress.Text == string.Empty)
                {
                    string strMsg = "Please enter Email Address";
                    MessageBox(strMsg);
                    txtEmailAddress.Focus();
                    return;

                }


               
                else
                {
                    sendeEmployeePass();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

      

    }
}