/*
 Navicat Premium Data Transfer

 Source Server         : Conexão Local FiapStore
 Source Server Type    : SQL Server
 Source Server Version : 16001000
 Source Host           : localhost:1433
 Source Catalog        : ApiLoja
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000
 File Encoding         : 65001

 Date: 22/05/2024 22:14:51
*/


-- ----------------------------
-- Table structure for Checkout
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Checkout]') AND type IN ('U'))
	DROP TABLE [dbo].[Checkout]
GO

CREATE TABLE [dbo].[Checkout] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [IdPedido] int  NOT NULL
)
GO

ALTER TABLE [dbo].[Checkout] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Cliente
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND type IN ('U'))
	DROP TABLE [dbo].[Cliente]
GO

CREATE TABLE [dbo].[Cliente] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [CPF] varchar(11) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Nome] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Login] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Senha] varchar(60) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [IdEndereco] int  NULL
)
GO

ALTER TABLE [dbo].[Cliente] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Endereco
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Endereco]') AND type IN ('U'))
	DROP TABLE [dbo].[Endereco]
GO

CREATE TABLE [dbo].[Endereco] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [CEP] varchar(7) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Logradouro] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Numero] int  NOT NULL,
  [Bairro] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Cidade] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[Endereco] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Pedido
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Pedido]') AND type IN ('U'))
	DROP TABLE [dbo].[Pedido]
GO

CREATE TABLE [dbo].[Pedido] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Data] datetime  NOT NULL,
  [IdCliente] int  NOT NULL
)
GO

ALTER TABLE [dbo].[Pedido] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for PedidoProduto
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[PedidoProduto]') AND type IN ('U'))
	DROP TABLE [dbo].[PedidoProduto]
GO

CREATE TABLE [dbo].[PedidoProduto] (
  [PedidoId] int  NOT NULL,
  [ProdutoId] int  NOT NULL,
  [Quantidade] int  NULL
)
GO

ALTER TABLE [dbo].[PedidoProduto] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Produto
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Produto]') AND type IN ('U'))
	DROP TABLE [dbo].[Produto]
GO

CREATE TABLE [dbo].[Produto] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Nome] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Categoria] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Preco] float(53)  NOT NULL
)
GO

ALTER TABLE [dbo].[Produto] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Auto increment value for Checkout
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Checkout]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table Checkout
-- ----------------------------
ALTER TABLE [dbo].[Checkout] ADD CONSTRAINT [PK__Checkout__3214EC078ABB8552] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Cliente
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Cliente]', RESEED, 3)
GO


-- ----------------------------
-- Uniques structure for table Cliente
-- ----------------------------
ALTER TABLE [dbo].[Cliente] ADD CONSTRAINT [UQ__Cliente__C1F89731A611DFBB] UNIQUE NONCLUSTERED ([CPF] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Cliente
-- ----------------------------
ALTER TABLE [dbo].[Cliente] ADD CONSTRAINT [PK__Cliente__3214EC0765890C95] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Endereco
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Endereco]', RESEED, 5)
GO


-- ----------------------------
-- Primary Key structure for table Endereco
-- ----------------------------
ALTER TABLE [dbo].[Endereco] ADD CONSTRAINT [PK__Endereco__3214EC07761D7807] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Pedido
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Pedido]', RESEED, 7)
GO


-- ----------------------------
-- Primary Key structure for table Pedido
-- ----------------------------
ALTER TABLE [dbo].[Pedido] ADD CONSTRAINT [PK__Pedido__3214EC07C6C78BA9] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table PedidoProduto
-- ----------------------------
ALTER TABLE [dbo].[PedidoProduto] ADD CONSTRAINT [PK__PedidoPr__2072943EF155073B] PRIMARY KEY CLUSTERED ([PedidoId], [ProdutoId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Produto
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Produto]', RESEED, 3)
GO


-- ----------------------------
-- Primary Key structure for table Produto
-- ----------------------------
ALTER TABLE [dbo].[Produto] ADD CONSTRAINT [PK__Produto__3214EC07717E30EB] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table Checkout
-- ----------------------------
ALTER TABLE [dbo].[Checkout] ADD CONSTRAINT [FK__Checkout__IdPedi__44FF419A] FOREIGN KEY ([IdPedido]) REFERENCES [dbo].[Pedido] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Cliente
-- ----------------------------
ALTER TABLE [dbo].[Cliente] ADD CONSTRAINT [fk_idendereco] FOREIGN KEY ([IdEndereco]) REFERENCES [dbo].[Endereco] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Pedido
-- ----------------------------
ALTER TABLE [dbo].[Pedido] ADD CONSTRAINT [fk_cliente_idcliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Cliente] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table PedidoProduto
-- ----------------------------
ALTER TABLE [dbo].[PedidoProduto] ADD CONSTRAINT [FK__PedidoPro__Pedid__412EB0B6] FOREIGN KEY ([PedidoId]) REFERENCES [dbo].[Pedido] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[PedidoProduto] ADD CONSTRAINT [FK__PedidoPro__Produ__4222D4EF] FOREIGN KEY ([ProdutoId]) REFERENCES [dbo].[Produto] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

