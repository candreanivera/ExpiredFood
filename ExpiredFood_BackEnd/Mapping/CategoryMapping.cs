using System;
using ExpiredFood_BackEnd.Entities;
using ExpiredFood_BackEnd.DTO;
using ExpiredFood.Mapping;

namespace ExpiredFood.Mapping;

public static class CategoryMapping
{

    public static Category toEntity(this CreateCategoryDTO newCategoryDTO){
        return new Category(){
        Name = newCategoryDTO.Name
    };
    }

    public static CategoryDTO ToDTO(this Category newCategorydb){
        return new(
            newCategorydb.CategoryId,
            newCategorydb.Name
        );
    }
}
