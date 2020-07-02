using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Model;
using WebApplication1.NPOI;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// 地表覆盖数据导入
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SurfaceCoverController : ControllerBase
    {
        /// <summary>
        /// t_landcover  20200702085540
        /// </summary>
        public void Save()
        {
            LZModel.lzjcContext lzjcContext = new LZModel.lzjcContext();//上下文对象
            var dataTable = new ImportExcel().Import(@"E:\Atest\地表覆盖数据汇总-0701.xlsx", 1);
            var json = JsonConvert.SerializeObject(dataTable);
            var data = JsonConvert.DeserializeObject<List<LZModel.TLandcover>>(json);
            //分组统计每个年份隶属区域的地类面积总和
            var group = data.GroupBy(e => new { e.Nf, e.Lsqy }).Select(e => new { NF = e.Key.Nf, LSQY = e.Key.Lsqy, SUM = e.Select(c => c.Dlmj).Sum() }).ToList();
            var datetime = DateTime.Now;
            foreach (var item in data)
            {
                var SUM = group.Where(e => e.NF == item.Nf && e.LSQY == item.Lsqy).First().SUM;
                item.Mjzb = item.Dlmj / SUM * 100;
                item.Rksj = datetime;
            }
            lzjcContext.TLandcover.AddRange(data);
            var result = lzjcContext.SaveChanges();
            var c = 8989;
        }
    }
}
