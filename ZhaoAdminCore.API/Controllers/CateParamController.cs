using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoAdminCore.API.IServices.Goods;
using ZhaoAdminCore.API.Model;
using ZhaoAdminCore.API.Model.Models;

namespace ZhaoAdminCore.API.Controllers
{
    /// <summary>
    /// 商品参数
    /// </summary>
    [Route("api/cateparams")]
    [ApiController]
    public class CateParamController : ControllerBase
    {
        private readonly ICateParamInfoService _cateParamInfoService;

        public CateParamController(ICateParamInfoService cateParamInfoService)
        {
            _cateParamInfoService = cateParamInfoService;
        }
        /// <summary>
        /// 获取参数列表
        /// </summary>
        /// <param name="attr_sel"></param>
        /// <param name="cat_id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("paramlist")]
        public async Task<MessageModel<List<CateParamInfo>>> GetCateParamInfoList(string attr_sel,int cat_id)
        {
            var data = new MessageModel<List<CateParamInfo>>();
            var cList = await _cateParamInfoService.Query(n => n.cat_ID == cat_id && n.attr_Sel == attr_sel);
            data.success = cList.Count>0;
            if (data.success)
            {
                data.msg = "获取参数列表成功！";
                data.response = cList;
            }
            return data;
        }
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("addcateparam")]
        public async Task<MessageModel<string>> AddCateParams(CateParamInfo cateParamInfo)
        {
            var data = new MessageModel<string>();
            data.success = await _cateParamInfoService.Add(cateParamInfo)>0;
            if (data.success)
            {
                data.msg = "添加参数成功！";
            }
            return data;
        }
        /// <summary>
        /// 根据id获取参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("cateparam")]
        public async Task<MessageModel<CateParamInfo>> GetCateParamInfoById(int id)
        {
            var data = new MessageModel<CateParamInfo>();
            var cateParam= await _cateParamInfoService.QueryById(id);
            data.success = cateParam!=null;
            if (data.success)
            {
                data.msg = "获取参数成功";
                data.response = cateParam;
            }
            return data;
        }
        /// <summary>
        /// 更新商品参数
        /// </summary>
        /// <param name="cateParamInfo"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updatecateparam")]
        public async Task<MessageModel<string>> UpdateCateParamInfo(CateParamInfo cateParamInfo)
        {
            var data = new MessageModel<string>();
            data.success = await _cateParamInfoService.Update(cateParamInfo);
            if (data.success)
            {
                data.msg = "更新参数成功！";
            }
            return data;
        }
        [HttpDelete]
        [Route("deletecateparam")]
        public async Task<MessageModel<string>> DeleteCateParamInfoById(int id)
        {
            var data = new MessageModel<string>();
            data.success = await _cateParamInfoService.DeleteById(id);
            if (data.success)
            {
                data.msg = "删除参数成功";
            }
            return data;
        }
    }
}
