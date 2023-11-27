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
    public partial class ZipperIssue : System.Web.UI.Page
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
            
                getSupplierId();
                getStoreId();
                //getCurrentDate();
                FirstGridViewRow();

            }

            if (IsPostBack)
            {

                loadSesscion();

            }

            //txtPO.Attributes.Add("onkeypress", "return controlEnter('" + txtPI.ClientID + "', event)");
            //txtPI.Attributes.Add("onkeypress", "return controlEnter('" + dtpReceiveDate.ClientID + "', event)");
            
        }

        #region "Function"


        private void FirstGridViewRow()
        {


            //if (ViewState["CurrentTable"] != null)
            //{
            DataTable dt = new DataTable();
            DataRow dr = null;
            // dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("PROGRAMME_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("STYLE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("ART_ID", typeof(string)));

            dt.Columns.Add(new DataColumn("COLOR_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("PARTICULAR_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("LINE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("MEASURE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("BLANCE", typeof(string)));

            dr = dt.NewRow();
            // dr["RowNumber"] = 1;
            dr["PROGRAMME_ID"] = string.Empty;
            dr["STYLE_ID"] = string.Empty;
            dr["ART_ID"] = string.Empty;

            dr["COLOR_ID"] = string.Empty;
            dr["PARTICULAR_NAME"] = string.Empty;
            dr["LINE_ID"] = string.Empty;
            dr["MEASURE_ID"] = string.Empty;

           
            dr["QUANTITY"] = string.Empty;
            dr["BLANCE"] = string.Empty;

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

            dtpIssueDate.Text = objLookUpDTO.AttendenceDate;


        }


        public void getStoreId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlStoreId.DataSource = objLookUpBLL.getStoreId();

            ddlStoreId.DataTextField = "store_name";
            ddlStoreId.DataValueField = "store_id";

            ddlStoreId.DataBind();
            if (ddlStoreId.Items.Count > 0)
            {

                ddlStoreId.SelectedIndex = 0;
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
                        DropDownList ddlStyleId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("ddlStyleId");
                        DropDownList ddlArtId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlArtId");
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                        TextBox txtParticular = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("txtParticular");
                        DropDownList ddlLineId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("ddlLineId");
                        DropDownList ddlMeasureId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("ddlMeasureId");


                        TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtBlance");
                        TextBox txtQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("txtQuantity");
                        

                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["PROGRAMME_ID"] = ddlProgrammeId.Text;
                        dtCurrentTable.Rows[i - 1]["STYLE_ID"] = ddlStyleId.Text;
                        dtCurrentTable.Rows[i - 1]["ART_ID"] = ddlArtId.Text;
                        dtCurrentTable.Rows[i - 1]["COLOR_ID"] = ddlColorId.Text;
                        dtCurrentTable.Rows[i - 1]["PARTICULAR_NAME"] = txtParticular.Text;
                        dtCurrentTable.Rows[i - 1]["LINE_ID"] = ddlLineId.Text;
                        dtCurrentTable.Rows[i - 1]["MEASURE_ID"] = ddlMeasureId.Text;
                       

                        
                        dtCurrentTable.Rows[i - 1]["QUANTITY"] = txtQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["BLANCE"] = txtBlance.Text;

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
                        DropDownList ddlStyleId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("ddlStyleId");
                        DropDownList ddlArtId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlArtId");
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                        TextBox txtParticular = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("txtParticular");
                       
                        DropDownList ddlLineId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("ddlLineId");
                        DropDownList ddlMeasureId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("ddlMeasureId");


                        TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtBlance");
                        TextBox txtQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("txtQuantity");


                        ddlProgrammeId.Text = dt.Rows[i]["PROGRAMME_ID"].ToString();
                        ddlStyleId.Text = dt.Rows[i]["STYLE_ID"].ToString();
                        ddlArtId.Text = dt.Rows[i]["ART_ID"].ToString();
                        ddlColorId.Text = dt.Rows[i]["COLOR_ID"].ToString();
                        txtParticular.Text = dt.Rows[i]["PARTICULAR_NAME"].ToString();
                        ddlLineId.Text = dt.Rows[i]["LINE_ID"].ToString();
                        ddlMeasureId.Text = dt.Rows[i]["MEASURE_ID"].ToString();



                        txtBlance.Text = dt.Rows[i]["BLANCE"].ToString();
                        txtQuantity.Text = dt.Rows[i]["QUANTITY"].ToString();
                        


                        rowIndex++;
                    }
                }
            }
        }


        public void saveZipperIssue()
        {
            int rowIndex = 0;
            string strMsg = "";

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

                        DropDownList ddlProgrammeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("ddlProgrammeId");
                        DropDownList ddlStyleId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("ddlStyleId");
                        DropDownList ddlArtId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlArtId");
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                        TextBox txtParticular = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("txtParticular");

                        DropDownList ddlLineId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("ddlLineId");
                        DropDownList ddlMeasureId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("ddlMeasureId");


                        TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtBlance");
                        TextBox txtQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("txtQuantity");



                       
                        

                        if (ddlProgrammeId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.ProgrammeId = ddlProgrammeId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.ProgrammeId = "";

                        }

                        if (ddlStyleId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.StyleId = ddlStyleId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.StyleId = "";

                        }

                        if (ddlArtId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.ArtId = ddlArtId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.ArtId = "";

                        }


                     
                        if (ddlColorId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.ColorId = ddlColorId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.ColorId = "";

                        }


                        if (ddlLineId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.LineId = ddlLineId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.LineId = "";

                        }

                        if (ddlMeasureId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.MeasureId = ddlMeasureId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.MeasureId = "";

                        }

                        if (ddlSupplierId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.SupplierId = "";

                        }


                        objFabricIssueDTO.ParticularName = txtParticular.Text;
                        objFabricIssueDTO.IssueDate = dtpIssueDate.Text;

                        
                        objFabricIssueDTO.Blance = txtBlance.Text;
                        objFabricIssueDTO.Quantity = txtQuantity.Text;

                        objFabricIssueDTO.UpdateBy = strEmployeeId;
                        objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
                        objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;

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




                        strMsg = objFabricIssueBLL.saveZipperIssue(objFabricIssueDTO);
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

        public void deleteZipperIssue()
        {
            
            string strMsg = "";

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();




          
            objFabricIssueDTO.ChallanNo = txtChallanNo.Text;
            objFabricIssueDTO.IssueDate = dtpIssueDate.Text;

                      
            objFabricIssueDTO.UpdateBy = strEmployeeId;
            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;


            strMsg = objFabricIssueBLL.deleteZipperIssue(objFabricIssueDTO);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;

    
            


        }

        public void searchZipperIssueRecord()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();
            DataTable dt = new DataTable();

          
            objFabricIssueDTO.ChallanNo = txtChallanNo.Text;
            objFabricIssueDTO.IssueDate = dtpIssueDate.Text;
          

            if (ddlSupplierId.SelectedValue.ToString() != " ")
            {
                objFabricIssueDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objFabricIssueDTO.SupplierId = "";

            }


            if (ddlStoreId.SelectedValue.ToString() != " ")
            {
                objFabricIssueDTO.StoreId = ddlStoreId.SelectedValue.ToString();
            }
            else
            {
                objFabricIssueDTO.StoreId = "";

            }




            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFabricIssueBLL.searchZipperIssueRecord(objFabricIssueDTO);


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
        public void searchZipperIssueRecordEntry()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();
            DataTable dt = new DataTable();


            objFabricIssueDTO.ChallanNo = txtChallanNo.Text;
            objFabricIssueDTO.IssueDate = dtpIssueDate.Text;


            if (ddlSupplierId.SelectedValue.ToString() != " ")
            {
                objFabricIssueDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objFabricIssueDTO.SupplierId = "";

            }


            if (ddlStoreId.SelectedValue.ToString() != " ")
            {
                objFabricIssueDTO.StoreId = ddlStoreId.SelectedValue.ToString();
            }
            else
            {
                objFabricIssueDTO.StoreId = "";

            }




            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFabricIssueBLL.searchZipperIssueRecordEntry(objFabricIssueDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                ViewState["CurrentTable"] = dt;
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


        public void searchZipperInfo()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();


            objFabricIssueDTO = objFabricIssueBLL.searchZipperInfo(txtChallanNo.Text, dtpIssueDate.Text, strHeadOfficeId, strBranchOfficeId);

            if (objFabricIssueDTO.SupplierId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlSupplierId.Text = objFabricIssueDTO.SupplierId;
            }

          

            if (objFabricIssueDTO.StoreId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlStoreId.Text = objFabricIssueDTO.StoreId;
            }





            dtpIssueDate.Text = objFabricIssueDTO.IssueDate;
            


        }


        #endregion


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtChallanNo.Text == " ")
            {

                string strMsg = "Please Enter Challan No!!!";
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

            else if (ddlSupplierId.Text == " ")
            {

                string strMsg = "Please Select Supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;
            }

            else if (ddlStoreId.Text == " ")
            {

                string strMsg = "Please Select Store Name!!!";
                MessageBox(strMsg);
                ddlStoreId.Focus();
                return;
            }


            else
            {
                deleteZipperIssue();
                saveZipperIssue();
                searchZipperIssueRecordEntry();
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtChallanNo.Text == " ")
            {

                string strMsg = "Please Enter Challan No!!!";
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

            else
            {

                deleteZipperIssue();

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchZipperIssueRecord();
            searchZipperInfo();
            searchZipperIssueRecordEntry();
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


        #region "Grid View Functionality"
        protected void gvFabricDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFabricDetails.PageIndex = e.NewPageIndex;

        }

        protected void gvFabricDetails_OnSelectedIndexChanged(object sender, EventArgs e)
        {


            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strProgrammeId = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strStyleId = gvEmployeeList.SelectedRow.Cells[2].Text;



        }




        protected void gvFabricDetails_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void gvFabricDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Select")
            {
                int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
                string strProgrammeId = gvEmployeeList.SelectedRow.Cells[1].Text;
                string strStyleId = gvEmployeeList.SelectedRow.Cells[2].Text;
            }
            if (e.CommandName == "Edit")
            {
            }
            if (e.CommandName == "Delete")
            {

            }




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
                DropDownList b = (e.Row.FindControl("ddlStyleId") as DropDownList);
                DropDownList c = (e.Row.FindControl("ddlArtId") as DropDownList);

                DropDownList d = (e.Row.FindControl("ddlColorId") as DropDownList);
                DropDownList f = (e.Row.FindControl("ddlLineId") as DropDownList);
                DropDownList g = (e.Row.FindControl("ddlMeasureId") as DropDownList);

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



                dt2 = objLookUpBLL.getStyleId();
                b.DataSource = dt2;
                b.DataBind();
                b.SelectedValue = dr["STYLE_ID"].ToString();


                dt3 = objLookUpBLL.getArtNo();
                c.DataSource = dt3;
                c.DataBind();
                c.SelectedValue = dr["ART_ID"].ToString();

                dt4 = objLookUpBLL.getColorId();
                d.DataSource = dt4;
                d.DataBind();
                d.SelectedValue = dr["COLOR_ID"].ToString();

                dt5 = objLookUpBLL.getLineId(strHeadOfficeId, strBranchOfficeId);
                f.DataSource = dt5;
                f.DataBind();
                f.SelectedValue = dr["LINE_ID"].ToString();


                dt6 = objLookUpBLL.getMeasureId();
                g.DataSource = dt6;
                g.DataBind();
                g.SelectedValue = dr["MEASURE_ID"].ToString();



            }



        }

        
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                searchZipperIssueRecord();
                searchZipperInfo();
            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;

        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {


            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strChallanNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strIssueDate = gvEmployeeList.SelectedRow.Cells[2].Text;


            txtChallanNo.Text = strChallanNo;
            dtpIssueDate.Text = strIssueDate;

            searchZipperIssueRecordEntry();

        }


        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {


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

    }
}