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
    public partial class AddSubject : System.Web.UI.Page
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

                loadSession();
                getOfficeName();
                loadSubjectRecord();
                //lblHeadOfficeName.Text = Master.HeadOfficeName;
                //lblHeadOfficeAddress.Text = Master.HeadOfficeAddress;

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
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        public void loadSession()
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
            //strHeadOfficeName = Session["strHeadOfficeName"].ToString().Trim();
            //strBranchOfficeName = Session["strBranchOfficeName"].ToString().Trim();

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

        public void saveSubjectInfo()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();



            objEmployeeDTO.SubjectId = txtSubjectId.Text;
            objEmployeeDTO.SubjectName = txtSubjectName.Text;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.UpdateBy = strEmployeeId;


            string strMsg = objEmployeeBLL.saveSubjectInfo(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);



        }

        public void clearTextBox()
        {
            txtSubjectId.Text = string.Empty;
            txtSubjectName.Text = string.Empty;

        }


        public void loadSubjectRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadSubjectRecord();


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


        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                saveSubjectInfo();
                loadSubjectRecord();
            }

            catch (Exception ex)
            {

                throw new Exception("Error :" +ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }


        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadSubjectRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strSubjectId = gvUnit.SelectedRow.Cells[0].Text;
            string strSubjectName = gvUnit.SelectedRow.Cells[1].Text;


           txtSubjectId.Text = strSubjectId;
           txtSubjectName.Text = strSubjectName;


           string strMsg = "Row Index: " + strRowId + "\\nSubject ID: " + strSubjectId + "\\nSubject Name : " + strSubjectName;
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
            loadSubjectRecord();
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