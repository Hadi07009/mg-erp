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
    public partial class AddThreadSupplier : System.Web.UI.Page
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
                loadTreadSupplierRecord();
                getOfficeName();

                lblMsg.Text = string.Empty;
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

        public void loadTreadSupplierRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadTreadSupplierRecord(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvTreadSupplier.DataSource = dt;
                gvTreadSupplier.DataBind();
                string strMsg = "TOTAL " + gvTreadSupplier.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvTreadSupplier.DataSource = dt;
                gvTreadSupplier.DataBind();
                int totalcolums = gvTreadSupplier.Rows[0].Cells.Count;
                gvTreadSupplier.Rows[0].Cells.Clear();
                gvTreadSupplier.Rows[0].Cells.Add(new TableCell());
                gvTreadSupplier.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvTreadSupplier.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }


        }

        public void clear()
        {

            txtTreadSupplieId.Text = "";
            txtTreadSupplierName.Text = "";

        }
        public void saveTreadSupplierInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.TreadSupplierId = txtTreadSupplieId.Text;
            objLookUpDTO.TreadSupplierName = txtTreadSupplierName.Text;

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;





            string strMsg = objLookUpBLL.saveTreadSupplierInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }


        public void deleteSupplierInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.TreadSupplierId = txtTreadSupplieId.Text;
         

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;





            string strMsg = objLookUpBLL.deleteSupplierInfo(objLookUpDTO);
            lblMsg.Text = strMsg;
            //MessageBox(strMsg);

        }

        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTreadSupplierName.Text == string.Empty)
            {
                string strMsg = "Please Enter Supplier Name!!!";
                txtTreadSupplierName.Focus();
                MessageBox(strMsg);
                return;


            }
            else
            {
                saveTreadSupplierInfo();
                loadTreadSupplierRecord();
                clear();


            }
        }


        #region "GridView Functionlity"

        protected void gvTreadSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTreadSupplier.PageIndex = e.NewPageIndex;
            
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvTreadSupplier.SelectedRow.RowIndex;
            string strCourseId = gvTreadSupplier.SelectedRow.Cells[0].Text;
            string strcourseName = gvTreadSupplier.SelectedRow.Cells[1].Text;


            txtTreadSupplieId.Text = strCourseId;
            txtTreadSupplierName.Text = strcourseName;


            //string strMsg = "Row Index: " + strRowId + "\\nSubject ID: " + strCourseId + "\\nSubject Name : " + strcourseName;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }
        protected void gvTreadSupplier_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvTreadSupplier_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTreadSupplier.EditIndex = e.NewEditIndex;
           
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvTreadSupplier, "Select$" + e.Row.RowIndex);
            }
        }




        #endregion

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtTreadSupplieId.Text == string.Empty)
            {
                string strMsg = "Please Enter Art ID!!!";
                txtTreadSupplieId.Focus();
                MessageBox(strMsg);
                return;


            }
            else
            {
                deleteSupplierInfo();
                loadTreadSupplierRecord();
                clear();


            }
        }

      



        
    }
}