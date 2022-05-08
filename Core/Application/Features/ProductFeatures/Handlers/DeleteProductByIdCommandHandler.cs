using Application.Features.ProductFeatures.Commands;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProductFeatures.Handlers;

public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
{
    private readonly IApplicationDbContext _context;

    public DeleteProductByIdCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);

        if (product == null) return default;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return product.Id;
    }
}