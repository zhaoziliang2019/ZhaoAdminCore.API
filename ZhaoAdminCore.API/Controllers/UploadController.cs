using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoAdminCore.API.Model;

namespace ZhaoAdminCore.API.Controllers
{
    [Route("api/upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        /// <summary>
        /// 保存照片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<List<string>>> post()
        {
            var data = new MessageModel<List<string>>();
            //返回的文件地址
            List<string> filenames = new List<string>();
            var files = Request.Form.Files;
            if (files == null|| files.Count==0)
            {
                data.success = false;
                data.msg = "上传失败！";
                return data;
            }
            //返回的文件地址
            var now = DateTime.Now;
            //文件存储路径
            var filePath = string.Format("/Uploads/{0}/{1}/{2}/", now.ToString("yyyy"), now.ToString("yyyyMM"), now.ToString("yyyyMMdd"));
            //获取当前web目录
            var webRootPath = AppContext.BaseDirectory;
            if (!Directory.Exists(webRootPath + filePath))
            {
                Directory.CreateDirectory(webRootPath + filePath);
            }
            try
            {
                //格式限制
                var allowType = new string[] { "image/jpg", "image/png", "image/jpeg" };
                if (files.Any(c => allowType.Contains(c.ContentType)))
                {
                    if (files.Sum(c => c.Length) <= 1024 * 1024 * 4)
                    {
                        foreach (var file in files)
                        {
                            //文件后缀
                            var fileExtension = Path.GetExtension(file.FileName);
                            var strDateTime = DateTime.Now.ToString("yyMMddhhmmssfff"); //取得时间字符串
                            var strRan = Convert.ToString(new Random().Next(100, 999)); //生成三位随机数
                            var saveName = strDateTime + strRan + fileExtension;

                            using (var stream = new FileStream(webRootPath+filePath + saveName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                            {
                                await file.CopyToAsync(stream);
                            }
                            filenames.Add(filePath + saveName);
                        }
                        data.msg = "上传成功";
                        data.success = true;
                        data.response = filenames;
                        return data;
                    }
                    else
                    {
                        data.msg = "图片过大";
                        data.success = false;
                        return data;
                    }
                }
                else
                {
                    data.msg = "图片格式错误";
                    data.success = false;
                    return data;
                }
            }
            catch (Exception ex)
            {
                data.success = false;
                data.msg = "上传失败！";
                return data;
            }
        }
    }
}
