using System;

namespace ExpiredFood.Entities;

public class User
{  
    int User_Id { get; set; }
    string ?Name { get; set; }
    string ?LastName { get; set; }
    string ?Address { get; set; }
    string ?Email { get; set; }
    int Phone { get; set; }
    int Household_Id { get; set; }

}
