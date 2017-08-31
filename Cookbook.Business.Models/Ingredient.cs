namespace Cookbook.Business.Models
{
    public sealed class Ingredient
    {
        private readonly int id;
        private readonly string name;

        public Ingredient(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id => id;

        public string Name => name;
    }
}