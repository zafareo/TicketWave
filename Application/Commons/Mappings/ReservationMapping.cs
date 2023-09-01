using Application.UseCases.Reservations.Commands.CreateReservation;
using Application.UseCases.Reservations.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Commons.Mappings;

public class ReservationMapping : Profile
{
    public ReservationMapping()
    {
        CreateMap<CreateReservationCommand, Reservation>().ReverseMap();
        CreateMap<GetAllReservationsQueryResponse, Reservation>().ReverseMap();
    }
}