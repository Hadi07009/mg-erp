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
    public partial class AddFabricDescription : System.Web.UI.Page
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
                getBuyerId();
                loadFabricDescriptionName();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }
        }

        public void getBuyerId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerId.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerId.DataTextField = "BUYER_SHORT_NAME";
            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {

                ddlBuyerId.SelectedIndex = 0;
            }


        }
        public void loadSession()
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

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (ddlBuyerId.Text == " ")
            {
                string strMsg = "Please Select Buyer Name!!!";
                MessageBox(strMsg);
                ddlBuyerId.Focus();
                return;


            }
            if (txtFabricName.Text == "")
            {

                string strMsg = "Please Enter Fabric Name!!!";
                txtFabricName.Focus();
                MessageBox(strMsg);
                return;

            }


            else
            {

                saveFabricDescriptionName();
                loadFabricDescriptionName();
                clearTextBox();
            }
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

       

        public void searchFabricDescriptionRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchFabricDescriptionRecord(txtFabricId.Text, ddlBuyerId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);

            txtFabricName.Text = objLookUpDTO.FabricName;
          
            if(objLookUpDTO.BuyerId =="0")
            {

                getBuyerId();
            }
            else
            {

                ddlBuyerId.SelectedValue = objLookUpDTO.BuyerId;
            }

        }



        public void loadFabricDescriptionName()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadFabricDescriptionName();


            if (dt.Rows.Count > 0)
            {
                gvFabricDescription.DataSource = dt;
                gvFabricDescription.DataBind();
                string strMsg = "TOTAL " + gvFabricDescription.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvFabricDescription.DataSource = dt;
                gvFabricDescription.DataBind();
                int totalcolums = gvFabricDescription.Rows[0].Cells.Count;
                gvFabricDescription.Rows[0].Cells.Clear();
                gvFabricDescription.Rows[0].Cells.Add(new TableCell());
                gvFabricDescription.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvFabricDescription.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }





        public void saveFabricDescriptionName()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.FabricId = txtFabricId.Text;
            objLookUpDTO.FabricName = txtFabricName.Text;

            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

            }
            else
            {
                objLookUpDTO.BuyerId = "";

            }



            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.saveFabricDescriptionName(objLookUpDTO);
            lblMsgRecord.Text= strMsg;
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }

        public void clearTextBox()
        {
            txtFabricId.Text = "";
            txtFabricName.Text = "";

        }

        #endregion

        #region "GridView Functionlity"

        protected void gvFabricDescription_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFabricDescription.PageIndex = e.NewPageIndex;
          
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvFabricDescription.SelectedRow.RowIndex;
            string strUnitId = gvFabricDescription.SelectedRow.Cells[0].Text;
            string strUnitName = gvFabricDescription.SelectedRow.Cells[1].Text;
            string strFabricSymbolicName = gvFabricDescription.SelectedRow.Cells[2].Text;


            txtFabricId.Text = strUnitId;
            txtFabricName.Text = strUnitName;
            searchFabricDescriptionRecord();

        }
        protected void gvFabricDescription_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvFabricDescription_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvFabricDescription.EditIndex = e.NewEditIndex;
            loadFabricDescriptionName();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvFabricDescription, "Select$" + e.Row.RowIndex);
            }
        }




        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtFabricId.Text == "")
            {

                string strMsg = "Please Enter Fabric ID!!!";
                txtFabricId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {

                searchFabricDescriptionRecord();
            }
        }

    }
}