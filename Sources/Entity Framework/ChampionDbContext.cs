using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Entity_Framework
{
     class ChampionDbContext : DbContext
     {     
        public DbSet<ChampionEntity> Champions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                    => optionsBuilder.UseSqlite($"Data Source=Entity_Framework.LigueOfLegend.db");
        // @"Server = LocalDataBase.db"
     }
}
