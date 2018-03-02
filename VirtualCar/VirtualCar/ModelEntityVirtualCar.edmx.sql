
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/22/2018 18:59:37
-- Generated from EDMX file: C:\Users\Moons\Documents\Visual Studio 2013\Projects\VirtualCar\VirtualCar\ModelEntityVirtualCar.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [VirtualCarDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DetallePedido_Pedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePedido] DROP CONSTRAINT [FK_DetallePedido_Pedido];
GO
IF OBJECT_ID(N'[dbo].[FK_DetallePedido_Producto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallePedido] DROP CONSTRAINT [FK_DetallePedido_Producto];
GO
IF OBJECT_ID(N'[dbo].[FK_Pedido_Cliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pedido] DROP CONSTRAINT [FK_Pedido_Cliente];
GO
IF OBJECT_ID(N'[dbo].[FK_Producto_Categoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Producto] DROP CONSTRAINT [FK_Producto_Categoria];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categoria]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categoria];
GO
IF OBJECT_ID(N'[dbo].[Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente];
GO
IF OBJECT_ID(N'[dbo].[DetallePedido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetallePedido];
GO
IF OBJECT_ID(N'[dbo].[Pedido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pedido];
GO
IF OBJECT_ID(N'[dbo].[Producto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Producto];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(50)  NULL,
    [descripcion] varchar(50)  NULL
);
GO

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombres] varchar(50)  NULL,
    [apellidos] nchar(10)  NULL,
    [Direccion] varchar(50)  NULL,
    [telefono] varchar(50)  NULL,
    [DNI] nchar(10)  NULL,
    [email] varchar(50)  NULL,
    [usuario] varbinary(50)  NULL,
    [clave] nchar(8)  NULL
);
GO

-- Creating table 'DetallePedidoes'
CREATE TABLE [dbo].[DetallePedidoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [id_ped] int  NULL,
    [id_pro] int  NULL,
    [cantidad] int  NULL,
    [precio_venta] float  NULL,
    [descuento] float  NULL,
    [importe] float  NULL
);
GO

-- Creating table 'Pedidoes'
CREATE TABLE [dbo].[Pedidoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [id_cli] int  NULL,
    [fecha_ped] datetime  NULL,
    [subtotal] float  NULL,
    [total] float  NULL,
    [IGV] float  NULL
);
GO

-- Creating table 'Productoes'
CREATE TABLE [dbo].[Productoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] varchar(50)  NULL,
    [descripcion] varchar(50)  NULL,
    [precio] float  NULL,
    [stock] int  NULL,
    [foto] varbinary(max)  NULL,
    [id_cat] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetallePedidoes'
ALTER TABLE [dbo].[DetallePedidoes]
ADD CONSTRAINT [PK_DetallePedidoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pedidoes'
ALTER TABLE [dbo].[Pedidoes]
ADD CONSTRAINT [PK_Pedidoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Productoes'
ALTER TABLE [dbo].[Productoes]
ADD CONSTRAINT [PK_Productoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [id_cat] in table 'Productoes'
ALTER TABLE [dbo].[Productoes]
ADD CONSTRAINT [FK_Producto_Categoria]
    FOREIGN KEY ([id_cat])
    REFERENCES [dbo].[Categorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Producto_Categoria'
CREATE INDEX [IX_FK_Producto_Categoria]
ON [dbo].[Productoes]
    ([id_cat]);
GO

-- Creating foreign key on [id_cli] in table 'Pedidoes'
ALTER TABLE [dbo].[Pedidoes]
ADD CONSTRAINT [FK_Pedido_Cliente]
    FOREIGN KEY ([id_cli])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pedido_Cliente'
CREATE INDEX [IX_FK_Pedido_Cliente]
ON [dbo].[Pedidoes]
    ([id_cli]);
GO

-- Creating foreign key on [id_ped] in table 'DetallePedidoes'
ALTER TABLE [dbo].[DetallePedidoes]
ADD CONSTRAINT [FK_DetallePedido_Pedido]
    FOREIGN KEY ([id_ped])
    REFERENCES [dbo].[Pedidoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePedido_Pedido'
CREATE INDEX [IX_FK_DetallePedido_Pedido]
ON [dbo].[DetallePedidoes]
    ([id_ped]);
GO

-- Creating foreign key on [id_pro] in table 'DetallePedidoes'
ALTER TABLE [dbo].[DetallePedidoes]
ADD CONSTRAINT [FK_DetallePedido_Producto]
    FOREIGN KEY ([id_pro])
    REFERENCES [dbo].[Productoes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetallePedido_Producto'
CREATE INDEX [IX_FK_DetallePedido_Producto]
ON [dbo].[DetallePedidoes]
    ([id_pro]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------