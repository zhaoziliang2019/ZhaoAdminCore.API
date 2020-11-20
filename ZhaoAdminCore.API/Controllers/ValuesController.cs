using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZhaoAdminCore.API.Common.Redis;

namespace ZhaoAdminCore.API.Controllers
{
    /// <summary>
    /// 测试接口
    /// </summary>
    [Route("api/values")]
    [ApiController]
    [Produces("application/json")]
    public class ValuesController : ControllerBase
    {
        private readonly IRedisCacheManager _redisCacheManager;

        public ValuesController(IRedisCacheManager redisCacheManager)
        {
            _redisCacheManager = redisCacheManager;
        }
        /// <summary>
        /// get方法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            _redisCacheManager.Set("zhao",12313,TimeSpan.FromMinutes(2));
            return Ok("成功");
        }
    }
}
