using Hello.BLL;
using Hello.IDAL;
using Hello.Oracle.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hello.MVC6 {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            //MVC6 - 의존성 주입 3가지 방법
            //1. AddSingleton<T>()
            //- 프로그램이 시작하면 프로그램이 종료될 때까지 메모리 상에 유지되는 객체 주입
            //2. AddScoped<T>();
            //-  웹사이트가 시작되어 1번의 요청이 있을때 메모리 상에 유지되는 객체 주입
            //3. AddTrasient<T>();
            //- 웹사이트가 시작되어 각 요청마다 새롭게 생성되는 객체 주입 (가장 라이트한 방법)
            services.AddTransient<UserBll>();
            services.AddTransient < IUserDal,UserDal>();
            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
