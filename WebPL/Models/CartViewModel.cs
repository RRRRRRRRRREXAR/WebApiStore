using Store.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPL.Models
{
    public class CartViewModel
    {
        public string SessionId { get; set; }
        List<ProductDTO> Cart = new List<ProductDTO>();
    }
}