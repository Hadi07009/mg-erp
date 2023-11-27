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
    public partial class AddLineInformation : System.Web.UI.Page
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
                loadLineRecord();
                getOfficeName();
                getProductionUnit();
                getSalaryUnitId();
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

        public void getProductionUnit()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            ddlProductionUnitId.DataSource = objLookUpBLL.getProductionUnit(strHeadOfficeId, strBranchOfficeId);

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

            LookUpDTO objLookUpDTO = new LookUpDTO();
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

        public void loadLineRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadLineRecord(strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
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
                lblMsg.Text = strMsg;

            }


        }

        public void clear()
        {

            txtLineName.Text = string.Empty;
            txtLineId.Text = string.Empty;
           
        }

        public void saveLineInformation()
        {

            LineDTO objLineDTO = new LineDTO();
            LineBLL objLineBLL = new LineBLL();

            objLineDTO.LineId = txtLineId.Text;
            objLineDTO.LineName = txtLineName.Text;

            if (ddlSalaryUnitId.SelectedValue.ToString() != " ")
            {
                objLineDTO.SalaryUnitId = ddlSalaryUnitId.SelectedValue.ToString();

            }
            else
            {

                objLineDTO.SalaryUnitId = "";

            }

            if (ddlProductionUnitId.SelectedValue.ToString() != " ")
            {
                objLineDTO.ProductionUnitId = ddlProductionUnitId.SelectedValue.ToString();

            }
            else
            {

                objLineDTO.ProductionUnitId = "";

            }


            if (chkActiveYn.Checked == true)
            {
                objLineDTO.ActvieYn = "Y";

            }
            else
            {
                objLineDTO.ActvieYn = "N";

            }



            objLineDTO.UpdateBy = strEmployeeId;
            objLineDTO.HeadOfficeId = strHeadOfficeId;
            objLineDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objLineBLL.saveLineInformation(objLineDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }


        #endregion

        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadLineRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strLineId = gvUnit.SelectedRow.Cells[0].Text;
            string strLineName = gvUnit.SelectedRow.Cells[1].Text;
            string strProductionUnitName = gvUnit.SelectedRow.Cells[2].Text;

            txtLineId.Text = strLineId;
            txtLineName.Text = strLineName;
         

            string strMsg = "Row Index: " + strRowId + "\\nLine ID: " + strLineId + "\\nLine Name : " + strLineName + "\\nProduction Unit Name : " + strProductionUnitName;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            MessageBox(strMsg);
        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
            loadLineRecord();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLineName.Text == string.Empty)
                {

                    string strMsg = "Please Enter Line Name!!!";
                    txtLineName.Focus();
                    MessageBox(strMsg);
                    return; 

                }
                else
                {
                    saveLineInformation();
                    loadLineRecord();
                }

            }

            catch (Exception ex)
            {

                throw new Exception("Error : " +ex.Message);
            }
        }

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


        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    //e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvUnit, "Select$" + e.Row.RowIndex);
        //    //e.Row.Attributes["style"] = "cursor:pointer";

        //    try
        //    {
        //        switch (e.Row.RowType)
        //        {
        //            case DataControlRowType.Header:
        //                //...
        //                break;
        //            case DataControlRowType.DataRow:
        //                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#93A3B0'; this.style.color='White'; this.style.cursor='pointer'");
        //                if (e.Row.RowState == DataControlRowState.Alternate)
        //                {
        //                    e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.AlternatingRowStyle.BackColor.ToKnownColor()));
        //                }
        //                else
        //                {
        //                    e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", gvUnit.RowStyle.BackColor.ToKnownColor()));
        //                }
        //                e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gvUnit, "Select$" + e.Row.RowIndex.ToString()));
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception("Error : " + ex.Message);
        //    }
        //}
        //}

        #endregion
    }
}