namespace Cookbook.Business.Models
{
    public sealed class Unit
    {
        private readonly int id;
        private readonly string pluralName;
        private readonly string singularName;

        public Unit(int id, string singularName, string pluralName)
        {
            this.id = id;
            this.pluralName = pluralName;
            this.singularName = singularName;
        }

        public int Id => id;

        public string PluralName => pluralName;

        public string SingularName => singularName;
    }
}