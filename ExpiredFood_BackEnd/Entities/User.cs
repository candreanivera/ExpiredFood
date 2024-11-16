using System;

namespace ExpiredFood_BackEnd.Entities;

public class User
{  
    public int UserId { get; set; }
    public string ?Name { get; set; }
    public string ?LastName { get; set; }
    public string ?Address { get; set; }
    public string ?Email { get; set; }
    public int Phone { get; set; } = 0;
    public ICollection<Transaction> ?Transactions { get; set; }

}
