using Domain.Entities;
using MediatR;

namespace Application.Features.ProductFeatures.Commands;

public record CreateProductCommand
    (string Name, string Barcode, string Description, decimal Rate) : IRequest<Product>;
