using Robotic.Spider.Core.Helper;
using Robotic.Spider.Core.SpiderCore;
using System.Drawing;
using static Robotic.Spider.Core.Helper.Variable;

namespace Robotic.Spider.Core.CommandCore
{
    /// <summary>
    /// Placing the spider at the given location on the wall
    /// </summary>
    public class LocationCommand : ICommand
    {
        public LocationCommand() { }

        public Result Extract(string command, ISpider? spider)
        {
            if (!string.IsNullOrEmpty(command) && !string.IsNullOrWhiteSpace(command))
            {
                var commandParts = command.Split(' ');

                if (commandParts.Length == 3 && 
                    int.TryParse(commandParts[0], out int xDimension) &&
                    int.TryParse(commandParts[1], out int yDimension) && 
                    Enum.TryParse(commandParts[2].ToUpper(), out Faces face))
                {
                    if(xDimension <= spider!.Dimension.XDimension && yDimension <= spider!.Dimension.YDimension)
                    {
                        spider!.Coordinate = new Point(xDimension, yDimension);
                        spider.Face = face;

                        return new Result
                        {
                            IsSuccess = true,
                            Value = spider,
                        };
                    }   
                    else
                    {
                        return new Result
                        {
                            IsSuccess = false,
                            Description = "The given location exceeded the wall limits.",
                        };
                    }
                }
            }

            return new Result
            {
                IsSuccess = false,
                Description = "Invalid Command!",
            };
        }
    }
}
