using Cookbook.Data.SqlServer.Odbc.Gateways;
using Cookbook.Data.SqlServer.Odbc.Gateways.Providers;
using Ninject.Modules;

namespace Cookbook.Data.SqlServer.Odbc
{
    public sealed class OdbcDataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRecipeDataService>().To<RecipeDataService>().InSingletonScope();
            Bind<IRecipeDataGatewayFactory>().To<RecipeDataGatewayFactory>().InSingletonScope();

            Bind<IComponentDataProvider>().To<ComponentDataProvider>().InSingletonScope();
            Bind<IIngredientDataProvider>().To<IngredientDataProvider>().InSingletonScope();
            Bind<IRecipeDataProvider>().To<RecipeDataProvider>().InSingletonScope();
            Bind<IUnitDataProvider>().To<UnitDataProvider>().InSingletonScope();
        }
    }
}