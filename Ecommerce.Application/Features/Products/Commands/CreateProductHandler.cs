using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Features.Products.Commands
{
    public class CreateProductHandler
    {
        private readonly IProductRepository _repo;

        public CreateProductHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateProductCommand command)
        {
            Product product = new Product
            {
                Name = command.Name,
                Price = command.Price,
                Stock = 0
            };

            await _repo.AddAsync(product);
            return product.Id;
        }
    }
}
