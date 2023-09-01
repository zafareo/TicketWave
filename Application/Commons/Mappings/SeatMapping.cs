using Application.UseCases.Seats.Commands.CreateSeat;
using Application.UseCases.Seats.Queries.AllSeats;
using AutoMapper;
using Domain.Entities;

namespace Application.Commons.Mappings;

public class SeatMapping : Profile
{
    public SeatMapping()
    {
        CreateMap<CreateSeatCommand, Seat>().ReverseMap();
        CreateMap<GetAllSeatsQueryResponse, Seat>().ReverseMap();
    }
}
