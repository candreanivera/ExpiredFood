using System.ComponentModel.DataAnnotations;
namespace ExpiredFood.DTO;

public record class UpdateTransactionDTO
(
    [Required] int UserID,
    [Required] DateTime Due_date,
    int FoodId,
    DateTime Timestamp,
    [StringLength(50)] string Observations
);