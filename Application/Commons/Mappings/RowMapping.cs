using Application.UseCases.Rows.Commands;
using Application.UseCases.Rows.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Commons.Mappings;

public class RowMapping : Profile
{
    public RowMapping()
    {
        CreateMap<CreateRowCommand, Row>().ReverseMap();
        CreateMap<GetAllRowsQueryResponse, Row>().ReverseMap();
    }
}
