using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models;

public partial class TransactionType
{
    public int TypeId { get; set; }

    public string? TypeName { get; set; }

}
