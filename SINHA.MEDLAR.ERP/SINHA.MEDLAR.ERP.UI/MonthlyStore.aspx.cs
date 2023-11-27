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
    public partial class MonthlyStore : System.Web.UI.Page
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
                getMonthYear();
                getOfficeName();
                getPartId();
                getEquipementId();
                //getSupplierId();
                clearMessage();

                
            }



            if (IsPostBack)
            {

                loadSesscion();

               

            }        

            txtYear.Attributes.Add("onkeypress", "return controlEnter('" + txtBeginingStock.ClientID + "', event)");
            txtBeginingStock.Attributes.Add("onkeypress", "return controlEnter('" + txtOpeningStock.ClientID + "', event)");
            txtOpeningStock.Attributes.Add("onkeypress", "return controlEnter('" + txtClosingBlance.ClientID + "', event)");

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }



        #region "Function"
        public void clearMessage()
        {
            lblMsgRecord.Text = "";
            lblMsg.Text = string.Empty;
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

        public void getMonthYear()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYear();

            txtYear.Text = objLookUpDTO.Year;
            txtMonth.Text = objLookUpDTO.Month;

        }

        public void clearTextBox()
        {
           
            txtTranId.Text = "";
            txtOpeningStock.Text = "";
            txtClosingBlance.Text = "";          
            txtPartNo.Text = "";
            txtBeginingStock.Text = "";
            getEquipementId();
            getPartId();


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



        //public void getSupplierId()
        //{

        //    LookUpBLL objLookUpBLL = new LookUpBLL();
           
           
        //    ddlSupplierId.DataSource = objLookUpBLL.getSupplierId();

        //    ddlSupplierId.DataTextField = "SUPPLIER_NAME";
        //    ddlSupplierId.DataValueField = "SUPPLIER_ID";

        //    ddlSupplierId.DataBind();
        //    if (ddlSupplierId.Items.Count > 0)
        //    {

        //        ddlSupplierId.SelectedIndex = 0;
        //    }

        //}

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
        public void chkBeginingStock()
        {
            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreBLL objMonthlyStoreBLL = new MonthlyStoreBLL();

            
            int year, month;

            year = Convert.ToInt32(txtYear.Text);
            month = Convert.ToInt32( txtMonth.Text);

            objMonthlyStoreDTO = objMonthlyStoreBLL.chkBeginingStock(txtTranId.Text, txtPartNo.Text, txtPartNoSrc.Text, txtYear.Text, txtMonth.Text, strHeadOfficeId, strBranchOfficeId);


            if (((objMonthlyStoreDTO.BeginingStock == null) || (objMonthlyStoreDTO.BeginingStock == "0") || (objMonthlyStoreDTO.StartTranMonth == month.ToString()) || (objMonthlyStoreDTO.StartTranMonth =="0") || (objMonthlyStoreDTO.StartTranMonth == null)) && (objMonthlyStoreDTO.StartTranYear == year.ToString()) || (objMonthlyStoreDTO.StartTranYear == null))
            {
                txtBeginingStock.ReadOnly = false;
            }
            else
            {
                txtBeginingStock.ReadOnly = true;
            }

        }
        public void saveMonthlyStoreInfo()
        {


            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreBLL objMonthlyStoreBLL = new MonthlyStoreBLL();



            objMonthlyStoreDTO.TranId = txtTranId.Text;
            objMonthlyStoreDTO.Year = txtYear.Text;
            objMonthlyStoreDTO.Month = txtMonth.Text;
            objMonthlyStoreDTO.PartNo = txtPartNo.Text;
            objMonthlyStoreDTO.BeginingStock = txtBeginingStock.Text;
            objMonthlyStoreDTO.OpeningStock = txtOpeningStock.Text;
            //objMonthlyStoreDTO.StockAfterAddition = txtStockAfterAddition.Text;
            objMonthlyStoreDTO.ClosingBlance = txtClosingBlance.Text;


            if (ddlSparePartId.SelectedValue.ToString() != " ")
            {
                objMonthlyStoreDTO.SparePartId = ddlSparePartId.SelectedValue.ToString();
            }
            else
            {
                objMonthlyStoreDTO.SparePartId = "";

            }

            if (ddlEquipementId.SelectedValue.ToString() != " ")
            {
                objMonthlyStoreDTO.EquipementId = ddlEquipementId.SelectedValue.ToString();
            }
            else
            {
                objMonthlyStoreDTO.EquipementId = "";

            }

            objMonthlyStoreDTO.UpdateBy = strEmployeeId;
            objMonthlyStoreDTO.HeadOfficeId = strHeadOfficeId;
            objMonthlyStoreDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objMonthlyStoreBLL.saveMonthlyStoreInfo(objMonthlyStoreDTO);

            if (strMsg != "INSERTED SUCCESSFULLY" && strMsg != "UPDATED SUCCESSFULLY")
            {
                string input = strMsg;
                string subStr = input.Substring(22);
                txtTranId.Text = subStr;

            }
            if (strMsg == "INSERTED SUCCESSFULLY" || strMsg == "UPDATED SUCCESSFULLY")
            {
                lblMsg.Text = strMsg;
                MessageBox(strMsg);

            }
            else
            {
                lblMsg.Text = strMsg;
                MessageBox(strMsg);

            }

        }
        public void MonthlyClosingBlance()
        {


            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreBLL objMonthlyStoreBLL = new MonthlyStoreBLL();

            if (ddlSparePartId.SelectedValue.ToString() != " ")
            {
                objMonthlyStoreDTO.PartId = ddlSparePartId.SelectedValue.ToString();
            }
            else
            {
                objMonthlyStoreDTO.PartId = "";

            }

            if (ddlEquipementId.SelectedValue.ToString() != " ")
            {
                objMonthlyStoreDTO.EquipementId = ddlEquipementId.SelectedValue.ToString();
            }
            else
            {
                objMonthlyStoreDTO.EquipementId = "";

            }



            objMonthlyStoreDTO.PartNo = txtPartNoSrc.Text;

            objMonthlyStoreDTO.Year = txtYear.Text;
            objMonthlyStoreDTO.Month = txtMonth.Text;

          


            objMonthlyStoreDTO.UpdateBy = strEmployeeId;
            objMonthlyStoreDTO.HeadOfficeId = strHeadOfficeId;
            objMonthlyStoreDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objMonthlyStoreBLL.MonthlyClosingBlance(objMonthlyStoreDTO);




            //lblMsg.Text = strMsg;
            //MessageBox(strMsg);

        }
        public void deleteMonthlyRecord()
        {


            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreBLL objMonthlyStoreBLL = new MonthlyStoreBLL();

            objMonthlyStoreDTO.TranId = txtTranId.Text;



            objMonthlyStoreDTO.Year = txtYear.Text;
            objMonthlyStoreDTO.Month = txtMonth.Text;
            objMonthlyStoreDTO.IssueDate = txtYear.Text;

            objMonthlyStoreDTO.UpdateBy = strEmployeeId;
            objMonthlyStoreDTO.HeadOfficeId = strHeadOfficeId;
            objMonthlyStoreDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objMonthlyStoreBLL.deleteMonthlyRecord(objMonthlyStoreDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }

        public void calculateTotalBlance()
        {


            if (txtOpeningStock.Text == "")
            {
                txtOpeningStock.Text = "0";

            }

            if (txtBeginingStock.Text == "")
            {
                txtBeginingStock.Text = "0";

            }

            //txtStockAfterAddition.Text = Convert.ToString(Convert.ToInt32(txtOpeningStock.Text) + Convert.ToInt32(txtBeginingStock.Text));


        }

        //public void calculateClosingBlance()
        //{


        //    if (txtStockAfterAddition.Text == "")
        //    {
        //        txtStockAfterAddition.Text = "0";

        //    }

        //    if (txtIssuedQuantity.Text == "")
        //    {
        //        txtIssuedQuantity.Text = "0";

        //    }

        //    txtClosingBlance.Text = Convert.ToString(Convert.ToInt32(txtStockAfterAddition.Text) + Convert.ToInt32(txtIssuedQuantity.Text));


        //}


        
        public void searchEquipementAndSparePartId(string strTranId)
        {
            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreBLL objMonthlyStoreBLL = new MonthlyStoreBLL();




            objMonthlyStoreDTO = objMonthlyStoreBLL.searchEquipementAndSparePartId(strTranId, strHeadOfficeId, strBranchOfficeId);


            if (objMonthlyStoreDTO.EquipementId == "0")
            {
                getEquipementId();
            }
            else
            {
                ddlEquipementId.SelectedValue = objMonthlyStoreDTO.EquipementId;

            }

            if (objMonthlyStoreDTO.SparePartId == "0")
            {
                getPartId();
            }
            else
            {
                ddlSparePartId.SelectedValue = objMonthlyStoreDTO.SparePartId;

            }




        }
        public void searchMonthlyStoreRecord()
        {
            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreBLL objMonthlyStoreBLL = new MonthlyStoreBLL();




            objMonthlyStoreDTO = objMonthlyStoreBLL.searchMonthlyStoreRecord(txtTranId.Text, txtPartNo.Text, txtPartNoSrc.Text,  txtYear.Text,txtMonth.Text, strHeadOfficeId, strBranchOfficeId);


            if (objMonthlyStoreDTO.TranId != "0")
            {
                txtTranId.Text = objMonthlyStoreDTO.TranId;
            }
            else
            {
                txtTranId.Text = "0";
            }
            if (objMonthlyStoreDTO.PartNo != "0")
            {
                txtPartNo.Text = objMonthlyStoreDTO.PartNo;
            }
            else
            {
                txtPartNo.Text = "0";
            }
            if (objMonthlyStoreDTO.BeginingStock != "0")
            {
                txtBeginingStock.Text = objMonthlyStoreDTO.BeginingStock;
            }
            else
            {
                txtBeginingStock.Text = "";
            }
            if (objMonthlyStoreDTO.OpeningStock != "0")
            {
                txtOpeningStock.Text = objMonthlyStoreDTO.OpeningStock;
            }
            else
            {
                txtOpeningStock.Text = "0";
            }
            if (objMonthlyStoreDTO.ClosingBlance != "0")
            {
                txtClosingBlance.Text = objMonthlyStoreDTO.ClosingBlance;
            }
            else
            {
                txtClosingBlance.Text = "";
            }


            if (objMonthlyStoreDTO.EquipementId == "0")
            {
                getEquipementId();
            }
            else
            {
                ddlEquipementId.SelectedValue = objMonthlyStoreDTO.EquipementId;

            }
            if (objMonthlyStoreDTO.SparePartId == "0")
            {
                getPartId();
            }
            else
            {
                ddlSparePartId.SelectedValue = objMonthlyStoreDTO.SparePartId;

            }




        }
        public void chkStockYn()
        {
            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreBLL objMonthlyStoreBLL = new MonthlyStoreBLL();

            string strYear = "";
            string strMonth = "";

            if (txtYear.Text != "")
            {
                strYear = txtYear.Text;
            }
            else
            {
                strYear = "";
            }

            if (txtMonth.Text != "")
            {
                strMonth = txtMonth.Text;
            }
            else
            {
                strMonth = "";
            }

            objMonthlyStoreDTO = objMonthlyStoreBLL.chkStockYn(txtTranId.Text, txtPartNo.Text,txtPartNoSrc.Text, strYear, strMonth, strHeadOfficeId, strBranchOfficeId);

            if (objMonthlyStoreDTO.StockYn == "Y")
            {

                searchMonthlyStoreRecord();
            }
            else
            {
                MonthlyClosingBlance();
                searchBeginingStoreRecord();

            }
  


        }
        public void searchBeginingStoreRecord()
        {
            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreBLL objMonthlyStoreBLL = new MonthlyStoreBLL();




            objMonthlyStoreDTO = objMonthlyStoreBLL.searchBeginingStoreRecord(txtTranId.Text, txtPartNo.Text, txtPartNoSrc.Text, txtYear.Text,txtMonth.Text, strHeadOfficeId, strBranchOfficeId);

            if (objMonthlyStoreDTO.BeginingStock != "0")
            {
                txtBeginingStock.Text = objMonthlyStoreDTO.BeginingStock;
            }
            else
            {
                txtBeginingStock.Text = "";
            }
            if (objMonthlyStoreDTO.OpeningStock != "0")
            {
                txtOpeningStock.Text = objMonthlyStoreDTO.OpeningStock;
            }
            else
            {
                txtOpeningStock.Text = "";
            }
            if (objMonthlyStoreDTO.ClosingBlance != "0")
            {
                txtClosingBlance.Text = objMonthlyStoreDTO.ClosingBlance;
            }
            else
            {
                txtClosingBlance.Text = "";
            }
           

            if (objMonthlyStoreDTO.PartNo == null || objMonthlyStoreDTO.PartNo == "0")
            {
               

            }
            else
            {
                txtPartNo.Text = objMonthlyStoreDTO.PartNo; 

            }
            
        }

        public void loadMonthlyStoreRecord()
        {
            MonthlyStoreDTO objMonthlyStoreDTO = new MonthlyStoreDTO();
            MonthlyStoreBLL objMonthlyStoreBLL = new MonthlyStoreBLL();


            DataTable dt = new DataTable();
            string strSparePartId = "", strEquipementId = "";

            if (ddlSparePartId.Text != " ")
            {
                strSparePartId = ddlSparePartId.SelectedValue.ToString();
            }
            else
            {
                strSparePartId = "";

            }


            if (ddlEquipementId.Text != " ")
            {
                strEquipementId = ddlEquipementId.SelectedValue.ToString();
            }
            else
            {
                strEquipementId = "";

            }


            dt = objMonthlyStoreBLL.loadMonthlyStoreRecord(strSparePartId, strEquipementId, txtPartNoSrc.Text,  txtYear.Text, txtMonth.Text, strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
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
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }


        }


        public void loadPartCategoryRecordForMonthlyStore()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            string strEquipementId = "", strSparePartId = "";

            if (ddlEquipementId.Text != " ")
            {
                strEquipementId = ddlEquipementId.SelectedValue.ToString();
            }
            else
            {
                strEquipementId = "";

            }

            if (ddlSparePartId.Text != " ")
            {
                strSparePartId = ddlSparePartId.SelectedValue.ToString();
            }
            else
            {
                strSparePartId = "";

            }


            dt = objLookUpBLL.loadPartCategoryRecordForMonthlyStore(txtPartNoSrc.Text, strEquipementId, strSparePartId, strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                string strMsg = "TOTAL " + GridView1.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
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
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }


        public void goToNextRecord()
        {
            if (txtSL.Text == string.Empty)
            {
                txtSL.Text = "1";
            }

            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            //gvIncrementList.SelectedIndex = 1;


            int l;
            l = GridView1.SelectedRow.RowIndex;
            if (l != 0)
            {

                int strId = GridView1.SelectedRow.RowIndex + 1;
                int strRowCount = strId;
                int intCount = GridView1.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                    return;

                }
                else
                {
                    GridView1.SelectedIndex += 1;
                    result = GridView1.SelectedRow.RowIndex + k;

                }

            }
            if (l == 0)
            {

                int intCount = GridView1.Rows.Count;
                int intCountRow = GridView1.Rows.Count;
                if (intCountRow == 1)
                {
                    intCountRow = 2;

                }

                int p = intCountRow - 1;
                //int p = intCountRow;
                if (l == p)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                    return;

                }

                else
                {
                    l = 1;

                    if (txtSL.Text == "1" && txtSLNew.Text == "")
                    {
                        GridView1.SelectedIndex = 0;
                        result = GridView1.SelectedRow.RowIndex + k;
                        txtSLNew.Text = "1";

                    }
                    else
                    {

                        int intC = GridView1.Rows.Count;
                        int intCo = GridView1.Rows.Count;
                        int ll = 0;

                        int pp = intCo - 1;
                        //int p = intCountRow;
                        if (ll == pp)
                        {
                            string strMsg = "There is no Data for the Next Record!!!";
                            MessageBox(strMsg);

                            return;

                        }
                        else
                        {

                            GridView1.SelectedIndex += 1;
                            result = GridView1.SelectedRow.RowIndex + k;

                        }

                    }


                }

            }

           
            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;



            if (strSLNo == "NO RECORD FOUND")
            {
                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                return;
            }
            else
            {

                string strPartNo = GridView1.SelectedRow.Cells[3].Text;
                if (strPartNo == "" || strPartNo == "&nbsp;")
                {
                    txtPartNo.Text = "";
                }
                else
                {

                    txtPartNo.Text = strPartNo;
                }

              
                txtSL.Text = Convert.ToString(strRowId);
            }
        }


        public void goToPreviousRecord()
        {
            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            //gvIncrementList.SelectedIndex = 1;


            int l;
            l = GridView1.SelectedRow.RowIndex;
            if (l != 0)
            {
                int strId = GridView1.SelectedRow.RowIndex - 1;
                int strRowCount = strId;
                int intCount = GridView1.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                  
                    return;

                }
                else
                {
                    GridView1.SelectedIndex -= 1;
                    result = GridView1.SelectedRow.RowIndex - k;
                }
            }
            if (l == 0)
            {

                int intCountRow = GridView1.Rows.Count;
                int p = intCountRow;
                if (intCountRow == p)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                   
                    return;

                }

                else
                {

                    l = 1;
                    GridView1.SelectedIndex = l;
                    result = GridView1.SelectedRow.RowIndex - k;

                }

            }

            int strRowId = GridView1.SelectedRow.RowIndex + 1;

            //int strRowCount = strRowId - 1;
            //int intCount = gvIncrementList.Rows.Count;
            //if (intCount == strRowCount)
            //{
            //    string strMsg = "Entry Completed";
            //    MessageBox(strMsg);
            //    return;

            //}
            //else
            //{





            string strPartNo = GridView1.SelectedRow.Cells[3].Text;
            

            txtSL.Text = Convert.ToString(strRowId);

            if (strPartNo == "" || strPartNo == "&nbsp;")
            {
                txtPartNo.Text = "";
            }
            else
            {

                txtPartNo.Text = strPartNo;
            }

           

        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {


            if (txtPartNo.Text == "")
            {
                string strMsg = "Please Enter Issue Part No!!!";
                MessageBox(strMsg);
                txtPartNo.Focus();
                return;
            }
            else
            {
                saveMonthlyStoreInfo();
                searchMonthlyStoreRecord();
                loadMonthlyStoreRecord();
            }         

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtTranId.Text == "")
            {
                string strMsg = "Please Enter ID!!!";
                MessageBox(strMsg);
                txtTranId.Focus();
                return; 
            }
            else
            {

                searchMonthlyStoreRecord();
               
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtTranId.Text == "")
            {
                string strMsg = "Please Enter ID!!!";
                MessageBox(strMsg);
                txtTranId.Focus();
                return;
            }
            else
            {

                deleteMonthlyRecord();
                loadMonthlyStoreRecord();
                clearTextBox();
            }
        }

        protected void ddlEquipementId_SelectedIndexChanged(object sender, EventArgs e)
        {
            getPartId();
        }


        #region "GridView Functionlity"
        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
           
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

            string strTranId = gvUnit.SelectedRow.Cells[0].Text;          
            string strYear = gvUnit.SelectedRow.Cells[3].Text;
            string strMonth = gvUnit.SelectedRow.Cells[4].Text;
            string strPartNo = gvUnit.SelectedRow.Cells[5].Text;
            string strBeginingStock = gvUnit.SelectedRow.Cells[6].Text;
            string strOpeningStock = gvUnit.SelectedRow.Cells[7].Text;
            string strClosingBlance = gvUnit.SelectedRow.Cells[8].Text;



            txtTranId.Text = strTranId;
            txtYear.Text = strYear;
            txtMonth.Text = strMonth;
            txtPartNo.Text = strPartNo;
            txtBeginingStock.Text = strBeginingStock;
            txtOpeningStock.Text = strOpeningStock;
            //txtStockAfterAddition.Text = strStockAfterAddition;
            txtClosingBlance.Text = strClosingBlance;


            //searchMonthlyStoreRecord();
            searchEquipementAndSparePartId(strTranId);




        }

        #endregion
        #region "GridViewFunctionlity2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            
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

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = GridView1.SelectedRow.RowIndex;
            string strUnitId = GridView1.SelectedRow.Cells[0].Text;
            string strUnitName = GridView1.SelectedRow.Cells[1].Text;
            string strUnitNameBng = GridView1.SelectedRow.Cells[3].Text;

            

            if (strUnitNameBng == "" || strUnitNameBng == "&nbsp;")
            {
                txtPartNo.Text = "";
            }
            else
            {

                txtPartNo.Text = strUnitNameBng;
            }


            chkStockYn();
        }

        #endregion

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadMonthlyStoreRecord();
        }

        protected void btnSearchSparePart_Click(object sender, EventArgs e)
        {
            

            loadPartCategoryRecordForMonthlyStore();
           
            clearTextBox();
            GridView1.SelectedIndex = 0;
            goToNextRecord();
            chkStockYn();          
            loadMonthlyStoreRecord();

            chkBeginingStock();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridView1.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }



                else
                {

                    goToNextRecord();
                    searchMonthlyStoreRecord();
                    clearMessage();


                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridView1.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
               

                else
                {
                    goToPreviousRecord(); 
                    searchMonthlyStoreRecord();
                    clearMessage();


                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            if (ddlSparePartId.Text == " ")
            {

                string strMsg = "Please Select Part Name!!!";
                MessageBox(strMsg);
                ddlSparePartId.Focus();
                return;
            }
            else
            {

                Response.Redirect("FileCS.ashx?SPARE_PART_ID=" + Server.UrlEncode(ddlSparePartId.SelectedValue.ToString()));

            }
        }

      
    }
}