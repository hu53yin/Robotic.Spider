using Robotic.Spider.Core.Helper;
using Robotic.Spider.Core.WallCore;
using System.Drawing;
using static Robotic.Spider.Core.Helper.Variable;

namespace Robotic.Spider.Core.SpiderCore
{
    public class Spider : ISpider
    {
        /// <summary>
        /// Spider's facing 
        /// UP, RIGHT, DOWN, LEFT
        /// </summary>
        public Faces Face { get; set; }

        private Point coordinate;

        /// <summary>
        /// Robot's coordinate (x,y)
        /// </summary>
        public Point Coordinate
        {
            get
            {
                return coordinate;
            }
            set
            {
                coordinate = value;
            }
        }

        /// <summary>
        /// Wall dimensions
        /// </summary>
        private IDimension dimension;

        public Spider(IDimension dimension)
        {
            this.dimension = dimension;
        }

        /// <summary>
        /// Spider can turn left
        /// </summary>
        public void TurnLeft()
        {
            //Change direction to left
            Face--;

            // The direction start from 0
            // 0 is UP, Before the UP direction change to the LEFT
            if (Face < 0)
            {
                Face = Faces.LEFT;
            }
        }

        /// <summary>
        /// Spider can turn right
        /// </summary>
        public void TurnRight()
        {
            // The direction is reached to the LEFT and turn to the right
            // The direction is changed to the UP. The UP is 0.
            Face = (Faces)(((int)Face + 1) % 4);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Coordinate.X, Coordinate.Y, Face.ToString());
        }

        /// <summary>
        /// Spider can move one unit forward
        /// </summary>
        /// <returns>Result</returns>
        public Result Forward()
        {
            switch (Face)
            {
                case Faces.UP:
                    if (coordinate.Y < dimension.YDimension)
                    {
                        coordinate.Y++;
                    }
                    else
                    {
                        return new Result
                        {
                            IsSuccess = false,
                            Description = string.Format("FORWARD Command discarded! Y Dimension reached {0}", dimension.YDimension)
                        };
                    }
                    break;
                case Faces.RIGHT:
                    if (coordinate.X < dimension.XDimension)
                    {
                        coordinate.X++;
                    }
                    else
                    {
                        return new Result
                        {
                            IsSuccess = false,
                            Description = string.Format("FORWARD Command discarded! X Dimension reached {0}", dimension.YDimension)
                        };
                    }
                    break;
                case Faces.DOWN:
                    if (coordinate.Y > 0)
                    {
                        coordinate.Y--;
                    }
                    else
                    {
                        return new Result
                        {
                            IsSuccess = false,
                            Description = string.Format("FORWARD Command discarded! Y Dimension reached 0")
                        };
                    }
                    break;
                case Faces.LEFT:
                    if (coordinate.X > 0)
                    {
                        coordinate.X--;
                    }
                    else
                    {
                        return new Result
                        {
                            IsSuccess = false,
                            Description = string.Format("FORWARD Command discarded! X Dimension reached 0")
                        };
                    }
                    break;
            }

            return new Result
            {
                IsSuccess = true,
                Description = "FORWARD Command executed!"
            };
        }
    }
}
