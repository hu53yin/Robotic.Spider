namespace Robotic.Spider.Core.WallCore
{
    /// <summary>
    /// Wall for spider placing
    /// </summary>
    public class Wall : IDimension
    {
        /// <summary>
        /// X dimension
        /// </summary>
        public int XDimension { get; }

        /// <summary>
        /// Y dimension
        /// </summary>
        public int YDimension { get; }

        public Wall(int xDimension, int yDimension)
        {
            XDimension = xDimension;
            YDimension = yDimension;
        }
    }
}
