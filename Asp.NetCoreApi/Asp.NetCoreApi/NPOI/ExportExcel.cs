using Asp.NetCoreApi.Infrastructure;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
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

namespace Asp.NetCoreApi.NPOI
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
                                newCell.SetCellValue(drValue);
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
            return barray;
        }

        /// <summary>  
        /// DataTable导出到Excel的MemoryStream  
        /// </summary>  
        /// <param name="dtSource">源DataTable</param>  
        /// <param name="strHeaderText">表头文本</param>
        public static byte[] ExportByteDatable(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();


            //ICellStyle dateStyle = workbook.CreateCellStyle();
            //IDataFormat format = workbook.CreateDataFormat();
            //dateStyle.DataFormat = format.GetFormat("yyyy-MM-dd");
            ICellStyle contentStyle = workbook.CreateCellStyle();
            contentStyle.Alignment = HorizontalAlignment.Center;
            contentStyle.VerticalAlignment = VerticalAlignment.Center;
            ISheet sheet = workbook.CreateSheet("sheet1");
            int rowIndex = 0;
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

            ByteArrayOutputStream bos = new ByteArrayOutputStream();
            workbook.Write(bos);
            byte[] barray = bos.ToByteArray();
            //InputStream stream = new ByteArrayInputStream(barray);
            return barray;
        }



        //https://mp.weixin.qq.com/s/PwSS4PSxyS562ds7LaJfqQ
        /// <summary>
        /// Excel数据导出简单示例
        /// </summary>
        /// <param name="resultMsg">导出结果</param>
        /// <param name="excelFilePath">保存excel文件路径</param>
        /// <returns></returns>
        public static bool ExcelDataExport(out string resultMsg, out string excelFilePath)
        {
            var result = true;
            excelFilePath = "";
            resultMsg = "successfully";
            //Excel导出名称
            string excelName = "人才培训课程表";
            try
            {
                //首先创建Excel文件对象
                var workbook = new HSSFWorkbook();
                //创建工作表，也就是Excel中的sheet，给工作表赋一个名称(Excel底部名称)
                var sheet = workbook.CreateSheet("人才培训课程表");
                //sheet.DefaultColumnWidth = 20;//默认列宽
                sheet.ForceFormulaRecalculation = true;//TODO:是否开始Excel导出后公式仍然有效（非必须）
                #region table 表格内容设置

                #region 标题样式
                //设置顶部大标题样式
                var cellStyleFont = NpoiExcelExportHelper._.CreateStyle(workbook, HorizontalAlignment.Center, VerticalAlignment.Center, 20, true, 700, "楷体", true, false, false, true, FillPattern.SolidForeground, HSSFColor.Coral.Index, HSSFColor.White.Index,
                    FontUnderlineType.None, FontSuperScript.None, false);

                //第一行表单
                var row = NpoiExcelExportHelper._.CreateRow(sheet, 0, 28);
                var cell = row.CreateCell(0);
                //合并单元格 例：第1行到第2行 第3列到第4列围成的矩形区域
                //TODO:关于Excel行列单元格合并问题
                //第一个参数：从第几行开始合并
                //第二个参数：到第几行结束合并
                //第三个参数：从第几列开始合并
                //第四个参数：到第几列结束合并
                CellRangeAddress region = new CellRangeAddress(0, 0, 0, 5);
                sheet.AddMergedRegion(region);
                cell.SetCellValue("人才培训课程表");//合并单元格后，只需对第一个位置赋值即可（TODO:顶部标题）
                cell.CellStyle = cellStyleFont;
                //二级标题列样式设置
                var headTopStyle = NpoiExcelExportHelper._.CreateStyle(workbook, HorizontalAlignment.Center, VerticalAlignment.Center, 15, true, 700, "楷体", true, false, false, true, FillPattern.SolidForeground, HSSFColor.Grey25Percent.Index, HSSFColor.Black.Index,
                FontUnderlineType.None, FontSuperScript.None, false);
                //表头名称
                var headerName = new[] { "课程类型", "序号", "日期", "课程名称", "内容概要", "讲师简介" };
                row = NpoiExcelExportHelper._.CreateRow(sheet, 1, 24);//第二行
                for (var i = 0; i < headerName.Length; i++)
                {
                    cell = NpoiExcelExportHelper._.CreateCells(row, headTopStyle, i, headerName[i]);
                    //设置单元格宽度
                    if (headerName[i] == "讲师简介" || headerName[i] == "内容概要")
                    {
                        sheet.SetColumnWidth(i, 10000);
                    }
                    else
                    {
                        sheet.SetColumnWidth(i, 5000);
                    }
                }
                #endregion

                #region 单元格内容信
                //单元格边框样式
                var cellStyle = NpoiExcelExportHelper._.CreateStyle(workbook, HorizontalAlignment.Center, VerticalAlignment.Center, 10, true, 400);
                //左侧列单元格合并 begin
                //TODO:关于Excel行列单元格合并问题（合并单元格后，只需对第一个位置赋值即可）
                //  第一个参数：从第几行开始合并
                //  第二个参数：到第几行结束合并
                //  第三个参数：从第几列开始合并
                //  第四个参数：到第几列结束合并
                CellRangeAddress leftOne = new CellRangeAddress(2, 7, 0, 0);
                sheet.AddMergedRegion(leftOne);
                CellRangeAddress leftTwo = new CellRangeAddress(8, 11, 0, 0);
                sheet.AddMergedRegion(leftTwo);
                //左侧列单元格合并 end
                var currentDate = DateTime.Now;
                string[] curriculumList = new[] { "艺术学", "设计学", "材料学", "美学", "心理学", "中国近代史", "管理人员的情绪修炼", "高效时间管理", "有效的目标管理", "沟通与协调" };
                int number = 1;
                for (var i = 0; i < 10; i++)
                {
                    row = NpoiExcelExportHelper._.CreateRow(sheet, i + 2, 20); //sheet.CreateRow(i+2);//在上面表头的基础上创建行
                    switch (number)
                    {
                        case 1:
                            cell = NpoiExcelExportHelper._.CreateCells(row, cellStyle, 0, "公共类课程");
                            break;
                        case 7:
                            cell = NpoiExcelExportHelper._.CreateCells(row, cellStyle, 0, "管理类课程");
                            break;
                    }
                    //创建单元格列公众类课程
                    cell = NpoiExcelExportHelper._.CreateCells(row, cellStyle, 1, number.ToString());
                    cell = NpoiExcelExportHelper._.CreateCells(row, cellStyle, 2, currentDate.AddDays(number).ToString("yyyy-MM-dd"));
                    cell = NpoiExcelExportHelper._.CreateCells(row, cellStyle, 3, curriculumList[i]);
                    cell = NpoiExcelExportHelper._.CreateCells(row, cellStyle, 4, "提升，充实，拓展自己综合实力");
                    cell = NpoiExcelExportHelper._.CreateCells(row, cellStyle, 5, "追逐时光_" + number + "号金牌讲师！");
                    number++;
                }
                #endregion
                #endregion
                string folder = DateTime.Now.ToString("yyyyMMdd");
                //保存文件到静态资源文件夹中（wwwroot）,使用绝对路径
                var uploadPath = @"E:\" + "UploadFile/" + folder + "/";
                //excel保存文件名
                string excelFileName = excelName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
                //创建目录文件夹
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                //Excel的路径及名称
                string excelPath = uploadPath + excelFileName;
                //使用FileStream文件流来写入数据（传入参数为：文件所在路径，对文件的操作方式，对文件内数据的操作）
                var fileStream = new FileStream(excelPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                //向Excel文件对象写入文件流，生成Excel文件
                workbook.Write(fileStream);

                //关闭文件流
                fileStream.Close();

                //释放流所占用的资源
                fileStream.Dispose();
                //excel文件保存的相对路径，提供前端下载
                var relativePositioning = "/UploadFile/" + folder + "/" + excelFileName;
                excelFilePath = relativePositioning;
            }
            catch (Exception e)
            {
                result = false;
                resultMsg = e.Message;
            }
            return result;
        }


        public static bool ExcelDataExportEx(List<ExprotToDt> exprotToDt)
        {
            //首先创建Excel文件对象
            var workbook = new HSSFWorkbook();

            #region Style
            //设置顶部大标题样式
            var cellStyleFont = NpoiExcelExportHelper._.CreateStyle(workbook, HorizontalAlignment.Center, VerticalAlignment.Center, 20, true, 700, "楷体", true, false, false, true, FillPattern.SolidForeground, HSSFColor.Coral.Index, HSSFColor.White.Index,
                FontUnderlineType.None, FontSuperScript.None, false);

            //二级标题列样式设置
            var headTopStyle = NpoiExcelExportHelper._.CreateStyle(workbook, HorizontalAlignment.Center, VerticalAlignment.Center, 15, true, 700, "楷体", true, false, false, true, FillPattern.SolidForeground, HSSFColor.Grey25Percent.Index, HSSFColor.Black.Index,
                FontUnderlineType.None, FontSuperScript.None, false);

            //单元格边框样式
            var cellStyle = NpoiExcelExportHelper._.CreateStyle(workbook, HorizontalAlignment.Center, VerticalAlignment.Center, 10, true, 400);
            #endregion

            var sheetNameList = exprotToDt.GroupBy(e => e.SheetName).Select(e => e.Count()).ToList();
            if (sheetNameList.Any(e => e > 1)) return false;

            foreach (var exprotItem in exprotToDt)
            {
                exprotItem.SheetName = string.IsNullOrEmpty(exprotItem.SheetName) ? "Sheet1" : exprotItem.SheetName;
                ISheet sheet = workbook.CreateSheet(exprotItem.SheetName);

                int[] arrColWidth = new int[exprotItem.Data.Columns.Count];//总列数
                #region 列宽度值
                foreach (DataColumn columnItem in exprotItem.Data.Columns)
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    var len = Encoding.GetEncoding(936).GetBytes(columnItem.ColumnName).Length * 1.5;
                    arrColWidth[columnItem.Ordinal] = Convert.ToInt32(len);
                    if (arrColWidth[columnItem.Ordinal] > 255) arrColWidth[columnItem.Ordinal] = 254;
                }
                for (int i = 0; i < exprotItem.Data.Rows.Count; i++)
                {
                    for (int j = 0; j < exprotItem.Data.Columns.Count; j++)
                    {
                        int intTemp = Encoding.GetEncoding(936).GetBytes(exprotItem.Data.Rows[i][j].ToString()).Length;
                        if (intTemp > arrColWidth[j] && intTemp < 255) arrColWidth[j] = intTemp;
                    }
                }
                #endregion
                int rowIndex = 0;//行数量
                foreach (DataRow row in exprotItem.Data.Rows)
                {
                    if (rowIndex == 65535 || rowIndex == 0)
                    {
                        if (rowIndex != 0) sheet = workbook.CreateSheet();
                        #region HeaderText顶部标题
                        if (!string.IsNullOrEmpty(exprotItem.HeaderText))
                        {
                            IRow headerRow = sheet.CreateRow(0);
                            headerRow.HeightInPoints = 28;
                            ICell headercell = headerRow.CreateCell(0);
                            headercell.SetCellValue(exprotItem.HeaderText);
                            //合并列
                            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, exprotItem.Data.Columns.Count - 1));
                            headercell.CellStyle = cellStyleFont;
                        }
                        #endregion

                        #region 二级表题
                        IRow bodyRow = null;
                        if (string.IsNullOrEmpty(exprotItem.HeaderText)) bodyRow = sheet.CreateRow(0);
                        else bodyRow = sheet.CreateRow(1);
                        bodyRow.HeightInPoints = 24;
                        foreach (DataColumn column in exprotItem.Data.Columns)
                        {
                            ICell cell = bodyRow.CreateCell(column.Ordinal);
                            cell.SetCellValue(column.ColumnName);
                            cell.CellStyle = headTopStyle;
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 3) * 256);
                        }
                        if (string.IsNullOrEmpty(exprotItem.HeaderText)) rowIndex = 1;
                        else rowIndex = 2;
                        #endregion
                    }
                    #region 内容数据
                    IRow dataRow = sheet.CreateRow(rowIndex);
                    dataRow.HeightInPoints = 20;
                    foreach (DataColumn column in exprotItem.Data.Columns)
                    {
                        ICell newCell = dataRow.CreateCell(column.Ordinal);
                        string drValue = row[column].ToString();
                        newCell.SetCellValue(drValue);
                        newCell.CellStyle = cellStyle;
                    }
                    rowIndex++;
                    #endregion
                }
            }

            string folder = DateTime.Now.ToString("yyyyMMdd");
            var uploadPath = @"E:\" + "UploadFile/" + folder + "/";
            string excelFileName = "测试Excel" + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls";
            if (!Directory.Exists(uploadPath)) Directory.CreateDirectory(uploadPath);
            string excelPath = uploadPath + excelFileName;
            using var fileStream = new FileStream(excelPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            workbook.Write(fileStream);
            fileStream.Close();
            fileStream.Dispose();
            return true;
        }
    }

    #region
    public class ExprotToDt
    {
        public DataTable Data { get; set; }
        public string SheetName { get; set; }
        public string HeaderText { get; set; }
    }


    #endregion
}
