using System.ComponentModel.DataAnnotations;
namespace ExpiredFood_BackEnd.DTO;

public record class CreateTransactionDTO
(
   [Required] int UserId,
   [Required] DateTime Due_date,
    int CategoryId,
    DateTime Timestamp,
    string Observations
);