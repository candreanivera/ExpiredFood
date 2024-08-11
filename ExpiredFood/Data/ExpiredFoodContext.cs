using System;
using ExpiredFood.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExpiredFood.Data;

//This class inherits from DbContext
public class ExpiredFoodContext : DbContext
{
    public DbSet<Category> categories { get; set; }

    public DbSet<Food> foods { get; set; }

    public DbSet<Transaction> transactions { get; set; }

    public DbSet<User> users { get; set; }

    public DbSet<Household> households { get; set; }

}
