namespace Cookbook.Presentation.ConsoleApplication.Menus.Options
{
    internal interface IOption
    {
        string Title { get; }

        void Execute();
    }
}