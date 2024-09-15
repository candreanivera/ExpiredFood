using System;
using ExpiredFood.DTO;
using ExpiredFood.Entities;

namespace ExpiredFood.Mapping;

public static class TransactionMapping
{
    public static TransactionDTO ToDTO(this Transaction newTransactiondb){
        return new(
        newTransactiondb.TransactionId,    
        newTransactiondb.UserId,
        newTransactiondb.User!.Name!,
        newTransactiondb.Due_Date,
        newTransactiondb.FoodId,
        newTransactiondb.Food!.Name!,
        newTransactiondb.Date,
        newTransactiondb.Observations!
        );
    }

    public static Transaction ToEntity(this CreateTransactionDTO newTransactionDTO){
        return new Transaction(){
           UserId = newTransactionDTO.UserID,
           Due_Date = newTransactionDTO.Due_date,
           FoodId = newTransactionDTO.FoodId,
           Date = newTransactionDTO.Timestamp,
           Observations = newTransactionDTO.Observations
          };
    }

    public static TransactionResumeDTO ToResumeDTO(this Transaction newTransactiondb){
        return new(
        newTransactiondb.TransactionId,    
        newTransactiondb.UserId,
        newTransactiondb.Due_Date,
        newTransactiondb.FoodId,
        newTransactiondb.Date,
        newTransactiondb.Observations!
        );
    }   
};