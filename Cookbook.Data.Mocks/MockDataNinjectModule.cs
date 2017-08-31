using Ninject.Modules;

namespace Cookbook.Data.Mocks
{
    public sealed class MockDataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRecipeDataService>().To<RecipeDataService>().InSingletonScope();
        }
    }
}