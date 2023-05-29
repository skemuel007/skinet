using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        if (!context.ProductBrands.Any())
        {
            var brandsData = File.ReadAllText("../Infrastructure/SeedData/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            context.ProductBrands.AddRange(brands);
        }
        
        if (!context.ProductTypes.Any())
        {
            var productTypesData = File.ReadAllText("../Infrastructure/SeedData/types.json");
            var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypesData);
            context.ProductTypes.AddRange(productTypes);
        }
        
        if (!context.Products.Any())
        {
            var productsData = File.ReadAllText("../Infrastructure/SeedData/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            context.Products.AddRange(products);
        }

        if (context.ChangeTracker.HasChanges())
            await context.SaveChangesAsync();
    }
}