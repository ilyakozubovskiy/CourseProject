using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.DAL;

public partial class LocalContext : DbContext
{
    public LocalContext()
    {
    }

    public LocalContext(DbContextOptions<LocalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionType> TransactionTypes { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Local;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK_Transactions");

            entity.ToTable("Transaction");

            entity.HasIndex(e => e.TransactionId, "IX_Transactions");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Client).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_Client");

            entity.Property(t => t.Name).HasColumnName("Name");
            entity.Property(t => t.Surname).HasColumnName("Surname");
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.ToTable("TransactionType");
            entity.HasKey(p => p.TypeId);

        });
        modelBuilder.Entity<Currency>(entity =>
        {
            entity.ToTable("Currency");
            entity.HasKey(p => p.CurrencyId);

        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
