using Store.BLL.DTO;
using Store.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebPL.Controllers
{
   // [EnableCors(origins: "https://localhost:4200", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        // GET: api/Product
        IProductService ProductService;
        IAdminService AdminService;
       
        public ProductController(IProductService service,IAdminService adminService)
        {
            this.ProductService = service;
            this.AdminService = adminService;
        }
        public IEnumerable<ProductDTO> Get()
        {
            return ProductService.GetAllProducts().ToList();
        }

        // GET: api/Product/5
        public object Get(int id)
        {
            return Ok(ProductService.GetProduct(id));
        }

        [Authorize(Roles ="admin")]
        // POST: api/Product
        public void Post([FromBody]ProductDTO value)
        {
            AdminService.CreateProduct(value);
        }

        [Authorize(Roles = "admin")]
        // PUT: api/Product
        public void Put([FromBody]ProductDTO value)
        {
            AdminService.UpdateProduct(value);
        }

        [Authorize(Roles = "admin")]
        // DELETE: api/Product/5
        public void Delete(int id)
        {
            AdminService.DeleteProduct(id);
        }
    }
}
