using AutoMapper;

using ContosoPizza.API.Models;
using ContosoPizza.API.DTOs.Requests;
using ContosoPizza.API.DTOs.Responses;

namespace ContosoPizza.API.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Pizza, GetPizzasDTO>();
        CreateMap<PostPizzaRequest, Pizza>();
        CreateMap<PutPizzaRequest, Pizza>();
    }
}
