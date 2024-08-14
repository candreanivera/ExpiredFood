using System;

namespace ExpiredFood.Entities;

public class User
{  
    public int UserId { get; set; }
    string ?Name { get; set; }
    string ?LastName { get; set; }
    string ?Address { get; set; }
    string ?Email { get; set; }
    int Phone { get; set; } = 0;
    public ICollection<Transaction> ?Transactions { get; set; }

}
