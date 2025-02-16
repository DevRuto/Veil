using System.Text;

using Veil.Core.Enums;

namespace Veil.Core.Entities;

public class TextMessage : BaseMessage
{
    public string Text => Encoding.UTF8.GetString(Value ?? []);

    public static TextMessage Create(string? text)
    {
        byte[]? value = null;
        if (!string.IsNullOrEmpty(text))
            value = Encoding.UTF8.GetBytes(text);
        var message = new TextMessage
        {
            Id = Guid.NewGuid(),
            Value = value,
            DataType = DataType.Text
        };

        return message;
    }
}
