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
	constraint CK_Tipo_01 check (Tipo = '0' or Tipo = '1')
	
);

create sequence Seq_Usuarios increment by 1 start with 1; 

create or replace procedure InserirUsuario
(cnome Usuarios.Nome%type, csenha Usuarios.Senha%type, ctipo Usuarios.Tipo%type, cemail Usuarios.Email%type, ctelefone Usuarios.Telefone%type) is
begin 
	insert into Usuarios(IdUsuario, Nome, Senha, Tipo, Email, Telefone) 
		values(Seq_Usuarios.nextval, cnome, csenha, ctipo, cemail, ctelefone);
end;

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
	update Usuarios set Nome = cnome, Senha = csenha, Tipo = ctipo, Email = cemail, Telefone = ctelefone where IdUsuario = id;
end;

create or replace procedure DeletarUsuario(id Usuarios.IdUsuario%type) is
begin
	delete from Usuarios where IdUsuario = id;
end;

--
CREATE TABLE Servico(

idServico INTEGER not null,
nomeServico VARCHAR(30) not null,
precoServico NUMBER not null,
descricaoServico clob not null
);
_______________________________________________________________________________

PROCEDURE atualizaServico (sid Servico.ID%type, snome Servico.Nome%type, spreco Servico%type, sdescricao Servico.Descricao%type ) IS

BEGIN
     update Servico set Nome=snome, Preco=spreco, Descricao=sdescricao WHERE id = sid;
END;/

PROCEDURE insereServico (snome Servico.Nome%type, spreco Servico%type, sdescricao Servico.Descricao%type ) IS
BEGIN
     insert into Servico(idServico, nomeServico, precoServico, descricaoServico) values(Seq_Servico.nextval, snome, spreco, sdescricao);
END;/

PROCEDURE removeServico (idServico Servico.ID%type) IS

BEGIN
     delete from Servico where id = idServico;
END;/
_______________________________________________________________________________

CREATE SEQUENCE seq_servico increment by 1 start with 1
