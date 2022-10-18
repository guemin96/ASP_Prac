using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Note.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.DAL.DataContext {
    public class NoteDbContext :DbContext {

        private readonly IConfiguration _configuration;
        
        public NoteDbContext(IConfiguration configuration) {    //appsettings에서 ADD싱글톤(의존성 주입)을 사용하여 DB정보를 configuration에 넣을 수 있다. 
            _configuration = configuration; 
        }

        public DbSet<Notice> Notices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
