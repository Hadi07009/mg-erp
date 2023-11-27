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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AddCartoonPriceList : System.Web.UI.Page
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
        string strUpdateDate = "";

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
                FirstGridViewRow();
                getOfficeName();
                getSupplierName();
              
            }

            if (IsPostBack)
            {

                loadSesscion();
                
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
        #region "Function"
        //GridViewShow
        private void FirstGridViewRow()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("CARTOON_PLY_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("CARTOON_LENGTH", typeof(string)));
            dt.Columns.Add(new DataColumn("CARTOON_WIDTH", typeof(string)));
            dt.Columns.Add(new DataColumn("CARTOON_HEIGHT", typeof(string)));
            dt.Columns.Add(new DataColumn("CARTOON_PERTICULAR", typeof(string)));
            dt.Columns.Add(new DataColumn("MEASUREMENT_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("CARTOON_RATE", typeof(string)));
            dt.Columns.Add(new DataColumn("CARTOON_ID", typeof(string)));


            dr = dt.NewRow();

            dr["CARTOON_PLY_ID"] = string.Empty;
            dr["CARTOON_LENGTH"] = string.Empty;
            dr["CARTOON_WIDTH"] = string.Empty;
            dr["CARTOON_HEIGHT"] = string.Empty;
            dr["CARTOON_PERTICULAR"] = string.Empty;
            dr["MEASUREMENT_ID"] = string.Empty;
            dr["CARTOON_RATE"] = string.Empty;
            dr["CARTOON_ID"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;
            gvCartoonPriceList.DataSource = dt;
            gvCartoonPriceList.DataBind();

            gvCartoonPriceList.Columns[7].Visible = false;
           
        }
        //AddRow start
        private void AddNewRow()
        {

            int rowIndex = 0;
           
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                
                if (dtCurrentTable.Rows.Count > 0)
                {
                    

                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox txtPlyId = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[0].FindControl("txtPlyId");
                        TextBox txtLength = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[1].FindControl("txtLength");
                        TextBox txtWidth = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[2].FindControl("txtWidth");
                        TextBox txtHeight = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[3].FindControl("txtHeight");
                        TextBox txtPerticular = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[4].FindControl("txtPerticular");
                        DropDownList ddlMesurementId = (DropDownList)gvCartoonPriceList.Rows[rowIndex].Cells[5].FindControl("ddlMesurementId");
                        TextBox txtRateId = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[6].FindControl("txtRateId");
                        TextBox txtCartoonPriceId = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[7].FindControl("txtCartoonPriceId");

                        drCurrentRow = dtCurrentTable.NewRow();

                        dtCurrentTable.Rows[i]["CARTOON_PLY_ID"] = txtPlyId.Text;
                        dtCurrentTable.Rows[i]["CARTOON_LENGTH"] = txtLength.Text;
                        dtCurrentTable.Rows[i]["CARTOON_WIDTH"] = txtWidth.Text;
                        dtCurrentTable.Rows[i]["CARTOON_HEIGHT"] = txtHeight.Text;
                        dtCurrentTable.Rows[i]["CARTOON_PERTICULAR"] = txtPerticular.Text;
                        dtCurrentTable.Rows[i]["MEASUREMENT_ID"] = ddlMesurementId.Text;
                        dtCurrentTable.Rows[i]["CARTOON_RATE"] = txtRateId.Text;
                        dtCurrentTable.Rows[i]["CARTOON_ID"] = txtCartoonPriceId.Text;


                        rowIndex++;
                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvCartoonPriceList.DataSource = dtCurrentTable;
                    gvCartoonPriceList.DataBind();

                    for (int i = 0; i <= rowIndex; i++)
                    {
                        TextBox Amount = (TextBox)gvCartoonPriceList.Rows[i].FindControl("txtPlyId");
                        Amount.Attributes.Add("readonly", "readonly");
                    }

                    TextBox strtxtPlyId = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[0].FindControl("txtPlyId");
                    strtxtPlyId.Focus();




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
                        TextBox txtPlyId = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[0].FindControl("txtPlyId");
                        TextBox txtLength = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[1].FindControl("txtLength");
                        TextBox txtWidth = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[2].FindControl("txtWidth");
                        TextBox txtHeight = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[3].FindControl("txtHeight");
                        TextBox txtPerticular = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[4].FindControl("txtPerticular");
                        DropDownList ddlMesurementId = (DropDownList)gvCartoonPriceList.Rows[rowIndex].Cells[5].FindControl("ddlMesurementId");
                        TextBox txtRateId = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[6].FindControl("txtRateId");
                        TextBox txtCartoonPriceId = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[7].FindControl("txtCartoonPriceId");

                        
                            txtPlyId.Text = dt.Rows[i]["CARTOON_PLY_ID"].ToString();
                            txtLength.Text = dt.Rows[i]["CARTOON_LENGTH"].ToString();
                            txtWidth.Text = dt.Rows[i]["CARTOON_WIDTH"].ToString();
                            txtHeight.Text = dt.Rows[i]["CARTOON_HEIGHT"].ToString();
                            txtPerticular.Text = dt.Rows[i]["CARTOON_PERTICULAR"].ToString();
                            ddlMesurementId.Text = dt.Rows[i]["MEASUREMENT_ID"].ToString();
                            txtRateId.Text = dt.Rows[i]["CARTOON_RATE"].ToString();
                            txtCartoonPriceId.Text = dt.Rows[i]["CARTOON_ID"].ToString();
                        

                        rowIndex++;
                    }
                }
            }
        }
        //AddRow end
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
        //DropDown
        public void getSupplierName()
        {
            ButtonPriceListBLL objButtonPriceListBLL = new ButtonPriceListBLL();
            ddlSupplierName.DataSource = objButtonPriceListBLL.GetSupplierId();
            ddlSupplierName.DataTextField = "SUPPLIER_NAME";
            ddlSupplierName.DataValueField = "SUPPLIER_ID";
            ddlSupplierName.DataBind();
            if (ddlSupplierName.Items.Count > 0)
            {
                ddlSupplierName.SelectedIndex = 0;
            }
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
        //MassageBox
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        //save CartoonPriceList
        public void saveCartoonPriceList()
        {
            CartoonPriceListDTO objCartoonPriceListDTO = new CartoonPriceListDTO();
            CartoonPriceListBLL objCartoonPriceListBLL = new CartoonPriceListBLL();
            
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
                        TextBox txtPlyId = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[0].FindControl("txtPlyId");
                        TextBox txtLength = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[1].FindControl("txtLength");
                        TextBox txtWidth = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[2].FindControl("txtWidth");
                        TextBox txtHeight = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[3].FindControl("txtHeight");
                        TextBox txtPerticular = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[4].FindControl("txtPerticular");
                        DropDownList ddlMesurementId = (DropDownList)gvCartoonPriceList.Rows[rowIndex].Cells[5].FindControl("ddlMesurementId");
                        TextBox txtRateId = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[6].FindControl("txtRateId");
                        TextBox txtCartoonPriceId = (TextBox)gvCartoonPriceList.Rows[rowIndex].Cells[7].FindControl("txtCartoonPriceId");


                        if (ddlSupplierName.Text != "0")
                        {
                            objCartoonPriceListDTO.SupplierId = ddlSupplierName.SelectedValue;
                        }
                        else
                        {
                            objCartoonPriceListDTO.SupplierId = "0";
                        }
                        objCartoonPriceListDTO.CartoonPriceId = txtCartoonPriceId.Text;

                        objCartoonPriceListDTO.PlyId = txtPlyId.Text;
                        objCartoonPriceListDTO.Length = txtLength.Text;
                        objCartoonPriceListDTO.Width = txtWidth.Text;
                        objCartoonPriceListDTO.Height = txtHeight.Text;
                        objCartoonPriceListDTO.Perticulars = txtPerticular.Text;

                        if (ddlMesurementId.Text != "0")
                        {
                            objCartoonPriceListDTO.MesurementUnit = ddlMesurementId.SelectedValue;
                        }
                        else
                        {
                            objCartoonPriceListDTO.MesurementUnit = "0";
                        }
                        objCartoonPriceListDTO.RateId = txtRateId.Text;
                        objCartoonPriceListDTO.UpdateBy = strEmployeeId;
                        objCartoonPriceListDTO.HeadOfficeId = strHeadOfficeId;
                        objCartoonPriceListDTO.BranchOfficeId = strBranchOfficeId;

                        strMsg = objCartoonPriceListBLL.saveCartoonPriceList(objCartoonPriceListDTO);
                        rowIndex++;
                    }

                }
                MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }

           

        }
        //Load Cartoon Price Record All
        //public void loadCartoonPriceList()
        //{
        //    CartoonPriceListDTO objCartoonPriceListDTO = new CartoonPriceListDTO();
        //    CartoonPriceListBLL objCartoonPriceListBLL = new CartoonPriceListBLL();
        //    DataTable dt = new DataTable();
        //    dt = objCartoonPriceListBLL.loadCartoonPriceList(strHeadOfficeId, strBranchOfficeId);
        //    if (dt.Rows.Count > 0)
        //    {
        //        gvViewRecord.DataSource = dt;
        //        gvViewRecord.DataBind();
        //        string strMsg = "TOTAL " + gvViewRecord.Rows.Count + " RECORD FOUND";
        //        //MessageBox(strMsg);
        //        lblMsg.Text = strMsg;
        //    }
        //    else
        //    {
        //        dt.Rows.Add(dt.NewRow());
        //        gvViewRecord.DataSource = dt;
        //        gvViewRecord.DataBind();
        //        int totalcolums = gvViewRecord.Rows[0].Cells.Count;
        //        gvViewRecord.Rows[0].Cells.Clear();
        //        gvViewRecord.Rows[0].Cells.Add(new TableCell());
        //        gvViewRecord.Rows[0].Cells[0].ColumnSpan = totalcolums;
        //        gvViewRecord.Rows[0].Cells[0].Text = "NO RECORD FOUND";
        //        string strMsg = "NO RECORD FOUND!!!";
        //        MessageBox(strMsg);
        //        lblMsg.Text = strMsg;
        //    }
        //}
        //Search cartoon price record 
        public void SearchCartoonPriceRecord()
        {
            CartoonPriceListDTO objCartoonPriceListDTO = new CartoonPriceListDTO();
            CartoonPriceListBLL objCartoonPriceListBLL = new CartoonPriceListBLL();
            if (ddlSupplierName.Text != "0")
            {
                objCartoonPriceListDTO.SupplierId = ddlSupplierName.SelectedValue;
                
            }
            objCartoonPriceListDTO.HeadOfficeId = strHeadOfficeId;
            objCartoonPriceListDTO.BranchOfficeId = strBranchOfficeId;
            DataTable dt = new DataTable();
            dt = objCartoonPriceListBLL.SearchCartoonPriceRecord(objCartoonPriceListDTO);

            if (dt.Rows.Count > 0)
            {
                gvCartoonPriceList.DataSource = dt;
                gvCartoonPriceList.DataBind();
               
                int count = ((DataTable)gvCartoonPriceList.DataSource).Rows.Count;
                string strMsg = "TOTAL " + gvCartoonPriceList.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvCartoonPriceList.DataSource = dt;
                gvCartoonPriceList.DataBind();
                int totalcolums = gvCartoonPriceList.Rows[0].Cells.Count;
                gvCartoonPriceList.Rows[0].Cells.Clear();
                gvCartoonPriceList.Rows[0].Cells.Add(new TableCell());
                gvCartoonPriceList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvCartoonPriceList.Rows[0].Cells[0].Text = "NO RECORD FOUND";
                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
        }
        #endregion        
        //AddRow Button

        //save button
        protected void btnSave_Click(object sender, EventArgs e)
        {
            saveCartoonPriceList();
            //SearchCartoonPriceRecord();
        }
        //Show button
        protected void btnShow_Click(object sender, EventArgs e)
        {
          //  loadCartoonPriceList();
        }
        //search button
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (ddlSupplierName.Text == "0")
            {
                string strMsg = "Please Select Supplier Name!!!";
                MessageBox(strMsg);

                return;
            }
            else
            {
                SearchCartoonPriceRecord();
            }
        }

        //==========All GridView Event================
              
        protected void gvCartoonPriceList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvCartoonPriceList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvCartoonPriceList_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //    try
            //    {
                    CartoonPriceListBLL objCartoonPriceListBLL = new CartoonPriceListBLL();

                    //DataRowView dr = e.Row.DataItem as DataRowView;
                    //DataTable dt = new DataTable();

                    //DropDownList a = (e.Row.FindControl("ddlMesurementId") as DropDownList);

                    //dt = objCartoonPriceListBLL.GetMesurementUnitId();
                    //a.DataSource = dt;
                    //a.DataBind();
                    //a.SelectedValue = dr["MEASURE_ID"].ToString();





                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {

                        LookUpBLL objLookUpBLL = new LookUpBLL();

                        DropDownList a = (e.Row.FindControl("ddlMesurementId") as DropDownList);


                        DataTable dt1 = new DataTable();
                        DataRowView dr = e.Row.DataItem as DataRowView;


                        dt1 = objCartoonPriceListBLL.GetMesurementUnitId();
                        a.DataSource = dt1;
                        a.DataBind();
                        a.SelectedValue = dr["MEASUREMENT_ID"].ToString();



                    }











               // }


                //catch (Exception ex)
                //{

                //}
            
            
        }
        
        //Delete data from Grid by ThreadId strat
        protected void gvCartoonPriceList_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                int stor_id = Convert.ToInt32(gvCartoonPriceList.DataKeys[e.RowIndex].Value.ToString());
                string strCartoonId = Convert.ToString(stor_id);

                deleteCartoonPriceRecord(strCartoonId);
                SearchCartoonPriceRecord();


            }
            catch
            {
                MessageBox("It haven't any ID to delete");
            }
        }
        public void deleteCartoonPriceRecord(string strCartoonId)
        {
            CartoonPriceListDTO objCartoonPriceListDTO = new CartoonPriceListDTO();
            CartoonPriceListBLL objCartoonPriceListBLL = new CartoonPriceListBLL();
            objCartoonPriceListDTO.CartoonPriceId = strCartoonId;


            objCartoonPriceListDTO.UpdateBy = strEmployeeId;
            objCartoonPriceListDTO.HeadOfficeId = strHeadOfficeId;
            objCartoonPriceListDTO.BranchOfficeId = strBranchOfficeId;
            string strMsg = objCartoonPriceListBLL.deleteCartoonPriceRecord(objCartoonPriceListDTO);
            MessageBox(strMsg);
        }
        //Delete data from Grid by ThreadId end
        protected void gvCartoonPriceList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }
    }

    }
