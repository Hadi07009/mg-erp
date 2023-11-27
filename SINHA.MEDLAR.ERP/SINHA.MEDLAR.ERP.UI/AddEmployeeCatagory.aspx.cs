using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AddEmployeeCatagory : System.Web.UI.Page
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
                Response.Redirect("Login.aspx", true );
                return;

            }

            if (!IsPostBack)
            {

                loadEmployeeCatagoryRecord();
                lblMsg.Text = "";
            }


            if (IsPostBack)
            {

                loadSesscion();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        #region "Function"

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


        public void loadEmployeeCatagoryRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadEmployeeCatagoryRecord();


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
            }


        }

        public void clear()
        {

            txtCatagoryId.Text = string.Empty;
            txtCatagoryNameEng.Text = string.Empty;
            txtCatagoryNameBng.Text = string.Empty;
        }

        public void saveEmployeeCatagory()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.CatagoryId = txtCatagoryId.Text;
            objLookUpDTO.CatagoryNameBng = txtCatagoryNameBng.Text;
            objLookUpDTO.CatagoryNameEng = txtCatagoryNameEng.Text;

            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            objLookUpDTO.UpdateBy = strEmployeeId;

            string strMsg = objLookUpBLL.saveEmployeeCatagory(objLookUpDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;



        }
        #endregion


        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadEmployeeCatagoryRecord();
        }

        protected void gvUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strUnitId = gvUnit.SelectedRow.RowIndex;
            string strUnitName = gvUnit.SelectedRow.Cells[0].Text;
            string strUnitNameBangla = gvUnit.SelectedRow.Cells[1].Text;



            //string strMsg = "Row Index: " + strUnitId + "\\nUnit Name: " + strUnitName + "\\nUnit Name Bangla: " + strUnitNameBangla;
            //MessageBox(strMsg);
        }
        //protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        //{
        //    e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        //    e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        //}


        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvUnit, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                saveEmployeeCatagory();
                loadEmployeeCatagoryRecord();
            }

            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }


    }
}