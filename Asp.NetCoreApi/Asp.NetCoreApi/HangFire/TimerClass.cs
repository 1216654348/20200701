using Microsoft.AspNetCore.Mvc.Razor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Asp.NetCoreApi.IService;

namespace Asp.NetCoreApi.HangFire
{
    public class TimerClass : ITimerClass
    {
        public TimerClass(IRepository repository)
        {
            _repository = repository;
        }
        public readonly IRepository _repository;
        public void TryNewTasks(object source, ElapsedEventArgs e)
        {
            Test.str.Add(DateTime.Now);
            //var str = getHttpResponse(@"http://47.111.62.9:8686/log/api/v2/open/data/findSightseeingCarData");
            //var result = JsonConvert.DeserializeObject<LZResultDto>(str);
            //var strdata = result.data + "";
            //var data = JsonConvert.DeserializeObject<CzqGgclDataListDto>(strdata);
            //var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //var sqllist = new List<string>();
            //sqllist.Add($"INSERT INTO `lzjc`.`t_temp_ggcl_copy`(`ID`, `CJSJ`, `ALLUSESIGHTCARNUM`, `INUSESIGHTCARNUM`, `REMAINSIGHTCARNUM`, `FAULTSIGHTCARNUM`, `RKSJ`,`CHARGINGCARNUM`) VALUES ('{Guid.NewGuid().ToString()}', '{time}', '{data.allUseSightCarNum}', '{data.inUseSightCarNum}', '{data.remainSightCarNum}', '{data.faultSightCarNum}','{time}','{data.chargingCarNum}')");
            //var isSuccess = _repository.ExecuteTransactionSQLList(sqllist);
            var Universal = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;//当前时间的时间戳
            var str0 = getHttpResponse($"http://47.111.62.9:8089/GetGaodeData?RequestUrl=key=2d73234b0d947094c80a92f299892030|apiid=24|aoiid=W0000000GC|ds=202007111445|appname=travel-liangzhu|timestamp={Universal}");
            var str15 = getHttpResponse($"http://47.111.62.9:8089/GetGaodeData?RequestUrl=key=2d73234b0d947094c80a92f299892030|apiid=24|aoiid=W0000000GC|ds=202007111500|appname=travel-liangzhu|timestamp={Universal}");
            var str30 = getHttpResponse($"http://47.111.62.9:8089/GetGaodeData?RequestUrl=key=2d73234b0d947094c80a92f299892030|apiid=24|aoiid=W0000000GC|ds=202007111515|appname=travel-liangzhu|timestamp={Universal}");
            var str45 = getHttpResponse($"http://47.111.62.9:8089/GetGaodeData?RequestUrl=key=2d73234b0d947094c80a92f299892030|apiid=24|aoiid=W0000000GC|ds=202007111530|appname=travel-liangzhu|timestamp={Universal}");
            var s0 = JsonConvert.DeserializeObject<Result>(str0);
            var s15 = JsonConvert.DeserializeObject<Result>(str15);
            var s30 = JsonConvert.DeserializeObject<Result>(str30);
            var s45 = JsonConvert.DeserializeObject<Result>(str45);

            var sqllist = new List<string>();
            var st0 = string.IsNullOrWhiteSpace(s0?.data?.index_data?.analysis?.area_data + "") ? "" : JsonConvert.SerializeObject(s0.data.index_data.analysis.area_data);
            var st15 = string.IsNullOrWhiteSpace(s15?.data?.index_data?.analysis?.area_data + "") ? "" : JsonConvert.SerializeObject(s15.data.index_data.analysis.area_data);
            var st30 = string.IsNullOrWhiteSpace(s30?.data?.index_data?.analysis?.area_data + "") ? "" : JsonConvert.SerializeObject(s30.data.index_data.analysis.area_data);
            var st45 = string.IsNullOrWhiteSpace(s45?.data?.index_data?.analysis?.area_data + "") ? "" : JsonConvert.SerializeObject(s45.data.index_data.analysis.area_data);
            sqllist.Add($"INSERT INTO `lzjc`.`t_temp_rlt`(`ID`, `00`, `00str`, `15`, `15str`, `30`, `30str`, `45`, `45str`, `RKSJ`) VALUES ('{Guid.NewGuid().ToString()}', '{s0?.data?.index_data?.analysis?.data_size}', ' {st0}', '{s15?.data?.index_data?.analysis?.data_size}', '{st15}', '{s30?.data?.index_data?.analysis?.data_size}', '{st30}', '{s45?.data?.index_data?.analysis?.data_size}', '{st45}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');");
            var isSuccess = _repository.ExecuteTransactionSQLList(sqllist);
        }







        /// <summary>
        /// 获取网页返回结果
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string getHttpResponse(string url)
        {
            try
            {
                //url = "http://api.xicidaili.com/free2016.txt";
                Uri httpURL = new Uri(url);
                CookieContainer cc = new CookieContainer();
                HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
                httpReq.CookieContainer = cc;
                httpReq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3371.0 Safari/537.36";
                HttpWebResponse httpResp = (System.Net.HttpWebResponse)httpReq.GetResponse();
                Stream respStream = httpResp.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                string result = respStreamReader.ReadToEnd();
                respStream.Close();
                respStreamReader.Close();
                return result;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
    #region
    public class LZResultDto
    {
        /// <summary>
        /// 数据
        /// </summary>
        public object data { get; set; }

        /// <summary>
        /// bool请求是否成功
        /// </summary>
        public bool result { get; set; }
        public int result_code { get; set; }
        public string result_message { get; set; }
    }

    internal class CzqGgclDataListDto
    {
        /// <summary>
        /// 充电车编号
        /// </summary>
        public string chargingCarNum { get; set; }
        /// <summary>
        /// 总量
        /// </summary>
        public int allUseSightCarNum { get; set; }
        /// <summary>
        /// 使用
        /// </summary>
        public int inUseSightCarNum { get; set; }
        /// <summary>
        /// 剩余(空闲中)
        /// </summary>
        public int remainSightCarNum { get; set; }
        /// <summary>
        /// 挂故障
        /// </summary>
        public int faultSightCarNum { get; set; }
    }
    #endregion

    public class Result
    {
        public Data data { get; set; }
        public int? errcode { get; set; }
        public object errdetail { get; set; }
        public string errmsg { get; set; }
        public object ext { get; set; }
    }

    public class Data
    {
        public int? charge_cnt { get; set; }
        public Index_data index_data { get; set; }

    }

    public class Index_data
    {
        public Analysis analysis { get; set; }
    }

    public class Analysis
    {
        public int? data_size { get; set; }
        public object area_data { get; set; }
        public int? max_index { get; set; }
    }



}
