using Application.UseCases.ScheduledEvents.Commands;
using Application.UseCases.ScheduledEvents.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Commons.Mappings;

public class ScheduledEventMapping : Profile
{
    public ScheduledEventMapping()
    {
        CreateMap<CreateScheduledEventCommand, ScheduledEvent>().ReverseMap();
        CreateMap<GetAllScheduledEventQueryResponse, ScheduledEvent>().ReverseMap();
    }
}
