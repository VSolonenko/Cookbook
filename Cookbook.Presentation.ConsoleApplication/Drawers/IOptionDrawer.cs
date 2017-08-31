using Cookbook.Presentation.ConsoleApplication.Menus.Options;

namespace Cookbook.Presentation.ConsoleApplication.Drawers
{
    internal interface IOptionDrawer
    {
        void Draw(IOption option, bool isSelected);
    }
}