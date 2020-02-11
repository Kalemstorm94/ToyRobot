using Robot.Enums;
using Robot.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Robot.Interfaces;
using Robot;

namespace UnitTests.Robot
{
    [TestClass]
    public class LeftCommandTests
    {
        private Mock<IBot> botMock;

        [TestInitialize]
        public void Setup()
        {
            botMock = new Mock<IBot>();
        }

        [TestMethod]
        [DataRow(1, 1, Direction.NORTH, Direction.WEST)]
        [DataRow(1, 1, Direction.EAST, Direction.NORTH)]
        [DataRow(1, 1, Direction.SOUTH, Direction.EAST)]
        [DataRow(1, 1, Direction.WEST, Direction.SOUTH)]
        public void TestDirectionsForLeftCommand(int x, int y, Direction dir, Direction expected)
        {
            //Arrange
            var position = new Position(x, y, dir);
            botMock.SetupGet(bot => bot.Position).Returns(position);
            var command = new LeftCommand(botMock.Object);

            //Act
            var actual = command.ProcessCommand().Direction;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
