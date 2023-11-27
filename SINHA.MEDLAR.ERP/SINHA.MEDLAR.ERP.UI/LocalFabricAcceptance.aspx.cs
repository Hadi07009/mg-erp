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

using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Specialized;



namespace SINHA.MEDLAR.ERP.UI
{
    public partial class LocalFabricAcceptance : System.Web.UI.Page
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
        string strReport = "";
        ReportDocument rd = new ReportDocument();

        string strDefaultName = "Report";
        ExportFormatType formatType = ExportFormatType.NoFormat;
        bool status;


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
                //getCurrentDate();
                FirstGridViewRow();
                rdoLC.Checked = true;

            }

            if (IsPostBack)
            {

                loadSesscion();

            }


        }


        #region "Function"


        private void FirstGridViewRow()
        {


            //if (ViewState["CurrentTable"] != null)
            //{
            DataTable dt = new DataTable();
            DataRow dr = null;
            // dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("PO_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("PI_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("PROGRAMME_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("FABRIC_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("FABRIC_CONSTRUCTION_ID", typeof(string)));


            dt.Columns.Add(new DataColumn("COLOR_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("PO_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("BLANCE_QUANTITY", typeof(string)));

            dt.Columns.Add(new DataColumn("QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("UNIT_ID", typeof(string)));

            dt.Columns.Add(new DataColumn("RATE_IN_DOLLAR", typeof(string)));
            dt.Columns.Add(new DataColumn("RATE_IN_TAKA", typeof(string)));
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));

            dr = dt.NewRow();
            // dr["RowNumber"] = 1;
            dr["PO_NO"] = string.Empty;
            dr["PI_NO"] = string.Empty;
            dr["PROGRAMME_ID"] = string.Empty;
            dr["FABRIC_ID"] = string.Empty;
            dr["FABRIC_CONSTRUCTION_ID"] = string.Empty;

            dr["COLOR_ID"] = string.Empty;


            dr["PO_QUANTITY"] = string.Empty;
            dr["BLANCE_QUANTITY"] = string.Empty;
            dr["QUANTITY"] = string.Empty;

            dr["UNIT_ID"] = string.Empty;

            dr["RATE_IN_DOLLAR"] = string.Empty;
            dr["RATE_IN_TAKA"] = string.Empty;
            dr["TRAN_ID"] = string.Empty;


            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvFabricDetails.DataSource = dt;
            gvFabricDetails.DataBind();
            // }
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



        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
        public void clearTextBox()
        {



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

        public void getCurrentDate()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getCurrentDate();

            dtpAcceptanceDate.Text = objLookUpDTO.AttendenceDate;


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


        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        TextBox txtPO = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("txtPO");
                        TextBox txtPI = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("txtPI");

                        DropDownList ddlProgrammeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlProgrammeId");
                        DropDownList ddlFabricId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlFabricId");
                        DropDownList ddlFabricConstructionId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("ddlFabricConstructionId");


                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("ddlColorId");


                        TextBox txtPOBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtPOBlance");
                        TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtBlance");
                        TextBox txtQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("txtQuantity");


                        DropDownList ddlMeasureId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[9].FindControl("ddlMeasureId");



                        TextBox txtRateInTaka = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[11].FindControl("txtRateInTaka");
                        TextBox txtRateInDollar = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[12].FindControl("txtRateInDollar");

                        TextBox txtTranId = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[13].FindControl("txtTranId");

                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["PO_NO"] = txtPO.Text;
                        dtCurrentTable.Rows[i - 1]["PI_NO"] = txtPI.Text;
                        dtCurrentTable.Rows[i - 1]["PROGRAMME_ID"] = ddlProgrammeId.Text;
                        dtCurrentTable.Rows[i - 1]["FABRIC_ID"] = ddlFabricId.Text;
                        dtCurrentTable.Rows[i - 1]["FABRIC_CONSTRUCTION_ID"] = ddlFabricConstructionId.Text;

                        dtCurrentTable.Rows[i - 1]["COLOR_ID"] = ddlColorId.Text;


                        dtCurrentTable.Rows[i - 1]["PO_QUANTITY"] = txtPOBlance.Text;
                        dtCurrentTable.Rows[i - 1]["BLANCE_QUANTITY"] = txtBlance.Text;
                        dtCurrentTable.Rows[i - 1]["QUANTITY"] = txtQuantity.Text;

                        dtCurrentTable.Rows[i - 1]["MEASURE_ID"] = ddlMeasureId.Text;


                       
                        dtCurrentTable.Rows[i - 1]["RATE_IN_TAKA"] = txtRateInTaka.Text;
                        dtCurrentTable.Rows[i - 1]["RATE_IN_DOLLAR"] = txtRateInDollar.Text;

                        dtCurrentTable.Rows[i - 1]["TRAN_ID"] = txtTranId.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gvFabricDetails.DataSource = dtCurrentTable;
                    gvFabricDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }


        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox txtPO = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("txtPO");
                        TextBox txtPI = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("txtPI");




                        DropDownList ddlProgrammeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlProgrammeId");
                        DropDownList ddlFabricId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlFabricId");
                        DropDownList ddlFabricConstructionId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("ddlFabricConstructionId");


                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("ddlColorId");


                        TextBox txtPOBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtPOBlance");
                        TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtBlance");
                        TextBox txtQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("txtQuantity");


                        DropDownList ddlMeasureId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[9].FindControl("ddlMeasureId");



                        TextBox txtRateInTaka = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[11].FindControl("txtRateInTaka");
                        TextBox txtRateInDollar = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[12].FindControl("txtRateInDollar");

                        TextBox txtTranId = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[13].FindControl("txtTranId");




                        txtPO.Text = dt.Rows[i]["PO_NO"].ToString();
                        txtPI.Text = dt.Rows[i]["PI_NO"].ToString();


                        ddlProgrammeId.Text = dt.Rows[i]["PROGRAMME_ID"].ToString();
                        ddlFabricId.Text = dt.Rows[i]["FABRIC_ID"].ToString();
                        ddlFabricConstructionId.Text = dt.Rows[i]["FABRIC_CONSTRUCTION_ID"].ToString();



                        ddlColorId.Text = dt.Rows[i]["COLOR_ID"].ToString();
                        txtPOBlance.Text = dt.Rows[i]["PO_BLANCE"].ToString();
                        txtBlance.Text = dt.Rows[i]["PO_QUANTITY"].ToString();


                        txtQuantity.Text = dt.Rows[i]["QUANTITY"].ToString();
                        ddlMeasureId.Text = dt.Rows[i]["MEASURE_ID"].ToString();


                      
                        txtRateInTaka.Text = dt.Rows[i]["RATE_IN_TAKA"].ToString();
                        txtRateInTaka.Text = dt.Rows[i]["RATE_IN_DOLLAR"].ToString();
                        txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();

                        rowIndex++;
                    }
                }
            }
        }


        public void saveLocalFabricAcceptance()
        {
            int rowIndex = 0;
            string strMsg = "";
            string strLCTypeId = "";

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();

            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        TextBox txtPO = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("txtPO");
                        TextBox txtPI = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("txtPI");




                        DropDownList ddlProgrammeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlProgrammeId");
                        DropDownList ddlFabricId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlFabricId");
                        DropDownList ddlFabricConstructionId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("ddlFabricConstructionId");


                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("ddlColorId");


                        TextBox txtPOBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtPOBlance");
                        TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtBlance");
                        TextBox txtQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("txtQuantity");


                        DropDownList ddlMeasureId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[9].FindControl("ddlMeasureId");



                        TextBox txtRateInTaka = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[11].FindControl("txtRateInTaka");
                        TextBox txtRateInDollar = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[12].FindControl("txtRateInDollar");

                        TextBox txtTranId = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[13].FindControl("txtTranId");




                      




                        if (ddlProgrammeId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.ProgrammeId = ddlProgrammeId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.ProgrammeId = "";

                        }

                        if (ddlMeasureId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.UnitId = ddlMeasureId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.UnitId = "";

                        }

                        if (ddlColorId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.ColorId = ddlColorId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.ColorId = "";

                        }


                        if (ddlProgrammeId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.ProgrammeId = ddlProgrammeId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.ProgrammeId = "";

                        }




                        if (ddlFabricId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.FabricId = ddlFabricId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.FabricId = "";

                        }

                        if (ddlFabricConstructionId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.FabricConstructionId = ddlFabricConstructionId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.FabricConstructionId = "";

                        }



                        
                        if (rdoCash.Checked == true)
                        {
                            strLCTypeId = "2";

                        }
                        if(rdoLC.Checked == true)
                        {
                            strLCTypeId = "1";

                        }



                        objFabricIssueDTO.LcTypeId = strLCTypeId;
                        objFabricIssueDTO.LcNo = txtLCNo.Text;
                       
                        objFabricIssueDTO.RateInTaka = txtRateInTaka.Text;
                        objFabricIssueDTO.RateInDollar = txtRateInDollar.Text;


                        objFabricIssueDTO.AcceptanceDate = dtpAcceptanceDate.Text;

                        objFabricIssueDTO.PI = txtPI.Text;
                        objFabricIssueDTO.PO = txtPO.Text;

                        objFabricIssueDTO.POBlance = txtPOBlance.Text;
                        objFabricIssueDTO.Blance = txtBlance.Text;

                        objFabricIssueDTO.ChallanNo = txtChallanNo.Text;
                        objFabricIssueDTO.DeliveryNo = txtDNNo.Text;

                        objFabricIssueDTO.UpdateBy = strEmployeeId;
                        objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
                        objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;




                        strMsg = objFabricIssueBLL.saveLocalFabricAcceptance(objFabricIssueDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;

                        rowIndex++;

                    }

                    if (strMsg == "INSERTED SUCCESSFULLY")
                    {

                        MessageBox(strMsg);
                    }


                }
            }


        }
        public void deleteLocalFabricAcceptance(string strTranId)
        {
            
            string strMsg = "";
          

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();


            objFabricIssueDTO.TranId = strTranId;
            objFabricIssueDTO.ChallanNo = txtChallanNo.Text;
            objFabricIssueDTO.AcceptanceDate = dtpAcceptanceDate.Text;

            objFabricIssueDTO.UpdateBy = strEmployeeId;
            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;




            strMsg = objFabricIssueBLL.deleteLocalFabricAcceptance(objFabricIssueDTO);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;


                    

                   


        }


       


        public void searchLocalFabricAcceptanceMain()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();
            DataTable dt = new DataTable();


            objFabricIssueDTO.ChallanNo = txtChallanNo.Text;
            objFabricIssueDTO.AcceptanceDate = dtpAcceptanceDate.Text;
           

            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFabricIssueBLL.searchFabricAcceptanceMain(objFabricIssueDTO);


            if (dt.Rows.Count > 0)
            {
                gvFabricDetails.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvFabricDetails.DataBind();

                int count = ((DataTable)gvFabricDetails.DataSource).Rows.Count;

                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvFabricDetails.DataSource = dt;
                gvFabricDetails.DataBind();
                int totalcolums = gvFabricDetails.Rows[0].Cells.Count;
                gvFabricDetails.Rows[0].Cells.Clear();
                gvFabricDetails.Rows[0].Cells.Add(new TableCell());
                gvFabricDetails.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvFabricDetails.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }
        
        public void searchLocalFabricAcceptanceSub()
        {


            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();


            objFabricIssueDTO = objFabricIssueBLL.searchLocalFabricAcceptanceSub(txtChallanNo.Text , dtpAcceptanceDate.Text, strHeadOfficeId, strBranchOfficeId);

           
            txtDNNo.Text = objFabricIssueDTO.DeliveryNo;
            txtLCNo.Text = objFabricIssueDTO.LcNo;

            if(objFabricIssueDTO.LcTypeId == "2")
            {

                rdoCash.Checked = true;

            }
            else
            {
                rdoCash.Checked = false;


            }


            if (objFabricIssueDTO.LcTypeId == "1")
            {

                rdoLC.Checked = true;

            }
            else
            {
                rdoLC.Checked = false;


            }



        }

    
        #endregion

        #region "Radio@Check"

        protected void rdoCash_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCash.Checked == true)
            {

                rdoLC.Checked = false;

            }
          
        }

        protected void rdoLC_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoLC.Checked == true)
            {

                rdoCash.Checked = false;

            }
        }


        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }


        #region "Grid View Functionality"
        protected void gvFabricDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFabricDetails.PageIndex = e.NewPageIndex;

        }

        protected void gvFabricDetails_OnSelectedIndexChanged(object sender, EventArgs e)
        {



        }




        protected void gvFabricDetails_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void gvFabricDetails_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void gvFabricDetails_Sorting(object sender, GridViewSortEventArgs e)
        {


        }


        protected void gvFabricDetails_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LookUpBLL objLookUpBLL = new LookUpBLL();


                DropDownList a = (e.Row.FindControl("ddlProgrammeId") as DropDownList);

                DropDownList d = (e.Row.FindControl("ddlColorId") as DropDownList);
                DropDownList f = (e.Row.FindControl("ddlMeasureId") as DropDownList);
                DropDownList g = (e.Row.FindControl("ddlFabricId") as DropDownList);
                DropDownList h = (e.Row.FindControl("ddlFabricConstructionId") as DropDownList);
                DropDownList k = (e.Row.FindControl("ddlCurrencyId") as DropDownList);


                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                DataTable dt6 = new DataTable();


                DataRowView dr = e.Row.DataItem as DataRowView;

                dt1 = objLookUpBLL.getProgrammeId();
                a.DataSource = dt1;
                a.DataBind();
                a.SelectedValue = dr["PROGRAMME_ID"].ToString();



                dt2 = objLookUpBLL.getColorIdStore();
                d.DataSource = dt2;
                d.DataBind();
                d.SelectedValue = dr["COLOR_ID"].ToString();



                dt5 = objLookUpBLL.getUnitIdStore(strHeadOfficeId, strBranchOfficeId);
                f.DataSource = dt5;
                f.DataBind();
                f.SelectedValue = dr["UNIT_ID"].ToString();


                dt6 = objLookUpBLL.getFabricId();
                g.DataSource = dt6;
                g.DataBind();
                g.SelectedValue = dr["FABRIC_ID"].ToString();


                dt6 = objLookUpBLL.getConstructionId();
                h.DataSource = dt6;
                h.DataBind();
                h.SelectedValue = dr["FABRIC_CONSTRUCTION_ID"].ToString();


             


            }
        }


        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchLocalFabricAcceptanceMain();
            searchLocalFabricAcceptanceSub();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpAcceptanceDate.Text.Length < 6)
            {


                string strMsg = "Please Enter Acceptance Date!!!";
                MessageBox(strMsg);
                dtpAcceptanceDate.Focus();
                return;


            }
            else if (txtChallanNo.Text == "")
            {
                string strMsg = "Please Enter Challan No!!!";
                MessageBox(strMsg);
                txtChallanNo.Focus();
                return;

            }


           
            else
            {
               
                saveLocalFabricAcceptance();
                searchLocalFabricAcceptanceMain();
                searchLocalFabricAcceptanceSub();

            }
        }

        protected void gvFabricDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvFabricDetails.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("TRAN_ID");

            int stor_id = Convert.ToInt32(gvFabricDetails.DataKeys[e.RowIndex].Value.ToString());
            string strTranId = Convert.ToString(stor_id);


            deleteLocalFabricAcceptance(strTranId);

            searchLocalFabricAcceptanceMain();
            searchLocalFabricAcceptanceSub();
        }
    }
}