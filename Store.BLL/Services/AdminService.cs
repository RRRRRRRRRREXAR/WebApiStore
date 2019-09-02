using Store.BLL.DTO;
using Store.BLL.Infrastructure;
using Store.BLL.Interfaces;
using Store.DAL.Entites;
using Store.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Services
{
    public class AdminService:IAdminService
    {
        private IUnitOfWork uow;
        public AdminService(IUnitOfWork wrk)
        {
            uow = wrk;
        }

        public void CreateProduct(ProductDTO product)
        {
            uow.Products.Create(new Product { CategoryId=product.Category.Id, Description=product.Description, Name=product.Name, Price=product.Price });
            uow.Save();
        }

        public void UpdateProduct(ProductDTO product)
        {
            uow.Products.Update(new Product {Id=product.Id, CategoryId = product.Category.Id, Description=product.Description, Name=product.Name, Price=product.Price});
            uow.Save();
        }

        public void DeleteProduct(int id)
        {
            uow.Products.Delete(id);
            uow.Save();
        }

        public void CreateCategory(ProductCategoryDTO category)
        {
            uow.Categories.Create(new ProductCategories { Name=category.Name });
            uow.Save();
        }

        public void UpdateCategory(ProductCategoryDTO category)
        {
            uow.Categories.Update(new ProductCategories { Name=category.Name,Id=category.Id});
            uow.Save();
        }

        public void DeleteCategory(ProductCategoryDTO category)
        {
            uow.Categories.Delete(category.Id);
            uow.Save();
        }
        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
