using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

namespace SINHA.MEDLAR.ERP.BLL
{
   public class GazetteBLL
    {
        public string AnalyzeIncrementPlusGazetteAdjustment(GazetteDTO objGazetteDTO)
        {
            GazetteDAL objGazetteDAL = new GazetteDAL();
            string strMsg = objGazetteDAL.AnalyzeIncrementPlusGazetteAdjustment(objGazetteDTO);
            return strMsg;
        }
        public string AnalyzeIncrementPlusGazetteAdjustmentForSingleEmp(GazetteDTO objGazetteDTO)
        {
            GazetteDAL objGazetteDAL = new GazetteDAL();
            string strMsg = objGazetteDAL.AnalyzeIncrementPlusGazetteAdjustmentForSingleEmp(objGazetteDTO);
            return strMsg;
        }
        public DataTable GetIncrementPlusGazetAdjSheet(GazetteDTO objGazetteDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    GazetteDAL objGazetteDAL = new GazetteDAL();
                    dt = objGazetteDAL.GetIncrementPlusGazetAdjSheet(objGazetteDTO);
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
        public DataTable GetIncrementPlusGazetAdjForSingleEmpSheet(GazetteDTO objGazetteDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    GazetteDAL objGazetteDAL = new GazetteDAL();
                    dt = objGazetteDAL.GetIncrementPlusGazetAdjForSingleEmpSheet(objGazetteDTO);
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

        public DataTable GetIncrementPlusGazetAdjRequisition(GazetteDTO objGazetteDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    GazetteDAL objGazetteDAL = new GazetteDAL();
                    dt = objGazetteDAL.GetIncrementPlusGazetAdjRequisition(objGazetteDTO);
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

        public DataTable GetIncrementPlusGazetAdjSummary(GazetteDTO objGazetteDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    GazetteDAL objGazetteDAL = new GazetteDAL();
                    dt = objGazetteDAL.GetIncrementPlusGazetAdjSummary(objGazetteDTO);
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
        public string ProcessIncrementPlusGazetteAdjustment(GazetteDTO objGazetteDTO)
        {
            GazetteDAL objGazetteDAL = new GazetteDAL();
            string strMsg = objGazetteDAL.ProcessIncrementPlusGazetteAdjustment(objGazetteDTO);
            return strMsg;
        }
        public string ProcessIncrementPlusGazetteAdjustmentForSingleEmp(GazetteDTO objGazetteDTO)
        {
            GazetteDAL objGazetteDAL = new GazetteDAL();
            string strMsg = objGazetteDAL.ProcessIncrementPlusGazetteAdjustmentForSingleEmp(objGazetteDTO);
            return strMsg;
        }

        public string SaveGazetteSetup(GazetteDTO objGazetteDTO)
        {
            GazetteDAL objGazetteDAL = new GazetteDAL();
            string strMsg = objGazetteDAL.SaveGazetteSetup(objGazetteDTO);
            return strMsg;
        }
        public DataTable LoadGazetteSetup(string strYear, string strMonth, string strHeadOffieId, string strBranchOffieId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            GazetteDAL objGazetteDAL = new GazetteDAL();
            DataTable dt = new DataTable();

            dt = objGazetteDAL.LoadGazetteSetup(strYear, strMonth, strHeadOffieId, strBranchOffieId);
            return dt;

        }

        public string SaveSalaryGazetteMapping(GazetteDTO objGazetteDTO)
        {
            GazetteDAL objGazetteDAL = new GazetteDAL();
            string strMsg = objGazetteDAL.SaveSalaryGazetteMapping(objGazetteDTO);
            return strMsg;
        }
        public DataTable LoadSalaryGazetteMapping()
        {
            GazetteDAL objGazetteDAL = new GazetteDAL();
            DataTable dt = new DataTable();
            dt = objGazetteDAL.LoadSalaryGazetteMapping();
            return dt;
        }

        public DataTable GetGazetteYear()
        {

            DataTable dt = new DataTable();
            GazetteDAL objGazetteDAL = new GazetteDAL();
            dt = objGazetteDAL.GetGazetteYear();
            return dt;

        }

        public string ProcessWorkerExtendedSalary(GazetteDTO objGazetteDTO)
        {
            GazetteDAL objGazetteDAL = new GazetteDAL();
            string strMsg = objGazetteDAL.ProcessWorkerExtendedSalary(objGazetteDTO);
            return strMsg;
        }

        public string ProcessIncrementArrearAdj(GazetteDTO objGazetteDTO)
        {
            GazetteDAL objGazetteDAL = new GazetteDAL();
            string strMsg = objGazetteDAL.ProcessIncrementArrearAdj(objGazetteDTO);
            return strMsg;
        }
        
        public DataTable GetIncrementPlusReGazetAdjSheet(GazetteDTO objGazetteDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    GazetteDAL objGazetteDAL = new GazetteDAL();
                    dt = objGazetteDAL.GetIncrementPlusReGazetAdjSheet(objGazetteDTO);
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

        public DataTable GetIncrementDetailSheet(GazetteDTO objGazetteDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    GazetteDAL objGazetteDAL = new GazetteDAL();
                    dt = objGazetteDAL.GetIncrementDetailSheet(objGazetteDTO);
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
        public DataTable GetPeriodicIncrementHistorySummary(GazetteDTO objGazetteDTO)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                try
                {
                    GazetteDAL objGazetteDAL = new GazetteDAL();
                    dt = objGazetteDAL.GetPeriodicIncrementHistorySummary(objGazetteDTO);
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
