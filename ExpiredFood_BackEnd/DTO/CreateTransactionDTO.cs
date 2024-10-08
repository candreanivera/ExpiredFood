using System.ComponentModel.DataAnnotations;
namespace ExpiredFood.DTO;

public record class CreateTransactionDTO
(
   [Required] int UserId,
   [Required] DateTime Due_date,
    int CategoryId,
    DateTime Timestamp,
    string Observations
);