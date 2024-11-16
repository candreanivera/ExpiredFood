using System.Reflection;
using ExpiredFood_BackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpiredFood_BackEnd.Data;

//This class inherits from DbContext
public class ExpiredFood_BackEndContext : DbContext{
    public ExpiredFood_BackEndContext(DbContextOptions<ExpiredFood_BackEndContext> options) :base(options) 
    { 
    }

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
        new {CategoryId = 4, Name = "Dairy products"},
        new {CategoryId = 5, Name = "Ice Cream and frozen deserts"},
        new {CategoryId = 6, Name = "Frozen vegetables"}
       );

       modelBuilder.Entity<User>().HasData(
        new {UserId = 1, Name = "Cristina", LastName = "Andreani",
        Address = "Que te importa 23, Auckland", Email = "queteimporta@example.com",
        Phone = 0211234567}
       );

       modelBuilder.Entity<User>().HasData(
        new {UserId = 2, Name = "Mathew", LastName = "Graham",
        Address = "Que te importa 23, Auckland", Email = "queteimporta@example.com",
        Phone = 0211234567}
       );
    }


}
    