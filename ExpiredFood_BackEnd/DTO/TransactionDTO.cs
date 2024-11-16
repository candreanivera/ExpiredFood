namespace ExpiredFood_BackEnd.DTO;

public record class TransactionDTO
(
int TrxId,
int UserID,
string UserName,
DateTime Due_date,
int CategoryId,
string CategoryName,
DateTime Timestamp,
string Observations
);