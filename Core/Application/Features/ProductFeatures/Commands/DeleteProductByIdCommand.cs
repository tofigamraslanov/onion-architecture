using MediatR;

namespace Application.Features.ProductFeatures.Commands;

public record DeleteProductByIdCommand(int Id) : IRequest<int>;
