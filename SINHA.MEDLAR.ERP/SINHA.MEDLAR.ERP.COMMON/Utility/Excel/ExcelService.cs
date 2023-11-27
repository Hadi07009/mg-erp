//using ClosedXML.Excel;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace SINHA.MEDLAR.ERP.COMMON.Utility.Excel
{
    public static class ExcelService
    {

        public static void ImportExcel(string filePath)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //Create a new ExcelPackage
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "VDWWD";
                excelPackage.Workbook.Properties.Title = "Title of Document";
                excelPackage.Workbook.Properties.Subject = "EPPlus demo export data";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                //Create the WorkSheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");

                //Add some text to cell A1
                worksheet.Cells["A1"].Value = "My first EPPlus spreadsheet!";
                //You could also use [line, column] notation:
                worksheet.Cells[1, 2].Value = "This is cell B1!";

                //Save your file
                //FileInfo fi1 = new FileInfo(@"Path\To\Your\File.xlsx");
                FileInfo fi1 = new FileInfo(filePath);
                excelPackage.SaveAs(fi1);
            }

            ////Opening an existing Excel file
            //FileInfo fi = new FileInfo(@"Path\To\Your\File.xlsx");
            //using (ExcelPackage excelPackage = new ExcelPackage(fi))
            //{
            //    //Get a WorkSheet by index. Note that EPPlus indexes are base 1, not base 0!
            //    ExcelWorksheet firstWorksheet = excelPackage.Workbook.Worksheets[1];

            //    //Get a WorkSheet by name. If the worksheet doesn't exist, throw an exeption
            //    ExcelWorksheet namedWorksheet = excelPackage.Workbook.Worksheets["SomeWorksheet"];

            //    //If you don't know if a worksheet exists, you could use LINQ,
            //    //So it doesn't throw an exception, but return null in case it doesn't find it
            //    ExcelWorksheet anotherWorksheet =
            //        excelPackage.Workbook.Worksheets.FirstOrDefault(x => x.Name == "SomeWorksheet");

            //    //Get the content from cells A1 and B1 as string, in two different notations
            //    string valA1 = firstWorksheet.Cells["A1"].Value.ToString();
            //    string valB1 = firstWorksheet.Cells[1, 2].Value.ToString();

            //    //Save your file
            //    excelPackage.Save();
            //}
        }

        public static void GenerateExcel(DataTable DT, string fullFileName, string sheetName)
        {
            var file = new FileInfo(fullFileName);
            string currentFileName = System.IO.Path.GetFileName(fullFileName);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage(file);

            var sheetcreate = excel.Workbook.Worksheets.Add(sheetName);

                        
            //Workbook workbook = new Workbook();
            //workbook.LoadFromFile("Sample.xlsx");

            int col = 0;
            foreach (DataColumn column in DT.Columns)  //printing column headings
            {
                sheetcreate.Cells[1, ++col].Value = column.ColumnName;
                sheetcreate.Cells[1, col].Style.Font.Bold = true;
                sheetcreate.Cells[1, col].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                sheetcreate.Cells[1, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                //sheetcreate.Cells[1, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#e0e0e0"));

            }
            if (DT.Rows.Count > 0)
            {
                int row = 1;
                decimal checkDecimal;
                for (int eachRow = 0; eachRow < DT.Rows.Count;)    //looping each row
                {

                    for (int eachColumn = 1; eachColumn <= col; eachColumn++)   //looping each column in a row
                    {
                        var eachRowObject = sheetcreate.Cells[row + 1, eachColumn];
                        eachRowObject.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        eachRowObject.Value = DT.Rows[eachRow][(eachColumn - 1)].ToString();

                        if (decimal.TryParse(DT.Rows[eachRow][(eachColumn - 1)].ToString(), out checkDecimal))      //verifying value is number to make it right align
                        {
                            eachRowObject.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        }
                        eachRowObject.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        if (eachRow % 2 == 0)       
                            eachRowObject.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ffffff")); //e0e0e0
                        else
                            eachRowObject.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"));
                    }
                    eachRow++;
                    row++;

                }
            }
            sheetcreate.Cells.AutoFitColumns();
            excel.Save();
        }

        private static DataTable GetDataTable(DataTable data)
        {
            //Create a DataTable with four columns
            DataTable table = new DataTable();
                        
            int columnscount = table.Columns.Count; 

            for (int j = 0; j < columnscount; j++)
            {
               table.Columns.Add(table.Columns[j].ColumnName.ToString(), table.Columns[j].DataType);                
            }

            table = data;
                        
            return table;
        }
                        
    }
}
