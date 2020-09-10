using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Asp.NetCoreApi.ReflexHelper
{
    public class ReflexhelperCS
    {
        public ReflexhelperCS()
        {
            str1 = "1";
            str2 = "2";
            str3 = "3";
            str4 = "4";
        }

        private string str1 { get; set; }
        internal string str2 { get; set; }
        protected string str3 { get; set; }
        public string str4 { get; set; }
    }


    public class TestReflexhelperCS
    {
        public void test()
        {
            ReflexhelperCS reflexhelperCS = new ReflexhelperCS();
            var str1 = reflexhelperCS.GetType().GetField("str1", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(reflexhelperCS);
            var str2 = reflexhelperCS.GetType().GetField("str2", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(reflexhelperCS);
            var str3 = reflexhelperCS.GetType().GetField("str3", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(reflexhelperCS);
            var str4 = reflexhelperCS.GetType().GetField("str4", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(reflexhelperCS);

            var test = reflexhelperCS.GetType().GetProperties();
            foreach (var item in test)
            {
                var Id = item.Name;
                var cccc = item.GetValue(reflexhelperCS);

            }

        }
    }
}
