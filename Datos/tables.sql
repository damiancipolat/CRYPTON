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
DROP TABLE IF EXISTS admin_backup; --BE
DROP TABLE IF EXISTS dvv; --BE
DROP TABLE IF EXISTS idiomas; --BE
DROP TABLE IF EXISTS idioma_palabras; --BE

--Tabla de usuarios.
create table usuario(
	idusuario bigint identity(1,1) primary key,
	nombre varchar(100),
	apellido varchar(100),
	alias varchar(50),
	email varchar(100),
	tipo_usuario int,
	pwd varchar(100) NOT NULL,
	[hash] text
);

insert into usuario(nombre,apellido,alias,email,tipo_usuario,pwd,[hash]) values('KIKI2','Cipolat','damxipo','damian.cipolat@gmail.com',1,'1234','trytrytrytryertfdgsdfgfd4354354353453443543');
select * from usuario;
update usuario set [hash]='545454545454',pwd='81dc9bdb52d04dc20036dbd8313ed055' where idusuario=1

--Tipo de usuario cliente, empleado.
create table tipo_usuario(
	tipo_usuario int identity(1,1) primary key,
	descrip varchar(50)
);
insert into tipo_usuario values('Cliente');
insert into tipo_usuario values('Empleado');

---Tabla con digito verificadores verticales.
create table dvv(
	tabla varchar(100) primary key,
	[hash] text,
	fecUpdate datetime
);

insert into dvv(tabla,[hash],fecUpdate) values('usuario','',GETDATE());
select * from dvv;

--Tabla de permisos
create table permiso
(
	idpermiso int identity(1,1) primary key,
	nombre varchar(150),
	es_patente bit
);

insert into permiso(nombre,es_patente) values('Usuario',0);
insert into permiso(nombre,es_patente) values('Cliente',1);
insert into permiso(nombre,es_patente) values('Empleado',0);
insert into permiso(nombre,es_patente) values('Operaciones',1);
insert into permiso(nombre,es_patente) values('Marketing',1);
insert into permiso(nombre,es_patente) values('IT',1);

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

insert into usuario_permiso values(1,4);
insert into usuario_permiso values(1,5);
insert into usuario_permiso values(1,6);

select * from permiso;
select * from rol_permiso;
select * from usuario_permiso

--Tabla de registro de backups.
create table admin_backup
(
	idbackup int identity(1,1) primary key,
	idusuario bigint,
	[path] varchar(100),
	fecRec datetime,
	[type] varchar(100)
);

select * from admin_backup;

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

insert into solic_estados(descrip) values('Aprobada');
insert into solic_estados(descrip) values('Rechazada');

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

select * from bitacora;

--Tabla de idiomas.
create table idiomas
(
	code varchar(50) primary key,
	descripcion varchar(100)
);

insert into idiomas(code,descripcion) values('ES','Español');
insert into idiomas(code,descripcion) values('ENG','English');

--Tabla de palabras por idioma.
create table idioma_palabras
(
	idpalabra int identity(1,1) primary key,
	code varchar(50),
	clave varchar(50),
	valor varchar(50)
);

insert into idioma_palabras(code,clave,valor) values('ES','WELCOME','Bienvenido');
insert into idioma_palabras(code,clave,valor) values('ES','HELLO','Hola');
insert into idioma_palabras(code,clave,valor) values('ES','LOGIN','Iniciar sesion');
insert into idioma_palabras(code,clave,valor) values('ES','LANG_CHOOSE_TITLE','Seleccionar idioma');
insert into idioma_palabras(code,clave,valor) values('ES','BUTTON_OK','Aceptar');
insert into idioma_palabras(code,clave,valor) values('ES','BUTTON_CANCEL','Cancelar');
insert into idioma_palabras(code,clave,valor) values('ES','LOGIN_TITLE_1','Iniciar sesión');
insert into idioma_palabras(code,clave,valor) values('ES','LOGIN_TITLE_EMAIL','Escriba su email');
insert into idioma_palabras(code,clave,valor) values('ES','LOGIN_TITLE_PASSWORD','Escriba su password');
insert into idioma_palabras(code,clave,valor) values('ES','LOGIN_BTN_INGRESAR','Ingresar');
insert into idioma_palabras(code,clave,valor) values('ES','LOGIN_BTN_CANCEL','Cancelar');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_SPLASH_TITLE','Haga click para ingresar al sistema.');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_BTN_LOGIN','Ingresar');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_CHANGE_LANGUAGE','Cambiar idioma');
insert into idioma_palabras(code,clave,valor) values('ES','SINGUP_TITLE','Registrar nuevo usuario');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_NAME','Escriba su nombre:');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_SURNAME','Escriba su apellido:');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_ALIAS','Escriba su alias:');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_EMAIL','Escriba su email:');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_PWD','Escriba su password:');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_OK','Aceptar');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_CANCEL','Cancelar');
insert into idioma_palabras(code,clave,valor) values('ES','LOGIN_INPUT_ERROR','Email y contraseña requeridos!');
insert into idioma_palabras(code,clave,valor) values('ES','LOGIN_INPUT_ERROR_TITLE','Aviso');
insert into idioma_palabras(code,clave,valor) values('ES','LOGIN_SERVICE_ERROR','Usuario o contraseña incorrectos!');
insert into idioma_palabras(code,clave,valor) values('ES','REGISTER_INPUT_ERROR','Valide los datos requeridos para registrar!');
insert into idioma_palabras(code,clave,valor) values('ES','REGISTER_INPUT_EMAIL_ERROR','Formato de email erroneo!');
insert into idioma_palabras(code,clave,valor) values('ES','REGISTER_INPUT_ERROR_TITLE','Aviso');
insert into idioma_palabras(code,clave,valor) values('ES','REGISTER_INPUT_SUCCESS','Usuario creado con exito!');


truncate table usuario;
truncate table dvv;

select * from idiomas;
select * from idioma_palabras;
select * from usuario;
select * from dvv;
select * from usuario_permiso;


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
);

with recursivo as(
               select sp2.idrol, sp2.idpermiso from rol_permiso SP2
               where sp2.idrol is NULL
               UNION ALL
               select sp.idrol, sp.idpermiso from rol_permiso sp
               inner join recursivo r on r.idpermiso = sp.idrol
            ) 
            select r.idrol,r.idpermiso,p.idpermiso as id,p.nombre, p.es_patente
            from recursivo r
            inner join permiso p on r.idpermiso = p.idpermiso
            inner join usuario_permiso up on up.idpermiso = p.idpermiso
            where up.idusuario = 1;

select * from usuario_permiso
select * from usuario

insert into usuario_permiso(idusuario,idpermiso) values(2,2)
*/


--BACKUP DATABASE Crypton TO DISK = 'c:\SQLCrypton.bak' WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Full Backup of SQLTestDB';
--use master;RESTORE DATABASE Crypton FROM DISK = 'C:\crypton_backup_bd_20210503054138.bak' WITH  FILE = 1,  NOUNLOAD,  STATS = 5;
--select * from admin_backup

select * from usuario
insert into usuario(nombre,apellido,alias,email,tipo_usuario,pwd,user) 
values('damian','cipolat','alf','alf@gmail.com',1,'9e94b15ed312fa42232fd87a55db0d39','402ac28ffb19680ff94a7420200d20c9');

select * from usuario
select * from dvv;

truncate table usuario;
truncate table dvh