using AutoMapper;
using Entity = Akakce.Domain.Entities;
using DTO = Akakce.Application.Features;

namespace Akakce.Application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        CreateMap<DTO.Basket.AddItemToBasketCommand, Entity.Basket>();
    }
}
