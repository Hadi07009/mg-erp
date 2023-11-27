using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class ContractBLL
    {

        public string saveContractInfo(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();
            string strMsg = objContractDAL.saveContractInfo(objContractDTO);
            return strMsg;
        }

        public string saveContractInfoPre(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();
            string strMsg = objContractDAL.saveContractInfoPre(objContractDTO);
            return strMsg;
        }

        public string saveContractInfoNull(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();
            string strMsg = objContractDAL.saveContractInfoNull(objContractDTO);
            return strMsg;
        }

        public string saveContractInfoTemp(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();
            string strMsg = objContractDAL.saveContractInfoTemp(objContractDTO);
            return strMsg;
        }



        public string deleteContractInfo(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();
            string strMsg = objContractDAL.deleteContractInfo(objContractDTO);
            return strMsg;
        }

        public string deleteContractInfoRecord(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();
            string strMsg = objContractDAL.deleteContractInfoRecord(objContractDTO);
            return strMsg;
        }

        public string updateContractInfo(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();
            string strMsg = objContractDAL.updateContractInfo(objContractDTO);
            return strMsg;
        }

        public DataTable searchContactRecord(ContractDTO objContractDTO)
        {

            DataTable dt = new DataTable();
            ContractDAL objContractDAL = new ContractDAL();


            dt = objContractDAL.searchContactRecord(objContractDTO);
            return dt;

        }

        public DataTable searchContactRecordSub(ContractDTO objContractDTO)
        {

            DataTable dt = new DataTable();
            ContractDAL objContractDAL = new ContractDAL();


            dt = objContractDAL.searchContactRecordSub(objContractDTO);
            return dt;

        }


        public ContractDTO searcContactMain(string strContactNo, string strIssueDate,string strAmmendDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractDAL objContractDAL = new ContractDAL();

            objContractDTO = objContractDAL.searcContactMain(strContactNo, strIssueDate, strAmmendDate, strHeadOfficeId, strBranchOfficeId);

            return objContractDTO;


        }

        public ContractDTO searchAmmendmentId(string strContactNo, string strIssueDate, string strAmmendDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractDAL objContractDAL = new ContractDAL();

            objContractDTO = objContractDAL.searchAmmendmentId(strContactNo, strIssueDate, strAmmendDate, strHeadOfficeId, strBranchOfficeId);

            return objContractDTO;


        }


        public ContractDTO searcAmendDate(string strAmendId, string strContactNo, string strIssueDate, string strAmmendDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractDAL objContractDAL = new ContractDAL();

            objContractDTO = objContractDAL.searcAmendDate(strAmendId, strContactNo, strIssueDate, strAmmendDate, strHeadOfficeId, strBranchOfficeId);

            return objContractDTO;


        }

        ///////////////////////////////////////
        public string saveContractBooking(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();
            string strMsg = objContractDAL.saveContractBooking(objContractDTO);
            return strMsg;
        }

        public DataTable searchContactBookingRecord(ContractDTO objContractDTO)
        {

            DataTable dt = new DataTable();
            ContractDAL objContractDAL = new ContractDAL();


            dt = objContractDAL.searchContactBookingRecord(objContractDTO);
            return dt;

        }

        public string deleteContractBooking(ContractDTO objContractDTO)
        {

            ContractDAL objContractDAL = new ContractDAL();
            string strMsg = objContractDAL.deleteContractBooking(objContractDTO);
            return strMsg;
        }


    }
}
