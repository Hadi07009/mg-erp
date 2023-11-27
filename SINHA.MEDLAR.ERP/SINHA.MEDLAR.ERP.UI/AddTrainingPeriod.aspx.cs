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
    public partial class AddTrainingPeriod : System.Web.UI.Page
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
            loadTrainPeriodRecord();
        }

        if (IsPostBack)
        {

            loadSesscion();
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


        public void loadTrainPeriodRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadTrainPeriodRecord();


            if (dt.Rows.Count > 0)
            {
                gvTrainPeriod.DataSource = dt;
                gvTrainPeriod.DataBind();
                string strMsg = "TOTAL " + gvTrainPeriod.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvTrainPeriod.DataSource = dt;
                gvTrainPeriod.DataBind();
                int totalcolums = gvTrainPeriod.Rows[0].Cells.Count;
                gvTrainPeriod.Rows[0].Cells.Clear();
                gvTrainPeriod.Rows[0].Cells.Add(new TableCell());
                gvTrainPeriod.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvTrainPeriod.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clear()
        {
            txtTrainPeriodId.Text = string.Empty;
            txtTrainPeriodName.Text = string.Empty;

        }

        public void saveTrainPeriodInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.TrainingPeriodId = txtTrainPeriodId.Text;
            objLookUpDTO.TrainingPeriodName = txtTrainPeriodName.Text;



            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            string strMsg = objLookUpBLL.saveTrainPeriodInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }

        public void clearTextBox()
        {
            txtTrainPeriodId.Text = "";
            txtTrainPeriodName.Text = "";

        }


        public void searchTrainPeriodEntry()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchTrainPeriodEntry(txtTrainPeriodId.Text, strHeadOfficeId, strBranchOfficeId);

            txtTrainPeriodName.Text = objLookUpDTO.TrainingPeriodName;

        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtTrainPeriodName.Text == "")
                {

                    string strMsg = "Please Enter Train Period!!!";
                    txtTrainPeriodName.Focus();
                    MessageBox(strMsg);
                    return; 
                }
                else
                {
                    saveTrainPeriodInfo();
                    loadTrainPeriodRecord();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
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


        #region "GridView Functionlity"

        protected void gvTrainPeriod_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTrainPeriod.PageIndex = e.NewPageIndex;
            loadTrainPeriodRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvTrainPeriod.SelectedRow.RowIndex;
            string strTrainPeriodId = gvTrainPeriod.SelectedRow.Cells[0].Text;
            string strTrainPeriodName = gvTrainPeriod.SelectedRow.Cells[1].Text;


            txtTrainPeriodId.Text = strTrainPeriodId;
            txtTrainPeriodName.Text = strTrainPeriodName;
        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvTrainPeriod_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTrainPeriod.EditIndex = e.NewEditIndex;
            loadTrainPeriodRecord();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvTrainPeriod, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtTrainPeriodId.Text == "")
            {

                string strMsg = "Please Enter Train Period Id!!!";
                txtTrainPeriodId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {
                searchTrainPeriodEntry();
            }
        }

        #endregion

    }
}