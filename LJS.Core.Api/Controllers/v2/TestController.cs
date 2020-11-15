using AutoMapper;
using LJS.Core.IServices;
using LJS.Core.Model;
using LJS.Core.Model.Models;
using LJS.Core.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static LJS.Core.Extensions.CustomApiVersion;

namespace LJS.Core.Api.Controllers.v2
{
    /// <summary>
    /// 测试专用
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [CustomRoute(ApiVersions.v2)]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly ITestServices _testServices;
        private readonly IMapper _mapper;

        public TestController(ITestServices testServices, IMapper mapper)
        {
            _testServices = testServices;
            _mapper = mapper;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<MessageModel<List<TestViewModels>>> GetAll()
        {
            return new MessageModel<List<TestViewModels>>()
            {
                msg = "查询成功",
                success = true,
                response = _mapper.Map<List<TestViewModels>>(await _testServices.Query())
            };
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<MessageModel<TestViewModels>> Get(long id)
        {
            var data = new MessageModel<TestViewModels>();
            var entity = await _testServices.QueryById(id);
            if (entity != null)
            {
                data.success = true;
                data.msg = "查询成功";
            }
            else
            {
                data.status = 204;
                data.msg = "未匹配到数据";
            }
            data.response = _mapper.Map<TestViewModels>(entity);
            return data;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> Add([FromBody] TestModel model)
        {
            var data = new MessageModel<string>();
            model.Name = "测试数据";
            model.Remark = "备注";
            model.CreateTime = DateTime.Now.ToLocalTime();
            model.UpdateTime = DateTime.Now.ToLocalTime();
            model.IsDeleted = false;
            var id = await _testServices.Add(model);
            data.success = id > 0;
            if (data.success)
            {
                data.status = 201;
                data.response = id.ObjToString();
                data.msg = "添加成功";
            }
            else
            {
                data.status = 202;
                data.msg = "添加失败";
            }
            return data;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<MessageModel<string>> Update(long id, [FromBody] TestModel model)
        {
            var data = new MessageModel<string>();
            if (!id.Equals(model.Id))
            {
                data.status = 202;
                data.msg = "传入Id与实体Id不一致";
                return data;
            }
            var entity = await _testServices.QueryById(id);
            if (entity == null)
            {
                data.status = 204;
                data.msg = "未匹配到数据";
                return data;
            }
            entity.Name = model.Name;
            entity.Remark = model.Remark;
            entity.UpdateTime = DateTime.Now.ToLocalTime();
            data.success = await _testServices.Update(entity);
            if (data.success)
            {
                data.success = true;
                data.msg = "更新成功";
                return data;
            }
            else
            {
                data.status = 202;
                data.msg = "更新失败";
                return data;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<MessageModel<string>> Delete(long id)
        {
            var data = new MessageModel<string>();
            var eneity = await _testServices.QueryById(id);
            if (eneity != null)
            {
                data.success = await _testServices.DeleteById(id);
                data.msg = data.success ? "删除成功" : "删除失败";
            }
            else
            {
                data.status = 204;
                data.msg = "未找到数据";
            }
            return data;
        }
    }
}
