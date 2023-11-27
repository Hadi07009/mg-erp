using SINHA.MEDLAR.ERP.BLL;
using SINHA.MEDLAR.ERP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class Rostering : System.Web.UI.Page
    {
        string strEmployeeId = "";
        string strSectionId = "";
        
        string strDesignationId = "";
        string strUnitId = "";
        string strCatagoryId;
        string strHeadOfficeId = "";
        string strBranchOfficeId = "";
        
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
                getOfficeName();
                GetRosterSpecificEmployee(strHeadOfficeId, strBranchOfficeId);
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
        }

        #region 

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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void GetShiftConfiguration()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.GetShiftConfiguration(strHeadOfficeId, strBranchOfficeId);
            if (dt.Rows.Count > 0)
            {
                //gvUnit.DataSource = dt;
                //gvUnit.DataBind();
            }
        }

        public void GetRosterSpecificEmployee(string headOfficeId, string branchOfficeId)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            //EmployeeShiftMapping objMapping = new EmployeeShiftMapping();
            

            var data = objLookUpBLL.GetRosterSpecificEmployee(headOfficeId, branchOfficeId);

            DateTime? minDate = null;
            DateTime? maxDate = null;


            var rosterDates = data.Select(x => new { roster_date = x.roster_date, roster_date_str = x.roster_date_str }).Distinct().ToList().OrderBy(x => x.roster_date);
            if (rosterDates.Count() > 0)
            {
                minDate = rosterDates.Min(x => x.roster_date);
                maxDate = rosterDates.Max(x => x.roster_date);
            }

            int dateCounter = 0;

            foreach (var effectDate in rosterDates)
            {

                dateCounter = dateCounter + 1;
                if (minDate == effectDate.roster_date)
                {
                    //1
                    var objShift1PreList = data.Where(x => (x.ShiftId == 1) && (x.roster_date < maxDate));
                    int counter = 0;
                    foreach (var item in objShift1PreList)
                    {
                        counter = counter + 1;
                        item.MappingId = counter;
                    }

                    GvShift1Pre.DataSource = objShift1PreList;
                    GvShift1Pre.DataBind();

                    var timeSchedule1 = objLookUpBLL.GetShiftingTimeSchedule(1, effectDate.roster_date_str, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
                    lblShift1PreOfficeTime.Text = "Office Time: " + timeSchedule1.LoginTime + " - " + timeSchedule1.LogoutTime;
                    lblShift1PreRosterDate.Text = "Roster Started on: " + effectDate.roster_date_str;

                    //2
                    var objShift2PreList = data.Where(x => (x.ShiftId == 2) && (x.roster_date < maxDate));
                    counter = 0;
                    foreach (var item in objShift2PreList)
                    {
                        counter = counter + 1;
                        item.MappingId = counter;
                    }
                    GvShift2Pre.DataSource = objShift2PreList;
                    GvShift2Pre.DataBind();

                    var timeSchedule2 = objLookUpBLL.GetShiftingTimeSchedule(2, effectDate.roster_date_str, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
                    lblShift2PreOfficeTime.Text = "Office Time: " + timeSchedule2.LoginTime + " - " + timeSchedule2.LogoutTime;
                    lblShift2PreRosterDate.Text = "Roster Started on: " + effectDate.roster_date_str;

                    //3
                    var objShift3PreList = data.Where(x => (x.ShiftId == 3) && (x.roster_date < maxDate));
                    counter = 0;
                    foreach (var item in objShift3PreList)
                    {
                        counter = counter + 1;
                        item.MappingId = counter;
                    }
                    GvShift3Pre.DataSource = objShift3PreList;
                    GvShift3Pre.DataBind();

                    var timeSchedule3 = objLookUpBLL.GetShiftingTimeSchedule(3, effectDate.roster_date_str, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
                    lblShift3PreOfficeTime.Text = "Office Time: " + timeSchedule3.LoginTime + " - " + timeSchedule3.LogoutTime;
                    lblShift3PrerRosterDate.Text = "Roster Started on: " + effectDate.roster_date_str;

                    //4
                    var objShift4PreList = data.Where(x => (x.ShiftId == 4) && (x.roster_date < maxDate));
                    counter = 0;
                    foreach (var item in objShift4PreList)
                    {
                        counter = counter + 1;
                        item.MappingId = counter;
                    }
                    GvShift4Pre.DataSource = objShift4PreList; //data.Where(x => (x.ShiftId == 4) && (x.EffectDate == effectDate.EffectDate));
                    GvShift4Pre.DataBind();

                    var timeSchedule4 = objLookUpBLL.GetShiftingTimeSchedule(4, effectDate.roster_date_str, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
                    lblShift4PreOfficeTime.Text = "Office Time: " + timeSchedule4.LoginTime + " - " + timeSchedule4.LogoutTime;
                    lblShift4PreRosterDate.Text = "Roster Started on: " + effectDate.roster_date_str;
                }

                if (maxDate == effectDate.roster_date)
                {
                    var objShift1PostList = data.Where(x => (x.ShiftId == 1) && (x.roster_date == effectDate.roster_date));
                    int counter = 0;
                    foreach (var item in objShift1PostList)
                    {
                        counter = counter + 1;
                        item.MappingId = counter;
                    }

                    GvShift1Post.DataSource = objShift1PostList; //data.Where(x => (x.ShiftId == 1) && (x.EffectDate == effectDate.EffectDate));
                    GvShift1Post.DataBind();

                    var timeSchedule1 = objLookUpBLL.GetShiftingTimeSchedule(1, effectDate.roster_date_str, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
                    lblShift1PostOfficeTime.Text = "Office Time: " + timeSchedule1.LoginTime + " - " + timeSchedule1.LogoutTime;
                    lblShift1PostRosterDate.Text = "Roster Started on: " + effectDate.roster_date_str;

                    var objShift2PostList = data.Where(x => (x.ShiftId == 2) && (x.roster_date == effectDate.roster_date));
                    counter = 0;
                    foreach (var item in objShift2PostList)
                    {
                        counter = counter + 1;
                        item.MappingId = counter;
                    }

                    GvShift2Post.DataSource = objShift2PostList; //data.Where(x => (x.ShiftId == 2) && (x.EffectDate == effectDate.EffectDate));
                    GvShift2Post.DataBind();

                    var timeSchedule2 = objLookUpBLL.GetShiftingTimeSchedule(2, effectDate.roster_date_str, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
                    lblShift2PostOfficeTime.Text = "Office Time: " + timeSchedule2.LoginTime + " - " + timeSchedule2.LogoutTime;
                    lblShift2PostRosterDate.Text = "Roster Started on: " + effectDate.roster_date_str;

                    var objShift3PostList = data.Where(x => (x.ShiftId == 3) && (x.roster_date == effectDate.roster_date));
                    counter = 0;
                    foreach (var item in objShift3PostList)
                    {
                        counter = counter + 1;
                        item.MappingId = counter;
                    }
                    GvShift3Post.DataSource = objShift3PostList; //data.Where(x => (x.ShiftId == 3) && (x.EffectDate == effectDate.EffectDate));
                    GvShift3Post.DataBind();

                    var timeSchedule3 = objLookUpBLL.GetShiftingTimeSchedule(3, effectDate.roster_date_str, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
                    lblShift3PostOfficeTime.Text = "Office Time: " + timeSchedule3.LoginTime + " - " + timeSchedule3.LogoutTime;
                    lblShift3PostRosterDate.Text = "Roster Started on: " + effectDate.roster_date_str;

                    var objShift4PostList = data.Where(x => (x.ShiftId == 4) && (x.roster_date == effectDate.roster_date));
                    counter = 0;
                    foreach (var item in objShift4PostList)
                    {
                        counter = counter + 1;
                        item.MappingId = counter;
                    }
                    GvShift4Post.DataSource = objShift4PostList; // data.Where(x => (x.ShiftId == 4) && (x.EffectDate == effectDate.EffectDate));
                    GvShift4Post.DataBind();

                    var timeSchedule4 = objLookUpBLL.GetShiftingTimeSchedule(4, effectDate.roster_date_str, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
                    lblShift4PostOfficeTime.Text = "Office Time: " + timeSchedule4.LoginTime + " - " + timeSchedule4.LogoutTime;
                    lblShift4PostRosterDate.Text = "Roster Started on: " + effectDate.roster_date_str;
                }
            }










            //old
            //var effectDates = data.Select(x => new { shift_effect_date = x.shift_effect_date, EffectDate = x.EffectDate }).Distinct().ToList().OrderBy(x => x.shift_effect_date);
            //if (effectDates.Count() > 0)
            //{
            //    minDate = effectDates.Min(x => x.shift_effect_date);
            //    maxDate = effectDates.Max(x => x.shift_effect_date);
            //}

            //int dateCounter = 0;

            //foreach (var effectDate in effectDates)
            //{

            //    dateCounter = dateCounter + 1;
            //    if (minDate == effectDate.shift_effect_date)
            //    {
            //        //1
            //        var objShift1PreList = data.Where(x => (x.ShiftId == 1) && (x.shift_effect_date < maxDate));
            //        int counter = 0;
            //        foreach (var item in objShift1PreList)
            //        {
            //            counter = counter + 1;
            //            item.MappingId = counter;
            //        }

            //        GvShift1Pre.DataSource = objShift1PreList; 
            //        GvShift1Pre.DataBind();

            //        var timeSchedule1 = objLookUpBLL.GetShiftingTimeSchedule(1, effectDate.EffectDate, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
            //        lblShift1PreOfficeTime.Text = "Office Time: " + timeSchedule1.LoginTime + " - " + timeSchedule1.LogoutTime;
            //        lblShift1PreRosterDate.Text = "Roster Started on: " + effectDate.EffectDate;

            //        //2
            //        var objShift2PreList = data.Where(x => (x.ShiftId == 2) && (x.shift_effect_date < maxDate));
            //        counter = 0;
            //        foreach (var item in objShift2PreList)
            //        {
            //            counter = counter + 1;
            //            item.MappingId = counter;
            //        }
            //        GvShift2Pre.DataSource = objShift2PreList; 
            //        GvShift2Pre.DataBind();

            //        var timeSchedule2 = objLookUpBLL.GetShiftingTimeSchedule(2, effectDate.EffectDate, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
            //        lblShift2PreOfficeTime.Text = "Office Time: " + timeSchedule2.LoginTime + " - " + timeSchedule2.LogoutTime;
            //        lblShift2PreRosterDate.Text = "Roster Started on: " + effectDate.EffectDate;

            //        //3
            //        var objShift3PreList = data.Where(x => (x.ShiftId == 3) && (x.shift_effect_date < maxDate));
            //        counter = 0;
            //        foreach (var item in objShift3PreList)
            //        {
            //            counter = counter + 1;
            //            item.MappingId = counter;
            //        }
            //        GvShift3Pre.DataSource = objShift3PreList;
            //        GvShift3Pre.DataBind();

            //        var timeSchedule3 = objLookUpBLL.GetShiftingTimeSchedule(3, effectDate.EffectDate, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
            //        lblShift3PreOfficeTime.Text = "Office Time: " + timeSchedule3.LoginTime + " - " + timeSchedule3.LogoutTime;
            //        lblShift3PrerRosterDate.Text = "Roster Started on: " + effectDate.EffectDate;

            //        //4
            //        var objShift4PreList = data.Where(x => (x.ShiftId == 4) && (x.shift_effect_date < maxDate));
            //        counter = 0;
            //        foreach (var item in objShift4PreList)
            //        {
            //            counter = counter + 1;
            //            item.MappingId = counter;
            //        }
            //        GvShift4Pre.DataSource = objShift4PreList; //data.Where(x => (x.ShiftId == 4) && (x.EffectDate == effectDate.EffectDate));
            //        GvShift4Pre.DataBind();

            //        var timeSchedule4 = objLookUpBLL.GetShiftingTimeSchedule(4, effectDate.EffectDate, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
            //        lblShift4PreOfficeTime.Text = "Office Time: " + timeSchedule4.LoginTime + " - " + timeSchedule4.LogoutTime;
            //        lblShift4PreRosterDate.Text = "Roster Started on: " + effectDate.EffectDate;
            //    }

            //    if (maxDate == effectDate.shift_effect_date)
            //    {
            //        var objShift1PostList = data.Where(x => (x.ShiftId == 1) && (x.shift_effect_date == effectDate.shift_effect_date));
            //        int counter = 0;
            //        foreach (var item in objShift1PostList)
            //        {
            //            counter = counter + 1;
            //            item.MappingId = counter;
            //        }

            //        GvShift1Post.DataSource = objShift1PostList; //data.Where(x => (x.ShiftId == 1) && (x.EffectDate == effectDate.EffectDate));
            //        GvShift1Post.DataBind();

            //        var timeSchedule1 = objLookUpBLL.GetShiftingTimeSchedule(1, effectDate.EffectDate, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
            //        lblShift1PostOfficeTime.Text = "Office Time: " + timeSchedule1.LoginTime + " - " + timeSchedule1.LogoutTime;
            //        lblShift1PostRosterDate.Text = "Roster Started on: " + effectDate.EffectDate;

            //        var objShift2PostList = data.Where(x => (x.ShiftId == 2) && (x.shift_effect_date == effectDate.shift_effect_date));
            //        counter = 0;
            //        foreach (var item in objShift2PostList)
            //        {
            //            counter = counter + 1;
            //            item.MappingId = counter;
            //        }

            //        GvShift2Post.DataSource = objShift2PostList; //data.Where(x => (x.ShiftId == 2) && (x.EffectDate == effectDate.EffectDate));
            //        GvShift2Post.DataBind();

            //        var timeSchedule2 = objLookUpBLL.GetShiftingTimeSchedule(2, effectDate.EffectDate, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
            //        lblShift2PostOfficeTime.Text = "Office Time: " + timeSchedule2.LoginTime + " - " + timeSchedule2.LogoutTime;
            //        lblShift2PostRosterDate.Text = "Roster Started on: " + effectDate.EffectDate;

            //        var objShift3PostList = data.Where(x => (x.ShiftId == 3) && (x.shift_effect_date == effectDate.shift_effect_date));
            //        counter = 0;
            //        foreach (var item in objShift3PostList)
            //        {
            //            counter = counter + 1;
            //            item.MappingId = counter;
            //        }
            //        GvShift3Post.DataSource = objShift3PostList; //data.Where(x => (x.ShiftId == 3) && (x.EffectDate == effectDate.EffectDate));
            //        GvShift3Post.DataBind();

            //        var timeSchedule3 = objLookUpBLL.GetShiftingTimeSchedule(3, effectDate.EffectDate, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
            //        lblShift3PostOfficeTime.Text = "Office Time: " + timeSchedule3.LoginTime + " - " + timeSchedule3.LogoutTime;
            //        lblShift3PostRosterDate.Text = "Roster Started on: " + effectDate.EffectDate;

            //        var objShift4PostList = data.Where(x => (x.ShiftId == 4) && (x.shift_effect_date == effectDate.shift_effect_date));
            //        counter = 0;
            //        foreach (var item in objShift4PostList)
            //        {
            //            counter = counter + 1;
            //            item.MappingId = counter;
            //        }
            //        GvShift4Post.DataSource = objShift4PostList; // data.Where(x => (x.ShiftId == 4) && (x.EffectDate == effectDate.EffectDate));
            //        GvShift4Post.DataBind();

            //        var timeSchedule4 = objLookUpBLL.GetShiftingTimeSchedule(4, effectDate.EffectDate, strHeadOfficeId, strBranchOfficeId).SingleOrDefault();
            //        lblShift4PostOfficeTime.Text = "Office Time: " + timeSchedule4.LoginTime + " - " + timeSchedule4.LogoutTime;
            //        lblShift4PostRosterDate.Text = "Roster Started on: " + effectDate.EffectDate;
            //    }
            //}
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
        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gvUnit.PageIndex = e.NewPageIndex;
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
            //    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

            //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvUnit, "Select$" + e.Row.RowIndex);
            //}
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //hf_shift_id.Value = string.Empty;
            //int strRowId = gvUnit.SelectedRow.RowIndex;

            //txtPunchStartTime.Text = gvUnit.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            //txtLoginStartTime.Text = gvUnit.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            //txtLoginGraceTime.Text = gvUnit.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            //txtLoginEndTime.Text = gvUnit.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            //txtLunchOutTime.Text = gvUnit.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            //txtLunchInTime.Text = gvUnit.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            //txtLogoutTime.Text = gvUnit.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            //txtPunchEndTime.Text = gvUnit.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            //dtpEffectDate.Text = gvUnit.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");

            //string activeYn = gvUnit.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            //if (activeYn == "Y")
            //    chkActiveYn.Checked = true;
            //else
            //    chkActiveYn.Checked = false;

            //hf_shift_configuration_id.Value = gvUnit.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            //hf_shift_id.Value = gvUnit.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
            //txtShiftId.Text = hf_shift_id.Value;
            //ddlShiftId.SelectedValue = hf_shift_id.Value;

            //txtLunchOutStartTime.Text = gvUnit.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
            //txtLunchOutEndTime.Text = gvUnit.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
            //txtLunchInStartTime.Text = gvUnit.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");
            //txtLunchInEndTime.Text = gvUnit.SelectedRow.Cells[16].Text.Replace("&nbsp;", "");
            //txtEearlyOtStartTime.Text = gvUnit.SelectedRow.Cells[17].Text.Replace("&nbsp;", "");
            //txtLogoutStartTime.Text = gvUnit.SelectedRow.Cells[18].Text.Replace("&nbsp;", "");
        }

        protected void btnRoster_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;
                LookUpDTO objLookUpDto = new LookUpDTO();
                LookUpBLL objLookUpBll = new LookUpBLL();

                if(string.IsNullOrEmpty(dtpEffectDate.Text))
                {
                    msg = "Enter valid Roster Date";
                    MessageBox(msg);
                    lblMsg.Text = msg;
                    return;
                }

                objLookUpDto.EffectDate = dtpEffectDate.Text;
                objLookUpDto.UpdateBy = strEmployeeId;
                objLookUpDto.HeadOfficeId = strHeadOfficeId;
                objLookUpDto.BranchOfficeId = strBranchOfficeId;

                msg = objLookUpBll.ProcessRostering(objLookUpDto);
                GetRosterSpecificEmployee(strHeadOfficeId, strBranchOfficeId);
            
                lblMsg.Text = msg;
                MessageBox(msg);
            }
            catch (Exception ex)
            {   
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void ClearAll()
        {
            
        }
    }
}