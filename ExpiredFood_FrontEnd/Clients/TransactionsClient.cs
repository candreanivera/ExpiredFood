using System;
using ExpiredFood.Frontend.Models;

namespace ExpiredFood.Frontend.Clients;

public class TransactionsClient(HttpClient httpClient)
{

    public async Task<TransactionDetails[]> GetTransactionsAsync()
    => await httpClient.GetFromJsonAsync<TransactionDetails[]>("transactions") ?? [];

    public async Task<TransactionCreate> GetTransactionAsync(int id)
    => await httpClient.GetFromJsonAsync<TransactionCreate>($"transactions/{id}") 
    ?? throw new Exception("Transaction not found");

    public async Task UpdateTransactionAsync(TransactionCreate updatedtransaction)
     => await httpClient.PutAsJsonAsync($"transactions/{updatedtransaction.Id}", updatedtransaction);

    public async Task AddTransactionAsync(TransactionCreate newtransaction)
    => await httpClient.PostAsJsonAsync("transactions", newtransaction);

    public async Task DeleteTransactionAsync(int id)
   => await httpClient.DeleteAsync($"transactions/{id}");
}
