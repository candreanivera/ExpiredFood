namespace ExpiredFood.DTO;

public record class TransactionDTO
(
int Id_Trx,
DateTime Due_date,
string Food_Name,
DateTime Timestamp,
string Observations
);