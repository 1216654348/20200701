using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Asp.NetCoreApi.NPOI;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.NetCoreApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //// GET: api/<ValuesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    //return new string[] { "value1", "value2" };
        //    kls_monitorContext kls_MonitorContext = new kls_monitorContext();//上下文对象
        //    var dataTable = new ImportExcel().Import(@"C:\Users\wangpeng\Desktop\123456.xlsx", 0);
        //    //列Columns0 Columns1   遗产要素名称      人员姓名
        //    var datalist = dataTable.Rows.Cast<DataRow>().Select(e => new YcysAndUser { Ycysmc = e["Columns0"] + "", UserName = e["Columns1"] + "" }).ToList();
        //    var ycysqd = kls_MonitorContext.GlyjcYcysqd.Where(e => datalist.Select(c => c.Ycysmc).Contains(e.Ycysmc)).ToList();//遗产要素清单
        //    var userinfo = kls_MonitorContext.OrgUserinfo.Where(e => datalist.Select(c => c.UserName).Contains(e.Realname)).ToList();//员工
        //    foreach (var item in datalist)
        //    {
        //        item.YcysId = ycysqd.Where(e => e.Ycysmc == item.Ycysmc).FirstOrDefault()?.Id;
        //        item.UserId = userinfo.Where(e => e.Realname == item.UserName).FirstOrDefault()?.Id;
        //        item.BmName = userinfo.Where(e => e.Realname == item.UserName).FirstOrDefault()?.Departmentid;
        //    }
        //    #region 异常数据
        //    var isnull = datalist.Where(e => string.IsNullOrEmpty(e.YcysId) || string.IsNullOrEmpty(e.UserId)).ToList();
        //    if (isnull.Count > 0)
        //    {
        //        var json = JsonConvert.SerializeObject(isnull);
        //        var test = JsonConvert.DeserializeObject<DataTable>(json);
        //    }
        //    #endregion


        //    //datalist   76日常巡查记录      112遗产要素单体影像图监测数据        22病害分布图及病害调查监测工作情况记录
        //    var jcpz = kls_MonitorContext.GlyjcJcpz.Where(e => e.Jcx == "76" || e.Jcx == "112" || e.Jcdxjtbwszbid == "22").AsNoTracking().ToList();
        //    foreach (var item in jcpz)
        //    {
        //        var name = datalist.Where(e => e.YcysId == item.Jcdxid).FirstOrDefault()?.UserId;
        //        if (!string.IsNullOrEmpty(name))
        //        {
        //            item.Sjcjfzrid = name;
        //        }
        //        var bmname = datalist.Where(e => e.YcysId == item.Jcdxid).FirstOrDefault()?.BmName;
        //        if (!string.IsNullOrEmpty(bmname))
        //        {
        //            item.Sjcjfzrbmid = bmname;
        //        }
        //    }
        //    var isnulls = jcpz.Where(e => string.IsNullOrEmpty(e.Sjcjfzrid)).Select(e => new { e.Id, e.Jcx, e.Jcdxid, e.Jcdxjtbwszbid }).ToList();
        //    if (isnulls.Count > 0)
        //    {
        //        var jsons = JsonConvert.SerializeObject(isnulls);
        //        var tests = JsonConvert.DeserializeObject<DataTable>(jsons);
        //    }
        //    kls_MonitorContext.UpdateRange(jcpz);
        //    var result = kls_MonitorContext.SaveChanges();
        //    return null;
        //}
        //#region
        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        //#endregion

        public void Get()
        {
            string BusinessJsonStr = "{\"DATA\":[{\"YCDSJID\":\"123456\",\"GLYCBTID\":11030,\"LYJDID\":\"123456\",\"JCSJ\":\"2020-07-22 00:00:00\",\"ZPMC\":null,\"SM\":null,\"TPLJ\":null,\"SCRID\":\"f69d2068-9767-472f-8bb2-a04fa3d8055f\",\"SCSJ\":\"f69d2068-9767-472f-8bb2-a04fa3d8055f\",\"PZRID\":null,\"PZSJ\":null,\"SJMJ\":null,\"FBFW\":null,\"XZCS\":null}],\"FILEPATHLIST\":[{\"YCDSJID\":\"123456\",\"FileID\":\"1c55df07-1def-45c2-8802-2ee23f4841fd\"}]}";
            var className1 = "WebApplication1.Controllers.HPF_LYYYKGL_KLGFSDXCZP";
            var className2 = "WebApplication1.Controllers.HPF_LYYYKGL_LYJD";
            var cType1 = Type.GetType(className1);
            var cType2 = Type.GetType(className2);
            var typeMaster = typeof(DockResultDataDataDetailModel<,>);
            var eType = typeMaster.MakeGenericType(cType1, cType2);
            var ent = DeserializeJsonToDynamicObject(BusinessJsonStr, eType);
        }

        public static dynamic DeserializeJsonToDynamicObject(string json, Type t)
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            dynamic o = serializer.Deserialize(new JsonTextReader(sr), t);
            return o;
        }
    }

    /// </summary>
    /// 数据主表+明细表+附件
    ///  </summary>
    public class DockResultDataDataDetailModel<T1, T2> where T1 : class where T2 : class
    {
        public List<T1> DATA { set; get; }
        /// <summary>
        /// 返回结果数据的关联子表
        /// </summary>
        public List<T2> DATADETAIL { set; get; }
        public List<FileInfoEx> FILEPATHLIST { set; get; }
    }

    public class FileInfoEx
    {
        public string FILETYPE { get; set; }
        public string YCDSJID { get; set; }
        public string RELATIVEPATH { get; set; }
        public string FILENAME { get; set; }
        public string FILEID { get; set; }
        public string LX { get; set; }

    }


    /// <summary>
    /// 旅游景点_客流高峰时段现场照片
    /// </summary>
    public class HPF_LYYYKGL_KLGFSDXCZP
    {
        public string ID { get; set; }

        public string LYJDID { get; set; }

        public DateTime? JCSJ { get; set; }

        public string ZPMC { get; set; }

        public string SM { get; set; }

        public string TPLJ { get; set; }

        public string SCRID { get; set; }

        public DateTime? SCSJ { get; set; }

        public string TPGS { get; set; }

        public string PZRID { get; set; }

        public DateTime? PZSJ { get; set; }

        public string CJDZBXX { get; set; }

        public string SJMJ { get; set; }

        public string FBFW { get; set; }

        public string XZCS { get; set; }

        public string SHRID { get; set; }

        public DateTime? SHSJ { get; set; }

        public string SHZT { get; set; }

        public string SHBTGSM { get; set; }

        public string SHYC { get; set; }

        public string YCDSJID { get; set; }

        public DateTime? RKSJ { get; set; }
        public string GLYCBTID { get; set; }
    }

    /// <summary>
    /// 旅游景点
    /// </summary>
    public class HPF_LYYYKGL_LYJD
    {

        public string ID { get; set; }

        public string GLYCBTID { get; set; }

        public string MC { get; set; }

        public string SM { get; set; }

        public double? JD { get; set; }

        public double? WD { get; set; }

        public string XQURL { get; set; }

        public string CJRID { get; set; }

        public DateTime? CJSJ { get; set; }
        public string WZSM { get; set; }

        public string SHRID { get; set; }

        public DateTime? SHSJ { get; set; }

        public string SHZT { get; set; }

        public string SHBTGSM { get; set; }

        public string SHYC { get; set; }

        public string DJRID { get; set; }

        public DateTime? DJSJ { get; set; }

        public string SFYDJ { get; set; }

        public string YCDSJID { get; set; }

        public DateTime? RKSJ { get; set; }
        public string YCYSBM { get; set; }

    }


    public class YcysAndUser
    {
        public string Ycysmc { get; set; }
        public string YcysId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string BmName { get; set; }
    }
}
