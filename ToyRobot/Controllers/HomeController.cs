using Robot;
using Robot.Enums;
using Robot.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using ToyRobot.Models;

namespace ToyRobot.Controllers
{
    public class HomeController : Controller
    {
        private static IBot Robot { get; set; }
        private static IGameManager Manager { get; set; }

        public ActionResult Game()
        {
            var Game = new GameModel();

            return View(Game);
        }

        [HttpPost]
        public ActionResult Game(GameModel Game)
        {
            var table = new Grid(Game.Columns, Game.Rows);
            Robot = new Bot();
            Manager = new GameManager(table, Robot);
            return RedirectToAction("GameBoard", "Home");
        }


        public ActionResult GameBoard()
        {
            try
            {
                BoardModel board = new BoardModel(Manager);
                return View(board);
            }
            catch
            {
                return RedirectToAction("Game", "Home");
            }
        }

        [HttpPost]
        public ActionResult GameBoard(BoardModel board, CommandType command)
        {
            SetManagerPlaceSettings(board);
            ICommand cmd = Manager.CreateCommand(command, Robot);
            Manager.AddCommandResult(cmd, Robot);
            board.FinishedCommands = (List<string>)Manager.FinishedCommands;
            board.Reports = (List<string>)Manager.Reports;

            return View(board);
        }

        private void SetManagerPlaceSettings(BoardModel board)
        {
            Manager.PlaceX = board.PlaceX;
            Manager.PlaceY = board.PlaceY;
            Manager.PlaceDirection = board.Direction;
        }

    }
}