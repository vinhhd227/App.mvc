using mvc.Models;

namespace mvc.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[] {
                new ProductModel() { Id = 1, Name = "iphone X", Price = 1000},
                new ProductModel() { Id = 2, Name = "Samsung", Price = 1200},
                new ProductModel() { Id = 3, Name = "Nokia", Price = 900},
                new ProductModel() { Id = 4, Name = "Huawei", Price = 999}
            });
        }
    }
}