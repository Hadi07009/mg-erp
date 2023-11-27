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
    public partial class ForeignFabricIssue : System.Web.UI.Page
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
                getBranchOfficeName();
                getSupplierId();
                getCurrentDate();
                FirstGridViewRow();
                getFabricConstructionId();
                getFabricId();
                getStyleIdStoreSearch();
                getProgrammeId();
                getStyleIdStoreSearch();
                getArtId();
                getSupplierIdSearch();
                getCurrentYear();

            }

            if (IsPostBack)
            {

                loadSesscion();

            }

            gvFabricDetails.Columns[10].Visible = false;

        }

        #region "Function"

        public void getCurrentYear()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYear();

            txtYear.Text = objLookUpDTO.Year;




        }
        private void FirstGridViewRow()
        {

           
            //if (ViewState["CurrentTable"] != null)
            //{
                DataTable dt = new DataTable();
                DataRow dr = null;

                //dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
             
                dt.Columns.Add(new DataColumn("PROGRAMME_ID", typeof(string)));
                dt.Columns.Add(new DataColumn("FABRIC_ID", typeof(string)));
                dt.Columns.Add(new DataColumn("FABRIC_CONSTRUCTION_ID", typeof(string)));
                dt.Columns.Add(new DataColumn("STYLE_ID", typeof(string)));
                dt.Columns.Add(new DataColumn("ART_ID", typeof(string)));
                dt.Columns.Add(new DataColumn("COLOR_ID", typeof(string)));
                dt.Columns.Add(new DataColumn("UNIT_ID", typeof(string)));
                dt.Columns.Add(new DataColumn("RECEIVE_QUANTITY", typeof(string)));
                dt.Columns.Add(new DataColumn("ISSUE_QUANTITY", typeof(string)));
                dt.Columns.Add(new DataColumn("REMAINING_QUANTITY", typeof(string)));

                dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));

            dr = dt.NewRow();
            // dr["RowNumber"] = 1;

               
                dr["PROGRAMME_ID"] = string.Empty;
                dr["FABRIC_ID"] = string.Empty;
                dr["FABRIC_CONSTRUCTION_ID"] = string.Empty;
                dr["STYLE_ID"] = string.Empty;
                dr["ART_ID"] = string.Empty;
                dr["COLOR_ID"] = string.Empty;
                dr["UNIT_ID"] = string.Empty;

                dr["RECEIVE_QUANTITY"] = string.Empty;
                dr["ISSUE_QUANTITY"] = string.Empty;
                dr["REMAINING_QUANTITY"] = string.Empty;
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

            //dtpIssueDate.Text = objLookUpDTO.AttendenceDate;
           

        }


        public void getStyleIdStoreSearch()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();

            ddlStyleIdSearch.DataSource = objLookUpBLL.getStyleIdStore();
            ddlStyleIdSearch.DataTextField = "STYLE_NO";
            ddlStyleIdSearch.DataValueField = "STYLE_ID";
            ddlStyleIdSearch.DataBind();
            if (ddlStyleIdSearch.Items.Count > 0)
            {
                ddlStyleIdSearch.SelectedIndex = 0;
            }
        }

        public void getFabricId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlFabricIdSearch.DataSource = objLookUpBLL.getFabricId();
            ddlFabricIdSearch.DataTextField = "FABRIC_NAME";
            ddlFabricIdSearch.DataValueField = "FABRIC_ID";
            ddlFabricIdSearch.DataBind();
            if (ddlFabricIdSearch.Items.Count > 0)
            {
                ddlFabricIdSearch.SelectedIndex = 0;
            }
        }


        public void getArtId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlArtIdSearch.DataSource = objLookUpBLL.getArtId();
            ddlArtIdSearch.DataTextField = "ART_NO";
            ddlArtIdSearch.DataValueField = "ART_ID";
            ddlArtIdSearch.DataBind();
            if (ddlArtIdSearch.Items.Count > 0)
            {
                ddlArtIdSearch.SelectedIndex = 0;
            }
        }


        public void getFabricConstructionId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlConstructioIdSearch.DataSource = objLookUpBLL.getConstructionId();
            ddlConstructioIdSearch.DataTextField = "FABRIC_CONSTRUCTION_NAME";
            ddlConstructioIdSearch.DataValueField = "FABRIC_CONSTRUCTION_ID";
            ddlConstructioIdSearch.DataBind();
            if (ddlConstructioIdSearch.Items.Count > 0)
            {
                ddlConstructioIdSearch.SelectedIndex = 0;
            }
        }


        public void getSupplierIdSearch()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSupplierIdSearch.DataSource = objLookUpBLL.getSupplierId();
            ddlSupplierIdSearch.DataTextField = "SUPPLIER_NAME";
            ddlSupplierIdSearch.DataValueField = "SUPPLIER_ID";
            ddlSupplierIdSearch.DataBind();
            if (ddlSupplierIdSearch.Items.Count > 0)
            {
                ddlSupplierIdSearch.SelectedIndex = 0;
            }
        }

        public void getSupplierId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSupplierId.DataSource = objLookUpBLL.getSupplierId();
            ddlSupplierId.DataTextField = "SUPPLIER_NAME";
            ddlSupplierId.DataValueField = "SUPPLIER_ID";
            ddlSupplierId.DataBind();
            if (ddlSupplierId.Items.Count > 0)
            {
                ddlSupplierId.SelectedIndex = 0;
            }
        }

        public void getProgrammeId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlProgrammeIdSearch.DataSource = objLookUpBLL.getProgrammeId();
            ddlProgrammeIdSearch.DataTextField = "PROGRAMME_NAME";
            ddlProgrammeIdSearch.DataValueField = "PROGRAMME_ID";
            ddlProgrammeIdSearch.DataBind();
            if (ddlProgrammeIdSearch.Items.Count > 0)
            {
                ddlProgrammeIdSearch.SelectedIndex = 0;
            }
        }




        public void getBranchOfficeName()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlStoreId.DataSource = objLookUpBLL.getBranchOfficeId(strHeadOfficeId);
            ddlStoreId.DataTextField = "BRANCH_OFFICE_NAME";
            ddlStoreId.DataValueField = "BRANCH_OFFICE_ID";
            ddlStoreId.DataBind();
            if (ddlStoreId.Items.Count > 0)
            {
                ddlStoreId.SelectedIndex = 0;
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


                       
                        DropDownList ddlProgrammeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("ddlProgrammeId");
                        DropDownList ddlFabricId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("ddlFabricId");
                        DropDownList ddlFabricConstructionId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlFabricConstructionId");


                        DropDownList ddlStyleId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlStyleId");
                        DropDownList ddlArtId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("ddlArtId");
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("ddlColorId");
                        DropDownList ddlUnitId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("ddlUnitId");

                        TextBox txtReceiveQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtReceiveQuantity");
                        TextBox txtIssueQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("txtIssueQuantity");
                        TextBox txtRemainingQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[9].FindControl("txtRemainingQuantity");

                        TextBox txtTranId = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[10].FindControl("txtTranId");


                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                     
                        dtCurrentTable.Rows[i - 1]["PROGRAMME_ID"] = ddlProgrammeId.Text;
                        dtCurrentTable.Rows[i - 1]["FABRIC_ID"] = ddlFabricId.Text;
                        dtCurrentTable.Rows[i - 1]["FABRIC_CONSTRUCTION_ID"] = ddlFabricConstructionId.Text;
                        dtCurrentTable.Rows[i - 1]["STYLE_ID"] = ddlStyleId.Text;
                        dtCurrentTable.Rows[i - 1]["ART_ID"] = ddlArtId.Text;
                        dtCurrentTable.Rows[i - 1]["COLOR_ID"] = ddlColorId.Text;
                        dtCurrentTable.Rows[i - 1]["UNIT_ID"] = ddlUnitId.Text;


                        dtCurrentTable.Rows[i - 1]["RECEIVE_QUANTITY"] = txtReceiveQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["ISSUE_QUANTITY"] = txtIssueQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["REMAINING_QUANTITY"] = txtRemainingQuantity.Text;
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
                        DropDownList ddlProgrammeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("ddlProgrammeId");
                        DropDownList ddlFabricId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("ddlFabricId");
                        DropDownList ddlFabricConstructionId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlFabricConstructionId");


                        DropDownList ddlStyleId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlStyleId");
                        DropDownList ddlArtId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("ddlArtId");
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("ddlColorId");
                        DropDownList ddlUnitId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("ddlUnitId");

                        TextBox txtReceiveQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtReceiveQuantity");
                        TextBox txtIssueQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("txtIssueQuantity");
                        TextBox txtRemainingQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[9].FindControl("txtRemainingQuantity");

                        TextBox txtTranId = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[10].FindControl("txtTranId");

                        ddlProgrammeId.Text = dt.Rows[i]["PROGRAMME_ID"].ToString();
                      
                        ddlFabricId.Text = dt.Rows[i]["FABRIC_ID"].ToString();
                        ddlFabricConstructionId.Text = dt.Rows[i]["FABRIC_CONSTRUCTION_ID"].ToString();
                        ddlStyleId.Text = dt.Rows[i]["STYLE_ID"].ToString();
                        ddlArtId.Text = dt.Rows[i]["ART_ID"].ToString();
                        ddlColorId.Text = dt.Rows[i]["COLOR_ID"].ToString();
                        ddlUnitId.Text = dt.Rows[i]["UNIT_ID"].ToString();



                        txtReceiveQuantity.Text = dt.Rows[i]["RECEIVE_QUANTITY"].ToString();
                        txtIssueQuantity.Text = dt.Rows[i]["ISSUE_QUANTITY"].ToString();
                        txtRemainingQuantity.Text = dt.Rows[i]["REMAINING_QUANTITY"].ToString();
                        txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();

                        rowIndex++;
                    }
                }
            }
        }


        public void saveFabricIssueSub()
        {
            int rowIndex = 0;
            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();
            string strMsg = "";

            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        DropDownList ddlProgrammeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("ddlProgrammeId");
                        DropDownList ddlFabricId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("ddlFabricId");
                        DropDownList ddlFabricConstructionId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlFabricConstructionId");


                        DropDownList ddlStyleId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlStyleId");
                        DropDownList ddlArtId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("ddlArtId");
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("ddlColorId");
                        DropDownList ddlUnitId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("ddlUnitId");

                        TextBox txtReceiveQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtReceiveQuantity");
                        TextBox txtIssueQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("txtIssueQuantity");
                        TextBox txtRemainingQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[9].FindControl("txtRemainingQuantity");

                        TextBox txtTranId = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[10].FindControl("txtTranId");


                        //sc.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}, {9}", ddlProgrammeId.SelectedValue.ToString(), txtLot.Text, txtArt.Text, ddlColorId.SelectedValue.ToString(), ddlFabricId.SelectedValue.ToString(), ddlFabricConstructionId.SelectedValue.ToString(), ddlMeasureId.SelectedValue.ToString(),txtRate.Text, txtQuantity.Text, txtBlance.Text ));


                        if (ddlStyleId.SelectedValue.ToString() != "0")
                        {
                            objFabricIssueDTO.StyleId = ddlStyleId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.StyleId = "";

                        }


                        if (ddlArtId.SelectedValue.ToString() != "0")
                        {
                            objFabricIssueDTO.ArtId = ddlArtId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.ArtId = "";

                        }


                        if (ddlSupplierId.SelectedValue.ToString() != "0")
                        {
                            objFabricIssueDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.SupplierId = "";

                        }


                        if (ddlProgrammeId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.ProgrammeId = ddlProgrammeId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.ProgrammeId = "";

                        }

                        if (ddlColorId.SelectedValue.ToString() != "0")
                        {
                            objFabricIssueDTO.ColorId = ddlColorId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.ColorId = "";

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

                        if (ddlUnitId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.UnitId = "";

                        }


                        objFabricIssueDTO.ReceiveQuantity = txtReceiveQuantity.Text;
                        objFabricIssueDTO.IssueQuantity = txtIssueQuantity.Text;
                        objFabricIssueDTO.RemainingQuantity = txtRemainingQuantity.Text;


                        objFabricIssueDTO.UpdateBy = strEmployeeId;
                        objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
                        objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;
                        objFabricIssueDTO.TranId = txtTranId.Text;


                        objFabricIssueDTO.IssueDate = dtpIssueDate.Text;
                        objFabricIssueDTO.ChallanNo = txtChallanNo.Text;

                        if (ddlStoreId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.StoreId = ddlStoreId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.StoreId = "";

                        }

                     

                         strMsg = objFabricIssueBLL.saveFabricIssueSub(objFabricIssueDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;
                       
                       

                        rowIndex++;

                        string strSupplierId = ddlSupplierId.SelectedValue;
                        string strProgrammeId = ddlProgrammeId.SelectedValue;
                        string strFabricId = ddlFabricId.SelectedValue;
                        string strConstructionId = ddlFabricConstructionId.SelectedValue;
                        string strStyleId = ddlStyleId.SelectedValue;
                        searchQty(strSupplierId, strProgrammeId, strFabricId, strConstructionId, strStyleId);

                    }

                   


                    MessageBox(strMsg);

                }
            }



           


        }
      
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {

             if (txtChallanNo.Text == " ")
            {

                string strMsg = "Please Enter Chalan No!!!";
                MessageBox(strMsg);
                txtChallanNo.Focus();
                return;
            }

            else if (dtpIssueDate.Text == " ")
            {

                string strMsg = "Please Enter Issue Date!!!";
                MessageBox(strMsg);
                dtpIssueDate.Focus();
                return;
            }

            else if (ddlStoreId.Text == " ")
            {

                string strMsg = "Please Select Store Name!!!";
                MessageBox(strMsg);
                ddlStoreId.Focus();
                return;
            }

            else if (ddlSupplierId.Text == "0")
            {

                string strMsg = "Please Select Store Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;
            }




            else
            {

                saveFabricIssueSub();
                searchForeignFabricMain();
                searchForeignFabricIssueSub();
            }
        }





        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        protected void btnSalaryProcess_Click(object sender, EventArgs e)
        {

        }

       


        #region "Grid View Functionality"


        protected void gvFabricDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFabricDetails.PageIndex = e.NewPageIndex;

        }



        protected void gvFabricDetails_SelectedIndexChanged(object sender, EventArgs e)
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
                DropDownList b = (e.Row.FindControl("ddlColorId") as DropDownList);
                DropDownList c = (e.Row.FindControl("ddlFabricId") as DropDownList);
                DropDownList d = (e.Row.FindControl("ddlFabricConstructionId") as DropDownList);
                DropDownList f = (e.Row.FindControl("ddlUnitId") as DropDownList);
                DropDownList g = (e.Row.FindControl("ddlArtId") as DropDownList);
                DropDownList h = (e.Row.FindControl("ddlStyleId") as DropDownList);

               


                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                DataTable dt5 = new DataTable();
                DataTable dt6 = new DataTable();
                DataTable dt7 = new DataTable();
               


                DataRowView dr = e.Row.DataItem as DataRowView;

                dt1 = objLookUpBLL.getProgrammeId();
                a.DataSource = dt1;
                a.DataBind();
                a.SelectedValue = dr["PROGRAMME_ID"].ToString();
               
                

                dt2 = objLookUpBLL.getColorIdStore();
                b.DataSource = dt2;
                b.DataBind();
                b.SelectedValue = dr["COLOR_ID"].ToString();


                dt3 = objLookUpBLL.getFabricId();
                c.DataSource = dt3;
                c.DataBind();
                c.SelectedValue = dr["FABRIC_ID"].ToString();

                dt4 = objLookUpBLL.getConstructionId();
                d.DataSource = dt4;
                d.DataBind();
                d.SelectedValue = dr["FABRIC_CONSTRUCTION_ID"].ToString();

                dt5 = objLookUpBLL.getUnitIdStore(strHeadOfficeId, strBranchOfficeId);
                f.DataSource = dt5;
                f.DataBind();
                f.SelectedValue = dr["UNIT_ID"].ToString();


                dt6 = objLookUpBLL.getArtId();
                g.DataSource = dt6;
                g.DataBind();
                g.SelectedValue = dr["ART_ID"].ToString();





                dt7 = objLookUpBLL.getStyleIdStore();
                h.DataSource = dt7;
                h.DataBind();
                h.SelectedValue = dr["STYLE_ID"].ToString();



            }
        }

        public void searchForeignFabricIssueSub()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();
            DataTable dt = new DataTable();

            objFabricIssueDTO.ChallanNo = txtChallanNo.Text;
            objFabricIssueDTO.IssueDate = dtpIssueDate.Text;




            if (ddlStoreId.SelectedValue.ToString() != " ")
            {
                objFabricIssueDTO.StoreId = ddlStoreId.SelectedValue.ToString();
            }
            else
            {
                objFabricIssueDTO.StoreId = "";

            }

            if (ddlSupplierId.SelectedValue.ToString() != "0")
            {
                objFabricIssueDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objFabricIssueDTO.SupplierId = "";

            }



            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFabricIssueBLL.searchForeignFabricIssueSub(objFabricIssueDTO);

           
            if (dt.Rows.Count > 0)
            {
                gvFabricDetails.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvFabricDetails.DataBind();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox txtRemainingQuantity = (TextBox)gvFabricDetails.Rows[i].FindControl("txtRemainingQuantity");
                    txtRemainingQuantity.Attributes.Add("readonly", "readonly");

                    TextBox txtReceiveQuantity = (TextBox)gvFabricDetails.Rows[i].FindControl("txtReceiveQuantity");
                    txtReceiveQuantity.Attributes.Add("readonly", "readonly");


                    //TextBox txtTranId = (TextBox)gvFabricDetails.Rows[i].FindControl("txtTranId");
                    //txtTranId.Attributes.Add("readonly", "readonly");

                }

                int count = ((DataTable)gvFabricDetails.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                //gvFabricDetails.Columns[10].Visible = false;
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
                lblMsgRecord.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }

        public void searchForeignFabricMain()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();


            objFabricIssueDTO = objFabricIssueBLL.searchForeignFabricMain(txtChallanNo.Text,  dtpIssueDate.Text, strHeadOfficeId, strBranchOfficeId);

            if (objFabricIssueDTO.StoreId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlStoreId.SelectedValue = objFabricIssueDTO.StoreId;
            }

            if (objFabricIssueDTO.SupplierId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlSupplierId.SelectedValue = objFabricIssueDTO.SupplierId;
            }





        }



        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtChallanNo.Text =="")
                {
                    string strMsg = "Please Enter Challan No!!!";
                    txtChallanNo.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if(dtpIssueDate.Text == "")
                {

                    string strMsg = "Please Enter Issue Date!!!";
                    dtpIssueDate.Focus();
                    MessageBox(strMsg);
                    return;
                   

                }
                else
                {
                    //processForeignFabricIssueFromReceive();
                    searchForeignFabricMain();
                    searchForeignFabricIssueSub();

                }



            }

            catch (Exception ex)
            {
                throw new Exception("Error " +ex.Message);

            }
        }

        public void deleteForeignFabricIssue(string strTranId)
        {


            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();


            objFabricIssueDTO.ChallanNo = txtChallanNo.Text;
            objFabricIssueDTO.IssueDate = dtpIssueDate.Text;

            objFabricIssueDTO.TranId = strTranId;
          

            objFabricIssueDTO.UpdateBy = strEmployeeId;
            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objFabricIssueBLL.deleteForeignFabricIssue(objFabricIssueDTO);
            MessageBox(strMsg);


        }

        public void processForeignFabricIssueFromReceive()
        {


            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();


            //objFabricIssueDTO.InvoiceNo = txtInvoiceNo.Text;
            //objFabricIssueDTO.ReceiveDate = dtpReceiveDate.Text;


            objFabricIssueDTO.UpdateBy = strEmployeeId;
            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objFabricIssueBLL.processForeignFabricIssueFromReceive(objFabricIssueDTO);
            //MessageBox(strMsg);


        }


        protected void gvContractDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvFabricDetails.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("TRAN_ID");

            int stor_id = Convert.ToInt32(gvFabricDetails.DataKeys[e.RowIndex].Value.ToString());
            string strTranId = Convert.ToString(stor_id);


            deleteForeignFabricIssue(strTranId);

            searchForeignFabricMain();
            searchForeignFabricIssueSub();
        }

        protected void ddlProgrammeId_SelectedIndexChanged(object sender, EventArgs e)
        {


            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();

            DropDownList tb = (DropDownList)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;

            DropDownList ddlProgrammeId = (DropDownList)gvFabricDetails.Rows[rowindex].FindControl("ddlProgrammeId");

            string strProgrammeId = ddlProgrammeId.SelectedValue;

            if (ddlSupplierId.SelectedValue == " ")
            {

                string strMsg = "Please Select Supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;

            }
            else
            {
                string strSupplierId = ddlSupplierId.SelectedValue;

                //objFabricIssueDTO = objFabricIssueBLL.searchForeignLcFabricTotalQty(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOfficeId);


                //TextBox txtReceiveQuantity = (TextBox)gvFabricDetails.Rows[rowindex].FindControl("txtReceiveQuantity");
                //txtReceiveQuantity.Text = objFabricIssueDTO.ReceiveQuantity;
                //txtReceiveQuantity.Attributes.Add("readonly", "readonly");

                TextBox txtRemainingQuantity = (TextBox)gvFabricDetails.Rows[rowindex].FindControl("txtRemainingQuantity");
                //TextBox txtRemainingQuantity = (TextBox)gvFabricDetails.Rows[i].FindControl("txtRemainingQuantity");
                txtRemainingQuantity.Attributes.Add("readonly", "readonly");









                LookUpBLL objLookUpBLL = new LookUpBLL();





                DropDownList ddlFabricId = (DropDownList)gvFabricDetails.Rows[rowindex].FindControl("ddlFabricId");
                ddlFabricId.DataSource = objLookUpBLL.getFabricIdByProgramme(ddlSupplierId.SelectedValue.ToString(), strProgrammeId, strHeadOfficeId, strBranchOfficeId);


                ddlFabricId.DataTextField = "FABRIC_NAME";
                ddlFabricId.DataValueField = "FABRIC_ID";

                ddlFabricId.DataBind();
                if (ddlFabricId.Items.Count > 0)
                {

                    ddlFabricId.SelectedIndex = 0;
                }



                DropDownList ddlFabricConstructionId = (DropDownList)gvFabricDetails.Rows[rowindex].FindControl("ddlFabricConstructionId");
                ddlFabricConstructionId.DataSource = objLookUpBLL.getFabricConstructionIdByProgramme(ddlSupplierId.SelectedValue.ToString(), strProgrammeId, strHeadOfficeId, strBranchOfficeId);


                ddlFabricConstructionId.DataTextField = "FABRIC_CONSTRUCTION_NAME";
                ddlFabricConstructionId.DataValueField = "FABRIC_CONSTRUCTION_ID";

                ddlFabricConstructionId.DataBind();
                if (ddlFabricConstructionId.Items.Count > 0)
                {

                    ddlFabricConstructionId.SelectedIndex = 0;
                }


                DropDownList ddlStyleId = (DropDownList)gvFabricDetails.Rows[rowindex].FindControl("ddlStyleId");
                ddlStyleId.DataSource = objLookUpBLL.getStyleIdByProgramme(ddlSupplierId.SelectedValue.ToString(), strProgrammeId, strHeadOfficeId, strBranchOfficeId);


                ddlStyleId.DataTextField = "STYLE_NO";
                ddlStyleId.DataValueField = "STYLE_ID";

                ddlStyleId.DataBind();
                if (ddlStyleId.Items.Count > 0)
                {

                    ddlStyleId.SelectedIndex = 0;
                }


                DropDownList ddlArtId = (DropDownList)gvFabricDetails.Rows[rowindex].FindControl("ddlArtId");
                ddlArtId.DataSource = objLookUpBLL.getArtIdByProgramme(ddlSupplierId.SelectedValue.ToString(), strProgrammeId, strHeadOfficeId, strBranchOfficeId);


                ddlArtId.DataTextField = "ART_NO";
                ddlArtId.DataValueField = "ART_ID";

                ddlArtId.DataBind();
                if (ddlArtId.Items.Count > 0)
                {

                    ddlArtId.SelectedIndex = 0;
                }


                DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowindex].FindControl("ddlColorId");
                ddlColorId.DataSource = objLookUpBLL.getColorIdByProgramme(ddlSupplierId.SelectedValue.ToString(), strProgrammeId, strHeadOfficeId, strBranchOfficeId);


                ddlColorId.DataTextField = "COLOR_NAME";
                ddlColorId.DataValueField = "COLOR_ID";

                ddlColorId.DataBind();
                if (ddlColorId.Items.Count > 0)
                {

                    ddlColorId.SelectedIndex = 0;
                }



                DropDownList ddlUnitId = (DropDownList)gvFabricDetails.Rows[rowindex].FindControl("ddlUnitId");
                ddlUnitId.DataSource = objLookUpBLL.getUnitIdByProgramme(ddlSupplierId.SelectedValue.ToString(), strProgrammeId, strHeadOfficeId, strBranchOfficeId);


                ddlUnitId.DataTextField = "UNIT_NAME";
                ddlUnitId.DataValueField = "UNIT_ID";

                ddlUnitId.DataBind();
                if (ddlUnitId.Items.Count > 0)
                {

                    ddlUnitId.SelectedIndex = 0;
                }

            }


        }
        protected void ddlUnitId_SelectedIndexChanged(object sender, EventArgs e)
        {


            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();

            DropDownList tb = (DropDownList)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;

            DropDownList ddlProgrammeId = (DropDownList)gvFabricDetails.Rows[rowindex].FindControl("ddlProgrammeId");
            DropDownList ddlFabricId = (DropDownList)gvFabricDetails.Rows[rowindex].FindControl("ddlFabricId");
            DropDownList ddlFabricConstructionId = (DropDownList)gvFabricDetails.Rows[rowindex].FindControl("ddlFabricConstructionId");
            DropDownList ddlStyleId = (DropDownList)gvFabricDetails.Rows[rowindex].FindControl("ddlStyleId");
            DropDownList ddlArtId = (DropDownList)gvFabricDetails.Rows[rowindex].FindControl("ddlArtId");
            DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowindex].FindControl("ddlColorId");
            DropDownList ddlUnitId = (DropDownList)gvFabricDetails.Rows[rowindex].FindControl("ddlUnitId");


            if (ddlSupplierId.SelectedValue == " ")
            {

                string strMsg = "Please Select Supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;

            }
            else
            {
                string strSupplierId = ddlSupplierId.SelectedValue;
                string strProgrammeId = ddlProgrammeId.SelectedValue;
                string strFabricId = ddlFabricId.SelectedValue;
                string strConstructionId = ddlFabricConstructionId.SelectedValue;
                string strStyleId = ddlStyleId.SelectedValue;
                string strArtId = ddlArtId.SelectedValue;
                string strColorId = ddlColorId.SelectedValue;
                string strUnitId = ddlUnitId.SelectedValue;


                objFabricIssueDTO = objFabricIssueBLL.searchSingleQty(strSupplierId, strProgrammeId, strFabricId, strConstructionId, strStyleId, strArtId, strColorId, strUnitId, strHeadOfficeId, strBranchOfficeId);

               
                TextBox txtReceiveQuantity = (TextBox)gvFabricDetails.Rows[rowindex].FindControl("txtReceiveQuantity");
                txtReceiveQuantity.Text = objFabricIssueDTO.ReceiveQuantity;
                txtReceiveQuantity.Attributes.Add("readonly", "readonly");

                TextBox txtRemainingQuantity = (TextBox)gvFabricDetails.Rows[rowindex].FindControl("txtRemainingQuantity");
                txtRemainingQuantity.Attributes.Add("readonly", "readonly");



                searchQty( strSupplierId,  strProgrammeId,  strFabricId,  strConstructionId,  strStyleId);
            }


        }



        public void searchQty(string strSupplierId, string strProgrammeId, string strFabricId, string strConstructionId, string strStyleId)
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();

            objFabricIssueDTO = objFabricIssueBLL.searchForeignFabricTotalRcvQty(strSupplierId, strProgrammeId, strFabricId, strConstructionId, strStyleId, strHeadOfficeId, strBranchOfficeId);

            txtTotalIssueQuantity.Text = objFabricIssueDTO.IssueQuantity;
            txtTotalIssueQuantity.ReadOnly = true;

            txtTotalReceiveQuantity.Text = objFabricIssueDTO.ReceiveQuantity;
            txtTotalReceiveQuantity.ReadOnly = true;


            txtTotalRemainingQuantity.Text = objFabricIssueDTO.RemainingQuantity;
            txtTotalRemainingQuantity.ReadOnly = true;


        }

        public void searchTotalRIQuantity()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();



            string strSupplierId = "";
            string strProgrammeId ="";
            string strFabricId = "";
            string strConstructionId = "";
            string strStyleId = "";


            if (ddlSupplierIdSearch.Text != "0")
            {
                strSupplierId = ddlSupplierIdSearch.SelectedValue;
            }
            else
            {
                strSupplierId = "";
            }


            if (ddlProgrammeIdSearch.Text != " ")
            {
                strProgrammeId = ddlProgrammeIdSearch.SelectedValue;
            }
            else
            {
                strProgrammeId = "";
            }

            if (ddlStyleIdSearch.Text != " ")
            {
                strStyleId = ddlStyleIdSearch.SelectedValue;
            }
            else
            {
                strStyleId = "";
            }


            if (ddlFabricIdSearch.Text != " ")
            {
                strFabricId = ddlFabricIdSearch.SelectedValue;
            }
            else
            {
                strFabricId = "";
            }


            if (ddlConstructioIdSearch.Text != " ")
            {
                strConstructionId = ddlConstructioIdSearch.SelectedValue;
            }
            else
            {
                strConstructionId = "";
            }



            objFabricIssueDTO = objFabricIssueBLL.searchForeignFabricTotalRcvQty(strSupplierId, strProgrammeId, strFabricId, strConstructionId, strStyleId, strHeadOfficeId, strBranchOfficeId);

            txtTotalIssueQuantity.Text = objFabricIssueDTO.IssueQuantity;
            txtTotalIssueQuantity.ReadOnly = true;

            txtTotalReceiveQuantity.Text = objFabricIssueDTO.ReceiveQuantity;
            txtTotalReceiveQuantity.ReadOnly = true;

            txtTotalRemainingQuantity.Text = objFabricIssueDTO.RemainingQuantity;
            txtTotalRemainingQuantity.ReadOnly = true;

        }




        protected void btnSearchRecord_Click(object sender, EventArgs e)
        {
            SearchForeignfabricIssue();
        }


        public void SearchForeignfabricIssue()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();




            DataTable dt = new DataTable();

            objFabricIssueDTO.ChallanNo = txtChallanNoSearch.Text;
          

            objFabricIssueDTO.IssueYear = txtYear.Text;


            if (ddlSupplierIdSearch.Text != "0")
            {
                objFabricIssueDTO.SupplierId = ddlSupplierIdSearch.SelectedValue;
            }
            else
            {
                objFabricIssueDTO.SupplierId = "";
            }


            if (ddlProgrammeIdSearch.Text != " ")
            {
                objFabricIssueDTO.ProgrammeId = ddlProgrammeIdSearch.SelectedValue;
            }
            else
            {
                objFabricIssueDTO.ProgrammeId = "";
            }

            if (ddlStyleIdSearch.Text != " ")
            {
                objFabricIssueDTO.StyleId = ddlStyleIdSearch.SelectedValue;
            }
            else
            {
                objFabricIssueDTO.StyleId = "";
            }

            if (ddlArtIdSearch.Text != " ")
            {
                objFabricIssueDTO.ArtId = ddlArtIdSearch.SelectedValue;
            }
            else
            {
                objFabricIssueDTO.ArtId = "";
            }


            if (ddlFabricIdSearch.Text != " ")
            {
                objFabricIssueDTO.FabricId = ddlFabricIdSearch.SelectedValue;
            }
            else
            {
                objFabricIssueDTO.FabricId = "";
            }


            if (ddlConstructioIdSearch.Text != " ")
            {
                objFabricIssueDTO.FabricConstructionId = ddlConstructioIdSearch.SelectedValue;
            }
            else
            {
                objFabricIssueDTO.FabricConstructionId = "";
            }





            objFabricIssueDTO.UpdateBy = strEmployeeId;
            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;


            dt = objFabricIssueBLL.SearchForeignfabricIssue(objFabricIssueDTO);


            if (dt.Rows.Count > 0)
            {
                gvForeignFabric.DataSource = dt;
                gvForeignFabric.DataBind();



                string strMsg = "TOTAL " + gvForeignFabric.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvForeignFabric.DataSource = dt;
                gvForeignFabric.DataBind();
                int totalcolums = gvForeignFabric.Rows[0].Cells.Count;
                gvForeignFabric.Rows[0].Cells.Clear();
                gvForeignFabric.Rows[0].Cells.Add(new TableCell());
                gvForeignFabric.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvForeignFabric.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }


        }



        #region gridviewEvent

        protected void gvForeignFabric_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvForeignFabric_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

       
        protected void gvForeignFabric_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvForeignFabric.SelectedRow.RowIndex + 1;


            string strReceiveDate = gvForeignFabric.SelectedRow.Cells[0].Text;
            string strInvoiceNo = gvForeignFabric.SelectedRow.Cells[1].Text;

            dtpIssueDate.Text = strReceiveDate;
            txtChallanNo.Text = strInvoiceNo;

            //dtpReceiveDate.Text = strReceiveDate;
            //txtInvoiceNo.Text = strInvoiceNo;


            searchForeignFabricMain();
            searchForeignFabricIssueSub();


        }










        #endregion

        protected void ddlStoreId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}