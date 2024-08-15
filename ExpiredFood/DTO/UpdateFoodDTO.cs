using System.ComponentModel.DataAnnotations;
namespace ExpiredFood.DTO;

public record class UpdateFoodDTO
(
    [Required][StringLength(40)] string Name,
    [Required][StringLength(40)] string Brand,
    int CategoryId
);
