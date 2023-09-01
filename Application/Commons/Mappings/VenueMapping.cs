using Application.UseCases.Venues.Commands;
using Application.UseCases.Venues.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Commons.Mappings;

public class VenueMapping : Profile
{
    public VenueMapping()
    {
        CreateMap<CreateVenueCommand, Venue>().ReverseMap();
        CreateMap<GetAllVenueQueryResponse, Venue>().ReverseMap();
    }
}
