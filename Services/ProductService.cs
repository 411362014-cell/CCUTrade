using System.Collections.Generic;
using System.Threading.Tasks;
using CCUTrade.Data;
using CCUTrade.Models;
using Microsoft.EntityFrameworkCore;

namespace CCUTrade.Services;

public class ProductService
{
    public async Task AddProduct(Product product)
    {
        using var db = new AppDbContext();

        db.Products.Add(product);

        await db.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAllProducts()
    {
        using var db = new AppDbContext();

        return await db.Products.ToListAsync();
    }
}