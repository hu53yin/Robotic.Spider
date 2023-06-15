using Robotic.Spider.Core.CommandCore;
using Robotic.Spider.Core.WallCore;

namespace Robotic.Spider.Test.CommandCore
{
    /// <summary>
    /// Unit tests for the WallCommand class.
    /// </summary>
    public class WallCommandTests
    {
        /// <summary>
        /// Tests the Extract method of the WallCommand class with a valid command and verifies if it returns the expected Wall object.
        /// </summary>
        /// <example>
        /// Create a wall command with the dimensions "7 15". 
        /// Create an expected wall object with the same dimensions. 
        /// Create a WallCommand instance. Call the Extract method with the command. 
        /// Assert that the result is successful. 
        /// Assert that the value of the result is an IDimension object that matches the expected wall object.
        /// </example>
        [Fact]
        public void Extract_ValidCommand_ReturnsWall()
        {
            var command = "7 15";
            var expectedWall = new Wall(7, 15);
            var wallCommand = new WallCommand();

            var result = wallCommand.Extract(command);

            Assert.True(result.IsSuccess);
            Assert.Equal(expectedWall, result.Value as IDimension);
        }

        /// <summary>
        /// Tests the Extract method of the WallCommand class with an invalid command and verifies if it returns an error result.
        /// </summary>
        /// <example>
        /// Create a wall command with an invalid command string. 
        /// Create a WallCommand instance. Call the Extract method with the command. 
        /// Assert that the result is not successful. 
        /// Assert that the description of the result matches the expected error message.
        /// </example>
        [Fact]
        public void Extract_InvalidCommand_ReturnsError()
        {
            var command = "invalid command";
            var wallCommand = new WallCommand();

            var result = wallCommand.Extract(command);

            Assert.False(result.IsSuccess);
            Assert.Equal("Invalid Command!", result.Description);
        }
    }
}
