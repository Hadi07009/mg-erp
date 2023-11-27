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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class OfficeShiftTime : System.Web.UI.Page
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

                getShiftTypeId();
                getUnitId();
                getSectionId();
                clearMsg();
                getOfficeName();
                btnSearch.Focus();
             
            }
            if (IsPostBack)
            {

                loadSesscion();
            }


            //gvOfficeShiftTime.Columns[5].Visible = false;
            



        }

        #region "Function"

      

        public void getDate()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getDate();

          



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



        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
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

        public void getShiftTypeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlShiftId.DataSource = objLookUpBLL.getShiftTypeId(strHeadOfficeId, strBranchOfficeId);

            ddlShiftId.DataTextField = "SHIFT_TYPE_NAME";
            ddlShiftId.DataValueField = "SHIFT_TYPE_ID";

            ddlShiftId.DataBind();
            if (ddlShiftId.Items.Count > 0)
            {

                ddlShiftId.SelectedIndex = 0;
            }

        }

        public void getUnitId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlUnitId.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlUnitId.DataTextField = "UNIT_NAME";
            ddlUnitId.DataValueField = "UNIT_ID";

            ddlUnitId.DataBind();
            if (ddlUnitId.Items.Count > 0)
            {

                ddlUnitId.SelectedIndex = 0;
            }

        }

      



        public void getSectionId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSectionId.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

            ddlSectionId.DataTextField = "SECTION_NAME";
            ddlSectionId.DataValueField = "SECTION_ID";

            ddlSectionId.DataBind();
            if (ddlSectionId.Items.Count > 0)
            {

                ddlSectionId.SelectedIndex = 0;
            }


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



       
        public void loadOfficeShiftTime()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            // objEmployeeDTO.LogDate = dtpAttendenceDate.Text;


            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";

            }





            dt = objEmployeeBLL.loadOfficeShiftTime(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int totalcolums = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridView1.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }

        }

    


       


        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }


      
       
       

       


    
        #endregion


        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                loadOfficeShiftTime();

            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

               
                searchEmployeeInfo();
                loadOfficeShiftTime();

            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

      

     

        public void searchEmployeeInfo()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
           
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;


      

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";

            }






            objEmployeeDTO.EmployeeId = txtEmpId.Text; ;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
           
          

         
            



            dt = objEmployeeBLL.searchEmployeeInfo(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvOfficeShiftTime.DataSource = dt;
                gvOfficeShiftTime.DataBind();

                int count = ((DataTable)gvOfficeShiftTime.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                //gvEmployeeList.Columns[2].Visible = false;
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvOfficeShiftTime.DataSource = dt;
                gvOfficeShiftTime.DataBind();
                int totalcolums = gvOfficeShiftTime.Rows[0].Cells.Count;
                gvOfficeShiftTime.Rows[0].Cells.Clear();
                gvOfficeShiftTime.Rows[0].Cells.Add(new TableCell());
                gvOfficeShiftTime.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvOfficeShiftTime.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                //gvEmployeeList.Columns[2].Visible = false;
                lblMsgRecord.Text = strMsg;
            }

        }




        #region "Grid View Functionality"
        protected void gvOfficeShiftTime_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOfficeShiftTime.PageIndex = e.NewPageIndex;
            

        }

      


        #endregion

      
        protected void gvOfficeShiftTime_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvOfficeShiftTime_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

       

     

        public void deleteOfficeShiftTimeRecord(string strEmpId)
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.EmpId = strEmpId;
          
          

            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objEmployeeBLL.deleteOfficeShiftTimeRecord(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }

        public void saveOfficeShiftTime()
        {
            
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";

            string strCount = gvOfficeShiftTime.Rows.Count.ToString();

            foreach (GridViewRow row in gvOfficeShiftTime.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {

                        string strId = (row.FindControl("lblEmployeeId") as Label).Text;

                        objEmployeeDTO.EmployeeId = strId;



                        if (ddlShiftId.SelectedValue.ToString() != "0")
                        {
                            objEmployeeDTO.ShiftTypeId = ddlShiftId.SelectedValue.ToString();
                        }
                        else
                        {

                            objEmployeeDTO.ShiftTypeId = "";
                        }


                        if (ddlSectionId.SelectedValue.ToString() != " ")
                        {
                            objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                        }
                        else
                        {

                            objEmployeeDTO.ShiftId = "";
                        }

                        if (ddlUnitId.SelectedValue.ToString() != " ")
                        {
                            objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                        }
                        else
                        {

                            objEmployeeDTO.UnitId = "";
                        }

                      

                      



                        objEmployeeDTO.UpdateBy = strEmployeeId;
                        objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                        objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                        




                        strMsg = objEmployeeBLL.saveOfficeShiftTime(objEmployeeDTO);
                        lblMsg.Text = strMsg;

                       

                      
                    }

                }



            }

            MessageBox(strMsg);







        }

        protected void gvOfficeShiftTime_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvOfficeShiftTime_OnRowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvOfficeShiftTime_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvOfficeShiftTime_OnRowDataBound(object sender, EventArgs e)
        {

        }
       

        protected void gvOfficeShiftTime_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

       


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int stor_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"].ToString());
            string strEmpId = Convert.ToString(stor_id);

            deleteOfficeShiftTimeRecord(strEmpId);
            loadOfficeShiftTime();


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {


            int strRowId = GridView1.SelectedRow.RowIndex;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string strDesignation = GridView1.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string strEmpId = GridView1.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");



            txtCardNo.Text = strCardNo;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            txtEmployeeId.Text = strEmpId;



        }




        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }




        protected void GridView1_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }

        }




       


        protected void ddlShifyTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(ddlShiftId.Text == " ")
            {

                string strMsg = "Please Enter Effect Date!!!";
                ddlShiftId.Focus();
                MessageBox(strMsg);
                return;

            }

            else
            {
                saveOfficeShiftTime();
                loadOfficeShiftTime();


            }

            
        }

        
    }
}