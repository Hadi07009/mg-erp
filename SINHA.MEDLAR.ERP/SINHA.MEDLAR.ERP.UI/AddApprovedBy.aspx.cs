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
    public partial class AddApprovedBy : System.Web.UI.Page
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
                getUnitId();
                getSectionId();
                clearMsg();
                getOfficeName();
               
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




        public void getUnitId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlUnitId.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlUnitId.DataTextField = "UNIT_NAME";
            ddlUnitId.DataValueField = "UNIT_ID";

            ddlUnitId.DataBind();
            if (ddlUnitId.Items.Count > 0)
            {

                ddlUnitId.SelectedIndex = 0;
            }


        }

        public void getSectionId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSectionId.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

            ddlSectionId.DataTextField = "SECTION_NAME";
            ddlSectionId.DataValueField = "SECTION_ID";

            ddlSectionId.DataBind();
            if (ddlSectionId.Items.Count > 0)
            {

                ddlSectionId.SelectedIndex = 0;
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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        public void searchApprovedByEmpEntry()
        {

            AddApprovedByDTO objAddApprovedByDTO = new AddApprovedByDTO();
            AddApprovedByBLL objAddApprovedByBLL = new AddApprovedByBLL();

            DataTable dt = new DataTable();



            objAddApprovedByDTO.HeadOfficeId = strHeadOfficeId;
            objAddApprovedByDTO.BranchOfficeId = strBranchOfficeId;



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objAddApprovedByDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objAddApprovedByDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objAddApprovedByDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objAddApprovedByDTO.SectionId = "";

            }

            dt = objAddApprovedByBLL.searchApprovedByEmpEntry(objAddApprovedByDTO);


            if (dt.Rows.Count > 0)
            {
                gvApprovedByEmpList.DataSource = dt;
                gvApprovedByEmpList.DataBind();

                int count = ((DataTable)gvApprovedByEmpList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvApprovedByEmpList.DataSource = dt;
                gvApprovedByEmpList.DataBind();
                int totalcolums = gvApprovedByEmpList.Rows[0].Cells.Count;
                gvApprovedByEmpList.Rows[0].Cells.Clear();
                gvApprovedByEmpList.Rows[0].Cells.Add(new TableCell());
                gvApprovedByEmpList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvApprovedByEmpList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
            }

        }
        public void searchApprovedByEmp()
        {

            AddApprovedByDTO objAddApprovedByDTO = new AddApprovedByDTO();
            AddApprovedByBLL objAddApprovedByBLL = new AddApprovedByBLL();

            DataTable dt = new DataTable();



            objAddApprovedByDTO.HeadOfficeId = strHeadOfficeId;
            objAddApprovedByDTO.BranchOfficeId = strBranchOfficeId;



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objAddApprovedByDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objAddApprovedByDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objAddApprovedByDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objAddApprovedByDTO.SectionId = "";

            }

            dt = objAddApprovedByBLL.searchApprovedByEmp(objAddApprovedByDTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
                // getFirstIndex();
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
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
            }

        }


        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }


        public void deleteApprovedEmployee(string strEmployeeId, string stHeadOfficeId, string strBranchOfficeid)
        {
            AddApprovedByDTO objAddApprovedByDTO = new AddApprovedByDTO();
            AddApprovedByBLL objAddApprovedByBLL = new AddApprovedByBLL();

            objAddApprovedByDTO.EmployeeId = strEmployeeId;


            objAddApprovedByDTO.UpdateBy = strEmployeeId;
            objAddApprovedByDTO.HeadOfficeId = strHeadOfficeId;
            objAddApprovedByDTO.BranchOfficeId = strBranchOfficeId;






            string strMsg = objAddApprovedByBLL.deleteApprovedEmployee(objAddApprovedByDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;
        }
        public void addApprovedByEmp()
        {
            
            AddApprovedByDTO objAddApprovedByDTO = new AddApprovedByDTO();
            AddApprovedByBLL objAddApprovedByBLL = new AddApprovedByBLL();
            string strMsg = "";
            string strCount = GridView1.Rows.Count.ToString();

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {

                            string strId = (row.FindControl("lblEmployeeId") as Label).Text;

                            objAddApprovedByDTO.EmployeeId = strId;

                            objAddApprovedByDTO.UpdateBy = strEmployeeId;
                            objAddApprovedByDTO.HeadOfficeId = strHeadOfficeId;
                            objAddApprovedByDTO.BranchOfficeId = strBranchOfficeId;


                            strMsg = objAddApprovedByBLL.addApprovedByEmp(objAddApprovedByDTO);

                        }

                    }


            }

            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }
        #endregion



        protected void btnShow_Click(object sender, EventArgs e)
        {
           
                    searchApprovedByEmpEntry();

              
            
        }



        #region "Grid View Functionality"
        protected void gvApprovedByEmpList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvApprovedByEmpList.PageIndex = e.NewPageIndex;
            searchApprovedByEmpEntry();
        }

        protected void gvApprovedByEmpList_OnSelectedIndexChanged(object sender, EventArgs e)
        {






        }




        protected void gvApprovedByEmpList_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }



        protected void gvApprovedByEmpList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {



            string strEmployeeId = gvApprovedByEmpList.Rows[e.RowIndex].Cells[0].Text;
            deleteApprovedEmployee(strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            searchApprovedByEmpEntry();




        }

        protected void gvApprovedByEmpList_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvApprovedByEmpList, "Select$" + e.Row.RowIndex);
            }
        }







        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }



        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        #endregion
        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string strEmployeeId = GridView1.SelectedRow.Cells[0].Text;

           
        }




        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
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

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvApprovedByEmpList, "Select$" + e.Row.RowIndex);
            }
        }






     


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
                     searchApprovedByEmp();
                     searchApprovedByEmpEntry();
                 
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvApprovedByEmpList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }

                else if (ddlUnitId.Text == " ")
                {

                    string strMsg = "Please Select Unit Name!!!";
                    MessageBox(strMsg);
                    ddlUnitId.Focus();
                    return;
                }


                else
                {
                    searchApprovedByEmpEntry();

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
                if (gvApprovedByEmpList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }

               
                else
                {
                    addApprovedByEmp();
                    searchApprovedByEmpEntry();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }
    }
}