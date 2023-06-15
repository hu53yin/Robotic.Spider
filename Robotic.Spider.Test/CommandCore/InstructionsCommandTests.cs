using Moq;
using Robotic.Spider.Core.CommandCore;
using Robotic.Spider.Core.SpiderCore;

namespace Robotic.Spider.Test.CommandCore
{
    public class InstructionsCommandTests
    {
        [Fact]
        public void Extract_ValidCommand_ReturnsSpiderWithInstructions()
        {
            var command = "FLFLFRFFLF";
            var spider = new Mock<ISpider>();

            var instructionsCommand = new InstructionsCommand();

            var result = instructionsCommand.Extract(command, spider.Object);

            Assert.True(result.IsSuccess);
            spider.Verify(s => s.Forward(), Times.Exactly(6));
            spider.Verify(s => s.TurnLeft(), Times.Exactly(3));
            spider.Verify(s => s.TurnRight(), Times.Once);
        }

        [Fact]
        public void Extract_InvalidCommand_ReturnsError()
        {
            var command = "invalid command";
            var spider = new Mock<ISpider>();
            var instructionsCommand = new InstructionsCommand();

            var result = instructionsCommand.Extract(command, spider.Object);

            Assert.False(result.IsSuccess);
            Assert.Equal("Invalid Command!", result.Description);
        }
    }
}
