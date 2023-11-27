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
    public partial class AddBloodGroup : System.Web.UI.Page
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

                loadBloodGroupRecord();
               
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


        public void loadBloodGroupRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadBloodGroupRecord();


            if (dt.Rows.Count > 0)
            {
                gvBloodGroup.DataSource = dt;
                gvBloodGroup.DataBind();
            }


        }

        public void clear()
        {
            txtBloodGroupId.Text = string.Empty;
            txtBloodGroupName.Text = string.Empty;

        }

        public void saveBloodGroupInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.BloodGroupId = txtBloodGroupId.Text;
            objLookUpDTO.BloodGroupName = txtBloodGroupName.Text;
            if (objLookUpDTO.BloodGroupName == "A POSITIVE" || objLookUpDTO.BloodGroupName == "A Positive" || objLookUpDTO.BloodGroupName == "A positive")
                objLookUpDTO.BloodGroupCode = "A+";
            else if (objLookUpDTO.BloodGroupName == "A NEGETIVE" || objLookUpDTO.BloodGroupName == "A Negative" || objLookUpDTO.BloodGroupName == "A negetive")
                objLookUpDTO.BloodGroupCode = "A-";
            else if (objLookUpDTO.BloodGroupName == "B POSITIVE" || objLookUpDTO.BloodGroupName == "B Positive" || objLookUpDTO.BloodGroupName == "B positive")
                objLookUpDTO.BloodGroupCode = "B+";
            else if (objLookUpDTO.BloodGroupName == "B NEGETIVE" || objLookUpDTO.BloodGroupName == "B Negative" || objLookUpDTO.BloodGroupName == "B negetive")
                objLookUpDTO.BloodGroupCode = "B-";
            else if (objLookUpDTO.BloodGroupName == "O POSITIVE" || objLookUpDTO.BloodGroupName == "O Positive" || objLookUpDTO.BloodGroupName == "O positive")
                objLookUpDTO.BloodGroupCode = "O+";
            else if (objLookUpDTO.BloodGroupName == "O NEGETIVE" || objLookUpDTO.BloodGroupName == "O Negative" || objLookUpDTO.BloodGroupName == "O negetive")
                objLookUpDTO.BloodGroupCode = "O-";
            else if (objLookUpDTO.BloodGroupName == "AB POSITIVE" || objLookUpDTO.BloodGroupName == "AB Positive" || objLookUpDTO.BloodGroupName == "AB positive")
                objLookUpDTO.BloodGroupCode = "AB+";
            else if (objLookUpDTO.BloodGroupName == "AB NEGETIVE" || objLookUpDTO.BloodGroupName == "AB Negative" || objLookUpDTO.BloodGroupName == "AB negetive")
                objLookUpDTO.BloodGroupCode = "AB-";
            else
                objLookUpDTO.BloodGroupCode = "";



            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            string strMsg = objLookUpBLL.saveBloodGroupInfo(objLookUpDTO);
            MessageBox(strMsg);
            

        }
        public void searchBloodGroupEntry()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchBloodGroupEntry(txtBloodGroupId.Text, strHeadOfficeId, strBranchOfficeId);

            txtBloodGroupName.Text = objLookUpDTO.BloodGroupName;

        }

        #endregion


        protected void gvBloodGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBloodGroup.PageIndex = e.NewPageIndex;
            loadBloodGroupRecord();
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvBloodGroup.SelectedRow.RowIndex;
            string strBloodGroupId = gvBloodGroup.SelectedRow.Cells[0].Text;
            string strBloodGroupName = gvBloodGroup.SelectedRow.Cells[2].Text;


            txtBloodGroupId.Text = strBloodGroupId;
            txtBloodGroupName.Text = strBloodGroupName;

        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
             if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvBloodGroup, "Select$" + e.Row.RowIndex);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchBloodGroupEntry();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtBloodGroupName.Text == string.Empty)
            {

                string strMsg = "Please Enter Blood Group Name!!!";
                MessageBox(strMsg);
                txtBloodGroupName.Focus();
                return;
            }
            else
            {
                saveBloodGroupInfo();
                loadBloodGroupRecord();
            }
        }
    }
}