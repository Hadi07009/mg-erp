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
    public partial class ArrearSetup : System.Web.UI.Page
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
                loadSesscion();
                loadArrearRecord();
                getOfficeName();
                BindMonth();
                lblMsg.Text = string.Empty;
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
        }


        #region "FUNCTION"
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

      
        public void loadArrearRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadArrearRecord(strHeadOfficeId, strBranchOfficeId);


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


        public void getFromMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlFromMonthId.DataSource = objLookUpBLL.getFromMonthId();

            ddlFromMonthId.DataTextField = "MONTH_NAME";
            ddlFromMonthId.DataValueField = "MONTH_ID";

            ddlFromMonthId.DataBind();
            if (ddlFromMonthId.Items.Count > 0)
            {

                ddlFromMonthId.SelectedIndex = 0;
            }
        }


        public void getToMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlToMonthId.DataSource = objLookUpBLL.getFromMonthId();

            ddlToMonthId.DataTextField = "MONTH_NAME";
            ddlToMonthId.DataValueField = "MONTH_ID";

            ddlToMonthId.DataBind();
            if (ddlToMonthId.Items.Count > 0)
            {

                ddlToMonthId.SelectedIndex = 0;
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


        public void getMonthYearForSalary()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtArrearYear.Text = objLookUpDTO.Year;


        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public string saveArrearSetup()
        {
            ArrearDTO objArrearDTO = new ArrearDTO();
            ArrearBLL objArrearBLL = new ArrearBLL();

            objArrearDTO.Year = txtArrearYear.Text;
            if (ddlFromMonthId.SelectedValue.ToString() != " ")
            {
                objArrearDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
            }
            else
            {
                objArrearDTO.FromMonthId = "";
            }
            if (ddlToMonthId.SelectedValue.ToString() != " ")
            {
                objArrearDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
            }
            else
            {
                objArrearDTO.ToMonthId = "";
            }


            objArrearDTO.EffectDate = txtEffectDate.Text;
            objArrearDTO.LimitDate = txtLimitDate.Text;

            if(chkCarryPreArrear.Checked)
                objArrearDTO.CarryPreArrear = "Y";
            else
                objArrearDTO.CarryPreArrear = "N";

            objArrearDTO.HeadOfficeId = strHeadOfficeId;
            objArrearDTO.BranchOfficeId = strBranchOfficeId;
            objArrearDTO.UpdateBy = strEmployeeId;

            string msg = objArrearBLL.saveArrearSetup(objArrearDTO);
            return msg;
        }

        private void Clear()
        {
            txtArrearYear.Text = string.Empty;
            ddlArrearFromMonthTo.SelectedValue = "0";
            ddlArrearToMonthTo.SelectedValue = "0";
            txtEffectDate.Text = string.Empty;
            txtLimitDate.Text = string.Empty;
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;

                if(string.IsNullOrEmpty(txtArrearYear.Text))
                {
                    msg = "Please Enter Arrear Year";
                    txtArrearYear.Focus();
                    MessageBox(msg);
                    return;
                }

                if (ddlFromMonthId.SelectedItem.Value == "0")
                {
                    msg = "Please Select From Month";
                    ddlFromMonthId.Focus();
                    MessageBox(msg);
                    return;
                }

                if (ddlToMonthId.SelectedItem.Value == "0")
                {
                    msg = "Please Select To Month";
                    ddlToMonthId.Focus();
                    MessageBox(msg);
                    return;
                }

                if (string.IsNullOrEmpty(txtEffectDate.Text))
                {
                    msg = "Please Enter Effect Date";
                    txtEffectDate.Focus();
                    MessageBox(msg);
                    return;
                }

                if (string.IsNullOrEmpty(txtLimitDate.Text))
                {
                    msg = "Please Enter Limit Date";
                    txtLimitDate.Focus();
                    MessageBox(msg);
                    return;
                }

              msg = saveArrearSetup();

              if (msg == "NOK")
              {
                  Clear();
              }
              MessageBox(msg);
              lblMsg.Text = msg;
              loadArrearRecord();
            }

            catch (Exception ex)
            {
            }
        }


        #region "Grid View Functionality"
        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadArrearRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            hfGridRowSelected.Value = string.Empty;
            hfGridRowSelected.Value = "selected";

            int strRowId = gvUnit.SelectedRow.RowIndex;
            string arrearYear = gvUnit.SelectedRow.Cells[1].Text;
            string fromMonthName = gvUnit.SelectedRow.Cells[2].Text;
            string toMonthName = gvUnit.SelectedRow.Cells[3].Text;

            string effectDate = gvUnit.SelectedRow.Cells[4].Text;
            string limitDate = gvUnit.SelectedRow.Cells[5].Text;
            string carryPreArrear = gvUnit.SelectedRow.Cells[6].Text;

            string fromMonthId = gvUnit.SelectedRow.Cells[7].Text;
            string toMonthId = gvUnit.SelectedRow.Cells[8].Text;

            txtArrearYear.Text = arrearYear;
            ddlFromMonthId.SelectedValue = fromMonthId;
            ddlToMonthId.SelectedValue = toMonthId;
            txtEffectDate.Text = effectDate;
            txtLimitDate.Text = limitDate;

            if (carryPreArrear == "Yes")
                chkCarryPreArrear.Checked = true;
            else
                chkCarryPreArrear.Checked = false;

            string strMsg = "Row Index: " + strRowId + "\\nArrear Year : " + arrearYear + "\\nFrom Month  : " + fromMonthName + "\\nTo Month  : " + toMonthName;
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
            loadArrearRecord();
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


        #endregion

        private void BindMonth()
        {
            DataTable data = GetMonth();
            //1
            ddlFromMonthId.DataSource = data;
            ddlFromMonthId.DataTextField = "MONTH_NAME";
            ddlFromMonthId.DataValueField = "MONTH_ID";

            ddlFromMonthId.DataBind();
            if (ddlFromMonthId.Items.Count > 0)
            {
                ddlFromMonthId.SelectedIndex = 0;
            }

            //2
            ddlToMonthId.DataSource = data;
            ddlToMonthId.DataTextField = "MONTH_NAME";
            ddlToMonthId.DataValueField = "MONTH_ID";

            ddlToMonthId.DataBind();
            if (ddlToMonthId.Items.Count > 0)
            {
                ddlToMonthId.SelectedIndex = 0;
            }

            //3
            ddlArrearFromMonthTo.DataSource = data;
            ddlArrearFromMonthTo.DataTextField = "MONTH_NAME";
            ddlArrearFromMonthTo.DataValueField = "MONTH_ID";

            ddlArrearFromMonthTo.DataBind();
            if (ddlArrearFromMonthTo.Items.Count > 0)
            {
                ddlArrearFromMonthTo.SelectedIndex = 0;
            }

            //4
            ddlArrearToMonthTo.DataSource = data;
            ddlArrearToMonthTo.DataTextField = "MONTH_NAME";
            ddlArrearToMonthTo.DataValueField = "MONTH_ID";

            ddlArrearToMonthTo.DataBind();
            if (ddlArrearToMonthTo.Items.Count > 0)
            {
                ddlArrearToMonthTo.SelectedIndex = 0;
            }
        }

        public DataTable GetMonth()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            return objLookUpBLL.getFromMonthId();
        }

        protected void btnDiscardUnpaidArrear_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;

                if (txtArrearYear.Text == "")
                {
                    msg = "Arrear Year Empty";
                    MessageBox(msg);
                    txtArrearYear.Focus();
                    return;
                }
                if (ddlFromMonthId.SelectedValue.ToString() == "0")
                {
                    msg = "From Month Empty";
                    MessageBox(msg);
                    ddlFromMonthId.Focus();
                    return;
                }
                if (ddlToMonthId.SelectedValue.ToString() == "0")
                {
                    msg = "To Month Empty";
                    MessageBox(msg);
                    ddlToMonthId.Focus();
                    return;
                }
                if (hfGridRowSelected.Value == string.Empty)
                {
                    msg = "Please Select One from Grid";
                    MessageBox(msg);
                    return;
                }

                msg = DiscardUnpaidIncrementArrear();
                MessageBox(msg);
            }
            catch(Exception ex)
            {
            }
        }

        protected void btnSyncAdvance_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;
                if (txtArrearYear.Text == "")
                {
                    msg = "Arrear Year Empty";
                    MessageBox(msg);
                    txtArrearYear.Focus();
                    return;
                }
                if (ddlFromMonthId.SelectedValue.ToString() == "0")
                {
                    msg = "From Month Empty";
                    MessageBox(msg);
                    ddlFromMonthId.Focus();
                    return;
                }
                if (ddlToMonthId.SelectedValue.ToString() == "0")
                {
                    msg = "To Month Empty";
                    MessageBox(msg);
                    ddlToMonthId.Focus();
                    return;
                }

                if (txtArrearYearTo.Text == "")
                {
                    msg = "Right Side- To Month Empty";
                    MessageBox(msg);
                    txtArrearYearTo.Focus();
                    return;
                }
                if (ddlArrearFromMonthTo.SelectedValue.ToString() == "0")
                {
                    msg = "Right Side- To Month Empty";
                    MessageBox(msg);
                    ddlArrearFromMonthTo.Focus();
                    return;
                }
                if (ddlArrearToMonthTo.SelectedValue.ToString() == "0")
                {
                    msg = "Right Side- To Month Empty";
                    MessageBox(msg);
                    ddlArrearToMonthTo.Focus();
                    return;
                }

                if (hfGridRowSelected.Value == string.Empty)
                {
                    msg = "Please Select One from Grid";
                    MessageBox(msg);
                    return;
                }

                msg = SyncAdvanceWithIncrementArrear();
                //if(!string.IsNullOrEmpty(msg))
                MessageBox(msg);
            }
            catch(Exception ex)
            {
            }
        }

        public string DiscardUnpaidIncrementArrear()
        {
            ArrearDTO objArrearDTO = new ArrearDTO();
            ArrearBLL objArrearBLL = new ArrearBLL();

            objArrearDTO.Year = txtArrearYear.Text;

            if (ddlFromMonthId.SelectedValue.ToString() != " ")
            {
                objArrearDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
            }
            else
            {
                objArrearDTO.FromMonthId = "";
            }
            
            if (ddlToMonthId.SelectedValue.ToString() != " ")
            {
                objArrearDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
            }
            else
            {
                objArrearDTO.ToMonthId = "";
            }

            objArrearDTO.HeadOfficeId = strHeadOfficeId;
            objArrearDTO.BranchOfficeId = strBranchOfficeId;
            objArrearDTO.UpdateBy = strEmployeeId;

            string msg = objArrearBLL.DiscardUnpaidIncrementArrear(objArrearDTO);
            return msg;
        }
        
        public string SyncAdvanceWithIncrementArrear()
        {
            ArrearDTO objArrearDTO = new ArrearDTO();
            ArrearBLL objArrearBLL = new ArrearBLL();

            objArrearDTO.Year = txtArrearYear.Text;

            if (ddlFromMonthId.SelectedValue.ToString() != " ")
            {
                objArrearDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
            }
            else
            {
                objArrearDTO.FromMonthId = "";
            }

            if (ddlToMonthId.SelectedValue.ToString() != " ")
            {
                objArrearDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
            }
            else
            {
                objArrearDTO.ToMonthId = "";
            }


            //
            objArrearDTO.ArrearYearTo = txtArrearYearTo.Text;

            if (ddlArrearFromMonthTo.SelectedValue.ToString() != " ")
            {
                objArrearDTO.ArrearFromMonthTo = ddlArrearFromMonthTo.SelectedValue.ToString();
            }
            else
            {
                objArrearDTO.ArrearFromMonthTo = "";
            }

            if (ddlArrearToMonthTo.SelectedValue.ToString() != " ")
            {
                objArrearDTO.ArrearToMonthTo = ddlArrearToMonthTo.SelectedValue.ToString();
            }
            else
            {
                objArrearDTO.ArrearToMonthTo = "";
            }
            
            objArrearDTO.HeadOfficeId = strHeadOfficeId;
            objArrearDTO.BranchOfficeId = strBranchOfficeId;
            objArrearDTO.UpdateBy = strEmployeeId;

            string msg = objArrearBLL.SyncAdvanceWithIncrementArrear(objArrearDTO);
            return msg;
        }

        protected void txtArrearYear_TextChanged(object sender, EventArgs e)
        {
            hfGridRowSelected.Value = string.Empty;
        }

        protected void ddlFromMonthId_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfGridRowSelected.Value = string.Empty;
        }

        protected void ddlToMonthId_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfGridRowSelected.Value = string.Empty;
        }
    }
}