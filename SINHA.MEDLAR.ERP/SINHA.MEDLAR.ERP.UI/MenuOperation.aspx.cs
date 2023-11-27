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

using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class MenuOperation : System.Web.UI.Page
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
        string strSoftId = "";
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
                getLoginEmpId();  
                clearMsg();
                getOfficeName();
                LoadMenuOperationInfo();
            }
            if (IsPostBack)
            {

                loadSesscion();
            }
        }

        #region "FUNCTION"

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
            Session["strSoftId"] = null;
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
       
        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
        }

        public void getLoginEmpId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEmployeeId.DataSource = objLookUpBLL.getLoginEmpId(strHeadOfficeId, strBranchOfficeId);

            ddlEmployeeId.DataTextField = "EMPLOYEE_NAME";
            ddlEmployeeId.DataValueField = "EMPLOYEE_ID";

            ddlEmployeeId.DataBind();
            if (ddlEmployeeId.Items.Count > 0)
            {

                ddlEmployeeId.SelectedIndex = 0;
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
            strSoftId = Session["strSoftId"].ToString().Trim();
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


        public void searchMenuOperationInfoEntry()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();

            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            dt = objLookUpBLL.searchMenuOperationInfoEntry(ddlEmployeeId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
                string strMsg = "TOTAL " + gvEmployeeList.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
                int totalcolums = gvEmployeeList.Rows[0].Cells.Count;
                gvEmployeeList.Rows[0].Cells.Clear();
                gvEmployeeList.Rows[0].Cells.Add(new TableCell());
                gvEmployeeList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvEmployeeList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                lblMsg.Text = strMsg;
            }

        }
        public void LoadMenuOperationInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();

            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            dt = objLookUpBLL.searchMenuOperationInfo(strSoftId, strHeadOfficeId,strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int totalcolums = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridView1.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                lblMsgRecord.Text = strMsg;
            }

        }


        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
 
        public void addMenuOperationInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            string strMsg = "";
            string strCount = GridView1.Rows.Count.ToString();

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {

                        string strMenuId = (row.FindControl("lblMenuId") as Label).Text;
                        string strMenuName = (row.FindControl("lblMenuName") as Label).Text;


                        objLookUpDTO.MenuId = strMenuId;
                        objLookUpDTO.MenuName = strMenuName;

                        if (ddlEmployeeId.SelectedValue.ToString() != " ")
                        {
                            objLookUpDTO.EmployeeId = ddlEmployeeId.SelectedValue.ToString();
                        }
                        else
                        {

                            objLookUpDTO.EmployeeId = "";
                        }
                      

                        objLookUpDTO.UpdateBy = strEmployeeId;
                        objLookUpDTO.HeadOfficeId = strHeadOfficeId;
                        objLookUpDTO.BranchOfficeId = strBranchOfficeId;


                        strMsg = objLookUpBLL.addMenuOperationInfo(objLookUpDTO);

                        }

                    }
            }

            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }
        public void deleteEmpMenu(string strEmployeeId, string strMenuId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.MenuId = strMenuId;
            objLookUpDTO.EmployeeId = strEmployeeId;

           

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objLookUpBLL.deleteEmpMenu(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }
        public void searchLoginEmployeeName(string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchLoginEmployeeName(strEmployeeId, strHeadOfficeId, strBranchOfficeId);

            txtEmployeeFullName.Text = objLookUpDTO.EmployeeName;


        }

        #endregion

        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
            
        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
         
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strMenuId = gvEmployeeList.SelectedRow.Cells[1].Text;


            txtEmployeeId.Text = strEmployeeId;
            txtMenuId.Text = strMenuId;

           

        }

        protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }

        protected void gvEmployeeList_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);
            }
        }

        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }

        #endregion
        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {

          


        }

        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }

        protected void GridView1_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlEmployeeId.Text == " ")
                {

                    string strMsg = "Please Select User Name!!!";
                    MessageBox(strMsg);
                    ddlEmployeeId.Focus();
                    return;
                }                             
                 else
                 {
                     searchMenuOperationInfoEntry();
                 }

            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
              {
                if (ddlEmployeeId.Text == " ")
                {

                    string strMsg = "Please Select User Name!!!";
                    MessageBox(strMsg);
                    ddlEmployeeId.Focus();
                    return;
                }

                else
                {
                    addMenuOperationInfo();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void ddlEmployeeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmployeeId.Text != " ")
            {

                searchLoginEmployeeName(ddlEmployeeId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);


            }
            else
            {


            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {
                string strMsg = "Please click searh Button!!!";
                lblMsg.Text = strMsg;
                MessageBox(strMsg);
                btnSearch.Focus();
                return;
            }

            else if (txtEmployeeId.Text == "")
            {
                string strMsg = "Please click in the Gridview!!!";
                MessageBox(strMsg);
                clearMessage();
                return;

            }
            else
            {
                deleteEmpMenu(txtEmployeeId.Text, txtMenuId.Text, strHeadOfficeId, strBranchOfficeId);

            }

        }
    }
}