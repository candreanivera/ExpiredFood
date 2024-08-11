using System;

namespace ExpiredFood.Entities;

public class Food
{
    int Food_Id { get; set; }
    string ?Name { get; set; }
    DateTime Expiration_Date { get; set; }
    int Category_Id { get; set; }
}
