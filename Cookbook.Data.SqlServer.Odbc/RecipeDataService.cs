﻿using Cookbook.Data.Gateways;
using Cookbook.Data.SqlServer.Odbc.Gateways;

namespace Cookbook.Data.SqlServer.Odbc
{
    internal sealed class RecipeDataService : IRecipeDataService
    {
        private readonly IRecipeDataGatewayFactory dataGatewayFactory;

        public RecipeDataService(IRecipeDataGatewayFactory dataGatewayFactory)
        {
            this.dataGatewayFactory = dataGatewayFactory;
        }

        public IRecipeDataGateway OpenDataGateway()
        {
            return dataGatewayFactory.CreateDataGateway();
        }
    }
}