USE [WaterSalesDB]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 9.10.2019 17:32:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 9.10.2019 17:32:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[customerID] [int] IDENTITY(1,1) NOT NULL,
	[customerName] [nvarchar](50) NULL,
	[customerSurname] [nvarchar](50) NULL,
	[customerPhone] [nvarchar](50) NULL,
	[customerAddress] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[customerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 9.10.2019 17:32:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[SalesID] [int] IDENTITY(1,1) NOT NULL,
	[SalesStatus] [nvarchar](50) NULL,
	[SalesAmount] [float] NULL,
	[CustomerID] [int] NULL,
	[Date] [datetime] NULL,
	[AdminID] [int] NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[SalesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([AdminID], [Username], [Password]) VALUES (1, N'rengin', N'123')
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([customerID], [customerName], [customerSurname], [customerPhone], [customerAddress]) VALUES (1, N'Rengin', N'Atilla', N'(555) 555-5555', N'bağlar caddesi tepebaşı/eskişehir')
INSERT [dbo].[Customer] ([customerID], [customerName], [customerSurname], [customerPhone], [customerAddress]) VALUES (2, N'Gökçe', N'Tenekci', N'(444) 444-4444', N'adapazarı sakarye')
INSERT [dbo].[Customer] ([customerID], [customerName], [customerSurname], [customerPhone], [customerAddress]) VALUES (3, N'Fadime', N'Açıkgöz', N'(852) 225-8555', N'yozgat')
INSERT [dbo].[Customer] ([customerID], [customerName], [customerSurname], [customerPhone], [customerAddress]) VALUES (4, N'zeynep', N'pektaş', N'(877) 887-7878', N'malatyaa')
INSERT [dbo].[Customer] ([customerID], [customerName], [customerSurname], [customerPhone], [customerAddress]) VALUES (8, N'dfdsf', N'dsfsd', N'(999) 999-9999', N'fWFFDGFFDSGFerg')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Sales] ON 

INSERT [dbo].[Sales] ([SalesID], [SalesStatus], [SalesAmount], [CustomerID], [Date], [AdminID]) VALUES (1003, N'beklemede', 50, 2, CAST(N'2019-10-09T17:26:17.013' AS DateTime), 1)
INSERT [dbo].[Sales] ([SalesID], [SalesStatus], [SalesAmount], [CustomerID], [Date], [AdminID]) VALUES (1004, N'yolda', 100, 3, CAST(N'2019-10-09T17:26:33.710' AS DateTime), 1)
INSERT [dbo].[Sales] ([SalesID], [SalesStatus], [SalesAmount], [CustomerID], [Date], [AdminID]) VALUES (1005, N'teslim', 50, 1, CAST(N'2019-10-09T17:26:44.103' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Sales] OFF
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Admin] FOREIGN KEY([AdminID])
REFERENCES [dbo].[Admin] ([AdminID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Admin]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([customerID])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Customer]
GO
