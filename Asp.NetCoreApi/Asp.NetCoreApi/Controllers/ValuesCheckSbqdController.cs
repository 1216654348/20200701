using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Asp.NetCoreApi.Extension;
using Asp.NetCoreApi.IService;
using Asp.NetCoreApi.NPOI;

namespace Asp.NetCoreApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesCheckSbqdController : ControllerBase
    {
        private readonly IRepository _repository;
        public ValuesCheckSbqdController(IRepository repository)
        {
            this._repository = repository;
        }
        #region
        //private readonly IRepository _repository;
        //public ValuesCheckSbqdController(IRepository repository)
        //{
        //    this._repository = repository;
        //}

        //public FileResult Get()
        //{
        //    var config = _repository.Current<JieruConfig>().ToList();//配置表
        //    var sbqd = (from c in _repository.Current<GlyjcSblx>() join d in _repository.Current<GlyjcSbqd>() on c.Id equals d.Lx select new { d.Id, c.Mc, d.Sbmc }).ToList();//设备清单
        //    var ywbysj = _repository.Current<YsjYwbysj>().ToList();//业务表元数据
        //    //37-局部环境(城址区、老虎岭)  328-实时天气(瓶窑、良渚、安溪、凤都)  321-大气质量时报(空气质量指数)
        //    //331-地下水位和地表水位  31-水质
        //    //330-土壤墒情
        //    var jcdlist = new List<JcdSbqd>() {
        //        new JcdSbqd(){ ID = "37", Field = "ID,JCSJ,YL,DQWD,SZQY,DQSD,FX,FS", Date = "JCSJ" },
        //        new JcdSbqd() { ID = "328", Field = "ID,TIME,RAIN,TEMP,PRESSURE,HUMIDITY,WIND_DIRECTION,WIND_SPEED",Date="TIME" } ,
        //        new JcdSbqd(){ ID="321" ,Field="ID,REPORT_DATE,AQI,AQI_LB_COLOR",Date="REPORT_DATE"} ,
        //        new JcdSbqd(){ ID="31",Field="ID,JCSJ,RJY,ZD,PH,DDL",Date="JCSJ"}
        //    };//监测点
        //    List<ExprotToDt> dataTables = new List<ExprotToDt>();
        //    foreach (var item in jcdlist)
        //    {
        //        var jcdconfig = config.Where(e => e.GrabType == item.ID).ToList();
        //        var tablename = ywbysj.Where(e => e.Id == item.ID).FirstOrDefault()?.Bmc;
        //        if (string.IsNullOrWhiteSpace(tablename)) continue;
        //        var sbidls = jcdconfig.GroupBy(e => e.Fkey).Select(e => e.Key);
        //        foreach (var sbls in sbidls)
        //        {
        //            var sb = sbqd.Where(e => e.Id == sbls).FirstOrDefault();
        //            if (sb == null) continue;
        //            var sql = $"select {item.Field} from {tablename} where jcdid='{sbls}' order by {item.Date} desc limit 0,100";
        //            var dt = _repository.GetDataTableResult(sql);
        //            dt = new ColumnToNote(_repository).DtColumnZH(dt, "lzjc", tablename);
        //            dataTables.Add(new ExprotToDt() { Data = dt, SheetName = sb.Mc + "-" + sb.Sbmc });
        //        }
        //    }
        //    var export = ExportExcel.ExportByte(dataTables, null);
        //    //var jklist = new List<string>() { "331", "330" };//基康
        //    return File(export, "application/octet-stream", DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        //}

        //private readonly IRepository _repository;
        //public ValuesCheckSbqdController(IRepository repository)
        //{
        //    this._repository = repository;
        //}
        #endregion
        public FileResult Get()
        {
            var sql = "select a.id '主键ID',a.CYKSSJ '采样开始时间',PH 'PH值',a.CJSJ '创建时间',SJDID,b.ID 'JCDID',b.MC from jieru_syysj a LEFT join wbjrdx_syjcd b on a.SJDID=b.id where shzt='2' order by CYKSSJ desc";
            var dt = _repository.GetDataTableResult(sql);
            var jcdlist = dt.Rows.Cast<DataRow>().Select(e => new { ID = e["JCDID"] + "", MC = e["MC"] + "" }).Distinct().ToList();
            dt.Columns.Remove("JCDID");
            dt.Columns.Remove("MC");
            List<ExprotToDt> dataTables = new List<ExprotToDt>();
            foreach (var item in jcdlist)
            {
                var dtnew = dt.Select($"SJDID='{item.ID}'").CopyToDataTable();
                dataTables.Add(new ExprotToDt() { Data = dt, SheetName = item.MC + "(" + dtnew.Rows.Count + ")" });
            }
            var export = ExportExcel.ExportByte(dataTables, null);
            return File(export, "application/octet-stream", $"酸雨监测(外部接入{dt.Rows.Count})" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }

        public FileResult Get1()
        {
            var sql = "select a.ID '主键ID',a.SWJCZID,a.jcsj '监测时间',a.sssw '实时水位',a.cjsj '创建时间',b.id 'JCDID',b.MC from wbjrsj_swjcd a LEFT join wbjrdx_swjcd b on a.swjczid=b.id where a.shzt='2' order by a.jcsj desc";
            var dt = _repository.GetDataTableResult(sql);
            var jcdlist = dt.Rows.Cast<DataRow>().Select(e => new { ID = e["JCDID"] + "", MC = e["MC"] + "" }).Distinct().ToList();
            dt.Columns.Remove("JCDID");
            dt.Columns.Remove("MC");
            List<ExprotToDt> dataTables = new List<ExprotToDt>();
            foreach (var item in jcdlist)
            {
                var dtnew = dt.Select($"SWJCZID='{item.ID}'").CopyToDataTable();
                dataTables.Add(new ExprotToDt() { Data = dt, SheetName = item.MC + "(" + dtnew.Rows.Count + ")" });
            }
            var export = ExportExcel.ExportByte(dataTables, null);
            return File(export, "application/octet-stream", $"水位监测(外部接入{dt.Rows.Count})" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }

        public FileResult Get2()
        {
            var sql = "select a.id '主键ID',a.SZJCDID,a.jcsj '监测时间',a.PH 'PH值',a.ddl '电导率',a.CJSJ '创建时间',B.ID 'JCDID',B.MC from zdjcsj_szjcd a LEFT join zdjcdx_szjcd b on a.szjcdid=b.id where a.shzt='2' order by a.jcsj desc";
            var dt = _repository.GetDataTableResult(sql);
            var jcdlist = dt.Rows.Cast<DataRow>().Select(e => new { ID = e["JCDID"] + "", MC = e["MC"] + "" }).Distinct().ToList();
            dt.Columns.Remove("JCDID");
            dt.Columns.Remove("MC");
            List<ExprotToDt> dataTables = new List<ExprotToDt>();
            foreach (var item in jcdlist)
            {
                var dtnew = dt.Select($"SZJCDID='{item.ID}'").CopyToDataTable();
                dataTables.Add(new ExprotToDt() { Data = dt, SheetName = item.MC + "(" + dtnew.Rows.Count + ")" });
            }
            var export = ExportExcel.ExportByte(dataTables, null);
            return File(export, "application/octet-stream", $"水质监测(站点监测{dt.Rows.Count})" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }

        public FileResult Get3()
        {
            var sql = "select a.report_date '发布时间',so2_24h_density '二氧化硫（SO2）24小时平均浓度',no2_24h_density '二氧化氮（NO2）24小时平均浓度',a.klw_24h_subindex '颗粒物（粒径<=10µm）24小时平均分指数',co_24h_density '一氧化碳（CO）24小时平均浓度',o3_1h_density '臭氧（O3）1小时平均浓度',klw2d5_24h_density '颗粒物（粒径<=2.5µm）24小时平均浓度',a.aqi '空气质量指数（AQI）',major_pollutant '首要污染物',aqi_class '空气质量指数级别',aqi_lb_lb '空气质量指数类别（类别）',aqi_lb_color '空气质量指数类别颜色',a.CJSJ '创建时间',a.id '主键ID',xzqbm,b.id 'JCDID',B.MC from jieru_aqi_report_day a LEFT join wbjrdx_xzqdqzld b on a.xzqbm=b.id where a.shzt='2' order by a.report_date desc";
            var dt = _repository.GetDataTableResult(sql);
            var jcdlist = dt.Rows.Cast<DataRow>().Select(e => new { ID = e["JCDID"] + "", MC = e["MC"] + "" }).Distinct().ToList();
            dt.Columns.Remove("JCDID");
            dt.Columns.Remove("MC");
            List<ExprotToDt> dataTables = new List<ExprotToDt>();
            foreach (var item in jcdlist)
            {
                var dtnew = dt.Select($"XZQBM='{item.ID}'").CopyToDataTable();
                dataTables.Add(new ExprotToDt() { Data = dt, SheetName = item.MC + "(" + dtnew.Rows.Count + ")" });
            }
            var export = ExportExcel.ExportByte(dataTables, null);
            return File(export, "application/octet-stream", $"大气质量(外部接入{dt.Rows.Count})" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }

        public FileResult Get4()
        {
            var sql = "select a.id '主键ID',a.ZKWDJCDID,a.jcsj '监测时间',a.wd1 '温度1',a.wd2 '温度2',a.wd3 '温度3',a.wd4 '温度4',a.wd5 '温度5',a.wd6 '温度6',a.wd7 '温度7',a.wd8 '温度8','大气平均温度' dqpjwd,wc1 '温差1',wc2 '温差2',wc3 '温差3',wc4 '温差4',wc5 '温差5',wc6 '温差6',wc7 '温差7',a.cjsj '创建时间',b.id 'JCDID',b.mc from zdjcsj_zkwdjcd a LEFT join zdjcdx_zkwdjcd b on a.zkwdjcdid=b.id where a.shzt='2' order by a.JCSJ desc";
            var dt = _repository.GetDataTableResult(sql);
            var jcdlist = dt.Rows.Cast<DataRow>().Select(e => new { ID = e["JCDID"] + "", MC = e["MC"] + "" }).Distinct().ToList();
            dt.Columns.Remove("JCDID");
            dt.Columns.Remove("MC");
            List<ExprotToDt> dataTables = new List<ExprotToDt>();
            foreach (var item in jcdlist)
            {
                var dtnew = dt.Select($"ZKWDJCDID='{item.ID}'").CopyToDataTable();
                dataTables.Add(new ExprotToDt() { Data = dt, SheetName = item.MC + "(" + dtnew.Rows.Count + ")" });
            }
            var export = ExportExcel.ExportByte(dataTables, null);
            return File(export, "application/octet-stream", $"钻孔温度(站点监测{dt.Rows.Count})" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }

        public FileResult Get5SSSSSSSSSS()
        {
            var sql = "select a.ID '主键ID',a.SJ '时间',a.WD '环境温度（℃）',a.SD '环境湿度（%）',a.LD '露点温度（℃）',a.QY '气压（pa）',a.JSL '降水量（mm）',a.FS '风速（m/s）',a.CO2 '二氧化碳',a.FX '风向（360°，正北方向为0，顺时针增大）',a.FL '风力',a.LFZFS '两分钟风速（m/s）',a.SFZFS '十分钟风速（m/s）',a.SSZFS '瞬时总辐射',a.SSSFS '瞬时散辐射',a.SSZJFS '瞬时直接辐射',a.SSFFS '瞬时反辐射',a.SSJFS '瞬时净辐射',a.SSZWFS '瞬时紫外辐射',a.LJZFS '累计总辐射',a.LJSFS '累计散辐射',a.LJZJFS '累计直接辐射',a.LJFSJ '累计反辐射',a.LJJFS '累计净辐射',a.LJZWFS '累计紫外辐射',a.RZS '日照时',a.CJSJ '创建时间',a.JCDID,b.id 'JCDID1',b.mc from glyjc_whj a LEFT join zdjcdx_whjjcd b on a.JCDID=b.id where a.shzt='2' order by a.SJ desc";
            var dt = _repository.GetDataTableResult(sql);
            var jcdlist = dt.Rows.Cast<DataRow>().Select(e => new { ID = e["JCDID1"] + "", MC = e["MC"] + "" }).Distinct().ToList();
            dt.Columns.Remove("JCDID1");
            dt.Columns.Remove("MC");
            List<ExprotToDt> dataTables = new List<ExprotToDt>();
            foreach (var item in jcdlist)
            {
                var dtnew = dt.Select($"JCDID='{item.ID}'").CopyToDataTable();
                dataTables.Add(new ExprotToDt() { Data = dt, SheetName = item.MC + "(" + dtnew.Rows.Count + ")" });
            }
            var export = ExportExcel.ExportByte(dataTables, null);
            return File(export, "application/octet-stream", $"微环境(站点监测{dt.Rows.Count})" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }

        public FileResult Get6()
        {
            var sql = "select a.time '发布时间',a.temp '当前气温，摄氏度',a.rain '一小时内的降雨量',a.wind_direction '风向',a.wind_desc '风向描述',a.wind_speed '风速',a.humidity '当前湿度',a.pressure '气压',a.visibility '能见度，单位为米',a.CJSJ '创建时间',a.ID '主键ID',a.rain_24 '24小时降雨量',a.XZQBM,b.id 'JCDID',B.MC from jieru_weather_live a LEFT join wbjrdx_xzqqx b on a.xzqbm=b.id where a.shzt='2' order by a.time desc";
            var dt = _repository.GetDataTableResult(sql);
            var jcdlist = dt.Rows.Cast<DataRow>().Select(e => new { ID = e["JCDID"] + "", MC = e["MC"] + "" }).Distinct().ToList();
            dt.Columns.Remove("JCDID");
            dt.Columns.Remove("MC");
            List<ExprotToDt> dataTables = new List<ExprotToDt>();
            foreach (var item in jcdlist)
            {
                var dtnew = dt.Select($"XZQBM='{item.ID}'").CopyToDataTable();
                dataTables.Add(new ExprotToDt() { Data = dt, SheetName = item.MC + "(" + dtnew.Rows.Count + ")" });
            }
            var export = ExportExcel.ExportByte(dataTables, null);
            return File(export, "application/octet-stream", $"天气实况(外部接入{dt.Rows.Count})" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }

        public FileResult Get7()
        {
            var sql = "select a.id '主键ID',a.SZJCDID,a.sw '水温（度）',a.ph 'PH值',a.cod 'COD（mg/L）',a.bod 'BOD（mg/L）',a.zd '浊度(NTU)',a.szdj '水质等级',a.jcsj '监测时间',a.lrsj '录入时间',a.cjsj '创建时间',b.id 'JCDID',B.MC from wbjrsj_szjcd a LEFT join wbjrdx_szjcd b on a.szjcdid=b.id where a.shzt='2' order by a.jcsj desc";
            var dt = _repository.GetDataTableResult(sql);
            var jcdlist = dt.Rows.Cast<DataRow>().Select(e => new { ID = e["JCDID"] + "", MC = e["MC"] + "" }).Distinct().ToList();
            dt.Columns.Remove("JCDID");
            dt.Columns.Remove("MC");
            List<ExprotToDt> dataTables = new List<ExprotToDt>();
            foreach (var item in jcdlist)
            {
                var dtnew = dt.Select($"SZJCDID='{item.ID}'").CopyToDataTable();
                dataTables.Add(new ExprotToDt() { Data = dt, SheetName = item.MC + "(" + dtnew.Rows.Count + ")" });
            }
            var export = ExportExcel.ExportByte(dataTables, null);
            return File(export, "application/octet-stream", $"水质监测(外部接入{dt.Rows.Count})" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }

        public FileResult Get8()
        {
            var sql = "select a.id '主键ID',a.SSQYID,a.jcsj '监测时间',a.rhwzplj '热红外照片路径',a.kjgzplj '可见光照片路径',a.dlvwjlj 'DLV文件路径',a.cjsj '创建时间',b.id 'JCDID',b.mc from zdjcsj_ybssqy a LEFT join zdjcdx_ybssqy b on a.ssqyid=b.id where a.shzt='2' order by a.jcsj desc";
            var dt = _repository.GetDataTableResult(sql);
            var jcdlist = dt.Rows.Cast<DataRow>().Select(e => new { ID = e["JCDID"] + "", MC = e["MC"] + "" }).Distinct().ToList();
            dt.Columns.Remove("JCDID");
            dt.Columns.Remove("MC");
            List<ExprotToDt> dataTables = new List<ExprotToDt>();
            foreach (var item in jcdlist)
            {
                var dtnew = dt.Select($"SSQYID='{item.ID}'").CopyToDataTable();
                dataTables.Add(new ExprotToDt() { Data = dt, SheetName = item.MC + "(" + dtnew.Rows.Count + ")" });
            }
            var export = ExportExcel.ExportByte(dataTables, null);
            return File(export, "application/octet-stream", $"岩壁渗水区域(站点监测{dt.Rows.Count})" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }

        public FileResult Get9()
        {
            var sql = "select a.id '主键ID',a.CFJID,a.jcsj '监测时间',a.jcz '监测值',a.wd '温度',a.sfydj '是否已对接',a.cjsj '创建时间',b.ID JCDID,b.MC from zdjcsj_lfj a LEFT join zdjcdx_lfj b on a.cfjid=b.id where a.shzt='2' order by a.jcsj desc";
            var dt = _repository.GetDataTableResult(sql);
            var jcdlist = dt.Rows.Cast<DataRow>().Select(e => new { ID = e["JCDID"] + "", MC = e["MC"] + "" }).Distinct().ToList();
            dt.Columns.Remove("JCDID");
            dt.Columns.Remove("MC");
            List<ExprotToDt> dataTables = new List<ExprotToDt>();
            foreach (var item in jcdlist)
            {
                var dtnew = dt.Select($"CFJID='{item.ID}'").CopyToDataTable();
                dataTables.Add(new ExprotToDt() { Data = dt, SheetName = item.MC + "(" + dtnew.Rows.Count + ")" });
            }
            var export = ExportExcel.ExportByte(dataTables, null);
            return File(export, "application/octet-stream", $"测缝计(站点监测{dt.Rows.Count})" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }
    }

    internal class JcdSbqd
    {
        public string ID { get; set; }
        public string Field { get; set; }
        public string Date { get; set; }
    }

}
