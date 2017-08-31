namespace Cookbook.Presentation.ConsoleApplication.Drawers
{
    internal interface IModelDrawer<in TModel>
    {
        void Draw(TModel model);
    }
}