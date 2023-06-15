using Moq;
using Robotic.Spider.Core.WallCore;
using System.Drawing;
using static Robotic.Spider.Core.Helper.Variable;

namespace Robotic.Spider.Test.SpiderCore
{
    /// <summary>
    /// Unit tests for the Spider class.
    /// </summary>
    public class SpiderTests
    {
        /// <summary>
        /// Tests the Forward method of the Spider class and verifies if it updates the coordinate correctly.
        /// </summary>
        /// <example>
        /// Create a wall mock object with dimensions of 10x10. Create a Spider instance with the wall mock object. 
        /// Set the spider's coordinate to (7, 15) and face to the right. Call the Forward method. 
        /// Assert that the result is successful. 
        /// Assert that the X coordinate of the spider is updated to 8 and the Y coordinate remains unchanged at 15.
        /// </example>
        [Fact]
        public void Spider_Forward_UpdatesCoordinate()
        {
            var wallMock = new Mock<IDimension>();
            wallMock.SetupGet(w => w.XDimension).Returns(10);
            wallMock.SetupGet(w => w.YDimension).Returns(10);
            
            var spider = new Core.SpiderCore.Spider(wallMock.Object);
            spider.Coordinate = new Point(7, 15);
            spider.Face = Faces.RIGHT;

            var result = spider.Forward();

            Assert.True(result.IsSuccess);
            Assert.Equal(8, spider.Coordinate.X);
            Assert.Equal(15, spider.Coordinate.Y);
        }

        /// <summary>
        /// Tests the TurnLeft method of the Spider class and verifies if it updates the face correctly.
        /// </summary>
        /// <example>
        /// Create a wall mock object. Create a Spider instance with the wall mock object. 
        /// Set the spider's face to Up. Call the TurnLeft method. 
        /// Assert that the face of the spider is updated to Left.
        /// </example>
        [Fact]
        public void Spider_TurnLeft_UpdatesFace()
        {
            var wallMock = new Mock<IDimension>();
            var spider = new Core.SpiderCore.Spider(wallMock.Object);
            spider.Face = Faces.UP;

            spider.TurnLeft();

            Assert.Equal(Faces.LEFT, spider.Face);
        }

        /// <summary>
        /// Tests the TurnRight method of the Spider class and verifies if it updates the face correctly.
        /// </summary>
        /// <example>
        /// Create a wall mock object. Create a Spider instance with the wall mock object. Set the spider's face to Down. Call the TurnRight method. Assert that the face of the spider is updated to Left.
        /// </example>
        [Fact]
        public void Spider_TurnRight_UpdatesFace()
        {
            var wallMock = new Mock<IDimension>();
            var spider = new Core.SpiderCore.Spider(wallMock.Object);
            spider.Face = Faces.DOWN;

            spider.TurnRight();

            Assert.Equal(Faces.LEFT, spider.Face);
        }
    }
}
