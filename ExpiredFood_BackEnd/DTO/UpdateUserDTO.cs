using System.ComponentModel.DataAnnotations;
namespace ExpiredFood_BackEnd.DTO;

public record class UpdateUserDTO
(
    [StringLength(40)] string Name,
    [StringLength(40)] string Last_Name,
    string Address,
    [StringLength(40)] string Email,
    int Phone
);