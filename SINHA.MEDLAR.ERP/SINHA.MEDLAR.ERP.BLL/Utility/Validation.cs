using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.BLL.Utility
{
    public static class Validation
    {
        public static string IsValidFiscalYear(string fromDate, string toDate)
        {

            string result = string.Empty;

            bool isValid = true;
            DateTime? firstDate = null;
            DateTime? secondDate = null;
            DateTime? fDate = null;
            DateTime? tDate = null;

            try
            {
                
                fDate = DateTime.Parse(fromDate, new CultureInfo("bn-BD"));
                tDate = DateTime.Parse(toDate, new CultureInfo("bn-BD"));

                var fromMonth = DateTime.Parse(fromDate, new CultureInfo("bn-BD")).Month;
                var fromYear = DateTime.Parse(fromDate, new CultureInfo("bn-BD")).Year;

                if (fromMonth >= 7 && fromMonth <= 12)
                {
                    firstDate = new DateTime(fromYear, 7, 1);
                    secondDate = new DateTime(fromYear + 1, 6, 30);
                }
                if (fromMonth >= 1 && fromMonth <= 6)
                {
                    firstDate = new DateTime(fromYear - 1, 7, 1);
                    secondDate = new DateTime(fromYear, 6, 30);
                }

                if (fDate > tDate)
                    isValid = false;
                if (fDate < firstDate || tDate > secondDate)
                    isValid = false;

                if (!isValid)
                    result = "Please Enter Valid Fiscal Year";
            }
            catch (Exception e)
            {
            }
            return result;
        }
    }
}
