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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class Index : System.Web.UI.Page
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
        //string strHeadOfficeName = "";
        //string strBranchOfficeName = "";
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["strEmployeeId"] == null)
            {

                sessionEmpty();
                return;
                
            }

            if (!IsPostBack)
            {

                loadSession();
                showWelcomeMsg();
                getOfficeName();



            }

      


        }

       

        protected void LogOutAnchor_Click(Object sender, EventArgs e)
        {
            LinkButton edit = sender as LinkButton;

            try
            {

                sessionEmpty();

            }

            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }

        #region "Function"

        public void clearCokkie()
        {

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();


        }
        public void showWelcomeMsg()
        {

            string strEmployeeName = Session["strEmployeeName"].ToString().Trim();

            lblMsg.Text = "WELCOME MR : " + strEmployeeName;
            lblDate.Text = "DATE : " + DateTime.Now.ToShortDateString();
            

            
        }
        public void loadSession()
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
            //strHeadOfficeName = Session["strHeadOfficeName"].ToString().Trim();
            //strBranchOfficeName = Session["strBranchOfficeName"].ToString().Trim();

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


            Label mpLabel = (Label)Master.FindControl("lblHeadOfficeName");
            HeadOfficeName = objLookUpDTO.HeadOfficeName;
            BranchOfficeName = objLookUpDTO.BranchOfficeName;
            HeadOfficeAddress = objLookUpDTO.HeadOfficeAddress;
            BranchOfficeAddress = objLookUpDTO.BranchOfficeAddress;



        }

        public string HeadOfficeName
        {
            get { return lblHeadOfficeName.Text; }
            set { lblHeadOfficeName.Text = value; } 
        }

        public string BranchOfficeName
        {
            get { return lblBranchOfficeName.Text; }
            set { lblBranchOfficeName.Text = value; }
        }

        public string HeadOfficeAddress
        {
            get { return lblHeadOfficeAddress.Text; }
            set { lblHeadOfficeAddress.Text = value; }
        }

        public string BranchOfficeAddress
        {
            get { return lblBranchOfficeAddress.Text; }
            set { lblBranchOfficeAddress.Text = value; }
        }

        #endregion
        protected void tmrUpdate_Tick(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToString("T");
        }
       


      
    }
}