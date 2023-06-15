using Moq;
using Robotic.Spider.Core.CommandCore;
using Robotic.Spider.Core.SpiderCore;
using Robotic.Spider.Core.WallCore;
using static Robotic.Spider.Core.Helper.Variable;

namespace Robotic.Spider.Test.CommandCore
{
    public class LocationCommandTests
    {
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
