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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Category>().HasData(
        new {CategoryId = 1, Name = "Fruits"},
        new {CategoryId = 2, Name = "Breads"},
        new {CategoryId = 3, Name = "Vegetables"},
        new {CategoryId = 4, Name = "Milks"},
        new {CategoryId = 5, Name = "Ice Cream and frozen deserts"},
        new {CategoryId = 6, Name = "Frozen vegetables"}
       );

       modelBuilder.Entity<User>().HasData(
        new {UserId = 1, Name = "Cristina", LastName = "Andreani",
        Address = "Que te importa 23, Auckland", Email = "queteimporta@example.com"}
       );

       modelBuilder.Entity<Food>().HasData(
        new {FoodId = 1, Name = "Pancito", Brand = "Freya´s", CategoryId = 2}
       );
    }


}
