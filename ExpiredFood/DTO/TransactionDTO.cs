namespace ExpiredFood.DTO;

public record class TransactionDTO
(
int Trx_Id,
DateTime Due_date,
DateTime Timestamp,
string Observations
);