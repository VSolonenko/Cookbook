using Ninject.Modules;

namespace Cookbook.Presentation.ConsoleApplication
{
    internal sealed class DataSource<TModule> : IDataSource
        where TModule : INinjectModule, new()
    {
        private readonly string name;

        public DataSource(string name)
        {
            this.name = name;
        }

        public string Name => name;

        public INinjectModule CreateModule()
        {
            return new TModule();
        }
    }
}