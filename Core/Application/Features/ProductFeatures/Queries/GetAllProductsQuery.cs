using Domain.Entities;
using MediatR;

namespace Application.Features.ProductFeatures.Queries;

public record GetAllProductsQuery : IRequest<IEnumerable<Product>>;
 