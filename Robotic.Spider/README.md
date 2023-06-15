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