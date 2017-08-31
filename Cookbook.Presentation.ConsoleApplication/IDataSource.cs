using Ninject.Modules;

namespace Cookbook.Presentation.ConsoleApplication
{
    internal interface IDataSource
    {
        string Name { get; }

        INinjectModule CreateModule();
    }
}