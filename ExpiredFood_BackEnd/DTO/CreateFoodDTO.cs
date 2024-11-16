using System.ComponentModel.DataAnnotations;
namespace ExpiredFood_BackEnd.DTO;

public record class CreateFoodDTO(
    [Required][StringLength(40)] string Name,
    [Required][StringLength(40)] string Brand,
    int CategoryId
);
