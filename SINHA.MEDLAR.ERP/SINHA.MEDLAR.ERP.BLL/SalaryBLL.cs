using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class SalaryBLL
    {

        public string saveIncrementWorkerCasual(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveIncrementWorkerCasual(objSalaryDTO);
            return strMsg;
        }
        public string addWorkerIncrementCasual(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addWorkerIncrementCasual(objSalaryDTO);
            return strMsg;
        }
        public SalaryDTO searchWorkerIncrementEntryCasual(string strEmployeeId, string strIncrementYear, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchWorkerIncrementEntryCasual(strEmployeeId, strIncrementYear, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }
        public string processSalaryStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processSalaryStaff(objSalaryDTO);
            return strMsg;
        }

        public string BankSheetUpload(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.BankSheetUpload(objSalaryDTO);
            return strMsg;
        }

        public string DeleteBankSheet(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.DeleteBankSheet(objSalaryDTO);
            return strMsg;
        }



        public string HalfSalaryStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.HalfSalaryStaff(objSalaryDTO);
            return strMsg;
        }

        public string deleteHalfSalaryStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.deleteHalfSalaryStaff(objSalaryDTO);
            return strMsg;
        }

        public string deleteHalfSalaryAddWorker(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.deleteHalfSalaryAddWorker(objSalaryDTO);
            return strMsg;
        }

        public string deleteHalfSalaryAddHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.deleteHalfSalaryAddHO(objSalaryDTO);
            return strMsg;
        }

        public string saveHalfSalaryAddStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveHalfSalaryAddStaff(objSalaryDTO);
            return strMsg;
        }

        public string saveHalfSalaryAddWorker(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveHalfSalaryAddWorker(objSalaryDTO);
            return strMsg;
        }

        public string saveHalfSalaryAddHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveHalfSalaryAddHO(objSalaryDTO);
            return strMsg;
        }


        public string processSalaryMiscStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processSalaryMiscStaff(objSalaryDTO);
            return strMsg;
        }

        public string halfSheetStaffMisc(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.halfSheetStaffMisc(objSalaryDTO);
            return strMsg;
        }

        public string halfSheetStaffSummery(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.halfSheetStaffSummery(objSalaryDTO);
            return strMsg;
        }

        public string monthlyStaffSalarySummeryProcess(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.monthlyStaffSalarySummeryProcess(objSalaryDTO);
            return strMsg;
        }

        public string saveBankSalary(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveBankSalary(objSalaryDTO);
            return strMsg;
        }

        public string procesFirstSalaryForBank(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.procesFirstSalaryForBank(objSalaryDTO);
            return strMsg;
        }

        public string saveSalaryMiscEntryCash(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveSalaryMiscEntryCash(objSalaryDTO);
            return strMsg;
        }


        public string savePunchCode(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.savePunchCode(objSalaryDTO);
            return strMsg;
        }


        public string saveSalaryMiscEntry(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveSalaryMiscEntry(objSalaryDTO);
            return strMsg;
        }

        public string saveSalaryEntryHOMISC(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveSalaryEntryHOMISC(objSalaryDTO);
            return strMsg;
        }


        public string processSalaryCertificate(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processSalaryCertificate(objSalaryDTO);
            return strMsg;
        }

        public string deleteSalaryCertificate(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.deleteSalaryCertificate(objSalaryDTO);
            return strMsg;
        }



        public string saveSalaryMiscEntryWoker(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveSalaryMiscEntryWoker(objSalaryDTO);
            return strMsg;
        }

        public string saveSalaryMiscEntryResign(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveSalaryMiscEntryResign(objSalaryDTO);
            return strMsg;
        }

        public string ProcessMonthlyResignSalaryStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.ProcessMonthlyResignSalaryStaff(objSalaryDTO);
            return strMsg;
        }
        public string saveHalfSalaryWorker(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveHalfSalaryWorker(objSalaryDTO);
            return strMsg;
        }

        public string saveHalfSalaryHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveHalfSalaryHO(objSalaryDTO);
            return strMsg;
        }

        public string saveHalfSalaryStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveHalfSalaryStaff(objSalaryDTO);
            return strMsg;
        }


        public string saveIncrementWorker(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveIncrementWorker(objSalaryDTO);
            return strMsg;
        }

        public string saveArrearWorkerEntry(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveArrearWorkerEntry(objSalaryDTO);
            return strMsg;
        }


        public string saveIncrementWorkerAnnual(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveIncrementWorkerAnnual(objSalaryDTO);
            return strMsg;
        }

        public string saveIncrementWorkerNonProposal(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveIncrementWorkerNonProposal(objSalaryDTO);
            return strMsg;
        }
        //public string saveIncrementStaffNonProposal(SalaryDTO objSalaryDTO)
        //{

        //    SalaryDAL objSalaryDAL = new SalaryDAL();
        //    string strMsg = objSalaryDAL.saveIncrementStaffNonProposal(objSalaryDTO);
        //    return strMsg;
        //}

        public string saveIncrementStaffNonProposal(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveIncrementStaffNonProposal(objSalaryDTO);
            return strMsg;
        }
        public string saveIncrementStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveIncrementStaff(objSalaryDTO);
            return strMsg;
        }


        public string saveIncrementStaffMonthly(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveIncrementStaffMonthly(objSalaryDTO);
            return strMsg;
        }


        public string processWorkerAttendence(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processWorkerAttendence(objSalaryDTO);
            return strMsg;
        }


        public string saveOverTimeEntryWoker(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveOverTimeEntryWoker(objSalaryDTO);
            return strMsg;
        }

        public string saveArrearAdvance(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveArrearAdvance(objSalaryDTO);
            return strMsg;
        }

        public string overTimeProcess(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.overTimeProcess(objSalaryDTO);
            return strMsg;
        }


        public string overTimeSummeryProcessMonthly(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.overTimeSummeryProcessMonthly(objSalaryDTO);
            return strMsg;
        }


        public string OverTimeRequisitionSummery(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.OverTimeRequisitionSummery(objSalaryDTO);
            return strMsg;
        }

        public string saveLeaveEntryWoker(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveLeaveEntryWoker(objSalaryDTO);
            return strMsg;
        }

        public string processLeaveWorker(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processLeaveWorker(objSalaryDTO);
            return strMsg;
        }


        public string workerleaveProcessByPunching(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.workerleaveProcessByPunching(objSalaryDTO);
            return strMsg;
        }

        public string staffleaveProcessByPunching(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.staffleaveProcessByPunching(objSalaryDTO);
            return strMsg;
        }

        public string processLeaveStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processLeaveStaff(objSalaryDTO);
            return strMsg;
        }

        public string processLeaveStaffMisc(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processLeaveStaffMisc(objSalaryDTO);
            return strMsg;
        }

        public string processLeaveStaffSummery(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processLeaveStaffSummery(objSalaryDTO);
            return strMsg;
        }

        public string saveLeaveEntryStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveLeaveEntryStaff(objSalaryDTO);
            return strMsg;
        }

        public string saveSalaryEntryStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveSalaryEntryStaff(objSalaryDTO);
            return strMsg;
        }

        public string saveMiscSalaryEntryStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveMiscSalaryEntryStaff(objSalaryDTO);
            return strMsg;
        }


        public string processMISCSalaryHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processMISCSalaryHO(objSalaryDTO);
            return strMsg;
        }

        public string processMonthlyLunch(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processMonthlyLunch(objSalaryDTO);
            return strMsg;
        }


        public string processSalaryWorker(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processSalaryWorker(objSalaryDTO);
            return strMsg;
        }
                
        
        //public string processSalaryWorkerTest(SalaryDTO objSalaryDTO)
        //{

        //    SalaryDAL objSalaryDAL = new SalaryDAL();
        //    string strMsg = objSalaryDAL.processSalaryWorkerTest(objSalaryDTO);
        //    return strMsg;
        //}
        
        public string processWorkingDayWorker(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processWorkingDayWorker(objSalaryDTO);
            return strMsg;
        }

        public string processWorkingDayStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processWorkingDayStaff(objSalaryDTO);
            return strMsg;
        }
        
        public string halfSalaryProcess(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.halfSalaryProcess(objSalaryDTO);
            return strMsg;
        }

        public string halfSalaryProcessHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.halfSalaryProcessHO(objSalaryDTO);
            return strMsg;
        }

        public string halfSalaryProcessHOMisc(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.halfSalaryProcessHOMisc(objSalaryDTO);
            return strMsg;
        }

        public string halfSalaryRequisition(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.halfSalaryRequisition(objSalaryDTO);
            return strMsg;
        }



        public string BonusProcessWorker(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.BonusProcessWorker(objSalaryDTO);
            return strMsg;
        }


        public string processBonusWorkerTest(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processBonusWorkerTest(objSalaryDTO);
            return strMsg;
        }

        public string saveBonusWorker(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveBonusWorker(objSalaryDTO);
            return strMsg;
        }

        public string saveBonusHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveBonusHO(objSalaryDTO);
            return strMsg;
        }

        public string BonusProcessStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.BonusProcessStaff(objSalaryDTO);
            return strMsg;
        }

        public string saveBonusStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveBonusStaff(objSalaryDTO);
            return strMsg;
        }

        public string saveBonusAddWorker(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveBonusAddWorker(objSalaryDTO);
            return strMsg;
        }

        public string saveBonusAddHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveBonusAddHO(objSalaryDTO);
            return strMsg;
        }

        public string BonusProcessHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.BonusProcessHO(objSalaryDTO);
            return strMsg;
        }



        public string bonusSummeryStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.bonusSummeryStaff(objSalaryDTO);
            return strMsg;
        }


        public string saveBonusProcessStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveBonusProcessStaff(objSalaryDTO);
            return strMsg;
        }

        public string saveBonusProcessManual(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveBonusProcessManual(objSalaryDTO);
            return strMsg;
        }


        public string addBonusManual(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addBonusManual(objSalaryDTO);
            return strMsg;
        }


        public string saveSalaryBasicInfoHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveSalaryBasicInfoHO(objSalaryDTO);
            return strMsg;
        }

        public string addWorkerPromotion(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addWorkerPromotion(objSalaryDTO);
            return strMsg;
        }

        public string addWorkerYearlyIncrementNonProposal(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addWorkerYearlyIncrementNonProposal(objSalaryDTO);
            return strMsg;
        }
        public string addStaffYearlyIncrementNonProposal(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addStaffYearlyIncrementNonProposal(objSalaryDTO);
            return strMsg;
        }

        public string employeeTransferAdd(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.employeeTransferAdd(objSalaryDTO);
            return strMsg;
        }

        public string TransferVirtually(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.TransferVirtually(objSalaryDTO);
            return strMsg;
        }

       
        public string UpdateVirtualTransfer(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.UpdateVirtualTransfer(objSalaryDTO);
            return strMsg;
        }
        public string DeleteVirtualTransfer(string transferId, string branchId, string headOfficeId)
        {
            string strMsg = "";
            SalaryDAL objSalaryDAL = new SalaryDAL();
            strMsg = objSalaryDAL.DeleteVirtualTransfer(transferId, branchId, headOfficeId);
            return strMsg;
        }
        public string addEmployeePromotion(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addEmployeePromotion(objSalaryDTO);
            return strMsg;
        }

        public string AddPromotionInfo(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.AddPromotionInfo(objSalaryDTO);
            return strMsg;
        }

        public string addWorkerIncrement(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addWorkerIncrement(objSalaryDTO);
            return strMsg;
        }
        public string addWorkerIncrementProposal(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addWorkerIncrementProposal(objSalaryDTO);
            return strMsg;
        }
        //
        public string ApplyIndividualWorkerAutoIncr(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.ApplyIndividualWorkerAutoIncr(objSalaryDTO);
            return strMsg;
        }

        //
        public string GetWorkerAutoIncrementAmount(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.GetWorkerAutoIncrementAmount(objSalaryDTO);
            return strMsg;
        }
        public string addWorkerIncrementAnnual(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addWorkerIncrementAnnual(objSalaryDTO);
            return strMsg;
        }

        public string addWorkerSalary(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addWorkerSalary(objSalaryDTO);
            return strMsg;
        }


        public string addWorkerArrear(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addWorkerArrear(objSalaryDTO);
            return strMsg;
        }


        public string ProcessWorkerArrear(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.ProcessWorkerArrear(objSalaryDTO);
            return strMsg;
        }

        public string ProcessWorkerArrearRequisition(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.ProcessWorkerArrearRequisition(objSalaryDTO);
            return strMsg;
        }


        public string addStaffIncrement(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addStaffIncrement(objSalaryDTO);
            return strMsg;
        }

        public string addStaffIncrementMonthly(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addStaffIncrementMonthly(objSalaryDTO);
            return strMsg;
        }
        public string addIncrementHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addIncrementHO(objSalaryDTO);
            return strMsg;
        }

        //
        public string IncrementHOAddUpdate(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.IncrementHOAddUpdate(objSalaryDTO);
            return strMsg;
        }

        //new: added on 30.12.2021
        public string CreateIncrementProposalHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.CreateIncrementProposalHO(objSalaryDTO);
            return strMsg;
        }
        //old
        public string AddIncrementProposalHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.AddIncrementProposalHO(objSalaryDTO);
            return strMsg;
        }




        public string addWorkerIncrementProposalStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addWorkerIncrementProposalStaff(objSalaryDTO);
            return strMsg;
        }




        public string deleteSalaryBasicInfoHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.deleteSalaryBasicInfoHO(objSalaryDTO);
            return strMsg;
        }

        public string saveSalaryBasicInfoWorker(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveSalaryBasicInfoWorker(objSalaryDTO);
            return strMsg;
        }

        public string deleteSalaryBasicInfoWorker(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.deleteSalaryBasicInfoWorker(objSalaryDTO);
            return strMsg;
        }


        public string saveSalaryBasicInfoStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveSalaryBasicInfoStaff(objSalaryDTO);
            return strMsg;
        }

        public string deleteSalaryBasicInfoStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.deleteSalaryBasicInfoStaff(objSalaryDTO);
            return strMsg;
        }

        public string processSalaryStaffMisc(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processSalaryStaffMisc(objSalaryDTO);
            return strMsg;
        }

        public string saveStaffSalary(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveStaffSalary(objSalaryDTO);
            return strMsg;
        }
        public DataTable searchSalaryInfoStaffMisc(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            DataTable dt = new DataTable();

            dt = objSalaryDAL.searchSalaryInfoStaffMisc(objSalaryDTO);
            return dt;

        }
        public DataTable searchSalaryHOMisc(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            DataTable dt = new DataTable();

            dt = objSalaryDAL.searchSalaryHOMisc(objSalaryDTO);
            return dt;

        }

        public DataTable searchSalaryRecordHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            DataTable dt = new DataTable();

            dt = objSalaryDAL.searchSalaryRecordHO(objSalaryDTO);
            return dt;

        }

        public DataTable searchSalaryRecordWorker(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            DataTable dt = new DataTable();

            dt = objSalaryDAL.searchSalaryRecordWorker(objSalaryDTO);
            return dt;

        }
        public DataTable searchSalaryRecordStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            DataTable dt = new DataTable();

            dt = objSalaryDAL.searchSalaryRecordStaff(objSalaryDTO);
            return dt;

        }

        public DataTable searchSalaryInfoStaff(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            DataTable dt = new DataTable();

            dt = objSalaryDAL.searchSalaryInfoStaff(objSalaryDTO);
            return dt;

        }

        public DataTable searchSalaryInfoWorker(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            DataTable dt = new DataTable();

            dt = objSalaryDAL.searchSalaryInfoWorker(objSalaryDTO);
            return dt;

        }

        public DataTable searchSalaryInfoHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            DataTable dt = new DataTable();

            dt = objSalaryDAL.searchSalaryInfoHO(objSalaryDTO);
            return dt;

        }
        public DataTable searchSalaryInfoHOMisc(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            DataTable dt = new DataTable();

            dt = objSalaryDAL.searchSalaryInfoHOMisc(objSalaryDTO);
            return dt;

        }

        public DataTable getSalaryBasicInfo(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            DataTable dt = new DataTable();

            dt = objSalaryDAL.getSalaryBasicInfo(objSalaryDTO);
            return dt;

        }


        public string processSalaryHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processSalaryHO(objSalaryDTO);
            return strMsg;
        }



        public string processSalaryHOMisc(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processSalaryHOMisc(objSalaryDTO);
            return strMsg;
        }


        public string saveAdvanceAmount(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveAdvanceAmount(objSalaryDTO);
            return strMsg;
        }

        public string saveIncrementHoldInfo(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveIncrementHoldInfo(objSalaryDTO);
            return strMsg;
        }

        public string saveTaxInfo(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveTaxInfo(objSalaryDTO);
            return strMsg;
        }

        public string processMonthlyResignSalary(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processMonthlyResignSalary(objSalaryDTO);
            return strMsg;
        }

        public string processMonthlySalaryTemp(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processMonthlySalaryTemp(objSalaryDTO);
            return strMsg;
        }

        public string processMonthlyResignOT(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processMonthlyResignOT(objSalaryDTO);
            return strMsg;
        }


        public string saveWorkerTransfer(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveWorkerTransfer(objSalaryDTO);
            return strMsg;
        }
        public string saveYearlyWorkerPromotion(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveYearlyWorkerPromotion(objSalaryDTO);
            return strMsg;
        }

        public string saveTax(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveTax(objSalaryDTO);
            return strMsg;
        }

        public string saveAdvance(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveAdvance(objSalaryDTO);
            return strMsg;
        }

        public string deleteAdvanceEntry(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.deleteAdvanceEntry(objSalaryDTO);
            return strMsg;
        }



        public DataTable getStaffIdForSalary(SalaryDTO objSalaryDTO)
        {

            DataTable dt = new DataTable();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            dt = objSalaryDAL.getStaffIdForSalary(objSalaryDTO);
            return dt;

        }

        public SalaryDTO showStaffSalayInfo(string strUnitId, string strSectionId, string strCatagoryId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId, string strUpdateBy)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.showStaffSalayInfo(strUnitId, strSectionId, strCatagoryId, strYear, strMonth, strHeadOfficeId, strBranchOfficeId, strUpdateBy);
            return objSalaryDTO;
        }

        public SalaryDTO searchAdvanceInfo(string strEmployeeId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchAdvanceInfo(strEmployeeId, strYear, strMonth, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }



        public string processSalaryOption(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.processSalaryOption(objSalaryDTO);
            return strMsg;
        }

        public string addMonthlySalary(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.addMonthlySalary(objSalaryDTO);
            return strMsg;
        }

        public SalaryDTO getEmployeeInformation(string strCardNo, string strHeadOfficeId, string strUnitId, string strSectionId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.getEmployeeInformation(strCardNo, strHeadOfficeId, strUnitId, strSectionId);
            return objSalaryDTO;
        }

        public SalaryDTO searchWorkerIncrementEntryAnnual(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOffieId)
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();
            objSalaryDTO = objSalaryDAL.searchWorkerIncrementEntryAnnual(strEmployeeId, strIncrementYear, strHeadOfficeId, strBranchOffieId);
            return objSalaryDTO;
        }
        //GetIncrementAmount(txtEmployeeId.Text, txtIncrementYear.Text, txtMonth.Text, hfBatchNo.Value, strHeadOfficeId, strBranchOfficeId);
        public SalaryDTO GetIncrementAmount(string employeeId, string incrementYear, string incrementMonth, string batchNo, string strHeadOfficeId, string strBranchOffieId)
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();
            //objSalaryDTO = objSalaryDAL.searchWorkerIncrementEntryAnnual(strEmployeeId, strIncrementYear, strHeadOfficeId, strBranchOffieId);
            objSalaryDTO = objSalaryDAL.GetIncrementAmount(employeeId, incrementYear, incrementMonth, batchNo, strHeadOfficeId, strBranchOffieId);
            return objSalaryDTO;
        }
        //
        public SalaryDTO GetPropGrossAtYearlyIncrement(string employeeId, string incrementYear, string incrementMonth, string strHeadOfficeId, string strBranchOffieId)
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();
            objSalaryDTO = objSalaryDAL.GetPropGrossAtYearlyIncrement(employeeId, incrementYear, incrementMonth, strHeadOfficeId, strBranchOffieId);
            return objSalaryDTO;
        }
        public SalaryDTO searchWorkerIncrementEntryNonProposal(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOffieId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchWorkerIncrementEntryNonProposal(strEmployeeId, strIncrementYear, strHeadOfficeId, strBranchOffieId);
            return objSalaryDTO;
        }
        //public SalaryDTO searchStaffIncrementEntryNonProposal(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOffieId)
        //{

        //    SalaryDTO objSalaryDTO = new SalaryDTO();
        //    SalaryDAL objSalaryDAL = new SalaryDAL();

        //    objSalaryDTO = objSalaryDAL.searchStaffIncrementEntryNonProposal(strEmployeeId, strIncrementYear, strHeadOfficeId, strBranchOffieId);
        //    return objSalaryDTO;
        //}

        public SalaryDTO searchStaffIncrementEntryNonProposal(string strEmployeeId, string strIncrementYear, string strHeadOfficeId, string strBranchOffieId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchStaffIncrementEntryNonProposal(strEmployeeId, strIncrementYear, strHeadOfficeId, strBranchOffieId);
            return objSalaryDTO;
        }
        public SalaryDTO searchTaxFee(string strEmployeeId,string strSalaryYear, string strSalaryMonth, string strHeadOfficeId, string strBranchOffieId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchTaxFee(strEmployeeId,strSalaryYear,strSalaryMonth, strHeadOfficeId, strBranchOffieId);
            return objSalaryDTO;
        }

        public SalaryDTO searchAdvanceFee(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strHeadOfficeId, string strBranchOffieId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchAdvanceFee(strEmployeeId, strSalaryYear, strSalaryMonth, strHeadOfficeId, strBranchOffieId);
            return objSalaryDTO;
        }


        public SalaryDTO searchTaxInfo(string strEmployeeId, string strSalaryFromYear, string strSalaryToYear, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchTaxInfo(strEmployeeId, strSalaryFromYear, strSalaryToYear, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }



        public DataTable loadSalaryEntry(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
                
            DataTable dt = new DataTable();

            dt = objSalaryDAL.loadSalaryEntry(objSalaryDTO);
            return dt;

        }



        public SalaryDTO searchMiscEntry(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchMiscEntry(strEmployeeId, strSalaryYear, strSalaryMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }


        public SalaryDTO searchPunchingCode(string strEmployeeId, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchPunchingCode(strEmployeeId, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }



        public SalaryDTO searchWorkingDay(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchWorkingDay(strEmployeeId, strSalaryYear, strSalaryMonth, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchWorkingDayMisc(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchWorkingDayMisc(strEmployeeId, strSalaryYear, strSalaryMonth, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }



        public SalaryDTO checkHoldYn(string strEmployeeId, string strSalaryYear,string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.checkHoldYn(strEmployeeId, strSalaryYear, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }


        public SalaryDTO searchSalaryEntryHOMISC(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchSalaryEntryHOMISC(strEmployeeId, strSalaryYear, strSalaryMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchMiscEntryCash(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchMiscEntryCash(strEmployeeId, strSalaryYear, strSalaryMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchMiscEntryWorker(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchMiscEntryWorker(strEmployeeId, strSalaryYear, strSalaryMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchResignEntryWorker(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchResignEntryWorker(strEmployeeId, strSalaryYear, strSalaryMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }



        public SalaryDTO searchMonthLoanEntryWorker(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchMonthLoanEntryWorker(strEmployeeId, strSalaryYear, strSalaryMonth, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchMonthLoanEntryResign(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchMonthLoanEntryResign(strEmployeeId, strSalaryYear, strSalaryMonth, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchMonthLoanEntryStaff(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchMonthLoanEntryStaff(strEmployeeId, strSalaryYear, strSalaryMonth, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searcHalfSalaryEntryWorker(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searcHalfSalaryEntryWorker(strEmployeeId, strSalaryYear, strSalaryMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searcHalfSalaryEntryHO(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searcHalfSalaryEntryHO(strEmployeeId, strSalaryYear, strSalaryMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searcHalfSalaryEntryStaff(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searcHalfSalaryEntryStaff(strEmployeeId, strSalaryYear, strSalaryMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }



        public SalaryDTO searchWorkerIncrementEntry(string strEmployeeId, string strIncrementYear, string strIncrementMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchWorkerIncrementEntry(strEmployeeId, strIncrementYear, strIncrementMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchWorkerArrearEntry(string strEmployeeId, string strIncrementYear, string strIncrementMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchWorkerArrearEntry(strEmployeeId, strIncrementYear, strIncrementMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }


        public SalaryDTO searchWorkerArrearSalary(string strEmployeeId, string strIncrementYear, string strIncrementMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchWorkerArrearSalary(strEmployeeId, strIncrementYear, strIncrementMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }



        public SalaryDTO searchStaffIncrementEntry(string strEmployeeId, string strIncrementYear,  string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchStaffIncrementEntry(strEmployeeId, strIncrementYear, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO GetIncrementAmountStaff(string strEmployeeId, string strIncrementYear, string month, string batchNo, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.GetIncrementAmountStaff(strEmployeeId, strIncrementYear, month, batchNo, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchStaffIncrementEntryMonthly(string strEmployeeId, string strIncrementYear, string strIncrementMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchStaffIncrementEntryMonthly(strEmployeeId, strIncrementYear, strIncrementMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchWorkerIncProposalEntry(string strEmployeeId, string strIncrementYear,string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchWorkerIncProposalEntry(strEmployeeId, strIncrementYear, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchBonusEntryWorker(string strEmployeeId, string strEidBonusTypeId, string strSalaryYear, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchBonusEntryWorker(strEmployeeId, strEidBonusTypeId, strSalaryYear, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchBonusEntryHO(string strEmployeeId, string strEidBonusTypeId, string strSalaryYear, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchBonusEntryHO(strEmployeeId, strEidBonusTypeId, strSalaryYear, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchBonusEntryStaff(string strEmployeeId, string strEidBonusTypeId, string strSalaryYear, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchBonusEntryStaff(strEmployeeId, strEidBonusTypeId, strSalaryYear, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }


        public SalaryDTO searchBonusManualEntry(string strEmployeeId, string strEidBonusTypeId, string strSalaryYear, string strFromMonth, string strToMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchBonusManualEntry(strEmployeeId, strEidBonusTypeId, strSalaryYear, strFromMonth, strToMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }


        public SalaryDTO searchOverTimeEntryWorker(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchOverTimeEntryWorker(strEmployeeId, strSalaryYear, strSalaryMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchArrearAdavanceEntryHO(string strEmployeeId, string strArrearYear, string strFromMonthId, string strToMonthId, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchArrearAdavanceEntryHO(strEmployeeId, strArrearYear, strFromMonthId, strToMonthId, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }


        public SalaryDTO searchLeaveEntryWorker(string strEmployeeId, string strSalaryYear, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchLeaveEntryWorker(strEmployeeId, strSalaryYear, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchLeaveEntryStaff(string strEmployeeId, string strSalaryYear,  string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchLeaveEntryStaff(strEmployeeId, strSalaryYear, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }



        public SalaryDTO searchSalaryEntryStaff(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchSalaryEntryStaff(strEmployeeId, strSalaryYear, strSalaryMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searchMiscSalaryEntryStaff(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchMiscSalaryEntryStaff(strEmployeeId, strSalaryYear, strSalaryMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }
        public string updateTax(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.updateTax(objSalaryDTO);
            return strMsg;
        }


        public SalaryDTO getFirstSalary(string strYear, string strMonth, string strEmployeeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.getFirstSalary(strYear, strMonth, strEmployeeId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public SalaryDTO searcReamingLoan(string strEmployeeId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searcReamingLoan(strEmployeeId, strYear, strMonth, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }


        public string employeeLogDataProcess(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.employeeLogDataProcess(objSalaryDTO);
            return strMsg;
        }

        public string attendenceProcess(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.attendenceProcess(objSalaryDTO);
            return strMsg;
        }


        public DataTable searchExcelFile(SalaryDTO objSalaryDTO)
        {

            DataTable dt = new DataTable();
            SalaryDAL objSalaryDAL = new SalaryDAL();


            dt = objSalaryDAL.searchExcelFile(objSalaryDTO);
            return dt;

        }

        public SalaryDTO DownloadMonthlyBankSheet(string strId, string strHeadOfficeId, string strBranchOfficeId)
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.DownloadMonthlyBankSheet(strId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public string saveMonthlyLunchEntryHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveMonthlyLunchEntryHO(objSalaryDTO);
            return strMsg;
        }
        public SalaryDTO searchLunchEntryHO(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchLunchEntryHO(strEmployeeId, strSalaryYear, strSalaryMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }




        ///////////////////////////////////////Salary Resign OT Entry//////////////////////////////////////////
        public string saveSalaryMiscOTEntryResign(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveSalaryMiscOTEntryResign(objSalaryDTO);
            return strMsg;
        }

        public SalaryDTO searchResignOTEntryWorker(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchResignOTEntryWorker(strEmployeeId, strSalaryYear, strSalaryMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }


        public DataTable searchOTSalaryInfoResign(EmployeeDTO objEmployeeDTO)
        {

            DataTable dt = new DataTable();
            EmployeeDAL objEmployeeDAL = new EmployeeDAL();


            dt = objEmployeeDAL.searchOTSalaryInfoResign(objEmployeeDTO);
            return dt;

        }



        public SalaryDTO searchSalaryEntryTemp(string strEmployeeId, string strSalaryYear, string strSalaryMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchSalaryEntryTemp(strEmployeeId, strSalaryYear, strSalaryMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public string saveSalaryEntryTempSave(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveSalaryEntryTempSave(objSalaryDTO);
            return strMsg;
        }


        public SalaryDTO searchSalaryEmployee(string strEmployeeId, string strUnitId, string strCardNo, string strSectionId,string strYear, string strMonth,  string strHeadOfficeId,  string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.searchSalaryEmployee(strEmployeeId, strUnitId, strCardNo, strSectionId, strYear, strMonth, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public string saveSalaryApproveEntry(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.saveSalaryApproveEntry(objSalaryDTO);
            return strMsg;
        }
        public string AppoinmentApprovalRequest(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.AppoinmentApprovalRequest(objSalaryDTO);
            return strMsg;
        }
        //
        public SalaryDTO loadSalaryEmployee(string strEmployeeId, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.loadSalaryEmployee(strEmployeeId, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }

        public string SaveGazetteInfo(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.SaveGazetteInfo(objSalaryDTO);
            return strMsg;
        }

        public string DeleteDiscardAnnualIncrement(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.DeleteDiscardAnnualIncrement(objSalaryDTO);
            return strMsg;
        }

        public string ProcessPromotionQueue(SalaryDTO SalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = "";
            strMsg = objSalaryDAL.ProcessPromotionQueue(SalaryDTO);
            return strMsg;
        }

        public string SavePermanentInfo(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.SavePermanentInfo(objSalaryDTO);
            return strMsg;
        }
        public string ProcessPermanentQueue(SalaryDTO SalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = "";
            strMsg = objSalaryDAL.ProcessPermanentQueue(SalaryDTO);
            return strMsg;
        }

        public string ProcessSpecialIncrementProposal(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.ProcessSpecialIncrementProposal(objSalaryDTO);
            return strMsg;
        }
        public string SaveSpecialIncrement(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.SaveSpecialIncrement(objSalaryDTO);
            return strMsg;
        }

        public string ProcessSpecialIncrement(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.ProcessSpecialIncrement(objSalaryDTO);
            return strMsg;
        }

        public decimal GetSpecialIncrementAmountByEmployeeId(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            decimal incrementAmount = objSalaryDAL.GetSpecialIncrementAmountByEmployeeId(objSalaryDTO);
            return incrementAmount;
        }

        public string DeleteWorkerSalaryInfo(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.DeleteWorkerSalaryInfo(objSalaryDTO);
            return strMsg;
        }

        //07.03.2022
        public string DeleteLunchHO(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.DeleteLunchHO(objSalaryDTO);
            return strMsg;
        }

        public SalaryDTO GetWorkerIncrementList(string strEmployeeId, string strIncrementYear, string strIncrementMonth, string strUnitId, string strSectionId, string strHeadOfficeId, string strBranchOfficeId)
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryDAL objSalaryDAL = new SalaryDAL();

            objSalaryDTO = objSalaryDAL.GetWorkerIncrementList(strEmployeeId, strIncrementYear, strIncrementMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            return objSalaryDTO;
        }
        public string SaveEmployeeConfirmationBasicInfo(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.SaveEmployeeConfirmationBasicInfo(objSalaryDTO);
            return strMsg;
        }
        public string ProcessEmployeeConfirmation(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.ProcessEmployeeConfirmation(objSalaryDTO);
            return strMsg;
        }

        //
        public DataTable GetEmployeeBasic(SalaryDTO objSalaryDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    SalaryDAL objSalaryDAL = new SalaryDAL();
                    dt = objSalaryDAL.GetEmployeeBasic(objSalaryDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        public DataTable GetSalaryHistory(SalaryDTO objSalaryDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    SalaryDAL objSalaryDAL = new SalaryDAL();
                    dt = objSalaryDAL.GetSalaryHistory(objSalaryDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteSuspensionEmployee(SalaryDTO objSalaryDTO)
        {

            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.DeleteSuspensionEmployee(objSalaryDTO);
            return strMsg;
        }
        public string UpdateVirtualTransferNew(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.UpdateVirtualTransferNew(objSalaryDTO);
            return strMsg;
        }
        public string TransferVirtuallyNew(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.TransferVirtuallyNew(objSalaryDTO);
            return strMsg;
        }
        public string SaveRoamingEmployee(SalaryDTO objSalaryDTO)
        {
            SalaryDAL objSalaryDAL = new SalaryDAL();
            string strMsg = objSalaryDAL.SaveRoamingEmployee(objSalaryDTO);
            return strMsg;
        }
    }
}
