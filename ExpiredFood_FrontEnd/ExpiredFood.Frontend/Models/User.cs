using System;

namespace ExpiredFood.Frontend.Models;

public class User
{
    public int UserID { get; set; }
    public string? Name { get; set; }
    public string? last_Name { get; set; }
    public string? address { get; set; }
    public string? email { get; set; }
    public int phone { get; set; } = 0;
}
