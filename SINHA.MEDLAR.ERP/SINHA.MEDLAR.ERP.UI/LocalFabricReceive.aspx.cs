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
    public partial class LocalFabricReceive : System.Web.UI.Page
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
               
                getFabricId();
                getConstructionId();
                getSupplierId();
                //getCurrentDate();
                FirstGridViewRow();
               
            }

            if (IsPostBack)
            {

                loadSesscion();

            }
            //gvFabricDetails.Columns[10].Visible = false;
            
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

            dt.Columns.Add(new DataColumn("COLOR_ID", typeof(string)));



            dt.Columns.Add(new DataColumn("RECEIVE_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("TOTAL_RECEIVE_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("PO_QUANTITY", typeof(string)));

           
            dt.Columns.Add(new DataColumn("UNIT_ID", typeof(string)));

            dt.Columns.Add(new DataColumn("RATE", typeof(string)));
            dt.Columns.Add(new DataColumn("CURRENCY_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));

            dr = dt.NewRow();
            // dr["RowNumber"] = 1;
            dr["PO_NO"] = string.Empty;
            dr["PI_NO"] = string.Empty;
            dr["PROGRAMME_ID"] = string.Empty;

            dr["COLOR_ID"] = string.Empty;
            dr["RECEIVE_QUANTITY"] = string.Empty;
            dr["TOTAL_RECEIVE_QUANTITY"] = string.Empty;
            dr["PO_QUANTITY"] = string.Empty;
            dr["UNIT_ID"] = string.Empty;

            dr["RATE"] = string.Empty;
            dr["CURRENCY_ID"] = string.Empty;
           
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

            dtpReceiveDate.Text = objLookUpDTO.AttendenceDate;


        }



        public void getFabricId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddLFabricId.DataSource = objLookUpBLL.getFabricId();

            ddLFabricId.DataTextField = "FABRIC_NAME";
            ddLFabricId.DataValueField = "FABRIC_ID";

            ddLFabricId.DataBind();
            if (ddLFabricId.Items.Count > 0)
            {

                ddLFabricId.SelectedIndex = 0;
            }


        }

        public void getConstructionId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddLFabricIdConstructionId.DataSource = objLookUpBLL.getConstructionId();

            ddLFabricIdConstructionId.DataTextField = "FABRIC_CONSTRUCTION_NAME";
            ddLFabricIdConstructionId.DataValueField = "FABRIC_CONSTRUCTION_ID";

            ddLFabricIdConstructionId.DataBind();
            if (ddLFabricIdConstructionId.Items.Count > 0)
            {

                ddLFabricIdConstructionId.SelectedIndex = 0;
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
                        
                        TextBox txtPO = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("txtPO");
                        TextBox txtPI = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("txtPI");


                        DropDownList ddlProgrammeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlProgrammeId");
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");


                        TextBox txtReceiveQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("txtReceiveQuantity");
                        TextBox txtTotalReceiveQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("txtTotalReceiveQuantity");
                        TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtBlance");


                        DropDownList ddlMeasureId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("ddlMeasureId");
                        DropDownList ddlCurrencyId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("ddlCurrencyId");

                        TextBox txtRate = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[9].FindControl("txtRate");
                        TextBox txtTranId = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[10].FindControl("txtTranId");

                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["PO_NO"] = txtPO.Text;
                        dtCurrentTable.Rows[i - 1]["PI_NO"] = txtPI.Text;
                        dtCurrentTable.Rows[i - 1]["PROGRAMME_ID"] = ddlProgrammeId.Text;
                        dtCurrentTable.Rows[i - 1]["COLOR_ID"] = ddlColorId.Text;


                        dtCurrentTable.Rows[i - 1]["RECEIVE_QUANTITY"] = txtReceiveQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["TOTAL_RECEIVE_QUANTITY"] = txtTotalReceiveQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["PO_QUANTITY"] = txtBlance.Text;
                       
                        dtCurrentTable.Rows[i - 1]["UNIT_ID"] = ddlMeasureId.Text;
                        dtCurrentTable.Rows[i - 1]["CURRENCY_ID"] = ddlCurrencyId.Text;


                        dtCurrentTable.Rows[i - 1]["RATE"] = txtRate.Text;
                
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
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");


                        TextBox txtReceiveQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("txtReceiveQuantity");
                        TextBox txtTotalReceiveQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("txtTotalReceiveQuantity");
                        TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtBlance");

                        DropDownList ddlMeasureId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("ddlMeasureId");
                        DropDownList ddlCurrencyId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("ddlCurrencyId");

                        TextBox txtRate = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[9].FindControl("txtRate");
                     
                        TextBox txtTranId = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[10].FindControl("txtTranId");


                        txtPO.Text = dt.Rows[i]["PO_NO"].ToString();
                        txtPI.Text = dt.Rows[i]["PI_NO"].ToString();


                        ddlProgrammeId.Text = dt.Rows[i]["PROGRAMME_ID"].ToString();
                        ddlColorId.Text = dt.Rows[i]["COLOR_ID"].ToString();



                        txtReceiveQuantity.Text = dt.Rows[i]["RECEIVE_QUANTITY"].ToString();
                        txtTotalReceiveQuantity.Text = dt.Rows[i]["TOTAL_RECEIVE_QUANTITY"].ToString();
                        txtBlance.Text = dt.Rows[i]["PO_QUANTITY"].ToString();

                        ddlMeasureId.Text = dt.Rows[i]["UNIT_ID"].ToString();
                        ddlCurrencyId.Text = dt.Rows[i]["CURRENCY_ID"].ToString();
                    
                        txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();



                        rowIndex++;
                    }
                }
            }
        }


        public void saveLocalFabricReceive()
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

                        TextBox txtPO = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("txtPO");
                        TextBox txtPI = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("txtPI");


                        DropDownList ddlProgrammeId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("ddlProgrammeId");
                        DropDownList ddlColorId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("ddlColorId");


                        TextBox txtReceiveQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("txtReceiveQuantity");
                        TextBox txtTotalReceiveQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("txtTotalReceiveQuantity");
                        TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtBlance");

                        DropDownList ddlMeasureId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("ddlMeasureId");
                        DropDownList ddlCurrencyId = (DropDownList)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("ddlCurrencyId");

                        TextBox txtRate = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[9].FindControl("txtRate");
                     
                        TextBox txtTranId = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[10].FindControl("txtTranId");


                        //sc.Add(string.Format("{0},{1}, {2}, {3},{4},{5},{6},{7},{8},{9}", txtPO.Text, txtPI.Text, ddlProgrammeId.SelectedValue.ToString(), ddlColorId.SelectedValue.ToString(), txtReceiveQuantity.Text, txtTotalReceiveQuantity.Text, txtBlance.Text, ddlMeasureId.SelectedValue.ToString(), txtRate.Text, ddlCurrencyId.SelectedValue.ToString()));



                        if (ddlCurrencyId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.CurrencyId = ddlCurrencyId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.CurrencyId = "";

                        }

                        if (ddlMeasureId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.MeasureId = ddlMeasureId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.MeasureId = "";

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


                        if (ddlSupplierId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.SupplierId = "";

                        }

                        if (ddLFabricId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.FabricId = ddLFabricId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.FabricId = "";

                        }

                        if (ddLFabricIdConstructionId.SelectedValue.ToString() != " ")
                        {
                            objFabricIssueDTO.FabricConstructionId = ddLFabricIdConstructionId.SelectedValue.ToString();
                        }
                        else
                        {
                            objFabricIssueDTO.FabricConstructionId = "";

                        }

                        objFabricIssueDTO.PI = txtPI.Text;
                        objFabricIssueDTO.PO = txtPO.Text;
                        objFabricIssueDTO.Amount = txtAmount.Text;


                        objFabricIssueDTO.Blance = txtBlance.Text;
                        objFabricIssueDTO.Rate = txtRate.Text;
                        objFabricIssueDTO.TotalReceiveQuantity = txtTotalReceiveQuantity.Text;
                        objFabricIssueDTO.ReceiveQuantity = txtReceiveQuantity.Text;
                        objFabricIssueDTO.ReceiveDate = dtpReceiveDate.Text;
                        objFabricIssueDTO.ChallanNo = txtChallanNo.Text;
                        objFabricIssueDTO.TranId = txtTranId.Text;

                        objFabricIssueDTO.UpdateBy = strEmployeeId;
                        objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
                        objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;




                        strMsg = objFabricIssueBLL.saveLocalFabricReceive(objFabricIssueDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;

                        rowIndex++;

                    }

                   
                        MessageBox(strMsg);
                    


                }
            }


        }
        public void deleteLocalFabricReceive()
        {
            int rowIndex = 0;
            string strMsg = "";

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();



            objFabricIssueDTO.ChallanNo = txtChallanNo.Text;




            objFabricIssueDTO.UpdateBy = strEmployeeId;
            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;




            strMsg = objFabricIssueBLL.deleteLocalFabricReceive(objFabricIssueDTO);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;


                
            


        }


        public void searchFabricReceive()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();
            DataTable dt = new DataTable();


         
            objFabricIssueDTO.ChallanNo = txtChallanNo.Text;


            if (ddlSupplierId.SelectedValue.ToString() != " ")
            {
                objFabricIssueDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objFabricIssueDTO.SupplierId = "";

            }

            if (ddLFabricId.SelectedValue.ToString() != " ")
            {
                objFabricIssueDTO.FabricId = ddLFabricId.SelectedValue.ToString();
            }
            else
            {
                objFabricIssueDTO.FabricId = "";

            }


            if (ddLFabricIdConstructionId.SelectedValue.ToString() != " ")
            {
                objFabricIssueDTO.FabricConstructionId = ddLFabricIdConstructionId.SelectedValue.ToString();
            }
            else
            {
                objFabricIssueDTO.FabricConstructionId = "";

            }



            objFabricIssueDTO.ReceiveDate = dtpReceiveDate.Text;



            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFabricIssueBLL.searchFabricReceive(objFabricIssueDTO);


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
     
        

      

       
        public void searchFabrciReceiveSupp()
        {

            //FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            //FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();


            //objFabricIssueDTO = objFabricIssueBLL.searchFabrciReceiveSupp(txtChallanNo.Text, txtPONo.Text, txtPINo.Text, dtpReceiveDate.Text, strHeadOfficeId, strBranchOfficeId);


            //if (objFabricIssueDTO.PI == "Y")
            //{

            //    searchFabricReceiveFromSupplier();
            //    searchFabricReceEntry();
            //}
            //else
            //{
            //    searchFabricReceiveFromPI();
            //    searchFabrciReceiveEntryPI();
            //}





        }

        //public void searchFabrciReceiveEntryPI()
        //{

        //    FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
        //    FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();


        //    objFabricIssueDTO = objFabricIssueBLL.searchFabrciReceiveEntryPI(txtChallanNo.Text, txtPONo.Text, txtPINo.Text, dtpReceiveDate.Text, strHeadOfficeId, strBranchOfficeId);



        

        //    if (objFabricIssueDTO.SupplierId == "0")
        //    {

        //        //nothing to do
        //    }
        //    else
        //    {
        //        ddlSupplierId.Text = objFabricIssueDTO.SupplierId;
        //    }



        //    if (objFabricIssueDTO.FabricConstructionId == "0")
        //    {

        //        //nothing to do
        //    }
        //    else
        //    {
        //        ddLFabricIdConstructionId.Text = objFabricIssueDTO.FabricConstructionId;
        //    }


        //    if (objFabricIssueDTO.FabricId == "0")
        //    {

        //        //nothing to do
        //    }
        //    else
        //    {
        //        ddLFabricId.Text = objFabricIssueDTO.FabricId;
        //    }


        //    dtpReceiveDate.Text = objFabricIssueDTO.ReceiveDate;
        //    txtAmount.Text = objFabricIssueDTO.Amount;


        //}

        #endregion

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



                dt2 = objLookUpBLL.getColorIdStore();
                d.DataSource = dt2;
                d.DataBind();
                d.SelectedValue = dr["COLOR_ID"].ToString();



                dt5 = objLookUpBLL.getUnitIdStore(strHeadOfficeId, strBranchOfficeId);
                f.DataSource = dt5;
                f.DataBind();
                f.SelectedValue = dr["UNIT_ID"].ToString();


                dt6 = objLookUpBLL.getCurrencyId(strHeadOfficeId, strBranchOfficeId);
                g.DataSource = dt6;
                g.DataBind();
                g.SelectedValue = dr["CURRENCY_ID"].ToString();



            }
        }


        #endregion

       

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtChallanNo.Text == "")
            {
                string strMsg = "Please Enter Challan No!!!";
                MessageBox(strMsg);
                txtChallanNo.Focus();
                return; 

            }

            else if (ddlSupplierId.Text == " ")
            {

                string strMsg = "Please Select Supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;
            }


            else if (ddLFabricId.Text == " ")
            {

                string strMsg = "Please Select Fabric Name!!!";
                MessageBox(strMsg);
                ddLFabricId.Focus();
                return;
            }

            else if (ddLFabricIdConstructionId.Text == " ")
            {

                string strMsg = "Please Select Fabric Construction!!!";
                MessageBox(strMsg);
                ddLFabricIdConstructionId.Focus();
                return;
            }



            else
            {

          
            saveLocalFabricReceive();
            searcLocalFabricReceiveMain();
            searchFabricReceiveSub();

            }
        }


        public void searcLocalFabricReceiveMain()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();

            string strAmendId = "";


            objFabricIssueDTO = objFabricIssueBLL.searcLocalFabricReceiveMain(txtChallanNo.Text, dtpReceiveDate.Text, ddlSupplierId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);





            if (objFabricIssueDTO.ChallanNo == " ")
            {

                //nothing to do
            }
            else
            {
                txtChallanNo.Text = objFabricIssueDTO.ChallanNo;
            }

            if (objFabricIssueDTO.SupplierId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlSupplierId.SelectedValue = objFabricIssueDTO.SupplierId;
            }
            if (objFabricIssueDTO.ReceiveDate == " ")
            {

                //nothing to do
            }
            else
            {
                dtpReceiveDate.Text = objFabricIssueDTO.ReceiveDate;
            }




            if (objFabricIssueDTO.FabricId == "0")
            {

                //nothing to do
            }
            else
            {
                ddLFabricId.SelectedValue = objFabricIssueDTO.FabricId;
            }

            if (objFabricIssueDTO.FabricConstructionId == "0")
            {

                //nothing to do
            }
            else
            {
                ddLFabricIdConstructionId.SelectedValue = objFabricIssueDTO.FabricConstructionId;
            }






        }

        public void searchFabricReceiveSub()
        {

            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();
            DataTable dt = new DataTable();



            objFabricIssueDTO.ChallanNo = txtChallanNo.Text;


            if (ddlSupplierId.SelectedValue.ToString() != " ")
            {
                objFabricIssueDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objFabricIssueDTO.SupplierId = "";

            }

            if (ddLFabricId.SelectedValue.ToString() != " ")
            {
                objFabricIssueDTO.FabricId = ddLFabricId.SelectedValue.ToString();
            }
            else
            {
                objFabricIssueDTO.FabricId = "";

            }


            if (ddLFabricIdConstructionId.SelectedValue.ToString() != " ")
            {
                objFabricIssueDTO.FabricConstructionId = ddLFabricIdConstructionId.SelectedValue.ToString();
            }
            else
            {
                objFabricIssueDTO.FabricConstructionId = "";

            }



            objFabricIssueDTO.ReceiveDate = dtpReceiveDate.Text;



            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFabricIssueBLL.searchFabricReceiveSub(objFabricIssueDTO);


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

        protected void btnShow_Click(object sender, EventArgs e)
        {

            if (txtChallanNo.Text == "")
            {
                string strMsg = "Please Enter Challan No!!!";
                MessageBox(strMsg);
                txtChallanNo.Focus();
                return;
            }

            if (dtpReceiveDate.Text == "")
            {
                string strMsg = "Please Enter Receive Date!!!";
                MessageBox(strMsg);
                dtpReceiveDate.Focus();
                return;
            }

            if (ddlSupplierId.Text == "")
            {
                string strMsg = "Please Enter Supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;
            }


            else
            {
                searcLocalFabricReceiveMain();
                searchFabricReceiveSub();


            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {


            if (txtChallanNo.Text == "")
            {
                string strMsg = "Please Enter Challan No!!!";
                MessageBox(strMsg);
                txtChallanNo.Focus();
                return;
            }

            if (dtpReceiveDate.Text == "")
            {
                string strMsg = "Please Enter Receive Date!!!";
                MessageBox(strMsg);
                dtpReceiveDate.Focus();
                return;
            }

            if (ddlSupplierId.Text == "")
            {
                string strMsg = "Please Enter Supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;
            }


            else
            {
                searcLocalFabricReceiveMain();
                searchFabricReceiveSub();


            }

           


        }

        protected void btnSearchLocalFabricReceive_Click(object sender, EventArgs e)
        {
            
        }


     
        protected void btnCalculation_Click(object sender, EventArgs e)
        {
            int rowIndex = 0;
            string strTotalReceiveQty = "";
            int strTotalReceiveQuantity;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {



                        TextBox txtReceiveQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("txtReceiveQuantity");
                        TextBox txtTotalReceiveQuantity = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("txtTotalReceiveQuantity");
                        TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtBlance");
                        TextBox txtQty = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[9].FindControl("txtQty");

                        if (txtReceiveQuantity.Text == "")
                        {
                            txtReceiveQuantity.Text = "0";

                        }
                        if (txtBlance.Text == "")
                        {
                            txtBlance.Text = "0";

                        }

                        if (txtQty.Text == "")
                        {
                            txtQty.Text = "0";

                        }

                        if (strTotalReceiveQty == "")
                        {

                            strTotalReceiveQty = "0";
                        }

                        if (txtReceiveQuantity.Text != "")
                        {

                            strTotalReceiveQuantity = Convert.ToInt32(txtReceiveQuantity.Text) + Convert.ToInt32(strTotalReceiveQty);

                        }
                        else
                        {

                            strTotalReceiveQuantity = Convert.ToInt32(txtReceiveQuantity.Text);
                        }

                        txtTotalReceiveQuantity.Text = Convert.ToString(strTotalReceiveQuantity);

                        int strBlance = Math.Abs(Convert.ToInt32(txtQty.Text) - Convert.ToInt32(txtReceiveQuantity.Text));
                        txtBlance.Text = Convert.ToString(strBlance);


                        strTotalReceiveQty = txtTotalReceiveQuantity.Text;
                    }

                    rowIndex++;


                }




            }

        }

        public void deleteLocalFabricReceive(string strTranId)
        {


            FabricIssueDTO objFabricIssueDTO = new FabricIssueDTO();
            FabricIssueBLL objFabricIssueBLL = new FabricIssueBLL();


            objFabricIssueDTO.ChallanNo = txtChallanNo.Text;
            objFabricIssueDTO.ReceiveDate = dtpReceiveDate.Text;
          
            objFabricIssueDTO.TranId = strTranId;




            objFabricIssueDTO.UpdateBy = strEmployeeId;
            objFabricIssueDTO.HeadOfficeId = strHeadOfficeId;
            objFabricIssueDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objFabricIssueBLL.deleteLocalFabricReceive(objFabricIssueDTO);
            MessageBox(strMsg);


        }



  

        protected void gvContractDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvFabricDetails.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("TRAN_ID");

            int stor_id = Convert.ToInt32(gvFabricDetails.DataKeys[e.RowIndex].Value.ToString());
            string strTranId = Convert.ToString(stor_id);


            deleteLocalFabricReceive(strTranId);

            searcLocalFabricReceiveMain();
            searchFabricReceiveSub();



        }
    }
}