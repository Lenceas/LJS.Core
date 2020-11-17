using LJS.Core.Common;
using LJS.Core.Common.DB;
using LJS.Core.Common.Helper;
using LJS.Core.Model.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LJS.Core.Model.Seed
{
    public class DBSeed
    {
        private static string SeedDataFolder = "/LJSCore.Data.json/{0}.tsv";

        /// <summary>
        /// 异步添加种子数据 SqlSugar
        /// </summary>
        /// <param name="myContext"></param>
        /// <param name="WebRootPath"></param>
        /// <returns></returns>
        public static async Task SeedAsync(MyContext myContext, string WebRootPath)
        {
            try
            {
                if (string.IsNullOrEmpty(WebRootPath))
                {
                    throw new Exception("获取wwwroot路径时，异常！");
                }

                Console.WriteLine();
                ConsoleHelper.WriteInfoLine("************ LJS.Core DataBase Set *****************");
                Console.WriteLine();

                // 创建数据库
                ConsoleHelper.WriteInfoLine($"Create Database...");
                myContext.Db.DbMaintenance.CreateDatabase();
                ConsoleHelper.WriteSuccessLine($"Database created successfully!");
                Console.WriteLine();

                // 创建数据库表，遍历指定命名空间下的class，
                // 注意不要把其他命名空间下的也添加进来。
                ConsoleHelper.WriteInfoLine("Create Tables...");
                var modelTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
                                 where t.IsClass && t.Namespace == "LJS.Core.Model.Models"
                                 select t;
                modelTypes.ToList().ForEach(t =>
                {
                    if (!myContext.Db.DbMaintenance.IsAnyTable(t.Name))
                    {
                        Console.WriteLine(t.Name);
                        myContext.Db.CodeFirst.InitTables(t);
                    }
                });
                ConsoleHelper.WriteSuccessLine($"Tables created successfully!");
                Console.WriteLine();

                if (AppSettings.app(new string[] { "AppSettings", "SeedDBDataEnabled" }).ObjToBool())
                {
                    JsonSerializerSettings setting = new JsonSerializerSettings();
                    JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
                    {
                        //日期类型默认格式化处理
                        setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                        setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                        //空值处理
                        setting.NullValueHandling = NullValueHandling.Ignore;

                        //高级用法九中的Bool类型转换 设置
                        //setting.Converters.Add(new BoolConvert("是,否"));

                        return setting;
                    });

                    Console.WriteLine($"Seeding database data...");

                    #region TestModel
                    if (!await myContext.Db.Queryable<TestModel>().AnyAsync())
                    {
                        var data = JsonConvert.DeserializeObject<List<TestModel>>(FileHelper.ReadFile(string.Format(WebRootPath + SeedDataFolder, "TestModel"), Encoding.UTF8), setting);
                        myContext.GetEntityDB<TestModel>().InsertRange(data);

                        //myContext.GetEntityDB<TestModel>().InsertRange(JsonHelper.ParseFormByJson<List<TestModel>>(FileHelper.ReadFile(string.Format(WebRootPath + SeedDataFolder, "TestModel"), Encoding.UTF8)));

                        Console.WriteLine("Table:TestModel created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:TestModel already exists...");
                    }
                    #endregion

                    #region User
                    if (!await myContext.Db.Queryable<User>().AnyAsync())
                    {
                        myContext.GetEntityDB<User>().InsertRange(JsonHelper.ParseFormByJson<List<User>>(FileHelper.ReadFile(string.Format(WebRootPath + SeedDataFolder, "User"), Encoding.UTF8)));
                    }
                    else
                    {
                        Console.WriteLine("Table:User already exists...");
                    }
                    #endregion

                    ConsoleHelper.WriteSuccessLine($"Done seeding database!");
                }

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                throw new Exception("错误信息：" + ex.Message);
            }
        }

        /// <summary>
        /// 异步添加种子数据 EF Core
        /// </summary>
        /// <param name="mySqlContext"></param>
        /// <param name="WebRootPath"></param>
        /// <returns></returns>
        public static async Task SeedAsyncByEFCore(MySqlContext mySqlContext, string WebRootPath)
        {
            try
            {
                if (string.IsNullOrEmpty(WebRootPath))
                {
                    throw new Exception("获取wwwroot路径时，异常！");
                }

                Console.WriteLine("************ LJS.Core DataBase Set *****************");
                Console.WriteLine();

                // 创建数据库
                Console.WriteLine("开始重置数据库...");
                await mySqlContext.Database.EnsureDeletedAsync();
                await mySqlContext.Database.EnsureCreatedAsync();
                Console.WriteLine();
                ConsoleHelper.WriteSuccessLine("数据库重置成功!");
                Console.WriteLine();
                Console.WriteLine("创建表...");
                Console.WriteLine();

                if (AppSettings.app(new string[] { "AppSettings", "SeedDBDataEnabled" }).ObjToBool())
                {
                    JsonSerializerSettings setting = new JsonSerializerSettings();
                    JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
                    {
                        //日期类型默认格式化处理
                        setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                        setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                        //空值处理
                        setting.NullValueHandling = NullValueHandling.Ignore;

                        //高级用法九中的Bool类型转换 设置
                        //setting.Converters.Add(new BoolConvert("是,否"));

                        return setting;
                    });

                    Console.WriteLine("初始化数据...");
                    Console.WriteLine();

                    #region TestModel
                    if (!await mySqlContext.TestModels.AnyAsync())
                    {
                        await mySqlContext.TestModels.AddRangeAsync(JsonHelper.ParseFormByJson<List<TestModel>>(FileHelper.ReadFile(string.Format(WebRootPath + SeedDataFolder, "TestModel"), Encoding.UTF8)));
                        await mySqlContext.SaveChangesAsync();
                        Console.WriteLine("Table:TestModel created success!");
                    }
                    else
                    {
                        Console.WriteLine("Table:TestModel already exists...");
                    }
                    #endregion
                    Console.WriteLine();
                    ConsoleHelper.WriteSuccessLine("初始化数据完成!");
                }

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                throw new Exception("1、如果使用的是Mysql，生成的数据库字段字符集可能不是utf8的，手动修改下，或者尝试方案：删掉数据库，在连接字符串后加上CharSet=UTF8，重新生成数据库. \n 2、其他错误：" + ex.Message);
            }
        }
    }
}
