using System;
using ExpiredFood.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExpiredFood.Data;

//This class inherits from DbContext
public class ExpiredFoodContext(DbContextOptions<ExpiredFoodContext> options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Food> Foods => Set<Food>();

    public DbSet<Transaction> Transactions => Set<Transaction>();

    public DbSet<User> Users => Set<User>();


    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Category>()
    //         .HasMany(c => c.Foods)          // Una categoría tiene muchos alimentos
    //         .WithOne(f => f.Category)       // Un alimento pertenece a una sola categoría
    //         .HasForeignKey(f => f.CategoryId); // Clave foránea en Food

    //     base.OnModelCreating(modelBuilder);
    // }

}
