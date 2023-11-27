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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Web.Services;
using System.Web.Script.Services;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class POEntry : System.Web.UI.Page
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
                FirstGridViewRow();


                getPOType();
                getBuyerId();
                //getStyleId();
                //getColorId();

                txtPONo.Focus();

            }

            if (IsPostBack)
            {

                loadSesscion();

            }


            txtPONo.Attributes.Add("onkeypress", "return controlEnter('" + dtpPODate.ClientID + "', event)");
            dtpPODate.Attributes.Add("onkeypress", "return controlEnter('" + txtRemarks.ClientID + "', event)");


        }


        #region "Function"

        //  ........... AutoCompleteType Fill Textbox ............
        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public static List<string> GetPONo(string PONo)
        //{
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    List<string> allPONo = new List<string>();

        //    string strBuyerId = "";
        //    if (System.Web.HttpContext.Current.Session["BuyerId"].ToString() != " ")
        //    {
        //        strBuyerId = System.Web.HttpContext.Current.Session["BuyerId"].ToString();
        //    }
        //    else
        //    {
        //        strBuyerId = "";
        //    }
        //    allPONo = objLookUpBLL.SearchPONo(PONo, strBuyerId);

        //    return allPONo;
        //}
        

        public void reportMaster()
        {
           




        }


        public void getPOType()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();


            ddlPoTypeId.DataSource = objLookUpBLL.getPOType(strHeadOfficeId,strBranchOfficeId);

            ddlPoTypeId.DataTextField = "PO_TYPE_NAME";
            ddlPoTypeId.DataValueField = "PO_TYPE_ID";

            ddlPoTypeId.DataBind();
            if (ddlPoTypeId.Items.Count > 0)
            {

                ddlPoTypeId.SelectedIndex = 0;
            }          
        }

        
        public void getBuyerId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerId.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId,strBranchOfficeId);

            ddlBuyerId.DataTextField = "BUYER_SHORT_NAME";
            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {

                ddlBuyerId.SelectedIndex = 0;
            }


        }
        

        private void FirstGridViewRow()
        {


          
            DataTable dt = new DataTable();
            DataRow dr = null;
           

            dt.Columns.Add(new DataColumn("PO_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("PO_ISSUE_DATE", typeof(string)));
            dt.Columns.Add(new DataColumn("STYLE_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("COLOR_FULL_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("UNIT_RATE", typeof(string)));
            dt.Columns.Add(new DataColumn("QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("AMOUNT", typeof(string)));
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));


            dr = dt.NewRow();
          

            dr["PO_NO"] = string.Empty;
            dr["PO_ISSUE_DATE"] = string.Empty;
            dr["STYLE_NO"] = string.Empty;
            dr["COLOR_FULL_NAME"] = string.Empty;
            dr["UNIT_RATE"] = string.Empty;
            dr["QUANTITY"] = string.Empty;
            dr["AMOUNT"] = string.Empty;
            dr["TRAN_ID"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvPOEntry.DataSource = dt;
            gvPOEntry.DataBind();
            
            gvPOEntry.Columns[5].Visible = false;
           

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


                        //DropDownList ddlStyleId = (DropDownList)gvPOEntry.Rows[rowIndex].Cells[0].FindControl("ddlStyleId");
                        //DropDownList ddlColorId = (DropDownList)gvPOEntry.Rows[rowIndex].Cells[1].FindControl("ddlColorId");
                        TextBox txtStyleNo = (TextBox)gvPOEntry.Rows[rowIndex].Cells[0].FindControl("txtStyleNo");
                        TextBox txtColorFullName = (TextBox)gvPOEntry.Rows[rowIndex].Cells[1].FindControl("txtColorFullName");
                        TextBox txtUnitRate = (TextBox)gvPOEntry.Rows[rowIndex].Cells[2].FindControl("txtUnitRate");
                        TextBox txtQuantity = (TextBox)gvPOEntry.Rows[rowIndex].Cells[3].FindControl("txtQuantity");
                        TextBox txtAmount = (TextBox)gvPOEntry.Rows[rowIndex].Cells[4].FindControl("txtAmount");
                        TextBox txtTranId = (TextBox)gvPOEntry.Rows[rowIndex].Cells[5].FindControl("txtTranId");



                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["STYLE_NO"] = txtStyleNo.Text;
                        dtCurrentTable.Rows[i - 1]["COLOR_FULL_NAME"] = txtColorFullName.Text;
                        dtCurrentTable.Rows[i - 1]["UNIT_RATE"] = txtUnitRate.Text;
                        dtCurrentTable.Rows[i - 1]["QUANTITY"] = txtQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["AMOUNT"] = txtAmount.Text;
                        dtCurrentTable.Rows[i - 1]["TRAN_ID"] = txtTranId.Text;



                        rowIndex++;
                       
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvPOEntry.DataSource = dtCurrentTable;
                    gvPOEntry.DataBind();

                    for (int i = 0; i <= rowIndex; i++)
                    {
                        TextBox Amount = (TextBox)gvPOEntry.Rows[i].FindControl("txtAmount");
                        Amount.Attributes.Add("readonly", "readonly");
                    }

                    TextBox strStyleNo = (TextBox)gvPOEntry.Rows[rowIndex].Cells[0].FindControl("txtStyleNo");
                    strStyleNo.Focus();
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


                        TextBox txtStyleNo = (TextBox)gvPOEntry.Rows[rowIndex].Cells[0].FindControl("txtStyleNo");
                        TextBox txtColorFullName = (TextBox)gvPOEntry.Rows[rowIndex].Cells[1].FindControl("txtColorFullName");
                        TextBox txtUnitRate = (TextBox)gvPOEntry.Rows[rowIndex].Cells[2].FindControl("txtUnitRate");
                        TextBox txtQuantity = (TextBox)gvPOEntry.Rows[rowIndex].Cells[3].FindControl("txtQuantity");
                        TextBox txtAmount = (TextBox)gvPOEntry.Rows[rowIndex].Cells[4].FindControl("txtAmount");
                        TextBox txtTranId = (TextBox)gvPOEntry.Rows[rowIndex].Cells[5].FindControl("txtTranId");

                        txtStyleNo.Text = dt.Rows[i]["STYLE_NO"].ToString();
                        txtColorFullName.Text = dt.Rows[i]["COLOR_FULL_NAME"].ToString();
                        txtUnitRate.Text = dt.Rows[i]["UNIT_RATE"].ToString();
                        txtQuantity.Text = dt.Rows[i]["QUANTITY"].ToString();
                        txtAmount.Text = dt.Rows[i]["AMOUNT"].ToString();
                        txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();


                        rowIndex++;
                    }
                }
            }
        }
        public void savePoEntryInfo()
        {

            if (txtPONo.Text == "")
            {

                string strMsg = "Please Enter Po No!!!";
                MessageBox(strMsg);
                txtPONo.Focus();
                return;

            }
            else if (ddlPoTypeId.SelectedValue == " ")
            {

                string strMsg = "Please Select Po Type!!!";
                MessageBox(strMsg);
                ddlPoTypeId.Focus();
                return;

            }
            else if (dtpPODate.Text.Length < 6)
            {

                string strMsg = "Please Enter Po Date!!!";
                MessageBox(strMsg);
                dtpPODate.Focus();
                return;

            }
            else if (ddlBuyerId.SelectedValue == " ")
            {

                string strMsg = "Please Select Buyer Name!!!";
                MessageBox(strMsg);
                ddlBuyerId.Focus();
                return;

            }
            else
            {
                POEntryDTO objPOEntryDTO = new POEntryDTO();
                POEntryBLL objPOEntryBLL = new POEntryBLL();

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
                            TextBox txtStyleNo = (TextBox)gvPOEntry.Rows[rowIndex].Cells[0].FindControl("txtStyleNo");
                            TextBox txtColorFullName = (TextBox)gvPOEntry.Rows[rowIndex].Cells[1].FindControl("txtColorFullName");
                            TextBox txtUnitRate = (TextBox)gvPOEntry.Rows[rowIndex].Cells[2].FindControl("txtUnitRate");
                            TextBox txtQuantity = (TextBox)gvPOEntry.Rows[rowIndex].Cells[3].FindControl("txtQuantity");
                            TextBox txtAmount = (TextBox)gvPOEntry.Rows[rowIndex].Cells[4].FindControl("txtAmount");
                            TextBox txtTranId = (TextBox)gvPOEntry.Rows[rowIndex].Cells[5].FindControl("txtTranId");

                           
                            objPOEntryDTO.PONo = txtPONo.Text;

                            if (dtpPODate.Text == "")
                            {
                                objPOEntryDTO.PODate = null;
                            }
                            else
                            {
                                objPOEntryDTO.PODate = dtpPODate.Text;

                            }
                            if (ddlPoTypeId.SelectedValue.ToString() != " ")
                            {
                                objPOEntryDTO.POTypeId = ddlPoTypeId.SelectedValue.ToString();

                            }
                            else
                            {

                                objPOEntryDTO.POTypeId = "";

                            }


                            if (ddlBuyerId.SelectedValue.ToString() != " ")
                            {
                                objPOEntryDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                            }
                            else
                            {

                                objPOEntryDTO.BuyerId = "";

                            }

                            objPOEntryDTO.Remarks = txtRemarks.Text;


                            objPOEntryDTO.StyleNo = txtStyleNo.Text;

                            if (txtAmount.Text == "")
                            {
                                objPOEntryDTO.Amount = null;
                            }
                            else
                            {
                                objPOEntryDTO.Amount = txtAmount.Text;

                            }
                            objPOEntryDTO.ColorFullName = txtColorFullName.Text;

                            objPOEntryDTO.UnitRate = txtUnitRate.Text;
                            objPOEntryDTO.Quantity = txtQuantity.Text;
                            objPOEntryDTO.TranId = txtTranId.Text;


                            objPOEntryDTO.UpdateBy = strEmployeeId;
                            objPOEntryDTO.HeadOfficeId = strHeadOfficeId;
                            objPOEntryDTO.BranchOfficeId = strBranchOfficeId;

                            if (txtStyleNo.Text != "")
                            {
                                strMsg = objPOEntryBLL.savePOEntryInfo(objPOEntryDTO);
                                //MessageBox(strMsg);
                                lblMsg.Text = strMsg;
                            }

                            rowIndex++;

                        }

                        if (strMsg == "INSERTED SUCCESSFULLY" || strMsg == "UPDATED SUCCESSFULLY" || strMsg == "THIS PO AND STYLE ALREADY EXISTS!!!")
                        {
                            MessageBox(strMsg);

                        }
                    }
                }
            }

           

        }

        public void LoadPOEntryInfoSub()
        {

            POEntryDTO objPOEntryDTO = new POEntryDTO();
            POEntryBLL objPOEntryBLL = new POEntryBLL();

            DataTable dt = new DataTable();

            
            objPOEntryDTO.PONo = txtPONo.Text;
            objPOEntryDTO.PODate = dtpPODate.Text;
            if (ddlBuyerId.SelectedValue.ToString() == "")
            {
                //
            }
            else
            {
                objPOEntryDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
            }


            if (ddlPoTypeId.SelectedValue.ToString() == "")
            {
                //
            }
            else
            {
                objPOEntryDTO.POTypeId = ddlPoTypeId.SelectedValue.ToString();
            }


            objPOEntryDTO.HeadOfficeId = strHeadOfficeId;
            objPOEntryDTO.BranchOfficeId = strBranchOfficeId;

            dt = objPOEntryBLL.LoadPOEntryInfoSub(objPOEntryDTO);

            gvPOEntry.Columns[5].Visible = true;

            if (dt.Rows.Count > 0)
            {
                gvPOEntry.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvPOEntry.DataBind();
                gvPOEntry.Columns[5].Visible = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox Amount = (TextBox)gvPOEntry.Rows[i].FindControl("txtAmount");
                    Amount.Attributes.Add("readonly", "readonly");
                }
                int count = ((DataTable)gvPOEntry.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;

            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPOEntry.DataSource = dt;
                gvPOEntry.DataBind();
                gvPOEntry.Columns[5].Visible = false;
                //int totalcolums = gvPOEntry.Rows[0].Cells.Count;
                //gvPOEntry.Rows[0].Cells.Clear();
                //gvPOEntry.Rows[0].Cells.Add(new TableCell());
                //gvPOEntry.Rows[0].Cells[0].ColumnSpan = totalcolums;
                //gvPOEntry.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }


        }

        public void searcPOInfoMain()
        {
            POEntryDTO objPOEntryDTO = new POEntryDTO();
            POEntryBLL objPOEntryBLL = new POEntryBLL();

            string strPONo = "";
            if (txtPONo.Text != "")
            {
                strPONo = txtPONo.Text;
            }
            else
            {
                strPONo = "";
            }

            objPOEntryDTO = objPOEntryBLL.searchPOInfoMain(strPONo, strHeadOfficeId, strBranchOfficeId);


            if (objPOEntryDTO.PODate == "0")
            {
                dtpPODate.Text = "";
            }
            else
            {
                dtpPODate.Text = objPOEntryDTO.PODate;

            }

            if (objPOEntryDTO.POTypeId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlPoTypeId.SelectedValue = objPOEntryDTO.POTypeId;
            }


            if (objPOEntryDTO.BuyerId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlBuyerId.SelectedValue = objPOEntryDTO.BuyerId;
            }


            if (objPOEntryDTO.Remarks == "0")
            {

                txtRemarks.Text = "";
            }
            else
            {
                txtRemarks.Text = objPOEntryDTO.Remarks;
            }

        }

        //protected void getDdlByBuyerId()
        //{
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    int i = gvPOEntry.Rows.Count;
        //    if (i == 1)
        //    {
        //        DropDownList a = (gvPOEntry.Rows[0].FindControl("ddlStyleId") as DropDownList);

        //        DataTable dt1 = new DataTable();
        //        DataRowView dr1 = gvPOEntry.Rows[0].DataItem as DataRowView;

        //        string strBuyerId = "";
        //        if (ddlBuyerId.SelectedValue != " ")
        //        {
        //            strBuyerId = ddlBuyerId.SelectedValue;
        //        }
        //        else
        //        {
        //            strBuyerId = "";
        //        }
        //        dt1 = objLookUpBLL.getStyleId(strBuyerId,strHeadOfficeId,strBranchOfficeId);
        //        a.DataSource = dt1;
        //        a.DataBind();

        //        DropDownList b = (gvPOEntry.Rows[0].FindControl("ddlColorId") as DropDownList);

        //        DataTable dt2 = new DataTable();
        //        DataRowView dr2 = gvPOEntry.Rows[0].DataItem as DataRowView;

        //        dt2 = objLookUpBLL.getColorId(strBuyerId);
        //        b.DataSource = dt2;
        //        b.DataBind();
        //    }
        //}

        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            AddNewRow();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPONo.Text == "")
            {
                string strMsg = "Please Enter PO No!!!";
                MessageBox(strMsg);
                txtPONo.Focus();
                return;


            }
            else if (dtpPODate.Text == "")
            {
                string strMsg = "Please Enter PO Date!!!";
                MessageBox(strMsg);
                dtpPODate.Focus();
                return;


            }
            else if (ddlPoTypeId.Text == " ")
            {
                string strMsg = "Please Select PO Type!!!";
                MessageBox(strMsg);
                ddlPoTypeId.Focus();
                return;


            }
            else if (ddlBuyerId.Text == " ")
            {
                string strMsg = "Please Select Buyer Name!!!";
                MessageBox(strMsg);
                ddlBuyerId.Focus();
                return;


            }
            //else if (txtRemarks.Text == "")
            //{
            //    string strMsg = "Please Enter Remarks!!!";
            //    MessageBox(strMsg);
            //    txtRemarks.Focus();
            //    return;


            //}

            else
            {
                savePoEntryInfo();
                LoadPOEntryInfoSub();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtPONo.Text == "")
            {
                string strMsg = "Please Enter PO No!!!";
                MessageBox(strMsg);
                txtPONo.Focus();
                return;
            }
            else
            {
                POEntryDTO objPOEntryDTO = new POEntryDTO();
                POEntryBLL objPOEntryBLL = new POEntryBLL();


                //objPOEntryDTO = objPOEntryBLL.chkPOExists(txtPONo.Text, strHeadOfficeId,strBranchOfficeId);


                //if (objPOEntryDTO.PODate != "")
                //{

                //    dtpPODate.Text = objPOEntryDTO.PODate;
                //}
                //else
                //{

                    searcPOInfoMain();
                    LoadPOEntryInfoSub();

                //}
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            POEntryDTO objPOEntryDTO = new POEntryDTO();
            POEntryBLL objPOEntryBLL = new POEntryBLL();
          
            objPOEntryDTO.PONo = txtPONo.Text;
            objPOEntryDTO.PODate = dtpPODate.Text;

            if (ddlBuyerId.SelectedValue.ToString() != "")
            {
                objPOEntryDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
            }
            else
            {
                objPOEntryDTO.BuyerId = "";
            }



            objPOEntryDTO.UpdateBy = strEmployeeId;
            objPOEntryDTO.HeadOfficeId = strHeadOfficeId;
            objPOEntryDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objPOEntryBLL.deletePoEntryRecord(objPOEntryDTO);
            MessageBox(strMsg);

            searcPOInfoMain();
            LoadPOEntryInfoSub();
        }

        #region "Grid View Functionality"
        protected void gvPOEntry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPOEntry.PageIndex = e.NewPageIndex;

        }

        protected void gvPOEntry_OnSelectedIndexChanged(object sender, EventArgs e)
        {



        }

        protected void gvPOEntry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void gvPOEntry_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

        }
        protected void gvPOEntry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int stor_id = Convert.ToInt32(gvPOEntry.DataKeys[e.RowIndex].Value.ToString());
            string strTarnId = Convert.ToString(stor_id);

            deletePoEntrySubRecord(strTarnId);
           searcPOInfoMain();
            LoadPOEntryInfoSub();
        }
        public void deletePoEntrySubRecord(string strTarnId)
        {          
            POEntryDTO objPOEntryDTO = new POEntryDTO();
            POEntryBLL objPOEntryBLL = new POEntryBLL();

            objPOEntryDTO.TranId = strTarnId;
            objPOEntryDTO.PONo = txtPONo.Text;
            objPOEntryDTO.PODate = dtpPODate.Text;

            if (ddlBuyerId.SelectedValue.ToString() != "")
            {
                objPOEntryDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
            }
            else
            {
                objPOEntryDTO.BuyerId = "";
            }



            objPOEntryDTO.UpdateBy = strEmployeeId;
            objPOEntryDTO.HeadOfficeId = strHeadOfficeId;
            objPOEntryDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objPOEntryBLL.deletePoEntrySubRecord(objPOEntryDTO);
            MessageBox(strMsg);
        }
        //protected void ddlBuyerId_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["BuyerId"] = ddlBuyerId.SelectedValue;
        //    getDdlByBuyerId();
        //}

        #endregion

        protected void txtStyleNo_TextChanged(object sender, EventArgs e)
        {
            POEntryDTO objPOEntryDTO = new POEntryDTO();
            POEntryBLL objPOEntryBLL = new POEntryBLL();

            TextBox tb = (TextBox)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;

            TextBox txtStyleNo = (TextBox)gvPOEntry.Rows[rowindex].FindControl("txtStyleNo");

            string strStyleNo = txtStyleNo.Text;

            if (ddlBuyerId.SelectedValue == " ")
            {

                string strMsg = "Please Select Buyer Name!!!";
                MessageBox(strMsg);
                ddlBuyerId.Focus();
                return;

            }
            else
            {
                string strBuyerId = ddlBuyerId.SelectedValue;

                objPOEntryDTO = objPOEntryBLL.chkStyleNo(strStyleNo, strBuyerId, strHeadOfficeId, strBranchOfficeId);

                if (objPOEntryDTO.ChkYN == "Y")
                {
                    txtStyleNo.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    txtStyleNo.BackColor = System.Drawing.Color.Red;
                }
                TextBox txtColorFullName = (TextBox)gvPOEntry.Rows[rowindex].FindControl("txtColorFullName");
                txtColorFullName.Focus();
            }
                    

        }
        protected void txtColorFullName_TextChanged(object sender, EventArgs e)
        {

            POEntryDTO objPOEntryDTO = new POEntryDTO();
            POEntryBLL objPOEntryBLL = new POEntryBLL();


            TextBox tb = (TextBox)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;

            TextBox txtColorFullName = (TextBox)gvPOEntry.Rows[rowindex].FindControl("txtColorFullName");

            string strColorFullName = txtColorFullName.Text;

            if(ddlBuyerId.SelectedValue ==" ")
            {
              
                string strMsg = "Please Select Buyer Name!!!";
                MessageBox(strMsg);
                ddlBuyerId.Focus();
                return;
               
            }
            else
            {
                string strBuyerId=ddlBuyerId.SelectedValue;

                objPOEntryDTO = objPOEntryBLL.chkColorName(strColorFullName, strBuyerId, strHeadOfficeId, strBranchOfficeId);

                if (objPOEntryDTO.ChkYN == "Y")
                {
                    txtColorFullName.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    txtColorFullName.BackColor = System.Drawing.Color.Red;
                }
                TextBox txtUnitRate = (TextBox)gvPOEntry.Rows[rowindex].FindControl("txtUnitRate");
                txtUnitRate.Focus();
            }

           
           
        }

       
    }
}