using Moq;
using Robotic.Spider.Core.CommandCore;
using Robotic.Spider.Core.SpiderCore;
using Robotic.Spider.Core.WallCore;
using static Robotic.Spider.Core.Helper.Variable;

namespace Robotic.Spider.Test.CommandCore
{
    /// <summary>
    /// Unit tests for the LocationCommand class.
    /// </summary>
    public class LocationCommandTests
    {
        /// <summary>
        /// Tests the Extract method of the LocationCommand class with a valid command and verifies if it returns the Spider object with the expected location.
        /// </summary>
        /// <example>
        /// Create a location command with the coordinate "4 10" and face "Left". 
        /// Create a mock Spider object. Set up the necessary properties and returns values on the spider object. 
        /// Create a LocationCommand instance. Call the Extract method with the command and spider object. 
        /// Assert that the result is successful. 
        /// Assert that the coordinate and face of the spider object match the expected values.
        /// </example>
        [Fact]
        public void Extract_ValidCommand_ReturnsSpiderWithLocation()
        {
            var command = "4 10 Left";
            var spider = new Mock<ISpider>();
            spider.SetupProperty(s => s.Coordinate);
            spider.SetupProperty(s => s.Face);
            spider.SetupGet(s => s.Dimension).Returns(new Wall(4, 10));

            var locationCommand = new LocationCommand();

            var result = locationCommand.Extract(command, spider.Object);

            Assert.True(result.IsSuccess);
            Assert.Equal(4, spider.Object.Coordinate.X);
            Assert.Equal(10, spider.Object.Coordinate.Y);
            Assert.Equal(Faces.LEFT, spider.Object.Face);
        }

        /// <summary>
        /// Tests the Extract method of the LocationCommand class with an invalid command and verifies if it returns an error result.
        /// </summary>
        /// <example>
        /// Create a location command with an invalid command string. 
        /// Create a mock Spider object. Create a LocationCommand instance. 
        /// Call the Extract method with the command and spider object. 
        /// Assert that the result is not successful. 
        /// Assert that the description of the result matches the expected error message.
        /// </example>
        [Fact]
        public void Extract_InvalidCommand_ReturnsError()
        {
            var command = "invalid command";
            var spider = new Mock<ISpider>();
            var locationCommand = new LocationCommand();

            var result = locationCommand.Extract(command, spider.Object);

            Assert.False(result.IsSuccess);
            Assert.Equal("Invalid Command!", result.Description);
        }
    }
}
