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
    [EnableCors(origins: "https://localhost:4200", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        IProductService productService;
        IAdminService adminService;
        public CategoryController(IProductService productService,IAdminService adminService)
        {
            this.adminService = adminService;
            this.productService = productService;
        }
        // GET api/<controller>
        public IEnumerable<ProductCategoryDTO> Get()
        {
            return productService.GetCategories();
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            productService.GetCategory(id);
            return Ok();
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]ProductCategoryDTO value)
        {
            adminService.CreateCategory(value);
            return Ok();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}