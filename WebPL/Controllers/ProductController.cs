using Store.BLL.DTO;
using Store.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebPL.Controllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
        IProductService service;
       
        public ProductController(IProductService service)
        {
            this.service = service;
        }
        public IEnumerable<ProductDTO> Get()
        {
            return service.GetAllProducts().ToList();
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
