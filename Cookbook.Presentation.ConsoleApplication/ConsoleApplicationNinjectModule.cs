using Cookbook.Business.Models;
using Cookbook.Presentation.ConsoleApplication.Drawers;
using Cookbook.Presentation.ConsoleApplication.Input;
using Cookbook.Presentation.ConsoleApplication.Menus;
using Cookbook.Presentation.ConsoleApplication.Menus.Options;
using Ninject.Modules;

namespace Cookbook.Presentation.ConsoleApplication
{
    internal sealed class ConsoleApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IApplication>().To<Application>().InSingletonScope();

            Bind<IMenu>().To<Menu>().InSingletonScope();

            Bind<IOption>().To<ShowAllRecipesOption>().InSingletonScope();
            Bind<IOption>().To<ShowRecipeByName>().InSingletonScope();

            Bind<IInputProvider>().To<InputProvider>().InSingletonScope();

            Bind<IErrorDrawer>().To<ErrorDrawer>().InSingletonScope();
            Bind<IInputDrawer>().To<InputDrawer>().InSingletonScope();
            Bind<IOptionDrawer>().To<OptionDrawer>().InSingletonScope();
            Bind<IModelDrawer<Component>>().To<ComponentModelDrawer>().InSingletonScope();
            Bind<IModelDrawer<Recipe>>().To<RecipeModelDrawer>().InSingletonScope();
        }
    }
}