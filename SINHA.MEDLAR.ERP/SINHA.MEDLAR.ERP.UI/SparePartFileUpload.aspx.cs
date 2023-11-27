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

using Oracle.ManagedDataAccess.Client;
using System.Web.Security;
using System.Net;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class SparePartFileUpload : System.Web.UI.Page
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
                loadSparePartFileRecord();
                getOfficeName();
                getSparePartId();
                clearMsg();
               
            }

            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
            {
                loadSesscion();
                uploadSparePartsFile();
                loadSparePartFileRecord();
            }


            if (IsPostBack)
            {

                loadSesscion();

            }
        }

        #region "Oracle Connection Function"

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        #endregion


        #region "Function"



        public void uploadSparePartsFile()
        {
            try
            {

                if (ddlSparePartId.Text == " ")
                {
                    string strMsg = "Please Select Spare Part Name!!!";
                    ddlSparePartId.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else
                {


                    if (FileUpload1.HasFile)
                    {

                        OracleTransaction trans = null;
                        string strContentType = FileUpload1.PostedFile.ContentType;

                        string strFileName = FileUpload1.PostedFile.FileName;
                        string strFileNamePath = Path.GetFileName(strFileName);
                        string ext = Path.GetExtension(strFileNamePath);
                        txtFileName.Text = FileUpload1.FileName; ;

                    

                        string type = String.Empty;

                        if (File.Exists(strFileName))
                        {
                            File.Delete(strFileName);
                        }

                        string strFileSavePath = Server.MapPath("~/spare_parts_file_upload/");
                        string strPath = Server.MapPath("~/spare_parts_file_upload/" + strFileName);
                        FileUpload1.SaveAs(strPath);

                        // Extract the content of the Document into a Byte array
                        int intlength = FileUpload1.PostedFile.ContentLength;
                        Byte[] byteData = new Byte[intlength];
                        FileUpload1.PostedFile.InputStream.Read(byteData, 0, intlength);


                        OracleConnection strConn = GetConnection();
                        string sql = "INSERT INTO SPARE_PART_FILE_UPLOAD(SPARE_PART_ID,FILE_NAME,FILE_SIZE,UPDATE_BY, HEAD_OFFICE_ID,BRANCH_OFFICE_ID) VALUES(:SPARE_PART_ID, :FILE_NAME,:FILE_SIZE,:UPDATE_BY, :HEAD_OFFICE_ID,:BRANCH_OFFICE_ID)";

                        try
                        {

                            OracleCommand objCommand = new OracleCommand(sql, strConn);
                            objCommand.Parameters.Add("SPARE_PART_ID", OracleDbType.Varchar2, ddlSparePartId.SelectedValue.ToString(), ParameterDirection.Input);
                            objCommand.Parameters.Add("FILE_NAME", OracleDbType.Varchar2, txtFileName.Text, ParameterDirection.Input);
                            objCommand.Parameters.Add("FILE_SIZE", OracleDbType.Blob, byteData, ParameterDirection.Input);


                            objCommand.Parameters.Add("UPDATE_BY", OracleDbType.Varchar2, strEmployeeId, ParameterDirection.Input);
                            objCommand.Parameters.Add("HEAD_OFFICE_ID", OracleDbType.Varchar2, strHeadOfficeId, ParameterDirection.Input);
                            objCommand.Parameters.Add("BRANCH_OFFICE_ID", OracleDbType.Varchar2, strBranchOfficeId, ParameterDirection.Input);


                            strConn.Open();
                            trans = strConn.BeginTransaction();
                            objCommand.ExecuteNonQuery();
                            lblMsg.Text = "INSERTED SUCCESSFULLY!!!";
                            trans.Commit();
                            MessageBox(lblMsg.Text);

                        }
                        catch (Exception ex)
                        {
                            lblMsg.Text = ex.ToString();

                        }

                        finally
                        {
                            strConn.Close();
                        }

                        //saveSparePartFile(ddlSparePartId.SelectedValue.ToString(), txtFileName.Text, byteData, strEmployeeId, strHeadOfficeId, strBranchOfficeId);

                    }

                }


            }

            catch (Exception ex)
            {

                FileUpload1.Dispose();
                FileUpload1.FileContent.Dispose();
                FileUpload1.PostedFile.InputStream.Close();
                FileUpload1.PostedFile.InputStream.Dispose();
                lblMsg.Text = ex.Message;

            }


            //Response.Redirect(Request.Url.AbsoluteUri);

        }

        public void clearMsg()
        {
            lblMsg.Text = "";
            lblMsgRecord.Text = "";


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






        public void getSparePartId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
           


            ddlSparePartId.DataSource = objLookUpBLL.getSparePartId(strHeadOfficeId, strBranchOfficeId);

            ddlSparePartId.DataTextField = "SPARE_PART_NAME";
            ddlSparePartId.DataValueField = "SPARE_PART_ID";

            ddlSparePartId.DataBind();
            if (ddlSparePartId.Items.Count > 0)
            {

                ddlSparePartId.SelectedIndex = 0;
            }

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



    

        public void loadSparePartFileRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            string strPartId = "";

            if (ddlSparePartId.Text != " ")
            {
                strPartId = ddlSparePartId.SelectedValue.ToString();
            }
            else
            {
                strPartId = "";

            }


            dt = objLookUpBLL.loadSparePartFileRecord(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                int totalcolums = gvUnit.Rows[0].Cells.Count;
                gvUnit.Rows[0].Cells.Clear();
                gvUnit.Rows[0].Cells.Add(new TableCell());
                gvUnit.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvUnit.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtFileName.Text = "";
          

           

        }

        public void saveSparePartFile(string strSparePartId, string strFileName, byte strByte, string strEmployeeId, string strHeadOffieId, string strBranchOffieId)
        {

            SparePartDTO objSparePartDTO = new SparePartDTO ();
            SparePartBLL objSparePartBLL =  new SparePartBLL ();


            string strMsg = objSparePartBLL.saveSparePartFile(strSparePartId, strFileName, strByte, strEmployeeId, strHeadOffieId, strBranchOffieId);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void lnkView(object sender, EventArgs e)
        {
            LinkButton lnkView = sender as LinkButton;
            GridViewRow row = lnkView.NamingContainer as GridViewRow;
            string urlName = Request.Url.AbsoluteUri;
            // Removing the Page Name
            urlName = urlName.Remove(urlName.LastIndexOf("/"));
            ////Adding FolderName and FileName in the URL
            string url = string.Format("{0}/spare_parts_file_upload/{1}", urlName, txtFileName.Text);
            string script = "<script type='text/javascript'>window.open('" + url + "')</script>";
            this.ClientScript.RegisterStartupScript(this.GetType(), "script", script);




       


        }


        protected void lnkDelete(object sender, EventArgs e)
        {
            LinkButton lnkDelete = sender as LinkButton;
            GridViewRow row = lnkDelete.NamingContainer as GridViewRow;
            string urlName = Request.Url.AbsoluteUri;
            // Removing the Page Name
            urlName = urlName.Remove(urlName.LastIndexOf("/"));
            //Adding FolderName and FileName in the URL
            string url = string.Format("{0}/spare_parts_file_upload/{1}", urlName, txtFileName.Text);
            string script = "<script type='text/javascript'>window.open('" + url + "')</script>";
            this.ClientScript.RegisterStartupScript(this.GetType(), "script", script);
        }

        protected void lnkDownload(object sender, EventArgs e)
        {


            System.Net.WebClient client = new System.Net.WebClient();
            Byte[] buffer = client.DownloadData(Server.MapPath("~/spare_parts_file_upload/") + txtFileName.Text);

            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }


        protected void gvUnit_OnRowEditing(object sender, EventArgs e)
        {
            
        }

        protected void gvUnit_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex + 1;
            string strSLNo = gvUnit.SelectedRow.Cells[0].Text;
            string strFileName = gvUnit.SelectedRow.Cells[2].Text;


            txtFileName.Text = strFileName;


            System.Net.WebClient client = new System.Net.WebClient();

            //SparePartDTO objSparePartDTO = new SparePartDTO();
            //SparePartBLL objSparePartBLL = new SparePartBLL();

            //objSparePartDTO = objSparePartBLL.searchSparePartsFile(strSLNo);


            Byte[] buffer = client.DownloadData(Server.MapPath("~/spare_parts_file_upload/") +txtFileName.Text);

            if (buffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer.Length.ToString());
                Response.BinaryWrite(buffer);
            }

        }



    }
}