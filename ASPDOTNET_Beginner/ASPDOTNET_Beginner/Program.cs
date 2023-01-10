using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDOTNET_Beginner {
    public class Program {
        public static void Main(string[] args) {                // Main() : CreateHostBuilder()메서드를 실행시켜 프로그램의 시작을 맡는 메서드
            CreateHostBuilder(args).Build().Run();              // CreateHostBuilder() : 웹의 환경 설정, 서버 세팅, 로깅 등 웹애플리케이션을 실행시키기 위해 기본적인 것들 구출할 수 있는 메서드
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
