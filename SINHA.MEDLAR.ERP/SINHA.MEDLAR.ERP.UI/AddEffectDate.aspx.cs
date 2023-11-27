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
    public partial class AddEffectDate : System.Web.UI.Page
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
                loadWorkerPromotionEffectDate();
                getOfficeName();
                getMonthId();
                getMonthYearForSalary();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }

        }


        #region "Function"

        public void getMonthYearForSalary()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtYear.Text = objLookUpDTO.Year;


        }

        public void getMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSalaryMonthId.DataSource = objLookUpBLL.getMonthId();

            ddlSalaryMonthId.DataTextField = "MONTH_NAME";
            ddlSalaryMonthId.DataValueField = "MONTH_ID";

            ddlSalaryMonthId.DataBind();
            if (ddlSalaryMonthId.Items.Count > 0)
            {

                ddlSalaryMonthId.SelectedIndex = 0;
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


        public void loadWorkerPromotionEffectDate()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadWorkerPromotionEffectDate(strHeadOfficeId, strBranchOfficeId);

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
            txtYear.Text = "";
            getMonthId();
            dtpEffectDate.Text = string.Empty;
           
        }

        public void savePromotionEffectdate()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.Year = txtYear.Text;
            objLookUpDTO.Month = ddlSalaryMonthId.SelectedValue.ToString();
            objLookUpDTO.EffectDate = dtpEffectDate.Text;


            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objLookUpBLL.savePromotionEffectdate(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }
        #endregion



        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadWorkerPromotionEffectDate();
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
            string strEffectId = gvUnit.SelectedRow.Cells[1].Text;
            string strEffectDate = gvUnit.SelectedRow.Cells[3].Text;




            txtYear.Text = strEffectId;
            dtpEffectDate.Text = strEffectDate;
           // string strMsg = "Row Index: " + strRowId + "\\nID: " + strEffectId + "\\nEffect Date : " + strEffectDate ;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtYear.Text == "")
                {
                    string strMsg = "Please Enter Year!!!";
                    txtYear.Focus();
                    MessageBox(strMsg);
                    return;
                }

                else if (ddlSalaryMonthId.Text == "0")
                {
                    string strMsg = "Please Select Month!!!";
                    ddlSalaryMonthId.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (dtpEffectDate.Text == string.Empty)
                {

                    string strMsg = "Please Enter Effect Date!!!";
                    MessageBox(strMsg);
                    dtpEffectDate.Focus();
                    return;
                }
                else
                {

                    savePromotionEffectdate();
                    loadWorkerPromotionEffectDate();

                }
            }

            catch (Exception ex)
            {

                throw new Exception("Error : "+ex.Message);
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

                throw new Exception("Error : " + ex.Message);
            }
        }
    }
}