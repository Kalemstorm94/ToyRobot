namespace Robot.Interfaces
{
    public interface IGrid
    {
        int Rows { get; }
        int Columns { get; }
        bool CheckAvailability(IPosition position);
    }
}
