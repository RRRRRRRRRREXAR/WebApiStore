using Store.BLL.DTO;
using Store.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebPL.Models;

namespace WebPL.Controllers
{
    public class CartController : ApiController
    {
        private IProductService service;
        // GET api/<controller>
        public CartController(IProductService service)
        {
            this.service = service;
        }
        public IEnumerable<ProductViewModel> Get(string token)
        {
            return SessionServer.Cart[token];
        }
        public string Get()
        {
            Guid g = Guid.NewGuid();
            SessionServer.Cart[g.ToString()] = new List<ProductViewModel>();
            return g.ToString();
        }
        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Test test)
        {
            var addedProduct= service.GetProduct(test.Id);
            ProductViewModel pr = new ProductViewModel { Id = addedProduct.Id, Category = new CategoryViewModel { Id = addedProduct.Category.Id, Name = addedProduct.Name }, Description = addedProduct.Description, Name = addedProduct.Name, Price = addedProduct.Price };
            SessionServer.Cart[test.Token].Add(pr);
            return Ok();
        }

      

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(string token,int id)
        {
            
            SessionServer.Cart[token].RemoveAt(id);
            return Ok();
        }
        
    }

   public class Test
    {
        public int Id { get; set; }
            
       public string Token { get; set; }
    }
}