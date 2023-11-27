using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.IO;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.IO;
using System.Web.Security;
using System.Text;
using System.Collections;


using Oracle.ManagedDataAccess.Client;
using System.Net;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class BankSalaryUploadFile : System.Web.UI.Page
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


        StreamReader objStreamReader;
        private int timeOut;
        FileStream fs;



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
                getOfficeName();
                getMonthYearForSalary();
                searchMonthlyBankFile();
            }

            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
            {
                loadSesscion();
                chkExcellFile();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }
        }


        #region "Function"
        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
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

        public void getMonthYearForSalary()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtSalaryYear.Text = objLookUpDTO.Year;
            txtSalaryMonth.Text = objLookUpDTO.Month;

        }

        #region "Oracle Connection Function"

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        #endregion


        public void chkExcellFile()
        {

            string fileName = Server.HtmlEncode(FileUpload1.FileName);
            string extension = System.IO.Path.GetExtension(fileName);

            if (extension == ".xlsx")
            {
                uploadMonthlyBankFile();
            }
            else
            {

                string strMsg = "Only Excell file is Allow!!!";
                MessageBox(strMsg);
                return;



            }



        }



        public void uploadMonthlyBankFile()
        {
            try
            {


                if (FileUpload1.HasFile)
                {


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

                    string strFileSavePath = Server.MapPath("~/BANK_SHEET/");
                    string strPath = Server.MapPath("~/BANK_SHEET/" + strFileName);
                    FileUpload1.SaveAs(strPath);


                    OracleTransaction trans = null;
                    // Extract the content of the Document into a Byte array
                    int intlength = FileUpload1.PostedFile.ContentLength;
                    Byte[] byteData = new Byte[intlength];
                    FileUpload1.PostedFile.InputStream.Read(byteData, 0, intlength);
                    OracleConnection strConn = GetConnection();

                    string sql = "SELECT 'Y' FROM BANK_SHEET_UPLOAD WHERE SALARY_YEAR = '" + txtSalaryYear.Text + "' AND SALARY_MONTH ='"+txtSalaryMonth.Text+"' AND head_office_id = '" + strHeadOfficeId + "'  and branch_office_id = '" + strBranchOfficeId + "'  ";
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
                            sql = "SELECT 'Y' FROM BANK_SHEET_UPLOAD WHERE SALARY_YEAR = '" + txtSalaryYear.Text + "' AND SALARY_MONTH ='" + txtSalaryMonth.Text + "' AND head_office_id = '" + strHeadOfficeId + "'  and branch_office_id = '" + strBranchOfficeId + "'  ";
                            //strConn.Open();
                            trans = strConn.BeginTransaction();
                            OracleCommand cmd = new OracleCommand(sql, strConn);
                            cmd.ExecuteNonQuery();
                            trans.Commit();
                            //strConn.Close();


                            sql = "INSERT INTO BANK_SHEET_UPLOAD(SALARY_YEAR, SALARY_MONTH, FILE_NAME, FILE_SIZE, UPDATE_BY, HEAD_OFFICE_ID,BRANCH_OFFICE_ID) VALUES(:SALARY_YEAR, :SALARY_MONTH, :FILE_NAME,:FILE_SIZE,  :UPDATE_BY, :HEAD_OFFICE_ID,:BRANCH_OFFICE_ID)";

                            try
                            {

                                objCommand = new OracleCommand(sql, strConn);
                                objCommand.Parameters.Add("SALARY_YEAR", OracleDbType.Varchar2, txtSalaryYear.Text, ParameterDirection.Input);
                                objCommand.Parameters.Add("SALARY_MONTH", OracleDbType.Varchar2, txtSalaryMonth.Text, ParameterDirection.Input);
                               
                                objCommand.Parameters.Add("FILE_NAME", OracleDbType.Varchar2, txtFileName.Text, ParameterDirection.Input);
                                objCommand.Parameters.Add("FILE_SIZE", OracleDbType.Blob, byteData, ParameterDirection.Input);



                                objCommand.Parameters.Add("UPDATE_BY", OracleDbType.Varchar2, strEmployeeId, ParameterDirection.Input);
                                objCommand.Parameters.Add("HEAD_OFFICE_ID", OracleDbType.Varchar2, strHeadOfficeId, ParameterDirection.Input);
                                objCommand.Parameters.Add("BRANCH_OFFICE_ID", OracleDbType.Varchar2, strBranchOfficeId, ParameterDirection.Input);


                                //strConn.Open();
                                trans = strConn.BeginTransaction();
                                objCommand.ExecuteNonQuery();
                                trans.Commit();


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
                            sql = "INSERT INTO BANK_SHEET_UPLOAD(SALARY_YEAR, SALARY_MONTH, FILE_NAME, FILE_SIZE, UPDATE_BY, HEAD_OFFICE_ID,BRANCH_OFFICE_ID) VALUES(:SALARY_YEAR, :SALARY_MONTH, :FILE_NAME,:FILE_SIZE,  :UPDATE_BY, :HEAD_OFFICE_ID,:BRANCH_OFFICE_ID)";

                            try
                            {

                                objCommand = new OracleCommand(sql, strConn);

                                objCommand.Parameters.Add("SALARY_YEAR", OracleDbType.Varchar2, txtSalaryYear.Text, ParameterDirection.Input);
                                objCommand.Parameters.Add("SALARY_MONTH", OracleDbType.Varchar2, txtSalaryMonth.Text, ParameterDirection.Input);

                                objCommand.Parameters.Add("FILE_NAME", OracleDbType.Varchar2, txtFileName.Text, ParameterDirection.Input);
                                objCommand.Parameters.Add("FILE_SIZE", OracleDbType.Blob, byteData, ParameterDirection.Input);



                                objCommand.Parameters.Add("UPDATE_BY", OracleDbType.Varchar2, strEmployeeId, ParameterDirection.Input);
                                objCommand.Parameters.Add("HEAD_OFFICE_ID", OracleDbType.Varchar2, strHeadOfficeId, ParameterDirection.Input);
                                objCommand.Parameters.Add("BRANCH_OFFICE_ID", OracleDbType.Varchar2, strBranchOfficeId, ParameterDirection.Input);


                                //strConn.Open();
                                trans = strConn.BeginTransaction();
                                objCommand.ExecuteNonQuery();
                                trans.Commit();


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




                    //saveSparePartFile(ddlSparePartId.SelectedValue.ToString(), txtFileName.Text, byteData, strEmployeeId, strHeadOfficeId, strBranchOfficeId);

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



        public void searchMonthlyBankFile()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.Year = txtSalaryYear.Text;
            objEmployeeDTO.Month = txtSalaryMonth.Text;




            dt = objEmployeeBLL.searchMonthlyBankFile(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeLogList.DataSource = dt;
                gvEmployeeLogList.DataBind();

                int count = ((DataTable)gvEmployeeLogList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;



            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvEmployeeLogList.DataSource = dt;
                gvEmployeeLogList.DataBind();
                int totalcolums = gvEmployeeLogList.Rows[0].Cells.Count;
                gvEmployeeLogList.Rows[0].Cells.Clear();
                gvEmployeeLogList.Rows[0].Cells.Add(new TableCell());
                gvEmployeeLogList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvEmployeeLogList.Rows[0].Cells[0].Text = "NO RECORD FOUND";
                //gvEmployeeList.Columns[2].Visible = false;
                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }

        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSalaryYear.Text == "")
            {

                string strMsg = "Please Enter Year!!!";
                MessageBox(strMsg);
                txtSalaryYear.Focus();
                return; 

            }
            else if (txtSalaryMonth.Text == "")
            {

                string strMsg = "Please Enter Month!!!";
                MessageBox(strMsg);
                txtSalaryMonth.Focus();
                return;

            }

            else
            {

                chkExcellFile();

            }
        }



        #region "Grid View Functionality"


        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            //gvEmployeeLogList.EditIndex = e.NewEditIndex;
            ////this.searchSalaryInfoHO();
            //gvEmployeeLogList.Columns[2].Visible = true;
        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            //GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
            //string strEmployeeId = (row.Cells[1].Controls[0] as TextBox).Text;
            //string strWorkingDay = (row.Cells[5].Controls[0] as TextBox).Text;
            //string strAllowenceAmount = (row.Cells[6].Controls[0] as TextBox).Text;
            //string strAttendenceBonus = (row.Cells[7].Controls[0] as TextBox).Text;




            //gvEmployeeLogList.EditIndex = -1;
            //this.searchSalaryInfoHO();
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            //gvEmployeeLogList.EditIndex = -1;
            //this.searchSalaryInfoHO();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeLogList, "Select$" + e.Row.RowIndex);
            }
        }
        protected void gvEmployeeLogList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            int strRowId = gvEmployeeLogList.SelectedRow.RowIndex + 1;
            string strYear = gvEmployeeLogList.SelectedRow.Cells[0].Text;
            string strMonth = gvEmployeeLogList.SelectedRow.Cells[1].Text;

            txtSalaryYear.Text = strYear;
            txtSalaryMonth.Text = strMonth;


            Response.Redirect(String.Format("BankFileHandler.ashx?SALARY_YEAR={0}&SALARY_MONTH={1}  ", Server.UrlEncode(txtSalaryYear.Text), Server.UrlEncode(txtSalaryMonth.Text)));
            

        }

        protected void gvEmployeeLogList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            gvEmployeeLogList.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }

        #endregion
    }
}