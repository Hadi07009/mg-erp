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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ForeignFabricAssign : System.Web.UI.Page
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
                loadSesscion();
                
                getOfficeName();
                getProgrammeId();
                getSupplierId();
                loadProgrammeFFSCAUC();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }


            lblMsg.Text = "";

            txtFabricId.Attributes.Add("onkeypress", "return controlEnter('" + txtFabricConstructionId.ClientID + "', event)");
            txtFabricConstructionId.Attributes.Add("onkeypress", "return controlEnter('" + txtArtId.ClientID + "', event)");
            txtArtId.Attributes.Add("onkeypress", "return controlEnter('" + txtStyleId.ClientID + "', event)");
            txtStyleId.Attributes.Add("onkeypress", "return controlEnter('" + txtColorId.ClientID + "', event)");
            txtColorId.Attributes.Add("onkeypress", "return controlEnter('" + txtUnitId.ClientID + "', event)");
            txtUnitId.Attributes.Add("onkeypress", "return controlEnter('" + txtCurrencyId.ClientID + "', event)");

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (ddlProgrammeId.Text == string.Empty)
            {

                string strMsg = "Please Enter Programme Name!!!";
                MessageBox(strMsg);
                ddlProgrammeId.Focus();
                return ;
            }


           else if (ddlSupplierId.Text == string.Empty)
            {

                string strMsg = "Please Enter supplier Name!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;
            }

            else if (txtFabricId.Text == string.Empty)
            {

                string strMsg = "Please Enter Fabric!!!";
                MessageBox(strMsg);
                txtFabricId.Focus();
                return;
            }

            else if (txtFabricConstructionId.Text == string.Empty)
            {

                string strMsg = "Please Enter Construction!!!";
                MessageBox(strMsg);
                txtFabricConstructionId.Focus();
                return;
            }

            else if (txtArtId.Text == string.Empty)
            {

                string strMsg = "Please Enter Art!!!";
                MessageBox(strMsg);
                txtArtId.Focus();
                return;
            }

            else if (txtStyleId.Text == string.Empty)
            {

                string strMsg = "Please Enter Style!!!";
                MessageBox(strMsg);
                ddlSupplierId.Focus();
                return;
            }

            else if (txtColorId.Text == string.Empty)
            {

                string strMsg = "Please Enter Color Name!!!";
                MessageBox(strMsg);
                txtColorId.Focus();
                return;
            }

            else if (txtUnitId.Text == string.Empty)
            {

                string strMsg = "Please Enter Unit!!!";
                MessageBox(strMsg);
                txtUnitId.Focus();
                return;
            }

            else if (txtCurrencyId.Text == string.Empty)
            {

                string strMsg = "Please Enter Currency!!!";
                MessageBox(strMsg);
                txtCurrencyId.Focus();
                return;
            }

            else
            {
                saveProgrammeFFSCAUCRecord();
                loadProgrammeFFSCAUC();
                clearTextBox();
               
                
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


        public void searchFabricAssign(string strTranId, string strHeadOfficeId, string strBranchOfficeId)
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveBLL objForeignFabricReceiveBLL = new ForeignFabricReceiveBLL();


            objForeignFabricReceiveDTO = objForeignFabricReceiveBLL.searchFabricAssign(strTranId, strHeadOfficeId, strBranchOfficeId);

            if (objForeignFabricReceiveDTO.ProgrammeId != "0")
            {
                ddlProgrammeId.SelectedValue = objForeignFabricReceiveDTO.ProgrammeId;

            }
            else
            {

                getProgrammeId();

            }

            if (objForeignFabricReceiveDTO.SupplierId != "0")
            {
                ddlSupplierId.SelectedValue = objForeignFabricReceiveDTO.SupplierId;

            }
            else
            {

                getSupplierId();

            }

            if (objForeignFabricReceiveDTO.FabricId != "0")
            {
                txtFabricId.Text = objForeignFabricReceiveDTO.FabricId;

            }
            else
            {

                txtFabricId.Text = "";

            }

            if (objForeignFabricReceiveDTO.ConstructionId != "0")
            {
                txtFabricConstructionId.Text = objForeignFabricReceiveDTO.ConstructionId;

            }
            else
            {

                txtFabricConstructionId.Text = "";

            }

            if (objForeignFabricReceiveDTO.ArtId != "0")
            {
                txtArtId.Text = objForeignFabricReceiveDTO.ArtId;

            }
            else
            {

                txtArtId.Text = "";

            }

            if (objForeignFabricReceiveDTO.UnitId != "0")
            {
                txtUnitId.Text = objForeignFabricReceiveDTO.UnitId;

            }
            else
            {

                txtUnitId.Text = "";

            }

            if (objForeignFabricReceiveDTO.StyleId != "0")
            {
                txtStyleId.Text = objForeignFabricReceiveDTO.StyleId;

            }
            else
            {

                txtStyleId.Text = "";

            }

            if (objForeignFabricReceiveDTO.CurrencyId != "0")
            {
                txtCurrencyId.Text = objForeignFabricReceiveDTO.CurrencyId;

            }
            else
            {

                txtCurrencyId.Text = "";

            }


            if (objForeignFabricReceiveDTO.ColorId != "0")
            {
                txtColorId.Text = objForeignFabricReceiveDTO.ColorId;

            }
            else
            {

                txtColorId.Text = "";

            }




        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

      
     
    
        public void saveProgrammeFFSCAUCRecord()
        {
           

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveBLL objForeignFabricReceiveBLL = new ForeignFabricReceiveBLL();

            if (ddlProgrammeId.SelectedValue.ToString() != "")
            {
                objForeignFabricReceiveDTO.ProgrammeId = ddlProgrammeId.SelectedValue.ToString();

            }
            else
            {

                objForeignFabricReceiveDTO.ProgrammeId = "";

            }
            if (ddlSupplierId.SelectedValue.ToString() != "")
            {
                objForeignFabricReceiveDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();

            }
            else
            {

                objForeignFabricReceiveDTO.SupplierId = "";

            }
            objForeignFabricReceiveDTO.FabricId = txtFabricId.Text;

            objForeignFabricReceiveDTO.FabricConstructionId = txtFabricConstructionId.Text;

            objForeignFabricReceiveDTO.ColorId = txtColorId.Text;

            objForeignFabricReceiveDTO.ArtId = txtArtId.Text;
            objForeignFabricReceiveDTO.StyleId = txtStyleId.Text;
            objForeignFabricReceiveDTO.UnitId = txtUnitId.Text;
            objForeignFabricReceiveDTO.CurrencyId = txtCurrencyId.Text;
            objForeignFabricReceiveDTO.TranId = txtTranId.Text;


            objForeignFabricReceiveDTO.UpdateBy = strEmployeeId;
            objForeignFabricReceiveDTO.HeadOfficeId = strHeadOfficeId;
            objForeignFabricReceiveDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objForeignFabricReceiveBLL.saveProgrammeFFSCAUCRecord(objForeignFabricReceiveDTO);
            lblMsgRecord.Text = strMsg;
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }








        public void loadProgrammeFFSCAUC()
        {

            ForeignFabricReceiveDTO objForeignFabricReceiveDTO = new ForeignFabricReceiveDTO();
            ForeignFabricReceiveBLL objForeignFabricReceiveBLL = new ForeignFabricReceiveBLL();


            DataTable dt = new DataTable();



            if (ddlProgrammeId.SelectedValue.ToString() != " ")
            {
                objForeignFabricReceiveDTO.ProgrammeId = ddlProgrammeId.SelectedValue.ToString();

            }
            else
            {
                objForeignFabricReceiveDTO.ProgrammeId = "";

            }

            if (ddlSupplierId.SelectedValue.ToString() != "0")
            {
                objForeignFabricReceiveDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();

            }
            else
            {
                objForeignFabricReceiveDTO.SupplierId = "";

            }




            objForeignFabricReceiveDTO.HeadOfficeId = strHeadOfficeId;
            objForeignFabricReceiveDTO.BranchOfficeId = strBranchOfficeId;

            dt = objForeignFabricReceiveBLL.loadProgrammeFFSCAUC(objForeignFabricReceiveDTO);


            if (dt.Rows.Count > 0)
            {
                gvBuyerEntry.DataSource = dt;
                gvBuyerEntry.DataBind();
                string strMsg = "TOTAL " + gvBuyerEntry.Rows.Count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvBuyerEntry.DataSource = dt;
                gvBuyerEntry.DataBind();
                int totalcolums = gvBuyerEntry.Rows[0].Cells.Count;
                gvBuyerEntry.Rows[0].Cells.Clear();
                gvBuyerEntry.Rows[0].Cells.Add(new TableCell());
                gvBuyerEntry.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvBuyerEntry.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;
                lblMsgRecord.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            
            txtArtId.Text = "";
         
            txtColorId.Text = "";
            txtCurrencyId.Text = "";

            txtFabricConstructionId.Text = "";
            txtFabricId.Text = "";

            txtStyleId.Text = "";
            txtUnitId.Text = "";
            txtTranId.Text = "";
           

        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            loadProgrammeFFSCAUC();
        }

        protected void gvBuyerEntry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBuyerEntry.PageIndex = e.NewPageIndex;
            
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvBuyerEntry, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvBuyerEntry.SelectedRow.RowIndex;
           
            string strTranId = gvBuyerEntry.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            //string strFabricName = gvBuyerEntry.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

            //string strFabricConstruction = gvBuyerEntry.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            //string strArtNo = gvBuyerEntry.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");


            //string strStyleName = gvBuyerEntry.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            //string strColorName = gvBuyerEntry.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

            //string strUnitName = gvBuyerEntry.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            //string strCurrencyName= gvBuyerEntry.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

            // ddlProgrammeId.Text = strProgrammeName;
            //txtFabricId.Text = strFabricName;
            //txtFabricConstructionId.Text = strFabricConstruction;
            //txtArtId.Text = strArtNo;
            //txtStyleId.Text = strStyleName;
            //txtColorId.Text = strColorName;
            //txtUnitId.Text = strUnitName;
            //txtCurrencyId.Text = strCurrencyName;

            txtTranId.Text = strTranId;

            searchFabricAssign(txtTranId.Text, strHeadOfficeId, strBranchOfficeId);


        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearTextBox();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " +ex.Message);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadProgrammeFFSCAUC();
        }

 
    }
}