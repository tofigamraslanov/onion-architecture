using Domain.Entities;
using MediatR;

namespace Application.Features.ProductFeatures.Queries;

public record GetProductByIdQuery(int Id) : IRequest<Product>;
