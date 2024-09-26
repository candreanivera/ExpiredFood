using System.ComponentModel.DataAnnotations;
namespace ExpiredFood.DTO;

public record class CreateTransactionDTO
(
   [Required] int UserID,
   [Required] DateTime Due_date,
    int CategoryId,
    DateTime Timestamp,
   [StringLength(50)] string Observations
);