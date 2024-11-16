using System.Reflection;
using ExpiredFood_BackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpiredFood_BackEnd.Data.Configurations
{
    public class ExpiredFoodConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
           
        }
    }
}
