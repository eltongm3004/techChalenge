DROP TABLE IF EXISTS public."Checkout";

CREATE TABLE public."Checkout" (
  "Id" serial PRIMARY KEY,
  "IdPedido" int NOT NULL
);

-- ----------------------------
-- Table structure for Cliente
-- ----------------------------
DROP TABLE IF EXISTS public."Cliente";

CREATE TABLE public."Cliente" (
  "Id" serial PRIMARY KEY,
  "CPF" varchar(11) NULL,
  "Nome" varchar(100) NOT NULL,
  "Login" varchar(50) NOT NULL,
  "Senha" varchar(60) NOT NULL,
  "IdEndereco" int NULL,
  CONSTRAINT "UQ_Cliente_CPF" UNIQUE ("CPF")
);
-- ----------------------------
-- Table structure for Endereco
-- ----------------------------
DROP TABLE IF EXISTS public."Endereco";

CREATE TABLE public."Endereco" (
  "Id" serial PRIMARY KEY,
  "CEP" varchar(8) NOT NULL,
  "Logradouro" varchar(100) NOT NULL,
  "Numero" int NOT NULL,
  "Bairro" varchar(50) NOT NULL,
  "Cidade" varchar(50) NOT NULL
);

-- ----------------------------
-- Table structure for Pedido
-- ----------------------------
DROP TABLE IF EXISTS public."Pedido";

CREATE TABLE public."Pedido" (
  "Id" serial PRIMARY KEY,
  "Data" timestamp NOT NULL,
  "IdCliente" int NOT NULL,
  "Status" varchar(20) NOT NULL
);

-- ----------------------------
-- Table structure for PedidoProduto
-- ----------------------------
DROP TABLE IF EXISTS public."PedidoProduto";

CREATE TABLE public."PedidoProduto" (
  "PedidoId" int NOT NULL,
  "ProdutoId" int NOT NULL,
  "Quantidade" int NULL,
  PRIMARY KEY ("PedidoId", "ProdutoId")
);

-- ----------------------------
-- Table structure for Produto
-- ----------------------------
DROP TABLE IF EXISTS public."Produto";

CREATE TABLE public."Produto" (
  "Id" serial PRIMARY KEY,
  "Nome" varchar(100) NOT NULL,
  "Categoria" varchar(50) NOT NULL,
  "Preco" double precision NOT NULL
);