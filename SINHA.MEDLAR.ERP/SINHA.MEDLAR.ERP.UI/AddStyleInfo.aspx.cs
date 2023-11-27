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
    public partial class AddStyleInfo : System.Web.UI.Page
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
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }

            txtStyleId.Attributes.Add("onkeypress", "return controlEnter('" + ddlBuyerId.ClientID + "', event)");
            ddlBuyerId.Attributes.Add("onkeypress", "return controlEnter('" + txtStyleNo.ClientID + "', event)");
            txtStyleNo.Attributes.Add("onkeypress", "return controlEnter('" + txtStyleDescription.ClientID + "', event)");

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadStyleRecord();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (ddlBuyerId.Text == string.Empty)
            {
                string strMsg = "Please Select Buyer Name!!!";
                MessageBox(strMsg);
                ddlBuyerId.Focus();
                return;
            }
            else if (txtStyleNo.Text == string.Empty)
            {
                string strMsg = "Please EnterStyle No!!!";
                MessageBox(strMsg);
                txtStyleNo.Focus();
                return ;
            }

            else if (txtStyleDescription.Text == string.Empty)
            {
                string strMsg = "Please Enter Style Description!!!";
                MessageBox(strMsg);
                txtStyleDescription.Focus();
                return;
            }
            else
            {
                SaveStyleInfo();
                loadStyleRecord();

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

        public void SaveStyleInfo()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.StyleId = txtStyleId.Text;

            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {

                objLookUpDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

            }
            else
            {

                objLookUpDTO.BuyerId = "";
            }

            objLookUpDTO.StyleNo = txtStyleNo.Text;
            objLookUpDTO.StyleDescription = txtStyleDescription.Text;


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.SaveStyleInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void searchStyleInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchStyleInfo(txtStyleId.Text);


            if (objLookUpDTO.BuyerId == "0")
            {


            }
            else
            {
                ddlBuyerId.SelectedValue = objLookUpDTO.BuyerId;

            }

            txtStyleNo.Text = objLookUpDTO.StyleNo;
            txtStyleDescription.Text = objLookUpDTO.StyleDescription;


        }

        public void loadStyleRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            string strBuyerId = "";
            if(ddlBuyerId.SelectedValue ==" ")
            {
                strBuyerId = "";
            }
            else
            {              
                strBuyerId = ddlBuyerId.SelectedValue;
            }
            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadStyleRecord(strBuyerId,strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvStyleInfo.DataSource = dt;
                gvStyleInfo.DataBind();
                string strMsg = "TOTAL " + gvStyleInfo.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvStyleInfo.DataSource = dt;
                gvStyleInfo.DataBind();
                int totalcolums = gvStyleInfo.Rows[0].Cells.Count;
                gvStyleInfo.Rows[0].Cells.Clear();
                gvStyleInfo.Rows[0].Cells.Add(new TableCell());
                gvStyleInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvStyleInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtStyleId.Text = "";
            txtStyleNo.Text = "";
            ddlBuyerId.SelectedIndex = 0;
            txtStyleDescription.Text = "";


        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtStyleId.Text == string.Empty)
            {

                string strMsg = "Please Enter Style ID!!!";
                MessageBox(strMsg);
                txtStyleId.Focus();
                return;
            }
            else
            {
                searchStyleInfo();

            }
        }

        protected void gvStyleInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStyleInfo.PageIndex = e.NewPageIndex;           
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvStyleInfo, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvStyleInfo.SelectedRow.RowIndex;
            string strStyleId = gvStyleInfo.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            //string strStyleNo= gvStyleInfo.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            //string strStyleDes = gvStyleInfo.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

            txtStyleId.Text = strStyleId;
            searchStyleInfo();

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

       
    }
}