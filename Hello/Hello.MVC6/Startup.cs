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

            //MVC6 - ������ ���� 3���� ���
            //1. AddSingleton<T>()
            //- ���α׷��� �����ϸ� ���α׷��� ����� ������ �޸� �� �����Ǵ� ��ü ����
            //2. AddScoped<T>();
            //-  ������Ʈ�� ���۵Ǿ� 1���� ��û�� ������ �޸� �� �����Ǵ� ��ü ����
            //3. AddTrasient<T>();
            //- ������Ʈ�� ���۵Ǿ� �� ��û���� ���Ӱ� �����Ǵ� ��ü ���� (���� ����Ʈ�� ���)
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
