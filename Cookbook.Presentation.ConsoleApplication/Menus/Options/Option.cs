namespace Cookbook.Presentation.ConsoleApplication.Menus.Options
{
    internal abstract class Option : IOption
    {
        private readonly string title;

        protected Option(string title)
        {
            this.title = title;
        }

        public string Title => title;

        public abstract void Execute();
    }
}