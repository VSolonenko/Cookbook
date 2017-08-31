namespace Cookbook.Data.SqlServer.Odbc.TransferObjects
{
    internal sealed class Component
    {
        public int Id { get; set; }

        public int IngredientId { get; set; }

        public double Quantity { get; set; }

        public int UnitId { get; set; }
    }
}