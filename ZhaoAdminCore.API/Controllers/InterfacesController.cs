using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZhaoAdminCore.API.IServices.SysManage;
using ZhaoAdminCore.API.Model;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Controllers
{
    /// <summary>
    /// 接口管理
    /// </summary>
    [Route("api/interfaces/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class InterfacesController : ControllerBase
    {
        private readonly IInterfacesService interfacesService;

        public InterfacesController(IInterfacesService _interfacesService)
        {
            interfacesService = _interfacesService;
        }
        /// <summary>
        /// 接口列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<MessageModel<PageModel<InterfacesInfo>>> Get(int page,int pagesize,string key="")
        {
            if (string.IsNullOrEmpty(key)||string.IsNullOrWhiteSpace(key))
            {
                key = "";
            }
            var inters = await interfacesService.QueryPage(n => n.iIsDeleted == false&&n.iName.Contains(key),page,pagesize);
            var data = new MessageModel<PageModel<InterfacesInfo>>();
            data.response = inters;
            data.success = inters.dataCount > 0;
            data.msg = "获取接口信息成功!";
            return data;
        }
    }
}
