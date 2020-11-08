using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoAdminCore.API.Common.Helper;
using ZhaoAdminCore.API.IServices.Goods;
using ZhaoAdminCore.API.Model;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CateGorieController : ControllerBase
    {
        private readonly ICateGorieInfoService cateGorieInfoService;

        public CateGorieController(ICateGorieInfoService _cateGorieInfoService)
        {
            cateGorieInfoService = _cateGorieInfoService;
        }
        /// <summary>
        /// 商品分类列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pagenum"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("categories")]
        public async Task<MessageModel<PageModel<CateGorieInfo>>> GetCateGorieInfoList(int type,int pagenum,int pagesize)
        {
            var data = new MessageModel<PageModel<CateGorieInfo>>();
            var cList = await cateGorieInfoService.QueryPage(n => n.cat_Level == type, pagenum, pagesize);
            var allLists= await cateGorieInfoService.Query();//全部分类列表
            var resList=GoodsHelper.GetCateGorieInfoLists(cList.data, allLists);
            cList.data = resList;
            cList.dataCount = resList.Count;
            if (cList.dataCount>0)
            {
                data.success = true;
                data.response = cList;
            }
            return data;
        }
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="cateGorieInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addcate")]
        public async Task<MessageModel<string>> AddCateGorieInfo(CateGorieInfo cateGorieInfo)
        {
            var data = new MessageModel<string>();
            data.success=await cateGorieInfoService.Add(cateGorieInfo)>0;
            if (data.success)
            {
                data.msg = "添加分类成功！";
            }
            return data;
        }
        [HttpGet]
        [Route("parentcates")]
        public async Task<MessageModel<List<CateGorieInfo>>> GetParentCateGorieList()
        {
            var data = new MessageModel<List<CateGorieInfo>>();
            var cList = await cateGorieInfoService.Query();
            data.success = true;
            data.response = GoodsHelper.GetParentCateGorieInfos(cList);
            return data;
        }
    }
}
