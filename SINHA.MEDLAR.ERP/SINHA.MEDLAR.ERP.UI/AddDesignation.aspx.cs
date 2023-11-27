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
    public partial class AddDesignation : System.Web.UI.Page
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
                // loadDesignationRecord();
                GetDesigntionByName();
                getOfficeName();
                getGradeId();
                getDesignationId();
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
        public void getGradeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlGrade.DataSource = objLookUpBLL.getGradeId(strHeadOfficeId, strBranchOfficeId);

            ddlGrade.DataTextField = "GRADE_NO";
            ddlGrade.DataValueField = "GRADE_ID";

            ddlGrade.DataBind();
            if (ddlGrade.Items.Count > 0)
            {

                ddlGrade.SelectedIndex = 0;
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

        public void loadDesignationRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadDesignationRecord(strHeadOfficeId, strBranchOfficeId);


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

        public void GetDesigntionByName()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();

            dt = objLookUpBLL.GetDesigntionByName(txtDesignationNameSearch.Text);


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
            ddlSchedule.SelectedIndex= 0;
            ddlGrade.SelectedIndex = 0;
            ddlDesignationId.SelectedIndex = 0;
            txtDesignationId.Text = string.Empty;
            txtDesignationNameEng.Text = string.Empty;
            txtDesignationNameBng.Text = string.Empty;

        }

    

        public void saveDesignation()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            if (ddlSchedule.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.ScheduleId = ddlSchedule.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.ScheduleId = "";
            }
            if (ddlGrade.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.GradeId = ddlGrade.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.GradeId = "";
            }
            if (ddlDesignationId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.ProposedDesignationId = ddlDesignationId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.ProposedDesignationId = "";
            }
            objLookUpDTO.DesignationId = txtDesignationId.Text;
            objLookUpDTO.DesignationNameEng = txtDesignationNameEng.Text;
            objLookUpDTO.DesignationNameBng = txtDesignationNameBng.Text;



            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            objLookUpDTO.UpdateBy = strEmployeeId;


            string strMsg = objLookUpBLL.saveDesignation(objLookUpDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;
            if (strMsg == "INSERTED SUCCESSFULLY")
            {
                clear();
            }


        }

        #endregion

        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadDesignationRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strDesignationId = gvUnit.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strDesignationName = gvUnit.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strDesignationBng = gvUnit.SelectedRow.Cells[2].Text.Replace("&#168;", "¨").Replace("&#182;", "¶")
                    .Replace("&#214;", "Ö").Replace("&#221;", "Ý").Replace("&#247;", "÷").Replace("&#169;", "©").Replace("&#177;", "±")
                    .Replace("&#172;", "¬").Replace("&#170;", "ª").Replace("&#243;", "ó").Replace("&#164;", "¤").Replace("&#248;", "ø")
                    .Replace("&#250;", "ú").Replace("&#219;", "Û").Replace("&#194;", "Â").Replace("&#196;", "Ä").Replace("&#175;", "¯")
                    .Replace("&amp;", "&").Replace("&#236;", "ì").Replace("&#173;", "­­­­­­­").Replace("&#183;", "­­­­­­­·").Replace("&#191;&#191;&#191;&#191;&#191;&#191;&#191;&#191;", "­­­­­­­¿¿¿¿¿¿¿¿")
                    .Replace("&#191;", "¿");
            string strScheduleID = gvUnit.SelectedRow.Cells[3].Text.Replace("&nbsp;", " ");
            string strGradeId = gvUnit.SelectedRow.Cells[5].Text.Replace("&nbsp;", " ");
            string ProposedDesignationId= gvUnit.SelectedRow.Cells[7].Text.Replace("&nbsp;", " ");
            txtDesignationId.Text = strDesignationId;
            txtDesignationNameEng.Text = strDesignationName;
            txtDesignationNameBng.Text = strDesignationBng;

           //  ddlSchedule.Text = strScheduleID;
           ddlSchedule.SelectedValue = strScheduleID;
            ddlGrade.SelectedValue = strGradeId;
            ddlDesignationId.SelectedValue = ProposedDesignationId;

        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
            loadDesignationRecord();
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


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetDesigntionByName();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {           
                if(txtDesignationNameEng.Text == string.Empty)
                {
                    MessageBox("Please enter designation name.");
                    return;
                }

                saveDesignation();
                GetDesigntionByName();
            }

            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {

                clear();
            }

            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }

    }
}