--Borro las tablas para volver a crearlas.
DROP TABLE IF EXISTS usuario;
DROP TABLE IF EXISTS tipo_usuario;
DROP TABLE IF EXISTS solic_onboarding;
DROP TABLE IF EXISTS onboarding_estados;
DROP TABLE IF EXISTS cliente;
DROP TABLE IF EXISTS moneda;
DROP TABLE IF EXISTS empleado;
DROP TABLE IF EXISTS cliente_agenda;
DROP TABLE IF EXISTS api_keys;
DROP TABLE IF EXISTS cuentas;
DROP TABLE IF EXISTS cuenta_estado;
DROP TABLE IF EXISTS billetera;
DROP TABLE IF EXISTS bitacora;
DROP TABLE IF EXISTS solic_operacion;
DROP TABLE IF EXISTS tipo_solic_op;
DROP TABLE IF EXISTS solic_estados;
DROP TABLE IF EXISTS transferencias;
DROP TABLE IF EXISTS orden_venta;
DROP TABLE IF EXISTS orden_compra;
DROP TABLE IF EXISTS orden_estado;
DROP TABLE IF EXISTS comisiones;
DROP TABLE IF EXISTS comisiones_valor;
DROP TABLE IF EXISTS permiso;
DROP TABLE IF EXISTS rol_permiso;
DROP TABLE IF EXISTS usuario_permiso;
DROP TABLE IF EXISTS conversiones;
DROP TABLE IF EXISTS admin_backup;
DROP TABLE IF EXISTS dvv;
DROP TABLE IF EXISTS idiomas;
DROP TABLE IF EXISTS idioma_palabras;

--Tabla de usuarios.
create table usuario(
	idusuario bigint identity(1,1) primary key,
	nombre varchar(100),
	apellido varchar(100),
	alias varchar(50),
	email varchar(100),
	tipo_usuario int,
	pwd varchar(100) NOT NULL,
	[hash] text,
	deleted datetime
);

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
	fecUpdate datetime,
	deleted datetime
);

insert into dvv(tabla,[hash],fecUpdate) values('usuario','',GETDATE());

--Tabla de permisos
create table permiso
(	
	codpermiso varchar(20) primary key,
	nombre varchar(150),
	es_patente bit,
	deleted datetime
);

--Esquema de roles
insert into permiso(codpermiso,nombre,es_patente) values('R001','Usuario',0);
insert into permiso(codpermiso,nombre,es_patente) values('R003','Empleado',0);
insert into permiso(codpermiso,nombre,es_patente) values('ADM001','Operaciones',0);
insert into permiso(codpermiso,nombre,es_patente) values('OP001','Ingresos',1);
insert into permiso(codpermiso,nombre,es_patente) values('OP002','Retiros',1);
insert into permiso(codpermiso,nombre,es_patente) values('ADM002','Marketing',1);
insert into permiso(codpermiso,nombre,es_patente) values('ADM003','IT',0);
insert into permiso(codpermiso,nombre,es_patente) values('IT0001','Alta usuarios',1);
insert into permiso(codpermiso,nombre,es_patente) values('IT0002','Gestion usuarios',1);
insert into permiso(codpermiso,nombre,es_patente) values('IT0003','Gestion idiomas',1);
insert into permiso(codpermiso,nombre,es_patente) values('R002','Cliente',0);
insert into permiso(codpermiso,nombre,es_patente) values('USR001','Extraer',1);
insert into permiso(codpermiso,nombre,es_patente) values('USR002','Ingresar',1);
insert into permiso(codpermiso,nombre,es_patente) values('USR003','Comprar',1);
insert into permiso(codpermiso,nombre,es_patente) values('USR004','Vender',1);
insert into permiso(codpermiso,nombre,es_patente) values('USR005','Buscar',1);

create table rol_permiso
(
	codrol varchar(20),
	codpermiso varchar(20),
	idusuario bigint
);

--Empleado IT
insert into rol_permiso(codrol,codpermiso,idusuario) values(NULL,'R001',1);
insert into rol_permiso(codrol,codpermiso,idusuario) values('R001','R003',1);
insert into rol_permiso(codrol,codpermiso,idusuario) values('R003','ADM003',1);
insert into rol_permiso(codrol,codpermiso,idusuario) values('ADM003','IT0001',1);
insert into rol_permiso(codrol,codpermiso,idusuario) values('ADM003','IT0002',1);
insert into rol_permiso(codrol,codpermiso,idusuario) values('ADM003','IT0003',1);
insert into rol_permiso(codrol,codpermiso,idusuario) values('R003','ADM001',1);
insert into rol_permiso(codrol,codpermiso,idusuario) values('ADM001','OP001',1);
insert into rol_permiso(codrol,codpermiso,idusuario) values('ADM001','OP002',1);
insert into rol_permiso(codrol,codpermiso,idusuario) values('R003','ADM002',1);

--Empleado Operaciones
insert into rol_permiso(codrol,codpermiso,idusuario) values(NULL,'R001',3);
insert into rol_permiso(codrol,codpermiso,idusuario) values('R001','R003',3);
insert into rol_permiso(codrol,codpermiso,idusuario) values('R003','ADM001',3);
insert into rol_permiso(codrol,codpermiso,idusuario) values('ADM001','OP001',3);
insert into rol_permiso(codrol,codpermiso,idusuario) values('ADM001','OP002',3);

select * from usuario
select * from rol_permiso
select * from permiso

insert into rol_permiso(codrol,codpermiso,idusuario) values(NULL,'R001',2);

--Tabla que relaciona permisos con usuarios.
create table usuario_permiso
(
	idusuario bigint,
	codpermiso varchar(20)
);

--Tabla de registro de backups.
create table admin_backup
(
	idbackup int identity(1,1) primary key,
	idusuario bigint,
	[path] varchar(100),
	fecRec datetime,
	[type] varchar(100),
	deleted datetime
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
	operador bigint,
	deleted datetime
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
	tipoDoc varchar(10),
	numero varchar(100),
	fec_nac datetime,
	num_tramite varchar(50),
	domicilio varchar(100),
	telefono varchar(100),
	valido varchar(1),
	deleted datetime
);

create table empleado(
	idempleado bigint identity(1,1) primary key,
	idusuario bigint,
	legajo varchar(100),
	deleted datetime
);

--Tabla de monedas.
create table moneda(
	cod varchar(10) primary key,
	descrip varchar(100),
	deleted datetime
);

insert into moneda(cod,descrip) values('ARS','Pesos argentinos');
insert into moneda(cod,descrip) values('BTC','Bitcoin');
insert into moneda(cod,descrip) values('LTC','Litecoin');
insert into moneda(cod,descrip) values('DOG','Dodge');

--Tabla de conversiones de cripto a ARS.
create table conversiones(
	idconversion bigint identity(1,1) primary key,
	codCripto varchar(10),
	cantCripto float,
	valorUSD float,
	deleted datetime
);

insert into conversiones(codCripto,cantCripto,valorUSD) values('BTC',1,33655.80);
insert into conversiones(codCripto,cantCripto,valorUSD) values('LTC',1,132.82);
insert into conversiones(codCripto,cantCripto,valorUSD) values('DOG',1,0.216820);
insert into conversiones(codCripto,cantCripto,valorUSD) values('ARS',1,0.010);
select * from conversiones

--Tabla de contactos.
create table cliente_agenda(
	idcontacto bigint identity(1,1) primary key,
	idcliente bigint,
	moneda varchar(10) NOT NULL,
	valor varchar(100),
	deleted datetime
);

--Api keys.
create table api_keys(
	ambiente varchar(10),
	btc varchar(50),
	ltc varchar(50),
	dog varchar(50)
);

insert into api_keys(ambiente,btc,ltc,dog) values('TEST_1','70d1-1c21-b76c-fb00','34e3-4277-7289-6fd6','7c02-9d46-b312-25ef');
insert into api_keys(ambiente,btc,ltc,dog) values('TEST_2','8e15-55be-cccd-b33c','7ebe-8f45-4490-37d4','cece-b117-15ca-e13d');
insert into api_keys(ambiente,btc,ltc,dog) values('PROD','6195-52ea-f8fb-dfc1','b311-ecc3-0e70-3c50','611f-3c58-e739-3378');

--Cuentas
create table cuentas
(
	idcuenta bigint identity(1,1) primary key,
	cliente bigint,
	fecAlta datetime,
	estado int
);

create table cuenta_estado
(
	id bigint identity(1,1) primary key,
	descrip varchar(100)
);

insert into cuenta_estado(descrip) values('Activa');
insert into cuenta_estado(descrip) values('Inactiva');
insert into cuenta_estado(descrip) values('Bloqueada');

--Billetera
create table billetera(
	idwallet bigint identity(1,1) primary key,
	idcliente bigint,
	idcuenta bigint,
	moneda varchar(10),
	direccion varchar(50),
	fecCreacion datetime,
	saldo float,
	deleted datetime
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
	fecProceso datetime,
	deleted datetime
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
	idcliente bigint,
	origen bigint,
	destino bigint,
	valor float,
	moneda varchar(10),
	idorden bigint,
	deleted datetime
);

--Tabla de comisiones.
create table comisiones(
	idcobro  bigint identity(1,1) primary key,
	operacion bigint,
	referencia bigint,
	moneda varchar(10),
	valor bigint,
	fecCobro datetime,	
	deleted datetime
);

--Tabla de comisiones - valor
create table comision_operacion_valor
(
	idope bigint identity(1,1) primary key,
	descrip varchar(100),
	valor float
);

insert into comision_operacion_valor(descrip,valor) values('Compra',0.5);
insert into comision_operacion_valor(descrip,valor) values('Venta',0.5);
insert into comision_operacion_valor(descrip,valor) values('Extraccion',2.5);

--Tabla de ordenes de venta.
create table orden_venta(
	idorden  bigint identity(1,1) primary key,
	vendedor bigint,
	cantidad float,
	ofrece varchar(10),
	pide varchar(10),
	precio float,
	fecCreacion datetime,
	fecFin datetime,
	ordenEstado int,
	deleted datetime
);
select * from orden_venta where  ofrece='BTC' and pide='ARS' and ordenEstado=1;
select * from usuario


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
	precio float,
	deleted datetime
);

--Bitacora. 
CREATE TABLE bitacora
(
	id bigint not NULL identity(1,1) PRIMARY KEY,
	idusuario bigint NULL,
	[type] bigint NULL,
	fec_log datetime NULL,
	payload TEXT not NULL	
);

--Tabla de idiomas.
create table idiomas
(
	code varchar(50) primary key,
	descripcion varchar(100),
	deleted datetime
);

insert into idiomas(code,descripcion) values('ES','Español');
insert into idiomas(code,descripcion) values('ENG','English');

--Tabla de palabras por idioma.
create table idioma_palabras
(
	idpalabra int identity(1,1) primary key,
	code varchar(50),
	clave varchar(50),
	valor varchar(100),
	deleted datetime
);

--ESPAÑOL
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
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_SPLASH_ACTIVITY','Haga click para realizar una operación.');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_BTN_LOGIN','Ingresar');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_CHANGE_LANGUAGE','Cambiar idioma');
insert into idioma_palabras(code,clave,valor) values('ES','SINGUP_DESCRIP','Completar para crear usuario empleado.');
insert into idioma_palabras(code,clave,valor) values('ES','SINGUP_TITLE','Registrar nuevo usuario');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_LEGACY','Legajo de empleado:');
insert into idioma_palabras(code,clave,valor) values('ES','SINGUP_DESCRIPTION','Completa estos datos para poder crear tu cuenta:');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_NAME','Escriba su nombre:');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_SURNAME','Escriba su apellido:');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_ALIAS','Escriba su alias:');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_EMAIL','Escriba su email:');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_PWD','Escriba su password:');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_OK','Aceptar');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_CANCEL','Cancelar');
insert into idioma_palabras(code,clave,valor) values('ES','DOCUMENT_NUMBER','DNI:');
insert into idioma_palabras(code,clave,valor) values('ES','BIRTH_DATE','Fecha de nacimiento:');
insert into idioma_palabras(code,clave,valor) values('ES','ORDER_NUMER','Número de tramite:');
insert into idioma_palabras(code,clave,valor) values('ES','ADDRESS','Dirección:');
insert into idioma_palabras(code,clave,valor) values('ES','PHONE_NUMBER','Número de telefono:');
insert into idioma_palabras(code,clave,valor) values('ES','REGISTER_INPUT_ERROR','Valide los datos requeridos para registrar!');
insert into idioma_palabras(code,clave,valor) values('ES','REGISTER_INPUT_EMAIL_ERROR','Formato de email erroneo!');
insert into idioma_palabras(code,clave,valor) values('ES','REGISTER_INPUT_ERROR_TITLE','Aviso');
insert into idioma_palabras(code,clave,valor) values('ES','REGISTER_INPUT_SUCCESS','Usuario creado con exito!');
insert into idioma_palabras(code,clave,valor) values('ES','LOGIN_INPUT_ERROR','Email y contraseña requeridos!');
insert into idioma_palabras(code,clave,valor) values('ES','LOGIN_INPUT_ERROR_TITLE','Aviso');
insert into idioma_palabras(code,clave,valor) values('ES','LOGIN_SERVICE_ERROR','Usuario o contraseña incorrectos!');
insert into idioma_palabras(code,clave,valor) values('ES','INTEGRITY_USERS_NOT_FOUND','No hay usuarios para validar integridad!');
insert into idioma_palabras(code,clave,valor) values('ES','INTEGRITY_USERS_CORRUPT','Integridad corrompida bd usuarios');
insert into idioma_palabras(code,clave,valor) values('ES','INTEGRITY_USERS_ENTITY_FAIL','Integridad de tabla de usuarios comprometida');
insert into idioma_palabras(code,clave,valor) values('ES','INTEGRITY_ERROR','ERROR - integridad comprometida');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_START','Inicio');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_LOGIN','Iniciar sesión');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_SIGNUP','Registrarse');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_SIGNOUT','Cerrar sesión');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_EXIT','Salir');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_OPERATE','Operar');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_BUY','Comprar');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_SELL','Vender');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_SEARCH','Buscar');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_DEPOSIT','Ingresar saldo');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_EXTRACT','Retirar saldo');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_IT','IT');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_BACKUP','Backup');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_PERMISSION','Permisos');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_USER','Usuarios');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_LANGUAGE','Idioma');
insert into idioma_palabras(code,clave,valor) values('ES','LANGUAGE_CHANGE_OK','Idioma cargado con exito');
insert into idioma_palabras(code,clave,valor) values('ES','LANGUAGE_CHANGE_ERROR','Error al cambiar el lenguaje');
insert into idioma_palabras(code,clave,valor) values('ES','YOUR_USER_LABEL','Tú usuario:');
insert into idioma_palabras(code,clave,valor) values('ES','YOUR_DOCUMENTS','Tú documentación:');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_EMAIL_REPEATED','Este email ya se encuentra en uso!');
insert into idioma_palabras(code,clave,valor) values('ES','SIGNUP_DNI_REPEATED','El número de documento ya se encuentra en uso!');
insert into idioma_palabras(code,clave,valor) values('ES','BAD_DNI','Formato de DNI incorrecto.');
insert into idioma_palabras(code,clave,valor) values('ES','BAD_PHONE','Formato de telefono incorrecto.');
insert into idioma_palabras(code,clave,valor) values('ES','BAD_TRAMITE','Formato número de tramite incorrecto.');
insert into idioma_palabras(code,clave,valor) values('ES','YOUR_WALLETS_LABEL','Tús billeteras...');
insert into idioma_palabras(code,clave,valor) values('ES','YOUR_WALLETS_DESCRIPT','Haz click sobre una billetera para ver su info.');
insert into idioma_palabras(code,clave,valor) values('ES','ARS_LABEL','Pesos');
insert into idioma_palabras(code,clave,valor) values('ES','DOG_LABEL','Doge');
insert into idioma_palabras(code,clave,valor) values('ES','LTC_LABEL','Litecoin');
insert into idioma_palabras(code,clave,valor) values('ES','BTC_LABEL','Bitecoin');
insert into idioma_palabras(code,clave,valor) values('ES','PERMISSION_TITLE','Permisos');
insert into idioma_palabras(code,clave,valor) values('ES','PERMISSION_LABEL','En esta seccion se puede agregar o quitar permisos a usuarios.');
insert into idioma_palabras(code,clave,valor) values('ES','PERMISSION_ABM','Lista de permisos:');
insert into idioma_palabras(code,clave,valor) values('ES','BTN_DEL_PERMISSION','Borrar');
insert into idioma_palabras(code,clave,valor) values('ES','BTN_CLOSE_PERMISSION','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','BTN_UPDATE_PERMISSION','Actualizar');
insert into idioma_palabras(code,clave,valor) values('ES','BTN_COMPOUND_PERMISSION','Agregar compuesto');
insert into idioma_palabras(code,clave,valor) values('ES','USR_SEARCH','Usuarios');
insert into idioma_palabras(code,clave,valor) values('ES','USR_SEARCH_DESCRIP','En esta seccion puede hacer cambios en caract. de los usuarios.');
insert into idioma_palabras(code,clave,valor) values('ES','USR_SEARCH_LABEL','Escriba nombre/apellido/email o parte:');
insert into idioma_palabras(code,clave,valor) values('ES','USR_SEARCH_BTN','Buscar');
insert into idioma_palabras(code,clave,valor) values('ES','USR_SEARCH_CLOSE','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','USR_PERM_BTN','Editar permisos');
insert into idioma_palabras(code,clave,valor) values('ES','USR_COL_ID','Id');
insert into idioma_palabras(code,clave,valor) values('ES','USR_COL_NAME','Nombre');
insert into idioma_palabras(code,clave,valor) values('ES','USR_COL_SURNAME','Apellido');
insert into idioma_palabras(code,clave,valor) values('ES','USR_COL_EMAIL','Email');
insert into idioma_palabras(code,clave,valor) values('ES','USR_COL_TYPE','Tipo de usuario');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_IT_ADD_USER','Alta de usuario');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_IT_USER_MANAGER','Gestion de usuarios');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_IT_LANG_MANAGER','Gestion de idiomas');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_UI_TITLE','Editor de idiomas');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_UI_DESCRIP','En esta sección podes editar los idiomas.');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_UI_NEW_LANGUAGE','Nuevo');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_UI_REFRESH_LANGUAGE','Actualizar');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_UI_EDIT_LANGUAGE','Editar');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_UI_ADD_LANGUAGE','Agregar');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_UI_DEL_LANGUAGE','Borrar');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_UI_CLOSE_LANGUAGE','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_NEW','Crear nuevo idioma');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_NEW_NAME','Nombre del idioma');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_NEW_OK','Idioma nuevo creado!');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_NEW_REQUIRED','Debe completar un valor para crear el idioma');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_NEW_ERROR','Hubo un error al crear el idioma');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_UPD_REQUIRED','Debe completar un valor');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_COL_CODE','Clave');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_COL_VALUE','Traducción');
insert into idioma_palabras(code,clave,valor) values('ES','UI_LANG_NEW_KEY','Nueva palabra');
insert into idioma_palabras(code,clave,valor) values('ES','UI_LANG_NEW_KEY_DESCRIP','Escriba la nueva palabra que formara parte del lenguaje.');
insert into idioma_palabras(code,clave,valor) values('ES','UI_LANG_NEW_KEY_TITLE','Clave');
insert into idioma_palabras(code,clave,valor) values('ES','UI_LANG_NEW_VALUE_TITLE','Traducción');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_UPD_OK','Lenguage actualizad correctamente');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_DELETE_CONFIRM','Borrar palabra');
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_DELETE_CONFIRM_TITLE','¿Seguro queres borrar esta palabra?');
insert into idioma_palabras(code,clave,valor) values('ES','USR_PERM_DEL_CONFIRM_TITLE','Seguro que desea borrar?');
insert into idioma_palabras(code,clave,valor) values('ES','USR_PERM_DEL_CONFIRM_DESCRIP','Eliga una opción');
insert into idioma_palabras(code,clave,valor) values('ES','USR_PERM_DEL_SUCESS','Permiso borrado!');
insert into idioma_palabras(code,clave,valor) values('ES','USR_PERM_DEL_REQ','Debe seleccionar un permiso');
insert into idioma_palabras(code,clave,valor) values('ES','USR_PERM_ADD_CONFIRM_TITLE','¿Quieres agregar un nuevo permiso?');
insert into idioma_palabras(code,clave,valor) values('ES','USR_PERM_ADD_CONFIRM_DESCRIP','Elija una opción');
insert into idioma_palabras(code,clave,valor) values('ES','USR_PERM_ADD_ERROR','Debes elegir items de ambas listas primero');
insert into idioma_palabras(code,clave,valor) values('ES','USR_PERM_ADD_DENY','No se puede agregar un permiso compuesto a uno atomico');
insert into idioma_palabras(code,clave,valor) values('ES','USR_PERM_COMP_ADD_TITLE','Nuevo permiso compuesto');
insert into idioma_palabras(code,clave,valor) values('ES','USR_PERM_COMP_ADD_DESCRIP','Nuevo permiso compuesto');
insert into idioma_palabras(code,clave,valor) values('ES','SELL_TITLE','Publicar ordén de venta');
insert into idioma_palabras(code,clave,valor) values('ES','SELL_INPUT','Tú ofreces:');
insert into idioma_palabras(code,clave,valor) values('ES','SELL_RECEIVE','Tú recibiras:');
insert into idioma_palabras(code,clave,valor) values('ES','SELL_MONEY','Moneda:');
insert into idioma_palabras(code,clave,valor) values('ES','SELL_CLOSE','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','SELL_PUBLISH','Publicar');
insert into idioma_palabras(code,clave,valor) values('ES','SELL_MONEY_MISMATCH','No puede elegirse la misma moneda!');
insert into idioma_palabras(code,clave,valor) values('ES','SELL_MONEY_EXCED','El valor ingresado no puede superar la cotizacion de mercado de');
insert into idioma_palabras(code,clave,valor) values('ES','SELL_MONEY_FREE_PRICE','Libre');
insert into idioma_palabras(code,clave,valor) values('ES','SELL_MONEY_MARKET_PRICE','Cotización actual');
insert into idioma_palabras(code,clave,valor) values('ES','SELL_MONEY_SUCCESS','Ordén publicada!');
insert into idioma_palabras(code,clave,valor) values('ES','SELL_TAX','Tarifa de impuestos');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_TITLE','Buscador');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_DESCRIP','En esta sección podes buscar por dif ofertas de ventas.');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_BTN_VIEW','Ver');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_BTN_BY','Por');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_BTN_SEARCH','Buscar');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_BTN_CLOSE','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_COL_ID','N°');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_COL_SELLER','Vendedor');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_COL_QTY','Cantidad');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_COL_REQ','Pide');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_COL_PRICE','Precio');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_COL_OFFER','Ofrece');

--ENGLISH
insert into idioma_palabras(code,clave,valor) values('ENG','WELCOME','Welcome');
insert into idioma_palabras(code,clave,valor) values('ENG','HELLO','Hello');
insert into idioma_palabras(code,clave,valor) values('ENG','LOGIN','Login');
insert into idioma_palabras(code,clave,valor) values('ENG','LANG_CHOOSE_TITLE','Choose language');
insert into idioma_palabras(code,clave,valor) values('ENG','BUTTON_OK','OK');
insert into idioma_palabras(code,clave,valor) values('ENG','BUTTON_CANCEL','Cancel');
insert into idioma_palabras(code,clave,valor) values('ENG','LOGIN_TITLE_1','Login');
insert into idioma_palabras(code,clave,valor) values('ENG','LOGIN_TITLE_EMAIL','Write your email');
insert into idioma_palabras(code,clave,valor) values('ENG','LOGIN_TITLE_PASSWORD','Write your password');
insert into idioma_palabras(code,clave,valor) values('ENG','LOGIN_BTN_INGRESAR','Enter');
insert into idioma_palabras(code,clave,valor) values('ENG','LOGIN_BTN_CANCEL','Cancel');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_SPLASH_TITLE','Click to enter the system');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_SPLASH_ACTIVITY','Click to select an operation.');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_BTN_LOGIN','Login');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_CHANGE_LANGUAGE','Choose language');
insert into idioma_palabras(code,clave,valor) values('ENG','SINGUP_TITLE','Register new user');
insert into idioma_palabras(code,clave,valor) values('ENG','SINGUP_DESCRIP','Complete to register a employee user.');
insert into idioma_palabras(code,clave,valor) values('ENG','SINGUP_DESCRIPTION','Complete this information to create your account:');
insert into idioma_palabras(code,clave,valor) values('ENG','SIGNUP_LEGACY','Employee legacy number:');
insert into idioma_palabras(code,clave,valor) values('ENG','SIGNUP_NAME','Write your name:');
insert into idioma_palabras(code,clave,valor) values('ENG','SIGNUP_SURNAME','Write your surname:');
insert into idioma_palabras(code,clave,valor) values('ENG','SIGNUP_ALIAS','Write your alias:');
insert into idioma_palabras(code,clave,valor) values('ENG','SIGNUP_EMAIL','Write your email:');
insert into idioma_palabras(code,clave,valor) values('ENG','SIGNUP_PWD','Write your password:');
insert into idioma_palabras(code,clave,valor) values('ENG','SIGNUP_OK','OK');
insert into idioma_palabras(code,clave,valor) values('ENG','SIGNUP_CANCEL','Cancel');
insert into idioma_palabras(code,clave,valor) values('ENG','DOCUMENT_NUMBER','Document number:');
insert into idioma_palabras(code,clave,valor) values('ENG','BIRTH_DATE','Birth date:');
insert into idioma_palabras(code,clave,valor) values('ENG','ORDER_NUMER','Order numer:');
insert into idioma_palabras(code,clave,valor) values('ENG','ADDRESS','Address:');
insert into idioma_palabras(code,clave,valor) values('ENG','PHONE_NUMBER','Phone number:');
insert into idioma_palabras(code,clave,valor) values('ENG','REGISTER_INPUT_ERROR','Validate the data required to register!');
insert into idioma_palabras(code,clave,valor) values('ENG','REGISTER_INPUT_EMAIL_ERROR','Email wrong format!');
insert into idioma_palabras(code,clave,valor) values('ENG','REGISTER_INPUT_ERROR_TITLE','Advice');
insert into idioma_palabras(code,clave,valor) values('ENG','REGISTER_INPUT_SUCCESS','User created successfully!');
insert into idioma_palabras(code,clave,valor) values('ENG','LOGIN_INPUT_ERROR','Email and password required!');
insert into idioma_palabras(code,clave,valor) values('ENG','LOGIN_INPUT_ERROR_TITLE','Warning');
insert into idioma_palabras(code,clave,valor) values('ENG','LOGIN_SERVICE_ERROR','The email or password was not correct!');
insert into idioma_palabras(code,clave,valor) values('ENG','INTEGRITY_USERS_NOT_FOUND','There are no users to validate integrity!');
insert into idioma_palabras(code,clave,valor) values('ENG','INTEGRITY_USERS_CORRUPT','Integrity corrupted bd users');
insert into idioma_palabras(code,clave,valor) values('ENG','INTEGRITY_USERS_ENTITY_FAIL','User table integrity compromised');
insert into idioma_palabras(code,clave,valor) values('ENG','INTEGRITY_ERROR','ERROR - integrity compromised');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_START','Start');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_LOGIN','Login');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_SIGNUP','Register');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_SIGNOUT','Sign out');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_EXIT','Exit');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_OPERATE','Operate');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_BUY','Buy');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_SELL','Sell');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_SEARCH','Search');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_DEPOSIT','Enter balance');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_EXTRACT','Withdraw balance');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_IT','TI');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_BACKUP','Backup');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_PERMISSION','Permissions');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_USER','Users');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_LANGUAGE','Languages');
insert into idioma_palabras(code,clave,valor) values('ENG','LANGUAGE_CHANGE_OK','The language has been successfully changed');
insert into idioma_palabras(code,clave,valor) values('ENG','LANGUAGE_CHANGE_ERROR','There was a problem trying to change the language');
insert into idioma_palabras(code,clave,valor) values('ENG','YOUR_USER_LABEL','Your user info:');
insert into idioma_palabras(code,clave,valor) values('ENG','YOUR_DOCUMENTS','Your document info:');
insert into idioma_palabras(code,clave,valor) values('ENG','SIGNUP_EMAIL_REPEATED','This email is already in use!');
insert into idioma_palabras(code,clave,valor) values('ENG','SIGNUP_DNI_REPEATED','This document number is already in use!');
insert into idioma_palabras(code,clave,valor) values('ENG','BAD_DNI','Document bad format!');
insert into idioma_palabras(code,clave,valor) values('ENG','BAD_PHONE','Phone number bad format!');
insert into idioma_palabras(code,clave,valor) values('ENG','BAD_TRAMITE','Order number bad format!');
insert into idioma_palabras(code,clave,valor) values('ENG','YOUR_WALLETS_LABEL','Your wallets...');
insert into idioma_palabras(code,clave,valor) values('ENG','YOUR_WALLETS_DESCRIPT','Click a wallet to see his info.');
insert into idioma_palabras(code,clave,valor) values('ENG','ARS_LABEL','Pesos');
insert into idioma_palabras(code,clave,valor) values('ENG','DOG_LABEL','Doge');
insert into idioma_palabras(code,clave,valor) values('ENG','LTC_LABEL','Litecoin');
insert into idioma_palabras(code,clave,valor) values('ENG','BTC_LABEL','Bitecoin');
insert into idioma_palabras(code,clave,valor) values('ENG','PERMISSION_TITLE','Permission');
insert into idioma_palabras(code,clave,valor) values('ENG','PERMISSION_LABEL','In this section you can manage the use permission.');
insert into idioma_palabras(code,clave,valor) values('ENG','PERMISSION_ABM','Permission list:');
insert into idioma_palabras(code,clave,valor) values('ENG','BTN_DEL_PERMISSION','Delete');
insert into idioma_palabras(code,clave,valor) values('ENG','BTN_CLOSE_PERMISSION','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','BTN_UPDATE_PERMISSION','Update');
insert into idioma_palabras(code,clave,valor) values('ENG','BTN_COMPOUND_PERMISSION','Add compound');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_SEARCH','User control');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_SEARCH_DESCRIP','In this section you can make changes in user attributes and permissions.');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_SEARCH_LABEL','Write user name/surname/email or part of it:');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_SEARCH_BTN','Search');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_SEARCH_CLOSE','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_PERM_BTN','Edit permission');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_COL_ID','Id');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_COL_NAME','Name');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_COL_SURNAME','Surname');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_COL_EMAIL','Email');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_COL_TYPE','User type');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_IT_ADD_USER','Add new user');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_IT_USER_MANAGER','User control');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_IT_LANG_MANAGER','Manage language');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_TITLE','Language editor');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_DESCRIP','In this section you customize the system language.');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_NEW_LANGUAGE','New');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_REFRESH_LANGUAGE','Refresh');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_EDIT_LANGUAGE','Edit word');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_ADD_LANGUAGE','Add');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_DEL_LANGUAGE','Delete');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_CLOSE_LANGUAGE','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','UI_LANG_NEW_KEY','New word');
insert into idioma_palabras(code,clave,valor) values('ENG','UI_LANG_NEW_KEY_DESCRIP','Write the key value for the new word');
insert into idioma_palabras(code,clave,valor) values('ENG','UI_LANG_NEW_KEY_TITLE','Key');
insert into idioma_palabras(code,clave,valor) values('ENG','UI_LANG_NEW_VALUE_TITLE','Traduction');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_COL_CODE','Key');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_COL_VALUE','Traduction');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UPD_OK','Language updated success!!');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_DELETE_CONFIRM','Delete word of language');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_DELETE_CONFIRM_TITLE','Do you want to delete?');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_PERM_DEL_CONFIRM_TITLE','Do you want to delete?');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_PERM_DEL_CONFIRM_DESCRIP','Select an option.');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_PERM_DEL_SUCESS','Permission deleted!');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_PERM_DEL_REQ','You mus select a permission');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_PERM_ADD_CONFIRM_TITLE','Do you want add a new permission?');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_PERM_ADD_CONFIRM_DESCRIP','Select an option');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_PERM_ADD_ERROR','You must select a permission from the tree and later in the permission list');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_PERM_ADD_DENY','It is not allowed to add within an atomic permission');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_PERM_COMP_ADD_TITLE','New compound permission');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_PERM_COMP_ADD_DESCRIP','New compound permission');
insert into idioma_palabras(code,clave,valor) values('ENG','SELL_TITLE','Publish sell order');
insert into idioma_palabras(code,clave,valor) values('ENG','SELL_INPUT','You offer:');
insert into idioma_palabras(code,clave,valor) values('ENG','SELL_RECEIVE','You receive:');
insert into idioma_palabras(code,clave,valor) values('ENG','SELL_MONEY','Money:');
insert into idioma_palabras(code,clave,valor) values('ENG','SELL_CLOSE','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','SELL_PUBLISH','Publish');
insert into idioma_palabras(code,clave,valor) values('ENG','SELL_MONEY_MISMATCH','You cant chose the same money booth');
insert into idioma_palabras(code,clave,valor) values('ENG','SELL_MONEY_EXCED','You cant exced market price');
insert into idioma_palabras(code,clave,valor) values('ENG','SELL_MONEY_FREE_PRICE','Free price');
insert into idioma_palabras(code,clave,valor) values('ENG','SELL_MONEY_MARKET_PRICE','Market price');
insert into idioma_palabras(code,clave,valor) values('ENG','SELL_MONEY_SUCCESS','Order published success!!');
insert into idioma_palabras(code,clave,valor) values('ENG','SELL_TAX','Tax rate');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_TITLE','Search');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_DESCRIP','In this section you can search different sell orders.');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_BTN_VIEW','View');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_BTN_BY','By');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_BTN_SEARCH','Search');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_BTN_CLOSE','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_COL_ID','Id');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_COL_SELLER','Seller');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_COL_QTY','Quantity');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_COL_REQ','Request');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_COL_PRICE','Price');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_COL_OFFER','Offer');

select * from idioma_palabras