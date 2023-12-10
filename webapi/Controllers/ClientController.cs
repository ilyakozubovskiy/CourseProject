using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using webapi.Models;

namespace webapi.Controllers;

[ApiController]
[Route("Client")]
public class ClientController : ControllerBase
{

    private readonly ILogger<ClientController> _logger;

    public ClientController(ILogger<ClientController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetClient")]
    public Client? GetClient(int clientid)
    {
        using (var db = new LocalContext())
        {
            return db.Clients.SingleOrDefault(c => c.Id == clientid);
        }
    }

    [HttpGet("GetClients")]
    public IEnumerable<Client> GetClients()
    {
        using (var db = new LocalContext())
        {
            return db.Clients.ToList();
        }
    }

    [HttpPost("AddClient")]
    public HttpResponseMessage AddClient(int id, string name, string surname)
    {
        using (var db = new LocalContext())
        {
            Client client = new Client
            {
                Id = id,
                Name = name,
                Surname = surname
            };

            db.Clients.Add(client);
            db.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.Created);

        }
    }

    [HttpPut("EditClient")]
    public HttpResponseMessage EditClient(int clientId, string name, string surname)
    {
        using (var db = new LocalContext())
        {
            var client = db.Clients.SingleOrDefault(c => c.Id == clientId);
            if (client != null)
            {
                client.Name = name;
                client.Surname = surname;
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }

            return new HttpResponseMessage(HttpStatusCode.NoContent);

        }
    }

    [HttpDelete("DeleteClient")]
    public HttpResponseMessage DeleteClient(int clientId)
    {
        using (var db = new LocalContext())
        {
            var client = db.Clients.SingleOrDefault(c => c.Id == clientId);
            if (client != null)
            {
                db.Clients.Remove(client);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
        }
    }
}
