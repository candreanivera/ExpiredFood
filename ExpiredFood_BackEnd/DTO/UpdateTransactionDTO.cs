using System.ComponentModel.DataAnnotations;
namespace ExpiredFood.DTO;

public record class UpdateTransactionDTO
(
    [Required] int UserID,
    int FoodId,
    DateTime Timestamp,
    [StringLength(50)] string Observations
);