USE [master]
GO
/****** Object:  Database [Jamesthew]    Script Date: 03-Nov-18 3:16:22 AM ******/
CREATE DATABASE [Jamesthew]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Jamesthew', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Jamesthew.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Jamesthew_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Jamesthew_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Jamesthew].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Jamesthew] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Jamesthew] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Jamesthew] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Jamesthew] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Jamesthew] SET ARITHABORT OFF 
GO
ALTER DATABASE [Jamesthew] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Jamesthew] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Jamesthew] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Jamesthew] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Jamesthew] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Jamesthew] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Jamesthew] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Jamesthew] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Jamesthew] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Jamesthew] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Jamesthew] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Jamesthew] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Jamesthew] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Jamesthew] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Jamesthew] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Jamesthew] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Jamesthew] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Jamesthew] SET RECOVERY FULL 
GO
ALTER DATABASE [Jamesthew] SET  MULTI_USER 
GO
ALTER DATABASE [Jamesthew] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Jamesthew] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Jamesthew] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Jamesthew] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Jamesthew', N'ON'
GO
USE [Jamesthew]
GO
/****** Object:  Table [dbo].[article]    Script Date: 03-Nov-18 3:16:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[article](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](max) NOT NULL,
	[body] [varchar](max) NOT NULL,
	[excerpt] [varchar](max) NOT NULL,
	[content_type] [varchar](250) NOT NULL,
	[published_at] [date] NULL,
	[created_by] [int] NOT NULL,
	[created_at] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[article_meta]    Script Date: 03-Nov-18 3:16:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[article_meta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[article_id] [int] NOT NULL,
	[_key] [varchar](250) NOT NULL,
	[_value] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[feedback]    Script Date: 03-Nov-18 3:16:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[feedback](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[article_id] [int] NOT NULL,
	[body] [varchar](max) NOT NULL,
	[created_by] [int] NOT NULL,
	[created_at] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[package]    Script Date: 03-Nov-18 3:16:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[package](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](max) NOT NULL,
	[body] [varchar](max) NOT NULL,
	[price] [int] NOT NULL,
	[expirydate] [int] NOT NULL,
	[is_public] [bit] NOT NULL,
	[created_by] [int] NOT NULL,
	[created_at] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment]    Script Date: 03-Nov-18 3:16:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[package_id] [int] NOT NULL,
	[title] [varchar](max) NOT NULL,
	[card_number] [int] NOT NULL,
	[card_expirydate] [date] NOT NULL,
	[csc] [int] NOT NULL,
	[created_by] [int] NOT NULL,
	[created_at] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[taxonomy]    Script Date: 03-Nov-18 3:16:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taxonomy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](max) NOT NULL,
	[body] [varchar](max) NOT NULL,
	[excerpt] [varchar](max) NOT NULL,
	[content_type] [varchar](250) NOT NULL,
	[created_by] [int] NOT NULL,
	[created_at] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[taxonomy_m2m]    Script Date: 03-Nov-18 3:16:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taxonomy_m2m](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[article_id] [int] NOT NULL,
	[taxonomy_id] [int] NOT NULL,
	[created_by] [int] NOT NULL,
	[created_at] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[taxonomy_meta]    Script Date: 03-Nov-18 3:16:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taxonomy_meta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[taxonomy_id] [int] NOT NULL,
	[_key] [varchar](250) NOT NULL,
	[_value] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 03-Nov-18 3:16:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[_password] [varchar](32) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[package_expirydate] [date] NULL,
	[is_admin] [bit] NOT NULL,
	[is_active] [bit] NOT NULL,
	[created_at] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[article] ON 

INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (1, N'Chicken', N'Chicken', N'Chiken', N'Recipe', CAST(N'2018-10-30' AS Date), 1, CAST(N'2018-10-30' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (2, N'Cafe', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-20' AS Date), 2, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (8, N'Cafe', N'jkhsfakjshf', N'Vegetable', N'Recipes', CAST(N'2018-10-20' AS Date), 1, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (9, N'Cafe', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-20' AS Date), 1, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (10, N'Cafe', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-20' AS Date), 1, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (11, N'Cafe', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-20' AS Date), 1, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (12, N'Cafe', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-20' AS Date), 1, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (13, N'Cafe', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-20' AS Date), 1, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (14, N'TAO XIN MAY', N'TAO XIN MAY', N'recipes', N'TIPS', CAST(N'2018-09-20' AS Date), 2, CAST(N'0001-01-01' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (15, N'VIP 1 Month', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-20' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (16, N'Cafe', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (17, N'Cafe', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (18, N'GG', N'GG', N'GG', N'GG', CAST(N'2018-10-31' AS Date), 3, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (19, N'Cafe', N'Chicken', N'Vegetable', N'Re', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (20, N'Cafe', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (21, N'Cafe', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-31' AS Date), 3, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (22, N'VIP 1 Month', N'Chicken', N'Vegetable', N'Re', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (23, N'Cafe', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (24, N'Cafe', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-31' AS Date), 3, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (25, N'Cafe', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (26, N'Cafe', N'Chicken', N'Vegetable', N'Re', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (27, N'test', N'test', N'test', N'test', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (28, N'Cafe', N'Chicken', N'Vegetable', N'Recipes', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (29, N'asdsadas', N'TEST
TEST
TEST
TEST', N'TEST', N'Recipe', CAST(N'2018-10-31' AS Date), 4, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (30, N'Cafe', N'WASHINGTON — 
Kimberly Williams acknowledges that she may not be what many people think of when they hear the phrase “evangelical Christian.”

In fact, Williams herself isn’t sure she embraces the label these days, even though she leads worship at the District Church in Washington, D.C., which by any definition is evangelical in belief.

“I’m still wrestling with it,” she says, worried the phrase has become too politicized and misunderstood. “As a woman and as a person of color, it’s just hard,” says Williams, an African-American.

That’s a growing sentiment within church-going evangelical circles in the U.S., especially among the expanding number of evangelicals who are nonwhite.

Almost 1-in-3 American evangelicals are not white, according to a 2017 study by the Public Religion Research Institute. And though many evangelicals of color embrace a conservative theology, their political beliefs are more varied than is commonly portrayed in the media.

As the 2018 midterm elections approach, the schisms suggest evangelical Christians, who make up a quarter of the population, may not be as solidly supportive of President Donald Trump and the Republican Party as many suspect.', N'bbbb', N'Tip', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (31, N'asd', N'asd', N'asd', N'Tip', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (32, N'xin chao', N'xin chao', N'xin chao', N'Tip', CAST(N'2018-10-31' AS Date), 2, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (34, N'What is your favorite?', N'dogs', N'dogs', N'FAQ', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (35, N'Egg', N'asda', N'sadsad', N'Material', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (36, N'Lunch', N'this is category for lunch', N'this is category for lunch', N'Category', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (37, N'bbbbbbbbbbbbbbbbbbbbb', N'asdasd', N'asdasdas', N'Recipe', CAST(N'2018-10-31' AS Date), 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (38, N'Egg', N'Egg', N'Egg', N'Tip', CAST(N'2018-11-01' AS Date), 1, CAST(N'2018-11-01' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (39, N'Tao thich', N'Tao thich', N'Tao thich', N'Recipe', CAST(N'2018-11-02' AS Date), 4, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (40, N'123', N'123', N'123', N'Recipe', CAST(N'2018-11-02' AS Date), 3, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (41, N'132', N'321', N'321', N'Recipe', CAST(N'2018-11-02' AS Date), 4, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (42, N'Premium', N'Premium', N'Premium', N'Tip', CAST(N'2018-11-02' AS Date), 1, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (43, N'Announcement', N'Fist Announcement', N'Announcement', N'Announcement', CAST(N'2018-11-02' AS Date), 1, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (44, N'Hello', N'AVC', N'AVC', N'FAQ', CAST(N'2018-11-02' AS Date), 1, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (45, N'sadasdsa', N'sadsadsad', N'sadsadsa', N'Recipe', CAST(N'2018-11-02' AS Date), 1, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (46, N'sadsadsa', N'sadsad', N'asdsadas', N'Recipe', CAST(N'2018-11-02' AS Date), 1, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[article] ([id], [title], [body], [excerpt], [content_type], [published_at], [created_by], [created_at]) VALUES (47, N'21321', N'321321', N'312321', N'Tip', CAST(N'2018-11-02' AS Date), 1, CAST(N'2018-11-02' AS Date))
SET IDENTITY_INSERT [dbo].[article] OFF
SET IDENTITY_INSERT [dbo].[article_meta] ON 

INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (1, 1, N'premium', N'true')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (2, 20, N'premium', N'true')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (3, 21, N'premium', N'true')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (4, 22, N'premium', N'false')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (5, 23, N'premium', N'true')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (6, 24, N'premium', N'true')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (7, 25, N'premium', N'true')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (8, 26, N'imagefile', N'~/images/THUA.PNG')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (9, 26, N'premium', N'true')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (10, 29, N'premium', N'true')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (11, 32, N'premium', N'true')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (12, 37, N'premium', N'true')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (13, 38, N'imagefile', N'~/images/cropper.jpg')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (14, 38, N'premium', N'true')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (15, 39, N'imagefile', N'~/images/3.jpg')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (16, 39, N'premium', N'false')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (17, 40, N'premium', N'False')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (18, 41, N'premium', N'False')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (19, 42, N'premium', N'true')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (20, 45, N'premium', N'true')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (21, 46, N'premium', N'false')
INSERT [dbo].[article_meta] ([id], [article_id], [_key], [_value]) VALUES (22, 47, N'premium', N'false')
SET IDENTITY_INSERT [dbo].[article_meta] OFF
SET IDENTITY_INSERT [dbo].[feedback] ON 

INSERT [dbo].[feedback] ([id], [article_id], [body], [created_by], [created_at]) VALUES (1, 21, N'Chicken', 3, CAST(N'2018-10-20' AS Date))
INSERT [dbo].[feedback] ([id], [article_id], [body], [created_by], [created_at]) VALUES (2, 1, N'This is Good', 2, CAST(N'2018-10-20' AS Date))
INSERT [dbo].[feedback] ([id], [article_id], [body], [created_by], [created_at]) VALUES (10, 1, N'sssss', 1, CAST(N'2001-01-01' AS Date))
INSERT [dbo].[feedback] ([id], [article_id], [body], [created_by], [created_at]) VALUES (12, 1, N'12321321', 4, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[feedback] ([id], [article_id], [body], [created_by], [created_at]) VALUES (13, 16, N'asdsadsad', 1, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[feedback] ([id], [article_id], [body], [created_by], [created_at]) VALUES (14, 29, N'13213123', 4, CAST(N'2018-11-02' AS Date))
SET IDENTITY_INSERT [dbo].[feedback] OFF
SET IDENTITY_INSERT [dbo].[package] ON 

INSERT [dbo].[package] ([id], [title], [body], [price], [expirydate], [is_public], [created_by], [created_at]) VALUES (1, N'VIP 1 Month', N'VIP 1 Month', 30, 30, 1, 1, CAST(N'2018-10-20' AS Date))
INSERT [dbo].[package] ([id], [title], [body], [price], [expirydate], [is_public], [created_by], [created_at]) VALUES (2, N'VIP 1 Year', N'VIP 1 Year', 300, 365, 1, 1, CAST(N'2018-10-20' AS Date))
SET IDENTITY_INSERT [dbo].[package] OFF
SET IDENTITY_INSERT [dbo].[payment] ON 

INSERT [dbo].[payment] ([id], [package_id], [title], [card_number], [card_expirydate], [csc], [created_by], [created_at]) VALUES (22, 2, N'123', 123456789, CAST(N'2018-11-14' AS Date), 123, 4, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[payment] ([id], [package_id], [title], [card_number], [card_expirydate], [csc], [created_by], [created_at]) VALUES (23, 1, N'demo3', 123456789, CAST(N'2018-11-07' AS Date), 111, 7, CAST(N'2018-11-03' AS Date))
SET IDENTITY_INSERT [dbo].[payment] OFF
SET IDENTITY_INSERT [dbo].[taxonomy] ON 

INSERT [dbo].[taxonomy] ([id], [title], [body], [excerpt], [content_type], [created_by], [created_at]) VALUES (3, N'Recipe', N'Recipe', N'Recipe', N'Recipe', 1, CAST(N'2018-10-30' AS Date))
INSERT [dbo].[taxonomy] ([id], [title], [body], [excerpt], [content_type], [created_by], [created_at]) VALUES (4, N'Tip', N'Tip', N'Tip', N'Tip', 1, CAST(N'2018-10-30' AS Date))
INSERT [dbo].[taxonomy] ([id], [title], [body], [excerpt], [content_type], [created_by], [created_at]) VALUES (5, N'Egg', N'Egg', N'Egg', N'Material', 1, CAST(N'2018-10-30' AS Date))
INSERT [dbo].[taxonomy] ([id], [title], [body], [excerpt], [content_type], [created_by], [created_at]) VALUES (6, N'Lunch', N'Lunch', N'Lunch', N'Category', 1, CAST(N'2018-10-20' AS Date))
INSERT [dbo].[taxonomy] ([id], [title], [body], [excerpt], [content_type], [created_by], [created_at]) VALUES (7, N'contest', N'contest', N'contest', N'Contest', 1, CAST(N'2018-10-20' AS Date))
INSERT [dbo].[taxonomy] ([id], [title], [body], [excerpt], [content_type], [created_by], [created_at]) VALUES (8, N'Buger', N'Buger', N'Buger', N'Category', 1, CAST(N'2018-10-20' AS Date))
INSERT [dbo].[taxonomy] ([id], [title], [body], [excerpt], [content_type], [created_by], [created_at]) VALUES (9, N'Burger', N'Burger', N'Burger', N'Material', 1, CAST(N'2018-10-20' AS Date))
INSERT [dbo].[taxonomy] ([id], [title], [body], [excerpt], [content_type], [created_by], [created_at]) VALUES (10, N'Breakfast', N'Breakfast', N'Breakfast', N'Category', 1, CAST(N'2018-10-20' AS Date))
INSERT [dbo].[taxonomy] ([id], [title], [body], [excerpt], [content_type], [created_by], [created_at]) VALUES (11, N'Smoothie', N'Smoothie', N'Smoothie', N'Category', 1, CAST(N'2018-10-20' AS Date))
INSERT [dbo].[taxonomy] ([id], [title], [body], [excerpt], [content_type], [created_by], [created_at]) VALUES (12, N'Sushi', N'Sushi', N'Sushi', N'Category', 1, CAST(N'2018-10-20' AS Date))
INSERT [dbo].[taxonomy] ([id], [title], [body], [excerpt], [content_type], [created_by], [created_at]) VALUES (13, N'Soup', N'Soup', N'Soup', N'Category', 1, CAST(N'2018-10-20' AS Date))
INSERT [dbo].[taxonomy] ([id], [title], [body], [excerpt], [content_type], [created_by], [created_at]) VALUES (14, N'Desert', N'Desert', N'Desert', N'Category', 1, CAST(N'2018-10-20' AS Date))
INSERT [dbo].[taxonomy] ([id], [title], [body], [excerpt], [content_type], [created_by], [created_at]) VALUES (15, N'This is first contest', N'This is first contest', N'This is first contest', N'Contest', 1, CAST(N'2018-10-20' AS Date))
SET IDENTITY_INSERT [dbo].[taxonomy] OFF
SET IDENTITY_INSERT [dbo].[taxonomy_m2m] ON 

INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (1, 1, 3, 1, CAST(N'2018-10-30' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (2, 1, 4, 1, CAST(N'2018-10-30' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (3, 1, 3, 1, CAST(N'2018-10-20' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (4, 9, 4, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (5, 14, 3, 2, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (6, 14, 4, 2, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (7, 15, 3, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (8, 16, 3, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (9, 17, 3, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (10, 18, 3, 3, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (11, 18, 4, 3, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (12, 19, 4, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (13, 20, 4, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (14, 21, 4, 3, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (15, 22, 3, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (16, 23, 4, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (17, 24, 3, 3, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (18, 24, 4, 3, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (19, 25, 4, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (20, 27, 3, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (21, 29, 3, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (22, 29, 4, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (23, 32, 3, 2, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (24, 32, 4, 2, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (25, 37, 5, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (26, 37, 6, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (27, 38, 5, 1, CAST(N'2018-11-01' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (28, 38, 9, 1, CAST(N'2018-11-01' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (29, 38, 6, 1, CAST(N'2018-11-01' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (30, 38, 8, 1, CAST(N'2018-11-01' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (31, 39, 9, 4, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (32, 39, 10, 4, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (33, 39, 12, 4, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (34, 39, 13, 4, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (35, 41, 5, 4, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (36, 41, 10, 4, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (37, 42, 9, 1, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (38, 42, 6, 1, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (39, 45, 9, 1, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (40, 45, 10, 1, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (41, 46, 5, 1, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (42, 46, 8, 1, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (43, 47, 9, 1, CAST(N'2018-11-02' AS Date))
INSERT [dbo].[taxonomy_m2m] ([id], [article_id], [taxonomy_id], [created_by], [created_at]) VALUES (44, 47, 10, 1, CAST(N'2018-11-02' AS Date))
SET IDENTITY_INSERT [dbo].[taxonomy_m2m] OFF
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [username], [_password], [email], [package_expirydate], [is_admin], [is_active], [created_at]) VALUES (1, N'admin', N'admin', N'admin@demo.com', CAST(N'2019-11-02' AS Date), 1, 1, CAST(N'2018-10-30' AS Date))
INSERT [dbo].[users] ([id], [username], [_password], [email], [package_expirydate], [is_admin], [is_active], [created_at]) VALUES (2, N'demo1', N'demo1', N'demo1@demo.com', CAST(N'2019-10-30' AS Date), 0, 1, CAST(N'2018-10-30' AS Date))
INSERT [dbo].[users] ([id], [username], [_password], [email], [package_expirydate], [is_admin], [is_active], [created_at]) VALUES (3, N'demo2', N'demo2', N'demo2@demo.com', CAST(N'2018-10-30' AS Date), 0, 0, CAST(N'2018-10-30' AS Date))
INSERT [dbo].[users] ([id], [username], [_password], [email], [package_expirydate], [is_admin], [is_active], [created_at]) VALUES (4, N'demo4', N'demo4', N'demo4@demo.com', CAST(N'2019-11-02' AS Date), 0, 1, CAST(N'2018-10-31' AS Date))
INSERT [dbo].[users] ([id], [username], [_password], [email], [package_expirydate], [is_admin], [is_active], [created_at]) VALUES (7, N'demo3', N'demo3', N'demo3@demo.com', CAST(N'2018-12-03' AS Date), 0, 1, CAST(N'2018-11-03' AS Date))
SET IDENTITY_INSERT [dbo].[users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__users__F3DBC572BE0098E7]    Script Date: 03-Nov-18 3:16:23 AM ******/
ALTER TABLE [dbo].[users] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[article]  WITH CHECK ADD FOREIGN KEY([created_by])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[article_meta]  WITH CHECK ADD FOREIGN KEY([article_id])
REFERENCES [dbo].[article] ([id])
GO
ALTER TABLE [dbo].[feedback]  WITH CHECK ADD FOREIGN KEY([article_id])
REFERENCES [dbo].[article] ([id])
GO
ALTER TABLE [dbo].[feedback]  WITH CHECK ADD FOREIGN KEY([created_by])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[package]  WITH CHECK ADD FOREIGN KEY([created_by])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[payment]  WITH CHECK ADD FOREIGN KEY([created_by])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[payment]  WITH CHECK ADD FOREIGN KEY([package_id])
REFERENCES [dbo].[package] ([id])
GO
ALTER TABLE [dbo].[taxonomy]  WITH CHECK ADD FOREIGN KEY([created_by])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[taxonomy_m2m]  WITH CHECK ADD FOREIGN KEY([article_id])
REFERENCES [dbo].[article] ([id])
GO
ALTER TABLE [dbo].[taxonomy_m2m]  WITH CHECK ADD FOREIGN KEY([created_by])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[taxonomy_m2m]  WITH CHECK ADD FOREIGN KEY([taxonomy_id])
REFERENCES [dbo].[taxonomy] ([id])
GO
ALTER TABLE [dbo].[taxonomy_meta]  WITH CHECK ADD FOREIGN KEY([taxonomy_id])
REFERENCES [dbo].[taxonomy] ([id])
GO
USE [master]
GO
ALTER DATABASE [Jamesthew] SET  READ_WRITE 
GO
