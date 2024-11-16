using System;
using System.ComponentModel.DataAnnotations;

namespace ExpiredFood.Frontend.Models;

public class TransactionCreate
{   
    public int Id { get; set; }
    [Required(ErrorMessage = "User field is required")]
    public int UserID{ get; set; }
    public DateTime Due_Date { get; set; }  

    [Required(ErrorMessage = "Category field is required")]
    public int CategoryId { get; set; }
    public DateTime Date { get; set; }
    public string ?Observations { get; set; }
}
