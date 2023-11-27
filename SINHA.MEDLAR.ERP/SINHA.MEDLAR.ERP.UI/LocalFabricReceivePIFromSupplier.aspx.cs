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
    public partial class LocalFabricReceivePIFromSupplier : System.Web.UI.Page
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
            dt.Columns.Add(new DataColumn("FABRIC_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("FABRIC_CONSTRUCTION_ID", typeof(string)));

            dt.Columns.Add(new DataColumn("COLOR_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("MEASURE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("CURRENCY_ID", typeof(string)));

            dt.Columns.Add(new DataColumn("RATE", typeof(string)));
            dt.Columns.Add(new DataColumn("QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("BLANCE", typeof(string)));

            dr = dt.NewRow();
            // dr["RowNumber"] = 1;
            dr["PROGRAMME_ID"] = string.Empty;
            dr["FABRIC_ID"] = string.Empty;
            dr["FABRIC_CONSTRUCTION_ID"] = string.Empty;

            dr["COLOR_ID"] = string.Empty;
            dr["MEASURE_ID"] = string.Empty;
            dr["CURRENCY_ID"] = string.Empty;

            dr["RATE"] = string.Empty;
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

            dtpReceiveDate.Text = objLookUpDTO.AttendenceDate;


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
                        DropDownList ddlFabricId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("ddlFabricId");
                        DropDownList ddlFabricConstructionId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlFabricConstructionId");
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                        DropDownList ddlMeasureId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("ddlMeasureId");
                        DropDownList ddlCurrencyId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("ddlCurrencyId");

                        TextBox txtRate = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("txtRate");
                        TextBox txtQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtQuantity");
                        TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtBlance");

                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["PROGRAMME_ID"] = ddlProgrammeId.Text;
                        dtCurrentTable.Rows[i - 1]["FABRIC_ID"] = ddlFabricId.Text;
                        dtCurrentTable.Rows[i - 1]["FABRIC_CONSTRUCTION_ID"] = ddlFabricConstructionId.Text;
                        dtCurrentTable.Rows[i - 1]["COLOR_ID"] = ddlColorId.Text;
                        dtCurrentTable.Rows[i - 1]["MEASURE_ID"] = ddlMeasureId.Text;
                        dtCurrentTable.Rows[i - 1]["CURRENCY_ID"] = ddlCurrencyId.Text;

                        dtCurrentTable.Rows[i - 1]["RATE"] = txtRate.Text;
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
                        DropDownList ddlFabricId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("ddlFabricId");
                        DropDownList ddlFabricConstructionId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlFabricConstructionId");
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                        DropDownList ddlMeasureId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("ddlMeasureId");
                        DropDownList ddlCurrencyId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("ddlCurrencyId");

                        TextBox txtRate = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("txtRate");
                        TextBox txtQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtQuantity");
                        TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtBlance");


                        ddlProgrammeId.Text = dt.Rows[i]["PROGRAMME_ID"].ToString();
                        ddlFabricId.Text = dt.Rows[i]["FABRIC_ID"].ToString();
                        ddlFabricConstructionId.Text = dt.Rows[i]["FABRIC_CONSTRUCTION_ID"].ToString();
                        ddlColorId.Text = dt.Rows[i]["COLOR_ID"].ToString();
                        ddlMeasureId.Text = dt.Rows[i]["MEASURE_ID"].ToString();
                        ddlCurrencyId.Text = dt.Rows[i]["CURRENCY_ID"].ToString();


                        txtRate.Text = dt.Rows[i]["RATE"].ToString();
                        txtQuantity.Text = dt.Rows[i]["QUANTITY"].ToString();
                        txtBlance.Text = dt.Rows[i]["BLANCE"].ToString();


                        rowIndex++;
                    }
                }
            }
        }


        public void saveLocalFabricReceivePI()
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
                        DropDownList ddlFabricId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("ddlFabricId");
                        DropDownList ddlFabricConstructionId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlFabricConstructionId");
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                        DropDownList ddlMeasureId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("ddlMeasureId");
                        DropDownList ddlCurrencyId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("ddlCurrencyId");

                        TextBox txtRate = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("txtRate");
                        TextBox txtQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtQuantity");
                        TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtBlance");



                        sc.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}", ddlProgrammeId.SelectedValue.ToString(), ddlFabricId.SelectedValue.ToString(), ddlFabricConstructionId.SelectedValue.ToString(), ddlColorId.SelectedValue.ToString(), ddlMeasureId.SelectedValue.ToString(), ddlCurrencyId.SelectedValue.ToString(), txtRate.Text, txtQuantity.Text, txtBlance.Text));


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


                     
                        if (ddlColorId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.ColorId = ddlColorId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.ColorId = "";

                        }

                      

                        if (ddlMeasureId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.MeasureId = ddlMeasureId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.MeasureId = "";

                        }

                        if (ddlCurrencyId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.CurrencyId = ddlCurrencyId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.CurrencyId = "";

                        }


                        objFabricIssueDTO.PI = txtPI.Text;
                        objFabricIssueDTO.PO = txtPO.Text;
                        objFabricIssueDTO.ReceiveDate = dtpReceiveDate.Text;

                        objFabricIssueDTO.Rate = txtRate.Text;
                        objFabricIssueDTO.Blance = txtBlance.Text;
                        objFabricIssueDTO.Quantity = txtQuantity.Text;

                        objFabricIssueDTO.UpdateBy = strEmployeeId;
                        objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
                        objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;
                     
                     
                       

                        if (ddlSupplierId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.SupplierId = "";

                        }




                        strMsg = objFabricIssueBLL.saveLocalFabricReceivePI(objFabricIssueDTO);
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

        public void deleteLocalFabricReceivePI()
        {
            
            string strMsg = "";

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();




          
            objFabricIssueDTO.PO = txtPO.Text;
                      
            objFabricIssueDTO.UpdateBy = strEmployeeId;
            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;


            strMsg = objFabricIssueBLL.deleteLocalFabricReceivePI(objFabricIssueDTO);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;

    
            


        }

        public void searchFabricReceivePI()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();
            DataTable dt = new DataTable();

          
            objFabricIssueDTO.ReferenceNo = txtReferenceNo.Text;

          

            if (ddlSupplierId.SelectedValue.ToString() != " ")
            {
                objFabricIssueDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objFabricIssueDTO.SupplierId = "";

            }


            objFabricIssueDTO.ReceiveDate = dtpReceiveDate.Text;
            objFabricIssueDTO.PO = txtPO.Text;
            objFabricIssueDTO.PI = txtPI.Text;


            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFabricIssueBLL.searchFabricReceivePI(objFabricIssueDTO);


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
        public void searchFabricReceiveEntryPI()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();
            DataTable dt = new DataTable();


            objFabricIssueDTO.ReferenceNo = txtReferenceNo.Text;



            if (ddlSupplierId.SelectedValue.ToString() != " ")
            {
                objFabricIssueDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objFabricIssueDTO.SupplierId = "";

            }


            objFabricIssueDTO.ReceiveDate = dtpReceiveDate.Text;
            objFabricIssueDTO.PO = txtPO.Text;
            objFabricIssueDTO.PI = txtPI.Text;


            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFabricIssueBLL.searchFabricReceiveEntryPI(objFabricIssueDTO);


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


        public void searchFabricInfoPI()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();


            objFabricIssueDTO = objFabricIssueBLL.searchFabricInfoPI(txtPO.Text, txtPI.Text, dtpReceiveDate.Text, strHeadOfficeId, strBranchOfficeId);

            if (objFabricIssueDTO.PI == "0")
            {

                //nothing to do
            }
            else
            {
               txtPI.Text = objFabricIssueDTO.PI;
            }

          

            if (objFabricIssueDTO.ReceiveDate == "0")
            {

                //nothing to do
            }
            else
            {
                dtpReceiveDate.Text = objFabricIssueDTO.ReceiveDate;
            }



            if (objFabricIssueDTO.SupplierId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlSupplierId.Text = objFabricIssueDTO.SupplierId;
            }


            txtReferenceNo.Text = objFabricIssueDTO.ReferenceNo;
            txtPO.Text = objFabricIssueDTO.PO;


        }


        #endregion


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPI.Text == " ")
            {

                string strMsg = "Please Enter PI!!!";
                MessageBox(strMsg);
                txtPI.Focus();
                return;
            }

            else if (txtPO.Text == " ")
            {

                string strMsg = "Please Enter PO!!!";
                MessageBox(strMsg);
                txtPO.Focus();
                return;
            }

            else if (dtpReceiveDate.Text == " ")
            {

                string strMsg = "Please Enter Receive Date!!!";
                MessageBox(strMsg);
                dtpReceiveDate.Focus();
                return;
            }

            else if (ddlSupplierId.Text == " ")
            {

                string strMsg = "Please Select Supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;
            }

            else
            {
                deleteLocalFabricReceivePI();
                saveLocalFabricReceivePI();
                searchFabricReceiveEntryPI();
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
             if (txtPO.Text == " ")
            {

                string strMsg = "Please Enter PO!!!";
                MessageBox(strMsg);
                txtPO.Focus();
                return;
            }

           

            else
            {

                deleteLocalFabricReceivePI();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        protected void btnCalculation_Click(object sender, EventArgs e)
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
               
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {


                       
                        TextBox txtRate = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("txtRate");
                        TextBox txtQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtQuantity");
                        TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtBlance");

                        if (txtRate.Text == "")
                        {
                            txtRate.Text = "0";

                        }
                        else if (txtQuantity.Text == "")
                        {

                            txtQuantity.Text = "0";
                        }
                        else
                        {


                            int strBlance = (Convert.ToInt32(txtRate.Text) * Convert.ToInt32(txtQuantity.Text));
                            txtBlance.Text = Convert.ToString(strBlance);

                        }

                        rowIndex++;
                    }

                }

           


            }

            

        }

        protected void btnSalaryProcess_Click(object sender, EventArgs e)
        {

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
                DropDownList b = (e.Row.FindControl("ddlFabricId") as DropDownList);
                DropDownList c = (e.Row.FindControl("ddlFabricConstructionId") as DropDownList);

                DropDownList d = (e.Row.FindControl("ddlColorId") as DropDownList);
                DropDownList f = (e.Row.FindControl("ddlMeasureId") as DropDownList);
                DropDownList g = (e.Row.FindControl("ddlCurrencyId") as DropDownList);

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



                dt2 = objLookUpBLL.getColorId();
                d.DataSource = dt2;
                d.DataBind();
                d.SelectedValue = dr["COLOR_ID"].ToString();


                dt3 = objLookUpBLL.getFabricId();
                b.DataSource = dt3;
                b.DataBind();
                b.SelectedValue = dr["FABRIC_ID"].ToString();

                dt4 = objLookUpBLL.getConstructionId();
                c.DataSource = dt4;
                c.DataBind();
                c.SelectedValue = dr["FABRIC_CONSTRUCTION_ID"].ToString();

                dt5 = objLookUpBLL.getMeasureId();
                f.DataSource = dt5;
                f.DataBind();
                f.SelectedValue = dr["MEASURE_ID"].ToString();


                dt6 = objLookUpBLL.getCurrencyId(strHeadOfficeId, strBranchOfficeId);
                g.DataSource = dt6;
                g.DataBind();
                g.SelectedValue = dr["CURRENCY_ID"].ToString();



            }
        }

        
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                searchFabricReceivePI();
                searchFabricInfoPI();
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