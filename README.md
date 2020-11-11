# LJS.Core
个人博客 前后端分离 API接口文档 .NET5 + EF Core/SqlSugar + MySql/Mongo

功能与进度

一、框架模块：

用 服务+接口 的形式封装框架

异步 async/await 开发

接入数据库 ORM 组件 —— EF Core(主要)/SqlSugar(测试用)

目前支持 MySql

实现项目启动，自动生成种子数据 

CodeFirst 

二、组件模块：

使用 Swagger 做api文档

使用 AutoFac 做依赖注入容器，并提供批量服务注入

使用 Automapper 处理对象映射

封装 JWT 自定义策略授权

三、计划

完善授权、集成Log4net日志、Redis 缓存、CORS 跨域、Redis 消息队列、Quartz.net 做任务调度
