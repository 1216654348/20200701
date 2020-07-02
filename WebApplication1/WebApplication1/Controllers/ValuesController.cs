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
using WebApplication1.Model;
using WebApplication1.NPOI;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
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
