using AutoMapper;

namespace NBPApp.Models.Mappers
{
    public class CurrencyBaseToViewModelProfile : Profile
    {
        public CurrencyBaseToViewModelProfile()
        {
            CreateMap<CurrencyDto, CurrencyViewModel>()
            .ForMember(
                dest => dest.Code,
                opt => opt.MapFrom(src => src.Code)
            )
            .ForMember(
                dest => dest.Currency,
                opt => opt.MapFrom(src => src.Currency)
            )
            .ForMember(
                dest => dest.EffectiveDate,
                opt => opt.MapFrom(src => src.EffectiveDate)
            )
            .ForMember(
                dest => dest.Mid,
                opt => opt.MapFrom(src => src.Mid.HasValue ? src.Mid : src.Bid + src.Ask / 2)
            );
        }

    }
}
