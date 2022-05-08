using Application.Features.ProductFeatures.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductFeatures.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);

        if (product == null) return default!;

        product.Barcode = request.Barcode;
        product.Name = request.Name;
        product.Rate = request.Rate;
        product.Description = request.Description;

        await _context.SaveChangesAsync();

        return product;
    }
}