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
using System.Collections.Specialized;


using System.IO;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class SewingThreadReceive : System.Web.UI.Page
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
                getCurrentDate();
                FirstGridViewRow();
                getSupplierId();
                getProgrammeId();
                getColorId();
                getBrandId();



            }

            if (IsPostBack)
            {

                loadSesscion();

            }


          // gvContractDetails.Columns[9].Visible = false;

          

           
        }


        #region "Function"


        public void getSupplierId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSupplierId.DataSource = objLookUpBLL.getThreadSupplierId();

            ddlSupplierId.DataTextField = "SUPPLIER_NAME";
            ddlSupplierId.DataValueField = "SUPPLIER_ID";

            ddlSupplierId.DataBind();
            if (ddlSupplierId.Items.Count > 0)
            {

                ddlSupplierId.SelectedIndex = 0;
            }


        }



        public void getBrandId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBrandId.DataSource = objLookUpBLL.getBrandId();

            ddlBrandId.DataTextField = "BRAND_NAME";
            ddlBrandId.DataValueField = "BRAND_ID";

            ddlBrandId.DataBind();
            if (ddlBrandId.Items.Count > 0)
            {

                ddlBrandId.SelectedIndex = 0;
            }


        }

        public void getProgrammeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlProgrammeId.DataSource = objLookUpBLL.getProgrammeId();

            ddlProgrammeId.DataTextField = "PROGRAMME_NAME";
            ddlProgrammeId.DataValueField = "PROGRAMME_ID";

            ddlProgrammeId.DataBind();
            if (ddlProgrammeId.Items.Count > 0)
            {

                ddlProgrammeId.SelectedIndex = 0;
            }


        }

        public void getColorId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlColorId.DataSource = objLookUpBLL.getColorIdStore();

            ddlColorId.DataTextField = "COLOR_NAME";
            ddlColorId.DataValueField = "COLOR_ID";

            ddlColorId.DataBind();
            if (ddlColorId.Items.Count > 0)
            {

                ddlColorId.SelectedIndex = 0;
            }


        }
       



        private void FirstGridViewRow()
        {


          
            DataTable dt = new DataTable();
            DataRow dr = null;
           

            dt.Columns.Add(new DataColumn("THREAD_COUNT", typeof(string)));
            dt.Columns.Add(new DataColumn("ART_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("RECEIVE_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("RATE", typeof(string)));
            dt.Columns.Add(new DataColumn("CURRENCY_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("TOTAL_AMOUNT", typeof(string)));
            dt.Columns.Add(new DataColumn("TOTAL_AMOUNT_USD", typeof(string)));


            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));


            dr = dt.NewRow();
          

            dr["THREAD_COUNT"] = string.Empty;
            dr["ART_ID"] = string.Empty;
            dr["RECEIVE_QUANTITY"] = string.Empty;
            dr["RATE"] = string.Empty;

            dr["CURRENCY_ID"] = string.Empty;
            dr["TOTAL_AMOUNT"] = string.Empty;
            dr["TOTAL_AMOUNT_USD"] = string.Empty;



            dr["TRAN_ID"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvContractDetails.DataSource = dt;
            gvContractDetails.DataBind();
         
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

           // dtpIssueDate.Text = objLookUpDTO.AttendenceDate;


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



                        TextBox txtThreadCount = (TextBox)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("txtThreadCount");

                        DropDownList ddlArtId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlArtId");
                        TextBox txtQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("txtQuantity");
                        TextBox txtRate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("txtRate");

                        DropDownList ddlCurrencyId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("ddlCurrencyId");
                        TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtTotalAmount");

                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("txtTranId");





                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["THREAD_COUNT"] = txtThreadCount.Text;
                        dtCurrentTable.Rows[i - 1]["ART_ID"] = ddlArtId.Text;
                        dtCurrentTable.Rows[i - 1]["RECEIVE_QUANTITY"] = txtQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["RATE"] = txtRate.Text;
                        
                        dtCurrentTable.Rows[i - 1]["CURRENCY_ID"] = ddlCurrencyId.Text;
                        dtCurrentTable.Rows[i - 1]["TOTAL_AMOUNT"] = txtTotalAmount.Text;
                        dtCurrentTable.Rows[i - 1]["TRAN_ID"] = txtTranId.Text;
                       
                     


                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvContractDetails.DataSource = dtCurrentTable;
                    gvContractDetails.DataBind();
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


                        TextBox txtThreadCount = (TextBox)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("txtThreadCount");

                        DropDownList ddlArtId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlArtId");
                        TextBox txtQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("txtQuantity");
                        TextBox txtRate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("txtRate");

                        DropDownList ddlCurrencyId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("ddlCurrencyId");
                        TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtTotalAmount");
                        TextBox txtTotalAmountUSD = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtTotalAmountUSD");
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("txtTranId");


                        txtThreadCount.Text = dt.Rows[i]["THREAD_COUNT"].ToString();
                        ddlArtId.Text = dt.Rows[i]["ART_ID"].ToString();
                        txtQuantity.Text = dt.Rows[i]["RECEIVE_QUANTITY"].ToString();
                        txtRate.Text = dt.Rows[i]["RATE"].ToString();
                      
                        txtTotalAmount.Text = dt.Rows[i]["TOTAL_AMOUNT"].ToString();
                        txtTotalAmountUSD.Text = dt.Rows[i]["TOTAL_AMOUNT_USD"].ToString();

                        txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();


                        rowIndex++;
                    }
                }
            }
        }

    


   
      
        public void saveSewingThreadReceiveInfo()
        {


            SewingThreadPriceDTO objSewingThreadPriceDTO = new SewingThreadPriceDTO();
            SewingThreadPriceBLL objSewingThreadPriceBLL = new SewingThreadPriceBLL();


            int rowIndex = 0;
            string strMsg = "";

            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        TextBox txtThreadCount = (TextBox)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("txtThreadCount");
                      
                        DropDownList ddlArtId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("ddlArtId");
                        TextBox txtQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("txtQuantity");
                        TextBox txtRate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("txtRate");

                        DropDownList ddlCurrencyId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("ddlCurrencyId");
                        TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtTotalAmount");
                        TextBox txtTotalAmountUSD = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtTotalAmountUSD");
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("txtTranId");

                        objSewingThreadPriceDTO.ThreadCount = txtThreadCount.Text;
                        objSewingThreadPriceDTO.TranId = txtTranId.Text;
                        objSewingThreadPriceDTO.TotalAmountUSD = txtTotalAmountUSD.Text;

                        if (ddlArtId.SelectedValue.ToString() != " ")
                        {
                            objSewingThreadPriceDTO.ArtId = ddlArtId.SelectedValue.ToString();

                        }
                        else
                        {
                            objSewingThreadPriceDTO.ArtId = "";

                        }
                        objSewingThreadPriceDTO.Quantity = txtQuantity.Text;
                        objSewingThreadPriceDTO.Rate = txtQuantity.Text;

                        if (ddlCurrencyId.SelectedValue.ToString() != " ")
                        {
                            objSewingThreadPriceDTO.CurrencyId = ddlCurrencyId.SelectedValue.ToString();

                        }
                        else
                        {
                            objSewingThreadPriceDTO.CurrencyId = "";

                        }


                        objSewingThreadPriceDTO.TotalAmount = txtTotalAmount.Text;

                        if (ddlSupplierId.SelectedValue.ToString() != " ")
                        {
                            objSewingThreadPriceDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();

                        }
                        else
                        {
                            objSewingThreadPriceDTO.SupplierId = "";

                        }
                        objSewingThreadPriceDTO.ReceiveDate = dtpReceiveDate.Text;
                        objSewingThreadPriceDTO.ChallanNo = txtChallanNo.Text;
                        if (ddlProgrammeId.SelectedValue.ToString() != " ")
                        {
                            objSewingThreadPriceDTO.ProgrammeId = ddlProgrammeId.SelectedValue.ToString();

                        }
                        else
                        {
                            objSewingThreadPriceDTO.ProgrammeId = "";

                        }
                        if (ddlColorId.SelectedValue.ToString() != " ")
                        {
                            objSewingThreadPriceDTO.ColorId = ddlColorId.SelectedValue.ToString();

                        }
                        else
                        {
                            objSewingThreadPriceDTO.ColorId = "";

                        }

                        if (ddlBrandId.SelectedValue.ToString() != " ")
                        {
                            objSewingThreadPriceDTO.BrandId = ddlBrandId.SelectedValue.ToString();

                        }
                        else
                        {
                            objSewingThreadPriceDTO.BrandId = "";

                        }


                        objSewingThreadPriceDTO.DollarToTaka = txtDollarToTaka.Text;



                        objSewingThreadPriceDTO.UpdateBy = strEmployeeId;
                        objSewingThreadPriceDTO.HeadOfficeId = strHeadOfficeId;
                        objSewingThreadPriceDTO.BranchOfficeId = strBranchOfficeId;






                        strMsg = objSewingThreadPriceBLL.saveSewingThreadReceiveInfo(objSewingThreadPriceDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;

                        rowIndex++;



                    }

                    if (strMsg == "INSERTED SUCCESSFULLY" || strMsg == "UPDATED SUCCESSFULLY")
                    {
                        MessageBox(strMsg);

                    }






                }


            }





        }



        public void searchSewingThreadReceiveRecord()
        {



            SewingThreadPriceDTO objSewingThreadPriceDTO = new SewingThreadPriceDTO();
            SewingThreadPriceBLL objSewingThreadPriceBLL = new SewingThreadPriceBLL();

            DataTable dt = new DataTable();



            objSewingThreadPriceDTO.ReceiveDate = dtpReceiveDate.Text;
            objSewingThreadPriceDTO.ChallanNo = txtChallanNo.Text;
            


            if (ddlSupplierId.Text != "0")
            {

                objSewingThreadPriceDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();

            }
            else
            {
                objSewingThreadPriceDTO.SupplierId = "";


            }

            if (ddlProgrammeId.Text != " ")
            {

                objSewingThreadPriceDTO.ProgrammeId = ddlProgrammeId.SelectedValue.ToString();

            }
            else
            {
                objSewingThreadPriceDTO.ProgrammeId = "";


            }
            if (ddlBrandId.Text != " ")
            {

                objSewingThreadPriceDTO.BrandId = ddlBrandId.SelectedValue.ToString();

            }
            else
            {
                objSewingThreadPriceDTO.BrandId = "";


            }

            if (ddlColorId.Text != "0")
            {

                objSewingThreadPriceDTO.ColorId = ddlColorId.SelectedValue.ToString();

            }
            else
            {

                objSewingThreadPriceDTO.ColorId = "";

            }






            objSewingThreadPriceDTO.HeadOfficeId = strHeadOfficeId;
            objSewingThreadPriceDTO.BranchOfficeId = strBranchOfficeId;

            dt = objSewingThreadPriceBLL.searchSewingThreadReceiveRecord(objSewingThreadPriceDTO);


            if (dt.Rows.Count > 0)
            {
                gvContractDetails.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvContractDetails.DataBind();

                int count = ((DataTable)gvContractDetails.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvContractDetails.DataSource = dt;
                gvContractDetails.DataBind();
                int totalcolums = gvContractDetails.Rows[0].Cells.Count;
                gvContractDetails.Rows[0].Cells.Clear();
                gvContractDetails.Rows[0].Cells.Add(new TableCell());
                gvContractDetails.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvContractDetails.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }

    


        public void searchSewingThreadReceiveMain()
        {
            SewingThreadPriceDTO objSewingThreadPriceDTO = new SewingThreadPriceDTO();
            SewingThreadPriceBLL objSewingThreadPriceBLL = new SewingThreadPriceBLL();



            objSewingThreadPriceDTO = objSewingThreadPriceBLL.searchSewingThreadReceiveMain( dtpReceiveDate.Text,ddlSupplierId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);





            if (objSewingThreadPriceDTO.ChallanNo == "0")
            {

                txtChallanNo.Text = "";
            }
            else
            {
                txtChallanNo.Text = objSewingThreadPriceDTO.ChallanNo;
            }


            if (objSewingThreadPriceDTO.ColorId == "0")
            {

                getColorId();
            }
            else
            {
                ddlColorId.SelectedValue = objSewingThreadPriceDTO.ColorId;
            }

            if (objSewingThreadPriceDTO.BrandId == "0")
            {

                getBrandId();
            }
            else
            {
                ddlBrandId.SelectedValue = objSewingThreadPriceDTO.BrandId;
            }

            if (objSewingThreadPriceDTO.ProgrammeId == "0")
            {

                getProgrammeId();
            }
            else
            {
                ddlProgrammeId.SelectedValue = objSewingThreadPriceDTO.ProgrammeId;
            }



            if (objSewingThreadPriceDTO.DollarToTaka == "")
            {
                txtDollarToTaka.Text = "";
            }
            else
            {


            
                txtDollarToTaka.Text = objSewingThreadPriceDTO.DollarToTaka;
            }

           

        }




        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }



        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchSewingThreadReceiveRecord();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {


            if (ddlSupplierId.Text == "")
            {
                string strMsg = "Please Select Supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;
            }


            else if (dtpReceiveDate.Text == "")
            {
                string strMsg = "Please Enter Receive Date!!!";
                MessageBox(strMsg);
                dtpReceiveDate.Focus();
                return;
            }
           
           

            else
            {
                searchSewingThreadReceiveMain();
                searchSewingThreadReceiveRecord();
               

            }

        }

        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {

        }


        #region "Grid View Functionality"
        protected void gvContractDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvContractDetails.PageIndex = e.NewPageIndex;

        }

        protected void gvContractDetails_OnSelectedIndexChanged(object sender, EventArgs e)
        {

           

        }




        protected void gvContractDetails_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void gvContractDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            int stor_id = Convert.ToInt32(gvContractDetails.DataKeys[e.RowIndex].Values["TRAN_ID"].ToString());
           
            string strTranId = Convert.ToString(stor_id);
            deleteSewingThreadReceiveRecord(strTranId);
            //searcFOBCostSheetMain();
            searchSewingThreadReceiveRecord();
            searchSewingThreadReceiveMain();

        }

        protected void gvContractDetails_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void gvContractDetails_Sorting(object sender, GridViewSortEventArgs e)
        {


        }


        protected void gvContractDetails_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LookUpBLL objLookUpBLL = new LookUpBLL();

                DropDownList a = (e.Row.FindControl("ddlCurrencyId") as DropDownList);
             

                DataTable dt = new DataTable();


                DataRowView dr = e.Row.DataItem as DataRowView;


                dt = objLookUpBLL.getCurrencyId(strHeadOfficeId, strBranchOfficeId);
                a.DataSource = dt;
                a.DataBind();
                a.SelectedValue = dr["CURRENCY_ID"].ToString();


              

                DropDownList c= (e.Row.FindControl("ddlArtId") as DropDownList);


                DataTable dt2 = new DataTable();


                DataRowView dr2 = e.Row.DataItem as DataRowView;


                dt2 = objLookUpBLL.getArtId();
                c.DataSource = dt2;
                 c.DataBind();
                c.SelectedValue = dr2["ART_ID"].ToString();




            }






        }


        #endregion

      

        protected void ddlAmendmentId_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            //searchContactRecord();
            //searcContactMain();
            
        }

        protected void btnSearchAmmendMent_Click(object sender, EventArgs e)
        {
         
           // searchContactRecord();
            //searcContactMain();
        }

        

        public void deleteSewingThreadReceiveRecord(string strTranId)
        {


            SewingThreadPriceDTO objSewingThreadPriceDTO = new SewingThreadPriceDTO();
            SewingThreadPriceBLL objSewingThreadPriceBLL = new SewingThreadPriceBLL();




            objSewingThreadPriceDTO.ReceiveDate  = dtpReceiveDate.Text;
            objSewingThreadPriceDTO.TranId = strTranId;
            objSewingThreadPriceDTO.ChallanNo = txtChallanNo.Text;
           

            if(ddlSupplierId.Text !=" ")
            {
                objSewingThreadPriceDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objSewingThreadPriceDTO.SupplierId = "";

            }

            if (ddlProgrammeId.Text != " ")
            {
                objSewingThreadPriceDTO.ProgrammeId = ddlProgrammeId.SelectedValue.ToString();
            }
            else
            {
                objSewingThreadPriceDTO.ProgrammeId = "";

            }

            if (ddlColorId.Text != " ")
            {
                objSewingThreadPriceDTO.ColorId = ddlColorId.SelectedValue.ToString();
            }
            else
            {
                objSewingThreadPriceDTO.ColorId = "";

            }
            if (ddlBrandId.Text != " ")
            {
                objSewingThreadPriceDTO.BrandId = ddlBrandId.SelectedValue.ToString();
            }
            else
            {
                objSewingThreadPriceDTO.BrandId = "";

            }

            objSewingThreadPriceDTO.UpdateBy = strEmployeeId;
            objSewingThreadPriceDTO.HeadOfficeId = strHeadOfficeId;
            objSewingThreadPriceDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objSewingThreadPriceBLL.deleteSewingThreadReceiveRecord(objSewingThreadPriceDTO);
            MessageBox(strMsg);


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlSupplierId.Text == " ")
            {
                string strMsg = "Please Enter Supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;


            }
            else if (dtpReceiveDate.Text == "")
            {
                string strMsg = "Please Enter Receive Date!!!";
                MessageBox(strMsg);
                dtpReceiveDate.Focus();
                return;


            }
            else if (txtChallanNo.Text == "")
            {
                string strMsg = "Please Enter Challan No!!!";
                MessageBox(strMsg);
                txtChallanNo.Focus();
                return;


            }
            else if (ddlProgrammeId.Text == " ")
            {
                string strMsg = "Please Enter Programme Name!!!";
                MessageBox(strMsg);
                ddlProgrammeId.Focus();
                return;


            }
            else if (ddlColorId.Text == " ")
            {
                string strMsg = "Please Select Color Name!!!";
                MessageBox(strMsg);
                ddlColorId.Focus();
                return;


            }

            else if (ddlBrandId.Text == " ")
            {
                string strMsg = "Please Select Brand Name!!!";
                MessageBox(strMsg);
                ddlBrandId.Focus();
                return;


            }




            else
            {

                saveSewingThreadReceiveInfo();
                searchSewingThreadReceiveRecord();


            }
        }






        //#region "Grid View Functionality"
        //protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvEmployeeList.PageIndex = e.NewPageIndex;

        //}

        //protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        //{



        //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
        //    string strContactNo = gvEmployeeList.SelectedRow.Cells[1].Text;
        //    string strIssueDate = gvEmployeeList.SelectedRow.Cells[2].Text;




        //}


        //protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{


        //}

        //protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        //{

        //}


        //protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
        //{



        //    e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        //    e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");



        //}

        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{



        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
        //        e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

        //        e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);

        //    }


        //}


        //protected void gvEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
        //{

        //}




        //#endregion
    }
}