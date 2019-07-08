USE [master]
GO
/****** Object:  Database [Fitness]    Script Date: 08.07.2019 16:25:27 ******/
CREATE DATABASE [Fitness]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Fitness', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Fitness.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Fitness_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Fitness_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Fitness] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Fitness].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Fitness] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Fitness] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Fitness] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Fitness] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Fitness] SET ARITHABORT OFF 
GO
ALTER DATABASE [Fitness] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Fitness] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Fitness] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Fitness] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Fitness] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Fitness] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Fitness] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Fitness] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Fitness] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Fitness] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Fitness] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Fitness] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Fitness] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Fitness] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Fitness] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Fitness] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Fitness] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Fitness] SET RECOVERY FULL 
GO
ALTER DATABASE [Fitness] SET  MULTI_USER 
GO
ALTER DATABASE [Fitness] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Fitness] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Fitness] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Fitness] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Fitness] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Fitness', N'ON'
GO
ALTER DATABASE [Fitness] SET QUERY_STORE = OFF
GO
USE [Fitness]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 08.07.2019 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](250) NULL,
	[Password] [nvarchar](250) NULL,
	[FullName] [nvarchar](250) NULL,
	[Photo] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calendar]    Script Date: 08.07.2019 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calendar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Start] [datetime] NULL,
	[Finish] [datetime] NULL,
	[Description] [nvarchar](250) NULL,
	[Day] [nvarchar](250) NULL,
	[Category] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClubInfo]    Script Date: 08.07.2019 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClubInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](100) NULL,
	[Address] [nvarchar](250) NULL,
	[City] [nvarchar](100) NULL,
	[Pincode] [nvarchar](100) NULL,
	[Fax] [nvarchar](100) NULL,
	[Website] [nvarchar](250) NULL,
	[Photo] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coupon]    Script Date: 08.07.2019 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coupon](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Start] [datetime] NULL,
	[Finish] [datetime] NULL,
	[Description] [nvarchar](250) NULL,
	[Photo] [nvarchar](250) NULL,
	[Code] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 08.07.2019 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Duration] [nvarchar](150) NULL,
	[Price] [int] NULL,
	[Description] [nvarchar](250) NULL,
	[Photo] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseSched]    Script Date: 08.07.2019 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseSched](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Start] [datetime] NULL,
	[Finish] [datetime] NULL,
	[Description] [nvarchar](250) NULL,
	[CourseId] [int] NULL,
	[RoomId] [int] NULL,
	[TrainerId] [int] NULL,
	[Status] [bit] NOT NULL,
	[Day] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Package]    Script Date: 08.07.2019 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Start] [datetime] NULL,
	[Finish] [datetime] NULL,
	[Description] [nvarchar](250) NULL,
	[Photo] [nvarchar](250) NULL,
	[Amount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 08.07.2019 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainer]    Script Date: 08.07.2019 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08.07.2019 16:25:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Email] [nvarchar](150) NULL,
	[Number] [nvarchar](150) NULL,
	[Gender] [bit] NULL,
	[Address] [nvarchar](250) NULL,
	[City] [nvarchar](150) NULL,
	[Pincode] [nvarchar](150) NULL,
	[Country] [nvarchar](150) NULL,
	[Photo] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([Id], [Username], [Password], [FullName], [Photo]) VALUES (1, N'admin', N'21232F297A57A5A743894A0E4A801FC3', N'Rauf Allahverdiyev', N'20190707022515621IMG_6055')
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[ClubInfo] ON 

INSERT [dbo].[ClubInfo] ([Id], [Number], [Address], [City], [Pincode], [Fax], [Website], [Photo]) VALUES (1, N'12345 54321', N'Fifth Avenue', N'New York', N'22222', N'11111', N'www.google.com', N'20190706040800814avatar5.jpg')
SET IDENTITY_INSERT [dbo].[ClubInfo] OFF
SET IDENTITY_INSERT [dbo].[Coupon] ON 

INSERT [dbo].[Coupon] ([Id], [Name], [Start], [Finish], [Description], [Photo], [Code]) VALUES (2, N'Body Building', CAST(N'2019-09-07T00:00:00.000' AS DateTime), CAST(N'2019-10-07T00:00:00.000' AS DateTime), N'<h3 style="color:#aaaaaa;font-style:italic;">Entering this code , you can get 20% discount for a month.</h3>
', N'2019070812271362916.jpg', N'RRAA03')
INSERT [dbo].[Coupon] ([Id], [Name], [Start], [Finish], [Description], [Photo], [Code]) VALUES (3, N'Crossfit', CAST(N'2019-07-14T00:00:00.000' AS DateTime), CAST(N'2019-07-28T00:00:00.000' AS DateTime), N'<p><em><strong>Nothing</strong></em></p>
', N'2019070802541562512.jpg', N'ANRP39')
SET IDENTITY_INSERT [dbo].[Coupon] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Name], [Duration], [Price], [Description], [Photo]) VALUES (8, N'Swimming', N'4 Months', 50, N'<p><span class="marker">Your weight is twice less in water.</span></p>
', N'2019070812591957117.jpg')
INSERT [dbo].[Course] ([Id], [Name], [Duration], [Price], [Description], [Photo]) VALUES (9, N'Yoga', N'1 Month', 150, N'<div style="background:#eeeeee;border:1px solid #cccccc;padding:5px 10px;">Yoga is wonderful</div>
', N'201907080108261738.jpg')
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[CourseSched] ON 

INSERT [dbo].[CourseSched] ([Id], [Start], [Finish], [Description], [CourseId], [RoomId], [TrainerId], [Status], [Day]) VALUES (5, CAST(N'2019-09-03T00:00:00.000' AS DateTime), CAST(N'2020-09-03T00:00:00.000' AS DateTime), N'<p>Birthday</p>
', 9, 5, 4, 0, N'Thursday')
SET IDENTITY_INSERT [dbo].[CourseSched] OFF
SET IDENTITY_INSERT [dbo].[Package] ON 

INSERT [dbo].[Package] ([Id], [Name], [Start], [Finish], [Description], [Photo], [Amount]) VALUES (5, N'Crossfit', CAST(N'2019-09-07T00:00:00.000' AS DateTime), CAST(N'2019-09-08T00:01:00.000' AS DateTime), N'<p><em><strong>Crossfit requires much stamina. You can join unless you have a heart problem</strong></em></p>
', N'20190706042043531f3.jpg', 80)
SET IDENTITY_INSERT [dbo].[Package] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([Id], [Name]) VALUES (3, N'Room 1')
INSERT [dbo].[Room] ([Id], [Name]) VALUES (4, N'Room 2')
INSERT [dbo].[Room] ([Id], [Name]) VALUES (5, N'Room 3')
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[Trainer] ON 

INSERT [dbo].[Trainer] ([Id], [Name]) VALUES (2, N'Rauf Allahverdiyev')
INSERT [dbo].[Trainer] ([Id], [Name]) VALUES (3, N'Zaur Allahverdiyev')
INSERT [dbo].[Trainer] ([Id], [Name]) VALUES (4, N'Anthony Josua')
INSERT [dbo].[Trainer] ([Id], [Name]) VALUES (5, N'Toğrul Rzayev')
SET IDENTITY_INSERT [dbo].[Trainer] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Email], [Number], [Gender], [Address], [City], [Pincode], [Country], [Photo]) VALUES (4, N'rauf2002', N'raufsa@code.edu.az', N'+994 50 850 75 75', 0, N'M.Hadi 136A', N'Davis', N'030902', N'CA', N'20190707104057627IMG_6055.JPG')
INSERT [dbo].[Users] ([Id], [Name], [Email], [Number], [Gender], [Address], [City], [Pincode], [Country], [Photo]) VALUES (7, N'nickottt', N'nihad@code.edu.az', N'+994 51 491 38 00', 0, N'Badamdar', N'Las Vegas', N'2108', N'NV', N'20190708035327254nihad.jpg')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[CourseSched]  WITH CHECK ADD FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[CourseSched]  WITH CHECK ADD FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[CourseSched]  WITH CHECK ADD FOREIGN KEY([TrainerId])
REFERENCES [dbo].[Trainer] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Fitness] SET  READ_WRITE 
GO
