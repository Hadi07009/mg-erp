using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.VisualBasic.FileIO;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;

using System.Web.Security;
using System.Text;
using System.Collections;
using System.Data.OleDb;
using SINHA.MEDLAR.ERP.UI.Utility;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class EmployeeLogProcess : System.Web.UI.Page
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

        ReportDocument rd = new ReportDocument();
        string strDefaultName = "Report";
        ExportFormatType formatType = ExportFormatType.NoFormat;
        StreamReader objStreamReader;
        private int timeOut;
        FileStream fs;
        //private const string uiCode = "0001";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;
            }

            if (!IsPostBack)
            {
                //this.dtpToDate. = 0;
                //dtpToDate.Select(0, 0);

                loadSesscion();
                getOfficeName();
                clearMsg();
                GetFloorDropdown();
                getUnitId();
                getSectionId();
                getOfficeName();
                getDirectoryName();
                getDate();
                //UIHelper.SetSucureEvents(this, strEmployeeId, uiCode, strBranchOfficeId, strHeadOfficeId);
                // GetEventPermission();
                //GetSittingBranchOfficeId();

            }

            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
            {
                loadSesscion();
                uploadEmpLogDate();
               
                //getDataFromFile();
                //clearMsg();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }
        }

        #region "Function"
        //public void GetEventPermission()
        //{
        //    EventPermissionDTO objEventPermissionDTO = new EventPermissionDTO();
        //    EmployeeBLL objEmployeeBLL = new EmployeeBLL();
        //    DataTable dt = new DataTable();
        //    objEventPermissionDTO.UpdateBy = strEmployeeId;
        //    objEventPermissionDTO.MenuCode = "0001";
        //    objEventPermissionDTO.HeadOfficeId = strHeadOfficeId;
        //    objEventPermissionDTO.BranchOfficeId = strBranchOfficeId;
        //    var basicInfo = objEmployeeBLL.GetEventPermission(objEventPermissionDTO);
        //    if (basicInfo.DisableProcess == "1")
        //        btnLogProcess.Visible = false;
        //}
        public void moveFile(string strPath, string strFileName)
        {
            try
            {
                string sourceFile = strPath;
                string strTargetSource = txtDataUploadDir.Text;
                string destinationFile = txtDataUploadDir.Text + "\\" + strFileName;

                if (!Directory.Exists(strTargetSource))
                {
                    Directory.CreateDirectory(strTargetSource);
                }
                if (File.Exists(destinationFile) == true)
                {
                        File.Delete(destinationFile);
                        System.IO.File.Copy(sourceFile, destinationFile);  
                }
                else
                {
                    System.IO.File.Copy(sourceFile, destinationFile);
                }
               
                objStreamReader = new StreamReader(strPath, true);
                objStreamReader.Dispose();
                objStreamReader.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                objStreamReader = new StreamReader(strPath, true);
                objStreamReader.Dispose();
                objStreamReader.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        public void copyFileFromLocalToRemote(string strPath, string strFileName)
        {

            List<string> picList = new List<string>();

            string sourceDir = strPath;//My local path
            string strTargerDir = @"E\DATA_UPLOAD";//Remote path

            string sourceFile = System.IO.Path.Combine(sourceDir, strFileName);
            string destFile = System.IO.Path.Combine(strTargerDir, strFileName);

            if (!System.IO.Directory.Exists(strTargerDir))
            {
                System.IO.Directory.CreateDirectory(strTargerDir);
            }

            System.IO.File.Copy(sourceFile, destFile, true);

            if (System.IO.Directory.Exists(sourceDir))
            {
                string[] files = System.IO.Directory.GetFiles(sourceDir);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    strFileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(strTargerDir, strFileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                MessageBox("Source path does not exist!");
            }




        }

        public void GetFloorDropdown()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlFloor.DataSource = objLookUpBLL.GetFloorDropdown(strHeadOfficeId, strBranchOfficeId);

            ddlFloor.DataTextField = "FLOOR_NAME";
            ddlFloor.DataValueField = "FLOOR_ID";

            ddlFloor.DataBind();
            if (ddlFloor.Items.Count > 0)
            {
                ddlFloor.SelectedIndex = 0;
            }
        }

        public void getUnitId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            //ddlUnitId.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);
            ddlUnitId.DataSource = objLookUpBLL.GetUnitBySittingOffice(strBranchOfficeId);

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
            //ddlSectionId.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);
            ddlSectionId.DataSource = objLookUpBLL.GetSectionBySittingOffice(strBranchOfficeId);

            ddlSectionId.DataTextField = "SECTION_NAME";
            ddlSectionId.DataValueField = "SECTION_ID";

            ddlSectionId.DataBind();
            if (ddlSectionId.Items.Count > 0)
            {

                ddlSectionId.SelectedIndex = 0;
            }


        }


        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
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


        public void uploadEmpLogDate()
        {
            try
            {

                if(ddlMediaTypeId.SelectedItem.Value == "")
                {
                    MessageBox("Please Select Media type");
                    return;
                }

                if (FileUpload1.HasFile)
                {
                    string strContentType = FileUpload1.PostedFile.ContentType;
                    string strFileName = FileUpload1.FileName;
                    if (File.Exists(strFileName))
                    {
                        File.Delete(strFileName);
                    }

                    string strFileSavePath = Server.MapPath("~/DATA_CAPTURE/") ;
                    string strPath = Server.MapPath("~/DATA_CAPTURE/" + FileUpload1.FileName);
                    FileUpload1.SaveAs(strPath);
             
                    txtFilePath.Text = strFileName;
                    txtFileName.Text = strFileName;
                    //copyFileFromLocalToRemote(strFileSavePath, strFileName);
                    moveFile(strPath, strFileName);
                    FileUpload1.DataBind();
                    FileUpload1.Dispose();
                    attendenceProcess(strFileName);
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
        }

        public void attendenceProcess(string strFileName)
        {


            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.UnitId = "";
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.SectionId = "";
            }
            if (ddlMediaTypeId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.MediaTypeId = ddlMediaTypeId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.MediaTypeId = "";
            }
            objSalaryDTO.FileName = strFileName;
            objSalaryDTO.FromDate = dtpFromDate.Text;
            objSalaryDTO.ToDate = dtpToDate.Text;


            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objSalaryBLL.attendenceProcess(objSalaryDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }

        public void showTextData(string strPath)
        {

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("SL", typeof(string)),
            new DataColumn("CARD_NO", typeof(string)),
         
            new DataColumn("LOG_DATE", typeof(string)),
            new DataColumn("LOG_TIME",typeof(string)) });


            string strRead = File.ReadAllText(strPath);
            foreach (string row in strRead.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;
                    foreach (string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }


            }

            gvEmployeeLogList.DataSource = dt;
            gvEmployeeLogList.DataBind();

            if (dt.Rows.Count > 0)
            {
                gvEmployeeLogList.DataSource = dt;
                gvEmployeeLogList.DataBind();
                string strMsg = "TOTAL " + gvEmployeeLogList.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
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

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }

        }

       

        //public void fetchData(string strPath)
        //{
        //    DataTable dt = new DataTable();
        //    bool isFirstRowHeader = true;
        //    string[] columnFirst = new string[] { "" };

        //    using (TextFieldParser parser = new TextFieldParser(strPath))
        //    {

        //        parser.TrimWhiteSpace = true;
        //        parser.TextFieldType = FieldType.Delimited;
        //        parser.SetDelimiters(",");
        //        if (isFirstRowHeader)
        //        {

        //            columnFirst = parser.ReadFields();
        //            foreach (string strFirst in columnFirst)
        //            {
        //                DataColumn strCardNo = new DataColumn(strFirst.Trim().ToLower(), Type.GetType("System.String"));
        //                //DataColumn strLogCount = new DataColumn(strFirst.Trim().ToLower(), Type.GetType("System.String"));
        //                //DataColumn strLogDate = new DataColumn(strFirst.Trim().ToLower(), Type.GetType("System.String"));
        //                //DataColumn strLogTime = new DataColumn(strFirst.Trim().ToLower(), Type.GetType("System.String"));

        //                dt.Columns.Add(strCardNo);
        //                //dt.Columns.Add(strLogCount);
        //                //dt.Columns.Add(strLogDate);
        //                //dt.Columns.Add(strLogTime);

        //            }
        //        }

        //        while (true)
        //        {
        //            if (isFirstRowHeader == false)
        //            {
        //                string[] parts = parser.ReadFields();
        //                if (parts == null)
        //                {

        //                    break;
        //                }

        //                dt.Rows.Add(parts);
        //            }

        //            isFirstRowHeader = false; 
        //        }
        //        gvEmployeeLogList.DataSource = dt;
        //        gvEmployeeLogList.DataBind();
  
        //    }
        


        //}
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void getDirectoryName()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            //start: old code
            //objLookUpDTO = objLookUpBLL.getDirectoryName(strHeadOfficeId, strBranchOfficeId);
            //txtDataUploadDir.Text = objLookUpDTO.DataUploadDir;
            //end: old code

            //start: new code
            txtDataUploadDir.Text = objLookUpBLL.GetDirectoryPath();
            //end: new code

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

        public void getDate()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getDate();

            dtpFromDate.Text = objLookUpDTO.FromDate;
            dtpToDate.Text = objLookUpDTO.FromDate;



        }


        public void uploadEmpLogData()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();



            objEmployeeDTO.FileName = txtFileName.Text;
            objEmployeeDTO.FilePath = txtFilePath.Text;



            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.uploadEmpLogData(objEmployeeDTO);
            MessageBox(strMsg);


        }

        #endregion


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


        }

        protected void gvEmployeeLogList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            gvEmployeeLogList.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }

        #endregion

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

                //uploadEmpLogData();
                //searchEmpLogFile();
                //readTextFile();


                saveEmployeeLogData();

            }

            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

        public void saveEmployeeLogData()
        {


            DataTable dt = new DataTable();
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strCardNo = "";
            string strLogCount = "";
            string strLogDate = "";
            string strLogTime = "";
            string strMsg = "";
            //foreach (GridViewRow row in gvEmployeeLogList.Rows)
            //{
            for (int i = 0; i < gvEmployeeLogList.Rows.Count; i++)
            {

                strCardNo = gvEmployeeLogList.Rows[i].Cells[0].Text;
                strLogCount = gvEmployeeLogList.Rows[i].Cells[1].Text;
                strLogDate = gvEmployeeLogList.Rows[i].Cells[2].Text;
                strLogTime = gvEmployeeLogList.Rows[i].Cells[3].Text;

                //strCardNo = row.Cells[0].Text;
                //strLogCount = row.Cells[1].Text;
                //strLogDate = row.Cells[2].Text;
                //strLogTime = row.Cells[3].Text;

                //dt.Rows.Add(strCardNo, strLogCount, strLogDate, strLogTime);

                //}
                //if (dt.Rows.Count > 0)
                //{

                objEmployeeDTO.CardNo = strCardNo;
                objEmployeeDTO.LogCount = strLogCount;
                objEmployeeDTO.LogDate = strLogDate;
                objEmployeeDTO.LogTime = strLogTime;
                

                objEmployeeDTO.FileName = txtFileName.Text;
                objEmployeeDTO.FilePath = txtFilePath.Text;
                objEmployeeDTO.UpdateBy = strEmployeeId;
                objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                strMsg = objEmployeeBLL.saveEmployeeLogData(objEmployeeDTO);
               


                // }

            }

            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }


        public void searchEmpLogFile()
        {



            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();


            DataTable dt = new DataTable();



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

            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.FromDate = dtpFromDate.Text;
            objEmployeeDTO.ToDate = dtpToDate.Text;

            dt = objEmployeeBLL.searchEmpLogFile(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeLogList.DataSource = dt;
                gvEmployeeLogList.DataBind();
                int count = ((DataTable)gvEmployeeLogList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
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

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }







        }
        public void readAndShowEmpLogData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EMPLOYEE_ID", typeof(String));
            dt.Columns.Add("CARD_NO.", typeof(String));
            dt.Columns.Add("LOG_DATE", typeof(String));
            dt.Columns.Add("LOGIN_TIME", typeof(String));
            dt.Columns.Add("LOGOUT_TIME", typeof(String));

            string strFileName = txtFileName.Text;
            string strFilePath = txtFilePath.Text;

            string line;
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    var row = dt.NewRow();
                    for (int i = 0; i < parts.Length; i++)
                    {
                        row[i] = parts[i];
                    }
                   
                }
                gvEmployeeLogList.DataSource = dt;
                gvEmployeeLogList.DataBind();
                sr.Close();
            }


        }



        public void readTextFile(string strPath)
        {


            try
            {

                deleteEmployeeLog();

               
                string sFileName = strPath;
                int lineNo = 0;
                string strLine = "";

                using (objStreamReader = new StreamReader(sFileName, true))
                {
                    string strCardNo = "";

                    string strDay = "";
                    string strMonth = "";
                    string strYear = "";
                    string strLogDate = "";
                    string strLogTime = "";
                    string strLogHour = "";
                    string strLogMinite = "";

                    while ((strLine = objStreamReader.ReadLine()) != null)
                    {

                        lineNo++;

                        strCardNo = strLine.Substring(5, 10).Trim();
                        strYear = strLine.Substring(16, 4).Trim();
                        strMonth = strLine.Substring(20, 2).Trim();
                        strDay = strLine.Substring(22, 2).Trim();
                        strLogHour = strLine.Substring(26, 2).Trim();
                        strLogMinite = strLine.Substring(28, 2).Trim();

                        strLogDate = strDay + "/" + strMonth + "/" + strYear;
                        strLogTime = strLogHour + ":" + strLogMinite;



                        saveEmployeeLogData(strCardNo, strLogDate, strLogTime);


                    }
                    
                    objStreamReader.Dispose();
                    objStreamReader.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    employeeLogDataProcess();

                }

                objStreamReader.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //processDailyAttendenceSheet();
                //searchEmpLogFile();

            }
            catch (Exception ex)
            {
                objStreamReader.Dispose();
                objStreamReader.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }
        public void readTextFileForPower(string strPath)
        {


            try
            {

                deleteEmployeeLog();


                string sFileName = strPath;
                int lineNo = 0;
                string strLine = "";

                using (objStreamReader = new StreamReader(sFileName))
                {
                    string strCardNo = "";

                    string strDay = "";
                    string strMonth = "";
                    string strYear = "";
                    string strLogDate = "";
                    string strLogTime = "";
                    string strLogHour = "";
                    string strLogMinite = "";

                    while ((strLine = objStreamReader.ReadLine()) != null)
                    {

                        lineNo++;

                       
                        strLogDate = strLine.Substring(1, 10).Trim();
                        strCardNo = strLine.Substring(12, 10).Trim();
                        strMonth = strLine.Substring(1, 2).Trim();
                        strDay = strLine.Substring(22, 2).Trim();
                        strLogHour = strLine.Substring(26, 2).Trim();
                        strLogMinite = strLine.Substring(28, 2).Trim();

                        strLogDate = strDay + "/" + strMonth + "/" + strYear;
                        strLogTime = strLogHour + ":" + strLogMinite;



                        saveEmployeeLogData(strCardNo, strLogDate, strLogTime);


                    }

                    objStreamReader.Dispose();
                    objStreamReader.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    employeeLogDataProcess();

                }

                objStreamReader.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //processDailyAttendenceSheet();
                //searchEmpLogFile();

            }
            catch (Exception ex)
            {
                objStreamReader.Dispose();
                objStreamReader.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }
        public void readTextFileForJK(string strPath)
        {


            try
            {

                deleteEmployeeLog();


                string sFileName = strPath;
                int lineNo = 0;
                string strLine = "";

                using (objStreamReader = new StreamReader(sFileName))
                {
                    string strCardNo = "";

                    string strDay = "";
                    string strMonth = "";
                    string strYear = "";
                    string strLogDate = "";
                    string strLogTime = "";
                    string strLogHour = "";
                    string strLogMinite = "";

                    while ((strLine = objStreamReader.ReadLine()) != null)
                    {

                        lineNo++;

                        strCardNo = strLine.Substring(5, 10).Trim();
                        strYear = strLine.Substring(16, 4).Trim();
                        strMonth = strLine.Substring(20, 2).Trim();
                        strDay = strLine.Substring(22, 2).Trim();
                        strLogHour = strLine.Substring(26, 2).Trim();
                        strLogMinite = strLine.Substring(28, 2).Trim();

                        strLogDate = strDay + "/" + strMonth + "/" + strYear;
                        strLogTime = strLogHour + ":" + strLogMinite;



                        saveEmployeeLogData(strCardNo, strLogDate, strLogTime);


                    }

                    objStreamReader.Dispose();
                    objStreamReader.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    employeeLogDataProcess();

                }

                objStreamReader.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //processDailyAttendenceSheet();
                //searchEmpLogFile();

            }
            catch (Exception ex)
            {
                objStreamReader.Dispose();
                objStreamReader.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }
        
        public void readTextFileForMAL(string strPath)
        {
           
            try
            {

               
                deleteEmployeeLog();


               
                string sFileName = strPath;
                int lineNo = 0;
                string strLine = "";

                using (objStreamReader = new StreamReader(sFileName))
                {
                    string strCardNo = "";

                    string strDay = "";
                    string strMonth = "";
                    string strYear = "";
                    string strLogDate = "";
                    string strLogTime = "";
                    string strLogHour = "";
                    string strLogMinite = "";

                   

                    while ((strLine = objStreamReader.ReadLine()) != null)
                    {

                        lineNo++;

                        strCardNo = strLine.Substring(2, 8).Trim();
                        strYear = strLine.Substring(23, 5).Trim();
                        strMonth = strLine.Substring(28, 2).Trim();
                        strDay = strLine.Substring(30, 2).Trim();
                        strLogHour = strLine.Substring(35, 2).Trim();
                        strLogMinite = strLine.Substring(37, 2).Trim();

                        strLogDate = strDay + "/" + strMonth + "/" + strYear;
                        strLogTime = strLogHour + ":" + strLogMinite;

                        saveEmployeeLogData(strCardNo, strLogDate, strLogTime);


                    }


                    objStreamReader.Dispose();
                    objStreamReader.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    employeeLogDataProcess();

                }

                objStreamReader.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
              
                //processDailyAttendenceSheet();
                //searchEmpLogFile();

            }

            catch (Exception ex)
            {
                objStreamReader.Dispose();
                objStreamReader.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
               
            }
        }
        public void readTextFileForBP(string strPath)
        {

            try
            {

                deleteEmployeeLog();


               
                string sFileName = strPath;
                int lineNo = 0;
                string strLine = "";

                using (objStreamReader = new StreamReader(sFileName, true))
                {
                    string strCardNo = "";

                    string strDay = "";
                    string strMonth = "";
                    string strYear = "";
                    string strLogDate = "";
                    string strLogTime = "";
                    string strLogHour = "";
                    string strLogMinite = "";

                    while ((strLine = objStreamReader.ReadLine()) != null)
                    {

                        lineNo++;

                        strCardNo = strLine.Substring(27, 10).Trim();
                        strYear = strLine.Substring(49, 4).Trim();
                        strMonth = strLine.Substring(54, 2).Trim();
                        strDay = strLine.Substring(57, 2).Trim();
                        strLogHour = strLine.Substring(60, 2).Trim();
                        strLogMinite = strLine.Substring(63, 2).Trim();

                        strLogDate = strDay + "/" + strMonth + "/" + strYear;
                        strLogTime = strLogHour + ":" + strLogMinite;

                        saveEmployeeLogData(strCardNo, strLogDate, strLogTime);


                    }


                    objStreamReader.Dispose();
                    objStreamReader.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    employeeLogDataProcess();

                }

                objStreamReader.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                //processDailyAttendenceSheet();
                //searchEmpLogFile();

            }

            catch (Exception ex)
            {
                objStreamReader.Dispose();
                objStreamReader.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

        }

        private static DataTable GetDataTableFromCSVFile(string csvfilePath)
        {
            DataTable csvData = new DataTable();
            using (TextFieldParser csvReader = new TextFieldParser(csvfilePath))
            {
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;

                //Read columns from CSV file, remove this line if columns not exits 
                string[] colFields = csvReader.ReadFields();

                foreach (string column in colFields)
                {
                    DataColumn datecolumn = new DataColumn(column);
                    datecolumn.AllowDBNull = true;
                    csvData.Columns.Add(datecolumn);
                }

                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    //Making empty value as null
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }
                    csvData.Rows.Add(fieldData);
                }
            }
            return csvData;
        }
        public void saveEmployeeLogData(string strCardNo, string strLogDate, string strLogTime)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();


            objEmployeeDTO.CardNo = strCardNo;
            objEmployeeDTO.LogDate = strLogDate;
            objEmployeeDTO.LogTime = strLogTime;

            objEmployeeDTO.FileName = txtFileName.Text;
            objEmployeeDTO.FilePath = txtFilePath.Text;


            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.saveEmployeeLogData(objEmployeeDTO);
            lblMsg.Text = strMsg;
            //MessageBox(strMsg);


        }
        public void deleteEmployeeLog()
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();


            objEmployeeDTO.FromDate = dtpFromDate.Text;
            objEmployeeDTO.ToDate = dtpToDate.Text;

            objEmployeeDTO.FileName = txtFileName.Text;
            objEmployeeDTO.FilePath = txtFilePath.Text;
         
            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.deleteEmployeeLog(objEmployeeDTO);
            //lblMsg.Text = strMsg;
         
        }

        public void employeeLogProcess()
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.FileName = txtFileName.Text;

            objEmployeeDTO.FromDate = dtpFromDate.Text;
            objEmployeeDTO.ToDate = dtpToDate.Text;

            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.employeeLogProcess(objEmployeeDTO);
            //lblMsg.Text = strMsg;

        }

        public void employeeLogDataProcess()
        {
            
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            
            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.UnitId = "";
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.SectionId = "";
            }

            objSalaryDTO.FromDate = dtpFromDate.Text;
            objSalaryDTO.ToDate = dtpFromDate.Text;
            
            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objSalaryBLL.employeeLogDataProcess(objSalaryDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }
        public void processDailyAttendenceSheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();





            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.SectionId = "";
            }



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.UnitId = "";

            }


            objReportDTO.UpdateBy = strEmployeeId;
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objReportBLL.processDailyAttendenceSheet(objReportDTO);




        }
        public void processDailyAttendenceSheetBuyer()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();
            
            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.SectionId = "";
            }
            
            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.UnitId = "";
            }
            objReportDTO.EmployeeId = "";
            objReportDTO.UpdateBy = strEmployeeId;
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            
            string strMsg = objReportBLL.processDailyAttendenceSheetBuyer(objReportDTO);
                        
        }

        public void rptAttendenceSheet()
        {
            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                                
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;
                objReportDTO.OTMunite = txtOTMinute.Text;


                if (ddlSittingType.SelectedValue.ToString() != "")
                {
                    objReportDTO.SittingTypeId = ddlSittingType.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SittingTypeId = "";
                }
                if (ddlFloor.SelectedValue.ToString() != "")
                {
                    objReportDTO.FloorId = ddlFloor.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.FloorId = "";
                }
                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
                }
                
                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";
                }
                               
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAttendenceSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.dailyAttendenceSheet(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                                
                reportMaster();

                //this.ClientScript.RegisterStartupScript(this.GetType(), "OpenReport", "<script language=javascript>window.open('frmViewReport.aspx?report=defectleakage','Report');</script>");

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }


        }

        //rptAttendanceSummary
        public void GetAttendanceSummary()
        {
            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();
                                
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
                }

                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";
                }

                objEmployeeBLL.PrepareAttendanceSummary(objReportDTO);

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptAttendanceSummary.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetAttendanceSummary(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster();

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }


        }


        public void rptAttendenceSheetHO()
        {
            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                //processDailyAttendenceSheet();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;




                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {

                    objReportDTO.SectionId = "";
                }


                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";

                }



                string strPath = Path.Combine(Server.MapPath("~/Reports/rpDailyAttendenceSheetMonthlyHONew.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.dailyAttendenceSheetHO(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster();

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }


        }
        public void rptAttendenceSheetBuyer()
        {
            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                                
                processDailyAttendenceSheetBuyer();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;
                objReportDTO.CardNo = txtCardNo.Text;



                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {

                    objReportDTO.SectionId = "";
                }


                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";

                }



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAttendenceSheetBuyer.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.dailyAttendenceSheetBuyer(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster();

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }


        }
        public void processDailyAbsenceSheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();
            
            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.SectionId = "";
            }
            

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.UnitId = "";

            }
            
            objReportDTO.UpdateBy = strEmployeeId;
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            
            string strMsg = objReportBLL.processDailyAbsenceSheet(objReportDTO);
            
        }
        public void attendenceSheetLate()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.FromDate = dtpFromDate.Text;
            objReportDTO.ToDate = dtpToDate.Text;


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.SectionId = "";
            }



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.UnitId = "";

            }


            objReportDTO.UpdateBy = strEmployeeId;
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objReportBLL.attendenceSheetLate(objReportDTO);




        }


        public void rptAttendenceSheetLate()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                        
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                
                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;
                
                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
                }

                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";
                }

                objReportDTO.CardNo = txtCardNo.Text;

                if (txtLateLimit.Text != string.Empty)
                {
                    objReportDTO.LateLimit = Convert.ToInt32(txtLateLimit.Text);
                }
                else
                {
                    objReportDTO.LateLimit = 0;
                }

                if (ddlSittingType.SelectedValue.ToString() != "")
                {
                    objReportDTO.SittingTypeId = ddlSittingType.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SittingTypeId = "";
                }

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAttendenceLateSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.dailyAttendenceLateSheet(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster();

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

        }

        public void rptAttendenceSheetWithLate()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
                }

                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";
                }

                objReportDTO.CardNo = txtCardNo.Text;

                if (txtLateLimit.Text != string.Empty)
                {
                    objReportDTO.LateLimit = Convert.ToInt32(txtLateLimit.Text);
                }
                else
                {
                    objReportDTO.LateLimit = 0;
                }

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAttendenceWithLateSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.dailyAttendenceWithLateSheet(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster();

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

        }

        public void rptAbsenceSheet()
        {
            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                
                processDailyAbsenceSheet();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.CardNo = txtCardNo.Text;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;

                if (ddlSittingType.SelectedValue.ToString() != "")
                {
                    objReportDTO.SittingTypeId = ddlSittingType.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SittingTypeId = "";
                }

                if (ddlFloor.SelectedValue.ToString() != "")
                {
                    objReportDTO.FloorId = ddlFloor.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.FloorId = "";
                }
                
                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
                }
                
                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";
                }
                
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptDailyAbsenceSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.dailyAbsenceSheet(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster();


                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            catch (Exception ex)
            {

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }


        }
        public void rptWorkerOverTimeSheet()
        {
            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                                
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.EmployeeId = "";
                
                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;
                objReportDTO.CardNo = txtCardNo.Text;
                
                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {

                    objReportDTO.SectionId = "";
                }


                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";

                }



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyOverTimeSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptWorkerOverTimeSheet(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster();

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

            catch (Exception ex)
            {

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }


        }
        public void reportMaster()
        {

            if (chkPDF.Checked == true)
            {

                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                ReportDocument crReportDocument = new ReportDocument();
                Response.Clear();
                Response.Buffer = true;

                formatType = ExportFormatType.PortableDocFormat;
                System.IO.Stream oStream = null;
                byte[] byteArray = null;

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                oStream = rd.ExportToStream(formatType);
                byteArray = new byte[oStream.Length];
                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(byteArray);
                Response.Flush();
                Response.Close();
                rd.Close();
                rd.Dispose();
            }
             if (chkExcel.Checked == true)
            {

                //CrystalReportViewer1.ReportSource = rd;
                //CrystalReportViewer1.DataBind();

                //formatType = ExportFormatType.Excel;
                //MemoryStream oStream;
                //Response.Clear();
                //Response.Buffer = false;
                //Response.ClearContent();
                //Response.ClearHeaders();

                //oStream = (MemoryStream)rd.ExportToStream(formatType);
                //Response.ContentType = "application/vnd.ms-excel";
                //oStream.Seek(0, SeekOrigin.Begin);
                //Response.BinaryWrite(oStream.ToArray());
                ////Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();

                rd.ExportToHttpResponse
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "attendence_report");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }
           



        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (dtpFromDate.Text == string.Empty)
            {
                string strMsg = "Please Enter From Date!!";
                dtpFromDate.Focus();
                MessageBox(strMsg);
                return; 
            }
            else if (dtpToDate.Text == string.Empty)
            {
                string strMsg = "Please Enter To Date!!";
                dtpToDate.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {
                //processDailyAttendenceSheet();
                searchEmpLogFile();

            }
        }

        protected void btnLogProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                employeeLogDataProcess();
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnAttendenceSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (dtpToDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter To Date!!";
                    dtpToDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else
                {
                    rptAttendenceSheet();
                }
            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }

        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {
                chkPDF.AutoPostBack = true;
                chkExcel.Checked = false;
           
            }
        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkExcel.AutoPostBack = true; 
                chkPDF.Checked = false;
           

            }
        }

        protected void btnAttendenceSheetLate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (dtpToDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter To Date!!";
                    dtpToDate.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else
                {      
                    rptAttendenceSheetLate();
                }
            }
            catch (Exception ex)
            {

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }

        protected void btnAbsenceSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (dtpToDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter To Date!!";
                    dtpToDate.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else
                {

                    rptAbsenceSheet();

                }


            }
            catch (Exception ex)
            {

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }

        protected void btnMonthlySheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (dtpToDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter To Date!!";
                    dtpToDate.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else
                {
                    GetOverTimeDetailSheet();
                    //rptWorkerOverTimeSheet();

                }


            }
            catch (Exception ex)
            {

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }
        public void GetOverTimeDetailSheet()
        {
            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.EmployeeId = "";

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;
                objReportDTO.CardNo = txtCardNo.Text;

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {

                    objReportDTO.SectionId = "";
                }


                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";

                }



                string strPath = Path.Combine(Server.MapPath("~/Reports/RptOTDetailSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetOverTimeDetailSheet(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster();

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        protected void btnMonthlyAttendenceSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (dtpToDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter To Date!!";
                    dtpToDate.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else
                {

                    rptAttendenceSheet();

                }


            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnAttendenceSheetBuyer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (dtpToDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter To Date!!";
                    dtpToDate.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else
                {

                    rptAttendenceSheetBuyer();

                }


            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }
                
        #region "Crystal Report Functionality"

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            

                ReportDocument rd = new ReportDocument();
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            

        }

        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {

            this.CrystalReportViewer1.ReportSource = null;

            CrystalReportViewer1.Dispose();

            if (rd != null)
            {

                rd.Close();

                rd.Dispose();

                rd = null;

            }

            GC.Collect();

            GC.WaitForPendingFinalizers();

        }

        protected void btnAttendenceSheetHO_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (dtpToDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter To Date!!";
                    dtpToDate.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else
                {

                    rptAttendenceSheetHO();

                }


            }
            catch (Exception ex)
            {

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }

        protected void btnIftarTimeEntry_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FileUpload2.HasFile)
                {
                    MessageBox("Please browse prescribed excel file");
                    return;
                }

                int counter = 0;
                ReportBLL objReportBLL = new ReportBLL();
                List<IfratTimeSheetDTO> objIfratTimeSheetDTOs = GetIftarTimeSheet();
                foreach (var objIfratTimeSheetDTO in objIfratTimeSheetDTOs)
                {
                    string strMsg = objReportBLL.ProcessIftarTimeSheet(objIfratTimeSheetDTO);
                    if (strMsg == "")
                        counter = counter + 1;
                }

                if (counter == 0)
                    MessageBox("No record updated");
                else if (objIfratTimeSheetDTOs.Count != counter)
                    MessageBox("All records has not been updated");
                else if (objIfratTimeSheetDTOs.Count == counter)
                    MessageBox("All records updated successfully");
            }
            catch (Exception ex)
            {
            }
        }

        private List<IfratTimeSheetDTO> GetIftarTimeSheet()
        {
            string path = string.Empty;
            string fileName = string.Empty;
            string folderPath = string.Empty;

            string ConStr = "";
            OleDbConnection conn = null;
            List<IfratTimeSheetDTO> objIfratTimeSheetDTOs = new List<IfratTimeSheetDTO>();
            try
            {
                if (FileUpload2.HasFile)
                {
                    fileName = FileUpload2.PostedFile.FileName;
                    folderPath = Server.MapPath("~/TempImageFiles");
                    path = folderPath + "/" + fileName;
                }
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string ext = Path.GetExtension(FileUpload2.FileName).ToLower();
                
                FileUpload2.SaveAs(path);
                if (ext.Trim() == ".xls")
                {
                    ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                }
                else if (ext.Trim() == ".xlsx")
                {
                    ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;";
                }

                string query = "SELECT * FROM [Sheet1$]";

                conn = new OleDbConnection(ConStr);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                var data = ds.Tables[0];

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(data.Rows[i][0].ToString()))
                    {
                        if (data.Rows[i][0].ToString() != "UnitId")
                        {
                            IfratTimeSheetDTO objIfratTimeSheetDTO = new IfratTimeSheetDTO();
                            objIfratTimeSheetDTO.UnitId = data.Rows[i][0].ToString();
                            objIfratTimeSheetDTO.UnitName = data.Rows[i][1].ToString();

                            objIfratTimeSheetDTO.SectionId = data.Rows[i][2].ToString();
                            objIfratTimeSheetDTO.SectionName = data.Rows[i][3].ToString();

                            objIfratTimeSheetDTO.FromDate = data.Rows[i][4].ToString();
                            objIfratTimeSheetDTO.ToDate = data.Rows[i][5].ToString();

                            objIfratTimeSheetDTO.InTime = data.Rows[i][6].ToString();
                            objIfratTimeSheetDTO.OutTime = data.Rows[i][7].ToString();

                            objIfratTimeSheetDTO.LunchIn = data.Rows[i][8].ToString();
                            objIfratTimeSheetDTO.LunchOut = data.Rows[i][9].ToString();
                            objIfratTimeSheetDTO.IftarTime = data.Rows[i][10].ToString();

                            objIfratTimeSheetDTO.IftarStartTime = objIfratTimeSheetDTO.IftarTime.Split('-')[0];
                            objIfratTimeSheetDTO.IftarEndTime = objIfratTimeSheetDTO.IftarTime.Split('-')[1];

                            objIfratTimeSheetDTO.IftarHour = Math.Floor(Convert.ToDecimal((DateTime.Parse(objIfratTimeSheetDTO.IftarEndTime, System.Globalization.CultureInfo.CurrentCulture) - DateTime.Parse(objIfratTimeSheetDTO.IftarStartTime, System.Globalization.CultureInfo.CurrentCulture)).TotalHours)).ToString();
                            objIfratTimeSheetDTO.IftarMinute = ((DateTime.Parse(objIfratTimeSheetDTO.IftarEndTime, System.Globalization.CultureInfo.CurrentCulture) - DateTime.Parse(objIfratTimeSheetDTO.IftarStartTime, System.Globalization.CultureInfo.CurrentCulture)).TotalMinutes - Convert.ToDouble(objIfratTimeSheetDTO.IftarHour) * 60).ToString();

                            objIfratTimeSheetDTOs.Add(objIfratTimeSheetDTO);
                        }
                    }
                }

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                if (File.Exists(path) == true)
                {
                    File.Delete(path);
                }
            }

            catch (Exception ex)
            {
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                if (File.Exists(path) == true)
                {
                    File.Delete(path);
                }
            }
            return objIfratTimeSheetDTOs;
        }

        protected void btnAttendanceSummary_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                 if (dtpToDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter To Date!!";
                    dtpToDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                //if (ddlUnitId.SelectedItem.Value == " ")
                //{
                //    string strMsg = "Please Select unit!!";
                //    dtpFromDate.Focus();
                //    MessageBox(strMsg);
                //    return;
                //}
                //else if (ddlSectionId.SelectedItem.Value == " ")
                //{
                //    string strMsg = "Please Select Section!!";
                //    dtpToDate.Focus();
                //    MessageBox(strMsg);
                //    return;
                //}
                //else
                //{
                     //rptAttendenceSheet();
                    GetAttendanceSummary();
               // }
            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }

        protected void btnFacStaffAndWokerWithoutPunch_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();

                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }

                //if (ddlFloor.SelectedValue.ToString() != "")
                //{
                //    objReportDTO.FloorId = ddlFloor.SelectedValue.ToString();
                //}
                //else
                //{
                //    objReportDTO.FloorId = "";
                //}

                GetEmployeeSheetWOPunch();
               
            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        protected void btnEmpListWithoutPunchOBranch_Click(object sender, EventArgs e)
        {

            try
            {
                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                //else if (dtpToDate.Text == string.Empty)
                //{
                //    string strMsg = "Please Enter To Date!!";
                //    dtpToDate.Focus();
                //    MessageBox(strMsg);
                //    return;
                //}
                //else
                //{
                    GetEmployeeSheetWOPunchOtherBranch();
                //}
            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        protected void BtnEmpListWithoutOutPunch_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (dtpToDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter To Date!!";
                    dtpToDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else
                {
                    GetEmployListWithoutOutPunch();
                }
            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public void GetEmployeeSheetWOPunch()
        {
            try
            {
                
                EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                objEmployeeDTO.LogDate = dtpFromDate.Text;
                objEmployeeDTO.UpdateBy = strEmployeeId;
                objEmployeeDTO.FromDate = dtpFromDate.Text;
                objEmployeeDTO.ToDate = dtpToDate.Text;
                objEmployeeDTO.CardNo = txtCardNo.Text;
                objEmployeeDTO.FloorId = ddlFloor.SelectedValue.ToString();


                string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmpListWithoutPunch.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objEmployeeBLL.GetUnpunchedHomeEmployee(objEmployeeDTO));
                
                //new
                //ReportDTO objReportDTO = new ReportDTO();
                //ReportBLL objReportBLL = new ReportBLL();

                //objReportDTO.HeadOfficeId = strHeadOfficeId;
                //objReportDTO.BranchOfficeId = strBranchOfficeId;
                //objReportDTO.UpdateBy = strEmployeeId;
                //objReportDTO.FromDate = dtpFromDate.Text;
                //objReportDTO.ToDate = dtpToDate.Text;
                //objReportDTO.CardNo = txtCardNo.Text;

                //string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmpListWithoutPunch.rpt"));
                //this.Context.Session["strReportPath"] = strPath;
                //rd.Load(strPath);
                //rd.SetDataSource(objReportBLL.GetEmployeeSheetWOPunch(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                reportMaster();
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }
        public void GetEmployeeSheetWOPunchOtherBranch()
        {
            try
            {
                EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();
                //new

                objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                objEmployeeDTO.UpdateBy = strEmployeeId;

                objEmployeeDTO.LogDate = dtpFromDate.Text;

                objEmployeeDTO.FromDate = dtpFromDate.Text;
                objEmployeeDTO.ToDate = dtpToDate.Text;
                objEmployeeDTO.CardNo = txtCardNo.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmpListWithoutPunch.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objEmployeeBLL.GetUnpunchedForeignEmployee(objEmployeeDTO));

                //old
                //ReportDTO objReportDTO = new ReportDTO();
                //ReportBLL objReportBLL = new ReportBLL();

                //objReportDTO.HeadOfficeId = strHeadOfficeId;
                //objReportDTO.BranchOfficeId = strBranchOfficeId;
                //objReportDTO.UpdateBy = strEmployeeId;
                //objReportDTO.FromDate = dtpFromDate.Text;
                //objReportDTO.ToDate = dtpToDate.Text;
                //objReportDTO.CardNo = txtCardNo.Text;

                //string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmpListWithoutPunch.rpt"));
                //this.Context.Session["strReportPath"] = strPath;
                //rd.Load(strPath);
                //rd.SetDataSource(objReportBLL.GetEmployeeSheetWOPunchOtherBranch(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                reportMaster();
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }

        public void GetEmployListWithoutOutPunch()
        {
            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;
                objReportDTO.CardNo = txtCardNo.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmpListWithoutPunch.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEmployListWithoutOutPunch(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                reportMaster();
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }

        #endregion

        protected void BtnLogDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                if (dtpToDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter To Date";
                    dtpToDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                if (ddlUnitId.Text != " ")
                {
                    if (ddlSectionId.Text == " ")
                    {
                        string strMsg = "Please Select Section Name!!!";
                        MessageBox(strMsg);
                        ddlUnitId.Focus();
                        return;
                    }
                }
                GetEmployeelogDetailSheet();
            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }
        public void GetEmployeelogDetailSheet()
        {
            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
                }

                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";
                }

                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.HeadOfficeId = strHeadOfficeId;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmployeelogDetail.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEmployeelogDetailSheet(objReportDTO));

                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                reportMaster();
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        protected void BtnActiveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                GetActiveEmployee();
            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }

        public void GetActiveEmployee()
        {
            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                if (ddlSittingType.SelectedValue.ToString() != "")
                {
                    objReportDTO.SittingTypeId = ddlSittingType.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SittingTypeId = "";
                }

                if (ddlFloor.SelectedValue.ToString() != "")
                {
                    objReportDTO.FloorId = ddlFloor.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.FloorId = "";
                }

                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";
                }

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
                }

                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.HeadOfficeId = strHeadOfficeId;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmployeelogDetail.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetActiveEmployee(objReportDTO));

                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                reportMaster();
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        protected void BtnHOEmpListWithoutOutPunch_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }

                GetHOEmployListWithoutOutPunch();

            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        public void GetHOEmployListWithoutOutPunch()
        {
            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;
                objReportDTO.CardNo = txtCardNo.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmpListWithoutPunch.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetHOEmployListWithoutOutPunch(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                reportMaster();
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }

        protected void BtnAttendanceLate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (dtpToDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter To Date!!";
                    dtpToDate.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else
                {
                    rptAttendenceSheetWithLate();
                }
            }
            catch (Exception ex)
            {

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
        }
    }
}