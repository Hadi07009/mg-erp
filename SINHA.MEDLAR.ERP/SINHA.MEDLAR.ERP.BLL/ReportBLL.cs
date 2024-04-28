using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
    public class ReportBLL
    {

        public DataSet employeeBasicInformaiton(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeBasicInformaiton(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet IncrementSummaryAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.IncrementSummaryAll(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet VFPackingSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.VFPackingSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet employeeBasicInformaitonForInsurence(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeBasicInformaitonForInsurence(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet employeeSalaryRange(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeSalaryRange(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptPoOrderSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptPoOrderSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptPoTrackingShipmentSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptPoTrackingShipmentSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet rdoPurchaseParts(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoPurchaseParts(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet rptPoTrackingShipmentHoldSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptPoTrackingShipmentHoldSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet DailySweingDefectSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.DailySweingDefectSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet employeeBasicInformaitonCV(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeBasicInformaitonCV(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet SkillMatrixTop(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.SkillMatrixTop(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet sparePartsListOfEngine(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.sparePartsListOfEngine(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet MonthlyStoreList(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.MonthlyStoreList(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet newEmployeeList(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.newEmployeeList(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet newEmployeeListWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.newEmployeeListWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet EmployeJobConfiramtionSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.EmployeJobConfiramtionSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet workerSalaryRange(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.workerSalaryRange(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet workerSalaryRangeSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.workerSalaryRangeSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet employeeSlipEng(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeSlipEng(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet employeeSlipBng(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeSlipBng(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet salaryCertificate(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salaryCertificate(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        public DataSet monthlyTiffinSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.monthlyTiffinSheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        
        public DataTable GetStaffMasterTiffinSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffMasterTiffinSheet(objReportDTO);
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
        public DataTable GetStaffBkashTiffinSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffBkashTiffinSheet(objReportDTO);
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
        //old
        public DataTable GetStaffTiffinSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffTiffinSheet(objReportDTO);
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
        public DataTable GetTaxStatementSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetTaxStatementSummary(objReportDTO);
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

        public DataTable GetTaxStatementDetail(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetTaxStatementDetail(objReportDTO);
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

        //public DataSet GetTaxStatementSummary(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {

        //            ReportDAL objReportDAL = new ReportDAL();
        //            dt = objReportDAL.GetTaxStatementSummary(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }

        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        public DataSet monthlyTiffinSheetWorkerRequisition(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyTiffinSheetWorkerRequisition(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet monthlySalaryRequisitionSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionSheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet halfSalarySheetRequisitionWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.halfSalarySheetRequisitionWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet salaryCertificateList(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salaryCertificateList(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet monthlyBankCashStatement(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyBankCashStatement(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlyAdvanceTaxInformation(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyAdvanceTaxInformation(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet yearlyAdvanceTaxHistory(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.yearlyAdvanceTaxHistory(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet yearlyAdvanceTaxSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.yearlyAdvanceTaxSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet monthlySalaryRequisitionSFL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionSFL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet bonusRequisitionSFL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusRequisitionSFL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet halfSalaryRequisitionSFL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.halfSalaryRequisitionSFL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet halfSalaryRequisitionMAL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.halfSalaryRequisitionMAL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet bonusRequisitionMAL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusRequisitionMAL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        public DataSet monthlySalaryRequisitionMAL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionMAL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalaryRequisitionHOMISCSFL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionHOMISCSFL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet bonusRequisitionHOMISCSFL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusRequisitionHOMISCSFL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet halfSalaryRequisitionHOMISCSFL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.halfSalaryRequisitionHOMISCSFL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet halfSalaryRequisitionHOMISCMAL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.halfSalaryRequisitionHOMISCMAL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet bonusRequisitionHOMISCMAL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusRequisitionHOMISCMAL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalaryRequisitionHOMISCMAL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionHOMISCMAL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalaryRequisitionHODetail(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionHODetail(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rdoIncrementProposal(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoIncrementProposal(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rdoIncrementProposalAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoIncrementProposalAll(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rdoIncrementProposalHOAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoIncrementProposalHOAll(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable GetIncrementProposalHo (ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetIncrementProposalHo(objReportDTO);
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

        public DataSet monthlySalaryRequisitionHOMISCDetail(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionHOMISCDetail(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet monthlyCashRequisitionDetail(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyCashRequisitionDetail(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet monthlyCashRequisitionSFL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyCashRequisitionSFL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet bonusCashRequisitionSFL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusCashRequisitionSFL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet bonusCashRequisitionMAL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusCashRequisitionMAL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlyCashRequisitionMAL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyCashRequisitionMAL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
                        
        public DataSet GetCNFCashRequisitionMAL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetCNFCashRequisitionMAL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet monthlyCashRequisitionDirector(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyCashRequisitionDirector(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet monthlyAdvanceInformation(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyAdvanceInformation(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet monthlyTaxInformation(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyTaxInformation(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet taxStatement(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.taxStatement(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet TaxSummerySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.TaxSummerySheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet YearlyTaxSummerySheetDetail(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.YearlyTaxSummerySheetDetail(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet YearlyTaxSummerySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.YearlyTaxSummerySheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet YearlyTaxSummerySheetFB(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.YearlyTaxSummerySheetFB(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }





        public DataSet monthlyArrearInformation(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyArrearInformation(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlyAdvanceArrearInformation(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyAdvanceArrearInformation(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet arrearRequisition(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.arrearRequisition(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet arrearSummerySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.arrearSummerySheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet arrearBankSheetVerl(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.arrearBankSheetVerl(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet arrearBankSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.arrearBankSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet arrearCashSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.arrearCashSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet designationList(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.designationList(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet QuantityDefectPermissible(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.QuantityDefectPermissible(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet monthlyAATInformation(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyAdvanceArrearInformation(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet inactiveEmployeeList(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.inactiveEmployeeList(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet employeeDetailInformaiton(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeDetailInformaiton(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet employeeDetailList(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeDetailList(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet EmployeeDetailListAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.EmployeeDetailListAll(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet employeeEducationHistory(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeEducationHistory(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet employeePreJobHistory(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeePreJobHistory(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet employeeSalarySlip(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeSalarySlip(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet employeeBasicInformationByOffiwise(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeBasicInformationByOffiwise(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet employeeSalarySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeSalarySheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet SalarySheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.SalarySheetStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public DataSet GetStaffSalarySheetAsCash(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetStaffSalarySheetAsCash(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetStaffSalarySheetAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetStaffSalarySheetAll(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public DataTable GetStaffMasterSalarySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffMasterSalarySheet(objReportDTO);
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

        public DataTable GetStaffMasterSalarySheet(ReportDTO objReportDTO, int tagNo)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffMasterSalarySheet(objReportDTO,tagNo);
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

        public DataTable GetAllStaffMasterSalarySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetAllStaffMasterSalarySheet(objReportDTO);
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

        public DataTable GetStaffSalarySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffSalarySheet(objReportDTO);
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
        
        public DataTable GetStaffGenericSalarySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffGenericSalarySheet(objReportDTO);
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

        public DataSet SalarySheetStaff(string strUnitId, string strSectionId, string strYear, string strMonth, string strHeadOfficeId, string strBranchOfficeId)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.SalarySheetStaff(strUnitId, strSectionId, strYear, strMonth, strHeadOfficeId, strBranchOfficeId);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet salarySheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salarySheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //public DataSet monthlySalarySheetTest(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {

        //            ReportDAL objReportDAL = new ReportDAL();
        //            ds = objReportDAL.monthlySalarySheetTest(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }

        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        //public DataSet monthlySalarySummerySheetTest(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {

        //            ReportDAL objReportDAL = new ReportDAL();
        //            ds = objReportDAL.monthlySalarySummerySheetTest(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }

        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}






        public DataSet ProductionSummerySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.ProductionSummerySheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet monthlySalaryResignSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryResignSheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalaryWorkerSheetTemp(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryWorkerSheetTemp(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet monthlySalaryResignStaffSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryResignStaffSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable MonthlySalaryResignSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.MonthlySalaryResignSheetStaff(objReportDTO);
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

        public DataSet monthlySalaryStaffSheetTemp(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryStaffSheetTemp(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet PurchaseSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.PurchaseSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet ZipperReceiveSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.ZipperReceiveSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet employeeLeaveSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeLeaveSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet employeeLeaveSummerySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeLeaveSummerySheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet EmployeJoiningResignInfo(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.EmployeJoiningResignInfo(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet EmployeeResignInfo(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.EmployeeResignInfo(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet EmployeJoiningInfo(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.EmployeJoiningInfo(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet EmployeeMaleFemaleInfo(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.EmployeeMaleFemaleInfo(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet MonthlySalaryStatement(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.MonthlySalaryStatement(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rdoIncrementSummeryStatement(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoIncrementSummeryStatement(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rdoIncSummeryStatement(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoIncSummeryStatement(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rdoIncSummeryStatementOneYear(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoIncSummeryStatementOneYear(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptYearlySalaryStatementprocess(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptYearlySalaryStatementprocess(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet rptmonthlySalaryRevenue(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptmonthlySalaryRevenue(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet SalaryRangeInformation(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.SalaryRangeInformation(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet monthlyIncrementList(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyIncrementList(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rdoSalaryInfoByGrade(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoSalaryInfoByGrade(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet rdoSalarySummeryInfoByGrade(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoSalarySummeryInfoByGrade(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rdoGradeAdjustIncrementYearly(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoGradeAdjustIncrementYearly(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rdoGradeAdjustIncrementRequisitionYearly(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoGradeAdjustIncrementRequisitionYearly(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable SalaryAdjustRequisitionAccordingToGazette(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.SalaryAdjustRequisitionAccordingToGazette(objReportDTO);
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
        public DataSet monthlySalaryRequisitionFactoryStaffGross(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionFactoryStaffGross(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet monthlySalaryRequisitionWorkerGross(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionWorkerGross(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet smvInforamtion(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.smvInforamtion(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptEmployeeProcessSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptEmployeeProcessSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet idCardSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.idCardSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //
        public DataSet GetAppraisalLetter(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetAppraisalLetter(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet IncrementLetterSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.IncrementLetterSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet IncrementLetterSheetBangla(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.IncrementLetterSheetBangla(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet ConfirmLetterSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.ConfirmLetterSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ConfirmLetterSheetBangla(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.ConfirmLetterSheetBangla(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet PromotionLetterSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.PromotionLetterSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet PromotionLetterSheetBangla(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.PromotionLetterSheetBangla(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet workerTransferSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.workerTransferSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet workerYearlyPromotionSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.workerYearlyPromotionSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet rptIncrementSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncrementSheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptIncrementSheetWorkerCasual(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncrementSheetWorkerCasual(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet rptArrearSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptArrearSheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptArrearSheetWorkerRequisition(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptArrearSheetWorkerRequisition(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet rptIncrementSheetRequisitionWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncrementSheetRequisitionWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptIncrementMonthlySummerySheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncrementMonthlySummerySheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptIncrementProposalSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncrementProposalSheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptIncListWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncListWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptIncListWorkerExists(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncListWorkerExists(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet rptIncrementSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncrementSheetStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptIncrementYearlyProposalSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncrementYearlyProposalSheetStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        public DataSet rptIncrementSheetStaffByUnit(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncrementSheetStaffByUnit(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptIncrementAnnualSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncrementAnnualSheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptIncrementAnnualSheetWorkerByRequisition(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncrementAnnualSheetWorkerByRequisition(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptIncrementAnnualSheetWorkerNonProposal(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncrementAnnualSheetWorkerNonProposal(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //public DataSet rptIncrementAnnualSheetStaffNonProposal(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {

        //            ReportDAL objReportDAL = new ReportDAL();
        //            ds = objReportDAL.rptIncrementAnnualSheetStaffNonProposal(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }

        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public DataSet incrementProposalSheetStaffSummeryNonProposal(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementProposalSheetStaffSummeryNonProposal(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptIncrementAnnualSheetStaffNonProposal(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncrementAnnualSheetStaffNonProposal(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet rptIncrementAnnualSheetWorkerNonProposalByUnit(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptIncrementAnnualSheetWorkerNonProposalByUnit(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet bonusSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusSheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet bonusSheetWorkerTest(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusSheetWorkerTest(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet bonusSlipWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusSlipWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptFirstBonusSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptFirstBonusSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptBankBonusSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptBankBonusSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet rptCashBonusSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptCashBonusSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet rptFirstSheetBonusSlip(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptFirstSheetBonusSlip(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet rptSecondSheetBonusSlip(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptSecondSheetBonusSlip(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptSecondBonusSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptSecondBonusSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptBonusSummerySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptBonusSummerySheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet bankBonusSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bankBonusSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet bonusCashSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusCashSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet GetDirectorCashSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetDirectorCashSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet GetNoneDirectorCashSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetNoneDirectorCashSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //New
        public DataTable FirstBonusSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.FirstBonusSheetStaff(objReportDTO);
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

        public DataTable GetStaffBkashSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffBkashSheet(objReportDTO);
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

        public DataTable GetStaffEidBonus(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffEidBonus(objReportDTO);
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
        public DataTable SecondBonusSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.SecondBonusSheetStaff(objReportDTO);
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



        //Old
        public DataSet bonusSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusSheetStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //GetBankBonusSheetStaff
        public DataSet GetBankBonusSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetBankBonusSheetStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //GetAllBonusSheetStaff
        public DataSet GetAllBonusSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetAllBonusSheetStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet bonusSheetManual(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusSheetManual(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet bonusPaySlipStaffFirst(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusPaySlipStaffFirst(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet bonusPaySlipStaffMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusPaySlipStaffMisc(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable StaffBonusSummerySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.StaffBonusSummerySheet(objReportDTO);
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

        //Old
        public DataSet bonusSummerySheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusSummerySheetStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet bonusSheetStaffMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusSheetStaffMisc(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //public DataSet paySlipWorker(ReportDTO objReportDTO)
        public DataTable paySlipWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable table = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.paySlipWorker(objReportDTO);
                    table = ds.Tables[0];

                    foreach (DataRow dr in table.Rows) // search whole table
                    {
                        //WHEN salary_month = '1' THEN 'Rvbyqvix'
                        //WHEN salary_month = '2' THEN '?de?yqvwi'
                        //WHEN salary_month = '3' THEN 'gvP?'
                        //WHEN salary_month = '4' THEN 'GwcÖj'
                        //WHEN salary_month = '5' THEN '‡g'
                        //WHEN salary_month = '6' THEN 'Ryb'
                        //WHEN salary_month = '7' THEN 'RyjvB'
                        //WHEN salary_month = '8' THEN 'AvMo'
                        //WHEN salary_month = '9' THEN '?m???^i'
                        //WHEN salary_month = '10' THEN 'A??vei'
                        //WHEN salary_month = '11' THEN 'b?f?^i'
                        //WHEN salary_month = '12' THEN 'wW?m?^i'

                        dr["month_year"] = Convert.ToString(dr["month_year"]).Replace("Jan", "Rvbyqvix");
                        dr["month_year"] = Convert.ToString(dr["month_year"]).Replace("Feb", "?de?yqvwi");
                        dr["month_year"] = Convert.ToString(dr["month_year"]).Replace("Mar", "gvP?");
                        dr["month_year"] = Convert.ToString(dr["month_year"]).Replace("Apr", "GwcÖj");

                        dr["month_year"] = Convert.ToString(dr["month_year"]).Replace("May", "‡g");
                        dr["month_year"] = Convert.ToString(dr["month_year"]).Replace("Jun", "Ryb");
                        dr["month_year"] = Convert.ToString(dr["month_year"]).Replace("Jul", "RyjvB");
                        dr["month_year"] = Convert.ToString(dr["month_year"]).Replace("Aug", "AvMo");

                        dr["month_year"] = Convert.ToString(dr["month_year"]).Replace("Sep", "?m???^i");
                        dr["month_year"] = Convert.ToString(dr["month_year"]).Replace("Oct", "A??vei");
                        dr["month_year"] = Convert.ToString(dr["month_year"]).Replace("Nov", "b?f?^i");
                        dr["month_year"] = Convert.ToString(dr["month_year"]).Replace("Dec", "wW?m?^i");


                        //if (dr["month_year"] == 2) // if id==2
                        //{
                        //    dr["Product_name"] = "cde"; //change the name
                        //                                //break; break or not depending on you
                        //}
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public DataSet monthlySalaryPaySlipTest(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {

        //            ReportDAL objReportDAL = new ReportDAL();
        //            ds = objReportDAL.monthlySalaryPaySlipTest(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }

        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public DataSet rptContractSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptContractSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptCostingSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptCostingSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptCostSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptCostSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet rptPOOrderSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptPOOrderSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet rptPORequisitionSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptPORequisitionSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet rptFabricsDetailSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptFabricsDetailSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet monthlyWorkingDayList(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyWorkingDayList(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public DataSet GetAttendanceRegister(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {
        //            ReportDAL objReportDAL = new ReportDAL();
        //            ds = objReportDAL.GetAttendanceRegister(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public DataSet rptProductionDefect(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptProductionDefect(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ProductionDefectVerificationSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.ProductionDefectVerificationSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ProductionDefectVerificationSummeryByUnitWise(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.ProductionDefectVerificationSummeryByUnitWise(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ProductionEfficiencySummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.ProductionEfficiencySummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ProductionEfficiencySummerByUnit(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.ProductionEfficiencySummerByUnit(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet SkillMatrixBottom(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.SkillMatrixBottom(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet ProductionEfficiency(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.ProductionEfficiency(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet ProductionEfficiencyDetail(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.ProductionEfficiencyDetail(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet ForeignFabricInformationDetail(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.ForeignFabricInformationDetail(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet foreignFabricSummeryByProgramme(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.foreignFabricSummeryByProgramme(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet rptHalfSalary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfSalary(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet rptHalfSalaryHO(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfSalaryHO(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptHalfSalarySheetByBankHO(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfSalarySheetByBankHO(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptHalfSalaryHOMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfSalaryHOMisc(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet rptHalfSalaryHOPaySlip(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfSalaryHOPaySlip(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet rptHalfSalaryHOPaySlipMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfSalaryHOPaySlipMisc(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptHalfSalaryHOCash(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfSalaryHOCash(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptHalfSalaryHOCashSlip(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfSalaryHOCashSlip(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet rptHalfCashSalaryRequisitionHO(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfCashSalaryRequisitionHO(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet rptHalfSalaryRequisition(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfSalaryRequisition(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Added by Asad on 14.06.2018
        public DataTable GetHalfSalarySummaryForWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetHalfSalarySummaryForWorker(objReportDTO);
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

        //Next
        public DataTable GetAttendanceRegisterNext(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetAttendanceRegisterNext(objReportDTO);
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
        public DataTable GetAttendanceRegister(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetAttendanceRegister(objReportDTO);
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

        public DataTable GetOTSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetOTSummary(objReportDTO);
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

        public DataTable GetWorkingHourSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkingHourSummary(objReportDTO);
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

        public DataTable GetStaffSalaryByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffSalaryByUnitGroup(objReportDTO);
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

        public DataTable GetCaseSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetCaseSheet(objReportDTO);
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
        public DataTable GetCaseNotice(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetCaseNotice(objReportDTO);
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

        
        public DataTable GetCaseEnvelope(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetCaseEnvelope(objReportDTO);
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
        
        public DataTable GetSalaryByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetSalaryByUnitGroup(objReportDTO);
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
        public DataTable GetWorkerSalaryMasterSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerSalaryMasterSheet(objReportDTO);
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

        public DataTable GetWorkerSalaryMasterSheet(ReportDTO objReportDTO, int tagNo)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerSalaryMasterSheet(objReportDTO,tagNo);
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

        public DataTable GetWorkerSalaryMasterSheetTiffin(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerSalaryMasterSheetTiffin(objReportDTO);
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


        public DataTable GetAllWorkerSalaryMasterSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetAllWorkerSalaryMasterSheet(objReportDTO);
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


        public DataTable GetFACSalarySheetWorkerForCorona(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetFACSalarySheetWorkerForCorona(objReportDTO);
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
        //public DataTable GetWorkerExtendedSalarySheet(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {
        //            ReportDAL objReportDAL = new ReportDAL();
        //            dt = objReportDAL.GetWorkerExtendedSalarySheet(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataTable GetIncrementArrearAdjSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetIncrementArrearAdjSheet(objReportDTO);
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

        //public DataTable GetExtendedSalaryRequisition(GazetteDTO objGazetteDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {
        //            ReportDAL objReportDAL = new ReportDAL();
        //            dt = objReportDAL.GetExtendedSalaryRequisition(objGazetteDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataTable GetIncrementArrearRequisition(GazetteDTO objGazetteDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetIncrementArrearRequisition(objGazetteDTO);
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
        public DataTable GetIncrementArrearReqSummary(GazetteDTO objGazetteDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetIncrementArrearReqSummary(objGazetteDTO);
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
        //GetStaffPaySlip
        public DataTable GetStaffPaySlip(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffPaySlip(objReportDTO);
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
        public DataTable GetWorkerPaySlipByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerPaySlipByUnitGroup(objReportDTO);
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

        public DataTable GetWorkerTiffinSheetByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerTiffinSheetByUnitGroup(objReportDTO);
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

        public DataTable bonusSheetWorkerByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.bonusSheetWorkerByUnitGroup(objReportDTO);
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

        public DataTable rptHalfSalaryW(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.rptHalfSalaryW(objReportDTO);
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

        
        public DataTable GetRoadMap(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetRoadMap(objReportDTO);
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
        
        public DataTable GethalfSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GethalfSheetStaff(objReportDTO);
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
        public DataTable rptHalfSheetStaffSecondSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.rptHalfSheetStaffSecondSheet(objReportDTO);
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

        public DataTable GetStaffHalfSheetSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffHalfSheetSummery(objReportDTO);
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
        public DataTable GetOverTimeSheetByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetOverTimeSheetByUnitGroup(objReportDTO);
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
        public DataSet rptHalfSalaryRequisitionStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfSalaryRequisitionStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptHalfBankSalaryRequisitionStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfBankSalaryRequisitionStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        public DataSet halfSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.halfSheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet EmployeeListByGrade(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.EmployeeListByGrade(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet workerMiscSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.workerMiscSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet monthlySalarySummeryWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySummeryWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet paySlipStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.paySlipStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetStaffSalaryPaySlip(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffSalaryPaySlip(objReportDTO);
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
        public DataSet rptHalfSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfSheetStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet halfBankSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.halfBankSheetStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //new 
        public DataTable StaffSalarySheetMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.StaffSalarySheetMisc(objReportDTO);
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

        //Old
        public DataSet monthlySalarySheetStaffMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySheetStaffMisc(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet monthlyPaySlipStaffMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyPaySlipStaffMisc(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptHalfSheetStaffMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfSheetStaffMisc(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptHalfSheetStaffSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptHalfSheetStaffSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //New
        //new
        public DataTable StaffSalarySummaryMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.StaffSalarySummaryMisc(objReportDTO);
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

        public DataTable StaffSalarySummaryMiscTiffin(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.StaffSalarySummaryMiscTiffin(objReportDTO);
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


        //Old
        public DataSet monthlyStaffSalarySummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyStaffSalarySummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlyStaffSalaryMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyStaffSalaryMisc(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet halfSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.halfSheetStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet salarySheetHO(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salarySheetHO(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalarySheetHOByBank(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySheetHOByBank(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalarySheetSPByBank(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySheetSPByBank(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet bonusSheetHOByBank(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusSheetHOByBank(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet monthlySalarySheetHOSrStaffs(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySheetHOSrStaffs(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalarySheetHOFactSrStafss(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySheetHOFactSrStafss(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet monthlySalarySheetHONormal(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySheetHONormal(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet salarySheetHOMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salarySheetHOMisc(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet GetHiddenSalarySheetHOMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetHiddenSalarySheetHOMisc(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlyLunchSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyLunchSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlyLunchSheetSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyLunchSheetSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet monthlySalarySheetHOSRMISC(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySheetHOSRMISC(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet monthlySalarySheetHOSRMISCNormal(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySheetHOSRMISCNormal(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalarySheetFactSRMISC(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySheetFactSRMISC(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet salarySlipHO(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salarySlipHO(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalarySlipHOSrStafss(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySlipHOSrStafss(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet monthlySalarySlipHoFactSr(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySlipHoFactSr(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet monthlySalaryPaySlipHONormal(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryPaySlipHONormal(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalaryCheckPaySlip(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryCheckPaySlip(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet salarySlipHOMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salarySlipHOMisc(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalarySheetHOMISCPaySlipNormal(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySheetHOMISCPaySlipNormal(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalarySheetHOMISCPaySlipSR(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySheetHOMISCPaySlipSR(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalarySheetHOMISCPaySlipFactSR(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalarySheetHOMISCPaySlipFactSR(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet salaryListForBank(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salaryListForBank(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public DataSet employeeListWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeListWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet employeeList(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeList(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet employeeJobYearMonthHistory(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeJobYearMonthHistory(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlyTiffinRequisition(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyTiffinRequisition(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet monthlyTiffinRequisitionSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyTiffinRequisitionSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetTiffinRequisitionSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetTiffinRequisitionSummary(objReportDTO);
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


        public DataSet monthlyOverTimeSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyOverTimeSheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlyOverTimeResignSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyOverTimeResignSheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptOverTimeShettWorkerSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptOverTimeShettWorkerSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet OTSummeryMonthly(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.OTSummeryMonthly(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlyOverTimeRequisition(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyOverTimeRequisition(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet rptOverTimeRequsitionSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptOverTimeRequsitionSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet monthlySalaryRequisitionFactoryStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionFactoryStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet monthlySalaryRequisitionFactoryStaffMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionFactoryStaffMisc(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalaryRequisitionWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet leaveSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.leaveSheetStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet GetNonAccountHolderEncashSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetNonAccountHolderEncashSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet leaveSheetStaffMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.leaveSheetStaffMisc(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet leaveSheetStaffSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.leaveSheetStaffSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet leaveSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.leaveSheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet monthlySalaryRequisition(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisition(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //public DataSet monthlySalaryRequisitionTest(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {

        //            ReportDAL objReportDAL = new ReportDAL();
        //            ds = objReportDAL.monthlySalaryRequisitionTest(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }

        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public DataSet monthlySalaryRequisitionSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public DataSet monthlySalaryRequisitionSummeryTest(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {

        //            ReportDAL objReportDAL = new ReportDAL();
        //            ds = objReportDAL.monthlySalaryRequisitionSummeryTest(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }

        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}


        public DataSet monthlySalaryRequisitionHOStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionHOStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlyEmployeeSalaryHistoryStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyEmployeeSalaryHistoryStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet monthlySalaryRequisitionBankStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryRequisitionBankStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet rpLayChartRegister(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rpLayChartRegister(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlyOTRequisition(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyOTRequisition(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet eidBonusRequisitionWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.eidBonusRequisitionWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet bonusRequisitionSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusRequisitionSheetStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet bonusRequisitionBankSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.bonusRequisitionBankSheetStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //nnn
        //public DataSet GetAllBonusRequisitionStaff(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {

        //            ReportDAL objReportDAL = new ReportDAL();
        //            ds = objReportDAL.bonusRequisitionBankSheetStaff(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }

        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        public DataSet eidBonusRequisitionWorkerTest(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.eidBonusRequisitionWorkerTest(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet eidBonusRequisitionSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.eidBonusRequisitionSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetIncrementProposalAuto(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetIncrementProposalAuto(objReportDTO);
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

        public DataSet LeaveRequisitionStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.LeaveRequisitionStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet LeaveRequisitionWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.LeaveRequisitionWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet leaveRequisitionAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.leaveRequisitionAll(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptLeaveRequisitionSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptLeaveRequisitionSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet dailyAttendenceTopSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.dailyAttendenceTopSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet attendencePresentSummerySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.attendencePresentSummerySheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet dailyAttendence(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.dailyAttendence(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet dailyAttendenceSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.dailyAttendenceSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

         }
                        
        public DataSet GetManualAttendanceSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetManualAttendanceSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        //PrepareAttendanceSummary

        public DataTable GetAttendanceSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetAttendanceSummary(objReportDTO);
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

        public DataTable dailyAttendenceSheetWOLogIn(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();

                    dt = objReportDAL.dailyAttendenceSheetWOLogIn(objReportDTO);
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

        public DataSet rptSalaryApproveSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptSalaryApproveSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet dailyAttendenceSheetHO(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.dailyAttendenceSheetHO(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }



        public DataSet dailyAttendenceSheetInOut(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.dailyAttendenceSheetInOut(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet EmployeeListAboveOneYear(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.EmployeeListAboveOneYear(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet EmployeeListBellowOneYear(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.EmployeeListBellowOneYear(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }




        public DataSet dailyAttendenceSheetBuyer(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.dailyAttendenceSheetBuyer(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }



        public DataSet dailyAbsenceSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.dailyAbsenceSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public DataTable GetOverTimeAnalyzeSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetOverTimeAnalyzeSheet(objReportDTO);
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
        public DataSet DailyAttendenceClosingSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.DailyAttendenceClosingSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet DailyAttendenceOpeningSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.DailyAttendenceOpeningSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet rptWorkerOverTimeSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptWorkerOverTimeSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet rptMonthlyAttendenceSheetSP(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptMonthlyAttendenceSheetSP(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet rptMonthlyAttendenceSummerySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptMonthlyAttendenceSummerySheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet rptMonthlyAttendenceSheetSPAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptMonthlyAttendenceSheetSPAll(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet rptMonthlyAttendenceSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptMonthlyAttendenceSheetWorker(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet BonusProposalForBellow6Month(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.BonusProposalForBellow6Month(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet BonusProposalForBellowOneYear(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.BonusProposalForBellowOneYear(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet BonusProposalWorker11to12Month(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.BonusProposalWorker11to12Month(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet rdoBonusProposalForBellow6MonthForStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoBonusProposalForBellow6MonthForStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet rdoBonusProposalForStaffBellow1Year(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoBonusProposalForStaffBellow1Year(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet rdoBonusProposalForStaff11to12Month(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoBonusProposalForStaff11to12Month(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }



        public DataSet rptlateSheetSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptlateSheetSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet dailyAttendenceLateSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.dailyAttendenceLateSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet dailyAttendenceWithLateSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.dailyAttendenceWithLateSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet salarySummeryHO(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salarySummeryHO(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet montlyBankSalaryList(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.montlyBankSalaryList(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetSalaryAdvice(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetSalaryAdvice(objReportDTO);
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

        //new
        public DataTable GetBankSalaryDetailHO(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetBankSalaryDetailHO(objReportDTO);
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

        public DataTable GetSalaryReruisitionSummaryHO(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetSalaryReruisitionSummaryHO(objReportDTO);
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

        public DataSet montlyBankSalarySlip(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.montlyBankSalarySlip(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet monthlyBankHalfSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyBankHalfSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet salaryListBankSPGCL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salaryListBankSPGCL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet salaryListBankSPEL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salaryListBankSPEL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet salaryListBankVERL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salaryListBankVERL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable monthlySalaryCheckSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.monthlySalaryCheckSheet(objReportDTO);
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
        
        public DataTable GetCNFCashSalarySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetCNFCashSalarySheet(objReportDTO);
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
        public DataSet monthlySalaryCheckSheetDirector(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryCheckSheetDirector(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlySalaryCheckSheetDirectorHO(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlySalaryCheckSheetDirectorHO(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet salaryListBankMAL(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salaryListBankMAL(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string processSalarySummeryHO(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalarySummeryHO(objReportDTO);
            return strMsg;
        }

        public string salaryProcessMiscHeadOfficeSeniorStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.salaryProcessMiscHeadOfficeSeniorStaff(objReportDTO);
            return strMsg;
        }

        public string processMonthlySalaryHOSr(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlySalaryHOSr(objReportDTO);
            return strMsg;
        }

        public string selectBankSalaryProcedure(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.selectBankSalaryProcedure(objReportDTO);
            return strMsg;
        }

        public string selectBankHalfSalaryProcedure(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.selectBankHalfSalaryProcedure(objReportDTO);
            return strMsg;
        }

        public string cashHalfSalaryProcedure(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.cashHalfSalaryProcedure(objReportDTO);
            return strMsg;
        }

        public string cashHalfSalaryRequisitionProcedure(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.cashHalfSalaryRequisitionProcedure(objReportDTO);
            return strMsg;
        }

        public string selectBonusBankProcedure(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.selectBonusBankProcedure(objReportDTO);
            return strMsg;
        }

        public string bonusRequisitionStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.bonusRequisitionStaff(objReportDTO);
            return strMsg;
        }

        public string bonusBankRequisitionStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.bonusBankRequisitionStaff(objReportDTO);
            return strMsg;
        }

        public string ProcessEidBonusRequisitionStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.ProcessEidBonusRequisitionStaff(objReportDTO);
            return strMsg;
        }

        public string ProcessAllBonusRequisitionStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.ProcessAllBonusRequisitionStaff(objReportDTO);
            return strMsg;
        }

        public string bonusCashSheetPro(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.bonusCashSheetPro(objReportDTO);
            return strMsg;
        }


        public string salaryProcessByBank(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.salaryProcessByBank(objReportDTO);
            return strMsg;
        }



        public string processMonthlyBankSalarySFL(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlyBankSalarySFL(objReportDTO);
            return strMsg;
        }

        public string processMonthlyBankSalaryMAL(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlyBankSalaryMAL(objReportDTO);
            return strMsg;
        }

        public string processSalaryRequisitionHO(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionHO(objReportDTO);
            return strMsg;
        }

        public string processBonusRequisitionHO(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processBonusRequisitionHO(objReportDTO);
            return strMsg;
        }

        public string processHalfSalaryRequisitionHO(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processHalfSalaryRequisitionHO(objReportDTO);
            return strMsg;
        }


        public string processSalaryRequisitionHODetail(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionHODetail(objReportDTO);
            return strMsg;
        }
        public string processSalaryRequisitionCashDetail(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionCashDetail(objReportDTO);
            return strMsg;
        }

        public string processSalaryRequisitionHOMISCDetail(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionHOMISCDetail(objReportDTO);
            return strMsg;
        }

        public string processArrearRequsition(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processArrearRequsition(objReportDTO);
            return strMsg;
        }

        public string processArrearSummery(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processArrearSummery(objReportDTO);
            return strMsg;
        }

        public string processArrearCash(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processArrearCash(objReportDTO);
            return strMsg;
        }


        public string selectArrearBank(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.selectArrearBank(objReportDTO);
            return strMsg;
        }

        public string processArrearSummeryUpdate(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processArrearSummeryUpdate(objReportDTO);
            return strMsg;
        }

        public string processMonthlyAttendenceSheet(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlyAttendenceSheet(objReportDTO);
            return strMsg;
        }


        public string processSalaryHistory(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryHistory(objReportDTO);
            return strMsg;
        }


        public string processMonthlyAttendenceSummerySheet(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlyAttendenceSummerySheet(objReportDTO);
            return strMsg;
        }

        public string processYearlyTaxStatement(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processYearlyTaxStatement(objReportDTO);
            return strMsg;
        }

        public string processYearlyTaxSummery(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processYearlyTaxSummery(objReportDTO);
            return strMsg;
        }

        public string processYearlyTaxSummeryFB(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processYearlyTaxSummeryFB(objReportDTO);
            return strMsg;
        }

        public string processTaxSummeryDetail(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processTaxSummeryDetail(objReportDTO);
            return strMsg;
        }



        public string processMonthlyAttendenceSummerySheetPower(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlyAttendenceSummerySheetPower(objReportDTO);
            return strMsg;
        }


        public string processMonthlyAttendenceSheetAll(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlyAttendenceSheetAll(objReportDTO);
            return strMsg;
        }

        public string processMonthlyAttendenceSheetHO(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlyAttendenceSheetHO(objReportDTO);
            return strMsg;
        }



        public string processMonthlyAttendenceSheetWorker(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlyAttendenceSheetWorker(objReportDTO);
            return strMsg;
        }

        public string ProcessBonusProposalForBellow6Month(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.ProcessBonusProposalForBellow6Month(objReportDTO);
            return strMsg;
        }

        public string processBonusProposalWorker11to12Month(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processBonusProposalWorker11to12Month(objReportDTO);
            return strMsg;
        }

        public string processBonusProposalStaff11to12Month(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processBonusProposalStaff11to12Month(objReportDTO);
            return strMsg;
        }

        public string ProcessBonusProposalStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.ProcessBonusProposalStaff(objReportDTO);
            return strMsg;
        }

        public string processMonthlyCashSalarySheet(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlyCashSalarySheet(objReportDTO);
            return strMsg;
        }

        public string processTiffinRequisition(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processTiffinRequisition(objReportDTO);
            return strMsg;
        }

        public string processWorkerSalaryRange(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processWorkerSalaryRange(objReportDTO);
            return strMsg;
        }
        public string processWorkerSalaryRangeSummery(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processWorkerSalaryRangeSummery(objReportDTO);
            return strMsg;
        }

        public string processWorkerPromotion(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processWorkerPromotion(objReportDTO);
            return strMsg;
        }

        public string processEmployeePromotion(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processEmployeePromotion(objReportDTO);
            return strMsg;
        }


        public string processAttendenceTopSheet(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processAttendenceTopSheet(objReportDTO);
            return strMsg;
        }

        public string processAttendencePresentSummerySheet(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processAttendencePresentSummerySheet(objReportDTO);
            return strMsg;
        }

        public string processAttendenceClosingSheet(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processAttendenceClosingSheet(objReportDTO);
            return strMsg;
        }

        public string processAttendenceOpeningSheet(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processAttendenceOpeningSheet(objReportDTO);
            return strMsg;
        }

        public string defectPermissibleProcess(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.defectPermissibleProcess(objReportDTO);
            return strMsg;
        }

        public string processDailyAttendenceSheet(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processDailyAttendenceSheet(objReportDTO);
            return strMsg;
        }

        public string ProcessIftarTimeSheet(IfratTimeSheetDTO objIfratTimeDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.ProcessIftarTimeSheet(objIfratTimeDTO);
            return strMsg;
        }

        public string processDailyAttendenceSheetBuyer(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processDailyAttendenceSheetBuyer(objReportDTO);
            return strMsg;
        }


        public string lateSheetSummery(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.lateSheetSummery(objReportDTO);
            return strMsg;
        }

        public string processSalaryByGrade(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryByGrade(objReportDTO);
            return strMsg;
        }

        public string processGradeAdjustIncrementYearly(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processGradeAdjustIncrementYearly(objReportDTO);
            return strMsg;
        }


        public string ProcessSalaryGradeAdjustment(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.ProcessSalaryGradeAdjustment(objReportDTO);
            return strMsg;
        }

        public string processGradeAdjustIncrementRequiYearly(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processGradeAdjustIncrementRequiYearly(objReportDTO);
            return strMsg;
        }

        public string processEmployeeYearList(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processEmployeeYearList(objReportDTO);
            return strMsg;
        }
        public string processSalaryRequisitionWokerGross(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionWokerGross(objReportDTO);
            return strMsg;
        }
        public string processSalaryRequisitionFactoryStaffGross(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionFactoryStaffGross(objReportDTO);
            return strMsg;
        }
        public string processDailyAbsenceSheet(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processDailyAbsenceSheet(objReportDTO);
            return strMsg;
        }
        public DataSet NewEmployeeList(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.NewEmployeeList(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable GetActiveEmployeeList(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetActiveEmployeeList(objReportDTO);
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

        public DataTable GetActiveEmployee(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetActiveEmployee(objReportDTO);
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


        public string attendenceSheetLate(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.attendenceSheetLate(objReportDTO);
            return strMsg;
        }

        public string processsDailyContractInfo(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processsDailyContractInfo(objReportDTO);
            return strMsg;
        }

        public string processOverTimeRequisition(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processOverTimeRequisition(objReportDTO);
            return strMsg;
        }

        public string processSalaryRequisitionFactoryStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionFactoryStaff(objReportDTO);
            return strMsg;
        }

        public string processSalaryRequisitionFactoryStaffMisc(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionFactoryStaffMisc(objReportDTO);
            return strMsg;
        }

        public string processLeaveRequisitionFactoryWorker(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processLeaveRequisitionFactoryWorker(objReportDTO);
            return strMsg;
        }

        public string processLeaveRequisitionAll(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processLeaveRequisitionAll(objReportDTO);
            return strMsg;
        }

        public string processLeaveRequisitionFactoryStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processLeaveRequisitionFactoryStaff(objReportDTO);
            return strMsg;
        }

        public string processSalaryRequisitionWoker(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionWoker(objReportDTO);
            return strMsg;
        }

        public string processSalaryRequisitionAll(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionAll(objReportDTO);
            return strMsg;
        }

        public string processSalaryRequisitionTest(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionTest(objReportDTO);
            return strMsg;
        }


        public string processSalaryRequisitionHoStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionHoStaff(objReportDTO);
            return strMsg;
        }

        public string processSalaryRequisitionHoBankStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionHoBankStaff(objReportDTO);
            return strMsg;
        }


        public string processHalfSalaryRequisitionHoStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processHalfSalaryRequisitionHoStaff(objReportDTO);
            return strMsg;
        }

        public string processHalfSalaryBankRequisitionHoStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processHalfSalaryBankRequisitionHoStaff(objReportDTO);
            return strMsg;
        }


        public string processMonthlyOTRequisition(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlyOTRequisition(objReportDTO);
            return strMsg;
        }

        public string processMonthlyWorkingDayList(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlyWorkingDayList(objReportDTO);
            return strMsg;
        }

        public string MonthlySalaryStatementprocess(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.MonthlySalaryStatementprocess(objReportDTO);
            return strMsg;
        }

        public string processYearlyWorkerIncrementStatement(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processYearlyWorkerIncrementStatement(objReportDTO);
            return strMsg;
        }

        public string processYearlyWorkerIncrementSummeryStatement(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processYearlyWorkerIncrementSummeryStatement(objReportDTO);
            return strMsg;
        }

        public string processYearlyWorkerIncSummeryStatement(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processYearlyWorkerIncSummeryStatement(objReportDTO);
            return strMsg;
        }

        public string YearlySalaryStatementprocess(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.YearlySalaryStatementprocess(objReportDTO);
            return strMsg;
        }

        public string monthlySalaryRevenue(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.monthlySalaryRevenue(objReportDTO);
            return strMsg;
        }


        public string defectCalculation(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.defectCalculation(objReportDTO);
            return strMsg;
        }

        public string ProductionEfficiencyDetailCalculation(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.ProductionEfficiencyDetailCalculation(objReportDTO);
            return strMsg;
        }

        public string DefectSummery(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.DefectSummery(objReportDTO);
            return strMsg;
        }

        public string EfficiencySummery(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.EfficiencySummery(objReportDTO);
            return strMsg;
        }



        public string bonusRequisitionWorker(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.bonusRequisitionWorker(objReportDTO);
            return strMsg;
        }

        public string bonusRequisitionWorkerTest(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.bonusRequisitionWorkerTest(objReportDTO);
            return strMsg;
        }

        public string deleteBonusWorker(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.deleteBonusWorker(objReportDTO);
            return strMsg;
        }

        public string deleteBonusAddWorker(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.deleteBonusAddWorker(objReportDTO);
            return strMsg;
        }

        public string deleteBonusAddHO(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.deleteBonusAddHO(objReportDTO);
            return strMsg;
        }

        public string deleteBonusStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.deleteBonusStaff(objReportDTO);
            return strMsg;
        }

        public string deleteBonusAddStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.deleteBonusAddStaff(objReportDTO);
            return strMsg;
        }

        public string monthlyWorkerSalaryMisc(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.monthlyWorkerSalaryMisc(objReportDTO);
            return strMsg;
        }

        public string deleteMonthlySalary(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.deleteMonthlySalary(objReportDTO);
            return strMsg;
        }

        public string processIncrementWorker(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncrementWorker(objReportDTO);
            return strMsg;
        }

        public string processIncrementWorkerAnnual(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncrementWorkerAnnual(objReportDTO);
            return strMsg;
        }

        public string processIncrementWorkerAnnualJK(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncrementWorkerAnnualJK(objReportDTO);
            return strMsg;
        }

        public string processIncrementRequisitionWorkerYearly(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncrementRequisitionWorkerYearly(objReportDTO);
            return strMsg;
        }


        public string processIncrementStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncrementStaff(objReportDTO);
            return strMsg;
        }



        public string processIncrementAmountToGross(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncrementAmountToGross(objReportDTO);
            return strMsg;
        }

        public string processIncrementProposal(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncrementProposal(objReportDTO);
            return strMsg;
        }


        public string processIncrementProposalMonthly(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncrementProposalMonthly(objReportDTO);
            return strMsg;
        }

        public string processIncProposalExistsMonthly(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncProposalExistsMonthly(objReportDTO);
            return strMsg;
        }

        public string processNewEmpProposal(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processNewEmpProposal(objReportDTO);
            return strMsg;
        }


        public string processIncrementAmountToGrossCasual(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncrementAmountToGrossCasual(objReportDTO);
            return strMsg;
        }


        public string processIncrementAmountToGrossStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncrementAmountToGrossStaff(objReportDTO);
            return strMsg;
        }

        public string processIncrementAmountToGrossStaffMonthly(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncrementAmountToGrossStaffMonthly(objReportDTO);
            return strMsg;
        }


        public string processIncrementAmountToGrossAnnualWorker(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncrementAmountToGrossAnnualWorker(objReportDTO);
            return strMsg;
        }

        public string processIncrementAmountToGrossWorkerNonProposal(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncrementAmountToGrossWorkerNonProposal(objReportDTO);
            return strMsg;
        }
        //public string processIncrementAmountStaffNonProposal(ReportDTO objReportDTO)
        //{
        //    ReportDAL objReportDAL = new ReportDAL();
        //    string strMsg = "";
        //    strMsg = objReportDAL.processIncrementAmountStaffNonProposal(objReportDTO);
        //    return strMsg;
        //}

        public string processIncrementAmountStaffNonProposal(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processIncrementAmountStaffNonProposal(objReportDTO);
            return strMsg;
        }

        public string processFivePercentNonProposal(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processFivePercentNonProposal(objReportDTO);
            return strMsg;
        }

        public string processStaffNonProposal(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processStaffNonProposal(objReportDTO);
            return strMsg;
        }

        public string processSalaryRequisitionHOMISC(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionHOMISC(objReportDTO);
            return strMsg;
        }

        public string processBonusRequisitionHOMISC(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processBonusRequisitionHOMISC(objReportDTO);
            return strMsg;
        }

        public string processHalfSalaryRequisitionHOMISC(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processHalfSalaryRequisitionHOMISC(objReportDTO);
            return strMsg;
        }

        public string processMonthlyCashRequisition(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlyCashRequisition(objReportDTO);
            return strMsg;
        }

        public string processBonusCashRequisitionHO(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processBonusCashRequisitionHO(objReportDTO);
            return strMsg;
        }

        public string processMonthlySalaryHOFactSr(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlySalaryHOFactSr(objReportDTO);
            return strMsg;
        }

        public string processMonthlySalaryHOSrNoraml(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processMonthlySalaryHOSrNoraml(objReportDTO);
            return strMsg;
        }

        public string salaryProcessMiscHeadOfficeSeniorFactoryStaff(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.salaryProcessMiscHeadOfficeSeniorFactoryStaff(objReportDTO);
            return strMsg;
        }

        public string salaryProcessMiscHeadOfficeNormal(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.salaryProcessMiscHeadOfficeNormal(objReportDTO);
            return strMsg;
        }
        public string processSalaryRequisition(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisition(objReportDTO);
            return strMsg;
        }


        public string foreignFabricSummery(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.foreignFabricSummery(objReportDTO);
            return strMsg;
        }

        public string foreignFabricDetailStatus(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.foreignFabricDetailStatus(objReportDTO);
            return strMsg;
        }


        public DataSet salaryRequisition(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salaryRequisition(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet incrementProposalWorkerAboveOneYear(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementProposalWorkerAboveOneYear(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet incGradeAdjustmentSheetAboveOneYear(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incGradeAdjustmentSheetAboveOneYear(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet incrementProposalWorkerAboveOneYearAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementProposalWorkerAboveOneYearAll(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet incrementProposalStaffAboveOneYearAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementProposalStaffAboveOneYearAll(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet incrementSheetAboveOneYearStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementSheetAboveOneYearStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rpIncrementProposalPower(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rpIncrementProposalPower(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet incrementProposalSheetWorkerSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementProposalSheetWorkerSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet incrementProposalSheetWorkerSummeryEng(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementProposalSheetWorkerSummeryEng(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet incrementProposalSheetStaffSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementProposalSheetStaffSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet incrementProposalSheetWorkerSummeryNonProposal(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementProposalSheetWorkerSummeryNonProposal(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet incrementProposalSheetStaffSummeryEng(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementProposalSheetStaffSummeryEng(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet incrementProposalWorkerBellowOneYear(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementProposalWorkerBellowOneYear(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet IncrementRequisitionWorkerYearly(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.IncrementRequisitionWorkerYearly(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet incrementSheetBellowOneYearStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementSheetBellowOneYearStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet incrementProposalStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementProposalStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet incrementProposalHOSheet1(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementProposalHOSheet1(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet incrementProposalHOSheet2(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementProposalHOSheet2(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet tiffinRequisition(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.tiffinRequisition(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet advanceAmountInfo(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.advanceAmountInfo(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet taxHistory(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.taxHistory(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet employeeJobHistory(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.employeeJobHistory(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet incrementSheetPower(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementSheetPower(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet incrementSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet incrementSheetAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementSheetAll(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public DataTable GetIncrementByMultipleYears(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetIncrementByMultipleYears(objReportDTO);
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
        public DataSet AllIncrementSummarySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.AllIncrementSummarySheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlyAdvanceSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyAdvanceSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet monthlyAdvanceEntryInformation(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyAdvanceEntryInformation(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet monthlyAdvanceLedgerInformation(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.monthlyAdvanceLedgerInformation(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet rptEmployeePerformance(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptEmployeePerformance(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet arrearSheetAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.arrearSheetAll(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet salaryHistory(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salaryHistory(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet arrearSlip(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.arrearSlip(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet incrementSlipNormal(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementSlipNormal(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet arrearSlipAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.arrearSlipAll(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet incrementSlipAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementSlipAll(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet arrearSlipHO(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.arrearSlipHO(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet arrearSlipHOFactoryStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.arrearSlipHOFactoryStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet incrementSheetHOSeniorStaffPayslip(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementSheetHOSeniorStaffPayslip(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet factoryStaffArrearSlip(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.factoryStaffArrearSlip(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet factoryStaffIncrementSlip(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.factoryStaffIncrementSlip(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet factoryStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.factoryStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet headOfficeStaf(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.headOfficeStaf(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet arrearSheetHOSeniorStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.arrearSheetHOSeniorStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet arrearSheetHOFactoryStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.arrearSheetHOFactoryStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet arrearSheetNormal(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.arrearSheetNormal(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet incrementProposalHOAboveOneYear(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementProposalHOAboveOneYear(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }






        public DataSet productionReport(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.productionReport(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet pOAssignInformation(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.pOAssignInformation(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet pOEntryInformation(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.pOEntryInformation(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet shipmentInformation(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.shipmentInformation(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet productionReportSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.productionReportSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet productionReportByBuyer(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.productionReportByBuyer(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet dailyProductionReportSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.dailyProductionReportSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet purchaseOrder(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.purchaseOrder(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet MaintenancePartsReceieveSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.MaintenancePartsReceieveSummary(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string processContactSheet(ReportDTO objReportDTO)
        {

            string strMsg = "";
            ReportDAL objReportDAL = new ReportDAL();

            strMsg = objReportDAL.processContactSheet(objReportDTO);

            return strMsg;



        }


        public DataSet MonthlySweingDefectSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.MonthlySweingDefectSummary(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet DailyFinishingDefectSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.DailyFinishingDefectSummery(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string processProductionDetailByBuyer(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";

            strMsg = objReportDAL.processProductionDetailByBuyer(objReportDTO);
            return strMsg;

        }

        public string processProductionDetail(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";

            strMsg = objReportDAL.processProductionDetail(objReportDTO);
            return strMsg;

        }

        public string processProductionSummery(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";

            strMsg = objReportDAL.processProductionSummery(objReportDTO);
            return strMsg;

        }


        public string monthlyProductionSheet(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";

            strMsg = objReportDAL.monthlyProductionSheet(objReportDTO);
            return strMsg;

        }

        public string dailyProductionDetail(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";

            strMsg = objReportDAL.dailyProductionDetail(objReportDTO);
            return strMsg;

        }

        public string ProcessdailyProduction(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";

            strMsg = objReportDAL.ProcessdailyProduction(objReportDTO);
            return strMsg;

        }

        public string processDailyProductionSum(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";

            strMsg = objReportDAL.processDailyProductionSum(objReportDTO);
            return strMsg;

        }

        public DataSet rptProductionSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptProductionSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        //Old
        public DataSet rptProductionSheetByBuyer(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptProductionSheetByBuyer(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet GetProductionSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    if (objReportDTO.PoStatus == "1") //Open
                        ds = objReportDAL.GetProdOfOpenPO(objReportDTO);
                    if (objReportDTO.PoStatus == "2") //Open and Close
                        ds = objReportDAL.GetProdOfOpenClosePO(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet rptProductionSheetByBuyerAndFactory(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptProductionSheetByBuyerAndFactory(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet rptMonthlyProductionSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptMonthlyProductionSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet rptProductionDetailSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptProductionDetailSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet rptMonthlyProductionSheetOnlyFinalized(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptMonthlyProductionSheetOnlyFinalized(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }



        public DataSet rdoProductionSheetByPODetail(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoProductionSheetByPODetail(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet rptMonthlyProductionSheetByPO(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptMonthlyProductionSheetByPO(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet rdoProductionShipmentSheetByPODetail(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoProductionShipmentSheetByPODetail(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet rdoProductionShipmentSheetByBuyerFactory(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rdoProductionShipmentSheetByBuyerFactory(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public List<string> SearchPONo(string strPONo, string strBuyerId)
        {

            List<string> allPONo = new List<string>();

            ReportDAL objReportDAL = new ReportDAL();


            allPONo = objReportDAL.SearchPONo(strPONo, strBuyerId);
            return allPONo;

        }

        public DataTable getBuyerId(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            LookUpDAL objLookUpDAL = new LookUpDAL();


            dt = objLookUpDAL.getBuyerId(strHeadOfficeId, strBranchOfficeId);
            return dt;

        }

        public DataSet dailyShipmentSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.dailyShipmentSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public string ProductionSheetByPODetail(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";

            strMsg = objReportDAL.ProductionSheetByPODetail(objReportDTO);
            return strMsg;

        }



        public string ProductionAndShipmentSheetByBuyer(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";

            strMsg = objReportDAL.ProductionAndShipmentSheetByBuyer(objReportDTO);
            return strMsg;

        }

        public string ProductionAndShipmentSheetUpdate(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";

            strMsg = objReportDAL.ProductionAndShipmentSheetUpdate(objReportDTO);
            return strMsg;

        }

        public string shipmentProcessByPO(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";

            strMsg = objReportDAL.shipmentProcessByPO(objReportDTO);
            return strMsg;

        }


        public DataSet rptPoTrackingShipmentSheetByBill(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.rptPoTrackingShipmentSheetByBill(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ReportDTO checkAdvanceSalary(string strYear, string strMonth, string strHeadOffieId, string strBranchOfficeId)
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportDAL objReportDAL = new ReportDAL();

            objReportDTO = objReportDAL.checkAdvanceSalary(strYear, strMonth, strHeadOffieId, strBranchOfficeId);
            return objReportDTO;

        }

        public DataTable GetTaxCertificate(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetTaxCertificate(objReportDTO);
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

        public DataTable GetSalaryGradeAdjustment_W(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetSalaryGradeAdjustment_W(objReportDTO);
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

        public DataTable SalaryAdjustSummaryAccordingToGazette(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.SalaryAdjustSummaryAccordingToGazette(objReportDTO);
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

        public DataTable GetBankStaffEncashmentSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetBankStaffEncashmentSheet(objReportDTO);
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
        public DataTable GetBankStaffEncashmentReqSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetBankStaffEncashmentReqSheet(objReportDTO);
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

        public DataSet LeaveSheetWorkerDetail(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.leaveSheetWorkerDetail(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //-----
        public DataSet StaffEncashmentDetail(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.StaffEncashmentDetail(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string saveEmployeeInfo(EmployeeDTO objEmployeeDTO, out string EmpId)
        {

            string strMsg = "";

            EmployeeDAL objEmployeeDAL = new EmployeeDAL();

            strMsg = objEmployeeDAL.saveEmployeeInfo(objEmployeeDTO, out EmpId);
            return strMsg;


        }

        public DataTable GetEmployeeDetail(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmployeeDetail(objReportDTO);
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

        public DataSet GetStaffSalaryBankSheetDetail(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetStaffSalaryBankSheetDetail(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetStaffSalarySheetDetailASBank(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetStaffSalarySheetDetailASBank(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string processSalaryRequisitionDetail(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.processSalaryRequisitionDetail(objReportDTO);
            return strMsg;
        }
        public DataSet GetMonthlySalaryRequisitionDetailStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetMonthlySalaryRequisitionDetailStaff(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string GetCurrectDateRanges(ReportDTO objReportDTO)
        {

            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = objReportDAL.GetCurrectDateRanges(objReportDTO);
            return strMsg;
        }

        public DataTable GetIncrementHistory(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetIncrementHistory(objReportDTO);
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

        public DataTable GetEidBonusStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEidBonusStaff(objReportDTO);
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


        public DataTable GetEidBonusRequisitionStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEidBonusRequisitionStaff(objReportDTO);
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

        public DataTable GetEmployeeInfoWithGrossSalary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmployeeInfoWithGrossSalary(objReportDTO);
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
                
        public string GetPreIncrementYear(ReportDTO objReportDTO)
        {
            string preIncrementYear = string.Empty;
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetPreIncrementYear(objReportDTO);
                    preIncrementYear = ds.Tables[0].Rows[0]["pre_increment_year"].ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return preIncrementYear;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet incrementSheetAboveOneYearStaffOnlyQuality(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.incrementSheetAboveOneYearStaffOnlyQuality(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetStaffGrossSalarySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffGrossSalarySheet(objReportDTO);
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
        public DataTable GetTotalfGrossSalarySheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetTotalfGrossSalarySheetStaff(objReportDTO);
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
        //commented on 26.11.2019
        //public DataTable dailyAttendenceSheetForSkillEmp(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {
        //            ReportDAL objReportDAL = new ReportDAL();
        //            dt = objReportDAL.dailyAttendenceSheetForSkillEmp(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataTable DailyAttendenceSheetForEmployeeSkill(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.DailyAttendenceSheetForEmployeeSkill(objReportDTO);
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
        public DataTable GetIncrementProposalWorkerByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetIncrementProposalWorkerByUnitGroup(objReportDTO);
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
        public DataTable GetIncrementWorkerByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetIncrementWorkerByUnitGroup(objReportDTO);
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
        public DataTable GetIncrementProposalStaffByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetIncrementProposalStaffByUnitGroup(objReportDTO);
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
        public DataTable GetWorkerIncrementProposalSheetByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerIncrementProposalSheetByUnitGroup(objReportDTO);
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
        public DataTable GetStaffIncrementProposalSheetByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffIncrementProposalSheetByUnitGroup(objReportDTO);
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

        public DataTable GetStaffAnnualIncrementSheetBySection(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffAnnualIncrementSheetBySection(objReportDTO);
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

        public DataTable GetWorkerStaffRequisitionSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerStaffRequisitionSummary(objReportDTO);
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
        public string MergeSalaryRequisition(ReportDTO objReportDTO)
        {
            ReportDAL objReportDAL = new ReportDAL();
            string strMsg = "";
            strMsg = objReportDAL.MergeSalaryRequisition(objReportDTO);
            return strMsg;
        }

        public DataTable GetWorkerAnnualIncrementSheetBySection(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerAnnualIncrementSheetBySection(objReportDTO);
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
        public DataTable GetWorkerSalaryRequisition(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerSalaryRequisition(objReportDTO);
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
        public DataTable GetStaffSalaryRequisition(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffSalaryRequisition(objReportDTO);
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

        public DataTable GetSpecialIncrementSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetSpecialIncrementSheet(objReportDTO);
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
        public DataTable GetIndividualPaymentInfo(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetIndividualPaymentInfo(objReportDTO);
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
        public DataTable GetStaffWorkerLeaveEncashmentSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffWorkerLeaveEncashmentSummary(objReportDTO);
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
        public DataTable GetWorkerBankSalarySheetByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerBankSalarySheetByUnitGroup(objReportDTO);
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
        public DataTable GetStaffBankSalarySheetByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffBankSalarySheetByUnitGroup(objReportDTO);
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
        public DataTable GetEmpBasicInfoSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmpBasicInfoSheet(objReportDTO);
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
        public DataTable EidBonusWorkerStaffRequisitionSummery(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.EidBonusWorkerStaffRequisitionSummery(objReportDTO);
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
        public DataTable GetWalletSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWalletSheet(objReportDTO);
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

        public DataTable GetWalletSheetUnitID(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWalletSheetUnitID(objReportDTO);
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

        public DataTable GetWalletSheetSectionID(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWalletSheetSectionID(objReportDTO);
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

        public DataTable GetWalletSheetUnitSectionID(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWalletSheetUnitSectionID(objReportDTO);
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
        public DataTable GetWorkerBKashSalaryReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerBKashSalaryReq(objReportDTO);
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
        
        public DataTable GetStaffBKashSalaryReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffBKashSalaryReq(objReportDTO);
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

        public DataTable GetWorkerStaffSalaryReqBKash(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerStaffSalaryReqBKash(objReportDTO);
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

        public DataTable GetWorkerStaffReqSummaryBKash(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerStaffReqSummaryBKash(objReportDTO);
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

        public DataTable GetStaffSalaryRequisitionMisc(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffSalaryRequisitionMisc(objReportDTO);
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

        public DataTable GetStaffMiscReqSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffMiscReqSummary(objReportDTO);
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

        public DataTable GetWorkerCashSalarySheetByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerCashSalarySheetByUnitGroup(objReportDTO);
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
                    
        public DataTable GetWorkerSalaryReqCash(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerSalaryReqCash(objReportDTO);
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
        public DataTable GetSalarySheetStaffAsBank(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetSalarySheetStaffAsBank(objReportDTO);
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
        public DataTable GetBonusSheetStaffAsBKashWallet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetBonusSheetStaffAsBKashWallet(objReportDTO);
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

        public DataTable GetBonusSheetWorkerAsBKashWallet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetBonusSheetWorkerAsBKashWallet(objReportDTO);
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
        public DataSet GetAccountHolderEncashSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetAccountHolderEncashSheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable GetCashStaffEncashmentReqSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetCashStaffEncashmentReqSheet(objReportDTO);
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
        public DataTable GetBonusSheetStaffWorkerAsBKashWallet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetBonusSheetStaffWorkerfAsBKashWallet(objReportDTO);
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

        public DataTable GetBonusBKashWalletTemplatePartAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetBonusBKashWalletTemplatePartAll(objReportDTO);
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


        public DataTable GetEidBonusBKashReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEidBonusBKashReq(objReportDTO);
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
        public DataTable GetEidBonusWorkerCashReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEidBonusWorkerCashReq(objReportDTO);
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

        public DataTable GetEidBonusStaffMiscReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEidBonusStaffMiscReq(objReportDTO);
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

        public DataTable GetEidBonusStaffCashReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEidBonusStaffCashReq(objReportDTO);
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
        public DataTable GetOverTimeSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetOverTimeSheet(objReportDTO);
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
        public DataTable GetOverTimeReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetOverTimeReq(objReportDTO);
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
        public DataTable GetEidBonusDirectorCashReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEidBonusDirectorCashReq(objReportDTO);
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
        public DataSet salarySheetHOTemp(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.salarySheetHOTemp(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable GetLeaveEncashSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetLeaveEncashSheetWorker(objReportDTO);
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

        //public DataTable GetLeaveEncashBKashSheetWorker(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {
        //            ReportDAL objReportDAL = new ReportDAL();
        //            dt = objReportDAL.GetLeaveEncashBKashSheetWorker(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public DataTable GetLeaveEncashBKashReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetLeaveEncashBKashReq(objReportDTO);
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

        public DataTable GetLeaveEncashCashReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetLeaveEncashCashReq(objReportDTO);
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


        public DataTable GetLeaveEncashBKashReqStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetLeaveEncashBKashReqStaff(objReportDTO);
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
        public DataTable GetLeaveEncashMiscReqStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetLeaveEncashMiscReqStaff(objReportDTO);
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

        public DataTable GetLeaveEncashCashReqStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetLeaveEncashCashReqStaff(objReportDTO);
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


        public DataTable GetLeaveEncashSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetLeaveEncashSheetStaff(objReportDTO);
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

        //public DataTable GetLeaveEncashBKashSheetStaff(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {
        //            ReportDAL objReportDAL = new ReportDAL();
        //            dt = objReportDAL.GetLeaveEncashBKashSheetStaff(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public DataTable GetLeaveEncashWorkerAsBKashWallet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetLeaveEncashWorkerAsBKashWallet(objReportDTO);
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
        public DataTable GetLeaveEncashStaffAsBKashWallet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetLeaveEncashStaffAsBKashWallet(objReportDTO);
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
        public DataTable GetEidBonusParcialBkashSheetWorker(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEidBonusParcialBkashSheetWorker(objReportDTO);
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
        public DataTable EidBonusWorkerBkashReqPart(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.EidBonusWorkerBkashReqPart(objReportDTO);
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
        public DataTable GetEidBonusWorkerCashReqPart(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEidBonusWorkerCashReqPart(objReportDTO);
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

        public DataTable GetStaffEidBonusPart(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffEidBonusPart(objReportDTO);
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
        
        public DataTable GetEidBonusStaffCashReqPart(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEidBonusStaffCashReqPart(objReportDTO);
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
        public DataTable SecondBonusSheetStaffPart(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    //dt = objReportDAL.SecondBonusSheetStaffPart(objReportDTO);
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
        
        public DataTable GetEidBonusSummaryByPaymentMode(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEidBonusSummaryByPaymentMode(objReportDTO);
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
        
        public DataTable GetStaffEncashmentSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetStaffEncashmentSummary(objReportDTO);
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
        public DataTable GetWorkerEncashmentSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerEncashmentSummary(objReportDTO);
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
        public DataTable GetLeaveEncashBKashWalletAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetLeaveEncashBKashWalletAll(objReportDTO);
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

        public DataTable GetOverTimeBKashTemplate(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetOverTimeBKashTemplate(objReportDTO);
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

        
        public DataTable GetHalfSalaryNonDFormWalletSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetHalfSalaryNonDFormWalletSheet(objReportDTO);
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
        public DataTable GetHalfSalaryDFormWalletSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetHalfSalaryDFormWalletSheet(objReportDTO);
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


        public DataTable GetDFormWalletSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetDFormWalletSheet(objReportDTO);
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
                
        public DataTable GetDForm5PercentWalletSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetDForm5PercentWalletSheet(objReportDTO);
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

        public DataTable GetNonDFormWalletSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetNonDFormWalletSheet(objReportDTO);
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
               
        public DataTable GetNonDForm5PercentWalletSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetNonDForm5PercentWalletSheet(objReportDTO);
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
        public DataTable GetDformReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetDformReq(objReportDTO);
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

        public DataTable GetHalfSalaryDFormReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetHalfSalaryDFormReq(objReportDTO);
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

        public DataTable GetHalfSalaryNonDFormReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetHalfSalaryNonDFormReq(objReportDTO);
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

        public DataTable GetNonDformReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetNonDformReq(objReportDTO);
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
        public DataTable GetLeaveEncashBKashReqAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetLeaveEncashBKashReqAll(objReportDTO);
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
        public DataTable GetTempSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetTempSheet(objReportDTO);
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
        public DataTable GetWorkerStaffReqSummaryCash(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetWorkerStaffReqSummaryCash(objReportDTO);
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
        public DataTable GetSharePercent(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetSharePercent(objReportDTO);
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
        public DataTable GetDisposableSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetDisposableSheet(objReportDTO);
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
        public DataTable GetDisposableSheetStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetDisposableSheetStaff(objReportDTO);
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

        public DataTable GetHalfSalaryMiscReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetHalfSalaryMiscReq(objReportDTO);
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

        public DataTable GetHalfSalaryReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetHalfSalaryReq(objReportDTO);
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
        public DataTable GetParcialSalarySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetParcialSalarySheet(objReportDTO);
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
        public DataTable GetGenderBasedOnSalary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetGenderBasedOnSalary(objReportDTO);
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
        public DataTable GetEibBonusMasterSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEibBonusMasterSheet(objReportDTO);
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
        public DataTable GetHalfSalaryWalletSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetHalfSalaryWalletSheet(objReportDTO);
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
        public DataTable GetEidBonusCashSummarySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEidBonusCashSummarySheet(objReportDTO);
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
        public DataTable EidBonusStaffMisceSalaryReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.EidBonusStaffMisceSalaryReq(objReportDTO);
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
        public DataTable GetHalfSalaryStaffMisceSalaryReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetHalfSalaryStaffMisceSalaryReq(objReportDTO);
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
        public DataTable GetHalfSalarySummaryByPaymentMode(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetHalfSalarySummaryByPaymentMode(objReportDTO);
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
        public DataTable GetEmpActiveInactiveHistory(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmpActiveInactiveHistory(objReportDTO);
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
        public DataTable GetConfirmationSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetConfirmationSheet(objReportDTO);
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
        public DataTable GetConfirmationSheetWithOutIncrement(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetConfirmationSheetWithOutIncrement(objReportDTO);
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

        //public DataTable GetEmployeeSheetWOPunch(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {
        //            ReportDAL objReportDAL = new ReportDAL();
        //            dt = objReportDAL.GetEmployeeSheetWOPunch(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public DataTable GetEmployeeSheetWOPunchOtherBranch(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {
        //            ReportDAL objReportDAL = new ReportDAL();
        //            dt = objReportDAL.GetEmployeeSheetWOPunchOtherBranch(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public DataTable GetEmployListWithoutOutPunch(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmployListWithoutOutPunch(objReportDTO);
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

        public DataTable GetTiffinBKashReqAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetTiffinBKashReqAll(objReportDTO);
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
        public DataTable GetTiffinCashReqAll(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetTiffinCashReqAll(objReportDTO);
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
        public DataTable GetTiffinBkashSheetByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetTiffinBkashSheetByUnitGroup(objReportDTO);
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
        public DataTable GetTiffinCashSheetByUnitGroup(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetTiffinCashSheetByUnitGroup(objReportDTO);
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
        public DataTable GetTiffinWalletSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetTiffinWalletSheet(objReportDTO);
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

        public DataTable GetTiffinWalletSheetByEType(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetTiffinWalletSheetByEType(objReportDTO);
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

        public DataTable NewEmployeeListJoiningBasis(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.NewEmployeeListJoiningBasis(objReportDTO);
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

        public DataTable GetMonthlyStatement(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetMonthlyStatement(objReportDTO);
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
        public DataTable GetMonthlySalaryMfsTemplate(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetMonthlySalaryMfsTemplate(objReportDTO);
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
        
        public DataTable GetMonthlySalaryMasterBkashTemplateByPhase(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetMonthlySalaryMasterBkashTemplateByPhase(objReportDTO);
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

        
        public DataTable GetMonthlySalaryForwardTemplateByPhase(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetMonthlySalaryForwardTemplateByPhase(objReportDTO);
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
        public DataTable GetMonthlyHoldSalaryBkashTemplateByPhase(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetMonthlyHoldSalaryBkashTemplateByPhase(objReportDTO);
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
        public DataTable GetMonthlyUnholdSalaryBkashTemplateByPhase(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetMonthlyUnholdSalaryBkashTemplateByPhase(objReportDTO);
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

        public DataTable GetMonthlySalaryMfsReq(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetMonthlySalaryMfsReq(objReportDTO);
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
        public DataTable GetMonthlySalaryMasterBkashReqByPhase(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetMonthlySalaryMasterBkashReqByPhase(objReportDTO);
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

        
        public DataTable GetMonthlyHoldSalaryBkashReqByPhase(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetMonthlyHoldSalaryBkashReqByPhase(objReportDTO);
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


        public DataTable GetMonthlyUnholdSalaryBkashReqByPhase(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetMonthlyUnholdSalaryBkashReqByPhase(objReportDTO);
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
        public DataTable GetEmpInfoManualSalary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmpInfoManualSalary(objReportDTO);
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
        public DataTable GetEmpInfoManualSalaryStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmpInfoManualSalaryStaff(objReportDTO);
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

        //new
        public DataTable GetEmployeeCache(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmployeeCache(objReportDTO);
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
        public DataTable GetEmploymentApprovalSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmploymentApprovalSheet(objReportDTO);
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
        public DataTable GetEmploymentNotApprovalSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmploymentNotApprovalSheet(objReportDTO);
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
        public DataTable GetEmployeeCacheForRecognization(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmployeeCacheForRecognization(objReportDTO);
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
        public DataSet IncrementProposalReqSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.IncrementProposalReqSummary(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MfsTemplate GetHoldBkashTemplate(EmployeeDTO objEmployeeDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MfsTemplate objTemplate = new MfsTemplate();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    objTemplate = objReportDAL.GetHoldBkashTemplate(objEmployeeDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return objTemplate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllStaffBankSalarySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    ds = objReportDAL.GetAllStaffBankSalarySheet(objReportDTO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetEmployeeJobHistoryOverall(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmployeeJobHistoryOverall(objReportDTO);
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
        public DataTable GetLeaveEncashReqStaff(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetLeaveEncashReqStaff(objReportDTO);
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
        public DataTable GetHOEidBonusBankAdvice(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetHOEidBonusBankAdvice(objReportDTO);
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
        public DataTable GetEmployeelogDetailSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmployeelogDetailSheet(objReportDTO);
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

        //public DataTable GetActiveEmployeeList(ReportDTO objReportDTO)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        try
        //        {
        //            ReportDAL objReportDAL = new ReportDAL();
        //            dt = objReportDAL.GetEmployeelogDetailSheet(objReportDTO);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
                
        public DataTable GetHOEidBonusMiscReqSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetHOEidBonusMiscReqSummary(objReportDTO);
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
        public DataTable GetSalaryMiscReqSummary(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetSalaryMiscReqSummary(objReportDTO);
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
        public DataTable GetLoginLateSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetLoginLateSheet(objReportDTO);
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
        public DataTable GetDeletedApprovalEmpSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetDeletedApprovalEmpSheet(objReportDTO);
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
        public string PrepareJobCard(ReportDTO objReportDTO)
        {
            string message = string.Empty;               
            ReportDAL objReportDAL = new ReportDAL();
            message = objReportDAL.PrepareJobCard(objReportDTO);    
            return message;
        }

        public DataTable GetJobCard(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetJobCard(objReportDTO);
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

        public DataTable GetJobCardWH(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetJobCardWH(objReportDTO);
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
        public DataTable GetOverTimeAnalyzeBetDateRange(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetOverTimeAnalyzeBetDateRange(objReportDTO);
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
        public DataTable GetMonthlyInactiveProposalSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetMonthlyInactiveProposalSheet(objReportDTO);
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
        public DataTable GetSalaryHistory(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetSalaryHistory(objReportDTO);
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
        public DataTable GetmonthWiseLeaveSummarySheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetmonthWiseLeaveSummarySheet(objReportDTO);
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
        public DataTable GetOverTimeDetailSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetOverTimeDetailSheet(objReportDTO);
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
        public DataTable GetUselessFaceIdSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetUselessFaceIdSheet(objReportDTO);
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
        public DataTable GetNewRecruitmentListBP(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetNewRecruitmentListBP(objReportDTO);
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
        public DataTable GetEmpListBeforeSalarySet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmpListBeforeSalarySet(objReportDTO);
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
        public DataTable GetEmpListBetWHRange(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmpListBetWHRange(objReportDTO);
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
        public DataTable GetDayClosingSheet(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetDayClosingSheet(objReportDTO);
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
        public DataTable GetEmpWhoseWDayLessThanMoreDays(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmpWhoseWDayLessThanMoreDays(objReportDTO);
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
        public DataTable GetPermanentEmployee(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {

                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetPermanentEmployee(objReportDTO);
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
        public DataTable GetEmpWhoseWDayLessThanXDays(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetEmpWhoseWDayLessThanXDays(objReportDTO);
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
        public DataTable GetHOEmployListWithoutOutPunch(ReportDTO objReportDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    ReportDAL objReportDAL = new ReportDAL();
                    dt = objReportDAL.GetHOEmployListWithoutOutPunch(objReportDTO);
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

    }
}
