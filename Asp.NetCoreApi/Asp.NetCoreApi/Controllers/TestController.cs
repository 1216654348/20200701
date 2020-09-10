using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Asp.NetCoreApi.Extension;
using Asp.NetCoreApi.HangFire;
using Asp.NetCoreApi.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.NetCoreApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //private readonly IRepository _repository;
        private readonly ITimerClass _timerClass;
        public TestController(IRepository repository, ITimerClass timerClass)
        {
            //this._repository = repository;
            _timerClass = timerClass;
        }
        //private static List<AngleDto> _angleDtos = new List<AngleDto>()
        //{
        //    new AngleDto(){Start = 337.6M,End = 22.5M,AngleName = "北"},
        //    new AngleDto(){Start = 22.6M,End = 67.5M,AngleName = "东北"},
        //    new AngleDto(){Start = 67.6M,End = 112.5M,AngleName = "东"},
        //    new AngleDto(){Start = 112.6M,End = 157.5M,AngleName = "东南"},
        //    new AngleDto(){Start = 157.6M,End = 202.5M,AngleName = "南"},
        //    new AngleDto(){Start = 202.6M,End = 247.5M,AngleName = "西南"},
        //    new AngleDto(){Start = 247.6M,End = 292.5M,AngleName = "西"},
        //    new AngleDto(){Start = 292.6M,End = 337.5M,AngleName = "西北"}
        //};


        //// GET: api/<TestController>
        //[HttpGet]
        //public IEnumerable<string> Get(string date)
        //{
        //    WebApplication1.LocalHostModel.lzjcContext lzjcContext = new WebApplication1.LocalHostModel.lzjcContext();
        //    TTempFkhx model = new TTempFkhx();
        //    model._1925.ToString();

        //    #region
        //    //var glslist = _repository.Current<GlyjcGls>().Take(1).AsNoTracking().ToList();
        //    //var cc = AutoMapper.Mapper.Map<GlyjcGlssss>(glslist.FirstOrDefault());
        //    //var dt = _repository.GetDataTableResult("select * from glyjc_gls");
        //    //var result = new ColumnToNote(_repository).DtColumnZH(dt, "lzjc", "glyjc_gls");
        //    #endregion

        //    #region
        //    //var c = "";
        //    //var rwb = _repository.Current<GlyjcRwb>().Where(e => e.Rwzt == "1").AsNoTracking().ToList();
        //    //var qdjlb = _repository.Current<GlyjcRcxcqdjlb>().AsNoTracking().ToList();
        //    //List<GlyjcRwb> glyjcRwbs = new List<GlyjcRwb>();
        //    //foreach (var item in rwb)
        //    //{
        //    //    var date = qdjlb.Where(e => e.Rwid == item.Id).ToList();
        //    //    if (date.Count > 1) c = item.Id + "数据异常";
        //    //    if (date.Count == 0) continue;
        //    //    item.Rwwcsj = date.FirstOrDefault().Cjsj;
        //    //    glyjcRwbs.Add(item);
        //    //}
        //    //_repository.Current<GlyjcRwb>().UpdateRange(glyjcRwbs);
        //    //var result = _repository.SaveChanges();
        //    #endregion

        //    decimal.TryParse(date, out decimal result);
        //    var fx = _angleDtos.Where(e => e.Start <= result && e.End >= result).ToList();

        //    return new string[] { "value1", "value2" };
        //}

        //public void GetT()
        //{


        //    System.Timers.Timer timer = new System.Timers.Timer();
        //    timer.Enabled = true;
        //    timer.Interval = 1000;
        //    timer.Start();
        //    timer.Elapsed += new System.Timers.ElapsedEventHandler(_timerClass.TryNewTasks);
        //    //_timerClass.TryNewTasks(null, null);
        //    Console.ReadKey();
        //}


        //#region
        ////// GET api/<TestController>/5
        ////[HttpGet("{id}")]
        ////public string Get(int id)
        ////{
        ////    return "value";
        ////}

        ////// POST api/<TestController>
        ////[HttpPost]
        ////public void Post([FromBody] string value)
        ////{
        ////}

        ////// PUT api/<TestController>/5
        ////[HttpPut("{id}")]
        ////public void Put(int id, [FromBody] string value)
        ////{
        ////}

        ////// DELETE api/<TestController>/5
        ////[HttpDelete("{id}")]
        ////public void Delete(int id)
        ////{
        ////}
        //#endregion
    }


    public class GlyjcGlssss
    {
        public string Id { get; set; }
        public string Ryid { get; set; }
        public string Gls { get; set; }
        public DateTime? Rq { get; set; }
        public string Sfzx { get; set; }
        public string Xcgj { get; set; }
        public DateTime? Rksj { get; set; }
    }

    public class AngleDto
    {
        public decimal Start { get; set; }
        public decimal End { get; set; }
        public string AngleName { get; set; }
    }
}
