using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.Web.Security;

using System.Web.Security;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


using System.Data;
using System.IO;

using Oracle.ManagedDataAccess.Client;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ImageDownload : System.Web.UI.Page
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


        #region "Oracle Connection Function"

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        #endregion

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
                displayImage();
            }

            if (IsPostBack)
            {

                loadSesscion();

            }

           



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


        public void displayImage()
        {

            string strEmployeeId = Request.QueryString["employee_id"];

            if (strEmployeeId != null)
            {
                MemoryStream memoryStream = new MemoryStream();

                string sql = "SELECT " +


                      "EMPLOYEE_PIC, " +
                      "file_name "+



                      "FROM vew_display_image WHERE EMPLOYEE_ID = '" + strEmployeeId + "'";




                OracleCommand objCommand = new OracleCommand(sql);
                OracleDataReader objDataReader;

                using (OracleConnection strConn = GetConnection())
                {

                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataReader = objCommand.ExecuteReader();
                    if (objDataReader.Read())
                    {
                        //objDataReader.Read();
                        //context.Response.BinaryWrite((Byte[])objDataReader[0]);
                        //context.Response.ContentType = "image/JPEG";
                        //context.Response.End();


                        byte[] imgData = (byte[])objDataReader["EMPLOYEE_PIC"];

                        //context.Response.ContentType = objDataReader["ImgType"].ToString();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.ContentType = "image/JPG";
                        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + objDataReader["file_name"] + "\"");
                        Response.BinaryWrite(imgData);
                        //context.Response.OutputStream.Write(imgData, 0, imgData.Length);
                    }



                }

            }

        }

        #endregion
    }
    
}