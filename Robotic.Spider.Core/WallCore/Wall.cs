namespace Robotic.Spider.Core.WallCore
{
    /// <summary>
    /// Wall for spider placing
    /// </summary>
    public class Wall : IDimension, IEquatable<Wall?>
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

        public bool Equals(Wall? wallCompare)
        {
            if (wallCompare is null) return false;

            if (ReferenceEquals(this, wallCompare)) return true;
            
            return XDimension == wallCompare.XDimension && YDimension == wallCompare.YDimension;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Wall);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(XDimension, YDimension);
        }
    }
}
