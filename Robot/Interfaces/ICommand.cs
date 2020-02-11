namespace Robot.Interfaces
{
    public interface ICommand
    {
        IBot Bot { get; }

        string Name { get; }

        IPosition ProcessCommand();
    }
}
