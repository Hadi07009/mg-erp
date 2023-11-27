using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Globalization;

namespace SINHA.MEDLAR.ERP.DBMANAGER
{
    public class DBUtil
    {
        #region DBUtil functions
        public static bool IsNumeric(string strNumber)
        {
            Double d;

            NumberFormatInfo n = new NumberFormatInfo();

            if (strNumber.Length == 0)
            {
                return false;
            }
            return Double.TryParse(strNumber, System.Globalization.NumberStyles.Float, n, out d);
        }
        public string TextWithSingleCode(string FullText)
        {
            try
            {
                string TotalText = string.Empty;
                string fullItem = string.Empty;

                FullText = FullText.Trim();
                if (FullText.Contains(","))
                {
                    string[] TextArray = FullText.Split(',');

                    foreach (string item in TextArray)
                    {
                        fullItem = fullItem + "'" + item + "',";
                    }
                    TotalText = fullItem.TrimEnd(',');

                }
                else
                {
                    TotalText = "'" + FullText + "'";
                }

                return TotalText;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }


        }
        #endregion

    }
}
