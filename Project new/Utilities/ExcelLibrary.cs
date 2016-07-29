using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Data;
using System.IO;
using System.Drawing;

namespace ChutHueManagement.Utilities
{
    public class ExcelLibrary
    {
        public ExcelLibrary()
        {

        }

        /// <summary>
        /// Hàm chuyển từ 1 Sheet trên Excel thành 1 DataTable
        /// </summary>
        /// <param name="oSheet">Sheet cần chuyển</param>
        /// <returns>DataTable</returns>
        DataTable WorksheetToDataTable(ExcelWorksheet oSheet)
        {
            int totalRows = oSheet.Dimension.End.Row;
            int totalCols = oSheet.Dimension.End.Column;

            DataTable dt = new DataTable(oSheet.Name);

            DataRow row = null;

            for (int i = 1; i <= totalRows; i++)
            {
                if (i > 1)
                    row = dt.Rows.Add();
                for (int j = 1; j <= totalCols; j++)
                {
                    if (i == 1)
                        dt.Columns.Add(oSheet.Cells[i, j].Value.ToString());
                    else
                        row[j - 1] = oSheet.Cells[i, j].Value.ToString();
                }
            }
            return dt;
        }

        /// <summary>
        /// Chuyển 1 sheet thành DataTable
        /// </summary>
        /// <param name="stream">1 Stream đang mở file Excel cần chuyển</param>
        /// <param name="sheetName">Tên sheet của file Execl cần chuyển</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDataWorkSheet(FileStream stream, string sheetName)
        {
            ExcelPackage excelPkg = new ExcelPackage();
            excelPkg.Load(stream);
            ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets[sheetName];
            ExcelLibrary lb = new ExcelLibrary();
            return lb.WorksheetToDataTable(oSheet);
        }

        /// <summary>
        /// Hàm chuyển DataTable thành 1 mảng Byte để lưu xuống Execl
        /// </summary>
        /// <param name="data">Chứa dữ liệu </param>
        /// <param name="Title"></param>
        /// <param name="sheetname"></param>
        /// <returns></returns>
        public static Byte[] ExportExcel(DataTable data, string Title, string sheetname)
        {
            using (ExcelPackage excelPkg = new ExcelPackage())
            {
                // 1. Setting Excel Workbook Properties
                excelPkg.Workbook.Properties.Author = "";
                excelPkg.Workbook.Properties.Title = Title;

                // Creating Excel Worksheet
                ExcelWorksheet oSheet = CreateSheet(excelPkg, sheetname);

                //  DataTable
                DataTable dt = data;

                // Putting Data into Cells
                CreateData(oSheet, dt);

                // Writting bytes by bytes in Excel File
                Byte[] content = excelPkg.GetAsByteArray();
                return content;
            }
        }

        /// <summary>
        /// Tạo 1 Sheet để export ra excel
        /// </summary>
        /// <param name="excelPkg">đối tượng việc excelPkg chứa dữ liêu cần chuyển</param>
        /// <param name="sheetName">Tên Sheet</param>
        /// <returns>ExcelWorksheet</returns>
        private static ExcelWorksheet CreateSheet(ExcelPackage excelPkg, string sheetName)
        {
            ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets.Add(sheetName);
            // Setting default font for whole sheet
            oSheet.Cells.Style.Font.Name = "Calibri";
            // Setting font size for whole sheet
            oSheet.Cells.Style.Font.Size = 11;
            return oSheet;
        }

        /// <summary>
        /// Tao5 Data cho Sheet từ 1 DataTable
        /// </summary>
        /// <param name="oSheet">Sheet cần chứa data</param>
        /// <param name="dt">DataTable chứa dữ liệu cần xuất</param>
        private static void CreateData(ExcelWorksheet oSheet, DataTable dt)
        {
            int numrows = dt.Rows.Count;
            int numcols = dt.Columns.Count;

            for (int i = 0; i < numcols; i++)
            {
                var cell = oSheet.Cells[1, i + 1];
                cell.Value = dt.Columns[i].ColumnName;

                var border = cell.Style.Border;
                border.Top.Style = border.Left.Style = border.Bottom.Style = border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                var fill = cell.Style.Fill;
                fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.AliceBlue);
            }


            for (int i = 0; i < numrows; i++)
            {
                for (int j = 0; j < numcols; j++)
                {
                    var cell1 = oSheet.Cells[i + 2, j + 1];
                    cell1.Value = dt.Rows[i][j].ToString();
                    var border = cell1.Style.Border;
                    border.Top.Style = border.Left.Style = border.Bottom.Style = border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                }
            }
        }
    }
}
