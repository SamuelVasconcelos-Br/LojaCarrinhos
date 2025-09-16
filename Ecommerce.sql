create database Ecommerce;

use Ecommerce;

-- CRIANDO AS TABELAS DO BANCO
create table produto(
Id int primary key auto_increment,
Nome varchar(50),
Descricao varchar(100),
Preco decimal(10,2),
ImageUrl varchar(255),
Estoque int

);

create table pedido(
Id int primary key auto_increment ,
DataPedido datetime,
Total decimal(10,2),
Status varchar(50),
Endereco varchar(100),
FormaPagamento varchar(100),
Frete decimal (10,2)
);


create table itemPedido(
Id int primary key auto_increment ,
PedidoId int,
ProdutoId int,
Quantidade int,
PrecoUnitario decimal(10,2)
);
insert into produto(Nome,Descricao,Preco,ImageUrl,Estoque)
values('Miniatura Ferrari LaFerrari','Escala 1:24 em metal',120.00,'imagens/mini1.jpg',500);

insert into produto(Nome,Descricao,Preco,ImageUrl,Estoque)
values('Miniatura Lamborghini Aventador','Colecionável escala 1:32',110.00,'imagens/mini2.jpg',450);

insert into produto(Nome,Descricao,Preco,ImageUrl,Estoque)
values('Miniatura Porsche 911 GT3 RS','Modelo esportivo em liga metálica',130.00,'imagens/mini3.jpg',600);

insert into produto(Nome,Descricao,Preco,ImageUrl,Estoque)
values('Miniatura Bugatti Chiron','Escala 1:24 com detalhes realistas',140.00,'imagens/mini4.jpg',400);

insert into produto(Nome,Descricao,Preco,ImageUrl,Estoque)
values('Miniatura Nissan GT-R R35','Colecionável escala 1:32',100.00,'imagens/mini5.jpg',550);

insert into produto(Nome,Descricao,Preco,ImageUrl,Estoque)
values('Miniatura McLaren P1','Escala 1:24 edição especial',135.00,'imagens/mini6.jpg',350);
select * from produto;
select * from pedido;
select * from itemPedido;