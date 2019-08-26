using Store.BLL.DTO;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPL.Models
{
    public static class SessionServer
    {
        public static ConcurrentDictionary<string, List<ProductDTO>> Cart = new ConcurrentDictionary<string, List<ProductDTO>>();
}