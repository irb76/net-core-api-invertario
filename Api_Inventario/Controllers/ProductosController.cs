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
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("productos").Result; 
            if (response.IsSuccessStatusCode)
            {
                var productos = response.Content.ReadAsStringAsync().Result;
                return productos;
            }
            else
            {
                return "error: no se ha podido obtener registros";
            }

        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("producto/" + id).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var producto = response.Content.ReadAsStringAsync().Result;
                return producto;
            }
            else
            {
                return "error: no se ha podido obtener registros";
            }
        }

        [HttpPost]
        public void Post([FromBody] Producto p)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/");
                var response = client.PostAsJsonAsync("producto", p).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("exito");
                }
                else
                    Console.Write("Error");
            }
        }

        
        [HttpPut]
        public void Put([FromBody] Producto p)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/");
                var response = client.PutAsJsonAsync("producto", p).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("exito");
                }
                else
                    Console.Write("Error");
            }
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/");
                var response = client.DeleteAsync("producto/" + id).Result;
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
