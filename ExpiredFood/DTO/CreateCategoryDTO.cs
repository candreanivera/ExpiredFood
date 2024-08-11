using System.ComponentModel.DataAnnotations;

namespace ExpiredFood.DTO;

public record class CreateCategoryDTO(
    [Required][MaxLength(50)] string Name
);
