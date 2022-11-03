using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Inventario.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        // GET: api/<ClientesController>
        [HttpGet]
        public string Get()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = client.GetAsync("clientes").Result;
            if (response.IsSuccessStatusCode)
            {
                var clientes = response.Content.ReadAsStringAsync().Result;
                return clientes;
            }
            else
            {
                return "error: no se ha podido obtener registros";
            }

        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = client.GetAsync("cliente/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var clientes = response.Content.ReadAsStringAsync().Result;
                return clientes;
            }
            else
            {
                return "error: no se ha podido obtener registros";
            }
        }

        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] Cliente c)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/");
                var response = client.PostAsJsonAsync("cliente", c).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("exito");
                }
                else
                    Console.Write("Error");
            }
        }

        // PUT api/<ClientesController>/5
        [HttpPut]
        public void Put([FromBody] Cliente c)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/");
                var response = client.PutAsJsonAsync("cliente", c).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("exito");
                }
                else
                    Console.Write("Error");
            }
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/");
                var response = client.DeleteAsync("cliente/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                }
                else
                    Console.Write("Error");
            }
        }
    }
}
