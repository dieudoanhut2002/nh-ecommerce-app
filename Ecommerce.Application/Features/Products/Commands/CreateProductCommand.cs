using MediatR;

namespace Ecommerce.Application.Features.Products.Commands;

public sealed class CreateProductCommand : IRequest<Guid>
{
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public int Stock { get; init; }
}
