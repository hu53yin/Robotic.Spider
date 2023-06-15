using Robotic.Spider.Core.Helper;
using Robotic.Spider.Core.SpiderCore;

namespace Robotic.Spider.Core.CommandCore
{
    /// <summary>
    /// Command processor definitions according to process steps
    /// </summary>
    public interface ICommandProcessor
    {
        Result ProcessWallCommand(string command);
        Result ProcessLocationCommand(string command, ISpider spider);
        Result ProcessInstructionsCommand(string command, ISpider spider);
    }
}
