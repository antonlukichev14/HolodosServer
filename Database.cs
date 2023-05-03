using Microsoft.Office.Interop.Excel;
using System;

namespace HolodosServer
{
    class Database
    {
        string filePath;

        Application excel;
        Workbook wb;
        public Worksheet ws;

        public Database()
        {

            filePath = @"DATABASEPLS.xlsx";
            excel = new Application();
            wb = excel.Workbooks.Open(filePath);
            ws = wb.Worksheets[1];


        }
        public string ReadCell(int column, int row)
        {
            string cellValue = ws.Cells[column, row].Value2.ToString();

            wb.Close();
            excel.Quit();

            return cellValue;
        }

        public void WriteCell(int column, int row, string value)
        {

            excel.Visible = true;
            excel.DisplayAlerts = false;

            ws.Cells[column, row].Value2 = value;

            wb.SaveAs(@"DATABASEPLS.xlsx");
            wb.Close();
            excel.ActiveWorkbook.Close();
            excel.Quit();
            GC.Collect();
        }

    }
}
