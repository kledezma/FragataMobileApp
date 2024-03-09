using FragataAssist.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragataAssist.Services.ProductService
{
    public interface IProductRepository
    {
        Task<bool> AddUpdateProductAsync(ProductInfo productInfo);
        Task<bool> DeleteProductAsync(int prodId);
        Task<ProductInfo> GetProductAsync(int prodId);
        Task<IEnumerable<ProductInfo>> GetProductsAsync();

    }
}
