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
    [Authorize]
    public class OrderController : ApiController
    {
        IProductService productService;
       
        // GET api/<controller>
        public IHttpActionResult Post(string token)
        {
            OrderDTO order = new OrderDTO();
            order.Products=
            productService.MakeOrder(new UserDTO { Email=User. },order);
            return Ok();
        }

    }
}