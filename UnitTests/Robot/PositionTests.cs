using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot;
using Robot.Constants;
using Robot.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Robot
{
    [TestClass]
    public class PositionTests
    {

        [TestMethod]
        [DataRow(1, 1, Direction.NORTH, "1, 1, NORTH")]
        [DataRow(2, 2, Direction.EAST, "2, 2, EAST")]
        [DataRow(3, 3, Direction.SOUTH, "3, 3, SOUTH")]
        [DataRow(4, 4, Direction.WEST, "4, 4, WEST")]
        public void TestGetCurrentPosition(int x, int y, Direction dir, string expected)
        {
            //Arrange
            var position = new Position(x, y, dir);

            //Act
            var actual = position.GetCurrentPosition();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
