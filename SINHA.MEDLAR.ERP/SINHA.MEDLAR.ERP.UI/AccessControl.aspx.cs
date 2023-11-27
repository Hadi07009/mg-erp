using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SINHA.MEDLAR.ERP.BLL;
using SINHA.MEDLAR.ERP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AccessControl : System.Web.UI.Page
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
                getUnitId();
                getSectionId();
                GetFloorDropdown();
                getOfficeName();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
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
        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {
                chkExcel.Checked = false;
            }
            else
            {
                chkPDF.Checked = true;
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

                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet_worker");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }
            //else
            //{

            //    CrystalReportViewer1.ReportSource = rd;
            //    CrystalReportViewer1.DataBind();

            //    formatType = ExportFormatType.PortableDocFormat;
            //    MemoryStream oStream;
            //    Response.Clear();
            //    Response.Buffer = false;
            //    Response.ClearContent();
            //    Response.ClearHeaders();

            //    oStream = (MemoryStream)rd.ExportToStream(formatType);
            //    Response.ContentType = "application/Pdf";
            //    oStream.Seek(0, SeekOrigin.Begin);
            //    Response.BinaryWrite(oStream.ToArray());
            //    //Response.End();
            //    oStream.Flush();
            //    oStream.Close();
            //    oStream.Dispose();
            //    CrystalReportViewer1.RefreshReport();

            //}



        }
        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkPDF.Checked = false;
            }
            else
            {
                chkExcel.Checked = true;
            }
        }
        public void Clear()
        {

        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        #region "Grid View GridViewCaseInfo"
        protected void GvEmployeeCache_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvEmployeeCache.PageIndex = e.NewPageIndex;
        }
        protected void GvEmployeeCache_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //int strRowId = GvEmployeeCache.SelectedRow.RowIndex + 1;
            ////string strSLNo = GvEmployeeCache.SelectedRow.Cells[0].Text;
            //string CaseNo = GvEmployeeCache.SelectedRow.Cells[0].Text;
            //string IssueDate = GvEmployeeCache.SelectedRow.Cells[4].Text;
            //string CaseMode = GvEmployeeCache.SelectedRow.Cells[6].Text;
            //string Amount = GvEmployeeCache.SelectedRow.Cells[7].Text;

            //if (CaseTypeId == "&nbsp;")
        }
        protected void GvEmployeeCache_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void GvEmployeeCache_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GvEmployeeCache_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the row that contains the button clicked 
            // by the user from the Rows collection.      
            GridViewRow row = GvEmployeeCache.Rows[index];

            if (e.CommandName == "Select")
            {
                //int strRowId = GvEmployeeCache.SelectedRow.RowIndex + 1;
                //string strSLNo = GvEmployeeCache.SelectedRow.Cells[0].Text;             
            }
            if (e.CommandName == "Edit")
            {
            }
            if (e.CommandName == "Delete")
            {
            }
            if (e.CommandName == "Approve")
            {
                string cacheId = Convert.ToString(GvEmployeeCache.DataKeys[row.RowIndex].Values["cache_id"]);

                EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                objEmployeeDTO = objEmployeeBLL.GetEmployeeCacheByCacheId(cacheId);
                if (objEmployeeDTO.ApproveYn == "Y")
                {
                    MessageBox("Already Approved");
                }
                else
                {
                    ApproveEmployment(cacheId);
                }
            }

            //int selectedRowIndex = GridView1.SelectedRow.RowIndex;
            //GridView1.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";
        }

        public void ApproveEmployment(string cacheId)
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.ApproveEmployment(cacheId, strHeadOfficeId, strBranchOfficeId, strEmployeeId);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }



        protected void GvEmployeeCache_Sorting(object sender, GridViewSortEventArgs e)
        {
        }
        protected void GvEmployeeCache_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GvEmployeeCache, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GvEmployeeCache_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cacheId = Convert.ToString(GvEmployeeCache.DataKeys[e.RowIndex].Values["cache_id"]);

            //try
            //{
            //    EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            //    string employeeId = Convert.ToString(GridViewCaseInfo.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"]);
            //    string msg = objEmployeeBLL.RemoveCase(employeeId);
            //    MessageBox(msg);
            //    LoadCaseInfoGrid();
            //}
            //catch
            //{
            //    MessageBox("Unable To Remove Case");
            //}                      
        }
        public void LoadEmployeeCache()
        {
            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            if (ddlRecognized.SelectedValue.ToString() != "")
            {
                objReportDTO.RecognizeYn = ddlRecognized.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.RecognizeYn = "";
            }

            if (ddlFloor.SelectedValue.ToString() != "")
            {
                objReportDTO.FloorId = ddlFloor.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.FloorId = "";
            }
            objReportDTO.EmployeeId = txtEmployeeId.Text;
            objReportDTO.CardNo = txtCardNo.Text;
            objReportDTO.FromCreateDate = txtFromDate.Text;
            objReportDTO.ToCreateDate = txtToDate.Text;
            objReportDTO.ApproveYn = "Y";
            objReportDTO.Delete_Yn = "N";

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;

            DataTable dt = objReportBLL.GetEmployeeCacheForRecognization(objReportDTO);

            if (dt.Rows.Count > 0)
            {
                GvEmployeeCache.DataSource = dt;
                GvEmployeeCache.DataBind();

                int count = ((DataTable)GvEmployeeCache.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GvEmployeeCache.DataSource = dt;
                GvEmployeeCache.DataBind();
                int totalcolums = GvEmployeeCache.Rows[0].Cells.Count;
                GvEmployeeCache.Rows[0].Cells.Clear();
                GvEmployeeCache.Rows[0].Cells.Add(new TableCell());
                GvEmployeeCache.Rows[0].Cells[0].ColumnSpan = totalcolums;
            }
        }

        #endregion
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadEmployeeCache();
        }

        protected void btnSheet_Click(object sender, EventArgs e)
        {

            try
            {
                GetEmploymentApprovalSheet();
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
        public void GetEmploymentApprovalSheet()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.EmployeeId = txtEmployeeId.Text;
                objReportDTO.CardNo = txtCardNo.Text;
                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();
                objReportDTO.RecognizeYn = ddlRecognized.SelectedItem.Value.Trim();

                objReportDTO.FloorId = ddlFloor.SelectedItem.Value.Trim();

                objReportDTO.ApproveYn = "Y";
                objReportDTO.Delete_Yn = "N";
                objReportDTO.FromCreateDate = txtFromDate.Text;
                objReportDTO.ToCreateDate = txtToDate.Text;
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;



                if (objReportDTO.ApproveYn == "Y") //Approved
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmploymentApprovalSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    //rd.SetDataSource(objReportBLL.GetEmploymentApprovalSheet(objReportDTO));
                    rd.SetDataSource(objReportBLL.GetEmployeeCacheForRecognization(objReportDTO));
                }
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

        public List<string> GetIdentityForAccessControl()
        {
            List<string> identity = new List<string>();

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.EmployeeId = txtEmployeeId.Text;
                objReportDTO.CardNo = txtCardNo.Text;
                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();

                objReportDTO.FloorId = ddlFloor.SelectedItem.Value.Trim();

                objReportDTO.ApproveYn = "Y";
                objReportDTO.RecognizeYn = "N";
                objReportDTO.Delete_Yn = "N";
                objReportDTO.FromCreateDate = txtFromDate.Text;
                objReportDTO.ToCreateDate = txtToDate.Text;
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                var data =  objReportBLL.GetEmployeeCacheForRecognization(objReportDTO);

                List<EmployeeDTO> objEmployeeList = new List<EmployeeDTO>();

                string employeeId = string.Empty;
                string employeeName = string.Empty;
                string line = string.Empty;

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    EmployeeDTO objEmployeeDTO = new EmployeeDTO();

                    employeeId = string.Empty;
                    employeeName = string.Empty;
                    line = string.Empty;

                    employeeId = data.Rows[i]["employee_id"].ToString();
                    employeeName = data.Rows[i]["employee_name"].ToString().Replace(' ', '-');

                    if (employeeName.Length > 18)
                    {
                        employeeName = employeeName.Substring(0, 18);
                    }

                    line = employeeId + "\t" + employeeName;
                    identity.Add(line);

                //objEmployeeList.Add(objEmployeeDTO);
                }   
            }
            catch (Exception ex)
            {
            }
            return identity;
        }
        public void DownloadFile()
        {
            string fileName = string.Empty;
            string filePath = string.Empty;
            string extention = ".txt";
            string downloadFileName = string.Empty;

            System.DateTime moment = DateTime.Now;

            string year = moment.Year.ToString();
            string month = moment.Month.ToString();
            string day = moment.Day.ToString();

            string hour = moment.Hour.ToString();
            string minute = moment.Minute.ToString();
            string second = moment.Second.ToString();

            string dateTime = year + month + day + "_" + hour + minute + second;
            
            downloadFileName = ddlFloor.SelectedItem.Text + "_" + dateTime + extention;

            string dirPath = Server.MapPath("FaceID");
            fileName = "\\User List";
            filePath = dirPath + fileName + extention;
            
            try
            {
                
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                FileStream fs = File.Create(filePath);
                fs.Close();
                var identity = GetIdentityForAccessControl();

                if (identity.Count() > 0)
                {
                    File.WriteAllLines(filePath, identity);

                    System.IO.FileStream fsX = null;
                    fsX = System.IO.File.Open(Server.MapPath("FaceID/" +
                          fileName + ".txt"), System.IO.FileMode.Open);

                    byte[] btFile = new byte[fsX.Length];
                    fsX.Read(btFile, 0, Convert.ToInt32(fsX.Length));
                    fsX.Close();

                    //string sGenName = "var_name";
                    Response.AddHeader("Content-disposition", "attachment; filename=" + downloadFileName);
                    Response.ContentType = "application/octet-stream";
                    Response.BinaryWrite(btFile);
                    Response.End();

                }
                else
                {
                    MessageBox("No Record Found.");
                    return;
                }
                MessageBox("Text File Generated Successfully.");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlRecognized.SelectedValue.ToString() == "")
            {
                string strMsg = "Please Select Recognize";
                MessageBox(strMsg);
                ddlRecognized.Focus();
                return;
            }
            UpdateEmployeeCache();
            LoadEmployeeCache();
        }
        public string UpdateEmployeeCache()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";

            int recordCounter = 0;
            try
            {
                string status = string.Empty;

                foreach (GridViewRow row in GvEmployeeCache.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                        //if (chkEmployee.Checked)
                        //{
                            recordCounter = recordCounter + 1;

                            TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
                            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;

                        //if (ddlRecognized.SelectedValue.ToString() != "")
                        //{
                        //    objEmployeeDTO.RecognizeYn = ddlRecognized.SelectedValue.ToString();
                        //}
                        //else
                        //{
                        //    objEmployeeDTO.RecognizeYn = "";
                        //}

                             if (chkEmployee.Checked)
                             {
                                 objEmployeeDTO.RecognizeYn = "Y";
                             }
                             else
                             {
                                 objEmployeeDTO.RecognizeYn = "N";
                             }

                             objEmployeeDTO.ApproveYn = "Y";

                             if (ddlFloor.SelectedValue.ToString() != "")
                             {
                                 objEmployeeDTO.FloorId = ddlFloor.SelectedValue.ToString();
                             }
                             else
                             {
                                 objEmployeeDTO.FloorId = "";
                             }

                            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                            objEmployeeDTO.CreateBy = strEmployeeId;

                            strMsg = objEmployeeBLL.UpdateEmployeeCache(objEmployeeDTO);
                            
                        //}
                    }
                }
                MessageBox(strMsg);
            }
            catch (Exception ex)
            {
            }
            return strMsg;
        }
        protected void btnTextFie_Click(object sender, EventArgs e)
        {
            try
            {
                // GetIdentityForAccessControl();
                //SaveFle();

                if (ddlFloor.SelectedItem.Text == string.Empty)
                {
                    string msg = "Please Select Floor";
                    lblMsg.Text = msg;
                    MessageBox(msg);
                    return;
                }
                DownloadFile();
                //if (ddlRecognized.SelectedItem.Value != "2")
                //{
                //    string msg = "Please Select Not Recognized";
                //    lblMsg.Text = msg;
                //    MessageBox(msg);
                //    return;
                //}
                //else
                //{
                //    DownloadFile();
                //}
            }
            catch (Exception ex)
            {
            }
        }

        protected void BtnUselessFaceID_Click(object sender, EventArgs e)
        {
            string recordCount = "0";

            if (FileUpload1.HasFile)
            {
                recordCount = UploadExcel();
            }
            else
            {
                MessageBox("File Not Found.");
                return;
            }

            if (recordCount == "0")
            {
                MessageBox("No record added.");
                return;
            }

            //MessageBox(recordCount + " records(s) added.  Click Ok to see useless face id.");

            GetUselessFaceIdSheet();        
        }

        public string UploadExcel()
        {
            //reference: https://www.yogihosting.com/import-excel-asp-net-mvc/
            string recordCount = "0";
           
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            try
            {
                if (FileUpload1.HasFile)
                {

                    string fileName = FileUpload1.FileName;
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }

                    string path = Server.MapPath("~/DATA_CAPTURE/" + FileUpload1.FileName);
                    FileUpload1.SaveAs(path);

                    FileUpload1.DataBind();
                    FileUpload1.Dispose();

                    string excelConnectionString = @"Provider='Microsoft.ACE.OLEDB.12.0';Data Source='" + path + "';Extended Properties='Excel 12.0 Xml;IMEX=1'";
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

                    try
                    {
                        objEmployeeBLL.DeleteFaceId(strBranchOfficeId);

                        excelConnection.Open();
                        string tableName = excelConnection.GetSchema("Tables").Rows[0]["TABLE_NAME"].ToString();
                        excelConnection.Close();

                        OleDbCommand cmd = new OleDbCommand("Select * from [" + tableName + "]", excelConnection);
                        excelConnection.Open();
                        using (OleDbDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                objEmployeeDTO = new EmployeeDTO();
                                objEmployeeDTO.EmployeeId = dr[0] == DBNull.Value ? "" : Convert.ToString(dr[0]).Trim();
                                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                                if (!string.IsNullOrEmpty(objEmployeeDTO.EmployeeId))
                                {
                                    objEmployeeBLL.SaveFaceId(objEmployeeDTO);
                                }
                            }
                        }
                        excelConnection.Close();

                        recordCount = objEmployeeBLL.CountFaceId(strBranchOfficeId);

                        //MessageBox(result + " records(s) added.");
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = ex.Message;
                        if (excelConnection.State.HasFlag(ConnectionState.Open))
                        {
                            excelConnection.Close();
                        }
                    }

                }
                else
                {
                    lblMsg.Text = "File Not Found.";
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
           return recordCount;
        }
        public void GetUselessFaceIdSheet()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.EmployeeId = txtEmployeeId.Text;
                objReportDTO.CardNo = txtCardNo.Text;
                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();

                objReportDTO.FromDate = txtFromDate.Text;
                objReportDTO.ToDate = txtToDate.Text;
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptUselessFaceIdSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetUselessFaceIdSheet(objReportDTO));
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
    }
}