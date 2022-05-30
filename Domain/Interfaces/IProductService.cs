using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        public Task<ProductDto> GetProductByIdAsync(string id);
        public Task<ProductDto> GetProductByNameAsync(string name);
        public Task<IEnumerable<ProductDto>> GetProductsByNameAsync(string name);
        public Task CreateProductAsync(ProductDto productDto);
        public Task<ProductDto> UpdateProductAsync(ProductDto productDto);
        public Task DeleteProductAsync(ProductDto productDto);

            
    }
}
