using Store.BLL.DTO;
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
        // GET api/<controller>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IEnumerable<ProductViewModel> Get(string token)
        {
            CreateNewCart(token);
            return SessionServer.Cart[token];
        }
        
        // POST api/<controller>
        public IHttpActionResult Post([FromBody]ProductViewModel value,string token)
        {
            token = CreateNewCart(token); 
            SessionServer.Cart[value.SessionId].Add(value);
            return Ok();
        }

      

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(string token,int id)
        {
            token= CreateNewCart(token);
            SessionServer.Cart[token].RemoveAt(id);
            return Ok();
        }
        private string CreateNewCart(string token)
        {
            if (token == null)
            {
                Guid g = Guid.NewGuid();
                SessionServer.Cart[g.ToString()] = new List<ProductViewModel>();
                return g.ToString();
            }
            else
            {
                return token;
            }
        }
    }
}