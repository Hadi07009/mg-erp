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
    public partial class AddEidInfo : System.Web.UI.Page
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
               
                getMonthYearForSalary();
                getOfficeName();
                getEidId();
                loadEidRecord();
                lblMsg.Text = string.Empty;
            }

            if (IsPostBack)
            {

                loadSesscion();
            }


        }

        #region "Function"

        public void getMonthYearForSalary()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYear();

            txtEidYear.Text = objLookUpDTO.Year;
           

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

        public void getEidId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEidId.DataSource = objLookUpBLL.getEidId();

            ddlEidId.DataTextField = "EID_NAME";
            ddlEidId.DataValueField = "EID_TYPE_ID";

            ddlEidId.DataBind();
            if (ddlEidId.Items.Count > 0)
            {

                ddlEidId.SelectedIndex = 0;
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


        public void loadEidRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadEidRecord(txtEidYear.Text, strHeadOfficeId, strBranchOfficeId);

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
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }




        }

        public void clear()
        {
            txtEidId.Text = string.Empty;
            lblMsg.Text = string.Empty;
            txtEidYear.Text = string.Empty;
            dtpEidDate.Text = string.Empty;
            dtpTaxDate.Text = string.Empty;
        }

        public void saveEidInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.EidId = txtEidId.Text;
            if (ddlEidId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.EidTypeId = ddlEidId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.EidTypeId = "";

            }
           
            objLookUpDTO.EidYear = txtEidYear.Text;
            objLookUpDTO.EidDate = dtpEidDate.Text;
            objLookUpDTO.TaxDate = dtpTaxDate.Text;


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objLookUpBLL.saveEidInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }
        #endregion



       
    

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {

                throw new Exception("Error " +ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlEidId.Text == "0")
                {
                    string strMsg = "PLEASE SELECT EID NAME!!!";
                    MessageBox(strMsg);
                    lblMsg.Text = strMsg;
                    ddlEidId.Focus();
                }
                else if (txtEidYear.Text == "")
                {
                    string strMsg = "PLEASE ENTER EID YEAR!!!";
                    MessageBox(strMsg);
                    lblMsg.Text = strMsg;
                    txtEidYear.Focus();
                }
                else
                {

                    saveEidInfo();
                    loadEidRecord();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error " + ex.Message);
            }
        }



        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
            loadEidRecord();
        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {


            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strEidId = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strEidName = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEidYear = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strEidDate = gvEmployeeList.SelectedRow.Cells[3].Text;
            


            txtEidId.Text = strEidId;
            txtEidYear.Text = strEidYear;
            dtpEidDate.Text = strEidDate;
            



        }


        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{

            //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            //    string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            //    string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            //    string strEmployeeId = gvEmployeeList.SelectedRow.Cells[5].Text;
            //    string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            //    string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


            //    txtSL.Text = Convert.ToString(strRowId);
            //    txtCardNo.Text = strCardNo;
            //    txtEmployeeId.Text = strEmployeeId;
            //    txtEmployeeName.Text = strEmployeeName;
            //    txtDesignationName.Text = strDesignation;

            //    searchMiscEntryWorker();
            //    txtWorkingDay.Focus();

            //}
            //if (e.CommandName == "Edit")
            //{
            //}
            //if (e.CommandName == "Delete")
            //{

            //}

            //int selectedRowIndex = gvEmployeeList.SelectedRow.RowIndex;
            //gvEmployeeList.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }

        protected void gvEmployeeList_OnRowEditing(object sender, GridViewEditEventArgs e)
        {

        }


        //protected void gvEmployeeList_OnRowDataBound(GridViewRowEventArgs e)
        //{



        //    e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        //    e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");



        //}

        protected void gvEmployeeList_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {



            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);

            }


        }


        protected void gvEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
        {

        }




        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            loadEidRecord();
        }


    }
}