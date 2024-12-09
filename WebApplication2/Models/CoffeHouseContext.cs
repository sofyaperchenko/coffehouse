using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class CoffeHouseContext : DbContext
{
    public CoffeHouseContext()
    {
    }

    public CoffeHouseContext(DbContextOptions<CoffeHouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<Catalogue> Catalogues { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Pay> Pays { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Tovar> Tovars { get; set; }

    public virtual DbSet<Zakaz> Zakazs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source= DESKTOP-I9SS3US\\SQLEXPRESS;Database=CoffeHouse; Integrated Security=True; TrustServerCertificate=False; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Basket>(entity =>
        {
            entity.ToTable("Basket");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TovarId).HasColumnName("TovarID");
        });

        modelBuilder.Entity<Catalogue>(entity =>
        {
            entity.ToTable("Catalogue");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TovarId).HasColumnName("TovarID");

            entity.HasOne(d => d.Tovar).WithMany(p => p.Catalogues)
                .HasForeignKey(d => d.TovarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Catalogue_Tovar");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BasketId).HasColumnName("BasketID");
            entity.Property(e => e.CatalogueId).HasColumnName("CatalogueID");
            entity.Property(e => e.Login).HasMaxLength(15);
            entity.Property(e => e.ZakazId).HasColumnName("ZakazID");
        });

        modelBuilder.Entity<Pay>(entity =>
        {
            entity.ToTable("Pay");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");
            entity.Property(e => e.ZakazId).HasColumnName("ZakazID");

            entity.HasOne(d => d.Client).WithMany(p => p.Pays)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pay_Client1");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.Pays)
                .HasForeignKey(d => d.PaymentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pay_PaymentType");

            entity.HasOne(d => d.Zakaz).WithMany(p => p.Pays)
                .HasForeignKey(d => d.ZakazId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pay_Zakaz");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.ToTable("PaymentType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Tovar>(entity =>
        {
            entity.ToTable("Tovar");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Zakaz>(entity =>
        {
            entity.ToTable("Zakaz");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TovarId).HasColumnName("TovarID");

            entity.HasOne(d => d.Tovar).WithMany(p => p.Zakazs)
                .HasForeignKey(d => d.TovarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zakaz_Tovar");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
