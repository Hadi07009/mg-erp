using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
using SINHA.MEDLAR.ERP.DTO;

namespace SINHA.MEDLAR.ERP.DAL
{
    public class SewingDAL
    {
        OracleTransaction trans = null;


        #region "Oracle Connection Function"

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        #endregion


        public string saveSewingDefectEntryInfo(SewingDTO objSewingDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_sewing_alter_entry");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objSewingDTO.SewingDefectEntryId != "")
            {

                objOracleCommand.Parameters.Add("P_SEWING_DEFECT_ENTRY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingDefectEntryId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SEWING_DEFECT_ENTRY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objSewingDTO.DefectDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_DEFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.DefectDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DEFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.LineId != "")
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.LineId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objSewingDTO.TotalCheckQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_TOTAL_CHECK_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.TotalCheckQuantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TOTAL_CHECK_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingDTO.HourNO != "")
            {

                objOracleCommand.Parameters.Add("P_HOUR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.HourNO;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_HOUR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objSewingDTO.ProductionQuantity != "")
            {

                objOracleCommand.Parameters.Add("PRODUCTION_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.ProductionQuantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("PRODUCTION_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.Shading != "")
            {

                objOracleCommand.Parameters.Add("P_SHADING", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.Shading;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SHADING", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingDTO.DamageHole != "")
            {

                objOracleCommand.Parameters.Add("P_DAMAGE_HOLE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.DamageHole;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DAMAGE_HOLE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objSewingDTO.FabricDefect != "")
            {

                objOracleCommand.Parameters.Add("P_FABRIC_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.FabricDefect;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.OpenInsecureStitch != "")
            {

                objOracleCommand.Parameters.Add("P_OPEN_INSECURE_STITCH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.OpenInsecureStitch;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_OPEN_INSECURE_STITCH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingDTO.BrokenStitch != "")
            {

                objOracleCommand.Parameters.Add("P_BROKEN_STITCH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.BrokenStitch;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BROKEN_STITCH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.SkipStitch != "")
            {

                objOracleCommand.Parameters.Add("P_SKIP_STITCH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SkipStitch;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SKIP_STITCH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.Missing != "")
            {

                objOracleCommand.Parameters.Add("P_MISSING", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.Missing;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MISSING", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.UnevenEdgeMarginWidth != "")
            {

                objOracleCommand.Parameters.Add("P_UNEVEN_EDGE_MARGIN_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.UnevenEdgeMarginWidth;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNEVEN_EDGE_MARGIN_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.JoinStitchPoorRepier != "")
            {

                objOracleCommand.Parameters.Add("P_JOIN_STITCH_POOR_REPIER", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.JoinStitchPoorRepier;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_JOIN_STITCH_POOR_REPIER", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.OverDownStitchr != "")
            {

                objOracleCommand.Parameters.Add("P_OVER_DOWN_STITCH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.OverDownStitchr;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_OVER_DOWN_STITCH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.TensionTightLoose != "")
            {

                objOracleCommand.Parameters.Add("P_TENSION_TIGHT_LOOSE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.TensionTightLoose;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TENSION_TIGHT_LOOSE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.Pleat != "")
            {

                objOracleCommand.Parameters.Add("P_PLEAT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.Pleat;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PLEAT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.CaughtbySeam != "")
            {

                objOracleCommand.Parameters.Add("P_CAUGHT_BY_SEAM", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.CaughtbySeam;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CAUGHT_BY_SEAM", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.AttachedByBartack != "")
            {

                objOracleCommand.Parameters.Add("P_ATTACHED_BY_BARTACK", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.AttachedByBartack;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ATTACHED_BY_BARTACK", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.RawedgeFraying != "")
            {

                objOracleCommand.Parameters.Add("P_RAWEDGE_FRAYING", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.RawedgeFraying;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RAWEDGE_FRAYING", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.ExcessLessInlay != "")
            {

                objOracleCommand.Parameters.Add("P_EXCESS_LESS_INLAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.ExcessLessInlay;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_EXCESS_LESS_INLAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.PoorShape != "")
            {

                objOracleCommand.Parameters.Add("P_POOR_SHAPE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.PoorShape;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_POOR_SHAPE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.PuckringLooseness != "")
            {

                objOracleCommand.Parameters.Add("P_PUCKRING_LOOSENESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.PuckringLooseness;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PUCKRING_LOOSENESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingDTO.RopingWavy != "")
            {

                objOracleCommand.Parameters.Add("P_ROPING_WAVY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.RopingWavy;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ROPING_WAVY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.Slanted != "")
            {

                objOracleCommand.Parameters.Add("P_SLANTED", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.Slanted;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SLANTED", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.HighKing != "")
            {

                objOracleCommand.Parameters.Add("P_HIGH_KING", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.HighKing;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_HIGH_KING", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.PanelHiLowUpdown != "")
            {

                objOracleCommand.Parameters.Add("P_PANEL_HI_LOW_UPDOWN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.PanelHiLowUpdown;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PANEL_HI_LOW_UPDOWN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.PanelReverse != "")
            {

                objOracleCommand.Parameters.Add("P_PANEL_REVERSE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.PanelReverse;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PANEL_REVERSE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.Projection != "")
            {

                objOracleCommand.Parameters.Add("P_PROJECTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.Projection;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROJECTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.UnmatchPairUnbalance != "")
            {

                objOracleCommand.Parameters.Add("P_UNMATCH_PAIR_UNBALANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.UnmatchPairUnbalance;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNMATCH_PAIR_UNBALANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.OilMark != "")
            {

                objOracleCommand.Parameters.Add("P_OIL_MARK", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.OilMark;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_OIL_MARK", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.SpotDirty != "")
            {

                objOracleCommand.Parameters.Add("P_SPOT_DIRTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SpotDirty;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SPOT_DIRTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.MissMisPlace != "")
            {

                objOracleCommand.Parameters.Add("P_MISS_MISPLACE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.MissMisPlace;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MISS_MISPLACE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.PoMainSiZeLblMistake != "")
            {

                objOracleCommand.Parameters.Add("P_PO_MAIN_SIZE_LBL_MISTAKE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.PoMainSiZeLblMistake;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_MAIN_SIZE_LBL_MISTAKE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.ChestWaist != "")
            {

                objOracleCommand.Parameters.Add("P_CHEST_WAIST", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.ChestWaist;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CHEST_WAIST", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.FbackLengthThigh != "")
            {

                objOracleCommand.Parameters.Add("P_F_BACK_LENGTH_THIGH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.FbackLengthThigh;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_F_BACK_LENGTH_THIGH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.SlvLengthInseam != "")
            {

                objOracleCommand.Parameters.Add("P_SLV_LENGTH_INSEAM", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SlvLengthInseam;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SLV_LENGTH_INSEAM", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.SweepHip != "")
            {

                objOracleCommand.Parameters.Add("P_SWEEP_HIP", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SweepHip;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SWEEP_HIP", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();

                }

            }



            return strMsg;
        }
        public string deleteSewingEntryRecord(SewingDTO objSewingDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_delete_sewing_entry");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

          
           
            objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingTranId;
            objOracleCommand.Parameters.Add("P_SEWING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingDate;
          


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();

                }

            }



            return strMsg;
        }
        public string saveFinishingDefectEntryInfo(SewingDTO objSewingDTO)
        {


            string strMsg = "";
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_finishiog_alter_entry");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objSewingDTO.FinishingDefectEntryId != "")
            {

                objOracleCommand.Parameters.Add("P_FINISHING_DEFECT_ENTRY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.FinishingDefectEntryId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FINISHING_DEFECT_ENTRY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objSewingDTO.DefectDate.Length > 6)
            {

                objOracleCommand.Parameters.Add("P_DEFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.DefectDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DEFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.LineId != "")
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.LineId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objSewingDTO.TotalCheckQuantity != "")
            {

                objOracleCommand.Parameters.Add("P_TOTAL_CHECK_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.TotalCheckQuantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TOTAL_CHECK_QTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingDTO.HourNO != "")
            {

                objOracleCommand.Parameters.Add("P_HOUR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.HourNO;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_HOUR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }
            if (objSewingDTO.ProductionQuantity != "")
            {

                objOracleCommand.Parameters.Add("PRODUCTION_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.ProductionQuantity;
            }
            else
            {

                objOracleCommand.Parameters.Add("PRODUCTION_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.Shading != "")
            {

                objOracleCommand.Parameters.Add("P_SHADING", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.Shading;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SHADING", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingDTO.DamageHole != "")
            {

                objOracleCommand.Parameters.Add("P_DAMAGE_HOLE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.DamageHole;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DAMAGE_HOLE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }



            if (objSewingDTO.FabricDefect != "")
            {

                objOracleCommand.Parameters.Add("P_FABRIC_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.FabricDefect;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.BtnHoleDefect != "")
            {

                objOracleCommand.Parameters.Add("P_BTN_HOLE_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.BtnHoleDefect;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BTN_HOLE_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingDTO.BrokenStitch != "")
            {

                objOracleCommand.Parameters.Add("P_BROKEN_STITCH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.BrokenStitch;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BROKEN_STITCH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.SkipStitch != "")
            {

                objOracleCommand.Parameters.Add("P_SKIP_STITCH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SkipStitch;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SKIP_STITCH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.Missing != "")
            {

                objOracleCommand.Parameters.Add("P_MISSING", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.Missing;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MISSING", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.UnevenEdgeMarginWidth != "")
            {

                objOracleCommand.Parameters.Add("P_UNEVEN_EDGE_MARGIN_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.UnevenEdgeMarginWidth;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNEVEN_EDGE_MARGIN_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.JoinStitchPoorRepier != "")
            {

                objOracleCommand.Parameters.Add("P_JOIN_STITCH_POOR_REPIER", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.JoinStitchPoorRepier;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_JOIN_STITCH_POOR_REPIER", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.OverDownStitchr != "")
            {

                objOracleCommand.Parameters.Add("P_OVER_DOWN_STITCH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.OverDownStitchr;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_OVER_DOWN_STITCH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.TensionTightLoose != "")
            {

                objOracleCommand.Parameters.Add("P_TENSION_TIGHT_LOOSE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.TensionTightLoose;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TENSION_TIGHT_LOOSE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.Pleat != "")
            {

                objOracleCommand.Parameters.Add("P_PLEAT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.Pleat;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PLEAT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.CaughtbySeam != "")
            {

                objOracleCommand.Parameters.Add("P_CAUGHT_BY_SEAM", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.CaughtbySeam;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CAUGHT_BY_SEAM", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.AttachedByBartack != "")
            {

                objOracleCommand.Parameters.Add("P_ATTACHED_BY_BARTACK", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.AttachedByBartack;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ATTACHED_BY_BARTACK", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.RawedgeFraying != "")
            {

                objOracleCommand.Parameters.Add("P_RAWEDGE_FRAYING", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.RawedgeFraying;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_RAWEDGE_FRAYING", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.ExcessLessInlay != "")
            {

                objOracleCommand.Parameters.Add("P_EXCESS_LESS_INLAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.ExcessLessInlay;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_EXCESS_LESS_INLAY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.PoorShape != "")
            {

                objOracleCommand.Parameters.Add("P_POOR_SHAPE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.PoorShape;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_POOR_SHAPE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.PuckringLooseness != "")
            {

                objOracleCommand.Parameters.Add("P_PUCKRING_LOOSENESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.PuckringLooseness;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PUCKRING_LOOSENESS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objSewingDTO.RopingWavy != "")
            {

                objOracleCommand.Parameters.Add("P_ROPING_WAVY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.RopingWavy;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ROPING_WAVY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.Slanted != "")
            {

                objOracleCommand.Parameters.Add("P_SLANTED", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.Slanted;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SLANTED", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.HighKing != "")
            {

                objOracleCommand.Parameters.Add("P_HIGH_KING", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.HighKing;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_HIGH_KING", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.PanelHiLowUpdown != "")
            {

                objOracleCommand.Parameters.Add("P_PANEL_HI_LOW_UPDOWN", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.PanelHiLowUpdown;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PANEL_HI_LOW_UPDOWN", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.PanelReverse != "")
            {

                objOracleCommand.Parameters.Add("P_PANEL_REVERSE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.PanelReverse;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PANEL_REVERSE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.Projection != "")
            {

                objOracleCommand.Parameters.Add("P_PROJECTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.Projection;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROJECTION", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.UnmatchPairUnbalance != "")
            {

                objOracleCommand.Parameters.Add("P_UNMATCH_PAIR_UNBALANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.UnmatchPairUnbalance;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNMATCH_PAIR_UNBALANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.OilMark != "")
            {

                objOracleCommand.Parameters.Add("P_OIL_MARK", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.OilMark;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_OIL_MARK", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.SpotDirty != "")
            {

                objOracleCommand.Parameters.Add("P_SPOT_DIRTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SpotDirty;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SPOT_DIRTY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.MissMisPlace != "")
            {

                objOracleCommand.Parameters.Add("P_MISS_MISPLACE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.MissMisPlace;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MISS_MISPLACE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.PoMainSiZeLblMistake != "")
            {

                objOracleCommand.Parameters.Add("P_PO_MAIN_SIZE_LBL_MISTAKE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.PoMainSiZeLblMistake;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_MAIN_SIZE_LBL_MISTAKE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.ChestWaist != "")
            {

                objOracleCommand.Parameters.Add("P_CHEST_WAIST", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.ChestWaist;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CHEST_WAIST", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.FbackLengthThigh != "")
            {

                objOracleCommand.Parameters.Add("P_F_BACK_LENGTH_THIGH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.FbackLengthThigh;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_F_BACK_LENGTH_THIGH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.SlvLengthInseam != "")
            {

                objOracleCommand.Parameters.Add("P_SLV_LENGTH_INSEAM", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SlvLengthInseam;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SLV_LENGTH_INSEAM", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objSewingDTO.SweepHip != "")
            {

                objOracleCommand.Parameters.Add("P_SWEEP_HIP", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SweepHip;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SWEEP_HIP", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 1000).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();

                }

            }



            return strMsg;
        }
        public DataTable loadSewingDefectEntryInfo( string strHeadOffieId, string strBranchOfficeId)
        {

            SewingDTO objSewingDTO = new SewingDTO();
            SewingDAL objSewingDAL = new SewingDAL();

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +
                
                 "SEWING_DEFECT_ENTRY_ID, " +
                 "LINE_NAME," +
                "TO_CHAR(DEFECT_DATE,'dd/mm/yyyy')DEFECT_DATE," +
                "HOUR_NO,"+
                 "TOTAL_CHECK_QTY," +
                 "PRODUCTION_QUANTITY"+
                 " FROM VEW_SEARCH_SEWING_ALTER  WHERE   head_office_id = '" + strHeadOffieId + "' and branch_office_id ='" + strBranchOfficeId + "' ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
                    dt.AcceptChanges();
                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }


            return dt;

        }

        public DataTable loadFinishingDefectEntryInfo(string strHeadOffieId, string strBranchOfficeId)
        {

            SewingDTO objSewingDTO = new SewingDTO();
            SewingDAL objSewingDAL = new SewingDAL();

            DataTable dt = new DataTable();

            string sql = "";
            sql = "SELECT " +

                 "FINISHING_DEFECT_ENTRY_ID, " +
                 "LINE_NAME," +
                "TO_CHAR(DEFECT_DATE,'dd/mm/yyyy')DEFECT_DATE," +
                "HOUR_NO," +
                 "TOTAL_CHECK_QTY," +
                 "PRODUCTION_QUANTITY" +
                 " FROM VEW_SEARCH_FINISHING_ALTER  WHERE   head_office_id = '" + strHeadOffieId + "' and branch_office_id ='" + strBranchOfficeId + "' ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
                    dt.AcceptChanges();
                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }


            return dt;

        }



        public SewingDTO searchSewingDefectEntry( string strSewingDefectentryId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SewingDTO objSewingDTO = new SewingDTO();
         
            string sql = "";
            sql = "SELECT " +
            "to_char(nvl(LINE_ID, '0')), " +
            "TO_CHAR(DEFECT_DATE,'dd/mm/yyyy')DEFECT_DATE," +
            "to_char(nvl(TOTAL_CHECK_QTY, '0')), " +
             "to_char(nvl(HOUR_NO, '0')), " +
             "to_char(nvl(PRODUCTION_QUANTITY, '0')), " +
            "to_char(nvl(SHADING, '0')), " +

            "to_char(nvl(DAMAGE_HOLE, '0')), " +

            "to_char(nvl(FABRIC_DEFECT, '0')) ," +

            "to_char(nvl(OPEN_INSECURE_STITCH, '0')), " +
            "to_char(nvl(BROKEN_STITCH, '0')) ," +
            "to_char(nvl(SKIP_STITCH, '0')), " +
            "to_char(nvl(MISSING, '0')), " +
            "to_char(nvl(UNEVEN_EDGE_MARGIN_WIDTH, '0')) ," +
            "to_char(nvl(JOIN_STITCH_POOR_REPIER, '0')), " +
            "to_char(nvl(OVER_DOWN_STITCH, '0')), " +
            "to_char(nvl(TENSION_TIGHT_LOOSE, '0')) ," +
            "to_char(nvl(PLEAT, '0')), " +
            "to_char(nvl(CAUGHT_BY_SEAM, '0')) ," +
            "to_char(nvl(ATTACHED_BY_BARTACK, '0')), " +
            "to_char(nvl(RAWEDGE_FRAYING, '0')) ," +
            "to_char(nvl(EXCESS_LESS_INLAY, '0')), " +
            "to_char(nvl(POOR_SHAPE, '0')), " +
            "to_char(nvl(PUCKRING_LOOSENESS, '0')) ," +
            "to_char(nvl(ROPING_WAVY, '0')) ," +
            "to_char(nvl(SLANTED, '0')) ," +
            "to_char(nvl(HIGH_KING, '0')), " +
            "to_char(nvl(PANEL_HI_LOW_UPDOWN, '0')) ," +
            "to_char(nvl(PANEL_REVERSE, '0')) ," +
            "to_char(nvl(PROJECTION, '0')), " +
            "to_char(nvl(UNMATCH_PAIR_UNBALANCE, '0')), " +

            "to_char(nvl(OIL_MARK, '0')) ," +
            "to_char(nvl(SPOT_DIRTY, '0')) ," +
            "to_char(nvl(MISS_MISPLACE, '0')), " +

            "to_char(nvl(PO_MAIN_SIZE_LBL_MISTAKE, '0')), " +
            "to_char(nvl(CHEST_WAIST, '0')), " +
            "to_char(nvl(F_BACK_LENGTH_THIGH, '0')), " +
            "to_char(nvl(SLV_LENGTH_INSEAM, '0')) ," +
            "to_char(nvl(SWEEP_HIP, '0')) " +

            " FROM VEW_SEARCH_SEWING_ALTER  WHERE SEWING_DEFECT_ENTRY_ID = '" + strSewingDefectentryId + "'  and head_office_id = '" + strHeadOfficeId + "' and branch_office_id ='" + strBranchOfficeId + "' ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                try
                {
                    while (objDataReader.Read())
                    {

                        objSewingDTO.LineId = objDataReader.GetString(0); ;
                        objSewingDTO.DefectDate = objDataReader.GetString(1);
                        objSewingDTO.TotalCheckQuantity = objDataReader.GetString(2);
                        objSewingDTO.HourNO = objDataReader.GetString(3);
                        objSewingDTO.ProductionQuantity = objDataReader.GetString(4);
                        objSewingDTO.Shading = objDataReader.GetString(5);
                        objSewingDTO.DamageHole = objDataReader.GetString(6);
                        objSewingDTO.FabricDefect = objDataReader.GetString(7);
                        objSewingDTO.OpenInsecureStitch = objDataReader.GetString(8);
                        objSewingDTO.BrokenStitch = objDataReader.GetString(9);
                        objSewingDTO.SkipStitch = objDataReader.GetString(10);
                        objSewingDTO.Missing = objDataReader.GetString(11);
                        objSewingDTO.UnevenEdgeMarginWidth = objDataReader.GetString(12);
                        objSewingDTO.JoinStitchPoorRepier = objDataReader.GetString(13);
                        objSewingDTO.OverDownStitchr = objDataReader.GetString(14);
                        objSewingDTO.TensionTightLoose = objDataReader.GetString(15);
                        objSewingDTO.Pleat = objDataReader.GetString(16);
                        objSewingDTO.CaughtbySeam = objDataReader.GetString(17);
                        objSewingDTO.AttachedByBartack = objDataReader.GetString(18);
                        objSewingDTO.RawedgeFraying = objDataReader.GetString(19);
                        objSewingDTO.ExcessLessInlay = objDataReader.GetString(20);
                        objSewingDTO.PoorShape = objDataReader.GetString(21);
                        objSewingDTO.PuckringLooseness = objDataReader.GetString(22);
                        objSewingDTO.RopingWavy = objDataReader.GetString(23);
                        objSewingDTO.Slanted = objDataReader.GetString(24);
                        objSewingDTO.HighKing = objDataReader.GetString(25);
                        objSewingDTO.PanelHiLowUpdown = objDataReader.GetString(26);
                        objSewingDTO.PanelReverse = objDataReader.GetString(27);
                        objSewingDTO.Projection = objDataReader.GetString(28);
                        objSewingDTO.UnmatchPairUnbalance = objDataReader.GetString(29);
                        objSewingDTO.OilMark = objDataReader.GetString(30);
                        objSewingDTO.SpotDirty = objDataReader.GetString(31);
                        objSewingDTO.MissMisPlace = objDataReader.GetString(32);
                        objSewingDTO.PoMainSiZeLblMistake = objDataReader.GetString(33);
                        objSewingDTO.ChestWaist = objDataReader.GetString(34);
                        objSewingDTO.FbackLengthThigh = objDataReader.GetString(35);
                        objSewingDTO.SlvLengthInseam = objDataReader.GetString(36);
                        objSewingDTO.SweepHip = objDataReader.GetString(37);
                        }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error : " + ex.Message);

                }

                finally
                {

                    strConn.Close();
                }

            }

            return objSewingDTO;
        }


        public SewingDTO searchFinishingDefectEntry(string strFinishingDefectentryId, string strHeadOfficeId, string strBranchOfficeId)
        {

            SewingDTO objSewingDTO = new SewingDTO();

            string sql = "";
            sql = "SELECT " +
            "to_char(nvl(LINE_ID, '0')), " +
            "TO_CHAR(DEFECT_DATE,'dd/mm/yyyy')DEFECT_DATE," +
            "to_char(nvl(TOTAL_CHECK_QTY, '0')), " +
             "to_char(nvl(HOUR_NO, '0')), " +
             "to_char(nvl(PRODUCTION_QUANTITY, '0')), " +
            "to_char(nvl(SHADING, '0')), " +

            "to_char(nvl(DAMAGE_HOLE, '0')), " +

            "to_char(nvl(FABRIC_DEFECT, '0')) ," +

            "to_char(nvl(BTN_HOLE_DEFECT, '0')), " +
            "to_char(nvl(BROKEN_STITCH, '0')) ," +
            "to_char(nvl(SKIP_STITCH, '0')), " +
            "to_char(nvl(MISSING, '0')), " +
            "to_char(nvl(UNEVEN_EDGE_MARGIN_WIDTH, '0')) ," +
            "to_char(nvl(JOIN_STITCH_POOR_REPIER, '0')), " +
            "to_char(nvl(OVER_DOWN_STITCH, '0')), " +
            "to_char(nvl(TENSION_TIGHT_LOOSE, '0')) ," +
            "to_char(nvl(PLEAT, '0')), " +
            "to_char(nvl(CAUGHT_BY_SEAM, '0')) ," +
            "to_char(nvl(ATTACHED_BY_BARTACK, '0')), " +
            "to_char(nvl(RAWEDGE_FRAYING, '0')) ," +
            "to_char(nvl(EXCESS_LESS_INLAY, '0')), " +
            "to_char(nvl(POOR_SHAPE, '0')), " +
            "to_char(nvl(PUCKRING_LOOSENESS, '0')) ," +
            "to_char(nvl(ROPING_WAVY, '0')) ," +
            "to_char(nvl(SLANTED, '0')) ," +
            "to_char(nvl(HIGH_KING, '0')), " +
            "to_char(nvl(PANEL_HI_LOW_UPDOWN, '0')) ," +
            "to_char(nvl(PANEL_REVERSE, '0')) ," +
            "to_char(nvl(PROJECTION, '0')), " +
            "to_char(nvl(UNMATCH_PAIR_UNBALANCE, '0')), " +

            "to_char(nvl(OIL_MARK, '0')) ," +
            "to_char(nvl(SPOT_DIRTY, '0')) ," +
            "to_char(nvl(MISS_MISPLACE, '0')), " +

            "to_char(nvl(PO_MAIN_SIZE_LBL_MISTAKE, '0')), " +
            "to_char(nvl(CHEST_WAIST, '0')), " +
            "to_char(nvl(F_BACK_LENGTH_THIGH, '0')), " +
            "to_char(nvl(SLV_LENGTH_INSEAM, '0')) ," +
            "to_char(nvl(SWEEP_HIP, '0')) " +

            " FROM FINISHING_ALTER_ENTRY  WHERE FINISHING_DEFECT_ENTRY_ID = '" + strFinishingDefectentryId + "'  and head_office_id = '" + strHeadOfficeId + "' and branch_office_id ='" + strBranchOfficeId + "' ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                try
                {
                    while (objDataReader.Read())
                    {

                        objSewingDTO.LineId = objDataReader.GetString(0); ;
                        objSewingDTO.DefectDate = objDataReader.GetString(1);
                        objSewingDTO.TotalCheckQuantity = objDataReader.GetString(2);
                        objSewingDTO.HourNO = objDataReader.GetString(3);
                        objSewingDTO.ProductionQuantity = objDataReader.GetString(4);
                        objSewingDTO.Shading = objDataReader.GetString(5);
                        objSewingDTO.DamageHole = objDataReader.GetString(6);
                        objSewingDTO.FabricDefect = objDataReader.GetString(7);
                        objSewingDTO.BtnHoleDefect = objDataReader.GetString(8);
                        objSewingDTO.BrokenStitch = objDataReader.GetString(9);
                        objSewingDTO.SkipStitch = objDataReader.GetString(10);
                        objSewingDTO.Missing = objDataReader.GetString(11);
                        objSewingDTO.UnevenEdgeMarginWidth = objDataReader.GetString(12);
                        objSewingDTO.JoinStitchPoorRepier = objDataReader.GetString(13);
                        objSewingDTO.OverDownStitchr = objDataReader.GetString(14);
                        objSewingDTO.TensionTightLoose = objDataReader.GetString(15);
                        objSewingDTO.Pleat = objDataReader.GetString(16);
                        objSewingDTO.CaughtbySeam = objDataReader.GetString(17);
                        objSewingDTO.AttachedByBartack = objDataReader.GetString(18);
                        objSewingDTO.RawedgeFraying = objDataReader.GetString(19);
                        objSewingDTO.ExcessLessInlay = objDataReader.GetString(20);
                        objSewingDTO.PoorShape = objDataReader.GetString(21);
                        objSewingDTO.PuckringLooseness = objDataReader.GetString(22);
                        objSewingDTO.RopingWavy = objDataReader.GetString(23);
                        objSewingDTO.Slanted = objDataReader.GetString(24);
                        objSewingDTO.HighKing = objDataReader.GetString(25);
                        objSewingDTO.PanelHiLowUpdown = objDataReader.GetString(26);
                        objSewingDTO.PanelReverse = objDataReader.GetString(27);
                        objSewingDTO.Projection = objDataReader.GetString(28);
                        objSewingDTO.UnmatchPairUnbalance = objDataReader.GetString(29);
                        objSewingDTO.OilMark = objDataReader.GetString(30);
                        objSewingDTO.SpotDirty = objDataReader.GetString(31);
                        objSewingDTO.MissMisPlace = objDataReader.GetString(32);
                        objSewingDTO.PoMainSiZeLblMistake = objDataReader.GetString(33);
                        objSewingDTO.ChestWaist = objDataReader.GetString(34);
                        objSewingDTO.FbackLengthThigh = objDataReader.GetString(35);
                        objSewingDTO.SlvLengthInseam = objDataReader.GetString(36);
                        objSewingDTO.SweepHip = objDataReader.GetString(37);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error : " + ex.Message);

                }

                finally
                {

                    strConn.Close();
                }

            }

            return objSewingDTO;
        }

        public DataTable SewingDefectEntrySearch(SewingDTO objSewingDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                
                "SEWING_DEFECT_ENTRY_ID, " +
                 "LINE_NAME," +
                "TO_CHAR(DEFECT_DATE,'dd/mm/yyyy')DEFECT_DATE," +
                "HOUR_NO,"+
                 "TOTAL_CHECK_QTY," +
                  "PRODUCTION_QUANTITY" +
                 " FROM VEW_SEARCH_SEWING_ALTER  WHERE head_office_id = '" + objSewingDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objSewingDTO.BranchOfficeId + "' ";


            if (objSewingDTO.LineId.Length > 0)
            {

                sql = sql + "and LINE_ID = '" + objSewingDTO.LineId + "'";
            }

            if (objSewingDTO.HourNO.Length > 0)
            {

                sql = sql + "and HOUR_NO = '" + objSewingDTO.HourNO + "'";
            }

            if (objSewingDTO.SewingDefectFromDate.Length > 6 && objSewingDTO.SewingDefectToDate.Length > 6)
            {

                sql = sql + "and DEFECT_DATE between to_date('" + objSewingDTO.SewingDefectFromDate + "', 'dd/mm/yyyy') and to_date('" + objSewingDTO.SewingDefectToDate + "', 'dd/mm/yyyy') ";
            }




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }
            return dt;

        }

        public DataTable FinishingDefectEntrySearch(SewingDTO objSewingDTO)
        {

            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +

                "FINISHING_DEFECT_ENTRY_ID, " +
                 "LINE_NAME," +
                "TO_CHAR(DEFECT_DATE,'dd/mm/yyyy')DEFECT_DATE," +
                "HOUR_NO," +
                 "TOTAL_CHECK_QTY," +
                  "PRODUCTION_QUANTITY" +
                 " FROM VEW_SEARCH_FINISHING_ALTER  WHERE head_office_id = '" + objSewingDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objSewingDTO.BranchOfficeId + "' ";


            if (objSewingDTO.LineId.Length > 0)
            {

                sql = sql + "and LINE_ID = '" + objSewingDTO.LineId + "'";
            }

            if (objSewingDTO.HourNO.Length > 0)
            {

                sql = sql + "and HOUR_NO = '" + objSewingDTO.HourNO + "'";
            }

            if (objSewingDTO.SewingDefectFromDate.Length > 6 && objSewingDTO.SewingDefectToDate.Length > 6)
            {

                sql = sql + "and DEFECT_DATE between to_date('" + objSewingDTO.SewingDefectFromDate + "', 'dd/mm/yyyy') and to_date('" + objSewingDTO.SewingDefectToDate + "', 'dd/mm/yyyy') ";
            }




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }
            return dt;

        }
        public DataTable getLineIdSearch(string strHeadOfficeId, string strBranchOfficeId)
        {

            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' LINE_ID, ' Please Select One ' LINE_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(LINE_ID), " +
                  "to_char(LINE_NAME) " +
                  "FROM L_LINE where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "' order by LINE_NAME ";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }



            return dt;

        }


        public string deleteSewingDefectRecord(SewingDTO objSewingDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_delete_sewing_record");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            objOracleCommand.Parameters.Add("P_SEWING_DEFECT_ENTRY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingDefectEntryId;


            //if (objSewingDTO.DefectDate.Length > 6 )
            //{
            //    objOracleCommand.Parameters.Add("P_DEFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.DefectDate;
            //}
            //else
            //{

            //    objOracleCommand.Parameters.Add("P_DEFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            using (OracleConnection strConn = GetConnection())
            {
                try
                {

                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }
            return strMsg;

        }



        public string deleteFinishingDefectRecord(SewingDTO objSewingDTO)
        {
            string strMsg = "";
            OracleTransaction objOracleTransaction = null;
            OracleCommand objOracleCommand = new OracleCommand("pro_delete_finishing_record");
            objOracleCommand.CommandType = CommandType.StoredProcedure;




            objOracleCommand.Parameters.Add("P_FINISHING_DEFECT_ENTRY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.FinishingDefectEntryId;


            //if (objSewingDTO.DefectDate.Length > 6 )
            //{
            //    objOracleCommand.Parameters.Add("P_DEFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.DefectDate;
            //}
            //else
            //{

            //    objOracleCommand.Parameters.Add("P_DEFECT_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            //}




            objOracleCommand.Parameters.Add("p_update_by", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.UpdateBy;
            objOracleCommand.Parameters.Add("p_head_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("p_branch_office_id", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;


            using (OracleConnection strConn = GetConnection())
            {
                try
                {

                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }
            return strMsg;

        }


        public DataTable GetProcessId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' PROCESS_ID, ' Please Select One ' PROCESS_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(PROCESS_ID), " +
                 "to_char(PROCESS_NAME) " +
                  "FROM L_PROCESS order by PROCESS_NAME ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }



            return dt;
        }
        public DataTable GetLineId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' LINE_ID, ' Please Select One ' LINE_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(LINE_ID), " +
                 "to_char(LINE_NAME) " +
                  "FROM L_LINE order by LINE_NAME ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }



            return dt;
        }
        public DataTable GetUnitId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' UNIT_ID, ' Please Select One ' UNIT_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(UNIT_ID), " +
                 "to_char(UNIT_NAME) " +
                  "FROM L_UNIT order by UNIT_NAME ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }



            return dt;
        }
        public DataTable GetFabricDefectId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' FABRIC_DEFECT_ID, ' Please Select One ' FABRIC_DEFECT_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(FABRIC_DEFECT_ID), " +
                 "to_char(FABRIC_DEFECT_NAME) " +
                  "FROM L_FABRIC_DEFECT order by FABRIC_DEFECT_NAME ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }



            return dt;
        }
        public DataTable GetSewingStitchDefectId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' SEWING_STITCH_DEFECT_ID, ' Please Select One ' SEWING_STITCH_DEFECT_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(SEWING_STITCH_DEFECT_ID), " +
                 "to_char(SEWING_STITCH_DEFECT_NAME) " +
                  "FROM L_SEWING_STITCH_DEFECT order by SEWING_STITCH_DEFECT_NAME ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }



            return dt;
        }
        public DataTable GetAestheticDefectId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' AESTHETIC_DEFECT_ID, ' Please Select One ' AESTHETIC_DEFECT_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(AESTHETIC_DEFECT_ID), " +
                 "to_char(AESTHETIC_DEFECT_NAME) " +
                  "FROM L_AESTHETIC_DEFECT order by AESTHETIC_DEFECT_NAME ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }



            return dt;
        }

        public DataTable GetDirtyStainId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' DIRTY_STAIN_ID, ' Please Select One ' DIRTY_STAIN_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(DIRTY_STAIN_ID), " +
                 "to_char(DIRTY_STAIN_NAME) " +
                  "FROM L_DIRTY_STAIN order by DIRTY_STAIN_NAME ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }



            return dt;
        }

        public DataTable GetSizeMeasurementDefectId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' SIZE_MEASUREMENT_DEFECT_ID, ' Please Select One ' SIZE_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(SIZE_ID)SIZE_MEASUREMENT_DEFECT_ID, " +
                 "to_char(SIZE_NAME) " +
                  "FROM L_IE_SIZE order by SIZE_NAME ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }



            return dt;
        }

        public DataTable GetMeasurementDiscrepancyId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' MEASUREMENT_DISCREPANCY_ID, ' Please Select One ' MEASUREMENT_DISCREPANCY_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(MEASUREMENT_DISCREPANCY_ID), " +
                 "to_char(MEASUREMENT_DISCREPANCY_NAME) " +
                  "FROM L_MEASUREMENT_DISCREPANCY order by MEASUREMENT_DISCREPANCY_NAME ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }



            return dt;
        }



        //Sewing Entry Save load search delete

        public string saveSewingEntry(SewingDTO objSewingDTO)
        {
            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("PRO_SEWING_ENTRY_SAVE");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            objOracleCommand.Parameters.Add("P_TRAN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingTranId;
            objOracleCommand.Parameters.Add("P_SEWING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingDate;


            if (objSewingDTO.SewingProcessId != " ")
            {
                objOracleCommand.Parameters.Add("P_PROCESS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingProcessId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROCESS_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objSewingDTO.SewingLineId != " ")
            {
                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingLineId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSewingDTO.SewingUnitId != " ")
            {
                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingUnitId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_UNIT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSewingDTO.SewingNumOfAudit != " ")
            {
                objOracleCommand.Parameters.Add("P_NUMBER_OF_AUDIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingNumOfAudit;

            }

            else
            {
                objOracleCommand.Parameters.Add("P_NUMBER_OF_AUDIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }

            if (objSewingDTO.SewingNumOfPassAudit != " ")
            {
                objOracleCommand.Parameters.Add("P_NUMBER_OF_PASS_AUDIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingNumOfPassAudit;

            }

            else
            {
                objOracleCommand.Parameters.Add("P_NUMBER_OF_PASS_AUDIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }



            if (objSewingDTO.SewingTotalCheckQuality != " ")
            {
                objOracleCommand.Parameters.Add("P_TOTAL_CHECK_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingTotalCheckQuality;

            }

            else
            {
                objOracleCommand.Parameters.Add("P_TOTAL_CHECK_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }
            if (objSewingDTO.TotalHours != " ")
            {
                objOracleCommand.Parameters.Add("P_TOTAL_HOURS", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.TotalHours;

            }

            else
            {
                objOracleCommand.Parameters.Add("P_TOTAL_CHECK_HOURS", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }


            if (objSewingDTO.SewingFabricDefectId != " ")
            {
                objOracleCommand.Parameters.Add("P_FABRIC_DEFECT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingFabricDefectId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_DEFECT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSewingDTO.NumberOfFabricDefect != " ")
            {
                objOracleCommand.Parameters.Add("P_NUMBER_OF_FABRIC_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.NumberOfFabricDefect;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_NUMBER_OF_FABRIC_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSewingDTO.SewingEntyStitchDefectId != " ")
            {
                objOracleCommand.Parameters.Add("P_SEWING_STITCH_DEFECT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingEntyStitchDefectId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SEWING_STITCH_DEFECT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSewingDTO.NumberOfSewingStitchDefect != " ")
            {
                objOracleCommand.Parameters.Add("P_NUMBER_OF_STITCH_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.NumberOfSewingStitchDefect;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_NUMBER_OF_STITCH_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSewingDTO.SewingAestheticDefectId != " ")
            {
                objOracleCommand.Parameters.Add("P_AESTHETIC_DEFECT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingAestheticDefectId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_AESTHETIC_DEFECT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSewingDTO.NumberOfAestheticDefect != " ")
            {
                objOracleCommand.Parameters.Add("P_NUMBER_OF_AESTHETIC_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.NumberOfAestheticDefect;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_NUMBER_OF_AESTHETIC_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSewingDTO.SewingDirtyStainId != " ")
            {
                objOracleCommand.Parameters.Add("P_DIRTY_STAIN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingDirtyStainId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_DIRTY_STAIN_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSewingDTO.NumberOfStainDefect != " ")
            {
                objOracleCommand.Parameters.Add("P_NUMBER_OF_STAIN_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.NumberOfStainDefect;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_NUMBER_OF_STAIN_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSewingDTO.SewingSizeMeasurementDefectId != " ")
            {
                objOracleCommand.Parameters.Add("P_SIZE_MEASUREMENT_DEFECT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingSizeMeasurementDefectId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SIZE_MEASUREMENT_DEFECT_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSewingDTO.NumberOfSizeDefect != " ")
            {
                objOracleCommand.Parameters.Add("P_NUMBER_OF_SIZE_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.NumberOfSizeDefect;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_NUMBER_OF_SIZE_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSewingDTO.SewingMeasurementDiscrepancyId != " ")
            {
                objOracleCommand.Parameters.Add("P_MEASUREMENT_DISCREPANCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingMeasurementDiscrepancyId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MEASUREMENT_DISCREPANCY_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }
            if (objSewingDTO.NumberOfDiscrepancyDefect != " ")
            {
                objOracleCommand.Parameters.Add("P_NUMBER_OF_DISCREPANCY_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.NumberOfDiscrepancyDefect;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_NUMBER_OF_DISCREPANCY_DEFECT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }

            return strMsg;

        }

        public DataTable loadSewingEntryRecord(string strSewingDate, string strHeadOfficeId, string strBranchOfficeId)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +
                            "TRAN_ID, " +
                               " to_char(SEWING_DATE, 'dd/mm/yyyy')SEWING_DATE, " +
                               "PROCESS_ID," +
                               "LINE_ID," +
                               "UNIT_ID," +
                               "NUMBER_OF_AUDIT," +
                               "NUMBER_OF_PASS_AUDIT," +
                               "TOTAL_CHECK_QUANTITY," +
                               "TOTAL_HOURS," +
                               "FABRIC_DEFECT_ID, " +
                               "NUMBER_OF_FABRIC_DEFECT, " +
                               "SEWING_STITCH_DEFECT_ID, " +
                               "NUMBER_OF_STITCH_DEFECT, " +
                               "AESTHETIC_DEFECT_ID, " +
                               "NUMBER_OF_AESTHETIC_DEFECT, " +
                               "DIRTY_STAIN_ID, " +
                               "NUMBER_OF_STAIN_DEFECT, " +
                               "SIZE_MEASUREMENT_DEFECT_ID, " +
                               "NUMBER_OF_SIZE_DEFECT, " +
                               "MEASUREMENT_DISCREPANCY_ID, " +
                               "NUMBER_OF_DISCREPANCY_DEFECT " +



                               "FROM VEW_SEWING_ENTRY where head_office_id = '" + strHeadOfficeId + "' and branch_office_id = '" + strBranchOfficeId + "' ";

            if (strSewingDate.Length > 6)
            {


                sql = sql + " and SEWING_DATE = to_date('" + strSewingDate + "', 'dd/mm/yyyy') ";
            }


            sql = sql + " order by TRAN_ID ";


            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
                    dt.AcceptChanges();
                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }


            return dt;
        }

        public DataTable loadSewingEntryRecordSub(SewingDTO objSewingDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +


                  "to_char(nvl(TRAN_ID, '0'))TRAN_ID, " +
                  "to_char(nvl(NUMBER_OF_AUDIT,'0'))NUMBER_OF_AUDIT, " +
                  "to_char(nvl(NUMBER_OF_PASS_AUDIT,'0'))NUMBER_OF_PASS_AUDIT, " +
                  "to_char(nvl(TOTAL_CHECK_QUANTITY,'0'))TOTAL_CHECK_QUANTITY, " +
                  "to_char(nvl(TOTAL_HOURS,'0'))TOTAL_HOURS, " +


                    "to_char(nvl(FABRIC_DEFECT_ID, '0'))FABRIC_DEFECT_ID, " +
                    "to_char(nvl(NUMBER_OF_FABRIC_DEFECT, '0'))NUMBER_OF_FABRIC_DEFECT, " +
                    "to_char(nvl(SEWING_STITCH_DEFECT_ID, '0'))SEWING_STITCH_DEFECT_ID, " +
                    "to_char(nvl(NUMBER_OF_STITCH_DEFECT, '0'))NUMBER_OF_STITCH_DEFECT, " +
                    "to_char(nvl(AESTHETIC_DEFECT_ID, '0'))AESTHETIC_DEFECT_ID, " +
                    "to_char(nvl(NUMBER_OF_AESTHETIC_DEFECT, '0'))NUMBER_OF_AESTHETIC_DEFECT, " +
                    "to_char(nvl(DIRTY_STAIN_ID, '0'))DIRTY_STAIN_ID, " +
                     "to_char(nvl(NUMBER_OF_STAIN_DEFECT, '0'))NUMBER_OF_STAIN_DEFECT, " +
                    "to_char(nvl(SIZE_MEASUREMENT_DEFECT_ID, '0'))SIZE_MEASUREMENT_DEFECT_ID, " +
                    "to_char(nvl(NUMBER_OF_SIZE_DEFECT, '0'))NUMBER_OF_SIZE_DEFECT, " +
                    "to_char(nvl(MEASUREMENT_DISCREPANCY_ID, '0'))MEASUREMENT_DISCREPANCY_ID, " +
                     "to_char(nvl(NUMBER_OF_DISCREPANCY_DEFECT, '0'))NUMBER_OF_DISCREPANCY_DEFECT " +





                    "FROM VEW_SEARCH_SEWING_ENTRY WHERE SEWING_DATE = to_Date('" + objSewingDTO.SewingDate + "', 'dd/mm/yyyy') and head_office_id = '" + objSewingDTO.HeadOfficeId + "' and branch_office_id ='" + objSewingDTO.BranchOfficeId + "' ";

          

            //sql = sql + " order by TRAN_ID ";


            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
                    dt.AcceptChanges();
                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }


            return dt;
        }

        public SewingDTO searchSewingEntry(string strSewingDate, string strHeadOfficeId, string strBranchOfficeId)
        {
            SewingDTO objSewingDTO = new SewingDTO();
            string sql = "";
            sql = "SELECT " +


                  "to_char(nvl(PROCESS_ID, '0')), " +
                  "to_char(nvl(LINE_ID, '0')), " +
                  "to_char(nvl(UNIT_ID, '0')), " +
                  "to_char(nvl(NUMBER_OF_AUDIT, '0')), " +
                  "to_char(nvl(NUMBER_OF_PASS_AUDIT,'0')), " +
                  "to_char(nvl(TOTAL_CHECK_QUANTITY,'0')), " +
                  "to_char(nvl(TOTAL_HOURS,'0')), " +
                  "to_char(nvl(FABRIC_DEFECT_ID, '0')), " +
                  "to_char(nvl(NUMBER_OF_FABRIC_DEFECT, '0')), " +
                  "to_char(nvl(SEWING_STITCH_DEFECT_ID, '0')), " +
                  "to_char(nvl(NUMBER_OF_STITCH_DEFECT, '0')), " +
                  "to_char(nvl(AESTHETIC_DEFECT_ID, '0')), " +
                  "to_char(nvl(NUMBER_OF_AESTHETIC_DEFECT, '0')), " +
                  "to_char(nvl(DIRTY_STAIN_ID, '0')), " +
                   "to_char(nvl(NUMBER_OF_STAIN_DEFECT, '0')), " +
                  "to_char(nvl(SIZE_MEASUREMENT_DEFECT_ID, '0')), " +
                  "to_char(nvl(NUMBER_OF_SIZE_DEFECT, '0')), " +
                  "to_char(nvl(MEASUREMENT_DISCREPANCY_ID, '0')), " +
                   "to_char(nvl(NUMBER_OF_DISCREPANCY_DEFECT, '0')) " +





                  "FROM VEW_SEARCH_SEWING_ENTRY WHERE SEWING_DATE = to_Date('" + strSewingDate + "', 'dd/mm/yyyy') and head_office_id = '" + strHeadOfficeId + "' and branch_office_id ='" + strBranchOfficeId + "' ";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                try
                {
                    while (objDataReader.Read())
                    {


                        objSewingDTO.SewingProcessId = objDataReader.GetString(0);
                        objSewingDTO.SewingLineId = objDataReader.GetString(1);
                        objSewingDTO.SewingUnitId = objDataReader.GetString(2);
                        objSewingDTO.SewingNumOfAudit = objDataReader.GetString(3);
                        objSewingDTO.SewingNumOfPassAudit = objDataReader.GetString(4);
                        objSewingDTO.SewingTotalCheckQuality = objDataReader.GetString(5);
                        objSewingDTO.TotalHours = objDataReader.GetString(6);
                        objSewingDTO.SewingFabricDefectId = objDataReader.GetString(7);
                        objSewingDTO.NumberOfFabricDefect = objDataReader.GetString(8);
                        objSewingDTO.SewingEntyStitchDefectId = objDataReader.GetString(9);
                        objSewingDTO.NumberOfSewingStitchDefect = objDataReader.GetString(10);
                        objSewingDTO.SewingAestheticDefectId = objDataReader.GetString(11);
                        objSewingDTO.NumberOfAestheticDefect = objDataReader.GetString(12);
                        objSewingDTO.SewingDirtyStainId = objDataReader.GetString(13);
                        objSewingDTO.NumberOfStainDefect = objDataReader.GetString(14);
                        objSewingDTO.SewingSizeMeasurementDefectId = objDataReader.GetString(15);
                        objSewingDTO.NumberOfSizeDefect = objDataReader.GetString(16);
                        objSewingDTO.SewingMeasurementDiscrepancyId = objDataReader.GetString(17);
                        objSewingDTO.NumberOfDiscrepancyDefect = objDataReader.GetString(18);





                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error : " + ex.Message);

                }

                finally
                {

                    strConn.Close();
                }

            }


            return objSewingDTO;
        }
        public SewingDTO loadSewingEntryRecordMain(string strSewingDate, string strHeadOfficeId, string strBranchOfficeId)
        {
            SewingDTO objSewingDTO = new SewingDTO();
            string sql = "";
            sql = "SELECT " +


                  "to_char(nvl(PROCESS_ID, '0')), " +
                  "to_char(nvl(LINE_ID, '0')), " +
                  "to_char(nvl(UNIT_ID, '0')) " +





                  "FROM VEW_SEWING_ENTRY WHERE SEWING_DATE = to_Date('" + strSewingDate + "', 'dd/mm/yyyy') and head_office_id = '" + strHeadOfficeId + "' and branch_office_id ='" + strBranchOfficeId + "' ";




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                try
                {
                    while (objDataReader.Read())
                    {


                        objSewingDTO.SewingProcessId = objDataReader.GetString(0);
                        objSewingDTO.SewingLineId = objDataReader.GetString(1);
                        objSewingDTO.SewingUnitId = objDataReader.GetString(2);
         
       





                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error : " + ex.Message);

                }

                finally
                {

                    strConn.Close();
                }

            }


            return objSewingDTO;
        }

        public string deleteSewingEntry(SewingDTO objSewingDto)
        {
            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_delete_SewingEntry");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objSewingDto.SewingDate != "")
            {
                objOracleCommand.Parameters.Add(" P_SEWING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDto.SewingDate;

            }
            else
            {

                objOracleCommand.Parameters.Add(" P_SEWING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }






            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDto.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDto.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDto.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }

            return strMsg;
        }

        public string saveSewingThreadOpeningBalance(SewingDTO objSewingDTO)
        {

            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_thread_sewing_save");

            objOracleCommand.CommandType = CommandType.StoredProcedure;



            objOracleCommand.Parameters.Add("P_THREAD_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingThreadId;

            if (objSewingDTO.SewingSupplierId != " ")
            {
                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingSupplierId;

            }
            else
            {

                objOracleCommand.Parameters.Add("P_SUPPLIER_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }



            if (objSewingDTO.SewingProgrammeId != " ")
            {
                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.SewingProgrammeId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PROGRAMME_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSewingDTO.ArtNo != " ")
            {
                objOracleCommand.Parameters.Add("P_ART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.ArtNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ART_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }

            if (objSewingDTO.ThreadCount != " ")
            {
                objOracleCommand.Parameters.Add("P_THREAD_COUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.ThreadCount;

            }

            else
            {
                objOracleCommand.Parameters.Add("P_THREAD_COUNT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }

            if (objSewingDTO.BalanceQty != " ")
            {
                objOracleCommand.Parameters.Add("P_BALANCE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.BalanceQty;

            }

            else
            {
                objOracleCommand.Parameters.Add("P_BALANCE_QUANTITY", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;


            }






            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDTO.BranchOfficeId;

            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }

            return strMsg;

        }


        public DataTable loadSewingEntryRecord(SewingDTO objSewingDTO)
        {


            DataTable dt = new DataTable();
            string sql = "";

            sql = "SELECT " +


                               "to_char(NVL(ART_NO,'0'))ART_NO, " +
                               "to_char(NVL(THREAD_COUNT,'0'))THREAD_COUNT, " +
                               "to_char(NVL(BALANCE_QUANTITY,'0'))BALANCE_QUANTITY, " +
                                "to_char(NVL(THREAD_ID,'0'))THREAD_ID " +

                               " FROM  VEW_SEARCH_SEWING_THREAD_ENTRY where head_office_id = '" + objSewingDTO.HeadOfficeId + "' AND branch_office_id = '" + objSewingDTO.BranchOfficeId + "' ";

            if (objSewingDTO.SewingSupplierId.Length > 0)
            {

                sql = sql + "and supplier_id = '" + objSewingDTO.SewingSupplierId + "'";
            }

            if (objSewingDTO.SewingProgrammeId.Length > 0)
            {

                sql = sql + "and programme_id = '" + objSewingDTO.SewingProgrammeId + "'";
            }




            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);
                    dt.AcceptChanges();
                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }


            return dt;
        }


        public DataTable GetProgrammeId()
        {
            DataTable dt = new DataTable();
            string sql = "";
            sql = "select ' ' PROGRAMME_ID, ' Please Select One ' PROGRAMME_NAME from dual " +
                    "union " +

                "SELECT " +
                  "to_char(PROGRAMME_ID), " +
                 "to_char(PROGRAMME_NAME) " +
                  "FROM L_PROGRAMME order by PROGRAMME_NAME ";

            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataAdapter objDataAdapter = new OracleDataAdapter(objCommand);
            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objCommand.Connection = strConn;
                    strConn.Open();
                    objDataAdapter.Fill(dt);

                }
                catch (Exception ex)
                {

                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }



            return dt;
        }

        public string deleteSewingThreadEntry(SewingDTO objSewingDto)
        {
            LoginDTO objLoginDTO = new LoginDTO();
            string strMsg = "";


            OracleCommand objOracleCommand = new OracleCommand("pro_delete_SewingThreadEntry");

            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objSewingDto.SewingThreadId != "")
            {
                objOracleCommand.Parameters.Add(" P_THREAD_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDto.SewingThreadId;

            }
            else
            {

                objOracleCommand.Parameters.Add(" P_THREAD_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;
            }






            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDto.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDto.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objSewingDto.BranchOfficeId;


            objOracleCommand.Parameters.Add("P_MESSAGE", OracleDbType.Varchar2, 500).Direction = ParameterDirection.Output;

            using (OracleConnection strConn = GetConnection())
            {
                try
                {
                    objOracleCommand.Connection = strConn;
                    strConn.Open();
                    trans = strConn.BeginTransaction();
                    objOracleCommand.ExecuteNonQuery();
                    trans.Commit();
                    strConn.Close();
                    strMsg = objOracleCommand.Parameters["P_MESSAGE"].Value.ToString();
                }

                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error : " + ex.Message);
                }

                finally
                {

                    strConn.Close();
                }

            }

            return strMsg;
        }


        public SewingDTO searchSewingThreadEntry(string strSupplierId, string strProgrammeId, string strHeadOfficeId, string strBranchOfficeId)
        {
            SewingDTO objSewingDTO = new SewingDTO();
            string sql = "";
            sql = "SELECT " +


                  "to_char(nvl(SUPPLIER_ID, '0')), " +
                  "to_char(nvl(PROGRAMME_ID, '0')), " +
                  "to_char(nvl(ART_NO, '0')), " +
                  "to_char(nvl(THREAD_COUNT, '0')), " +
                  "to_char(nvl(BALANCE_QUANTITY,'0')) " +






                  "FROM VEW_SEARCH_SEWING_THREAD_ENTRY WHERE    head_office_id = '" + strHeadOfficeId + "' and branch_office_id ='" + strBranchOfficeId + "' and SUPPLIER_ID = '" + strSupplierId + "'  and PROGRAMME_ID = '" + strProgrammeId + "' ";






            OracleCommand objCommand = new OracleCommand(sql);
            OracleDataReader objDataReader;

            using (OracleConnection strConn = GetConnection())
            {

                objCommand.Connection = strConn;
                strConn.Open();
                objDataReader = objCommand.ExecuteReader();
                try
                {
                    while (objDataReader.Read())
                    {


                        objSewingDTO.SewingSupplierId = objDataReader.GetString(0);
                        objSewingDTO.SewingProgrammeId = objDataReader.GetString(1);
                        objSewingDTO.ArtNo = objDataReader.GetString(2);
                        objSewingDTO.ThreadCount = objDataReader.GetString(3);
                        objSewingDTO.BalanceQty = objDataReader.GetString(4);






                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error : " + ex.Message);

                }

                finally
                {

                    strConn.Close();
                }

            }


            return objSewingDTO;
        }





    


    }
}
