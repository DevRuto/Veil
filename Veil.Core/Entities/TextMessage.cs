using Veil.Core.Enums;

namespace Veil.Core.Entities;

public class TextMessage : BaseMessage
{

    public static TextMessage Create(string? text)
    {
        var message = new TextMessage
        {
            Id = Guid.NewGuid(),
            Value = text,
            DataType = DataType.Text
        };

        return message;
    }
}
