using Akakce.Application.Interfaces.Repositories;
using FluentValidation;

namespace Akakce.Application.Features.Basket;

public class AddItemToBasketCommandValidator : AbstractValidator<AddItemToBasketCommand>
{
    private readonly IProductRepositoryAsync productRepository;
    private readonly IStockRepositoryAsync stockRepository;

    public AddItemToBasketCommandValidator(IProductRepositoryAsync productRepository, IStockRepositoryAsync stockRepository)
    {
        this.productRepository = productRepository;
        this.stockRepository = stockRepository;

        RuleFor(p => p.UserId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(p => p.ProductId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MustAsync(IsValidProduct).WithMessage("Geçerli bir ürün değil.")
            .DependentRules(() =>
            {
                RuleFor(p => p.Quantity)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MustAsync((item, quantity, cancellationToken) => { return IsStockEnough(item.Quantity, item.ProductId, cancellationToken); })
                    .WithMessage("Sepete eklemeye çalıştığınız ürün stoklarda yeteri miktarda bulunmamaktadır.");
            });
    }

    private async Task<bool> IsValidProduct(long productId, CancellationToken cancellationToken)
    {
        return await productRepository.IsValidProductAsync(productId);
    }

    private async Task<bool> IsStockEnough(int quantity, long productId, CancellationToken cancellationToken)
    {
        return await stockRepository.IsStockEnoughAsync(quantity, productId);
    }


}
