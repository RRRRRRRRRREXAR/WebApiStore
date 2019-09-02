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
    [EnableCors(origins: "https://localhost:4200", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        IProductService productService;
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}