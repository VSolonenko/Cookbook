﻿using Cookbook.Business.Models;
using System.Data.Odbc;

namespace Cookbook.Data.SqlServer.Odbc.Gateways.Providers
{
    internal interface IIngredientDataProvider
    {
        Ingredient FindIngredientById(int ingredientId, OdbcConnection connection);
    }
}