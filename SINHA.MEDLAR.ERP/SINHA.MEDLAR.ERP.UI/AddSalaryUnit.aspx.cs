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
    public partial class AddSalaryUnit : System.Web.UI.Page
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
                loadSalaryLineRecord();
                getOfficeName();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }

         

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtSalaryUnitName.Text == string.Empty)
            {
                string strMsg = "Please Enter Unit Name!!!";
                MessageBox(strMsg);
                txtSalaryUnitName.Focus();
                return ;
            }

          
            else
            {
                SaveSalaryUnitInfo();
                loadSalaryLineRecord();

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

        public void SaveSalaryUnitInfo()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.SalaryUnitId = txtSalaryUnitId.Text;
            objLookUpDTO.SalaryUnitName = txtSalaryUnitName.Text;
          


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.SaveSalaryUnitInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void searchSalaryUnitInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchSalaryUnitInfo(txtSalaryUnitId.Text);

            txtSalaryUnitName.Text = objLookUpDTO.SalaryUnitName;
          


        }

        public void loadSalaryLineRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadSalaryLineRecord(strHeadOfficeId, strBranchOfficeId);

            gvSalaryUnitInfo.Columns[1].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvSalaryUnitInfo.DataSource = dt;
                gvSalaryUnitInfo.DataBind();
                gvSalaryUnitInfo.Columns[1].Visible = false;
                string strMsg = "TOTAL " + gvSalaryUnitInfo.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvSalaryUnitInfo.DataSource = dt;
                gvSalaryUnitInfo.DataBind();
                gvSalaryUnitInfo.Columns[1].Visible = false;
                int totalcolums = gvSalaryUnitInfo.Rows[0].Cells.Count;
                gvSalaryUnitInfo.Rows[0].Cells.Clear();
                gvSalaryUnitInfo.Rows[0].Cells.Add(new TableCell());
                gvSalaryUnitInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvSalaryUnitInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtSalaryUnitId.Text = "";
            txtSalaryUnitName.Text = "";
          


        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSalaryUnitId.Text == string.Empty)
            {

                string strMsg = "Please Enter ID!!!";
                MessageBox(strMsg);
                txtSalaryUnitId.Focus();
                return;
            }
            else
            {
                searchSalaryUnitInfo();

            }
        }

        protected void gvSalaryUnitInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSalaryUnitInfo.PageIndex = e.NewPageIndex;           
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvSalaryUnitInfo, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvSalaryUnitInfo.SelectedRow.RowIndex;
            string strSalaryUnitId = gvSalaryUnitInfo.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strSalaryUnitName = gvSalaryUnitInfo.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
          
            txtSalaryUnitId.Text = strSalaryUnitId;
            txtSalaryUnitName.Text = strSalaryUnitName;
          

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