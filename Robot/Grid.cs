using Robot.Interfaces;

namespace Robot
{
    public class Grid : IGrid
    {
        public int Rows { get; }
        public int Columns { get; }

        private int OriginX = 0;
        private int OriginY = 0;

        public Grid(int columns, int rows)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        /// <summary>
        /// Method used to check if a point is inside a rectangle, in our case to check
        /// if a given position of (x, y) are inside the grid, if the last is big enough.
        /// </summary>
        /// <param name="position">Position to be checked</param>
        /// <returns></returns>
        public bool CheckAvailability(IPosition position)
        {
            if (position == null)
            {
                return false;
            }

            if (position.PosX > this.OriginX - 1 && position.PosX < this.Columns && position.PosY > this.OriginY - 1 && position.PosY < this.Rows)
            {
                return true;
            }

            return false;
        }
    }
}
