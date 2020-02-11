using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot;
using Robot.Enums;

namespace UnitTests.Robot
{
    [TestClass]
    public class GridTests
    {

        [TestMethod]
        [DataRow(5, 5, 1, 1, true)]
        [DataRow(5, 5, 6, 6, false)]
        [DataRow(0, 0, 1, 1, false)]
        [DataRow(0, 1, 1, 1, false)]
        [DataRow(1, 2, 0, 1, true)]
        public void TestDirectionsForRightCommand(int cols, int rows, int posX, int posY, bool expected)
        {
            //Arrange
            var position = new Position(posX, posY, Direction.NORTH);
            var grid = new Grid(cols, rows);

            //Act
            var actual = grid.CheckAvailability(position);

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
