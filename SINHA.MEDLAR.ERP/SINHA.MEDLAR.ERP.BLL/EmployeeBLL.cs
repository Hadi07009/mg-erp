using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class EmployeeBLL
    {

        public string LogSchedule(string infoType, string info)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.LogSchedule(infoType,  info);
            return strMsg;
        }

        public string saveEmployeeInfo(EmployeeDTO objEmployeeDTO, out string EmpId)
        {
            string strMsg = "";
            
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.saveEmployeeInfo(objEmployeeDTO, out EmpId);
            return strMsg;
        }
        public string UpdateEmployeeInfo(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.UpdateEmployeeInfo(objEmployeeDTO);
            return strMsg;
        }
        public string SaveImage(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveImage(objEmployeeDTO);
            return strMsg;
        }

        public string SaveSignatureImage(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveSignatureImage(objEmployeeDTO);
            return strMsg;
        }

        public string processManualAttendenceSheetSearch(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.processManualAttendenceSheetSearch(objEmployeeDTO);
            return strMsg;


        }



        public string EmployeeLeaveSave(LeaveDTO objLeaveDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.EmployeeLeaveSave(objLeaveDTO);
            return strMsg;


        }

        public string uploadEmployeeDesFile(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.uploadEmployeeDesFile(objEmployeeDTO);
            return strMsg;


        }


        public string saveCounselingInfo(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.saveCounselingInfo(objEmployeeDTO);
            return strMsg;


        }



        public string saveActiveEmployee(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.saveActiveEmployee(objEmployeeDTO);
            return strMsg;


        }

        public string saveInactiveEmployee(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.saveInactiveEmployee(objEmployeeDTO);
            return strMsg;


        }

        public string saveEmployeeCard(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.saveEmployeeCard(objEmployeeDTO);
            return strMsg;


        }

        public string SaveIdCard(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveIdCard(objEmployeeDTO);
            return strMsg;
        }
               
        //
        public string SaveCase(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveCase(objEmployeeDTO);
            return strMsg;
        }

        public string ReorderCase(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.ReorderCase(objEmployeeDTO);
            return strMsg;
        }

        public string RemoveCase(string employeeId)
        {
            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.RemoveCase(employeeId);
            return strMsg;
        }

        public string saveIncrementLetter(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.saveIncrementLetter(objEmployeeDTO);
            return strMsg;


        }
        public string deleteEmployeeIdCard(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.deleteEmployeeIdCard(objEmployeeDTO);
            return strMsg;


        }
        public string deleteIncrementLetter(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.deleteIncrementLetter(objEmployeeDTO);
            return strMsg;


        }

        public string saveEmployeeAttendence(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.saveEmployeeAttendence(objEmployeeDTO);
            return strMsg;   
        }

        public string saveEmployeeAttendenceRemarks(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.saveEmployeeAttendenceRemarks(objEmployeeDTO);
            return strMsg;
        }

        public string saveEmployeeAttendenceNewJoin(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.saveEmployeeAttendenceNewJoin(objEmployeeDTO);
            return strMsg;
        }

        public string processManualAttendence(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.processManualAttendence(objEmployeeDTO);
            return strMsg;


        }

        public string deleteManualAttendence(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.deleteManualAttendence(objEmployeeDTO);
            return strMsg;


        }
        
        public string processManualAttendenceForBP(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.processManualAttendenceForBP(objEmployeeDTO);
            return strMsg;


        }


        public string addSalaryCertificateInfo(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.addSalaryCertificateInfo(objEmployeeDTO);
            return strMsg;


        }


        public string saveSubjectInfo(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.saveSubjectInfo(objEmployeeDTO);
            return strMsg;


        }

        public string saveEmployeePreJobInfo(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.saveEmployeePreJobInfo(objEmployeeDTO);
            return strMsg;


        }

        public string saveEmployeeEducation(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.saveEmployeeEducation(objEmployeeDTO);
            return strMsg;


        }

        public string inactiveProcess(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.inactiveProcess(objEmployeeDTO);
            return strMsg;


        }

        public EmployeeDTO searchCounselingEntry(string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.searchCounselingEntry(strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;


        }


        public EmployeeDTO searchEmployeeInfo(string strEmployeeId, string strCardNo, string strHeadOfficeId, string strBranchOfficeId, string strEmpId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.searchEmployeeInfo(strEmployeeId, strCardNo, strHeadOfficeId, strBranchOfficeId, strEmpId);
            return objEmployeeDTO;


        }

        
        public EmployeeDTO GetEmployeeCacheByCacheId(string cacheId)
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.GetEmployeeCacheByCacheId(cacheId);
            return objEmployeeDTO;
        }

        public string DeleteUnpaidEmployeePermanently(string cacheId, string employeeId, string loggedInEmployee)
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            string result = objEmployeeDAL.DeleteUnpaidEmployeePermanently(cacheId, employeeId, loggedInEmployee);
            return result;
        }

        public EmployeeDTO ReadOnlyYn(string strEmployeeId,string strMonth, string strYear, string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.ReadOnlyYn(strEmployeeId, strMonth, strYear, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;


        }

        public EmployeeDTO PermissionYn(string strEmployeeId,  string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.PermissionYn(strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;


        }



        public EmployeeDTO searchAttendenceRecord(string strLogDate, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.searchAttendenceRecord(strLogDate, strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;


        }


        public EmployeeDTO searchAttendenceRecordFromAttenSearchIn(string strLogDate, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.searchAttendenceRecordFromAttenSearchIn(strLogDate, strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;


        }

        public EmployeeDTO searchAttendenceRecordFromAttenSearchLunchIn(string strLogDate, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.searchAttendenceRecordFromAttenSearchLunchIn(strLogDate, strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;


        }

        public EmployeeDTO searchAttendenceRecordFromAttenSearchLunchOut(string strLogDate, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.searchAttendenceRecordFromAttenSearchLunchOut(strLogDate, strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;


        }
        public EmployeeDTO searchAttendenceRecordFromAttenSearchFinalOut(string strLogDate, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.searchAttendenceRecordFromAttenSearchFinalOut(strLogDate, strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;


        }


        public EmployeeDTO searchEmpLeaveEntry(string strEmployeeId, string strFromDate, string strToDate, string strYear, string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.searchEmpLeaveEntry(strEmployeeId, strFromDate, strToDate, strYear, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;


        }


        public EmployeeDTO searchEmployeeStatus(string strEmployeeId, string strCardNo, string strHeadOfficeId, string strBranchOfficeId, string strEmpId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.searchEmployeeStatus(strEmployeeId, strCardNo, strHeadOfficeId, strBranchOfficeId, strEmpId);
            return objEmployeeDTO;


        }


        public EmployeeDTO searchEmployeeEducation(string strEmployeeId, string strYear, string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.searchEmployeeEducation(strEmployeeId, strYear, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;


        }

        public EmployeeDTO searchEmployeePreJobInfo(string strEmployeeId, string strJoiningDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.searchEmployeePreJobInfo(strEmployeeId, strJoiningDate, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;


        }


        public DataSet bindEmployeeRecord()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            DataSet ds = new DataSet();

            ds = objEmployeeDAL.bindEmployeeRecord();
            return ds;

        }

        public DataTable searchEmployeeRecordForPreJobInfo(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordForPreJobInfo(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeEntryRecord(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeEntryRecord(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeEductionEntryRecord(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeEductionEntryRecord(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeEducationRecordForDelete(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeEducationRecordForDelete(objEmployeeDTO);
            return dt;

        }


        public DataTable searchEmployeePreviousJobHistoryForDelete(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeePreviousJobHistoryForDelete(objEmployeeDTO);
            return dt;

        }
        public DataTable searchEmployeeRecordforAdvance(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforAdvance(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeRecordForAttendence(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordForAttendence(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeAllforAttendenceEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeAllforAttendenceEntry(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmpRecordAttendence(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmpRecordAttendence(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeRecordLastOutIsNull(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordLastOutIsNull(objEmployeeDTO);
            return dt;

        }

        public DataTable searchAttendenceEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchAttendenceEntry(objEmployeeDTO);
            return dt;

        }



        public DataTable searchEmployeeRecordforImage(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforImage(objEmployeeDTO);
            return dt;

        }

        public DataTable searchLeaveEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchLeaveEntry(objEmployeeDTO);
            return dt;

        }

        public DataTable searchLeaveSummery(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchLeaveSummery(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeRecordforSalaryCertificate(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforSalaryCertificate(objEmployeeDTO);
            return dt;

        }

        public DataTable searchSalaryCertificateEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchSalaryCertificateEntry(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeRecordforMiscEntryHO(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforMiscEntryHO(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeRecordforPunching(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforPunching(objEmployeeDTO);
            return dt;

        }


        public DataTable searchEmployeeRecordforPurchaseEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforPurchaseEntry(objEmployeeDTO);
            return dt;

        }

        public DataTable searchMonthlyBankFile(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchMonthlyBankFile(objEmployeeDTO);
            return dt;

        }

        public DataTable searchPurchaseEntryRecord(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchPurchaseEntryRecord(objEmployeeDTO);
            return dt;

        }



        public DataTable employeeRecordforTransfer(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.employeeRecordforTransfer(objEmployeeDTO);
            return dt;
        }
        //
        public DataTable GetVirtualTransfer(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetVirtualTransfer(objEmployeeDTO);
            return dt;
        }

        //
        public DataTable GetVirtualTransferByTransferId(string transferId)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetVirtualTransferByTransferId(transferId);
            return dt;
        }
        public DataTable searchEmployeeRecordforAdvanceEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforAdvanceEntry(objEmployeeDTO);
            return dt;

        }


        public DataTable searchEmployeeRecordforHalf(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforHalf(objEmployeeDTO);
            return dt;

        }


        public DataTable searchEmployeeRecordHold(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordHold(objEmployeeDTO);
            return dt;

        }


        public EmployeeDTO searchEmployeeMisc(string strEmployeeId, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();

            objEmployeeDTO = objEmployeeDAL.searchEmployeeMisc(strEmployeeId, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;

        }

        public DataTable searchInactiveEmployee(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            
            dt = objEmployeeDAL.searchInactiveEmployee(objEmployeeDTO);
            return dt;
        }


        public DataTable searchTaxEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchTaxEntry(objEmployeeDTO);
            return dt;

        }

        public DataTable searchAdvanceEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchAdvanceEntry(objEmployeeDTO);
            return dt;

        }



        public DataTable searchEmployeeInformation(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.searchEmployeeInformation(objEmployeeDTO);
            return dt;
        }
        public DataTable GetSecurityLog(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetSecurityLog(objEmployeeDTO);
            return dt;
        }

        
        public DataTable GetEmployeeById(String employeeId)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetEmployeeById(employeeId);
            return dt;
        }

        public DataTable searchEmployeeRecordForProcess(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordForProcess(objEmployeeDTO);
            return dt;

        }

        public DataTable searchJobHistory(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchJobHistory(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeSummeryInformation(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeSummeryInformation(objEmployeeDTO);
            return dt;

        }


        public DataTable searchSalaryInfoHO(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchSalaryInfoHO(objEmployeeDTO);
            return dt;

        }

        public DataTable searchPunchingInfo(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchPunchingInfo(objEmployeeDTO);
            return dt;

        }


        public DataTable searchSalaryInfoHOMISC(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchSalaryInfoHOMISC(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeRecordforHOMiscEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforHOMiscEntry(objEmployeeDTO);
            return dt;

        }


        public DataTable searchEmployeeRecordforAttendenceEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforAttendenceEntry(objEmployeeDTO);
            return dt;

        }

        public DataTable searchSalaryInfoStaff(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchSalaryInfoStaff(objEmployeeDTO);
            return dt;

        }

        public DataTable searchMiscSalaryInfoStaff(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchMiscSalaryInfoStaff(objEmployeeDTO);
            return dt;

        }


        public DataTable searchSalaryInfoWorker(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchSalaryInfoWorker(objEmployeeDTO);
            return dt;

        }

        public DataTable searchSalaryInfoResign(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchSalaryInfoResign(objEmployeeDTO);
            return dt;

        }

        public DataTable searchWorkerPromotionEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchWorkerPromotionEntry(objEmployeeDTO);
            return dt;

        }
        public DataTable searchYearlyWorkerPromotionEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchYearlyWorkerPromotionEntry(objEmployeeDTO);
            return dt;

        }



        public DataTable searchHalfSalaryInfoWorker(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchHalfSalaryInfoWorker(objEmployeeDTO);
            return dt;

        }

        public DataTable searchHalfSalaryInfoHO(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchHalfSalaryInfoHO(objEmployeeDTO);
            return dt;

        }


        public DataTable searchHalfSalaryInfoStaff(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchHalfSalaryInfoStaff(objEmployeeDTO);
            return dt;

        }



        public DataTable searchInactiveEmployeeList(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchInactiveEmployeeList(objEmployeeDTO);
            return dt;

        }

        public DataTable searchActiveEmployeeList(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();



            dt = objEmployeeDAL.searchActiveEmployeeList(objEmployeeDTO);
            return dt;

        }

        public DataTable searchIncEmployeeList(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchIncEmployeeList(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeList(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeList(objEmployeeDTO);
            return dt;

        }


        public DataTable searchWorkerBonusEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchWorkerBonusEntry(objEmployeeDTO);
            return dt;

        }


        public DataTable searchStaffBonusEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchStaffBonusEntry(objEmployeeDTO);
            return dt;

        }

        public DataTable searchBonusEntryManual(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchBonusEntryManual(objEmployeeDTO);
            return dt;

        }


        public DataTable searchOverTimeInfoWorker(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchOverTimeInfoWorker(objEmployeeDTO);
            return dt;

        }

        public DataTable searchLeaveWorker(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchLeaveWorker(objEmployeeDTO);
            return dt;

        }

        public DataTable searchLeaveStaff(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchLeaveStaff(objEmployeeDTO);
            return dt;

        }


        public DataTable searchEmployeeRecordforSalaryEntryStaff(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.searchEmployeeRecordforSalaryEntryStaff(objEmployeeDTO);
            return dt;
        }

        public DataTable GetPayableStaff(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetPayableStaff(objEmployeeDTO);
            return dt;
        }

        public DataTable searchEmployeeRecordforMiscEntryStaff(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.searchEmployeeRecordforMiscEntryStaff(objEmployeeDTO);
            return dt;
        }

        public DataTable GetPayableMiscStaff(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetPayableMiscStaff(objEmployeeDTO);
            return dt;
        }


        public DataTable searchEmployeeRecordforMiscEntryWorker(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.searchEmployeeRecordforMiscEntryWorker(objEmployeeDTO);
            return dt;
        }

        public DataTable GetPayableWorker(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetPayableWorker(objEmployeeDTO);
            return dt;
        }

        public DataTable SearchEmpForGazetteProcess(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.SearchEmpForGazetteProcess(objEmployeeDTO);
            return dt;
        }

        public DataTable searchEmployeeRecordforResignEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforResignEntry(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeRecordforTemp(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforTemp(objEmployeeDTO);
            return dt;

        }


        public DataTable searchEmployeeRecordforResignEntryOT(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforResignEntryOT(objEmployeeDTO);
            return dt;

        }

        public DataTable searchWorkerArrearEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchWorkerArrearEntry(objEmployeeDTO);
            return dt;

        }

        public DataTable searchWorkerRecordforArrear(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchWorkerRecordforArrear(objEmployeeDTO);
            return dt;

        }

        public DataTable searchWorkerRecordForProcess(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchWorkerRecordForProcess(objEmployeeDTO);
            return dt;

        }

        public DataTable searchWorkerRecord(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchWorkerRecord(objEmployeeDTO);
            return dt;

        }

        public DataTable searchOperatorRecordForVerification(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchOperatorRecordForVerification(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeProcess(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeProcess(objEmployeeDTO);
            return dt;

        }

        public DataTable searchConselingInfo(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchConselingInfo(objEmployeeDTO);
            return dt;

        }



        public DataTable searchProcessRecord(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchProcessRecord(objEmployeeDTO);
            return dt;

        }



        public DataTable searchEmployeeRecordforTransfer(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforTransfer(objEmployeeDTO);
            return dt;

        }


        public DataTable employeeRecordForYearlyPromotion(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.employeeRecordForYearlyPromotion(objEmployeeDTO);
            return dt;

        }

        public DataTable LoadWorkerPromotionRecord(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.LoadWorkerPromotionRecord(objEmployeeDTO);
            return dt;
        }

        //new
        public List<EmployeeDTO> GetEmployeePicture(EmployeeDTO objEmployeeDTO)
        {
            EmployeeDAL objEmployeeDal = new EmployeeDAL();          
            return objEmployeeDal.GetEmployeePicture(objEmployeeDTO);
        }

        public string UpdateEmployeePicture(EmployeeDTO objEmployeeDTO)
        {
            EmployeeDAL objEmployeeDal = new EmployeeDAL();
            return objEmployeeDal.UpdateEmployeePicture(objEmployeeDTO);
        }

        public List<LeaveDTO> GetEmployeeLeave(LeaveDTO objLeaveDTO)
        {
            EmployeeDAL objEmployeeDal = new EmployeeDAL();
            return objEmployeeDal.GetEmployeeLeave(objLeaveDTO);
        }

        public string UpdateEmployeeLeave(LeaveDTO objLeaveDTO)
        {
            EmployeeDAL objEmployeeDal = new EmployeeDAL();
            return objEmployeeDal.UpdateEmployeeLeave(objLeaveDTO);
        }

        //public DataTable searchEmployeeRecordforMiscEntryWorker(EmployeeDTO objEmployeeDTO)
        //{
        //    DataTable dt = new DataTable();
        //    EmployeeDAL objEmployeeDAL = new EmployeeDAL();
        //    dt = objEmployeeDAL.searchEmployeeRecordforMiscEntryWorker(objEmployeeDTO);
        //    return dt;
        //}

        public DataTable searchWorkerRecordForIncrement(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.searchWorkerRecordForIncrement(objEmployeeDTO);
            return dt;
        }
        public DataTable searchWorkerRecordForIncrementCasual(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchWorkerRecordForIncrementCasual(objEmployeeDTO);
            return dt;


        }
        public DataTable searchIncrementEntryWorkerCasual(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchIncrementEntryWorkerCasual(objEmployeeDTO);
            return dt;

        }
        public DataTable searchWorkerRecordForAnnualIncrement(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchWorkerRecordForAnnualIncrement(objEmployeeDTO);
            return dt;


        }
        //SearchAnnualIncrementNonProposalStaff
        public DataTable SearchAnnualIncrementNonProposalStaff(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.SearchAnnualIncrementNonProposalStaff(objEmployeeDTO);
            return dt;
        }

        public DataTable searchWorkerRecordForAnnualIncrementNonProposal(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchWorkerRecordForAnnualIncrementNonProposal(objEmployeeDTO);
            return dt;


        }


        public DataTable searchStaffRecordForIncrementMonthly(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchStaffRecordForIncrementMonthly(objEmployeeDTO);
            return dt;

        }

        public DataTable searchStaffRecordForIncrement(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchStaffRecordForIncrement(objEmployeeDTO);
            return dt;

        }

        public DataTable searchIncrementEntryWorker(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchIncrementEntryWorker(objEmployeeDTO);
            return dt;

        }

        public DataTable searchIncrementEntryWorkerAnnual(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchIncrementEntryWorkerAnnual(objEmployeeDTO);
            return dt;

        }

        public DataTable searchIncrementEntryWorkerNonProposal(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchIncrementEntryWorkerNonProposal(objEmployeeDTO);
            return dt;

        }
        //public DataTable searchIncrementEntryStaffNonProposal(EmployeeDTO objEmployeeDTO)
        //{
        //    DataTable dt = new DataTable();
        //    EmployeeDAL objEmployeeDAL = new EmployeeDAL();
        //    dt = objEmployeeDAL.searchIncrementEntryStaffNonProposal(objEmployeeDTO);
        //    return dt;
        //}

        public DataTable searchIncrementEntryStaffNonProposal(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.searchIncrementEntryStaffNonProposal(objEmployeeDTO);
            return dt;
        }

        public DataTable searchIncrementEntryStaff(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchIncrementEntryStaff(objEmployeeDTO);
            return dt;

        }

        public DataTable searchIncrementEntryStaffMonthly(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchIncrementEntryStaffMonthly(objEmployeeDTO);
            return dt;

        }


        public DataTable searchWorkerRecordforBonus(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchWorkerRecordforBonus(objEmployeeDTO);
            return dt;

        }

        public DataTable searchHORecordforBonus(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchHORecordforBonus(objEmployeeDTO);
            return dt;

        }

        public DataTable searchStaffRecordforBonus(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchStaffRecordforBonus(objEmployeeDTO);
            return dt;

        }

        public DataTable searchRecordforBonusManual(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchRecordforBonusManual(objEmployeeDTO);
            return dt;

        }


        public DataTable searchEmployeeRecordforSkill(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordforSkill(objEmployeeDTO);
            return dt;

        }



        public DataTable loadProcess(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.loadProcess(objEmployeeDTO);
            return dt;

        }

        public DataTable LoadWorkerSkill(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.LoadWorkerSkill(objEmployeeDTO);
            return dt;

        }


        public DataTable searchIncremenRecord(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchIncremenRecord(objEmployeeDTO);
            return dt;

        }

        public DataTable searchAdvanceArrearEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchAdvanceArrearEntry(objEmployeeDTO);
            return dt;

        }


        public DataTable searchEmployeeRecordWorker(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordWorker(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeRecordStaff(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordStaff(objEmployeeDTO);
            return dt;

        }


        public DataTable searchEmployeeRecordForHold(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordForHold(objEmployeeDTO);
            return dt;

        }

        public DataTable searchIncrementHoldInfo(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchIncrementHoldInfo(objEmployeeDTO);
            return dt;

        }


        public DataTable searchEmployeeRecord(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecord(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeeRecordEducation(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordEducation(objEmployeeDTO);
            return dt;

        }

        public DataTable searchEmployeePreJobInfo(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeePreJobInfo(objEmployeeDTO);
            return dt;

        }


        public string uploadEmpLogData(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.uploadEmpLogData(objEmployeeDTO);
            return strMsg;


        }


        public string saveEmployeeLogData(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.saveEmployeeLogData(objEmployeeDTO);
            return strMsg;


        }

        public string deleteEmployeeLog(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.deleteEmployeeLog(objEmployeeDTO);
            return strMsg;


        }

        public string employeeLogProcess(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.employeeLogProcess(objEmployeeDTO);
            return strMsg;


        }
        public string DeleteEmployeeEducation(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.DeleteEmployeeEducation(objEmployeeDTO);
            return strMsg;


        }
        public string DeleteEmployeePreviousJobHistory(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.DeleteEmployeePreviousJobHistory(objEmployeeDTO);
            return strMsg;


        }
        public DataTable searchEmpLogFile(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmpLogFile(objEmployeeDTO);
            return dt;

        }



        public EmployeeDTO getUrl(string strEmployeeId, string strMenuId, string strSoftId, string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.getUrl(strEmployeeId,strMenuId, strSoftId, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;


        }

        public EmployeeDTO getSetUpUrl(string strEmployeeId, string strMenuId, string strSoftId, string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.getSetUpUrl(strEmployeeId, strMenuId, strSoftId, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;


        }

        public EmployeeDTO getTopMenuUpUrl(string strMenuId, string strSoftId, string strHeadOfficeId, string strBranchOfficeId)
        {


            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            objEmployeeDTO = objEmployeeDAL.getTopMenuUpUrl(strMenuId, strSoftId, strHeadOfficeId, strBranchOfficeId);
            return objEmployeeDTO;


        }


        public DataTable getMenuItem(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.getMenuItem(objEmployeeDTO);
            return dt;

        }
        public DataSet getTopMenuItem(EmployeeDTO objEmployeeDTO)
        {

            DataSet ds = new DataSet();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            ds = objEmployeeDAL.getTopMenuItem(objEmployeeDTO);
            return ds;

        }

        public DataTable getSetupMenu(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.getSetupMenu(objEmployeeDTO);
            return dt;

        }


        public string deleteAttendenceAprovedEmployeeRecord(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.deleteAttendenceAprovedEmployeeRecord(objEmployeeDTO);
            return strMsg;
        }

        public string addAttendenceAprovedEmp(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.addAttendenceAprovedEmp(objEmployeeDTO);
            return strMsg;


        }

        public DataTable searchAttendenceAprovedEmployeeEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchAttendenceAprovedEmployeeEntry(objEmployeeDTO);
            return dt;

        }
        public DataTable DownloadImgEmployee(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.DownloadImgEmployee(objEmployeeDTO);
            return dt;

        }





        public DataTable searchMonthlyLunchEntryHO(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchMonthlyLunchEntryHO(objEmployeeDTO);
            return dt;

        }
        public DataTable searchEmployeeforLunchEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeforLunchEntry(objEmployeeDTO);
            return dt;

        }

        public string addSalaryAppovedProcessForEmp(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.addSalaryAppovedProcessForEmp(objEmployeeDTO);
            return strMsg;


        }

        public string addSalaryCheckedProcessForEmp(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.addSalaryCheckedProcessForEmp(objEmployeeDTO);
            return strMsg;


        }


        public string SalaryAppovedProcessForEmp(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.SalaryAppovedProcessForEmp(objEmployeeDTO);
            return strMsg;


        }

        public DataTable searchSalaryApprovedEmployeeEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchSalaryApprovedEmployeeEntry(objEmployeeDTO);
            return dt;

        }

        public DataTable searchSalaryCheckedEmployeeEntry(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchSalaryCheckedEmployeeEntry(objEmployeeDTO);
            return dt;

        }


        public DataTable LoadEmployeeSalaryCheck(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.LoadEmployeeSalaryCheck(objEmployeeDTO);
            return dt;

        }

        public DataTable LoadEmployeeSalaryApprove(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.LoadEmployeeSalaryApprove(objEmployeeDTO);
            return dt;

        }
        public DataTable searchEmployeeSalaryApprove(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeSalaryApprove(objEmployeeDTO);
            return dt;

        }





        public string deleteSalaryCheckedEmpRecord(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.deleteSalaryCheckedEmpRecord(objEmployeeDTO);
            return strMsg;
        }

        public string deleteSalaryAprovedEmpRecord(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.deleteSalaryAprovedEmpRecord(objEmployeeDTO);
            return strMsg;
        }

        public string deleteSalaryCheckEmpRecord(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.deleteSalaryCheckEmpRecord(objEmployeeDTO);
            return strMsg;
        }

        public DataTable searchEmployeeInfo(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.searchEmployeeInfo(objEmployeeDTO);
            return dt;
        }

        public DataTable GetEmployeeBasicInfo(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetEmployeeBasicInfo(objEmployeeDTO);
            return dt;
        }

        public string saveOfficeShiftTime(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.saveOfficeShiftTime(objEmployeeDTO);
            return strMsg;


        }

        public string SaveEmployeeShiftMapping(EmployeeDTO objEmployeeDTO, out string status)
        {
            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveEmployeeShiftMapping(objEmployeeDTO, out status);
            return strMsg;
        }

        public DataTable loadOfficeShiftTime(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.loadOfficeShiftTime(objEmployeeDTO);
            return dt;
        }

        public DataTable GetEmployeeShiftMapping(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetEmployeeShiftMapping(objEmployeeDTO);
            return dt;
        }


        #region Emoplyee Special Mapping
        public string SaveSpecialEmployeeShiftMapping(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveSpecialEmployeeShiftMapping(objEmployeeDTO);
            return strMsg;
        }
        public DataTable GetSpecialEmployeeShiftMapping(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetSpecialEmployeeShiftMapping(objEmployeeDTO);
            return dt;
        }
        #endregion

        public string deleteOfficeShiftTimeRecord(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.deleteOfficeShiftTimeRecord(objEmployeeDTO);
            return strMsg;
        }


        //
        //New
        public string SaveEmployeeShiftHolidayMapping(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveEmployeeShiftHolidayMapping(objEmployeeDTO);
            return strMsg;
        }

        public EmployeeShiftHolidayMapping GetEmployeeShiftHolidayMappingByMappingId(string mappingId)
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            var objMapping = objEmployeeDAL.GetEmployeeShiftHolidayMappingByMappingId(mappingId);
            return objMapping;
        }

        //03.04.2019
        public List<EmployeeDTO> GetShiftEmployeeBasicInfo(EmployeeDTO objEmployeeDTO)
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            var objList = objEmployeeDAL.GetShiftEmployeeBasicInfo(objEmployeeDTO);
            return objList;
        }

        //Old
        public string saveOfficeShiftHoliday(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.saveOfficeShiftHoliday(objEmployeeDTO);
            return strMsg;
        }

        public DataTable loadOfficeShiftHoliday(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.loadOfficeShiftHoliday(objEmployeeDTO);
            return dt;
        }

        public DataTable GetShiftEmpHolidayMappingByEmp(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetShiftEmpHolidayMappingByEmp(objEmployeeDTO);
            return dt;
        }

        public string deleteOfficeShiftHolidayRecord(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.deleteOfficeShiftHolidayRecord(objEmployeeDTO);
            return strMsg;
        }

        public string DeleteEmployeeShiftHoliday(string mappingId)
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.DeleteEmployeeShiftHoliday(mappingId);
            return strMsg;
        }
        public DataTable searchOTSalaryInfoResign(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchOTSalaryInfoResign(objEmployeeDTO);
            return dt;

        }


        public DataTable searchSalaryInfoTemp(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchSalaryInfoTemp(objEmployeeDTO);
            return dt;

        }


        public DataTable searchSalaryApproveEntryRecord(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchSalaryApproveEntryRecord(objEmployeeDTO);
            return dt;

        }
        public DataTable loadSalaryApproveEntryRecord(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.loadSalaryApproveEntryRecord(objEmployeeDTO);
            return dt;

        }

        public DataTable searchDiscardAnnualIncrementWorker(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.searchDiscardAnnualIncrementWorker(objEmployeeDTO);
            return dt;
        }

        public string PrepareAttendanceSummary(ReportDTO objReportDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.PrepareAttendanceSummary(objReportDTO);
            return strMsg;
        }


        public DataTable GetEmployeeInformation(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetEmployeeInformation(objEmployeeDTO);
            return dt;
        }

        public string SaveEmployeeContactDetail(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveEmployeeContactDetail(objEmployeeDTO);
            return strMsg;
        }

        public DataTable GetPermanentQueue(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetPermanentQueue(objEmployeeDTO);
            return dt;
        }
        //public string EmployeeSkillSave(EmployeeDTO objEmployeeDTO)
        //{

        //    EmployeeDAL objEmployeeDAL = new EmployeeDAL();
        //    string strMsg = objEmployeeDAL.EmployeeSkillSave(objEmployeeDTO);
        //    return strMsg;
        //}
        //public List<EmployeeDTO> GetSkillEmployeeBasicInfo(EmployeeDTO objEmployeeDTO)
        //{
        //    EmployeeDAL objEmployeeDAL = new EmployeeDAL();

        //    var objList = objEmployeeDAL.GetSkillEmployeeBasicInfo(objEmployeeDTO);
        //    return objList;
        //}
        //public DataTable GetSkillEmployeeMapping(EmployeeDTO objEmployeeDTO)
        //{
        //    DataTable dt = new DataTable();
        //    EmployeeDAL objEmployeeDAL = new EmployeeDAL();
        //    dt = objEmployeeDAL.GetSkillEmployeeMapping(objEmployeeDTO);
        //    return dt;
        //}

        public string ActiveInactiveEmployeeSave(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.ActiveInactiveEmployeeSave(objEmployeeDTO);
            return strMsg;
        }
        public List<EmployeeDTO> GetActiveInactiveEmployee(EmployeeDTO objEmployeeDTO)
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            var objList = objEmployeeDAL.GetActiveInactiveEmployee(objEmployeeDTO);
            return objList;
        }

        public string EmployeeSkillSave(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.EmployeeSkillSave(objEmployeeDTO);
            return strMsg;
        }
        public List<EmployeeDTO> GetEmployeeSkillBasicInfo(EmployeeDTO objEmployeeDTO)
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            var objList = objEmployeeDAL.GetEmployeeSkillBasicInfo(objEmployeeDTO);
            return objList;
        }
        public DataTable GetEmployeeSkill(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetEmployeeSkill(objEmployeeDTO);
            return dt;
        }
        public string DeleteEmployeeSkillRecord(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.DeleteEmployeeSkillRecord(objEmployeeDTO);
            return strMsg;
        }

        public DataTable GetSpecialIncrement(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetSpecialIncrement(objEmployeeDTO);
            return dt;
        }
        public DataTable GetSpecialIncrementProposal(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetSpecialIncrementProposal(objEmployeeDTO);
            return dt;
        }
        public string SaveMeternityBenefitInfo(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveMeternityBenefitInfo(objEmployeeDTO);
            return strMsg;
        }
        public DataTable GetEmployeeBasicInformation(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetEmployeeBasicInformation(objEmployeeDTO);
            return dt;
        }
        public DataTable GetMaternityBenefitedEmployee(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetMaternityBenefitedEmployee(objEmployeeDTO);
            return dt;
        }
        public DataTable GetLeaveEncashmentEmpInfo(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetLeaveEncashmentEmpInfo(objEmployeeDTO);
            return dt;
        }
        public DataTable GetLeaveEncashmentStaffEmpInfo(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetLeaveEncashmentStaffEmpInfo(objEmployeeDTO);
            return dt;
        }

        public DataTable GetSelectedMonthlyIncrementList(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetSelectedMonthlyIncrementList(objEmployeeDTO);
            return dt;
        }
        public DataTable GetMonthlyEligibleIncrementListWorker(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetMonthlyEligibleIncrementListWorker(objEmployeeDTO);
            return dt;
        }
        public string DeleteEnvelope(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.DeleteEnvelope(objEmployeeDTO);
            return strMsg;
        }
        public string SaveEnvelope(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveEnvelope(objEmployeeDTO);
            return strMsg;
        }
        //public EventPermissionDTO GetEventPermission(EventPermissionDTO objEventPermission)
        //{
        //    EmployeeDAL objEmployeeDAL = new EmployeeDAL();

        //    var objList = objEmployeeDAL.GetEventPermission(objEventPermission);
        //    return objList;
        //}

        public EventPermissionDTO GetEventPermissionNew(EventPermissionDTO objEventPermission)
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            var objList = objEmployeeDAL.GetEventPermissionNew(objEventPermission);
            return objList;
        }

        public DataTable GetEmpConfirmationWithIncrement(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetEmpConfirmationWithIncrement(objEmployeeDTO);
            return dt;
        }
        public DataTable GetEmployeeBasicInformatiom(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetEmployeeBasicInformatiom(objEmployeeDTO);
            return dt;
        }
        public string SaveAttendanceBonus(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveAttendanceBonus(objEmployeeDTO);
            return strMsg;
        }
        public DataTable GetAttendanceBonus(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetAttendanceBonus(objEmployeeDTO);
            return dt;
        }
        public string SaveEmployeeInCache(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveEmployeeInCache(objEmployeeDTO);
            return strMsg;
        }
        public string ApproveEmployment(string cacheId, string headOfficeId, string branchOfficeId, string createBy)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.ApproveEmployment(cacheId, headOfficeId, branchOfficeId, createBy);
            return strMsg;
        }
        //
        public DataTable GetEmployeeCacseInformation(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetEmployeeCacseInformation(objEmployeeDTO);
            return dt;
        }

        public string UpdateEmployeeCache(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.UpdateEmployeeCache(objEmployeeDTO);
            return strMsg;
        }

        public string DeleteFaceId(string branchOfficeId)
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.DeleteFaceId(branchOfficeId);
            return strMsg;
        }

        public string SaveFaceId(EmployeeDTO objEmployeeDTO)
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.SaveFaceId(objEmployeeDTO);
            return strMsg;
        }

        public string CountFaceId(string branchOfficeId)
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.CountFaceId(branchOfficeId);
            return strMsg;
        }

        public string SaveResignEmployee(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveResignEmployee(objEmployeeDTO);
            return strMsg;
        }

        public DataTable GetEmployeeForResign(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetEmployeeForResign(objEmployeeDTO);
            return dt;
        }
        public DataTable GetResignEmployee(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetResignEmployee(objEmployeeDTO);
            return dt;
        }
        public string SaveFoodDeduction(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveFoodDeduction(objEmployeeDTO);
            return strMsg;
        }
        public DataTable GetFoodDeduction(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetFoodDeduction(objEmployeeDTO);
            return dt;
        }
        public DataTable GetEmployeeForFoodDeduction(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetEmployeeForFoodDetuction(objEmployeeDTO);
            return dt;
        }
        public string SaveInactiveEmpAfterMonthlySalary(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.SaveInactiveEmpAfterMonthlySalary(objEmployeeDTO);
            return strMsg;
        }

        //new
        
        public string ProcessMonthlyInactivation(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.ProcessMonthlyInactivation(objEmployeeDTO);
            return strMsg;
        }

        public string ResetMonthlyInactiveProcess(EmployeeDTO objEmployeeDTO)
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.ResetMonthlyInactiveProcess(objEmployeeDTO);
            return strMsg;
        }
        public DataTable GetEmployeeForInActive(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetEmployeeForInActive(objEmployeeDTO);
            return dt;
        }
        public DataTable GetSalaryUnitSection(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetSalaryUnitSection(objEmployeeDTO);
            return dt;
        }
        public DataTable GetSalaryUnitSectionBottomGrid(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetSalaryUnitSectionBottomGrid(objEmployeeDTO);
            return dt;
        }

        public string IsPhaseWiseSalaryLock(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.IsPhaseWiseSalaryLock(objEmployeeDTO);
            return strMsg;
        }

        public string CreatePhaseIdInMonthlySalary(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.CreatePhaseIdInMonthlySalary(objEmployeeDTO);
            return strMsg;
        }
        public string UpdatePhaseIdInMonthlySalary(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.UpdatePhaseIdInMonthlySalary(objEmployeeDTO);
            return strMsg;
        }

        public DataTable GetConsumedEarnLeave(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.GetConsumedEarnLeave(objEmployeeDTO);
            return dt;

        }


        public DataTable GetEmployeeEarnLeave(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.GetEmployeeEarnLeave(objEmployeeDTO);
            return dt;

        }
        public DataTable searchEmployeeRecordForLeave(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchEmployeeRecordForLeave(objEmployeeDTO);
            return dt;

        }
        public DataTable GetSuspensionEmployee(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.GetSuspensionEmployee(objEmployeeDTO);
            return dt;

        }
        public string SavePaymentHoldEmployee(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SavePaymentHoldEmployee(objEmployeeDTO);
            return strMsg;
        }
        public DataTable GetPaymentHoldEmployee(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetPaymentHoldEmployee(objEmployeeDTO);
            return dt;
        }
        public DataTable GetEmployeeForPaymentHold(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetEmployeeForPaymentHold(objEmployeeDTO);
            return dt;
        }
        public string MakeHoldPayment(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.MakeHoldPayment(objEmployeeDTO);
            return strMsg;
        }
        public string DeleteEmpFromPaymentHold(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.DeleteEmpFromPaymentHold(objEmployeeDTO);
            return strMsg;
        }
        public string HoldPayment(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.HoldPayment(objEmployeeDTO);
            return strMsg;
        }
        public string DeleteFromResign(EmployeeDTO objEmployeeDTO)
        {

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            string strMsg = objEmployeeDAL.DeleteFromResign(objEmployeeDTO);
            return strMsg;
        }
        public DataTable GetVirtualTransferNew(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetVirtualTransferNew(objEmployeeDTO);
            return dt;
        }
        public string SaveAttendanceDashboard(AttendanceDashboardDTO objAttendanceDashboardDTO)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveAttendanceDashboard(objAttendanceDashboardDTO);
            return strMsg;
        }
        public DataTable GetAttendanceDashboard(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetAttendanceDashboard(objEmployeeDTO);
            return dt;
        }
        public string SaveShift(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.SaveShift(objEmployeeDTO);
            return strMsg;
        }
        public DataTable GetShift(string HeadOfficeId, string BranchOfficeId)
        {
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            DataTable dt = new DataTable();
            dt = objEmployeeDAL.GetShift(HeadOfficeId, BranchOfficeId);
            return dt;
        }
        public DataTable GetLogChangeEmpInfoSheet(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetLogChangeEmpInfoSheet(objEmployeeDTO);
            return dt;
        }

        public DataTable GetUnpunchedHomeEmployee(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetUnpunchedHomeEmployee(objEmployeeDTO);
            return dt;
        }

        public DataTable GetUnpunchedForeignEmployee(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetUnpunchedForeignEmployee(objEmployeeDTO);
            return dt;
        }
        public string ProcessIncrementArrearStaff(EmployeeDTO objEmployeeDTO)
        {

            string strMsg = "";
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.ProcessIncrementArrearStaff(objEmployeeDTO);
            return strMsg;

        }
        public DataTable GetRoamingEmployee(EmployeeDTO objEmployeeDTO)
        {
            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetRoamingEmployee(objEmployeeDTO);
            return dt;
        }
        public string CreateIndividualPaymentPhase(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.CreateIndividualPaymentPhase(objEmployeeDTO);
            return strMsg;
        }
       
        public DataTable GetIndividualPaidEmployee(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetIndividualPaidEmployee(objEmployeeDTO);
            return dt;
        }
        public string DeleteEmpFromIndividualPayment(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.DeleteEmpFromIndividualPayment(objEmployeeDTO);
            return strMsg;
        }
        public DataTable GetIndividualPaymentSheet(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetIndividualPaymentSheet(objEmployeeDTO);
            return dt;
        }
        public DataTable GetEmployeeForIndividualPayment(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetEmployeeForIndividualPayment(objEmployeeDTO);
            return dt;
        }

        public DataTable GetPhaseWisePaymentSetup(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetPhaseWisePaymentSetup(objEmployeeDTO);
            return dt;
        }
        public DataTable GetPaymentRule(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetPaymentRule(objEmployeeDTO);
            return dt;
        }

        public DataTable GetEmployeeInformatiom(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            dt = objEmployeeDAL.GetEmployeeInformatiom(objEmployeeDTO);
            return dt;
        }
        public DataTable GetMonthlyInactiveSheet(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            dt = objEmployeeDAL.GetMonthlyInactiveSheet(objEmployeeDTO);
            return dt;
        }
        public string chkEmployeeActivation(EmployeeDTO objEmployeeDTO)
        {
            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();
            strMsg = objEmployeeDAL.chkEmployeeActivation(objEmployeeDTO);
            return strMsg;
        }
        public DataTable GetWorkerForProductionDefectProcess(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.GetWorkerForProductionDefectProcess(objEmployeeDTO);
            return dt;

        }
        public DataTable GetEmpForPromotion(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.GetEmpForPromotion(objEmployeeDTO);
            return dt;

        }

        public DataTable GetEmpForGradeChange(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.GetEmpForGradeChange(objEmployeeDTO);
            return dt;

        }
    }
}
