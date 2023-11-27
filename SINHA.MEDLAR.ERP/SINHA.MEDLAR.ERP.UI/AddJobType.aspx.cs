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
    public partial class AddJobType : System.Web.UI.Page
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
            loadJobTypeRecord();
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


        public void loadJobTypeRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadJobTypeRecord();


            if (dt.Rows.Count > 0)
            {
                gvJobType.DataSource = dt;
                gvJobType.DataBind();
                string strMsg = "TOTAL " + gvJobType.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvJobType.DataSource = dt;
                gvJobType.DataBind();
                int totalcolums = gvJobType.Rows[0].Cells.Count;
                gvJobType.Rows[0].Cells.Clear();
                gvJobType.Rows[0].Cells.Add(new TableCell());
                gvJobType.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvJobType.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void clear()
        {
            txtJobTypeId.Text = string.Empty;
            txtJobTypeName.Text = string.Empty;

        }

        public void saveJobTypeInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.JobTypeId = txtJobTypeId.Text;
            objLookUpDTO.JobTypeName = txtJobTypeName.Text;



            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            string strMsg = objLookUpBLL.saveJobTypeInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }

        public void clearTextBox()
        {
            txtJobTypeId.Text = "";
            txtJobTypeName.Text = "";

        }


        public void searchJobTypeEntry()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchJobTypeEntry(txtJobTypeId.Text, strHeadOfficeId, strBranchOfficeId);

            txtJobTypeName.Text = objLookUpDTO.JobTypeName;

        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtJobTypeName.Text == "")
                {

                    string strMsg = "Please Enter Job Type Name!!!";
                    txtJobTypeName.Focus();
                    MessageBox(strMsg);
                    return; 
                }
                else
                {
                    saveJobTypeInfo();
                    loadJobTypeRecord();
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

        protected void gvJobType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvJobType.PageIndex = e.NewPageIndex;
            loadJobTypeRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvJobType.SelectedRow.RowIndex;
            string strJobTypeId = gvJobType.SelectedRow.Cells[0].Text;
            string strJobTypeName = gvJobType.SelectedRow.Cells[1].Text;


            txtJobTypeId.Text = strJobTypeId;
            txtJobTypeName.Text = strJobTypeName;
        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvJobType_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvJobType.EditIndex = e.NewEditIndex;
            loadJobTypeRecord();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvJobType, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtJobTypeId.Text == "")
            {

                string strMsg = "Please Enter Job Type Id!!!";
                txtJobTypeId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {
                searchJobTypeEntry();
            }
        }

        #endregion
    }
}