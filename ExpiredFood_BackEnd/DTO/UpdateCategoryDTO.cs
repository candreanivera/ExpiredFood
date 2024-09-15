using System.ComponentModel.DataAnnotations;
namespace ExpiredFood.DTO;

public record class UpdateCategoryDTO
(
    [Required][StringLength(40)] string Name
);
