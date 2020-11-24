INTRODUCTION
------------

This project is about a squad of robotic rovers that are to be landed by NASA on a plateau on Mars. 
This plateau, which is curiously rectangular, must be navigated by the rovers so that their on board 
cameras can get a complete view of the surrounding terrain to send back to Earth.

By this project, you will be able to enter the plateau size, rover's starting point and movement commands 
then see the last point and direction of the rovers. 

If you want to consider boundaries and crash possibilities, you should pass the considerBoundaryAndCrash 
parameter as true to the Move method of the Squad class.

The solution is consist of three project: MarsRover is the console application, MarsRoverBusiness is the class 
library that includes the Plateau, Squad, Rover and Result classes, and UnitTestMarsRover is the project that includes
unit tests.

The MarsRover project should be made as the startup project. When you open the solution and execute it, 
you will see the command prompt that asking you to enter the plateau's upper-right coordinates.
Then you will be asked for entering rovers's start point with direction and the movement command letters.
If you enter these informations in an invalid format, you will be warned. You can add rovers as many as you want.
If you don't want to add any more, you should type "N" to the question which will ask you if you want to add another rover.
Then you will see the rovers's calculated last points and directions.

CONTACT
-------
If you face with any issue, please don't hasitate to contact with me over "ofyetis@gmail.com"
