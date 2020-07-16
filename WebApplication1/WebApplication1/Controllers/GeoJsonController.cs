using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeoJSON.Net.Geometry;
using WebApplication1.NPOI;
using WebApplication1.Extension;
using WebApplication1.IService;
using System.Data;
using WebApplication1.LZModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GeoJsonController : ControllerBase
    {
        //public readonly IRepository _repository;

        //public GeoJsonController(IRepository repository)
        //{
        //    _repository = repository;
        //}


        //[HttpGet]
        //public ActionResult Get()
        //{
        //    var sbqd = _repository.Current<LZModel.GlyjcSbqd>().AsNoTracking().ToList();//设备清单
        //    //ColumnToNote.DtColumnZH()
        //    var trsqdt = _repository.GetDataTableResult("select a.ID,a.PARAID,a.JCSJ,a.JCZ,a.JSSJ,a.CJSJ,a.YSSJID,b.SBID,b.JCSD,b.JCFX,b.JCZBMC from glyjc_trsq a left join glyjc_jksjjrpzb b on a.PARAID=b.PARAID where a.JCSJ between '2020-07-08 00:00:00' and '2020-07-08 23:59:59'");
        //    var trsqdata = trsqdt.Rows.Cast<DataRow>().Select(e => new TrsqData { ID = e["ID"] + "", PARAID = e["PARAID"] + "", JCSJ = e["JCSJ"] + "", JCZ = e["JCZ"] + "", JSSJ = e["JSSJ"] + "", CJSJ = e["CJSJ"] + "", YSSJID = e["YSSJID"] + "", SBID = e["SBID"] + "", JCSD = e["JCSD"] + "", JCFX = e["JCFX"] + "", JCZBMC = e["JCZBMC"] + "" }).ToList();
        //    List<ExprotToDt> dtSources = new List<ExprotToDt>();//Excel 集合
        //    var sbqdtrsq = sbqd.Where(e => e.Lx == "14" && trsqdata.Select(c => c.SBID).Contains(e.Id)).ToList();
        //    foreach (var item in sbqdtrsq)
        //    {
        //        var trsqitem = trsqdata.Where(e => e.SBID == item.Id).OrderBy(e => e.JCSD).ThenBy(e => e.JCFX).ThenBy(e => e.JCZBMC).ThenBy(e => e.JCSJ).ToList();
        //        foreach (var it in trsqitem)
        //        {
        //            it.SBID_DESC = item.Sbmc;
        //        }
        //        var json = JsonConvert.SerializeObject(trsqitem);
        //        var datatable = JsonConvert.DeserializeObject<DataTable>(json);
        //        List<DtatableField> fields = new List<DtatableField>();
        //        #region
        //        fields.Add(new DtatableField() { Column = "ID", Value = "主键ID" });
        //        fields.Add(new DtatableField() { Column = "PARAID", Value = "" });
        //        fields.Add(new DtatableField() { Column = "JCSJ", Value = "监测时间" });
        //        fields.Add(new DtatableField() { Column = "JCZ", Value = "监测值" });
        //        fields.Add(new DtatableField() { Column = "JSSJ", Value = "接收时间" });
        //        fields.Add(new DtatableField() { Column = "CJSJ", Value = "创建时间" });
        //        fields.Add(new DtatableField() { Column = "YSSJID", Value = "原始数据ID" });
        //        fields.Add(new DtatableField() { Column = "SBID", Value = "" });
        //        fields.Add(new DtatableField() { Column = "JCSD", Value = "监测深度" });
        //        fields.Add(new DtatableField() { Column = "JCFX", Value = "监测方向" });
        //        fields.Add(new DtatableField() { Column = "JCZBMC", Value = "监测指标名称" });
        //        fields.Add(new DtatableField() { Column = "SBID_DESC", Value = "设备名称" });
        //        #endregion
        //        new ColumnToNote(_repository).DtColumnArray(datatable, fields);
        //        dtSources.Add(new ExprotToDt() { Data = datatable, SheetName = item.Sbmc });
        //    }
        //    var export = ExportExcel.ExportByte(dtSources, null);
        //    //var jklist = new List<string>() { "331", "330" };//基康
        //    return File(export, "application/octet-stream", "0708土壤墒情" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        //}

        //[HttpGet]
        //public ActionResult Get1()
        //{
        //    var sbqd = _repository.Current<LZModel.GlyjcSbqd>().AsNoTracking().ToList();//设备清单
        //    //ColumnToNote.DtColumnZH()
        //    var swdt = _repository.GetDataTableResult("select a.ID,a.PARAID,a.JCSJ,a.JCZ,a.JSSJ,a.CJSJ,a.YSSJID,b.SBID,b.JCZBMC from glyjc_shuiwei a left join glyjc_jksjjrpzb b on a.PARAID=b.PARAID where a.JCSJ between '2020-06-01 00:00:00' and '2020-07-16 10:55:00'");
        //    var swdata = swdt.Rows.Cast<DataRow>().Select(e => new ShuiWeiData { ID = e["ID"] + "", PARAID = e["PARAID"] + "", JCSJ = e["JCSJ"] + "", JCZ = e["JCZ"] + "", JSSJ = e["JSSJ"] + "", CJSJ = e["CJSJ"] + "", YSSJID = e["YSSJID"] + "", SBID = e["SBID"] + "", JCZBMC = e["JCZBMC"] + "", }).ToList();
        //    List<ExprotToDt> dtSources = new List<ExprotToDt>();//Excel 集合
        //    List<string> str = new List<string>() { "11", "12" };
        //    var sbqdtrsq = sbqd.Where(e => str.Contains(e.Lx) && swdata.Select(c => c.SBID).Contains(e.Id)).ToList();
        //    var count = 0;
        //    foreach (var item in sbqdtrsq)
        //    {
        //        var trsqitem = swdata.Where(e => e.SBID == item.Id).OrderBy(e => e.JCZBMC).ThenBy(e => e.JCSJ).ToList();
        //        foreach (var it in trsqitem)
        //        {
        //            it.SBID_DESC = item.Sbmc;
        //        }
        //        var json = JsonConvert.SerializeObject(trsqitem);
        //        var datatable = JsonConvert.DeserializeObject<DataTable>(json);
        //        List<DtatableField> fields = new List<DtatableField>();
        //        #region
        //        fields.Add(new DtatableField() { Column = "ID", Value = "主键ID" });
        //        fields.Add(new DtatableField() { Column = "PARAID", Value = "" });
        //        fields.Add(new DtatableField() { Column = "JCSJ", Value = "监测时间" });
        //        fields.Add(new DtatableField() { Column = "JCZ", Value = "监测值" });
        //        fields.Add(new DtatableField() { Column = "JSSJ", Value = "接收时间" });
        //        fields.Add(new DtatableField() { Column = "CJSJ", Value = "创建时间" });
        //        fields.Add(new DtatableField() { Column = "YSSJID", Value = "原始数据ID" });
        //        fields.Add(new DtatableField() { Column = "SBID", Value = "" });
        //        fields.Add(new DtatableField() { Column = "SBID_DESC", Value = "设备名称" });
        //        fields.Add(new DtatableField() { Column = "JCZBMC", Value = "监测指标名称" });
        //        #endregion
        //        new ColumnToNote(_repository).DtColumnArray(datatable, fields);
        //        dtSources.Add(new ExprotToDt() { Data = datatable, SheetName = item.Sbmc });
        //        count = count + datatable.Rows.Count;
        //    }
        //    var test = dtSources.Select(e => e.Data.Rows.Count);
        //    var export = ExportExcel.ExportByte(dtSources, null);
        //    //var jklist = new List<string>() { "331", "330" };//基康
        //    return File(export, "application/octet-stream", "0601-0716水位(地下地表)" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        //}

    }



    public class TrsqData
    {
        public string ID { get; set; }
        public string PARAID { get; set; }
        public string JCSJ { get; set; }
        public string JCZ { get; set; }
        public string JSSJ { get; set; }
        public string CJSJ { get; set; }
        public string YSSJID { get; set; }
        public string SBID { get; set; }
        public string SBID_DESC { get; set; }
        public string JCSD { get; set; }
        public string JCFX { get; set; }
        public string JCZBMC { get; set; }
    }

    public class ShuiWeiData
    {
        //ID
        //PARAID
        //JCSJ
        //JCZ
        //JSSJ
        //CJSJ
        //YSSJID
        //SBID
        //JCZBMC
        public string ID { get; set; }
        public string PARAID { get; set; }
        public string JCSJ { get; set; }
        public string JCZ { get; set; }
        public string JSSJ { get; set; }
        public string CJSJ { get; set; }
        public string YSSJID { get; set; }
        public string SBID { get; set; }
        public string SBID_DESC { get; set; }
        public string JCZBMC { get; set; }

    }

}
