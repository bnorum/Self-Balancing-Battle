using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NorumBradenFinal.Pages.tblEnemy;
using NorumBradenFinal.Pages.tblGameStats;
using NorumBradenFinal.Pages.tblPlayer;
namespace NorumBradenFinal;

public partial class Bnorum1Context : DbContext
{

    public Bnorum1Context(DbContextOptions<Bnorum1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEnemy> TblEnemies { get; set; }

    public virtual DbSet<TblGameStat> TblGameStats { get; set; }


    public virtual DbSet<TblPlayer> TblPlayers { get; set; }


    public IConfiguration myconfig { get; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer(myconfig.GetConnectionString("NorumConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       

        modelBuilder.Entity<TblEnemy>(entity =>
        {
            entity.HasKey(e => e.Enemyid).HasName("PK__tblEnemy__947AB8FC85774B76");

            entity.ToTable("tblEnemy");

            entity.Property(e => e.Enemyid)
                .ValueGeneratedNever()
                .HasColumnName("enemyid");
            entity.Property(e => e.Enemyattack).HasColumnName("enemyattack");
            entity.Property(e => e.Enemyhealth).HasColumnName("enemyhealth");
        });

        modelBuilder.Entity<TblGameStat>(entity =>
        {
            entity.HasKey(e => e.Gamestatsid).HasName("PK__tblGameS__E75590768B5A94CD");

            entity.ToTable("tblGameStats");

            entity.Property(e => e.Gamestatsid)
                .ValueGeneratedNever()
                .HasColumnName("gamestatsid");
            entity.Property(e => e.Damagetaken).HasColumnName("damagetaken");
            entity.Property(e => e.Enemyid).HasColumnName("enemyid");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Playerid).HasColumnName("playerid");
            entity.Property(e => e.Turnstaken).HasColumnName("turnstaken");

            entity.HasOne(d => d.Enemy).WithMany(p => p.TblGameStats)
                .HasForeignKey(d => d.Enemyid)
                .HasConstraintName("FK__tblGameSt__enemy__73BA3083");

            entity.HasOne(d => d.Player).WithMany(p => p.TblGameStats)
                .HasForeignKey(d => d.Playerid)
                .HasConstraintName("FK__tblGameSt__playe__74AE54BC");
        });

        modelBuilder.Entity<TblPlayer>(entity =>
        {
            entity.HasKey(e => e.Playerid).HasName("PK__tblPlaye__2CD7147901DD8929");

            entity.ToTable("tblPlayer");

            entity.Property(e => e.Playerid)
                .ValueGeneratedNever()
                .HasColumnName("playerid");
            entity.Property(e => e.Attack).HasColumnName("attack");
            entity.Property(e => e.Health).HasColumnName("health");
            entity.Property(e => e.Magicpower).HasColumnName("magicpower");
            entity.Property(e => e.Mana).HasColumnName("mana");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
