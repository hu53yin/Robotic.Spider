using Moq;
using Robotic.Spider.Core.CommandCore;
using Robotic.Spider.Core.SpiderCore;

namespace Robotic.Spider.Test.CommandCore
{
    /// <summary>
    /// Unit tests for the InstructionsCommand class.
    /// </summary>
    public class InstructionsCommandTests
    {
        /// <summary>
        /// Tests the Extract method of the InstructionsCommand class with a valid command and verifies if it returns the Spider object with the expected instructions.
        /// </summary>
        /// <example>
        /// Create an instructions command with the sequence "FLFLFRFFLF". 
        /// Create a mock Spider object. Create an InstructionsCommand instance. Call the Extract method with the command and spider object. 
        /// Assert that the result is successful. 
        /// Verify that the Forward, TurnLeft, and TurnRight methods of the spider object are called the expected number of times.
        /// </example>
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

        /// <summary>
        /// Tests the Extract method of the InstructionsCommand class with an invalid command and verifies if it returns an error result.
        /// </summary>
        /// <example>
        /// Create an instructions command with an invalid command string. Create a mock Spider object. 
        /// Create an InstructionsCommand instance. Call the Extract method with the command and spider object. 
        /// Assert that the result is not successful. Assert that the description of the result matches the expected error message.
        /// </example>
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
