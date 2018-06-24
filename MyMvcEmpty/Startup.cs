using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyMvcEmpty
{
    public class Startup
    {
        #region mycode
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        #endregion

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region mycode
            services.Configure<Class>(Configuration);//注册班级信息到IOptions

            services.AddMvc();//依赖注册mvc
            #endregion

            #region mycode ： Cookie-based认证
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {//自定义登陆地址，不配置的话则默认为http://localhost:5000/Account/Login
                   //options.LoginPath = "/Account/MyLogin";
               });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration, IApplicationLifetime applicationLifetime)//mycode
        {
            #region mycode : Cookie-based认证，必须放前面，后面无效
            app.UseAuthentication();
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //注释掉：防止MVC管道被占用
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("[@]Hello World!");

            //    #region mycode
            //    var myClass = new Class();
            //    Configuration.Bind(myClass);//将appsettiong读取的内容绑定到myClass变量
            //    #endregion

            //    await context.Response.WriteAsync($"[@]ClassNo:{myClass.ClassNo}");
            //    await context.Response.WriteAsync($"[@]ClassDesc:{myClass.ClassDesc}");
            //    await context.Response.WriteAsync($"[@]{myClass.Students.Count}Students");

            //    await context.Response.WriteAsync($"[@]ConnectionStrings.DefaultConnection:{configuration["ConnectionStrings:DefaultConnection"]}");

            //    //宿主环境信息-IConfiguration
            //    await context.Response.WriteAsync($"[@]ApplicationName={env.ApplicationName}");//应用程序名称-MyMvcEmpty
            //    await context.Response.WriteAsync($"[@]ContentRootFileProvider={env.ContentRootFileProvider}");//项目所在目录文件提供程序-Microsoft.Extensions.FileProviders.PhysicalFileProvider
            //    await context.Response.WriteAsync($"[@]ContentRootPath={env.ContentRootPath}");//项目所在目录-F:\sss\CoreTest\MyMvcEmpty\MyMvcEmpty
            //    await context.Response.WriteAsync($"[@]EnvironmentName={env.EnvironmentName}");//开发环境-Development
            //    await context.Response.WriteAsync($"[@]WebRootPath={env.WebRootPath}");//WebRoot所在目录-F:\sss\CoreTest\MyMvcEmpty\MyMvcEmpty\wwwroot
            //    await context.Response.WriteAsync($"[@]WebRootFileProvider={env.WebRootFileProvider}");//WebRoot文件提供程序-Microsoft.Extensions.FileProviders.PhysicalFileProvider
            //    await context.Response.WriteAsync($"[@]IsDevelopment={env.IsDevelopment()}");
            //    await context.Response.WriteAsync($"[@]IsEnvironment('Development')={env.IsEnvironment("Development")}");
            //    await context.Response.WriteAsync($"[@]IsProduction={env.IsProduction()}");
            //    await context.Response.WriteAsync($"[@]IsStaging={env.IsStaging()}");


            //    //ApplicationLifetime可以在应用开始、结束中、结束后的时候执行委托的事件
            //    applicationLifetime.ApplicationStarted.Register(()=> {
            //        Console.WriteLine("Started1");
            //    });
            //    applicationLifetime.ApplicationStopping.Register(() => {
            //        Console.WriteLine("Stopping");
            //    });
            //    applicationLifetime.ApplicationStopped.Register(() => {
            //        Console.WriteLine("Stopped");
            //    });


            //});

            #region mycode
            app.UseMvcWithDefaultRoute();//使用MVC并使用默认路由
            #endregion

            //test

            //test2
        }
    }
}
