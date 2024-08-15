namespace ExpiredFood.DTO;

public record class TransactionDTO
(
int Trx_Id,
int UserID,
DateTime Due_date,
int FoodId,
DateTime Timestamp,
string Observations
);