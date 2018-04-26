using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoSunriseCargoRest.Models;

namespace DemoSunriseCargoRest.Controllers
{
    public class ClientController : ApiController
    {

        static List<Client> Clients = new List<Client>
        {
            new Client{Id=1, Name="De madre"},
            new Client{Id=2, Name="De madre2"},
                
        };

        [HttpGet]
        public List<Client> GetAll()
        {
            return Clients;
        }

        [HttpGet]
        public Client GetById(int idClient)
        {
            return Clients.FirstOrDefault(x => x.Id == idClient);
        }


        //[HttpPost]
        //public Client GetByFiltro([FromBody] Filtro objFiltro)
        //{
        //    return Clients.FirstOrDefault(x => x.Id == idClient);
        //}

        [HttpPost]
        public void Add([FromBody]Client client)
        {
            Clients.Add(client);
        }
        [HttpPatch]
        public bool Update(Client client)
        {
            var found = Clients.FirstOrDefault(x => x.Id == client.Id);
            found.Name = client.Name;
            return true;

        }
        [HttpDelete]
        public bool Delete(int idClient)
        {
            Clients.RemoveAll(x => x.Id == idClient);
            return true;

        }
    }
}
