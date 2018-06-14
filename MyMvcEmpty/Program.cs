using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyMvcEmpty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        #region mycode
        //AddJsonFile说明
        //第一个参数（optional）：（Whether the file is optional）是否可选，意思是如果配置文件不存在的时候是否要抛异常。
        //第二个参数（reloadOnChange）：（Whether the configuration should be reloaded if the file changes.）是否改变的时候重新加载。
        #endregion
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //mycode:默认： builder.AddJsonFile("appsettings.json", false, true);
            .ConfigureAppConfiguration(builder =>
            {
                builder.AddJsonFile("appsettings.json", false, true);//若第二个为false，IOptionsSnapshot方式读取也不能热更新
                //builder.AddCommandLine(args);//从命令行中读取配置文件
            })//mycode
              .UseUrls("http://192.168.5.228:51219", "http://localhost:51219")//IP访问//mycode
                .UseStartup<Startup>()
                .Build();
    }
}
