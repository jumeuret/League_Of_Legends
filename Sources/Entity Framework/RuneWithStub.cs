﻿using EntityFramework.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework;

public class RuneWithStub: ApplicationDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var rune1 = new RuneEntity
        {
            Id = 1,
            Name = "Mana",
            Description =
                "Mana (also known as MP) is a stat that is the resource of many champions necessary to cast most of their abilities.",
            Family = "une famille",
            Icon = "Un icon inexistant",
            Image = "Pas d'image",
            Categorie = "Glyphe"
        };
    //     
    // var runePage1 = new RunePageEntity
    // {
    //     Id = 1,
    //     Name = "page1",
    //     Runes = rune1
    // }

    var champion1 = new ChampionEntity{Id = 1, Name = "Akali", Icon= "ff", Bio = "gg"};
    var champion2 = new ChampionEntity{Id = 3, Name = "Aatrox",Icon = "gg", Bio = "gg"};
    var champion3 = new ChampionEntity{Id = 4, Name = "Ahri", Icon= "ff", Bio = "gg"};
    var champion4 = new ChampionEntity{Id = 5, Name = "Akshan", Icon= "ff", Bio = "gg"};
    var champion5 = new ChampionEntity{Id = 5, Name = "Bard", Icon= "ff", Bio = "gg"};
    var champion6 = new ChampionEntity{Id = 6, Name = "Alistar", Icon= "ff", Bio = "gg"};
    
    modelBuilder.Entity<ChampionEntity>().HasData(champion1, champion2,champion3,champion4,champion5,champion6);
    modelBuilder.Entity<SkinEntity>().Property<int>("ChampionId");
    modelBuilder.Entity<SkinEntity>().HasData(
        new { Id = 1, ChampionId = 2, Name = "gg", Description = "truc", Price = (float)11.5 },
        new { Id = 2, ChampionId = 2, Name = "hh", Description = "truc", Price = (float)11.5 },
        new { Id = 3, ChampionId = 2, Name = "ii", Description = "truc", Price = (float)11.5 },
        new { Id = 4, ChampionId = 1, Name = "jj", Description = "truc", Price = (float)11.5 },
        new { Id = 5, ChampionId = 1, Name = "ll", Description = "truc", Price = (float)11.5 }
    );
    // modelBuilder.Entity<ChampionEntity>().HasMany(c => c.Skins).WithOne(s => s.ChampionEntity);
    
    base.SaveChanges();
    }
}  