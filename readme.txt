# Api Loja
## Descri��o do Projeto
Uma API com endpoints para ser usada em aplica��es do tipo E-Commerce
### Tecnologias utilizadas
.NET 8, Postgre
### Como rodar
Abrir o programa Docker Desktop
Extrair o RAR para uma pasta.
Acessar a pasta atrav�s do Prompt de Comando
Executar ```docker-compose up -d``` na pasta onde est� localizado o arquivo do docker-compose.yml
### Observa��es Gerais
-O compose subir� 2 inst�ncias, uma para o banco de dados e outra para a api.
###
http://localhost:1012/swagger/index.html
###
-O Json para fazer pedidos 
```{
  "idProdutoXQtde": {
    "additionalProp1": 0,
    "additionalProp2": 0,
    "additionalProp3": 0
  },
  "Data": DateTime
}
```
No lugar das "additionalProp", substituir pelo Id do produto e a quantidade solicitada.
-Nesta vers�o, como n�o h� login, todos os pedidos efetuados s�o cadastrados no primeiro cliente que se cadastrar (Id 1)
###
- Quando o pedido for realizado pode-se verificar o status em listar pedido como ``Recebido``.
- Quando for realizado o fakecheckout, o status do pedido ser� alterado para ``Pago``.


##link Miro
https://miro.com/app/board/uXjVKVou2MA=/
https://miro.com/app/board/uXjVKVogqwk=/

##link Github
https://github.com/eltongm3004/techchalenge