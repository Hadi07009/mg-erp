using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.Web.Security;

using System.IO;

using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Data;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AddSize : System.Web.UI.Page
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
                loadSize();

                getOfficeName();
                lblMsg.Text = string.Empty;
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

        public void loadSize()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadSize();


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
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
                lblMsgRecord.Text = strMsg;

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

        public void clearTextBox()
        {
            txtSizeId.Text = string.Empty;
            txtSize.Text = string.Empty;

        }

        public void saveIESize()
        {

            WokerProcessDTO objWokerProcessDTO = new WokerProcessDTO();
            WorkerProcessBLL objWorkerProcessBLL = new WorkerProcessBLL();


            objWokerProcessDTO.SizeId = txtSizeId.Text;
            objWokerProcessDTO.SizeName = txtSize.Text;


            objWokerProcessDTO.UpdateBy = strEmployeeId;
            objWokerProcessDTO.HeadOfficeId = strHeadOfficeId;
            objWokerProcessDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objWorkerProcessBLL.saveIESize(objWokerProcessDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }


        #endregion
        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadSize();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strSizeId = gvUnit.SelectedRow.Cells[0].Text;
            string strSizeName = gvUnit.SelectedRow.Cells[1].Text;

            txtSizeId.Text = strSizeId;
            txtSize.Text = strSizeName;

            string strMsg = "Row Index: " + strRowId + "\\nProcess ID: " + strSizeId + "\\nProcess Name : " + strSizeName;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
            loadSize();
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





        #endregion
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSize.Text == string.Empty)
            {
                string strMsg = "Please Enter Size!!!";
                txtSize.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {

                saveIESize();
                loadSize();
                clearTextBox();
                txtSize.Focus();
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvUnit.Rows.Count == 0)
            {
                string strMsg = "Please click searh Button!!!";
                MessageBox(strMsg);
                btnSearch.Focus();
                return;
            }

            if (txtSizeId.Text == "")
            {

                string strMsg = "Please Click in the Gridview!!!";
                MessageBox(strMsg);
                return;


            }
            else
            {
                deleteWorkerSize();
                loadSize();
                clearTextBox();
            }
        }


        public void deleteWorkerSize()
        {
            WokerProcessDTO objWokerProcessDTO = new WokerProcessDTO();
            WorkerProcessBLL objWorkerProcessBLL = new WorkerProcessBLL();


            objWokerProcessDTO.ProcessId = txtSizeId.Text;

            objWokerProcessDTO.UpdateBy = strEmployeeId;
            objWokerProcessDTO.HeadOfficeId = strHeadOfficeId;
            objWokerProcessDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objWorkerProcessBLL.deleteWorkerSize(objWokerProcessDTO);
            MessageBox(strMsg);


        }

    }
}