using Robotic.Spider.Core.Helper;
using Robotic.Spider.Core.SpiderCore;

namespace Robotic.Spider.Core.CommandCore
{
    /// <summary>
    /// Spider interaction commands interface
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Extract the command to the parameters
        /// </summary>
        Result Extract(string command, ISpider? spider = null);
    }
}
