/*
	
	Script para criar tablespace, usuário, etc.

	Usuário para banco: ms_user. 
	Senha do usuário do banco: ms_user;

	create tablespace mr datafile 'mr.dat' size 20m online;
	create temporary tablespace mr_temp tempfile 'mr_temp.dbf' size 5m autoextend on;
	create user ms_user identified by ms_user default tablespace mr temporary tablespace mr_temp quota 20m on mr;
	grant create session to ms_user;
	grant create table to ms_user;
	grant create view to ms_user;
	grant create any trigger to ms_user;
	grant create any procedure to ms_user;
	grant create sequence to ms_user;
	grant create synonym to ms_user;
	
*/

create table Usuarios (

	IdUsuario integer,
	Nome varchar2(255) not null,
	Senha varchar2(255) not null,
	Tipo char(1) not null,
	Email varchar2(255) not null,
	Telefone varchar2(255) not null,
	
	constraint PK_Usuario primary key (IdUsuario),
	constraint UQ_Usuarios_Nome unique (Nome),
	constraint UQ_Usuarios_Email unique (Email),
	constraint CK_Tipo_01 check (Tipo = '0' or Tipo = '1') -- 0: Padrao, 1:Admin.
	
);

create table Servicos (

	IdServico integer,
	Nome varchar2(50) not null,
	Preco number(18,2) not null,
	Descricao clob not null,
	IdImagem integer,

	constraint PK_Servicos primary key (IdServico),
	constraint FK_Servicos_Imagens foreign key (IdImagem) references Imagens(IdImagem)

);

create table Produtos (

	IdProduto integer not null,
	Nome varchar2(50) not null,
	Preco number(18,2) not null,
	Descricao clob not null,
	IdImagem integer,

	constraint PK_Produtos primary key (IdProduto),
	constraint FK_Produtos_Imagens foreign key (IdImagem) references Imagens(IdImagem)

);

create table Imagens (
	
	IdImagem integer,
	Caminho varchar2(255) not null,

	constraint PK_Imagem primary key (IdImagem),
	constraint UQ_Imagem_Caminho unique (Caminho)

);

--Sequences:
create sequence Seq_Imagens increment by 1 start with 1;
create sequence Seq_Produtos increment by 1 start with 1;
create sequence Seq_Servicos increment by 1 start with 1;
create sequence Seq_Usuarios increment by 1 start with 1;

--Procedures:

--Usuário

create or replace procedure InserirUsuario (
	cnome Usuarios.Nome%type, 
	csenha Usuarios.Senha%type, 
	ctipo Usuarios.Tipo%type, 
	cemail Usuarios.Email%type, 
	ctelefone Usuarios.Telefone%type
) is
begin 
	insert into Usuarios(IdUsuario, Nome, Senha, Tipo, Email, Telefone) 
		values(Seq_Usuarios.nextval, cnome, csenha, ctipo, cemail, ctelefone);
end;/

create or replace procedure AtualizarUsuario
(
	id 			Usuarios.IdUsuario%type, 
	cnome 		Usuarios.Nome%type, 
	csenha 		Usuarios.Senha%type, 
	ctipo 		Usuarios.Tipo%type, 
	cemail 		Usuarios.Email%type, 
	ctelefone 	Usuarios.Telefone%type
) is
begin
	update Usuarios set 
		Nome = cnome, 
		Senha = csenha, 
		Tipo = ctipo, 
		Email = cemail, 
		Telefone = ctelefone 
	where IdUsuario = id;
end;/

create or replace procedure DeletarUsuario(id Usuarios.IdUsuario%type) is
begin
	delete from Usuarios where IdUsuario = id;
end;/

--Serviço

create or replace procedure AtualizarServico (
	id Servicos.IdServico%type, 
	cnome Servicos.Nome%type, 
	cpreco Servicos.Preco%type, 
	cdescricao Servicos.Descricao%type 
) is
begin
     update Servicos set Nome=cnome, Preco=cpreco, Descricao=cdescricao where idServico = id;
end;/

create or replace procedure InserirServico (
	cnome Servicos.Nome%type, 
	cpreco Servicos.Preco%type, 
	cdescricao Servicos.Descricao%type 
) is
begin
     insert into Servicos (IdServico, Nome, Preco, Descricao) 
	 values (Seq_Servicos.nextval, cnome, cpreco, cdescricao);
end;/

create or replace procedure RemoverServico (id Servicos.IdServico%type) is
begin
     delete from Servicos where idServico = id;
end;/

--Produto

create or replace procedure AtualizarProduto (
	id Produtos.IdProduto%type, 
	cnome Produtos.Nome%type, 
	cpreco Produtos.Preco%type, 
	cdescricao Produtos.Descricao%type, 
	cIdImagem Produtos.IdImagem%type
) is
begin
     update Produtos set Nome=cnome, Preco=cpreco, Descricao=cdescricao, IdImagem = cIdImagem where IdProduto = id;
end;/

create or replace procedure InserirProduto (
	cnome Produtos.Nome%type, 
	cpreco Produtos.Preco%type, 
	cdescricao Produtos.Descricao%type,
	cIdImagem Produtos.IdImagem%type
) is
begin
     insert into Produtos(IdProduto, Nome, Preco, Descricao, IdImagem) 
	 values(Seq_Produtos.nextval, cnome, cpreco, cdescricao, cIdImagem);
end;/

create or replace procedure RemoverProduto (id Produtos.IdProduto%type) IS
begin
     delete from Produtos where IdProduto = id;
end;/

--Imagem

create or replace procedure InserirImagem (ccaminho Imagens.Caminho%type) is
begin
	insert into Imagens(IdImagem, Caminho) values(Seq_Imagens.nextval, ccaminho);
end;/

create or replace procedure AtualizarImagem (id Imagens.IdImagem%type, ccaminho Imagem.Caminho%type) is
begin
	update Imagens set Caminho = ccaminho where IdImagem = id;
end;/

create or replace procedure RemoverImagem (id Imagens.IdImagem%type) is
begin
	delete from Imagens where IdImagem = id;
end;/

--Inserts:

execute InserirUsuario('Admin', 'Admin', '1', 'adsreges@gmail.com', '');