-- ----------------------------
-- Foreign Keys structure for table Checkout
-- ----------------------------
ALTER TABLE public."Checkout" 
ADD CONSTRAINT "FK_Checkout_IdPedido"
FOREIGN KEY ("IdPedido") REFERENCES public."Pedido" ("Id") 
ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Cliente
-- ----------------------------
ALTER TABLE public."Cliente" 
ADD CONSTRAINT "fk_idendereco"
FOREIGN KEY ("IdEndereco") REFERENCES public."Endereco" ("Id") 
ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Pedido
-- ----------------------------
ALTER TABLE public."Pedido" 
ADD CONSTRAINT "fk_cliente_idcliente"
FOREIGN KEY ("IdCliente") REFERENCES public."Cliente" ("Id") 
ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table PedidoProduto
-- ----------------------------
ALTER TABLE public."PedidoProduto" 
ADD CONSTRAINT "FK_PedidoProduto_PedidoId"
FOREIGN KEY ("PedidoId") REFERENCES public."Pedido" ("Id") 
ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE public."PedidoProduto"
ADD CONSTRAINT "FK_PedidoProduto_ProdutoId"
FOREIGN KEY ("ProdutoId") REFERENCES public."Produto" ("Id") 
ON DELETE NO ACTION ON UPDATE NO ACTION;