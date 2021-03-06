USE master
GO
DROP database if exists Crypton_BD
GO
CREATE DATABASE Crypton_BD 
    ON (NAME = N'Crypton', FILENAME = N'C:\Crypton_bd_.mdf', SIZE = 1024MB, FILEGROWTH = 256MB)
LOG ON (NAME = N'Crypton_log', FILENAME = N'C:\Crypton_bd_log.ldf', SIZE = 512MB, FILEGROWTH = 125MB)
GO
USE [Crypton_BD]
GO
/****** Object:  Table [dbo].[admin_backup]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin_backup](
	[idbackup] [int] IDENTITY(1,1) NOT NULL,
	[idusuario] [bigint] NULL,
	[path] [varchar](100) NULL,
	[fecRec] [datetime] NULL,
	[type] [varchar](100) NULL,
	[deleted] [datetime] NULL,
	[size] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[idbackup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[api_keys]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[api_keys](
	[ambiente] [varchar](10) NULL,
	[btc] [varchar](50) NULL,
	[ltc] [varchar](50) NULL,
	[dog] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[banco_data]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[banco_data](
	[idbanco] [bigint] IDENTITY(1,1) NOT NULL,
	[cbu] [varchar](100) NULL,
	[nombre] [varchar](100) NULL,
	[alias] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idbanco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[billetera]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[billetera](
	[idwallet] [bigint] IDENTITY(1,1) NOT NULL,
	[idcliente] [bigint] NULL,
	[idcuenta] [bigint] NULL,
	[moneda] [varchar](10) NULL,
	[direccion] [varchar](50) NULL,
	[fecCreacion] [datetime] NULL,
	[saldo] [varchar](12) NULL,
	[deleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idwallet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bitacora]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bitacora](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[idusuario] [bigint] NULL,
	[fec_log] [datetime] NULL,
	[activity] [varchar](150) NULL,
	[payload] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clienta_agenda]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clienta_agenda](
	[idcontacto] [bigint] IDENTITY(1,1) NOT NULL,
	[idcliente] [bigint] NULL,
	[moneda] [varchar](10) NOT NULL,
	[valor] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idcontacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[idcliente] [bigint] IDENTITY(1,1) NOT NULL,
	[idusuario] [bigint] NULL,
	[tipoDoc] [varchar](10) NULL,
	[numero] [varchar](100) NULL,
	[fec_nac] [datetime] NULL,
	[num_tramite] [varchar](50) NULL,
	[domicilio] [varchar](100) NULL,
	[telefono] [varchar](100) NULL,
	[valido] [varchar](1) NULL,
	[deleted] [datetime] NULL,
	[cbu] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente_agenda]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente_agenda](
	[idcontacto] [bigint] IDENTITY(1,1) NOT NULL,
	[idcliente] [bigint] NULL,
	[moneda] [varchar](10) NOT NULL,
	[valor] [varchar](100) NULL,
	[deleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idcontacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cliente_cambios]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente_cambios](
	[idchange] [bigint] IDENTITY(1,1) NOT NULL,
	[change_date] [datetime] NULL,
	[idcliente] [bigint] NULL,
	[tipoDoc] [varchar](10) NULL,
	[numero] [varchar](100) NULL,
	[fec_nac] [datetime] NULL,
	[num_tramite] [varchar](50) NULL,
	[domicilio] [varchar](100) NULL,
	[telefono] [varchar](100) NULL,
	[cbu] [varchar](50) NULL,
	[rollback_user] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[idchange] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comision_operacion_valor]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comision_operacion_valor](
	[idope] [bigint] IDENTITY(1,1) NOT NULL,
	[descrip] [varchar](100) NULL,
	[valor] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[idope] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comisiones]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comisiones](
	[idcobro] [bigint] IDENTITY(1,1) NOT NULL,
	[tipo_operacion] [int] NULL,
	[referencia] [bigint] NULL,
	[idcliente] [bigint] NULL,
	[idwallet] [bigint] NULL,
	[moneda] [varchar](10) NULL,
	[valor] [float] NULL,
	[fecCobro] [datetime] NULL,
	[processed] [int] NULL,
	[deleted] [datetime] NULL,
	[fecRegister] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idcobro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[conversiones]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[conversiones](
	[idconversion] [bigint] IDENTITY(1,1) NOT NULL,
	[codCripto] [varchar](10) NULL,
	[cantCripto] [float] NULL,
	[valorUSD] [float] NULL,
	[deleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idconversion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuenta_estado]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuenta_estado](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[descrip] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuentas]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentas](
	[idcuenta] [bigint] IDENTITY(1,1) NOT NULL,
	[cliente] [bigint] NULL,
	[fecAlta] [datetime] NULL,
	[estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idcuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dvv]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dvv](
	[tabla] [varchar](100) NOT NULL,
	[hash] [text] NULL,
	[fecUpdate] [datetime] NULL,
	[deleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[tabla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[empleado]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleado](
	[idempleado] [bigint] IDENTITY(1,1) NOT NULL,
	[idusuario] [bigint] NULL,
	[legajo] [varchar](100) NULL,
	[deleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idempleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[idioma_palabras]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[idioma_palabras](
	[code] [varchar](50) NOT NULL,
	[clave] [varchar](50) NOT NULL,
	[valor] [varchar](100) NULL,
	[deleted] [datetime] NULL,
 CONSTRAINT [pk_idioma_palabra] PRIMARY KEY CLUSTERED 
(
	[code] ASC,
	[clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[idiomas]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[idiomas](
	[code] [varchar](50) NOT NULL,
	[descripcion] [varchar](100) NULL,
	[deleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[moneda]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[moneda](
	[cod] [varchar](10) NOT NULL,
	[descrip] [varchar](100) NULL,
	[deleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[notificaciones]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notificaciones](
	[idnotification] [bigint] IDENTITY(1,1) NOT NULL,
	[idcliente] [bigint] NULL,
	[payload] [text] NULL,
	[fecRegistro] [datetime] NULL,
	[marked] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idnotification] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[onboarding_estados]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[onboarding_estados](
	[idestado] [int] IDENTITY(1,1) NOT NULL,
	[descrip] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idestado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orden_compra]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orden_compra](
	[idcompra] [int] IDENTITY(1,1) NOT NULL,
	[idorden] [bigint] NULL,
	[fecOperacion] [datetime] NULL,
	[comprador] [bigint] NULL,
	[cantidad] [varchar](12) NULL,
	[moneda] [varchar](10) NULL,
	[deleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idcompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orden_estado]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orden_estado](
	[ídtipo] [int] IDENTITY(1,1) NOT NULL,
	[descrip] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ídtipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orden_venta]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orden_venta](
	[idorden] [bigint] IDENTITY(1,1) NOT NULL,
	[vendedor] [bigint] NULL,
	[cantidad] [varchar](12) NULL,
	[ofrece] [varchar](10) NULL,
	[pide] [varchar](10) NULL,
	[precio] [varchar](12) NULL,
	[fecCreacion] [datetime] NULL,
	[fecFin] [datetime] NULL,
	[ordenEstado] [int] NULL,
	[deleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idorden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[palabras]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[palabras](
	[word] [varchar](50) NOT NULL,
	[fecCreation] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[word] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permiso]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permiso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[permiso] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[permiso_permiso]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permiso_permiso](
	[id_permiso_padre] [int] NULL,
	[id_permiso_hijo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[solic_estados]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[solic_estados](
	[idestado] [bigint] IDENTITY(1,1) NOT NULL,
	[descrip] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idestado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[solic_ingreso]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[solic_ingreso](
	[idingreso] [bigint] IDENTITY(1,1) NOT NULL,
	[idusuario] [bigint] NULL,
	[idwallet] [bigint] NULL,
	[valor] [float] NULL,
	[fecSolic] [datetime] NULL,
	[origen] [varchar](50) NULL,
	[revisor] [bigint] NULL,
	[estado_solic] [int] NULL,
	[fecProceso] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[solic_onboarding]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[solic_onboarding](
	[idsolic] [bigint] IDENTITY(1,1) NOT NULL,
	[fecSolic] [datetime] NULL,
	[idusuario] [bigint] NULL,
	[img_frente] [varchar](100) NULL,
	[img_dorso] [varchar](100) NULL,
	[img_selfie] [varchar](100) NULL,
	[solic_estado] [int] NULL,
	[fecProceso] [datetime] NULL,
	[operador] [bigint] NULL,
	[deleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idsolic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[solic_operacion]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[solic_operacion](
	[idoperacion] [bigint] IDENTITY(1,1) NOT NULL,
	[idusuario] [bigint] NULL,
	[tipo_solic] [int] NULL,
	[idwallet] [bigint] NULL,
	[valor] [float] NULL,
	[cbu] [varchar](50) NULL,
	[operador] [bigint] NULL,
	[estado_solic] [int] NULL,
	[fecRegistro] [datetime] NULL,
	[fecProceso] [datetime] NULL,
	[deleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idoperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[solic_retiro]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[solic_retiro](
	[idretiro] [bigint] IDENTITY(1,1) NOT NULL,
	[idusuario] [bigint] NULL,
	[idwallet] [bigint] NULL,
	[valor] [float] NULL,
	[fecSolic] [datetime] NULL,
	[cbu] [varchar](50) NULL,
	[operador] [bigint] NULL,
	[estado_solic] [int] NULL,
	[fecProceso] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idretiro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_solic_op]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_solic_op](
	[idtiposolic] [bigint] IDENTITY(1,1) NOT NULL,
	[descrip] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idtiposolic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_usuario]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_usuario](
	[tipo_usuario] [int] IDENTITY(1,1) NOT NULL,
	[descrip] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[tipo_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transferencias]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transferencias](
	[idtransf] [bigint] IDENTITY(1,1) NOT NULL,
	[fecProc] [datetime] NULL,
	[cliente] [bigint] NULL,
	[origen] [bigint] NULL,
	[destino] [bigint] NULL,
	[valor] [float] NULL,
	[moneda] [varchar](10) NULL,
	[idorden] [bigint] NULL,
	[deleted] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idtransf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[idusuario] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[apellido] [varchar](100) NULL,
	[alias] [varchar](50) NULL,
	[email] [varchar](100) NULL,
	[tipo_usuario] [int] NULL,
	[pwd] [varchar](100) NOT NULL,
	[hash] [text] NULL,
	[deleted] [datetime] NULL,
	[estado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_bloq]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_bloq](
	[idbloq] [bigint] IDENTITY(1,1) NOT NULL,
	[idusuario] [bigint] NULL,
	[motivo] [varchar](200) NULL,
	[fecBloq] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idbloq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_cliente]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_cliente](
	[idcliente] [bigint] IDENTITY(1,1) NOT NULL,
	[idusuario] [bigint] NULL,
	[nombre] [varchar](100) NULL,
	[apellido] [varchar](100) NULL,
	[numero] [varchar](100) NULL,
	[fec_nac] [varchar](20) NULL,
	[num_tramite] [varchar](50) NULL,
	[domicilio] [varchar](100) NULL,
	[email] [varchar](100) NULL,
	[telefono] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_contactos]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_contactos](
	[idcontacto] [bigint] IDENTITY(1,1) NOT NULL,
	[idcliente] [bigint] NULL,
	[moneda] [varchar](10) NOT NULL,
	[valor] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idcontacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario_estado]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_estado](
	[idestado] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idestado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios_permisos]    Script Date: 30/11/2021 6:23:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios_permisos](
	[id_usuario] [int] NOT NULL,
	[id_permiso] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[admin_backup] ON 

INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (1, 5, N'C:\\Crypton_BD_backup_10.24.2021.22.39.16.bak', CAST(N'2021-10-24T22:39:16.527' AS DateTime), N'BACKUP', NULL, 5627904)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (2, 5, N'C:\Users\54116\Desktop\Crypton_BD_backup_09.18.2021.13.03.56.bak', CAST(N'2021-09-18T13:03:56.543' AS DateTime), N'BACKUP', NULL, NULL)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (3, 5, N'C:\Users\54116\Desktop\Crypton_BD_backup_09.18.2021.13.04.54.bak', CAST(N'2021-09-18T13:04:54.230' AS DateTime), N'BACKUP', NULL, NULL)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (4, 5, N'C:\Users\54116\Documents\Crypton_BD_backup_09.20.2021.21.29.40.bak', CAST(N'2021-09-20T21:29:40.873' AS DateTime), N'BACKUP', NULL, NULL)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (5, 5, N'C:\Users\54116\Desktop\Crypton_BD_backup_09.20.2021.21.33.39.bak', CAST(N'2021-09-20T21:33:39.567' AS DateTime), N'BACKUP', NULL, NULL)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (6, 5, N'C:\\Crypton_BD_backup_10.15.2021.19.38.13.bak', CAST(N'2021-10-15T19:38:13.003' AS DateTime), N'BACKUP', NULL, NULL)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (10, 5, N'C:\\Crypton_BD_backup_10.24.2021.22.25.02.bak', CAST(N'2021-10-24T22:25:02.180' AS DateTime), N'BACKUP', NULL, 0)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (11, 5, N'C:\\Crypton_BD_backup_10.24.2021.22.27.40.bak', CAST(N'2021-10-24T22:27:40.243' AS DateTime), N'BACKUP', NULL, 0)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (12, 5, N'C:\\Crypton_BD_backup_10.24.2021.22.30.24.bak', CAST(N'2021-10-24T22:30:24.650' AS DateTime), N'BACKUP', NULL, 0)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (13, 5, N'C:\\Crypton_BD_backup_10.24.2021.22.31.37.bak', CAST(N'2021-10-24T22:31:37.487' AS DateTime), N'BACKUP', NULL, 0)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (14, 5, N'C:\\Crypton_BD_backup_10.24.2021.22.35.36.bak', CAST(N'2021-10-24T22:35:36.767' AS DateTime), N'BACKUP', NULL, 0)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (15, 5, N'C:\\Crypton_BD_backup_10.24.2021.22.37.36.bak', CAST(N'2021-10-24T22:37:36.677' AS DateTime), N'BACKUP', NULL, 0)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (16, 5, N'C:\\Crypton_BD_backup_10.24.2021.22.37.52.bak', CAST(N'2021-10-24T22:37:52.490' AS DateTime), N'BACKUP', NULL, 0)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (17, 5, N'C:\\Crypton_BD_backup_10.24.2021.22.39.16.bak', CAST(N'2021-10-24T22:39:16.527' AS DateTime), N'BACKUP', NULL, 0)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (18, 5, N'C:\\Crypton_BD_backup_10.24.2021.22.40.20.bak', CAST(N'2021-10-24T22:40:20.920' AS DateTime), N'BACKUP', NULL, 5627904)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (19, 5, N'C:\\Crypton_BD_backup_10.25.2021.00.07.44.bak', CAST(N'2021-10-25T00:07:44.290' AS DateTime), N'BACKUP', NULL, 0)
INSERT [dbo].[admin_backup] ([idbackup], [idusuario], [path], [fecRec], [type], [deleted], [size]) VALUES (20, 5, N'C:\\Crypton_BD_backup_11.05.2021.17.19.16.bak', CAST(N'2021-11-05T17:19:16.847' AS DateTime), N'BACKUP', NULL, 0)
SET IDENTITY_INSERT [dbo].[admin_backup] OFF
GO
INSERT [dbo].[api_keys] ([ambiente], [btc], [ltc], [dog]) VALUES (N'TEST_1', N'70d1-1c21-b76c-fb00', N'34e3-4277-7289-6fd6', N'7c02-9d46-b312-25ef')
INSERT [dbo].[api_keys] ([ambiente], [btc], [ltc], [dog]) VALUES (N'TEST_2', N'7ebe-8f45-4490-37d4', N'8e15-55be-cccd-b33c', N'cece-b117-15ca-e13d')
INSERT [dbo].[api_keys] ([ambiente], [btc], [ltc], [dog]) VALUES (N'TEST_3', N'445a-3f29-2ac6-1193', N'81ae-7b52-0529-5eb2', N'b5a7-8ef5-79da-85c7')
INSERT [dbo].[api_keys] ([ambiente], [btc], [ltc], [dog]) VALUES (N'PROD', N'6195-52ea-f8fb-dfc1', N'b311-ecc3-0e70-3c50', N'611f-3c58-e739-3378')
GO
SET IDENTITY_INSERT [dbo].[banco_data] ON 

INSERT [dbo].[banco_data] ([idbanco], [cbu], [nombre], [alias]) VALUES (1, N'0070064130004043187745', N'Banco Galicia', N'Crypton_BD.ars')
SET IDENTITY_INSERT [dbo].[banco_data] OFF
GO
SET IDENTITY_INSERT [dbo].[billetera] ON 

INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (1, 1, 1, N'ARS', N'1-20210917053953248-1', CAST(N'2021-09-17T05:39:53.247' AS DateTime), N'998300', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (2, 1, 1, N'BTC', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:39:53.280' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (3, 1, 1, N'LTC', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:39:53.307' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (4, 1, 1, N'DOG', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:39:53.327' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (5, 2, 2, N'ARS', N'2-20210917054034519-2', CAST(N'2021-09-17T05:40:34.520' AS DateTime), N'600', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (6, 2, 2, N'BTC', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:40:34.543' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (7, 2, 2, N'LTC', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:40:34.563' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (8, 2, 2, N'DOG', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:40:34.587' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (9, 3, 3, N'ARS', N'3-20210917054111257-3', CAST(N'2021-09-17T05:41:11.257' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (10, 3, 3, N'BTC', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:41:11.280' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (11, 3, 3, N'LTC', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:41:11.300' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (12, 3, 3, N'DOG', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:41:11.337' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (13, 4, 4, N'ARS', N'4-20210917054154504-4', CAST(N'2021-09-17T05:41:54.503' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (14, 4, 4, N'BTC', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:41:54.530' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (15, 4, 4, N'LTC', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:41:54.550' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (16, 4, 4, N'DOG', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:41:54.573' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (17, 5, 5, N'ARS', N'5-20210917054322188-5', CAST(N'2021-09-17T05:43:22.187' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (18, 5, 5, N'BTC', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:43:22.223' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (19, 5, 5, N'LTC', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:43:22.247' AS DateTime), N'0', NULL)
INSERT [dbo].[billetera] ([idwallet], [idcliente], [idcuenta], [moneda], [direccion], [fecCreacion], [saldo], [deleted]) VALUES (20, 5, 5, N'DOG', N'2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC', CAST(N'2021-09-17T05:43:22.277' AS DateTime), N'0', NULL)
SET IDENTITY_INSERT [dbo].[billetera] OFF
GO
SET IDENTITY_INSERT [dbo].[bitacora] ON 

INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (1, 1, CAST(N'2021-09-17T05:39:16.970' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (2, 1, CAST(N'2021-09-17T05:39:53.253' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en ars pesos id:1')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (3, 1, CAST(N'2021-09-17T05:39:53.273' AS DateTime), N'SIGNUP', N'Se ha creado :BTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (4, 1, CAST(N'2021-09-17T05:39:53.287' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en bitcoin:2')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (5, 1, CAST(N'2021-09-17T05:39:53.303' AS DateTime), N'SIGNUP', N'Se ha creado :LTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (6, 1, CAST(N'2021-09-17T05:39:53.310' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en litecoin id:3')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (7, 1, CAST(N'2021-09-17T05:39:53.323' AS DateTime), N'SIGNUP', N'Se ha creado :DOG/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (8, 1, CAST(N'2021-09-17T05:39:53.330' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en doge id:4')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (9, 1, CAST(N'2021-09-17T05:39:54.600' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10, 1, CAST(N'2021-09-17T05:39:54.630' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (11, 1, CAST(N'2021-09-17T05:39:54.660' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (12, 1, CAST(N'2021-09-17T05:39:57.773' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (13, 1, CAST(N'2021-09-17T05:40:34.523' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en ars pesos id:5')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (14, 1, CAST(N'2021-09-17T05:40:34.537' AS DateTime), N'SIGNUP', N'Se ha creado :BTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (15, 1, CAST(N'2021-09-17T05:40:34.547' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en bitcoin:6')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (16, 1, CAST(N'2021-09-17T05:40:34.560' AS DateTime), N'SIGNUP', N'Se ha creado :LTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (17, 1, CAST(N'2021-09-17T05:40:34.567' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en litecoin id:7')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (18, 1, CAST(N'2021-09-17T05:40:34.580' AS DateTime), N'SIGNUP', N'Se ha creado :DOG/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (19, 1, CAST(N'2021-09-17T05:40:34.590' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en doge id:8')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20, 1, CAST(N'2021-09-17T05:40:35.603' AS DateTime), N'LOGIN', N'Request login of user:charlie.brown@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (21, 1, CAST(N'2021-09-17T05:40:35.637' AS DateTime), N'SESSION', N'An user has started session - email:charlie.brown@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (22, 2, CAST(N'2021-09-17T05:40:35.653' AS DateTime), N'LOGIN', N'Login of user:charlie.brown@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (23, 2, CAST(N'2021-09-17T05:40:38.397' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (24, 2, CAST(N'2021-09-17T05:41:11.260' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en ars pesos id:9')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (25, 2, CAST(N'2021-09-17T05:41:11.277' AS DateTime), N'SIGNUP', N'Se ha creado :BTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (26, 2, CAST(N'2021-09-17T05:41:11.283' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en bitcoin:10')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (27, 2, CAST(N'2021-09-17T05:41:11.297' AS DateTime), N'SIGNUP', N'Se ha creado :LTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (28, 2, CAST(N'2021-09-17T05:41:11.303' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en litecoin id:11')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (29, 2, CAST(N'2021-09-17T05:41:11.330' AS DateTime), N'SIGNUP', N'Se ha creado :DOG/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30, 2, CAST(N'2021-09-17T05:41:11.337' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en doge id:12')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (31, 2, CAST(N'2021-09-17T05:41:12.650' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (32, 2, CAST(N'2021-09-17T05:41:12.667' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (33, 3, CAST(N'2021-09-17T05:41:12.680' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (34, 3, CAST(N'2021-09-17T05:41:15.027' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (35, 3, CAST(N'2021-09-17T05:41:54.507' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en ars pesos id:13')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (36, 3, CAST(N'2021-09-17T05:41:54.527' AS DateTime), N'SIGNUP', N'Se ha creado :BTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (37, 3, CAST(N'2021-09-17T05:41:54.533' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en bitcoin:14')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (38, 3, CAST(N'2021-09-17T05:41:54.547' AS DateTime), N'SIGNUP', N'Se ha creado :LTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (39, 3, CAST(N'2021-09-17T05:41:54.553' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en litecoin id:15')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (40, 3, CAST(N'2021-09-17T05:41:54.567' AS DateTime), N'SIGNUP', N'Se ha creado :DOG/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (41, 3, CAST(N'2021-09-17T05:41:54.577' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en doge id:16')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (42, 3, CAST(N'2021-09-17T05:41:55.700' AS DateTime), N'LOGIN', N'Request login of user:uai@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (43, 3, CAST(N'2021-09-17T05:41:55.730' AS DateTime), N'SESSION', N'An user has started session - email:uai@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (44, 4, CAST(N'2021-09-17T05:41:55.747' AS DateTime), N'LOGIN', N'Login of user:uai@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (45, 4, CAST(N'2021-09-17T05:41:59.270' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (46, 4, CAST(N'2021-09-17T05:43:22.193' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en ars pesos id:17')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (47, 4, CAST(N'2021-09-17T05:43:22.217' AS DateTime), N'SIGNUP', N'Se ha creado :BTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (48, 4, CAST(N'2021-09-17T05:43:22.227' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en bitcoin:18')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (49, 4, CAST(N'2021-09-17T05:43:22.243' AS DateTime), N'SIGNUP', N'Se ha creado :LTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (50, 4, CAST(N'2021-09-17T05:43:22.253' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en litecoin id:19')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (51, 4, CAST(N'2021-09-17T05:43:22.270' AS DateTime), N'SIGNUP', N'Se ha creado :DOG/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (52, 4, CAST(N'2021-09-17T05:43:22.280' AS DateTime), N'SIGNUP', N'Se ha creado la cuenta en doge id:20')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (53, 4, CAST(N'2021-09-17T05:43:23.213' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (54, 4, CAST(N'2021-09-17T05:43:23.243' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (55, 5, CAST(N'2021-09-17T05:43:23.270' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (56, 5, CAST(N'2021-09-17T05:43:28.273' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (57, 5, CAST(N'2021-09-17T05:44:27.317' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (58, 5, CAST(N'2021-09-17T05:44:27.347' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (59, 5, CAST(N'2021-09-17T05:44:27.367' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (60, 0, CAST(N'2021-09-17T05:50:41.037' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (61, 0, CAST(N'2021-09-17T05:50:41.067' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (62, 5, CAST(N'2021-09-17T05:50:41.090' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (63, 5, CAST(N'2021-09-17T05:51:24.583' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (64, 5, CAST(N'2021-09-17T05:51:33.620' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (65, 5, CAST(N'2021-09-17T05:51:41.190' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (66, 5, CAST(N'2021-09-17T05:51:41.213' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (67, 5, CAST(N'2021-09-17T05:51:41.240' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (68, 0, CAST(N'2021-09-17T05:52:33.517' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (69, 0, CAST(N'2021-09-17T05:52:33.560' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (70, 5, CAST(N'2021-09-17T05:52:33.583' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (71, 5, CAST(N'2021-09-17T05:55:50.247' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (72, 5, CAST(N'2021-09-17T05:56:03.080' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (73, 5, CAST(N'2021-09-17T05:56:03.107' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (74, 5, CAST(N'2021-09-17T05:56:03.113' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (75, 5, CAST(N'2021-09-17T05:58:28.950' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (76, 5, CAST(N'2021-09-17T05:58:40.153' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (77, 5, CAST(N'2021-09-17T05:58:40.227' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (78, 5, CAST(N'2021-09-17T05:58:40.253' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (79, 0, CAST(N'2021-09-17T06:02:26.993' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (80, 0, CAST(N'2021-09-17T06:02:27.027' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (81, 5, CAST(N'2021-09-17T06:02:27.050' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (82, 5, CAST(N'2021-09-17T06:03:50.623' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (83, 5, CAST(N'2021-09-17T06:04:02.293' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (84, 5, CAST(N'2021-09-17T06:04:02.307' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (85, 3, CAST(N'2021-09-17T06:04:02.320' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (86, 3, CAST(N'2021-09-17T06:04:10.483' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (87, 0, CAST(N'2021-09-17T12:45:02.823' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (88, 0, CAST(N'2021-09-17T12:45:02.960' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (89, 5, CAST(N'2021-09-17T12:45:03.297' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (90, 0, CAST(N'2021-09-17T12:53:01.867' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (91, 0, CAST(N'2021-09-17T12:53:01.903' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (92, 5, CAST(N'2021-09-17T12:53:10.897' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (93, 0, CAST(N'2021-09-17T22:17:42.293' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (94, 0, CAST(N'2021-09-17T22:17:42.317' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (95, 5, CAST(N'2021-09-17T22:17:42.337' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (96, 5, CAST(N'2021-09-17T22:17:45.740' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (97, 5, CAST(N'2021-09-17T22:17:54.737' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (98, 5, CAST(N'2021-09-17T22:17:54.757' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (99, 3, CAST(N'2021-09-17T22:17:54.770' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
GO
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (100, 0, CAST(N'2021-09-17T22:34:28.743' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (101, 0, CAST(N'2021-09-17T22:34:28.767' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (102, 3, CAST(N'2021-09-17T22:34:28.787' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (103, 0, CAST(N'2021-09-17T23:48:02.987' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (104, 0, CAST(N'2021-09-17T23:48:03.020' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (105, 3, CAST(N'2021-09-17T23:48:03.050' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (106, 0, CAST(N'2021-09-17T23:51:06.453' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (107, 0, CAST(N'2021-09-17T23:51:06.487' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (108, 3, CAST(N'2021-09-17T23:51:06.510' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (109, 0, CAST(N'2021-09-17T23:54:50.723' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (110, 0, CAST(N'2021-09-17T23:54:50.757' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (111, 3, CAST(N'2021-09-17T23:54:50.793' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (112, 0, CAST(N'2021-09-18T00:09:17.207' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (113, 0, CAST(N'2021-09-18T00:09:17.233' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (114, 3, CAST(N'2021-09-18T00:09:17.263' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (115, 0, CAST(N'2021-09-18T00:15:31.800' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (116, 0, CAST(N'2021-09-18T00:15:31.837' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (117, 3, CAST(N'2021-09-18T00:15:31.873' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (118, 0, CAST(N'2021-09-18T00:26:51.993' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (119, 0, CAST(N'2021-09-18T00:26:52.020' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (120, 3, CAST(N'2021-09-18T00:26:52.047' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (121, 0, CAST(N'2021-09-18T00:27:41.187' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (122, 0, CAST(N'2021-09-18T00:27:41.223' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (123, 3, CAST(N'2021-09-18T00:27:41.250' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (124, 0, CAST(N'2021-09-18T00:28:32.717' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (125, 0, CAST(N'2021-09-18T00:28:32.740' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (126, 3, CAST(N'2021-09-18T00:28:32.757' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (127, 0, CAST(N'2021-09-18T00:31:28.053' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (128, 0, CAST(N'2021-09-18T00:31:28.080' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (129, 3, CAST(N'2021-09-18T00:31:28.107' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (130, 0, CAST(N'2021-09-18T00:34:48.127' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (131, 0, CAST(N'2021-09-18T00:34:48.167' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (132, 3, CAST(N'2021-09-18T00:34:48.200' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (133, 0, CAST(N'2021-09-18T00:44:12.827' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (134, 0, CAST(N'2021-09-18T00:44:12.857' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (135, 3, CAST(N'2021-09-18T00:44:12.890' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (136, 0, CAST(N'2021-09-18T00:47:12.383' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (137, 0, CAST(N'2021-09-18T00:47:12.420' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (138, 3, CAST(N'2021-09-18T00:47:12.450' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10002, 0, CAST(N'2021-09-18T01:17:08.973' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10003, 0, CAST(N'2021-09-18T01:17:09.023' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10004, 3, CAST(N'2021-09-18T01:17:09.067' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10005, 0, CAST(N'2021-09-18T01:18:38.473' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10006, 0, CAST(N'2021-09-18T01:18:38.510' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10007, 3, CAST(N'2021-09-18T01:18:38.540' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10008, 0, CAST(N'2021-09-18T01:19:23.643' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10009, 0, CAST(N'2021-09-18T01:19:23.677' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10010, 3, CAST(N'2021-09-18T01:19:23.713' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10011, 0, CAST(N'2021-09-18T01:21:19.367' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10012, 0, CAST(N'2021-09-18T01:21:19.397' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10013, 3, CAST(N'2021-09-18T01:21:19.420' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10014, 0, CAST(N'2021-09-18T01:22:18.290' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10015, 0, CAST(N'2021-09-18T01:22:18.317' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10016, 3, CAST(N'2021-09-18T01:22:18.337' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10017, 0, CAST(N'2021-09-18T01:24:03.197' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10018, 0, CAST(N'2021-09-18T01:24:03.227' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10019, 3, CAST(N'2021-09-18T01:24:03.257' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10020, 0, CAST(N'2021-09-18T01:27:00.687' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10021, 0, CAST(N'2021-09-18T01:27:00.737' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10022, 3, CAST(N'2021-09-18T01:27:00.760' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10023, 3, CAST(N'2021-09-18T01:27:08.203' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10024, 3, CAST(N'2021-09-18T01:27:20.227' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10025, 3, CAST(N'2021-09-18T01:27:20.227' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10026, 5, CAST(N'2021-09-18T01:27:20.240' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10027, 5, CAST(N'2021-09-18T01:28:00.410' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10028, 5, CAST(N'2021-09-18T01:28:09.377' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10029, 5, CAST(N'2021-09-18T01:28:09.390' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10030, 3, CAST(N'2021-09-18T01:28:09.390' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10031, 3, CAST(N'2021-09-18T01:28:27.400' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10032, 3, CAST(N'2021-09-18T01:28:35.630' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10033, 3, CAST(N'2021-09-18T01:28:35.647' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10034, 5, CAST(N'2021-09-18T01:28:35.663' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10035, 0, CAST(N'2021-09-18T01:33:13.983' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10036, 0, CAST(N'2021-09-18T01:33:14.030' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10037, 3, CAST(N'2021-09-18T01:33:14.060' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10038, 0, CAST(N'2021-09-18T01:34:32.477' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10039, 0, CAST(N'2021-09-18T01:34:32.510' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10040, 3, CAST(N'2021-09-18T01:34:32.540' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10041, 3, CAST(N'2021-09-18T01:35:06.413' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10042, 3, CAST(N'2021-09-18T01:35:21.913' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10043, 3, CAST(N'2021-09-18T01:35:21.923' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10044, 3, CAST(N'2021-09-18T01:35:21.940' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10045, 3, CAST(N'2021-09-18T01:35:26.363' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10046, 3, CAST(N'2021-09-18T01:35:32.887' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10047, 3, CAST(N'2021-09-18T01:35:32.910' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10048, 5, CAST(N'2021-09-18T01:35:32.910' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10049, 0, CAST(N'2021-09-18T01:38:26.890' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10050, 0, CAST(N'2021-09-18T01:38:26.923' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10051, 5, CAST(N'2021-09-18T01:38:26.953' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10052, 0, CAST(N'2021-09-18T01:41:07.820' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10053, 0, CAST(N'2021-09-18T01:41:07.837' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10054, 3, CAST(N'2021-09-18T01:41:07.850' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10055, 3, CAST(N'2021-09-18T01:41:12.633' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10056, 3, CAST(N'2021-09-18T01:41:19.217' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10057, 3, CAST(N'2021-09-18T01:41:19.233' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10058, 5, CAST(N'2021-09-18T01:41:19.247' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10059, 0, CAST(N'2021-09-18T06:35:31.643' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10060, 0, CAST(N'2021-09-18T06:35:31.663' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10061, 5, CAST(N'2021-09-18T06:35:31.803' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10062, 5, CAST(N'2021-09-18T06:36:08.767' AS DateTime), N'SESSION', N'An user has closed the session')
GO
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10063, 5, CAST(N'2021-09-18T06:36:23.837' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10064, 5, CAST(N'2021-09-18T06:36:23.867' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10065, 3, CAST(N'2021-09-18T06:36:23.883' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10066, 3, CAST(N'2021-09-18T06:36:37.903' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10067, 3, CAST(N'2021-09-18T06:36:46.793' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10068, 3, CAST(N'2021-09-18T06:36:46.807' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10069, 5, CAST(N'2021-09-18T06:36:46.820' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10070, 0, CAST(N'2021-09-18T06:39:06.177' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10071, 0, CAST(N'2021-09-18T06:39:06.217' AS DateTime), N'SESSION', N'An user has started session - email:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10072, 3, CAST(N'2021-09-18T06:39:06.247' AS DateTime), N'LOGIN', N'Login of user:alf@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10073, 3, CAST(N'2021-09-18T06:39:24.123' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10074, 3, CAST(N'2021-09-18T06:39:35.083' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10075, 3, CAST(N'2021-09-18T06:39:35.100' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10076, 5, CAST(N'2021-09-18T06:39:35.117' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10077, 0, CAST(N'2021-09-18T06:40:29.067' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10078, 0, CAST(N'2021-09-18T06:40:29.103' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10079, 5, CAST(N'2021-09-18T06:40:29.150' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10080, 5, CAST(N'2021-09-18T06:41:16.507' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10081, 0, CAST(N'2021-09-18T10:37:09.347' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10082, 0, CAST(N'2021-09-18T10:37:09.383' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10083, 5, CAST(N'2021-09-18T10:37:09.417' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10084, 5, CAST(N'2021-09-18T10:37:29.993' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10085, 5, CAST(N'2021-09-18T10:37:39.957' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10086, 5, CAST(N'2021-09-18T10:37:39.967' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10087, 5, CAST(N'2021-09-18T10:37:39.970' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10088, 0, CAST(N'2021-09-18T11:35:42.687' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10089, 0, CAST(N'2021-09-18T11:35:42.727' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10090, 5, CAST(N'2021-09-18T11:35:42.760' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10091, 0, CAST(N'2021-09-18T12:11:31.077' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10092, 0, CAST(N'2021-09-18T12:11:31.140' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10093, 5, CAST(N'2021-09-18T12:11:31.193' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10094, 0, CAST(N'2021-09-18T12:14:28.667' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10095, 0, CAST(N'2021-09-18T12:14:28.707' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10096, 5, CAST(N'2021-09-18T12:14:28.743' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10097, 0, CAST(N'2021-09-18T12:18:15.333' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10098, 0, CAST(N'2021-09-18T12:18:15.360' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10099, 5, CAST(N'2021-09-18T12:18:15.407' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10100, 0, CAST(N'2021-09-18T12:18:50.627' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10101, 0, CAST(N'2021-09-18T12:18:50.663' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10102, 5, CAST(N'2021-09-18T12:18:50.697' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10103, 0, CAST(N'2021-09-18T12:29:36.243' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10104, 0, CAST(N'2021-09-18T12:29:36.257' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10105, 5, CAST(N'2021-09-18T12:29:36.270' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10106, 0, CAST(N'2021-09-18T12:30:30.097' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10107, 0, CAST(N'2021-09-18T12:30:30.113' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10108, 5, CAST(N'2021-09-18T12:30:30.127' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10109, 0, CAST(N'2021-09-18T12:36:10.963' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10110, 0, CAST(N'2021-09-18T12:36:10.993' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10111, 5, CAST(N'2021-09-18T12:36:11.040' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10112, 0, CAST(N'2021-09-18T12:37:38.550' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10113, 0, CAST(N'2021-09-18T12:37:38.590' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10114, 5, CAST(N'2021-09-18T12:37:38.623' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10115, 0, CAST(N'2021-09-18T12:40:19.877' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10116, 0, CAST(N'2021-09-18T12:40:19.917' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10117, 5, CAST(N'2021-09-18T12:40:19.957' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10118, 0, CAST(N'2021-09-18T12:43:15.427' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10119, 0, CAST(N'2021-09-18T12:43:15.467' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10120, 5, CAST(N'2021-09-18T12:43:15.503' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10121, 0, CAST(N'2021-09-18T13:01:37.693' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10122, 0, CAST(N'2021-09-18T13:01:37.727' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10123, 5, CAST(N'2021-09-18T13:01:37.743' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10124, 0, CAST(N'2021-09-18T13:03:42.393' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10125, 0, CAST(N'2021-09-18T13:03:42.603' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10126, 5, CAST(N'2021-09-18T13:03:42.797' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10127, 0, CAST(N'2021-09-18T13:04:42.060' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10128, 0, CAST(N'2021-09-18T13:04:42.097' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10129, 5, CAST(N'2021-09-18T13:04:42.123' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10130, 0, CAST(N'2021-09-18T13:09:55.183' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10131, 0, CAST(N'2021-09-18T13:09:55.287' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10132, 5, CAST(N'2021-09-18T13:09:55.317' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10133, 0, CAST(N'2021-09-18T13:12:03.653' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10134, 0, CAST(N'2021-09-18T13:12:03.757' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10135, 5, CAST(N'2021-09-18T13:12:03.793' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10136, 0, CAST(N'2021-09-18T13:13:52.640' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10137, 0, CAST(N'2021-09-18T13:13:52.717' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10138, 5, CAST(N'2021-09-18T13:13:52.800' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10139, 0, CAST(N'2021-09-18T13:16:18.470' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10140, 0, CAST(N'2021-09-18T13:16:18.523' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10141, 5, CAST(N'2021-09-18T13:16:18.560' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10142, 0, CAST(N'2021-09-18T13:18:20.943' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10143, 0, CAST(N'2021-09-18T13:18:26.583' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10144, 0, CAST(N'2021-09-18T13:18:26.630' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10145, 5, CAST(N'2021-09-18T13:18:26.667' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10146, 0, CAST(N'2021-09-18T13:19:17.707' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10147, 0, CAST(N'2021-09-18T13:19:17.733' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10148, 5, CAST(N'2021-09-18T13:19:17.757' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10149, 0, CAST(N'2021-09-18T14:20:44.517' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10150, 0, CAST(N'2021-09-18T14:20:44.660' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10151, 5, CAST(N'2021-09-18T14:20:44.980' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10152, 0, CAST(N'2021-09-20T21:14:31.157' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10153, 0, CAST(N'2021-09-20T21:14:31.287' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10154, 5, CAST(N'2021-09-20T21:14:31.560' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10155, 0, CAST(N'2021-09-20T21:25:59.227' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10156, 0, CAST(N'2021-09-20T21:25:59.277' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10157, 5, CAST(N'2021-09-20T21:25:59.307' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10158, 0, CAST(N'2021-09-20T21:28:16.137' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10159, 0, CAST(N'2021-09-20T21:28:16.170' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10160, 5, CAST(N'2021-09-20T21:28:16.190' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10161, 0, CAST(N'2021-09-20T21:29:15.480' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10162, 0, CAST(N'2021-09-20T21:29:15.557' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
GO
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10163, 5, CAST(N'2021-09-20T21:29:26.087' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10164, 0, CAST(N'2021-09-20T21:33:29.567' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10165, 0, CAST(N'2021-09-20T21:33:29.623' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10166, 5, CAST(N'2021-09-20T21:33:29.647' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10167, 0, CAST(N'2021-09-20T21:34:20.337' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10168, 0, CAST(N'2021-09-20T21:34:20.410' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10169, 5, CAST(N'2021-09-20T21:34:20.440' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10170, 0, CAST(N'2021-09-20T21:35:04.653' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10171, 0, CAST(N'2021-09-20T21:35:04.683' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (10172, 5, CAST(N'2021-09-20T21:35:04.707' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20167, 0, CAST(N'2021-09-22T01:42:56.173' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20168, 0, CAST(N'2021-09-22T01:42:56.277' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20169, 5, CAST(N'2021-09-22T01:42:56.307' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20170, 0, CAST(N'2021-09-23T01:36:33.187' AS DateTime), N'LOGIN', N'Request login of user:alf@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20171, 0, CAST(N'2021-09-24T19:14:41.200' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20172, 0, CAST(N'2021-10-09T16:50:19.713' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20173, 0, CAST(N'2021-10-09T19:40:48.267' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20174, 0, CAST(N'2021-10-09T19:40:48.307' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20175, 5, CAST(N'2021-10-09T19:40:48.347' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20176, 0, CAST(N'2021-10-09T20:45:11.000' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20177, 0, CAST(N'2021-10-09T20:52:46.077' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20178, 0, CAST(N'2021-10-09T20:53:40.097' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20179, 0, CAST(N'2021-10-09T20:54:16.247' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20180, 0, CAST(N'2021-10-09T20:54:47.617' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20181, 0, CAST(N'2021-10-09T20:55:23.367' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20182, 0, CAST(N'2021-10-09T20:59:03.900' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20183, 0, CAST(N'2021-10-09T21:08:13.477' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20184, 0, CAST(N'2021-10-09T21:09:21.620' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20185, 0, CAST(N'2021-10-09T21:09:43.987' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20186, 0, CAST(N'2021-10-09T21:09:44.020' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20187, 5, CAST(N'2021-10-09T21:09:44.250' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20188, 0, CAST(N'2021-10-09T21:23:36.447' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20189, 0, CAST(N'2021-10-09T21:23:49.170' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20190, 0, CAST(N'2021-10-09T21:23:49.207' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20191, 1, CAST(N'2021-10-09T21:23:49.257' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20192, 1, CAST(N'2021-10-09T21:26:34.220' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20193, 1, CAST(N'2021-10-09T21:26:44.830' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20194, 1, CAST(N'2021-10-09T21:26:44.863' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20195, 5, CAST(N'2021-10-09T21:26:44.887' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20196, 0, CAST(N'2021-10-09T22:47:55.220' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20197, 0, CAST(N'2021-10-09T22:48:03.137' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20198, 0, CAST(N'2021-10-09T22:48:03.227' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20199, 1, CAST(N'2021-10-09T22:48:03.493' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20200, 1, CAST(N'2021-10-09T22:48:08.143' AS DateTime), N'PROFILE', N'Load profile:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20201, 1, CAST(N'2021-10-09T22:55:55.910' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20202, 1, CAST(N'2021-10-09T22:56:03.857' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20203, 1, CAST(N'2021-10-09T22:56:03.883' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20204, 5, CAST(N'2021-10-09T22:56:04.113' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20205, 5, CAST(N'2021-10-09T22:56:26.073' AS DateTime), N'USER', N'User:roberto@gmail.com buscando:roberto')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20206, 5, CAST(N'2021-10-09T22:56:33.923' AS DateTime), N'USER', N'User:roberto@gmail.com buscando:damian')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20207, 0, CAST(N'2021-10-10T10:57:15.987' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20208, 0, CAST(N'2021-10-10T10:57:33.050' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20209, 0, CAST(N'2021-10-10T10:57:33.097' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20210, 5, CAST(N'2021-10-10T10:57:33.160' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20211, 0, CAST(N'2021-10-10T19:50:56.537' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20212, 0, CAST(N'2021-10-10T19:51:22.180' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20213, 0, CAST(N'2021-10-10T20:00:15.380' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT1')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20214, 0, CAST(N'2021-10-10T20:02:30.667' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20215, 0, CAST(N'2021-10-10T20:03:51.057' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_CORRUPT')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20216, 0, CAST(N'2021-10-10T20:05:17.330' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_ENTITY_FAIL')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20217, 0, CAST(N'2021-10-10T20:06:33.500' AS DateTime), N'INTEGRITY', N'INTEGRITY_USERS_ENTITY_FAIL')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20218, 0, CAST(N'2021-10-11T10:52:26.713' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20219, 0, CAST(N'2021-10-11T10:52:26.823' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20220, 1, CAST(N'2021-10-11T10:52:27.040' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20221, 1, CAST(N'2021-10-11T10:52:32.813' AS DateTime), N'PROFILE', N'Load profile:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20222, 1, CAST(N'2021-10-11T10:52:40.523' AS DateTime), N'PROFILE', N'Update profile:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20223, 0, CAST(N'2021-10-11T11:00:17.583' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20224, 0, CAST(N'2021-10-11T11:00:17.627' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20225, 1, CAST(N'2021-10-11T11:00:17.663' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20226, 1, CAST(N'2021-10-11T11:00:21.757' AS DateTime), N'PROFILE', N'Load profile:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20227, 1, CAST(N'2021-10-11T11:00:29.690' AS DateTime), N'PROFILE', N'Update profile:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20228, 0, CAST(N'2021-10-14T11:26:47.730' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20229, 0, CAST(N'2021-10-14T11:26:47.870' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20230, 5, CAST(N'2021-10-14T11:26:48.197' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20231, 5, CAST(N'2021-10-14T11:26:56.997' AS DateTime), N'USER', N'User:roberto@gmail.com buscando:a')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20232, 0, CAST(N'2021-10-14T17:56:24.747' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20233, 0, CAST(N'2021-10-14T17:56:24.860' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20234, 5, CAST(N'2021-10-14T17:56:25.013' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20235, 0, CAST(N'2021-10-15T18:38:50.767' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20236, 0, CAST(N'2021-10-15T18:38:50.860' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20237, 5, CAST(N'2021-10-15T18:38:51.033' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20238, 0, CAST(N'2021-10-15T18:45:56.060' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20239, 0, CAST(N'2021-10-15T18:45:56.083' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20240, 5, CAST(N'2021-10-15T18:45:56.103' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20241, 5, CAST(N'2021-10-15T18:46:53.007' AS DateTime), N'USER', N'User:roberto@gmail.com buscando:r')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20242, 5, CAST(N'2021-10-15T18:47:16.027' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20243, 5, CAST(N'2021-10-15T18:47:21.127' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20244, 5, CAST(N'2021-10-15T18:47:21.140' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20245, 1, CAST(N'2021-10-15T18:47:21.157' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20246, 1, CAST(N'2021-10-15T18:47:23.037' AS DateTime), N'PROFILE', N'Load profile:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20247, 1, CAST(N'2021-10-15T18:47:30.883' AS DateTime), N'PROFILE', N'Update profile:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20248, 1, CAST(N'2021-10-15T18:47:32.677' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20249, 1, CAST(N'2021-10-15T18:47:39.480' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20250, 1, CAST(N'2021-10-15T18:47:39.497' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20251, 5, CAST(N'2021-10-15T18:47:39.503' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20252, 5, CAST(N'2021-10-15T18:47:44.673' AS DateTime), N'USER', N'User:roberto@gmail.com buscando:d')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20253, 5, CAST(N'2021-10-15T18:48:02.130' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20254, 0, CAST(N'2021-10-15T19:15:16.717' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20255, 0, CAST(N'2021-10-15T19:15:16.737' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20256, 1, CAST(N'2021-10-15T19:15:16.753' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
GO
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20257, 1, CAST(N'2021-10-15T19:15:18.707' AS DateTime), N'PROFILE', N'Load profile:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20258, 1, CAST(N'2021-10-15T19:15:24.017' AS DateTime), N'WALLET', N'Cargando wallet:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20259, 1, CAST(N'2021-10-15T19:16:20.240' AS DateTime), N'WALLET', N'Cargando wallet:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20260, 1, CAST(N'2021-10-15T19:19:05.597' AS DateTime), N'WALLET', N'Cargando wallet:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20261, 1, CAST(N'2021-10-15T19:19:06.717' AS DateTime), N'BALANCE', N'Se ha consultado el balance:BTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC, 0.53397162')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20262, 1, CAST(N'2021-10-15T19:19:07.190' AS DateTime), N'BALANCE', N'Se ha consultado el balance:LTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC, 0.76694461')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20263, 1, CAST(N'2021-10-15T19:19:07.693' AS DateTime), N'BALANCE', N'Se ha consultado el balance:DOG/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC, 1000.51698581')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20264, 1, CAST(N'2021-10-15T19:19:29.367' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20265, 0, CAST(N'2021-10-15T19:26:05.927' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20266, 0, CAST(N'2021-10-15T19:26:12.893' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20267, 0, CAST(N'2021-10-15T19:26:12.913' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20268, 5, CAST(N'2021-10-15T19:26:12.940' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20269, 0, CAST(N'2021-10-15T19:28:27.283' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20270, 0, CAST(N'2021-10-15T19:28:27.310' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20271, 5, CAST(N'2021-10-15T19:28:27.330' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20272, 5, CAST(N'2021-10-15T19:29:40.287' AS DateTime), N'USER', N'User:roberto@gmail.com buscando:damian')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20273, 5, CAST(N'2021-10-15T19:30:36.597' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20274, 5, CAST(N'2021-10-15T19:30:47.373' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20275, 5, CAST(N'2021-10-15T19:30:47.393' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20276, 1, CAST(N'2021-10-15T19:30:47.410' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20277, 1, CAST(N'2021-10-15T19:30:50.273' AS DateTime), N'PROFILE', N'Load profile:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20278, 1, CAST(N'2021-10-15T19:31:10.817' AS DateTime), N'PROFILE', N'Update profile:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20279, 1, CAST(N'2021-10-15T19:31:12.857' AS DateTime), N'PROFILE', N'Load profile:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20280, 1, CAST(N'2021-10-15T19:31:15.830' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20281, 1, CAST(N'2021-10-15T19:31:26.517' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20282, 1, CAST(N'2021-10-15T19:31:26.547' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20283, 5, CAST(N'2021-10-15T19:31:26.570' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20284, 5, CAST(N'2021-10-15T19:31:32.653' AS DateTime), N'USER', N'User:roberto@gmail.com buscando:da')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20285, 5, CAST(N'2021-10-15T19:31:51.977' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20286, 5, CAST(N'2021-10-15T19:32:01.377' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20287, 5, CAST(N'2021-10-15T19:32:01.397' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20288, 1, CAST(N'2021-10-15T19:32:01.407' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20289, 1, CAST(N'2021-10-15T19:32:03.503' AS DateTime), N'PROFILE', N'Load profile:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20290, 1, CAST(N'2021-10-15T19:36:04.330' AS DateTime), N'PROFILE', N'Load profile:LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20291, 1, CAST(N'2021-10-15T19:37:36.690' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20292, 1, CAST(N'2021-10-15T19:37:46.377' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20293, 1, CAST(N'2021-10-15T19:37:46.423' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20294, 5, CAST(N'2021-10-15T19:37:46.440' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20404, 0, CAST(N'2021-07-25T00:10:27.340' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20405, 0, CAST(N'2021-07-25T00:10:27.373' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (20406, 5, CAST(N'2021-07-25T00:10:27.390' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30413, 0, CAST(N'2021-03-31T21:10:16.120' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:1 11d71138d9ddee37d1fcce5aedec3ce4,b35965ae5f527639882c56524f0624af')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30414, 0, CAST(N'2021-07-31T21:10:27.777' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:1 11d71138d9ddee37d1fcce5aedec3ce4,b35965ae5f527639882c56524f0624af')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30415, 0, CAST(N'2021-08-31T21:10:11.487' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:1 11d71138d9ddee37d1fcce5aedec3ce4,b35965ae5f527639882c56524f0624af')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30416, 0, CAST(N'2021-08-31T21:10:50.617' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30417, 0, CAST(N'2021-08-31T21:10:50.670' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30418, 1, CAST(N'2021-08-31T21:10:50.757' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30449, 0, CAST(N'2021-09-01T02:11:36.753' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30450, 0, CAST(N'2021-09-01T02:11:36.817' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30451, 5, CAST(N'2021-09-01T02:11:36.833' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30452, 0, CAST(N'2021-12-01T02:11:54.630' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30453, 0, CAST(N'2021-12-01T02:11:54.663' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30454, 5, CAST(N'2021-12-01T02:11:54.677' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30571, 0, CAST(N'2021-02-02T13:11:20.430' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30572, 0, CAST(N'2021-02-02T13:11:20.477' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30573, 1, CAST(N'2021-02-02T13:11:20.517' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30574, 0, CAST(N'2021-03-02T13:11:53.890' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30575, 0, CAST(N'2021-03-02T13:11:53.920' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30576, 1, CAST(N'2021-03-02T13:11:53.950' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30577, 0, CAST(N'2021-04-02T13:11:41.533' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30578, 0, CAST(N'2021-04-02T13:11:41.567' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30579, 1, CAST(N'2021-04-02T13:11:41.597' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30580, 1, CAST(N'2021-04-02T13:11:43.970' AS DateTime), N'BALANCE', N'Se ha consultado el balance:BTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC, 0.53397162')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30581, 1, CAST(N'2021-04-02T13:11:44.403' AS DateTime), N'BALANCE', N'Se ha consultado el balance:LTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC, 0.76694461')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30582, 1, CAST(N'2021-04-02T13:11:44.843' AS DateTime), N'BALANCE', N'Se ha consultado el balance:DOG/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC, 1000.51698581')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30634, 0, CAST(N'2021-09-02T19:11:50.097' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30635, 0, CAST(N'2021-09-02T19:11:50.200' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30636, 1, CAST(N'2021-09-02T19:11:50.520' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30637, 1, CAST(N'2021-10-02T19:11:00.027' AS DateTime), N'BALANCE', N'Se ha consultado el balance:BTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC, 0.53397162')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30638, 1, CAST(N'2021-10-02T19:11:00.587' AS DateTime), N'BALANCE', N'Se ha consultado el balance:LTC/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC, 0.76694461')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30639, 1, CAST(N'2021-10-02T19:11:01.013' AS DateTime), N'BALANCE', N'Se ha consultado el balance:DOG/2N9xZAjmVpb8pCjJWUiwVcHtTayhhnwoAZC, 1000.51698581')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30640, 0, CAST(N'2021-04-02T21:11:03.963' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30641, 0, CAST(N'2021-04-02T21:11:04.023' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30642, 5, CAST(N'2021-04-02T21:11:04.077' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30643, 5, CAST(N'2021-04-02T21:11:20.597' AS DateTime), N'USER', N'User:roberto@gmail.com buscando:a')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30681, 0, CAST(N'2021-08-02T22:11:17.057' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30682, 0, CAST(N'2021-08-02T22:11:17.143' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30683, 5, CAST(N'2021-08-02T22:11:17.180' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30684, 5, CAST(N'2021-08-02T22:11:20.843' AS DateTime), N'USER', N'User:roberto@gmail.com buscando:d')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30685, 0, CAST(N'2021-10-02T22:11:52.913' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30686, 0, CAST(N'2021-10-02T22:11:52.963' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30687, 5, CAST(N'2021-10-02T22:11:52.997' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30688, 5, CAST(N'2021-10-02T22:11:58.470' AS DateTime), N'USER', N'User:roberto@gmail.com buscando:a')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30717, 0, CAST(N'2021-11-03T01:11:45.050' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:1 93b6fcf5d94ad6e3e2eaf0c5054adf0c,11d71138d9ddee37d1fcce5aedec3ce4')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30718, 0, CAST(N'2021-09-03T13:11:26.147' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:1 93b6fcf5d94ad6e3e2eaf0c5054adf0c,11d71138d9ddee37d1fcce5aedec3ce4')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30735, 0, CAST(N'2021-10-03T18:11:41.867' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:1 93b6fcf5d94ad6e3e2eaf0c5054adf0c,11d71138d9ddee37d1fcce5aedec3ce4')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30773, 5, CAST(N'2021-01-04T12:11:23.397' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30774, 5, CAST(N'2021-01-04T12:11:28.880' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30775, 5, CAST(N'2021-01-04T12:11:28.923' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30776, 5, CAST(N'2021-01-04T12:11:29.203' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30777, 0, CAST(N'2021-12-04T12:11:10.620' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:2 17364a8f8199c90f74596cef6e0aac72,582c2f81866583e1c388e94d98a94ac1')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30778, 0, CAST(N'2021-12-04T12:11:39.400' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30779, 0, CAST(N'2021-12-04T12:11:39.433' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30780, 5, CAST(N'2021-12-04T12:11:39.697' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30802, 0, CAST(N'2021-04-04T13:11:16.657' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:2 17364a8f8199c90f74596cef6e0aac72,582c2f81866583e1c388e94d98a94ac1')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30803, 0, CAST(N'2021-04-04T13:11:39.860' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30804, 0, CAST(N'2021-04-04T13:11:39.887' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30805, 5, CAST(N'2021-04-04T13:11:39.933' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30806, 0, CAST(N'2021-04-04T14:11:57.637' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:2 17364a8f8199c90f74596cef6e0aac72,582c2f81866583e1c388e94d98a94ac1')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30807, 0, CAST(N'2021-05-04T14:11:09.613' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
GO
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30808, 0, CAST(N'2021-05-04T14:11:09.630' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30809, 5, CAST(N'2021-05-04T14:11:09.657' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30821, 0, CAST(N'2021-01-04T21:11:46.880' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:2 17364a8f8199c90f74596cef6e0aac72,582c2f81866583e1c388e94d98a94ac1')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30822, 0, CAST(N'2021-03-04T21:11:01.603' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:2 17364a8f8199c90f74596cef6e0aac72,582c2f81866583e1c388e94d98a94ac1')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30823, 0, CAST(N'2021-05-04T21:11:03.320' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:2 17364a8f8199c90f74596cef6e0aac72,582c2f81866583e1c388e94d98a94ac1')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30824, 0, CAST(N'2021-05-04T21:11:56.687' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:2 17364a8f8199c90f74596cef6e0aac72,582c2f81866583e1c388e94d98a94ac1')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30825, 0, CAST(N'2021-06-04T21:11:52.750' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:2 17364a8f8199c90f74596cef6e0aac72,582c2f81866583e1c388e94d98a94ac1')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30826, 0, CAST(N'2021-10-04T21:11:16.997' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:2 17364a8f8199c90f74596cef6e0aac72,582c2f81866583e1c388e94d98a94ac1')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30832, 0, CAST(N'2021-10-05T16:11:12.433' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:2 17364a8f8199c90f74596cef6e0aac72,582c2f81866583e1c388e94d98a94ac1')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30833, 0, CAST(N'2021-10-05T16:11:46.493' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30834, 0, CAST(N'2021-10-05T16:11:46.510' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30835, 5, CAST(N'2021-10-05T16:11:46.917' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30857, 0, CAST(N'2021-02-05T18:11:06.993' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:2 17364a8f8199c90f74596cef6e0aac72,582c2f81866583e1c388e94d98a94ac1')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30858, 0, CAST(N'2021-08-05T19:11:19.787' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Vertical warning - users entity table violated')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30859, 0, CAST(N'2021-10-05T19:11:27.800' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Vertical warning - users entity table violated')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30860, 0, CAST(N'2021-11-05T19:11:28.730' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:3 11ef2806b6d39f105b3bfd29c0990f99,249f35576f57e0b3ee2c4a24f5e90464')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30861, 0, CAST(N'2021-12-05T19:11:47.377' AS DateTime), N'VIOLATION ERROR - DETAIL', N'Horizontal warning - Comparing hash id:3 11ef2806b6d39f105b3bfd29c0990f99,249f35576f57e0b3ee2c4a24f5e90464')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30874, 0, CAST(N'2021-02-05T20:11:41.273' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30875, 0, CAST(N'2021-02-05T20:11:41.360' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30876, 5, CAST(N'2021-02-05T20:11:41.703' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30877, 0, CAST(N'2021-04-05T20:11:27.977' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30878, 0, CAST(N'2021-04-05T20:11:27.983' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30879, 5, CAST(N'2021-04-05T20:11:27.997' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30920, 0, CAST(N'2021-08-25T15:11:59.227' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30921, 0, CAST(N'2021-08-25T15:11:59.753' AS DateTime), N'SESSION', N'An user has started session - email:+EZUHnQRIH9QPvTBik7de/ylBBnOWs/NH2E/URHP9gA=')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30922, 5, CAST(N'2021-08-25T15:11:59.983' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30923, 5, CAST(N'2021-09-25T15:11:33.410' AS DateTime), N'USER', N'User:+EZUHnQRIH9QPvTBik7de/ylBBnOWs/NH2E/URHP9gA= buscando:a')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30924, 0, CAST(N'2021-12-25T15:11:06.890' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30925, 0, CAST(N'2021-12-25T15:11:07.463' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30926, 5, CAST(N'2021-12-25T15:11:07.697' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30927, 5, CAST(N'2021-12-25T15:11:25.683' AS DateTime), N'USER', N'User:roberto@gmail.com buscando:a')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30942, 0, CAST(N'2021-03-25T19:11:58.930' AS DateTime), N'LOGIN', N'Request login of user:charlie.brown@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30943, 0, CAST(N'2021-03-25T19:11:59.487' AS DateTime), N'SESSION', N'An user has started session - email:charlie.brown@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30944, 2, CAST(N'2021-03-25T19:11:59.720' AS DateTime), N'LOGIN', N'Login of user:charlie.brown@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30945, 2, CAST(N'2021-04-25T19:11:49.307' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30946, 0, CAST(N'2021-05-25T19:11:43.423' AS DateTime), N'LOGIN', N'Request login of user:charlie.brown@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30947, 0, CAST(N'2021-05-25T19:11:43.973' AS DateTime), N'SESSION', N'An user has started session - email:charlie.brown@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30948, 2, CAST(N'2021-05-25T19:11:44.207' AS DateTime), N'LOGIN', N'Login of user:charlie.brown@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30949, 2, CAST(N'2021-06-25T19:11:03.457' AS DateTime), N'SESSION', N'An user has closed the session')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30950, 0, CAST(N'2021-06-25T19:11:46.890' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30951, 0, CAST(N'2021-09-25T19:11:29.160' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30952, 0, CAST(N'2021-09-25T19:11:29.727' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30953, 1, CAST(N'2021-09-25T19:11:29.923' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30954, 1, CAST(N'2021-11-25T19:11:08.337' AS DateTime), N'PROFILE', N'Load profile:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30959, 0, CAST(N'2021-02-25T20:11:56.953' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30960, 0, CAST(N'2021-02-25T20:11:57.203' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30961, 5, CAST(N'2021-02-25T20:11:57.437' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30980, 0, CAST(N'2021-07-26T02:11:29.407' AS DateTime), N'LOGIN', N'Request login of user:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30981, 0, CAST(N'2021-07-26T02:11:30.017' AS DateTime), N'SESSION', N'An user has started session - email:damian.cipolat@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30982, 1, CAST(N'2021-07-26T02:11:30.290' AS DateTime), N'LOGIN', N'Login of user:damian.cipolat@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30983, 0, CAST(N'2021-12-26T10:11:04.527' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30984, 0, CAST(N'2021-12-26T10:11:05.197' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30985, 5, CAST(N'2021-12-26T10:11:05.727' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30989, 0, CAST(N'2021-12-26T11:11:24.050' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30990, 0, CAST(N'2021-12-26T11:11:24.523' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (30991, 5, CAST(N'2021-12-26T11:11:24.767' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (31002, 0, CAST(N'2021-11-26T12:11:23.367' AS DateTime), N'LOGIN', N'Request login of user:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (31003, 0, CAST(N'2021-11-26T12:11:23.923' AS DateTime), N'SESSION', N'An user has started session - email:roberto@gmail.com')
INSERT [dbo].[bitacora] ([id], [idusuario], [fec_log], [activity], [payload]) VALUES (31004, 5, CAST(N'2021-11-26T12:11:24.190' AS DateTime), N'LOGIN', N'Login of user:roberto@gmail.com success!')
SET IDENTITY_INSERT [dbo].[bitacora] OFF
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([idcliente], [idusuario], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [valido], [deleted], [cbu]) VALUES (1, 1, N'DNI', N'33295515', CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'1111111', N'uai', N'123456456789', N'N', NULL, N'0070064130004043181234')
INSERT [dbo].[cliente] ([idcliente], [idusuario], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [valido], [deleted], [cbu]) VALUES (2, 2, N'DNI', N'30123123', CAST(N'2020-10-10T00:00:00.000' AS DateTime), N'21321231', N'sadsad', N'23132132123', N'N', NULL, N'0070064130004043187745')
INSERT [dbo].[cliente] ([idcliente], [idusuario], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [valido], [deleted], [cbu]) VALUES (3, 3, N'DNI', N'33295515', CAST(N'2030-10-10T00:00:00.000' AS DateTime), N'78995464564', N'mi casita', N'1234234', N'N', NULL, N'0070064130004043187745')
INSERT [dbo].[cliente] ([idcliente], [idusuario], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [valido], [deleted], [cbu]) VALUES (4, 4, N'DNI', N'30303045', CAST(N'2020-10-10T00:00:00.000' AS DateTime), N'10454654', N'asdsadsad', N'45345435345', N'N', NULL, N'0070064130004043187745')
SET IDENTITY_INSERT [dbo].[cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[cliente_cambios] ON 

INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (1, CAST(N'2021-09-17T05:39:53.000' AS DateTime), 1, N'DNI', N'33295515', CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'1111111', N'sadsadsad', N'343434444', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (2, CAST(N'2021-09-17T05:40:34.000' AS DateTime), 2, N'DNI', N'30123123', CAST(N'2020-10-10T00:00:00.000' AS DateTime), N'21321231', N'sadsad', N'23132132123', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (3, CAST(N'2021-09-17T05:41:11.000' AS DateTime), 3, N'DNI', N'10145689', CAST(N'2030-10-10T00:00:00.000' AS DateTime), N'666666', N'asdsad', N'3434343443', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (4, CAST(N'2021-09-17T05:41:54.000' AS DateTime), 4, N'DNI', N'30303045', CAST(N'2020-10-10T00:00:00.000' AS DateTime), N'10454654', N'asdsadsad', N'45345435345', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (5, CAST(N'2021-09-17T05:43:22.000' AS DateTime), 5, N'DNI', N'33254789', CAST(N'2020-10-10T00:00:00.000' AS DateTime), N'4545454', N'sadasd', N'889798798798', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (6, CAST(N'2021-09-17T05:55:37.000' AS DateTime), 4, N'DNI', N'30303045', CAST(N'2020-10-10T00:00:00.000' AS DateTime), N'10454654', N'asdsadsad', N'45345435345', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (7, CAST(N'2021-09-17T23:55:19.000' AS DateTime), 3, N'DNI', N'33295515', CAST(N'2030-10-10T00:00:00.000' AS DateTime), N'78995464564', N'mi casita', N'1234234', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (8, CAST(N'2021-09-18T00:09:43.000' AS DateTime), 3, N'DNI', N'345345345345', CAST(N'2030-10-10T00:00:00.000' AS DateTime), N'435345435', N'mi 45', N'66666666', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (9, CAST(N'2021-09-18T00:16:53.000' AS DateTime), 3, N'DNI', N'345345345345', CAST(N'2030-10-10T00:00:00.000' AS DateTime), N'435345435', N'mi 45', N'66666666', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (13, CAST(N'2021-09-18T00:46:40.000' AS DateTime), 3, N'DNI', N'345345345345', CAST(N'2030-03-10T00:00:00.000' AS DateTime), N'435345435', N'mi 45', N'12332432432', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (14, CAST(N'2021-09-18T00:46:46.000' AS DateTime), 3, N'DNI', N'345345345345', CAST(N'2030-03-10T00:00:00.000' AS DateTime), N'435345435', N'mi 45', N'12332432432', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (15, CAST(N'2021-09-18T00:47:18.000' AS DateTime), 3, N'DNI', N'345345345345', CAST(N'2030-04-10T00:00:00.000' AS DateTime), N'435345435', N'mi 45', N'12332432432', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (10004, CAST(N'2021-09-18T01:18:53.000' AS DateTime), 3, N'DNI', N'345345345345', CAST(N'2030-01-11T00:00:00.000' AS DateTime), N'435345435', N'mi 45', N'12332432432', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (10005, CAST(N'2021-09-18T01:19:35.000' AS DateTime), 3, N'DNI', N'345345345345', CAST(N'2030-08-11T00:00:00.000' AS DateTime), N'435345435', N'mi 45', N'12332432432', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (10009, CAST(N'2021-09-18T01:24:23.000' AS DateTime), 3, N'DNI', N'345345345345', CAST(N'2030-11-29T00:00:00.000' AS DateTime), N'435345435', N'mi 45', N'12332432432', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (10010, CAST(N'2021-09-18T01:27:06.000' AS DateTime), 3, N'DNI', N'345345345345', CAST(N'2030-11-21T00:00:00.000' AS DateTime), N'435345435', N'mi 45', N'12332432432', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (10011, CAST(N'2021-09-18T01:34:51.000' AS DateTime), 3, N'DNI', N'345345345345', CAST(N'2030-11-13T00:00:00.000' AS DateTime), N'435345435', N'mi 45', N'12332432432', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (10012, CAST(N'2021-09-18T01:35:04.000' AS DateTime), 3, N'DNI', N'345345345345', CAST(N'2030-11-13T00:00:00.000' AS DateTime), N'435345435', N'ROCKO', N'12332432432', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (10013, CAST(N'2021-09-18T06:36:35.000' AS DateTime), 3, N'DNI', N'345345345345', CAST(N'2030-11-13T00:00:00.000' AS DateTime), N'435345435', N'papita', N'12332432432', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (10014, CAST(N'2021-10-11T10:52:40.000' AS DateTime), 1, N'DNI', N'33295515', CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'1111111', N'sadsadsad', N'343434444', NULL, NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (10015, CAST(N'2021-10-11T11:00:29.000' AS DateTime), 1, N'DNI', N'33295515', CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'1111111', N'sadsadsad', N'343434444', N'0070064130004043181234', NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (10016, CAST(N'2021-10-15T18:47:30.000' AS DateTime), 1, N'DNI', N'33295515', CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'1111111', N'av sanjuan 1234', N'343434444', N'0070064130004043181234', NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (10017, CAST(N'2021-10-15T19:31:10.000' AS DateTime), 1, N'DNI', N'33295515', CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'1111111', N'uai', N'123456456789', N'0070064130004043181234', NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (10018, CAST(N'2021-10-24T12:21:19.000' AS DateTime), 1, N'DNI', N'33295515', CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'1111111', N'av sanjuan 1234', N'1149481663', N'0070064130004043181234', NULL)
INSERT [dbo].[cliente_cambios] ([idchange], [change_date], [idcliente], [tipoDoc], [numero], [fec_nac], [num_tramite], [domicilio], [telefono], [cbu], [rollback_user]) VALUES (10019, CAST(N'2021-10-24T12:31:06.000' AS DateTime), 1, N'DNI', N'33295515', CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'1111111', N'uai', N'123456456789', NULL, 1)
SET IDENTITY_INSERT [dbo].[cliente_cambios] OFF
GO
SET IDENTITY_INSERT [dbo].[comision_operacion_valor] ON 

INSERT [dbo].[comision_operacion_valor] ([idope], [descrip], [valor]) VALUES (1, N'Compra', 0.5)
INSERT [dbo].[comision_operacion_valor] ([idope], [descrip], [valor]) VALUES (2, N'Venta', 0.5)
INSERT [dbo].[comision_operacion_valor] ([idope], [descrip], [valor]) VALUES (3, N'Extraccion', 2.5)
SET IDENTITY_INSERT [dbo].[comision_operacion_valor] OFF
GO
SET IDENTITY_INSERT [dbo].[comisiones] ON 

INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (1, 1, 1, 2, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (2, 1, 1, 2, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (3, 1, 1, 2, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (4, 1, 1, 2, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (5, 1, 1, 2, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (6, 1, 1, 2, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (7, 1, 1, 2, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (8, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (9, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (10, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (11, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (12, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (13, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (14, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (15, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (16, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (17, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (18, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (19, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (20, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:42:31.177' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (21, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:43:21.363' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (22, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:43:22.067' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (23, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:43:22.457' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (24, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:43:22.797' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (25, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:43:23.163' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (26, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:43:23.577' AS DateTime))
INSERT [dbo].[comisiones] ([idcobro], [tipo_operacion], [referencia], [idcliente], [idwallet], [moneda], [valor], [fecCobro], [processed], [deleted], [fecRegister]) VALUES (27, 1, 1, 1, 1, N'ARS', 100, NULL, 1, NULL, CAST(N'2021-11-04T02:43:23.830' AS DateTime))
SET IDENTITY_INSERT [dbo].[comisiones] OFF
GO
SET IDENTITY_INSERT [dbo].[conversiones] ON 

INSERT [dbo].[conversiones] ([idconversion], [codCripto], [cantCripto], [valorUSD], [deleted]) VALUES (1, N'BTC', 1, 33655.8, NULL)
INSERT [dbo].[conversiones] ([idconversion], [codCripto], [cantCripto], [valorUSD], [deleted]) VALUES (2, N'LTC', 1, 132.82, NULL)
INSERT [dbo].[conversiones] ([idconversion], [codCripto], [cantCripto], [valorUSD], [deleted]) VALUES (3, N'DOG', 1, 0.21682, NULL)
INSERT [dbo].[conversiones] ([idconversion], [codCripto], [cantCripto], [valorUSD], [deleted]) VALUES (4, N'ARS', 1, 0.01, NULL)
SET IDENTITY_INSERT [dbo].[conversiones] OFF
GO
SET IDENTITY_INSERT [dbo].[cuenta_estado] ON 

INSERT [dbo].[cuenta_estado] ([id], [descrip]) VALUES (1, N'Activa')
INSERT [dbo].[cuenta_estado] ([id], [descrip]) VALUES (2, N'Inactiva')
INSERT [dbo].[cuenta_estado] ([id], [descrip]) VALUES (3, N'Bloqueada')
SET IDENTITY_INSERT [dbo].[cuenta_estado] OFF
GO
SET IDENTITY_INSERT [dbo].[cuentas] ON 

INSERT [dbo].[cuentas] ([idcuenta], [cliente], [fecAlta], [estado]) VALUES (1, 1, CAST(N'2021-09-17T05:39:53.000' AS DateTime), 1)
INSERT [dbo].[cuentas] ([idcuenta], [cliente], [fecAlta], [estado]) VALUES (2, 2, CAST(N'2021-09-17T05:40:34.000' AS DateTime), 1)
INSERT [dbo].[cuentas] ([idcuenta], [cliente], [fecAlta], [estado]) VALUES (3, 3, CAST(N'2021-09-17T05:41:11.000' AS DateTime), 1)
INSERT [dbo].[cuentas] ([idcuenta], [cliente], [fecAlta], [estado]) VALUES (4, 4, CAST(N'2021-09-17T05:41:54.000' AS DateTime), 1)
INSERT [dbo].[cuentas] ([idcuenta], [cliente], [fecAlta], [estado]) VALUES (5, 5, CAST(N'2021-09-17T05:43:22.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[cuentas] OFF
GO
INSERT [dbo].[dvv] ([tabla], [hash], [fecUpdate], [deleted]) VALUES (N'usuario', N'8b75a894618d68f8691db25d921da1b317364a8f8199c90f74596cef6e0aac7211ef2806b6d39f105b3bfd29c0990f99eb1456f562a2108e2e86141c9c6bb113d8c0084346e261ae9c888be0f253ec6fe64b3bb790547331b67807286bf7e523926ec230c42603938166e2a676d08daf973469fa873e6d863d213a84765eaf6afa6a2e7293833eedc5e2306f8be0fe47', CAST(N'2021-09-17T05:39:09.050' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[empleado] ON 

INSERT [dbo].[empleado] ([idempleado], [idusuario], [legajo], [deleted]) VALUES (1, 5, N'13123123213', NULL)
INSERT [dbo].[empleado] ([idempleado], [idusuario], [legajo], [deleted]) VALUES (2, 7, N'asdasdsad', NULL)
INSERT [dbo].[empleado] ([idempleado], [idusuario], [legajo], [deleted]) VALUES (3, 8, N'222222', NULL)
INSERT [dbo].[empleado] ([idempleado], [idusuario], [legajo], [deleted]) VALUES (4, 9, N'erererer', NULL)
SET IDENTITY_INSERT [dbo].[empleado] OFF
GO
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'ADDRESS', N'Address:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'ARS_LABEL', N'Pesos', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BACKUP_COL_FEC', N'Date', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BACKUP_COL_PATH', N'Path', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BACKUP_COL_SIZE', N'File size in bytes', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BACKUP_COL_TYPE', N'Type', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BACKUP_MSG_DESCRIP', N'Do you want to make a new backup?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BACKUP_MSG_RESTORE_DESCRIP', N'Do you want to restore to this backup?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BACKUP_MSG_TITLE', N'Backup', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BAD_DNI', N'Document bad format!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BAD_PHONE', N'Phone number bad format!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BAD_TRAMITE', N'Order number bad format!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BIRTH_DATE', N'Birth date:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BTC_LABEL', N'Bitecoin', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BTN_CLOSE', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BTN_CLOSE_BACKUP', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BTN_CLOSE_PERMISSION', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BTN_COMPOUND_PERMISSION', N'Add compound', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BTN_COPY', N'Copy', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BTN_DEL_PERMISSION', N'Delete', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BTN_LOAD_BACKUP', N'Load backup', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BTN_NEW_BACKUP', N'New backup', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BTN_RETIRO_OK', N'Acept', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'btn_retiro_reject', N'Reject', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BTN_UPDATE_PERMISSION', N'Update', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BUTTON_CANCEL', N'Cancel', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BUTTON_OK', N'OK', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BUY_DATE', N'Buy date', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BUY_ERROR', N'An error has produced buying the order..', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'BUY_SUCCESS', N'You have purchased the order, wait some minutes to see the balance updated in your wallet!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'CBU_CASHIN_LABEL', N'You must enter AR$ ammount', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'CBU_CASHIN_TITLE', N'Enter value', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'CBU_TITLE', N'CBU Query', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'CBU_TITLE_DESCRIP', N'Use this address to make AR$ cash in.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COBRAR_BTN_PROCESS', N'Start process', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COBRAR_FRM_TITLE', N'Charge commissions', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COBRAR_FRM_TITLE_DESCRIP', N'Here is the list of commissions pending collection:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COBRAR_TOTAL_LABEL', N'Total pending receivable:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COBRAR_WAITING', N'Procesando, aguarde un momento...', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COMMISION_DEBTS_NOTIFY_BTN', N'Notify debt', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COMMISION_DEBTS_TITLE', N'Debst report', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COMMISION_DEBTS_TITLE_DESCRIP', N'From here you can see the client debts list.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COMP_CRUD_ADD', N'Add', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COMP_CRUD_ADD_DESCRIP', N'Complete the value here', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COMP_CRUD_ADD_VALUE', N'Add new value', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COMP_CRUD_CLOSE', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COMP_CRUD_DELETE', N'Delete', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COMP_CRUD_DELETE_CONFIRM', N'Do you want to delete this value?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COMP_CRUD_DELETE_OK', N'Delete ok!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COMP_CRUD_DELETE_TITLE', N'Delete', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COMP_CRUD_DESCRIPTION', N'You can edit and add data from here', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COMP_CRUD_TITLE_FAMILY', N'Edit family', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'COMP_CRUD_TITLE_PATENT', N'Edit patents', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'CRYPTO_EXTRACT_SUCCESS', N'Transfer success!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'CRYPTO_EXTRACT_TITLE', N'Money withdrawal', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'CRYPTO_EXTRACT_TXT', N'The withdrawal has a cost of %s, do you want to proceed?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'DOCUMENT_NUMBER', N'Document number:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'DOG_LABEL', N'Doge', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EDIT_FAMILY_SELECTOR_DESCRIP', N'You can choose a family here', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EDIT_FAMILY_SELECTOR_TITLE', N'Choose a family', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EDIT_PATENTE_DESCRIP', N'You can manage the patents here.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EDIT_PATENTE_SELECTOR_DESCRIP', N'You can choose a patent here', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EDIT_PATENTE_SELECTOR_TITLE', N'Choose a patent', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EDIT_PATENTE_TITLE', N'Patent editor', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EXTRACT_ARS_AMMOUNT', N'Ammount:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EXTRACT_ARS_CBU', N'Your CBU:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EXTRACT_ARS_DESCRIP', N'From here request to send money to your bank account', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EXTRACT_ARS_NO_FOUNDS', N'No founds', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EXTRACT_ARS_OK', N'Operation success!.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EXTRACT_ARS_PENDING_DEBTS', N'You have commision pending to payment', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EXTRACT_ARS_TITLE', N'Request extraction', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EXTRACT_ARS_VALUE_LABEL', N'Value to extract:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EXTRACT_ARS_VALUE_LABEL_DESCRIP', N'From here you can request a withdrawal of money to your bank account', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EXTRACT_CRYPTO_WALLET_DESCRIP', N'You can extract your cryptos from here', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EXTRACT_CRYPTO_WALLET_DESTINY', N'Transfer success!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EXTRACT_CRYPTO_WALLET_ORIGIN', N'Origin account:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EXTRACT_CRYPTO_WALLET_TITLE', N'Extract crypto', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'EXTRACT_CRYPTO_WALLET_VALUE', N'Ammount:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'FRM_CHANGE_CONTROL', N'Changes control', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'FRM_CHANGE_CONTROL_BTN_RECOVE', N'Restore changes', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'GRAL_NO_RESULTS', N'Results not found', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'GRAL_OPERATION_SUCCESS', N'Operation success!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'GRAL_UNABLE_TO_PROCESS', N'Unable to process', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'GRAL_YOU_MUST_ENTER_A_VALUE', N'You must enter a value..', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'HELLO', N'Hello', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'INTEGRITY_ERROR', N'Violation of integrity, the administrator will be notified', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'INTEGRITY_USERS_CORRUPT', N'Violation of integrity, the administrator will be notified', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'INTEGRITY_USERS_ENTITY_FAIL', N'Violation of integrity, the administrator will be notified', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'INTEGRITY_USERS_NOT_FOUND', N'Violation of integrity, the administrator will be notified', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LANG_CHOOSE_TITLE', N'Choose language', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LANGUAGE_CHANGE_ERROR', N'There was a problem trying to change the language', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LANGUAGE_CHANGE_OK', N'The language has been successfully changed', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOG_ACTIV_TITLE', N'Activation tag', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOG_BTN_CLOSE', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOG_BTN_SEARCH', N'Search', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOG_COL_ACTIVIDAD', N'Activity', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOG_COL_FECHA', N'Log date', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOG_COL_ID', N'LogId', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOG_COL_TEXTO', N'Description', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOG_COL_USUARIO', N'User', NULL)
GO
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOG_FROM_TITLE', N'From:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOG_SEARCH_DESCRIP', N'Search in the log database', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOG_SEARCH_TITLE', N'Search', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOG_TEXT_TITLE', N'Text:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOG_TO_TITLE', N'To:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOGIN', N'Login', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOGIN_BTN_CANCEL', N'Cancel', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOGIN_BTN_INGRESAR', N'Enter', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOGIN_INPUT_ERROR', N'Email and password required!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOGIN_INPUT_ERROR_TITLE', N'Warning', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOGIN_SERVICE_ERROR', N'The email or password was not correct!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOGIN_TITLE_1', N'Login', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOGIN_TITLE_EMAIL', N'Write your email', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LOGIN_TITLE_PASSWORD', N'Write your password', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'LTC_LABEL', N'Litecoin', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_BTN_LOGIN', N'Login', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_CHANGE_LANGUAGE', N'Choose language', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_BACKUP', N'Backup', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_BUY', N'Buy', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_CASH_IN', N'Enter ammount', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_CBU', N'See bank codes', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_DEPOSIT', N'Enter balance', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_EXIT', N'Exit', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_EXTRACT', N'Withdraw balance', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_EXTRACT_CRYPTO', N'Withadrawal crypto', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_IT', N'TI', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_IT_ADD_USER', N'Add new user', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_IT_BACKUP', N'Backup', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_IT_LANG_MANAGER', N'Manage language', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_IT_USER_MANAGER', N'User control', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_IT_USER_PERM_MANAGER', N'Manage user permission', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_LANGUAGE', N'Languages', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_LOG_SEARCH', N'Log search', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_LOGIN', N'Login', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_MY_SELLS', N'My publications', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_MY_WALLETS', N'My wallets', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_NOTIFICATIONS', N'Notifications', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_OPERATE', N'Operate', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_PERMISSION', N'Permissions', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_PROFILE', N'Profile', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_RECOMENDATIONS', N'Recommendations', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_SEARCH', N'Search', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_SELL', N'Sell', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_SIGNOUT', N'Sign out', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_SIGNUP', N'Register', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_START', N'Start', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_MENU_USER', N'Users', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_SPLASH_ACTIVITY', N'Click to select an operation.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MAIN_SPLASH_TITLE', N'Click to enter the system', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MY_BUYS', N'My buys', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MY_SELL_FINISH_CONFIRM', N'Select an option', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MY_SELL_FINISH_SUCCESS', N'Order finished success!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MY_SELL_FINISH_TITLE', N'Do you want to finish this sell order?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MY_SELL_ORDERS_PAUSE', N'Finish order', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'MY_SELL_ORDERS_TITLE', N'My sell orders', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'NOTIF_BUY_OK_SUCCESS', N'Hi %c! the purchase of your order was successful!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'NOTIF_BUY_SUCCESS', N'Congratulations, your order was buy by %c', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'NOTIF_CLOSE', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'NOTIF_DATE', N'Date', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'NOTIF_DESCRIP', N'This are your notifications', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'NOTIF_TEXT', N'Message', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'NOTIF_TITLE', N'Notifications', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'OP_BTN_BUY', N'Buy', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'OP_BTN_CLOSE', N'Cancel', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'OP_DETAIL_LABEL', N'Sell order detail:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'OP_OFFER', N'Offer:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'OP_REQ', N'For:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'OP_SELLER', N'Published by:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'OP_TAX_LABEL', N'Taxes:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'OP_TAX_LABEL_INFO', N'In this section you can see the tax list for this operation.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'OP_TITLE', N'Order', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'OP_TOTAL', N'Final balance:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'ORDER_NUMER', N'Order numer:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'PERMISSION_ABM', N'Permission list:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'PERMISSION_LABEL', N'In this section you can manage the use permission.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'PERMISSION_TITLE', N'Permission', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'PHONE_NUMBER', N'Phone number:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'PROFILE_ADDRESS', N'Address:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'PROFILE_BIRTH_DATE', N'Birth Date:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'PROFILE_CBU', N'CBU', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'PROFILE_CLOSE', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'PROFILE_DOC_NUMBER', N'Id number:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'PROFILE_FORM', N'Client profile', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'PROFILE_OK', N'Save', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'PROFILE_PHONE', N'Phone number:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'PROFILE_TRAMITE', N'Tramit number:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'PROFILE_TYPE_DOC', N'Document type:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'RECOM_CLOSE', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'RECOM_DESCRIP', N'In this section you can see the purchase recommendations suitable for you.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'RECOM_TITLE', N'Recomendations', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'RECOM_VIEW', N'View', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REGISTER_INPUT_EMAIL_ERROR', N'Email wrong format!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REGISTER_INPUT_ERROR', N'Validate the data required to register!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REGISTER_INPUT_ERROR_TITLE', N'Advice', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REGISTER_INPUT_SUCCESS', N'User created successfully!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REPORT_DBT_DESCRIP', N'In this section you can check the earnings collected / receivable.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REPORT_DBT_DESDE', N'From', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REPORT_DBT_DOWNLOAD', N'Download report', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REPORT_DBT_HASTA', N'To', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REPORT_DBT_PAY', N'Charge commissions', NULL)
GO
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REPORT_DBT_REPORT_GENERATED', N'Report generated success!!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REPORT_DBT_REPORT_SAVE', N'Save report', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REPORT_DBT_SEARCH', N'Search', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REPORT_DBT_TITLE', N'Debt report', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REPORT_DBT_TOTAL', N'Total:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'REPORT_DBT_TYPE', N'Type', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'RETIRO_TITLE', N'Withdrawal', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'RETIRO_TITLE_DESCRIP', N'You can approve / reject orders from here.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_BTN_BY', N'By', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_BTN_CLOSE', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_BTN_SEARCH', N'Search', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_BTN_VIEW', N'View', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_CBU_BTN_CASHIN', N'Enter founds', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_CBU_BTN_CLOSE', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_CBU_BTN_SEARCH', N'Search', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_CBU_CLIENT', N'CBU', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_CBU_DNI', N'DNI', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_CBU_EMAIL', N'Email', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_CBU_TDOC', N'Doc type', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_CBU_TITLE', N'Search CBU', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_CBU_TITLE_DESCRIP', N'Find cbu clients from here:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_CBU_WRITE', N'Write the CBU:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_COL_ID', N'Id', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_COL_OFFER', N'Offer', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_COL_PRICE', N'Price', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_COL_QTY', N'Quantity', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_COL_REQ', N'Request', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_COL_SELLER', N'Seller', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_COL_STATUS', N'Status', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_DESCRIP', N'In this section you can search different sell orders.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEARCH_TITLE', N'Search', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SEEL_TAX_LABEL', N'The tax operation is %d.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SELL_CLOSE', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SELL_INPUT', N'You offer:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SELL_MONEY', N'Money:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SELL_MONEY_EXCED', N'You cant exced market price', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SELL_MONEY_FREE_PRICE', N'Free price', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SELL_MONEY_MARKET_PRICE', N'Market price', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SELL_MONEY_MISMATCH', N'You cant chose the same money booth', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SELL_MONEY_SUCCESS', N'Order published success!!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SELL_PUBLISH', N'Publish', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SELL_RECEIVE', N'You receive:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SELL_TAX', N'Tax rate', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SELL_TITLE', N'Publish sell order', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SIGNUP_ALIAS', N'Write your alias:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SIGNUP_CANCEL', N'Cancel', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SIGNUP_DNI_REPEATED', N'This document number is already in use!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SIGNUP_EMAIL', N'Write your email:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SIGNUP_EMAIL_REPEATED', N'This email is already in use!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SIGNUP_LEGACY', N'Employee legacy number:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SIGNUP_NAME', N'Write your name:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SIGNUP_OK', N'OK', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SIGNUP_PWD', N'Write your password:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SIGNUP_SURNAME', N'Write your surname:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SINGUP_DESCRIP', N'Complete to register a employee user.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SINGUP_DESCRIPTION', N'Complete this information to create your account:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'SINGUP_TITLE', N'Register new user', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TAX_NETWORK_FEE', N'Network transference fee', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TAX_NETWORK_FEE_ERROR', N'Unable to fetch transaction fee.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TAX_PLATFORM_FOR_BUY', N'Platform fee for this operation', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TAX_PLATFORM_FOR_SELL', N'Platform fee for this operation', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TEMPLATE_CONFIRM_DELETE', N'Do you want to delete this key and in the associated languages?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TEMPLATE_EDITOR', N'Dictionary edit', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TEMPLATE_EDITOR_ADD', N'Add key', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TEMPLATE_EDITOR_ADD_OK', N'Key created ok!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TEMPLATE_EDITOR_DELETE', N'Delete key', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TEMPLATE_EDITOR_DELETE_OK', N'Key deleted ok!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TREE_CRUD_ADD_FAMILY', N'+ Family', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TREE_CRUD_ADD_PATENT', N'+ Patent', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TREE_CRUD_CLOSE', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TREE_CRUD_DELETE', N'Delete', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TREE_CRUD_FAMILY', N'CRUD Family', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TREE_CRUD_PATENT', N'CRUD patent', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TREE_CRUD_SAVE', N'Save', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TREE_CRUD_VIEW', N'View', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TREE_DESCRIP_EDITOR', N'Remember you edit the familys separatedly', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TREE_FAMILY_EXISTS', N'The family already exists!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TREE_PATENT_EXISTS', N'The patent already exists!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TREE_TITLE_EDITOR', N'Permission editor', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TXT_ALIAS', N'Alias:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TXT_BACKUP_DESCRIP', N'Manage here the system backups.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TXT_BACKUP_TITLE', N'Backup', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TXT_BACKUP_TITLE_LIST', N'Your previous backups.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TXT_BANK', N'Banck:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'TXT_CBU', N'CBU:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'UI_LANG_NEW_KEY', N'New word', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'UI_LANG_NEW_KEY_DESCRIP', N'Write the key value for the new word', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'UI_LANG_NEW_KEY_TITLE', N'Key', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'UI_LANG_NEW_VALUE_TITLE', N'Traduction', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USER_STATUS_ALIAS', N'User:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USER_STATUS_LABEL', N'Choouse the status:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USER_STATUS_TITLE', N'Set state', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USER_TREE_EDITOR_DESCRIP', N'You can edit from this module, the permission of each user.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USER_TREE_EDITOR_TITLE', N'User/permission editor', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_CHANGE_CLOSE', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_CHANGE_CONFIRM', N'Confirm restore', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_CHANGE_RESTORE_SUCCESS', N'Restore success!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_CHANGE_TITLE', N'Do you want to restore the entity at this point?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_COL_EMAIL', N'Email', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_COL_ID', N'Id', NULL)
GO
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_COL_NAME', N'Name', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_COL_SURNAME', N'Surname', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_COL_TYPE', N'User type', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_CONTROL_BTN_CHANGE', N'Change ctrl.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_CONTROL_COL_CHANGE_ADDRESS', N'Address', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_CONTROL_COL_CHANGE_EMAIL', N'Email', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_CONTROL_COL_CHANGE_FEC_NAC', N'Birth date', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_CONTROL_COL_CHANGE_NUM', N'Number', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_CONTROL_COL_CHANGE_OPERATOR', N'Rollback by', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_CONTROL_COL_CHANGE_PHONE', N'Phone', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_CONTROL_COL_CHANGE_TDOC', N'Doc type', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_CONTROL_COL_CHANGRE_NUM_TRAMITE', N'N° operation', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_LANG_ALL_DELETE_CONFIRM_TITLE', N'Do you want to delete this language and all his words?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_LANG_COL_CODE', N'Key', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_LANG_COL_VALUE', N'Traduction', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_LANG_DELETE_CONFIRM', N'Delete word of language', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_LANG_DELETE_CONFIRM_TITLE', N'Do you want to delete?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_LANG_UI_ADD_LANGUAGE', N'Add', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_LANG_UI_CLOSE_LANGUAGE', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_LANG_UI_DEL_LANGUAGE', N'Delete', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_LANG_UI_DESCRIP', N'In this section you customize the system language.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_LANG_UI_EDIT_LANGUAGE', N'Edit word', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_LANG_UI_NEW_LANGUAGE', N'New', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_LANG_UI_REFRESH_LANGUAGE', N'Refresh', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_LANG_UI_TITLE', N'Language editor', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_LANG_UPD_OK', N'Language updated success!!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_PERM_ADD_CONFIRM_DESCRIP', N'Select an option', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_PERM_ADD_CONFIRM_TITLE', N'Do you want add a new permission?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_PERM_ADD_DENY', N'It is not allowed to add within an atomic permission', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_PERM_ADD_ERROR', N'You must select a permission from the tree and later in the permission list', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_PERM_BTN', N'Edit permission', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_PERM_COMP_ADD_DESCRIP', N'New compound permission', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_PERM_COMP_ADD_TITLE', N'New compound permission', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_PERM_DEL_CONFIRM_DESCRIP', N'Select an option.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_PERM_DEL_CONFIRM_TITLE', N'Do you want to delete?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_PERM_DEL_REQ', N'You mus select a permission', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_PERM_DEL_SUCESS', N'Permission deleted!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_SEARCH', N'User control', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_SEARCH_BTN', N'Search', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_SEARCH_CLOSE', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_SEARCH_DESCRIP', N'In this section you can make changes in user attributes and permissions.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_SEARCH_LABEL', N'Write user name/surname/email or part of it:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_SEARCHER', N'User searcher', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_TXT_CTRL_DESCRIP', N'Here you can see the entity changes and restore if you want.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'USR_TXT_CTRL_TITLE', N'Changes control', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'WALLET_ADDRESS', N'Address', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'WALLET_BTN_CLOSE', N'Close', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'WALLET_BTN_REFRESH', N'Refresh', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'WALLET_DESCRIP', N'You will see your moneys.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'WALLET_MONEY', N'Money', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'WALLET_PENDING_VALUE', N'Pending balance', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'WALLET_READY_VALUE', N'Available balance', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'WALLET_TITLE', N'Your wallets', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'WARNING_TITLE', N'AVISO:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'WARNING_TITLE_DESCRIP', N'You must transfer using the same CBU registerd in your profile.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'WELCOME', N'Welcome', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'YOUR_DOCUMENTS', N'Your document info:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'YOUR_USER_LABEL', N'Your user info:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'YOUR_WALLETS_DESCRIPT', N'Click a wallet to see his info.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ENG', N'YOUR_WALLETS_LABEL', N'Your wallets...', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'ADDRESS', N'Dirección:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'ARS_LABEL', N'Pesos', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BACKUP_COL_FEC', N'Fecha', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BACKUP_COL_PATH', N'Path', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BACKUP_COL_SIZE', N'Tamaño en bytes', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BACKUP_COL_TYPE', N'Tipo', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BACKUP_MSG_DESCRIP', N'¿Queres realizar un nuevo backup?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BACKUP_MSG_RESTORE_DESCRIP', N'¿Queres cargar este backup?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BACKUP_MSG_TITLE', N'Backup', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BAD_DNI', N'Formato de DNI incorrecto.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BAD_PHONE', N'Formato de telefono incorrecto.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BAD_TRAMITE', N'Formato número de tramite incorrecto.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BIRTH_DATE', N'Fecha de nacimiento:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BTC_LABEL', N'Bitecoin', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BTN_CLOSE', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BTN_CLOSE_BACKUP', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BTN_CLOSE_PERMISSION', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BTN_COMPOUND_PERMISSION', N'Agregar compuesto', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BTN_COPY', N'Copiar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BTN_DEL_PERMISSION', N'Borrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BTN_LOAD_BACKUP', N'Cargar backup', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BTN_NEW_BACKUP', N'Nuevo backup', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BTN_RETIRO_OK', N'Aceptar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BTN_RETIRO_REJECT', N'Rechazar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BTN_UPDATE_PERMISSION', N'Actualizar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BUTTON_CANCEL', N'Cancelar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BUTTON_OK', N'Aceptar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BUY_DATE', N'Fecha de compra', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BUY_ERROR', N'Se produjo un error no se podra realizar la compra!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'BUY_SUCCESS', N'Haz comprado la orden, espera unos minutos para ver el saldo actualizado en tu billetera!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'CBU_CASHIN_LABEL', N'Debe ingresar un valor en AR$', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'CBU_CASHIN_TITLE', N'Ingresar fondos', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'CBU_TITLE', N'Consulta de CBU', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'CBU_TITLE_DESCRIP', N'Usa esta dirección para acreditar AR$.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COBRAR_BTN_PROCESS', N'Cobrar comisiones:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COBRAR_FRM_TITLE', N'Cobrar comisiones', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COBRAR_FRM_TITLE_DESCRIP', N'Aqui se ve la lista de comisiones pendientes por cobrar:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COBRAR_TOTAL_LABEL', N'Total pendiente por cobrar:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COMMISION_DEBTS_NOTIFY_BTN', N'Notificar deuda', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COMMISION_DEBTS_TITLE', N'Reporte de deudores', NULL)
GO
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COMMISION_DEBTS_TITLE_DESCRIP', N'Aqui se ve la lista de comisiones pendientes por cobrar.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COMP_CRUD_ADD', N'Agregar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COMP_CRUD_ADD_DESCRIP', N'Complete el valor', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COMP_CRUD_ADD_VALUE', N'Agregar nuevo valor', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COMP_CRUD_CLOSE', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COMP_CRUD_DELETE', N'Borrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COMP_CRUD_DELETE_CONFIRM', N'¿Quiere borrar este valor?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COMP_CRUD_DELETE_OK', N'Borrado ok!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COMP_CRUD_DELETE_TITLE', N'Borrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COMP_CRUD_DESCRIPTION', N'Desde aqui podes borrar y agregar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COMP_CRUD_TITLE_FAMILY', N'Editar familias', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'COMP_CRUD_TITLE_PATENT', N'Editar patentes', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'CRYPTO_EXTRACT_SUCCESS', N'Transferencia exitosa!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'CRYPTO_EXTRACT_TITLE', N'Extraer cripto moneda', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'CRYPTO_EXTRACT_TXT', N'El valor de la operacion sera %s, quiere proceder?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'DOCUMENT_NUMBER', N'DNI:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'DOG_LABEL', N'Doge', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EDIT_FAMILY_SELECTOR_DESCRIP', N'Elige una familia desde aqui', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EDIT_FAMILY_SELECTOR_TITLE', N'Elige una familia', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EDIT_PATENTE_DESCRIP', N'Desde aqui podes crear o borrar patentes', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EDIT_PATENTE_SELECTOR_DESCRIP', N'Desde aqui podes elegir una patente', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EDIT_PATENTE_SELECTOR_TITLE', N'Selecciona una patente', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EDIT_PATENTE_TITLE', N'Editar patentes', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EXTRACT_ARS_AMMOUNT', N'Saldo:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EXTRACT_ARS_CBU', N'Tú CBU:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EXTRACT_ARS_DESCRIP', N'Desde aqui solicitar enviar dinero a tu cuenta bancaria', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EXTRACT_ARS_NO_FOUNDS', N'No tenes fondos suficientes.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EXTRACT_ARS_OK', N'Operación exitosa.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EXTRACT_ARS_PENDING_DEBTS', N'Tenes comisiones pendientes de pagar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EXTRACT_ARS_TITLE', N'Solicitar extracción', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EXTRACT_ARS_VALUE_LABEL', N'Valor a extraer:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EXTRACT_ARS_VALUE_LABEL_DESCRIP', N'De aqui podes pedir un retiro de dinero a tu cuenta bancaria', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EXTRACT_CRYPTO_WALLET_DESCRIP', N'De aqui podes extraer tus crypto.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EXTRACT_CRYPTO_WALLET_DESTINY', N'Dirección destino:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EXTRACT_CRYPTO_WALLET_ORIGIN', N'Cuenta origen:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EXTRACT_CRYPTO_WALLET_TITLE', N'Extraer crypto', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'EXTRACT_CRYPTO_WALLET_VALUE', N'Valor a transferir:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'FRM_CHANGE_CONTROL', N'Control de cambios', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'FRM_CHANGE_CONTROL_BTN_RECOVE', N'Recuperar cambio', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'GRAL_NO_RESULTS', N'No se han encontrado resultados', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'GRAL_OPERATION_SUCCESS', N'Operación completa!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'GRAL_UNABLE_TO_PROCESS', N'No se pudo procesar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'GRAL_YOU_MUST_ENTER_A_VALUE', N'Debes ingresar un valor...', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'HELLO', N'Hola', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'INTEGRITY_ERROR', N'Violacion a la integridad, se notificara al administrador', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'INTEGRITY_USERS_CORRUPT', N'Violacion a la integridad, se notificara al administrador', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'INTEGRITY_USERS_ENTITY_FAIL', N'Violacion a la integridad, se notificara al administrador', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'INTEGRITY_USERS_NOT_FOUND', N'Violacion a la integridad, se notificara al administrador', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LANG_CHOOSE_TITLE', N'Seleccionar idioma', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LANGUAGE_CHANGE_ERROR', N'Error al cambiar el lenguaje', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LANGUAGE_CHANGE_OK', N'Idioma cargado con exito', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOG_ACTIV_TITLE', N'Actividad', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOG_BTN_CLOSE', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOG_BTN_SEARCH', N'Buscar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOG_COL_ACTIVIDAD', N'Actividad', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOG_COL_FECHA', N'Fecha log', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOG_COL_ID', N'LogId', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOG_COL_TEXTO', N'Descripcion', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOG_COL_USUARIO', N'Usuario', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOG_FROM_TITLE', N'Desde:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOG_SEARCH_DESCRIP', N'Buscar en los registros', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOG_SEARCH_TITLE', N'Buscar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOG_TEXT_TITLE', N'Texto:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOG_TO_TITLE', N'Hasta:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOGIN', N'Iniciar sesion', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOGIN_BTN_CANCEL', N'Cancelar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOGIN_BTN_INGRESAR', N'Ingresar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOGIN_INPUT_ERROR', N'Email y contraseña requeridos!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOGIN_INPUT_ERROR_TITLE', N'Aviso', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOGIN_SERVICE_ERROR', N'Usuario o contraseña incorrectos!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOGIN_TITLE_1', N'Iniciar sesión', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOGIN_TITLE_EMAIL', N'Escriba su email', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LOGIN_TITLE_PASSWORD', N'Escriba su password', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'LTC_LABEL', N'Litecoin', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_BTN_LOGIN', N'Ingresar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_CHANGE_LANGUAGE', N'Cambiar idioma', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_BACKUP', N'Backup', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_BUY', N'Comprar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_CASH_IN', N'Ingresar fondos', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_CBU', N'Ver cbu', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_DEPOSIT', N'Ingresar saldo', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_EXIT', N'Salir', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_EXTRACT', N'Retirar saldo', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_EXTRACT_ARS', N'Extracciones ARS', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_EXTRACT_CRYPTO', N'Extraer crypto', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_IT', N'IT', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_IT_ADD_USER', N'Alta de usuario', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_IT_BACKUP', N'Backup', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_IT_LANG_MANAGER', N'Gestion de idiomas', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_IT_USER_MANAGER', N'Gestion de usuarios', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_IT_USER_PERM_MANAGER', N'Gestionar permisos de usuarios', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_LANGUAGE', N'Idioma', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_LOG_SEARCH', N'Buscar en bitacora', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_LOGIN', N'Iniciar sesión', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_MY_SELLS', N'Mis publicaciones', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_MY_WALLETS', N'Mis billeteras', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_NOTIFICATIONS', N'Notificaciones', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_OPERATE', N'Operar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_PERMISSION', N'Permisos', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_PROFILE', N'Perfil', NULL)
GO
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_RECOMENDATIONS', N'Recomendaciones', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_SEARCH', N'Buscar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_SELL', N'Vender', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_SIGNOUT', N'Cerrar sesión', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_SIGNUP', N'Registrarse', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_START', N'Inicio', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_MENU_USER', N'Usuarios', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_SPLASH_ACTIVITY', N'Haga click para realizar una operación.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MAIN_SPLASH_TITLE', N'Haga click para ingresar al sistema.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MY_BUYS', N'Mis compras', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MY_SELL_FINISH_CONFIRM', N'Escoja una opción.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MY_SELL_FINISH_SUCCESS', N'Orden finalizada con exito!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MY_SELL_FINISH_TITLE', N'¿Seguro desea finalizar esta orden de venta?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MY_SELL_ORDERS_PAUSE', N'Finalizar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'MY_SELL_ORDERS_TITLE', N'Mis ordenes de venta', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'NOTIF_BUY_OK_SUCCESS', N'Hola %c! la compra de la orden fue exitosa!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'NOTIF_BUY_SUCCESS', N'Felicitaciones tu orden fue comprada por %c', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'NOTIF_CLOSE', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'NOTIF_DATE', N'Fecha envio', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'NOTIF_DESCRIP', N'Estas son tus notificaciones', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'NOTIF_TEXT', N'Mensaje', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'NOTIF_TITLE', N'Notificaciones', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'OP_BTN_BUY', N'Comprar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'OP_BTN_CLOSE', N'Cancelar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'OP_DETAIL_LABEL', N'Detalle de venta:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'OP_OFFER', N'Pide:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'OP_REQ', N'Por:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'OP_SELLER', N'Publicado por:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'OP_TAX_LABEL', N'Impuestos:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'OP_TAX_LABEL_INFO', N'En esta seccón ves el detalle de impuestos.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'OP_TITLE', N'Ordén', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'OP_TOTAL', N'Costo total:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'ORDER_NUMER', N'Número de tramite:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'PERMISSION_ABM', N'Lista de permisos:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'PERMISSION_LABEL', N'En esta seccion se puede agregar o quitar permisos a usuarios.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'PERMISSION_TITLE', N'Permisos', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'PHONE_NUMBER', N'Número de telefono:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'PROFILE_ADDRESS', N'Dirección:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'PROFILE_BIRTH_DATE', N'Fecha de nacimiento:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'PROFILE_CBU', N'CBU', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'PROFILE_CLOSE', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'PROFILE_DOC_NUMBER', N'Número de documento:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'PROFILE_FORM', N'Perfil de cliente', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'PROFILE_OK', N'Guardar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'PROFILE_PHONE', N'Telefono:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'PROFILE_TRAMITE', N'Número de tramite:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'PROFILE_TYPE_DOC', N'Tipo de documento:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'RECOM_CLOSE', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'RECOM_DESCRIP', N'En esta sección veras ofertas para tí.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'RECOM_TITLE', N'Recomendaciones', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'RECOM_VIEW', N'Ver', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REGISTER_INPUT_EMAIL_ERROR', N'Formato de email erroneo!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REGISTER_INPUT_ERROR', N'Valide los datos requeridos para registrar!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REGISTER_INPUT_ERROR_TITLE', N'Aviso', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REGISTER_INPUT_SUCCESS', N'Usuario creado con exito!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REPORT_DBT_DESCRIP', N'En esta sección podes consultar las ganancias cobradas / por cobrar.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REPORT_DBT_DESDE', N'Desde', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REPORT_DBT_DOWNLOAD', N'Descargar reporte', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REPORT_DBT_HASTA', N'Hasta', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REPORT_DBT_PAY', N'Cobrar comisiones', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REPORT_DBT_REPORT_GENERATED', N'Reporte generado!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REPORT_DBT_REPORT_SAVE', N'Guardar reporte', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REPORT_DBT_SEARCH', N'Buscar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REPORT_DBT_TITLE', N'Reporte de cobros', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REPORT_DBT_TOTAL', N'Total:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'REPORT_DBT_TYPE', N'Tipo', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'RETIRO_TITLE', N'Extracciones', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'RETIRO_TITLE_DESCRIP', N'De aqui podes aprobar  / rechazar extracciones.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_BTN_BY', N'Por', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_BTN_CLOSE', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_BTN_SEARCH', N'Buscar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_BTN_VIEW', N'Ver', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_CBU_BTN_CASHIN', N'Ingresar fondos', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_CBU_BTN_CLOSE', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_CBU_BTN_SEARCH', N'Buscar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_CBU_CLIENT', N'CBU', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_CBU_DNI', N'DNI', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_CBU_EMAIL', N'Email', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_CBU_TDOC', N'Tipo doc', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_CBU_TITLE', N'Buscar CBU', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_CBU_TITLE_DESCRIP', N'De aqui podes buscar CBU de los clientes', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_CBU_WRITE', N'Escriba el CBU:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_COL_ID', N'N°', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_COL_OFFER', N'Ofrece', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_COL_PRICE', N'Precio', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_COL_QTY', N'Cantidad', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_COL_REQ', N'Pide', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_COL_SELLER', N'Vendedor', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_COL_STATUS', N'Estado', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_DESCRIP', N'En esta sección podes buscar por dif ofertas de ventas.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEARCH_TITLE', N'Buscador', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SEEL_TAX_LABEL', N'La venta tendra una comisión de %d.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SELL_CLOSE', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SELL_INPUT', N'Tú ofreces:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SELL_MONEY', N'Moneda:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SELL_MONEY_EXCED', N'El valor ingresado no puede superar la cotizacion de mercado de', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SELL_MONEY_FREE_PRICE', N'Libre', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SELL_MONEY_MARKET_PRICE', N'Cotización actual', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SELL_MONEY_MISMATCH', N'No puede elegirse la misma moneda!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SELL_MONEY_SUCCESS', N'Ordén publicada!', NULL)
GO
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SELL_PUBLISH', N'Publicar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SELL_RECEIVE', N'Tú recibiras:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SELL_TAX', N'Tarifa de impuestos', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SELL_TITLE', N'Publicar ordén de venta', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SIGNUP_ALIAS', N'Escriba su alias:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SIGNUP_CANCEL', N'Cancelar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SIGNUP_DNI_REPEATED', N'El número de documento ya se encuentra en uso!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SIGNUP_EMAIL', N'Escriba su email:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SIGNUP_EMAIL_REPEATED', N'Este email ya se encuentra en uso!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SIGNUP_LEGACY', N'Legajo de empleado:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SIGNUP_NAME', N'Escriba su nombre:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SIGNUP_OK', N'Aceptar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SIGNUP_PWD', N'Escriba su password:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SIGNUP_SURNAME', N'Escriba su apellido:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SINGUP_DESCRIP', N'Completar para crear usuario empleado.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SINGUP_DESCRIPTION', N'Completa estos datos para poder crear tu cuenta:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'SINGUP_TITLE', N'Registrar nuevo usuario', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TAX_NETWORK_FEE', N'Costo de transferencia de la red', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TAX_NETWORK_FEE_ERROR', N'No se puede obtener el costo de transferencia.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TAX_PLATFORM_FOR_BUY', N'Comision de la operación', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TAX_PLATFORM_FOR_SELL', N'Comision de la operación', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TEMPLATE_CONFIRM_DELETE', N'¿Seguro desea borrar la clave, se borrara en todos los idiomas que la tengan?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TEMPLATE_EDITOR', N'Editar diccionario', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TEMPLATE_EDITOR_ADD', N'Agregar clave', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TEMPLATE_EDITOR_ADD_OK', N'Clave creada ok!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TEMPLATE_EDITOR_DELETE', N'Borrar clave', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TEMPLATE_EDITOR_DELETE_OK', N'Clave borrada ok!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TREE_CRUD_ADD_FAMILY', N'+ Familia', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TREE_CRUD_ADD_PATENT', N'+ Patente', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TREE_CRUD_CLOSE', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TREE_CRUD_DELETE', N'Borrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TREE_CRUD_FAMILY', N'ABM Familia', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TREE_CRUD_PATENT', N'ABM Patente', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TREE_CRUD_SAVE', N'Guardar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TREE_CRUD_VIEW', N'Ver', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TREE_DESCRIP_EDITOR', N'Recorda que las familias se edita separads.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TREE_FAMILY_EXISTS', N'La familia ya existe!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TREE_PATENT_EXISTS', N'La patente ya existe!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TREE_TITLE_EDITOR', N'Editor de familias/permisos', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TXT_ALIAS', N'Alias:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TXT_BACKUP_DESCRIP', N'Maneje aqui la creación carga de backups.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TXT_BACKUP_TITLE', N'Backup', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TXT_BACKUP_TITLE_LIST', N'Estos son los backups que has realizado.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TXT_BANK', N'Banco:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'TXT_CBU', N'CBU:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'UI_LANG_NEW_KEY', N'Nueva palabra', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'UI_LANG_NEW_KEY_DESCRIP', N'Escriba la nueva palabra que formara parte del lenguaje.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'UI_LANG_NEW_KEY_TITLE', N'Clave', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'UI_LANG_NEW_VALUE_TITLE', N'Traducción', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USER_STATUS_ALIAS', N'Usuario:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USER_STATUS_LABEL', N'Seleccione el estado:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USER_STATUS_TITLE', N'Cambiar estado', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USER_TREE_EDITOR_DESCRIP', N'Desde aqui podes configurar los permisos que tiene cada usuario.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USER_TREE_EDITOR_TITLE', N'Editor usuario/permisos', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_CHANGE_CLOSE', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_CHANGE_CONFIRM', N'Confirmar restore?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_CHANGE_RESTORE_SUCCESS', N'Restore exitoso!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_CHANGE_TITLE', N'¿Seguro deseas recuperar la entidad a este punto?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_COL_EMAIL', N'Email', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_COL_ID', N'Id', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_COL_NAME', N'Nombre', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_COL_SURNAME', N'Apellido', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_COL_TYPE', N'Tipo de usuario', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_CONTROL_BTN_CHANGE', N'Ctrl. cambios', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_CONTROL_COL_CHANGE_ADDRESS', N'Direccón', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_CONTROL_COL_CHANGE_EMAIL', N'Email', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_CONTROL_COL_CHANGE_FEC_NAC', N'Fecha nacimiento', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_CONTROL_COL_CHANGE_NUM', N'Número', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_CONTROL_COL_CHANGE_OPERATOR', N'Rollback por', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_CONTROL_COL_CHANGE_PHONE', N'Telefono', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_CONTROL_COL_CHANGE_TDOC', N'Tipo documento', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_CONTROL_COL_CHANGRE_NUM_TRAMITE', N'N° operation', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_ALL_DELETE_CONFIRM_TITLE', N'¿Seguro queres borrar lenguaje, se borraran todas las palabras?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_COL_CODE', N'Clave', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_COL_VALUE', N'Traducción', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_DELETE_CONFIRM', N'Borrar palabra', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_DELETE_CONFIRM_TITLE', N'¿Seguro queres borrar esta palabra?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_NEW', N'Crear nuevo idioma', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_NEW_ERROR', N'Hubo un error al crear el idioma', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_NEW_NAME', N'Nombre del idioma', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_NEW_OK', N'Idioma nuevo creado!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_NEW_REQUIRED', N'Debe completar un valor para crear el idioma', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_UI_ADD_LANGUAGE', N'Agregar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_UI_CLOSE_LANGUAGE', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_UI_DEL_LANGUAGE', N'Borrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_UI_DESCRIP', N'En esta sección podes editar los idiomas.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_UI_EDIT_LANGUAGE', N'Editar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_UI_NEW_LANGUAGE', N'Nuevo', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_UI_REFRESH_LANGUAGE', N'Actualizar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_UI_TITLE', N'Editor de idiomas', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_UPD_OK', N'Lenguage actualizad correctamente', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_LANG_UPD_REQUIRED', N'Debe completar un valor', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_PERM_ADD_CONFIRM_DESCRIP', N'Elija una opción', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_PERM_ADD_CONFIRM_TITLE', N'¿Quieres agregar un nuevo permiso?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_PERM_ADD_DENY', N'No se puede agregar un permiso compuesto a uno atomico', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_PERM_ADD_ERROR', N'Debes elegir items de ambas listas primero', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_PERM_BTN', N'Editar permisos', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_PERM_COMP_ADD_DESCRIP', N'Nuevo permiso compuesto', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_PERM_COMP_ADD_TITLE', N'Nuevo permiso compuesto', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_PERM_DEL_CONFIRM_DESCRIP', N'Eliga una opción', NULL)
GO
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_PERM_DEL_CONFIRM_TITLE', N'Seguro que desea borrar?', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_PERM_DEL_REQ', N'Debe seleccionar un permiso', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_PERM_DEL_SUCESS', N'Permiso borrado!', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_SEARCH', N'Usuarios', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_SEARCH_BTN', N'Buscar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_SEARCH_CLOSE', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_SEARCH_DESCRIP', N'En esta seccion puede hacer cambios en caract. de los usuarios.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_SEARCH_LABEL', N'Escriba nombre/apellido/email o parte:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_SEARCHER', N'Buscador de usuarios', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_TXT_CTRL_DESCRIP', N'Aqui podes ver los cambios realizados y recuperarlos.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'USR_TXT_CTRL_TITLE', N'Control de cambos', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'WALLET_ADDRESS', N'Dirección', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'WALLET_BTN_CLOSE', N'Cerrar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'WALLET_BTN_REFRESH', N'Actualizar', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'WALLET_DESCRIP', N'Aquí veras tus distintas monedas.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'WALLET_MONEY', N'Moneda', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'WALLET_PENDING_VALUE', N'Saldo pendiente', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'WALLET_READY_VALUE', N'Saldo disponible', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'WALLET_TITLE', N'Tús billeteras', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'WARNING_TITLE', N'AVISO:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'WARNING_TITLE_DESCRIP', N'Debes transferir del mismo CBU que tenes registrado en tú perfil.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'WELCOME', N'Bienvenido', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'YOUR_DOCUMENTS', N'Tú documentación:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'YOUR_USER_LABEL', N'Tú usuario:', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'YOUR_WALLETS_DESCRIPT', N'Haz click sobre una billetera para ver su info.', NULL)
INSERT [dbo].[idioma_palabras] ([code], [clave], [valor], [deleted]) VALUES (N'ES', N'YOUR_WALLETS_LABEL', N'Tús billeteras...', NULL)
GO
INSERT [dbo].[idiomas] ([code], [descripcion], [deleted]) VALUES (N'ASG', N'Asgardiano', NULL)
INSERT [dbo].[idiomas] ([code], [descripcion], [deleted]) VALUES (N'ENG', N'English', NULL)
INSERT [dbo].[idiomas] ([code], [descripcion], [deleted]) VALUES (N'ES', N'Español', NULL)
GO
INSERT [dbo].[moneda] ([cod], [descrip], [deleted]) VALUES (N'ARS', N'Pesos argentinos', NULL)
INSERT [dbo].[moneda] ([cod], [descrip], [deleted]) VALUES (N'BTC', N'Bitcoin', NULL)
INSERT [dbo].[moneda] ([cod], [descrip], [deleted]) VALUES (N'DOG', N'Dodge', NULL)
INSERT [dbo].[moneda] ([cod], [descrip], [deleted]) VALUES (N'LTC', N'Litecoin', NULL)
GO
SET IDENTITY_INSERT [dbo].[notificaciones] ON 

INSERT [dbo].[notificaciones] ([idnotification], [idcliente], [payload], [fecRegistro], [marked]) VALUES (1, 1, N'Hola damian necesitamos que ingreses en tu cuenta de ARS el valor de $1300 para saldar tus deudas.', CAST(N'2021-11-03T15:00:48.000' AS DateTime), 0)
INSERT [dbo].[notificaciones] ([idnotification], [idcliente], [payload], [fecRegistro], [marked]) VALUES (2, 2, N'Hemos debitado de cuenta de ARS el valor de $100', CAST(N'2021-11-04T21:07:43.000' AS DateTime), 0)
INSERT [dbo].[notificaciones] ([idnotification], [idcliente], [payload], [fecRegistro], [marked]) VALUES (3, 2, N'Hemos debitado de cuenta de ARS el valor de $100', CAST(N'2021-11-04T21:07:44.000' AS DateTime), 0)
INSERT [dbo].[notificaciones] ([idnotification], [idcliente], [payload], [fecRegistro], [marked]) VALUES (4, 2, N'Hemos debitado de cuenta de ARS el valor de $100', CAST(N'2021-11-04T21:07:44.000' AS DateTime), 0)
INSERT [dbo].[notificaciones] ([idnotification], [idcliente], [payload], [fecRegistro], [marked]) VALUES (5, 2, N'Hemos debitado de cuenta de ARS el valor de $100', CAST(N'2021-11-04T21:07:45.000' AS DateTime), 0)
INSERT [dbo].[notificaciones] ([idnotification], [idcliente], [payload], [fecRegistro], [marked]) VALUES (6, 2, N'Hemos debitado de cuenta de ARS el valor de $100', CAST(N'2021-11-04T21:07:45.000' AS DateTime), 0)
INSERT [dbo].[notificaciones] ([idnotification], [idcliente], [payload], [fecRegistro], [marked]) VALUES (7, 2, N'Hemos debitado de cuenta de ARS el valor de $100', CAST(N'2021-11-04T21:07:46.000' AS DateTime), 0)
INSERT [dbo].[notificaciones] ([idnotification], [idcliente], [payload], [fecRegistro], [marked]) VALUES (8, 2, N'Hemos debitado de cuenta de ARS el valor de $100', CAST(N'2021-11-04T21:07:47.000' AS DateTime), 0)
INSERT [dbo].[notificaciones] ([idnotification], [idcliente], [payload], [fecRegistro], [marked]) VALUES (9, 1, N'Hemos debitado de cuenta de ARS el valor de $100', CAST(N'2021-11-04T21:07:47.000' AS DateTime), 0)
INSERT [dbo].[notificaciones] ([idnotification], [idcliente], [payload], [fecRegistro], [marked]) VALUES (10, 1, N'Hemos debitado de cuenta de ARS el valor de $100', CAST(N'2021-11-04T21:07:48.000' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[notificaciones] OFF
GO
SET IDENTITY_INSERT [dbo].[onboarding_estados] ON 

INSERT [dbo].[onboarding_estados] ([idestado], [descrip]) VALUES (1, N'Valido')
INSERT [dbo].[onboarding_estados] ([idestado], [descrip]) VALUES (2, N'Rechazado')
INSERT [dbo].[onboarding_estados] ([idestado], [descrip]) VALUES (3, N'Ilegible')
SET IDENTITY_INSERT [dbo].[onboarding_estados] OFF
GO
SET IDENTITY_INSERT [dbo].[orden_estado] ON 

INSERT [dbo].[orden_estado] ([ídtipo], [descrip]) VALUES (1, N'Disponible')
INSERT [dbo].[orden_estado] ([ídtipo], [descrip]) VALUES (2, N'Vendida')
INSERT [dbo].[orden_estado] ([ídtipo], [descrip]) VALUES (3, N'Expirada')
INSERT [dbo].[orden_estado] ([ídtipo], [descrip]) VALUES (4, N'Finalizada')
SET IDENTITY_INSERT [dbo].[orden_estado] OFF
GO
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'ADDRESS', CAST(N'2021-09-17T05:39:09.157' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'ARS_LABEL', CAST(N'2021-09-17T05:39:09.157' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BACKUP_COL_FEC', CAST(N'2021-09-18T12:05:03.177' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BACKUP_COL_PATH', CAST(N'2021-09-18T12:05:03.177' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BACKUP_COL_SIZE', CAST(N'2021-10-24T22:46:46.810' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BACKUP_COL_TYPE', CAST(N'2021-09-18T12:05:03.177' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BAD_DNI', CAST(N'2021-09-17T05:39:09.160' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BAD_PHONE', CAST(N'2021-09-17T05:39:09.160' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BAD_TRAMITE', CAST(N'2021-09-17T05:39:09.160' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BIRTH_DATE', CAST(N'2021-09-17T05:39:09.160' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BTC_LABEL', CAST(N'2021-09-17T05:39:09.160' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BTN_CLOSE', CAST(N'2021-10-29T01:46:25.247' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BTN_CLOSE_BACKUP', CAST(N'2021-09-18T11:25:53.717' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BTN_CLOSE_PERMISSION', CAST(N'2021-09-17T05:39:09.160' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BTN_COMPOUND_PERMISSION', CAST(N'2021-09-17T05:39:09.160' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BTN_COPY', CAST(N'2021-10-29T01:46:25.247' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BTN_DEL_PERMISSION', CAST(N'2021-09-17T05:39:09.160' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BTN_LOAD_BACKUP', CAST(N'2021-09-18T11:25:53.717' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BTN_NEW_BACKUP', CAST(N'2021-09-18T11:25:53.717' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BTN_RETIRO_OK', CAST(N'2021-11-01T20:56:11.593' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BTN_RETIRO_REJECT', CAST(N'2021-11-01T20:56:11.593' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BTN_UPDATE_PERMISSION', CAST(N'2021-09-17T05:39:09.160' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BUTTON_CANCEL', CAST(N'2021-09-17T05:39:09.160' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BUTTON_OK', CAST(N'2021-09-17T05:39:09.160' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BUY_DATE', CAST(N'2021-09-17T05:39:09.243' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BUY_ERROR', CAST(N'2021-09-17T05:39:09.160' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'BUY_SUCCESS', CAST(N'2021-09-17T05:39:09.163' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'CBU_CASHIN_LABEL', CAST(N'2021-11-01T03:03:16.563' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'CBU_CASHIN_TITLE', CAST(N'2021-11-01T03:03:16.560' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'CBU_TITLE', CAST(N'2021-10-29T01:46:25.243' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'CBU_TITLE_DESCRIP', CAST(N'2021-10-29T01:46:25.243' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COBRAR_BTN_PROCESS', CAST(N'2021-11-04T21:36:07.890' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COBRAR_FRM_TITLE', CAST(N'2021-11-04T21:36:07.887' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COBRAR_FRM_TITLE_DESCRIP', CAST(N'2021-11-04T21:36:07.890' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COBRAR_TOTAL_LABEL', CAST(N'2021-11-04T21:36:07.890' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COBRAR_WAITING', CAST(N'2021-11-04T21:36:07.890' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COMMISION_DEBTS_NOTIFY_BTN', CAST(N'2021-11-03T15:29:51.827' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COMMISION_DEBTS_TITLE', CAST(N'2021-11-03T15:29:51.797' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COMMISION_DEBTS_TITLE_DESCRIP', CAST(N'2021-11-03T15:29:51.827' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COMP_CRUD_ADD', CAST(N'2021-09-17T05:39:09.230' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COMP_CRUD_ADD_DESCRIP', CAST(N'2021-09-17T05:39:09.233' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COMP_CRUD_ADD_VALUE', CAST(N'2021-09-17T05:39:09.233' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COMP_CRUD_CLOSE', CAST(N'2021-09-17T05:39:09.233' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COMP_CRUD_DELETE', CAST(N'2021-09-17T05:39:09.233' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COMP_CRUD_DELETE_CONFIRM', CAST(N'2021-09-17T05:39:09.233' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COMP_CRUD_DELETE_OK', CAST(N'2021-09-17T05:39:09.233' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COMP_CRUD_DELETE_TITLE', CAST(N'2021-09-17T05:39:09.233' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COMP_CRUD_DESCRIPTION', CAST(N'2021-09-17T05:39:09.230' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COMP_CRUD_TITLE_FAMILY', CAST(N'2021-09-17T05:39:09.230' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'COMP_CRUD_TITLE_PATENT', CAST(N'2021-09-17T05:39:09.230' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'CRYPTO_EXTRACT_SUCCESS', CAST(N'2021-11-02T13:33:43.277' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'CRYPTO_EXTRACT_TITLE', CAST(N'2021-11-02T13:33:43.277' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'CRYPTO_EXTRACT_TXT', CAST(N'2021-11-02T13:33:43.250' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'DOCUMENT_NUMBER', CAST(N'2021-09-17T05:39:09.163' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'DOG_LABEL', CAST(N'2021-09-17T05:39:09.163' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EDIT_FAMILY_SELECTOR_DESCRIP', CAST(N'2021-09-17T05:39:09.230' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EDIT_FAMILY_SELECTOR_TITLE', CAST(N'2021-09-17T05:39:09.230' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EDIT_PATENT_DESCRIP', CAST(N'2021-09-17T05:39:09.230' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EDIT_PATENT_TITLE', CAST(N'2021-09-17T05:39:09.230' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EDIT_PATENTE_SELECTOR_DESCRIP', CAST(N'2021-09-17T05:39:09.230' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EDIT_PATENTE_SELECTOR_TITLE', CAST(N'2021-09-17T05:39:09.230' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EXTRACT_ARS_AMMOUNT', CAST(N'2021-11-01T11:59:39.270' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EXTRACT_ARS_CBU', CAST(N'2021-11-01T11:59:39.270' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EXTRACT_ARS_DESCRIP', CAST(N'2021-11-01T11:45:07.597' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EXTRACT_ARS_NO_FOUNDS', CAST(N'2021-11-01T17:58:37.010' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EXTRACT_ARS_OK', CAST(N'2021-11-01T18:13:38.017' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EXTRACT_ARS_PENDING_DEBTS', CAST(N'2021-11-01T17:58:37.010' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EXTRACT_ARS_TITLE', CAST(N'2021-11-01T11:45:07.597' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EXTRACT_ARS_VALUE_LABEL', CAST(N'2021-11-01T11:45:07.600' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EXTRACT_ARS_VALUE_LABEL_DESCRIP', CAST(N'2021-11-01T11:45:07.600' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EXTRACT_CRYPTO_WALLET_DESCRIP', CAST(N'2021-11-02T13:55:19.963' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EXTRACT_CRYPTO_WALLET_DESTINY', CAST(N'2021-11-02T13:55:19.963' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EXTRACT_CRYPTO_WALLET_ORIGIN', CAST(N'2021-11-02T13:55:19.963' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EXTRACT_CRYPTO_WALLET_TITLE', CAST(N'2021-11-02T13:55:19.963' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'EXTRACT_CRYPTO_WALLET_VALUE', CAST(N'2021-11-02T13:55:19.963' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'FRM_CHANGE_CONTROL', CAST(N'2021-09-17T05:39:09.253' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'FRM_CHANGE_CONTROL_BTN_RECOVE', CAST(N'2021-09-17T05:39:09.253' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'GRAL_NO_RESULTS', CAST(N'2021-11-01T02:57:37.253' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'GRAL_OPERATION_SUCCESS', CAST(N'2021-11-01T02:57:37.253' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'GRAL_UNABLE_TO_PROCESS', CAST(N'2021-11-01T02:57:37.253' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'GRAL_YOU_MUST_ENTER_A_VALUE', CAST(N'2021-11-01T02:57:37.253' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'HELLO', CAST(N'2021-09-17T05:39:09.163' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'INTEGRITY_ERROR', CAST(N'2021-09-17T05:39:09.163' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'INTEGRITY_USERS_CORRUPT', CAST(N'2021-09-17T05:39:09.163' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'INTEGRITY_USERS_ENTITY_FAIL', CAST(N'2021-09-17T05:39:09.163' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'INTEGRITY_USERS_NOT_FOUND', CAST(N'2021-09-17T05:39:09.163' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LANG_CHOOSE_TITLE', CAST(N'2021-09-17T05:39:09.167' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LANGUAGE_CHANGE_ERROR', CAST(N'2021-09-17T05:39:09.167' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LANGUAGE_CHANGE_OK', CAST(N'2021-09-17T05:39:09.167' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOG_ACTIV_TITLE', CAST(N'2021-09-17T05:39:09.247' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOG_BTN_CLOSE', CAST(N'2021-09-17T05:39:09.250' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOG_BTN_SEARCH', CAST(N'2021-09-17T05:39:09.247' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOG_COL_ACTIVIDAD', CAST(N'2021-09-17T05:39:09.250' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOG_COL_FECHA', CAST(N'2021-09-17T05:39:09.250' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOG_COL_ID', CAST(N'2021-09-17T05:39:09.250' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOG_COL_TEXTO', CAST(N'2021-09-17T05:39:09.250' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOG_COL_USUARIO', CAST(N'2021-09-17T05:39:09.250' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOG_FROM_TITLE', CAST(N'2021-09-17T05:39:09.247' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOG_SEARCH_DESCRIP', CAST(N'2021-09-17T05:39:09.247' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOG_SEARCH_TITLE', CAST(N'2021-09-17T05:39:09.247' AS DateTime))
GO
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOG_TEXT_TITLE', CAST(N'2021-09-17T05:39:09.247' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOG_TO_TITLE', CAST(N'2021-09-17T05:39:09.247' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOGIN', CAST(N'2021-09-17T05:39:09.167' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOGIN_BTN_CANCEL', CAST(N'2021-09-17T05:39:09.167' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOGIN_BTN_INGRESAR', CAST(N'2021-09-17T05:39:09.167' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOGIN_INPUT_ERROR', CAST(N'2021-09-17T05:39:09.167' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOGIN_INPUT_ERROR_TITLE', CAST(N'2021-09-17T05:39:09.167' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOGIN_SERVICE_ERROR', CAST(N'2021-09-17T05:39:09.167' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOGIN_TITLE_1', CAST(N'2021-09-17T05:39:09.170' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOGIN_TITLE_EMAIL', CAST(N'2021-09-17T05:39:09.170' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LOGIN_TITLE_PASSWORD', CAST(N'2021-09-17T05:39:09.170' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'LTC_LABEL', CAST(N'2021-09-17T05:39:09.170' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_BTN_LOGIN', CAST(N'2021-09-17T05:39:09.170' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_CHANGE_LANGUAGE', CAST(N'2021-09-17T05:39:09.170' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_BACKUP', CAST(N'2021-09-17T05:39:09.170' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_BUY', CAST(N'2021-09-17T05:39:09.170' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_CASH_IN', CAST(N'2021-11-01T03:22:20.040' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_CBU', CAST(N'2021-10-31T21:17:08.227' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_DEPOSIT', CAST(N'2021-09-17T05:39:09.170' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_EXIT', CAST(N'2021-09-17T05:39:09.170' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_EXTRACT', CAST(N'2021-09-17T05:39:09.170' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_EXTRACT_ARS', CAST(N'2021-11-01T22:52:40.870' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_EXTRACT_CRYPTO', CAST(N'2021-11-02T14:14:02.397' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_IT', CAST(N'2021-09-17T05:39:09.170' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_IT_ADD_USER', CAST(N'2021-09-17T05:39:09.173' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_IT_BACKUP', CAST(N'2021-09-18T10:30:29.977' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_IT_LANG_MANAGER', CAST(N'2021-09-17T05:39:09.173' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_IT_USER_MANAGER', CAST(N'2021-09-17T05:39:09.173' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_IT_USER_PERM_MANAGER', CAST(N'2021-09-17T05:39:09.247' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_LANGUAGE', CAST(N'2021-09-17T05:39:09.173' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_LOG_SEARCH', CAST(N'2021-09-17T05:39:09.250' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_LOGIN', CAST(N'2021-09-17T05:39:09.173' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_MY_SELLS', CAST(N'2021-09-17T05:39:09.173' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_MY_WALLETS', CAST(N'2021-09-17T05:39:09.173' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_NOTIFICATIONS', CAST(N'2021-09-17T05:39:09.173' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_OPERATE', CAST(N'2021-09-17T05:39:09.173' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_PERMISSION', CAST(N'2021-09-17T05:39:09.177' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_RECOMENDATIONS', CAST(N'2021-09-17T05:39:09.177' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_SEARCH', CAST(N'2021-09-17T05:39:09.177' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_SELL', CAST(N'2021-09-17T05:39:09.177' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_SIGNOUT', CAST(N'2021-09-17T05:39:09.177' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_SIGNUP', CAST(N'2021-09-17T05:39:09.177' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_START', CAST(N'2021-09-17T05:39:09.177' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_MENU_USER', CAST(N'2021-09-17T05:39:09.177' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_SPLASH_ACTIVITY', CAST(N'2021-09-17T05:39:09.177' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MAIN_SPLASH_TITLE', CAST(N'2021-09-17T05:39:09.180' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MY_BUYS', CAST(N'2021-09-17T05:39:09.243' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MY_SELL_FINISH_CONFIRM', CAST(N'2021-09-17T05:39:09.180' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MY_SELL_FINISH_SUCCESS', CAST(N'2021-09-17T05:39:09.180' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MY_SELL_FINISH_TITLE', CAST(N'2021-09-17T05:39:09.180' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MY_SELL_ORDERS_PAUSE', CAST(N'2021-09-17T05:39:09.180' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'MY_SELL_ORDERS_TITLE', CAST(N'2021-09-17T05:39:09.180' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'NOTIF_BUY_OK_SUCCESS', CAST(N'2021-09-17T05:39:09.180' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'NOTIF_BUY_SUCCESS', CAST(N'2021-09-17T05:39:09.180' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'NOTIF_CLOSE', CAST(N'2021-09-17T05:39:09.180' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'NOTIF_DATE', CAST(N'2021-09-17T05:39:09.180' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'NOTIF_DESCRIP', CAST(N'2021-09-17T05:39:09.180' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'NOTIF_TEXT', CAST(N'2021-09-17T05:39:09.183' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'NOTIF_TITLE', CAST(N'2021-09-17T05:39:09.183' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'OP_BTN_BUY', CAST(N'2021-09-17T05:39:09.183' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'OP_BTN_CLOSE', CAST(N'2021-09-17T05:39:09.183' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'OP_DETAIL_LABEL', CAST(N'2021-09-17T05:39:09.183' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'OP_OFFER', CAST(N'2021-09-17T05:39:09.183' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'OP_REQ', CAST(N'2021-09-17T05:39:09.183' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'OP_SELLER', CAST(N'2021-09-17T05:39:09.183' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'OP_TAX_LABEL', CAST(N'2021-09-17T05:39:09.183' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'OP_TAX_LABEL_INFO', CAST(N'2021-09-17T05:39:09.187' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'OP_TITLE', CAST(N'2021-09-17T05:39:09.187' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'OP_TOTAL', CAST(N'2021-09-17T05:39:09.243' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'ORDER_NUMER', CAST(N'2021-09-17T05:39:09.187' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'PERMISSION_ABM', CAST(N'2021-09-17T05:39:09.187' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'PERMISSION_LABEL', CAST(N'2021-09-17T05:39:09.187' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'PERMISSION_TITLE', CAST(N'2021-09-17T05:39:09.187' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'PHONE_NUMBER', CAST(N'2021-09-17T05:39:09.187' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'PROFILE_ADDRESS', CAST(N'2021-09-17T23:47:10.580' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'PROFILE_BIRTH_DATE', CAST(N'2021-09-17T23:47:10.580' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'PROFILE_CBU', CAST(N'2021-10-11T10:44:04.990' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'PROFILE_CLOSE', CAST(N'2021-09-17T23:47:10.580' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'PROFILE_DOC_NUMBER', CAST(N'2021-09-17T23:47:10.580' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'PROFILE_FORM', CAST(N'2021-09-17T23:48:35.627' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'PROFILE_OK', CAST(N'2021-09-17T23:47:10.580' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'PROFILE_PHONE', CAST(N'2021-09-17T23:47:10.580' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'PROFILE_TRAMITE', CAST(N'2021-09-17T23:47:10.580' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'PROFILE_TYPE_DOC', CAST(N'2021-09-17T23:47:10.580' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'RECOM_CLOSE', CAST(N'2021-09-17T05:39:09.187' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'RECOM_DESCRIP', CAST(N'2021-09-17T05:39:09.187' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'RECOM_TITLE', CAST(N'2021-09-17T05:39:09.190' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'RECOM_VIEW', CAST(N'2021-09-17T05:39:09.190' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'REGISTER_INPUT_EMAIL_ERROR', CAST(N'2021-09-17T05:39:09.190' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'REGISTER_INPUT_ERROR', CAST(N'2021-09-17T05:39:09.190' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'REGISTER_INPUT_ERROR_TITLE', CAST(N'2021-09-17T05:39:09.190' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'REGISTER_INPUT_SUCCESS', CAST(N'2021-09-17T05:39:09.190' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'REPORT_DBT_DESCRIP', CAST(N'2021-11-04T09:29:43.950' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'REPORT_DBT_DESDE', CAST(N'2021-11-04T09:29:43.950' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'REPORT_DBT_DOWNLOAD', CAST(N'2021-11-26T12:34:06.880' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'REPORT_DBT_HASTA', CAST(N'2021-11-04T09:29:43.950' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'REPORT_DBT_PAY', CAST(N'2021-11-04T09:29:43.950' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'REPORT_DBT_SEARCH', CAST(N'2021-11-04T09:29:43.950' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'REPORT_DBT_TITLE', CAST(N'2021-11-04T09:29:43.947' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'REPORT_DBT_TOTAL', CAST(N'2021-11-04T13:59:10.543' AS DateTime))
GO
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'REPORT_DBT_TYPE', CAST(N'2021-11-04T09:29:43.950' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'RETIRO_TITLE', CAST(N'2021-11-01T20:56:11.590' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'RETIRO_TITLE_DESCRIP', CAST(N'2021-11-01T20:56:11.590' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_BTN_BY', CAST(N'2021-09-17T05:39:09.190' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_BTN_CLOSE', CAST(N'2021-09-17T05:39:09.190' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_BTN_SEARCH', CAST(N'2021-09-17T05:39:09.190' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_BTN_VIEW', CAST(N'2021-09-17T05:39:09.190' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_CBU_CLIENT', CAST(N'2021-11-01T00:39:19.337' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_CBU_DNI', CAST(N'2021-11-01T00:39:19.340' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_CBU_EMAIL', CAST(N'2021-11-01T00:39:19.340' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_CBU_TDOC', CAST(N'2021-11-01T00:39:19.340' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_COL_ID', CAST(N'2021-09-17T05:39:09.190' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_COL_OFFER', CAST(N'2021-09-17T05:39:09.193' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_COL_PRICE', CAST(N'2021-09-17T05:39:09.193' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_COL_QTY', CAST(N'2021-09-17T05:39:09.193' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_COL_REQ', CAST(N'2021-09-17T05:39:09.193' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_COL_SELLER', CAST(N'2021-09-17T05:39:09.193' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_COL_STATUS', CAST(N'2021-09-17T05:39:09.193' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_DESCRIP', CAST(N'2021-09-17T05:39:09.193' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEARCH_TITLE', CAST(N'2021-09-17T05:39:09.193' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SEEL_TAX_LABEL', CAST(N'2021-09-17T05:39:09.240' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SELL_CLOSE', CAST(N'2021-09-17T05:39:09.197' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SELL_INPUT', CAST(N'2021-09-17T05:39:09.197' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SELL_MONEY', CAST(N'2021-09-17T05:39:09.197' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SELL_MONEY_EXCED', CAST(N'2021-09-17T05:39:09.197' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SELL_MONEY_FREE_PRICE', CAST(N'2021-09-17T05:39:09.197' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SELL_MONEY_MARKET_PRICE', CAST(N'2021-09-17T05:39:09.197' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SELL_MONEY_MISMATCH', CAST(N'2021-09-17T05:39:09.197' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SELL_MONEY_SUCCESS', CAST(N'2021-09-17T05:39:09.197' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SELL_PUBLISH', CAST(N'2021-09-17T05:39:09.200' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SELL_RECEIVE', CAST(N'2021-09-17T05:39:09.200' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SELL_TAX', CAST(N'2021-09-17T05:39:09.200' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SELL_TITLE', CAST(N'2021-09-17T05:39:09.200' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SIGNUP_ALIAS', CAST(N'2021-09-17T05:39:09.200' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SIGNUP_CANCEL', CAST(N'2021-09-17T05:39:09.200' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SIGNUP_DNI_REPEATED', CAST(N'2021-09-17T05:39:09.200' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SIGNUP_EMAIL', CAST(N'2021-09-17T05:39:09.200' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SIGNUP_EMAIL_REPEATED', CAST(N'2021-09-17T05:39:09.203' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SIGNUP_LEGACY', CAST(N'2021-09-17T05:39:09.203' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SIGNUP_NAME', CAST(N'2021-09-17T05:39:09.203' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SIGNUP_OK', CAST(N'2021-09-17T05:39:09.203' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SIGNUP_PWD', CAST(N'2021-09-17T05:39:09.203' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SIGNUP_SURNAME', CAST(N'2021-09-17T05:39:09.203' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SINGUP_DESCRIP', CAST(N'2021-09-17T05:39:09.203' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SINGUP_DESCRIPTION', CAST(N'2021-09-17T05:39:09.207' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'SINGUP_TITLE', CAST(N'2021-09-17T05:39:09.207' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TAX_NETWORK_FEE', CAST(N'2021-09-17T05:39:09.207' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TAX_NETWORK_FEE_ERROR', CAST(N'2021-09-17T05:39:09.240' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TAX_PLATFORM_FOR_BUY', CAST(N'2021-09-17T05:39:09.207' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TAX_PLATFORM_FOR_SELL', CAST(N'2021-09-17T05:39:09.207' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TEMPLATE_CONFIRM_DELETE', CAST(N'2021-09-17T05:39:09.227' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TEMPLATE_EDITOR', CAST(N'2021-09-17T05:39:09.227' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TEMPLATE_EDITOR_ADD', CAST(N'2021-09-17T05:39:09.227' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TEMPLATE_EDITOR_ADD_OK', CAST(N'2021-09-17T05:39:09.227' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TEMPLATE_EDITOR_DELETE', CAST(N'2021-09-17T05:39:09.227' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TEMPLATE_EDITOR_DELETE_OK', CAST(N'2021-09-17T05:39:09.227' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TREE_CRUD_ADD_FAMILY', CAST(N'2021-09-17T05:39:09.237' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TREE_CRUD_ADD_PATENT', CAST(N'2021-09-17T05:39:09.237' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TREE_CRUD_CLOSE', CAST(N'2021-09-17T05:39:09.240' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TREE_CRUD_DELETE', CAST(N'2021-09-17T05:39:09.240' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TREE_CRUD_FAMILY', CAST(N'2021-09-17T05:39:09.237' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TREE_CRUD_PATENT', CAST(N'2021-09-17T05:39:09.237' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TREE_CRUD_SAVE', CAST(N'2021-09-17T05:39:09.237' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TREE_CRUD_VIEW', CAST(N'2021-09-17T05:39:09.237' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TREE_DESCRIP_EDITOR', CAST(N'2021-09-17T05:39:09.237' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TREE_FAMILY_EXISTS', CAST(N'2021-09-17T05:39:09.240' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TREE_PATENT_EXISTS', CAST(N'2021-09-17T05:39:09.240' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TREE_TITLE_EDITOR', CAST(N'2021-09-17T05:39:09.237' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TXT_ALIAS', CAST(N'2021-10-29T01:46:25.247' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TXT_BACKUP_DESCRIP', CAST(N'2021-09-18T11:25:53.717' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TXT_BACKUP_TITLE', CAST(N'2021-09-18T11:25:53.717' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TXT_BANK', CAST(N'2021-10-29T01:46:25.247' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'TXT_CBU', CAST(N'2021-10-29T01:46:25.243' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'UI_LANG_NEW_KEY', CAST(N'2021-09-17T05:39:09.207' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'UI_LANG_NEW_KEY_DESCRIP', CAST(N'2021-09-17T05:39:09.207' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'UI_LANG_NEW_KEY_TITLE', CAST(N'2021-09-17T05:39:09.210' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'UI_LANG_NEW_VALUE_TITLE', CAST(N'2021-09-17T05:39:09.210' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USER_STATUS_ALIAS', CAST(N'2021-11-02T21:10:52.820' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USER_STATUS_LABEL', CAST(N'2021-11-02T21:10:52.820' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USER_STATUS_TITLE', CAST(N'2021-11-02T21:10:52.820' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USER_TREE_EDITOR_DESCRIP', CAST(N'2021-09-17T05:39:09.240' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USER_TREE_EDITOR_TITLE', CAST(N'2021-09-17T05:39:09.240' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_CHANGE_CLOSE', CAST(N'2021-09-17T05:39:09.257' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_CHANGE_CONFIRM', CAST(N'2021-09-17T05:39:09.257' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_CHANGE_RESTORE_SUCCESS', CAST(N'2021-09-17T05:39:09.257' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_CHANGE_TITLE', CAST(N'2021-09-17T05:39:09.257' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_COL_EMAIL', CAST(N'2021-09-17T05:39:09.210' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_COL_ID', CAST(N'2021-09-17T05:39:09.210' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_COL_NAME', CAST(N'2021-09-17T05:39:09.210' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_COL_SURNAME', CAST(N'2021-09-17T05:39:09.210' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_COL_TYPE', CAST(N'2021-09-17T05:39:09.210' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_CONTROL_BTN_CHANGE', CAST(N'2021-09-17T05:39:09.250' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_CONTROL_COL_CHANGE_ADDRESS', CAST(N'2021-09-17T05:39:09.253' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_CONTROL_COL_CHANGE_EMAIL', CAST(N'2021-09-17T05:39:09.253' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_CONTROL_COL_CHANGE_FEC_NAC', CAST(N'2021-09-17T05:39:09.253' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_CONTROL_COL_CHANGE_NUM', CAST(N'2021-09-17T05:39:09.250' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_CONTROL_COL_CHANGE_OPERATOR', CAST(N'2021-10-24T21:09:30.863' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_CONTROL_COL_CHANGE_PHONE', CAST(N'2021-09-17T05:39:09.253' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_CONTROL_COL_CHANGE_TDOC', CAST(N'2021-09-17T05:39:09.250' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_CONTROL_COL_CHANGRE_NUM_TRAMITE', CAST(N'2021-09-17T05:39:09.253' AS DateTime))
GO
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_ALL_DELETE_CONFIRM_TITLE', CAST(N'2021-09-17T05:39:09.217' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_COL_CODE', CAST(N'2021-09-17T05:39:09.210' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_COL_VALUE', CAST(N'2021-09-17T05:39:09.210' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_DELETE_CONFIRM', CAST(N'2021-09-17T05:39:09.210' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_DELETE_CONFIRM_TITLE', CAST(N'2021-09-17T05:39:09.210' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_NEW', CAST(N'2021-09-17T05:39:09.213' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_NEW_ERROR', CAST(N'2021-09-17T05:39:09.213' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_NEW_NAME', CAST(N'2021-09-17T05:39:09.213' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_NEW_OK', CAST(N'2021-09-17T05:39:09.213' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_NEW_REQUIRED', CAST(N'2021-09-17T05:39:09.213' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_UI_ADD_LANGUAGE', CAST(N'2021-09-17T05:39:09.213' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_UI_CLOSE_LANGUAGE', CAST(N'2021-09-17T05:39:09.213' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_UI_DEL_LANGUAGE', CAST(N'2021-09-17T05:39:09.217' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_UI_DESCRIP', CAST(N'2021-09-17T05:39:09.217' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_UI_EDIT_LANGUAGE', CAST(N'2021-09-17T05:39:09.217' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_UI_NEW_LANGUAGE', CAST(N'2021-09-17T05:39:09.217' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_UI_REFRESH_LANGUAGE', CAST(N'2021-09-17T05:39:09.217' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_UI_TITLE', CAST(N'2021-09-17T05:39:09.217' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_UPD_OK', CAST(N'2021-09-17T05:39:09.217' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_LANG_UPD_REQUIRED', CAST(N'2021-09-17T05:39:09.217' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_PERM_ADD_CONFIRM_DESCRIP', CAST(N'2021-09-17T05:39:09.220' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_PERM_ADD_CONFIRM_TITLE', CAST(N'2021-09-17T05:39:09.220' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_PERM_ADD_DENY', CAST(N'2021-09-17T05:39:09.220' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_PERM_ADD_ERROR', CAST(N'2021-09-17T05:39:09.220' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_PERM_BTN', CAST(N'2021-09-17T05:39:09.220' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_PERM_COMP_ADD_DESCRIP', CAST(N'2021-09-17T05:39:09.220' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_PERM_COMP_ADD_TITLE', CAST(N'2021-09-17T05:39:09.220' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_PERM_DEL_CONFIRM_DESCRIP', CAST(N'2021-09-17T05:39:09.220' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_PERM_DEL_CONFIRM_TITLE', CAST(N'2021-09-17T05:39:09.220' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_PERM_DEL_REQ', CAST(N'2021-09-17T05:39:09.220' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_PERM_DEL_SUCESS', CAST(N'2021-09-17T05:39:09.220' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_SEARCH', CAST(N'2021-09-17T05:39:09.223' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_SEARCH_BTN', CAST(N'2021-09-17T05:39:09.223' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_SEARCH_CLOSE', CAST(N'2021-09-17T05:39:09.223' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_SEARCH_DESCRIP', CAST(N'2021-09-17T05:39:09.223' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_SEARCH_LABEL', CAST(N'2021-09-17T05:39:09.223' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_SEARCHER', CAST(N'2021-09-17T05:39:09.250' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_TXT_CTRL_DESCRIP', CAST(N'2021-09-17T05:39:09.257' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'USR_TXT_CTRL_TITLE', CAST(N'2021-09-17T05:39:09.257' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'WALLET_BTN_CLOSE', CAST(N'2021-09-17T05:39:09.243' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'WALLET_BTN_REFRESH', CAST(N'2021-09-17T05:39:09.243' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'WALLET_DESCRIP', CAST(N'2021-09-17T05:39:09.240' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'WALLET_MONEY', CAST(N'2021-09-17T05:39:09.243' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'WALLET_PENDING_VALUE', CAST(N'2021-09-17T05:39:09.243' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'WALLET_READY_VALUE', CAST(N'2021-09-17T05:39:09.243' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'WALLET_TITLE', CAST(N'2021-09-17T05:39:09.240' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'WARNING_TITLE', CAST(N'2021-10-29T01:46:25.243' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'WARNING_TITLE_DESCRIP', CAST(N'2021-10-29T01:46:25.243' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'WELCOME', CAST(N'2021-09-17T05:39:09.223' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'YOUR_DOCUMENTS', CAST(N'2021-09-17T05:39:09.223' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'YOUR_USER_LABEL', CAST(N'2021-09-17T05:39:09.223' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'YOUR_WALLETS_DESCRIPT', CAST(N'2021-09-17T05:39:09.223' AS DateTime))
INSERT [dbo].[palabras] ([word], [fecCreation]) VALUES (N'YOUR_WALLETS_LABEL', CAST(N'2021-09-17T05:39:09.227' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[permiso] ON 

INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (1, N'SEARCH_OFFERS', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (2, N'RECOMENDATIONS', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (3, N'MY_PUBLICATIONS', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (4, N'MY_BALANCE', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (5, N'PUBLISH_OFFER', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (6, N'CREATE_USER', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (7, N'MANAGE_USERS', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (8, N'MANAGE_PERMISSION', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (9, N'MANAGE_USER_PERMISSION', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (10, N'MANAGE_LANGUAGES', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (11, N'NOTIFICATIONS', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (12, N'MY_BUYS', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (13, N'SEARCH_LOG', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (14, N'CLIENTS', NULL)
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (15, N'EMPLOYEES', NULL)
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (16, N'IT', NULL)
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (17, N'MY_PROFILE', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (1002, N'BACKUP', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (1003, N'CBU', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (1004, N'EXTRACT', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (1005, N'CASH_IN', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (1007, N'EXTRACT_CRYPTO', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (1009, N'EARNINGS_REPORT', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (1006, N'EXTRACT_LIST', N'P')
INSERT [dbo].[permiso] ([id], [nombre], [permiso]) VALUES (1008, N'DEBTS_REPORT', N'P')
SET IDENTITY_INSERT [dbo].[permiso] OFF
GO
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (10, 1)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (10, 2)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (10, 3)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (10, 4)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (10, 5)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (11, 12)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (12, 6)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (12, 7)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (12, 8)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (12, 9)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (12, 18)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (16, 7)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (16, 8)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (16, 9)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (16, 10)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (16, 13)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (16, 6)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (16, 1002)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 1003)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 1004)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (15, 1005)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 1007)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (15, 16)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 1)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 2)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 3)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 4)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 5)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 11)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 12)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 13)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (14, 17)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (15, 1006)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (15, 1008)
INSERT [dbo].[permiso_permiso] ([id_permiso_padre], [id_permiso_hijo]) VALUES (15, 1009)
GO
SET IDENTITY_INSERT [dbo].[solic_estados] ON 

INSERT [dbo].[solic_estados] ([idestado], [descrip]) VALUES (1, N'Aprobada')
INSERT [dbo].[solic_estados] ([idestado], [descrip]) VALUES (2, N'Rechazada')
INSERT [dbo].[solic_estados] ([idestado], [descrip]) VALUES (3, N'Pendientes')
SET IDENTITY_INSERT [dbo].[solic_estados] OFF
GO
SET IDENTITY_INSERT [dbo].[solic_operacion] ON 

INSERT [dbo].[solic_operacion] ([idoperacion], [idusuario], [tipo_solic], [idwallet], [valor], [cbu], [operador], [estado_solic], [fecRegistro], [fecProceso], [deleted]) VALUES (1, 1, 1, 1, 10, N'0070064130004043181234', 5, 1, CAST(N'2021-01-11T01:39:13.000' AS DateTime), CAST(N'2021-01-11T01:39:13.000' AS DateTime), NULL)
INSERT [dbo].[solic_operacion] ([idoperacion], [idusuario], [tipo_solic], [idwallet], [valor], [cbu], [operador], [estado_solic], [fecRegistro], [fecProceso], [deleted]) VALUES (2, 1, 1, 1, 10, N'0070064130004043181234', 5, 1, CAST(N'2021-01-11T01:39:45.000' AS DateTime), CAST(N'2021-01-11T01:39:45.000' AS DateTime), NULL)
INSERT [dbo].[solic_operacion] ([idoperacion], [idusuario], [tipo_solic], [idwallet], [valor], [cbu], [operador], [estado_solic], [fecRegistro], [fecProceso], [deleted]) VALUES (3, 1, 1, 1, 200, N'0070064130004043181234', 5, 1, CAST(N'2021-01-11T02:09:51.000' AS DateTime), CAST(N'2021-01-11T02:09:51.000' AS DateTime), NULL)
INSERT [dbo].[solic_operacion] ([idoperacion], [idusuario], [tipo_solic], [idwallet], [valor], [cbu], [operador], [estado_solic], [fecRegistro], [fecProceso], [deleted]) VALUES (4, 1, 1, 1, 300, N'0070064130004043181234', 5, 1, CAST(N'2021-01-11T02:13:07.000' AS DateTime), CAST(N'2021-01-11T02:13:07.000' AS DateTime), NULL)
INSERT [dbo].[solic_operacion] ([idoperacion], [idusuario], [tipo_solic], [idwallet], [valor], [cbu], [operador], [estado_solic], [fecRegistro], [fecProceso], [deleted]) VALUES (8, 1, 0, 1, 10, N'0070064130004043181234', 0, 0, CAST(N'2021-11-01T17:43:57.293' AS DateTime), CAST(N'2021-11-01T17:43:57.293' AS DateTime), NULL)
INSERT [dbo].[solic_operacion] ([idoperacion], [idusuario], [tipo_solic], [idwallet], [valor], [cbu], [operador], [estado_solic], [fecRegistro], [fecProceso], [deleted]) VALUES (9, 1, 0, 1, 2, N'0070064130004043181234', 0, 0, CAST(N'2021-11-01T21:49:20.830' AS DateTime), CAST(N'2021-11-01T21:49:20.830' AS DateTime), NULL)
INSERT [dbo].[solic_operacion] ([idoperacion], [idusuario], [tipo_solic], [idwallet], [valor], [cbu], [operador], [estado_solic], [fecRegistro], [fecProceso], [deleted]) VALUES (10, 1, 1, 1, 2, N'0070064130004043181234', 0, 1, CAST(N'2021-11-01T21:59:05.563' AS DateTime), CAST(N'2021-11-01T21:59:05.563' AS DateTime), NULL)
INSERT [dbo].[solic_operacion] ([idoperacion], [idusuario], [tipo_solic], [idwallet], [valor], [cbu], [operador], [estado_solic], [fecRegistro], [fecProceso], [deleted]) VALUES (11, 1, 1, 1, 2, N'0070064130004043181234', 0, 1, CAST(N'2021-11-01T21:59:11.983' AS DateTime), CAST(N'2021-11-01T21:59:11.983' AS DateTime), NULL)
INSERT [dbo].[solic_operacion] ([idoperacion], [idusuario], [tipo_solic], [idwallet], [valor], [cbu], [operador], [estado_solic], [fecRegistro], [fecProceso], [deleted]) VALUES (12, 2, 1, 5, 600, N'0070064130004043187745', 5, 1, CAST(N'2021-11-05T16:41:17.657' AS DateTime), CAST(N'2021-11-05T16:41:17.657' AS DateTime), NULL)
INSERT [dbo].[solic_operacion] ([idoperacion], [idusuario], [tipo_solic], [idwallet], [valor], [cbu], [operador], [estado_solic], [fecRegistro], [fecProceso], [deleted]) VALUES (13, 1, 1, 1, 1000, N'0070064130004043181234', 0, 1, CAST(N'2021-11-25T19:21:10.357' AS DateTime), CAST(N'2021-11-25T19:21:10.357' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[solic_operacion] OFF
GO
SET IDENTITY_INSERT [dbo].[tipo_solic_op] ON 

INSERT [dbo].[tipo_solic_op] ([idtiposolic], [descrip]) VALUES (1, N'Ingreso de saldo')
INSERT [dbo].[tipo_solic_op] ([idtiposolic], [descrip]) VALUES (2, N'Retiro de saldo')
SET IDENTITY_INSERT [dbo].[tipo_solic_op] OFF
GO
SET IDENTITY_INSERT [dbo].[tipo_usuario] ON 

INSERT [dbo].[tipo_usuario] ([tipo_usuario], [descrip]) VALUES (1, N'Cliente')
INSERT [dbo].[tipo_usuario] ([tipo_usuario], [descrip]) VALUES (2, N'Empleado')
SET IDENTITY_INSERT [dbo].[tipo_usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON 

INSERT [dbo].[usuario] ([idusuario], [nombre], [apellido], [alias], [email], [tipo_usuario], [pwd], [hash], [deleted], [estado]) VALUES (1, N'damian', N'cipolat', N'prueba', N'LHLofA3Jn47gKzJqcki4hIHqqQIjrysxgaGjJZgsVwM=', 1, N'e10adc3949ba59abbe56e057f20f883e', N'8b75a894618d68f8691db25d921da1b3', NULL, 1)
INSERT [dbo].[usuario] ([idusuario], [nombre], [apellido], [alias], [email], [tipo_usuario], [pwd], [hash], [deleted], [estado]) VALUES (2, N'charlie', N'brown', N'cbrown', N'i5HY/mgU6DofzSzcU3Tvgjp37KY26Vl7OVlIFrotG2Q=', 1, N'e10adc3949ba59abbe56e057f20f883e', N'17364a8f8199c90f74596cef6e0aac72', NULL, 1)
INSERT [dbo].[usuario] ([idusuario], [nombre], [apellido], [alias], [email], [tipo_usuario], [pwd], [hash], [deleted], [estado]) VALUES (3, N'alf', N'shomwei', N'alf', N'HYixVzlYXo/uTIuS0ysz2Q==', 1, N'e10adc3949ba59abbe56e057f20f883e', N'11ef2806b6d39f105b3bfd29c0990f99', NULL, 1)
INSERT [dbo].[usuario] ([idusuario], [nombre], [apellido], [alias], [email], [tipo_usuario], [pwd], [hash], [deleted], [estado]) VALUES (4, N'uai', N'uai', N'5e1050842a4700c9abfb9b34bc5667df', N'7ime9r7HTrxtqW8XVDLYog==', 1, N'e10adc3949ba59abbe56e057f20f883e', N'eb1456f562a2108e2e86141c9c6bb113', NULL, 1)
INSERT [dbo].[usuario] ([idusuario], [nombre], [apellido], [alias], [email], [tipo_usuario], [pwd], [hash], [deleted], [estado]) VALUES (5, N'roberto', N'teco', N'roberto', N'+EZUHnQRIH9QPvTBik7de/ylBBnOWs/NH2E/URHP9gA=', 2, N'e10adc3949ba59abbe56e057f20f883e', N'd8c0084346e261ae9c888be0f253ec6f', NULL, 1)
INSERT [dbo].[usuario] ([idusuario], [nombre], [apellido], [alias], [email], [tipo_usuario], [pwd], [hash], [deleted], [estado]) VALUES (6, N'matias', N'matias', N'matias', N'8Sp4GAAy8Af9YesBC5M7VHmvdZhs3u7UunMlQU+U/pM=', 2, N'e10adc3949ba59abbe56e057f20f883e', N'e64b3bb790547331b67807286bf7e523', NULL, 1)
INSERT [dbo].[usuario] ([idusuario], [nombre], [apellido], [alias], [email], [tipo_usuario], [pwd], [hash], [deleted], [estado]) VALUES (7, N'prueba', N'prueba', N'prueba', N'3ro57FQVvmSAflg5Y/kc8Q5OxsN4t/9IGpJKdbD3xtg=', 2, N'e10adc3949ba59abbe56e057f20f883e', N'926ec230c42603938166e2a676d08daf', NULL, 1)
INSERT [dbo].[usuario] ([idusuario], [nombre], [apellido], [alias], [email], [tipo_usuario], [pwd], [hash], [deleted], [estado]) VALUES (8, N'thor', N'thor', N'thor', N'WQzRkVfSmv8xG/hM7o5vmQ==', 2, N'e10adc3949ba59abbe56e057f20f883e', N'973469fa873e6d863d213a84765eaf6a', NULL, 1)
INSERT [dbo].[usuario] ([idusuario], [nombre], [apellido], [alias], [email], [tipo_usuario], [pwd], [hash], [deleted], [estado]) VALUES (9, N'bart', N'bart', N'bart', N'LkoeV1G1dO9ejwE1tOr2vA==', 2, N'e10adc3949ba59abbe56e057f20f883e', N'fa6a2e7293833eedc5e2306f8be0fe47', NULL, 1)
SET IDENTITY_INSERT [dbo].[usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario_bloq] ON 

INSERT [dbo].[usuario_bloq] ([idbloq], [idusuario], [motivo], [fecBloq]) VALUES (1, NULL, N'Por fraude tratando de joder en la opera', CAST(N'2021-11-02T22:08:45.990' AS DateTime))
INSERT [dbo].[usuario_bloq] ([idbloq], [idusuario], [motivo], [fecBloq]) VALUES (2, 5, N'Prueba', CAST(N'2021-11-02T22:11:23.250' AS DateTime))
INSERT [dbo].[usuario_bloq] ([idbloq], [idusuario], [motivo], [fecBloq]) VALUES (3, 1, N'Por que lo dice rocko', CAST(N'2021-11-02T22:16:49.313' AS DateTime))
INSERT [dbo].[usuario_bloq] ([idbloq], [idusuario], [motivo], [fecBloq]) VALUES (4, 1, N'prueba', CAST(N'2021-11-02T22:20:48.380' AS DateTime))
INSERT [dbo].[usuario_bloq] ([idbloq], [idusuario], [motivo], [fecBloq]) VALUES (5, 1, N'Por que lo dijo rocko', CAST(N'2021-11-02T22:26:24.277' AS DateTime))
INSERT [dbo].[usuario_bloq] ([idbloq], [idusuario], [motivo], [fecBloq]) VALUES (6, 1, N'rocko', CAST(N'2021-11-02T22:27:40.317' AS DateTime))
INSERT [dbo].[usuario_bloq] ([idbloq], [idusuario], [motivo], [fecBloq]) VALUES (7, 1, N'no pagastes nada', CAST(N'2021-11-05T20:36:54.700' AS DateTime))
INSERT [dbo].[usuario_bloq] ([idbloq], [idusuario], [motivo], [fecBloq]) VALUES (8, 1, N'por que me dijo rocko', CAST(N'2021-11-25T15:21:17.617' AS DateTime))
INSERT [dbo].[usuario_bloq] ([idbloq], [idusuario], [motivo], [fecBloq]) VALUES (9, 1, N'por que me dijo rocko', CAST(N'2021-11-25T15:21:43.987' AS DateTime))
INSERT [dbo].[usuario_bloq] ([idbloq], [idusuario], [motivo], [fecBloq]) VALUES (10, 1, N'prueba 123456', CAST(N'2021-11-25T15:25:06.863' AS DateTime))
INSERT [dbo].[usuario_bloq] ([idbloq], [idusuario], [motivo], [fecBloq]) VALUES (11, 1, N'rockito', CAST(N'2021-11-25T15:30:02.400' AS DateTime))
SET IDENTITY_INSERT [dbo].[usuario_bloq] OFF
GO
SET IDENTITY_INSERT [dbo].[usuario_estado] ON 

INSERT [dbo].[usuario_estado] ([idestado], [nombre]) VALUES (1, N'Activo')
INSERT [dbo].[usuario_estado] ([idestado], [nombre]) VALUES (2, N'Inactivo')
INSERT [dbo].[usuario_estado] ([idestado], [nombre]) VALUES (3, N'Bloquedo')
SET IDENTITY_INSERT [dbo].[usuario_estado] OFF
GO
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (1, 14)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (2, 16)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (3, 14)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (4, 14)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (8, 15)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (9, 15)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (5, 15)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (6, 15)
INSERT [dbo].[usuarios_permisos] ([id_usuario], [id_permiso]) VALUES (7, 15)
GO
/****** Object:  Index [ix_1_billetera]    Script Date: 30/11/2021 6:23:09 ******/
CREATE NONCLUSTERED INDEX [ix_1_billetera] ON [dbo].[billetera]
(
	[idwallet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [ix_1_cliente]    Script Date: 30/11/2021 6:23:09 ******/
CREATE NONCLUSTERED INDEX [ix_1_cliente] ON [dbo].[cliente]
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [ix_2_cliente]    Script Date: 30/11/2021 6:23:09 ******/
CREATE NONCLUSTERED INDEX [ix_2_cliente] ON [dbo].[cliente]
(
	[cbu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [ix_1_idiomas]    Script Date: 30/11/2021 6:23:09 ******/
CREATE NONCLUSTERED INDEX [ix_1_idiomas] ON [dbo].[idioma_palabras]
(
	[code] ASC,
	[clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [ix_2_idiomas]    Script Date: 30/11/2021 6:23:09 ******/
CREATE NONCLUSTERED INDEX [ix_2_idiomas] ON [dbo].[idioma_palabras]
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [ix_1_usuario]    Script Date: 30/11/2021 6:23:09 ******/
CREATE NONCLUSTERED INDEX [ix_1_usuario] ON [dbo].[usuario]
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[palabras] ADD  DEFAULT (getdate()) FOR [fecCreation]
GO
USE [master]
GO
ALTER DATABASE [Crypton_BD] SET  READ_WRITE 
GO
