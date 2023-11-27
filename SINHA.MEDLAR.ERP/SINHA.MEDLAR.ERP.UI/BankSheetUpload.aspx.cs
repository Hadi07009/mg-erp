using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.IO;


using System.Data;
using System.Web.SessionState;
using Oracle.ManagedDataAccess.Client;
using System.Web.Security;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class BankSheetUpload : System.Web.UI.Page
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
                clearMsg();
                getOfficeName();
                getMonthYearForSalary();
            }

            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
            {
                loadSesscion();
                uploadExcelFile();
                searchExcelFile(); 
            }

            if (IsPostBack)
            {

                loadSesscion();
            }
        }


        


        //public void downloadExcelFile()
        //{
        //    string sql = "";
        //    OracleTransaction trans = null;
        //    OracleConnection strConn = GetConnection();
        //    sql = "SELECT * FROM BANK_SHEET_UPLOAD WHERE SALARY_YEAR = '" + txtSalaryYear.Text + "' AND SALARY_MONTH = '" + txtsalaryMonth.Text + "' AND head_office_id = '" + strHeadOfficeId + "'  and branch_office_id = '" + strBranchOfficeId + "'";
        //    OracleCommand objCommand = new OracleCommand(sql);

        //    using (OracleDataAdapter objOracleDataAdapter = new OracleDataAdapter())
        //    {
        //        objCommand.Connection = strConn;
        //        objOracleDataAdapter.SelectCommand = objCommand;

        //        using (DataTable dt = new DataTable())
        //        {
        //            objOracleDataAdapter.Fill(dt);
        //            using (XLWorkbook wb = new XLWorkbook())
        //            {
        //                wb.Worksheets.Add(dt, "BANK_SHEET_UPLOAD");

        //                Response.Clear();
        //                Response.Buffer = true;
        //                Response.Charset = "";
        //                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //                Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
        //                using (MemoryStream MyMemoryStream = new MemoryStream())
        //                {
        //                    wb.SaveAs(MyMemoryStream);
        //                    MyMemoryStream.WriteTo(Response.OutputStream);
        //                    Response.Flush();
        //                    Response.End();
        //                }
        //            }
        //        }



        //    }




        //}
       


        #region "FUNCTION"

        public void uploadExcelFile()
        {


            if (FileUpload1.HasFile)
            {

                string strContentType = FileUpload1.PostedFile.ContentType;
                string strFileName = FileUpload1.FileName;
                if (File.Exists(strFileName))
                {
                    File.Delete(strFileName);
                }
                string strPath = Server.MapPath("~/BANK_SHEET/" + FileUpload1.FileName);
                FileUpload1.SaveAs(strPath);

                txtFilePath.Text = strPath;
                txtFileName.Text = strFileName;

                string ext = Path.GetExtension(strFileName);
                string type = String.Empty;



                switch (ext)    // this switch code validate the files which allow to upload only excel file you can change it for any file
                {

                    case ".xls":

                        type = "application/vnd.ms-excel";

                        break;


                    case ".xlsx":

                        type = "application/vnd.ms-excel";


                        break;

                    case ".ppt":

                        type = "application/vnd.ms-point";


                        break;


                    case ".pptx":

                        type = "application/vnd.ms-point";


                        break;

                    case ".doc":

                        type = "application/vnd.ms-word";


                        break;

                    case ".docx":

                        type = "application/vnd.ms-word";


                        break;

                    case ".pdf":

                        type = "application/pdf";


                        break;
                }




                if (type != String.Empty)
                {


                        SalaryDTO objSalaryDTO = new SalaryDTO();
                        SalaryBLL objSalaryBLL = new SalaryBLL();

                        HttpPostedFile imgFile = FileUpload1.PostedFile;

                        txtFileName.Text = FileUpload1.FileName; ;



                        FileInfo fi = new System.IO.FileInfo(FileUpload1.PostedFile.FileName);

                        string fileName = fi.Name;
                        BinaryReader b = new BinaryReader(imgFile.InputStream);
                        byte[] byteArray = b.ReadBytes(imgFile.ContentLength);


                        string fileSize = Convert.ToBase64String(byteArray);

                        if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
                        {

                            objSalaryDTO.Year = txtSalaryYear.Text;
                            objSalaryDTO.Month = txtsalaryMonth.Text;
                            objSalaryDTO.TranId = txtTranId.Text;


                            objSalaryDTO.FileName = strFileName;
                            objSalaryDTO.FileSize = fileSize;
                            objSalaryDTO.FileType = type;

                            objSalaryDTO.UpdateBy = strEmployeeId;
                            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
                            objSalaryDTO.BranchOfficeId = strBranchOfficeId;


                            string strMsg = objSalaryBLL.BankSheetUpload(objSalaryDTO);
                            MessageBox(strMsg);

                        }

                          



                }

                }
                else
                {




                    lblMsg.Text = "Select Only Excel File having extension .xlsx or .xls "; // if file is other than speified extension 

                }



            


        }

        public void DeleteBankSheet()
        {


            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            objSalaryDTO.Year = txtSalaryYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;
            objSalaryDTO.TranId = txtTranId.Text;


        
            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objSalaryBLL.DeleteBankSheet(objSalaryDTO);
            MessageBox(strMsg);



        }

        public void getMonthYearForSalary()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtSalaryYear.Text = objLookUpDTO.Year;
            txtsalaryMonth.Text = objLookUpDTO.Month;

        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
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

        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
        }


        public void searchExcelFile()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            DataTable dt = new DataTable();

            objSalaryDTO.Year = txtSalaryYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;



            dt = objSalaryBLL.searchExcelFile(objSalaryDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
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
                //gvEmployeeList.Columns[2].Visible = false;
                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }
        public void downloadExcelFile(string strTranId)
        {


          



        }

        #endregion



     
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                searchExcelFile();

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
           
        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string strTranId = gvEmployeeList.SelectedRow.Cells[1].Text;
                txtTranId.Text = strTranId;

                //downloadExcelFile(strTranId);


            }
            catch (Exception ex)
            {
                throw new Exception("Error : "+ex.Message);

            }

           


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

            int id = int.Parse(e.CommandName);
            string strId = Convert.ToString(id);

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            objSalaryDTO = objSalaryBLL.DownloadMonthlyBankSheet(strId, strHeadOfficeId, strBranchOfficeId);

            string name = objSalaryDTO.FileName;
            string fileType = objSalaryDTO.FileType;
            byte[] documentBytes = objSalaryDTO.FileDocuments;
            Response.ClearContent();
            Response.ContentType = fileType;
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", name));
            Response.BinaryWrite(documentBytes);
            Response.Flush();
            Response.Close();

        }



        #endregion

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            if (txtTranId.Text == "")
            {
                string strMsg = "Please Click in the Gridview!!!";
                MessageBox(strMsg);
                return;

            }

            if (txtSalaryYear.Text == "")
            {
                string strMsg = "Please Enter Salary Year!!!";
                txtSalaryYear.Focus();
                MessageBox(strMsg);
                return;

            }
            else if (txtsalaryMonth.Text == "")
            {
                string strMsg = "Please Enter Salary Month!!!";
                txtsalaryMonth.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {
                DeleteBankSheet();
                searchExcelFile(); 
            }
        }

















    }
}