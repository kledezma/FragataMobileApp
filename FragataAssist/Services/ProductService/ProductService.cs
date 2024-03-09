using FragataAssist.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragataAssist.Services.ProductService
{
    internal class ProductService : IProductRepository
    {
        public SQLiteAsyncConnection _db;
        string _dbPath;

        public ProductService(string dbPath)
        {
            _dbPath = dbPath;
            InitAsync();
        }

        private async Task InitAsync()
        {
            if(_db != null)
            {
                return;
            }
             _db = new SQLiteAsyncConnection(_dbPath);
            await _db.CreateTableAsync<ProductInfo>();
        }
        public async Task<bool> AddUpdateProductAsync(ProductInfo productInfo) {
            if(productInfo.Id > 0)
            {
                await _db.UpdateAsync(productInfo);
            }
            else
            {
                await _db.InsertAsync(productInfo);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteProductAsync(int prodId)
        {
            await _db.DeleteAsync<ProductInfo>(prodId);
            return await Task.FromResult(true);
        }
        public async Task<ProductInfo> GetProductAsync(int prodId)
        {
            return await _db.Table<ProductInfo>().Where(p => p.Id == prodId).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<ProductInfo>> GetProductsAsync()
        {
            await InitAsync();
            return await Task.FromResult(await _db.Table<ProductInfo>().ToListAsync());  
        }
    }
}
