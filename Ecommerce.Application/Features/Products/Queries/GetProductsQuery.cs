using Ecommerce.Application.DTOs;
using MediatR;

namespace Ecommerce.Application.Features.Products.Queries;

public sealed record GetProductsQuery : IRequest<IReadOnlyList<ProductDto>>;
