using Akakce.Application.Interfaces;
using Akakce.Application.Wrappers;
using Entities = Akakce.Domain.Entities;
using AutoMapper;
using MediatR;
using Akakce.Application.Exceptions;

namespace Akakce.Application.Features.Basket;

public partial class AddItemToBasketCommand : IRequest<Response<string>>
{
    public long UserId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
}
public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommand, Response<string>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddItemToBasketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = _mapper.Map<Entities.Basket>(request);
        await _unitOfWork.Baskets.AddAsync(basket);
        await _unitOfWork.CompleteAsync();
        return new Response<string>("Sepete başarı ile eklendi.");
    }
}
