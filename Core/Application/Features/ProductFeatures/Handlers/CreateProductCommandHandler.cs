using Application.Features.ProductFeatures.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductFeatures.Handlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Barcode = request.Barcode,
            Name = request.Name,
            Rate = request.Rate,
            Description = request.Description,
        };

        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync();

        return product;
    }
}