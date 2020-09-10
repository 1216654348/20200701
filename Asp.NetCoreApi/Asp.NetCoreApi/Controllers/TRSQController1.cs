﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asp.NetCoreApi.IService;

namespace Asp.NetCoreApi.Controllers
{
    /// <summary>
    /// 土壤墒情导出
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TRSQController1 : ControllerBase
    {
        public readonly IRepository _repository;
        public TRSQController1(IRepository repository)
        {
            _repository = repository;
        }
    }
}
