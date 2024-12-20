using HR_2024.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Ef
{
    public class AppCon:DbContext
    {

        public AppCon(DbContextOptions<AppCon> options):base(options) 
        {
            
        }
       public DbSet<Tb_Help> Helps { get; set; }
        public DbSet<GeneralManagement> GeneralManagements { get; set; }
        public DbSet<Management_Sub> Management_Subs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Management_Unit> Management_Units { get; set; }
       // public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Evaluation> evaluations { get; set; }

    }
}
