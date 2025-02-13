using AutoMapper;

namespace Veil.Application.Message.Queries;

public class MessageDto
{
    public string? Id { get;  init; }
    public string? Text { get; init; }

    private class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Core.Entities.Message, MessageDto>();
        }
    }
}
