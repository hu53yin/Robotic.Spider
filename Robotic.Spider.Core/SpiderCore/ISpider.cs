using Robotic.Spider.Core.Helper;
using System.Drawing;
using static Robotic.Spider.Core.Helper.Variable;

namespace Robotic.Spider.Core.SpiderCore
{
    public interface ISpider
    {
        /// <summary>
        /// Spider's facing
        /// UP, RIGHT, DOWN, LEFT
        /// </summary>
        Faces Face { get; set; }

        /// <summary>
        /// Spider's coordinate (x,y)
        /// </summary>
        Point Coordinate { get; set; }

        /// <summary>
        /// Spider can turn left
        /// </summary>
        void TurnLeft();

        /// <summary>
        /// Spider can turn right
        /// </summary>
        void TurnRight();

        /// <summary>
        /// Spider can move one unit forward
        /// </summary>
        /// <returns>Result</returns>
        Result Forward();
    }
}
