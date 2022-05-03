--create database BVXK

USE [BVXK]
GO

/****** Object:  Table [dbo].[Account]    Script Date: 28/04/2022 6:55:15 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Account](
	[uid] [int] IDENTITY(1,1) NOT NULL,
	[role] [int] NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[displayName] [nvarchar](50) NULL,
	[address] [text] NULL,
	[phoneNumber] [nchar](10) NULL,
	[avatar] [image] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [BVXK]
GO

/****** Object:  Table [dbo].[Xe]    Script Date: 29/04/2022 2:22:13 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Xe](
	[idXe] [int] IDENTITY(1,1) NOT NULL,
	[tenTaiXe] [nvarchar](50) NULL,
	[loaiXe] [int] NULL,
	[soDienThoai] [nchar](10) NULL,
	[soLuongGhe] [int] NULL,
	[bienSo] [nchar](10) NULL,
 CONSTRAINT [PK_Xe] PRIMARY KEY CLUSTERED 
(
	[idXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [BVXK]
GO

/****** Object:  Table [dbo].[ThongKe]    Script Date: 28/04/2022 6:55:28 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ThongKe](
	[idThongKe] [int] IDENTITY(1,1) NOT NULL,
	[idVe] [int] NULL,
	[ngayDat] [smalldatetime] NULL,
	[loaiVe] [int] NULL,
	[soLuong] [int] NULL,
	[idDonHang] [int] NULL,
	[giaVe] [money] NULL,
 CONSTRAINT [PK_ThongKe] PRIMARY KEY CLUSTERED 
(
	[idThongKe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [BVXK]
GO

/****** Object:  Table [dbo].[LichTrinh]    Script Date: 28/04/2022 6:55:39 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LichTrinh](
	[idLichTrinh] [int] IDENTITY(1,1) NOT NULL,
	[idXe] [int] NOT NULL,
	[noiXuatPhat] [nvarchar](50) NULL,
	[noiDen] [nvarchar](50) NULL,
	[ngayDi] [smalldatetime] NULL,
	[ngayDen] [smalldatetime] NULL,
	[hinh1] [image] NULL,
	[hinh2] [image] NULL,
 CONSTRAINT [PK_TTLichTrinh] PRIMARY KEY CLUSTERED 
(
	[idLichTrinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[LichTrinh]  WITH CHECK ADD  CONSTRAINT [FK_LichTrinh_Xe] FOREIGN KEY([idXe])
REFERENCES [dbo].[Xe] ([idXe])
GO

ALTER TABLE [dbo].[LichTrinh] CHECK CONSTRAINT [FK_LichTrinh_Xe]
GO

USE [BVXK]
GO

/****** Object:  Table [dbo].[VeXe]    Script Date: 28/04/2022 6:55:48 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VeXe](
	[idVe] [int] IDENTITY(1,1) NOT NULL,
	[idLichTrinh] [int] NOT NULL,
	[GiaVe] [money] NULL,
	[tinhTrang] [int] NULL,
	[loaiVe] [int] NULL,
 CONSTRAINT [PK_VeXe] PRIMARY KEY CLUSTERED 
(
	[idVe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[VeXe]  WITH CHECK ADD  CONSTRAINT [FK_VeXe_LichTrinh] FOREIGN KEY([idLichTrinh])
REFERENCES [dbo].[LichTrinh] ([idLichTrinh])
GO

ALTER TABLE [dbo].[VeXe] CHECK CONSTRAINT [FK_VeXe_LichTrinh]
GO

USE [BVXK]
GO

/****** Object:  Table [dbo].[DonHang]    Script Date: 29/04/2022 2:22:41 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DonHang](
	[idDonHang] [int] IDENTITY(1,1) NOT NULL,
	[idVeXe] [int] NOT NULL,
	[tenKhachHang] [nvarchar](50) NULL,
	[soDienThoai] [nchar](10) NULL,
	[thoiGianDon] [smalldatetime] NULL,
	[tinhTrang] [int] NULL,
	[diemDon] [nvarchar](50) NULL,
	[diemTra] [nvarchar](50) NULL,
	[email] [text] NULL,
	[cmnd] [text] NULL,
	[soLuong] [int] NULL,
	[ghiChu] [text] NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[idDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_VeXe] FOREIGN KEY([idVeXe])
REFERENCES [dbo].[VeXe] ([idVe])
GO

ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_VeXe]
GO

USE [BVXK]
GO

/****** Object:  Table [dbo].[CT_DonHang]    Script Date: 29/04/2022 2:22:50 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CT_DonHang](
	[idCTDonHang] [int] IDENTITY(1,1) NOT NULL,
	[idDonHang] [int] NOT NULL,
	[soGhe] [int] NOT NULL,
 CONSTRAINT [PK_CT_DonHang] PRIMARY KEY CLUSTERED 
(
	[idCTDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CT_DonHang]  WITH CHECK ADD  CONSTRAINT [FK_CT_DonHang_DonHang] FOREIGN KEY([idDonHang])
REFERENCES [dbo].[DonHang] ([idDonHang])
GO

ALTER TABLE [dbo].[CT_DonHang] CHECK CONSTRAINT [FK_CT_DonHang_DonHang]
GO

