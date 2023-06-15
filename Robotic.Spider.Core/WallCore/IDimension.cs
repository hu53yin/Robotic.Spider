namespace Robotic.Spider.Core.WallCore
{
    /// <summary>
    /// Dimensions for wall creation
    /// </summary>
    public interface IDimension
    {
        /// <summary>
        /// X dimension
        /// </summary>
        int XDimension { get; }

        /// <summary>
        /// Y dimension
        /// </summary>
        int YDimension { get; }

        /// <summary>
        /// Equality check
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Equals(object obj);
    }
}
