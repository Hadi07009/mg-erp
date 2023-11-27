using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SINHA.MEDLAR.ERP.DAL;
using SINHA.MEDLAR.ERP.DTO;

using System.Data; 
namespace SINHA.MEDLAR.ERP.BLL
{
 public   class SewingBLL
    {
     public string saveSewingDefectEntryInfo(SewingDTO objSewingDTO)
        {
            string strMsg = "";
            SewingDAL objSewingDAL = new SewingDAL();


            strMsg = objSewingDAL.saveSewingDefectEntryInfo(objSewingDTO);
            return strMsg;


        }

        public string deleteSewingThreadEntry(SewingDTO objSewingDto)
        {
            string strMsg = "";
            SewingDAL objSewingDAL = new SewingDAL();


            strMsg = objSewingDAL.deleteSewingThreadEntry(objSewingDto);
            return strMsg;
        }

        public DataTable GetProgrammeId()
        {
            DataTable dt = new DataTable();

            SewingDAL objSewingDAL = new SewingDAL();

            dt = objSewingDAL.GetProgrammeId();
            return dt;
        }

        public string deleteSewingEntryRecord(SewingDTO objSewingDTO)
        {
            string strMsg = "";
            SewingDAL objSewingDAL = new SewingDAL();


            strMsg = objSewingDAL.deleteSewingEntryRecord(objSewingDTO);
            return strMsg;


        }


        public string saveFinishingDefectEntryInfo(SewingDTO objSewingDTO)
        {
            string strMsg = "";
            SewingDAL objSewingDAL = new SewingDAL();


            strMsg = objSewingDAL.saveFinishingDefectEntryInfo(objSewingDTO);
            return strMsg;


        }

        public string saveSewingThreadOpeningBalance(SewingDTO objSewingDTO)
        {
            string strMsg = "";
            SewingDAL objSewingDAL = new SewingDAL();


            strMsg = objSewingDAL.saveSewingThreadOpeningBalance(objSewingDTO);
            return strMsg;
        }

        public DataTable loadSewingEntryRecord(SewingDTO objSewingDTO)
        {

            SewingDAL objSewingDAL = new SewingDAL();
            DataTable dt = new DataTable();

            dt = objSewingDAL.loadSewingEntryRecord(objSewingDTO);
            return dt;
        }



        public DataTable getLineIdSearch(string strHeadOfficeId, string strBranchOfficeId)
     {

         DataTable dt = new DataTable();
         SewingDAL objSewingDAL = new SewingDAL();


         dt = objSewingDAL.getLineIdSearch(strHeadOfficeId, strBranchOfficeId);
         return dt;

     }

     public DataTable loadSewingDefectEntryInfo( string strHeadOffieId, string strBranchOfficeId)
     {

         SewingDTO objSewingDTO = new SewingDTO();
         SewingDAL objSewingDAL = new SewingDAL();
         DataTable dt = new DataTable();

         dt = objSewingDAL.loadSewingDefectEntryInfo( strHeadOffieId, strBranchOfficeId);
         return dt;

     }

     public DataTable loadFinishingDefectEntryInfo(string strHeadOffieId, string strBranchOfficeId)
     {

         SewingDTO objSewingDTO = new SewingDTO();
         SewingDAL objSewingDAL = new SewingDAL();
         DataTable dt = new DataTable();

         dt = objSewingDAL.loadFinishingDefectEntryInfo(strHeadOffieId, strBranchOfficeId);
         return dt;

     }

     public SewingDTO searchSewingDefectEntry(string strSewingDefectentryId,  string strHeadOffieId, string strBranchOfficeId)
     {

         SewingDTO objSewingDTO = new SewingDTO();
         SewingDAL objSewingDAL = new SewingDAL();


         objSewingDTO = objSewingDAL.searchSewingDefectEntry(strSewingDefectentryId,   strHeadOffieId, strBranchOfficeId);
         return objSewingDTO;

     }

     public SewingDTO searchFinishingDefectEntry(string strFinishingDefectentryId, string strHeadOffieId, string strBranchOfficeId)
     {

         SewingDTO objSewingDTO = new SewingDTO();
         SewingDAL objSewingDAL = new SewingDAL();


         objSewingDTO = objSewingDAL.searchFinishingDefectEntry(strFinishingDefectentryId, strHeadOffieId, strBranchOfficeId);
         return objSewingDTO;

     }

     public DataTable SewingDefectEntrySearch(SewingDTO objSewingDTO)
     {

         SewingDAL objSewingDAL = new SewingDAL();
         DataTable dt = new DataTable();

         dt = objSewingDAL.SewingDefectEntrySearch(objSewingDTO);
         return dt;

     }

     public DataTable FinishingDefectEntrySearch(SewingDTO objSewingDTO)
     {

         SewingDAL objSewingDAL = new SewingDAL();
         DataTable dt = new DataTable();

         dt = objSewingDAL.FinishingDefectEntrySearch(objSewingDTO);
         return dt;

     }

     public string deleteSewingDefectRecord(SewingDTO objSewingDTO)
     {

         SewingDAL objSewingDAL = new SewingDAL();
         string strMsg = objSewingDAL.deleteSewingDefectRecord(objSewingDTO);
         return strMsg;
     }

     public string deleteFinishingDefectRecord(SewingDTO objSewingDTO)
     {

         SewingDAL objSewingDAL = new SewingDAL();
         string strMsg = objSewingDAL.deleteFinishingDefectRecord(objSewingDTO);
         return strMsg;
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



        public DataTable GetProcessId()
        {
            DataTable dt = new DataTable();

            SewingDAL objSewingDAL = new SewingDAL();

            dt = objSewingDAL.GetProcessId();
            return dt;
        }
        public DataTable GetLineId()
        {
            DataTable dt = new DataTable();

            SewingDAL objSewingDAL = new SewingDAL();

            dt = objSewingDAL.GetLineId();
            return dt;
        }
        public DataTable GetUnitId()
        {
            DataTable dt = new DataTable();

            SewingDAL objSewingDAL = new SewingDAL();

            dt = objSewingDAL.GetUnitId();
            return dt;
        }
        public DataTable GetFabricDefectId()
        {
            DataTable dt = new DataTable();

            SewingDAL objSewingDAL = new SewingDAL();

            dt = objSewingDAL.GetFabricDefectId();
            return dt;
        }
        public DataTable GetSewingStitchDefectId()
        {
            DataTable dt = new DataTable();

            SewingDAL objSewingDAL = new SewingDAL();

            dt = objSewingDAL.GetSewingStitchDefectId();
            return dt;
        }
        public DataTable GetAestheticDefectId()
        {
            DataTable dt = new DataTable();

            SewingDAL objSewingDAL = new SewingDAL();

            dt = objSewingDAL.GetAestheticDefectId();
            return dt;
        }
        public DataTable GetDirtyStainId()
        {
            DataTable dt = new DataTable();

            SewingDAL objSewingDAL = new SewingDAL();

            dt = objSewingDAL.GetDirtyStainId();
            return dt;
        }
        public DataTable GetSizeMeasurementDefectId()
        {
            DataTable dt = new DataTable();

            SewingDAL objSewingDAL = new SewingDAL();

            dt = objSewingDAL.GetSizeMeasurementDefectId();
            return dt;
        }

        public DataTable GetMeasurementDiscrepancyId()
        {
            DataTable dt = new DataTable();

            SewingDAL objSewingDAL = new SewingDAL();

            dt = objSewingDAL.GetMeasurementDiscrepancyId();
            return dt;
        }



        public string saveSewingEntry(SewingDTO objSewingDTO)
        {
            string strMsg = "";
            SewingDAL objSewingDAL = new SewingDAL();


            strMsg = objSewingDAL.saveSewingEntry(objSewingDTO);
            return strMsg;
        }

        public DataTable loadSewingEntryRecord(string strSewingDate, string strHeadOfficeId, string strBranchOfficeId)
        {

            SewingDAL objSewingDAL = new SewingDAL();
            DataTable dt = new DataTable();

            dt = objSewingDAL.loadSewingEntryRecord(strSewingDate, strHeadOfficeId, strBranchOfficeId);
            return dt;
        }

        public DataTable loadSewingEntryRecordSub(SewingDTO objSewingDTO)
        {

            SewingDAL objSewingDAL = new SewingDAL();
            DataTable dt = new DataTable();

            dt = objSewingDAL.loadSewingEntryRecordSub(objSewingDTO);
            return dt;
        }


        public SewingDTO searchSewingEntry(string strSewingDate, string strHeadOfficeId, string strBranchOfficeId)
        {
            SewingDTO objSewingDTO = new SewingDTO();
            SewingDAL objSewingDAL = new SewingDAL();
            objSewingDTO = objSewingDAL.searchSewingEntry(strSewingDate, strHeadOfficeId, strBranchOfficeId);
            return objSewingDTO;
        }

        public SewingDTO loadSewingEntryRecordMain(string strSewingDate, string strHeadOfficeId, string strBranchOfficeId)
        {
            SewingDTO objSewingDTO = new SewingDTO();
            SewingDAL objSewingDAL = new SewingDAL();
            objSewingDTO = objSewingDAL.loadSewingEntryRecordMain(strSewingDate, strHeadOfficeId, strBranchOfficeId);
            return objSewingDTO;
        }


        public string deleteSewingEntry(SewingDTO objSewingDto)
        {
            string strMsg = "";
            SewingDAL objSewingDAL = new SewingDAL();


            strMsg = objSewingDAL.deleteSewingEntry(objSewingDto);
            return strMsg;
        }

        public SewingDTO searchSewingThreadEntry(string srtSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOfficeId)
        {
            SewingDTO objSewingDTO = new SewingDTO();
            SewingDAL objSewingDAL = new SewingDAL();
            objSewingDTO = objSewingDAL.searchSewingThreadEntry(srtSupplierId, strProgrammeId, strHeadOfficeId, strBranchOfficeId);
            return objSewingDTO;
        }





      

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         