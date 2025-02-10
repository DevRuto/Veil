using Shouldly;

using Veil.Core.Entities;

namespace Veil.UnitTests.Core;

public class MessageTest
{
    [Fact]
    public void ShouldHaveNewGuid()
    {
        var message = Message.Create("test message");
        
        message.Text.ShouldBe("test message");
        message.Id.ShouldNotBe(Guid.Empty);
    }
}
