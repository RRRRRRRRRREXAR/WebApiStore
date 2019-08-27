using Store.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebPL.Models;

namespace WebPL.Controllers
{
    public class CartController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<ProductViewModel> Get(string sessionId)
        {
            return SessionServer.Cart[sessionId];
        }
            
        // POST api/<controller>
        public IHttpActionResult Post([FromBody]ProductViewModel value)
        {
            SessionServer.Cart[value.SessionId].Add(value);
            return Ok();
        }

      

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(string sessionId,int id)
        {
            SessionServer.Cart[sessionId].RemoveAt(id);
            return Ok();
        }
    }
}