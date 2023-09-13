using System;
using System.Collections.Generic;
using System.Linq;
using Homework.Data;
using Homework.Models;

namespace Homework.Repository
{
    public class ProductRepository
    {
        private readonly HomeworkDbContext _context;

        public ProductRepository(HomeworkDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public void Create(Product product)
        {
            if (product != null)
            {
                product.ProductId = Guid.NewGuid();
                _context.Products.Add(product);
                _context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public bool Exists(Guid id)
        {
            return _context.Products.Any(p => p.ProductId == id);
        }
    }
}
