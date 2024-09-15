namespace ExpiredFood.DTO;

public record class TransactionDTO
(
int TrxId,
int UserID,
string UserName,
DateTime Due_date,
int FoodId,
string FoodName,
DateTime Timestamp,
string Observations
);