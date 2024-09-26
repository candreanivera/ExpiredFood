using System;
using ExpiredFood.Frontend.Models;

namespace ExpiredFood.Frontend.Clients;

public class UsersClient(HttpClient httpClient)
{

    public async Task<User[]> GetUsersAsync()
    => await httpClient.GetFromJsonAsync<User[]>("Users") ?? [];
}
