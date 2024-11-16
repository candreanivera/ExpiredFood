using System.ComponentModel.DataAnnotations;
namespace ExpiredFood_BackEnd.DTO;

public record class UpdateCategoryDTO
(
    [Required][StringLength(40)] string Name
);
