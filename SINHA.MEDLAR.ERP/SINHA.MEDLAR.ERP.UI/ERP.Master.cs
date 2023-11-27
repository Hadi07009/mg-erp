using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.Net;
using System.Web.Configuration;
using System.Configuration;

using Oracle.ManagedDataAccess.Client;
using System.Text;
using System.IO;
using SINHA.MEDLAR.ERP.DBMANAGER;
using System.Security.Cryptography;
using System.Web.Services;
using SINHA.MEDLAR.ERP.UI.Utility;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ERP : System.Web.UI.MasterPage
    {
        string strEmployeeId = "";
        string strSectionId = "";
        string strDesignationId = "";
        string strUnitId = "";
        string strCatagoryId;
        string strHeadOfficeId = "";
        string strBranchOfficeId = "";
        string strLoginDay = "";
        string strLoginMonth = "";
        string strLoginDate = "";
        string strSoftId = "";

        private const string uiCode = "0009";

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
                getTitileName();

                getTopMenuItem();
                getMenuItem();
                getSetupMenu();
                getOfficeName();

                string childPageName = Request.Url.Segments[Request.Url.Segments.Length - 1];                
                UIHelper.SetSucureEvents(this.ContentPlaceHolder2.Page, strEmployeeId, childPageName, strBranchOfficeId, strHeadOfficeId);

            }
            if (IsPostBack)
            {
                loadSession();
            }
        }

        public void getTitileName()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getTitileName(strHeadOfficeId, strBranchOfficeId, strSoftId);

            lblTitle.Text = objLookUpDTO.SoftName;



        }
        private string getValuePath(Int32 Parent, DataTable dt)
        {
            int predecessor = Parent;
            StringBuilder valuePath = new StringBuilder();
            valuePath.Append(Parent.ToString());
            DataRow[] drPar;
            while (true)
            {
                drPar = dt.Select("MENU_ID=" + predecessor);
                if (drPar[0]["MENU_ID"].ToString().Equals("0"))
                    break;
                valuePath.Insert(0, '/');
                valuePath.Insert(0, drPar[0]["MENU_ID"].ToString());
                predecessor = Convert.ToInt32(drPar[0]["MENU_ID"].ToString());
            }
            return valuePath.ToString();
        }
        public void getTopMenuItem()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataSet ds = new DataSet();

            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();


            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = strEmployeeId;
            objEmployeeDTO.SoftId = strSoftId;




            ds = objEmployeeBLL.getTopMenuItem(objEmployeeDTO);

            foreach (DataRow level1DataRow in ds.Tables[0].Rows)
            {
                MenuItem item = new MenuItem();
                item.Text = level1DataRow["menu_name"].ToString();
                item.NavigateUrl = level1DataRow["menu_path"].ToString() + "?id=" + level1DataRow["MENU_ID"].ToString() + "?Day=" + dy + "?Month=" + mn + "?year=" + yy;
                mnuBar.Items.Add(item);
            }


            //if (dt.Rows.Count > 0)
            //{
            //    gvTopMenu.DataSource = dt;
            //    gvTopMenu.DataBind();

            //    int count = ((DataTable)gvTopMenu.DataSource).Rows.Count;
            //    //string strMsg = " TOTAL " + count + " RECORD FOUND";
            //    // MessageBox(strMsg);
            //    //lblMsg.Text = strMsg;
            //    //gvEmployeeList.Columns[2].Visible = false;
            //    // getFirstIndex();



            //}
            //else
            //{
            //    dt.Rows.Add(dt.NewRow());
            //    gvTopMenu.DataSource = dt;
            //    gvTopMenu.DataBind();
            //    int totalcolums = gvTopMenu.Rows[0].Cells.Count;
            //    gvTopMenu.Rows[0].Cells.Clear();
            //    gvTopMenu.Rows[0].Cells.Add(new TableCell());
            //    gvTopMenu.Rows[0].Cells[0].ColumnSpan = totalcolums;
            //    gvTopMenu.Rows[0].Cells[0].Text = "NO MENU FOUND";

            //    //string strMsg = "NO RECORD FOUND!!!";
            //    //MessageBox(strMsg);
            //    //lblMsg.Text = strMsg;
            //    //gvEmployeeList.Columns[2].Visible = false;
            //}




        }
                
        public void getMenuItem()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = strEmployeeId;
            objEmployeeDTO.SoftId = strSoftId;


            dt = objEmployeeBLL.getMenuItem(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvMenu.DataSource = dt;
                gvMenu.DataBind();

                int count = ((DataTable)gvMenu.DataSource).Rows.Count;
                //string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                //lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();



            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvMenu.DataSource = dt;
                gvMenu.DataBind();
                int totalcolums = gvMenu.Rows[0].Cells.Count;
                gvMenu.Rows[0].Cells.Clear();
                gvMenu.Rows[0].Cells.Add(new TableCell());
                gvMenu.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvMenu.Rows[0].Cells[0].Text = "NO MENU FOUND";

                //string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                //lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }
        public void getSetupMenu()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = strEmployeeId;
            objEmployeeDTO.SoftId = strSoftId;


            dt = objEmployeeBLL.getSetupMenu(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvSetup.DataSource = dt;
                gvSetup.DataBind();

                int count = ((DataTable)gvSetup.DataSource).Rows.Count;
                //string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                //lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();



            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvSetup.DataSource = dt;
                gvSetup.DataBind();
                int totalcolums = gvSetup.Rows[0].Cells.Count;
                gvSetup.Rows[0].Cells.Clear();
                gvSetup.Rows[0].Cells.Add(new TableCell());
                gvSetup.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvSetup.Rows[0].Cells[0].Text = "NO MENU FOUND";

                //string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                //lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }
        
        private void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["strEmployeeId"] == null)
            {


                Session.Clear();
                Roles.DeleteCookie();
                Response.Redirect("Login.aspx", false);
                return;

            }

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
            strSoftId = Session["strSoftId"].ToString().Trim();
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
            Session.Abandon();
            Session.RemoveAll();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            FormsAuthentication.SignOut();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "clearHistory", "ClearHistory();", true);
            FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("Login.aspx", false);
            //Server.Transfer("Login.aspx");
        }
        public void LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // Invalidate the Cache on the Client Side

            foreach (var cookie in Request.Cookies.AllKeys)
            {
                Request.Cookies.Remove(cookie);
            }
            foreach (var cookie in Response.Cookies.AllKeys)
            {
                Response.Cookies.Remove(cookie);
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "clearHistory", "ClearHistory();", true);
            Response.Redirect("Login.aspx", false);
        }
        protected void LogOutAnchor_Click(Object sender, EventArgs e)
        {


            try
            {

                sessionEmpty();
                //LogOff();

            }

            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }
        protected void LogOut()
        {

            Session.Abandon();
            string loggedOutPageUrl = "Logout.aspx";
            Response.Write("<script language='javascript' >");
            Response.Write("function ClearHistory()");
            Response.Write("{");
            Response.Write(" var backlen=history.length;");
            Response.Write(" history.go(-backlen);");
            Response.Write(" window.location.href='" + loggedOutPageUrl + "'; ");
            Response.Write("}");
            Response.Write("</script>");
        }
        public void singOut()
        {
            //FormsAuthentication.SignOut();
            //Session.Clear();  // This may not be needed -- but can't hurt
            //Session.Abandon();

            //// Clear authentication cookie
            //HttpCookie rFormsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            //rFormsCookie.Expires = DateTime.Now.AddYears(-1);
            //Response.Cookies.Add(rFormsCookie);

            //// Clear session cookie 
            //HttpCookie rSessionCookie = new HttpCookie("SESSION_ID", "");
            //rSessionCookie.Expires = DateTime.Now.AddYears(-1);
            //Response.Cookies.Add(rSessionCookie);

            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetNoStore();
            //sessionEmpty();


        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            try
            {
                sessionEmpty();   
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
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
                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Redirect("ChangePassword.aspx", false);

            }

            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Redirect("Index.aspx", false);

            }

            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnEmployeeBasic_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Redirect("EmployeeBasic.aspx", false);

            }

            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnEmployeeList_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Redirect("EmployeeSearch.aspx", false);

            }

            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnTax_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Redirect("Tax.aspx", false);

            }

            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            try
            {

                //getReportPage();

            }

            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }



        #region "Gridview Functionlity"
        protected void gvMenu_OnSelectedIndexChanged(object sender, EventArgs e)
        {



        }

        protected void gvMenu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


        }





        protected void gvMenu_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void gvMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                string strMenuId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MENU_ID"));


                objEmployeeDTO = objEmployeeBLL.getUrl(strEmployeeId, strMenuId, strSoftId, strHeadOfficeId, strBranchOfficeId);

                e.Row.Attributes["onclick"] = "location.href='" + objEmployeeDTO.MenuPath + "?id=" + DataBinder.Eval(e.Row.DataItem, "MENU_ID") + "?Day=" + dy + "?Month=" + mn + "?Year=" + yy + "' ";
                e.Row.Attributes["style"] = "cursor:pointer";


            }

            e.Row.Attributes["style"] = "cursor:pointer";
            gvMenu.Columns[0].Visible = false;


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = (e.Row.DataItem as DataRowView)["MENU_NAME"].ToString();

            }

            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
            }

        }
        #endregion
        #region "Gridview Functionlity Second"
        protected void gvSetup_OnSelectedIndexChanged(object sender, EventArgs e)
        {



        }

        protected void gvSetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


        }





        protected void gvSetup_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void gvSetup_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        }

        protected void gvSetup_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            String dy = datevalue.Day.ToString();
            String mn = datevalue.Month.ToString();
            String yy = datevalue.Year.ToString();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                string strMenuId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MENU_ID"));


                objEmployeeDTO = objEmployeeBLL.getSetUpUrl(strEmployeeId, strMenuId, strSoftId, strHeadOfficeId, strBranchOfficeId);

                e.Row.Attributes["onclick"] = "location.href='" + objEmployeeDTO.MenuPath + "?id=" + DataBinder.Eval(e.Row.DataItem, "MENU_ID") + "?Day=" + dy + "?Month=" + mn + "?Year=" + yy + "' ";
                e.Row.Attributes["style"] = "cursor:pointer";




                //e.Row.Attributes.Add("onmouseover", "MouseEvents(this, event)");
                //e.Row.Attributes.Add("onmouseout", "MouseEvents(this, event)");

                //e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor;this.style.cursor='hand';this.style.backgroundColor='#ffccff';";
                //e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor=this.originalstyle;";

            }
            e.Row.Attributes["style"] = "cursor:pointer";
            gvSetup.Columns[0].Visible = false;


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.ToolTip = (e.Row.DataItem as DataRowView)["MENU_NAME"].ToString();

            }


            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].ToolTip = e.Row.Cells[i].Text;
            }



        }
        #endregion

        #region"Encrypt@Decrypt"
        public class EncryptDecryptQueryString
        {
            private byte[] key = { };
            private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
            public string Decrypt(string stringToDecrypt, string sEncryptionKey)
            {
                byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];
                try
                {
                    key = System.Text.Encoding.UTF8.GetBytes(sEncryptionKey);
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    inputByteArray = Convert.FromBase64String(stringToDecrypt);
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms,
                      des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                    return encoding.GetString(ms.ToArray());
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }

            public string Encrypt(string stringToEncrypt, string SEncryptionKey)
            {
                try
                {
                    key = System.Text.Encoding.UTF8.GetBytes(SEncryptionKey);
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms,
                      des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }
        #endregion


        public void getOfficeName()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getHeadOfficeName(strHeadOfficeId, strBranchOfficeId);

            //lblHeadOfficeName.Text = objLookUpDTO.HeadOfficeName;
            //lblHeadOfficeAddress.Text = objLookUpDTO.HeadOfficeAddress;
            lblBranchOfficeName.Text = objLookUpDTO.BranchOfficeName;
            //lblBranchOfficeAddress.Text = objLookUpDTO.BranchOfficeAddress;

        }
    }
}