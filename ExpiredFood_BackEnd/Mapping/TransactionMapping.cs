using System;
using ExpiredFood_BackEnd.DTO;
using ExpiredFood_BackEnd.Entities;

namespace ExpiredFood.Mapping;

public static class TransactionMapping
{
    public static TransactionDTO ToDTO(this Transaction newTransactiondb){
        return new(
        newTransactiondb.TransactionId,    
        newTransactiondb.UserId,
        newTransactiondb.User!.Name!,
        newTransactiondb.Due_Date,
        newTransactiondb.CategoryId,
        newTransactiondb.Category!.Name!,
        newTransactiondb.Date,
        newTransactiondb.Observations!
        );
    }

    public static Transaction ToEntity(this CreateTransactionDTO newTransactionDTO){
        return new Transaction(){
           UserId = newTransactionDTO.UserId,
           Due_Date = newTransactionDTO.Due_date,
           CategoryId = newTransactionDTO.CategoryId,
           Date = newTransactionDTO.Timestamp,
           Observations = newTransactionDTO.Observations
          };
    }

    public static TransactionResumeDTO ToResumeDTO(this Transaction newTransactiondb){
        return new(
        newTransactiondb.TransactionId,    
        newTransactiondb.UserId,
        newTransactiondb.Due_Date,
        newTransactiondb.CategoryId,
        newTransactiondb.Date,
        newTransactiondb.Observations!
        );
    }   
};