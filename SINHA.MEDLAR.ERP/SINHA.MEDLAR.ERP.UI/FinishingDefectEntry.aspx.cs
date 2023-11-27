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
    public partial class FinishingDefectEntry : System.Web.UI.Page
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
                getOfficeName();
         //   loadSewingDefectEntryInfo();
                getLineId();
                getLineIdSearch();
                clearMsg();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }


            //txtSewingDefectentryId.Attributes.Add("onkeypress", "return controlEnter('" + txtDate.ClientID + "', event)");
            //txtDate.Attributes.Add("onkeypress", "return controlEnter('" + ddlLineId.ClientID + "', event)");
            //ddlLineId.Attributes.Add("onkeypress", "return controlEnter('" + txtTotalCheckQuantity.ClientID + "', event)");
            txtHourNo.Attributes.Add("onkeypress", "return controlEnter('" + txtTotalCheckQuantity.ClientID + "', event)");
            txtTotalCheckQuantity.Attributes.Add("onkeypress", "return controlEnter('" + txtProductionQuantity.ClientID + "', event)");
            txtProductionQuantity.Attributes.Add("onkeypress", "return controlEnter('" + txtShading.ClientID + "', event)");
            txtShading.Attributes.Add("onkeypress", "return controlEnter('" + txtDamageHole.ClientID + "', event)");
            txtDamageHole.Attributes.Add("onkeypress", "return controlEnter('" + txtFabricDefect.ClientID + "', event)");
            txtFabricDefect.Attributes.Add("onkeypress", "return controlEnter('" + txtBtnHoleDefect.ClientID + "', event)");
            txtBtnHoleDefect.Attributes.Add("onkeypress", "return controlEnter('" + txtBrokenStitch.ClientID + "', event)");
            txtBrokenStitch.Attributes.Add("onkeypress", "return controlEnter('" + txtSkipStitch.ClientID + "', event)");
            txtSkipStitch.Attributes.Add("onkeypress", "return controlEnter('" + txtMissing.ClientID + "', event)");
            txtMissing.Attributes.Add("onkeypress", "return controlEnter('" + txtUnevenEdgeMarginWidth.ClientID + "', event)");
            txtUnevenEdgeMarginWidth.Attributes.Add("onkeypress", "return controlEnter('" + txtJoinStitchPoorRepier.ClientID + "', event)");
            txtJoinStitchPoorRepier.Attributes.Add("onkeypress", "return controlEnter('" + txtOverDownStitch.ClientID + "', event)");
            txtOverDownStitch.Attributes.Add("onkeypress", "return controlEnter('" + txtTensionTightLoose.ClientID + "', event)");
            txtTensionTightLoose.Attributes.Add("onkeypress", "return controlEnter('" + txtPleat.ClientID + "', event)");
            txtPleat.Attributes.Add("onkeypress", "return controlEnter('" + txtCaughtBySeen.ClientID + "', event)");
            txtCaughtBySeen.Attributes.Add("onkeypress", "return controlEnter('" + txtAttachedByBartrack.ClientID + "', event)");
            txtAttachedByBartrack.Attributes.Add("onkeypress", "return controlEnter('" + txtRawedgeFraying.ClientID + "', event)");
            txtRawedgeFraying.Attributes.Add("onkeypress", "return controlEnter('" + txtExcessLessInlay.ClientID + "', event)");
            txtExcessLessInlay.Attributes.Add("onkeypress", "return controlEnter('" + txtPoorShape.ClientID + "', event)");
            txtPoorShape.Attributes.Add("onkeypress", "return controlEnter('" + txtPuckingLooseness.ClientID + "', event)");
            txtPuckingLooseness.Attributes.Add("onkeypress", "return controlEnter('" + txtRopingWavy.ClientID + "', event)");
            txtRopingWavy.Attributes.Add("onkeypress", "return controlEnter('" + txtStanted.ClientID + "', event)");
            txtStanted.Attributes.Add("onkeypress", "return controlEnter('" + txtHighKing.ClientID + "', event)");
            txtHighKing.Attributes.Add("onkeypress", "return controlEnter('" + txtPanelHilowUpdown.ClientID + "', event)");
            txtPanelHilowUpdown.Attributes.Add("onkeypress", "return controlEnter('" + txtPanelReverse.ClientID + "', event)");
            txtPanelReverse.Attributes.Add("onkeypress", "return controlEnter('" + txtProjection.ClientID + "', event)");
            txtProjection.Attributes.Add("onkeypress", "return controlEnter('" + txtUnmatchPairUnBalance.ClientID + "', event)");
            txtUnmatchPairUnBalance.Attributes.Add("onkeypress", "return controlEnter('" + txtOilMark.ClientID + "', event)");
            txtOilMark.Attributes.Add("onkeypress", "return controlEnter('" + txtSpotDirty.ClientID + "', event)");
            txtSpotDirty.Attributes.Add("onkeypress", "return controlEnter('" + txtMissPlace.ClientID + "', event)");
            txtMissPlace.Attributes.Add("onkeypress", "return controlEnter('" + txtPo.ClientID + "', event)");
            txtPo.Attributes.Add("onkeypress", "return controlEnter('" + txtChestWaist.ClientID + "', event)");
            txtChestWaist.Attributes.Add("onkeypress", "return controlEnter('" + txtFBack.ClientID + "', event)");
            txtFBack.Attributes.Add("onkeypress", "return controlEnter('" + txtSlvLengthInseam.ClientID + "', event)");
            txtSlvLengthInseam.Attributes.Add("onkeypress", "return controlEnter('" + txtsweepHip.ClientID + "', event)");
            txtsweepHip.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

        }


        public void clearMsg()
        {
            lblMsg.Text = "";

        }
        public void loadSession()
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
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDate.Text == " ")
            {

                string strMsg = "Please Date!!!";
                MessageBox(strMsg);
              
                return;
            }

            else if (ddlLineId.Text == " ")
            {

                string strMsg = "Please Enter Line!!!";
                MessageBox(strMsg);
                //dtpIssueDate.Focus();
                return;
            }

           
          
           
            else
            {

                saveFinishingDefectEntryInfo();
             //searchSewingDefectEntry();
                loadFinishingDefectEntryInfo();
                clearTextBox();
            }
        }

        #region "Function"


        public void getLineId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();

            ddlLineId.DataSource = objLookUpBLL.getLineId(strHeadOfficeId, strBranchOfficeId);

            ddlLineId.DataTextField = "LINE_NAME";
            ddlLineId.DataValueField = "LINE_ID";

            ddlLineId.DataBind();
            if (ddlLineId.Items.Count > 0)
            {

                ddlLineId.SelectedIndex = 0;
            }

        }

        public void getLineIdSearch()
        {

            SewingBLL objSewingBLL = new SewingBLL();

            ddlLineIdSearch.DataSource = objSewingBLL.getLineIdSearch(strHeadOfficeId, strBranchOfficeId);

            ddlLineIdSearch.DataTextField = "LINE_NAME";
            ddlLineIdSearch.DataValueField = "LINE_ID";

            ddlLineIdSearch.DataBind();
            if (ddlLineIdSearch.Items.Count > 0)
            {

                ddlLineIdSearch.SelectedIndex = 0;
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


        public void loadFinishingDefectEntryInfo()
        {
            SewingDTO objSewingDTO = new SewingDTO();
            SewingBLL objSewingBLL = new SewingBLL();

            DataTable dt = new DataTable();
            dt = objSewingBLL.loadFinishingDefectEntryInfo(strHeadOfficeId, strBranchOfficeId);

            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";

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


        public void saveFinishingDefectEntryInfo()
        {

            SewingDTO objSewingDTO = new SewingDTO();
            SewingBLL objSewingBLL =new SewingBLL();

            objSewingDTO.FinishingDefectEntryId = txtFinishingDefectentryId.Text;
            objSewingDTO.LineId = ddlLineId.SelectedValue.ToString();
            objSewingDTO.DefectDate = txtDate.Text;
            objSewingDTO.HourNO = txtHourNo.Text;
            objSewingDTO.ProductionQuantity = txtProductionQuantity.Text;
            objSewingDTO.Shading = txtShading.Text;
            objSewingDTO.DamageHole = txtDamageHole.Text;
            objSewingDTO.FabricDefect = txtFabricDefect.Text;
            objSewingDTO.BtnHoleDefect = txtBtnHoleDefect.Text;
            objSewingDTO.BrokenStitch = txtBrokenStitch.Text;
            objSewingDTO.SkipStitch = txtSkipStitch.Text;
            objSewingDTO.Missing = txtMissing.Text;
            objSewingDTO.UnevenEdgeMarginWidth = txtUnevenEdgeMarginWidth.Text;
            objSewingDTO.JoinStitchPoorRepier = txtJoinStitchPoorRepier.Text;
            objSewingDTO.OverDownStitchr = txtOverDownStitch.Text;
            objSewingDTO.TensionTightLoose = txtTensionTightLoose.Text;
            objSewingDTO.Pleat = txtPleat.Text;
            objSewingDTO.CaughtbySeam = txtCaughtBySeen.Text;
            objSewingDTO.AttachedByBartack = txtAttachedByBartrack.Text;
            objSewingDTO.RawedgeFraying = txtRawedgeFraying.Text;
            objSewingDTO.ExcessLessInlay = txtExcessLessInlay.Text;
            objSewingDTO.PoorShape = txtPoorShape.Text;
            objSewingDTO.PuckringLooseness = txtPuckingLooseness.Text;
            objSewingDTO.RopingWavy = txtRopingWavy.Text;
            objSewingDTO.Slanted = txtStanted.Text;
            objSewingDTO.HighKing = txtHighKing.Text;
            objSewingDTO.PanelHiLowUpdown = txtPanelHilowUpdown.Text;
            objSewingDTO.PanelReverse = txtPanelReverse.Text;
            objSewingDTO.Projection = txtProjection.Text;
            objSewingDTO.UnmatchPairUnbalance = txtUnmatchPairUnBalance.Text;
            objSewingDTO.OilMark = txtOilMark.Text;
            objSewingDTO.SpotDirty = txtSpotDirty.Text;
            objSewingDTO.MissMisPlace = txtMissPlace.Text;
            objSewingDTO.PoMainSiZeLblMistake = txtPo.Text;
            objSewingDTO.ChestWaist = txtChestWaist.Text;
            objSewingDTO.FbackLengthThigh = txtFBack.Text;
            objSewingDTO.SlvLengthInseam = txtSlvLengthInseam.Text;
            objSewingDTO.SweepHip = txtsweepHip.Text;
            objSewingDTO.TotalCheckQuantity = txtTotalCheckQuantity.Text;

            objSewingDTO.UpdateBy = strUnitId;
            objSewingDTO.HeadOfficeId = strHeadOfficeId;
            objSewingDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objSewingBLL.saveFinishingDefectEntryInfo(objSewingDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

          
        }

        public void clearTextBox()
        {
            txtFinishingDefectentryId.Text = "";

            txtDate.Text = "";
            ddlLineId.SelectedItem.Text = "";
            txtTotalCheckQuantity.Text = "";
            txtHourNo.Text = "";
            txtProductionQuantity.Text = "";
            txtShading.Text = "";
            txtDamageHole.Text = "";
            txtFabricDefect.Text = "";  //
            txtBtnHoleDefect.Text = "";
            txtBrokenStitch.Text = "";
            txtSkipStitch.Text = "";
            txtMissing.Text = "";
            txtUnevenEdgeMarginWidth.Text = "";
            txtJoinStitchPoorRepier.Text = "";
            txtOverDownStitch.Text = "";
            txtTensionTightLoose.Text = "";
            txtPleat.Text = "";
            txtCaughtBySeen.Text = "";
            txtAttachedByBartrack.Text = "";
            txtRawedgeFraying.Text = "";
            txtExcessLessInlay.Text = "";
            txtPoorShape.Text = "";
            txtPuckingLooseness.Text = "";
            txtRopingWavy.Text = "";
            txtStanted.Text = "";
            txtHighKing.Text = "";
            txtPanelHilowUpdown.Text = "";
            txtPanelReverse.Text = "";
            txtProjection.Text = "";
            txtUnmatchPairUnBalance.Text = "";
            txtOilMark.Text = "";
            txtSpotDirty.Text = "";
            txtMissPlace.Text = "";
            txtPo.Text = "";
            txtChestWaist.Text = "";
            txtFBack.Text = "";
            txtSlvLengthInseam.Text = "";
            txtsweepHip.Text = "";
            getLineId();
           // searchSewingDefectEntry();
        }

        public void searchFinishingDefectEntry()
        {

            SewingDTO objSewingDTO = new SewingDTO();
            SewingBLL objSewingBLL = new SewingBLL();


            objSewingDTO = objSewingBLL.searchFinishingDefectEntry(txtFinishingDefectentryId.Text, strHeadOfficeId, strBranchOfficeId);





            if (objSewingDTO.LineId == "0")
            {



            }
            else
            {
                ddlLineId.SelectedValue = objSewingDTO.LineId;
            }

           

            if (objSewingDTO.DefectDate == "0")
            {

                txtDate.Text = "";

            }
            else
            {
                txtDate.Text = objSewingDTO.DefectDate;
            }

            if (objSewingDTO.TotalCheckQuantity == "0")
            {

                txtTotalCheckQuantity.Text = "";

            }
            else
            {
                txtTotalCheckQuantity.Text = objSewingDTO.TotalCheckQuantity;
            }


            if (objSewingDTO.HourNO == "0")
            {

                txtHourNo.Text = "";

            }
            else
            {
                txtHourNo.Text = objSewingDTO.HourNO;
            }

            if (objSewingDTO.ProductionQuantity == "0")
            {

                txtProductionQuantity.Text = "";

            }
            else
            {
                txtProductionQuantity.Text = objSewingDTO.ProductionQuantity;
            }


            if (objSewingDTO.Shading == "0")
            {


                txtShading.Text = "";
            }
            else
            {
                txtShading.Text = objSewingDTO.Shading;
            }

          
            if (objSewingDTO.DamageHole == "0")
            {

                txtDamageHole.Text = "";

            }
            else
            {
                txtDamageHole.Text = objSewingDTO.DamageHole;
            }


           
            if (objSewingDTO.FabricDefect == "0")
            {


                txtFabricDefect.Text = "";

            }
            else
            {
                txtFabricDefect.Text = objSewingDTO.FabricDefect;
            }
           
            if (objSewingDTO.BtnHoleDefect == "0")
            {

                txtBtnHoleDefect.Text = "";

            }
            else
            {
                txtBtnHoleDefect.Text = objSewingDTO.BtnHoleDefect;
            }

          
            if (objSewingDTO.BrokenStitch == "0")
            {

                txtBrokenStitch.Text = "";

            }
            else
            {
                txtBrokenStitch.Text = objSewingDTO.BrokenStitch;
            }

           
            if (objSewingDTO.SkipStitch == "0")
            {

                txtSkipStitch.Text = "";

            }
            else
            {
                txtSkipStitch.Text = objSewingDTO.SkipStitch;
            }

          
            if (objSewingDTO.Missing == "0")
            {

                txtMissing.Text = "";

            }
            else
            {
                txtMissing.Text = objSewingDTO.Missing;
            }
           

            if (objSewingDTO.UnevenEdgeMarginWidth == "0")
            {

                txtUnevenEdgeMarginWidth.Text = "";

            }
            else
            {
                txtUnevenEdgeMarginWidth.Text = objSewingDTO.UnevenEdgeMarginWidth;
            }
           
            if (objSewingDTO.JoinStitchPoorRepier == "0")
            {

                txtJoinStitchPoorRepier.Text = "";

            }
            else
            {
                txtJoinStitchPoorRepier.Text = objSewingDTO.JoinStitchPoorRepier;
            }

           
            if (objSewingDTO.OverDownStitchr == "0")
            {

                txtOverDownStitch.Text = "";

            }
            else
            {
                txtOverDownStitch.Text = objSewingDTO.OverDownStitchr;
            }
            
            if (objSewingDTO.TensionTightLoose == "0")
            {
                txtTensionTightLoose.Text = "";


            }
            else
            {
                txtTensionTightLoose.Text = objSewingDTO.TensionTightLoose;
            }

           
            if (objSewingDTO.Pleat == "0")
            {

                txtPleat.Text = "";

            }
            else
            {
                txtPleat.Text = objSewingDTO.Pleat;
            }
            
            if (objSewingDTO.CaughtbySeam == "0")
            {

                txtCaughtBySeen.Text = "";

            }
            else
            {
                txtCaughtBySeen.Text = objSewingDTO.CaughtbySeam;
            }
          
            if (objSewingDTO.AttachedByBartack == "0")
            {


                txtAttachedByBartrack.Text = "";
            }
            else
            {
                txtAttachedByBartrack.Text = objSewingDTO.AttachedByBartack;
            }
           
            if (objSewingDTO.RawedgeFraying == "0")
            {
                txtRawedgeFraying.Text = "";


            }
            else
            {
                txtRawedgeFraying.Text = objSewingDTO.RawedgeFraying;
            }
           
            if (objSewingDTO.ExcessLessInlay == "0")
            {

                txtExcessLessInlay.Text = "";

            }
            else
            {
                txtExcessLessInlay.Text = objSewingDTO.ExcessLessInlay;
            }
          
            if (objSewingDTO.PoorShape == "0")
            {

                txtPoorShape.Text = "";

            }
            else
            {
                txtPoorShape.Text = objSewingDTO.PoorShape;
            }
           
            if (objSewingDTO.PuckringLooseness == "0")
            {

                txtPuckingLooseness.Text = "";

            }
            else
            {
                txtPuckingLooseness.Text = objSewingDTO.PuckringLooseness;
            }
           
            if (objSewingDTO.RopingWavy == "0")
            {

                txtRopingWavy.Text = "";

            }
            else
            {
                txtRopingWavy.Text = objSewingDTO.RopingWavy;
            }
          
            if (objSewingDTO.Slanted == "0")
            {

                txtStanted.Text = "";

            }
            else
            {
                txtStanted.Text = objSewingDTO.Slanted;
            }
            if (objSewingDTO.Slanted == "0")
            {
                txtStanted.Text = "";


            }
            else
            {
                txtStanted.Text = objSewingDTO.Slanted;
            }
            if (objSewingDTO.Slanted == "0")
            {
                txtStanted.Text = "";


            }
            else
            {
                txtStanted.Text = objSewingDTO.Slanted;
            }
           
            if (objSewingDTO.PanelHiLowUpdown == "0")
            {

                txtPanelHilowUpdown.Text = "";

            }
            else
            {
                txtPanelHilowUpdown.Text = objSewingDTO.PanelHiLowUpdown;
            }
           
            if (objSewingDTO.PanelReverse == "0")
            {


                txtPanelReverse.Text = "";
            }
            else
            {
                txtPanelReverse.Text = objSewingDTO.PanelReverse;
            }
          
            if (objSewingDTO.Projection == "0")
            {

                txtProjection.Text = "";

            }
            else
            {
                txtProjection.Text = objSewingDTO.Projection;
            }
            
            if (objSewingDTO.UnmatchPairUnbalance == "0")
            {

                txtUnmatchPairUnBalance.Text = "";

            }
            else
            {
                txtUnmatchPairUnBalance.Text = objSewingDTO.UnmatchPairUnbalance;
            }
     
            if (objSewingDTO.OilMark == "0")
            {

                txtOilMark.Text = "";

            }
            else
            {
                txtOilMark.Text = objSewingDTO.OilMark;
            }
          
            if (objSewingDTO.SpotDirty == "0")
            {

                txtSpotDirty.Text = "";

            }
            else
            {
                txtSpotDirty.Text = objSewingDTO.SpotDirty;
            }
            
            if (objSewingDTO.MissMisPlace == "0")
            {
                txtMissPlace.Text = "";


            }
            else
            {
                txtMissPlace.Text = objSewingDTO.MissMisPlace;
            }
          
            if (objSewingDTO.PoMainSiZeLblMistake == "0")
            {
                txtPo.Text = "";


            }
            else
            {
                txtPo.Text = objSewingDTO.PoMainSiZeLblMistake;
            }
           
            if (objSewingDTO.ChestWaist == "0")
            {
                txtChestWaist.Text = "";


            }
            else
            {
                txtChestWaist.Text = objSewingDTO.ChestWaist;
            }
           
            if (objSewingDTO.FbackLengthThigh == "0")
            {

                txtFBack.Text = "";

            }
            else
            {
                txtFBack.Text = objSewingDTO.FbackLengthThigh;
            }
          
            if (objSewingDTO.SlvLengthInseam == "0")
            {

                txtSlvLengthInseam.Text = "";

            }
            else
            {
                txtSlvLengthInseam.Text = objSewingDTO.SlvLengthInseam;
            }
           
            if (objSewingDTO.SweepHip == "0")
            {

                txtsweepHip.Text = "";

            }
            else
            {
                txtsweepHip.Text = objSewingDTO.SweepHip;
            }
        }



    
        #endregion

        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;

        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strSewingDefectentryId = gvUnit.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strDate = gvUnit.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strLine = gvUnit.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            txtFinishingDefectentryId.Text = strSewingDefectentryId;
            txtDate.Text = strDate;
        
          searchFinishingDefectEntry();

        }
        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
          searchFinishingDefectEntry();
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {

            {

                FinishingDefectEntrySearch();
            }
           
        }

        public void FinishingDefectEntrySearch()
        {
            SewingDTO objSewingDTO = new SewingDTO();
            SewingBLL objSewingBLL = new SewingBLL();
            DataTable dt = new DataTable();



            objSewingDTO.HeadOfficeId = strHeadOfficeId;
            objSewingDTO.BranchOfficeId = strBranchOfficeId;
            objSewingDTO.FinishingDefectEntryId = txtFinishingDefectentryId.Text;
            objSewingDTO.LineId = ddlLineIdSearch.Text;
            objSewingDTO.SewingDefectFromDate = dtpFromDate.Text;
            objSewingDTO.SewingDefectToDate = dtpToDate.Text;
            objSewingDTO.HourNO = txtHourNoSearch.Text;

            if (ddlLineIdSearch.SelectedValue.ToString() != " ")
            {
                objSewingDTO.LineId = ddlLineIdSearch.SelectedValue.ToString();
            }
            else
            {

                objSewingDTO.LineId = "";
            }

            //


            dt = objSewingBLL.FinishingDefectEntrySearch(objSewingDTO);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();

                int count = ((DataTable)gvUnit.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();


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
              //  lblMsgRecord.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            deleteFinishingDefectRecord();
            loadFinishingDefectEntryInfo();
            clearTextBox();
        }
        public void deleteFinishingDefectRecord()
        {
            SewingDTO objSewingDTO = new SewingDTO();
            SewingBLL objSewingBLL = new SewingBLL();


            objSewingDTO.FinishingDefectEntryId = txtFinishingDefectentryId.Text;

            objSewingDTO.UpdateBy = strEmployeeId;
            objSewingDTO.HeadOfficeId = strHeadOfficeId;
            objSewingDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objSewingBLL.deleteFinishingDefectRecord(objSewingDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;


        }
    }
}