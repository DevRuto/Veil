using System.Text;

using AutoMapper;

using Veil.Core.Entities;
using Veil.Core.Enums;

namespace Veil.Application.Message.Queries;

public class MessageDto
{
    public string? Id { get;  init; }
    public string? Text { get; init; }
    public DataType MessageType { get; set; }
    public DateTimeOffset Created { get; set; }
    public Guid Author { get; set; }

    private class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<BaseMessage, MessageDto>()
                .ForMember(msg => msg.Author, m => m.MapFrom(src => src.CreatedBy))
                .ForMember(msg => msg.MessageType, m => m.MapFrom(src => src.DataType))
                .ForMember(msg => msg.Text, m => m.MapFrom(src => GetCorrespondingText(src)));
        }

        private static string GetCorrespondingText(BaseMessage msg)
        {
            if (msg.DataType == DataType.Text && msg.Value != null)
                return Encoding.UTF8.GetString(msg.Value);
            else if (msg.DataType == DataType.Image)
                return "Image type not implemented";
            return "N/A";
        }
    }
}
