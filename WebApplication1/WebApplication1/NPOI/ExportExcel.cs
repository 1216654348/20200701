using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.NPOI
{
    public class ExportExcel
    {
        /// <summary>  
        /// DataTable导出到Excel文件  
        /// </summary>  
        /// <param name="dtSource">源DataTable</param>  
        /// <param name="strHeaderText">表头文本</param>  
        /// <param name="strFileName">保存位置</param>
        public static void Export(DataTable dtSource, string strHeaderText, string strFileName)
        {
            using (MemoryStream ms = Export(dtSource, strHeaderText))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

        /// <summary>  
        /// DataTable导出到Excel的MemoryStream  
        /// </summary>  
        /// <param name="dtSource">源DataTable</param>  
        /// <param name="strHeaderText">表头文本</param>
        public static MemoryStream Export(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            //ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            //dateStyle.DataFormat = format.GetFormat("yyyy-MM-dd");

            #region 取得每列的列宽（最大宽度）
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {

                //GBK对应的code page是CP936
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                if (arrColWidth[item.Ordinal] > 255)
                {
                    arrColWidth[item.Ordinal] = 254;
                }
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j] && intTemp < 255)
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            #endregion

            int rowIndex = 0;

            ICellStyle contentStyle = workbook.CreateCellStyle();
            contentStyle.Alignment = HorizontalAlignment.Center;
            contentStyle.VerticalAlignment = VerticalAlignment.Center;

            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 表头及样式
                    if (!string.IsNullOrEmpty(strHeaderText))
                    {
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        headerRow.GetCell(0).CellStyle = headStyle;

                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                    }
                    #endregion


                    #region 列头及样式
                    {
                        IRow headerRow = null;
                        if (string.IsNullOrEmpty(strHeaderText))
                        {
                            headerRow = sheet.CreateRow(0);
                        }
                        else
                        {
                            headerRow = sheet.CreateRow(1);
                        }
                        headerRow.Height = 700;
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        headStyle.VerticalAlignment = VerticalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);


                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽  
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 3) * 256);

                        }
                    }
                    #endregion
                    if (string.IsNullOrEmpty(strHeaderText))
                    {
                        rowIndex = 1;
                    }
                    else
                    {
                        rowIndex = 2;
                    }

                }
                #endregion


                #region 填充内容

                IRow dataRow = sheet.CreateRow(rowIndex);
                dataRow.Height = 500;
                foreach (DataColumn column in dtSource.Columns)
                {
                    ICell newCell = dataRow.CreateCell(column.Ordinal);
                    newCell.CellStyle = contentStyle;

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型  
                            if (column.ColumnName.ToUpper() == "审核状态")
                            {
                                if (drValue == "0")
                                {
                                    newCell.SetCellValue("待审核");
                                }
                                if (drValue == "1")
                                {
                                    newCell.SetCellValue("已通过");
                                }
                                if (drValue == "2")
                                {
                                    newCell.SetCellValue("未通过");
                                }
                                if (drValue == "3")
                                {
                                    newCell.SetCellValue("未提交");
                                }
                            }
                            else
                            {
                                newCell.SetCellValue(drValue);
                            }
                            break;
                        case "System.DateTime"://日期类型  
                            DateTime dateV;
                            if (!string.IsNullOrEmpty(drValue))
                            {
                                DateTime.TryParse(drValue, out dateV);
                                newCell.SetCellValue(dateV.ToString("yyyy-MM-dd HH:mm:ss"));

                                //newCell.CellStyle = dateStyle;//格式化显示  
                            }
                            else
                            {
                                newCell.SetCellValue("");
                            }


                            break;
                        case "System.Boolean"://布尔型  
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型  
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                        case "System.SByte":
                            int intV = 0;
                            if (string.IsNullOrEmpty(drValue))
                            {
                                newCell.SetCellValue("");
                                break;
                            }
                            else
                            {
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV.ToString());
                                break;
                            }
                        case "System.Decimal"://浮点型  
                        case "System.Double":
                            double doubV = 0;
                            if (string.IsNullOrEmpty(drValue))
                            {
                                newCell.SetCellValue("");
                                break;
                            }
                            else
                            {
                                double.TryParse(drValue, out doubV);
                                newCell.SetCellValue(doubV.ToString());
                                break;
                            }


                        case "System.DBNull"://空值处理  
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }


            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                //sheet.Dispose();
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet  
                return ms;
            }

        }



        /// <summary>  
        /// DataTable导出到Excel的MemoryStream  
        /// </summary>  
        /// <param name="dtSource">源DataTable</param>  
        /// <param name="strHeaderText">表头文本</param>
        public static byte[] ExportByte(List<ExprotToDt> dtSources, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();


            //ICellStyle dateStyle = workbook.CreateCellStyle();
            //IDataFormat format = workbook.CreateDataFormat();
            //dateStyle.DataFormat = format.GetFormat("yyyy-MM-dd");

            int count = 0;
            foreach (var dtSource in dtSources)
            {
                ICellStyle contentStyle = workbook.CreateCellStyle();
                contentStyle.Alignment = HorizontalAlignment.Center;
                contentStyle.VerticalAlignment = VerticalAlignment.Center;

                ISheet sheet = workbook.CreateSheet(dtSource.SheetName + count);
                count = count + 1;
                int rowIndex = 0;
                #region 取得每列的列宽（最大宽度）
                int[] arrColWidth = new int[dtSource.Data.Columns.Count];
                foreach (DataColumn item in dtSource.Data.Columns)
                {

                    //GBK对应的code page是CP936
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                    if (arrColWidth[item.Ordinal] > 255)
                    {
                        arrColWidth[item.Ordinal] = 254;
                    }
                }
                for (int i = 0; i < dtSource.Data.Rows.Count; i++)
                {
                    for (int j = 0; j < dtSource.Data.Columns.Count; j++)
                    {
                        int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Data.Rows[i][j].ToString()).Length;
                        if (intTemp > arrColWidth[j] && intTemp < 255)
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }
                #endregion
                foreach (DataRow row in dtSource.Data.Rows)
                {
                    #region 新建表，填充表头，填充列头，样式
                    if (rowIndex == 65535 || rowIndex == 0)
                    {
                        if (rowIndex != 0)
                        {
                            sheet = workbook.CreateSheet();
                        }

                        #region 表头及样式
                        if (!string.IsNullOrEmpty(strHeaderText))
                        {
                            IRow headerRow = sheet.CreateRow(0);
                            headerRow.CreateCell(0).SetCellValue(strHeaderText);

                            ICellStyle headStyle = workbook.CreateCellStyle();
                            headStyle.Alignment = HorizontalAlignment.Center;
                            IFont font = workbook.CreateFont();
                            font.FontHeightInPoints = 20;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);

                            headerRow.GetCell(0).CellStyle = headStyle;

                            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Data.Columns.Count - 1));
                        }
                        #endregion


                        #region 列头及样式
                        {
                            IRow headerRow = null;
                            if (string.IsNullOrEmpty(strHeaderText))
                            {
                                headerRow = sheet.CreateRow(0);
                            }
                            else
                            {
                                headerRow = sheet.CreateRow(1);
                            }
                            headerRow.Height = 700;
                            ICellStyle headStyle = workbook.CreateCellStyle();
                            headStyle.Alignment = HorizontalAlignment.Center;
                            headStyle.VerticalAlignment = VerticalAlignment.Center;
                            IFont font = workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);


                            foreach (DataColumn column in dtSource.Data.Columns)
                            {
                                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                                //设置列宽  
                                sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 3) * 256);

                            }
                        }
                        #endregion
                        if (string.IsNullOrEmpty(strHeaderText))
                        {
                            rowIndex = 1;
                        }
                        else
                        {
                            rowIndex = 2;
                        }

                    }
                    #endregion


                    #region 填充内容

                    IRow dataRow = sheet.CreateRow(rowIndex);
                    dataRow.Height = 500;
                    foreach (DataColumn column in dtSource.Data.Columns)
                    {
                        ICell newCell = dataRow.CreateCell(column.Ordinal);
                        newCell.CellStyle = contentStyle;

                        string drValue = row[column].ToString();
                        //string drValue = dtSource.Rows[i][column].ToString();

                        switch (column.DataType.ToString())
                        {
                            case "System.String"://字符串类型  
                                if (column.ColumnName.ToUpper() == "审核状态")
                                {
                                    if (drValue == "0")
                                    {
                                        newCell.SetCellValue("待审核");
                                    }
                                    if (drValue == "1")
                                    {
                                        newCell.SetCellValue("已通过");
                                    }
                                    if (drValue == "2")
                                    {
                                        newCell.SetCellValue("未通过");
                                    }
                                    if (drValue == "3")
                                    {
                                        newCell.SetCellValue("未提交");
                                    }
                                }
                                else
                                {
                                    newCell.SetCellValue(drValue);
                                }
                                break;
                            case "System.DateTime"://日期类型  
                                DateTime dateV;
                                if (!string.IsNullOrEmpty(drValue))
                                {
                                    DateTime.TryParse(drValue, out dateV);
                                    newCell.SetCellValue(dateV.ToString("yyyy-MM-dd HH:mm:ss"));

                                    //newCell.CellStyle = dateStyle;//格式化显示  
                                }
                                else
                                {
                                    newCell.SetCellValue("");
                                }


                                break;
                            case "System.Boolean"://布尔型  
                                bool boolV = false;
                                bool.TryParse(drValue, out boolV);
                                newCell.SetCellValue(boolV);
                                break;
                            case "System.Int16"://整型  
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                            case "System.SByte":
                                int intV = 0;
                                if (string.IsNullOrEmpty(drValue))
                                {
                                    newCell.SetCellValue("");
                                    break;
                                }
                                else
                                {
                                    int.TryParse(drValue, out intV);
                                    newCell.SetCellValue(intV.ToString());
                                    break;
                                }
                            case "System.Decimal"://浮点型  
                            case "System.Double":
                                double doubV = 0;
                                if (string.IsNullOrEmpty(drValue))
                                {
                                    newCell.SetCellValue("");
                                    break;
                                }
                                else
                                {
                                    double.TryParse(drValue, out doubV);
                                    newCell.SetCellValue(doubV.ToString());
                                    break;
                                }


                            case "System.DBNull"://空值处理  
                                newCell.SetCellValue("");
                                break;
                            default:
                                newCell.SetCellValue("");
                                break;
                        }

                    }
                    #endregion

                    rowIndex++;
                }
            }

            ByteArrayOutputStream bos = new ByteArrayOutputStream();
            workbook.Write(bos);
            byte[] barray = bos.ToByteArray();
            //InputStream stream = new ByteArrayInputStream(barray);
            return barray;

        }

    }

    public class ExprotToDt
    {
        public DataTable Data { get; set; }
        public string SheetName { get; set; }
    }
}
