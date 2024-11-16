using System;
using ExpiredFood_BackEnd.DTO;
using ExpiredFood_BackEnd.Entities;

namespace ExpiredFood.Mapping;

public static class UserMapping
{
    public static UserDTO ToDTO(this User newUser){
        return new(
        newUser.UserId,    
        newUser.Name!,
        newUser.LastName!,
        newUser.Address!,
        newUser.Email!,
        newUser.Phone
        );
    }

    public static User ToEntity(this CreateUserDTO newUserDto){
        return new User(){
           Name = newUserDto.Name,
           LastName = newUserDto.Last_Name,
           Address = newUserDto.Address,
           Email = newUserDto.Email,
           Phone = newUserDto.Phone
          };
    }
 
};