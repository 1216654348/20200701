using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using WebApplication1.IService;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesHome1Controller : ControllerBase
    {
        //private readonly IRepository _repository;
        //public ValuesHome1Controller(IRepository repository)
        //{
        //    this._repository = repository;
        //}

        //public string Get()
        //{
        //    var c = "";
        //    //var sbqd = _repository.Current<GlyjcSbqd>().ToList();
        //    //var sbqdsql = _repository.GetDataTableResult("select * from glyjc_sbqd");
        //    var glslist = _repository.Current<GlyjcGls>().Where(e => e.Xcgj != null && e.Xcgj != "").AsNoTracking().ToList();
        //    List<GlyjcGls> glyjcGls = new List<GlyjcGls>();
        //    foreach (var item in glslist)
        //    {
        //        //if (string.IsNullOrEmpty(item.Xcgj)) continue;
        //        //var data = JsonConvert.DeserializeObject<List<List<double>>>(item.Xcgj);
        //        //foreach (var arritem in data)
        //        //{
        //        //    if (arritem.Count == 2)
        //        //    {
        //        //        var v1 = arritem[0];
        //        //        arritem[0] = arritem[1];
        //        //        arritem[1] = v1;
        //        //    }
        //        //    else
        //        //    {
        //        //        c = "数据异常";
        //        //    }
        //        //}
        //        //item.Xcgj = JsonConvert.SerializeObject(data);
        //        item.Xcgj = item.Xcgj.Replace("\"", "");
        //    }
        //    _repository.Current<GlyjcGls>().UpdateRange(glslist);
        //    var result = _repository.SaveChanges();

        //    return null;
        //}

        //public string UpdateXcgjJson()
        //{
        //    var c = "";
        //    var path = @"D:\Atest\XcgjJson\";
        //    var glslist = _repository.Current<GlyjcGls>().AsNoTracking().ToList();
        //    DirectoryInfo dir = new DirectoryInfo(path);
        //    FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
        //    List<GlyjcGls> data = new List<GlyjcGls>();
        //    int count = 0;
        //    foreach (var item in fileinfo)
        //    {
        //        var arr = GetRyidAndRq(item.Name);//文件名(人员ID和巡查时间)及后缀名     04b66e95293546f98fd45b15aca77ec0_2018-05-09.json
        //        if (arr.Count == 2)
        //        {
        //            DateTime.TryParse(arr[1], out DateTime dateTime);
        //            var gls = glslist.Where(e => e.Ryid == arr[0] && e.Rq == dateTime).ToList();
        //            if (gls.Count() > 1) c = item.FullName + "数据异常";
        //            if (gls.Count() == 0) continue;
        //            var glsfir = gls.FirstOrDefault();
        //            glsfir.Xcgj = GetJson(item.FullName);
        //            data.Add(glsfir);
        //        }
        //        else
        //        {
        //            c = item.FullName + "文件名异常";
        //        }
        //        count = count + 1;
        //        System.Diagnostics.Trace.WriteLine(count + "、" + item);
        //    }
        //    _repository.Current<GlyjcGls>().UpdateRange(data);
        //    var result = _repository.SaveChanges();
        //    return null;
        //}

        ///// <summary>
        ///// 根据文件名获取人员ID和时间
        ///// </summary>
        ///// <param name="filename">文件名(人员ID和巡查时间)及后缀名</param>
        ///// <returns>人员ID和时间</returns>
        //public List<string> GetRyidAndRq(string filename)
        //{
        //    filename = filename.Replace(".json", "");
        //    var arr = filename.Split('_').ToList();
        //    return arr;
        //}

        ///// <summary>
        ///// 读取Json文件(并调整经纬度顺序)
        ///// </summary>
        ///// <returns>经纬度json字符串</returns>
        //public string GetJson(string path)
        //{
        //    using (System.IO.StreamReader file = System.IO.File.OpenText(path))
        //    {
        //        var json = file.ReadToEnd();
        //        if (string.IsNullOrWhiteSpace(json)) return "";
        //        var data = JsonConvert.DeserializeObject<List<List<string>>>(json);
        //        foreach (var arritem in data)
        //        {
        //            if (arritem.Count == 2)
        //            {
        //                var v1 = arritem[0];
        //                arritem[0] = arritem[1];
        //                arritem[1] = v1;
        //            }
        //        }
        //        var strjson = JsonConvert.SerializeObject(data);
        //        strjson = strjson.Replace("\"", "");
        //        return strjson;
        //    }
        //}

        //#region 保存geo-json
        ////List<TYcysqdYsm> ycysqdYsms = new List<TYcysqdYsm>();
        ////var count = 0;
        //////读取.json文件数据
        ////using (System.IO.StreamReader file = System.IO.File.OpenText(path))
        ////{
        ////    using (JsonTextReader reader = new JsonTextReader(file))
        ////    {
        ////        JObject o = (JObject)JToken.ReadFrom(reader);
        ////        var features = o["features"];//数据
        ////        foreach (var item in features)
        ////        {
        ////            var type = item["type"] + "";//类型
        ////            var properties = item["properties"];//属性
        ////            var FID = properties["FID"] + "";
        ////            var Layer = properties["Layer"] + "";
        ////            var Name = properties["NAME"] + "";
        ////            var Shape_Leng = properties["Shape_Leng"] + "";
        ////            var Shape_Area = properties["Shape_Area"] + "";
        ////            decimal dData = 0;
        ////            if (Shape_Area.Contains("E"))
        ////            {
        ////                dData = Convert.ToDecimal(Decimal.Parse(Shape_Area, System.Globalization.NumberStyles.Float));
        ////            }
        ////            else
        ////            {
        ////                decimal.TryParse(Shape_Area, out dData);
        ////            }

        ////            var geometry = item["geometry"] + "";
        ////            if (!string.IsNullOrEmpty(geometry))
        ////            {
        ////                geometry = cleanString(geometry);
        ////            }
        ////            ycysqdYsms.Add(new TYcysqdYsm() { Id = Guid.NewGuid().ToString(), Fid = FID, Type = type, Layer = Layer, Name = Name, ShapeLeng = Shape_Leng, ShapeArea = dData.ToString(), Geometry = geometry, Rksj = DateTime.Now });
        ////            count = count + 1;
        ////            System.Diagnostics.Trace.WriteLine(count + ":" + Layer + ":" + Name);
        ////            if (count + ":" + Layer + ":" + Name == "77:外城遗址:金家台地群")
        ////            {
        ////                var a = 123;
        ////            }
        ////        }
        ////    }
        ////}
        ////_repository.Current<TYcysqdYsm>().AddRange(ycysqdYsms);
        ////var result = _repository.SaveChanges();
        ////var tr = result > 0;
        ////return new ResultModel(tr, tr ? "保存成功" : "保存失败", null);
        //#endregion
    }



    public class DataDto
    {
        public Dictionary<double, double> dic { get; set; }
    }


}
