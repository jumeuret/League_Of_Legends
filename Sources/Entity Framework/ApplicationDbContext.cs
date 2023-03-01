﻿using EntityFramework;
using EntityFramework.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework;

public class ApplicationDbContext : DbContext
{
    public DbSet<ChampionEntity> ChampionSet { get; set; }
    public DbSet<SkillEntity> SkillSet{ get; set; }
    public DbSet<SkinEntity> SkinSet { get; set;  }
    public DbSet<CharacteristicsEntity> CharacteristicSet { get; set; }
    public DbSet<RuneEntity> RuneSet { get; set; }
    public DbSet<RunePageEntity> RunePageSet { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=LeagueOfLegends.db");
        }
    }
    
    public ApplicationDbContext()
    {
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

}