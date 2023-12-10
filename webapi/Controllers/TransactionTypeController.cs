using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using webapi.Models;

namespace webapi.Controllers;

[ApiController]
[Route("TransactionType")]
public class TransactionTypeController : ControllerBase
{

    private readonly ILogger<ClientController> _logger;

    public TransactionTypeController(ILogger<ClientController> logger)
    {
        _logger = logger;
    }



    [HttpGet("GetTransactionTypes")]
    public IEnumerable<TransactionType> GetTransactionTypes()
    {
        using (var db = new LocalContext())
        {
            return db.TransactionTypes.ToList();
        }
    }


}
