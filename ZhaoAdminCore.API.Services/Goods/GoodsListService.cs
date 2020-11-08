/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/11/1 20:52:32
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： GoodsListService
** 描    述： GoodsListService
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZhaoAdminCore.API.IRepository.Goods;
using ZhaoAdminCore.API.IServices.Goods;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Services.BASE;

namespace ZhaoAdminCore.API.Services.Goods
{
    public class GoodsListService:BaseService<GoodsListInfo>, IGoodsListService
    {
        private readonly IGoodsListRepository _goodsListRepository;

        public GoodsListService(IGoodsListRepository goodsListRepository)
        {
            _goodsListRepository = goodsListRepository;
            this.BaseDal = goodsListRepository;
        }
    }
}
