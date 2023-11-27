using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.DAL;

using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Configuration;


namespace SINHA.MEDLAR.ERP.DAL
{
    public class LayChartDAL
    {
        #region "Oracle Connection Function"

        private OracleConnection GetConnection()
        {
            var conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"];
            string strConnString = conString.ConnectionString;
            return new OracleConnection(strConnString);
        }

        #endregion

        public string saveLayChart(LayChartDTO objLayChartDTO)
        {
            string strMsg = "";
           
            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_lay_chart_register_save");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objLayChartDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.PONo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLayChartDTO.SRNo != "")
            {

                objOracleCommand.Parameters.Add("P_SR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.SRNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLayChartDTO.CuttingNo != "")
            {

                objOracleCommand.Parameters.Add("P_CUTTING_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.CuttingNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CUTTING_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objLayChartDTO.CuttingDate != "")
            {

                objOracleCommand.Parameters.Add("P_CUTTING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.CuttingDate;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_CUTTING_DATE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLayChartDTO.LineId != "")
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.LineId;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_LINE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLayChartDTO.MeasurementWidth != "")
            {

                objOracleCommand.Parameters.Add("P_MESAUREMENT_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.MeasurementWidth;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MESAUREMENT_WIDTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLayChartDTO.MeasurementLength != "")
            {

                objOracleCommand.Parameters.Add("P_MESAUREMENT_LENGTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.MeasurementLength;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_MESAUREMENT_LENGTH", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLayChartDTO.RollNo != "")
            {

                objOracleCommand.Parameters.Add("P_ROLL_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.RollNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_ROLL_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLayChartDTO.LengthWiseShrinkage != "")
            {

                objOracleCommand.Parameters.Add("P_LENGTH_WISE_SHRINKAGE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.LengthWiseShrinkage;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_LENGTH_WISE_SHRINKAGE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objLayChartDTO.WidthWiseShrinkage != "")
            {

                objOracleCommand.Parameters.Add("P_WIDTH_WISE_SHRINKAGE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.WidthWiseShrinkage;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_WIDTH_WISE_SHRINKAGE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLayChartDTO.Shade != "")
            {

                objOracleCommand.Parameters.Add("P_SHADE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.Shade;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SHADE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLayChartDTO.LayOut != "")
            {

                objOracleCommand.Parameters.Add("P_LAY_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.LayOut;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_LAY_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLayChartDTO.TotalLayOut != "")
            {

                objOracleCommand.Parameters.Add("P_TOTAL_LAY_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.TotalLayOut;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_TOTAL_LAY_OUT", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objLayChartDTO.StickerNo != "")
            {

                objOracleCommand.Parameters.Add("P_STICKER_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.StickerNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_STICKER_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objLayChartDTO.YardPerMeter != "")
            {

                objOracleCommand.Parameters.Add("P_YDS_PER_METER", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.YardPerMeter;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_YDS_PER_METER", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            if (objLayChartDTO.FabricUse != "")
            {

                objOracleCommand.Parameters.Add("P_FABRIC_USE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.FabricUse;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_FABRIC_USE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLayChartDTO.Elance != "")
            {

                objOracleCommand.Parameters.Add("P_BLANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.Elance;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_BLANCE", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }


            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.BranchOfficeId;


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
        public string deleteLayChart(LayChartDTO objLayChartDTO)
        {
            string strMsg = "";

            OracleTransaction trans = null;

            OracleCommand objOracleCommand = new OracleCommand("pro_delete_lay_chart");
            objOracleCommand.CommandType = CommandType.StoredProcedure;

            if (objLayChartDTO.PONo != "")
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.PONo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_PO_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }

            if (objLayChartDTO.SRNo != "")
            {

                objOracleCommand.Parameters.Add("P_SR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.SRNo;
            }
            else
            {

                objOracleCommand.Parameters.Add("P_SR_NO", OracleDbType.Varchar2, ParameterDirection.Input).Value = null;

            }




            objOracleCommand.Parameters.Add("P_UPDATE_BY", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.UpdateBy;
            objOracleCommand.Parameters.Add("P_HEAD_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.HeadOfficeId;
            objOracleCommand.Parameters.Add("P_BRANCH_OFFICE_ID", OracleDbType.Varchar2, ParameterDirection.Input).Value = objLayChartDTO.BranchOfficeId;


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
        public DataTable searchLayChartEntry(LayChartDTO objLayChartDTO)
        {

            DataTable dt = new DataTable();
            LayChartDAL objLayChartDAL = new LayChartDAL();

            string sql = "";

            sql = "SELECT " +
                 
                   "PO_NO, "+
                   "SR_NO, "+
                   "ROLL_NO, "+
                   "LENGTH_WISE_SHRINKAGE, "+
                   "WIDTH_WISE_SHRINKAGE, "+
                   "SHADE, "+
                   "LAY_OUT, "+
                   "TOTAL_LAY_OUT, "+
                   "STICKER_NO, "+
                   "YDS_PER_METER, "+
                   "FABRIC_USE, "+
                   "BLANCE, "+
                   "UPDATE_BY, "+
                   "UPDATE_DATE, "+
                   "HEAD_OFFICE_ID, "+
                   "BRANCH_OFFICE_ID, "+
                   "CUTTING_NO, "+
                   "CUTTING_DATE, "+
                   "LINE_ID, "+
                   "MESAUREMENT_WIDTH, "+
                   "MESAUREMENT_LENGTH " +




                  "FROM VEW_SEARCH_LAY_CHART_ENTRY WHERE head_office_id = '" + objLayChartDTO.HeadOfficeId + "'  AND BRANCH_OFFICE_ID = '" + objLayChartDTO.BranchOfficeId + "'  ";






            if (objLayChartDTO.PONo.Length > 0)
            {

                sql = sql + "and PO_NO = '" + objLayChartDTO.PONo + "'";
            }
            if (objLayChartDTO.SRNo.Length > 0)
            {

                sql = sql + "and SR_NO = '" + objLayChartDTO.SRNo + "'";
            }

            if (objLayChartDTO.FromDate.Length > 6 && objLayChartDTO.ToDate.Length > 6)
            {

                sql = sql + " and CUTTING_DATE BETWEEN TO_DATE( '" + objLayChartDTO.FromDate + "', 'dd/mm/yyyy') AND TO_DATE( '" + objLayChartDTO.ToDate + "', 'dd/mm/yyyy') ";
            }



           // sql = sql + "order by SL ";

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
    }
}
