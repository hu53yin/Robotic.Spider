using Robotic.Spider.Core.CommandCore;
using Robotic.Spider.Core.Helper;
using Robotic.Spider.Core.SpiderCore;
using Robotic.Spider.Core.WallCore;

///
/// # Spider Robot Challange
/// # Author: Huseyin Gurkan
///

try
{
    Console.WriteLine("Robotic Spider");
    Console.WriteLine("Enter your command!");

    var executionStep = 1;
    Result result = new Result();
    IDimension? wall = null;
    ISpider? spider = null;
    var commandProcessor = new CommandProcessor(new WallCommand(), new LocationCommand(), new InstructionsCommand());

    while (true)
    {
        var userCommand = Console.ReadLine();

        if (!string.IsNullOrEmpty(userCommand) &&
            !string.IsNullOrWhiteSpace(userCommand))
        {
            // Creating the wall with the given dimensions
            if(executionStep == 1) 
            {
                result = commandProcessor.ProcessWallCommand(userCommand);

                if(result.IsSuccess)
                {
                    wall = result.Value as IDimension;
                    executionStep++;
                }
                else
                {
                    Console.WriteLine(result.Description);
                }
            }
            // Placing the spider at the given location on the wall
            else if (executionStep == 2 && wall != null)
            {
                spider = new Spider(wall);
                result = commandProcessor.ProcessLocationCommand(userCommand, spider);

                if (result.IsSuccess)
                {
                    spider = result.Value as ISpider;
                    executionStep++;
                }
                else
                {
                    Console.WriteLine(result.Description);
                }
            }
            // Applying the given instructions to the spider
            else if (executionStep == 3 && spider != null)
            {
                result = commandProcessor.ProcessInstructionsCommand(userCommand, spider);

                if (result.IsSuccess)
                {
                    spider = result.Value as ISpider;
                    Console.WriteLine(spider!.ToString());
                    
                    break;
                }
                else
                {
                    Console.WriteLine(result.Description);
                }
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
