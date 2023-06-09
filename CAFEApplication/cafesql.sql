USE [master]
GO
/****** Object:  Database [CAFEApplication]    Script Date: 4.04.2023 12:44:07 ******/
CREATE DATABASE [CAFEApplication]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CAFEApplication', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CAFEApplication.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CAFEApplication_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CAFEApplication_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CAFEApplication] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CAFEApplication].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CAFEApplication] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CAFEApplication] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CAFEApplication] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CAFEApplication] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CAFEApplication] SET ARITHABORT OFF 
GO
ALTER DATABASE [CAFEApplication] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CAFEApplication] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CAFEApplication] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CAFEApplication] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CAFEApplication] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CAFEApplication] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CAFEApplication] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CAFEApplication] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CAFEApplication] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CAFEApplication] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CAFEApplication] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CAFEApplication] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CAFEApplication] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CAFEApplication] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CAFEApplication] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CAFEApplication] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CAFEApplication] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CAFEApplication] SET RECOVERY FULL 
GO
ALTER DATABASE [CAFEApplication] SET  MULTI_USER 
GO
ALTER DATABASE [CAFEApplication] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CAFEApplication] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CAFEApplication] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CAFEApplication] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CAFEApplication] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CAFEApplication] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CAFEApplication', N'ON'
GO
ALTER DATABASE [CAFEApplication] SET QUERY_STORE = ON
GO
ALTER DATABASE [CAFEApplication] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CAFEApplication]
GO
/****** Object:  Table [dbo].[Icecekler]    Script Date: 4.04.2023 12:44:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Icecekler](
	[IcecekNo] [int] IDENTITY(1,1) NOT NULL,
	[IcecekAdi] [varchar](50) NULL,
	[Fiyat] [varchar](50) NULL,
	[Adet] [varchar](50) NULL,
	[SNo] [int] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[IcecekNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 4.04.2023 12:44:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[KullaniciNo] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [varchar](50) NULL,
	[Sifre] [varchar](50) NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[KullaniciNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 4.04.2023 12:44:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[MusteriNo] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [varchar](50) NULL,
	[Telefon] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Yas] [int] NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[MusteriNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Saticilar]    Script Date: 4.04.2023 12:44:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Saticilar](
	[SNo] [int] IDENTITY(1,1) NOT NULL,
	[SAdi] [varchar](50) NULL,
	[SAdres] [varchar](50) NULL,
	[Il] [varchar](50) NULL,
	[Urun] [varchar](50) NULL,
	[CalisanSayisi] [int] NULL,
 CONSTRAINT [PK_Saticilar] PRIMARY KEY CLUSTERED 
(
	[SNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Siparisler]    Script Date: 4.04.2023 12:44:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siparisler](
	[SiparisNo] [int] IDENTITY(1,1) NOT NULL,
	[SiparisAdi] [varchar](50) NULL,
	[SiparisAdres] [varchar](50) NULL,
	[SiparisTarihi] [varchar](50) NULL,
	[MusteriNo] [int] NULL,
 CONSTRAINT [PK_Siparisler] PRIMARY KEY CLUSTERED 
(
	[SiparisNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tatlılar]    Script Date: 4.04.2023 12:44:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tatlılar](
	[TatlıNo] [int] IDENTITY(1,1) NOT NULL,
	[TatlıAdi] [varchar](50) NULL,
	[Fiyat] [int] NULL,
	[Adet] [int] NULL,
	[SNo] [int] NULL,
 CONSTRAINT [PK_Tatlilar] PRIMARY KEY CLUSTERED 
(
	[TatlıNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Icecekler] ON 

INSERT [dbo].[Icecekler] ([IcecekNo], [IcecekAdi], [Fiyat], [Adet], [SNo]) VALUES (1, N'Cappucino', N'45', N'2', 1)
INSERT [dbo].[Icecekler] ([IcecekNo], [IcecekAdi], [Fiyat], [Adet], [SNo]) VALUES (2, N'Mocha', N'40', N'5', 1)
INSERT [dbo].[Icecekler] ([IcecekNo], [IcecekAdi], [Fiyat], [Adet], [SNo]) VALUES (3, N'Americano', N'35', N'3', 1)
SET IDENTITY_INSERT [dbo].[Icecekler] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanicilar] ON 

INSERT [dbo].[Kullanicilar] ([KullaniciNo], [KullaniciAdi], [Sifre]) VALUES (1, N'Hilal', N'123')
INSERT [dbo].[Kullanicilar] ([KullaniciNo], [KullaniciAdi], [Sifre]) VALUES (2, N'Ayşe', N'741')
INSERT [dbo].[Kullanicilar] ([KullaniciNo], [KullaniciAdi], [Sifre]) VALUES (3, N'Selin', N'456')
INSERT [dbo].[Kullanicilar] ([KullaniciNo], [KullaniciAdi], [Sifre]) VALUES (4, N'Tülay', N'123')
SET IDENTITY_INSERT [dbo].[Kullanicilar] OFF
GO
SET IDENTITY_INSERT [dbo].[Musteri] ON 

INSERT [dbo].[Musteri] ([MusteriNo], [AdSoyad], [Telefon], [Email], [Yas]) VALUES (1, N'Başak', N'741258', N'Basak.', 25)
INSERT [dbo].[Musteri] ([MusteriNo], [AdSoyad], [Telefon], [Email], [Yas]) VALUES (2, N'System.Windows.Forms.TextBox, Text: Ahmet', N'789456', N'Ahmet.', 35)
SET IDENTITY_INSERT [dbo].[Musteri] OFF
GO
SET IDENTITY_INSERT [dbo].[Saticilar] ON 

INSERT [dbo].[Saticilar] ([SNo], [SAdi], [SAdres], [Il], [Urun], [CalisanSayisi]) VALUES (1, N'Trendyol', N'Levent', N'İstanbul', N'Cheesecake', 150)
INSERT [dbo].[Saticilar] ([SNo], [SAdi], [SAdres], [Il], [Urun], [CalisanSayisi]) VALUES (2, N'Hepsiburada', N'Şişli', N'İstanbul', N'Fudge Brownies', 50)
SET IDENTITY_INSERT [dbo].[Saticilar] OFF
GO
SET IDENTITY_INSERT [dbo].[Siparisler] ON 

INSERT [dbo].[Siparisler] ([SiparisNo], [SiparisAdi], [SiparisAdres], [SiparisTarihi], [MusteriNo]) VALUES (1, N'Ev', N'Halkalı', N'20 Mayıs', 1)
INSERT [dbo].[Siparisler] ([SiparisNo], [SiparisAdi], [SiparisAdres], [SiparisTarihi], [MusteriNo]) VALUES (3, N'İş ', N'Levent', N'2 Ocak', 2)
INSERT [dbo].[Siparisler] ([SiparisNo], [SiparisAdi], [SiparisAdres], [SiparisTarihi], [MusteriNo]) VALUES (4, N'Ev', N'Levent', N'2 Mart', 1)
SET IDENTITY_INSERT [dbo].[Siparisler] OFF
GO
SET IDENTITY_INSERT [dbo].[Tatlılar] ON 

INSERT [dbo].[Tatlılar] ([TatlıNo], [TatlıAdi], [Fiyat], [Adet], [SNo]) VALUES (1, N'Cheesecake', 45, 5, 1)
INSERT [dbo].[Tatlılar] ([TatlıNo], [TatlıAdi], [Fiyat], [Adet], [SNo]) VALUES (2, N'Fudge Brownies', 30, 10, 1)
INSERT [dbo].[Tatlılar] ([TatlıNo], [TatlıAdi], [Fiyat], [Adet], [SNo]) VALUES (3, N'Apple Pie', 45, 16, 1)
SET IDENTITY_INSERT [dbo].[Tatlılar] OFF
GO
ALTER TABLE [dbo].[Icecekler]  WITH CHECK ADD  CONSTRAINT [FK_Icecekler_Saticilar] FOREIGN KEY([SNo])
REFERENCES [dbo].[Saticilar] ([SNo])
GO
ALTER TABLE [dbo].[Icecekler] CHECK CONSTRAINT [FK_Icecekler_Saticilar]
GO
ALTER TABLE [dbo].[Siparisler]  WITH CHECK ADD  CONSTRAINT [FK_Siparisler_Musteri] FOREIGN KEY([MusteriNo])
REFERENCES [dbo].[Musteri] ([MusteriNo])
GO
ALTER TABLE [dbo].[Siparisler] CHECK CONSTRAINT [FK_Siparisler_Musteri]
GO
ALTER TABLE [dbo].[Tatlılar]  WITH CHECK ADD  CONSTRAINT [FK_Tatlılar_Saticilar] FOREIGN KEY([SNo])
REFERENCES [dbo].[Saticilar] ([SNo])
GO
ALTER TABLE [dbo].[Tatlılar] CHECK CONSTRAINT [FK_Tatlılar_Saticilar]
GO
/****** Object:  StoredProcedure [dbo].[KullaniciGiris]    Script Date: 4.04.2023 12:44:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[KullaniciGiris]
@KullaniciAdi varchar(50),
@Sifre varchar(50)
as begin
select * from Kullanicilar where KullaniciAdi =@KullaniciAdi and Sifre=@Sifre
end
GO
USE [master]
GO
ALTER DATABASE [CAFEApplication] SET  READ_WRITE 
GO
