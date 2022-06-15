using CommonLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class ProductService
    {
        private readonly ProductDbContext _dbContext;

        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            return GetProductsInternal();
        }

        public void CreateProduct(ProductDto product)
        {
            var p = new Product();
            p.ProductName = product.ProductName;
            p.UnitPrice = product.UnitPrice;
            p.Category = _dbContext.Categories.Where(e => e.CategoryId == product.CategoryId).FirstOrDefault();
            p.UnitsInStock = product.UnitsInStock;
            p.QuantityPerUnit = product.QuantityPerUnit;
            p.CategoryName = p.Category.CategoryName;
            p.CategoryDescription = p.Category.Description;
            _dbContext.Add(p);
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(ProductDto product)
        {
            var p = _dbContext.Products.Where(e => e.ProductId == product.ProductId).FirstOrDefault();
            p.ProductName = product.ProductName;
            p.UnitPrice = product.UnitPrice;
            p.Category = _dbContext.Categories.Where(e => e.CategoryId == product.CategoryId).FirstOrDefault();
            p.UnitsInStock = product.UnitsInStock;
            p.QuantityPerUnit = product.QuantityPerUnit;
            p.CategoryName = p.Category.CategoryName;
            p.CategoryDescription = p.Category.Description;
            _dbContext.SaveChanges();

  
        }

        public void DeleteProduct(ProductDto product)
        {
            var p = _dbContext.Products.Where(e => e.ProductId == product.ProductId).FirstOrDefault();
            _dbContext.Remove(p);
            _dbContext.SaveChanges();
        }


        private IEnumerable<ProductDto> GetProductsInternal()
        {
     
            return _dbContext.Products.Include("Category").ToList().Select(ProductDto.ProductFunc).ToList(); ;
        }
    }
}
