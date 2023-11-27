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
    public partial class AddLineInfo : System.Web.UI.Page
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
                loadLineInfo();
                getOfficeName();
              
                getProductionUnitId();
                getSalaryUnitId();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }

            txtLineId.Attributes.Add("onkeypress", "return controlEnter('" + txtLineName.ClientID + "', event)");
            txtLineName.Attributes.Add("onkeypress", "return controlEnter('" + ddlProductionUnitId.ClientID + "', event)");
            ddlProductionUnitId.Attributes.Add("onkeypress", "return controlEnter('" + ddlSalaryUnitId.ClientID + "', event)");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtLineName.Text == string.Empty)
            {
                string strMsg = "Please Enter Line Name!!!";
                MessageBox(strMsg);
                txtLineName.Focus();
                return ;
            }

          
            else if (ddlProductionUnitId.Text == string.Empty)
            {
                string strMsg = "Please Select Production Unit!!!";
                MessageBox(strMsg);
                ddlProductionUnitId.Focus();
                return;
            }
            else if (ddlSalaryUnitId.Text == string.Empty)
            {
                string strMsg = "Please Select Salary Unit!!!";
                MessageBox(strMsg);
                ddlSalaryUnitId.Focus();
                return;
            }
            else
            {
                SaveLineInfo();
                loadLineInfo();

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


        
        public void getProductionUnitId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlProductionUnitId.DataSource = objLookUpBLL.getProductionUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlProductionUnitId.DataTextField = "PRODUCTION_UNIT_NAME";
            ddlProductionUnitId.DataValueField = "PRODUCTION_UNIT_ID";

            ddlProductionUnitId.DataBind();
            if (ddlProductionUnitId.Items.Count > 0)
            {

                ddlProductionUnitId.SelectedIndex = 0;
            }

        }
        public void getSalaryUnitId()
        {

            

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSalaryUnitId.DataSource = objLookUpBLL.getSalaryUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlSalaryUnitId.DataTextField = "SALARY_UNIT_NAME";
            ddlSalaryUnitId.DataValueField = "SALARY_UNIT_ID";

            ddlSalaryUnitId.DataBind();
            if (ddlSalaryUnitId.Items.Count > 0)
            {

                ddlSalaryUnitId.SelectedIndex = 0;
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

        public void SaveLineInfo()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.LineId = txtLineId.Text;
            objLookUpDTO.LineName = txtLineName.Text;

         
            if (ddlProductionUnitId.SelectedValue.ToString() != " ")
            {

                objLookUpDTO.ProductionUnitId = ddlProductionUnitId.SelectedValue.ToString();

            }
            else
            {

                objLookUpDTO.ProductionUnitId = "";
            }

            if (ddlSalaryUnitId.SelectedValue.ToString() != " ")
            {

                objLookUpDTO.SalaryUnitId = ddlSalaryUnitId.SelectedValue.ToString();

            }
            else
            {

                objLookUpDTO.SalaryUnitId = "";
            }


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.SaveLineInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void searchLineInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchLineInfo(txtLineId.Text);


            if (objLookUpDTO.ProductionUnitId == "0")
            {

            }
            else
            {
                ddlProductionUnitId.SelectedValue = objLookUpDTO.ProductionUnitId;
            }

            if (objLookUpDTO.SalaryUnitId == "0")
            {

            }
            else
            {
                ddlSalaryUnitId.SelectedValue = objLookUpDTO.SalaryUnitId;
            }
        }

        public void loadLineInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadLineInfo(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvLineInfo.DataSource = dt;
                gvLineInfo.DataBind();
                string strMsg = "TOTAL " + gvLineInfo.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvLineInfo.DataSource = dt;
                gvLineInfo.DataBind();
                int totalcolums = gvLineInfo.Rows[0].Cells.Count;
                gvLineInfo.Rows[0].Cells.Clear();
                gvLineInfo.Rows[0].Cells.Add(new TableCell());
                gvLineInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvLineInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtLineId.Text = "";
            txtLineName.Text = "";
          
            ddlProductionUnitId.SelectedValue = null;
            ddlSalaryUnitId.SelectedValue = null;


        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtLineId.Text == string.Empty)
            {

                string strMsg = "Please Enter Line ID!!!";
                MessageBox(strMsg);
                txtLineId.Focus();
                return;
            }
            else
            {
                loadLineInfo();

            }
        }

        protected void gvLineInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLineInfo.PageIndex = e.NewPageIndex;           
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvLineInfo, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvLineInfo.SelectedRow.RowIndex;
            string strLineId = gvLineInfo.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strLineName = gvLineInfo.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strBuyerFullName = gvLineInfo.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

            txtLineId.Text = strLineId;
            txtLineName.Text = strLineName;

            searchLineInfo();

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

        protected void ddlFactoryId_SelectedIndexChanged(object sender, EventArgs e)
        {
            getSalaryUnitId();
        }
    }
}