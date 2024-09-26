using System;
using ExpiredFood.Frontend.Models;

namespace ExpiredFood.Frontend.Clients;

public class CategoriesClient(HttpClient httpClient)
{

    public async Task<Category[]> GetCategoriesAsync()
    => await httpClient.GetFromJsonAsync<Category[]>("categories") ?? [];
}
