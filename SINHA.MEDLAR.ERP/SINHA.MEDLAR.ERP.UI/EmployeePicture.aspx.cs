using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.IO;

using Oracle.ManagedDataAccess.Client;
using System.Web.Security;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class EmployeePicture : System.Web.UI.Page
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

            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
            {
                //upLoadAndDisplay();

            }
            if (!IsPostBack)
            {
                loadSesscion();
                getOfficeName();
                getUnitId();
                getSectionId();
                lblMsg.Text = "";
                btnSearch.Focus();
                
            }
            
            if (IsPostBack)
            {

                loadSesscion();
            }
        }

       

        #region "Function"

        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
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
      
        //private void StartUpLoad()
        //{

           

        //    string imgName = FileUpload1.FileName;
        //    string imgPath = "Employee_Image/" + imgName;
        //    int imgSize = FileUpload1.PostedFile.ContentLength;
        //    if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
        //    {
        //        if (FileUpload1.PostedFile.ContentLength > 10240)
        //        {

        //            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('File is too big.')", true);

        //        }

        //        else
        //        {

                   
        //            FileUpload1.SaveAs(Server.MapPath(imgPath));
        //            imgEmployee.ImageUrl = "~/" + imgPath.Trim();
        //            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('Image saved!')", true);

        //        }



        //    }

        //}


        public void clearTextBox()
        {
            //txtEmployeeId.Text = "";
            //txtCardNo.Text = "";
            //txtDesignationName.Text = "";
            //txtEmployeeName.Text = "";
            //txtSL.Text = "";


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
        bool checkFileType(string filename)
        {
            string ext = Path.GetExtension(filename);
            switch (ext.ToLower())
            {
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                case ".bmp":
                    return true;
                case ".gif":
                    return true;
                case ".png":
                    return true;
                default:
                    return false;
            }
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

        
        public void getUnitId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlUnitId.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlUnitId.DataTextField = "UNIT_NAME";
            ddlUnitId.DataValueField = "UNIT_ID";

            ddlUnitId.DataBind();
            if (ddlUnitId.Items.Count > 0)
            {

                ddlUnitId.SelectedIndex = 0;
            }

        }

        public void getSectionId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSectionId.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

            ddlSectionId.DataTextField = "SECTION_NAME";
            ddlSectionId.DataValueField = "SECTION_ID";

            ddlSectionId.DataBind();
            if (ddlSectionId.Items.Count > 0)
            {

                ddlSectionId.SelectedIndex = 0;
            }


        }
        //private void upLoadAndDisplay()
        //{

            

        //    string imgName = FileUpload1.FileName;
        //    if (checkFileType(imgName))
        //    {

        //        string imgPath = "Employee_Image/" + imgName;
        //        string strImage = "~/" + imgPath.Trim();
        //        int imgSize = FileUpload1.PostedFile.ContentLength;
        //        if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
        //        {

        //            FileUpload1.SaveAs(Server.MapPath(imgPath));
        //            imgEmployee.ImageUrl = "~/" + imgPath.Trim();

        //            txtImagePath.Text = Server.MapPath(imgPath);


        //        }

        //    }

        //    //CopyFiles("http://127.0.0.6/" + imgName, "http://192.168.0.6/" + txtImagePath.Text);


           
        //}

      

        public void CopyFiles(string sourcePath, string destinationPath)
        {
            string[] files = System.IO.Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath(sourcePath));
            foreach (var file in files)
            {
                string filePath = System.Web.HttpContext.Current.Server.MapPath(destinationPath).ToString();

                System.IO.File.Copy(file, System.IO.Path.Combine(filePath, System.IO.Path.GetFileName(file)));

            };
        }

        //public void uploadImage()
        //{
           
        //    if (FileUpload1.HasFile == true)
        //    {
        //        int imageFileLength = FileUpload1.PostedFile.ContentLength;
        //        string strContentType = FileUpload1.PostedFile.ContentType;
        //        string strFileName = FileUpload1.PostedFile.FileName;
        //        imgEmployee.Visible = true; 
        //        imgEmployee.ImageUrl = strFileName;
        //        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Employee_Image/" + FileUpload1.FileName));
              

        //        byte[] imageArray = new byte[imageFileLength];
        //        HttpPostedFile imgPostedFile = FileUpload1.PostedFile;
        //        imgPostedFile.InputStream.Read(imageArray, 0, imageFileLength);
        //    }


        //}

        public void saveEmployeeImage()
        {
            ImageDTO objImageDTO = new ImageDTO();
            ImageBLL objImageBLL = new ImageBLL();

            //int imageFileLength = FileUpload1.PostedFile.ContentLength;
            //byte[] imageArray = new byte[imageFileLength];
            //HttpPostedFile imgPostedFile = FileUpload1.PostedFile;
            //imgPostedFile.InputStream.Read(imageArray, 0, imageFileLength);
          

            string strImageType = FileUpload1.PostedFile.ContentType;
            byte[] imageData = new byte [FileUpload1.PostedFile.InputStream.Length + 1];
            FileUpload1.PostedFile.InputStream.Read(imageData, 0, imageData.Length);

            //FileStream fs = new FileStream(SourceLoc, FileMode.Open, FileAccess.Read); 



           
            objImageDTO.EmployeeId = txtEmployeeId.Text;
            objImageDTO.EmployeeName = txtEmployeeName.Text;
            objImageDTO.Image = imageData;
            

            objImageDTO.HeadOfficeId = strHeadOfficeId;
            objImageDTO.BranchOfficeId = strBranchOfficeId;
            objImageDTO.UpdateBy = strEmployeeId;

            string strMsg = objImageBLL.saveEmployeeImage(objImageDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;
        }

        public void deleteEmployeeImage()
        {


            ImageDTO objImageDTO = new ImageDTO();
            ImageBLL objImageBLL = new ImageBLL();


            objImageDTO.EmployeeId = txtEmployeeId.Text;
            objImageDTO.HeadOfficeId = strHeadOfficeId;
            objImageDTO.BranchOfficeId = strBranchOfficeId;
            objImageDTO.UpdateBy = strEmployeeId;

            string strMsg = objImageBLL.deleteEmployeeImage(objImageDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;


        }


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void searchEmployeeImage()
        {
            
            ImageDTO objImageDTO = new ImageDTO ();
            ImageBLL objImageBLL = new ImageBLL ();

            objImageDTO = objImageBLL.searchEmployeeImage(txtEmployeeId.Text, strHeadOfficeId, strBranchOfficeId);

            txtEmployeeId.Text = objImageDTO.EmployeeId;
           
            txtEmployeeName.Text = objImageDTO.EmployeeName;
           

        }


        public void searchEmployeeRecordforImage()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
           

          


            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;




        
            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";

            }





            dt = objEmployeeBLL.searchEmployeeRecordforAdvance(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
                int totalcolums = gvEmployeeList.Rows[0].Cells.Count;
                gvEmployeeList.Rows[0].Cells.Clear();
                gvEmployeeList.Rows[0].Cells.Add(new TableCell());
                gvEmployeeList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvEmployeeList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }

        }

        public void goToNextRecord()
        {

            if (txtSL.Text == string.Empty)
            {
                txtSL.Text = "1";
            }


            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            //gvIncrementList.SelectedIndex = 1;


            int l;
            l = gvEmployeeList.SelectedRow.RowIndex;
            if (l != 0)
            {
                int strId = gvEmployeeList.SelectedRow.RowIndex + 1;
                int strRowCount = strId;
                int intCount = gvEmployeeList.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                    return;

                }
                {

                    gvEmployeeList.SelectedIndex += 1;
                    result = gvEmployeeList.SelectedRow.RowIndex + k;

                }

            }
            if (l == 0)
            {

                int intCount = gvEmployeeList.Rows.Count;
                int intCountRow = gvEmployeeList.Rows.Count;
                int p = intCountRow - 1;
                if (l == p)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                    return;

                }

                else
                {
                    l = 1;

                    if (txtSL.Text == "1" && txtSLNew.Text == "")
                    {
                        gvEmployeeList.SelectedIndex = 0;
                        result = gvEmployeeList.SelectedRow.RowIndex + k;
                        txtSLNew.Text = "1";
                    }
                    else
                    {
                        gvEmployeeList.SelectedIndex += 1;
                        result = gvEmployeeList.SelectedRow.RowIndex + k;
                    }
                }

            }


            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;



            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
        }

        public void goToPreviousRecord()
        {
            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            //gvIncrementList.SelectedIndex = 1;


            int l;
            l = gvEmployeeList.SelectedRow.RowIndex;
            if (l != 0)
            {
                int strId = gvEmployeeList.SelectedRow.RowIndex - 1;
                int strRowCount = strId;
                int intCount = gvEmployeeList.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    return;

                }
                else
                {
                    gvEmployeeList.SelectedIndex -= 1;
                    result = gvEmployeeList.SelectedRow.RowIndex - k;
                }
            }
            if (l == 0)
            {

                int intCountRow = gvEmployeeList.Rows.Count;
                int p = intCountRow;

                if (intCountRow == p)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    return;

                }

                else
                {

                    l = 1;
                    gvEmployeeList.SelectedIndex = l;
                    result = gvEmployeeList.SelectedRow.RowIndex - k;

                }

            }

            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;





            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;



            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

        }

        #endregion
        

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }

                else if (txtEmployeeId.Text== string.Empty)
                {
                    string strMsg = "Please click in the Gridview!!!";
                    MessageBox(strMsg);
                    return; 

                }
                else
                {
                    saveImage();
                    //goToNextRecord();

                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }



        #region "Image Save"

        #region "Oracle Connection Function"

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        #endregion


        public void saveImage()
        {
            OracleTransaction trans = null;

            HttpPostedFile imgFile = FileUpload1.PostedFile;
            OracleConnection strConn = GetConnection();
            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
            {
                DateTime dt = DateTime.UtcNow.Date;
                string currentDate = Convert.ToString(DateTime.Now.ToShortDateString());
                string strFileName = FileUpload1.PostedFile.FileName;
                string strImageExtension = Path.GetExtension(this.FileUpload1.PostedFile.FileName);


                BinaryReader b = new BinaryReader(imgFile.InputStream);
                byte[] byteArray = b.ReadBytes(imgFile.ContentLength);
                string sql = "SELECT 'Y' FROM EMPLOYEE_IMAGE WHERE EMPLOYEE_ID = '" + txtEmployeeId.Text + "' AND head_office_id = '" + strHeadOfficeId + "'  and branch_office_id = '" + strBranchOfficeId + "'";
                OracleCommand objCommand = new OracleCommand(sql);
                OracleDataReader objDataReader;
                string strDeleteYn = "";

                using (strConn = GetConnection())
                {

                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataReader = objCommand.ExecuteReader();

                    if (objDataReader.Read())
                    {

                        strDeleteYn = "Y";

                    }
                    else
                    {
                        strDeleteYn = "N";

                    }

                    if (strDeleteYn == "Y")
                    {
                        sql = "DELETE EMPLOYEE_IMAGE WHERE EMPLOYEE_ID = '" + txtEmployeeId.Text + "' AND head_office_id = '" + strHeadOfficeId + "'  and branch_office_id = '" + strBranchOfficeId + "'";
                        //strConn.Open();
                        trans = strConn.BeginTransaction();
                        OracleCommand cmd = new OracleCommand(sql, strConn);
                        cmd.ExecuteNonQuery();
                        trans.Commit();

                        sql = " INSERT INTO EMPLOYEE_IMAGE(EMPLOYEE_PIC,EMPLOYEE_ID,IMAGE_NAME,IMAGE_EXTENSION, UPDATE_BY,HEAD_OFFICE_ID,BRANCH_OFFICE_ID) VALUES(:EMPLOYEE_PIC, :EMPLOYEE_ID,:IMAGE_NAME,:IMAGE_EXTENSION,:UPDATE_BY,:HEAD_OFFICE_ID,:BRANCH_OFFICE_ID) ";

                        try
                        {

                            //strConn.Open();
                            cmd = new OracleCommand(sql, strConn);

                            cmd.Parameters.Add("EMPLOYEE_PIC", OracleDbType.Blob, byteArray, ParameterDirection.Input);
                            cmd.Parameters.Add("EMPLOYEE_ID", OracleDbType.Varchar2, txtEmployeeId.Text, ParameterDirection.Input);

                            cmd.Parameters.Add("IMAGE_NAME", OracleDbType.Varchar2, strFileName, ParameterDirection.Input);

                            cmd.Parameters.Add("IMAGE_EXTENSION", OracleDbType.Varchar2, strImageExtension, ParameterDirection.Input);
                            cmd.Parameters.Add("UPDATE_BY", OracleDbType.Varchar2, strEmployeeId, ParameterDirection.Input);
                            //cmd.Parameters.Add("UPDATE_DATE", OracleDbType.Varchar2, currentDate, ParameterDirection.Input);
                            cmd.Parameters.Add("HEAD_OFFICE_ID", OracleDbType.Varchar2, strHeadOfficeId, ParameterDirection.Input);
                            cmd.Parameters.Add("BRANCH_OFFICE_ID", OracleDbType.Varchar2, strBranchOfficeId, ParameterDirection.Input);


                            trans = strConn.BeginTransaction();
                            cmd.ExecuteNonQuery();
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
                    }




                    else

                    {


                        sql = " INSERT INTO EMPLOYEE_IMAGE(EMPLOYEE_PIC,EMPLOYEE_ID,IMAGE_NAME,IMAGE_EXTENSION, UPDATE_BY,HEAD_OFFICE_ID,BRANCH_OFFICE_ID) VALUES(:EMPLOYEE_PIC, :EMPLOYEE_ID,:IMAGE_NAME,:IMAGE_EXTENSION,:UPDATE_BY,:HEAD_OFFICE_ID,:BRANCH_OFFICE_ID) ";

                        try
                        {

                            //strConn.Open();
                            OracleCommand cmd = new OracleCommand(sql, strConn);

                            cmd.Parameters.Add("EMPLOYEE_PIC", OracleDbType.Blob, byteArray, ParameterDirection.Input);
                            cmd.Parameters.Add("EMPLOYEE_ID", OracleDbType.Varchar2, txtEmployeeId.Text, ParameterDirection.Input);

                            cmd.Parameters.Add("IMAGE_NAME", OracleDbType.Varchar2, strFileName, ParameterDirection.Input);

                            cmd.Parameters.Add("IMAGE_EXTENSION", OracleDbType.Varchar2, strImageExtension, ParameterDirection.Input);
                            cmd.Parameters.Add("UPDATE_BY", OracleDbType.Varchar2, strEmployeeId, ParameterDirection.Input);
                            //cmd.Parameters.Add("UPDATE_DATE", OracleDbType.Varchar2, currentDate, ParameterDirection.Input);
                            cmd.Parameters.Add("HEAD_OFFICE_ID", OracleDbType.Varchar2, strHeadOfficeId, ParameterDirection.Input);
                            cmd.Parameters.Add("BRANCH_OFFICE_ID", OracleDbType.Varchar2, strBranchOfficeId, ParameterDirection.Input);


                            trans = strConn.BeginTransaction();
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                            lblMsg.Text = "INSERTED SUCCESSFULLY!!!";
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


                    }
                }
            }
        }


        #endregion

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //   searchEmployeeImage();
        //   imgEmployee.ImageUrl = "ImageHandler.ashx?image_id=" + txtEmployeeId.Text;
        //}

        protected void txtEmployeeId0_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                searchEmployeeRecordforImage();
                clearTextBox();
                gvEmployeeList.SelectedIndex = 0;
                goToNextRecord();

            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }


        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
            searchEmployeeRecordforImage();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;



            //string strMsg = "Row Index: " + strRowId + "\\SL: " + strSLNo + "\\CARD NO: " + strCardNo + "\\nEmployee ID : " + strEmployeeId + "\\nName: " + strEmployeeName +
            //    "\\nDesignation: " + strDesignation;

            // MessageBox(strMsg);

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
           
           
        }




        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }


        protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);
            }
        }

        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvUnit, "Select$" + e.Row.RowIndex);
        //        //e.Row.Attributes["style"] = "cursor:pointer";

        //        try
        //        {
        //            switch (e.Row.RowType)
        //            {
        //                case DataControlRowType.Header:
        //                    //...
        //                    break;
        //                case DataControlRowType.DataRow:
        //                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#93A3B0'; this.style.color='White'; this.style.cursor='pointer'");
        //                    if (e.Row.RowState == DataControlRowState.Alternate)
        //                    {
        //                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.AlternatingRowStyle.BackColor.ToKnownColor()));
        //                    }
        //                    else
        //                    {
        //                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.RowStyle.BackColor.ToKnownColor()));
        //                    }
        //                    e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gvUnit, "Select$" + e.Row.RowIndex.ToString()));
        //                    break;
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            throw new Exception("Error : " + ex.Message);
        //        }
        //    }
        //}




        protected void gvEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadEmployeeRecord();


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
            }
            if (dt != null)
            {
                DataView dataView = new DataView(dt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                gvEmployeeList.DataSource = dataView;
                gvEmployeeList.DataBind();
            }
        }

        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }

        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            switch (GridViewSortDirection)
            {
                case "ASC":
                    GridViewSortDirection = "DESC";
                    break;

                case "DESC":
                    GridViewSortDirection = "ASC";
                    break;
            }

            return GridViewSortDirection;
        }


        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        #endregion

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else
                {

                        
                        goToNextRecord();
                        clearTextBox();
                        clearMessage();
                }
               

            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else
                {

                   

                        clearTextBox();
                        goToPreviousRecord();
                        clearMessage();
                    

                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }


        //public void displayImage()
        //{
        //    OracleConnection strConn = GetConnection();
        //    OracleCommand cmd = new OracleCommand("Select EMPLOYEE_PIC from EMPLOYEE_IMAGE where EMPLOYEE_ID = " + txtEmployeeId.Text + "", strConn);
        //    strConn.Open();
        //    OracleDataReader dr = null;
        //    dr = cmd.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            byte[] img = (byte[])dr["EMPLOYEE_PIC"];
        //            string base64string = Convert.ToBase64String(img, 0, img.Length);

        //            lblImage.Text = "<img src='data:image/png;base64," + base64string + "' alt='No Image' width='142px' Height='120px' vspace='5px' hspace='200px' />";
        //        }
        //    }
        //    strConn.Close();

        //}

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                deleteEmployeeImage();
                clearTextBox();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " +ex.Message);

            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            int contentLength = FileUpload1.PostedFile.ContentLength;//You may need it for validation
            string contentType = FileUpload1.PostedFile.ContentType;//You may need it for validation
            string fileName = FileUpload1.PostedFile.FileName;
            //avatarUpload.PostedFile.SaveAs(@"c:\test.tmp");//Or code to save in the DataBase.
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Employee_Image" ));
        }





        protected void Upload(object sender, EventArgs e)
        {

        }

    }
}