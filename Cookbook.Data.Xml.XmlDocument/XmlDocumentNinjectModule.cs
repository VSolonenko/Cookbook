using Cookbook.Data.Xml.XmlDocument.DataProviders;
using Cookbook.Data.Xml.XmlDocument.Gateways;
using Ninject.Modules;

namespace Cookbook.Data.Xml.XmlDocument
{
    public sealed class XmlDocumentNinjectModule : NinjectModule
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