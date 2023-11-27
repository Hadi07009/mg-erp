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
    public partial class Roster : System.Web.UI.Page
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
            dtpEffectDate.Focus();
            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;
            }
            if (!IsPostBack)
            {
                loadSesscion();
                getOfficeName();
                LoadRoster();
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


        public void LoadRoster()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.LoadRoster(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvRoster.DataSource = dt;
                gvRoster.DataBind();
                string strMsg = "TOTAL " + gvRoster.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvRoster.DataSource = dt;
                gvRoster.DataBind();
                int totalcolums = gvRoster.Rows[0].Cells.Count;
                gvRoster.Rows[0].Cells.Clear();
                gvRoster.Rows[0].Cells.Add(new TableCell());
                gvRoster.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvRoster.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
        }
        public void SaveRoster()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            if(!string.IsNullOrEmpty(txtRosterId.Text))
            objLookUpDTO.RosterId = Convert.ToDecimal(txtRosterId.Text);
            objLookUpDTO.EffectDate = dtpEffectDate.Text;

            if (chkAcftiveYn.Checked == true)
            {
                objLookUpDTO.ActiveYn = "Y";
            }
            else
            {
                objLookUpDTO.ActiveYn = "N";
            }

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.SaveRoster(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }

        public void clearTextBox()
        {
            txtRosterId.Text = "";
            dtpEffectDate.Text = "";
            chkAcftiveYn.Checked = false;
        }

        #endregion

        #region "GridView Functionlity"

        protected void gvRoster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRoster.PageIndex = e.NewPageIndex;
            LoadRoster();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvRoster.SelectedRow.RowIndex;
            string RosterId = gvRoster.SelectedRow.Cells[0].Text;
            string EffectDate = gvRoster.SelectedRow.Cells[1].Text;
            string ActiveYn = gvRoster.SelectedRow.Cells[2].Text;

          
            txtRosterId.Text = RosterId;
            dtpEffectDate.Text = EffectDate;
           if(ActiveYn=="Y")
            
                chkAcftiveYn.Checked = true;          
           else
                chkAcftiveYn.Checked = false;
        }
        protected void gvRoster_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvRoster_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvRoster.EditIndex = e.NewEditIndex;
            LoadRoster();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            }
        }
        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpEffectDate.Text == "")
            {

                string strMsg = "Please Set Effect Date!!!";
                dtpEffectDate.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {
                SaveRoster();
                LoadRoster();
                clearTextBox();
            }
        }
    }
}