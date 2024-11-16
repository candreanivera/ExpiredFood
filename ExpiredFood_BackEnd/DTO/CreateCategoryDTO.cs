using System.ComponentModel.DataAnnotations;
namespace ExpiredFood_BackEnd.DTO;

public record class CreateCategoryDTO(
    [Required][StringLength(40)] string Name
);
