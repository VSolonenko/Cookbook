using Cookbook.Business;
using Cookbook.Data.Mocks;
using Cookbook.Data.SqlServer.Odbc;
using Ninject;
using Ninject.Modules;
using System;

namespace Cookbook.Presentation.ConsoleApplication
{
    internal sealed class Container : DisposableObject
    {
        private readonly Lazy<IDataSource> dataSource;
        private readonly Lazy<IKernel> kernel;

        public Container()
        {
            dataSource = new Lazy<IDataSource>(CreateDataSource);
            kernel = new Lazy<IKernel>(CreateKernel);
        }

        public IKernel Kernel => kernel.Value;

        private IDataSource CreateDataSource()
        {
            var dataSources = new IDataSource[]
            {
                new DataSource<MockDataNinjectModule>("Mocks"),
                new DataSource<OdbcDataNinjectModule>("SQL Server (ODBC)")
            };

            while (true)
            {
                Console.Clear();

                for (var index = 0; index < dataSources.Length; ++index)
                {
                    Console.WriteLine($"{index + 1}. {dataSources[index].Name}");
                }

                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                if (key.Key > ConsoleKey.D0 && key.Key < ConsoleKey.D9)
                {
                    int index = key.Key - ConsoleKey.D0 - 1;
                    if (index >= 0 && index < dataSources.Length)
                    {
                        return dataSources[index];
                    }
                }
            }
        }

        private IKernel CreateKernel()
        {
            INinjectModule dataModule = dataSource.Value.CreateModule();

            var kernel = new StandardKernel(
                new ConsoleApplicationNinjectModule(),
                new BusinessNinjectModule(),
                dataModule
            );

            return kernel;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (kernel.IsValueCreated)
                {
                    kernel.Value.Dispose();
                }
            }
        }
    }
}