using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Robot;
using Robot.Commands;
using Robot.Enums;
using Robot.Interfaces;

namespace UnitTests.Robot
{
    [TestClass]
    public class RightCommandTests
    {
        private Mock<IBot> botMock;

        [TestInitialize]
        public void Setup()
        {
            botMock = new Mock<IBot>();
        }

        [TestMethod]
        [DataRow(1, 1, Direction.NORTH, Direction.EAST)]
        [DataRow(1, 1, Direction.EAST, Direction.SOUTH)]
        [DataRow(1, 1, Direction.SOUTH, Direction.WEST)]
        [DataRow(1, 1, Direction.WEST, Direction.NORTH)]
        public void TestDirectionsForRightCommand(int x, int y, Direction dir, Direction expected)
        {
            //Arrange
            var position = new Position(x, y, dir);
            botMock.SetupGet(bot => bot.Position).Returns(position);
            var command = new RightCommand(botMock.Object);

            //Act
            var actual = command.ProcessCommand().Direction;

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
