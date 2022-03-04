CREATE TABLE permiso_new(
	nombre varchar(100) NULL,
	id int IDENTITY(1,1) NOT NULL,
	permiso varchar(50) NULL
);

CREATE TABLE permiso_permiso_new(
	id_permiso_padre int NULL,
	id_permiso_hijo int NULL
);

CREATE TABLE [dbo].[usuarios_permisos](
	id_usuario int not null,
	id_permiso int not null
);

select * from permiso_new;

--Patentes
insert into permiso_new(nombre,permiso) values('Volar','Volar');
insert into permiso_new(nombre,permiso) values('Comer','Comer');
insert into permiso_new(nombre,permiso) values('Jugar','Jugar');
insert into permiso_new(nombre,permiso) values('Saltar','Saltar');
insert into permiso_new(nombre,permiso) values('Estudiar','Estudiar');

--Familias
insert into permiso_new(nombre) values('F1');
insert into permiso_new(nombre) values('F2');
insert into permiso_new(nombre) values('F3');

--Armo un arbol.

--F1
insert into permiso_permiso_new values(6,1);
insert into permiso_permiso_new values(6,2);
insert into permiso_permiso_new values(6,3);
insert into permiso_permiso_new values(6,7);

--F2
insert into permiso_permiso_new values(7,10);
insert into permiso_permiso_new values(7,12);
insert into permiso_permiso_new values(7,13);

select * from permiso_new
select * from permiso_permiso_new


