namespace ExpiredFood_BackEnd.DTO;

public record class TransactionResumeDTO
(
int TrxId,
int UserID,
DateTime Due_date,
int FoodId,
DateTime Timestamp,
string Observations
);