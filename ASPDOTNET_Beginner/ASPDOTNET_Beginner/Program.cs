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
        public static void Main(string[] args) {                // Main() : CreateHostBuilder()�޼��带 ������� ���α׷��� ������ �ô� �޼���
            CreateHostBuilder(args).Build().Run();              // CreateHostBuilder() : ���� ȯ�� ����, ���� ����, �α� �� �����ø����̼��� �����Ű�� ���� �⺻���� �͵� ������ �� �ִ� �޼���
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
