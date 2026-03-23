// API/Controllers/ProductController.cs
using Ecommerce.Application.Features.Products.Commands;
using Ecommerce.Application.Features.Products.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly CreateProductHandler _createHandler;
    private readonly GetAllProductsHandler _getHandler;

    public ProductController(
        CreateProductHandler createHandler,
        GetAllProductsHandler getHandler)
    {
        _createHandler = createHandler;
        _getHandler = getHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        Guid id = await _createHandler.Handle(command);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Application.DTOs.ProductDto> result = await _getHandler.Handle();
        return Ok(result);
    }
}