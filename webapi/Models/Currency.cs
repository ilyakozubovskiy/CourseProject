using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models;

public partial class Currency
{
    public int CurrencyId { get; set; }

    public string? CurrencyName { get; set; }

}
