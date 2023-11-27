using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using System.Web.Security;
using System.Data;
using System.Collections.Specialized;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AddHangerPrice : System.Web.UI.Page
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
        string strID = "";

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
                getOfficeName();
                getSupplierId();
                getCurrencyId();
                getStyleId();
                getColorId();
                LoadHangerRecord();
                lblMsg.Text = "";
             
               
            }

            if (IsPostBack)
            {

                loadSesscion();
            }

            txtSize.Attributes.Add("onkeypress", "return controlEnter('" + txtRate.ClientID + "', event)");
            txtRate.Attributes.Add("onkeypress", "return controlEnter('" + txtParticular.ClientID + "', event)");
        }

        #region "Function"

        //public void getRecord()
        //{


        //    DataTable dt = new DataTable();
        //    DataRow dr = null;

        //    dt.Columns.Add(new DataColumn("SL", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Column1", typeof(string)));//for TextBox value   
        //    dt.Columns.Add(new DataColumn("Column2", typeof(string)));//for TextBox value   
        //    dt.Columns.Add(new DataColumn("Column3", typeof(string)));//for DropDownList selected item   
        //    dt.Columns.Add(new DataColumn("Column4", typeof(string)));//for DropDownList selected item   
        //    dt.Columns.Add(new DataColumn("Column5", typeof(string)));//for DropDownList selected item   

        //    dr = dt.NewRow();
        //    dr["SL"] = 1;
        //    dr["Column1"] = string.Empty;
        //    dr["Column2"] = string.Empty;
        //    dt.Rows.Add(dr);

        //    //Store the DataTable in ViewState for future reference   
        //    ViewState["CurrentTable"] = dt;

        //    //Bind the Gridview   
        //    Gridview1.DataSource = dt;
        //    Gridview1.DataBind();

        //    TextBox box1 = (TextBox)Gridview1.Rows[0].Cells[1].FindControl("txtThreadCount");
        //    box1.Focus();

        //    //After binding the gridview, we can then extract and fill the DropDownList with Data   
        //    DropDownList ddl1 = (DropDownList)Gridview1.Rows[0].Cells[4].FindControl("ddlCurrencyId");
        //    DropDownList ddl2 = (DropDownList)Gridview1.Rows[0].Cells[5].FindControl("ddlBrandId");
        //    DataTable dt3 = new DataTable();
        //    DataTable dt4 = new DataTable();
        //    dt3 = getCurrId();

        //    ddl1.DataSource = dt3;
        //    ddl1.DataBind();

        //    dt4 = getBrand();
        //    ddl2.DataSource = dt4;
        //    ddl2.DataBind();

        //}

        //public void addNewRow()
        //{
        //    if (ViewState["CurrentTable"] != null)
        //    {

        //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        //        DataRow drCurrentRow = null;

        //        if (dtCurrentTable.Rows.Count > 0)
        //        {
        //            drCurrentRow = dtCurrentTable.NewRow();
        //            drCurrentRow["SL"] = dtCurrentTable.Rows.Count + 1;

        //            //add new row to DataTable   
        //            dtCurrentTable.Rows.Add(drCurrentRow);
        //            //Store the current data to ViewState for future reference   

        //            ViewState["CurrentTable"] = dtCurrentTable;


        //            for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
        //            {

        //                //extract the TextBox values   

        //                TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("txtThreadCount");
        //                TextBox box2 = (TextBox)Gridview1.Rows[i].Cells[2].FindControl("txtWhitePrice");
        //                TextBox box3 = (TextBox)Gridview1.Rows[i].Cells[3].FindControl("txtColorPrice");
        //                box1.Focus();


        //                dtCurrentTable.Rows[i]["Column1"] = box1.Text;
        //                dtCurrentTable.Rows[i]["Column2"] = box2.Text;
        //                dtCurrentTable.Rows[i]["Column3"] = box3.Text;
        //                //extract the DropDownList Selected Items   

        //                DropDownList ddl1 = (DropDownList)Gridview1.Rows[i].Cells[4].FindControl("ddlCurrencyId");
        //                DropDownList ddl2 = (DropDownList)Gridview1.Rows[i].Cells[5].FindControl("ddlBrandId");

        //                // Update the DataRow with the DDL Selected Items   

        //                dtCurrentTable.Rows[i]["Column4"] = ddl1.SelectedItem.Text;
        //                dtCurrentTable.Rows[i]["Column5"] = ddl2.SelectedItem.Text;

        //            }

        //            //Rebind the Grid with the current data to reflect changes   
        //            Gridview1.DataSource = dtCurrentTable;
        //            Gridview1.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        Response.Write("ViewState is null");

        //    }


        //    //Set Previous Data on Postbacks   
        //    setPreviousData();

        //}


        //private void setPreviousData()
        //{

        //    int rowIndex = 0;
        //    if (ViewState["CurrentTable"] != null)
        //    {

        //        DataTable dt = (DataTable)ViewState["CurrentTable"];
        //        if (dt.Rows.Count > 0)
        //        {

        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {

        //                TextBox box1 = (TextBox)Gridview1.Rows[i].Cells[1].FindControl("txtThreadCount");
        //                TextBox box2 = (TextBox)Gridview1.Rows[i].Cells[2].FindControl("txtWhitePrice");
        //                TextBox box3 = (TextBox)Gridview1.Rows[i].Cells[3].FindControl("txtColorPrice");



        //                DropDownList ddl1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[4].FindControl("ddlCurrencyId");
        //                DropDownList ddl2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[5].FindControl("ddlBrandId");

        //                //Fill the DropDownList with Data   
        //                DataTable dt3 = new DataTable();
        //                DataTable dt4 = new DataTable();
        //                dt3 = getCurrId();

        //                ddl1.DataSource = dt3;
        //                ddl1.DataBind();

        //                dt4 = getBrand();
        //                ddl2.DataSource = dt4;
        //                ddl2.DataBind();

        //                if (i < dt.Rows.Count - 1)
        //                {

        //                    //Assign the value from DataTable to the TextBox   
        //                    box1.Text = dt.Rows[i]["Column1"].ToString();
        //                    box2.Text = dt.Rows[i]["Column2"].ToString();
        //                    box3.Text = dt.Rows[i]["Column3"].ToString();


        //                    //Set the Previous Selected Items on Each DropDownList  on Postbacks   
        //                    ddl1.ClearSelection();
        //                    ddl1.Items.FindByText(dt.Rows[i]["Column4"].ToString()).Selected = true;

        //                    ddl2.ClearSelection();
        //                    ddl2.Items.FindByText(dt.Rows[i]["Column5"].ToString()).Selected = true;

        //                }

        //                rowIndex++;
        //            }
        //        }
        //    }
        //}


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

        public void getCurrencyId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlCurrencyId.DataSource = objLookUpBLL.getCurrencyId(strHeadOfficeId,strBranchOfficeId);

            ddlCurrencyId.DataTextField = "CURRENCY_NAME";
            ddlCurrencyId.DataValueField = "CURRENCY_ID";

            ddlCurrencyId.DataBind();
            if (ddlCurrencyId.Items.Count > 0)
            {

                ddlCurrencyId.SelectedIndex = 0;
            }

        }

        public void getColorId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlColorId.DataSource = objLookUpBLL.getColorId();

            ddlColorId.DataTextField = "COLOR_NAME";
            ddlColorId.DataValueField = "COLOR_ID";

            ddlColorId.DataBind();
            if (ddlColorId.Items.Count > 0)
            {

                ddlColorId.SelectedIndex = 0;
            }

        }


        public void getStyleId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlStyleId.DataSource = objLookUpBLL.getStyleId();

            ddlStyleId.DataTextField = "STYLE_NAME";
            ddlStyleId.DataValueField = "STYLE_ID";

            ddlStyleId.DataBind();
            if (ddlStyleId.Items.Count > 0)
            {

                ddlStyleId.SelectedIndex = 0;
            }

        }


        public void LoadHangerRecord()
        {



            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.LoadHangerRecord();


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                int totalcolums = gvUnit.Rows[0].Cells.Count;
                gvUnit.Rows[0].Cells.Clear();
                gvUnit.Rows[0].Cells.Add(new TableCell());
                gvUnit.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvUnit.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }




        }

        public void clear()
        {

            txtParticular.Text = "";
            txtSize.Text = "";
            txtRate.Text = "";

        }

        public void saveHangerPrice()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.HangerId = txtHangerId.Text;
            objLookUpDTO.HangerRate = txtRate.Text;
            objLookUpDTO.HangerSize = txtSize.Text;
            objLookUpDTO.ParticularName = txtParticular.Text;

            if (ddlColorId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.ColorId = ddlColorId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.ColorId = "";

            }

            if (ddlStyleId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.StyleId = ddlStyleId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.StyleId = "";

            }


            if (ddlCurrencyId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.CurrencyId = ddlCurrencyId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.CurrencyId = "";

            }


            if (ddlSupplierId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.SupplierId = "";

            }


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;




            string strMsg = objLookUpBLL.saveHangerPrice(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }

        //public void saveSewingThreadPriceList(string strThreadCopunt, string strWhitePrice, string strColorPrice, string strCurrencyId, string strbrandId)
        //{

        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    objLookUpDTO.ThreadCount = strThreadCopunt;
        //    objLookUpDTO.ThreadId = strWhitePrice;
        //    objLookUpDTO.WhitePrice = strWhitePrice;
        //    objLookUpDTO.ColorPrice = strColorPrice;

        //    if (strCurrencyId.Length > 0 )
        //    {
        //        objLookUpDTO.CurrencyId = strCurrencyId;
        //    }
        //    else
        //    {
        //        objLookUpDTO.CurrencyId = "";

        //    }

        //    if (strbrandId.Length > 0)
        //    {
        //        objLookUpDTO.BrandId = strbrandId;
        //    }
        //    else
        //    {
        //        objLookUpDTO.BrandId = "";

        //    }

           
        //    if (ddlSupplierId.SelectedValue.ToString() != " ")
        //    {
        //        objLookUpDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objLookUpDTO.SupplierId = "";

        //    }


        //    objLookUpDTO.UpdateBy = strEmployeeId;
        //    objLookUpDTO.HeadOfficeId = strHeadOfficeId;
        //    objLookUpDTO.BranchOfficeId = strBranchOfficeId;




        //    string strMsg = objLookUpBLL.saveThreadPrice(objLookUpDTO);
        //    lblMsg.Text = strMsg;
        //    //MessageBox(strMsg);
           


        //}



        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            getSupplierId();
            getCurrencyId();
            getStyleId();
            getColorId();
        }

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    int rowIndex = 0;
        //    StringCollection sc = new StringCollection();
        //    if (ViewState["CurrentTable"] != null)
        //    {
        //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        //        if (dtCurrentTable.Rows.Count > 0)
        //        {
        //            for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
        //            {
        //                //extract the TextBox values  
        //                TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txtThreadCount");
        //                TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtWhitePrice");
        //                TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txtColorPrice");

        //                DropDownList ddl1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[3].FindControl("ddlCurrencyId");
        //                DropDownList ddl2 = (DropDownList)Gridview1.Rows[rowIndex].Cells[4].FindControl("ddlBrandId");
        //                //get the values from TextBox and DropDownList  
        //                //then add it to the collections with a comma "," as the delimited values 
        //                //sc.Add(string.Format("{0},{1},{2},{3}, {4},{5}", box1.Text, box2.Text,box3.Text, ddl1.SelectedValue.ToString(), ddl2.SelectedValue.ToString()));

        //                saveSewingThreadPriceList(box1.Text, box2.Text, box3.Text, ddl1.SelectedValue.ToString(), ddl2.SelectedValue.ToString());
        //                rowIndex++;

        //            }
                   
        //        }
        //    }

           
        //}


        #region "Grid View Functionality"
        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
           LoadHangerRecord();
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvUnit, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strThreadCount = gvUnit.SelectedRow.Cells[4].Text;
            string strWhitePrice = gvUnit.SelectedRow.Cells[5].Text;
            string strColorPrice = gvUnit.SelectedRow.Cells[6].Text;


            //string strMsg = "Row Index: " + strRowId + "\\nUnit ID: " + strUnitId + "\\nUnit Name : " + strUnitName + "\\nUnit Name Bangla : " + strUnitNameBng;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
            //txtThreadCount.Text = strThreadCount;
            //txtWhitePrice.Text = strWhitePrice;
            //txtColorPrice.Text = strColorPrice;
        }

        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
            LoadHangerRecord();
        }

        #endregion
        #region "Gridview2 Functionlity"

        protected void Gridview1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    DataTable dt = (DataTable)ViewState["CurrentTable"];
            //    LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
            //    if (lb != null)
            //    {
            //        if (dt.Rows.Count > 1)
            //        {
            //            if (e.Row.RowIndex == dt.Rows.Count - 1)
            //            {
            //                lb.Visible = false;
            //            }
            //        }
            //        else
            //        {
            //            lb.Visible = false;
            //        }
            //    }
            //}
        }




        protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    TextBox box1 = (TextBox)Gridview1.Rows[0].Cells[1].FindControl("txtThreadCount");
            //    TextBox box2 = (TextBox)Gridview1.Rows[0].Cells[2].FindControl("txtWhitePrice");
            //    TextBox box3 = (TextBox)Gridview1.Rows[0].Cells[3].FindControl("txtColorPrice");

            //    box1.Attributes.Add("onkeydown", String.Format("SwitchOnEnter(event,'{0}');", box2.ClientID) );

            //}

        }


        #endregion
       
       

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveHangerPrice();
            LoadHangerRecord();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadHangerRecord();
        }

       
       

    }
}