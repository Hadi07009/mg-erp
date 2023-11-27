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
    public partial class HangerPriceEntry : System.Web.UI.Page
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
                getSupplierId();

               
                    

            }

            if (IsPostBack)
            {

                loadSesscion();

            }


          

        }


        #region "Function"


        public void getSupplierId()
        {
            ButtonPriceListBLL objButtonPriceListBLL = new ButtonPriceListBLL();
            ddlSupplierId.DataSource = objButtonPriceListBLL.GetSupplierId();
            ddlSupplierId.DataTextField = "SUPPLIER_NAME";
            ddlSupplierId.DataValueField = "SUPPLIER_ID";
            ddlSupplierId.DataBind();
            if (ddlSupplierId.Items.Count > 0)
            {
                ddlSupplierId.SelectedIndex = 0;
            }
        }

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


            ddlSupplierId.DataSource = objLookUpBLL.getPOType(strHeadOfficeId,strBranchOfficeId);

            ddlSupplierId.DataTextField = "PO_TYPE_NAME";
            ddlSupplierId.DataValueField = "PO_TYPE_ID";

            ddlSupplierId.DataBind();
            if (ddlSupplierId.Items.Count > 0)
            {

                ddlSupplierId.SelectedIndex = 0;
            }          
        }


        

        private void FirstGridViewRow()
        {


          
            DataTable dt = new DataTable();
            DataRow dr = null;
           

            dt.Columns.Add(new DataColumn("STYLE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("HANGER_SIZE", typeof(string)));
            dt.Columns.Add(new DataColumn("PARTICULARS", typeof(string)));
            dt.Columns.Add(new DataColumn("COLOR_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("RATE", typeof(string)));
            dt.Columns.Add(new DataColumn("CURRENCY_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("tran_id", typeof(string)));

            dr = dt.NewRow();
          

            dr["STYLE_ID"] = string.Empty;
            dr["HANGER_SIZE"] = string.Empty;
            dr["PARTICULARS"] = string.Empty;
            dr["COLOR_ID"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["CURRENCY_ID"] = string.Empty;
            dr["tran_id"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvPOEntry.DataSource = dt;
            gvPOEntry.DataBind();
            
            
           

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


                        DropDownList ddlStyleId = (DropDownList)gvPOEntry.Rows[rowIndex].Cells[0].FindControl("ddlStyleId");
                        TextBox txtHangerSize = (TextBox)gvPOEntry.Rows[rowIndex].Cells[1].FindControl("txtHangerSize");
                        TextBox txtParticulars = (TextBox)gvPOEntry.Rows[rowIndex].Cells[2].FindControl("txtParticulars");
                        DropDownList ddlColorId = (DropDownList)gvPOEntry.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                        TextBox txtRate = (TextBox)gvPOEntry.Rows[rowIndex].Cells[4].FindControl("txtRate");
                        DropDownList ddlCurrencyId = (DropDownList)gvPOEntry.Rows[rowIndex].Cells[6].FindControl("ddlCurrencyId");
                        TextBox txtHangerId = (TextBox)gvPOEntry.Rows[rowIndex].Cells[5].FindControl("txtHangerId");


                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["STYLE_ID"] = ddlStyleId.Text;
                        dtCurrentTable.Rows[i - 1]["HANGER_SIZE"] = txtHangerSize.Text;
                        dtCurrentTable.Rows[i - 1]["PARTICULARS"] = txtParticulars.Text;
                        dtCurrentTable.Rows[i - 1]["COLOR_ID"] = ddlColorId.Text;
                        dtCurrentTable.Rows[i - 1]["RATE"] = txtRate.Text;
                       
                        dtCurrentTable.Rows[i - 1]["CURRENCY_ID"] = ddlCurrencyId.Text;
                        dtCurrentTable.Rows[i - 1]["tran_id"] = txtHangerId.Text;

                        rowIndex++;
                       
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvPOEntry.DataSource = dtCurrentTable;
                    gvPOEntry.DataBind();



                    TextBox strtxtHangerId = (TextBox)gvPOEntry.Rows[rowIndex].Cells[5].FindControl("txtHangerId");
                    strtxtHangerId.Focus();

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

                        DropDownList ddlStyleId = (DropDownList)gvPOEntry.Rows[rowIndex].Cells[0].FindControl("ddlStyleId");
                        TextBox txtHangerSize = (TextBox)gvPOEntry.Rows[rowIndex].Cells[1].FindControl("txtHangerSize");
                        TextBox txtParticulars = (TextBox)gvPOEntry.Rows[rowIndex].Cells[2].FindControl("txtParticulars");
                        DropDownList ddlColorId = (DropDownList)gvPOEntry.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                        TextBox txtRate = (TextBox)gvPOEntry.Rows[rowIndex].Cells[4].FindControl("txtRate");
                        DropDownList ddlCurrencyId = (DropDownList)gvPOEntry.Rows[rowIndex].Cells[6].FindControl("ddlCurrencyId");
                        TextBox txtHangerId = (TextBox)gvPOEntry.Rows[rowIndex].Cells[5].FindControl("txtHangerId");




                        ddlStyleId.Text = dt.Rows[i]["STYLE_ID"].ToString();
                        txtHangerSize.Text = dt.Rows[i]["HANGER_SIZE"].ToString();
                        txtParticulars.Text = dt.Rows[i]["PARTICULARS"].ToString();
                        ddlColorId.Text = dt.Rows[i]["COLOR_ID"].ToString();
                        txtRate.Text = dt.Rows[i]["RATE"].ToString();
                        ddlCurrencyId.Text = dt.Rows[i]["CURRENCY_ID"].ToString();
                        txtHangerId.Text = dt.Rows[i]["tran_id"].ToString();

                        rowIndex++;
                    }
                }
            }
        }
        public void saveHangerPriceInfo()
        {

            if (ddlSupplierId.SelectedValue == " ")
            {

                string strMsg = "Please Select Po Type!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;

            }
            
            else
            {
                HangerPriceDTO objHangerPriceDTO = new HangerPriceDTO();
                HangerPriceBLL objHangerPriceBLL = new HangerPriceBLL();

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
                            DropDownList ddlStyleId = (DropDownList)gvPOEntry.Rows[rowIndex].Cells[0].FindControl("ddlStyleId");
                            TextBox txtHangerSize = (TextBox)gvPOEntry.Rows[rowIndex].Cells[1].FindControl("txtHangerSize");
                            TextBox txtParticulars = (TextBox)gvPOEntry.Rows[rowIndex].Cells[2].FindControl("txtParticulars");
                            DropDownList ddlColorId = (DropDownList)gvPOEntry.Rows[rowIndex].Cells[3].FindControl("ddlColorId");
                            TextBox txtRate = (TextBox)gvPOEntry.Rows[rowIndex].Cells[4].FindControl("txtRate");
                            DropDownList ddlCurrencyId = (DropDownList)gvPOEntry.Rows[rowIndex].Cells[6].FindControl("ddlCurrencyId");
                            TextBox txtHangerId = (TextBox)gvPOEntry.Rows[rowIndex].Cells[5].FindControl("txtHangerId");


                            objHangerPriceDTO.HangerId = txtHangerId.Text;
                            objHangerPriceDTO.PriceRate = txtRate.Text;

                            if (ddlColorId.SelectedValue.ToString() != " ")
                            {
                                objHangerPriceDTO.ColorId = ddlColorId.SelectedValue.ToString();

                            }
                            else
                            {

                                objHangerPriceDTO.ColorId = "";

                            }


                            if (ddlSupplierId.SelectedValue.ToString() != " ")
                            {
                                objHangerPriceDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();

                            }
                            else
                            {

                                objHangerPriceDTO.SupplierId = "";

                            }


                            if (ddlCurrencyId.SelectedValue.ToString() != " ")
                            {
                                objHangerPriceDTO.CurrencyId = ddlCurrencyId.SelectedValue.ToString();

                            }
                            else
                            {

                                objHangerPriceDTO.CurrencyId = "";

                            }


                            if (ddlStyleId.SelectedValue.ToString() != " ")
                            {
                                objHangerPriceDTO.StyleId = ddlStyleId.SelectedValue.ToString();

                            }
                            else
                            {

                                objHangerPriceDTO.StyleId = "";

                            }










                            objHangerPriceDTO.UpdateBy = strEmployeeId;
                            objHangerPriceDTO.HeadOfficeId = strHeadOfficeId;
                            objHangerPriceDTO.BranchOfficeId = strBranchOfficeId;

                          
                            strMsg = objHangerPriceBLL.saveHangerPriceInfo(objHangerPriceDTO);
                            lblMsg.Text = strMsg;
                            

                            rowIndex++;

                        }

                        if (strMsg == "INSERTED SUCCESSFULLY" || strMsg == "UPDATED SUCCESSFULLY" )
                        {
                            MessageBox(strMsg);

                        }
                    }
                }
            }

           

        }

        public void LoadHangerPriceRecord()
        {

            HangerPriceDTO objHangerPriceDTO = new HangerPriceDTO();
            HangerPriceBLL objHangerPriceBLL = new HangerPriceBLL();

            DataTable dt = new DataTable();

            
         
            if (ddlSupplierId.SelectedValue.ToString() == "0")
            {
                objHangerPriceDTO.SupplierId = "";
            }
            else
            {
                objHangerPriceDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }


            objHangerPriceDTO.HeadOfficeId = strHeadOfficeId;
            objHangerPriceDTO.BranchOfficeId = strBranchOfficeId;

            dt = objHangerPriceBLL.LoadHangerPriceRecord(objHangerPriceDTO);

            //gvPOEntry.Columns[5].Visible = true;

            if (dt.Rows.Count > 0)
            {
                gvPOEntry.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvPOEntry.DataBind();
               // gvPOEntry.Columns[5].Visible = false;
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
                //gvPOEntry.Columns[5].Visible = false;
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

    

       

        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            AddNewRow();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlSupplierId.Text == "0")
            {
                string strMsg = "Please Select Supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;


            }
           

            else
            {
                saveHangerPriceInfo();
                LoadHangerPriceRecord();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (ddlSupplierId.Text == "")
            {
                string strMsg = "Please Enter Supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;
            }
            else
            {


                LoadHangerPriceRecord();

                
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            HangerPriceDTO objHangerPriceDTO = new HangerPriceDTO();
            HangerPriceBLL objHangerPriceBLL = new HangerPriceBLL();
          
         

            if (ddlSupplierId.SelectedValue.ToString() != "")
            {
                objHangerPriceDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objHangerPriceDTO.SupplierId = "";
            }



            objHangerPriceDTO.UpdateBy = strEmployeeId;
            objHangerPriceDTO.HeadOfficeId = strHeadOfficeId;
            objHangerPriceDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objHangerPriceBLL.deleteHangerRecord(objHangerPriceDTO);
            MessageBox(strMsg);


            LoadHangerPriceRecord();
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
            if (e.Row.RowType == DataControlRowType.DataRow)
                try
                {

                    HangerPriceDTO objHangerPriceDTO = new HangerPriceDTO();
                    HangerPriceBLL objHangerPriceBLL = new HangerPriceBLL();

                    PolyBagBLL objPolyBagBLL = new PolyBagBLL();
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    DataTable dt = new DataTable();
  
                    DropDownList a = (e.Row.FindControl("ddlCurrencyId") as DropDownList);
                    dt = objHangerPriceBLL.getCurrencyId(strHeadOfficeId, strBranchOfficeId);
                    a.DataSource = dt;
                    a.DataBind();
                    a.SelectedValue = dr["CURRENCY_ID"].ToString();

                    DataTable dt1 = new DataTable();
                    DropDownList b = (e.Row.FindControl("ddlStyleId") as DropDownList);
                    dt1 = objHangerPriceBLL.getStyleId(strHeadOfficeId, strBranchOfficeId);
                    b.DataSource = dt1;
                    b.DataBind();
                    b.SelectedValue = dr["STYLE_ID"].ToString();


                    DataTable dt2 = new DataTable();
                    DropDownList c = (e.Row.FindControl("ddlColorId") as DropDownList);
                    dt2 = objHangerPriceBLL.getColorId(strHeadOfficeId, strBranchOfficeId);
                    c.DataSource = dt2;
                    c.DataBind();
                    c.SelectedValue = dr["COLOR_ID"].ToString();





                }
                catch (Exception ex)
                {

                }
        }
        protected void gvPOEntry_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int stor_id = Convert.ToInt32(gvPOEntry.DataKeys[e.RowIndex].Value.ToString());
            string strTarnId = Convert.ToString(stor_id);

            deleteHangerRecordById(strTarnId);
            LoadHangerPriceRecord();
        }
        public void deleteHangerRecordById(string strTarnId)
        {          
            HangerPriceDTO objHangerPriceDTO = new HangerPriceDTO();
            HangerPriceBLL objHangerPriceBLL = new HangerPriceBLL();

            objHangerPriceDTO.HangerId = strTarnId;

            if (ddlSupplierId.SelectedValue.ToString() != "")
            {
                objHangerPriceDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objHangerPriceDTO.SupplierId = "";
            }



            objHangerPriceDTO.UpdateBy = strEmployeeId;
            objHangerPriceDTO.HeadOfficeId = strHeadOfficeId;
            objHangerPriceDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objHangerPriceBLL.deleteHangerRecordById(objHangerPriceDTO);
            MessageBox(strMsg);
        }
        //protected void ddlBuyerId_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["BuyerId"] = ddlBuyerId.SelectedValue;
        //    getDdlByBuyerId();
        //}

        #endregion



       
    }
}