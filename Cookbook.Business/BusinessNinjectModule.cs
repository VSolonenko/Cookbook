using Ninject.Modules;

namespace Cookbook.Business
{
    public sealed class BusinessNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRecipeManager>().To<RecipeManager>().InSingletonScope();
        }
    }
}