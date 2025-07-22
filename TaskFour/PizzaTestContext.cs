using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TaskFour.Models;

namespace TaskFour;

public partial class PizzaTestContext : DbContext
{
    public PizzaTestContext()
    {
    }

    public PizzaTestContext(DbContextOptions<PizzaTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PizzaModel> Pizzas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=PizzaTest;Port=5432;Username=postgres;Password=admin;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PizzaModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pizzas_pkey");

            entity.ToTable("pizzas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Ingredients).HasColumnName("ingredients");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
