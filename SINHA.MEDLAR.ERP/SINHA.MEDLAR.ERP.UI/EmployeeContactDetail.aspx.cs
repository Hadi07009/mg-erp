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


using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;



using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Collections.Specialized;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class EmployeeContactDetail : System.Web.UI.Page
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
        ReportDocument rd = new ReportDocument();
        string strDefaultName = "Report";
        ExportFormatType formatType = ExportFormatType.NoFormat;

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
                getHeadOfficeId();
                
            }
            if (IsPostBack)
            {
                loadSesscion();
                Session["strID"] = null;
            }
            txtEmpName.Attributes.Add("onkeypress", "return controlEnter('" + btnSearchEmployee.ClientID + "', event)");         
        }

        #region "Load Drop Down List"

        public void loadSesscion()
        {
            strEmployeeId = Session["strEmployeeId"].ToString().Trim();
            strSectionId = Session["strSectionId"].ToString().Trim();
            strDesignationId = Session["strDesignationId"].ToString().Trim();
            strUnitId = Session["strUnitId"].ToString().Trim();
            strCatagoryId = Session["strCatagoryId"].ToString().Trim();
            strHeadOfficeId = Session["strHeadOfficeId"].ToString().Trim();
            strBranchOfficeId = Session["strBranchOfficeId"].ToString().Trim();
            strLoginDay = Session["strLoginDay"].ToString().Trim();
            strLoginMonth = Session["strLoginMonth"].ToString().Trim();
            strLoginDate = Session["strLoginDate"].ToString().Trim();

            if (Session["strID"] != null)
            {
                strID = Session["strID"].ToString().Trim();
            }
        }
        //Newly created for Session
        public void CreateSession()
        {
            string employeeId = "_" + Request.Cookies["eid"].Value.ToString();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            var employee = objEmployeeBLL.GetEmployeeById(employeeId);
            string suffix = "_" + (string)employee.Rows[0]["BRANCH_OFFICE_ID"];

            strEmployeeId = Session["strEmployeeId" + suffix].ToString().Trim();
            strSectionId = Session["strSectionId" + suffix].ToString().Trim();
            strDesignationId = Session["strDesignationId" + suffix].ToString().Trim();
            strUnitId = Session["strUnitId" + suffix].ToString().Trim();
            strCatagoryId = Session["strCatagoryId" + suffix].ToString().Trim();
            strHeadOfficeId = Session["strHeadOfficeId" + suffix].ToString().Trim();
            strBranchOfficeId = Session["strBranchOfficeId" + suffix].ToString().Trim();
            strLoginDay = Session["strLoginDay" + suffix].ToString().Trim();
            strLoginMonth = Session["strLoginMonth" + suffix].ToString().Trim();
            strLoginDate = Session["strLoginDate" + suffix].ToString().Trim();
            if (Session["strID" + suffix] != null)
            {
                strID = Session["strID" + suffix].ToString().Trim();
            }
        }
        //Newly created for Session
        public void ClearSession()
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


        public void getBranchOfficeId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBranchOfficeId.DataSource = objLookUpBLL.getBranchOfficeId(ddlHeadOfficeId.Text);

            ddlBranchOfficeId.DataTextField = "BRANCH_OFFICE_NAME";
            ddlBranchOfficeId.DataValueField = "BRANCH_OFFICE_ID";

            ddlBranchOfficeId.DataBind();
            if (ddlBranchOfficeId.Items.Count > 0)
            {
                ddlBranchOfficeId.SelectedIndex = 0;
            }
        }
        public void getHeadOfficeId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlHeadOfficeId.DataSource = objLookUpBLL.getHeadOfficeNeme();

            ddlHeadOfficeId.DataTextField = "HEAD_OFFICE_NAME";
            ddlHeadOfficeId.DataValueField = "Head_OFFICE_ID";

            ddlHeadOfficeId.DataBind();
            if (ddlHeadOfficeId.Items.Count > 0)
            {
                ddlHeadOfficeId.SelectedIndex = 0;
            }
        }
        public void getDesignationId()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.BranchOfficeId = ddlBranchOfficeId.Text;
           
            ddlDesignationId.DataSource = objLookUpBLL.GetActiveDesignation(objLookUpDTO);            
            ddlDesignationId.DataTextField = "DESIGNATION_NAME";
            ddlDesignationId.DataValueField = "DESIGNATION_ID";                     
            ddlDesignationId.DataBind();
            ddlDesignationId.Items.Insert(0, new ListItem { Text = "Please Select One", Value = "", Selected = true });
           
        }
        #endregion
        #region "Function"

        public void GetEmployeeInformation()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();


            string strActiveYn = "";
            objEmployeeDTO.EmployeeName = txtEmpName.Text;
            if (ddlHeadOfficeId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.HeadOfficeId = ddlHeadOfficeId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.HeadOfficeId = "";
            }
            if (ddlBranchOfficeId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.BranchOfficeId = ddlBranchOfficeId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.BranchOfficeId = "";
            }
            if (ddlDesignationId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.DesignationId = ddlDesignationId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.DesignationId = "";
            }
            dt = objEmployeeBLL.GetEmployeeInformation(objEmployeeDTO);
            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
               // MessageBox(strMsg);
                 lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
                int totalcolums = gvEmployeeList.Rows[0].Cells.Count;
                gvEmployeeList.Rows[0].Cells.Clear();
                gvEmployeeList.Rows[0].Cells.Add(new TableCell());
                gvEmployeeList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvEmployeeList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
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

            // lblHeadOfficeName.Text = objLookUpDTO.HeadOfficeName;
            //  lblHeadOfficeAddress.Text = objLookUpDTO.HeadOfficeAddress;
            // lblBranchOfficeName.Text = objLookUpDTO.BranchOfficeName;
            //lblBranchOfficeAddress.Text = objLookUpDTO.BranchOfficeAddress;

        }
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        #endregion
        #region "DML"

        public void SaveEmployeeContactDetail()
        {
            string strMsg = string.Empty;

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            foreach (GridViewRow row in gvEmployeeList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                { 
                        //TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");

                    var txtEmployeeId = row.Cells[8].Text;

                    TextBox txtEmail = (TextBox)row.FindControl("txtEmail");
                        TextBox txtPhoneNo = (TextBox)row.FindControl("txtPhoneNo");

                        objEmployeeDTO.EmployeeName = txtEmpName.Text;
                        if (ddlDesignationId.SelectedValue.ToString() != " ")
                        {
                            objEmployeeDTO.DesignationId = ddlDesignationId.SelectedValue.ToString();
                        }
                        else
                        {
                            objEmployeeDTO.DesignationId = "";
                        }
                        objEmployeeDTO.PhoneNo = txtPhoneNo.Text;
                        objEmployeeDTO.EmailAddress = txtEmail.Text;
                    objEmployeeDTO.EmployeeId = txtEmployeeId; // txtEmployeeId.Text;
                        objEmployeeDTO.UpdateBy = strEmployeeId;
                        objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                        objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                        strMsg = objEmployeeBLL.SaveEmployeeContactDetail(objEmployeeDTO);  
                }
            }
            MessageBox(strMsg);
        }
        public void clear()
        {

        }
        #endregion

        protected void ddlDesignationId_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (ddlBranchOfficeId.SelectedValue.ToString() != " ")
            {
                getDesignationId();
            }
            else
            {

                ddlDesignationId.Text = ""; 
            }
        }

       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               SaveEmployeeContactDetail();
                GetEmployeeInformation();
            }

            catch (Exception ex)
            {
                throw new Exception("Error :" + ex.Message);
            }
        }

        protected void ddlBranchOfficeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHeadOfficeId.SelectedValue.ToString() != " ")
            {
                getBranchOfficeId();
            }
            else
            {
                ddlBranchOfficeId.Text = " ";
                ddlDesignationId.Text = "";
            }               
        }


        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;

        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {


            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text.Replace("&#168;", "¨").Replace("&#182;", "¶")
                    .Replace("&#214;", "Ö").Replace("&#221;", "Ý").Replace("&#247;", "÷").Replace("&#169;", "©").Replace("&#177;", "±")
                    .Replace("&#172;", "¬").Replace("&#170;", "ª").Replace("&#243;", "ó").Replace("&#164;", "¤").Replace("&#248;", "ø")
                    .Replace("&#250;", "ú").Replace("&#219;", "Û").Replace("&#194;", "Â").Replace("&#196;", "Ä").Replace("&#175;", "¯")
                    .Replace("&amp;", "&").Replace("&#236;", "ì").Replace("&#173;", "­­­­­­­").Replace("&#183;", "­­­­­­­·").Replace("&#191;&#191;&#191;&#191;&#191;&#191;&#191;&#191;", "­­­­­­­¿¿¿¿¿¿¿¿")
                    .Replace("&#191;", "¿");

        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);
            }
        }





        protected void gvEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadEmployeeRecord();


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
            }
            if (dt != null)
            {
                DataView dataView = new DataView(dt);
                // dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                gvEmployeeList.DataSource = dataView;
                gvEmployeeList.DataBind();
            }
        }

        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }




        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //gvEmployeeList.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }

        #endregion



        protected void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                GetEmployeeInformation();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }
    }
}
































      

    

