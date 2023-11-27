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
    public partial class PolybagSetup : System.Web.UI.Page
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
              
                
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }


            gvPolyBagSetup.Columns[4].Visible = false;
            lblMsg.Text = "";
            lblMsgRecord.Text = "";

        }
      
        protected void btnSave_Click(object sender, EventArgs e)
        {

           
            //if (txtProgrammeName.Text == string.Empty)
            //{

            //    string strMsg = "Please Enter Fabric Name!!!";
            //    MessageBox(strMsg);

            //    txtProgrammeName.Focus();
            //    return ;
            //}

            //else
            //{

            savePolybagSentupInfo();
           // loadPolyBagRecord();


            //}

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

            dt.Columns.Add(new DataColumn("STYLE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("POLY_BAG_LENGHT", typeof(string)));
            dt.Columns.Add(new DataColumn("POLY_BAG_WIDTH", typeof(string)));
            dt.Columns.Add(new DataColumn("POLY_BAG_HEIGHT", typeof(string)));
          
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));



            dr = dt.NewRow();

            dr["STYLE_ID"] = string.Empty;
            dr["POLY_BAG_LENGHT"] = string.Empty;
            dr["POLY_BAG_WIDTH"] = string.Empty;
            dr["POLY_BAG_HEIGHT"] = string.Empty;
            dr["TRAN_ID"] = string.Empty;


            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvPolyBagSetup.DataSource = dt;
             gvPolyBagSetup.DataBind();


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

       
   
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

      
     
      
        public void savePolybagSentupInfo()
        {

           
            PolyBagDTO objPolyBagDTO = new PolyBagDTO();
            PolyBagBLL objPolyBagBLL = new PolyBagBLL();

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
                        DropDownList ddlStyleId = (DropDownList)gvPolyBagSetup.Rows[rowIndex].Cells[0].FindControl("ddlStyleId");
                        TextBox txtPolyBagLength = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[1].FindControl("txtPolyBagLength");
                        TextBox txtPolyBagWidth = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[2].FindControl("txtPolyBagWidth");
                        TextBox txtPolyBagHeihgt = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[3].FindControl("txtPolyBagHeihgt");
                        TextBox txtPolybagId = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[4].FindControl("txtPolybagId");


                        //  objSewingDTO.SewingId = txtSewingId.Text;

                        if (ddlStyleId.Text != "0")
                        {
                            objPolyBagDTO.StyleId = ddlStyleId.SelectedValue;
                        }
                        else
                        {
                            objPolyBagDTO.StyleId = "0";
                        }
                       

                        objPolyBagDTO.PolybagLenght = txtPolyBagLength.Text;

                        objPolyBagDTO.PolybagWidth =txtPolyBagWidth.Text;

                        objPolyBagDTO.PolybagHeight = txtPolyBagHeihgt.Text;
                        objPolyBagDTO.PolybagId = txtPolybagId.Text;

                        objPolyBagDTO.UpdateBy = strEmployeeId;

                        objPolyBagDTO.HeadOfficeId = strHeadOfficeId;
                        objPolyBagDTO.BranchOfficeId = strBranchOfficeId;

                        strMsg = objPolyBagBLL.savePolybagSentupInfo(objPolyBagDTO);

                        rowIndex++;

                    }


                }

                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                lblMsg.Text = strMsg;
               

            }

            loadPolyBagRecord();
        }


        public void deletePolybagSetupEntry(string strPolyBagId)
        {
            SewingDTO objSewingDTO = new SewingDTO();
            SewingBLL objSewingBLL = new SewingBLL();

            PolyBagDTO objPolyBagDTO = new PolyBagDTO();
            PolyBagBLL objPolyBagBLL = new PolyBagBLL();


            //// objSewingDTO.SewingYear = txtSewingYear.Text;



            objPolyBagDTO.PolybagId = strPolyBagId;

            objPolyBagDTO.UpdateBy = strEmployeeId;
            objPolyBagDTO.HeadOfficeId = strHeadOfficeId;
            objPolyBagDTO.BranchOfficeId = strBranchOfficeId;





            string strMsg = objPolyBagBLL.deletePolybagSetupEntry(objPolyBagDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }//Delete Sewing Entry



        protected void gvPolyBagSetup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                int stor_id = Convert.ToInt32(gvPolyBagSetup.DataKeys[e.RowIndex].Values["POLYBAG_ID"].ToString());
                string strPolyBagId = Convert.ToString(stor_id);

                deletePolybagSetupEntry(strPolyBagId);
                loadPolyBagRecord();



            }
            catch
            {
                MessageBox("It haven't any ID to delete");
            }
        }
        public void loadPolyBagRecord()
        {
            

            PolyBagDTO objPolyBagDTO = new PolyBagDTO();
            PolyBagBLL objPolyBagBLL = new PolyBagBLL();

           
            DataTable dt = new DataTable();





            objPolyBagDTO.HeadOfficeId = strHeadOfficeId;
            objPolyBagDTO.BranchOfficeId = strBranchOfficeId;
     





          
            dt = objPolyBagBLL.loadPolyBagRecord(objPolyBagDTO);


            if (dt.Rows.Count > 0)
            {
                gvPolyBagSetup.DataSource = dt;
                gvPolyBagSetup.DataBind();

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{

                //    TextBox txtPolybagId = (TextBox)gvPolyBagSetup.Rows[i].FindControl("txtPolybagId");
                //    txtPolybagId.Attributes.Add("readonly", "readonly");
                //}

                string strMsg = "TOTAL " + gvPolyBagSetup.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPolyBagSetup.DataSource = dt;
                gvPolyBagSetup.DataBind();
                int totalcolums = gvPolyBagSetup.Rows[0].Cells.Count;
                gvPolyBagSetup.Rows[0].Cells.Clear();
                gvPolyBagSetup.Rows[0].Cells.Add(new TableCell());
                gvPolyBagSetup.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPolyBagSetup.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }


        }

        protected void gvPolyBagSetup_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {



            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                PolyBagBLL objPolyBagBLL = new PolyBagBLL();

                DropDownList a = (e.Row.FindControl("ddlStyleId") as DropDownList);


                DataTable dt1 = new DataTable();
                DataRowView dr = e.Row.DataItem as DataRowView;


                dt1 = objPolyBagBLL.GetPolyBagStyleId();
                a.DataSource = dt1;
                a.DataBind();
                a.SelectedValue = dr["STYLE_ID"].ToString();



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
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {



                        DropDownList ddlStyleId = (DropDownList)gvPolyBagSetup.Rows[rowIndex].Cells[0].FindControl("ddlStyleId");
                        TextBox txtPolyBagLength = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[1].FindControl("txtPolyBagLength");
                        TextBox txtPolyBagWidth = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[2].FindControl("txtPolyBagWidth");
                        TextBox txtPolyBagHeihgt = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[3].FindControl("txtPolyBagHeihgt");
                        TextBox txtPolybagId = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[4].FindControl("txtPolybagId");






                        drCurrentRow = dtCurrentTable.NewRow();
                       
                        dtCurrentTable.Rows[i - 1]["STYLE_ID"] = ddlStyleId.Text;
                        dtCurrentTable.Rows[i - 1]["POLY_BAG_LENGHT"] = txtPolyBagLength.Text;
                        dtCurrentTable.Rows[i - 1]["POLY_BAG_WIDTH"] = txtPolyBagWidth.Text;
                        dtCurrentTable.Rows[i - 1]["POLY_BAG_HEIGHT"] = txtPolyBagHeihgt.Text;
                        dtCurrentTable.Rows[i - 1]["TRAN_ID"] = txtPolybagId.Text;




                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvPolyBagSetup.DataSource = dtCurrentTable;
                    gvPolyBagSetup.DataBind();
                    //for (int i = 0; i <= rowIndex; i++)
                    //{
                    //    TextBox Amount = (TextBox)gvShipmentInfo.Rows[i].FindControl("txtAmount");
                    //    Amount.Attributes.Add("readonly", "readonly");
                    //}

                    //TextBox strtxtPONo = (TextBox)gvShipmentInfo.Rows[rowIndex].Cells[0].FindControl("txtPONo");
                    //strtxtPONo.Focus();
                    
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

                        DropDownList ddlStyleId = (DropDownList)gvPolyBagSetup.Rows[rowIndex].Cells[0].FindControl("ddlStyleId");
                        TextBox txtPolyBagLength = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[1].FindControl("txtPolyBagLength");
                        TextBox txtPolyBagWidth = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[2].FindControl("txtPolyBagWidth");
                        TextBox txtPolyBagHeihgt = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[3].FindControl("txtPolyBagHeihgt");
                        TextBox txtPolybagId = (TextBox)gvPolyBagSetup.Rows[rowIndex].Cells[4].FindControl("txtPolybagId");



                        ddlStyleId.Text = dt.Rows[i]["STYLE_ID"].ToString();
                        txtPolyBagLength.Text = dt.Rows[i]["POLY_BAG_LENGHT"].ToString();
                        txtPolyBagWidth.Text = dt.Rows[i]["POLY_BAG_WIDTH"].ToString();
                        txtPolyBagHeihgt.Text = dt.Rows[i]["POLY_BAG_HEIGHT"].ToString();
                        txtPolybagId.Text = dt.Rows[i]["TRAN_ID"].ToString();



                        rowIndex++;
                    }
                }
            }
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //if (txtThreadId.Text == string.Empty)
            //{

            //    string strMsg = "Please Enter Programme ID!!!";
            //    MessageBox(strMsg);
            //    txtThreadId.Focus();
            //    return;
            //}
            //else
            //{
            //    loadSewingEntryRecord();

            //}
            //searchSewingThreadEntry();
            loadPolyBagRecord();
        }


    
        //DropDownList in GridView End
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {

              //  clear();
            }

            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }
       
        protected void gvPolyBagSetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
        }
        protected void gvPolyBagSetup_RowDataBound(GridViewRowEventArgs e)
        {
           

        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPolyBagSetup, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
           
           

            
        }



        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadPolyBagRecord();
        }
    }
}