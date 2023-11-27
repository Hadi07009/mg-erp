using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;
using SINHA.MEDLAR.ERP.DTO.ViewModels;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class LookUpBLL
    {


        #region "DML"

        public DataTable GetSalaryByUnitGroup_Test(string strHeadOfficeId,string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.GetSalaryByUnitGroup_Test(strHeadOfficeId, strBranchOfficeId);
            return dt;
        }
        public DataTable loadUnitRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadUnitRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable getPoUnitId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPoUnitId();
            return dt;

        }

        public string saveSizeNameForPacking(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveSizeNameForPacking(objLookUpDTO);
            return strMsg;


        }

        public DataTable getSizeNameId(string strPO, string strStyleNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSizeNameId(strPO, strStyleNo, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public LookUpDTO searchUnderSizeNaneInfo(string strSizeNameId, string strPONO, string strStyleNO, string strHeadOfficeId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchUnderSizeNaneInfo(strSizeNameId, strPONO, strStyleNO, strHeadOfficeId, strBranchOffieId);
            return objLookUpDTO;

        }
        public DataTable loadSizeNameForPacking(string strPO, string strStyleNo,string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSizeNameForPacking( strPO, strStyleNo, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable loadSizeName(string strPO, string strStyleNo)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSizeName(strPO, strStyleNo);
            return dt;

        }
        public LookUpDTO searchSizeNameForPacking(string strBarcodeNumber)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchSizeNameForPacking(strBarcodeNumber);
            return objLookUpDTO;

        }
        public LookUpDTO searchTotalOrderQuantity(string strPONO, string strStyleNO, string strHeadOfficeId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchTotalOrderQuantity(strPONO, strStyleNO, strHeadOfficeId, strBranchOffieId);
            return objLookUpDTO;

        }
        public LookUpDTO searchOrderQuantity(string strPONO, string strStyleNO, string strHeadOfficeId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchOrderQuantity(strPONO, strStyleNO, strHeadOfficeId, strBranchOffieId);
            return objLookUpDTO;

        }
        public DataTable loadVFPackingRecord(string strStyleNO, string strpackingDate, string strPoNO, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadVFPackingRecord(strStyleNO, strpackingDate, strPoNO, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public string saveVFPackingList(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveVFPackingList(objLookUpDTO);
            return strMsg;


        }

        public LookUpDTO chckQtyPerCutton(string strSizeNameId, int strcount, string strPONO, string strStyleNO, string strHeadOfficeId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.chckQtyPerCutton(strSizeNameId, strcount, strPONO, strStyleNO, strHeadOfficeId, strBranchOffieId);
            return objLookUpDTO;

        }
        public string saveIncrementLockSetup(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            strMsg = objLookUpDAL.saveIncrementLockSetup(objLookUpDTO);
            return strMsg;
        }


        public LookUpDTO searchEmpShift(string strShiftTypeId, string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            objLookUpDTO = objLookUpDAL.searchEmpShift(strShiftTypeId, strHeadOffieId, strBranchOffieId);
            return objLookUpDTO;
        }


        public DataTable loadIncrementLockSetup(string strYear, string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadIncrementLockSetup(strYear, strHeadOffieId, strBranchOffieId);
            return dt;

        }
        public string savePoUnitName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.savePoUnitName(objLookUpDTO);
            return strMsg;


        }



        public DataTable loadPoUnitRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadPoUnitRecord();
            return dt;

        }

        public string saveHolidayTypeInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveHolidayTypeInfo(objLookUpDTO);
            return strMsg;


        }
        public DataTable getShipmentModeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getShipmentModeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable getPartshipmentId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPartshipmentId();
            return dt;

        }

        public string saveLeaveTypeInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveLeaveTypeInfo(objLookUpDTO);
            return strMsg;


        }

        public LookUpDTO searchLeaveTypeEntry(string strLeaveId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchLeaveTypeEntry(strLeaveId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchShiftType(string strsearchShiftTypeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchShiftType(strsearchShiftTypeId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }



        public DataTable loadLeaveTypeRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadLeaveTypeRecord();
            return dt;

        }

        public DataTable getPoSupplierId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPoSupplierId();
            return dt;

        }
        public DataTable GetPurchager()
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.GetPurchager();
            return dt;
        }

        //
        public DataTable loadDeliverRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadDeliverRecord();
            return dt;

        }
        public string saveSupplierInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveSupplierInfo(objLookUpDTO);
            return strMsg;


        }
        public DataTable getDeliverToId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getDeliverToId();
            return dt;

        }
        public DataTable getPaymentModeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPaymentModeId();
            return dt;

        }
        public string saveDeliverInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveDeliverInfo(objLookUpDTO);
            return strMsg;


        }
        public DataTable loadPurchaseRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadPurchaseRecord();
            return dt;

        }
        public LookUpDTO searchDeliverToEntry(string strOfficeID, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchDeliverToEntry(strOfficeID, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public LookUpDTO searchSupplierEntry(string strSupplierID, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchSupplierEntry(strSupplierID, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public DataTable getTranshipmentId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getTranshipmentId();
            return dt;

        }
        public LookUpDTO searchPurchaseEntry(string strOfficeID, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchPurchaseEntry(strOfficeID, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public string savePurchaseInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.savePurchaseInfo(objLookUpDTO);
            return strMsg;


        }
        public DataTable getPurchareId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPurchareId();
            return dt;

        }
        public string saveTranshipmentInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveTranshipmentInfo(objLookUpDTO);
            return strMsg;


        }
        public DataTable loadPartshipmentRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadPartshipmentRecord();
            return dt;

        }
        public string savePaymentModeInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.savePaymentModeInfo(objLookUpDTO);
            return strMsg;


        }


        public LookUpDTO searchHolidayInfo(string strHolidayId, string strFromDate, string strToDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchHolidayInfo(strHolidayId, strFromDate, strToDate, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }


        public LookUpDTO searchPaymentModeEntry(string strPaymentModeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchPaymentModeEntry(strPaymentModeId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public DataTable loadTranshipmentRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadTranshipmentRecord();
            return dt;

        }
        public LookUpDTO searchTranshipmentEntry(string strTranShipmentId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchTranshipmentEntry(strTranShipmentId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public string savePartshipmentInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.savePartshipmentInfo(objLookUpDTO);
            return strMsg;


        }
        public LookUpDTO searchPartshipmentEntry(string strPartShipmentId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchPartshipmentEntry(strPartShipmentId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public DataTable loadPaymentModeRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadPaymentModeRecord();
            return dt;

        }
        public DataTable loadPoSupplierRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadPoSupplierRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public string saveGenderInfoInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveGenderInfoInfo(objLookUpDTO);
            return strMsg;


        }
        public string saveReligionInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveReligionInfo(objLookUpDTO);
            return strMsg;


        }
        public string saveDistrictInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveDistrictInfo(objLookUpDTO);
            return strMsg;


        }
        public string saveNationalityInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveNationalityInfo(objLookUpDTO);
            return strMsg;


        }
        public string saveJobTypeInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveJobTypeInfo(objLookUpDTO);
            return strMsg;


        }
        public string saveJobLocationInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveJobLocationInfo(objLookUpDTO);
            return strMsg;


        }
        public string saveEmployeeTypeInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveEmployeeTypeInfo(objLookUpDTO);
            return strMsg;


        }
        public string saveTrainPeriodInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveTrainPeriodInfo(objLookUpDTO);
            return strMsg;


        }
        public string saveOccurenceTypeInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveOccurenceTypeInfo(objLookUpDTO);
            return strMsg;


        }
        public string savePaymentTypeInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.savePaymentTypeInfo(objLookUpDTO);
            return strMsg;


        }
        public LookUpDTO searchGenderEntry(string strGenderId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchGenderEntry(strGenderId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public LookUpDTO searchReligionEntry(string strReligionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchReligionEntry(strReligionId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public LookUpDTO searchDistrictEntry(string strDistrictId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchDistrictEntry(strDistrictId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public LookUpDTO searchNationalityEntry(string strNationalityId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchNationalityEntry(strNationalityId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public LookUpDTO searchJobTypeEntry(string strJobTypeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchJobTypeEntry(strJobTypeId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public LookUpDTO searchJobLocationEntry(string strJobLocationId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchJobLocationEntry(strJobLocationId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public LookUpDTO searchEmployeeTypeEntry(string strEmployeeTypeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchEmployeeTypeEntry(strEmployeeTypeId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public LookUpDTO searchTrainPeriodEntry(string strEmployeeTypeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchTrainPeriodEntry(strEmployeeTypeId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public LookUpDTO searchOccurenceTypeEntry(string strOccurenceTypeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchOccurenceTypeEntry(strOccurenceTypeId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public LookUpDTO searchPaymentTypeEntry(string strPaymentTypeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchPaymentTypeEntry(strPaymentTypeId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public DataTable loadGenderRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadGenderRecord();
            return dt;

        }
        public DataTable loadReligionRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadReligionRecord();
            return dt;

        }
        public DataTable loadDistrictRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadDistrictRecord();
            return dt;

        }
        public DataTable loadNationalityRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadNationalityRecord();
            return dt;

        }
        public DataTable loadJobTypeRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadJobTypeRecord();
            return dt;

        }
        public DataTable loadJobLocationRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadJobLocationRecord();
            return dt;

        }
        public DataTable loadEmployeeTypeRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadEmployeeTypeRecord();
            return dt;

        }
        public DataTable loadTrainPeriodRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadTrainPeriodRecord();
            return dt;

        }
        public DataTable loadOccurenceTypeRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadOccurenceTypeRecord();
            return dt;

        }
        public DataTable loadPaymentTypeRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadPaymentTypeRecord();
            return dt;

        }

        public string saveSeasonInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveSeasonInfo(objLookUpDTO);
            return strMsg;


        }
        public LookUpDTO searchSeasonInfo(string strSeasonId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchSeasonInfo(strSeasonId);
            return objLookUpDTO;

        }
        public DataTable loadSeasonRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSeasonRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public string deleteEmpMenu(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objSalaryDAL = new LookUpDAL();
            string strMsg = objSalaryDAL.deleteEmpMenu(objLookUpDTO);
            return strMsg;
        }

        public string addMenuOperationInfo(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objSalaryDAL = new LookUpDAL();
            string strMsg = objSalaryDAL.addMenuOperationInfo(objLookUpDTO);
            return strMsg;
        }

        public string saveRequiusitionInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveRequiusitionInfo(objLookUpDTO);
            return strMsg;


        }

        public string SparePartsFileSave(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.SparePartsFileSave(objLookUpDTO);
            return strMsg;


        }

        public string saveMenuRecord(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveMenuRecord(objLookUpDTO);
            return strMsg;


        }


        public string saveLoginEmployeeInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();
            
            strMsg = objLookUpDAL.saveLoginEmployeeInfo(objLookUpDTO);
            return strMsg;
            
        }


        public string saveLineWiseOperator(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            strMsg = objLookUpDAL.saveLineWiseOperator(objLookUpDTO);
            return strMsg;
        }

        public string saveProductInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveProductInfo(objLookUpDTO);
            return strMsg;


        }

        public LookUpDTO searchProductInfo(string strProductTranId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchProductInfo(strProductTranId);
            return objLookUpDTO;

        }
        //search Requisition Info
        public LookUpDTO searchRequisitionInfo(string strTranId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchRequisitionInfo(strTranId);
            return objLookUpDTO;

        }

        public LookUpDTO searchLoginEmployeeInfo(string strEmployeeId, string strHeadOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchLoginEmployeeInfo(strEmployeeId, strHeadOfficeId);
            return objLookUpDTO;

        }


        public DataTable loadProductInfo(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadProductInfo(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public string saveFileUpload(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveFileUpload(objLookUpDTO);
            return strMsg;


        }

        public DataTable DownloadFile(int strTranId)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.DownloadFile(strTranId);
            return dt;
        }

        public LookUpDTO getFileInfo(int id, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getFileInfo(id, strYear, strMonth, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;
        }


        public DataTable loadFileUploadRecord(string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadFileUploadRecord(strYear, strMonth, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public string saveDHUWorkingDaySetup(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            strMsg = objLookUpDAL.saveDHUWorkingDaySetup(objLookUpDTO);
            return strMsg;
        }



        public string saveSalaryLockSetup(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            strMsg = objLookUpDAL.saveSalaryLockSetup(objLookUpDTO);
            return strMsg;
        }

        public string saveLeaveLockSetup(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            strMsg = objLookUpDAL.saveLeaveLockSetup(objLookUpDTO);
            return strMsg;
        }


        public string saveStaffSalary(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveStaffSalary(objLookUpDTO);
            return strMsg;


        }

        public string saveWorkerSalarySetup(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveWorkerSalarySetup(objLookUpDTO);
            return strMsg;


        }


        public string saveUnitInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveUnitInfo(objLookUpDTO);
            return strMsg;


        }


        public string saveWorkerSalaryByGrade(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveWorkerSalaryByGrade(objLookUpDTO);
            return strMsg;


        }


        public string saveTiffinfee(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveTiffinfee(objLookUpDTO);
            return strMsg;


        }

        public DataTable loadTiffinFee(string strHeadOffieId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadTiffinFee(strHeadOffieId, strBranchOfficeId);
            return dt;

        }

        public string saveVendorBankInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveVendorBankInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveManufactureBankInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveManufactureBankInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveVendorInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveVendorInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveShipTypeInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveShipTypeInfo(objLookUpDTO);
            return strMsg;


        }

        public string savePaymentTermInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.savePaymentTermInfo(objLookUpDTO);
            return strMsg;


        }
        public string saveShipInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveShipInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveManufactureInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveManufactureInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveItemInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveItemInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveCompnayInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveCompnayInfo(objLookUpDTO);
            return strMsg;


        }


        public string savePartInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.savePartInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveEquipmentInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveEquipmentInfo(objLookUpDTO);
            return strMsg;


        }

        public string savePartCategoryInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.savePartCategoryInfo(objLookUpDTO);
            return strMsg;


        }

        public string deleteSparePart(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteSparePart(objLookUpDTO);
            return strMsg;


        }


        public string deleteEquipmentInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteEquipmentInfo(objLookUpDTO);
            return strMsg;


        }

        public string deleteSparePartCategory(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteSparePartCategory(objLookUpDTO);
            return strMsg;


        }


        public string saveThreadPrice(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveThreadPrice(objLookUpDTO);
            return strMsg;


        }

        public string saveHangerPrice(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveHangerPrice(objLookUpDTO);
            return strMsg;


        }

        public string saveSewingThreadPrice(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveSewingThreadPrice(objLookUpDTO);
            return strMsg;


        }

        public string savePolyBagSetup(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.savePolyBagSetup(objLookUpDTO);
            return strMsg;


        }

        public string saveThreadOpeningBlance(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveThreadOpeningBlance(objLookUpDTO);
            return strMsg;


        }

        public string saveHoliday(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();
            strMsg = objLookUpDAL.saveHoliday(objLookUpDTO);
            return strMsg;
        }

        public string SaveShiftEmployeeHoliday(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();
            strMsg = objLookUpDAL.SaveShiftEmployeeHoliday(objLookUpDTO);
            return strMsg;
        }

        public string DeleteHoliday(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.DeleteHoliday(objLookUpDTO);
            return strMsg;


        }


        public string saveZipperColor(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveZipperColor(objLookUpDTO);
            return strMsg;


        }

        public string saveProcessName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveProcessName(objLookUpDTO);
            return strMsg;


        }

        public string saveTopInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveTopInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveMachineInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveMachineInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveBottomInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveBottomInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveSectionProcess(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveSectionProcess(objLookUpDTO);
            return strMsg;


        }

        public string saveProgrammeSection(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveProgrammeSection(objLookUpDTO);
            return strMsg;


        }

        public string saveProgramme(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveProgramme(objLookUpDTO);
            return strMsg;


        }

        public string saveMainProcess(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveMainProcess(objLookUpDTO);
            return strMsg;


        }

        public string saveFrontCategory(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveFrontCategory(objLookUpDTO);
            return strMsg;


        }

        public string saveAuxiliaryProcess(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveAuxiliaryProcess(objLookUpDTO);
            return strMsg;


        }

        public string saveLineName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveLineName(objLookUpDTO);
            return strMsg;


        }

        public string saveProductInformation(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveProductInformation(objLookUpDTO);
            return strMsg;


        }


        public string saveArtInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveArtInfo(objLookUpDTO);
            return strMsg;


        }

        public string deleteProcessName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteProcessName(objLookUpDTO);
            return strMsg;


        }

        public string deleteLineName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteLineName(objLookUpDTO);
            return strMsg;


        }

        public string deleteProductName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteProductName(objLookUpDTO);
            return strMsg;


        }

        public string deleteArtInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteArtInfo(objLookUpDTO);
            return strMsg;


        }

        public string deleteTopInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteTopInfo(objLookUpDTO);
            return strMsg;


        }

        public string deleteMachineInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteMachineInfo(objLookUpDTO);
            return strMsg;


        }

        public string deleteBottomInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteBottomInfo(objLookUpDTO);
            return strMsg;


        }

        public string deleteSectionProcess(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteSectionProcess(objLookUpDTO);
            return strMsg;


        }

        public string deleteProgrammeSection(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteProgrammeSection(objLookUpDTO);
            return strMsg;


        }
        public string deleteProgramme(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteProgramme(objLookUpDTO);
            return strMsg;


        }

        public string deleteMainProcess(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteMainProcess(objLookUpDTO);
            return strMsg;


        }

        public string deleteFrontCategory(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteFrontCategory(objLookUpDTO);
            return strMsg;


        }

        public string deleteAuxiliaryProcess(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteAuxiliaryProcess(objLookUpDTO);
            return strMsg;


        }

        public string saveStoreInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveStoreInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveImporterInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveImporterInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveForeignButtonColor(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveForeignButtonColor(objLookUpDTO);
            return strMsg;


        }

        public string saveSupervisorInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveSupervisorInfo(objLookUpDTO);
            return strMsg;


        }


        public string saveHalfSalaryInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveHalfSalaryInfo(objLookUpDTO);
            return strMsg;


        }

        public string leaveSave(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();
            
            strMsg = objLookUpDAL.leaveSave(objLookUpDTO);
            return strMsg;
            
        }

        public string saveShiftInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();
            strMsg = objLookUpDAL.saveShiftInfo(objLookUpDTO);
            return strMsg;
        }

        public string SaveShiftConfiguration(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();
            strMsg = objLookUpDAL.SaveShiftConfiguration(objLookUpDTO);
            return strMsg;
        }

        #region Special Shift Configuration
        public string SaveSpecialShiftConfiguration(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();
            strMsg = objLookUpDAL.SaveSpecialShiftConfiguration(objLookUpDTO);
            return strMsg;
        }
        public DataTable GetSpecialShiftConfiguration(string headOfficeId, string branchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.GetSpecialShiftConfiguration(headOfficeId, branchOfficeId);
            return dt;
        }
        #endregion


        public string saveEidInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveEidInfo(objLookUpDTO);
            return strMsg;


        }

        public string savePromotionEffectdate(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.savePromotionEffectdate(objLookUpDTO);
            return strMsg;


        }

        public string saveHeadOfficeInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveHeadOfficeInfo(objLookUpDTO);
            return strMsg;


        }

        //Head Office Info Search
        public LookUpDTO searchHeadOfficeInfo(string strHeadOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchHeadOfficeInfo(strHeadOfficeId);
            return objLookUpDTO;

        }

        public DataTable loadBranchOfficeRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadBranchOfficeRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public string saveBranchOfficeInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveBranchOfficeInfo(objLookUpDTO);
            return strMsg;


        }


        //
        //Branch Office Info Search
        public LookUpDTO searchBranchOfficeInfo(string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchBranchOfficeInfo(strBranchOfficeId);
            return objLookUpDTO;

        }
        //


        public string saveBloodGroupInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveBloodGroupInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveGrade(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveGrade(objLookUpDTO);
            return strMsg;


        }

        public string saveBuyerInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveBuyerInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveCGPInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveCGPInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveCountryInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveCountryInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveCourseInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveCourseInfo(objLookUpDTO);
            return strMsg;


        }

        public string SaveFebricconstruction(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.SaveFebricconstruction(objLookUpDTO);
            return strMsg;


        }

        public string saveFabricName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveFabricName(objLookUpDTO);
            return strMsg;


        }

        public string saveStyleName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveStyleName(objLookUpDTO);
            return strMsg;


        }

        public string saveBrandName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveBrandName(objLookUpDTO);
            return strMsg;


        }

        public string saveCurrencyName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveCurrencyName(objLookUpDTO);
            return strMsg;


        }

        public string saveSupplierType(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveSupplierType(objLookUpDTO);
            return strMsg;


        }

        public string saveColorName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveColorName(objLookUpDTO);
            return strMsg;


        }


        public string saveDepartment(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveDepartment(objLookUpDTO);
            return strMsg;


        }
        public string saveDesignation(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveDesignation(objLookUpDTO);
            return strMsg;


        }

        public string saveEmployeeCatagory(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveEmployeeCatagory(objLookUpDTO);
            return strMsg;


        }
        public string saveSection(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveSection(objLookUpDTO);
            return strMsg;


        }
        public string saveTotalOrderQty(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveTotalOrderQty(objLookUpDTO);
            return strMsg;


        }
        #endregion
        public string SaveBuyerInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.SaveBuyerInfo(objLookUpDTO);
            return strMsg;


        }


        public string SavePOtypeInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.SavePOtypeInfo(objLookUpDTO);
            return strMsg;


        }

        public DataTable loadLineInfo(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadLineInfo(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public LookUpDTO searchLineInfo(string strLineId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchLineInfo(strLineId);
            return objLookUpDTO;

        }

        public string SaveLineInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.SaveLineInfo(objLookUpDTO);
            return strMsg;


        }

        public LookUpDTO searchColorInfo(string strBuyerId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchColorInfo(strBuyerId);
            return objLookUpDTO;

        }


        public string SaveColorInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.SaveColorInfo(objLookUpDTO);
            return strMsg;


        }

        public string saveSalaryPaymentDateInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();

            strMsg = objLookUpDAL.saveSalaryPaymentDateInfo(objLookUpDTO);
            return strMsg;

        }


        public DataTable loadSalaryPaymentDateInfo(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSalaryPaymentDateInfo(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }




        public LookUpDTO getSalaryMonthId(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getSalaryMonthId(objLookUpDTO);
            return objLookUpDTO;

        }

        public DataTable loadBuyerRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadBuyerRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;


        }

        public LookUpDTO searchHolidayTypeEntry(string strHolidayId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchHolidayTypeEntry(strHolidayId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public DataTable loadHolidayTypeRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadHolidayTypeRecord();
            return dt;

        }

        //load Requisition Info
        public DataTable searchMenuOperationInfoEntry(string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objTiffinDAL = new LookUpDAL();


            dt = objTiffinDAL.searchMenuOperationInfoEntry(strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getEmployeeId(string strProcessId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getEmployeeId(strProcessId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadRequisitionInfo(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadRequisitionInfo(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public LookUpDTO getDeviceInfo(string strProductId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getDeviceInfo(strProductId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public DataTable getProductCategory(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getProductCategory(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadDHUWorkingDaySetup(string strYear, string strMonth, string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadDHUWorkingDaySetup(strYear, strMonth, strHeadOffieId, strBranchOffieId);
            return dt;

        }

        public DataTable loadLineWiseOperator(string strYear, string strMonth, string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadLineWiseOperator(strYear, strMonth, strHeadOffieId, strBranchOffieId);
            return dt;

        }

        public DataTable loadSalaryLockSetup(string strYear, string strMonth, string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSalaryLockSetup(strYear, strMonth, strHeadOffieId, strBranchOffieId);
            return dt;

        }

        public DataTable loadLeaveLockSetup(string strYear, string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadLeaveLockSetup(strYear, strHeadOffieId, strBranchOffieId);
            return dt;

        }

        public DataTable loadStaffSalary(string strHeadOffieId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadStaffSalary(strHeadOffieId, strBranchOfficeId);
            return dt;

        }

        public LookUpDTO searchUnitInfo(string strUnitId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchUnitInfo(strUnitId);
            return objLookUpDTO;

        }

        public LookUpDTO searchSalaryByGradeInfo(string strYear, string strGradeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchSalaryByGradeInfo(strYear, strGradeId);
            return objLookUpDTO;

        }




        public DataTable loadHOSalarySetup(string strHeadOffieId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadHOSalarySetup(strHeadOffieId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadWorkerSalarySetup(string strHeadOffieId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadWorkerSalarySetup(strHeadOffieId, strBranchOfficeId);
            return dt;

        }


        public string saveHOSalarySetup(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveHOSalarySetup(objLookUpDTO);
            return strMsg;


        }
        public LookUpDTO searchVendorBankInfo(string strBankId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchVendorBankInfo(strBankId);
            return objLookUpDTO;

        }

        public LookUpDTO searchManufactureBankInfo(string strBankId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchManufactureBankInfo(strBankId);
            return objLookUpDTO;

        }

        public LookUpDTO searchVendorInfo(string strBankId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchVendorInfo(strBankId);
            return objLookUpDTO;

        }

        public LookUpDTO searchShipTypeInfo(string strShipTypeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchShipTypeInfo(strShipTypeId);
            return objLookUpDTO;

        }
        public LookUpDTO searchPaymentTermInfo(string strPaymentTermId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchPaymentTermInfo(strPaymentTermId);
            return objLookUpDTO;

        }

        public LookUpDTO searchShipInfo(string strShipId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchShipInfo(strShipId);
            return objLookUpDTO;

        }

        public LookUpDTO searchManufactureInfo(string strManufactureId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchManufactureInfo(strManufactureId);
            return objLookUpDTO;

        }

        public LookUpDTO searchItemInfo(string strItemId, string strHeadOfficeId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchItemInfo(strItemId, strHeadOfficeId, strBranchOffieId);
            return objLookUpDTO;

        }
        public LookUpDTO searchCompanyInfo(string strItemId, string strHeadOfficeId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchCompanyInfo(strItemId, strHeadOfficeId, strBranchOffieId);
            return objLookUpDTO;

        }


        public LookUpDTO searchPartInfo(string strSparePartId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchPartInfo(strSparePartId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchEquipemetInfo(string strEquipmentId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchEquipemetInfo(strEquipmentId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchPartCategoryInfo(string strSparePartId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchPartCategoryInfo(strSparePartId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchSupervisorName(string strSupervisorId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchSupervisorName(strSupervisorId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO getSoftwareVersion()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getSoftwareVersion();
            return objLookUpDTO;

        }

        public LookUpDTO searchDepartment(string strDepartmentId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchDepartment(strDepartmentId);
            return objLookUpDTO;

        }



        public LookUpDTO searchLoginEmployeeName(string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchLoginEmployeeName(strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }


        public LookUpDTO searchImporterEntry(string strImportId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchImporterEntry(strImportId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchZipperColorEntry(string strColorId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchZipperColorEntry(strColorId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }


        public LookUpDTO searchForeignButtonColor(string strForeignButtonColorId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchForeignButtonColor(strForeignButtonColorId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchFebricConstruction(string strFebricConstructionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchFebricConstruction(strFebricConstructionId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchFebricEntry(string strFebricId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchFebricEntry(strFebricId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchStyleEntry(string strSTyleId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchStyleEntry(strSTyleId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }


        public LookUpDTO searchColorEntry(string strColorId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchColorEntry(strColorId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchCourseEntry(string strCourseID, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchCourseEntry(strCourseID, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchProcessEntry(string strTopId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchProcessEntry(strTopId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchMachineEntry(string strMachineId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchMachineEntry(strMachineId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchCatagoryEntry(string strCatagoryId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchCatagoryEntry(strCatagoryId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchSectionEntry(string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchSectionEntry(strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }


        public LookUpDTO searchProgrammeSectionEntry(string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchProgrammeSectionEntry(strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchProgrammeEntry(string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchProgrammeEntry(strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public string GetDirectoryPath()
        {
            LookUpDAL objLookUpDAL = new LookUpDAL();
            return objLookUpDAL.GetDirectoryPath();
        }

        public LookUpDTO getDirectoryName(string strHeadOfficeId, string strBranchOfficeId)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getDirectoryName(strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;
        }

        public LookUpDTO getTitileName(string strHeadOfficeId, string strBranchOfficeId, string strSoftId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getTitileName(strHeadOfficeId, strBranchOfficeId, strSoftId);
            return objLookUpDTO;

        }

        public LookUpDTO getYearMonth()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getYearMonth();
            return objLookUpDTO;

        }

        public LookUpDTO getTaxEntryPermission(string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getTaxEntryPermission(strYear, strMonth, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }


        public LookUpDTO getTransferMsg(string strEmployeeId, string strTransferYear, string strTransferMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getTransferMsg(strEmployeeId, strTransferYear, strTransferMonth, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }


        public LookUpDTO getDate()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getDate();
            return objLookUpDTO;

        }


        public LookUpDTO getOfficeName(string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getOfficeName(strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
     

        public DataTable loadSalaryByGradeRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSalaryByGradeRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadVendorBankRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadVendorBankRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadManufactureBankRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadManufactureBankRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadVendorInfo(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadVendorInfo(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadShipTypeInfo(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadShipTypeInfo(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadPaymentTermInfo(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadPaymentTermInfo(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadShipInfo(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadShipInfo(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadManufactureInfo(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadManufactureInfo(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable loadItemRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadItemRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadCompanyRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadCompanyRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadPartRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadPartRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable loadEquipmentRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadEquipmentRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable loadPartCategoryRecord(string strPartId, string strPartNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadPartCategoryRecord(strPartId, strPartNo, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadPartCategoryRecordForMonthlyStore(string strPartNo, string strEquipementId, string strSparePartId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadPartCategoryRecordForMonthlyStore(strPartNo, strEquipementId, strSparePartId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable loadSparePartFileRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSparePartFileRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable loadIncrementSetupRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadIncrementSetupRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadIncrementSetupRecordYearly(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadIncrementSetupRecordYearly(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable loadSupervisorRecrod(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSupervisorRecrod(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadLeaveEffectRecord(string strYear, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadLeaveEffectRecord(strYear, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable loadOfficeRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadOfficeRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        #region "Load Drop Down List"
        public DataTable getGenderId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getGenderId();
            return dt;

        }

        public DataTable getLoginEmpId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getLoginEmpId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getSoftwareId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSoftwareId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable getPartId(string strEquipementId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPartId(strEquipementId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getSparePartId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSparePartId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getEquipementId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getEquipementId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable getArtId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getArtId();
            return dt;

        }


        public DataTable getFabricDescriptionId(string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getFabricDescriptionId(strBuyerId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getFabricDescriptionSymbolicId(string strFabricId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getFabricDescriptionSymbolicId(strFabricId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getStyleIdFOBBudget(string strPOId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getStyleIdFOBBudget(strPOId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }



        public DataTable getManufacturerId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getManufacturerId();
            return dt;

        }

        public DataTable getAmendmentId(string strContractNo, string strIssueDate, string strAmmendDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getAmendmentId(strContractNo, strIssueDate, strAmmendDate, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable getPaymentTermId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPaymentTermId();
            return dt;

        }


        public DataTable getVandorId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getVandorId();
            return dt;

        }

        public DataTable getVandorBankId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getVandorBankId();
            return dt;

        }

        public DataTable getShipId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getShipId();
            return dt;

        }

        public DataTable getShipTypeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getShipTypeId();
            return dt;

        }



        public DataTable getManufacturerBankId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getManufacturerBankId();
            return dt;

        }


        public DataTable getStoreId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getStoreId();
            return dt;

        }

        public DataTable getProgrammeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getProgrammeId();
            return dt;

        }

        public DataTable getBrandId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getBrandId();
            return dt;

        }

        public DataTable getCurrencyId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getCurrencyId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getMonthId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getMonthId();
            return dt;

        }



        public DataTable getWorkingDay(string strQuery)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getWorkingDay(strQuery);
            return dt;

        }

        public DataTable getMaritalStatusId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getMaritalStatusId();
            return dt;

        }
        public DataTable getApprovedId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getApprovedId();
            return dt;

        }

        public DataTable getApprovedIdForCertificate()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getApprovedIdForCertificate();
            return dt;

        }

        public DataTable getReligionId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getReligionId();
            return dt;

        }

        public DataTable getBloodGroupId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getBloodGroupId();
            return dt;

        }

        public DataTable getCourseId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getCourseId();
            return dt;

        }

        public DataTable getInstituteId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getInstituteId();
            return dt;

        }

        public DataTable getSubjectId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSubjectId();
            return dt;

        }

        public DataTable getCGPAId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getCGPAId();
            return dt;

        }

        public DataTable getJobId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getJobId();
            return dt;

        }

        public DataTable getSupervisorId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSupervisorId();
            return dt;

        }


        public DataTable getUnitId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getUnitId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable GetPaymentPhase()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.GetPaymentPhase();
            return dt;
        }
        public DataTable GetAllBank()
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetAllBank();
            return dt;

        }
        public DataTable GetIncrementType()
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetIncrementType();
            return dt;
        }

        public DataTable GetIncrementType2()
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetIncrementType2();
            return dt;
        }


        public DataTable getMachineIdParts(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getMachineIdParts(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getSupplierInfo(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSupplierInfo(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }





        public DataTable getUnitIdStore(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getUnitIdStore(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getSoftId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSoftId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getUnitIdForPurchase()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getUnitIdForPurchase();
            return dt;

        }

        public DataTable getProductId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getProductId();
            return dt;

        }


        public DataTable getUnitIdTo(string strOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getUnitIdTo(strOfficeId);
            return dt;

        }

        public DataTable getUnitIdToByOfficeId(string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getUnitIdToByOfficeId(strBranchOfficeId);
            return dt;

        }


        //Load Head Office Record
        public DataTable loadHeadOfficeRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadHeadOfficeRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable getTopId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getTopId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getSectionProcessId(string strProcessId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSectionProcessId(strProcessId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getMainProcessId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getMainProcessId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getProgrammeSectionId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getProgrammeSectionId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getMachineId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getMachineId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getCategoryId(string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getCategoryId(strSectionId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getBottomId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getBottomId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getAuxiliaryProcessId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getAuxiliaryProcessId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getProcess(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getProcess(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable GetEmpProcess(string EmployeeId, string CardNo)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.GetEmpProcess(EmployeeId, CardNo);
            return dt;

        }
        public DataTable getProcessId(string strCardNo, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getProcessId(strCardNo, strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getDepartmentId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getDepartmentId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getBSizeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getBSizeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getTB(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getTB(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getProcessSelectTypeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getProcessSelectTypeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getGradeId(string strHeadOfficeId, string strBranchOfficeId)
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.getGradeId(strHeadOfficeId, strBranchOfficeId);
            return dt;
        }

        //
        public DataTable GetGrade(string strHeadOfficeId, string strBranchOfficeId)
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetGrade(strHeadOfficeId, strBranchOfficeId);
            return dt;
        }
        public DataTable GetGradeByDesignationId(string designationId, string headOfficeId, string branchOfficeId)
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetGradeByDesignationId(designationId, headOfficeId, branchOfficeId);
            return dt;
        }

        public DataTable getBloodGroupId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getBloodGroupId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getSupplierTYpeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSupplierTYpeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable getIESizeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getIESizeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getWorkerProcessId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getWorkerProcessId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getMachineBrandId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getMachineBrandId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getMachineRegionId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getMachineRegionId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getMachineModelId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getMachineModelId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getMachineTypeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getMachineTypeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getLogInTimeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getLogInTimeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getLogOutTimeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getLogOutTimeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getLunchInTimeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getLunchInTimeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable getLunchOutTimeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getLunchOutTimeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getUnitIdFrom(string strHeadOfficeId, string strHeadOfficeIdFrom)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getUnitIdFrom(strHeadOfficeId, strHeadOfficeIdFrom);
            return dt;

        }
        public DataTable getUnitIdTo(string strHeadOfficeId, string strHeadOfficeIdTo)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getUnitIdTo(strHeadOfficeId, strHeadOfficeIdTo);
            return dt;

        }

        public DataTable getUnitIdForInactive(string strHeadOfficeId, string strOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getUnitIdForInactive(strHeadOfficeId, strOfficeId);
            return dt;

        }


        public DataTable getOfficeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getOfficeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable getFromMonthId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getFromMonthId();
            return dt;

        }

        public DataTable getToMonthId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getToMonthId();
            return dt;

        }


        public DataTable getEidTypeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getEidTypeId();
            return dt;

        }

        public DataTable getEidId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getEidId();
            return dt;

        }

        public DataTable getSectionId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSectionId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable getUnitGroupId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getUnitGroupId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable getHeadOfficeId(string strHeadOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getHeadOfficeId(strHeadOfficeId);
            return dt;

        }


        public DataTable getLetterTypeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getLetterTypeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getSectionIdForPurchase()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSectionIdForPurchase();
            return dt;

        }


        public DataTable getEmployeeTypeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getEmployeeTypeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }



        public DataTable getRequisitionId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getRequisitionId();
            return dt;

        }

        public DataTable getUnitIdMedlar()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getUnitIdMedlar();
            return dt;

        }

        public DataTable getUnitIdJK()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getUnitIdJK();
            return dt;

        }
        public DataTable getSectionIdMedlar()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSectionIdMedlar();
            return dt;

        }

        public DataTable getSectionIdJK()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSectionIdJK();
            return dt;

        }

        public DataTable getDesignationId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getDesignationId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getDesignation(string GradeId, string strHeadOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getDesignation(GradeId, strHeadOfficeId);
            return dt;

        }
        public DataTable getCatagoryId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getCatagoryId();
            return dt;

        }

        public DataTable getSalaryEntryTypeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSalaryEntryTypeId();
            return dt;

        }
        public DataTable getSalaryProcessTypeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSalaryProcessTypeId();
            return dt;

        }
        public DataTable getBonusProcessTypeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getBonusProcessTypeId();
            return dt;

        }
        public DataTable getTiffinProcessTypeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getTiffinProcessTypeId();
            return dt;

        }
        public DataTable getIncrementProcessTypeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getIncrementProcessTypeId();
            return dt;

        }

        public DataTable getHolidayId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getHolidayId();
            return dt;

        }

        public DataTable getDepartmentId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getDepartmentId();
            return dt;

        }

        public DataTable getNationalityId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getNationalityId();
            return dt;

        }

        public DataTable geTitleId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.geTitleId();
            return dt;

        }

        public DataTable getBranchOfficeId(string strHeadOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getBranchOfficeId(strHeadOfficeId);
            return dt;

        }


        public DataTable getJobLocationId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getJobLocationId();
            return dt;

        }

        public DataTable getEmployeeTypeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getEmployeeTypeId();
            return dt;

        }

        public DataTable getPaymentTypeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPaymentTypeId();
            return dt;

        }

        public DataTable getShiftId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getShiftId();
            return dt;

        }
        public DataTable getPeriodtId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPeriodtId();
            return dt;

        }

        public DataTable getOccurenceTypeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getOccurenceTypeId();
            return dt;

        }

        public DataTable getDivisionId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getDivisionId();
            return dt;

        }

        public DataTable getDistrictId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getDistrictId();
            return dt;

        }

        public DataTable getEmpId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getEmpId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getEmpIdForProcess(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getEmpIdForProcess(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getLeaveId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getLeaveId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getEmployeeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getEmployeeId();
            return dt;

        }


        public DataTable getEmployeeSearch(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getEmployeeSearch(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }




        #endregion


        #region "Load Grid"
        public DataTable loadDesignationRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadDesignationRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadSubjectRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSubjectRecord();
            return dt;

        }

        public DataTable loadArrearRecord(string headOfficeId, string branchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadArrearRecord(headOfficeId, branchOfficeId);
            return dt;

        }

        public DataTable loadWorkerPromotionEffectDate(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadWorkerPromotionEffectDate(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadEidRecord(string strEidYear, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadEidRecord(strEidYear, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable loadEmployeeCatagoryRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadEmployeeCatagoryRecord();
            return dt;

        }

        public DataTable loadHeadOfficeRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadHeadOfficeRecord();
            return dt;

        }

        public DataTable loadHolidayRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadHolidayRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadBloodGroupRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadBloodGroupRecord();
            return dt;

        }

        public DataTable loadGradeRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadGradeRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadHalfSalaryInfo(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadHalfSalaryInfo(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable loadBuyerRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadBuyerRecord();
            return dt;

        }

        public DataTable loadSupplierRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSupplierRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadWokerProcess()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadWokerProcess();
            return dt;

        }

        public DataTable loadMachineTypeRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadMachineTypeRecord();
            return dt;

        }

        public DataTable searchMachineEntryResult()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.searchMachineEntryResult();
            return dt;

        }

        public DataTable loadMachineRegionRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadMachineRegionRecord();
            return dt;

        }

        public DataTable loadMachineModelRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadMachineModelRecord();
            return dt;

        }

        public DataTable loadMachineBranchRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadMachineBranchRecord();
            return dt;

        }


        public DataTable loadSize()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSize();
            return dt;

        }

        public DataTable loadCGPARecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadCGPARecord();
            return dt;

        }

        public DataTable loadCountryRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadCountryRecord();
            return dt;

        }


        public DataTable loadCourseRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadCourseRecord();
            return dt;

        }


        public DataTable loadFebricConstruction()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadFebricConstruction();
            return dt;

        }
        public DataTable loadFebricName()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadFebricName();
            return dt;

        }

        public DataTable loadStyleName()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadStyleName();
            return dt;

        }

        public DataTable loadCurrencyRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadCurrencyRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadBrandRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadBrandRecord();
            return dt;

        }


        public DataTable loadSupplierType()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSupplierType();
            return dt;

        }

        public DataTable loadColor()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadColor();
            return dt;

        }






        public DataTable loadEmployeeRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadEmployeeRecord();
            return dt;

        }

        public DataTable getEmployeeImage()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.getEmployeeImage();
            return dt;

        }

        public DataTable loadDepartmentRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadDepartmentRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable loadShiftRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadShiftRecord();
            return dt;

        }
        //public DataTable loadShiftRecord()
        //{

        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpDAL objLookUpDAL = new LookUpDAL();
        //    DataTable dt = new DataTable();

        //    dt = objLookUpDAL.loadShiftRecord();
        //    return dt;

        //}
        
        public DataTable GetShiftConfiguration(string headOfficeId, string branchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.GetShiftConfiguration(headOfficeId, branchOfficeId);
            return dt;
        }

        public string SaveRoster(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.SaveRoster(objLookUpDTO);
            return strMsg;
        }

        public DataTable LoadRoster(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.LoadRoster(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable LoadRosterSequence(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.LoadRosterSequence(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public List<EmployeeShiftMapping> GetRosterSpecificEmployee(string headOfficeId, string branchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

           var objMapping = objLookUpDAL.GetRosterSpecificEmployee(headOfficeId, branchOfficeId);
            return objMapping;
        }

        public string ProcessRostering(LookUpDTO objLookUp)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            
            var message = objLookUpDAL.ProcessRostering(objLookUp);
            return message;
        }

        

        public List<EmployeeShiftMapping> GetShiftingTimeSchedule(decimal shiftId, string effectDate, string headOfficeId, string branchOfficeId)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            var objTimeSchedule = objLookUpDAL.GetShiftingTimeSchedule(shiftId, effectDate, headOfficeId, branchOfficeId);
            return objTimeSchedule;
        }

        public DataTable loadSectionRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSectionRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadQtyRecordRecord(string strPONO, string strStyleNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadQtyRecordRecord( strPONO,  strStyleNo, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        #endregion


        public LookUpDTO getMonthYear()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getMonthYear();
            return objLookUpDTO;

        }

        public LookUpDTO getMonthYearForAdvance()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getMonthYearForAdvance();
            return objLookUpDTO;

        }



        public LookUpDTO getMonthYearForTax()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getMonthYearForTax();
            return objLookUpDTO;

        }

        public LookUpDTO getCurrentDate()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getCurrentDate();
            return objLookUpDTO;

        }


        public LookUpDTO getMonthYearForSalary()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getMonthYearForSalary();
            return objLookUpDTO;

        }

        public LookUpDTO GetPreIncrementMonthYear(string increment_year, string increment_month, string branch_office_id)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.GetPreIncrementMonthYear(increment_year, increment_month, branch_office_id);
            return objLookUpDTO;
        }

        public LookUpDTO getMonthYearForSalaryForIncApprove(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getMonthYearForSalaryForIncApprove(strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }


        public LookUpDTO getMonthDay()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getMonthDay();
            return objLookUpDTO;

        }


        public LookUpDTO getMonthYearForLeave()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getMonthYearForLeave();
            return objLookUpDTO;

        }


        public LookUpDTO getEffectiveDate(string strYear, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getEffectiveDate(strYear, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }


        public LookUpDTO getLeaveSetupTypeId(string strLeaveId, string strYear, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getLeaveSetupTypeId(strLeaveId, strYear, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }


        public LookUpDTO getYearForIncrementProposal(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getYearForIncrementProposal(strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        //new
        public LookUpDTO GetLastIncrementProposal(string employeeTypeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.GetLastIncrementProposal(employeeTypeId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO getYearForIncrementYear(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getYearForIncrementYear(strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }



        public LookUpDTO getIncrementEffectDate(string strYear, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getIncrementEffectDate(strYear, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO getAttendencePrivilaged(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getAttendencePrivilaged(strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO getMonthYearForHalSalary(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getMonthYearForHalSalary(strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO getArrearYear(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getArrearYear(strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO getMonthYearForInactive()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getMonthYearForInactive();
            return objLookUpDTO;

        }

        public DataTable getBuyerId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getBuyerId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getContractId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getContractId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getPOId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPOId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getStyleId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getStyleId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable getImporterId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getImporterId();
            return dt;

        }

        public DataTable getBuyerIdStore(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getBuyerIdStore(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getProductionUnitId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getProductionUnitId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getPONo(string strContactNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPONo(strContactNo, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable getStyleNo(LookUpDTO objLookUpDTO)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getStyleNo(objLookUpDTO);
            return dt;

        }

        public DataTable getStyleId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getStyleId();
            return dt;

        }

        public DataTable getStyleNo(string strContractNo, string strPOId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getStyleNo(strContractNo, strPOId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }

        public DataTable getContractStyleId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getContractStyleId();
            return dt;

        }


        public DataTable getContractPOId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getContractPOId();
            return dt;

        }



        public DataTable getSupplierId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSupplierId();
            return dt;

        }

        public DataTable getThreadSupplierId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getThreadSupplierId();
            return dt;

        }

        public DataTable getStyleIdStore()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getStyleIdStore();
            return dt;

        }

        public DataTable getArtNo()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getArtNo();
            return dt;

        }

        public DataTable getImporter()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getImporter();
            return dt;

        }


        public DataTable getAllBranchOfficeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getAllBranchOfficeId();
            return dt;

        }

        public DataTable getProductionUnit(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getProductionUnit(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadSalaryUnitRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSalaryUnitRecord();
            return dt;

        }

        public DataTable getSalaryUnitId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSalaryUnitId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getStyleIdByLine(string strLineId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getStyleIdByLine(strLineId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public LookUpDTO getPercentAmount(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getPercentAmount(strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public DataTable getItemId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getItemId();
            return dt;

        }



        public DataTable getLineId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getLineId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getEfficiencyId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getEfficiencyId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable loadLineRecord(string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.loadLineRecord(strBranchOfficeId);
            return dt;

        }

        public DataTable loadPercentageAmount()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadPercentageAmount();
            return dt;

        }

        public DataTable loadPOTypeRecord()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.loadPOTypeRecord();
            return dt;

        }

        public DataTable loadFactoryRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadFactoryRecord();
            return dt;

        }

        public DataTable loadBankRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadBankRecord();
            return dt;

        }

        public DataTable getPOIdByLine(string strLineId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPOIdByLine(strLineId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getSizeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSizeId();
            return dt;

        }


        public DataTable getShippingId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getShippingId();
            return dt;

        }
        public DataTable getPONo(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPONo(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getPONoByBuyer(string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPONoByBuyer(strBuyerId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable loadStyleRecord()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.loadStyleRecord();
            return dt;

        }

        public DataTable loadProductionUnitRecord()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.loadProductionUnitRecord();
            return dt;

        }

        public DataTable loadColorRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadColorRecord();
            return dt;

        }

        public DataTable loadZipperColorRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadZipperColorRecord();
            return dt;

        }

        public DataTable loadProcessRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadProcessRecord();
            return dt;

        }

        public DataTable searchProcessRecord(string strTopId, string strBottomId, string strAuxiliaryProcessId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.searchProcessRecord(strTopId, strBottomId, strAuxiliaryProcessId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }




        public DataTable loadTopRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadTopRecord();
            return dt;

        }

        public DataTable loadTopRecordByName(string strProcessName)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadTopRecordByName(strProcessName);
            return dt;

        }

        public DataTable loadMachineRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadMachineRecord();
            return dt;

        }

        public DataTable loadBottomRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadBottomRecord();
            return dt;

        }
        public DataTable loadProgrammeSectionRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadProgrammeSectionRecord();
            return dt;

        }

        public DataTable loadProgrammeRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadProgrammeRecord();
            return dt;

        }

        public DataTable loadSectionProcessRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSectionProcessRecord();
            return dt;

        }

        public DataTable loadMainProcessRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadMainProcessRecord();
            return dt;

        }

        public DataTable loadFrontCatagoryRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadFrontCatagoryRecord();
            return dt;

        }

        public DataTable loadAuxiliaryProcessRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadAuxiliaryProcessRecord();
            return dt;

        }


        public DataTable loadLineRecord(string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadLineRecord(strHeadOffieId, strBranchOffieId);
            return dt;

        }

        public DataTable loadProductRecord(string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadProductRecord(strHeadOffieId, strBranchOffieId);
            return dt;

        }


        public DataTable loadArtRecord(string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadArtRecord(strHeadOffieId, strBranchOffieId);
            return dt;

        }

        public DataTable loadStoreRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadStoreRecord();
            return dt;

        }

        public DataTable loadImporterRecord(string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadImporterRecord(strHeadOffieId, strBranchOffieId);
            return dt;

        }

        public DataTable loadForeignButtonColorRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadForeignButtonColorRecord();
            return dt;

        }

        public DataTable LoadThreadRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.LoadThreadRecord();
            return dt;

        }

        public DataTable LoadHangerRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.LoadHangerRecord();
            return dt;

        }

        public DataTable loadSewingThreadPrice()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSewingThreadPrice();
            return dt;

        }

        public DataTable loadPolyBagSetup()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadPolyBagSetup();
            return dt;

        }


        public DataTable getCurrId()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.getCurrId();
            return dt;

        }

        public DataTable getBrand()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.getBrand();
            return dt;

        }

        public DataTable LoadThreadOpeningRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.LoadThreadOpeningRecord();
            return dt;

        }

        public DataTable loadBasicSize(string strHeadOfficeId, string strBranchOffiecId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadBasicSize(strHeadOfficeId, strBranchOffiecId);
            return dt;

        }

        public DataTable getSeasonId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSeasonId();
            return dt;

        }
        public DataTable getPOIdContract(string strContractId,  string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPOIdContract(strContractId,  strHeadOfficeId, strBranchOffiecId);
            return dt;

        }
        public DataTable getStyleIdContract(string strContractId, string strPOId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getStyleIdContract(strContractId, strPOId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }

        public DataTable getBuyerIdContract(string strContractNo, string strPOId,string strStyleId, string strFOBDate, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getBuyerIdContract(strContractNo, strPOId, strStyleId, strFOBDate, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }

        public DataTable getBuyerIdContract()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getBuyerIdContract();
            return dt;

        }

        public DataTable getSeasonIdContract(string strContractNo, string strPOId, string strStyleId, string strFOBDate, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSeasonIdContract(strContractNo, strPOId, strStyleId, strFOBDate, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }


        public DataTable getPOTypeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPOTypeId();
            return dt;

        }
        public DataTable getColorIdContract()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getColorIdContract();
            return dt;

        }
        public DataTable getColorId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getColorId();
            return dt;

        }

        public DataTable getColorIdStore()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getColorIdStore();
            return dt;

        }

        public DataTable getSewingColorId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSewingColorId();
            return dt;

        }

        public DataTable getFabricId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getFabricId();
            return dt;

        }
        public DataTable getFabricIdByProgramme(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getFabricIdByProgramme(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }

        public DataTable getFabricIdFromPOAssign(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getFabricIdFromPOAssign(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }


        public DataTable getFabricConstructionIdByProgramme(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getFabricConstructionIdByProgramme(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }

        public DataTable getFabricConstructionIdFromPOAssign(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getFabricConstructionIdFromPOAssign(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }


        public DataTable getStyleIdByProgramme(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getStyleIdByProgramme(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }

        public DataTable getStyleIdFromPOAssign(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getStyleIdFromPOAssign(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }


        public DataTable getArtIdByProgramme(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getArtIdByProgramme(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }

        public DataTable getArtIdFromPOAssign(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getArtIdFromPOAssign(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }

        public DataTable getColorIdByProgramme(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getColorIdByProgramme(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }

        public DataTable getColorIdFromPOAssign(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getColorIdFromPOAssign(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }


        public DataTable getUnitIdByProgramme(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getUnitIdByProgramme(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }

        public DataTable getUnitIdFromPOAssign(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getUnitIdFromPOAssign(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }

        public DataTable getCurrencyIdFromPOAssign(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOffiecId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getCurrencyIdFromPOAssign(strSupplierId, strProgrammeId, strHeadOfficeId, strBranchOffiecId);
            return dt;

        }

        public DataTable getConstructionId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getConstructionId();
            return dt;

        }

        public DataTable getMeasureId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getMeasureId();
            return dt;

        }


        public DataTable loadLoginEmployeeInfo(string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadLoginEmployeeInfo(strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public LookUpDTO searchMenuRecord(string strMenuId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchMenuRecord(strMenuId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;
        }


        public DataTable loadMenuRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadMenuRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable searchMenuOperationInfo(string strSoftId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.searchMenuOperationInfo(strSoftId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public LookUpDTO searchBloodGroupEntry(string strBloodGroupId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchBloodGroupEntry(strBloodGroupId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO searchArrearBonusInfo(string strTranId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchArrearBonusInfo(strTranId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public string saveBonusLockSetup(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            strMsg = objLookUpDAL.saveBonusLockSetup(objLookUpDTO);
            return strMsg;
        }
        public DataTable loadBonusLockSetup(string strEidTypeId, string strEidYear, string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadBonusLockSetup(strEidTypeId, strEidYear, strHeadOffieId, strBranchOffieId);
            return dt;

        }

        public DataTable loadArrearBonusRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadArrearBonusRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public string saveArrearBonusInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveArrearBonusInfo(objLookUpDTO);
            return strMsg;


        }



        public List<string> SearchRequisitionNo(string strRequisitionNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            // DataTable dt = new DataTable();
            List<string> allRequisitionNo = new List<string>();

            LookUpDAL objLookUpDAL = new LookUpDAL();


            allRequisitionNo = objLookUpDAL.SearchRequisitionNo(strRequisitionNo, strHeadOfficeId, strBranchOfficeId);
            return allRequisitionNo;

        }

        public List<string> SearchRequisitionNoFromPOtracking(string strRequisitionNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            // DataTable dt = new DataTable();
            List<string> allRequisitionNo = new List<string>();

            LookUpDAL objLookUpDAL = new LookUpDAL();


            allRequisitionNo = objLookUpDAL.SearchRequisitionNoFromPOtracking(strRequisitionNo, strHeadOfficeId, strBranchOfficeId);
            return allRequisitionNo;

        }




        public List<string> SearchPartNo(string strRequisitionNo, string strPartNo, string strHeadOfficeId, string strBranchOfficeId)
        {


            List<string> allPartNo = new List<string>();

            LookUpDAL objLookUpDAL = new LookUpDAL();


            allPartNo = objLookUpDAL.SearchPartNo(strRequisitionNo, strPartNo, strHeadOfficeId, strBranchOfficeId);
            return allPartNo;

        }

        public List<string> SearchPartNoFromPOTracking(string strRequisitionNo, string strPartNo, string strHeadOfficeId, string strBranchOfficeId)
        {


            List<string> allPartNo = new List<string>();

            LookUpDAL objLookUpDAL = new LookUpDAL();


            allPartNo = objLookUpDAL.SearchPartNoFromPOTracking(strRequisitionNo, strPartNo, strHeadOfficeId, strBranchOfficeId);
            return allPartNo;

        }


        public List<string> SearchPoNumber(string strPoNumber, string strHeadOfficeId, string strBranchOfficeId)
        {

            // DataTable dt = new DataTable();
            List<string> allPoNumber = new List<string>();

            LookUpDAL objLookUpDAL = new LookUpDAL();


            allPoNumber = objLookUpDAL.SearchPoNumber(strPoNumber, strHeadOfficeId, strBranchOfficeId);
            return allPoNumber;

        }

        public List<string> SearchPartNoFromMonthlyStore(string strRequisitionNo, string strPartNo, string strHeadOfficeId, string strBranchOfficeId)
        {


            List<string> allPartNo = new List<string>();

            LookUpDAL objLookUpDAL = new LookUpDAL();


            allPartNo = objLookUpDAL.SearchPartNoFromMonthlyStore(strRequisitionNo, strPartNo, strHeadOfficeId, strBranchOfficeId);
            return allPartNo;

        }

        public DataTable loadColorRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadColorRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public LookUpDTO searchPOTypeInfo(string strPOTypeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchPOTypeInfo(strPOTypeId);
            return objLookUpDTO;

        }
        public string SaveProductionUnitInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.SaveProductionUnitInfo(objLookUpDTO);
            return strMsg;


        }

        public DataTable loadPOTypeRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadPOTypeRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;


        }

        public LookUpDTO searchBuyerInfo(string strBuyerId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchBuyerInfo(strBuyerId);
            return objLookUpDTO;

        }

        public DataTable loadProductionLineRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadProductionLineRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public string SaveSalaryUnitInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.SaveSalaryUnitInfo(objLookUpDTO);
            return strMsg;


        }

        public LookUpDTO searchSalaryUnitInfo(string strSalaryUnitId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchSalaryUnitInfo(strSalaryUnitId);
            return objLookUpDTO;

        }
        public string SaveStyleInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.SaveStyleInfo(objLookUpDTO);
            return strMsg;


        }

        public DataTable loadSalaryLineRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSalaryLineRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public LookUpDTO searchStyleInfo(string strStyleId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchStyleInfo(strStyleId);
            return objLookUpDTO;

        }

        public DataTable loadStyleRecord(string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadStyleRecord(strBuyerId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public string SaveToleranceInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.SaveToleranceInfo(objLookUpDTO);
            return strMsg;


        }

        public LookUpDTO searchToleranceInfo(string strToleranceId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchToleranceInfo(strToleranceId);
            return objLookUpDTO;

        }

        public DataTable loadToleranceRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadToleranceRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable getFactoryOfficeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getFactoryOfficeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public LookUpDTO getPOId(string strPOId, string strHeadOfficeId, string strBranchOfficeId)
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            objLookUpDTO = objLookUpDAL.getPOId(strPOId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;
        }

        public DataTable getPOIdContract()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getPOIdContract();
            return dt;

        }

        public DataTable getAmendmentId(string strContractNo, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getAmendmentId(strContractNo, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getStyleIdContract()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getStyleIdContract();
            return dt;

        }


        public DataTable getStyleId(string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getStyleId(strBuyerId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable SearchStyleId(string strPONo, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.SearchStyleId(strPONo, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable getPOType(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();

            DataTable dt = new DataTable();

            dt = objLookUpDAL.getPOType(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public List<string> SearchPONo(string strPONo, string strBuyerId)
        {

            List<string> allPONo = new List<string>();

            LookUpDAL objLookUpDAL = new LookUpDAL();


            allPONo = objLookUpDAL.SearchPONo(strPONo, strBuyerId);
            return allPONo;

        }

        public LookUpDTO getPOWiseDate(string strPONo, string strHeadOfficeId, string strBranchOfficeId)
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            objLookUpDTO = objLookUpDAL.getPOWiseDate(strPONo, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;
        }
        public DataTable getStyleIdByPO(string strBuyerId, string strPONo, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getStyleIdByPO(strBuyerId, strPONo, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public string saveMeasurementDiscrepancy(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveMeasurementDiscrepancy(objLookUpDTO);
            return strMsg;



        }

        public DataTable loadMeasurementDiscrepancy(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadMeasurementDiscrepancy(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }



        public DataTable loadFabricDefect(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadFabricDefect(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public string saveFabricDefect(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveFabricDefect(objLookUpDTO);
            return strMsg;


        }



        public DataTable loadSewingStitchDefect(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSewingStitchDefect(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public string saveSewingStitchDefect(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveSewingStitchDefect(objLookUpDTO);
            return strMsg;


        }


        public string saveAestheticDefect(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveAestheticDefect(objLookUpDTO);
            return strMsg;


        }

        public DataTable loadAestheticDefectRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadAestheticDefectRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public string saveDirtyStainEntryRecord(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveDirtyStainEntryRecord(objLookUpDTO);
            return strMsg;


        }

        public DataTable loadAddDirtyStainEntryRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadAddDirtyStainEntryRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }



        public DataTable loadLeaveEncashment(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadLeaveEncashment(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public string saveLeaveEncashment(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveLeaveEncashment(objLookUpDTO);
            return strMsg;


        }

        public LookUpDTO GetHoliday(string strHeadOfficeId, string strBranchOfficeId, string year)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.GetHoliday(strHeadOfficeId, strBranchOfficeId, year);
            return objLookUpDTO;
        }


        public DataTable searchMenuInfoEntry(string strEmployeeId, string strSoftId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objTiffinDAL = new LookUpDAL();


            dt = objTiffinDAL.searchMenuInfoEntry(strEmployeeId, strSoftId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public string addMenuInfo(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objSalaryDAL = new LookUpDAL();
            string strMsg = objSalaryDAL.addMenuInfo(objLookUpDTO);
            return strMsg;
        }

        public DataTable searchMenuInfoEntryRecord(string strSoftId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objTiffinDAL = new LookUpDAL();


            dt = objTiffinDAL.searchMenuInfoEntryRecord(strSoftId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public string deleteEmployeeMenuFromGrid(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objSalaryDAL = new LookUpDAL();
            string strMsg = objSalaryDAL.deleteEmployeeMenuFromGrid(objLookUpDTO);
            return strMsg;
        }


        public DataTable getMenuName(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getMenuName(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable loadMenuInfo(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadMenuInfo(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public LookUpDTO searchMenuInfo(string strMenuId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchMenuInfo(strMenuId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public LookUpDTO getHeadOfficeName(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.getHeadOfficeName(strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public string saveMenuInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveMenuInfo(objLookUpDTO);
            return strMsg;


        }

        public DataTable getOfficeShiftTypeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getOfficeShiftTypeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable GetSpecialShift()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            
            dt = objLookUpDAL.GetSpecialShift();
            return dt;

        }


        public DataTable getShiftTypeId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getShiftTypeId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        //
        public DataTable GetShift(string branchOfficeId)
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetShift(branchOfficeId);
            return dt;
        }
        public string saveShiftTypeName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveShiftTypeName(objLookUpDTO);
            return strMsg;


        }

        public DataTable loadShiftType()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadShiftType();
            return dt;

        }

        public string saveUnitStoreName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveUnitStoreName(objLookUpDTO);
            return strMsg;


        }

        public DataTable loadUnitStoreName(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadUnitStoreName(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public LookUpDTO searchUnitStoreRecord(string strUnitId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchUnitStoreRecord(strUnitId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }

        public string saveColorSewingName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveColorSewingName(objLookUpDTO);
            return strMsg;


        }


        public DataTable loadColorSewing()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadColorSewing();
            return dt;

        }

        //Tread Supplier save
        public string saveTreadSupplierInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveTreadSupplierInfo(objLookUpDTO);
            return strMsg;


        }
        // load Tread Supplier
        public DataTable loadTreadSupplierRecord(string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadTreadSupplierRecord(strHeadOffieId, strBranchOffieId);
            return dt;

        }
        //delete tread supplier
        public string deleteSupplierInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteSupplierInfo(objLookUpDTO);
            return strMsg;


        }
        //save Tread Color
        public string saveTreadColor(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveTreadColor(objLookUpDTO);
            return strMsg;


        }

        //load tread color
        public DataTable loadTreadColorRecord(string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadTreadColorRecord(strHeadOffieId, strBranchOffieId);
            return dt;

        }
        //deleteColorInfo
        public string deleteColorInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteColorInfo(objLookUpDTO);
            return strMsg;


        }


        public string saveFabricDescriptionName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveFabricDescriptionName(objLookUpDTO);
            return strMsg;


        }
        public DataTable loadFabricDescriptionName()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadFabricDescriptionName();
            return dt;

        }

        public LookUpDTO searchFabricDescriptionRecord(string strFabricId, string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchFabricDescriptionRecord(strFabricId, strBuyerId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }


        public string saveMachineName(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveMachineName(objLookUpDTO);
            return strMsg;


        }

        public DataTable loadMachineName(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadMachineName(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public LookUpDTO searchMachineName(string strMachineId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchMachineName(strMachineId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;



        }




        /////////////////////////////////////////////////////////////////
        public DataTable getBuyerIdSearch(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getBuyerIdSearch(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getSupplierIdSearch(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getSupplierIdSearch(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getShipmentTypeIdSearch(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getShipmentTypeIdSearch(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataTable getImporterIdSearch(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getImporterIdSearch(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public DataTable searcContractId(string strYear, string strBuyerId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
           
            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.searcContractId(strYear, strBuyerId, strHeadOfficeId, strBranchOfficeId);

            return dt;


        }

        public DataTable searcContractId(string strYear,  string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();

            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.searcContractId(strYear, strHeadOfficeId, strBranchOfficeId);

            return dt;


        }



        public DataTable getColorName()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getColorName();
            return dt;

        }


        public string saveSalarySetupYearMonth(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.saveSalarySetupYearMonth(objLookUpDTO);
            return strMsg;


        }

        public DataTable loadSalaryMonthYear(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadSalaryMonthYear(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public string deleteSparePartInfo(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.deleteSparePartInfo(objLookUpDTO);
            return strMsg;


        }

        public DataTable loadColorContractRecord(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadColorContractRecord(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }


        public string saveIncrementProposalLockSetup(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            strMsg = objLookUpDAL.saveIncrementProposalLockSetup(objLookUpDTO);
            return strMsg;
        }


        public DataTable loadIncrementProposalLockSetup(string strYear, string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadIncrementProposalLockSetup(strYear, strHeadOffieId, strBranchOffieId);
            return dt;

        }


        public string saveArrearLockSetup(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            strMsg = objLookUpDAL.saveArrearLockSetup(objLookUpDTO);
            return strMsg;
        }

        public DataTable loadArrearLockSetup(string strYear, string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadArrearLockSetup(strYear, strHeadOffieId, strBranchOffieId);
            return dt;

        }

        public string SavePromotionPermission(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            strMsg = objLookUpDAL.SavePromotionPermission(objLookUpDTO);
            return strMsg;
        }
        public DataTable GetPromossionPermission(LookUpDTO objLookUpDTO)
        {
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.GetPromossionPermission(objLookUpDTO);
            return dt;
        }

        public DataTable GetActiveDesignation(LookUpDTO objLookUpDTO)
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.GetActiveDesignation(objLookUpDTO);
            return dt;
        }
        public DataTable getHeadOfficeNeme()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getHeadOfficeNeme();
            return dt;

        }
        public DataTable GetSkillLevelId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.GetSkillLevelId();
            return dt;
        }

        public DataTable GetShiftByDutyType(string dutyTypeId, string branchOfficeId)
        {
            LookUpDAL objLookUpDAL = new LookUpDAL();
            return objLookUpDAL.GetShiftByDutyType(dutyTypeId, branchOfficeId);
        }


        public DataTable GetUnitBySittingOffice(String BranchOfficeId)
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.GetUnitBySittingOffice(BranchOfficeId);
            return dt;
        }

        public DataTable GetSectionBySittingOffice(String BranchOfficeId)
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.GetSectionBySittingOffice(BranchOfficeId);
            return dt;
        }
        public DataTable GetDesigntionByName(string DesignationName)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.GetDesigntionByName(DesignationName);
            return dt;

        }


        #region ScanPack- Setup   

        public string SaveCartoonSize(LookUpDTO objLookUpDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.SaveCartoonSize(objLookUpDTO);
            return strMsg;


        }


        public DataTable LoadCartoonRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.LoadCartoonRecord();
            return dt;

        }
        public LookUpDTO searchCartoon(string strGenderId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            objLookUpDTO = objLookUpDAL.searchCartoon(strGenderId, strHeadOfficeId, strBranchOfficeId);
            return objLookUpDTO;

        }
        public string SavePackingMaster(PackingMaster objPackingMaster)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();
            strMsg = objLookUpDAL.SavePackingMaster(objPackingMaster);
            return strMsg;
        }
        public string SaveProductSizeInfo(ProductSizeInfo objProductSizeInfo)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();
            strMsg = objLookUpDAL.SaveProductSizeInfo(objProductSizeInfo);
            return strMsg;
        }
        public string SaveCartoonDetails(CartoonDetails objCartoonDetails)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();
            strMsg = objLookUpDAL.SaveCartoonDetails(objCartoonDetails);
            return strMsg;
        }

        public string SaveCartoonMapping(CartoonMapping objCartoonMapping)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();
            strMsg = objLookUpDAL.SaveCartoonMapping(objCartoonMapping);
            return strMsg;
        }
        public List<ProductSizeInfo> GetProductSizeInfo(ProductSizeInfo objProductSizeInfo)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<ProductSizeInfo> productSizeInfo = objLookUpDAL.GetProductSizeInfo(objProductSizeInfo);

            return productSizeInfo;
        }

        public EmployeeDTO GetEmployeeDetail(string employeeId)
        {
            LookUpDAL objLookUpDAL = new LookUpDAL();
            EmployeeDTO objEmployeeDTO = objLookUpDAL.GetEmployeeDetail(employeeId);

            return objEmployeeDTO;
        }
        public List<PackingMaster> GetAllPackingMaster(PackingMaster objPacking)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<PackingMaster> objPackingMaster = objLookUpDAL.GetAllPackingMaster(objPacking);

            return objPackingMaster;
        }
        public List<PackingMaster> GetPackingMaster(PackingMaster objPacking)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<PackingMaster> objPackingMaster = objLookUpDAL.GetPackingMaster(objPacking);

            return objPackingMaster;
        }
        public List<CartoonDetails> GetCartoonDetailsInfo(CartoonDetails objCartoon)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<CartoonDetails> objCartoonDetails = objLookUpDAL.GetCartoonDetailsInfo(objCartoon);

            return objCartoonDetails;
        }
        public List<CartoonMapping> GetCartoonMappingInfo(CartoonMapping objCartoon)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<CartoonMapping> objCartoonMapping = objLookUpDAL.GetCartoonMappingInfo(objCartoon);

            return objCartoonMapping;
        }
        public List<BuyerInfo> GetBuyer(string headOfficeId, string branchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<BuyerInfo> objBuyerInfo = objLookUpDAL.GetBuyer(headOfficeId, branchOfficeId);

            return objBuyerInfo;
        }
        public List<CartoonDetails> GetCartoonSize(string po_no, string style_no, string packing_master_id, string headOfficeId, string branchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<CartoonDetails> objCartoonDetails = objLookUpDAL.GetCartoonSize(po_no, style_no, packing_master_id, headOfficeId, branchOfficeId);

            return objCartoonDetails;
        }
        public List<PackingType> GetPackingType(string headOfficeId, string branchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<PackingType> objPackingType = objLookUpDAL.GetPackingType(headOfficeId, branchOfficeId);

            return objPackingType;
        }
        public List<ShipmentType> GetShipmentMode(string headOfficeId, string branchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<ShipmentType> objShipmentType = objLookUpDAL.GetShipmentMode(headOfficeId, branchOfficeId);

            return objShipmentType;
        }
        public List<SeasonInfo> GetSeason(string headOfficeId, string branchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<SeasonInfo> objSeasonInfo = objLookUpDAL.GetSeason(headOfficeId, branchOfficeId);

            return objSeasonInfo;
        }
        public List<ProductSizeInfo> GetSizeInfo(string po_no, string style_no, string packing_master_id, string headOfficeId, string branchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<ProductSizeInfo> objCartoonDetails = objLookUpDAL.GetSizeInfo(po_no, style_no, packing_master_id, headOfficeId, branchOfficeId);

            return objCartoonDetails;
        }
        public List<ManufacturerInfo> GetManufacturer(string headOfficeId, string branchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<ManufacturerInfo> objManufacturerInfo = objLookUpDAL.GetManufacturer(headOfficeId, branchOfficeId);

            return objManufacturerInfo;
        }
        public List<CartoonDTO> GetCartoon(string headOfficeId, string branchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<CartoonDTO> objCartoonDTO = objLookUpDAL.GetCartoon(headOfficeId, branchOfficeId);

            return objCartoonDTO;
        }


        public DataTable loadGazetteInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.loadGazetteInfo();
            return dt;

        }
        public DataTable GetShareHolderId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.GetShareHolderId();
            return dt;
        }
        public DataTable GetNomineeId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.GetNomineeId();
            return dt;
        }
        public DataTable GetCompanyId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.GetCompanyShare();
            return dt;

        }
        public DataTable GetEmployeeStatusId()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.GetEmployeeStatusId();
            return dt;
        }
        public string SaveEventPermission(EventPermissionDTO objEventPermissionDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();
            strMsg = objLookUpDAL.SaveEventPermission(objEventPermissionDTO);
            return strMsg;
        }
        public DataTable GetEventPermission(EventPermissionDTO objEventPermissionDTO)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetEventPermission(objEventPermissionDTO);
            return dt;
        }
        public DataTable GetMenuName()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetMenuName();
            return dt;
        }
        public string SaveSalaryPreconditionLockSetupMonthly(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            strMsg = objLookUpDAL.SaveSalaryPreconditionLockSetupMonthly(objLookUpDTO);
            return strMsg;
        }
        public string SaveDesignationParameter(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            strMsg = objLookUpDAL.SaveDesignationParameter(objLookUpDTO);
            return strMsg;
        }
        public DataTable GetSalaryPreconditionLockSetupMonthly(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.GetSalaryPreconditionLockSetupMonthly(objLookUpDTO);
            return dt;

        }
        public DataTable GetDesignationParameter(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.GetDesignationParameter(objLookUpDTO);
            return dt;

        }

        public DataTable GetFloor(string HeadOfficeId, string BranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetFloor(HeadOfficeId, BranchOfficeId);
            return dt;
        }
        
        public DataTable GetFloorDropdown(string HeadOfficeId, string BranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.GetFloor(HeadOfficeId, BranchOfficeId);

            DataRow dr1 = dt.NewRow();
            dr1["FLOOR_ID"] = "";
            dr1["FLOOR_NAME"] = "Please Select One";
            dt.Rows.InsertAt(dr1, 0); // InsertAt specified position

            return dt;
        }

        public DataTable GetEmployeeStatus()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.GetEmployeeStatus();
            return dt;

        }
        public string SavePhaseWiseSalaryLockSetup(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            strMsg = objLookUpDAL.SavePhaseWiseSalaryLockSetup(objLookUpDTO);
            return strMsg;
        }
        public DataTable GetPhaseWiseSalaryLockSetup(string Year, string Month, string HeadOffieId, string BranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.GetPhaseWiseSalaryLockSetup(Year, Month, HeadOffieId, BranchOffieId);
            return dt;

        }
        public DataTable GetPaymentType()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.GetPaymentType();
            return dt;

        }
        public DataTable GetTimeSetup(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.GetTimeSetup(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable GetShiftMapping(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.GetShiftMapping(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable GetShiftTimeMapping(string shiftId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.GetShiftTimeMapping(shiftId, strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable GetTime(string HeadOfficeId, string BranchOfficeId)
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetTime(HeadOfficeId, BranchOfficeId);
            return dt;
        }

        public DataTable GetTime(string shiftId, string headOfficeId, string branchOfficeId)
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetTime(shiftId, headOfficeId, branchOfficeId);
            return dt;
        }


        public DataTable GetUnitSection(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.GetUnitSection(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable GetDutyType()
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetDutyType();
            return dt;
        }
        public DataTable GetRosterShift()
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetRosterShift();
            return dt;
        }
        public DataTable GetRoamingType()
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetRoamingType();
            return dt;
        }
        public DataTable GetGeneralShift()
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetGeneralShift();
            return dt;
        }
        public DataTable GetOTDeductionSetup(string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.GetOTDeductionSetup(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public DataTable GetPurpose()
        {
            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetPurpose();
            return dt;
        }
        public string SaveMonthlyInactiveSetup(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            strMsg = objLookUpDAL.SaveMonthlyInactiveSetup(objLookUpDTO);
            return strMsg;
        }

        public DataTable GetMonthlyInactiveSetup(string HeadOfficeId, string BranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            dt = objLookUpDAL.GetMonthlyInactiveSetup(HeadOfficeId, BranchOfficeId);
            return dt;
        }
       
        public DataTable GetUI(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.GetUI(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }
        public string SavePaymentRule(LookUpDTO objLookUpDTO)
        {

            LookUpDAL objLookUpDAL = new LookUpDAL();
            string strMsg = "";

            strMsg = objLookUpDAL.SavePaymentRule(objLookUpDTO);
            return strMsg;
        }
        public string SaveDisableEvent(EventPermissionDTO objEventPermissionDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.SaveDisableEvent(objEventPermissionDTO);
            return strMsg;
        }
        public string SaveUserInterface(EventPermissionDTO objEventPermissionDTO)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();


            strMsg = objLookUpDAL.SaveUserInterface(objEventPermissionDTO);
            return strMsg;
        }
        public DataTable GetUserInterface()
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetUserInterface();
            return dt;
        }
        public DataTable GetDisableEvent(string MenuId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();

            dt = objLookUpDAL.GetDisableEvent(MenuId);
            return dt;
        }
        public DataTable GetUserInterface(EventPermissionDTO objEventPermissionDTO)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetUserInterface(objEventPermissionDTO);
            return dt;
        }
        public DataTable GetDisableEvent(EventPermissionDTO objEventPermissionDTO)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            dt = objLookUpDAL.GetDisableEvent(objEventPermissionDTO);
            return dt;
        }

        #endregion

        #region ScanPack- Operation 

        public List<CartoonSummary> GetCartoonSummary(string poNo, string styleNo, string headOfficeId, string branchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<CartoonSummary> objCartoonSummaries = objLookUpDAL.GetCartoonSummary(poNo, styleNo, headOfficeId, branchOfficeId);

            //List<CartoonSummary> objCartoonSummaries = new List<CartoonSummary>();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    CartoonSummary objCartoon = new CartoonSummary();
            //    objCartoon.CARTOON_ID = dt.Rows[i]["CARTOON_ID"].ToString();
            //    objCartoon.CARTOON_SIZE = dt.Rows[i]["CARTOON_SIZE"].ToString();
            //    objCartoon.po_no = dt.Rows[i]["po_no"].ToString();
            //    objCartoon.style_no = dt.Rows[i]["style_no"].ToString();
            //    objCartoonSummaries.Add(objCartoon);
            //}

            return objCartoonSummaries;
        }
        public List<CartoonDetail> GetCartoonDetail(string cartoonId, string poNo, string styleNo, string headOfficeId, string branchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpDAL objLookUpDAL = new LookUpDAL();
            DataTable dt = new DataTable();

            List<CartoonDetail> objCartoonSummaries = objLookUpDAL.GetCartoonDetail(cartoonId, poNo, styleNo, headOfficeId, branchOfficeId);

            //List<CartoonSummary> objCartoonSummaries = new List<CartoonSummary>();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    CartoonSummary objCartoon = new CartoonSummary();
            //    objCartoon.CARTOON_ID = dt.Rows[i]["CARTOON_ID"].ToString();
            //    objCartoon.CARTOON_SIZE = dt.Rows[i]["CARTOON_SIZE"].ToString();
            //    objCartoon.po_no = dt.Rows[i]["po_no"].ToString();
            //    objCartoon.style_no = dt.Rows[i]["style_no"].ToString();
            //    objCartoonSummaries.Add(objCartoon);
            //}

            return objCartoonSummaries;
        }

        public string SaveProduct(LookUpDTO objLookUpDTO, out string status)
        {
            string strMsg = "";
            LookUpDAL objLookUpDAL = new LookUpDAL();
            strMsg = objLookUpDAL.SaveProduct(objLookUpDTO, out status);
            return strMsg;
        }


        #endregion

    }

}

//public DataTable GetShiftByDutyType(string dutyTypeId, string branchOfficeId)