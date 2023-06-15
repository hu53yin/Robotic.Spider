using Moq;
using Robotic.Spider.Core.CommandCore;
using Robotic.Spider.Core.Helper;
using Robotic.Spider.Core.SpiderCore;
using Robotic.Spider.Core.WallCore;

namespace Robotic.Spider.Test.CommandCore
{
    public class CommandProcessorTests
    {
        [Fact]
        public void ProcessWallCommand_ValidCommand_ReturnsWall()
        {
            var command = "7 15";
            var expectedWall = new Wall(7, 15);
            var wallCommandMock = new Mock<ICommand>();
            wallCommandMock.Setup(c => c.Extract(command, null)).Returns(new Result { IsSuccess = true, Value = expectedWall });

            var commandProcessor = new CommandProcessor(wallCommandMock.Object, null, null);

            var result = commandProcessor.ProcessWallCommand(command);

            Assert.True(result.IsSuccess);
            Assert.Equal(expectedWall, result.Value);
        }

        [Fact]
        public void ProcessLocationCommand_ValidCommand_ReturnsSpiderWithLocation()
        {
            var command = "4 10 Left";
            var spider = new Mock<ISpider>();
            var locationCommandMock = new Mock<ICommand>();
            locationCommandMock.Setup(c => c.Extract(command, spider.Object)).Returns(new Result { IsSuccess = true, Value = spider.Object });

            var commandProcessor = new CommandProcessor(null, locationCommandMock.Object, null);

            var result = commandProcessor.ProcessLocationCommand(command, spider.Object);

            Assert.True(result.IsSuccess);
            Assert.Equal(spider.Object, result.Value);
        }

        [Fact]
        public void ProcessInstructionsCommand_ValidCommand_ReturnsSpiderWithInstructions()
        {
            var command = "FLFLFRFFLF";
            var spider = new Mock<ISpider>();
            var instructionsCommandMock = new Mock<ICommand>();
            instructionsCommandMock.Setup(c => c.Extract(command, spider.Object)).Returns(new Result { IsSuccess = true, Value = spider.Object });

            var commandProcessor = new CommandProcessor(null, null, instructionsCommandMock.Object);

            var result = commandProcessor.ProcessInstructionsCommand(command, spider.Object);

            Assert.True(result.IsSuccess);
            Assert.Equal(spider.Object, result.Value);
        }
    }
}
