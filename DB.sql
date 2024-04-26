USE [master]
GO
/****** Object:  Database [Services365]    Script Date: 6/17/2023 3:49:05 PM ******/
CREATE DATABASE [Services365]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Services365', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Services365.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Services365_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Services365_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Services365] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Services365].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Services365] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Services365] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Services365] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Services365] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Services365] SET ARITHABORT OFF 
GO
ALTER DATABASE [Services365] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Services365] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Services365] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Services365] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Services365] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Services365] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Services365] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Services365] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Services365] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Services365] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Services365] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Services365] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Services365] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Services365] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Services365] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Services365] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Services365] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Services365] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Services365] SET  MULTI_USER 
GO
ALTER DATABASE [Services365] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Services365] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Services365] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Services365] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Services365] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Services365] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Services365] SET QUERY_STORE = ON
GO
ALTER DATABASE [Services365] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Services365]
GO
/****** Object:  Table [dbo].[Cola]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cola](
	[IdCola] [int] IDENTITY(1,1) NOT NULL,
	[NombreCola] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cola] PRIMARY KEY CLUSTERED 
(
	[IdCola] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[IdEstado] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faq]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faq](
	[IdFaq] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[Solucion] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Faq] PRIMARY KEY CLUSTERED 
(
	[IdFaq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[IdInventario] [int] IDENTITY(1,1) NOT NULL,
	[TipoEquipo] [varchar](50) NOT NULL,
	[Marca] [varchar](50) NOT NULL,
	[Modelo] [varchar](50) NOT NULL,
	[Serie] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[VersionInv] [varchar(50)] NOT NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[IdInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[IdServicio] [int] IDENTITY(1,1) NOT NULL,
	[TipoServicio] [varchar](50) NOT NULL,
	[Tiempo] [int] NOT NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[IdServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tiquete]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tiquete](
	[IdTiquete] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFinal] [datetime] NULL,
	[IdUsuario] [int] NOT NULL,
	[IdTecnico] [int] NULL,
	[IdEstado] [int] NOT NULL,
	[IdServicio] [int] NULL,
	[IdCola] [int] NULL,
	[IdFaq] [int] NULL,
	[IdInventario] [int] NULL,
 CONSTRAINT [PK_Tiquete] PRIMARY KEY CLUSTERED 
(
	[IdTiquete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Alias] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido1] [varchar](50) NOT NULL,
	[Apellido2] [varchar](50) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Contrasenna] [nvarchar](50) NOT NULL,
	[IdRol] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cola] ON 
GO
INSERT [dbo].[Cola] ([IdCola], [NombreCola]) VALUES (1, N'NombreCola1')
GO
SET IDENTITY_INSERT [dbo].[Cola] OFF
GO
SET IDENTITY_INSERT [dbo].[Estado] ON 
GO
INSERT [dbo].[Estado] ([IdEstado], [Estado]) VALUES (1, 1)
GO
INSERT [dbo].[Estado] ([IdEstado], [Estado]) VALUES (2, 0)
GO
SET IDENTITY_INSERT [dbo].[Estado] OFF
GO
SET IDENTITY_INSERT [dbo].[Faq] ON 
GO
INSERT [dbo].[Faq] ([IdFaq], [Titulo], [Descripcion], [Solucion]) VALUES (1, N'Titulo1', N'Descripcion1', N'Solucion')
GO
SET IDENTITY_INSERT [dbo].[Faq] OFF
GO
SET IDENTITY_INSERT [dbo].[Inventario] ON 
GO
INSERT [dbo].[Inventario] ([IdInventario], [TipoEquipo], [Marca], [Modelo], [Serie], [Nombre], [VersionInv]) VALUES (1, N'Equipo1', N'Marca1', N'Modelo1', N'Serie1', N'Nombre1', 1.1)
GO
SET IDENTITY_INSERT [dbo].[Inventario] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 
GO
INSERT [dbo].[Rol] ([IdRol], [NombreRol]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Rol] ([IdRol], [NombreRol]) VALUES (2, N'User')
GO
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicio] ON 
GO
INSERT [dbo].[Servicio] ([IdServicio], [TipoServicio], [Tiempo]) VALUES (1, N'TipoServicio', 20)
GO
SET IDENTITY_INSERT [dbo].[Servicio] OFF
GO
SET IDENTITY_INSERT [dbo].[Tiquete] ON 
GO
INSERT [dbo].[Tiquete] ([IdTiquete], [Titulo], [Descripcion], [FechaInicio], [FechaFinal], [IdUsuario], [IdTecnico], [IdEstado], [IdServicio], [IdCola], [IdFaq], [IdInventario]) VALUES (2, N'Titulo1', N'DescripcionTiquete', CAST(N'1894-07-01T00:00:00.000' AS DateTime), CAST(N'1894-07-01T00:00:00.000' AS DateTime), 1, 2, 1, 1, 1, 1, 1)
GO
INSERT [dbo].[Tiquete] ([IdTiquete], [Titulo], [Descripcion], [FechaInicio], [FechaFinal], [IdUsuario], [IdTecnico], [IdEstado], [IdServicio], [IdCola], [IdFaq], [IdInventario]) VALUES (3, N'Titulo1', N'DescripcionTiquete', CAST(N'1894-07-01T00:00:00.000' AS DateTime), CAST(N'1894-07-01T00:00:00.000' AS DateTime), 1, 1, 1, 1, 1, 1, 1)
GO
INSERT [dbo].[Tiquete] ([IdTiquete], [Titulo], [Descripcion], [FechaInicio], [FechaFinal], [IdUsuario], [IdTecnico], [IdEstado], [IdServicio], [IdCola], [IdFaq], [IdInventario]) VALUES (4, N'Titulo1', N'DescripcionTiquete', CAST(N'1894-07-01T00:00:00.000' AS DateTime), CAST(N'1894-07-01T00:00:00.000' AS DateTime), 3, 4, 1, 1, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Tiquete] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Alias], [Nombre], [Apellido1], [Apellido2], [Correo], [Contrasenna], [IdRol]) VALUES (1, N'u1', N'Usuario1', N'U', N'U', N'u@u', N'asd', 2)
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Alias], [Nombre], [Apellido1], [Apellido2], [Correo], [Contrasenna], [IdRol]) VALUES (2, N'a1', N'Admin1', N'A', N'A', N'a@a', N'asd', 1)
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Alias], [Nombre], [Apellido1], [Apellido2], [Correo], [Contrasenna], [IdRol]) VALUES (3, N'j1', N'jose', N'A', N'A', N'a@a', N'asd', 1)
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Alias], [Nombre], [Apellido1], [Apellido2], [Correo], [Contrasenna], [IdRol]) VALUES (4, N'c1', N'cris', N'A', N'A', N'a@a', N'asd', 1)
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Alias], [Nombre], [Apellido1], [Apellido2], [Correo], [Contrasenna], [IdRol]) VALUES (6, N'test1', N'test1', N'test', N'test', N'u@u', N'asad', 2)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Tiquete]  WITH CHECK ADD  CONSTRAINT [FK_Tiquete_Cola] FOREIGN KEY([IdCola])
REFERENCES [dbo].[Cola] ([IdCola])
GO
ALTER TABLE [dbo].[Tiquete] CHECK CONSTRAINT [FK_Tiquete_Cola]
GO
ALTER TABLE [dbo].[Tiquete]  WITH CHECK ADD  CONSTRAINT [FK_Tiquete_Estado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estado] ([IdEstado])
GO
ALTER TABLE [dbo].[Tiquete] CHECK CONSTRAINT [FK_Tiquete_Estado]
GO
ALTER TABLE [dbo].[Tiquete]  WITH CHECK ADD  CONSTRAINT [FK_Tiquete_Faq] FOREIGN KEY([IdFaq])
REFERENCES [dbo].[Faq] ([IdFaq])
GO
ALTER TABLE [dbo].[Tiquete] CHECK CONSTRAINT [FK_Tiquete_Faq]
GO
ALTER TABLE [dbo].[Tiquete]  WITH CHECK ADD  CONSTRAINT [FK_Tiquete_Inventario] FOREIGN KEY([IdInventario])
REFERENCES [dbo].[Inventario] ([IdInventario])
GO
ALTER TABLE [dbo].[Tiquete] CHECK CONSTRAINT [FK_Tiquete_Inventario]
GO
ALTER TABLE [dbo].[Tiquete]  WITH CHECK ADD  CONSTRAINT [FK_Tiquete_Servicio] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicio] ([IdServicio])
GO
ALTER TABLE [dbo].[Tiquete] CHECK CONSTRAINT [FK_Tiquete_Servicio]
GO
ALTER TABLE [dbo].[Tiquete]  WITH CHECK ADD  CONSTRAINT [FK_Tiquete_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Tiquete] CHECK CONSTRAINT [FK_Tiquete_Usuario]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
/****** Object:  StoredProcedure [dbo].[ConsultarColas]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarColas]
AS
BEGIN
    SELECT [IdCola]
          ,[NombreCola]
    FROM [dbo].[Cola]
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarFaq]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarFaq]
    @Titulo NVARCHAR(100)
AS
BEGIN
    SELECT [IdFaq]
          ,[Titulo]
          ,[Descripcion]
          ,[Solucion]
    FROM [dbo].[Faq]
    WHERE [Titulo] = @Titulo
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarInventario]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarInventario]
    @IdInventario NVARCHAR(50)
AS
BEGIN
    SELECT [IdInventario]
          ,[TipoEquipo]
          ,[Marca]
          ,[Modelo]
          ,[Serie]
          ,[Nombre]
          ,[VersionInv]
    FROM [dbo].[Inventario]
    WHERE [IdInventario] = @IdInventario
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarServicio]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarServicio]
    @TipoServicio NVARCHAR(50)
AS
BEGIN
    SELECT [IdServicio]
          ,[TipoServicio]
          ,[Tiempo]
    FROM [dbo].[Servicio]
    WHERE [TipoServicio] = @TipoServicio
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarTodoFaqs]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarTodoFaqs]
AS
BEGIN
    SELECT [IdFaq]
          ,[Titulo]
          ,[Descripcion]
          ,[Solucion]
    FROM [dbo].[Faq]
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarTodoInventario]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarTodoInventario]
AS
BEGIN
    SELECT [IdInventario]
          ,[TipoEquipo]
          ,[Marca]
          ,[Modelo]
          ,[Serie]
          ,[Nombre]
          ,[VersionInv]
    FROM [dbo].[Inventario]
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarTodoServicios]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarTodoServicios]
AS
BEGIN
    SELECT [IdServicio]
          ,[TipoServicio]
          ,[Tiempo]
    FROM [dbo].[Servicio]
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarUsuarios]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ConsultarUsuarios]

AS
BEGIN

	select u.Alias, u.Nombre, u.Apellido1, u.Apellido2, u.Correo, 
	r.NombreRol
	from dbo.Usuario u
	join rol r on u.IdRol = r.IdRol;

END
GO
/****** Object:  StoredProcedure [dbo].[GetColasByNombreCola]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetColasByNombreCola]
    @NombreCola NVARCHAR(50)
AS
BEGIN
    SELECT [IdCola]
          ,[NombreCola]
    FROM [dbo].[Cola]
    WHERE [NombreCola] = @NombreCola
END

GO
/****** Object:  StoredProcedure [dbo].[CrearInventario]    Script Date: 01/07/2023 16:38:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearInventario]
	@TipoEquipo varchar(50),
	@Marca varchar(50),
	@Modelo varchar(50),
	@Serie nvarchar(10),
	@Nombre varchar(50),
	@VersionInv float
AS
BEGIN
	INSERT INTO Inventario (TipoEquipo,Marca, Modelo, Serie, Nombre, VersionInv) VALUES(@TipoEquipo, @Marca, @Modelo, @Serie, @Nombre, @VersionInv)
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarInventario]    Script Date: 01/07/2023 16:38:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarInventario]
	@IdInventario int,
	@TipoEquipo varchar(50),
	@Marca varchar(50),
	@Modelo varchar(50),
	@Serie nvarchar(10),
	@Nombre varchar(50),
	@VersionInv float
AS
BEGIN

UPDATE Inventario SET TipoEquipo= @TipoEquipo,Marca= @Marca, Modelo= @Modelo, Serie= @Serie, Nombre= @Nombre, VersionInv = @VersionInv WHERE IdInventario = @IdInventario

END

GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IniciarSesion]
	@Correo VARCHAR(50),
	@Contrasenna VARCHAR(50)

AS
BEGIN

SELECT IdUsuario,
       Alias,
       Nombre,
       Apellido1,
       Apellido2,
       Correo,
       IdRol
  FROM dbo.Usuario
  WHERE Correo = @Correo
    AND Contrasenna = @Contrasenna


END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarUsuario]    Script Date: 6/17/2023 3:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegistrarUsuario]
	@Alias VARCHAR(50),
    @Nombre VARCHAR(50),
    @Apellido1 VARCHAR(50),
    @Apellido2 VARCHAR(50),
    @Correo VARCHAR(50),
	@Contrasenna VARCHAR(50),
    @IdRol int
AS
BEGIN

INSERT INTO dbo.Usuario (Alias, Nombre, Apellido1, Apellido2, Correo,Contrasenna, IdRol)
Values
	   (@Alias,
       @Nombre,
       @Apellido1,
       @Apellido2,
       @Correo,
	   @Contrasenna,
       @IdRol)

END
GO
USE [master]
GO
ALTER DATABASE [Services365] SET  READ_WRITE 
GO
/****** Object:  StoredProcedure [dbo].[CrearTiquete]    Script Date: 7/20/2023 6:43:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearTiquete]
@Titulo varchar(50),
@Descripcion varchar(50),
@FechaFinal datetime,
@IdUsuario int,
@IdTecnico int,
@IdEstado int,
@IdServicio int,
@IdCola int,
@IdFaq int,
@IdInvetario int
AS
BEGIN
	
	Insert into dbo.Tiquete(
	Titulo, Descripcion, 
	FechaInicio, FechaFinal,
	IdUsuario, IdTecnico,
	IdEstado, IdServicio,
	IdCola, IdFaq, IdInventario)
	Values(@Titulo, @Descripcion, 
	GETDATE(), @FechaFinal,
	@IdUsuario, @IdTecnico, 
	@IdEstado, @IdServicio,
	@IdCola, @IdFaq, @IdInvetario);

END
GO
/****** Object:  StoredProcedure [dbo].[EditarTiquete]    Script Date: 7/20/2023 6:43:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarTiquete]
@IdTiquete int,
@Titulo varchar(50),
@Descripcion varchar(50),
@FechaFinal datetime,
@IdUsuario int,
@IdTecnico int,
@IdEstado int,
@IdServicio int,
@IdCola int,
@IdFaq Int,
@IdInventario int
AS
BEGIN
    UPDATE dbo.Tiquete
    SET Titulo = @Titulo,
        Descripcion = @Descripcion,
        FechaFinal = @FechaFinal,
        IdUsuario = @IdUsuario,
        IdTecnico = @IdTecnico,
        IdEstado = @IdEstado,
		IdServicio = @IdServicio,
		IdCola = @IdCola, 
		IdFaq = @IdFaq, 
		IdInventario = @IdInventario
    WHERE IdTiquete = @IdTiquete;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarTiquete]    Script Date: 7/20/2023 6:43:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarTiquete]
@IdTiquete int
AS
BEGIN
    delete Tiquete
    WHERE IdTiquete = @IdTiquete;
END
GO
/****** Object:  StoredProcedure [dbo].[ListarTiquetes]    Script Date: 7/20/2023 6:43:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarTiquetes]
AS
BEGIN
select 
--Todo tiquete
tiquete.*,
--Todo de foreign keys
estado.*, servicio.*, cola.*, faq.*, inventario.*,
--Primer nombre es de rol usuario, segundo nombre es de rol tecnico
u.Nombre, ru.NombreRol, t.Nombre AS tecNombre, rt.NombreRol AS tecNombreRol
	from dbo.Tiquete tiquete
	join dbo.Estado estado on tiquete.IdEstado = estado.IdEstado
	join dbo.Servicio servicio on tiquete.IdServicio = servicio.IdServicio
	join dbo.Cola cola on tiquete.IdCola = cola.IdCola
	join dbo.Faq faq on tiquete.IdFaq = faq.IdFaq
	join dbo.Inventario inventario on tiquete.IdInventario = inventario.IdInventario
--Join de usuario
	join dbo.Usuario u on tiquete.IdUsuario = u.IdUsuario
--Join the tecnico
	join dbo.Usuario t on tiquete.IdTecnico = t.IdUsuario
--Join de rol usuario
	join dbo.Rol ru on u.IdRol = ru.IdRol
--join de rol tecnico
	join dbo.Rol rt on t.IdRol = rt.IdRol
--busqueda del tiquete
END
GO
/****** Object:  StoredProcedure [dbo].[BuscarTiquete]    Script Date: 7/20/2023 6:43:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuscarTiquete]
@IdTiquete int
AS
BEGIN
select 
--Todo tiquete
tiquete.*,
--Todo de foreign keys
estado.*, servicio.*, cola.*, faq.*, inventario.*,
--Primer nombre es de rol usuario, segundo nombre es de rol tecnico
u.Nombre, ru.NombreRol, t.Nombre, rt.NombreRol
	from dbo.Tiquete tiquete
	join dbo.Estado estado on tiquete.IdEstado = estado.IdEstado
	join dbo.Servicio servicio on tiquete.IdServicio = servicio.IdServicio
	join dbo.Cola cola on tiquete.IdCola = cola.IdCola
	join dbo.Faq faq on tiquete.IdFaq = faq.IdFaq
	join dbo.Inventario inventario on tiquete.IdInventario = inventario.IdInventario
--Join de usuario
	join dbo.Usuario u on tiquete.IdUsuario = u.IdUsuario
--Join the tecnico
	join dbo.Usuario t on tiquete.IdTecnico = t.IdUsuario
--Join de rol usuario
	join dbo.Rol ru on u.IdRol = ru.IdRol
--join de rol tecnico
	join dbo.Rol rt on t.IdRol = rt.IdRol
--busqueda del tiquete
where tiquete.IdTiquete = @IdTiquete ;
END
GO
