using System.Collections.Generic;

namespace Cookbook.Business.Models
{
    public sealed class Recipe
    {
        private readonly IEnumerable<Component> components;
        private readonly int id;
        private readonly string name;

        public Recipe(int id, string name, IEnumerable<Component> components)
        {
            this.components = components;
            this.id = id;
            this.name = name;
        }

        public IEnumerable<Component> Components => components;

        public int Id => id;

        public string Name => name;
    }
}