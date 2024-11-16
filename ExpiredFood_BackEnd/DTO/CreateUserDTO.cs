using System.ComponentModel.DataAnnotations;
namespace ExpiredFood_BackEnd.DTO;

public record class CreateUserDTO
(
    [Required][StringLength(40)] string Name,
    [Required][StringLength(40)] string Last_Name,
    string Address,
    [Required][StringLength(40)] string Email,
    int Phone
);
