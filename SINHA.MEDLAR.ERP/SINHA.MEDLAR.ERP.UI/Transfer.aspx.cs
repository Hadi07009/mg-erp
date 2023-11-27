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
    public partial class EmployeeTransfer : System.Web.UI.Page
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
                getDepartmentId();
                getUnitId();
                getSectionId();
                getDesignationId();
                getCatagoryId();
                getBranchOfficeId();
                //loadEmployeeTransferEntry();
                getEmployeeId();
            }
           
            if (IsPostBack)
            {

                loadSesscion();
            }
           
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

        public void getEmployeeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlApprovedById.DataSource = objLookUpBLL.getEmployeeId();

            ddlApprovedById.DataTextField = "EMPLOYEE_NAME";
            ddlApprovedById.DataValueField = "employee_id";

            ddlApprovedById.DataBind();
            if (ddlApprovedById.Items.Count > 0)
            {

                ddlApprovedById.SelectedIndex = 0;
            }

        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void loadEmployeeTransferEntry()
        {
            TransferDTO objEmployeeTransferDTO = new TransferDTO();
            TransferBLL objEmployeeTransferBLL = new TransferBLL();

            DataTable dt = new DataTable();
            dt = objEmployeeTransferBLL.loadEmployeeTransferEntry();

            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
            }


        }
      
        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadEmployeeTransferEntry();
        }
        protected void gvUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strUnitId = gvUnit.SelectedRow.RowIndex;
            string strUnitName = gvUnit.SelectedRow.Cells[0].Text;
            string strUnitNameBangla = gvUnit.SelectedRow.Cells[1].Text;



            string strMsg = "Row Index: " + strUnitId + "\\nUnit Name: " + strUnitName + "\\nUnit Name Bangla: " + strUnitNameBangla;
            MessageBox(strMsg);
        }
        //protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        //{
        //    e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        //    e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        //}

        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvUnit, "Edit$" + e.Row.RowIndex);
        //        e.Row.Attributes["style"] = "cursor:pointer";
        //    }
        //}

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvUnit, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";

                try
                {
                    switch (e.Row.RowType)
                    {
                        case DataControlRowType.Header:
                            //...
                            break;
                        case DataControlRowType.DataRow:
                            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#93A3B0'; this.style.color='White'; this.style.cursor='pointer'");
                            if (e.Row.RowState == DataControlRowState.Alternate)
                            {
                                e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.AlternatingRowStyle.BackColor.ToKnownColor()));
                            }
                            else
                            {
                                e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.RowStyle.BackColor.ToKnownColor()));
                            }
                            e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gvUnit, "Select$" + e.Row.RowIndex.ToString()));
                            break;
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }
            }
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

        public void clear()
        {
            txtEmployeeId.Text = string.Empty;
            dtpTransferDate.Text = string.Empty;
            dtpEffectiveDate.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            


        }

        public void saveEmployeeTransfer()
        {
            TransferDTO objEmployeeTransferDTO = new TransferDTO();
            TransferBLL objEmployeeTransferBLL = new TransferBLL();


            objEmployeeTransferDTO.EmployeeId = txtEmployeeId.Text;
           
            objEmployeeTransferDTO.HeadOfficeId = ddlBranchOfficeID.SelectedValue.ToString();
            objEmployeeTransferDTO.DepartmentId = ddlDepartmentId.SelectedValue.ToString();
            objEmployeeTransferDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            objEmployeeTransferDTO.DesignationId = ddlDesignationId.SelectedValue.ToString();
            objEmployeeTransferDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            objEmployeeTransferDTO.CatagoryId = ddlCatagoryId.SelectedValue.ToString();
            objEmployeeTransferDTO.TransferDate = dtpTransferDate.Text;
            objEmployeeTransferDTO.EffectiveDate = dtpEffectiveDate.Text;
            objEmployeeTransferDTO.ApprovedBy = ddlApprovedById.SelectedValue.ToString();


            objEmployeeTransferDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeTransferDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeTransferDTO.UpdateBy = strEmployeeId;


            string strMsg = objEmployeeTransferBLL.saveEmployeeTransfer(objEmployeeTransferDTO);
            MessageBox(strMsg);


        }
        #endregion

        #region "LoadCombo"
        public void getBranchOfficeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBranchOfficeID.DataSource = objLookUpBLL.getBranchOfficeId(strHeadOfficeId);

            ddlBranchOfficeID.DataTextField = "HEAD_OFFICE_NAME";
            ddlBranchOfficeID.DataValueField = "HEAD_OFFICE_ID";

            ddlBranchOfficeID.DataBind();
            if (ddlBranchOfficeID.Items.Count > 0)
            {

                ddlBranchOfficeID.SelectedIndex = 0;
            }
        }

        public void getDepartmentId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlDepartmentId.DataSource = objLookUpBLL.getDepartmentId();

            ddlDepartmentId.DataTextField = "DEPARTMENT_NAME";
            ddlDepartmentId.DataValueField = "DEPARTMENT_ID";

            ddlDepartmentId.DataBind();
            if (ddlDepartmentId.Items.Count > 0)
            {

                ddlDepartmentId.SelectedIndex = 0;
            }

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
                ddlSectionId.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId );

                ddlSectionId.DataTextField = "SECTION_NAME";
                ddlSectionId.DataValueField = "SECTION_ID";

                ddlSectionId.DataBind();
                if (ddlSectionId.Items.Count > 0)
                {

                    ddlSectionId.SelectedIndex = 0;
                }

          
        }

        public void getDesignationId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlDesignationId.DataSource = objLookUpBLL.getDesignationId(strHeadOfficeId, strBranchOfficeId);

            ddlDesignationId.DataTextField = "DESIGNATION_NAME";
            ddlDesignationId.DataValueField = "DESIGNATION_ID";

            ddlDesignationId.DataBind();
            if (ddlDesignationId.Items.Count > 0)
            {

                ddlDesignationId.SelectedIndex = 0;
            }

        }

        public void getCatagoryId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlCatagoryId.DataSource = objLookUpBLL.getCatagoryId();

            ddlCatagoryId.DataTextField = "CATAGORY_NAME";
            ddlCatagoryId.DataValueField = "CATAGORY_ID";

            ddlCatagoryId.DataBind();
            if (ddlCatagoryId.Items.Count > 0)
            {

                ddlCatagoryId.SelectedIndex = 0;
            }

        }
        #endregion
        


        
      

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                saveEmployeeTransfer();
            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}