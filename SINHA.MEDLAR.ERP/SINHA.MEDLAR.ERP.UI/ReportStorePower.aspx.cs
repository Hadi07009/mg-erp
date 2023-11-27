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

using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Specialized;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ReportStorePower : System.Web.UI.Page
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
        string strReport = "";
        ReportDocument rd = new ReportDocument();

        string strDefaultName = "Report";
        ExportFormatType formatType = ExportFormatType.NoFormat;
        bool status;



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
                clearMsg();
                getOfficeName();
                getEquipementId();
                getPartId();
            }

            if (IsPostBack)
            {

                loadSesscion();

            }
        }

        #region "Export Convert Function"
        public void ReportFormatMaster()
        {
            //Export the report in different format
            string strDefaultName = "Report";
            ExportFormatType formatType = ExportFormatType.NoFormat;
            if (chkPDF.Checked == true)
            {
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                ReportDocument crReportDocument = new ReportDocument();
                Response.Clear();
                Response.Buffer = true;

                formatType = ExportFormatType.PortableDocFormat;
                System.IO.Stream oStream = null;
                byte[] byteArray = null;

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                oStream = rd.ExportToStream(formatType);
                byteArray = new byte[oStream.Length];
                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(byteArray);
                Response.Flush();
                Response.Close();
                rd.Close();
                rd.Dispose();



            }
            if (chkExcel.Checked == true)
            {
                //formatType = ExportFormatType.Excel;
                //MemoryStream oStream;
                //Response.Clear();
                //Response.Buffer = false;
                //Response.ClearContent();
                //Response.ClearHeaders();

                //oStream = (MemoryStream)rd.ExportToStream(formatType);

                //Response.ContentType = "application/vnd.ms-excel";

                //oStream.Seek(0, SeekOrigin.Begin);
                //Response.BinaryWrite(oStream.ToArray());
                //Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();


                rd.ExportToHttpResponse
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "report_worker");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }

            if (chkWord.Checked == true)
            {
                //formatType = ExportFormatType.WordForWindows;
                //MemoryStream oStream;
                //oStream = (MemoryStream)rd.ExportToStream(formatType);
                //Response.ContentType = "application/vnd.ms-word";
                //oStream.Seek(0, SeekOrigin.Begin);
                //Response.BinaryWrite(oStream.ToArray());
                //Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();

                Response.ClearContent();
                Response.ClearHeaders();
                rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, "report_worker");
                Response.End();


            }

            if (chkCSV.Checked == true)
            {
                formatType = ExportFormatType.CharacterSeparatedValues;
                rd.ExportToHttpResponse(formatType, Response, true, strDefaultName);
                Response.End();
                CrystalReportViewer1.RefreshReport();
            }

            if (chkText.Checked == true)
            {
                formatType = ExportFormatType.RichText;
                MemoryStream oStream;
                oStream = (MemoryStream)rd.ExportToStream(formatType);
                Response.ContentType = "text/richtext";
                oStream.Seek(0, SeekOrigin.Begin);
                Response.BinaryWrite(oStream.ToArray());
                Response.End();
                oStream.Flush();
                oStream.Close();
                oStream.Dispose();
                CrystalReportViewer1.RefreshReport();
            }


            //switch (rbFormat.SelectedItem.Value)
            //{
            //    case "Word":
            //        formatType = ExportFormatType.WordForWindows;
            //        break;
            //    case "PDF":
            //        formatType = ExportFormatType.PortableDocFormat;
            //        break;
            //    case "Excel":
            //        formatType = ExportFormatType.Excel;
            //        break;
            //    case "CSV":
            //        formatType = ExportFormatType.CharacterSeparatedValues;
            //        break;
            //}

            //rd.ExportToHttpResponse(formatType, Response, true, strDefaultName );
            //Response.End();
            //CrystalReportViewer1.RefreshReport();





        }

        #endregion
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


        public void getEquipementId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEquipementId.DataSource = objLookUpBLL.getEquipementId(strHeadOfficeId, strBranchOfficeId);

            ddlEquipementId.DataTextField = "EQUIPMENT_NAME";
            ddlEquipementId.DataValueField = "EQUIPMENT_ID";

            ddlEquipementId.DataBind();
            if (ddlEquipementId.Items.Count > 0)
            {

                ddlEquipementId.SelectedIndex = 0;
            }

        }

        public void getPartId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            string strEquipementId = "";
            if (ddlEquipementId.SelectedValue.ToString() != " ")
            {
                strEquipementId = ddlEquipementId.SelectedValue.ToString();
            }
            else
            {
                strEquipementId = "";

            }

            ddlSparePartId.DataSource = objLookUpBLL.getPartId(strEquipementId, strHeadOfficeId, strBranchOfficeId);

            ddlSparePartId.DataTextField = "SPARE_PART_NAME";
            ddlSparePartId.DataValueField = "SPARE_PART_ID";

            ddlSparePartId.DataBind();
            if (ddlSparePartId.Items.Count > 0)
            {

                ddlSparePartId.SelectedIndex = 0;
            }

        }


        public void clearMessage()
        {

            //lblMsg.Text = string.Empty;
        }
        public void clearTextBox()
        {



        }

        public void clearMsg()
        {

            // lblMsg.Text = string.Empty;
            //lblMsgRecord.Text = string.Empty;
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

        #endregion

        #region "CheckBox"
        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {

                chkPDF.AutoPostBack = true;
                chkExcel.Checked = false;
                chkText.Checked = false;
                chkWord.Checked = false;
                chkCSV.Checked = false;
            }
        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkExcel.AutoPostBack = true;
                chkPDF.Checked = false;
                chkText.Checked = false;
                chkWord.Checked = false;
                chkCSV.Checked = false;
            }
        }

        protected void chkWord_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWord.Checked == true)
            {
                chkWord.AutoPostBack = true;
                chkPDF.Checked = false;
                chkText.Checked = false;
                chkExcel.Checked = false;
                chkCSV.Checked = false;
            }
        }

        protected void chkText_CheckedChanged(object sender, EventArgs e)
        {
            if (chkText.Checked == true)
            {
                chkText.AutoPostBack = true;
                chkPDF.Checked = false;
                chkWord.Checked = false;
                chkExcel.Checked = false;
                chkCSV.Checked = false;
            }
        }

        protected void chkCSV_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCSV.Checked == true)
            {
                chkCSV.AutoPostBack = true;
                chkPDF.Checked = false;
                chkWord.Checked = false;
                chkExcel.Checked = false;
                chkText.Checked = false;
            }
        }

        #endregion

        protected void btnView_Click(object sender, EventArgs e)
        {

            try
            {

                if (rdoSparePartsListOfEnginee.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    if (ddlEquipementId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.EquipementId = ddlEquipementId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.EquipementId = "";
                    }



                    if (ddlSparePartId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.PartId = ddlSparePartId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.PartId = "";

                    }




                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptListOfEngine.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.sparePartsListOfEngine(objReportDTO));
                    rd.SetDataSource(ds);
                    rd.SetDatabaseLogon("erp", "erp");
                    CrystalReportViewer1.ReportSource = rd;
                    CrystalReportViewer1.DataBind();




                    ReportFormatMaster();
                    this.CrystalReportViewer1.Dispose();
                    this.CrystalReportViewer1 = null;
                    rd.Dispose();
                    rd.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                }



                if (rdoMonthlyStore.Checked == true)
                {

                    ReportDTO objReportDTO = new ReportDTO();
                    ReportBLL objReportBLL = new ReportBLL();


                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;




                    objReportDTO.Year = txtYear.Text;
                    objReportDTO.Month = txtMonth.Text;


                    if (ddlEquipementId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.EquipementId = ddlEquipementId.SelectedValue.ToString();
                    }
                    else
                    {

                        objReportDTO.EquipementId = "";
                    }



                    if (ddlSparePartId.SelectedValue.ToString() != " ")
                    {
                        objReportDTO.PartId = ddlSparePartId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.PartId = "";

                    }




                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyStore.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    DataSet ds = new DataSet();

                    ds = (objReportBLL.MonthlyStoreList(objReportDTO));
                    rd.SetDataSource(ds);
                    rd.SetDatabaseLogon("erp", "erp");
                    CrystalReportViewer1.ReportSource = rd;
                    CrystalReportViewer1.DataBind();




                    ReportFormatMaster();
                    this.CrystalReportViewer1.Dispose();
                    this.CrystalReportViewer1 = null;
                    rd.Dispose();
                    rd.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                }















            }

            catch (Exception ex)
            {
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }


        }

        #region "Crystal Report Functionality"

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {


            }

            else if (chkWord.Checked == true)
            {




            }

            else
            {


                ReportDocument rd = new ReportDocument();
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

        }

        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {

            this.CrystalReportViewer1.ReportSource = null;

            CrystalReportViewer1.Dispose();

            if (rd != null)
            {

                rd.Close();

                rd.Dispose();

                rd = null;

            }

            GC.Collect();

            GC.WaitForPendingFinalizers();

        }



        #endregion

        protected void ddlEquipementId_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPartId();
        
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getPartId();
        }

    }
}