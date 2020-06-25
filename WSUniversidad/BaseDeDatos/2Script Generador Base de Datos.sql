USE [master]
GO
/****** Object:  Database [Universidad]    Script Date: 23/06/2020 18:13:51 ******/
CREATE DATABASE [Universidad]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Universidad', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Universidad.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Universidad_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Universidad_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Universidad] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Universidad].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Universidad] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Universidad] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Universidad] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Universidad] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Universidad] SET ARITHABORT OFF 
GO
ALTER DATABASE [Universidad] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Universidad] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Universidad] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Universidad] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Universidad] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Universidad] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Universidad] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Universidad] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Universidad] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Universidad] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Universidad] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Universidad] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Universidad] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Universidad] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Universidad] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Universidad] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Universidad] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Universidad] SET RECOVERY FULL 
GO
ALTER DATABASE [Universidad] SET  MULTI_USER 
GO
ALTER DATABASE [Universidad] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Universidad] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Universidad] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Universidad] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Universidad] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Universidad', N'ON'
GO
ALTER DATABASE [Universidad] SET QUERY_STORE = OFF
GO
USE [Universidad]
GO
/****** Object:  Table [dbo].[alumnos]    Script Date: 23/06/2020 18:13:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alumnos](
	[codigo_alumno] [bigint] NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[fecha_ingreso] [datetime] NOT NULL,
	[carrera] [int] NOT NULL,
	[estado_alumno] [varchar](50) NOT NULL,
 CONSTRAINT [PK_alumnos] PRIMARY KEY CLUSTERED 
(
	[codigo_alumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[log_eventos]    Script Date: 23/06/2020 18:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[log_eventos](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[fecha_evento] [datetime] NOT NULL,
	[usuario] [varchar](100) NOT NULL,
	[descripcion_evento] [varchar](150) NOT NULL,
	[valor_anterior] [varchar](50) NULL,
	[valor_actual] [varchar](50) NULL,
 CONSTRAINT [PK_log_eventos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[materias]    Script Date: 23/06/2020 18:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[materias](
	[codigo_materia] [int] NOT NULL,
	[nombre_materia] [varchar](50) NOT NULL,
	[creditos_materia] [int] NOT NULL,
 CONSTRAINT [PK_materias] PRIMARY KEY CLUSTERED 
(
	[codigo_materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[notas]    Script Date: 23/06/2020 18:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notas](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[cod_materia1] [int] NOT NULL,
	[cod_alumno1] [bigint] NOT NULL,
	[cod_profesor1] [bigint] NOT NULL,
	[nota] [decimal](16, 3) NOT NULL,
	[periodo] [int] NOT NULL,
 CONSTRAINT [PK_notas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profesores]    Script Date: 23/06/2020 18:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profesores](
	[cod_profesor] [bigint] NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
 CONSTRAINT [PK_profesores] PRIMARY KEY CLUSTERED 
(
	[cod_profesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rel_materia_alumno]    Script Date: 23/06/2020 18:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_materia_alumno](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[cod_materia2] [int] NOT NULL,
	[cod_alumno1] [bigint] NOT NULL,
 CONSTRAINT [PK_rel_materia_alumno] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rel_materia_profesor]    Script Date: 23/06/2020 18:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_materia_profesor](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[codigo_materia3] [int] NOT NULL,
	[codigo_profesor1] [bigint] NOT NULL,
 CONSTRAINT [PK_rel_materia_profesor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rel_materia_salon]    Script Date: 23/06/2020 18:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rel_materia_salon](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo_materia4] [int] NOT NULL,
	[nro_salon1] [int] NOT NULL,
 CONSTRAINT [PK_rel_materia_salon] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salones]    Script Date: 23/06/2020 18:13:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salones](
	[num_salon] [int] NOT NULL,
	[descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_salones] PRIMARY KEY CLUSTERED 
(
	[num_salon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[notas]  WITH CHECK ADD  CONSTRAINT [FK_notas_alumnos] FOREIGN KEY([cod_alumno1])
REFERENCES [dbo].[alumnos] ([codigo_alumno])
GO
ALTER TABLE [dbo].[notas] CHECK CONSTRAINT [FK_notas_alumnos]
GO
ALTER TABLE [dbo].[notas]  WITH CHECK ADD  CONSTRAINT [FK_notas_materias] FOREIGN KEY([cod_materia1])
REFERENCES [dbo].[materias] ([codigo_materia])
GO
ALTER TABLE [dbo].[notas] CHECK CONSTRAINT [FK_notas_materias]
GO
ALTER TABLE [dbo].[notas]  WITH CHECK ADD  CONSTRAINT [FK_notas_profesores] FOREIGN KEY([cod_profesor1])
REFERENCES [dbo].[profesores] ([cod_profesor])
GO
ALTER TABLE [dbo].[notas] CHECK CONSTRAINT [FK_notas_profesores]
GO
ALTER TABLE [dbo].[rel_materia_alumno]  WITH CHECK ADD  CONSTRAINT [FK_rel_materia_alumno_alumnos] FOREIGN KEY([cod_alumno1])
REFERENCES [dbo].[alumnos] ([codigo_alumno])
GO
ALTER TABLE [dbo].[rel_materia_alumno] CHECK CONSTRAINT [FK_rel_materia_alumno_alumnos]
GO
ALTER TABLE [dbo].[rel_materia_alumno]  WITH CHECK ADD  CONSTRAINT [FK_rel_materia_alumno_materias] FOREIGN KEY([cod_materia2])
REFERENCES [dbo].[materias] ([codigo_materia])
GO
ALTER TABLE [dbo].[rel_materia_alumno] CHECK CONSTRAINT [FK_rel_materia_alumno_materias]
GO
ALTER TABLE [dbo].[rel_materia_profesor]  WITH CHECK ADD  CONSTRAINT [FK_rel_materia_profesor_materias] FOREIGN KEY([codigo_materia3])
REFERENCES [dbo].[materias] ([codigo_materia])
GO
ALTER TABLE [dbo].[rel_materia_profesor] CHECK CONSTRAINT [FK_rel_materia_profesor_materias]
GO
ALTER TABLE [dbo].[rel_materia_profesor]  WITH CHECK ADD  CONSTRAINT [FK_rel_materia_profesor_profesores] FOREIGN KEY([codigo_profesor1])
REFERENCES [dbo].[profesores] ([cod_profesor])
GO
ALTER TABLE [dbo].[rel_materia_profesor] CHECK CONSTRAINT [FK_rel_materia_profesor_profesores]
GO
ALTER TABLE [dbo].[rel_materia_salon]  WITH CHECK ADD  CONSTRAINT [FK_rel_materia_salon_materias] FOREIGN KEY([codigo_materia4])
REFERENCES [dbo].[materias] ([codigo_materia])
GO
ALTER TABLE [dbo].[rel_materia_salon] CHECK CONSTRAINT [FK_rel_materia_salon_materias]
GO
ALTER TABLE [dbo].[rel_materia_salon]  WITH CHECK ADD  CONSTRAINT [FK_rel_materia_salon_salones] FOREIGN KEY([nro_salon1])
REFERENCES [dbo].[salones] ([num_salon])
GO
ALTER TABLE [dbo].[rel_materia_salon] CHECK CONSTRAINT [FK_rel_materia_salon_salones]
GO
USE [master]
GO
ALTER DATABASE [Universidad] SET  READ_WRITE 
GO
