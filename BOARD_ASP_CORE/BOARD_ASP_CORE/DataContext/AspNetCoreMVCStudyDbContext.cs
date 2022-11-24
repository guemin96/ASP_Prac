using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BOARD_ASP_CORE.DataContext {
    public class AspNetCoreMVCStudyDbContext :DbContext {
        //사용 안함
        //private readonly IConfiguration _configuration;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //    string test = _configuration.GetConnectionString("ConnectionString");

        //    optionsBuilder.UseSqlServer(test);
        //}
    }
}
