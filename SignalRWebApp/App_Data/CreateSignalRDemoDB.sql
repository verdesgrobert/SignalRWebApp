USE [SignalRDemo]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 30/01/2018 16:20:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 30/01/2018 16:20:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[UnitPrice] [decimal](18, 0) NULL,
	[Quantity] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

GO
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName]) VALUES (1, N'Robert', N'Verdes')
GO
INSERT [dbo].[Customers] ([CustomerID], [FirstName], [LastName]) VALUES (2, N'TestName', N'LastName')
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

GO
INSERT [dbo].[Products] ([ProductID], [Name], [UnitPrice], [Quantity]) VALUES (1, N'Product1', CAST(10 AS Decimal(18, 0)), CAST(1 AS Decimal(18, 0)))
GO
INSERT [dbo].[Products] ([ProductID], [Name], [UnitPrice], [Quantity]) VALUES (2, N'Product2', CAST(1 AS Decimal(18, 0)), CAST(5 AS Decimal(18, 0)))
GO
INSERT [dbo].[Products] ([ProductID], [Name], [UnitPrice], [Quantity]) VALUES (3, N'Product3', CAST(1 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)))
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
