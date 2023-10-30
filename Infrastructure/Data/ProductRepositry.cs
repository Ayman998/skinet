using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepositry : IProductRepositry
    {
        private readonly StoreContext _context;
        public ProductRepositry(StoreContext context)
        {
            _context = context;

        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(p=>p.ProductBrand)
            .Include(p=>p.ProductType)
            .FirstOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.Include(p=>p.ProductBrand)
            .Include(p=>p.ProductType)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.productTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.productBrands.ToListAsync();
        }
    }
}