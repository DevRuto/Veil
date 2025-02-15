using Shouldly;

using Veil.Core.Entities;
using Veil.Core.Enums;

namespace Veil.UnitTests.Core;

public class TextMessageTest
{
    [Fact]
    public void ShouldHaveNewGuid()
    {
        var message = TextMessage.Create("test message");
        
        message.Id.ShouldNotBe(Guid.Empty);
        message.Value.ShouldBe("test message");
        message.DataType.ShouldBe(DataType.Text);
    }
}
