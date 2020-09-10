using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCoreApi.Extension;
using Asp.NetCoreApi.HangFire;

namespace Asp.NetCoreApi.IService
{
    public class ServiceRegister
    {
        /// <summary>
        /// 依赖注入的注册
        /// </summary>
        /// <param name="services"></param>
        public static void AddService(IServiceCollection services)
        {
            services.AddScoped<IRepository, BaseRepository>();
            services.AddScoped<ITimerClass, TimerClass>();
        }

    }
}
