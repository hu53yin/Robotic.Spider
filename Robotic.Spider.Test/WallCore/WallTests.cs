using Robotic.Spider.Core.WallCore;

namespace Robotic.Spider.Test.WallCore
{
    public class WallTests
    {
        [Fact]
        public void Wall_ConstructsCorrectly()
        {
            int xDimension = 7;
            int yDimension = 15;

            var wall = new Wall(xDimension, yDimension);

            Assert.Equal(xDimension, wall.XDimension);
            Assert.Equal(yDimension, wall.YDimension);
        }
    }
}
