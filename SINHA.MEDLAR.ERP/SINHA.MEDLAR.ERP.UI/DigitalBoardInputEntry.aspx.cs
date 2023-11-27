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
    public partial class DigitalBoardInputEntry : System.Web.UI.Page
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
             //   loadDigitalBoardInputRecord();
             
                getOfficeName();

                getBuyerId();
                getLineId();
                getBuyerIdSearch();
                getLineIdSearch();

               
            }

            if (IsPostBack)
            {

                loadSesscion();
            }



            dtpInputDate.Attributes.Add("onkeypress", "return controlEnter('" + txtStyle.ClientID + "', event)");
         


            txtStyle.Attributes.Add("onkeypress", "return controlEnter('" + txtSmv.ClientID + "', event)");
            txtSmv.Attributes.Add("onkeypress", "return controlEnter('" + txtManpower.ClientID + "', event)");
            txtManpower.Attributes.Add("onkeypress", "return controlEnter('" + txtTargetEfficiency.ClientID + "', event)");
            txtTargetEfficiency.Attributes.Add("onkeypress", "return controlEnter('" + txtTargetPerHour.ClientID + "', event)");
            txtTargetPerHour.Attributes.Add("onkeypress", "return controlEnter('" + txtDayTarget.ClientID + "', event)");



            txtDayTarget.Attributes.Add("onkeypress", "return controlEnter('" + txtDhuLimit.ClientID + "', event)");

            txtDhuLimit.Attributes.Add("onkeypress", "return controlEnter('" + txtHour.ClientID + "', event)");
            txtHour.Attributes.Add("onkeypress", "return controlEnter('" + txtAchive.ClientID + "', event)");
            txtAchive.Attributes.Add("onkeypress", "return controlEnter('" + txtDefect.ClientID + "', event)");
            txtDefect.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtHour.Text == string.Empty || txtAchive.Text == string.Empty ||txtDefect.Text==string.Empty)
                {
                    string strMsg = "Please Fill All The Field!!!";
                    txtHour.Focus();
                    MessageBox(strMsg);
                    return;


                }

                else
                {
                    saveDigitalBoardInputInfo();
                    loadDigitalBoardInputRecord();

                }



            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            {
                DigitalBoardEntrySearch();
            }
        }


        public void DigitalBoardEntrySearch()
        {
            DigitalBoardDTO objDigitalBoardDTO = new DigitalBoardDTO();
            DigitalBoardBLL objDigitalBoardBLL = new DigitalBoardBLL();
            DataTable dt = new DataTable();

            objDigitalBoardDTO.HeadOfficeId = strHeadOfficeId;
            objDigitalBoardDTO.BranchOfficeId = strBranchOfficeId;
            objDigitalBoardDTO.DigitalBoardInputId = txtDigitalBordInputEntryId.Text;

            objDigitalBoardDTO.InputFromDate = dtpPdFromDate.Text;
            objDigitalBoardDTO.InputToDate = dtpPdToDate.Text;

            if (ddlBuyerIdSearch.SelectedValue.ToString() != "0")
            {
                objDigitalBoardDTO.BuyerId = ddlBuyerIdSearch.SelectedValue.ToString();
            }
            else
            {

                objDigitalBoardDTO.BuyerId = "";
            }

            //
            if (ddlLineIdSearch.SelectedValue.ToString() != "0")
            {
                objDigitalBoardDTO.LineId = ddlLineIdSearch.SelectedValue.ToString();
            }
            else
            {

                objDigitalBoardDTO.LineId = "";
            }

    



            dt = objDigitalBoardBLL.DigitalBoardEntrySearch(objDigitalBoardDTO);


            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();

                int count = ((DataTable)GridView2.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();


            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView2.DataSource = dt;
                GridView2.DataBind();
                int totalcolums = GridView2.Rows[0].Cells.Count;
                GridView2.Rows[0].Cells.Clear();
                GridView2.Rows[0].Cells.Add(new TableCell());
                GridView2.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridView2.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {

                clear();

            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

        #region "Function"

       


        public void getBuyerId()
        {

            DigitalBoardBLL objDigitalBoardBLL = new DigitalBoardBLL();
            ddlBuyerId.DataSource = objDigitalBoardBLL.getBuyerId(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerId.DataTextField = "BUYER_NAME";

            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {

                ddlBuyerId.SelectedIndex = 0;
            }

        }
        public void getLineId()
        {

            DigitalBoardBLL objDigitalBoardBLL = new DigitalBoardBLL();
            ddlLineId.DataSource = objDigitalBoardBLL.getLineId(strHeadOfficeId, strBranchOfficeId);

            ddlLineId.DataTextField = "LINE_NAME";

            ddlLineId.DataValueField = "LINE_ID";

            ddlLineId.DataBind();
            if (ddlLineId.Items.Count > 0)
            {
                ddlLineId.SelectedIndex = 0;
            }

        }

        public void getLineIdSearch()
        {

            DigitalBoardBLL objDigitalBoardBLL = new DigitalBoardBLL();
            ddlLineIdSearch.DataSource = objDigitalBoardBLL.getLineIdSearch(strHeadOfficeId, strBranchOfficeId);

            ddlLineIdSearch.DataTextField = "LINE_NAME";

            ddlLineIdSearch.DataValueField = "LINE_ID";

            ddlLineIdSearch.DataBind();
            if (ddlLineIdSearch.Items.Count > 0)
            {

                ddlLineIdSearch.SelectedIndex = 0;
            }

        }

        public void getBuyerIdSearch()
        {

            DigitalBoardBLL objDigitalBoardBLL = new DigitalBoardBLL();
            ddlBuyerIdSearch.DataSource = objDigitalBoardBLL.getBuyerIdSearch(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerIdSearch.DataTextField = "BUYER_NAME";

            ddlBuyerIdSearch.DataValueField = "BUYER_ID";

            ddlBuyerIdSearch.DataBind();
            if (ddlBuyerIdSearch.Items.Count > 0)
            {

                ddlBuyerIdSearch.SelectedIndex = 0;
            }

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


        public void loadDigitalBoardInputRecord()
        {
            DigitalBoardDTO objDigitalBoardDTO = new DigitalBoardDTO();
            DigitalBoardBLL objDigitalBoardBLL = new DigitalBoardBLL();

            DataTable dt = new DataTable();
            dt = objDigitalBoardBLL.loadDigitalBoardInputRecord(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";

                lblMsg.Text = strMsg;
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
                lblMsg.Text = strMsg;

            }

        }

        public void clear()
        {
            txtDigitalBordInputEntryId.Text = "";
            dtpInputDate.Text = "";

            ddlBuyerId.Items.Clear();
            txtStyle.Text = "";
            txtSmv.Text = "";
            txtManpower.Text = "";
            txtTargetEfficiency.Text = "";
            txtTargetPerHour.Text = "";
            txtDayTarget.Text = "";
            ddlLineId.Items.Clear();
            txtDhuLimit.Text = "";
            txtHour.Text = "";
            txtAchive.Text = "";
            txtDefect.Text = "";
           
            getBuyerId();
            getLineId();
        }
        public void saveDigitalBoardInputInfo()
        {

            DigitalBoardDTO objDigitalBoardDTO = new DigitalBoardDTO();
            DigitalBoardBLL objDigitalBoardBLL = new DigitalBoardBLL();

            objDigitalBoardDTO.DigitalBoardInputId = txtDigitalBordInputEntryId.Text;
            objDigitalBoardDTO.InputDate = dtpInputDate.Text;
            objDigitalBoardDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
            objDigitalBoardDTO.StyleNo = txtStyle.Text;
            objDigitalBoardDTO.SMV = txtSmv.Text;
            objDigitalBoardDTO.ManPower = txtManpower.Text;
            objDigitalBoardDTO.TargetEfficiency = txtTargetEfficiency.Text;
            objDigitalBoardDTO.TargetPerHour = txtTargetPerHour.Text;
            objDigitalBoardDTO.DayTarget = txtDayTarget.Text;
            objDigitalBoardDTO.LineId = ddlLineId.SelectedValue.ToString();
            objDigitalBoardDTO.DHULimit = txtDhuLimit.Text;
            objDigitalBoardDTO.Hour = txtHour.Text;
            objDigitalBoardDTO.Achieve = txtAchive.Text;
            objDigitalBoardDTO.Defect = txtDefect.Text;

            objDigitalBoardDTO.UpdateBy = strEmployeeId;
            objDigitalBoardDTO.HeadOfficeId = strHeadOfficeId;
            objDigitalBoardDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objDigitalBoardBLL.saveDigitalBoardInputInfo(objDigitalBoardDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
            txtDigitalBordInputEntryId.Text = "";
            txtHour.Text = "";
            txtAchive.Text = "";
            txtDefect.Text = "";
         

        }



        public void searchDigitalBoardInputEntry()
        {

            DigitalBoardDTO objDigitalBoardDTO = new DigitalBoardDTO();
            DigitalBoardBLL objDigitalBoardBLL = new DigitalBoardBLL();

            objDigitalBoardDTO = objDigitalBoardBLL.searchDigitalBoardInputEntry(txtDigitalBordInputEntryId.Text, strHeadOfficeId, strBranchOfficeId);
            dtpInputDate.Text = objDigitalBoardDTO.InputDate;
            if (objDigitalBoardDTO.BuyerId == "0")
            {

             
            }
            else
            {
                ddlBuyerId.SelectedValue = objDigitalBoardDTO.BuyerId;
            }

            if (objDigitalBoardDTO.LineId == "0")
            {

              
            }
            else
            {
                ddlLineId.SelectedValue = objDigitalBoardDTO.LineId;
            }
            txtStyle.Text = objDigitalBoardDTO.StyleNo;
            txtSmv.Text = objDigitalBoardDTO.SMV;
            txtManpower.Text = objDigitalBoardDTO.ManPower;
            txtTargetEfficiency.Text = objDigitalBoardDTO.TargetEfficiency;
            txtTargetPerHour.Text = objDigitalBoardDTO.TargetPerHour;
            txtDayTarget.Text = objDigitalBoardDTO.DayTarget;
            txtDhuLimit.Text = objDigitalBoardDTO.DHULimit;
            txtHour.Text = objDigitalBoardDTO.Hour;
            txtAchive.Text = objDigitalBoardDTO.Achieve;
            txtDefect.Text = objDigitalBoardDTO.Defect;



        }

        #endregion

        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;

        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;

            string strdigitalboardinputid = gvUnit.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strInputDate = gvUnit.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");


            txtDigitalBordInputEntryId.Text = strdigitalboardinputid;
            dtpInputDate.Text = strInputDate;
            searchDigitalBoardInputEntry();

    

        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
            loadDigitalBoardInputRecord();
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

        protected void chkActiveYn_CheckedChanged(object sender, EventArgs e)
        {

        }

     
        protected void gvUnit2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;

        }


        protected void OnRowDataBound2(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvUnit, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged2(object sender, EventArgs e)
        {
            int strRowId = GridView2.SelectedRow.RowIndex;
            string strdigitalboardinputid = GridView2.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");


            txtDigitalBordInputEntryId.Text = strdigitalboardinputid;
       

       searchDigitalBoardInputEntry();

        }

        protected void gvUnit2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView2.EditIndex = e.NewEditIndex;
      loadDigitalBoardInputRecord();
        }

        #endregion

        

       
    }
}