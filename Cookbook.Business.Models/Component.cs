namespace Cookbook.Business.Models
{
    public sealed class Component
    {
        private readonly int id;
        private readonly Ingredient ingredient;
        private readonly double quantity;
        private readonly Unit unit;

        public Component(int id, Ingredient ingredient, double quantity, Unit unit)
        {
            this.id = id;
            this.ingredient = ingredient;
            this.quantity = quantity;
            this.unit = unit;
        }

        public int Id => id;

        public Ingredient Ingredient => ingredient;

        public double Quantity => quantity;

        public Unit Unit => unit;
    }
}