--Borro las tablas para volver a crearlas.
DROP TABLE IF EXISTS usuario;
DROP TABLE IF EXISTS tipo_usuario;
DROP TABLE IF EXISTS usuario_estado;
DROP TABLE IF EXISTS usuario_bloq;
DROP TABLE IF EXISTS solic_onboarding;
DROP TABLE IF EXISTS onboarding_estados;
DROP TABLE IF EXISTS cliente;
DROP TABLE IF EXISTS cliente_cambios;
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
DROP TABLE IF EXISTS control_cambios;
DROP TABLE IF EXISTS comision_operacion_valor;
DROP TABLE IF EXISTS conversiones;
DROP TABLE IF EXISTS notificaciones;
DROP TABLE IF EXISTS admin_backup;
DROP TABLE IF EXISTS dvv;
DROP TABLE IF EXISTS idiomas;
DROP TABLE IF EXISTS palabras;
DROP TABLE IF EXISTS idioma_palabras;
DROP TABLE IF EXISTS permiso;
DROP TABLE IF EXISTS permiso_permiso;
DROP TABLE IF EXISTS usuarios_permisos;
DROP TABLE IF EXISTS banco_data;

--Tabla de banco.
create table banco_data(
	idbanco bigint identity(1,1) primary key,
	cbu varchar(100),
	nombre varchar(100),
	alias varchar(50)
);

insert into banco_data(cbu,nombre,alias) values('0070064130004043187745','Banco Galicia','Crypton.ars');

--Tabla de usuarios.
create table usuario(
	idusuario bigint identity(1,1) primary key,
	nombre varchar(100),
	apellido varchar(100),
	alias varchar(50),
	email varchar(100),
	tipo_usuario int,
	estado int,
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

--Tabla de estados de usuario.
CREATE TABLE usuario_estado(
	[idestado] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] varchar(100)
);

insert into usuario_estado(nombre) values('Activo');
insert into usuario_estado(nombre) values('Inactivo');
insert into usuario_estado(nombre) values('Bloqueado');

--Tabla de bloqueo de usuarios.
CREATE TABLE usuario_bloq(
	[idbloq] [bigint] IDENTITY(1,1) NOT NULL,
	[idusuario] [bigint] NULL,
	[motivo] [varchar](200) NULL,
	[fecBloq] [datetime] NULL
);

---Tabla con digito verificadores verticales.
create table dvv(
	tabla varchar(100) primary key,
	[hash] text,
	fecUpdate datetime,
	deleted datetime
);

insert into dvv(tabla,[hash],fecUpdate) values('usuario','',GETDATE());

--Permisos
CREATE TABLE permiso(
	id int IDENTITY(1,1) NOT NULL,
	nombre varchar(100) NULL,
	permiso varchar(100)
);

CREATE TABLE permiso_permiso(
	id_permiso_padre int NULL,
	id_permiso_hijo int NULL
);

CREATE TABLE usuarios_permisos(
	id_usuario int not null,
	id_permiso int not null
);

--Patentes
insert into permiso(nombre,permiso) values('SEARCH_OFFERS','P');
insert into permiso(nombre,permiso) values('RECOMENDATIONS','P');
insert into permiso(nombre,permiso) values('MY_PUBLICATIONS','P');
insert into permiso(nombre,permiso) values('MY_BALANCE','P');
insert into permiso(nombre,permiso) values('MY_PROFILE','P');
insert into permiso(nombre,permiso) values('PUBLISH_OFFER','P');
insert into permiso(nombre,permiso) values('CREATE_USER','P');
insert into permiso(nombre,permiso) values('MANAGE_USERS','P');
insert into permiso(nombre,permiso) values('MANAGE_PERMISSION','P');
insert into permiso(nombre,permiso) values('MANAGE_USER_PERMISSION','P')
insert into permiso(nombre,permiso) values('MANAGE_LANGUAGES','P');
insert into permiso(nombre,permiso) values('NOTIFICATIONS','P');
insert into permiso(nombre,permiso) values('MY_BUYS','P');
insert into permiso(nombre,permiso) values('SEARCH_LOG','P');
insert into permiso(nombre,permiso) values('BACKUP','P');
insert into permiso(nombre,permiso) values('CBU','P');
insert into permiso(nombre,permiso) values('EXTRACT','P');
insert into permiso(nombre,permiso) values('CASH_IN','P');
insert into permiso(nombre,permiso) values('EXTRACT_LIST','P');


--Familias
insert into permiso(nombre,permiso) values('CLIENTS',null);
insert into permiso(nombre,permiso) values('EMPLOYEES',null);
insert into permiso(nombre,permiso) values('IT',null);

--Relacion permisos-cliente
insert into permiso_permiso values(10,1);
insert into permiso_permiso values(10,2);
insert into permiso_permiso values(10,3);
insert into permiso_permiso values(10,4);
insert into permiso_permiso values(10,5);

--Relacion permisos-empleado
insert into permiso_permiso values(11,12);
insert into permiso_permiso values(12,6);
insert into permiso_permiso values(12,7);
insert into permiso_permiso values(12,8);
insert into permiso_permiso values(12,9);
insert into permiso_permiso values(12,18);

--Tabla de registro de backups.
create table admin_backup
(
	idbackup int identity(1,1) primary key,
	idusuario bigint,
	[path] varchar(100),
	fecRec datetime,
	[type] varchar(100),
	size   bigint,
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
	cbu varchar(50),
	deleted datetime
);

create table cliente_cambios(
	idchange bigint identity(1,1) primary key,
	change_date datetime,
	idcliente bigint,	
	tipoDoc varchar(10),
	numero varchar(100),
	fec_nac datetime,
	num_tramite varchar(50),
	domicilio varchar(100),
	telefono varchar(100),
	cbu varchar(50),
	roollback_user bigint
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
insert into api_keys(ambiente,btc,ltc,dog) values('TEST_2','7ebe-8f45-4490-37d4','8e15-55be-cccd-b33c','cece-b117-15ca-e13d');
insert into api_keys(ambiente,btc,ltc,dog) values('TEST_3','445a-3f29-2ac6-1193','81ae-7b52-0529-5eb2','b5a7-8ef5-79da-85c7');
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
	saldo varchar(12),
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
insert into solic_estados(descrip) values('Pendientes');

--Tabla de transferencias.
create table transferencias(
	idtransf bigint identity(1,1) primary key,
	fecProc datetime,
	cliente bigint,
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
	tipo_operacion int,
	referencia bigint,
	idcliente bigint,
	idwallet bigint,
	moneda varchar(10),
	valor varchar(12),
	fecCobro datetime,
	processed int,
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
	cantidad varchar(12), --money
	ofrece varchar(10),
	pide varchar(10),
	precio varchar(12), --money
	fecCreacion datetime,
	fecFin datetime,
	ordenEstado int,
	deleted datetime
);

--Tabla de tipo de ordenes.
create table orden_estado(
	ídtipo int identity(1,1) primary key,
	descrip varchar(100)
);

insert into orden_estado(descrip) values('Disponible');
insert into orden_estado(descrip) values('Vendida');
insert into orden_estado(descrip) values('Expirada');
insert into orden_estado(descrip) values('Finalizada');

--Tabla de ordenes de compra.
create table orden_compra(
	idcompra int identity(1,1) primary key,
	idorden bigint,
	fecOperacion datetime,
	comprador bigint,
	cantidad varchar(12),
	moneda varchar(10),
	deleted datetime
);

--Notificaciones
create table notificaciones
(
	idnotification bigint not NULL identity(1,1) PRIMARY KEY,
	idcliente bigint,
	payload text,
	fecRegistro datetime,
	marked int
);

--Bitacora. 
CREATE TABLE bitacora
(
	id bigint not NULL identity(1,1) PRIMARY KEY,
	idusuario bigint NULL,	
	fec_log datetime NULL,
	activity varchar(150),
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
insert into idiomas(code,descripcion) values('ASG','Asgardiano');

--Tabla de palabras
create table palabras
(
	word varchar(50) primary key,
	fecCreation datetime default GETDATE()
);

insert into palabras(word) values('ADDRESS');
insert into palabras(word) values('ARS_LABEL');
insert into palabras(word) values('BAD_DNI');
insert into palabras(word) values('BAD_PHONE');
insert into palabras(word) values('BAD_TRAMITE');
insert into palabras(word) values('BIRTH_DATE');
insert into palabras(word) values('BTC_LABEL');
insert into palabras(word) values('BTN_CLOSE_PERMISSION');
insert into palabras(word) values('BTN_COMPOUND_PERMISSION');
insert into palabras(word) values('BTN_DEL_PERMISSION');
insert into palabras(word) values('BTN_UPDATE_PERMISSION');
insert into palabras(word) values('BUTTON_CANCEL');
insert into palabras(word) values('BUTTON_OK');
insert into palabras(word) values('BUY_ERROR');
insert into palabras(word) values('BUY_SUCCESS');
insert into palabras(word) values('DOCUMENT_NUMBER');
insert into palabras(word) values('DOG_LABEL');
insert into palabras(word) values('HELLO');
insert into palabras(word) values('INTEGRITY_ERROR');
insert into palabras(word) values('INTEGRITY_USERS_CORRUPT');
insert into palabras(word) values('INTEGRITY_USERS_ENTITY_FAIL');
insert into palabras(word) values('INTEGRITY_USERS_NOT_FOUND');
insert into palabras(word) values('LANG_CHOOSE_TITLE');
insert into palabras(word) values('LANGUAGE_CHANGE_ERROR');
insert into palabras(word) values('LANGUAGE_CHANGE_OK');
insert into palabras(word) values('LOGIN');
insert into palabras(word) values('LOGIN_BTN_CANCEL');
insert into palabras(word) values('LOGIN_BTN_INGRESAR');
insert into palabras(word) values('LOGIN_INPUT_ERROR');
insert into palabras(word) values('LOGIN_INPUT_ERROR_TITLE');
insert into palabras(word) values('LOGIN_SERVICE_ERROR');
insert into palabras(word) values('LOGIN_TITLE_1');
insert into palabras(word) values('LOGIN_TITLE_EMAIL');
insert into palabras(word) values('LOGIN_TITLE_PASSWORD');
insert into palabras(word) values('LTC_LABEL');
insert into palabras(word) values('MAIN_BTN_LOGIN');
insert into palabras(word) values('MAIN_CHANGE_LANGUAGE');
insert into palabras(word) values('MAIN_MENU_BACKUP');
insert into palabras(word) values('MAIN_MENU_BUY');
insert into palabras(word) values('MAIN_MENU_DEPOSIT');
insert into palabras(word) values('MAIN_MENU_EXIT');
insert into palabras(word) values('MAIN_MENU_EXTRACT');
insert into palabras(word) values('MAIN_MENU_IT');
insert into palabras(word) values('MAIN_MENU_IT_ADD_USER');
insert into palabras(word) values('MAIN_MENU_IT_LANG_MANAGER');
insert into palabras(word) values('MAIN_MENU_IT_USER_MANAGER');
insert into palabras(word) values('MAIN_MENU_LANGUAGE');
insert into palabras(word) values('MAIN_MENU_LOGIN');
insert into palabras(word) values('MAIN_MENU_MY_SELLS');
insert into palabras(word) values('MAIN_MENU_MY_WALLETS');
insert into palabras(word) values('MAIN_MENU_NOTIFICATIONS');
insert into palabras(word) values('MAIN_MENU_OPERATE');
insert into palabras(word) values('MAIN_MENU_PERMISSION');
insert into palabras(word) values('MAIN_MENU_RECOMENDATIONS');
insert into palabras(word) values('MAIN_MENU_SEARCH');
insert into palabras(word) values('MAIN_MENU_SELL');
insert into palabras(word) values('MAIN_MENU_SIGNOUT');
insert into palabras(word) values('MAIN_MENU_SIGNUP');
insert into palabras(word) values('MAIN_MENU_START');
insert into palabras(word) values('MAIN_MENU_USER');
insert into palabras(word) values('MAIN_MENU_IT_BACKUP');
insert into palabras(word) values('MAIN_MENU_CBU');
insert into palabras(word) values('MAIN_MENU_CASH_IN');
insert into palabras(word) values('MAIN_SPLASH_ACTIVITY');
insert into palabras(word) values('MAIN_SPLASH_TITLE');
insert into palabras(word) values('MY_SELL_FINISH_CONFIRM');
insert into palabras(word) values('MY_SELL_FINISH_SUCCESS');
insert into palabras(word) values('MY_SELL_FINISH_TITLE');
insert into palabras(word) values('MY_SELL_ORDERS_PAUSE');
insert into palabras(word) values('MY_SELL_ORDERS_TITLE');
insert into palabras(word) values('NOTIF_BUY_OK_SUCCESS');
insert into palabras(word) values('NOTIF_BUY_SUCCESS');
insert into palabras(word) values('NOTIF_CLOSE');
insert into palabras(word) values('NOTIF_DATE');
insert into palabras(word) values('NOTIF_DESCRIP');
insert into palabras(word) values('NOTIF_TEXT');
insert into palabras(word) values('NOTIF_TITLE');
insert into palabras(word) values('OP_BTN_BUY');
insert into palabras(word) values('OP_BTN_CLOSE');
insert into palabras(word) values('OP_DETAIL_LABEL');
insert into palabras(word) values('OP_OFFER');
insert into palabras(word) values('OP_REQ');
insert into palabras(word) values('OP_SELLER');
insert into palabras(word) values('OP_TAX_LABEL');
insert into palabras(word) values('OP_TAX_LABEL_INFO');
insert into palabras(word) values('OP_TITLE');
insert into palabras(word) values('ORDER_NUMER');
insert into palabras(word) values('PERMISSION_ABM');
insert into palabras(word) values('PERMISSION_LABEL');
insert into palabras(word) values('PERMISSION_TITLE');
insert into palabras(word) values('PHONE_NUMBER');
insert into palabras(word) values('RECOM_CLOSE');
insert into palabras(word) values('RECOM_DESCRIP');
insert into palabras(word) values('RECOM_TITLE');
insert into palabras(word) values('RECOM_VIEW');
insert into palabras(word) values('REGISTER_INPUT_EMAIL_ERROR');
insert into palabras(word) values('REGISTER_INPUT_ERROR');
insert into palabras(word) values('REGISTER_INPUT_ERROR_TITLE');
insert into palabras(word) values('REGISTER_INPUT_SUCCESS');
insert into palabras(word) values('SEARCH_BTN_BY');
insert into palabras(word) values('SEARCH_BTN_CLOSE');
insert into palabras(word) values('SEARCH_BTN_SEARCH');
insert into palabras(word) values('SEARCH_BTN_VIEW');
insert into palabras(word) values('SEARCH_COL_ID');
insert into palabras(word) values('SEARCH_COL_OFFER');
insert into palabras(word) values('SEARCH_COL_PRICE');
insert into palabras(word) values('SEARCH_COL_QTY');
insert into palabras(word) values('SEARCH_COL_REQ');
insert into palabras(word) values('SEARCH_COL_SELLER');
insert into palabras(word) values('SEARCH_COL_STATUS');
insert into palabras(word) values('SEARCH_DESCRIP');
insert into palabras(word) values('SEARCH_TITLE');
insert into palabras(word) values('SELL_CLOSE');
insert into palabras(word) values('SELL_INPUT');
insert into palabras(word) values('SELL_MONEY');
insert into palabras(word) values('SELL_MONEY_EXCED');
insert into palabras(word) values('SELL_MONEY_FREE_PRICE');
insert into palabras(word) values('SELL_MONEY_MARKET_PRICE');
insert into palabras(word) values('SELL_MONEY_MISMATCH');
insert into palabras(word) values('SELL_MONEY_SUCCESS');
insert into palabras(word) values('SELL_PUBLISH');
insert into palabras(word) values('SELL_RECEIVE');
insert into palabras(word) values('SELL_TAX');
insert into palabras(word) values('SELL_TITLE');
insert into palabras(word) values('SIGNUP_ALIAS');
insert into palabras(word) values('SIGNUP_CANCEL');
insert into palabras(word) values('SIGNUP_DNI_REPEATED');
insert into palabras(word) values('SIGNUP_EMAIL');
insert into palabras(word) values('SIGNUP_EMAIL_REPEATED');
insert into palabras(word) values('SIGNUP_LEGACY');
insert into palabras(word) values('SIGNUP_NAME');
insert into palabras(word) values('SIGNUP_OK');
insert into palabras(word) values('SIGNUP_PWD');
insert into palabras(word) values('SIGNUP_SURNAME');
insert into palabras(word) values('SINGUP_DESCRIP');
insert into palabras(word) values('SINGUP_DESCRIPTION');
insert into palabras(word) values('SINGUP_TITLE');
insert into palabras(word) values('TAX_NETWORK_FEE');
insert into palabras(word) values('TAX_PLATFORM_FOR_BUY');
insert into palabras(word) values('TAX_PLATFORM_FOR_SELL');
insert into palabras(word) values('UI_LANG_NEW_KEY');
insert into palabras(word) values('UI_LANG_NEW_KEY_DESCRIP');
insert into palabras(word) values('UI_LANG_NEW_KEY_TITLE');
insert into palabras(word) values('UI_LANG_NEW_VALUE_TITLE');
insert into palabras(word) values('USR_COL_EMAIL');
insert into palabras(word) values('USR_COL_ID');
insert into palabras(word) values('USR_COL_NAME');
insert into palabras(word) values('USR_COL_SURNAME');
insert into palabras(word) values('USR_COL_TYPE');
insert into palabras(word) values('USR_LANG_COL_CODE');
insert into palabras(word) values('USR_LANG_COL_VALUE');
insert into palabras(word) values('USR_LANG_DELETE_CONFIRM');
insert into palabras(word) values('USR_LANG_DELETE_CONFIRM_TITLE');
insert into palabras(word) values('USR_LANG_NEW');
insert into palabras(word) values('USR_LANG_NEW_ERROR');
insert into palabras(word) values('USR_LANG_NEW_NAME');
insert into palabras(word) values('USR_LANG_NEW_OK');
insert into palabras(word) values('USR_LANG_NEW_REQUIRED');
insert into palabras(word) values('USR_LANG_UI_ADD_LANGUAGE');
insert into palabras(word) values('USR_LANG_UI_CLOSE_LANGUAGE');
insert into palabras(word) values('USR_LANG_UI_DEL_LANGUAGE');
insert into palabras(word) values('USR_LANG_ALL_DELETE_CONFIRM_TITLE');
insert into palabras(word) values('USR_LANG_UI_DESCRIP');
insert into palabras(word) values('USR_LANG_UI_EDIT_LANGUAGE');
insert into palabras(word) values('USR_LANG_UI_NEW_LANGUAGE');
insert into palabras(word) values('USR_LANG_UI_REFRESH_LANGUAGE');
insert into palabras(word) values('USR_LANG_UI_TITLE');
insert into palabras(word) values('USR_LANG_UPD_OK');
insert into palabras(word) values('USR_LANG_UPD_REQUIRED');
insert into palabras(word) values('USR_PERM_ADD_CONFIRM_DESCRIP');
insert into palabras(word) values('USR_PERM_ADD_CONFIRM_TITLE');
insert into palabras(word) values('USR_PERM_ADD_DENY');
insert into palabras(word) values('USR_PERM_ADD_ERROR');
insert into palabras(word) values('USR_PERM_BTN');
insert into palabras(word) values('USR_PERM_COMP_ADD_DESCRIP');
insert into palabras(word) values('USR_PERM_COMP_ADD_TITLE');
insert into palabras(word) values('USR_PERM_DEL_CONFIRM_DESCRIP');
insert into palabras(word) values('USR_PERM_DEL_CONFIRM_TITLE');
insert into palabras(word) values('USR_PERM_DEL_REQ');
insert into palabras(word) values('USR_PERM_DEL_SUCESS');
insert into palabras(word) values('USR_SEARCH');
insert into palabras(word) values('USR_SEARCH_BTN');
insert into palabras(word) values('USR_SEARCH_CLOSE');
insert into palabras(word) values('USR_SEARCH_DESCRIP');
insert into palabras(word) values('USR_SEARCH_LABEL');
insert into palabras(word) values('WELCOME');
insert into palabras(word) values('YOUR_DOCUMENTS');
insert into palabras(word) values('YOUR_USER_LABEL');
insert into palabras(word) values('YOUR_WALLETS_DESCRIPT');
insert into palabras(word) values('YOUR_WALLETS_LABEL');
insert into palabras(word) values('TEMPLATE_EDITOR');
insert into palabras(word) values('TEMPLATE_EDITOR_ADD');
insert into palabras(word) values('TEMPLATE_EDITOR_DELETE');
insert into palabras(word) values('TEMPLATE_CONFIRM_DELETE');
insert into palabras(word) values('TEMPLATE_EDITOR_ADD_OK');
insert into palabras(word) values('TEMPLATE_EDITOR_DELETE_OK');
insert into palabras(word) values('EDIT_PATENT_TITLE');
insert into palabras(word) values('EDIT_PATENT_DESCRIP');
insert into palabras(word) values('EDIT_PATENTE_SELECTOR_TITLE');
insert into palabras(word) values('EDIT_PATENTE_SELECTOR_DESCRIP');
insert into palabras(word) values('EDIT_FAMILY_SELECTOR_TITLE');
insert into palabras(word) values('EDIT_FAMILY_SELECTOR_DESCRIP');
insert into palabras(word) values('COMP_CRUD_TITLE_FAMILY');
insert into palabras(word) values('COMP_CRUD_TITLE_PATENT');
insert into palabras(word) values('COMP_CRUD_DESCRIPTION');
insert into palabras(word) values('COMP_CRUD_ADD');
insert into palabras(word) values('COMP_CRUD_CLOSE');
insert into palabras(word) values('COMP_CRUD_DELETE');
insert into palabras(word) values('COMP_CRUD_ADD_VALUE');
insert into palabras(word) values('COMP_CRUD_ADD_DESCRIP');
insert into palabras(word) values('COMP_CRUD_DELETE_TITLE');
insert into palabras(word) values('COMP_CRUD_DELETE_CONFIRM');
insert into palabras(word) values('COMP_CRUD_DELETE_OK');
insert into palabras(word) values('TREE_TITLE_EDITOR');
insert into palabras(word) values('TREE_DESCRIP_EDITOR');
insert into palabras(word) values('TREE_CRUD_FAMILY');
insert into palabras(word) values('TREE_CRUD_PATENT');
insert into palabras(word) values('TREE_CRUD_VIEW');
insert into palabras(word) values('TREE_CRUD_ADD_FAMILY');
insert into palabras(word) values('TREE_CRUD_ADD_PATENT');
insert into palabras(word) values('TREE_CRUD_SAVE');
insert into palabras(word) values('TREE_CRUD_CLOSE');
insert into palabras(word) values('TREE_CRUD_DELETE');
insert into palabras(word) values('TREE_PATENT_EXISTS');
insert into palabras(word) values('TREE_FAMILY_EXISTS');
insert into palabras(word) values('USER_TREE_EDITOR_TITLE');
insert into palabras(word) values('USER_TREE_EDITOR_DESCRIP');
insert into palabras(word) values('SEEL_TAX_LABEL');
insert into palabras(word) values('TAX_NETWORK_FEE_ERROR');
insert into palabras(word) values('WALLET_TITLE');
insert into palabras(word) values('WALLET_DESCRIP');
insert into palabras(word) values('WALLET_BTN_REFRESH');
insert into palabras(word) values('WALLET_BTN_CLOSE');
insert into palabras(word) values('WALLET_MONEY');
insert into palabras(word) values('WALLET_READY_VALUE');
insert into palabras(word) values('WALLET_PENDING_VALUE');
insert into palabras(word) values('OP_TOTAL');
insert into palabras(word) values('MY_BUYS');
insert into palabras(word) values('BUY_DATE');
insert into palabras(word) values('MAIN_MENU_IT_USER_PERM_MANAGER');
insert into palabras(word) values('LOG_ACTIV_TITLE');
insert into palabras(word) values('LOG_FROM_TITLE');
insert into palabras(word) values('LOG_TO_TITLE');
insert into palabras(word) values('LOG_TEXT_TITLE');
insert into palabras(word) values('LOG_SEARCH_TITLE');
insert into palabras(word) values('LOG_SEARCH_DESCRIP');
insert into palabras(word) values('LOG_BTN_SEARCH');
insert into palabras(word) values('LOG_BTN_CLOSE');
insert into palabras(word) values('LOG_COL_ID');
insert into palabras(word) values('LOG_COL_FECHA');
insert into palabras(word) values('LOG_COL_USUARIO');
insert into palabras(word) values('LOG_COL_ACTIVIDAD');
insert into palabras(word) values('LOG_COL_TEXTO');
insert into palabras(word) values('MAIN_MENU_LOG_SEARCH');
insert into palabras(word) values('USR_SEARCHER');
insert into palabras(word) values('USR_CONTROL_BTN_CHANGE');
insert into palabras(word) values('USR_CONTROL_COL_CHANGE_TDOC');
insert into palabras(word) values('USR_CONTROL_COL_CHANGE_NUM');
insert into palabras(word) values('USR_CONTROL_COL_CHANGE_FEC_NAC');
insert into palabras(word) values('USR_CONTROL_COL_CHANGRE_NUM_TRAMITE');
insert into palabras(word) values('USR_CONTROL_COL_CHANGE_ADDRESS');
insert into palabras(word) values('USR_CONTROL_COL_CHANGE_EMAIL');
insert into palabras(word) values('USR_CONTROL_COL_CHANGE_PHONE');
insert into palabras(word) values('USR_CONTROL_COL_CHANGE_OPERATOR');
insert into palabras(word) values('FRM_CHANGE_CONTROL');
insert into palabras(word) values('FRM_CHANGE_CONTROL_BTN_RECOVE');
insert into palabras(word) values('USR_CHANGE_CLOSE');
insert into palabras(word) values('USR_TXT_CTRL_TITLE');
insert into palabras(word) values('USR_TXT_CTRL_DESCRIP');
insert into palabras(word) values('USR_CHANGE_CONFIRM');
insert into palabras(word) values('USR_CHANGE_TITLE');
insert into palabras(word) values('USR_CHANGE_RESTORE_SUCCESS');
insert into palabras(word) values('PROFILE_TYPE_DOC');
insert into palabras(word) values('PROFILE_DOC_NUMBER');
insert into palabras(word) values('PROFILE_BIRTH_DATE');
insert into palabras(word) values('PROFILE_TRAMITE');
insert into palabras(word) values('PROFILE_ADDRESS');
insert into palabras(word) values('PROFILE_PHONE');
insert into palabras(word) values('PROFILE_CLOSE');
insert into palabras(word) values('PROFILE_OK');
insert into palabras(word) values('PROFILE_FORM');
insert into palabras(word) values('PROFILE_CBU');
insert into palabras(word) values('TXT_BACKUP_TITLE');
insert into palabras(word) values('TXT_BACKUP_DESCRIP');
insert into palabras(word) values('BTN_NEW_BACKUP');
insert into palabras(word) values('BTN_LOAD_BACKUP');
insert into palabras(word) values('BTN_CLOSE_BACKUP');
insert into palabras(word) values('BACKUP_COL_PATH');
insert into palabras(word) values('BACKUP_COL_FEC');
insert into palabras(word) values('BACKUP_COL_TYPE');
insert into palabras(word) values('BACKUP_MSG_RESTORE_DESCRIP');
insert into palabras(word) values('BACKUP_COL_SIZE');
insert into palabras(word) values('TXT_BACKUP_TITLE_LIST');
insert into palabras(word) values('CBU_TITLE');
insert into palabras(word) values('CBU_TITLE_DESCRIP');
insert into palabras(word) values('WARNING_TITLE');
insert into palabras(word) values('WARNING_TITLE_DESCRIP');
insert into palabras(word) values('TXT_CBU');
insert into palabras(word) values('TXT_ALIAS');
insert into palabras(word) values('TXT_BANK');
insert into palabras(word) values('BTN_COPY');
insert into palabras(word) values('BTN_CLOSE');
insert into palabras(word) values('SEARCH_CBU_TITLE');
insert into palabras(word) values('SEARCH_CBU_TITLE_DESCRIP');
insert into palabras(word) values('SEARCH_CBU_WRITE');
insert into palabras(word) values('SEARCH_CBU_BTN_SEARCH');
insert into palabras(word) values('SEARCH_CBU_BTN_CASHIN');
insert into palabras(word) values('SEARCH_CBU_BTN_CLOSE');
insert into palabras(word) values('SEARCH_CBU_CLIENT');
insert into palabras(word) values('SEARCH_CBU_TDOC');
insert into palabras(word) values('SEARCH_CBU_DNI');
insert into palabras(word) values('SEARCH_CBU_EMAIL');
insert into palabras(word) values('GRAL_NO_RESULTS');
insert into palabras(word) values('GRAL_YOU_MUST_ENTER_A_VALUE');
insert into palabras(word) values('GRAL_UNABLE_TO_PROCESS');
insert into palabras(word) values('GRAL_OPERATION_SUCCESS');
insert into palabras(word) values('CBU_CASHIN_TITLE');
insert into palabras(word) values('CBU_CASHIN_LABEL');
insert into palabras(word) values('EXTRACT_ARS_TITLE');
insert into palabras(word) values('EXTRACT_ARS_DESCRIP');
insert into palabras(word) values('EXTRACT_ARS_VALUE_LABEL');
insert into palabras(word) values('EXTRACT_ARS_VALUE_LABEL_DESCRIP');
insert into palabras(word) values('EXTRACT_ARS_CBU');
insert into palabras(word) values('EXTRACT_ARS_AMMOUNT');
insert into palabras(word) values('EXTRACT_ARS_PENDING_DEBTS');
insert into palabras(word) values('EXTRACT_ARS_NO_FOUNDS');
insert into palabras(word) values('EXTRACT_ARS_OK');
insert into palabras(word) values('RETIRO_TITLE');
insert into palabras(word) values('RETIRO_TITLE_DESCRIP');
insert into palabras(word) values('BTN_RETIRO_OK');
insert into palabras(word) values('BTN_RETIRO_REJECT');
insert into palabras(word) values('MAIN_MENU_EXTRACT_ARS');

--Tabla de palabras por idioma.
create table idioma_palabras
(	
	code varchar(50),
	clave varchar(50),
	valor varchar(100),
	deleted datetime,
	CONSTRAINT pk_idioma_palabra PRIMARY KEY (code,clave)
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
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_START','Inicio');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_LOGIN','Iniciar sesión');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_SIGNUP','Registrarse');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_SIGNOUT','Cerrar sesión');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_EXIT','Salir');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_OPERATE','Operar');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_SEARCH','Buscar');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_SELL','Vender');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_RECOMENDATIONS','Recomendaciones');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_NOTIFICATIONS','Notificaciones');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_MY_WALLETS','Mis billeteras');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_MY_SELLS','Mis publicaciones');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_BUY','Comprar');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_DEPOSIT','Ingresar saldo');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_EXTRACT','Retirar saldo');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_IT','IT');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_LOG_SEARCH','Buscar en bitacora');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_BACKUP','Backup');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_PERMISSION','Permisos');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_USER','Usuarios');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_LANGUAGE','Idioma');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_PROFILE','Perfil');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_IT_BACKUP','Backup');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_CASH_IN','Ingresar fondos');
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
insert into idioma_palabras(code,clave,valor) values('ES','USR_LANG_ALL_DELETE_CONFIRM_TITLE','¿Seguro queres borrar lenguaje, se borraran todas las palabras?');
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
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_COL_STATUS','Estado');
insert into idioma_palabras(code,clave,valor) values('ES','MY_SELL_ORDERS_TITLE','Mis ordenes de venta');
insert into idioma_palabras(code,clave,valor) values('ES','MY_SELL_ORDERS_PAUSE','Finalizar');
insert into idioma_palabras(code,clave,valor) values('ES','MY_SELL_FINISH_TITLE','¿Seguro desea finalizar esta orden de venta?');
insert into idioma_palabras(code,clave,valor) values('ES','MY_SELL_FINISH_CONFIRM','Escoja una opción.');
insert into idioma_palabras(code,clave,valor) values('ES','MY_SELL_FINISH_SUCCESS','Orden finalizada con exito!');
insert into idioma_palabras(code,clave,valor) values('ES','RECOM_TITLE','Recomendaciones');
insert into idioma_palabras(code,clave,valor) values('ES','RECOM_DESCRIP','En esta sección veras ofertas para tí.');
insert into idioma_palabras(code,clave,valor) values('ES','RECOM_CLOSE','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','RECOM_VIEW','Ver');
insert into idioma_palabras(code,clave,valor) values('ES','OP_TITLE','Ordén');
insert into idioma_palabras(code,clave,valor) values('ES','OP_SELLER','Publicado por:');
insert into idioma_palabras(code,clave,valor) values('ES','OP_DETAIL_LABEL','Detalle de venta:');
insert into idioma_palabras(code,clave,valor) values('ES','OP_TAX_LABEL','Impuestos:');
insert into idioma_palabras(code,clave,valor) values('ES','OP_TAX_LABEL_INFO','En esta seccón ves el detalle de impuestos.');
insert into idioma_palabras(code,clave,valor) values('ES','OP_BTN_BUY','Comprar');
insert into idioma_palabras(code,clave,valor) values('ES','OP_BTN_CLOSE','Cancelar');
insert into idioma_palabras(code,clave,valor) values('ES','OP_OFFER','Pide:');
insert into idioma_palabras(code,clave,valor) values('ES','OP_REQ','Por:');
insert into idioma_palabras(code,clave,valor) values('ES','OP_TOTAL','Costo total:');
insert into idioma_palabras(code,clave,valor) values('ES','TAX_PLATFORM_FOR_BUY','Comision de la operación');
insert into idioma_palabras(code,clave,valor) values('ES','TAX_PLATFORM_FOR_SELL','Comision de la operación');
insert into idioma_palabras(code,clave,valor) values('ES','TAX_NETWORK_FEE','Costo de transferencia de la red');
insert into idioma_palabras(code,clave,valor) values('ES','NOTIF_TITLE','Notificaciones');
insert into idioma_palabras(code,clave,valor) values('ES','NOTIF_DESCRIP','Estas son tus notificaciones');
insert into idioma_palabras(code,clave,valor) values('ES','NOTIF_CLOSE','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','NOTIF_DATE','Fecha envio');
insert into idioma_palabras(code,clave,valor) values('ES','NOTIF_TEXT','Mensaje');
insert into idioma_palabras(code,clave,valor) values('ES','NOTIF_BUY_SUCCESS','Felicitaciones tu orden fue comprada por %c');
insert into idioma_palabras(code,clave,valor) values('ES','NOTIF_BUY_OK_SUCCESS','Hola %c! la compra de la orden fue exitosa!');
insert into idioma_palabras(code,clave,valor) values('ES','BUY_SUCCESS','Haz comprado la orden, espera unos minutos para ver el saldo actualizado en tu billetera!');
insert into idioma_palabras(code,clave,valor) values('ES','BUY_ERROR','Se produjo un error no se podra realizar la compra!');
insert into idioma_palabras(code,clave,valor) values('ES','TEMPLATE_EDITOR','Editar diccionario');
insert into idioma_palabras(code,clave,valor) values('ES','TEMPLATE_EDITOR_ADD','Agregar clave');
insert into idioma_palabras(code,clave,valor) values('ES','TEMPLATE_EDITOR_DELETE','Borrar clave');
insert into idioma_palabras(code,clave,valor) values('ES','TEMPLATE_CONFIRM_DELETE','¿Seguro desea borrar la clave, se borrara en todos los idiomas que la tengan?');
insert into idioma_palabras(code,clave,valor) values('ES','TEMPLATE_EDITOR_ADD_OK','Clave creada ok!');
insert into idioma_palabras(code,clave,valor) values('ES','TEMPLATE_EDITOR_DELETE_OK','Clave borrada ok!');
insert into idioma_palabras(code,clave,valor) values('ES','EDIT_PATENTE_TITLE','Editar patentes');
insert into idioma_palabras(code,clave,valor) values('ES','EDIT_PATENTE_DESCRIP','Desde aqui podes crear o borrar patentes');
insert into idioma_palabras(code,clave,valor) values('ES','EDIT_PATENTE_SELECTOR_TITLE','Selecciona una patente');
insert into idioma_palabras(code,clave,valor) values('ES','EDIT_PATENTE_SELECTOR_DESCRIP','Desde aqui podes elegir una patente');
insert into idioma_palabras(code,clave,valor) values('ES','EDIT_FAMILY_SELECTOR_TITLE','Elige una familia');
insert into idioma_palabras(code,clave,valor) values('ES','EDIT_FAMILY_SELECTOR_DESCRIP','Elige una familia desde aqui');
insert into idioma_palabras(code,clave,valor) values('ES','COMP_CRUD_TITLE_FAMILY','Editar familias');
insert into idioma_palabras(code,clave,valor) values('ES','COMP_CRUD_TITLE_PATENT','Editar patentes');
insert into idioma_palabras(code,clave,valor) values('ES','COMP_CRUD_DESCRIPTION','Desde aqui podes borrar y agregar');
insert into idioma_palabras(code,clave,valor) values('ES','COMP_CRUD_ADD','Agregar');
insert into idioma_palabras(code,clave,valor) values('ES','COMP_CRUD_CLOSE','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','COMP_CRUD_DELETE','Borrar');
insert into idioma_palabras(code,clave,valor) values('ES','COMP_CRUD_ADD_VALUE','Agregar nuevo valor');
insert into idioma_palabras(code,clave,valor) values('ES','COMP_CRUD_ADD_DESCRIP','Complete el valor');
insert into idioma_palabras(code,clave,valor) values('ES','COMP_CRUD_DELETE_TITLE','Borrar');
insert into idioma_palabras(code,clave,valor) values('ES','COMP_CRUD_DELETE_CONFIRM','¿Quiere borrar este valor?');
insert into idioma_palabras(code,clave,valor) values('ES','COMP_CRUD_DELETE_OK','Borrado ok!');
insert into idioma_palabras(code,clave,valor) values('ES','TREE_TITLE_EDITOR','Editor de familias/permisos');
insert into idioma_palabras(code,clave,valor) values('ES','TREE_DESCRIP_EDITOR','Recorda que las familias se edita separads.');
insert into idioma_palabras(code,clave,valor) values('ES','TREE_CRUD_FAMILY','ABM Familia');
insert into idioma_palabras(code,clave,valor) values('ES','TREE_CRUD_PATENT','ABM Patente');
insert into idioma_palabras(code,clave,valor) values('ES','TREE_CRUD_VIEW','Ver');
insert into idioma_palabras(code,clave,valor) values('ES','TREE_CRUD_ADD_FAMILY','+ Familia');
insert into idioma_palabras(code,clave,valor) values('ES','TREE_CRUD_ADD_PATENT','+ Patente');
insert into idioma_palabras(code,clave,valor) values('ES','TREE_CRUD_SAVE','Guardar');
insert into idioma_palabras(code,clave,valor) values('ES','TREE_CRUD_CLOSE','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','TREE_CRUD_DELETE','Borrar');
insert into idioma_palabras(code,clave,valor) values('ES','TREE_PATENT_EXISTS','La patente ya existe!');
insert into idioma_palabras(code,clave,valor) values('ES','TREE_FAMILY_EXISTS','La familia ya existe!');
insert into idioma_palabras(code,clave,valor) values('ES','USER_TREE_EDITOR_TITLE','Editor usuario/permisos');
insert into idioma_palabras(code,clave,valor) values('ES','USER_TREE_EDITOR_DESCRIP','Desde aqui podes configurar los permisos que tiene cada usuario.');
insert into idioma_palabras(code,clave,valor) values('ES','SEEL_TAX_LABEL','La venta tendra una comisión de %d.');
insert into idioma_palabras(code,clave,valor) values('ES','TAX_NETWORK_FEE_ERROR','No se puede obtener el costo de transferencia.');
insert into idioma_palabras(code,clave,valor) values('ES','WALLET_TITLE','Tús billeteras');
insert into idioma_palabras(code,clave,valor) values('ES','WALLET_DESCRIP','Aquí veras tus distintas monedas.');
insert into idioma_palabras(code,clave,valor) values('ES','WALLET_BTN_REFRESH','Actualizar');
insert into idioma_palabras(code,clave,valor) values('ES','WALLET_BTN_CLOSE','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','WALLET_MONEY','Moneda');
insert into idioma_palabras(code,clave,valor) values('ES','WALLET_ADDRESS','Dirección');
insert into idioma_palabras(code,clave,valor) values('ES','WALLET_READY_VALUE','Saldo disponible');
insert into idioma_palabras(code,clave,valor) values('ES','WALLET_PENDING_VALUE','Saldo pendiente');
insert into idioma_palabras(code,clave,valor) values('ES','MY_BUYS','Mis compras');
insert into idioma_palabras(code,clave,valor) values('ES','BUY_DATE','Fecha de compra');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_IT_USER_PERM_MANAGER','Gestionar permisos de usuarios');
insert into idioma_palabras(code,clave,valor) values('ES','LOG_ACTIV_TITLE','Actividad');
insert into idioma_palabras(code,clave,valor) values('ES','LOG_FROM_TITLE','Desde:');
insert into idioma_palabras(code,clave,valor) values('ES','LOG_TO_TITLE','Hasta:');
insert into idioma_palabras(code,clave,valor) values('ES','LOG_TEXT_TITLE','Texto:');
insert into idioma_palabras(code,clave,valor) values('ES','LOG_SEARCH_TITLE','Buscar');
insert into idioma_palabras(code,clave,valor) values('ES','LOG_SEARCH_DESCRIP','Buscar en los registros');
insert into idioma_palabras(code,clave,valor) values('ES','LOG_BTN_SEARCH','Buscar');
insert into idioma_palabras(code,clave,valor) values('ES','LOG_BTN_CLOSE','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','LOG_COL_ID','LogId');
insert into idioma_palabras(code,clave,valor) values('ES','LOG_COL_FECHA','Fecha log');
insert into idioma_palabras(code,clave,valor) values('ES','LOG_COL_USUARIO','Usuario');
insert into idioma_palabras(code,clave,valor) values('ES','LOG_COL_ACTIVIDAD','Actividad');
insert into idioma_palabras(code,clave,valor) values('ES','LOG_COL_TEXTO','Descripcion');
insert into idioma_palabras(code,clave,valor) values('ES','USR_SEARCHER','Buscador de usuarios');
insert into idioma_palabras(code,clave,valor) values('ES','USR_CONTROL_BTN_CHANGE','Ctrl. cambios');
insert into idioma_palabras(code,clave,valor) values('ES','USR_CONTROL_COL_CHANGE_TDOC','Tipo documento');
insert into idioma_palabras(code,clave,valor) values('ES','USR_CONTROL_COL_CHANGE_NUM','Número');
insert into idioma_palabras(code,clave,valor) values('ES','USR_CONTROL_COL_CHANGE_FEC_NAC','Fecha nacimiento');
insert into idioma_palabras(code,clave,valor) values('ES','USR_CONTROL_COL_CHANGRE_NUM_TRAMITE','N° operation');
insert into idioma_palabras(code,clave,valor) values('ES','USR_CONTROL_COL_CHANGE_ADDRESS','Direccón');
insert into idioma_palabras(code,clave,valor) values('ES','USR_CONTROL_COL_CHANGE_EMAIL','Email');
insert into idioma_palabras(code,clave,valor) values('ES','USR_CONTROL_COL_CHANGE_PHONE','Telefono');
insert into idioma_palabras(code,clave,valor) values('ES','USR_CONTROL_COL_CHANGE_OPERATOR','Rollback por');
insert into idioma_palabras(code,clave,valor) values('ES','FRM_CHANGE_CONTROL','Control de cambios');
insert into idioma_palabras(code,clave,valor) values('ES','FRM_CHANGE_CONTROL_BTN_RECOVE','Recuperar cambio');
insert into idioma_palabras(code,clave,valor) values('ES','USR_CHANGE_CLOSE','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','USR_TXT_CTRL_TITLE','Control de cambos');
insert into idioma_palabras(code,clave,valor) values('ES','USR_TXT_CTRL_DESCRIP','Aqui podes ver los cambios realizados y recuperarlos.');
insert into idioma_palabras(code,clave,valor) values('ES','USR_CHANGE_CONFIRM','Confirmar restore?');
insert into idioma_palabras(code,clave,valor) values('ES','USR_CHANGE_TITLE','¿Seguro deseas recuperar la entidad a este punto?');
insert into idioma_palabras(code,clave,valor) values('ES','USR_CHANGE_RESTORE_SUCCESS','Restore exitoso!');
insert into idioma_palabras(code,clave,valor) values('ES','PROFILE_TYPE_DOC','Tipo de documento:');
insert into idioma_palabras(code,clave,valor) values('ES','PROFILE_DOC_NUMBER','Número de documento:');
insert into idioma_palabras(code,clave,valor) values('ES','PROFILE_BIRTH_DATE','Fecha de nacimiento:');
insert into idioma_palabras(code,clave,valor) values('ES','PROFILE_TRAMITE','Número de tramite:');
insert into idioma_palabras(code,clave,valor) values('ES','PROFILE_ADDRESS','Dirección:');
insert into idioma_palabras(code,clave,valor) values('ES','PROFILE_PHONE','Telefono:');
insert into idioma_palabras(code,clave,valor) values('ES','PROFILE_CLOSE','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','PROFILE_OK','Guardar');
insert into idioma_palabras(code,clave,valor) values('ES','PROFILE_FORM','Perfil de cliente');
insert into idioma_palabras(code,clave,valor) values('ES','PROFILE_CBU','CBU');
insert into idioma_palabras(code,clave,valor) values('ES','TXT_BACKUP_TITLE','Backup');
insert into idioma_palabras(code,clave,valor) values('ES','TXT_BACKUP_DESCRIP','Maneje aqui la creación carga de backups.');
insert into idioma_palabras(code,clave,valor) values('ES','BTN_NEW_BACKUP','Nuevo backup');
insert into idioma_palabras(code,clave,valor) values('ES','BTN_LOAD_BACKUP','Cargar backup');
insert into idioma_palabras(code,clave,valor) values('ES','BTN_CLOSE_BACKUP','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','BACKUP_COL_PATH','Path');
insert into idioma_palabras(code,clave,valor) values('ES','BACKUP_COL_FEC','Fecha');
insert into idioma_palabras(code,clave,valor) values('ES','BACKUP_COL_TYPE','Tipo');
insert into idioma_palabras(code,clave,valor) values('ES','BACKUP_MSG_TITLE','Backup');
insert into idioma_palabras(code,clave,valor) values('ES','BACKUP_MSG_DESCRIP','¿Queres realizar un nuevo backup?');
insert into idioma_palabras(code,clave,valor) values('ES','BACKUP_MSG_RESTORE_DESCRIP','¿Queres cargar este backup?');
insert into idioma_palabras(code,clave,valor) values('ES','BACKUP_COL_SIZE','Tamaño en bytes');
insert into idioma_palabras(code,clave,valor) values('ES','TXT_BACKUP_TITLE_LIST','Estos son los backups que has realizado.');
insert into idioma_palabras(code,clave,valor) values('ES','INTEGRITY_USERS_NOT_FOUND','Violacion a la integridad, se notificara al administrador');
insert into idioma_palabras(code,clave,valor) values('ES','INTEGRITY_USERS_CORRUPT','Violacion a la integridad, se notificara al administrador');
insert into idioma_palabras(code,clave,valor) values('ES','INTEGRITY_USERS_ENTITY_FAIL','Violacion a la integridad, se notificara al administrador');
insert into idioma_palabras(code,clave,valor) values('ES','INTEGRITY_ERROR','Violacion a la integridad, se notificara al administrador');
insert into idioma_palabras(code,clave,valor) values('ES','CBU_TITLE','Consulta de CBU');
insert into idioma_palabras(code,clave,valor) values('ES','CBU_TITLE_DESCRIP','Usa esta dirección para acreditar AR$.');
insert into idioma_palabras(code,clave,valor) values('ES','WARNING_TITLE','AVISO:');
insert into idioma_palabras(code,clave,valor) values('ES','WARNING_TITLE_DESCRIP','Debes transferir del mismo CBU que tenes registrado en tú perfil.');
insert into idioma_palabras(code,clave,valor) values('ES','BTN_COPY','Copiar');
insert into idioma_palabras(code,clave,valor) values('ES','BTN_CLOSE','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','TXT_CBU','CBU:');
insert into idioma_palabras(code,clave,valor) values('ES','TXT_ALIAS','Alias:');
insert into idioma_palabras(code,clave,valor) values('ES','TXT_BANK','Banco:');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_CBU','Ver cbu');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_CBU_TITLE','Buscar CBU');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_CBU_TITLE_DESCRIP','De aqui podes buscar CBU de los clientes');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_CBU_WRITE','Escriba el CBU:');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_CBU_BTN_SEARCH','Buscar');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_CBU_BTN_CASHIN','Ingresar fondos');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_CBU_BTN_CLOSE','Cerrar');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_CBU_CLIENT','CBU');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_CBU_TDOC','Tipo doc');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_CBU_DNI','DNI');
insert into idioma_palabras(code,clave,valor) values('ES','SEARCH_CBU_EMAIL','Email');
insert into idioma_palabras(code,clave,valor) values('ES','GRAL_NO_RESULTS','No se han encontrado resultados');
insert into idioma_palabras(code,clave,valor) values('ES','GRAL_YOU_MUST_ENTER_A_VALUE','Debes ingresar un valor...');
insert into idioma_palabras(code,clave,valor) values('ES','GRAL_UNABLE_TO_PROCESS','No se pudo procesar');
insert into idioma_palabras(code,clave,valor) values('ES','GRAL_OPERATION_SUCCESS','Operación completa!');
insert into idioma_palabras(code,clave,valor) values('ES','CBU_CASHIN_TITLE','Ingresar fondos');
insert into idioma_palabras(code,clave,valor) values('ES','CBU_CASHIN_LABEL','Debe ingresar un valor en AR$');
insert into idioma_palabras(code,clave,valor) values('ES','EXTRACT_ARS_TITLE','Solicitar extracción');
insert into idioma_palabras(code,clave,valor) values('ES','EXTRACT_ARS_DESCRIP','Desde aqui solicitar enviar dinero a tu cuenta bancaria');
insert into idioma_palabras(code,clave,valor) values('ES','EXTRACT_ARS_VALUE_LABEL','Valor a extraer:');
insert into idioma_palabras(code,clave,valor) values('ES','EXTRACT_ARS_VALUE_LABEL_DESCRIP','De aqui podes pedir un retiro de dinero a tu cuenta bancaria');
insert into idioma_palabras(code,clave,valor) values('ES','EXTRACT_ARS_CBU','Tú CBU:');
insert into idioma_palabras(code,clave,valor) values('ES','EXTRACT_ARS_AMMOUNT','Saldo:');
insert into idioma_palabras(code,clave,valor) values('ES','EXTRACT_ARS_PENDING_DEBTS','Tenes comisiones pendientes de pagar');
insert into idioma_palabras(code,clave,valor) values('ES','EXTRACT_ARS_NO_FOUNDS','No tenes fondos suficientes.');
insert into idioma_palabras(code,clave,valor) values('ES','EXTRACT_ARS_OK','Operación exitosa.');
insert into idioma_palabras(code,clave,valor) values('ES','RETIRO_TITLE','Extracciones');
insert into idioma_palabras(code,clave,valor) values('ES','RETIRO_TITLE_DESCRIP','De aqui podes aprobar  / rechazar extracciones.');
insert into idioma_palabras(code,clave,valor) values('ES','BTN_RETIRO_OK','Aceptar');
insert into idioma_palabras(code,clave,valor) values('ES','BTN_RETIRO_REJECT','Rechazar');
insert into idioma_palabras(code,clave,valor) values('ES','MAIN_MENU_EXTRACT_ARS','Extracciones ARS');

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
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_START','Start');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_LOGIN','Login');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_SIGNUP','Register');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_SIGNOUT','Sign out');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_EXIT','Exit');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_OPERATE','Operate');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_RECOMENDATIONS','Recommendations');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_NOTIFICATIONS','Notifications');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_MY_WALLETS','My wallets');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_MY_SELLS','My publications');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_BUY','Buy');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_SELL','Sell');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_SEARCH','Search');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_DEPOSIT','Enter balance');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_EXTRACT','Withdraw balance');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_IT','TI');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_LOG_SEARCH','Log search');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_BACKUP','Backup');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_PERMISSION','Permissions');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_USER','Users');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_LANGUAGE','Languages');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_PROFILE','Profile');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_CASH_IN','Enter ammount');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_EXTRACT','Withdrawal AR$');
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
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_IT_BACKUP','Backup');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_TITLE','Language editor');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_DESCRIP','In this section you customize the system language.');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_NEW_LANGUAGE','New');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_REFRESH_LANGUAGE','Refresh');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_EDIT_LANGUAGE','Edit word');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_ADD_LANGUAGE','Add');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_UI_DEL_LANGUAGE','Delete');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_LANG_ALL_DELETE_CONFIRM_TITLE','Do you want to delete this language and all his words?');
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
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_COL_STATUS','Status');
insert into idioma_palabras(code,clave,valor) values('ENG','MY_SELL_ORDERS_TITLE','My sell orders');
insert into idioma_palabras(code,clave,valor) values('ENG','MY_SELL_ORDERS_PAUSE','Finish order');
insert into idioma_palabras(code,clave,valor) values('ENG','MY_SELL_FINISH_TITLE','Do you want to finish this sell order?');
insert into idioma_palabras(code,clave,valor) values('ENG','MY_SELL_FINISH_CONFIRM','Select an option');
insert into idioma_palabras(code,clave,valor) values('ENG','MY_SELL_FINISH_SUCCESS','Order finished success!');
insert into idioma_palabras(code,clave,valor) values('ENG','RECOM_TITLE','Recomendations');
insert into idioma_palabras(code,clave,valor) values('ENG','RECOM_DESCRIP','In this section you can see the purchase recommendations suitable for you.');
insert into idioma_palabras(code,clave,valor) values('ENG','RECOM_CLOSE','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','RECOM_VIEW','View');
insert into idioma_palabras(code,clave,valor) values('ENG','OP_TITLE','Order');
insert into idioma_palabras(code,clave,valor) values('ENG','OP_SELLER','Published by:');
insert into idioma_palabras(code,clave,valor) values('ENG','OP_DETAIL_LABEL','Sell order detail:');
insert into idioma_palabras(code,clave,valor) values('ENG','OP_TAX_LABEL','Taxes:');
insert into idioma_palabras(code,clave,valor) values('ENG','OP_TAX_LABEL_INFO','In this section you can see the tax list for this operation.');
insert into idioma_palabras(code,clave,valor) values('ENG','OP_BTN_BUY','Buy');
insert into idioma_palabras(code,clave,valor) values('ENG','OP_BTN_CLOSE','Cancel');
insert into idioma_palabras(code,clave,valor) values('ENG','OP_OFFER','Offer:');
insert into idioma_palabras(code,clave,valor) values('ENG','OP_REQ','For:');
insert into idioma_palabras(code,clave,valor) values('ENG','OP_TOTAL','Final balance:');
insert into idioma_palabras(code,clave,valor) values('ENG','TAX_PLATFORM_FOR_BUY','Platform fee for this operation');
insert into idioma_palabras(code,clave,valor) values('ENG','TAX_PLATFORM_FOR_SELL','Platform fee for this operation');
insert into idioma_palabras(code,clave,valor) values('ENG','TAX_NETWORK_FEE','Network transference fee');
insert into idioma_palabras(code,clave,valor) values('ENG','NOTIF_TITLE','Notifications');
insert into idioma_palabras(code,clave,valor) values('ENG','NOTIF_DESCRIP','This are your notifications');
insert into idioma_palabras(code,clave,valor) values('ENG','NOTIF_CLOSE','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','NOTIF_DATE','Date');
insert into idioma_palabras(code,clave,valor) values('ENG','NOTIF_TEXT','Message');
insert into idioma_palabras(code,clave,valor) values('ENG','NOTIF_BUY_SUCCESS','Congratulations, your order was buy by %c');
insert into idioma_palabras(code,clave,valor) values('ENG','NOTIF_BUY_OK_SUCCESS','Hi %c! the purchase of your order was successful!');
insert into idioma_palabras(code,clave,valor) values('ENG','BUY_SUCCESS','You have purchased the order, wait some minutes to see the balance updated in your wallet!');
insert into idioma_palabras(code,clave,valor) values('ENG','BUY_ERROR','An error has produced buying the order..');
insert into idioma_palabras(code,clave,valor) values('ENG','TEMPLATE_EDITOR','Dictionary edit');
insert into idioma_palabras(code,clave,valor) values('ENG','TEMPLATE_EDITOR_ADD','Add key');
insert into idioma_palabras(code,clave,valor) values('ENG','TEMPLATE_EDITOR_DELETE','Delete key');
insert into idioma_palabras(code,clave,valor) values('ENG','TEMPLATE_CONFIRM_DELETE','Do you want to delete this key and in the associated languages?');
insert into idioma_palabras(code,clave,valor) values('ENG','TEMPLATE_EDITOR_ADD_OK','Key created ok!');
insert into idioma_palabras(code,clave,valor) values('ENG','TEMPLATE_EDITOR_DELETE_OK','Key deleted ok!');
insert into idioma_palabras(code,clave,valor) values('ENG','EDIT_PATENTE_TITLE','Patent editor');
insert into idioma_palabras(code,clave,valor) values('ENG','EDIT_PATENTE_DESCRIP','You can manage the patents here.');
insert into idioma_palabras(code,clave,valor) values('ENG','EDIT_PATENTE_SELECTOR_TITLE','Choose a patent');
insert into idioma_palabras(code,clave,valor) values('ENG','EDIT_PATENTE_SELECTOR_DESCRIP','You can choose a patent here');
insert into idioma_palabras(code,clave,valor) values('ENG','EDIT_FAMILY_SELECTOR_TITLE','Choose a family');
insert into idioma_palabras(code,clave,valor) values('ENG','EDIT_FAMILY_SELECTOR_DESCRIP','You can choose a family here');
insert into idioma_palabras(code,clave,valor) values('ENG','COMP_CRUD_TITLE_FAMILY','Edit family');
insert into idioma_palabras(code,clave,valor) values('ENG','COMP_CRUD_TITLE_PATENT','Edit patents');
insert into idioma_palabras(code,clave,valor) values('ENG','COMP_CRUD_DESCRIPTION','You can edit and add data from here');
insert into idioma_palabras(code,clave,valor) values('ENG','COMP_CRUD_ADD','Add');
insert into idioma_palabras(code,clave,valor) values('ENG','COMP_CRUD_CLOSE','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','COMP_CRUD_DELETE','Delete');
insert into idioma_palabras(code,clave,valor) values('ENG','COMP_CRUD_ADD_VALUE','Add new value');
insert into idioma_palabras(code,clave,valor) values('ENG','COMP_CRUD_ADD_DESCRIP','Complete the value here');
insert into idioma_palabras(code,clave,valor) values('ENG','COMP_CRUD_DELETE_TITLE','Delete');
insert into idioma_palabras(code,clave,valor) values('ENG','COMP_CRUD_DELETE_CONFIRM','Do you want to delete this value?');
insert into idioma_palabras(code,clave,valor) values('ENG','COMP_CRUD_DELETE_OK','Delete ok!');
insert into idioma_palabras(code,clave,valor) values('ENG','TREE_TITLE_EDITOR','Permission editor');
insert into idioma_palabras(code,clave,valor) values('ENG','TREE_DESCRIP_EDITOR','Remember you edit the familys separatedly');
insert into idioma_palabras(code,clave,valor) values('ENG','TREE_CRUD_FAMILY','CRUD Family');
insert into idioma_palabras(code,clave,valor) values('ENG','TREE_CRUD_PATENT','CRUD patent');
insert into idioma_palabras(code,clave,valor) values('ENG','TREE_CRUD_VIEW','View');
insert into idioma_palabras(code,clave,valor) values('ENG','TREE_CRUD_ADD_FAMILY','+ Family');
insert into idioma_palabras(code,clave,valor) values('ENG','TREE_CRUD_ADD_PATENT','+ Patent');
insert into idioma_palabras(code,clave,valor) values('ENG','TREE_CRUD_SAVE','Save');
insert into idioma_palabras(code,clave,valor) values('ENG','TREE_CRUD_CLOSE','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','TREE_CRUD_DELETE','Delete');
insert into idioma_palabras(code,clave,valor) values('ENG','TREE_PATENT_EXISTS','The patent already exists!');
insert into idioma_palabras(code,clave,valor) values('ENG','TREE_FAMILY_EXISTS','The family already exists!');
insert into idioma_palabras(code,clave,valor) values('ENG','USER_TREE_EDITOR_TITLE','User/permission editor');
insert into idioma_palabras(code,clave,valor) values('ENG','USER_TREE_EDITOR_DESCRIP','You can edit from this module, the permission of each user.');
insert into idioma_palabras(code,clave,valor) values('ENG','SEEL_TAX_LABEL','The tax operation is %d.');
insert into idioma_palabras(code,clave,valor) values('ENG','TAX_NETWORK_FEE_ERROR','Unable to fetch transaction fee.');
insert into idioma_palabras(code,clave,valor) values('ENG','WALLET_TITLE','Your wallets');
insert into idioma_palabras(code,clave,valor) values('ENG','WALLET_DESCRIP','You will see your moneys.');
insert into idioma_palabras(code,clave,valor) values('ENG','WALLET_BTN_REFRESH','Refresh');
insert into idioma_palabras(code,clave,valor) values('ENG','WALLET_BTN_CLOSE','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','WALLET_MONEY','Money');
insert into idioma_palabras(code,clave,valor) values('ENG','WALLET_ADDRESS','Address');
insert into idioma_palabras(code,clave,valor) values('ENG','WALLET_READY_VALUE','Available balance');
insert into idioma_palabras(code,clave,valor) values('ENG','WALLET_PENDING_VALUE','Pending balance');
insert into idioma_palabras(code,clave,valor) values('ENG','MY_BUYS','My buys');
insert into idioma_palabras(code,clave,valor) values('ENG','BUY_DATE','Buy date');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_IT_USER_PERM_MANAGER','Manage user permission');
insert into idioma_palabras(code,clave,valor) values('ENG','LOG_ACTIV_TITLE','Activation tag');
insert into idioma_palabras(code,clave,valor) values('ENG','LOG_FROM_TITLE','From:');
insert into idioma_palabras(code,clave,valor) values('ENG','LOG_TO_TITLE','To:');
insert into idioma_palabras(code,clave,valor) values('ENG','LOG_TEXT_TITLE','Text:');
insert into idioma_palabras(code,clave,valor) values('ENG','LOG_SEARCH_TITLE','Search');
insert into idioma_palabras(code,clave,valor) values('ENG','LOG_SEARCH_DESCRIP','Search in the log database');
insert into idioma_palabras(code,clave,valor) values('ENG','LOG_BTN_SEARCH','Search');
insert into idioma_palabras(code,clave,valor) values('ENG','LOG_BTN_CLOSE','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','LOG_COL_ID','LogId');
insert into idioma_palabras(code,clave,valor) values('ENG','LOG_COL_FECHA','Log date');
insert into idioma_palabras(code,clave,valor) values('ENG','LOG_COL_USUARIO','User');
insert into idioma_palabras(code,clave,valor) values('ENG','LOG_COL_ACTIVIDAD','Activity');
insert into idioma_palabras(code,clave,valor) values('ENG','LOG_COL_TEXTO','Description');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_SEARCHER','User searcher');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_CONTROL_BTN_CHANGE','Change ctrl.');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_CONTROL_COL_CHANGE_TDOC','Doc type');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_CONTROL_COL_CHANGE_NUM','Number');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_CONTROL_COL_CHANGE_FEC_NAC','Birth date');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_CONTROL_COL_CHANGRE_NUM_TRAMITE','N° operation');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_CONTROL_COL_CHANGE_ADDRESS','Address');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_CONTROL_COL_CHANGE_EMAIL','Email');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_CONTROL_COL_CHANGE_PHONE','Phone');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_CONTROL_COL_CHANGE_OPERATOR','Rollback by');
insert into idioma_palabras(code,clave,valor) values('ENG','FRM_CHANGE_CONTROL','Changes control');
insert into idioma_palabras(code,clave,valor) values('ENG','FRM_CHANGE_CONTROL_BTN_RECOVE','Restore changes');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_CHANGE_CLOSE','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_TXT_CTRL_TITLE','Changes control');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_TXT_CTRL_DESCRIP','Here you can see the entity changes and restore if you want.');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_CHANGE_CONFIRM','Confirm restore');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_CHANGE_TITLE','Do you want to restore the entity at this point?');
insert into idioma_palabras(code,clave,valor) values('ENG','USR_CHANGE_RESTORE_SUCCESS','Restore success!');
insert into idioma_palabras(code,clave,valor) values('ENG','PROFILE_TYPE_DOC','Document type:');
insert into idioma_palabras(code,clave,valor) values('ENG','PROFILE_DOC_NUMBER','Id number:');
insert into idioma_palabras(code,clave,valor) values('ENG','PROFILE_BIRTH_DATE','Birth Date:');
insert into idioma_palabras(code,clave,valor) values('ENG','PROFILE_TRAMITE','Tramit number:');
insert into idioma_palabras(code,clave,valor) values('ENG','PROFILE_ADDRESS','Address:');
insert into idioma_palabras(code,clave,valor) values('ENG','PROFILE_PHONE','Phone number:');
insert into idioma_palabras(code,clave,valor) values('ENG','PROFILE_CLOSE','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','PROFILE_OK','Save');
insert into idioma_palabras(code,clave,valor) values('ENG','PROFILE_FORM','Client profile');
insert into idioma_palabras(code,clave,valor) values('ENG','PROFILE_CBU','CBU');
insert into idioma_palabras(code,clave,valor) values('ENG','TXT_BACKUP_TITLE','Backup');
insert into idioma_palabras(code,clave,valor) values('ENG','TXT_BACKUP_DESCRIP','Manage here the system backups.');
insert into idioma_palabras(code,clave,valor) values('ENG','BTN_NEW_BACKUP','New backup');
insert into idioma_palabras(code,clave,valor) values('ENG','BTN_LOAD_BACKUP','Load backup');
insert into idioma_palabras(code,clave,valor) values('ENG','BTN_CLOSE_BACKUP','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','BACKUP_COL_PATH','Path');
insert into idioma_palabras(code,clave,valor) values('ENG','BACKUP_COL_FEC','Date');
insert into idioma_palabras(code,clave,valor) values('ENG','BACKUP_COL_TYPE','Type');
insert into idioma_palabras(code,clave,valor) values('ENG','BACKUP_MSG_TITLE','Backup');
insert into idioma_palabras(code,clave,valor) values('ENG','BACKUP_MSG_DESCRIP','Do you want to make a new backup?');
insert into idioma_palabras(code,clave,valor) values('ENG','BACKUP_MSG_RESTORE_DESCRIP','Do you want to restore to this backup?');
insert into idioma_palabras(code,clave,valor) values('ENG','BACKUP_COL_SIZE','File size in bytes');
insert into idioma_palabras(code,clave,valor) values('ENG','TXT_BACKUP_TITLE_LIST','Your previous backups.');
insert into idioma_palabras(code,clave,valor) values('ENG','INTEGRITY_USERS_NOT_FOUND','Violation of integrity, the administrator will be notified');
insert into idioma_palabras(code,clave,valor) values('ENG','INTEGRITY_USERS_CORRUPT','Violation of integrity, the administrator will be notified');
insert into idioma_palabras(code,clave,valor) values('ENG','INTEGRITY_USERS_ENTITY_FAIL','Violation of integrity, the administrator will be notified');
insert into idioma_palabras(code,clave,valor) values('ENG','INTEGRITY_ERROR','Violation of integrity, the administrator will be notified');
insert into idioma_palabras(code,clave,valor) values('ENG','CBU_TITLE','CBU Query');
insert into idioma_palabras(code,clave,valor) values('ENG','CBU_TITLE_DESCRIP','Use this address to make AR$ cash in.');
insert into idioma_palabras(code,clave,valor) values('ENG','WARNING_TITLE','AVISO:');
insert into idioma_palabras(code,clave,valor) values('ENG','WARNING_TITLE_DESCRIP','You must transfer using the same CBU registerd in your profile.');
insert into idioma_palabras(code,clave,valor) values('ENG','BTN_COPY','Copy');
insert into idioma_palabras(code,clave,valor) values('ENG','BTN_CLOSE','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','TXT_CBU','CBU:');
insert into idioma_palabras(code,clave,valor) values('ENG','TXT_ALIAS','Alias:');
insert into idioma_palabras(code,clave,valor) values('ENG','TXT_BANK','Banck:');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_CBU','See bank codes');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_CBU_TITLE','Search CBU');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_CBU_TITLE_DESCRIP','Find cbu clients from here:');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_CBU_WRITE','Write the CBU:');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_CBU_BTN_SEARCH','Search');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_CBU_BTN_CASHIN','Enter founds');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_CBU_BTN_CLOSE','Close');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_CBU_CLIENT','CBU');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_CBU_TDOC','Doc type');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_CBU_DNI','DNI');
insert into idioma_palabras(code,clave,valor) values('ENG','SEARCH_CBU_EMAIL','Email');
insert into idioma_palabras(code,clave,valor) values('ENG','GRAL_NO_RESULTS','Results not found');
insert into idioma_palabras(code,clave,valor) values('ENG','GRAL_YOU_MUST_ENTER_A_VALUE','You must enter a value..');
insert into idioma_palabras(code,clave,valor) values('ENG','GRAL_UNABLE_TO_PROCESS','Unable to process');
insert into idioma_palabras(code,clave,valor) values('ENG','GRAL_OPERATION_SUCCESS','Operation success!');
insert into idioma_palabras(code,clave,valor) values('ENG','CBU_CASHIN_TITLE','Enter value');
insert into idioma_palabras(code,clave,valor) values('ENG','CBU_CASHIN_LABEL','You must enter AR$ ammount');
insert into idioma_palabras(code,clave,valor) values('ENG','EXTRACT_ARS_TITLE','Request extraction');
insert into idioma_palabras(code,clave,valor) values('ENG','EXTRACT_ARS_DESCRIP','From here request to send money to your bank account');
insert into idioma_palabras(code,clave,valor) values('ENG','EXTRACT_ARS_VALUE_LABEL','Value to extract:');
insert into idioma_palabras(code,clave,valor) values('ENG','EXTRACT_ARS_VALUE_LABEL_DESCRIP','From here you can request a withdrawal of money to your bank account');
insert into idioma_palabras(code,clave,valor) values('ENG','EXTRACT_ARS_CBU','Your CBU:');
insert into idioma_palabras(code,clave,valor) values('ENG','EXTRACT_ARS_AMMOUNT','Ammount:');
insert into idioma_palabras(code,clave,valor) values('ENG','EXTRACT_ARS_PENDING_DEBTS','You have commision pending to payment');
insert into idioma_palabras(code,clave,valor) values('ENG','EXTRACT_ARS_NO_FOUNDS','No founds');
insert into idioma_palabras(code,clave,valor) values('ENG','EXTRACT_ARS_OK','Operation success!.');
insert into idioma_palabras(code,clave,valor) values('ENG','RETIRO_TITLE','Withdrawal');
insert into idioma_palabras(code,clave,valor) values('ENG','RETIRO_TITLE_DESCRIP','You can approve / reject orders from here.');
insert into idioma_palabras(code,clave,valor) values('ENG','BTN_RETIRO_OK','Acept');
insert into idioma_palabras(code,clave,valor) values('ENG','btn_retiro_reject','Reject');
insert into idioma_palabras(code,clave,valor) values('ENG','MAIN_MENU_EXTRACT_ARS','Withadrawal AR$');

select * from cliente where idcliente=1;
select * from billetera where idcliente=1 and moneda='ARS';
--0070064130004043181234

select * from solic_operacion
select * from tipo_solic_op
select * from comisiones

--update usuario set hash='11d71138d9ddee37d1fcce5aedec3ce4' where idusuario=1;
update dvv set hash='11d71138d9ddee37d1fcce5aedec3ce4582c2f81866583e1c388e94d98a94ac1249f35576f57e0b3ee2c4a24f5e904644ace166b6ebac5a0a7fc65215355b02fb02d434351c4222e8d4179fe345dc855b1d54b9d8f892ad6148242b19c2de8bfc5bda982841d0102af928a5785c49eed227a682048f0337ba2630c1a9a39c18e7770fda546695217e9260a2f2ff3fb99'
--update dvv set hash='b35965ae5f527639882c56524f0624af582c2f81866583e1c388e94d98a94ac1249f35576f57e0b3ee2c4a24f5e904644ace166b6ebac5a0a7fc65215355b02fb02d434351c4222e8d4179fe345dc855b1d54b9d8f892ad6148242b19c2de8bfc5bda982841d0102af928a5785c49eed227a682048f0337ba2630c1a9a39c18e7770fda546695217e9260a2f2ff3fb99'

select * from dvv
select * from cuentas
select * from cliente
select * from comisiones

select * from comisiones where  idcliente=1 and processed=0;
select * from solic_operacion where  estado_solic=2;

--update comisiones set processed=1
select * from tipo_solic_op
select idoperacion,alias,tipo_solic,cbu,valor from solic_operacion;
select * from solic_estados

insert into solic_operacion(idusuario,tipo_solic,idwallet,valor,cbu,operador,estado_solic,fecRegistro,fecProceso) values(1,0,1,100,'0070064130004043181234',0,0,'01/11/2021 17:36:49','01/01/0001 0:00:00');SELECT @@IDENTITY;

insert into comisiones(tipo_operacion,referencia,idcliente,idwallet,moneda,valor,fecCobro,processed)
values(1,1,1,1,'ARS',100,NULL,0);