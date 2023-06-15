using Robotic.Spider.Core.Helper;
using Robotic.Spider.Core.SpiderCore;
using Robotic.Spider.Core.WallCore;

namespace Robotic.Spider.Core.CommandCore
{
    /// <summary>
    /// Creating the wall with the given dimensions
    /// </summary>
    public class WallCommand : ICommand
    {
        public WallCommand() { }

        public Result Extract(string command, ISpider? spider = null)
        {
            if (!string.IsNullOrEmpty(command) && !string.IsNullOrWhiteSpace(command))
            {
                var commandParts = command.Split(' ');

                if (commandParts.Length == 2 && int.TryParse(commandParts[0], out int xDimension) &&
                    int.TryParse(commandParts[1], out int yDimension))
                {
                    var wall = new Wall(xDimension, yDimension);
                    
                    return new Result
                    {
                        IsSuccess = true,
                        Value = wall,
                    };
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
