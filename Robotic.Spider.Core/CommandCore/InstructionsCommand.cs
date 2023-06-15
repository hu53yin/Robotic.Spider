using Robotic.Spider.Core.Helper;
using Robotic.Spider.Core.SpiderCore;
using static Robotic.Spider.Core.Helper.Variable;

namespace Robotic.Spider.Core.CommandCore
{
    /// <summary>
    /// Applying the given instructions to the spider
    /// </summary>
    public class InstructionsCommand : ICommand
    {
        public InstructionsCommand() { }

        public Result Extract(string command, ISpider? spider)
        {
            if (!string.IsNullOrEmpty(command) && !string.IsNullOrWhiteSpace(command))
            {
                var result = new Result();

                foreach (char letter in command)
                {
                    SpiderCommands spiderCommand;

                    switch (letter)
                    {
                        case 'F':
                            spiderCommand = SpiderCommands.FORWARD;
                            break;
                        case 'L':
                            spiderCommand = SpiderCommands.LEFT;
                            break;
                        case 'R':
                            spiderCommand = SpiderCommands.RIGHT;
                            break;
                        default:
                            return new Result
                            {
                                IsSuccess = false,
                                Description = "Invalid Command!",
                            };
                    }

                    switch (spiderCommand)
                    {
                        case SpiderCommands.FORWARD:
                            result = spider!.Forward();
                            break;
                        case SpiderCommands.LEFT:
                            spider!.TurnLeft();
                            break;
                        case SpiderCommands.RIGHT:
                            spider!.TurnRight();
                            break;
                        default:
                            return new Result
                            {
                                IsSuccess = false,
                                Description = "Invalid Command!",
                            };
                    }
                }

                return new Result
                {
                    IsSuccess = result.IsSuccess,
                    Description = result.Description,
                    Value = spider,
                };
            }

            return new Result
            {
                IsSuccess = false,
                Description = "Invalid Command!",
            };
        }
    }
}
