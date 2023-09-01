using Application.UseCases.Customers.Commands;
using Application.UseCases.Customers.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Commons.Mappings;

public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<CreateCustomerCommand, Customer>().ReverseMap();
        CreateMap<GetAllCustomersQueryResponse, Customer>().ReverseMap();
    }
}