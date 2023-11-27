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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

using System.Web.UI.HtmlControls;
using System.Collections;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class Efficiency : System.Web.UI.Page
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
                getEmpProcessId();
               
                clearMsg();
                getOfficeName();
                getDate();
                getLineId();

                txtEmpCardNo.Attributes.Add("onKeyPress", "doClick('" + btnSearch.ClientID + "',event)");
                btnSearch.Attributes.Add("onKeyPress", "doClick('" + txtStyleNo.ClientID + "',event)");
                txtStyleNo.Attributes.Add("onKeyPress", "doClick('" + txtAchieveQuantity.ClientID + "',event)");
                txtAchieveQuantity.Attributes.Add("onKeyPress", "doClick('" + txtWorkingHour.ClientID + "',event)");
            }

            if (IsPostBack)
            {

                loadSesscion();

            }


            txtStyleNo.Attributes.Add("onkeypress", "return controlEnter('" + txtAchieveQuantity.ClientID + "', event)");
            txtAchieveQuantity.Attributes.Add("onkeypress", "return controlEnter('" + txtWorkingHour.ClientID + "', event)");
           
        }




        #region "Function"

        public void getLineId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();

            ddlLineId.DataSource = objLookUpBLL.getLineId(strHeadOfficeId, strBranchOfficeId);

            ddlLineId.DataTextField = "LINE_NAME";
            ddlLineId.DataValueField = "LINE_ID";

            ddlLineId.DataBind();
            if (ddlLineId.Items.Count > 0)
            {

                ddlLineId.SelectedIndex = 0;
            }

        }


        public void getDate()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getDate();

            dtpEfficiencyDate.Text = objLookUpDTO.FromDate;




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


        public void clearYellowTextBox()
        {
            txtCardNo.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            txtDesignationName.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtSL.Text = string.Empty;
            txtSLNew.Text = string.Empty;

        }

        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
        public void clearTextBox()
        {

            txtMachineName.Text = "";
            txtSMV.Text = "";
            txtTargetValue.Text = "";
            txtAchieveQuantity.Text = "";
            txtWorkingHour.Text = "";

        }

        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
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

        public void getDefectDays()
        {

            ProcessDTO objProcessDTO = new ProcessDTO();
            ProcessBLL objProcessBLL = new ProcessBLL();


            objProcessDTO = objProcessBLL.getDefectDays(txtEmployeeId.Text, strHeadOfficeId, strBranchOfficeId, dtpPdFromDate.Text, dtpPdToDate.Text);

          




        }




        public void getEmpProcessId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();

            ddlEmpProcessId.DataSource = objLookUpBLL.getProcess(strHeadOfficeId, strBranchOfficeId);

            ddlEmpProcessId.DataTextField = "TOP_PROCESS_NAME";
            ddlEmpProcessId.DataValueField = "TOP_PROCESS_ID";

            ddlEmpProcessId.DataBind();
            if (ddlEmpProcessId.Items.Count > 0)
            {

                ddlEmpProcessId.SelectedIndex = 0;
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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }



        public void searchWorkerRecordForProcess()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.ProcessCode = txtProcessCode.Text;

            if (ddlEmpProcessId.SelectedValue.ToString() != "0")
            {
                objEmployeeDTO.ProcessId = ddlEmpProcessId.SelectedValue.ToString();
            }
            else
            {

                objEmployeeDTO.ProcessId = "";
            }



            dt = objEmployeeBLL.searchWorkerRecordForProcess(objEmployeeDTO);


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

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }
        public void searchEfficiencyEntry()
        {

            ProcessDTO objProcessDTO = new ProcessDTO();
            ProcessBLL objProcessBLL = new ProcessBLL();

            DataTable dt = new DataTable();



            objProcessDTO.HeadOfficeId = strHeadOfficeId;
            objProcessDTO.BranchOfficeId = strBranchOfficeId;
            objProcessDTO.EmployeeId = txtEmpId.Text;
            objProcessDTO.CardNo = txtEmpCardNo.Text;

            objProcessDTO.ProductionFromDate = dtpPdFromDate.Text;
            objProcessDTO.ProductionToDate = dtpPdToDate.Text;


            if (ddlEmpProcessId.SelectedValue.ToString() != "0")
            {
                objProcessDTO.ProcessId = ddlEmpProcessId.SelectedValue.ToString();
            }
            else
            {

                objProcessDTO.ProcessId = "";
            }



            dt = objProcessBLL.searchEfficiencyEntry(objProcessDTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();


            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int totalcolums = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridView1.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }




        public void getFirstIndex()
        {
            //var rowCount = gvEmployeeList.Rows.Count;


            //int rowIndex = 1;
            //if (gvEmployeeList.SelectedIndex == 0)
            //{


            //    rowIndex = 0;
            //    GridViewRow row = gvEmployeeList.Rows[rowIndex];
            //    txtCardNo.Text = row.Cells[1].Text;
            //    txtDesignationName.Text = row.Cells[4].Text;
            //    txtEmployeeName.Text = row.Cells[3].Text;
            //    txtEmployeeId.Text = row.Cells[2].Text;


            //}
            //else
            //{

            //    GridViewRow row = gvEmployeeList.Rows[rowIndex];
            //    txtCardNo.Text = row.Cells[1].Text;
            //    txtDesignationName.Text = row.Cells[4].Text;
            //    txtEmployeeName.Text = row.Cells[3].Text;
            //    txtEmployeeId.Text = row.Cells[2].Text;

            //    rowIndex = rowIndex + 1;

            //}


            int nRow = gvEmployeeList.SelectedIndex;

            if (nRow == -1)
            {
                int rowIndex = 0;
                GridViewRow row = gvEmployeeList.Rows[rowIndex];
                txtCardNo.Text = row.Cells[1].Text;
                txtDesignationName.Text = row.Cells[4].Text;
                txtEmployeeName.Text = row.Cells[3].Text;
                txtEmployeeId.Text = row.Cells[2].Text;

                int l;
                l = gvEmployeeList.SelectedRow.RowIndex + 1;
                txtSL.Text = Convert.ToString(l);
            }
            int courow = gvEmployeeList.Rows.Count - 1;
            {


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
                else
                {
                    gvEmployeeList.SelectedIndex += 1;
                    result = gvEmployeeList.SelectedRow.RowIndex + k;

                }

            }
            if (l == 0)
            {

                int intCount = gvEmployeeList.Rows.Count;
                int intCountRow = gvEmployeeList.Rows.Count;
                if (intCountRow == 1)
                {
                    intCountRow = 2;

                }

                int p = intCountRow - 1;
                //int p = intCountRow;
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

                        int intC = gvEmployeeList.Rows.Count;
                        int intCo = gvEmployeeList.Rows.Count;
                        int ll = 0;

                        int pp = intCo - 1;
                        //int p = intCountRow;
                        if (ll == pp)
                        {
                            string strMsg = "There is no Data for the Next Record!!!";
                            MessageBox(strMsg);

                            return;

                        }
                        else
                        {

                            gvEmployeeList.SelectedIndex += 1;
                            result = gvEmployeeList.SelectedRow.RowIndex + k;

                        }

                    }


                }

            }


            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            if (strSLNo == "NO RECORD FOUND")
            {
                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                return;
            }
            else
            {

                string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
                string strEmployeeId = gvEmployeeList.SelectedRow.Cells[8].Text;
                string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
                string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;
                string strProcessName = gvEmployeeList.SelectedRow.Cells[4].Text;


                string strMachineName = gvEmployeeList.SelectedRow.Cells[5].Text;
                string strSMV = gvEmployeeList.SelectedRow.Cells[6].Text;
                string strTargetValue = gvEmployeeList.SelectedRow.Cells[7].Text;


                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;
                txtProcessName.Text = System.Net.WebUtility.HtmlDecode(strProcessName);


                if (strMachineName == "" || strMachineName == "&nbsp;")
                {

                    txtMachineName.Text = "";
                }
                else
                {
                    txtMachineName.Text = strMachineName;

                }
                if (strSMV == "" || strSMV == "&nbsp;")
                {

                    txtSMV.Text = "";
                }
                else
                {
                    txtSMV.Text = strSMV;

                }

                if (strTargetValue == "" || strTargetValue == "&nbsp;")
                {

                    txtTargetValue.Text = "";
                }
                else
                {
                    txtTargetValue.Text = strTargetValue;

                }

                //txtWorkingDay.Focus();

            }
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
                    //txtWorkingDay.Focus();
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
                    //txtWorkingDay.Focus();
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

            //int strRowCount = strRowId - 1;
            //int intCount = gvIncrementList.Rows.Count;
            //if (intCount == strRowCount)
            //{
            //    string strMsg = "Entry Completed";
            //    MessageBox(strMsg);
            //    return;

            //}
            //else
            //{




            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;


            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[8].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strProcessName = gvEmployeeList.SelectedRow.Cells[4].Text;
            
            string strMachineName = gvEmployeeList.SelectedRow.Cells[5].Text;
            string strSMV = gvEmployeeList.SelectedRow.Cells[6].Text;
            string strTargetValue = gvEmployeeList.SelectedRow.Cells[7].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            txtProcessName.Text = System.Net.WebUtility.HtmlDecode(strProcessName);

            if (strMachineName == "" || strMachineName == "&nbsp;")
            {

                txtMachineName.Text = "";
            }
            else
            {
                txtMachineName.Text = strMachineName;

            }
            if (strSMV == "" || strSMV == "&nbsp;")
            {

                txtSMV.Text = "";
            }
            else
            {
                txtSMV.Text = strSMV;

            }

            if (strTargetValue == "" || strTargetValue == "&nbsp;")
            {

                txtTargetValue.Text = "";
            }
            else
            {
                txtTargetValue.Text = strTargetValue;

            }



        }




        public void saveEfficiencyInfo()
        {

            ProcessDTO objProcessDTO = new ProcessDTO();
            ProcessBLL objProcessBLL = new ProcessBLL();

            objProcessDTO.EmployeeId = txtEmployeeId.Text;
            objProcessDTO.SMV = txtSMV.Text;
            objProcessDTO.TargetValue = txtTargetValue.Text;
            objProcessDTO.EfficiencyDate = dtpEfficiencyDate.Text;
            objProcessDTO.StyleNo = txtStyleNo.Text;

            
            objProcessDTO.AchieveQuantity = txtAchieveQuantity.Text;
            objProcessDTO.WorkingHour = txtWorkingHour.Text;
            objProcessDTO.ProcessId = txtProcessName.Text;

            if (ddlLineId.SelectedValue.ToString() != " ")
            {
                objProcessDTO.LineId = ddlLineId.SelectedValue.ToString();
            }
            else
            {

                objProcessDTO.LineId = "";
            }

            

            objProcessDTO.UpdateBy = strEmployeeId;
            objProcessDTO.HeadOfficeId = strHeadOfficeId;
            objProcessDTO.BranchOfficeId = strBranchOfficeId;






            string strMsg = objProcessBLL.saveEfficiencyInfo(objProcessDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;


        }
        public void deleteEfficiencyRecord()
        {

            ProcessDTO objProcessDTO = new ProcessDTO();
            ProcessBLL objProcessBLL = new ProcessBLL();

            objProcessDTO.EmployeeId = txtEmployeeId.Text;
            objProcessDTO.EfficiencyDate = dtpEfficiencyDate.Text;




            objProcessDTO.UpdateBy = strEmployeeId;
            objProcessDTO.HeadOfficeId = strHeadOfficeId;
            objProcessDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objProcessBLL.deleteEfficiencyRecord(objProcessDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;


        }



        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (gvEmployeeList.Rows.Count == 0)
            {
                string strMsg = "Please click searh Button!!!";
                MessageBox(strMsg);
                clearMessage();
                btnSearch.Focus();

                return;
            }
            else if (txtEmployeeId.Text == string.Empty)
            {
                string strMsg = "Please click in the Gridview!!!";
                MessageBox(strMsg);
                clearMessage();
                return;

            }


            else
            {
                saveEfficiencyInfo();
                clearTextBox();
                searchEfficiencyEntry();
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //if (ddlEmpProcessId.Text == "0" || txtProcessCode.Text == "")
            //{

            //    string strMsg = "Please Select Process Name OR Enter Process Code!!!";
            //    MessageBox(strMsg);
            //    clearMessage();
            //    return;

            //}
            //else
            //{

                searchWorkerRecordForProcess();
                clearYellowTextBox();
                clearTextBox();
                gvEmployeeList.SelectedIndex = 0;
                goToNextRecord();
                searchEfficiencyEntry();
                getDefectDays();

            //}

        }


        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
          
        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {


            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[8].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strProcessName = gvEmployeeList.SelectedRow.Cells[4].Text;
           

            string strMachineName = gvEmployeeList.SelectedRow.Cells[5].Text;
            string strSMV = gvEmployeeList.SelectedRow.Cells[6].Text;
            string strTargetValue = gvEmployeeList.SelectedRow.Cells[7].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            txtProcessName.Text = System.Net.WebUtility.HtmlDecode(strProcessName);


            if (strMachineName == "" || strMachineName == "&nbsp;")
            {

                txtMachineName.Text = "";
            }
            else
            {
                txtMachineName.Text = strMachineName;

            }
            if (strSMV == "" || strSMV == "&nbsp;")
            {

                txtSMV.Text = "";
            }
            else
            {
                txtSMV.Text = strSMV;

            }

            if (strTargetValue == "" || strTargetValue == "&nbsp;")
            {

                txtTargetValue.Text = "";
            }
            else
            {
                txtTargetValue.Text = strTargetValue;

            }



        }


        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{

            //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            //    string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            //    string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            //    string strEmployeeId = gvEmployeeList.SelectedRow.Cells[5].Text;
            //    string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            //    string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


            //    txtSL.Text = Convert.ToString(strRowId);
            //    txtCardNo.Text = strCardNo;
            //    txtEmployeeId.Text = strEmployeeId;
            //    txtEmployeeName.Text = strEmployeeName;
            //    txtDesignationName.Text = strDesignation;

            //    searchMiscEntryWorker();
            //    txtWorkingDay.Focus();

            //}
            //if (e.CommandName == "Edit")
            //{
            //}
            //if (e.CommandName == "Delete")
            //{

            //}

            //int selectedRowIndex = gvEmployeeList.SelectedRow.RowIndex;
            //gvEmployeeList.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

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

        }




        #endregion

        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchEfficiencyEntry();
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

                    goToPreviousRecord();
                    getDefectDays();
                    clearMessage();


                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

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
                    getDefectDays();
                    clearMessage();


                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }


        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[12].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;
            string strStyleNo = GridView1.SelectedRow.Cells[11].Text;

            string strDate = GridView1.SelectedRow.Cells[5].Text;
            string strSMV = GridView1.SelectedRow.Cells[6].Text;
            string strTargetValue = GridView1.SelectedRow.Cells[7].Text;
            string strAQ = GridView1.SelectedRow.Cells[9].Text;
            string strWorkingHour = GridView1.SelectedRow.Cells[10].Text;


            if (strDate == "&nbsp;")
            {
                strDate = "";

            }
            else
            {
                dtpEfficiencyDate.Text = strDate;

            }


            if (strSMV == "&nbsp;")
            {
                strSMV = "";

            }
            else
            {
                txtSMV.Text = strSMV;

            }

            if (strStyleNo == "&nbsp;")
            {
                strStyleNo = "";

            }
            else
            {
                txtStyleNo.Text = strStyleNo;

            }


            if (strTargetValue == "&nbsp;")
            {
                strTargetValue = "";

            }
            else
            {
                txtTargetValue.Text = strTargetValue;

            }


            if (strAQ == "&nbsp;")
            {
                strAQ = "";

            }
            else
            {
                txtAchieveQuantity.Text = strAQ;

            }

            if (strWorkingHour == "&nbsp;")
            {
                strWorkingHour = "";

            }
            else
            {
                txtWorkingHour.Text = strWorkingHour;

            }



            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            
           
            
           



            getDefectDays();

        }




        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{
            //    int strRowId = GridView1.SelectedRow.RowIndex + 1;
            //    string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            //    string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            //    string strEmployeeId = GridView1.SelectedRow.Cells[9].Text;
            //    string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            //    string strDesignation = GridView1.SelectedRow.Cells[3].Text;


            //    txtSL.Text = Convert.ToString(strRowId);
            //    txtCardNo.Text = strCardNo;
            //    txtEmployeeId.Text = strEmployeeId;
            //    txtEmployeeName.Text = strEmployeeName;
            //    txtDesignationName.Text = strDesignation;

            //    searchMiscEntryWorker();

            //    txtWorkingDay.Focus();
            //}
            //if (e.CommandName == "Edit")
            //{
            //}
            //if (e.CommandName == "Delete")
            //{

            //}




            //int selectedRowIndex = GridView1.SelectedRow.RowIndex;
            //GridView1.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {


        }


        protected void GridView1_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }

        #endregion

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {
                string strMsg = "Please click Show Button!!!";
                MessageBox(strMsg);
                btnSearch.Focus();
                return;
            }
            else if (txtEmployeeId.Text == "")
            {
                string strMsg = "Please click Gridview!!!";
                MessageBox(strMsg);
                btnSearch.Focus();
                return;
            }

            else if (dtpEfficiencyDate.Text == "")
            {
                string strMsg = "Please Select Date!!!";
                MessageBox(strMsg);
                dtpEfficiencyDate.Focus();
                return;
            }

            else
            {
                deleteEfficiencyRecord();
                searchEfficiencyEntry();
                clearTextBox();
                clearYellowTextBox();
                dtpEfficiencyDate.Text = "";
            }

        }

    }
}