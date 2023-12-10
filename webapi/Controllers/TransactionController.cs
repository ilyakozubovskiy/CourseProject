using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using webapi.DAL;
using webapi.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{

    private readonly ILogger<TransactionController> _logger;

    public TransactionController(ILogger<TransactionController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetTransactions")]
    public IEnumerable<Transaction> GetTransactions(int parameter)
    {
        using (var db = new LocalContext())
        {
            return db.Transactions.ToList().Where(c => (c.ClientId == parameter || c.TransactionId == parameter));
        }
    }

    [HttpPost("AddTransaction")]
    public HttpResponseMessage AddTransaction(decimal amount,int cardNumber, DateTime date,
        string type, int clientId, string name, string surname, string currency )
    {
        using (var db = new LocalContext())
        {
            Transaction transaction = new Transaction
            {
                Amount = amount,
                CardNumber = cardNumber,
                Date = date,
                Type = type,
                ClientId = clientId,
                Name = name,
                Surname = surname,
                Currency = currency
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.Created);

        }
    }

    [HttpPut("EditTransaction")]
    public HttpResponseMessage EditTransaction(int transactionId, string? type = null, 
        decimal? amount = null, int? cardNumber = null, DateTime? date = null)
    {
        using (var db = new LocalContext())
        {
            var transaction = db.Transactions.SingleOrDefault(c => c.TransactionId == transactionId);
            if (transaction != null)
            {
                transaction.Amount = amount ?? transaction.Amount;
                transaction.CardNumber = cardNumber ?? transaction.CardNumber; 
                transaction.Date = date ?? transaction.Date;
                transaction.Type = type ?? transaction.Type;

                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }

            return new HttpResponseMessage(HttpStatusCode.NoContent);

        }
    }

    [HttpGet("GetTransaction")]
    public Transaction? GetTransaction(int transactionId)
    {
        using (var db = new LocalContext())
        {
            return db.Transactions.SingleOrDefault(c => c.TransactionId == transactionId);
        }
    }
    

    [HttpDelete("DeleteTransaction")]
    public HttpResponseMessage DeleteTransaction(int transactionId)
    {
        using (var db = new LocalContext())
        {
            var  transaction= db.Transactions.SingleOrDefault(c => c.TransactionId == transactionId);
            if (transaction != null)
            {
                db.Transactions.Remove(transaction);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
        }
    }
}
