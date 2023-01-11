using ASPDOTNET_Beginner.Models;
using ASPDOTNET_Beginner.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASPDOTNET_Beginner {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddControllers();
            services.AddTransient<JsonFileProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // HTTP Processing Pipline을 설정해 주는 메서드
        // HTTP Request가 들어오면 미들웨어를 계속 추가하여 구성된 Request Pipline에 따라 어떻게 반응할 것인지 지정하는 역할을 한다.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {       
            
            //미들웨어1
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            //미들웨어2
            app.UseHttpsRedirection();
            //미들웨어3
            app.UseStaticFiles();
            //미들웨어4
            app.UseRouting();
            //미들웨어5
            app.UseAuthorization();
            //미들웨어6
            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
            });
        }
    }
}
