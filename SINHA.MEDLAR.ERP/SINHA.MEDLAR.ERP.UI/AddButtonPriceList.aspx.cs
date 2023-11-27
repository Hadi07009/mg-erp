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
    public partial class AddButtonPriceList : System.Web.UI.Page
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
        private object objButtonPriceListDTO;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;

            }
            if (!IsPostBack)
            {
                FirstGridViewRow();
                loadSesscion();
               
                getOfficeName();
                GetSupplierId();


            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }

            lblMsg.Text = "";
            lblMsgRecord.Text = "";

            gvButtonPriceList.Columns[6].Visible = false;
      

        }
      
        protected void btnSave_Click(object sender, EventArgs e)
        {


            if (ddlSupplierId.Text == " ")
            {

                string strMsg = "Please Select Supplier Name!!!";
                MessageBox(strMsg);

                ddlSupplierId.Focus();
                return;
            }

            else
            {

                saveButtonPriceList();
                loadButtonPriceListRecord();
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
        private void FirstGridViewRow()
        {



            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("PARTICULARS", typeof(string)));
            dt.Columns.Add(new DataColumn("COLOR_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("LINE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("ART_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("MESUREMENT_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("PRICE_RATE", typeof(string)));
          
          
            dt.Columns.Add(new DataColumn("BUTTON_PRICE_LIST_ID", typeof(string)));



            dr = dt.NewRow();
            dr["PARTICULARS"] = string.Empty;
            dr["COLOR_ID"] = string.Empty;
            dr["LINE_ID"] = string.Empty;
            dr["ART_ID"] = string.Empty;
            dr["MESUREMENT_ID"] = string.Empty;
            dr["PRICE_RATE"] = string.Empty;
            dr["BUTTON_PRICE_LIST_ID"] = string.Empty;
           


            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvButtonPriceList.DataSource = dt;
            gvButtonPriceList.DataBind();


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

        public void GetSupplierId()
        {
            ButtonPriceListDTO objButtonPriceListDTO = new ButtonPriceListDTO();
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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

      
     
      
        public void saveButtonPriceList()
        {

           
            ButtonPriceListDTO objButtonPriceListDTO = new ButtonPriceListDTO();
            ButtonPriceListBLL objButtonPriceListBLL = new ButtonPriceListBLL();

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
                        TextBox txtParticulars = (TextBox)gvButtonPriceList.Rows[rowIndex].Cells[0].FindControl("txtParticulars");
                        DropDownList ddlColorId = (DropDownList)gvButtonPriceList.Rows[rowIndex].Cells[1].FindControl("ddlColorId");
                        DropDownList ddlLineId = (DropDownList)gvButtonPriceList.Rows[rowIndex].Cells[2].FindControl("ddlLineId");
                        DropDownList ddlArtId = (DropDownList)gvButtonPriceList.Rows[rowIndex].Cells[3].FindControl("ddlArtId");

                        DropDownList ddlMeasurementId = (DropDownList)gvButtonPriceList.Rows[rowIndex].Cells[4].FindControl("ddlMeasurementId");



                        TextBox txtRateUs = (TextBox)gvButtonPriceList.Rows[rowIndex].Cells[5].FindControl("txtRateUs");
                        TextBox txtButtonPriceListId = (TextBox)gvButtonPriceList.Rows[rowIndex].Cells[6].FindControl("txtButtonPriceListId");



                        //  objSewingDTO.SewingId = txtSewingId.Text;
                        objButtonPriceListDTO.Particulars = txtParticulars.Text;
                        if (ddlMeasurementId.Text != "0")
                        {
                            objButtonPriceListDTO.MUnit = ddlMeasurementId.SelectedValue;
                        }
                        else
                        {
                            objButtonPriceListDTO.ColorId = "0";
                        }


                        if (ddlColorId.Text != "0")
                        {
                            objButtonPriceListDTO.ColorId = ddlColorId.SelectedValue;
                        }
                        else
                        {
                            objButtonPriceListDTO.ColorId = "0";
                        }
                        if (ddlLineId.Text != "0")
                        {
                            objButtonPriceListDTO.LineId = ddlLineId.SelectedValue;
                        }
                        else
                        {
                            objButtonPriceListDTO.LineId = "0";
                        }
                        if (ddlArtId.Text != "0")
                        {
                            objButtonPriceListDTO.ArtId = ddlArtId.SelectedValue;
                        }
                        else
                        {
                            objButtonPriceListDTO.ArtId = "0";
                        }

                      
                        objButtonPriceListDTO.RateUS = txtRateUs.Text;
                        objButtonPriceListDTO.ButtonPriceListId = txtButtonPriceListId.Text;

                        if (ddlSupplierId.Text != "0")
                        {
                            objButtonPriceListDTO.SupplierId = ddlSupplierId.SelectedValue;
                        }
                        else
                        {
                            objButtonPriceListDTO.SupplierId = "0";
                        }

                        objButtonPriceListDTO.UpdateBy = strEmployeeId;

                        objButtonPriceListDTO.HeadOfficeId = strHeadOfficeId;
                        objButtonPriceListDTO.BranchOfficeId = strBranchOfficeId;

                        strMsg = objButtonPriceListBLL.saveButtonPriceList(objButtonPriceListDTO);

                        rowIndex++;

                    }


                }

                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                lblMsg.Text = strMsg;
               

            }

         
        }


        public void deleteButtonPriceListRecord(string strButtonPriceListId)
        {
            ButtonPriceListDTO objButtonPriceListDTO = new ButtonPriceListDTO();
            ButtonPriceListBLL objButtonPriceListBLL = new ButtonPriceListBLL();




            //// objSewingDTO.SewingYear = txtSewingYear.Text;



            objButtonPriceListDTO.ButtonPriceListId = strButtonPriceListId;

            objButtonPriceListDTO.UpdateBy = strEmployeeId;
            objButtonPriceListDTO.HeadOfficeId = strHeadOfficeId;
            objButtonPriceListDTO.BranchOfficeId = strBranchOfficeId;





            string strMsg = objButtonPriceListBLL.deleteButtonPriceListRecord(objButtonPriceListDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }//Delete Sewing Entry



        protected void gvButtonPriceList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                int stor_id = Convert.ToInt32(gvButtonPriceList.DataKeys[e.RowIndex].Values["BUTTON_PRICE_LIST_ID"].ToString());
                string strButtonPriceListId = Convert.ToString(stor_id);

                deleteButtonPriceListRecord(strButtonPriceListId);
                //savePolybagSentupInfo();
                //searchSewingThreadEntry();
                loadButtonPriceListRecord();



            }
            catch
            {
                MessageBox("It haven't any ID to delete");
            }
        }
        public void loadButtonPriceListRecord()
        {
            

            ButtonPriceListDTO objButtonPriceListDTO = new ButtonPriceListDTO();
            ButtonPriceListBLL objButtonPriceListBLL = new ButtonPriceListBLL();
            DataTable dt = new DataTable();





            objButtonPriceListDTO.HeadOfficeId = strHeadOfficeId;
            objButtonPriceListDTO.BranchOfficeId = strBranchOfficeId;
           
            if (ddlSupplierId.SelectedValue.ToString() != " ")
            {
                objButtonPriceListDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objButtonPriceListDTO.SupplierId = "";

            }






            dt = objButtonPriceListBLL.loadButtonPriceListRecord(objButtonPriceListDTO);


            if (dt.Rows.Count > 0)
            {
                gvButtonPriceList.DataSource = dt;
                gvButtonPriceList.DataBind();
                string strMsg = "TOTAL " + gvButtonPriceList.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvButtonPriceList.DataSource = dt;
                gvButtonPriceList.DataBind();
                int totalcolums = gvButtonPriceList.Rows[0].Cells.Count;
                gvButtonPriceList.Rows[0].Cells.Clear();
                gvButtonPriceList.Rows[0].Cells.Add(new TableCell());
                gvButtonPriceList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvButtonPriceList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }


        }
        public void searchButtonPriceList()
        {


            ButtonPriceListDTO objButtonPriceListDTO = new ButtonPriceListDTO();
            ButtonPriceListBLL objButtonPriceListBLL = new ButtonPriceListBLL();
            DataTable dt = new DataTable();



            if (ddlSupplierId.SelectedValue.ToString() != " ")
            {
                objButtonPriceListDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objButtonPriceListDTO.SupplierId = "";

            }

            objButtonPriceListDTO.HeadOfficeId = strHeadOfficeId;
            objButtonPriceListDTO.BranchOfficeId = strBranchOfficeId;
            //  objSewingDTO.ArtNo = txtArtNo.ToString();
            // objSewingDTO.ThreadCount = txtThreadCount.ToString();


            // objEmployeeDTO.LogDate = dtpAttendenceDate.Text;
            //objPolyBagDTO.PolybagLenght=txt


            //if (ddlp.SelectedValue.ToString() != " ")
            //{
            //    objSewingDTO.SewingSupplierId = ddlSupplierId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objSewingDTO.SewingSupplierId = "";

            //}


            //if (ddlProgrammeId.SelectedValue.ToString() != " ")
            //{
            //    objSewingDTO.SewingProgrammeId = ddlProgrammeId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objSewingDTO.SewingProgrammeId = "";

            //}






            dt = objButtonPriceListBLL.searchButtonPriceList(objButtonPriceListDTO);


            if (dt.Rows.Count > 0)
            {
                gvButtonPriceList.DataSource = dt;
                gvButtonPriceList.DataBind();
                string strMsg = "TOTAL " + gvButtonPriceList.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvButtonPriceList.DataSource = dt;
                gvButtonPriceList.DataBind();
                int totalcolums = gvButtonPriceList.Rows[0].Cells.Count;
                gvButtonPriceList.Rows[0].Cells.Clear();
                gvButtonPriceList.Rows[0].Cells.Add(new TableCell());
                gvButtonPriceList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvButtonPriceList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }


        }

        protected void gvButtonPriceList_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
                try
                {

                    ButtonPriceListDTO objButtonPriceListDTO = new ButtonPriceListDTO();
                    ButtonPriceListBLL objButtonPriceListBLL = new ButtonPriceListBLL();
                    PolyBagBLL objPolyBagBLL = new PolyBagBLL();
                    DataRowView dr = e.Row.DataItem as DataRowView;
                    DataTable dt = new DataTable();
                    DropDownList a = (e.Row.FindControl("ddlColorId") as DropDownList);
                    dt = objButtonPriceListBLL.GetColorId();
                    a.DataSource = dt;
                    a.DataBind();
                    a.SelectedValue = dr["COLOR_ID"].ToString();

                    DropDownList b = (e.Row.FindControl("ddlLineId") as DropDownList);
                    dt = objButtonPriceListBLL.GetLineId();
                    b.DataSource = dt;
                    b.DataBind();
                    b.SelectedValue = dr["LINE_ID"].ToString();

                    DropDownList c = (e.Row.FindControl("ddlArtId") as DropDownList);
                    dt = objButtonPriceListBLL.GetArtId();
                    c.DataSource = dt;
                    c.DataBind();
                    c.SelectedValue = dr["ART_ID"].ToString();




                    DropDownList d = (e.Row.FindControl("ddlMesurementId") as DropDownList);


                    DataTable dt1 = new DataTable();
                  
                    dt1 = objButtonPriceListBLL.GetMesurementUnitId();
                    d.DataSource = dt1;
                    d.DataBind();
                    d.SelectedValue = dr["MEASUREMENT_ID"].ToString();



                }
                catch (Exception ex)
                 {

                }
        }
        public void searchSewingThreadEntry()
        {
            //SewingDTO objSewingDTO = new SewingDTO();
            //SewingBLL objSewingBLL = new SewingBLL();

            //PolyBagDTO objPolyBagDTO = new PolyBagDTO();
            //PolyBagBLL objPolyBagBLL = new PolyBagBLL();


            //objPolyBagDTO = objSewingBLL.searchSewingThreadEntry(ddlSupplierId.Text, ddlProgrammeId.Text, strHeadOfficeId, strBranchOfficeId);

            //int rowIndex = 0;

            //if (ViewState["CurrentTable"] != null)
            //{
            //    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            //    DataRow drCurrentRow = null;
            //    if (dtCurrentTable.Rows.Count > 0)
            //    {
            //        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
            //        {



            //            DropDownList ddlPolyBagStyleId = (DropDownList)gvPolyBagSetup.Rows[rowIndex].Cells[0].FindControl("ddlPolyBagStyleId");
            //            TextBox txtPolyBagLength = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[1].FindControl("txtPolyBagLength");
            //            TextBox txtPolyBagWidth = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[2].FindControl("txtPolyBagWidth");
            //            TextBox txtPolyBagHeihgt = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[3].FindControl("txtPolyBagHeihgt");
            //            TextBox txtPolybagId = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[4].FindControl("txtPolybagId");





            //            if (objPolyBagDTO.PolybagStyleId == "0")
            //            {

            //                //nothing to do
            //            }
            //            else
            //            {
            //                ddlPolyBagStyleId.SelectedValue = objPolyBagDTO.PolybagStyleId;
            //            }




            //            objPolyBagDTO.PolybagHeight = txtPolyBagLength.Text;

            //            objPolyBagDTO.PolybagWidth = txtPolyBagWidth.Text;

            //            objPolyBagDTO.PolybagHeight = txtPolyBagHeihgt.Text;
            //            objPolyBagDTO.PolybagId = txtPolybagId.Text;
            //        }
            //    }
            //}

        }//Search Sewing Entry

        public void clearTextBox()
        {
           
            //txtProgrammeName.Text = "";
           


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


                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox txtParticulars = (TextBox)gvButtonPriceList.Rows[rowIndex].Cells[0].FindControl("txtParticulars");
                        DropDownList ddlColorId = (DropDownList)gvButtonPriceList.Rows[rowIndex].Cells[1].FindControl("ddlColorId");
                        DropDownList ddlLineId = (DropDownList)gvButtonPriceList.Rows[rowIndex].Cells[2].FindControl("ddlLineId");
                        DropDownList ddlArtId = (DropDownList)gvButtonPriceList.Rows[rowIndex].Cells[3].FindControl("ddlArtId");


                        DropDownList ddlMeasurementId = (DropDownList)gvButtonPriceList.Rows[rowIndex].Cells[4].FindControl("ddlMeasurementId");

                        TextBox txtRateUs = (TextBox)gvButtonPriceList.Rows[rowIndex].Cells[5].FindControl("txtRateUs");
                        TextBox txtButtonPriceListId = (TextBox)gvButtonPriceList.Rows[rowIndex].Cells[6].FindControl("txtButtonPriceListId");

                        drCurrentRow = dtCurrentTable.NewRow();

                        dtCurrentTable.Rows[i - 1]["PARTICULARS"] = txtParticulars.Text;
                        dtCurrentTable.Rows[i - 1]["COLOR_ID"] = ddlColorId.Text;
                        dtCurrentTable.Rows[i - 1]["LINE_ID"] = ddlLineId.Text;
                        dtCurrentTable.Rows[i - 1]["ART_ID"] = ddlArtId.Text;

                        dtCurrentTable.Rows[i - 1]["MESUREMENT_ID"] = ddlMeasurementId.Text;
                        dtCurrentTable.Rows[i - 1]["PRICE_RATE"] = txtRateUs.Text;

                        dtCurrentTable.Rows[i - 1]["BUTTON_PRICE_LIST_ID"] = txtButtonPriceListId.Text;
                      

                        rowIndex++;
                    }
                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvButtonPriceList.DataSource = dtCurrentTable;
                    gvButtonPriceList.DataBind();




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
                        TextBox txtParticulars = (TextBox)gvButtonPriceList.Rows[rowIndex].Cells[0].FindControl("txtParticulars");
                        DropDownList ddlColorId = (DropDownList)gvButtonPriceList.Rows[rowIndex].Cells[1].FindControl("ddlColorId");
                        DropDownList ddlLineId = (DropDownList)gvButtonPriceList.Rows[rowIndex].Cells[2].FindControl("ddlLineId");
                        DropDownList ddlArtId = (DropDownList)gvButtonPriceList.Rows[rowIndex].Cells[3].FindControl("ddlArtId");

                        DropDownList ddlMeasurementId = (DropDownList)gvButtonPriceList.Rows[rowIndex].Cells[4].FindControl("ddlMeasurementId");

                        TextBox txtRateUs = (TextBox)gvButtonPriceList.Rows[rowIndex].Cells[5].FindControl("txtRateUs");
                        TextBox txtButtonPriceListId = (TextBox)gvButtonPriceList.Rows[rowIndex].Cells[6].FindControl("txtButtonPriceListId");

                        //if (i < dt.Rows.Count - 1)
                        //{

                            txtParticulars.Text = dt.Rows[i]["PARTICULARS"].ToString();
                            ddlColorId.Text = dt.Rows[i]["COLOR_ID"].ToString();
                            ddlLineId.Text = dt.Rows[i]["LINE_ID"].ToString();
                            ddlArtId.Text = dt.Rows[i]["ART_ID"].ToString();
                            ddlMeasurementId.Text = dt.Rows[i]["MESUREMENT_ID"].ToString();
                            txtRateUs.Text = dt.Rows[i]["PRICE_RATE"].ToString();
                            txtButtonPriceListId.Text = dt.Rows[i]["BUTTON_PRICE_LIST_ID"].ToString();
                        //}

                        rowIndex++;
                    }
                }
            }
        }

    

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlSupplierId.Text == " ")
            {

                string strMsg = "Please Select Supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;
            }
            else
            {
                loadButtonPriceListRecord();

            }
            
          
        }


    
       
        protected void gvButtonPriceList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
          
        }
        protected void gvButtonPriceList_RowDataBound(GridViewRowEventArgs e)
        {
           
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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