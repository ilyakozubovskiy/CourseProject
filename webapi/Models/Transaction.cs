using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int ClientId { get; set; }
    public string? Name { get; set; }

    public string? Surname { get; set; }

    public decimal? Amount { get; set; }

    public string? Type { get; set; }

    public DateTime Date { get; set; }

    public int CardNumber { get; set; }

    public string? Currency { get; set; }

    public virtual Client Client { get; set; } = null!;
}
