using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Robot;
using Robot.Commands;
using Robot.Enums;
using Robot.Interfaces;

namespace UnitTests.Robot
{
    [TestClass]
    public class GameManagerTests
    {
        private Mock<IBot> botMock;
        private Mock<IGrid> gridMock;


        [TestInitialize]
        public void Setup()
        {
            botMock = new Mock<IBot>();
            gridMock = new Mock<IGrid>();
        }

        private void ConfigureMocks(int x, int y, Direction dir)
        {
            var position = new Position(x - 2, y - 2, dir);
            botMock.SetupGet(bot => bot.Position).Returns(position);
            gridMock.Setup(grid => grid.Rows).Returns(x);
            gridMock.Setup(grid => grid.Columns).Returns(y);
            gridMock.Setup(grid => grid.CheckAvailability(position)).Returns(true);
        }


        [TestMethod]
        [DataRow(5, 5, Direction.NORTH)]
        public void TestValidCommand(int x, int y, Direction dir)
        {
            //Arrange
            ConfigureMocks(x, y, dir);
            ICommand command = new LeftCommand(botMock.Object);
            var gameManager = new GameManager(gridMock.Object, botMock.Object);
            //gridMock.Setup(grid => grid.CheckAvailability(command.ProcessCommand())).Returns(true);

            //Act
            gameManager.AddCommandResult(command, botMock.Object);

            //Assert
            Assert.AreEqual(1, gameManager.FinishedCommands.Count);
            Assert.AreEqual(0, gameManager.Reports.Count);
        }

        [TestMethod]
        [DataRow(5, 5, Direction.NORTH)]
        public void TestValidReportCommand(int x, int y, Direction dir)
        {
            //Arrange
            ConfigureMocks(x, y, dir);
            ICommand command = new ReportCommand(botMock.Object);
            var gameManager = new GameManager(gridMock.Object, botMock.Object);
            //gridMock.Setup(grid => grid.CheckAvailability(command.ProcessCommand())).Returns(true);

            //Act
            gameManager.AddCommandResult(command, botMock.Object);

            //Assert
            Assert.AreEqual(1, gameManager.FinishedCommands.Count);
            Assert.AreEqual(1, gameManager.Reports.Count);
        }

        [TestMethod]
        [DataRow(5, 5, Direction.NORTH)]
        public void TestInvalidCommand(int x, int y, Direction dir)
        {
            //Arrange
            ICommand command = new MoveCommand(botMock.Object);
            var gameManager = new GameManager(gridMock.Object, botMock.Object);

            //Act
            gameManager.AddCommandResult(command, botMock.Object);

            //Assert
            Assert.AreEqual(1, gameManager.FinishedCommands.Count);
            Assert.AreEqual(0, gameManager.Reports.Count);
        }

        [TestMethod]
        [DataRow(CommandType.LEFT)]
        [DataRow(CommandType.MOVE)]
        [DataRow(CommandType.PLACE)]
        [DataRow(CommandType.REPORT)]
        [DataRow(CommandType.RIGHT)]
        public void TestFactory(CommandType type)
        {
            //Arrange
            var gameManager = new GameManager(gridMock.Object, botMock.Object);

            if (type == CommandType.PLACE)
            {
                gameManager.PlaceX = 0;
                gameManager.PlaceY = 0;
                gameManager.PlaceDirection = Direction.NORTH;
            }

            //Act
            var cmd = gameManager.CreateCommand(type, botMock.Object);

            //Assert
            Assert.AreEqual(type.ToString(), cmd.Name);
        }

    }
}
