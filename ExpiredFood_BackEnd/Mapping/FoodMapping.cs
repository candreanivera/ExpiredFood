using System;
using ExpiredFood_BackEnd.DTO;
using ExpiredFood_BackEnd.Entities;

namespace ExpiredFood.Mapping;

public static class FoodMapping
{
    public static FoodDTO ToDTO(this Food newFood){
        return new(
        newFood.FoodId,    
        newFood.Name!,
        newFood.Brand!,
        newFood.Category!.Name!
        );
    }

    public static Food ToEntity(this CreateFoodDTO newFoodDto){
        return new Food(){
           Name = newFoodDto.Name,
           Brand = newFoodDto.Brand,
           CategoryId = newFoodDto.CategoryId
          };
    }

    public static FoodResumeDTO ToResumeDTO(this Food newFoodb){
        return new(
        newFoodb.FoodId,  
        newFoodb.Name!,
        newFoodb.Brand!,
        newFoodb.CategoryId
        );
    }   
};