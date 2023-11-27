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
    public partial class IncrementSetup : System.Web.UI.Page
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
        string strID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;
            }

            if (!IsPostBack)
            {


                //load DropDown List
                loadSesscion();
                getOfficeName();
            
                lblMsg.Text = string.Empty;
                getMonthYearForSalary();
                loadIncrementSetupRecord();

            }
            if (IsPostBack)
            {

                loadSesscion();
            }

        }


        #region "Function"

        public void loadIncrementSetupRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadIncrementSetupRecord(strHeadOfficeId, strBranchOfficeId);


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

        public void getMonthYearForSalary()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtIncrementYear.Text = objLookUpDTO.Year;


        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        public void IncrementSetupSave()
        {

            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();


           
           

            objIncrementDTO.Year = txtIncrementYear.Text;
           
           
            objIncrementDTO.EffectDate = dtpEffectDate.Text;
            objIncrementDTO.LimitDate = dtpLimitDate.Text;

            objIncrementDTO.UpdateBy = strEmployeeId;
            objIncrementDTO.HeadOfficeId = strHeadOfficeId;
            objIncrementDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objIncrementBLL.incrementSetupSave(objIncrementDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;


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

       

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                 if (txtIncrementYear.Text == string.Empty)
                {

                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtIncrementYear.Focus();
                    return; 
                }
                


                else if (dtpEffectDate.Text == string.Empty)
                {

                    string strMsg = "Please Enter Effect Date!!!";
                    MessageBox(strMsg);
                    dtpEffectDate.Focus();
                    return;
                }

                 else if (dtpLimitDate.Text == string.Empty)
                 {

                     string strMsg = "Please Enter Limit Date!!!";
                     MessageBox(strMsg);
                     dtpLimitDate.Focus();
                     return;
                 }


                else
                {
                    IncrementSetupSave();
                    loadIncrementSetupRecord();
                }

            }

            catch (Exception ex)
            {

                throw new Exception("Error : " +ex.Message);
            }
        }

        #region "Gridview Functionality"
        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadIncrementSetupRecord();
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

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strUnitId = gvUnit.SelectedRow.Cells[0].Text;
            string strUnitName = gvUnit.SelectedRow.Cells[1].Text;
            string strUnitNameBng = gvUnit.SelectedRow.Cells[2].Text;

            txtIncrementYear.Text = strUnitId;
            dtpEffectDate.Text = strUnitName;
            dtpLimitDate.Text = strUnitNameBng;



            //string strMsg = "Row Index: " + strRowId + "\\nUnit ID: " + strUnitId + "\\nUnit Name : " + strUnitName + "\\nUnit Name Bangla : " + strUnitNameBng;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }


        #endregion
    }
}