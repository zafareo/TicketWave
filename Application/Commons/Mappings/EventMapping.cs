using Application.UseCases.Events.Commands;
using Application.UseCases.Events.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Commons.Mappings;

public class EventMapping : Profile
{
    public EventMapping()
    {
        CreateMap<CreateEventCommand, Event>().ReverseMap();
        CreateMap<GetAllEventsQueryResponse, Event>().ReverseMap();
    }
}
