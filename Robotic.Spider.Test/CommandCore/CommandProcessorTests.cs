using Moq;
using Robotic.Spider.Core.CommandCore;
using Robotic.Spider.Core.Helper;
using Robotic.Spider.Core.SpiderCore;
using Robotic.Spider.Core.WallCore;

namespace Robotic.Spider.Test.CommandCore
{
    /// <summary>
    /// Unit tests for the CommandProcessor class.
    /// </summary>
    public class CommandProcessorTests
    {
        /// <summary>
        /// Tests the ProcessWallCommand method of the CommandProcessor class with a valid command and verifies if it returns the expected Wall object.
        /// </summary>
        /// <example>
        /// Create a wall command with dimensions "7 15". Mock the wall command extraction to return a successful result with the expected wall object. 
        /// Create a CommandProcessor instance and call the ProcessWallCommand method with the command. 
        /// Assert that the result is successful and the returned wall matches the expected wall.
        /// </example>
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

        /// <summary>
        /// Tests the ProcessLocationCommand method of the CommandProcessor class with a valid command and verifies if it returns the Spider object with the expected location.
        /// </summary>
        /// <example>
        /// Create a location command with coordinates "4 10" and direction "Left". Mock the location command extraction to return a successful result with the spider object. 
        /// Create a CommandProcessor instance and call the ProcessLocationCommand method with the command and spider object. 
        /// Assert that the result is successful and the returned spider object matches the expected spider.
        /// </example>
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

        /// <summary>
        /// Tests the ProcessInstructionsCommand method of the CommandProcessor class with a valid command and verifies if it returns the Spider object with the expected instructions.
        /// </summary>
        /// <example>
        /// Create an instructions command with the sequence "FLFLFRFFLF". Mock the instructions command extraction to return a successful result with the spider object. 
        /// Create a CommandProcessor instance and call the ProcessInstructionsCommand method with the command and spider object. 
        /// Assert that the result is successful and the returned spider object matches the expected spider.
        /// </example>
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
