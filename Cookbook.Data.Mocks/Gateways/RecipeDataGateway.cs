using Cookbook.Business.Models;
using Cookbook.Data.Exceptions;
using Cookbook.Data.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookbook.Data.Mocks.Gateways
{
    internal sealed class RecipeDataGateway : IRecipeDataGateway
    {
        private readonly Lazy<IEnumerable<Recipe>> recipes;

        public RecipeDataGateway()
        {
            recipes = new Lazy<IEnumerable<Recipe>>(CreateRecipes);
        }

        private IEnumerable<Recipe> CreateRecipes()
        {
            var mintLeaf = new Ingredient(1, "Mint Leaf");
            var simpleSyrup = new Ingredient(2, "Simple Syrup");
            var limeJuice = new Ingredient(3, "Fresh Lime Juice");
            var whiteRum = new Ingredient(4, "White Rum");
            var clubSoda = new Ingredient(5, "Club Soda");
            var ryeWhiskey = new Ingredient(6, "Rye Whiskey");
            var sweetVermouth = new Ingredient(7, "Sweet Vermouth");
            var angosturaBitters = new Ingredient(8, "Angostura Bitters");
            var daleBitters = new Ingredient(9, "Dale DeGroff's Pimento Aromatic Bitters");
            var benedictine = new Ingredient(10, "Bénédictine");
            var cognac = new Ingredient(11, "Cognac");
            var georgeWhiskey = new Ingredient(12, "George Dickel Rye Whiskey");
            var scotchWhiskey = new Ingredient(13, "Scotch Whisky");
            var glenrothes = new Ingredient(14, "The Glenrothes Select Reserve Single Malt Scotch Whisky");
            var cherryHeering = new Ingredient(15, "Cherry Heering");
            var orangeJuice = new Ingredient(16, "Orange Juice");
            var plymouthGin = new Ingredient(17, "Plymouth Gin");
            var lemonJuice = new Ingredient(18, "Lemon Juice");
            var eggWhite = new Ingredient(19, "Egg White");

            var pieces = new Unit(1, "pc.", "pcs.");
            var ounces = new Unit(2, "oz.", "oz.");
            var drops = new Unit(3, "drop", "drops");
            var dashes = new Unit(4, "dash", "dashes");
            var teaspoons = new Unit(5, "tsp.", "tsp.");

            var mojitoMintLeaf = new Component(1, mintLeaf, 6.0, pieces);
            var mojitoSimpleSyrup = new Component(2, simpleSyrup, 0.75, ounces);
            var mojitoFreshLimeJuice = new Component(3, limeJuice, 0.75, ounces);
            var mojitoWhiteRum = new Component(4, whiteRum, 1.5, ounces);
            var mojitoClubSoda = new Component(5, clubSoda, 1.5, ounces);
            var manhattanRyeWhiskey = new Component(6, ryeWhiskey, 2.0, ounces);
            var manhattanSweetVermouth = new Component(7, sweetVermouth, 1.0, ounces);
            var manhattanAngosturaBitters = new Component(7, angosturaBitters, 5.0, drops);
            var vieuxCarreDaleBitters = new Component(8, daleBitters, 4.0, dashes);
            var vieuxCarreBenedictine = new Component(9, benedictine, 2.0, teaspoons);
            var vieuxCarreSweetVermouth = new Component(10, sweetVermouth, 0.75, ounces);
            var vieuxCarreCognac = new Component(11, cognac, 0.75, ounces);
            var vieuxCarreGeorgeWhiskey = new Component(12, georgeWhiskey, 0.75, ounces);
            var robRoyScotchWhiskey = new Component(13, scotchWhiskey, 2.0, ounces);
            var robRoySweetVermouth = new Component(14, sweetVermouth, 0.75, ounces);
            var robRoyAngosturaBitters = new Component(15, angosturaBitters, 3.0, dashes);
            var bloodAndSandGlenrothes = new Component(16, glenrothes, 0.75, ounces);
            var bloodAndSandSweetVermouth = new Component(17, sweetVermouth, 0.75, ounces);
            var bloodAndSandCherryHeering = new Component(18, cherryHeering, 0.75, ounces);
            var bloodAndSandOrangeJuice = new Component(19, orangeJuice, 0.75, ounces);
            var ginFizzClubSoda = new Component(20, clubSoda, 1.0, ounces);
            var ginFizzPlymouthGin = new Component(21, plymouthGin, 2.0, ounces);
            var ginFizzLemonJuice = new Component(22, lemonJuice, 1.0, ounces);
            var ginFizzSimpleSyrup = new Component(23, simpleSyrup, 0.75, ounces);
            var ginFizzEggWhite = new Component(24, eggWhite, 1.0, pieces);

            var mojito = new Recipe(1, "Mojito", new[] { mojitoMintLeaf, mojitoSimpleSyrup, mojitoFreshLimeJuice, mojitoWhiteRum, mojitoClubSoda });
            var manhattan = new Recipe(2, "Manhattan", new[] { manhattanRyeWhiskey, manhattanSweetVermouth, manhattanAngosturaBitters });
            var vieuxCarre = new Recipe(3, "Vieux Carré", new[] { vieuxCarreDaleBitters, vieuxCarreBenedictine, vieuxCarreSweetVermouth, vieuxCarreCognac, vieuxCarreGeorgeWhiskey });
            var robRoy = new Recipe(4, "Rob Roy", new[] { robRoyScotchWhiskey, robRoySweetVermouth, robRoyAngosturaBitters });
            var bloodAndSand = new Recipe(5, "Blood & Sand", new[] { bloodAndSandGlenrothes, bloodAndSandSweetVermouth, bloodAndSandCherryHeering, bloodAndSandOrangeJuice });
            var ginFizz = new Recipe(6, "Gin Fizz", new[] { ginFizzClubSoda, ginFizzPlymouthGin, ginFizzLemonJuice, ginFizzSimpleSyrup, ginFizzEggWhite });

            return new[] { mojito, manhattan, vieuxCarre, robRoy, bloodAndSand, ginFizz };
        }

        public void Dispose()
        {
            // Do nothing.
        }

        public Recipe FindRecipe(string name)
        {
            return recipes.Value.SingleOrDefault(recipe => recipe.Name.Equals(name))
                ?? throw new RecipeNotFoundDataException(name);
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return recipes.Value;
        }
    }
}