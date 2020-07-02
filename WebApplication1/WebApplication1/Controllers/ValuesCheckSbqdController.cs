using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using WebApplication1.Extension;
using WebApplication1.IService;
using WebApplication1.NPOI;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesCheckSbqdController : ControllerBase
    {
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
    }

    internal class JcdSbqd
    {
        public string ID { get; set; }
        public string Field { get; set; }
        public string Date { get; set; }
    }

}
