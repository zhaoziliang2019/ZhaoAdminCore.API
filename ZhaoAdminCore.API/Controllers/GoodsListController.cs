using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZhaoAdminCore.API.IServices.Goods;
using ZhaoAdminCore.API.Model;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Controllers
{
    /// <summary>
    /// 商品列表
    /// </summary>
    [Route("api/goodslists")]
    [ApiController]
    [Produces("application/json")]
    public class GoodsListController : ControllerBase
    {
        private readonly IGoodsListService _goodsListService;

        public GoodsListController(IGoodsListService goodsListService)
        {
            _goodsListService = goodsListService;
        }
        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pagenum"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        public async Task<MessageModel<PageModel<GoodsListInfo>>> GetGoodsList(string query,int pagenum,int pagesize)
        {
            var data = new MessageModel<PageModel<GoodsListInfo>>();
            if (string.IsNullOrEmpty(query)||string.IsNullOrWhiteSpace(query))
            {
                query = "";
            }
            var list = await _goodsListService.QueryPage(n=>n.goods_Name.Contains(query),pagenum,pagesize);
            data.response = list;
            data.success = true;
            data.msg = "获取商品列表";
            return data;
        }
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="goodsListInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addgood")]
        public async Task<MessageModel<string>> AddGoodsListInfo(GoodsListInfo goodsListInfo)
        {
            var data = new MessageModel<string>();
            if (string.IsNullOrWhiteSpace(goodsListInfo.goods_Name))
            {
                data.success = false;
                data.msg = "商品名称为空";
                return data;
            }
            var isHasByGoodsName = await _goodsListService.Query(n=>n.goods_Name==goodsListInfo.goods_Name);
            if (isHasByGoodsName.Count>0)
            {
                data.success = false;
                data.msg = "已存在该商品,请添加其他商品！";
                return data;
            }
            data.success= await _goodsListService.Add(goodsListInfo)>0;
            if (data.success)
            {
                data.msg = "添加商品成功！";
            }
            return data;
        }
    }
}
