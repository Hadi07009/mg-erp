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
    public partial class AprovedEmployee : System.Web.UI.Page
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
                getMonthId();
                getUnitId();
                getSectionId();
                clearMsg();
                getOfficeName();
               
            }
            if (IsPostBack)
            {

                loadSesscion();
            }

            txtAprovedYear.Text = DateTime.Now.Year.ToString();
            txtAprovedYear.Attributes.Add("onkeypress", "return controlEnter('" + ddlMonthId.ClientID + "', event)");
            ddlMonthId.Attributes.Add("onkeypress", "return controlEnter('" + ddlUnitId.ClientID + "', event)");
            ddlUnitId.Attributes.Add("onkeypress", "return controlEnter('" + ddlSectionId.ClientID + "', event)");
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

        public void getMonthId()
        {
            AprovedEmployeeBLL objAprovedEmployeeBLL = new AprovedEmployeeBLL();

            ddlMonthId.DataSource = objAprovedEmployeeBLL.getMonthId(strHeadOfficeId, strBranchOfficeId);

            ddlMonthId.DataTextField = "MONTH_NAME";
            ddlMonthId.DataValueField = "MONTH_ID";

            ddlMonthId.DataBind();
            if (ddlMonthId.Items.Count > 0)
            {

                ddlMonthId.SelectedIndex = 0;
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


        public void searchAprovedEmployeeEntry()
        {

            AprovedEmployeeDTO objAprovedEmployeeDTO = new AprovedEmployeeDTO();
            AprovedEmployeeBLL objAprovedEmployeeBLL = new AprovedEmployeeBLL();

            DataTable dt = new DataTable();



            objAprovedEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objAprovedEmployeeDTO.BranchOfficeId = strBranchOfficeId;



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objAprovedEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objAprovedEmployeeDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objAprovedEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objAprovedEmployeeDTO.SectionId = "";

            }

            objAprovedEmployeeDTO.AprovedYear = txtAprovedYear.Text;

            if (ddlMonthId.SelectedValue.ToString() != " ")
            {
                objAprovedEmployeeDTO.AprovedMonth = ddlMonthId.SelectedValue.ToString();
            }
            else
            {
                objAprovedEmployeeDTO.AprovedMonth = "";

            }

            dt = objAprovedEmployeeBLL.searchAprovedEmployeeEntry(objAprovedEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvAprovedEmployeeList.DataSource = dt;
                gvAprovedEmployeeList.DataBind();

                int count = ((DataTable)gvAprovedEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvAprovedEmployeeList.DataSource = dt;
                gvAprovedEmployeeList.DataBind();
                int totalcolums = gvAprovedEmployeeList.Rows[0].Cells.Count;
                gvAprovedEmployeeList.Rows[0].Cells.Clear();
                gvAprovedEmployeeList.Rows[0].Cells.Add(new TableCell());
                gvAprovedEmployeeList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvAprovedEmployeeList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
            }

        }
        public void searchAprovedEmployee()
        {

            AprovedEmployeeDTO objAprovedEmployeeDTO = new AprovedEmployeeDTO();
            AprovedEmployeeBLL objAprovedEmployeeBLL = new AprovedEmployeeBLL();

            DataTable dt = new DataTable();



            objAprovedEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objAprovedEmployeeDTO.BranchOfficeId = strBranchOfficeId;



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objAprovedEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objAprovedEmployeeDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objAprovedEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objAprovedEmployeeDTO.SectionId = "";

            }



            objAprovedEmployeeDTO.AprovedYear = txtAprovedYear.Text;

            if (ddlMonthId.SelectedValue.ToString() != " ")
            {
                objAprovedEmployeeDTO.AprovedMonth = ddlMonthId.SelectedValue.ToString();
            }
            else
            {
                objAprovedEmployeeDTO.AprovedMonth = "";

            }

            dt = objAprovedEmployeeBLL.searchAprovedEmployee(objAprovedEmployeeDTO);


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
 
        public void addAprovedEmployee()
        {

            AprovedEmployeeDTO objAprovedEmployeeDTO = new AprovedEmployeeDTO();
            AprovedEmployeeBLL objAprovedEmployeeBLL = new AprovedEmployeeBLL();
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

                            objAprovedEmployeeDTO.EmployeeId = strId;


                            if (ddlUnitId.SelectedValue.ToString() != " ")
                            {
                                objAprovedEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                            }
                            else
                            {
                                objAprovedEmployeeDTO.UnitId = "";

                            }
                            if (ddlSectionId.SelectedValue.ToString() != " ")
                            {
                                objAprovedEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                            }
                            else
                            {

                                objAprovedEmployeeDTO.SectionId = "";
                            }

                            objAprovedEmployeeDTO.AprovedYear = txtAprovedYear.Text;

                            if (ddlMonthId.SelectedValue.ToString() != " ")
                            {
                                objAprovedEmployeeDTO.AprovedMonth = ddlMonthId.SelectedValue.ToString();
                            }
                            else
                            {
                                objAprovedEmployeeDTO.AprovedMonth = "";

                            }

                            objAprovedEmployeeDTO.UpdateBy = strEmployeeId;
                            objAprovedEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                            objAprovedEmployeeDTO.BranchOfficeId = strBranchOfficeId;


                            strMsg = objAprovedEmployeeBLL.addAprovedEmployee(objAprovedEmployeeDTO);
                           

                           

                        }

                    }


            }

            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }
        #endregion



        protected void btnShow_Click(object sender, EventArgs e)
        {
             try
            {
                if (ddlMonthId.Text == "0")
                {

                    string strMsg = "Please Select Month Name!!!";
                    MessageBox(strMsg);
                    ddlMonthId.Focus();
                    return;
                }

                else if (txtAprovedYear.Text == " ")
                {

                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtAprovedYear.Focus();
                    return;
                }

                else
                {

                    searchAprovedEmployeeEntry();

                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error : "+ex.Message);

            }
            
        }



        #region "Grid View Functionality"
        protected void gvAprovedEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAprovedEmployeeList.PageIndex = e.NewPageIndex;
            searchAprovedEmployeeEntry();
        }

        protected void gvAprovedEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {






        }




        protected void gvAprovedEmployeeList_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }
        protected void gvAprovedEmployeeList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int stor_id = Convert.ToInt32(gvAprovedEmployeeList.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"].ToString());
            string strEmpId = Convert.ToString(stor_id);


            string strAprovedYear = txtAprovedYear.Text;


            string strAprovedMonth = "";
            if (ddlMonthId.SelectedValue.ToString() != " ")
            {
                strAprovedMonth = ddlMonthId.SelectedValue.ToString();
            }
            else
            {
                strAprovedMonth = "";

            }



            deleteAprovedEmployeeRecord(strEmpId, strAprovedYear, strAprovedMonth);

        }

        public void deleteAprovedEmployeeRecord(string strEmpId, string strAprovedYear, string strAprovedMonth)
        {


            AprovedEmployeeDTO objAprovedEmployeeDTO = new AprovedEmployeeDTO();
            AprovedEmployeeBLL objAprovedEmployeetBLL = new AprovedEmployeeBLL();


            objAprovedEmployeeDTO.EmpId = strEmpId;
            objAprovedEmployeeDTO.AprovedYear = strAprovedYear;
            objAprovedEmployeeDTO.AprovedMonth = strAprovedMonth;

            objAprovedEmployeeDTO.UpdateBy = strEmployeeId;
            objAprovedEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objAprovedEmployeeDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objAprovedEmployeetBLL.deleteAprovedEmployeeRecord(objAprovedEmployeeDTO);
            MessageBox(strMsg);

            searchAprovedEmployeeEntry();

        }

        protected void gvAprovedEmployeeList_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }

        protected void gvAprovedEmployeeList_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
            //    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

            //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvAprovedEmployeeList, "Select$" + e.Row.RowIndex);
            //}
        }


        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }


        protected void gvAprovedEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
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

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvAprovedEmployeeList, "Select$" + e.Row.RowIndex);
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
                if (ddlMonthId.Text == "0")
                {

                    string strMsg = "Please Select Month Name!!!";
                    MessageBox(strMsg);
                    ddlMonthId.Focus();
                    return;
                }

                else if (txtAprovedYear.Text == " ")
                {

                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtAprovedYear.Focus();
                    return;
                }

                else
                {

                    searchAprovedEmployee();
                    searchAprovedEmployeeEntry();
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
                if (gvAprovedEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else if (txtAprovedYear.Text == " ")
                {

                    string strMsg = "Please Enter Aproved Year !!!";
                    MessageBox(strMsg);
                    txtAprovedYear.Focus();
                    return;
                }

                else if (ddlMonthId.Text == "0")
                {

                    string strMsg = "Please Select Month !!!";
                    MessageBox(strMsg);
                    ddlMonthId.Focus();
                    return;
                }


                else
                {
                    addAprovedEmployee();
                    searchAprovedEmployeeEntry();

                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void gvAprovedEmployeeList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }


    }
}