create database Ecommerce;
-- drop database Ecommerce;
use Ecommerce;

-- CRIANDO AS TABELAS DO BANCO
create table produtos(
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

insert into produtos(Nome,Descricao,Preco,ImageUrl,Estoque)
values('Miniatura Ferrari LaFerrari','Escala 1:24 em metal',1200.00,'img/1875bf9c617bcae10a1e3accf3897707.webp',500);

insert into produtos(Nome,Descricao,Preco,ImageUrl,Estoque)
values('Miniatura Lamborghini Aventador','Colecionável escala 1:32',1130.00,'img/2aa947bfc0554d2cb31aad476f3c2ac2-340cbcf11001517dd516843799671842-1024-1024.webp',450);

insert into produtos(Nome,Descricao,Preco,ImageUrl,Estoque)
values('Miniatura Porsche 911 GT3 RS','Modelo esportivo em liga metálica',1342.90,'img/porsche-911-gt3-cerna-s-pruhem-1-18-maisto-191310019.jpeg',600);

insert into produtos(Nome,Descricao,Preco,ImageUrl,Estoque)
values('Miniatura Bugatti Chiron','Escala 1:24 com detalhes realistas',1781.89,'img/QQ20231109114244__95352.webp',400);

insert into produtos(Nome,Descricao,Preco,ImageUrl,Estoque)
values('Miniatura Nissan GT-R R35','Colecionável escala 1:32',1230.59,'img/OIP.webp',550);

insert into produtos(Nome,Descricao,Preco,ImageUrl,Estoque)
values('Miniatura McLaren P1','Escala 1:24 edição especial',2137.97,'img/miniatura-carro-mclaren-p1-gtr-51-c-luz-e-som-california-action-1-32-california-toys-68323_a.jpeg',350);
select * from produtos;
select * from pedido;
select * from itemPedido;