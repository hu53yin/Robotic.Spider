using Robotic.Spider.Core.WallCore;

namespace Robotic.Spider.Test.WallCore
{
    /// <summary>
    /// Unit tests for the Wall class.
    /// </summary>
    public class WallTests
    {
        /// <summary>
        /// Tests the constructor of the Wall class and verifies if it constructs a wall with the correct dimensions.
        /// </summary>
        /// <example>
        /// Set the xDimension variable to 7 and the yDimension variable to 15. 
        /// Create a Wall instance using the xDimension and yDimension variables. 
        /// Assert that the XDimension property of the wall is equal to the xDimension variable and the YDimension property of the wall is equal to the yDimension variable.
        /// </example>
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
