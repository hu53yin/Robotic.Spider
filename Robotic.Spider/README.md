## Robot Spider Challange

The application is a simulation of a robot spider moving on a wall. 

A squad of robotic spiders are to be sent to explore micro fractures on the wall of a building! 
This wall, which is rectangular, must be navigated by the Spiders so that their on-board diagnostics 
can get a complete view of the wall from close up before sending the data back to the control deck. 
The spiders are highly autonomous and will follow the instructions sent to them in the start 
command. 

A spider's position is represented by a combination of x and y coordinates and a current orientation. 
The wall is divided up into a grid to simplify navigation. 
An example position might be “0 0 Up” which means the spider is in the bottom left corner and facing 
up the wall. 

### Running of the program:
`cd .\Robot.Spider\`

`dotnet build`

`dotnet run`

### Running of the tests:
`cd .\Robot.Spider.Test\`

`dotnet build`

`dotnet test`

### Dependencies:
- .NET Core 7
- xUnit 2.4.2
- Moq 4.18.4

### Design Decisions:
- When the program starts, the desired size of the tabletop is created first. 
According to the scenario, a tabletop with dimensions of 5 units x 5 units is created, and the robot object is given to the tabletop. 
Afterwards, the user is expected to enter a command through the shell. Every command entered is processed in an error-free manner. 
Error conditions and all processes are logged to the file in the background. These are not displayed to the user on the front, so the user input is not affected. 
Logs are in the /logs folder under the directory where the application is running. 
(In case of Debug: It can be found in the .\Toy.Robot\Toy.Robot\bin\Debug\net6.0\logs folder.)

- First, the PLACE command is expected to come and place the robot on the tabletop. Other commands are ignored and not processed until this command is entered. 
If additional commands come after the first PLACE command, it starts to execute. Then the PLACE command may go again. 
Commands continue to be executed until the REPORT command is received.

- When the REPORT command comes, the robot's position is written on the screen, and the program is exited.

- According to the tabletop's dimensions, the robot is prevented from falling off the tabletop. Commands are checked according to the Regex pattern. 
A factory Design pattern has been applied for the command processing structure. Only with the execute method are user inputs processed and applied to the robot. 
The Execute method extracts the entered command into its components and uses the relevant commands on the robot. 

- An enum protects the command standard, and commands entered accordingly can be executed over the factory after passing the control.
Group information is used in the regex pattern. Thanks to the group structure, the commands entered can be easily separated into their components, 
and then the command components can be easily accessed through the groups. 

- String constants have been created to prevent the use of magic strings in the project. 
All operations return a standard Result object, which can be logged directly with the logging structure.