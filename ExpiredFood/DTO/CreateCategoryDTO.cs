using System.ComponentModel.DataAnnotations;
namespace ExpiredFood.DTO;

public record class CreateCategoryDTO(
    [Required][StringLength(40)] string Name
);
