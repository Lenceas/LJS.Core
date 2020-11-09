using AutoMapper;
using LJS.Core.Model.Models;
using LJS.Core.Model.ViewModels;

namespace LJS.Core.Extensions.AutoMapper
{
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            CreateMap<TestModel, TestViewModels>();
            CreateMap<TestViewModels, TestModel>();
        }
    }
}
