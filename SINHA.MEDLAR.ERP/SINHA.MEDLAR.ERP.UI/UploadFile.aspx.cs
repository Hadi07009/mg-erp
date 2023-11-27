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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class UploadFile : System.Web.UI.Page
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
                getMonthYear();
                getOfficeName();
                loadFileUploadRecord();
                
              
            }

            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
            {
                loadSesscion();
                saveFileUpload();
                loadFileUploadRecord();
               
            }


            if (IsPostBack)
            {

                loadSesscion();
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveFileUpload();
            loadFileUploadRecord();
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

        public void getMonthYear()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtYear.Text = objLookUpDTO.Year;
            txtMonth.Text = objLookUpDTO.Month;

        }



        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        //Load Year Month


        public void saveFileUpload()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            //Upload File
            FileInfo fi = new FileInfo(FileUpload1.FileName);

            string strFileName = FileUpload1.FileName;
            if (File.Exists(strFileName))
            {
                File.Delete(strFileName);
            }


            string fileName = fi.Name;
            string extension = Path.GetExtension(FileUpload1.FileName);
            byte[] strFileSize = FileUpload1.FileBytes;
            string fileSize = Convert.ToBase64String(strFileSize);

            FileUpload1.PostedFile.SaveAs(Server.MapPath(@"~/BANK_SHEET/" + fileName.Trim()));
            string path = @"~/BANK_SHEET/" + fileName.Trim();

            objLookUpDTO.FileName = fileName;
            objLookUpDTO.FileExtension = extension;
            objLookUpDTO.FilePath =path;
            txtFilePath.Text = path;
            objLookUpDTO.DataFile = fileSize.ToString();
            objLookUpDTO.FileSalaryYear = txtYear.Text;
            objLookUpDTO.FileSalaryMonth = txtMonth.Text;

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.saveFileUpload(objLookUpDTO);
            MessageBox(strMsg);

        }
        //File Download

        protected void OpenDocument(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
            Download(id);
        }

        private void Download(int id)
        {
            LookUpDTO objLookUpoDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpoDTO = objLookUpBLL.getFileInfo(id, txtYear.Text, txtMonth.Text, strHeadOfficeId, strBranchOfficeId);

            string name = objLookUpoDTO.FileName;
            byte[] documentBytes = objLookUpoDTO.FileDocuments;
            Response.ClearContent();
            Response.ContentType = "application/Excel";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", name));
            Response.AddHeader("Content-Length", documentBytes.ToString());
            Response.BinaryWrite(documentBytes);
            Response.Flush();
            Response.Close();
        }




        public void searchUnitInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            //objLookUpDTO = objLookUpBLL.searchUnitInfo(txtUnitId.Text);

            //txtUnitNameEng.Text = objLookUpDTO.UnitName;
            //txtUnitNameBng.Text = objLookUpDTO.UnitNameBangla;


        }

        public void loadFileUploadRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadFileUploadRecord(txtYear.Text, txtMonth.Text, strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
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
                lblMsg.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtFilePath.Text = "";
            txtYear.Text = "";
            txtMonth.Text = "";


        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //if (txtUnitId.Text == string.Empty)
            //{

            //    string strMsg = "Please Enter Unit ID!!!";
            //    MessageBox(strMsg);
            //    txtUnitId.Focus();
            //    return;
            //}
            //else
            //{
            //    searchUnitInfo();

            //}
        }

        protected void gvUnit_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {


                string strTranId = gvUnit.SelectedRow.Cells[0].Text;
                txtTranId.Text = strTranId;
                Download(Convert.ToInt32(strTranId));


            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }




        }


        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvUnit, "Select$" + e.Row.RowIndex);
                
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearTextBox();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " +ex.Message);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadFileUploadRecord();
        }

    
    }
}