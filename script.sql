USE [master]
GO
/****** Object:  Database [DB_Bryan_Kevin]    Script Date: 03-01-23 22:03:08 ******/
CREATE DATABASE [DB_Bryan_Kevin]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Bryan_Kevin', FILENAME = N'C:\Users\kevin\DB_Bryan_Kevin.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_Bryan_Kevin_log', FILENAME = N'C:\Users\kevin\DB_Bryan_Kevin_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_Bryan_Kevin] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Bryan_Kevin].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Bryan_Kevin] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Bryan_Kevin] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_Bryan_Kevin] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DB_Bryan_Kevin] SET QUERY_STORE = OFF
GO
USE [DB_Bryan_Kevin]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 03-01-23 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrator](
	[idAdministrator] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Administ__97EB80969793094C] PRIMARY KEY CLUSTERED 
(
	[idAdministrator] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 03-01-23 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[idPlayer] [int] NOT NULL,
	[idVideoGame] [int] NOT NULL,
	[bookingDate] [date] NOT NULL,
 CONSTRAINT [PK__Booking__6BFD521C99AD82DC] PRIMARY KEY CLUSTERED 
(
	[idPlayer] ASC,
	[idVideoGame] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Copy]    Script Date: 03-01-23 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Copy](
	[idCopy] [int] IDENTITY(1,1) NOT NULL,
	[idVideoGame] [int] NOT NULL,
	[idPlayer] [int] NOT NULL,
 CONSTRAINT [PK__Copy__80B32CEFC45047F6] PRIMARY KEY CLUSTERED 
(
	[idCopy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loan]    Script Date: 03-01-23 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loan](
	[idLoan] [int] IDENTITY(1,1) NOT NULL,
	[startDate] [date] NULL,
	[endDate] [date] NULL,
	[ongoing] [bit] NOT NULL,
	[idCopy] [int] NULL,
	[idBorrower] [int] NOT NULL,
	[idLender] [int] NULL,
 CONSTRAINT [PK__Loan__1B9464CDF1DBF372] PRIMARY KEY CLUSTERED 
(
	[idLoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 03-01-23 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[idPlayer] [int] IDENTITY(1,1) NOT NULL,
	[pseudo] [varchar](20) NOT NULL,
	[username] [varchar](20) NOT NULL,
	[password] [varchar](20) NOT NULL,
	[registrationDate] [date] NOT NULL,
	[dateOfBirth] [date] NOT NULL,
	[credit] [int] NOT NULL,
 CONSTRAINT [PK__Player__3EFB5EA61AF60CBF] PRIMARY KEY CLUSTERED 
(
	[idPlayer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VideoGame]    Script Date: 03-01-23 22:03:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoGame](
	[idVideoGame] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[creditCost] [int] NOT NULL,
	[console] [varchar](20) NOT NULL,
 CONSTRAINT [PK__VideoGam__5060CBA4B9E30F81] PRIMARY KEY CLUSTERED 
(
	[idVideoGame] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Administrator] ON 

INSERT [dbo].[Administrator] ([idAdministrator], [username], [password]) VALUES (1, N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[Administrator] OFF
GO
INSERT [dbo].[Booking] ([idPlayer], [idVideoGame], [bookingDate]) VALUES (1, 14011, CAST(N'2023-01-03' AS Date))
INSERT [dbo].[Booking] ([idPlayer], [idVideoGame], [bookingDate]) VALUES (1, 14018, CAST(N'2023-01-03' AS Date))
INSERT [dbo].[Booking] ([idPlayer], [idVideoGame], [bookingDate]) VALUES (1, 16015, CAST(N'2023-01-02' AS Date))
INSERT [dbo].[Booking] ([idPlayer], [idVideoGame], [bookingDate]) VALUES (1, 16019, CAST(N'2023-01-03' AS Date))
INSERT [dbo].[Booking] ([idPlayer], [idVideoGame], [bookingDate]) VALUES (2, 14011, CAST(N'2023-01-03' AS Date))
INSERT [dbo].[Booking] ([idPlayer], [idVideoGame], [bookingDate]) VALUES (2, 14024, CAST(N'2023-01-03' AS Date))
INSERT [dbo].[Booking] ([idPlayer], [idVideoGame], [bookingDate]) VALUES (2, 16010, CAST(N'2023-01-03' AS Date))
INSERT [dbo].[Booking] ([idPlayer], [idVideoGame], [bookingDate]) VALUES (3012, 14013, CAST(N'2023-01-01' AS Date))
INSERT [dbo].[Booking] ([idPlayer], [idVideoGame], [bookingDate]) VALUES (10007, 14010, CAST(N'2023-01-02' AS Date))
INSERT [dbo].[Booking] ([idPlayer], [idVideoGame], [bookingDate]) VALUES (11007, 14015, CAST(N'2023-01-03' AS Date))
INSERT [dbo].[Booking] ([idPlayer], [idVideoGame], [bookingDate]) VALUES (11007, 14020, CAST(N'2023-01-03' AS Date))
INSERT [dbo].[Booking] ([idPlayer], [idVideoGame], [bookingDate]) VALUES (11007, 16015, CAST(N'2023-01-03' AS Date))
INSERT [dbo].[Booking] ([idPlayer], [idVideoGame], [bookingDate]) VALUES (11008, 14018, CAST(N'2023-01-03' AS Date))
INSERT [dbo].[Booking] ([idPlayer], [idVideoGame], [bookingDate]) VALUES (11008, 16010, CAST(N'2023-01-03' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Copy] ON 

INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13003, 14007, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13004, 14008, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13005, 14009, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13006, 14010, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13007, 14011, 10007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13008, 14009, 10007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13009, 14012, 10007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13010, 14013, 10007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13011, 14011, 3012)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13012, 14014, 3012)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13013, 14015, 3012)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13014, 14011, 3012)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13015, 14011, 3012)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13016, 14016, 3012)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13017, 14017, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13018, 14018, 3)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13019, 14019, 3)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13020, 14020, 3)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13021, 14021, 3)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13022, 14022, 2)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13023, 14023, 2)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13024, 14024, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13025, 14025, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13026, 14026, 2)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13027, 14027, 2)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13028, 14012, 10007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (13029, 14021, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (14002, 15006, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (15002, 14008, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (16002, 14019, 3)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17002, 14011, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17003, 14014, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17004, 14014, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17005, 14014, 10007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17006, 16006, 11007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17007, 16007, 11007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17008, 14015, 11007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17009, 16008, 11007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17010, 16009, 11007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17011, 16010, 11007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17012, 14023, 10007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17013, 16011, 10007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17014, 14012, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17015, 16008, 2)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17016, 16012, 2)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17017, 16013, 2)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17018, 16014, 3)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17019, 16015, 3)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17020, 16016, 3)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17021, 14015, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17022, 16016, 1)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17023, 16017, 6007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17024, 16018, 6007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17025, 16019, 6007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17026, 16020, 6007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17027, 16019, 2)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17028, 16018, 2)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17029, 16012, 11008)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17030, 16021, 11008)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17031, 14016, 11007)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17032, 16007, 2)
INSERT [dbo].[Copy] ([idCopy], [idVideoGame], [idPlayer]) VALUES (17033, 16020, 11007)
SET IDENTITY_INSERT [dbo].[Copy] OFF
GO
SET IDENTITY_INSERT [dbo].[Loan] ON 

INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21015, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-06' AS Date), 1, 13004, 11008, 1)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21016, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-18' AS Date), 1, 13010, 1, 10007)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21017, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-08' AS Date), 0, 17011, 1, 11007)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21018, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-11' AS Date), 1, 13006, 2, 1)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21019, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-16' AS Date), 1, 13013, 2, 3012)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21020, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-07' AS Date), 1, 17010, 2, 11007)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21021, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-20' AS Date), 0, 13011, 10007, 3012)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21022, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-10' AS Date), 1, 17019, 10007, 3)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21023, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-11' AS Date), 1, 13018, 3012, 3)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21024, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-12' AS Date), 1, 13024, 3012, 1)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21025, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-15' AS Date), 1, 17025, 2, 6007)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21026, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-14' AS Date), 1, 13022, 10007, 2)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21027, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-12' AS Date), 1, 13020, 1, 3)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21028, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-26' AS Date), 1, 13012, 11007, 3012)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21029, NULL, NULL, 0, 13011, 1, 3012)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21030, NULL, NULL, 0, 17011, 11008, 11007)
INSERT [dbo].[Loan] ([idLoan], [startDate], [endDate], [ongoing], [idCopy], [idBorrower], [idLender]) VALUES (21031, CAST(N'2023-01-03' AS Date), CAST(N'2023-01-18' AS Date), 1, 13008, 11008, 10007)
SET IDENTITY_INSERT [dbo].[Loan] OFF
GO
SET IDENTITY_INSERT [dbo].[Player] ON 

INSERT [dbo].[Player] ([idPlayer], [pseudo], [username], [password], [registrationDate], [dateOfBirth], [credit]) VALUES (1, N'kev', N'kevin', N'kev', CAST(N'2022-10-20' AS Date), CAST(N'1999-04-25' AS Date), 20)
INSERT [dbo].[Player] ([idPlayer], [pseudo], [username], [password], [registrationDate], [dateOfBirth], [credit]) VALUES (2, N'bry', N'bryan', N'bry', CAST(N'2022-12-22' AS Date), CAST(N'1998-06-25' AS Date), 9)
INSERT [dbo].[Player] ([idPlayer], [pseudo], [username], [password], [registrationDate], [dateOfBirth], [credit]) VALUES (3, N'bob', N'bob', N'bob', CAST(N'2022-10-10' AS Date), CAST(N'2022-12-08' AS Date), 24)
INSERT [dbo].[Player] ([idPlayer], [pseudo], [username], [password], [registrationDate], [dateOfBirth], [credit]) VALUES (3012, N'maxime', N'maxime', N'max', CAST(N'2022-12-09' AS Date), CAST(N'2022-12-16' AS Date), 22)
INSERT [dbo].[Player] ([idPlayer], [pseudo], [username], [password], [registrationDate], [dateOfBirth], [credit]) VALUES (6007, N'luc', N'luc', N'123', CAST(N'2022-12-12' AS Date), CAST(N'2022-12-12' AS Date), 16)
INSERT [dbo].[Player] ([idPlayer], [pseudo], [username], [password], [registrationDate], [dateOfBirth], [credit]) VALUES (10007, N'diego', N'Diego', N'diego', CAST(N'2022-12-20' AS Date), CAST(N'1999-12-20' AS Date), 17)
INSERT [dbo].[Player] ([idPlayer], [pseudo], [username], [password], [registrationDate], [dateOfBirth], [credit]) VALUES (11007, N'chris', N'Christophe', N'chris', CAST(N'2022-12-29' AS Date), CAST(N'2006-12-28' AS Date), 9)
INSERT [dbo].[Player] ([idPlayer], [pseudo], [username], [password], [registrationDate], [dateOfBirth], [credit]) VALUES (11008, N'lea', N'Lea', N'lea', CAST(N'2023-01-03' AS Date), CAST(N'2005-01-10' AS Date), -5)
SET IDENTITY_INSERT [dbo].[Player] OFF
GO
SET IDENTITY_INSERT [dbo].[VideoGame] ON 

INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14007, N'GTA V', 3, N'Ps4')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14008, N'Mario Galaxy', 1, N'Wii')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14009, N'Cyberpunk', 5, N'PS5')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14010, N'Halo', 2, N'XBOX')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14011, N'Red dead Redemption', 2, N'Ps4')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14012, N'Grounded', 5, N'Xbox Serie X')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14013, N'Call of Duty', 4, N'PS5')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14014, N'Lego star wars', 1, N'Ps3')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14015, N'Fifa 23', 5, N'Ps5')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14016, N'Dead by Daylight', 4, N'Xbox One')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14017, N'Fifa 22', 4, N'Ps4')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14018, N'The division', 2, N'Ps4')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14019, N'Mario Bros', 1, N'Wii u')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14020, N'Mario kart', 3, N'Nintendo switch')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14021, N'Splatoon', 2, N'Nintendo Ds')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14022, N'Cyperpunk', 4, N'Ps5')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14023, N'The division 2', 3, N'Xbox One')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14024, N'Assasin''s creed Unity', 2, N'Ps4')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14025, N'Assasin''s creed Origin', 3, N'Xbox')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14026, N'Assassin''s creed Black Flag', 1, N'Ps3')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (14027, N'Assassin''s creed Odyssey', 2, N'Ps4')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (15006, N'Call of duty MwII', 4, N'Ps4')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16006, N'The division 2', 3, N'Ps4')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16007, N'Zombie U', 2, N'Wii U')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16008, N'Nintendogs', 1, N'Nintendo Ds')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16009, N'Minecraft', 1, N'Xbox 360')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16010, N'Farcry 3', 2, N'Ps3')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16011, N'Elden Rings', 5, N'Ps5')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16012, N'Sea of Thieves', 4, N'Xbox Serie X')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16013, N'Jedi fallen Order', 4, N'Ps4')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16014, N'Forza Horizon 5', 5, N'Xbox Serie X')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16015, N'Need For Speed', 4, N'Ps4')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16016, N'Uncharted', 2, N'Ps vita')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16017, N'Ghost Recon Widlands', 3, N'Xbox One')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16018, N'Fallout 4', 3, N'Ps4')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16019, N'Watch Dogs 2', 3, N'Ps4')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16020, N'GTA V', 2, N'Xbox 360')
INSERT [dbo].[VideoGame] ([idVideoGame], [name], [creditCost], [console]) VALUES (16021, N'Valorant', 5, N'Xbox Serie X')
SET IDENTITY_INSERT [dbo].[VideoGame] OFF
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK__Booking__idPlaye__2E1BDC42] FOREIGN KEY([idPlayer])
REFERENCES [dbo].[Player] ([idPlayer])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK__Booking__idPlaye__2E1BDC42]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK__Booking__idVideo__2F10007B] FOREIGN KEY([idVideoGame])
REFERENCES [dbo].[VideoGame] ([idVideoGame])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK__Booking__idVideo__2F10007B]
GO
ALTER TABLE [dbo].[Copy]  WITH CHECK ADD  CONSTRAINT [FK__Copy__idPlayer__300424B4] FOREIGN KEY([idPlayer])
REFERENCES [dbo].[Player] ([idPlayer])
GO
ALTER TABLE [dbo].[Copy] CHECK CONSTRAINT [FK__Copy__idPlayer__300424B4]
GO
ALTER TABLE [dbo].[Copy]  WITH CHECK ADD  CONSTRAINT [FK__Copy__idVideoGam__30F848ED] FOREIGN KEY([idVideoGame])
REFERENCES [dbo].[VideoGame] ([idVideoGame])
GO
ALTER TABLE [dbo].[Copy] CHECK CONSTRAINT [FK__Copy__idVideoGam__30F848ED]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK__Loan__idBorrower__31EC6D26] FOREIGN KEY([idBorrower])
REFERENCES [dbo].[Player] ([idPlayer])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK__Loan__idBorrower__31EC6D26]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK__Loan__idCopy__32E0915F] FOREIGN KEY([idCopy])
REFERENCES [dbo].[Copy] ([idCopy])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK__Loan__idCopy__32E0915F]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK__Loan__idLender__33D4B598] FOREIGN KEY([idLender])
REFERENCES [dbo].[Player] ([idPlayer])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK__Loan__idLender__33D4B598]
GO
USE [master]
GO
ALTER DATABASE [DB_Bryan_Kevin] SET  READ_WRITE 
GO
