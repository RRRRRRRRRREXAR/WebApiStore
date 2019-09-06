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
        public IProductService productService;

        public OrderController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET api/<controller>
        public IHttpActionResult Post([FromBody]CartModel token)
        {
            OrderDTO order = new OrderDTO();
            var s = SessionServer.Cart[token.Token];
            order.Products = new List<ProductDTO>();

            foreach (var el in s)
            {
                order.Products.Add(new ProductDTO {Id=el.Id, Description=el.Description, Name=el.Name, Price=el.Price, Category=new ProductCategoryDTO {Id=el.Category.Id,Name=el.Category.Name } });
            }
            productService.MakeOrder(order);
            return Ok();
        }

    }
}