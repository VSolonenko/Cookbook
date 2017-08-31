using Ninject;

namespace Cookbook.Presentation.ConsoleApplication
{
    internal sealed class Program
    {
        private static void Main()
        {
            using (var container = new Container())
            {
                IApplication application = container.Kernel.Get<IApplication>();
                application.Run();
            }
        }
    }
}