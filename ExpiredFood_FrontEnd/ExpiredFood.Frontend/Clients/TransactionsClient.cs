using System;
using ExpiredFood.Frontend.Models;

namespace ExpiredFood.Frontend.Clients;

public class TransactionsClient(HttpClient httpClient)
{

    public async Task<TransactionDetails[]> GetTransactionsAsync()
    => await httpClient.GetFromJsonAsync<TransactionDetails[]>("transactions") ?? [];

    public async Task AddTransactionAsync(TransactionCreate newtransaction)
    => await httpClient.PostAsJsonAsync("transactions", newtransaction);
}
