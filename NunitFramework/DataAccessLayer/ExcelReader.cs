using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace NUnitFramework.DataAccessLayer
{
    class ExcelReader
    {
        public DataTable SheetToDataTable(String filePath,String sheetName)
        {
            Excel.Application xlApp=null;
            Excel.Workbook xlBook=null;
            DataTable dataTable = new DataTable();
            try
            {
                xlApp = new Excel.Application();
                xlBook= xlApp.Workbooks.Open(filePath);

                Excel.Worksheet xlSheet = xlBook.Sheets[sheetName];

                Excel.Range xlRange = xlSheet.UsedRange;

                for (int i = 1; i <= xlRange.Columns.Count; i++)
                {
                    if (xlRange.Cells[1, i] != null && xlRange.Cells[1, i].value != "")
                    {
                        dataTable.Columns.Add(xlRange.Cells[1, i].value);
                    }
                }

                for (int i = 2; i <= xlRange.Rows.Count; i++)
                {
                    DataRow row = dataTable.NewRow();
                    for (int j = 1; j <= xlRange.Columns.Count; j++)
                    {
                        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].value != "")
                        {
                            row[j - 1] = xlRange.Cells[i, j].Value;
                        }
                    }
                    dataTable.Rows.Add(row);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Sheet to Datatable issue");
                
            }
            finally
            {
                xlBook.Close();
                xlApp.Quit();
            }
  

            return dataTable;
        }
    }
}
