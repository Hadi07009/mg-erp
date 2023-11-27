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
    public partial class ReportStore : System.Web.UI.Page
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
                getProgrammeId();
                getArtId();
                getSupplierId();
                getBuyerIdStore();
                getProgrammeId();
                getFabricId();
                getColorId();
                getFabricConstructionId();
                getStyleIdStore();



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

        public void getArtId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlArtId.DataSource = objLookUpBLL.getArtId();

            ddlArtId.DataTextField = "ART_NO";
            ddlArtId.DataValueField = "ART_ID";

            ddlArtId.DataBind();
            if (ddlArtId.Items.Count > 0)
            {
                ddlArtId.SelectedIndex = 0;
            }
        }


        public void getSupplierId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSupplierId.DataSource = objLookUpBLL.getSupplierId();
            ddlSupplierId.DataTextField = "SUPPLIER_NAME";
            ddlSupplierId.DataValueField = "SUPPLIER_ID";
            ddlSupplierId.DataBind();
            if (ddlSupplierId.Items.Count > 0)
            {
                ddlSupplierId.SelectedIndex = 0;
            }
        }
        public void getBuyerIdStore()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();

            ddlBuyerId.DataSource = objLookUpBLL.getBuyerIdStore(strHeadOfficeId, strBranchOfficeId);
            ddlBuyerId.DataTextField = "BUYER_NAME";
            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {
                ddlBuyerId.SelectedIndex = 0;
            }
        }




        public void getProgrammeId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlProgrammeId.DataSource = objLookUpBLL.getProgrammeId();
            ddlProgrammeId.DataTextField = "PROGRAMME_NAME";
            ddlProgrammeId.DataValueField = "PROGRAMME_ID";
            ddlProgrammeId.DataBind();
            if (ddlProgrammeId.Items.Count > 0)
            {
                ddlProgrammeId.SelectedIndex = 0;
            }
        }
        public void getFabricId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();

            ddlFabricId.DataSource = objLookUpBLL.getFabricId();
            ddlFabricId.DataTextField = "FABRIC_NAME";
            ddlFabricId.DataValueField = "FABRIC_ID";
            ddlFabricId.DataBind();
            if (ddlFabricId.Items.Count > 0)
            {
                ddlFabricId.SelectedIndex = 0;
            }
        }
        public void getColorId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();

            ddlColorId.DataSource = objLookUpBLL.getColorIdStore();
            ddlColorId.DataTextField = "COLOR_NAME";
            ddlColorId.DataValueField = "COLOR_ID";
            ddlColorId.DataBind();
            if (ddlColorId.Items.Count > 0)
            {
                ddlColorId.SelectedIndex = 0;
            }
        }
        public void getFabricConstructionId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();

            ddlConstructionId.DataSource = objLookUpBLL.getConstructionId();
            ddlConstructionId.DataTextField = "FABRIC_CONSTRUCTION_NAME";
            ddlConstructionId.DataValueField = "FABRIC_CONSTRUCTION_ID";
            ddlConstructionId.DataBind();
            if (ddlConstructionId.Items.Count > 0)
            {
                ddlConstructionId.SelectedIndex = 0;
            }
        }
        public void getStyleIdStore()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();

            ddlStyleId.DataSource = objLookUpBLL.getStyleIdStore();
            ddlStyleId.DataTextField = "STYLE_NO";
            ddlStyleId.DataValueField = "STYLE_ID";
            ddlStyleId.DataBind();
            if (ddlStyleId.Items.Count > 0)
            {
                ddlStyleId.SelectedIndex = 0;
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

        public void reportMaster()
        {

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

                //CrystalReportViewer1.ReportSource = rd;
                //CrystalReportViewer1.DataBind();

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
                ////Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();

                rd.ExportToHttpResponse
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "Report_store");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }
            //else
            //{

            //    CrystalReportViewer1.ReportSource = rd;
            //    CrystalReportViewer1.DataBind();

            //    formatType = ExportFormatType.PortableDocFormat;
            //    MemoryStream oStream;
            //    Response.Clear();
            //    Response.Buffer = false;
            //    Response.ClearContent();
            //    Response.ClearHeaders();

            //    oStream = (MemoryStream)rd.ExportToStream(formatType);
            //    Response.ContentType = "application/Pdf";
            //    oStream.Seek(0, SeekOrigin.Begin);
            //    Response.BinaryWrite(oStream.ToArray());
            //    //Response.End();
            //    oStream.Flush();
            //    oStream.Close();
            //    oStream.Dispose();
            //    CrystalReportViewer1.RefreshReport();

            //}



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

                if (rdoForeignFabricDetail.Checked == true)
                {

                    try
                    {

                        if (dtpDate.Text == "")
                        {

                            string strMsg = "Please Enter Date!!!";
                            dtpDate.Focus();
                            MessageBox(strMsg);
                            return;


                        }

                        else if(ddlSupplierId.Text == "0")
                        {

                            string strMsg = "Please Select Supplier!!!";
                            ddlSupplierId.Focus();
                            MessageBox(strMsg);
                            return;


                        }

                        else if(ddlProgrammeId.Text == "")
                        {

                            string strMsg = "Please Select Programme!!!";
                            ddlProgrammeId.Focus();
                            MessageBox(strMsg);
                            return;


                        }

                        else if(ddlFabricId.Text == "")
                        {

                            string strMsg = "Please Select Fabric!!!";
                            ddlFabricId.Focus();
                            MessageBox(strMsg);
                            return;


                        }

                        else if(ddlConstructionId.Text == "")
                        {

                            string strMsg = "Please Select Construction!!!";
                            ddlConstructionId.Focus();
                            MessageBox(strMsg);
                            return;


                        }

                        else if(ddlArtId.Text == "")
                        {

                            string strMsg = "Please Select Art!!!";
                            ddlArtId.Focus();
                            MessageBox(strMsg);
                            return;


                        }

                        else if (ddlColorId.Text == "")
                        {

                            string strMsg = "Please Select Color!!!";
                            ddlColorId.Focus();
                            MessageBox(strMsg);
                            return;


                        }


                        else
                        {



                            ReportDTO objReportDTO = new ReportDTO();
                            ReportBLL objReportBLL = new ReportBLL();

                            foreignFabricDetailStatus();

                            objReportDTO.HeadOfficeId = strHeadOfficeId;
                            objReportDTO.BranchOfficeId = strBranchOfficeId;
                            objReportDTO.UpdateBy = strEmployeeId;

                         
                            objReportDTO.Date = dtpDate.Text;
                          

                            if (ddlProgrammeId.SelectedValue.ToString() != " ")
                            {
                                objReportDTO.ProgrammeId = ddlProgrammeId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.ProgrammeId = "";

                            }

                            if (ddlStyleId.SelectedValue.ToString() != " ")
                            {
                                objReportDTO.StyleId = ddlStyleId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.StyleId = "";

                            }


                            if (ddlBuyerId.SelectedValue.ToString() != " ")
                            {
                                objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.BuyerId = "";

                            }

                            if (ddlArtId.SelectedValue.ToString() != " ")
                            {
                                objReportDTO.ArtNo = ddlArtId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.ArtNo = "";

                            }

                            if (ddlFabricId.SelectedValue.ToString() != " ")
                            {
                                objReportDTO.FabricId = ddlFabricId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.FabricId = "";

                            }

                            if (ddlConstructionId.SelectedValue.ToString() != " ")
                            {
                                objReportDTO.ConstructionId = ddlConstructionId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.ConstructionId = "";

                            }


                            if (ddlSupplierId.SelectedValue.ToString() != "0")
                            {
                                objReportDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.SupplierId = "";

                            }


                            if (ddlColorId.SelectedValue.ToString() != "0")
                            {
                                objReportDTO.ColorId = ddlColorId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.ColorId = "";

                            }




                            string strPath = Path.Combine(Server.MapPath("~/Reports/rptForeignFabricDetailInformation.rpt"));
                            this.Context.Session["strReportPath"] = strPath;
                            rd.Load(strPath);
                            rd.SetDataSource(objReportBLL.ForeignFabricInformationDetail(objReportDTO));


                            rd.SetDatabaseLogon("erp", "erp");
                            CrystalReportViewer1.ReportSource = rd;
                            CrystalReportViewer1.DataBind();



                            reportMaster();


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


                if (rdoForeignFabricSummeryByProgramme.Checked == true)
                {

                    try
                    {


                        if(ddlProgrammeId.Text == "")
                        {

                            string strMsg = "Please Select Programme Name!!!";
                            ddlProgrammeId.Focus();
                            MessageBox(strMsg);
                            return;

                        }
                       
                        else if(dtpDate.Text =="")
                        {

                            string strMsg = "Please Enter Date!!!";
                            dtpDate.Focus();
                            MessageBox(strMsg);
                            return;


                        }
                        else
                        {
                            ReportDTO objReportDTO = new ReportDTO();
                            ReportBLL objReportBLL = new ReportBLL();


                            foreignFabricSummeryByProgramme();

                            objReportDTO.HeadOfficeId = strHeadOfficeId;
                            objReportDTO.BranchOfficeId = strBranchOfficeId;
                            objReportDTO.UpdateBy = strEmployeeId;

                          
                            objReportDTO.ToDate = dtpDate.Text;
                         

                            if (ddlProgrammeId.SelectedValue.ToString() != " ")
                            {
                                objReportDTO.ProgrammeId = ddlProgrammeId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.ProgrammeId = "";

                            }

                            if (ddlStyleId.SelectedValue.ToString() != " ")
                            {
                                objReportDTO.StyleId = ddlStyleId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.StyleId = "";

                            }


                            if (ddlBuyerId.SelectedValue.ToString() != " ")
                            {
                                objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.BuyerId = "";

                            }

                            if (ddlArtId.SelectedValue.ToString() != " ")
                            {
                                objReportDTO.ArtNo = ddlArtId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.ArtNo = "";

                            }

                            if (ddlFabricId.SelectedValue.ToString() != " ")
                            {
                                objReportDTO.FabricId = ddlFabricId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.FabricId = "";

                            }

                            if (ddlConstructionId.SelectedValue.ToString() != " ")
                            {
                                objReportDTO.ConstructionId = ddlConstructionId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.ConstructionId = "";

                            }


                            if (ddlArtId.SelectedValue.ToString() != " ")
                            {
                                objReportDTO.ArtNo = ddlArtId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.ArtNo = "";

                            }


                            if (ddlColorId.SelectedValue.ToString() != " ")
                            {
                                objReportDTO.ColorId = ddlColorId.SelectedValue.ToString();
                            }
                            else
                            {
                                objReportDTO.ColorId = "";

                            }



                            string strPath = Path.Combine(Server.MapPath("~/Reports/rptForeignFabricSummary.rpt"));
                            this.Context.Session["strReportPath"] = strPath;
                            rd.Load(strPath);
                            rd.SetDataSource(objReportBLL.foreignFabricSummeryByProgramme(objReportDTO));


                            rd.SetDatabaseLogon("erp", "erp");
                            CrystalReportViewer1.ReportSource = rd;
                            CrystalReportViewer1.DataBind();



                            reportMaster();


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




        #region "Function"


        public void foreignFabricSummeryByProgramme()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

          
            objReportDTO.ToDate = dtpDate.Text;

    

            if (ddlProgrammeId.SelectedValue.ToString() != " ")
            {
                objReportDTO.ProgrammeId = ddlProgrammeId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ProgrammeId = "";

            }

            if (ddlStyleId.SelectedValue.ToString() != " ")
            {
                objReportDTO.StyleId = ddlStyleId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.StyleId = "";

            }


            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.BuyerId = "";

            }

            if (ddlArtId.SelectedValue.ToString() != " ")
            {
                objReportDTO.ArtNo = ddlArtId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ArtNo = "";

            }

            if (ddlFabricId.SelectedValue.ToString() != " ")
            {
                objReportDTO.FabricId = ddlFabricId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.FabricId = "";

            }

            if (ddlConstructionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.ConstructionId = ddlConstructionId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ConstructionId = "";

            }


            if (ddlArtId.SelectedValue.ToString() != " ")
            {
                objReportDTO.ArtNo = ddlArtId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ArtNo = "";

            }


            if (ddlColorId.SelectedValue.ToString() != "0")
            {
                objReportDTO.ColorId = ddlColorId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ColorId = "";

            }


            if (ddlSupplierId.SelectedValue.ToString() != "0")
            {
                objReportDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.SupplierId = "";

            }


            string strMsg = objReportBLL.foreignFabricSummery(objReportDTO);



        }
        public void foreignFabricDetailStatus()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

         
            objReportDTO.Date = dtpDate.Text;

          

            if (ddlProgrammeId.SelectedValue.ToString() != " ")
            {
                objReportDTO.ProgrammeId = ddlProgrammeId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ProgrammeId = "";

            }

            if (ddlStyleId.SelectedValue.ToString() != " ")
            {
                objReportDTO.StyleId = ddlStyleId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.StyleId = "";

            }


            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objReportDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.BuyerId = "";

            }

            if (ddlArtId.SelectedValue.ToString() != " ")
            {
                objReportDTO.ArtNo = ddlArtId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ArtNo = "";

            }

            if (ddlFabricId.SelectedValue.ToString() != " ")
            {
                objReportDTO.FabricId = ddlFabricId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.FabricId = "";

            }

            if (ddlConstructionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.ConstructionId = ddlConstructionId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ConstructionId = "";

            }


            if (ddlArtId.SelectedValue.ToString() != " ")
            {
                objReportDTO.ArtNo = ddlArtId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ArtNo = "";

            }


            if (ddlColorId.SelectedValue.ToString() != "0")
            {
                objReportDTO.ColorId = ddlColorId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ColorId = "";

            }

            if (ddlSupplierId.SelectedValue.ToString() != "0")
            {
                objReportDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.SupplierId = "";

            }


            string strMsg = objReportBLL.foreignFabricDetailStatus(objReportDTO);



        }


        #endregion




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

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            getFabricIdFromPOAssign();
            getFabricConstructionIdFromPOAssign();
            getStyleIdFromPOAssign();
            getArtIdFromPOAssign();
            getColorIdFromPOAssign();


        }


        public void getFabricIdFromPOAssign()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlFabricId.DataSource = objLookUpBLL.getFabricIdFromPOAssign(ddlSupplierId.SelectedValue.ToString(), ddlProgrammeId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);


            ddlFabricId.DataTextField = "FABRIC_NAME";
            ddlFabricId.DataValueField = "FABRIC_ID";

            ddlFabricId.DataBind();
            if (ddlFabricId.Items.Count > 0)
            {

                ddlFabricId.SelectedIndex = 0;
            }

        }

        public void getFabricConstructionIdFromPOAssign()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlConstructionId.DataSource = objLookUpBLL.getFabricConstructionIdFromPOAssign(ddlSupplierId.SelectedValue.ToString(), ddlProgrammeId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);


            ddlConstructionId.DataTextField = "FABRIC_CONSTRUCTION_NAME";
            ddlConstructionId.DataValueField = "FABRIC_CONSTRUCTION_ID";

            ddlConstructionId.DataBind();
            if (ddlConstructionId.Items.Count > 0)
            {

                ddlConstructionId.SelectedIndex = 0;
            }

        }


        public void getStyleIdFromPOAssign()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlStyleId.DataSource = objLookUpBLL.getStyleIdFromPOAssign(ddlSupplierId.SelectedValue.ToString(), ddlProgrammeId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);


            ddlStyleId.DataTextField = "STYLE_NO";
            ddlStyleId.DataValueField = "STYLE_ID";

            ddlStyleId.DataBind();
            if (ddlStyleId.Items.Count > 0)
            {

                ddlStyleId.SelectedIndex = 0;
            }

        }

        public void getArtIdFromPOAssign()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
          
            ddlArtId.DataSource = objLookUpBLL.getArtIdFromPOAssign(ddlSupplierId.SelectedValue.ToString(), ddlProgrammeId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);


            ddlArtId.DataTextField = "ART_NO";
            ddlArtId.DataValueField = "ART_ID";

            ddlArtId.DataBind();
            if (ddlArtId.Items.Count > 0)
            {

                ddlArtId.SelectedIndex = 0;
            }



        }

        public void getColorIdFromPOAssign()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();

            ddlColorId.DataSource = objLookUpBLL.getColorIdFromPOAssign(ddlSupplierId.SelectedValue.ToString(), ddlProgrammeId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);


            ddlColorId.DataTextField = "COLOR_NAME";
            ddlColorId.DataValueField = "COLOR_ID";

            ddlColorId.DataBind();
            if (ddlColorId.Items.Count > 0)
            {

                ddlColorId.SelectedIndex = 0;
            }



        }





    }
}