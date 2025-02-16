using System.Text;

using Shouldly;

using Veil.Core.Entities;
using Veil.Core.Enums;

namespace Veil.UnitTests.Core;

public class TextMessageTest
{
    [Fact]
    public void ShouldHaveNewGuid()
    {
        var testMessage = "test message";
        var message = TextMessage.Create(testMessage);
        
        message.Id.ShouldNotBe(Guid.Empty);
        message.Value.ShouldBe(Encoding.UTF8.GetBytes(testMessage));
        message.Text.ShouldBe(testMessage);
        message.DataType.ShouldBe(DataType.Text);
    }
}
