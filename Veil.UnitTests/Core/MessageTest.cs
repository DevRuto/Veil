using Shouldly;

using Veil.Core.Entities;

namespace Veil.UnitTests.Core;

public class MessageTest
{
    [Fact]
    public void ShouldHaveNewGuid()
    {
        var message = TextMessage.Create("test message");
        
        message.Value.ShouldBe("test message");
        message.Id.ShouldNotBe(Guid.Empty);
    }
}
