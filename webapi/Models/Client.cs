using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
