/******************************************************************** 
** 作    者：zzl
** 创始时间：2020/11/1 20:49:45
** 修 改 人： 
** 修改时间：
** 修 改 人：
** 修改时间：
** 版   本：1.0           
** 名    称： GoodsListRepository
** 描    述： GoodsListRepository
********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using ZhaoAdminCore.API.IRepository.Goods;
using ZhaoAdminCore.API.IRepository.UnitOfWork;
using ZhaoAdminCore.API.Model.Models;
using ZhaoAdminCore.API.Repository.BASE;

namespace ZhaoAdminCore.API.Repository.Goods
{
    public class GoodsListRepository:BaseRepository<GoodsListInfo>, IGoodsListRepository
    {
        public GoodsListRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
    }
}
