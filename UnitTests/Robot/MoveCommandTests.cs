using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Robot;
using Robot.Commands;
using Robot.Enums;
using Robot.Interfaces;

namespace UnitTests.Robot
{
    [TestClass]
    public class MoveCommandTests
    {
        private Mock<IBot> botMock;

        [TestInitialize]
        public void Setup()
        {
            botMock = new Mock<IBot>();
        }

        [TestMethod]
        [DataRow(1, 1, Direction.NORTH, 1, 2)]
        [DataRow(1, 1, Direction.EAST, 2, 1)]
        [DataRow(1, 1, Direction.SOUTH, 1, 0)]
        [DataRow(1, 1, Direction.WEST, 0, 1)]
        public void TestPositionAfterMoving(int x, int y, Direction dir, int expX, int expY)
        {
            //Arrange
            var position = new Position(x, y, dir);
            botMock.SetupGet(bot => bot.Position).Returns(position);
            var command = new MoveCommand(botMock.Object);

            //Act
            var cmd = command.ProcessCommand();
            var actualX = cmd.PosX;
            var actualY = cmd.PosY;

            //Assert
            Assert.AreEqual(expX, actualX);
            Assert.AreEqual(expY, actualY);
        }
    }
}
