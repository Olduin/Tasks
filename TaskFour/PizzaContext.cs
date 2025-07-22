using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TaskFour.Models;

namespace TaskFour;

public partial class PizzaContext : DbContext
{
    public PizzaContext()
    {
    }

    public PizzaContext(DbContextOptions<PizzaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PizzaModel> Pizzas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseNpgsql("Host=localhost;Database=pizzatest;Port=5432;Username=postgres;Password=admin;");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {  
        modelBuilder.Entity<PizzaModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pizzas__3214EC075CEC0408");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
