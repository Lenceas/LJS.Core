using AutoMapper;
using LJS.Core.Common.Helper;
using LJS.Core.IServices;
using LJS.Core.Model;
using LJS.Core.Model.Models;
using LJS.Core.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LJS.Core.Extensions.CustomApiVersion;

namespace LJS.Core.Api.Controllers
{
    /// <summary>
    /// 用户接口
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [CustomRoute(ApiVersions.v3)]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public UserController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<MessageModel<List<UserViewModels>>> GetAll()
        {
            return new MessageModel<List<UserViewModels>>()
            {
                msg = "查询成功",
                success = true,
                response = _mapper.Map<List<UserViewModels>>(await _userServices.Query(t => t.IsDeleted == false && t.Status == 1, "SortId"))
            };
        }

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<MessageModel<UserViewModels>> Get(long id)
        {
            var data = new MessageModel<UserViewModels>();
            var entity = await _userServices.Query(t => t.Id == id && t.IsDeleted == false && t.Status == 1);
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
            data.response = _mapper.Map<UserViewModels>(entity);
            return data;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageModel<string>> Add([FromBody] UserViewModels model)
        {
            var data = new MessageModel<string>();
            var isExist = await _userServices.IsExist(model.LoginName);
            if (isExist)
            {
                return new MessageModel<string>()
                {
                    success = false,
                    status = 202,
                    msg = $"用户名{model.LoginName}已存在",
                };
            }
            var entity = new User(model.LoginName, model.LoginPwd, model.RealName, model.Remark);
            var id = await _userServices.Add(entity);
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
        public async Task<MessageModel<string>> Update(long id, [FromBody] UserViewModels model)
        {
            var data = new MessageModel<string>();
            if (!id.Equals(model.Id))
            {
                data.status = 202;
                data.msg = "传入Id与实体Id不一致";
                return data;
            }
            var entities = await _userServices.Query(t => t.Id == model.Id && t.IsDeleted == false && t.Status == 1);
            if (entities.Count == 0)
            {
                data.status = 204;
                data.msg = "未匹配到数据";
                return data;
            }
            var entity = entities.OrderBy(t => t.SortId).FirstOrDefault();
            entity.LoginName = model.LoginName;
            entity.LoginPwd = MD5Helper.MD5Encrypt64(model.LoginPwd);
            entity.RealName = model.RealName;
            entity.Remark = model.Remark;
            entity.UpdateTime = DateTime.Now.ToLocalTime();
            data.success = await _userServices.Update(entity);
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
            var entities = await _userServices.Query(t => t.Id == id && t.IsDeleted == false && t.Status == 1);
            if (entities.Count > 0)
            {
                data.success = await _userServices.DeleteById(id);
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
