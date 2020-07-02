using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WebApplication1.IService;

namespace WebApplication1.HangFire
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
            var str = getHttpResponse(@"http://47.111.62.9:8686/log/api/v2/open/data/findSightseeingCarData");
            var result = JsonConvert.DeserializeObject<LZResultDto>(str);
            var strdata = result.data + "";
            var data = JsonConvert.DeserializeObject<CzqGgclDataListDto>(strdata);
            var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var sqllist = new List<string>();
            sqllist.Add($"INSERT INTO `lzjc`.`t_temp_ggcl_copy`(`ID`, `CJSJ`, `ALLUSESIGHTCARNUM`, `INUSESIGHTCARNUM`, `REMAINSIGHTCARNUM`, `FAULTSIGHTCARNUM`, `RKSJ`,`CHARGINGCARNUM`) VALUES ('{Guid.NewGuid().ToString()}', '{time}', '{data.allUseSightCarNum}', '{data.inUseSightCarNum}', '{data.remainSightCarNum}', '{data.faultSightCarNum}','{time}','{data.chargingCarNum}')");
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
}
