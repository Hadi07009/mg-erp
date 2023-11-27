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


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class DailyCutting : System.Web.UI.Page
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
                getBuyerSearchId();
                getStyleSearId();



            }

            if (IsPostBack)
            {

                loadSesscion();

            }

            txtPoNo.Attributes.Add("onkeypress", "return controlEnter('" + txtSize.ClientID + "', event)");
            txtSize.Attributes.Add("onkeypress", "return controlEnter('" + txtQuantity.ClientID + "', event)");
        }

        #region "Function"



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


        }

        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
        public void clearTextBox()
        {
            txtBuyerName.Text = "";
            txtColorName.Text = "";
            txtPoNo.Text = "";
            txtTotalOrderQuantity.Text = "";
            txtSize.Text = "";
            txtQuantity.Text = "";
            txtStyleNo.Text = "";

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

        public void getStyleSearId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlStyleSearchId.DataSource = objLookUpBLL.getStyleId();

            ddlStyleSearchId.DataTextField = "STYLE_NAME";
            ddlStyleSearchId.DataValueField = "STYLE_ID";

            ddlStyleSearchId.DataBind();
            if (ddlStyleSearchId.Items.Count > 0)
            {

                ddlStyleSearchId.SelectedIndex = 0;
            }

        }




        public void getBuyerSearchId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerSearchId.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerSearchId.DataTextField = "BUYER_NAME";
            ddlBuyerSearchId.DataValueField = "BUYER_ID";

            ddlBuyerSearchId.DataBind();
            if (ddlBuyerSearchId.Items.Count > 0)
            {

                ddlBuyerSearchId.SelectedIndex = 0;
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


        public void saveBuyerMeasurement()
        {


            BuyerPODTO objBuyerPODTO = new BuyerPODTO();
            BuyerPOBLL objBuyerPOBLL = new BuyerPOBLL();


            objBuyerPODTO.Quantity = txtQuantity.Text;
            objBuyerPODTO.Size = txtSize.Text;
            objBuyerPODTO.PONo = txtPoNo.Text;

            objBuyerPODTO.UpdateBy = strEmployeeId;
            objBuyerPODTO.HeadOfficeId = strHeadOfficeId;
            objBuyerPODTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objBuyerPOBLL.saveBuyerMeasurement(objBuyerPODTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);




        }

        public void searchPoEntry()
        {


            BuyerPODTO objBuyerPODTO = new BuyerPODTO();
            BuyerPOBLL objBuyerPOBLL = new BuyerPOBLL();




            objBuyerPODTO = objBuyerPOBLL.searchPoEntry(txtPoNo.Text, strHeadOfficeId, strBranchOfficeId);

            txtBuyerName.Text = objBuyerPODTO.BuyerId;
            txtColorName.Text = objBuyerPODTO.ColorId;
            txtTotalOrderQuantity.Text = objBuyerPODTO.OrderQuantity;
            txtStyleNo.Text = objBuyerPODTO.StyleId;



        }

        public void searchBuyerMeasurement()
        {

            BuyerPODTO objBuyerPODTO = new BuyerPODTO();
            BuyerPOBLL objBuyerPOBLL = new BuyerPOBLL();

            DataTable dt = new DataTable();



            objBuyerPODTO.HeadOfficeId = strHeadOfficeId;
            objBuyerPODTO.BranchOfficeId = strBranchOfficeId;

            objBuyerPODTO.PONo = txtPoNo.Text;
            objBuyerPODTO.POSearchNo = txtPoSearchNo.Text;
           


            dt = objBuyerPOBLL.searchBuyerMeasurement(objBuyerPODTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
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
                //GridView1.Columns[2].Visible = false;
            }

        }



        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchBuyerMeasurement();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPoNo.Text == "")
            {
                string strMsg = "Please Enter PO NO!!!";
                MessageBox(strMsg);
                txtPoNo.Focus();
                return;

            }
            else if (txtTotalOrderQuantity.Text == "")
            {
                string strMsg = "Please PO Entry First!!!";
                MessageBox(strMsg);
                txtTotalOrderQuantity.Focus();
                return;

            }

            else
            {

                saveBuyerMeasurement();
                searchBuyerMeasurement();

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchBuyerMeasurement();
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
            string strEmployeeId = GridView1.SelectedRow.Cells[9].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;





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

        protected void btnSearchPO_Click(object sender, EventArgs e)
        {
            if (txtPoNo.Text == "")
            {

                string strMsg = "Please Enter PO NO!!!";
                MessageBox(strMsg);
                txtPoNo.Focus();
                return; 

            }
            else
            {

                searchPoEntry();

            }
        }


    }
}