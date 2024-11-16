using System.ComponentModel.DataAnnotations;
namespace ExpiredFood_BackEnd.DTO;

public record class UpdateTransactionDTO
(
    [Required] int UserId,
    int CategoryId,
    DateTime Due_Date,
    DateTime Date,
    string Observations
);