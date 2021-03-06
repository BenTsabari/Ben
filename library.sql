USE [master]
GO
/****** Object:  Database [mydb]    Script Date: 30/03/2021 18:38:39 ******/
CREATE DATABASE [mydb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mynew', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Mynew.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Mynew_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Mynew.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [mydb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [mydb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [mydb] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [mydb] SET ANSI_NULLS ON 
GO
ALTER DATABASE [mydb] SET ANSI_PADDING ON 
GO
ALTER DATABASE [mydb] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [mydb] SET ARITHABORT ON 
GO
ALTER DATABASE [mydb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [mydb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [mydb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [mydb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [mydb] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [mydb] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [mydb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [mydb] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [mydb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [mydb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [mydb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [mydb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [mydb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [mydb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [mydb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [mydb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [mydb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [mydb] SET RECOVERY FULL 
GO
ALTER DATABASE [mydb] SET  MULTI_USER 
GO
ALTER DATABASE [mydb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [mydb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [mydb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [mydb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [mydb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [mydb] SET QUERY_STORE = OFF
GO
USE [mydb]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 30/03/2021 18:38:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 30/03/2021 18:38:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](40) NULL,
	[SupplierID] [int] NULL,
	[BookAuthor] [nvarchar](100) NULL,
	[BookPrintedYear] [int] NULL,
	[BookShelfLoction] [int] NULL,
	[BookBinding] [bit] NULL,
	[CategoryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 30/03/2021 18:38:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[ContactName] [nvarchar](50) NULL,
	[ContactTitle] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[City] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 30/03/2021 18:38:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (1, N'On Shelf')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (2, N'To Find')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (3, N'Adventures')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (4, N'Kids')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (5, N'Travel')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (6, N'Novel')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (8, N'Textbooks')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (13, N'Sciences')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (14, N'Psychology')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (177, N'kate')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (179, N'Danielle')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (180, N'ben')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (181, N'anna')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (183, N'Test')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (184, N'Test2')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (185, N'Test4')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (186, N'Test5')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (189, N'Test8')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([BookID], [BookName], [SupplierID], [BookAuthor], [BookPrintedYear], [BookShelfLoction], [BookBinding], [CategoryID]) VALUES (20, N'a', 3, N'a', 1, 1, 0, 1)
INSERT [dbo].[Products] ([BookID], [BookName], [SupplierID], [BookAuthor], [BookPrintedYear], [BookShelfLoction], [BookBinding], [CategoryID]) VALUES (21, N'b', 3, N'b', 2, 10, 0, 1)
INSERT [dbo].[Products] ([BookID], [BookName], [SupplierID], [BookAuthor], [BookPrintedYear], [BookShelfLoction], [BookBinding], [CategoryID]) VALUES (22, N'c', 1, N'c', 5, 51, 0, 1)
INSERT [dbo].[Products] ([BookID], [BookName], [SupplierID], [BookAuthor], [BookPrintedYear], [BookShelfLoction], [BookBinding], [CategoryID]) VALUES (23, N'd', 1, N'd', 1, 4, 0, 3)
INSERT [dbo].[Products] ([BookID], [BookName], [SupplierID], [BookAuthor], [BookPrintedYear], [BookShelfLoction], [BookBinding], [CategoryID]) VALUES (29, N'dj', 1, N'd', 444, 47, 0, 1)
INSERT [dbo].[Products] ([BookID], [BookName], [SupplierID], [BookAuthor], [BookPrintedYear], [BookShelfLoction], [BookBinding], [CategoryID]) VALUES (30, N'fff', 1, N'fff', 3, 61, 0, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City]) VALUES (1, N'eyal', N'HHH', N'HHH', N'HHH', N'HHH')
INSERT [dbo].[Suppliers] ([SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City]) VALUES (3, N'dddd', N'dddd', N'dddd', N'dddd', N'dddd')
INSERT [dbo].[Suppliers] ([SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City]) VALUES (38, N'b', N'b', N'b', N'b', N'b')
INSERT [dbo].[Suppliers] ([SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City]) VALUES (41, N'e', N'e', N'e', N'e', N'e')
INSERT [dbo].[Suppliers] ([SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City]) VALUES (42, N'f', N'f', N'f', N'f', N'f')
INSERT [dbo].[Suppliers] ([SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City]) VALUES (43, N'l', N'l', N'l', N'l', N'l')
INSERT [dbo].[Suppliers] ([SupplierID], [CompanyName], [ContactName], [ContactTitle], [Address], [City]) VALUES (45, N's2', N's2', N's2', N's2', N's2')
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (4, N'Kate', N'Tsabari')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (5, N'Danielle', N'Ben')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (7, N'Amiram', N'Tsabari')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (8, N'a', N'a')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (9, N'b', N'b')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (10, N'c', N'c')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (12, N'd', N'd')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (13, N'yy', N'yy')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (14, N'Lior', N'Lior')
INSERT [dbo].[Users] ([UserID], [UserName], [Password]) VALUES (15, N'Dana', N'Banana')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
USE [master]
GO
ALTER DATABASE [mydb] SET  READ_WRITE 
GO
