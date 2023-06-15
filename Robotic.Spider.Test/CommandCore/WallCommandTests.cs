using Robotic.Spider.Core.CommandCore;
using Robotic.Spider.Core.WallCore;

namespace Robotic.Spider.Test.CommandCore
{
    public class WallCommandTests
    {
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
