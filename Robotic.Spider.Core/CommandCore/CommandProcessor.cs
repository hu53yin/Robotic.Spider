using Robotic.Spider.Core.Helper;
using Robotic.Spider.Core.SpiderCore;

namespace Robotic.Spider.Core.CommandCore
{
    /// <summary>
    /// Extract the required parameters and process each command
    /// </summary>
    public class CommandProcessor : ICommandProcessor
    {
        private readonly ICommand wallCommand;
        private readonly ICommand locationCommand;
        private readonly ICommand instructionsCommand;

        public CommandProcessor(ICommand wallCommand, ICommand locationCommand, ICommand instructionsCommand)
        {
            this.wallCommand = wallCommand;
            this.locationCommand = locationCommand;
            this.instructionsCommand = instructionsCommand;
        }

        public Result ProcessWallCommand(string command)
        {
            return wallCommand.Extract(command);
        }

        public Result ProcessLocationCommand(string command, ISpider spider)
        {
            return locationCommand.Extract(command, spider);
        }

        public Result ProcessInstructionsCommand(string command, ISpider spider)
        {
            return instructionsCommand.Extract(command, spider);
        }
    }
}
