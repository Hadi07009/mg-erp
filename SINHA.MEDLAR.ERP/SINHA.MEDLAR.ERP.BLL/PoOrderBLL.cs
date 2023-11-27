using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;
using System.Data;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class PoOrderBLL
    {
        public string savePoOrderInfo(PoOrderDTO objPoOrderDTO)
        {

            PoOrderDAL objPoOrderDAL = new PoOrderDAL();
            string strMsg = objPoOrderDAL.savePoOrderInfo(objPoOrderDTO);
            return strMsg;
        }
        public DataTable LoadPoNo(PoOrderDTO objPoOrderDTO)
        {

            DataTable dt = new DataTable();
            PoOrderDAL objPoOrderDAL = new PoOrderDAL();


            dt = objPoOrderDAL.LoadPoNo(objPoOrderDTO);
            return dt;

        }
        public DataTable searchPoOrderRecord(string PoRequisitionNo, string strPoNumber, string strIssueDate, string strDeliveryDate, string strHeadOfficeId, string strBranchOfficeId)
        {
            DataTable dt = new DataTable();
            PoOrderDAL objPoOrderDAL = new PoOrderDAL();
            dt = objPoOrderDAL.searchPoOrderRecord(PoRequisitionNo, strPoNumber, strIssueDate, strDeliveryDate, strHeadOfficeId, strBranchOfficeId);
            return dt;
        }

        public DataTable GetOrderByOrderId(string poNo, string employeeId, string headOfficeId, string branchOfficeId)
        {
            DataTable dt = new DataTable();
            PoOrderDAL objPoOrderDAL = new PoOrderDAL();
            dt = objPoOrderDAL.GetOrderByOrderId(poNo, employeeId, headOfficeId, branchOfficeId);
            return dt;
        }
        public DataTable searchPoRequisitionInfo(string strPoRequisitionNo, string strPurchaseDate, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {
            DataTable dt = new DataTable();
            PoOrderDAL objPoOrderDAL = new PoOrderDAL();
            dt = objPoOrderDAL.searchPoRequisitionInfo(strPoRequisitionNo, strPurchaseDate, strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return dt;
        }

        //public DataTable searchPoRequisitionInfo(string strPoRequisitionNo, string strPurchaseDate, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        //GetRequisitionInfo(txtPoRequisitionNo.Text, strEmployeeId, strHeadOfficeId, strBranchOfficeId)
        public DataTable GetRequisitionInfo(string requisitionNo, string employeeId, string headOfficeId, string branchOfficeId)
        {
            DataTable dt = new DataTable();
            PoOrderDAL objPoOrderDAL = new PoOrderDAL();
            dt = objPoOrderDAL.GetRequisitionInfo(requisitionNo, employeeId, headOfficeId, branchOfficeId);
            return dt;
        }

        public PoOrderDTO searchPoOrderRecordMain(string strRequisitionNo, string strPoNumber, string strIssueDate, string strDeliveryDate,string strHeadOfficeId, string strBranchOfficeId)
        {


            PoOrderDTO objPoOrderDTO = new PoOrderDTO();
            PoOrderDAL objPoOrderDAL = new PoOrderDAL();

            objPoOrderDTO = objPoOrderDAL.searchPoOrderRecordMain(strRequisitionNo, strPoNumber, strIssueDate, strDeliveryDate, strHeadOfficeId, strBranchOfficeId);

            return objPoOrderDTO;


        }

        public PoOrderDTO searchPoOrderRecordFinalMain(string strPoNumber, string strIssueDate, string strDeliveryDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            PoOrderDTO objPoOrderDTO = new PoOrderDTO();
            PoOrderDAL objPoOrderDAL = new PoOrderDAL();

            objPoOrderDTO = objPoOrderDAL.searchPoOrderRecordFinalMain(strPoNumber, strIssueDate, strDeliveryDate, strHeadOfficeId, strBranchOfficeId);

            return objPoOrderDTO;


        }
        public DataTable SearchPoRequisitionNo(string strPoRequisitionNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();

            PoOrderDAL objPoOrderDAL = new PoOrderDAL();


            dt = objPoOrderDAL.SearchPoRequisitionNo(strPoRequisitionNo, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable SearchPoNo(string strPoNumber, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();

            PoOrderDAL objPoOrderDAL = new PoOrderDAL();


            dt = objPoOrderDAL.SearchPoNo(strPoNumber, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
    }
}
