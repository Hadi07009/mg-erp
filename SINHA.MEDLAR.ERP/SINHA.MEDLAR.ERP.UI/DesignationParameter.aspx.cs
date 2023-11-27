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
    public partial class DesignationParameter : System.Web.UI.Page
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
                GetDesignationParameter();
                getOfficeName();
                getDesignationId();
            }

            if (IsPostBack)
            {
                loadSesscion();
            }
            txtTiffinCrossOverTime.Attributes.Add("onkeypress", "return controlEnter('" + txtTiffinCrossOverTime.ClientID + "', event)");
            ddlDesignationId.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtTiffinCrossOverTime.Text == string.Empty)
                {
                    string strMsg = "Please Enter  Year";
                    txtTiffinCrossOverTime.Focus();
                    MessageBox(strMsg);
                    return;
                }

              
                else if (ddlDesignationId.Text == " ")
                {
                    string strMsg = "Please Select Designation";
                    ddlDesignationId.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else
                {
                    SaveDesignationParameter();
                    GetDesignationParameter();                  
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
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

        #region "Function"

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


        public void GetDesignationParameter()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            DataTable dt = new DataTable();
            
         

            if (ddlDesignationId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.DesignationId = ddlDesignationId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.DesignationId = "";
            }
            objLookUpDTO.TiffinCrossOverTime = txtTiffinCrossOverTime.Text;
            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;

            dt = objLookUpBLL.GetDesignationParameter(objLookUpDTO);

            gvDesignationParam.Columns[1].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvDesignationParam.DataSource = dt;
                gvDesignationParam.DataBind();
                gvDesignationParam.Columns[1].Visible = false;
                string strMsg = "TOTAL " + gvDesignationParam.Rows.Count + " RECORD FOUND";
             
                lblMsg.Text = strMsg;
                
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvDesignationParam.DataSource = dt;
                gvDesignationParam.DataBind();
                gvDesignationParam.Columns[1].Visible = false;
                int totalcolums = gvDesignationParam.Rows[0].Cells.Count;
                gvDesignationParam.Rows[0].Cells.Clear();
                gvDesignationParam.Rows[0].Cells.Add(new TableCell());
                gvDesignationParam.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvDesignationParam.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }

        public void clear()
        {
            txtTiffinCrossOverTime.Text=string.Empty;
            ddlDesignationId.Text = " ";
        }
        public void SaveDesignationParameter()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.TiffinCrossOverTime = txtTiffinCrossOverTime.Text;
            
            if (ddlDesignationId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.DesignationId = ddlDesignationId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.DesignationId = "";
            }

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.SaveDesignationParameter(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }
       
        #endregion

        #region "GridView Functionlity"

        protected void gvDesignationParam_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDesignationParam.PageIndex = e.NewPageIndex;
            
        }

        protected void gvDesignationParam_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvDesignationParam.SelectedRow.RowIndex;        
            string DesignationID = gvDesignationParam.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string TiffinCrossOverTime = gvDesignationParam.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            

            if (DesignationID != "")
            {
                ddlDesignationId.SelectedValue = DesignationID;
                ddlDesignationId.DataBind();
            }
            txtTiffinCrossOverTime.Text = TiffinCrossOverTime;
        }
        protected void gvDesignationParam_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvDesignationParam_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDesignationParam.EditIndex = e.NewEditIndex;
           
        }
        protected void gvDesignationParam_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvDesignationParam, "Select$" + e.Row.RowIndex);
            }
        }

        protected void chkActiveYn_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        #endregion
        protected void btnShow_Click(object sender, EventArgs e)
        {
            GetDesignationParameter();
        }
    }
}