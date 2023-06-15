using Moq;
using Robotic.Spider.Core.WallCore;
using System.Drawing;
using static Robotic.Spider.Core.Helper.Variable;

namespace Robotic.Spider.Test.SpiderCore
{
    public class SpiderTests
    {
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

        [Fact]
        public void Spider_TurnLeft_UpdatesFace()
        {
            var wallMock = new Mock<IDimension>();
            var spider = new Core.SpiderCore.Spider(wallMock.Object);
            spider.Face = Faces.UP;

            spider.TurnLeft();

            Assert.Equal(Faces.LEFT, spider.Face);
        }

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
