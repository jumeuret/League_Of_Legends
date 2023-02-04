﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class ChampionDbContext : DbContext
    {
        public DbSet<ChampionEntity> Champions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                    => optionsBuilder.UseSqlite("Data Source=LigueOfLegend.db");
        // @"Server = LocalDataBase.db"
    }
}
