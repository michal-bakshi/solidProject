using data.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAB-D-09;Database=newUserDB;" +
               "User Id=DOMAIN\\seminar;Integrated Security=True;TrustServerCertificate=True");
        }

        public DbSet<User> Users { get; set; }
    }
}
