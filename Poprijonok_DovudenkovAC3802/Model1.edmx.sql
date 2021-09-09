
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/09/2021 13:58:16
-- Generated from EDMX file: C:\Users\10180027\source\repos\alex16541\PoprijonokCompany\Poprijonok_DovudenkovAC3802\Model.edmx
-- --------------------------------------------------
Create database [AgentsOfCompany];
GO

SET QUOTED_IDENTIFIER OFF;
GO
USE [AgentsOfCompany];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Agent_AgentType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Agent] DROP CONSTRAINT [FK_Agent_AgentType];
GO
IF OBJECT_ID(N'[dbo].[FK_AgentPriorityHistory_Agent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AgentPriorityHistory] DROP CONSTRAINT [FK_AgentPriorityHistory_Agent];
GO
IF OBJECT_ID(N'[dbo].[FK_Material_MaterialType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Material] DROP CONSTRAINT [FK_Material_MaterialType];
GO
IF OBJECT_ID(N'[dbo].[FK_MaterialCountHistory_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MaterialCountHistory] DROP CONSTRAINT [FK_MaterialCountHistory_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_MaterialSupplier_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MaterialSupplier] DROP CONSTRAINT [FK_MaterialSupplier_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_MaterialSupplier_Supplier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MaterialSupplier] DROP CONSTRAINT [FK_MaterialSupplier_Supplier];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_ProductType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product] DROP CONSTRAINT [FK_Product_ProductType];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductCostHistory_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductCostHistory] DROP CONSTRAINT [FK_ProductCostHistory_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductMaterial_Material]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductMaterial] DROP CONSTRAINT [FK_ProductMaterial_Material];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductMaterial_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductMaterial] DROP CONSTRAINT [FK_ProductMaterial_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductSale_Agent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductSale] DROP CONSTRAINT [FK_ProductSale_Agent];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductSale_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProductSale] DROP CONSTRAINT [FK_ProductSale_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_Shop_Agent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Shop] DROP CONSTRAINT [FK_Shop_Agent];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Agent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Agent];
GO
IF OBJECT_ID(N'[dbo].[AgentPriorityHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AgentPriorityHistory];
GO
IF OBJECT_ID(N'[dbo].[AgentType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AgentType];
GO
IF OBJECT_ID(N'[dbo].[Material]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Material];
GO
IF OBJECT_ID(N'[dbo].[MaterialCountHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaterialCountHistory];
GO
IF OBJECT_ID(N'[dbo].[MaterialSupplier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaterialSupplier];
GO
IF OBJECT_ID(N'[dbo].[MaterialType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaterialType];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[ProductCostHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductCostHistory];
GO
IF OBJECT_ID(N'[dbo].[ProductMaterial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductMaterial];
GO
IF OBJECT_ID(N'[dbo].[ProductSale]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSale];
GO
IF OBJECT_ID(N'[dbo].[ProductType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductType];
GO
IF OBJECT_ID(N'[dbo].[Shop]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Shop];
GO
IF OBJECT_ID(N'[dbo].[Supplier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Supplier];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Agent'
CREATE TABLE [dbo].[Agent] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(150)  NOT NULL,
    [AgentTypeID] int  NOT NULL,
    [Address] nvarchar(300)  NULL,
    [INN] varchar(12)  NOT NULL,
    [KPP] varchar(9)  NULL,
    [DirectorName] nvarchar(100)  NULL,
    [Phone] nvarchar(20)  NOT NULL,
    [Email] nvarchar(255)  NULL,
    [Logo] nvarchar(100)  NULL,
    [Priority] int  NULL
);
GO

-- Creating table 'AgentPriorityHistory'
CREATE TABLE [dbo].[AgentPriorityHistory] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AgentID] int  NOT NULL,
    [ChangeDate] datetime  NOT NULL,
    [PriorityValue] int  NOT NULL
);
GO

-- Creating table 'AgentType'
CREATE TABLE [dbo].[AgentType] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NOT NULL,
    [Image] nvarchar(100)  NULL
);
GO

-- Creating table 'Material'
CREATE TABLE [dbo].[Material] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [CountInPack] int  NOT NULL,
    [Unit] nvarchar(10)  NOT NULL,
    [CountInStock] float  NULL,
    [MinCount] float  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Cost] decimal(10,2)  NOT NULL,
    [Image] nvarchar(100)  NULL,
    [MaterialTypeID] int  NOT NULL
);
GO

-- Creating table 'MaterialCountHistory'
CREATE TABLE [dbo].[MaterialCountHistory] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [MaterialID] int  NOT NULL,
    [ChangeDate] datetime  NOT NULL,
    [CountValue] float  NOT NULL
);
GO

-- Creating table 'MaterialType'
CREATE TABLE [dbo].[MaterialType] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NOT NULL,
    [DefectedPercent] float  NOT NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(100)  NOT NULL,
    [ProductTypeID] int  NULL,
    [ArticleNumber] nvarchar(10)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Image] nvarchar(100)  NULL,
    [ProductionPersonCount] int  NULL,
    [ProductionWorkshopNumber] int  NULL,
    [MinCostForAgent] decimal(10,2)  NOT NULL
);
GO

-- Creating table 'ProductCostHistory'
CREATE TABLE [dbo].[ProductCostHistory] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ProductID] int  NOT NULL,
    [ChangeDate] datetime  NOT NULL,
    [CostValue] decimal(10,2)  NOT NULL
);
GO

-- Creating table 'ProductMaterial'
CREATE TABLE [dbo].[ProductMaterial] (
    [ProductID] int  NOT NULL,
    [MaterialID] int  NOT NULL,
    [Count] float  NULL
);
GO

-- Creating table 'ProductSale'
CREATE TABLE [dbo].[ProductSale] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AgentID] int  NOT NULL,
    [ProductID] int  NOT NULL,
    [SaleDate] datetime  NOT NULL,
    [ProductCount] int  NOT NULL
);
GO

-- Creating table 'ProductType'
CREATE TABLE [dbo].[ProductType] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NOT NULL,
    [DefectedPercent] float  NULL
);
GO

-- Creating table 'Shop'
CREATE TABLE [dbo].[Shop] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(150)  NOT NULL,
    [Address] nvarchar(300)  NULL,
    [AgentID] int  NOT NULL
);
GO

-- Creating table 'Supplier'
CREATE TABLE [dbo].[Supplier] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(150)  NOT NULL,
    [INN] varchar(12)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [QualityRating] int  NULL,
    [SupplierType] nvarchar(20)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'MaterialSupplier'
CREATE TABLE [dbo].[MaterialSupplier] (
    [Material_ID] int  NOT NULL,
    [Supplier_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Agent'
ALTER TABLE [dbo].[Agent]
ADD CONSTRAINT [PK_Agent]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AgentPriorityHistory'
ALTER TABLE [dbo].[AgentPriorityHistory]
ADD CONSTRAINT [PK_AgentPriorityHistory]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'AgentType'
ALTER TABLE [dbo].[AgentType]
ADD CONSTRAINT [PK_AgentType]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Material'
ALTER TABLE [dbo].[Material]
ADD CONSTRAINT [PK_Material]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'MaterialCountHistory'
ALTER TABLE [dbo].[MaterialCountHistory]
ADD CONSTRAINT [PK_MaterialCountHistory]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'MaterialType'
ALTER TABLE [dbo].[MaterialType]
ADD CONSTRAINT [PK_MaterialType]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ProductCostHistory'
ALTER TABLE [dbo].[ProductCostHistory]
ADD CONSTRAINT [PK_ProductCostHistory]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ProductID], [MaterialID] in table 'ProductMaterial'
ALTER TABLE [dbo].[ProductMaterial]
ADD CONSTRAINT [PK_ProductMaterial]
    PRIMARY KEY CLUSTERED ([ProductID], [MaterialID] ASC);
GO

-- Creating primary key on [ID] in table 'ProductSale'
ALTER TABLE [dbo].[ProductSale]
ADD CONSTRAINT [PK_ProductSale]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ProductType'
ALTER TABLE [dbo].[ProductType]
ADD CONSTRAINT [PK_ProductType]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Shop'
ALTER TABLE [dbo].[Shop]
ADD CONSTRAINT [PK_Shop]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Supplier'
ALTER TABLE [dbo].[Supplier]
ADD CONSTRAINT [PK_Supplier]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Material_ID], [Supplier_ID] in table 'MaterialSupplier'
ALTER TABLE [dbo].[MaterialSupplier]
ADD CONSTRAINT [PK_MaterialSupplier]
    PRIMARY KEY CLUSTERED ([Material_ID], [Supplier_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AgentTypeID] in table 'Agent'
ALTER TABLE [dbo].[Agent]
ADD CONSTRAINT [FK_Agent_AgentType]
    FOREIGN KEY ([AgentTypeID])
    REFERENCES [dbo].[AgentType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Agent_AgentType'
CREATE INDEX [IX_FK_Agent_AgentType]
ON [dbo].[Agent]
    ([AgentTypeID]);
GO

-- Creating foreign key on [AgentID] in table 'AgentPriorityHistory'
ALTER TABLE [dbo].[AgentPriorityHistory]
ADD CONSTRAINT [FK_AgentPriorityHistory_Agent]
    FOREIGN KEY ([AgentID])
    REFERENCES [dbo].[Agent]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AgentPriorityHistory_Agent'
CREATE INDEX [IX_FK_AgentPriorityHistory_Agent]
ON [dbo].[AgentPriorityHistory]
    ([AgentID]);
GO

-- Creating foreign key on [AgentID] in table 'ProductSale'
ALTER TABLE [dbo].[ProductSale]
ADD CONSTRAINT [FK_ProductSale_Agent]
    FOREIGN KEY ([AgentID])
    REFERENCES [dbo].[Agent]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductSale_Agent'
CREATE INDEX [IX_FK_ProductSale_Agent]
ON [dbo].[ProductSale]
    ([AgentID]);
GO

-- Creating foreign key on [AgentID] in table 'Shop'
ALTER TABLE [dbo].[Shop]
ADD CONSTRAINT [FK_Shop_Agent]
    FOREIGN KEY ([AgentID])
    REFERENCES [dbo].[Agent]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Shop_Agent'
CREATE INDEX [IX_FK_Shop_Agent]
ON [dbo].[Shop]
    ([AgentID]);
GO

-- Creating foreign key on [MaterialTypeID] in table 'Material'
ALTER TABLE [dbo].[Material]
ADD CONSTRAINT [FK_Material_MaterialType]
    FOREIGN KEY ([MaterialTypeID])
    REFERENCES [dbo].[MaterialType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Material_MaterialType'
CREATE INDEX [IX_FK_Material_MaterialType]
ON [dbo].[Material]
    ([MaterialTypeID]);
GO

-- Creating foreign key on [MaterialID] in table 'MaterialCountHistory'
ALTER TABLE [dbo].[MaterialCountHistory]
ADD CONSTRAINT [FK_MaterialCountHistory_Material]
    FOREIGN KEY ([MaterialID])
    REFERENCES [dbo].[Material]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MaterialCountHistory_Material'
CREATE INDEX [IX_FK_MaterialCountHistory_Material]
ON [dbo].[MaterialCountHistory]
    ([MaterialID]);
GO

-- Creating foreign key on [MaterialID] in table 'ProductMaterial'
ALTER TABLE [dbo].[ProductMaterial]
ADD CONSTRAINT [FK_ProductMaterial_Material]
    FOREIGN KEY ([MaterialID])
    REFERENCES [dbo].[Material]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductMaterial_Material'
CREATE INDEX [IX_FK_ProductMaterial_Material]
ON [dbo].[ProductMaterial]
    ([MaterialID]);
GO

-- Creating foreign key on [ProductTypeID] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [FK_Product_ProductType]
    FOREIGN KEY ([ProductTypeID])
    REFERENCES [dbo].[ProductType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_ProductType'
CREATE INDEX [IX_FK_Product_ProductType]
ON [dbo].[Product]
    ([ProductTypeID]);
GO

-- Creating foreign key on [ProductID] in table 'ProductCostHistory'
ALTER TABLE [dbo].[ProductCostHistory]
ADD CONSTRAINT [FK_ProductCostHistory_Product]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Product]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductCostHistory_Product'
CREATE INDEX [IX_FK_ProductCostHistory_Product]
ON [dbo].[ProductCostHistory]
    ([ProductID]);
GO

-- Creating foreign key on [ProductID] in table 'ProductMaterial'
ALTER TABLE [dbo].[ProductMaterial]
ADD CONSTRAINT [FK_ProductMaterial_Product]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Product]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProductID] in table 'ProductSale'
ALTER TABLE [dbo].[ProductSale]
ADD CONSTRAINT [FK_ProductSale_Product]
    FOREIGN KEY ([ProductID])
    REFERENCES [dbo].[Product]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductSale_Product'
CREATE INDEX [IX_FK_ProductSale_Product]
ON [dbo].[ProductSale]
    ([ProductID]);
GO

-- Creating foreign key on [Material_ID] in table 'MaterialSupplier'
ALTER TABLE [dbo].[MaterialSupplier]
ADD CONSTRAINT [FK_MaterialSupplier_Material]
    FOREIGN KEY ([Material_ID])
    REFERENCES [dbo].[Material]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Supplier_ID] in table 'MaterialSupplier'
ALTER TABLE [dbo].[MaterialSupplier]
ADD CONSTRAINT [FK_MaterialSupplier_Supplier]
    FOREIGN KEY ([Supplier_ID])
    REFERENCES [dbo].[Supplier]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MaterialSupplier_Supplier'
CREATE INDEX [IX_FK_MaterialSupplier_Supplier]
ON [dbo].[MaterialSupplier]
    ([Supplier_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------