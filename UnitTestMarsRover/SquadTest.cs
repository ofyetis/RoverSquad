﻿using MarsRoverBusiness;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMarsRover
{
    [TestClass]
    public class SquadTest
    {
        [TestMethod]
        public void Move_PlateauConsiderBoundaryAndCrashFalseGiven_ReturnsTrue()
        {
            //Arrange
            Plateau plateau = new Plateau()
            {
                UpperRightX = 5,
                UpperRightY = 5
            };
            Rover rover = new Rover()
            {
                CoordinateX = 1,
                CoordinateY = 2,
                Direction = Helpers.Direction.North,
                MovementList = Helpers.Helpers.GetMovementEnumList("LMLMLMLMM")
            };
            Rover rover2 = new Rover()
            {
                CoordinateX = 3,
                CoordinateY = 3,
                Direction = Helpers.Direction.East,
                MovementList = Helpers.Helpers.GetMovementEnumList("MMRMMRMRRM")
            };
            Squad squad = new Squad();
            squad.Add(rover);
            squad.Add(rover2);

            //Act
            var result = squad.Move(plateau, false);
            Result expectedResult = new Result();

            //Assert
            Assert.AreEqual(expectedResult.Success, result.Success);
            Assert.AreEqual(expectedResult.ErrorMessage, result.ErrorMessage);
        }

        [TestMethod]
        public void Move_PlateauConsiderBoundaryAndCrashTrueGiven_ReturnsTrue_2()
        {
            //Arrange
            Plateau plateau = new Plateau()
            {
                UpperRightX = 5,
                UpperRightY = 5
            };
            Rover rover = new Rover()
            {
                CoordinateX = 1,
                CoordinateY = 2,
                Direction = Helpers.Direction.North,
                MovementList = Helpers.Helpers.GetMovementEnumList("LMLMLMLMM")
            };
            Rover rover2 = new Rover()
            {
                CoordinateX = 3,
                CoordinateY = 3,
                Direction = Helpers.Direction.East,
                MovementList = Helpers.Helpers.GetMovementEnumList("MMRMMRMRRM")
            };
            Rover rover3 = new Rover()
            {
                CoordinateX = 3,
                CoordinateY = 5,
                Direction = Helpers.Direction.West,
                MovementList = Helpers.Helpers.GetMovementEnumList("MMLM")
            };
            Squad squad = new Squad();
            squad.Add(rover);
            squad.Add(rover2);
            squad.Add(rover3);

            //Act
            var result = squad.Move(plateau, true);
            Result expectedResult = new Result();

            //Assert
            Assert.AreEqual(expectedResult.Success, result.Success);
            Assert.AreEqual(expectedResult.ErrorMessage, result.ErrorMessage);
        }

        [TestMethod]
        public void Move_PlateauConsiderBoundaryAndCrashTrueGiven_ReturnsFalse()
        {
            //Arrange
            Plateau plateau = new Plateau()
            {
                UpperRightX = 5,
                UpperRightY = 5
            };
            Rover rover = new Rover()
            {
                CoordinateX = 1,
                CoordinateY = 2,
                Direction = Helpers.Direction.North,
                MovementList = Helpers.Helpers.GetMovementEnumList("LMLMLMLMM")
            };
            Rover rover2 = new Rover()
            {
                CoordinateX = 3,
                CoordinateY = 3,
                Direction = Helpers.Direction.East,
                MovementList = Helpers.Helpers.GetMovementEnumList("MMRMMRMRRM")
            };
            Rover rover3 = new Rover()
            {
                CoordinateX = 3,
                CoordinateY = 5,
                Direction = Helpers.Direction.West,
                MovementList = Helpers.Helpers.GetMovementEnumList("MMLMM")
            };
            Squad squad = new Squad();
            squad.Add(rover);
            squad.Add(rover2);
            squad.Add(rover3);

            //Act
            var result = squad.Move(plateau, true);
            Result expectedResult = new Result()
            {
                Success = false,
                ErrorMessage = "The rover will crash with another rover with this route. Please change the route!"
            };

            //Assert
            Assert.AreEqual(expectedResult.Success, result.Success);
            Assert.AreEqual(expectedResult.ErrorMessage, result.ErrorMessage);
        }

        [TestMethod]
        public void Move_PlateauConsiderBoundaryAndCrashTrueGiven_ReturnsFalse_2()
        {
            //Arrange
            Plateau plateau = new Plateau()
            {
                UpperRightX = 5,
                UpperRightY = 5
            };
            Rover rover = new Rover()
            {
                CoordinateX = 6,
                CoordinateY = 2,
                Direction = Helpers.Direction.North,
                MovementList = Helpers.Helpers.GetMovementEnumList("LMLMLMLMM")
            };
            Rover rover2 = new Rover()
            {
                CoordinateX = 3,
                CoordinateY = 3,
                Direction = Helpers.Direction.East,
                MovementList = Helpers.Helpers.GetMovementEnumList("MMRMMRMRRM")
            };
            Rover rover3 = new Rover()
            {
                CoordinateX = 3,
                CoordinateY = 5,
                Direction = Helpers.Direction.West,
                MovementList = Helpers.Helpers.GetMovementEnumList("MMLMM")
            };
            Squad squad = new Squad();
            squad.Add(rover);
            squad.Add(rover2);
            squad.Add(rover3);

            //Act
            var result = squad.Move(plateau, true);
            Result expectedResult = new Result()
            {
                Success = false,
                ErrorMessage = "The route is not within the boundaries!"
            };

            //Assert
            Assert.AreEqual(expectedResult.Success, result.Success);
            Assert.AreEqual(expectedResult.ErrorMessage, result.ErrorMessage);
        }

    }
}
