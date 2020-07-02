using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.NPOI
{
    public class ImportExcel
    {
        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="file">导入路径</param>
        /// <param name="firtitle">首行是否是标题列,如果有标题列,标题列作为DataTable中的列明(1是、0否)</param>
        /// <returns></returns>
        public DataTable Import(string file, int firtitle = 1)
        {
            try
            {
                DataTable dt = new DataTable();
                IWorkbook workbook;
                string fileExt = Path.GetExtension(file).ToLower();//获取扩展名
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))//打开文件读取数据
                {
                    //XSSFWorkbook 适用XLSX格式，HSSFWorkbook 适用XLS格式
                    if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(fs); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(fs); } else { workbook = null; }
                    if (workbook == null) { return null; }
                    ISheet sheet = workbook.GetSheetAt(0);//获取第一个表单
                    List<int> columns = new List<int>();
                    //第一行行数据
                    IRow header = sheet.GetRow(sheet.FirstRowNum);
                    //第一行末尾列
                    for (int i = 0; i < header.LastCellNum; i++)
                    {
                        object obj = GetValueType(header.GetCell(i));
                        if (obj == null || obj.ToString() == string.Empty)
                        {
                            dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                        }
                        else
                        {
                            if (firtitle == 1)
                            {
                                dt.Columns.Add(new DataColumn(obj.ToString()));
                            }
                            else if (firtitle == 0)
                            {
                                dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                            }
                        }
                        columns.Add(i);
                    }

                    var fir = sheet.FirstRowNum;
                    if (firtitle == 1)
                        fir = fir + 1;
                    //数据  
                    for (int i = fir; i <= sheet.LastRowNum; i++)//首行   尾行
                    {
                        DataRow dr = dt.NewRow();
                        bool hasValue = false;
                        foreach (int j in columns)
                        {
                            dr[j] = GetValueType(sheet.GetRow(i).GetCell(j));
                            if (dr[j] != null && dr[j].ToString() != string.Empty)
                            {
                                hasValue = true;
                            }
                        }
                        if (hasValue)
                        {
                            dt.Rows.Add(dr);
                        }
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取单元格类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:  
                    return null;
                case CellType.Boolean: //BOOLEAN:  
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:  
                    return cell.NumericCellValue;
                case CellType.String: //STRING:  
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:  
                    return cell.ErrorCellValue;
                case CellType.Formula: //FORMULA:  
                default:
                    return "=" + cell.CellFormula;
            }
        }



    }
}
