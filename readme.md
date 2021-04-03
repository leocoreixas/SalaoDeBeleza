# Sistema Salão de Beleza

Essa API project foi desenvoldido com o ASP.NET Core. Essa API seguiu boas praticas com Clean Code. 

### Pré requisitos

Instalação do Visual Studio Code e .NET Core .

```
baixar as ultimas versões:
https://code.visualstudio.com/
https://dotnet.microsoft.com/download
```


 Bancos de dados
```
SQLite uma SQL database engine
```
# Endpoints Home
Endpoints dentro da home.

## **GET** ```/api/v1```
Retorna um teste de criação de usuario.

Exemplo: https://localhost:5001/api/v1/

resposta esperada:
```
{
    "id": 1,
    "nomeUsuario": "leonardo",
    "senha": "*******",
    "email": "leonardo@gmail.com"
}
```
# Endpoints Usuario
Endpoints dentro de usuario.

## **POST** ```/api/v1/user```
Cria um usuario.
Entrada utilizada no postman em raw e JSON

Exemplo: https://localhost:5001/api/v1/user
```
{
    "nomeUsuario": "teste",
    "senha": "123456",
    "email": "teste@gmail.com"
}
```
resposta esperada:
```
{
    "id": 20,
    "nomeUsuario": "teste",
    "senha": "123456",
    "email": "teste@gmail.com"
}
```
O id incrementa de acordo com a criação do usuario.


## **PUT** ```/api/v1/user```
Cria um usuario ou verifica se já existe.
Entrada utilizada no postman em raw e JSON

Exemplo: https://localhost:5001/api/v1/user
```
{
    "nomeUsuario": "teste",
    "senha": "123456",
    "email": "teste@gmail.com"
}
```
respostas esperadas:
```
{
    "mensagem": "Usuário não encontrado"
}
```
```
{
    "mensagem": "Não foi possível criar o usuário"
}
```
```
{
    "id": 1,
    "nomeUsuario": "teste",
    "senha": "123456",
    "email": "teste@gmail.com"
}
```

## **DELETE** ```/api/v1/user/delete```
Apagar um usuario.
Entrada utilizada no postman em raw e JSON

Exemplo: https://localhost:5001/api/v1/user/delete
```
{
    "id": 1,  
    "nomeUsuario": "teste",
    "senha": "123456",
    "email": "teste@gmail.com"
}
```
resposta esperada:
```
{
    "mensagem": "Usuário apagado"
}
```

# Endpoints Cliente
Endpoints dentro de cliente.

## **GET** ```/api/v1/clientes```
Retorna a lista de clientes existentes.

Exemplo: https://localhost:5001/api/v1/clientes

resposta esperada:
```
{
  [
    {
      "id":1,
      "nome": "leonardo",
      "email": "teste@gmail.com",
      "telefone": "21 967329230"
    }

    {
      "id":2,
      "nome": "leonardo",
      "email": "teste@gmail.com",
      "telefone": "21 967329230"
    }
  ]
}
```
A lista vai variar de acordo com o numero de clientes cadastrados.


## **POST** ```/api/v1/cliente```
Cria um cliente.
Entrada utilizada no postman em raw e JSON

Exemplo: https://localhost:5001/api/v1/cliente
```
{ 
    "nome": "leonardo",
    "email": "teste@gmail.com",
    "telefone": "21 967329230"
}
```
resposta esperada:
```
{
    "id":1,
    "nome": "leonardo",
    "email": "teste@gmail.com",
    "telefone": "21 967329230"
}
```
O id incrementa de acordo com a criação do cliente.

## **DELETE** ```/api/v1/cliente/delete```
Apagar um usuario.
Entrada utilizada no postman em raw e JSON

Exemplo: https://localhost:5001/api/v1/cliente/delete
```
{
    "id":1,
    "nome": "leonardo",
    "email": "teste@gmail.com",
    "telefone": "21 967329230"
}
```
resposta esperada:
```
{
    "mensagem": "Cliente apagado"
}
```
# Endpoints Funcionário
Endpoints dentro de funcionário.

## **GET** ```/api/v1/funcionarios```
Retorna a lista de funcionários existentes.

Exemplo: https://localhost:5001/api/v1/funcionarios

resposta esperada:
```
{
  [
    {
      "id":1,
      "nome": "leonardo",
      "telefone": "21 967329230",
      "comissao": 25,
      "usuario_id": 1
    }

    {
      "id":2,
      "nome": "leonardo",
      "telefone": "21 967329230",
      "comissao": 25,
      "usuario_id": 1
    }
  ]
}
```
A lista vai variar de acordo com o numero de funcionários cadastrados.


## **POST** ```/api/v1/funcionario```
Cria um funcionário.
Entrada utilizada no postman em raw e JSON

Exemplo: https://localhost:5001/api/v1/funcionario
```
{ 
    "nome": "leonardo",
    "telefone": "21 967329230",
    "comissao": 25,
    "usuario_id": 1
}
```
resposta esperada:
```
{
    "id":1,
    "nome": "leonardo",
    "telefone": "21 967329230",
    "comissao": 25,
    "usuario_id": 1
}
```
O id incrementa de acordo com a criação do funcionário.


## **DELETE** ```/api/v1/funcionario/delete```
Apagar um funcionário.
Entrada utilizada no postman em raw e JSON

Exemplo: https://localhost:5001/api/v1/funcionario/delete
```
{
    "id":1,
    "nome": "leonardo",
    "telefone": "21 967329230",
    "comissao": 25,
    "usuario_id": 1
}
```
resposta esperada:
```
{
    "mensagem": "Funcionário apagado"
}
```
# Endpoints Produto
Endpoints dentro de produto.

## **GET** ```/api/v1/produtos```
Retorna a lista de produtos existentes.

Exemplo: https://localhost:5001/api/v1/produtos

resposta esperada:
```
{
  [
    {
      "id":1,
      "descricao": "condicionador",
      "qnt_destoque": 100,
      "valor": 15,
      "venda_id": 1
    }

    {
      "id":2,
      "descricao": "shampoo",
      "qnt_destoque": 100,
      "valor": 15,
      "venda_id": 2
    }
  ]
}
```
A lista vai variar de acordo com o numero de produtos cadastrados.


## **POST** ```/api/v1/produto```
Cria um produto.
Entrada utilizada no postman em raw e JSON

Exemplo: https://localhost:5001/api/v1/produto
```
{ 
    "descricao": "condicionador",
    "qnt_destoque": 100,
    "valor": 15,
    "venda_id": 1
}
```
resposta esperada:
```
{
    "id":1,
    "descricao": "condicionador",
    "qnt_destoque": 100,
    "valor": 15,
    "venda_id": 1
}
```
O id incrementa de acordo com a criação do produto.


## **DELETE** ```/api/v1/produto/delete```
Apagar um produto.
Entrada utilizada no postman em raw e JSON

Exemplo: https://localhost:5001/api/v1/produto/delete
```
{
    "id":1,
    "descricao": "condicionador",
    "qnt_destoque": 100,
    "valor": 15,
    "venda_id": 1
}
```
resposta esperada:
```
{
    "mensagem": "Produto apagado"
}
```
# Endpoints Serviço
Endpoints dentro de serviço.

## **GET** ```/api/v1/servico```
Retorna a lista de serviços existentes.

Exemplo: https://localhost:5001/api/v1/servicos

resposta esperada:
```
{
  [
    {
      "id":1,
      "nome": "cortar cabelo",
      "valor": 30,
      "fidelidade": 1
      "venda_id": 1
    }

    {
      "id":2,
      "nome": "fazer unha",
      "valor": 25,
      "fidelidade": 2
      "venda_id": 1
    }
  ]
}
```
A lista vai variar de acordo com o numero de serviços cadastrados.
A fidelidade vai variar de acordo com o numero de servicos que aquele cliente recebeu,
assim quando atingir 10 o próximo serviço será gratuito.


## **POST** ```/api/v1/servico```
Cria um serviço.
Entrada utilizada no postman em raw e JSON

Exemplo: https://localhost:5001/api/v1/servico
```
{ 
    "nome": "cortar cabelo",
    "valor": 30,
    "fidelidade": 1
    "venda_id": 1
}
```
resposta esperada:
```
{
    "id":1,
    "nome": "cortar cabelo",
    "valor": 30,
    "fidelidade": 1
    "venda_id": 1
}
```
O id incrementa de acordo com a criação do serviço.


## **DELETE** ```/api/v1/servico/delete```
Apagar um serviço.
Entrada utilizada no postman em raw e JSON

Exemplo: https://localhost:5001/api/v1/servico/delete
```
{
    "id":1,
    "nome": "cortar cabelo",
    "valor": 30,
    "fidelidade": 1
    "venda_id": 1
}
```
resposta esperada:
```
{
    "mensagem": "Serviço apagado"
}
```
# Endpoints Pagamento
Endpoints dentro de pagamento.

## **GET** ```/api/v1/pagamentos```
Retorna a lista de pagamentos existentes.

Exemplo: https://localhost:5001/api/v1/pagamentos

resposta esperada:
```
{
  [
    {
      "id":1,
      "nome_cliente": "leonardo",
      "Forma_pagamento": "cartao de credito",
      "valor_total": 100,
      "valor_recebido":100,
      "DataPagamento": "2021-03-23T18:25:43.511Z"
    }

    {
      "id":2,
      "nome_cliente": "leonardo",
      "Forma_pagamento": "dinheiro",
      "valor_total": 200,
      "valor_recebido":200,
      "Data_pagamento": "2020-01-23T18:25:43.511Z" 
    }
  ]
}
```
A lista vai variar de acordo com o numero de pagamentos cadastrados.

## **POST** ```/api/v1/pagamento```
Cria um pagamento.
Entrada utilizada no postman em raw e JSON

Exemplo: https://localhost:5001/api/v1/pagamento
```
{ 
    "nome_cliente": "leonardo",
    "Forma_pagamento": "dinheiro",
    "valor_total": 200,
    "valor_recebido":200,
    "Data_pagamento": "2020-01-23T18:25:43.511Z" 
}
```
resposta esperada:
```
{
    "id":2,
    "nome_cliente": "leonardo",
    "Forma_pagamento": "dinheiro",
    "valor_total": 200,
    "valor_recebido":200,
    "Data_pagamento": "2020-01-23T18:25:43.511Z" 
}
```
O id incrementa de acordo com a criação do pagamento.


## **DELETE** ```/api/v1/pagamento/delete```
Apagar um serviço.
Entrada utilizada no postman em raw e JSON

Exemplo: https://localhost:5001/api/v1/pagamento/delete
```
{
    "id":1,
    "nome": "cortar cabelo",
    "valor": 30,
    "fidelidade": 1
    "venda_id": 1
}
```
resposta esperada:
```
{
    "mensagem": "Pagamento apagado"
}
```

## Feito com

* [.Net Core](https://docs.microsoft.com/pt-br/dotnet/) - Framework livre e de código aberto.

