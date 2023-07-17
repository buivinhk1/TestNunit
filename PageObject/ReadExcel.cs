using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Office.Interop.Excel;

namespace TestNunit.PageObject
{
    public class ReadExcel
    {
        public void ReadDataFromExcel()
        {
            FileInfo fileInfo = new FileInfo(@"C:\Users\vbui22\Documents\TestData.xlsx");

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Index of sheet in Excel file

                // Read values ​​from specific cells in worksheet
                string valueA1 = worksheet.Cells["A1"].Value.ToString();
                string valueB2 = worksheet.Cells["B2"].Value.ToString();
                //...@"C:\Users\vbui22\Documents\TestData.xlsx"
                // Use readable values ​​in your execution
                //...
            }
        }
       
    }
}

