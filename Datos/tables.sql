--Borro las tablas para volver a crearlas.
DROP TABLE IF EXISTS usuario;		--BE
DROP TABLE IF EXISTS tipo_usuario;	--BE
DROP TABLE IF EXISTS solic_onboarding;	--BE
DROP TABLE IF EXISTS onboarding_estados; --BE
DROP TABLE IF EXISTS cliente;	--BE
DROP TABLE IF EXISTS moneda; --BE
DROP TABLE IF EXISTS cliente_agenda; --BE
DROP TABLE IF EXISTS api_keys;
DROP TABLE IF EXISTS billetera; --BE
DROP TABLE IF EXISTS bitacora; --BE
DROP TABLE IF EXISTS solic_operacion; --BE
DROP TABLE IF EXISTS tipo_solic_op; --BE
DROP TABLE IF EXISTS solic_estados; --BE
DROP TABLE IF EXISTS transferencias; --BE
DROP TABLE IF EXISTS orden_venta; --BE
DROP TABLE IF EXISTS orden_compra --BE
DROP TABLE IF EXISTS orden_estado; --BE
DROP TABLE IF EXISTS comisiones; --BE
DROP TABLE IF EXISTS permiso; --BE
DROP TABLE IF EXISTS rol_permiso; --BE
DROP TABLE IF EXISTS usuario_permiso; --BE

--Tabla de usuarios.
create table usuario(
	idusuario bigint identity(1,1) primary key,
	nombre varchar(100),
	apellido varchar(100),
	alias varchar(50),
	email varchar(100),
	tipo_usuario int,
	pwd varchar(100) NOT NULL
);

--Tipo de usuario cliente, empleado.
create table tipo_usuario(
	tipo_usuario int identity(1,1) primary key,
	descrip varchar(50)
);
insert into tipo_usuario values('Cliente');
insert into tipo_usuario values('Empleado');

--Tabla de permisos
create table permiso
(
	idpermiso int identity(1,1) primary key,
	nombre varchar(150),
	es_rol bit
);

insert into permiso(nombre,es_rol) values('Usuario',0);
insert into permiso(nombre,es_rol) values('Cliente',1);
insert into permiso(nombre,es_rol) values('Empleado',0);
insert into permiso(nombre,es_rol) values('Operaciones',1);
insert into permiso(nombre,es_rol) values('Marketing',1);
insert into permiso(nombre,es_rol) values('IT',1);

create table rol_permiso
(
	idrol int,
	idpermiso int
);

insert into rol_permiso(idrol,idpermiso) values(NULL,1);
insert into rol_permiso(idrol,idpermiso) values(1,2);
insert into rol_permiso(idrol,idpermiso) values(1,3);
insert into rol_permiso(idrol,idpermiso) values(3,4);
insert into rol_permiso(idrol,idpermiso) values(3,5);
insert into rol_permiso(idrol,idpermiso) values(3,6);

--Tabla que relaciona permisos con usuarios.
create table usuario_permiso
(
	idusuario bigint,
	idpermiso int
);

--Validaciones de identidad, se ingresa documentacion y estado.
create table solic_onboarding(
	idsolic bigint identity(1,1) primary key,
	fecSolic datetime,
	idusuario bigint,
	img_frente varchar(100),
	img_dorso varchar(100),
	img_selfie varchar(100),
	solic_estado int,
	fecProceso datetime,
	opreador bigint
);

--Estados de validacion de identidad.
create table onboarding_estados(
	idestado int identity(1,1) primary key,
	descrip varchar(50)
);

insert into onboarding_estados values('Valido');
insert into onboarding_estados values('Rechazado');
insert into onboarding_estados values('Ilegible');

--Informacion personal del cliente pedido del BCRA.
create table cliente(
	idcliente bigint identity(1,1) primary key,
	idusuario bigint,
	nombre varchar(100),
	apellido varchar(100),
	numero varchar(100),
	fec_nac varchar(20),
	num_tramite varchar(50),
	domicilio varchar(100),
	email varchar(100),
	telefono varchar(100),
	idonboarding bigint,
);

--Tabla de monedas.
create table moneda(
	cod varchar(10) primary key,
	descrip varchar(100)
);

insert into moneda values('ARS','Pesos argentinos');
insert into moneda values('BTC','Bitcoin');
insert into moneda values('LTC','Litecoin');
insert into moneda values('DOG','Dodge');

--Tabla de contactos.
create table clienta_agenda(
	idcontacto bigint identity(1,1) primary key,
	idcliente bigint,
	moneda varchar(10) NOT NULL,
	valor varchar(100)
);

--Api keys.
create table api_keys(
	ambiente varchar(10),
	btc varchar(50),
	ltc varchar(50),
	dog varchar(50)
);

insert into api_keys(ambiente,btc,ltc,dog) values('TEST','70d1-1c21-b76c-fb00','34e3-4277-7289-6fd6','7c02-9d46-b312-25ef');
insert into api_keys(ambiente,btc,ltc,dog) values('PROD','6195-52ea-f8fb-dfc1','d685-3e52-8b59-abe6','3894-9455-f527-4054');

--Billetera
create table billetera(
	idwallet bigint identity(1,1) primary key,
	idcliente bigint,
	moneda varchar(10),
	direccion varchar(30),
	fecCreacion datetime,
	saldo float
);

--Tabla de solicitudes de retiro de dinero.
create table solic_operacion
(
	idoperacion bigint identity(1,1) primary key,
	idusuario bigint,
	tipo_solic int,
	idwallet bigint,
	valor float,
	cbu varchar(50),
	operador bigint,
	estado_solic int,
	fecRegistro datetime,
	fecProceso datetime
);

--Tabla de tipo de operaciones
create table tipo_solic_op(
	idtiposolic bigint identity(1,1) primary key,
	descrip varchar(100)
);

insert into tipo_solic_op(descrip) values('Ingreso de saldo');
insert into tipo_solic_op(descrip) values('Retiro de saldo');

--Estado de solicitudes
create table solic_estados(
	idestado bigint identity(1,1) primary key,
	descrip varchar(100)
);

insert into solic_estado(descrip) values('Aprobada');
insert into solic_estado(descrip) values('Rechazada');

--Tabla de transferencias.
create table transferencias(
	idtransf bigint identity(1,1) primary key,
	fecProc datetime,
	idusuario bigint,
	origen bigint,
	destino bigint,
	valor float,
	moneda varchar(10),
	idorden bigint
);

--Tabla de comisiones.
create table comisiones(
	idcobro  bigint identity(1,1) primary key,
	operacion varchar(5),
	referencia bigint,
	moneda varchar(10),
	valor bigint,
	fecCobro datetime
);

--Tabla de ordenes de venta.
create table orden_venta(
	idorden  bigint identity(1,1) primary key,
	vendedor bigint,
	cantidad int,
	moneda varchar(10),
	precio float
);

--Tabla de tipo de ordenes.
create table orden_estado(
	ídtipo int identity(1,1) primary key,
	descrip varchar(100)
);

insert into orden_estado(descrip) values('Disponible');
insert into orden_estado(descrip) values('Vendida');
insert into orden_estado(descrip) values('Expirada');

--Tabla de ordenes de compra.
create table orden_compra(
	idcompra int identity(1,1) primary key,
	idorden bigint,
	fecOperacion datetime,
	comprador bigint,
	moneda varchar(10),
	cantidad int,
	precio float
);

--Bitacora.
CREATE TABLE bitacora
(
	id bigint not NULL identity(1,1) PRIMARY KEY,
	idusuario bigint NULL,
	[type] bigint NULL,
	fec_log date NULL,
	payload TEXT not NULL	
);

/*
/*	VISTAS */
DROP VIEW IF EXISTS v_operaciones;

--Vista de operaciones.
create view v_operaciones
as(
	select  concat('ING',si.fecProceso) as idoperacion,
			si.fecProceso,
			si.idusuario,
			si.valor,
			si.origen,
			'ING' as tipo_operacion 
	from solic_ingreso as si
	union all
	select  concat('RET',sr.fecProceso) as idoperacion,
			sr.fecProceso,
			sr.idusuario,
			sr.valor,
			sr.idwallet,
			'RET' as tipo_operacion
	from solic_retiro as sr
	union all
	select concat('CONCAT',t.idtransf) as idoperacion,
			t.fecProc as fecProceso,
			t.idusuario,
			t.valor,
			t.origen, 'TRANSF' as tipo_operacion
	from transferencias as t
);*/

/*
with recursivo as (
                        select sp2.idrol, sp2.idpermiso  from rol_permiso SP2
                        where sp2.idrol is NULL --acá se va variando la familia que busco
                        UNION ALL 
                        select sp.idrol, sp.idpermiso from rol_permiso sp 
                        inner join recursivo r on r.idpermiso= sp.idrol
                        )
                        select r.idrol,r.idpermiso,p.idpermiso,p.nombre, p.es_rol
                        from recursivo r 
                        inner join permiso p on r.idpermiso = p.idpermiso
*/

