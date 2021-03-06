USE [master]
GO
/****** Object:  Database [BookHiveDb]    Script Date: 04-07-2022 08:21:58 AM ******/
CREATE DATABASE [BookHiveDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookHiveDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\BookHiveDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BookHiveDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\BookHiveDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BookHiveDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookHiveDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookHiveDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookHiveDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookHiveDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookHiveDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookHiveDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookHiveDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookHiveDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookHiveDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookHiveDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookHiveDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookHiveDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookHiveDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookHiveDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookHiveDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookHiveDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookHiveDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookHiveDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookHiveDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookHiveDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookHiveDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookHiveDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookHiveDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookHiveDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookHiveDb] SET  MULTI_USER 
GO
ALTER DATABASE [BookHiveDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookHiveDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookHiveDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookHiveDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BookHiveDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BookHiveDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BookHiveDb] SET QUERY_STORE = OFF
GO
USE [BookHiveDb]
GO
/****** Object:  Table [dbo].[AdminDetails]    Script Date: 04-07-2022 08:21:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminDetails](
	[AdminEmail] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookDetails]    Script Date: 04-07-2022 08:21:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookDetails](
	[BookName] [nvarchar](50) NULL,
	[BookId] [int] NOT NULL,
	[Gerner] [nvarchar](50) NULL,
	[Author] [nvarchar](50) NULL,
	[Language] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [float] NULL,
	[Photo] [varchar](max) NULL,
 CONSTRAINT [PK_BookDetails] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 04-07-2022 08:21:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[UserEmail] [nvarchar](50) NULL,
	[UserId] [int] NULL,
	[BookName] [nvarchar](50) NULL,
	[Price] [float] NULL,
	[Quantity] [int] NULL,
	[TotalBill] [float] NULL,
	[Address] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 04-07-2022 08:21:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[UserName] [nvarchar](50) NULL,
	[UserEmail] [nvarchar](50) NULL,
	[Contact] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Password] [nvarchar](50) NULL,
	[UserId] [int] IDENTITY(111,1) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AdminDetails] ([AdminEmail], [Password]) VALUES (N'saidhanush@gmail.com', N'Dhanush@1234')
GO
INSERT [dbo].[BookDetails] ([BookName], [BookId], [Gerner], [Author], [Language], [Description], [Price], [Photo]) VALUES (N'Wish I Could Tell You', 501, N'Fiction', N'Durjoy Datta', N'English', N'If you have lost a special one in your life, Wish I Could Tell You is a power-packed story that conveys the message of selfless and pure love and will help you find yourself.', 150, N'https://th.bing.com/th/id/OIP.Y-Vssr8doT7GgHSBtRLsbgAAAA?pid=ImgDet&w=184&h=282&c=7&dpr=1.25')
INSERT [dbo].[BookDetails] ([BookName], [BookId], [Gerner], [Author], [Language], [Description], [Price], [Photo]) VALUES (N'To Kill a Mockingbird', 502, N'Crime', N'Harper Lee', N'English', N'Told through the eyes of a child To Kill a Mockingbird is primarily an example of Southern Gothic fiction that combines both dark and comedic elements and uses a perfect blend of thrill and fiction to exude a deep message', 349.5, N'https://th.bing.com/th/id/OIP.aTa-kZ0PhtKm8_RkQR0UJwHaJ4?pid=ImgDet&w=213&h=283&c=7&dpr=1.25')
INSERT [dbo].[BookDetails] ([BookName], [BookId], [Gerner], [Author], [Language], [Description], [Price], [Photo]) VALUES (N'One Arranged Murder', 503, N'Mystery', N'Chetan Bhagat', N'English', N'One Arranged Murder is one of the best thriller mysteries with a good story, interesting plot and unexpected twists.', 200, N'https://th.bing.com/th/id/OIP.qW0RX_CMBHqVANwE0U-rvwAAAA?pid=ImgDet&w=213&h=288&c=7&dpr=1.25')
INSERT [dbo].[BookDetails] ([BookName], [BookId], [Gerner], [Author], [Language], [Description], [Price], [Photo]) VALUES (N'Think Like a Monk', 504, N'Self-help book', N'Jay Shetty', N'English', N'Want to train your mind to attain inner peace and purpose every day, Think Like a Monk is one of the best books to get your hands on.', 299, N'https://th.bing.com/th/id/OIP.KAYv4DRQ7CccBMXJPv0HrAAAAA?pid=ImgDet&w=212&h=283&c=7&dpr=1.25')
INSERT [dbo].[BookDetails] ([BookName], [BookId], [Gerner], [Author], [Language], [Description], [Price], [Photo]) VALUES (N'Wise and Otherwise', 505, N'Non-fiction', N'Sudha Murthy', N'English', N'Wise and Otherwise is one of the best books by Sudha Murthy. The book explains how understanding human and human nature is one of the toughest jobs in this world. With an interesting title and content inside, the book shows how things that seem right or good or vice versa can be completely different if explored to the proper depth.', 199, N'https://th.bing.com/th/id/OIP.bFGxCuQh1KjfHbavGYaTrwHaLR?pid=ImgDet&w=203&h=308&c=7&dpr=1.25')
INSERT [dbo].[BookDetails] ([BookName], [BookId], [Gerner], [Author], [Language], [Description], [Price], [Photo]) VALUES (N'The Alchemist', 506, N'Horror', N'Paulo Coelho', N'English', N'The book shows how we all have our goals and must never give up - no matter how many obstacles come our way. The book was originally written in Portuguese and later translated into English. The book is a perfect pick for beginners, inspiring them to take the risk of following their hearts and realizing their dreams.', 249, N'https://th.bing.com/th/id/OIP.V6xZbGrESoRr16qpWje5zgAAAA?pid=ImgDet&w=203&h=307&c=7&dpr=1.25')
INSERT [dbo].[BookDetails] ([BookName], [BookId], [Gerner], [Author], [Language], [Description], [Price], [Photo]) VALUES (N'Ikigai', 507, N'Self-helf', N'Francesc Miralles and Hector Gar', N'English', N'While giving a message of devoting time to your passion, the book is a great pick if you want to stop chasing materialistic things and stay focused in your life to attain inner peace and happiness.', 349, N'https://th.bing.com/th/id/OIP.dxiTXo1D--POGfZNSIQ4vAHaLc?pid=ImgDet&w=201&h=311&c=7&dpr=1.25')
INSERT [dbo].[BookDetails] ([BookName], [BookId], [Gerner], [Author], [Language], [Description], [Price], [Photo]) VALUES (N'A Man Called Ove', 508, N'Novel', N'Fredrik Backman', N'English', N'The book is an example of a character study where Oves interaction with everything, his views towards society and his ironclad rules in life are gradually changed. The story focuses on how love and friendship make Ove - a lonely and grumpy old man loved by all.",
', 299, N'https://th.bing.com/th/id/OIP.-SYURqk6TmcoU9uyAFR_gQHaLe?pid=ImgDet&w=201&h=311&c=7&dpr=1.25')
INSERT [dbo].[BookDetails] ([BookName], [BookId], [Gerner], [Author], [Language], [Description], [Price], [Photo]) VALUES (N'The Art of Living', 509, N'Spirituality', N'Paramahansa Yogananda', N'English', N'The Art of Living contains practical guidance for everyday living.', 199, N'https://th.bing.com/th/id/OIP.VJudHEoOLvRt02FMsHrjFAHaKl?pid=ImgDet&w=209&h=299&c=7&dpr=1.25')
INSERT [dbo].[BookDetails] ([BookName], [BookId], [Gerner], [Author], [Language], [Description], [Price], [Photo]) VALUES (N'The Gift of Forgiveness', 510, N'Spirituality', N'Katherine Pratt', N'English', N'This inspiring book tells real-life stories of learning to forgive the seemingly unforgivable. Its raw, brave approach to writing will help you have hope for the future and improve your interpersonal relationships.', 499, N'https://th.bing.com/th/id/OIP.lTrmrpnjWedLMZzOsiOMTQHaK8?pid=ImgDet&w=206&h=304&c=7&dpr=1.25')
GO
INSERT [dbo].[Cart] ([UserEmail], [UserId], [BookName], [Price], [Quantity], [TotalBill], [Address]) VALUES (N'vimala@email.com', 222, N'AngularText', 1000, 2, 2000, NULL)
INSERT [dbo].[Cart] ([UserEmail], [UserId], [BookName], [Price], [Quantity], [TotalBill], [Address]) VALUES (N'nandini@email.com', 112, N'Sql Text', 3999, 1, 3999, N'Raj,Ap')
INSERT [dbo].[Cart] ([UserEmail], [UserId], [BookName], [Price], [Quantity], [TotalBill], [Address]) VALUES (N'nandini@email.com', 112, N'Arabian Nights', 123.55, 1, 123.55, N'Raj,Ap')
INSERT [dbo].[Cart] ([UserEmail], [UserId], [BookName], [Price], [Quantity], [TotalBill], [Address]) VALUES (N'ravi@email.com', 116, N'Wish I Could Tell You', 150, 1, 150, N'A.p')
INSERT [dbo].[Cart] ([UserEmail], [UserId], [BookName], [Price], [Quantity], [TotalBill], [Address]) VALUES (N'dhanush@gmail.com', 1128, N'Wish I Could Tell You', 150, 1, 150, N'Machilipatnam')
INSERT [dbo].[Cart] ([UserEmail], [UserId], [BookName], [Price], [Quantity], [TotalBill], [Address]) VALUES (N'dhanush@gmail.com', 1128, N'To Kill a Mockingbird', 349.5, 1, 349.5, N'Machilipatnam')
INSERT [dbo].[Cart] ([UserEmail], [UserId], [BookName], [Price], [Quantity], [TotalBill], [Address]) VALUES (N'dhanush@gmail.com', 1128, N'Think Like a Monk', 299, 1, 299, N'Machilipatnam')
GO
SET IDENTITY_INSERT [dbo].[UserDetails] ON 

INSERT [dbo].[UserDetails] ([UserName], [UserEmail], [Contact], [Address], [Password], [UserId]) VALUES (N'Dhanush', N'dhanush@gmail.com', N'9999999999', N'Machilipatnam', N'Dhanush@12345', 1128)
INSERT [dbo].[UserDetails] ([UserName], [UserEmail], [Contact], [Address], [Password], [UserId]) VALUES (N'Aditya', N'aditya@gmail.com', N'8888888888', N'Delhi', N'Aditya@12345', 1129)
INSERT [dbo].[UserDetails] ([UserName], [UserEmail], [Contact], [Address], [Password], [UserId]) VALUES (N'Hussain', N'Hussain@gmail.com', N'888899999', N'Bangalore', N'Hussain@12345', 1130)
INSERT [dbo].[UserDetails] ([UserName], [UserEmail], [Contact], [Address], [Password], [UserId]) VALUES (N'Ravi', N'Ravi@gmail.com', N'77777777', N'Andhra Pradesh', N'Ravi@12345', 1131)
INSERT [dbo].[UserDetails] ([UserName], [UserEmail], [Contact], [Address], [Password], [UserId]) VALUES (N'Nandini', N'Nandini@gmail.com', N'7799885566', N'Andhra Pradesh', N'Nandini@12345', 1132)
INSERT [dbo].[UserDetails] ([UserName], [UserEmail], [Contact], [Address], [Password], [UserId]) VALUES (N'Vimala', N'Vimala@gmail.com', N'9191919191', N'Andhra Pradesh', N'Vimala@12345', 1133)
SET IDENTITY_INSERT [dbo].[UserDetails] OFF
GO
USE [master]
GO
ALTER DATABASE [BookHiveDb] SET  READ_WRITE 
GO
