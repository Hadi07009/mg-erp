using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
   public class SewingDTO
   {
       private string strSewingDefectEntryId;
       private string strLineId;
       private string strDefectDate; //
       private string strShading; ///
       private string strDamageHole; ///
       private string strFabricDefect; ///
       private string strOpenInsecureStitch; //
       private string strBrokenStitch; //
       private string strSkipStitch; //
       private string strMissing; //
       private string strUnevenEdgeMarginWidth; //
       private string strJoinStitchPoorRepier; //
       private string strOverDownStitchr; //
       private string strTensionTightLoose; //
       private string strPleat; //
       private string strCaughtbySeam; //
       private string strAttachedByBartack; //
       private string strRawedgeFraying; //
       private string strExcessLessInlay; //
       private string strPoorShape; //
       private string strPuckringLooseness; //
       private string strRopingWavy; //
       private string strSlanted; //
       private string strHighKing; //
       private string strPanelHiLowUpdown; //
       private string strPanelReverse; //
       private string strProjection; //
       private string strUnmatchPairUnbalance;//
       private string strOilMark; //
       private string strSpotDirty; //
       private string strMissMisPlace; //
       private string strPoMainSiZeLblMistake;//
       private string strChestWaist;//
       private string strFbackLengthThigh; //
       private string strSlvLengthInseam; //
       private string strSweepHip;
       private string strUpdateBy;
       private string strHeadOfficeId;
       private string strBranchOfficeId;
       private string strTotalCheckQuantity;
       private string strHourNO;

       private string strSewingDefectFromDate;
       private string strSewingDefectToDate;
       private string strProductionQuantity;
       private string strBtnHoleDefect;


        private string strSewingYear;
        private string strSewingMonth;
        private string strSewingDate;
        private string strSewingProcessId;
        private string strSewingLineId;
        private string strSewingUnitId;
        private string strSewingNumOfAudit;
        private string strSewingNumOfPassAudit;
        private string strSewingTotalCheckQuality;
        private string strSewingFabricDefectId;
        private string strSewingEntyStitchDefectId;
        private string strSewingAestheticDefectId;
        private string strSewingDirtyStainId;
        private string strSewingSizeMeasurementDefectId;
        private string strSewingMeasurementDiscrepancyId;
        private string strSewingUpdateDate;



        private string strFinishingDefectEntryId;
       
        private string strNumberOfSewingStitchDefect;
        private string strNumberOfAestheticDefect;
        private string strNumberOfStainDefect;
        private string strNumberOfSizeDefect;
        private string strNumberOfDiscrepancyDefect;
        private string strTotalHours;
        private string strSewingTranId;

        private string strSewingSupplierId;
        private string strSewingProgrammeId;
        private string strThreadCount;
        private string strBalanceQty;
        private string strSewingThreadId;
        private string strArtNo;
        private string strTranId;
        private string strArtId;
        private string strQuantity;
        private string strRate;
        private string strCurrencyId;


        public string CurrencyId
        {
            get { return strCurrencyId; }
            set { strCurrencyId = value; }
        }
        public string Rate
        {
            get { return strRate; }
            set { strRate = value; }
        }


        public string Quantity
        {
            get { return strQuantity; }
            set { strQuantity = value; }
        }
        public string ArtId
        {
            get { return strArtId; }
            set { strArtId = value; }
        }

        public string TranId
        {
            get { return strTranId; }
            set { strTranId = value; }
        }
        public string ArtNo
        {
            get { return strArtNo; }
            set { strArtNo = value; }
        }
        public string SewingThreadId
        {
            get { return strSewingThreadId; }
            set { strSewingThreadId = value; }
        }

        public string BalanceQty
        {
            get { return strBalanceQty; }
            set { strBalanceQty = value; }
        }
        public string ThreadCount
        {
            get { return strThreadCount; }
            set { strThreadCount = value; }
        }
        public string SewingProgrammeId
        {
            get { return strSewingProgrammeId; }
            set { strSewingProgrammeId = value; }
        }

        public string SewingSupplierId
        {
            get { return strSewingSupplierId; }
            set { strSewingSupplierId = value; }
        }

        public string SewingTranId
        {
            get { return strSewingTranId; }
            set { strSewingTranId = value; }
        }
        public string TotalHours
        {
            get { return strTotalHours; }
            set { strTotalHours = value; }
        }

        public string NumberOfDiscrepancyDefect
        {
            get { return strNumberOfDiscrepancyDefect; }
            set { strNumberOfDiscrepancyDefect = value; }
        }
        public string NumberOfSizeDefect
        {
            get { return strNumberOfSizeDefect; }
            set { strNumberOfSizeDefect = value; }
        }
        public string NumberOfStainDefect
        {
            get { return strNumberOfStainDefect; }
            set { strNumberOfStainDefect = value; }
        }
        public string NumberOfAestheticDefect
        {
            get { return strNumberOfAestheticDefect; }
            set { strNumberOfAestheticDefect = value; }
        }
        public string NumberOfSewingStitchDefect
        {
            get { return strNumberOfSewingStitchDefect; }
            set { strNumberOfSewingStitchDefect = value; }
        }
        public string NumberOfFabricDefect
        {
            get { return strFinishingDefectEntryId; }
            set { strFinishingDefectEntryId = value; }
        }
        public string SewingYear
        {
            get { return strSewingYear; }
            set { strSewingYear = value; }
        }
        public string SewingMonth
        {
            get { return strSewingMonth; }
            set { strSewingMonth = value; }
        }
        public string SewingDate
        {
            get { return strSewingDate; }
            set { strSewingDate = value; }
        }
        public string SewingProcessId
        {
            get { return strSewingProcessId; }
            set { strSewingProcessId = value; }
        }
        public string SewingLineId
        {
            get { return strSewingLineId; }
            set { strSewingLineId = value; }
        }
        public string SewingUnitId
        {
            get { return strSewingUnitId; }
            set { strSewingUnitId = value; }
        }
        public string SewingNumOfAudit
        {
            get { return strSewingNumOfAudit; }
            set { strSewingNumOfAudit = value; }
        }
        public string SewingNumOfPassAudit
        {
            get { return strSewingNumOfPassAudit; }
            set { strSewingNumOfPassAudit = value; }
        }
        public string SewingTotalCheckQuality
        {
            get { return strSewingTotalCheckQuality; }
            set { strSewingTotalCheckQuality = value; }
        }
        public string SewingFabricDefectId
        {
            get { return strSewingFabricDefectId; }
            set { strSewingFabricDefectId = value; }
        }
        public string SewingEntyStitchDefectId
        {
            get { return strSewingEntyStitchDefectId; }
            set { strSewingEntyStitchDefectId = value; }
        }
        public string SewingDirtyStainId
        {
            get { return strSewingDirtyStainId; }
            set { strSewingDirtyStainId = value; }
        }
        public string SewingAestheticDefectId
        {
            get { return strSewingAestheticDefectId; }
            set { strSewingAestheticDefectId = value; }
        }
        public string SewingSizeMeasurementDefectId
        {
            get { return strSewingSizeMeasurementDefectId; }
            set { strSewingSizeMeasurementDefectId = value; }
        }
        public string SewingMeasurementDiscrepancyId
        {
            get { return strSewingMeasurementDiscrepancyId; }
            set { strSewingMeasurementDiscrepancyId = value; }
        }
        public string SewingUpdateDate
        {
            get { return strSewingUpdateDate; }
            set { strSewingUpdateDate = value; }
        }



        public string FinishingDefectEntryId
       {
           get { return strFinishingDefectEntryId; }
           set { strFinishingDefectEntryId = value; }
       }

       public string BtnHoleDefect
       {
           get { return strBtnHoleDefect; }
           set { strBtnHoleDefect = value; }
       }

       public string ProductionQuantity
       {
           get { return strProductionQuantity; }
           set { strProductionQuantity = value; }
       }

       public string SewingDefectFromDate
       {
           get { return strTotalCheckQuantity; }
           set { strTotalCheckQuantity = value; }
       }

       public string HourNO
       {
           get { return strHourNO; }
           set { strHourNO = value; }
       }

       public string SewingDefectToDate
       {
           get { return strSewingDefectToDate; }
           set { strSewingDefectToDate = value; }
       }
       public string TotalCheckQuantity
       {
           get { return strTotalCheckQuantity; }
           set { strTotalCheckQuantity = value; }
       }
       public string UpdateBy
       {
           get { return strUpdateBy; }
           set { strUpdateBy = value; }
       }
       public string HeadOfficeId
       {
           get { return strHeadOfficeId; }
           set { strHeadOfficeId = value; }
       }

       public string BranchOfficeId
       {
           get { return strBranchOfficeId; }
           set { strBranchOfficeId = value; }
       }
       public string SewingDefectEntryId
       {
           get { return strSewingDefectEntryId; }
           set { strSewingDefectEntryId = value; }
       }

       public string LineId
       {
           get { return strLineId; }
           set { strLineId = value; }
       }
       public string DefectDate
       {
           get { return strDefectDate; }
           set { strDefectDate = value; }
       }
       public string Shading
       {
           get { return strShading; }
           set { strShading = value; }
       }

       public string DamageHole
       {
           get { return strDamageHole; }
           set { strDamageHole = value; }
       }

       public string FabricDefect
       {
           get { return strFabricDefect; }
           set { strFabricDefect = value; }
       }

       public string OpenInsecureStitch
       {
           get { return strOpenInsecureStitch; }
           set { strOpenInsecureStitch = value; }
       }

       public string BrokenStitch
       {
           get { return strBrokenStitch; }
           set { strBrokenStitch = value; }
       }

       public string SkipStitch
       {
           get { return strSkipStitch; }
           set { strSkipStitch = value; }
       }

       public string Missing
       {
           get { return strMissing; }
           set { strMissing = value; }
       }

       public string UnevenEdgeMarginWidth
       {
           get { return strUnevenEdgeMarginWidth; }
           set { strUnevenEdgeMarginWidth = value; }
       }

       public string JoinStitchPoorRepier
       {
           get { return strJoinStitchPoorRepier; }
           set { strJoinStitchPoorRepier = value; }
       }

       public string OverDownStitchr
       {
           get { return strOverDownStitchr; }
           set { strOverDownStitchr = value; }
       }

       public string TensionTightLoose
       {
           get { return strTensionTightLoose; }
           set { strTensionTightLoose = value; }
       }

       public string Pleat
       {
           get { return strPleat; }
           set { strPleat = value; }
       }

       public string CaughtbySeam
       {
           get { return strCaughtbySeam; }
           set { strCaughtbySeam = value; }
       }

       public string AttachedByBartack
       {
           get { return strAttachedByBartack; }
           set { strAttachedByBartack = value; }
       }

       public string RawedgeFraying
       {
           get { return strRawedgeFraying; }
           set { strRawedgeFraying = value; }
       }

       public string ExcessLessInlay
       {
           get { return strExcessLessInlay; }
           set { strExcessLessInlay = value; }
       }

       public string PoorShape
       {
           get { return strPoorShape; }
           set { strPoorShape = value; }
       }

       public string PuckringLooseness
       {
           get { return strPuckringLooseness; }
           set { strPuckringLooseness = value; }
       }

       public string RopingWavy
       {
           get { return strRopingWavy; }
           set { strRopingWavy = value; }
       }

       public string Slanted
       {
           get { return strSlanted; }
           set { strSlanted = value; }
       }

       public string HighKing
       {
           get { return strHighKing; }
           set { strHighKing = value; }
       }

       public string PanelHiLowUpdown
       {
           get { return strPanelHiLowUpdown; }
           set { strPanelHiLowUpdown = value; }
       }

       public string PanelReverse
       {
           get { return strPanelReverse; }
           set { strPanelReverse = value; }
       }

       public string Projection
       {
           get { return strProjection; }
           set { strProjection = value; }
       }

       public string UnmatchPairUnbalance
       {
           get { return strUnmatchPairUnbalance; }
           set { strUnmatchPairUnbalance = value; }
       }

       public string OilMark
       {
           get { return strOilMark; }
           set { strOilMark = value; }
       }

       public string SpotDirty
       {
           get { return strSpotDirty; }
           set { strSpotDirty = value; }
       }

       public string MissMisPlace
       {
           get { return strMissMisPlace; }
           set { strMissMisPlace = value; }
       }

       public string PoMainSiZeLblMistake
       {
           get { return strPoMainSiZeLblMistake; }
           set { strPoMainSiZeLblMistake = value; }
       }

       public string ChestWaist
       {
           get { return strChestWaist; }
           set { strChestWaist = value; }
       }

       public string FbackLengthThigh
       {
           get { return strFbackLengthThigh; }
           set { strFbackLengthThigh = value; }
       }

       public string SlvLengthInseam
       {
           get { return strSlvLengthInseam; }
           set { strSlvLengthInseam = value; }
       }
       public string SweepHip
       {
           get { return strSweepHip; }
           set { strSweepHip = value; }
       }
    }
}
