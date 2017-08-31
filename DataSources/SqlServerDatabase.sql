USE MASTER;
GO

IF DB_ID('Cookbook') IS NOT NULL
BEGIN
	DROP DATABASE [Cookbook];
END
GO

CREATE DATABASE [Cookbook];
GO

USE [Cookbook];
GO

-- Tables.
CREATE TABLE [Components]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Quantity] FLOAT NOT NULL,
	[IngredientId] INT NOT NULL,
	[UnitId] INT NOT NULL
);
GO

CREATE TABLE [Ingredients]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(255) NOT NULL UNIQUE
);
GO

CREATE TABLE [Recipes]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(255) NOT NULL UNIQUE
);
GO

CREATE TABLE [Units]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[PluralName] NVARCHAR(255) NOT NULL UNIQUE,
	[SingularName] NVARCHAR(255) NOT NULL UNIQUE
);
GO

-- Cross reference tables.
CREATE TABLE [RecipesComponents]
(
	[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[ComponentId] INT NOT NULL,
	[RecipeId] INT NOT NULL
);
GO

-- Foreign keys.
ALTER TABLE [Components]
ADD FOREIGN KEY ([IngredientId]) REFERENCES [Ingredients] ([Id]);
GO

ALTER TABLE [Components]
ADD FOREIGN KEY ([UnitId]) REFERENCES [Units] ([Id]);
GO

ALTER TABLE [RecipesComponents]
ADD FOREIGN KEY ([ComponentId]) REFERENCES [Components] ([Id]);
GO

ALTER TABLE [RecipesComponents]
ADD FOREIGN KEY ([RecipeId]) REFERENCES [Recipes] ([Id]);
GO

-- Inserts.
INSERT INTO [Units] ([PluralName], [SingularName]) VALUES
	(N'pcs.', N'pc.'),
	(N'oz.', N'oz.'),
	(N'drops', N'drop'),
	(N'dashes', N'dash'),
	(N'tsp.', N'tsp.');
GO

INSERT INTO [Ingredients] ([Name]) VALUES
	(N'Mint Leaf'),
	(N'Simple Syrup'),
	(N'Fresh Lime Juice'),
	(N'White Rum'),
	(N'Club Soda'),
	(N'Rye Whiskey'),
	(N'Sweet Vermouth'),
	(N'Angostura Bitters'),
	(N'Dale DeGroff''s Pimento Aromatic Bitters'),
	(N'Bénédictine'),
	(N'Cognac'),
	(N'George Dickel Rye Whiskey'),
	(N'Scotch Whiskey');
GO

INSERT INTO [Recipes] ([Name]) VALUES
	(N'Mojito'),
	(N'Manhattan'),
	(N'Vieux Carré'),
	(N'Rob Roy');
GO

INSERT INTO [Components] ([Quantity], [IngredientId], [UnitId]) VALUES
	(6.0, 1, 1),
	(0.75, 2, 2),
	(0.75, 3, 2),
	(1.5, 4, 2),
	(1.5, 5, 2),
	(2.0, 6, 2),
	(1.0, 7, 2),
	(5.0, 8, 3),
	(4.0, 9, 4),
	(2.0, 10, 5),
	(0.75, 7, 2),
	(0.75, 11, 2),
	(0.75, 12, 2),
	(2.0, 13, 2),
	(0.75, 7, 2),
	(3.0, 8, 4);
GO

INSERT INTO [RecipesComponents] ([ComponentId], [RecipeId]) VALUES
	(1, 1),
	(2, 1),
	(3, 1),
	(4, 1),
	(5, 1),
	(6, 2),
	(7, 2),
	(8, 2),
	(9, 3),
	(10, 3),
	(11, 3),
	(12, 3),
	(13, 3),
	(14, 4),
	(15, 4),
	(16, 4);
GO