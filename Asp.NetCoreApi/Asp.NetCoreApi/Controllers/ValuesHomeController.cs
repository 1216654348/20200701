﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using Asp.NetCoreApi.Extension;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.NetCoreApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesHomeController : ControllerBase
    {
        //// GET: api/<ValuesHomeController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    //return new string[] { "value1", "value2" };

        //    lzjcContext lzjcContext = new lzjcContext();
        //    var date = new DateTime(2019, 12, 31, 00, 00, 00);
        //    var data = lzjcContext.GlyjcRcxcycjl.Where(e => e.Tjsj >= date).ToList(); //提交时间为2019 - 12 - 31及以后的数据
        //    var user = lzjcContext.OrgUserinfo.ToList();//创建人ID    提交人ID     异常解除人ID     巡查员
        //    var ycysqd = lzjcContext.GlyjcYcysqd.ToList();//遗产要素清单
        //    var zbx = lzjcContext.TRcxcZbx.ToList();//指标项
        //    var xcqy = lzjcContext.GlyjcRcxcqy.ToList();//日常巡查区域
        //    var dycdyxcd_enum = lzjcContext.YsjDomainEnumitem.Where(e => e.Enumid == "671f1aa1-aa80-11e8-b019-1866daf8aad4").ToList();//对遗产地影响程度
        //    var sjcjfs_enum = lzjcContext.YsjDomainEnumitem.Where(e => e.Enumid == "FD89GSS9F-V89W7E-23B1L3J-42J42HB42K3").ToList();//对遗产地影响程度
        //    var xgjl = lzjcContext.GlyjcXgdgljl.ToList();//巡更记录

        //    var datalist = data.Select(e => new GlyjcRcxcycjlDto()
        //    {
        //        Id = e.Id,
        //        Cjrid = e.Cjrid,
        //        CJRXM = user.Where(c => c.Id == e.Cjrid).Count() < 1 ? "" : user.Where(c => c.Id == e.Cjrid).FirstOrDefault().Realname,
        //        Cjsj = e.Cjsj,
        //        //Shrid = e.Shrid,
        //        //SHRXM = user.Where(c => c.Id == e.Shrid).Count() < 1 ? "" : user.Where(c => c.Id == e.Shrid).FirstOrDefault().Realname,
        //        //Shsj = e.Shsj,
        //        Shzt = e.Shzt,
        //        Shzt_DESC= e.Shzt==null?"": e.Shzt.ToString()=="0"?"待审核": e.Shzt.ToString() == "1" ? "已通过" : e.Shzt.ToString() == "2" ? "未通过" : e.Shzt.ToString() == "3" ? "未提交" :"",
        //        //Shbtgsm = e.Shbtgsm,
        //        //Sfkdj = e.Sfkdj,
        //        //Djrid = e.Djrid,
        //        //DJRXM = user.Where(c => c.Id == e.Djrid).Count() < 1 ? "" : user.Where(c => c.Id == e.Djrid).FirstOrDefault().Realname,
        //        //Djsj = e.Djsj,
        //        Sfydj = e.Sfydj,
        //        Shyc = e.Shyc,
        //        Tjrid = e.Tjrid,
        //        TJRXM = user.Where(c => c.Id == e.Tjrid).Count() < 1 ? "" : user.Where(c => c.Id == e.Tjrid).FirstOrDefault().Realname,
        //        Tjsj = e.Tjsj,
        //        Ycjcrid = e.Ycjcrid,
        //        YCJCRXM = user.Where(c => c.Id == e.Ycjcrid).Count() < 1 ? "" : user.Where(c => c.Id == e.Ycjcrid).FirstOrDefault().Realname,
        //        Xcrq = e.Xcrq,
        //        Ycsj = e.Ycsj,
        //        Yczb = e.Yczb,
        //        Xcy = e.Xcy,
        //        XCYXM = user.Where(c => c.Id == e.Xcy).Count() < 1 ? "" : user.Where(c => c.Id == e.Xcy).FirstOrDefault().Realname,
        //        Dscqdcs = e.Dscqdcs,
        //        Rwid = e.Rwid,
        //        Zpmc = e.Zpmc,
        //        Sfbj = e.Sfbj,
        //        SFBJ_DESC = e.Sfbj == "0" ? "否" : e.Sfbj == "1" ? "是" : "",
        //        //Ycysid = e.Ycysid,
        //        YCYSID_DESC = ycysqd.Where(c => c.Id == e.Ycysid).Count() < 1 ? "" : ycysqd.Where(c => c.Id == e.Ycysid).FirstOrDefault().Ycysmc,
        //        Sjms = e.Sjms,
        //        Yclx = e.Yclx,
        //        YCLX_DESC = zbx.Where(c => c.Id == e.Yclx).Count() < 1 ? "" : zbx.Where(c => c.Id == e.Yclx).FirstOrDefault().Name,
        //        Sjcjfs = e.Sjcjfs,
        //        SJCJFS_DESC = sjcjfs_enum.Where(c => c.Code == e.Sjcjfs).Count() < 1 ? "" : sjcjfs_enum.Where(c => c.Code == e.Sjcjfs).FirstOrDefault().Name,
        //        Jchzp = e.Jchzp,
        //        Jcsj = e.Jcsj,
        //        Ycsfjc = e.Ycsfjc,
        //        YCSFJC_DESC = e.Ycsfjc == "0" ? "否" : e.Ycsfjc == "1" ? "是" : "",
        //        //Pg = e.Pg,
        //        Fswzwz = e.Fswzwz,
        //        Jd = e.Jd,
        //        Wd = e.Wd,
        //        //Rcxcjlid = e.Rcxcjlid,
        //        //Xgjlid = e.Xgjlid,
        //        Qyid = e.Qyid,
        //        QYID_DESC = xcqy.Where(c => c.Id == e.Qyid).Count() < 1 ? "" : xcqy.Where(c => c.Id == e.Qyid).FirstOrDefault().Qymc,
        //        //Bz = e.Bz,
        //        //Dycdyxcd = e.Dycdyxcd,
        //        //DYCDYXCD_DESC = dycdyxcd_enum.Where(c => c.Code == e.Dycdyxcd).Count() < 1 ? "" : dycdyxcd_enum.Where(c => c.Code == e.Dycdyxcd).FirstOrDefault().Name,
        //        //Ysclzp = e.Ysclzp,
        //        Sort = e.Sort,
        //        Xcdid = e.Xcdid,
        //        XCDMC = xgjl.Where(c => c.Id == e.Xcdid).Count() < 1 ? "" : xgjl.Where(c => c.Id == e.Xcdid).FirstOrDefault().Mc
        //    }).ToList();

        //    //var webAttPaht = @"http://60.191.9.82:82/";

        //    var fjb = lzjcContext.GlyjcFjb.Where(e => datalist.Select(c => c.Id).Contains(e.Sjid) && e.Bid == "75").ToList();


        //    List<string> str = new List<string>();
        //    foreach (var item in datalist)
        //    {
        //        //ZpmcPath异常记录照片名称
        //        var zpmc = fjb.Where(e => e.Fjdyzdm.ToUpper() == "ZPMC" && e.Sjid == item.Id).Select(e => new PahtFile() { MLMC = e.Mlmc, CCMC = e.Ccmc }).ToList();
        //        item.ZpmcPath = zpmc.Select(e => e.CCMC).Join(",");

        //        str.AddRange(pathweb(zpmc));



        //        //解除后照片
        //        var jchzp = fjb.Where(e => e.Fjdyzdm.ToUpper() == "JCHZP" && e.Sjid == item.Id).Select(e => new PahtFile() { MLMC = e.Mlmc, CCMC = e.Ccmc }).ToList();
        //        item.JchzpPath = jchzp.Select(e => e.CCMC).Join(",");

        //        str.AddRange(pathweb(jchzp));
        //    }


        //    var json = JsonConvert.SerializeObject(datalist);
        //    var datatable = JsonConvert.DeserializeObject<DataTable>(json);
        //    ExportExcel_NPOI.Export(datatable, null, $@"D:\Afile\{DateTime.Now.ToString("yyyyMMddHHmmss")}.xls");
        //    return null;
        //}


        //public List<string> pathweb(List<PahtFile> pahts)
        //{
        //    List<string> str = new List<string>();
        //    foreach (var item in pahts)
        //    {
        //        var path = Path.Combine(item.MLMC, item.CCMC);
        //        str.Add(PathHelper.AddWebAttPathValue(path));
        //    }
        //    return str;
        //}



        //#region
        ////// GET api/<ValuesHomeController>/5
        ////[HttpGet("{id}")]
        ////public string Get(int id)
        ////{
        ////    return "value";
        ////}

        ////// POST api/<ValuesHomeController>
        ////[HttpPost]
        ////public void Post([FromBody] string value)
        ////{
        ////}

        ////// PUT api/<ValuesHomeController>/5
        ////[HttpPut("{id}")]
        ////public void Put(int id, [FromBody] string value)
        ////{
        ////}

        ////// DELETE api/<ValuesHomeController>/5
        ////[HttpDelete("{id}")]
        ////public void Delete(int id)
        ////{
        ////}
        //#endregion
    }

    public class ExportExcel_NPOI
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
                        //if (column.ColumnName.ToUpper() == "审核状态")
                        //{
                        //    if (drValue == "0")
                        //    {
                        //        newCell.SetCellValue("待审核");
                        //    }
                        //    if (drValue == "1")
                        //    {
                        //        newCell.SetCellValue("已通过");
                        //    }
                        //    if (drValue == "2")
                        //    {
                        //        newCell.SetCellValue("未通过");
                        //    }
                        //    if (drValue == "3")
                        //    {
                        //        newCell.SetCellValue("未提交");
                        //    }
                        //}
                        //else
                        //{
                        //    int.TryParse(drValue, out intV);
                        //    newCell.SetCellValue("");
                        //}


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
    }

    public class GlyjcRcxcycjlDto
    {
        public string Id { get; set; }
        public string Cjrid { get; set; }
        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CJRXM { get; set; }
        public DateTime? Cjsj { get; set; }
        //public string Shrid { get; set; }
        //public string SHRXM { get; set; }
        //public DateTime? Shsj { get; set; }
        public sbyte? Shzt { get; set; }
        public string Shzt_DESC { get; set; }
        //public string Shbtgsm { get; set; }
        //public sbyte? Sfkdj { get; set; }
        //public string Djrid { get; set; }
        //public string DJRXM { get; set; }
        //public DateTime? Djsj { get; set; }
        public sbyte? Sfydj { get; set; }
        public string Shyc { get; set; }
        public string Tjrid { get; set; }
        public string TJRXM { get; set; }
        public DateTime? Tjsj { get; set; }
        public string Ycjcrid { get; set; }
        public string YCJCRXM { get; set; }
        public DateTime? Xcrq { get; set; }
        public string Ycsj { get; set; }
        public string Yczb { get; set; }
        public string Xcy { get; set; }
        public string XCYXM { get; set; }
        public string Dscqdcs { get; set; }
        public string Rwid { get; set; }
        public string Zpmc { get; set; }
        public string ZpmcPath { get; set; }
        public string Sfbj { get; set; }
        public string SFBJ_DESC { get; set; }
        //public string Ycysid { get; set; }
        public string YCYSID_DESC { get; set; }
        public string Sjms { get; set; }
        public string Yclx { get; set; }
        public string YCLX_DESC { get; set; }
        public string Sjcjfs { get; set; }
        public string SJCJFS_DESC { get; set; }
        public string Jchzp { get; set; }
        public string JchzpPath { get; set; }
        public DateTime? Jcsj { get; set; }
        public string Ycsfjc { get; set; }
        public string YCSFJC_DESC { get; set; }
        //public string Pg { get; set; }
        public string Fswzwz { get; set; }
        public double? Jd { get; set; }
        public double? Wd { get; set; }
        //public string Rcxcjlid { get; set; }
        //public string Xgjlid { get; set; }
        public string Qyid { get; set; }
        public string QYID_DESC { get; set; }
        //public string Bz { get; set; }
        //public string Dycdyxcd { get; set; }
        //public string DYCDYXCD_DESC { get; set; }
        //public string Ysclzp { get; set; }
        public int? Sort { get; set; }
        public string Xcdid { get; set; }
        public string XCDMC { get; set; }
    }

    public class PahtFile
    {
        public string MLMC { get; set; }
        public string CCMC { get; set; }
    }

}
