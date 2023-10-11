using OfficeOpenXml.Table;
using OfficeOpenXml;

namespace CloudPOS.Utlis
{
    public static class ReportHelper
    {
        public static byte[] ExportToExcel<T>(IList<T> table, string filename)
        {
            using ExcelPackage pack = new ExcelPackage();
            ExcelWorksheet ws = pack.Workbook.Worksheets.Add(filename);
            ws.Cells["A1"].LoadFromCollection(table, true, TableStyles.Light1);
            return pack.GetAsByteArray();
        }
    }
}
