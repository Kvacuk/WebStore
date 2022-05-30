using AutoMapper;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Domain.DTO;
using Domain.Interfaces;
using System.Text.RegularExpressions;

namespace Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork context, IMapper mapper)
        {
            _database = context;
            _mapper = mapper;
        }

        public async Task CreateProductAsync(ProductDto productDto)
        {
            await _database.ProductRepository.AddAsync(_mapper.Map<Product>(productDto));
        }

        public async Task DeleteProductAsync(ProductDto productDto)
        {
            await _database.ProductRepository.RemoveAsync(_mapper.Map<Product>(productDto));
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _database.ProductRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(string id)
        {
            var expressionForGuid = @"^\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";
            if (!String.IsNullOrWhiteSpace(id) && Regex.IsMatch(id, expressionForGuid))
            {
                Guid.TryParse(id, out Guid productId);
                var item = await _database.ProductRepository.GetByIdAsync(productId);
                if (item != null)
                {
                    var product = _mapper.Map<ProductDto>(item);
                    return product;
                }
                else
                    throw new ArgumentException("Announcement with current Id wasn't found");
            }
            else
            {
                throw new ArgumentException("Wrong filled Id`s format");
            }
        }

        public async Task<ProductDto> GetProductByNameAsync(string name)
        {
            var product = await _database.ProductRepository.FindFirstAsync(x => x.Name.Contains(name));
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByNameAsync(string name)
        {
            var products = await _database.ProductRepository.FindAsync(x => x.Name.Contains(name));
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> UpdateProductAsync(ProductDto productDto)
        {
            var product = await GetProductByIdAsync(productDto.Id.ToString());
            await _database.ProductRepository.UpdateAsync(_mapper.Map<Product>(product));
            return product;
        }
    }
}
