USE [ProjectPRN221]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [nvarchar](450) NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LaundryStores]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LaundryStores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [nvarchar](450) NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[Capacity] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_LaundryStores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Quantity] [smallint] NOT NULL,
	[StoreServiceId] [int] NOT NULL,
	[TotalPrice] [float] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderTime] [datetime2](7) NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[OrderStatus] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[ImgUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shippings]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shippings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[StaffId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_Shippings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationUserId] [nvarchar](450) NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Age] [int] NOT NULL,
	[Address] [nvarchar](100) NULL,
	[JobPosition] [int] NOT NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoreServices]    Script Date: 11/15/2023 12:17:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NOT NULL,
	[LaundryStoreId] [int] NOT NULL,
	[Weight] [float] NULL,
	[UnitPrice] [float] NULL,
 CONSTRAINT [PK_StoreServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230927173648_UpdateUser', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231013071922_AddEntities', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231013073012_AddEntities2', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231013143800_UpdateStaff', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231013153649_UpdateShipping', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231013184142_FixApplicationUser', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231020060709_UpdateIdentity', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231023153520_UpdateService', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231023154742_UpdateService2', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231023155419_UpdateService3', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231024144556_UpdateDatabase4', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231024181930_UpdateOrderDetail', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231024185904_UpdateOrder', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231025035456_updateOrder3', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231026083108_UpdateOrder5', N'5.0.17')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'Staff', N'STAFF', N'A comfort zone is a beautiful place, but nothing ever grows there. It provides strong               ')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2', N'Customer', N'CUSTOMER', N'A comfort zone is a beautiful place, but nothing ever grows there. To start working                 ')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3', N'LaundryStore', N'LAUNDRYSTORE', N'If the Show objects under schema in navigation pane option is checked at the Preferences            ')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4', N'Admin', N'ADMIN', N'Genius is an infinite capacity for taking pains. Import Wizard allows you to import                 ')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2399f3c2-3367-4e37-ba9e-b4f821bb3211', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8db1fc06-e9d7-4270-8e28-d48e36317e02', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'22795565-8a2c-4af4-be0e-333be2f40e0f', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'49e1b3dd-c27d-4062-a93b-38f27276a509', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'56016d37-2712-4186-95a1-ab0a29a0dd76', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ac51ac6c-9dd5-4416-bdb3-54bf188e3b33', N'3')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'be2aa6c2-8894-489d-bdd8-f98c46a8da21', N'3')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9d8c9385-5a15-4fc6-9292-3fc3ba636184', N'4')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator]) VALUES (N'1', N'Zhou Yunxi', N'Zhou Yunxi', N'yunxizhou@icloud.com', N'zhyunxi@yahoo.com', 0, N'vnAzKvid7o', N'Success consists of going from failure to failure without loss of enthusiasm.                       ', N'Navicat Data Modeler enables you to build high-quality conceptual, logical and physical             ', N'312-308-5715', 1, 0, NULL, 0, 0, N'Zhou Yunxi', N'Navicat Data Modeler is a powerful and cost-effective database design tool which                    ')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator]) VALUES (N'2', N'Steve Murray', N'Steve Murray', N'stemurray@gmail.com', N'steve55@icloud.com', 1, N'fzexicbqhL', N'To successfully establish a new connection to local/remote server - no matter via                   ', N'You must be the change you wish to see in the world. Anyone who has never made a                    ', N'(116) 619 2896', 1, 0, NULL, 0, 0, N'Steve Murray', N'How we spend our days is, of course, how we spend our lives. Anyone who has never                   ')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator]) VALUES (N'22795565-8a2c-4af4-be0e-333be2f40e0f', N'customer2@gmail.com', N'CUSTOMER2@GMAIL.COM', N'customer2@gmail.com', N'CUSTOMER2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHT/GSXW0xY8CR0nZOyQEOD0SK1vs6irNWUcRh8sQJNPCarKQ4QP6ziNoXsvKQGgPg==', N'AH5UZTAZYCOOPMYIOVHHMJVJECZN4554', N'f529839f-5a91-4f2e-88fd-639908b9f291', NULL, 0, 0, NULL, 1, 0, N'Customer2', N'ApplicationUser')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator]) VALUES (N'2399f3c2-3367-4e37-ba9e-b4f821bb3211', N'staff2@gmail.com', N'STAFF2@GMAIL.COM', N'staff2@gmail.com', N'STAFF2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEeyeWPt97Y1J2ww6cevwoBItNO74a+Lx6Npe1sV5cPC9f7M5Dn80RJGT6+y1aNd6A==', N'4XFDYT3ZU4PKCV2TPCBREAGF4QPCVWQI', N'83b94308-fe32-4ea6-a412-5fb56a8e7cfd', NULL, 0, 0, NULL, 1, 0, N'Staff2', N'ApplicationUser')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator]) VALUES (N'3', N'Ma Xiuying', N'Ma Xiuying', N'xiuyingma2015@gmail.com', N'max6@mail.com', 1, N'SxzDd0Ceb6', N'Sometimes you win, sometimes you learn. Actually it is just in an idea when feel                    ', N'Difficult circumstances serve as a textbook of life for people. Navicat Cloud provides              ', N'153-3940-6037', 0, 0, NULL, 0, 0, N'Ma Xiuying', N'To successfully establish a new connection to local/remote server - no matter via                   ')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator]) VALUES (N'4', N'Cao Lan', N'Cao Lan', N'lanc@hotmail.com', N'caolan2@icloud.com', 0, N'3dd4hWETAv', N'If it scares you, it might be a good thing to try. Export Wizard allows you to export               ', N'You can select any connections, objects or projects, and then select the corresponding              ', N'(1865) 06 3896', 1, 0, NULL, 0, 0, N'Cao Lan', N'Success consists of going from failure to failure without loss of enthusiasm.                       ')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator]) VALUES (N'49e1b3dd-c27d-4062-a93b-38f27276a509', N'tekato2002@gmail.com', N'TEKATO2002@GMAIL.COM', N'tekato2002@gmail.com', N'TEKATO2002@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKfgu4IscV0HJYAs+4wJy3+bBlbOwTHhSuA2t5fQoub6IHMBM4vXY0kF1Q3AihSAjg==', N'V2KD2C7CXSXFN2KX3ENV6FE53MBSM22U', N'c3657888-ab05-4928-83d4-1d08beb1d88a', NULL, 0, 0, NULL, 1, 0, N'Lewis', N'ApplicationUser')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator]) VALUES (N'56016d37-2712-4186-95a1-ab0a29a0dd76', N'customer@gmail.com', N'CUSTOMER@GMAIL.COM', N'customer@gmail.com', N'CUSTOMER@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEN1AdtG0oBhE0ciP8+aTsJyJ6RB2E6KC7BkGdtiFdrhvIP5+GVDqrsKq44hBa9/n9Q==', N'WQA5DANUQSYVM7OMETSUSUEJASBRKKFP', N'a741800b-4d14-4f20-a91c-e934e644992b', NULL, 0, 0, NULL, 1, 0, N'Customer1', N'ApplicationUser')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator]) VALUES (N'8db1fc06-e9d7-4270-8e28-d48e36317e02', N'staff1@gmail.com', N'STAFF1@GMAIL.COM', N'staff1@gmail.com', N'STAFF1@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPO9GF4xEj6iXnKgX3H/lzLLylJQcFLE6vC0vheRd2RZt95ZsCsVDJWGyBa6nW6WhA==', N'AVHI52QCJS22UXHAAODL7JHNRCJRUDNY', N'f3e4e8d1-3cd1-46a7-8f10-461771590055', NULL, 0, 0, NULL, 1, 0, N'Staff1', N'ApplicationUser')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator]) VALUES (N'9d8c9385-5a15-4fc6-9292-3fc3ba636184', N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEfuIUAQ1avXj60Pbrg0ZRrelua/4qDpb52+HhZMgfcrRWwENj9OEZIR8m//M9KOOw==', N'6IPJ4ZIEGL4L4M2PHCUN4H3FQVUT43NC', N'e6c74776-24a2-4bea-a5ce-8de6d82929d5', NULL, 0, 0, NULL, 1, 0, N'Admin', N'ApplicationUser')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator]) VALUES (N'ac51ac6c-9dd5-4416-bdb3-54bf188e3b33', N'store1@gmail.com', N'STORE1@GMAIL.COM', N'store1@gmail.com', N'STORE1@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEAx56jDUDVBn6rBUeqAbagGtEym4COztjrAF9zdL/ZQ3RviO30VtKJBLnmPq6XuUYg==', N'T435CMSEMCCX7VJIA7WX2N37FXL2FTI4', N'dc336462-51fe-4867-9afa-34f492fa1c58', NULL, 0, 0, NULL, 1, 0, N'Test Store', N'ApplicationUser')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Name], [Discriminator]) VALUES (N'be2aa6c2-8894-489d-bdd8-f98c46a8da21', N'store2@gmail.com', N'STORE2@GMAIL.COM', N'store2@gmail.com', N'STORE2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEMlSvvsLWA1V450UZNkYCUGj1fplQPQCO6KZt1NGrYS3FdjTF/FyPOhPNV22CZZ4ig==', N'Y6JVIW5AQAEIUIQVVUDFYO7T3JLH3FNP', N'84c27895-7ef5-4a9f-a8ce-7bc670c2fa93', NULL, 0, 0, NULL, 1, 0, N'Store2', N'ApplicationUser')
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [ApplicationUserId], [Name], [Address]) VALUES (1, N'56016d37-2712-4186-95a1-ab0a29a0dd76', N'Customer1', N'123 ABC Street1')
INSERT [dbo].[Customers] ([Id], [ApplicationUserId], [Name], [Address]) VALUES (5, N'49e1b3dd-c27d-4062-a93b-38f27276a509', N'Lewis', N'No edit yet')
INSERT [dbo].[Customers] ([Id], [ApplicationUserId], [Name], [Address]) VALUES (6, N'9d8c9385-5a15-4fc6-9292-3fc3ba636184', N'customerTest', N'default')
INSERT [dbo].[Customers] ([Id], [ApplicationUserId], [Name], [Address]) VALUES (7, N'22795565-8a2c-4af4-be0e-333be2f40e0f', N'Customer2', N'Customer 2')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[LaundryStores] ON 

INSERT [dbo].[LaundryStores] ([Id], [ApplicationUserId], [Name], [Address], [Capacity], [Status]) VALUES (1, N'4', N'Cosmo Laundry', N'13 3-803 Kusunokiajima, Kita Ward', 7, 0)
INSERT [dbo].[LaundryStores] ([Id], [ApplicationUserId], [Name], [Address], [Capacity], [Status]) VALUES (2, N'2', N'T&T Laundry', N'534 Whitehouse Lane, Huntingdon Rd', 7, 0)
INSERT [dbo].[LaundryStores] ([Id], [ApplicationUserId], [Name], [Address], [Capacity], [Status]) VALUES (3, N'3', N'Cali Sài Gòn', N'1-6-9, Marunouchi, Chiyoda-ku', 8, 0)
INSERT [dbo].[LaundryStores] ([Id], [ApplicationUserId], [Name], [Address], [Capacity], [Status]) VALUES (4, N'1', N'Joins Pro', N'934 Grape Street', 7, 1)
INSERT [dbo].[LaundryStores] ([Id], [ApplicationUserId], [Name], [Address], [Capacity], [Status]) VALUES (5, N'ac51ac6c-9dd5-4416-bdb3-54bf188e3b33', N'Test Store', N'No edit yet', 5, 0)
INSERT [dbo].[LaundryStores] ([Id], [ApplicationUserId], [Name], [Address], [Capacity], [Status]) VALUES (7, N'be2aa6c2-8894-489d-bdd8-f98c46a8da21', N'Store2', N'Store2 address', 7, 1)
SET IDENTITY_INSERT [dbo].[LaundryStores] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [Name], [Description], [ImgUrl]) VALUES (1, N'Giặt hấp áo Sơ Mi', N'Wilson, lo sento', N'https://giatui247.vn/web/image/product.product/11/image_1024/%5BDVC-01%5D%20Gi%E1%BA%B7t%20%E1%BB%A7i%20%C3%A1o%20S%C6%A1%20Mi?unique=617a57d')
INSERT [dbo].[Services] ([Id], [Name], [Description], [ImgUrl]) VALUES (2, N'Giặt hấp áo Khoác Phao', N'linguens et homo, Id apparens quad quad non et estis', N'https://giatui247.vn/web/image/product.template/45/image_512/%5BDVH-12%5D%20Gi%E1%BA%B7t%20h%E1%BA%A5p%20%C3%A1o%20Kho%C3%A1c%20Phao?unique=a437578')
INSERT [dbo].[Services] ([Id], [Name], [Description], [ImgUrl]) VALUES (3, N'Giặt hấp quần Âu', N'Longam, estis gravis vobis estis apparens nomen nomen eggredior.', N'https://giatui247.vn/web/image/product.template/42/image_512/%5BDVH-09%5D%20Gi%E1%BA%B7t%20h%E1%BA%A5p%20qu%E1%BA%A7n%20%C3%82u?unique=eb46516')
INSERT [dbo].[Services] ([Id], [Name], [Description], [ImgUrl]) VALUES (4, N'Giặt hấp phụ kiện thời trang', N'quad fecit, estis regit, fecit. Longam, quad non si', N'https://giatui247.vn/web/image/product.template/47/image_512/%5BDVH-14%5D%20Gi%E1%BA%B7t%20h%E1%BA%A5p%20ph%E1%BB%A5%20ki%E1%BB%87n%20th%E1%BB%9Di%20trang%20%28Option%29?unique=513b571')
INSERT [dbo].[Services] ([Id], [Name], [Description], [ImgUrl]) VALUES (5, N'Giặt hấp áo Khoác Mangto', N'pars nomen venit Id gravis et si estis fecit. apparens', N'https://giatui247.vn/web/image/product.template/44/image_512/%5BDVH-11%5D%20Gi%E1%BA%B7t%20h%E1%BA%A5p%20%C3%A1o%20Kho%C3%A1c%20%28Mangto%29?unique=8b79052')
INSERT [dbo].[Services] ([Id], [Name], [Description], [ImgUrl]) VALUES (6, N'Giày thể thao -Sneaker', N'quad venit fecit. regit, vantis. homo, regit, pars Longam,', N'https://giatui247.vn/web/image/product.template/55/image_512/%5BDVS-13%5D%20Gi%E1%BA%B7t%20Gi%C3%A0y%20V%E1%BB%87%20Sinh%20Gi%C3%A0y%20%28Gi%C3%A0y%20th%E1%BB%83%20thao%20-Sneaker%29?unique=05326e2')
INSERT [dbo].[Services] ([Id], [Name], [Description], [ImgUrl]) VALUES (7, N'Giặt Khăn Tắm Khách sạn', N'fecit, pladior Sed gravis nomen eggredior. Et quad', N'https://giatui247.vn/web/image/product.template/33/image_512/%5BDKS-03%5D%20Gi%E1%BA%B7t%20Kh%C4%83n%20T%E1%BA%AFm%20%28Kh%C3%A1ch%20s%E1%BA%A1n%29?unique=6f20fd2')
INSERT [dbo].[Services] ([Id], [Name], [Description], [ImgUrl]) VALUES (8, N'Giặt sấy Quần Áo', N'apparens gravis quo regit, Sed gravis vobis quad novum', N'https://giatui247.vn/web/image/product.template/34/image_512/%5BDVS-01%5D%20Gi%E1%BA%B7t%20s%E1%BA%A5y%20Qu%E1%BA%A7n%20%C3%81o?unique=ab486b4')
INSERT [dbo].[Services] ([Id], [Name], [Description], [ImgUrl]) VALUES (9, N'Giặt hấp áo Dài Bộ', N'apparens novum vobis et eggredior. fecit, quo venit apparens estis homo, vobis', N'https://giatui247.vn/web/image/product.template/40/image_512/%5BDVH-07%5D%20Gi%E1%BA%B7t%20h%E1%BA%A5p%20%C3%A1o%20D%C3%A0i%20%28B%E1%BB%99%29?unique=b3a891e')
INSERT [dbo].[Services] ([Id], [Name], [Description], [ImgUrl]) VALUES (10, N'Giặt hấp áo Da', N'apparens venit pladior Sed quo novum vobis nomen vobis vantis.', N'https://giatui247.vn/web/image/product.template/46/image_512/%5BDVH-13%5D%20Gi%E1%BA%B7t%20h%E1%BA%A5p%20%C3%A1o%20Da%20%28Thu%E1%BB%99c%20da%29?unique=9586039')
INSERT [dbo].[Services] ([Id], [Name], [Description], [ImgUrl]) VALUES (11, N'Giặt hấp Đầm Váy', N'novum eudis estis quad fecit, si vobis imaginator eudis non Longam, quo fecit.', N'https://giatui247.vn/web/image/product.template/37/image_512/%5BDVH-03%5D%20Gi%E1%BA%B7t%20h%E1%BA%A5p%20%C4%90%E1%BA%A7m%20V%C3%A1y?unique=83a275f')
INSERT [dbo].[Services] ([Id], [Name], [Description], [ImgUrl]) VALUES (12, N'Giặt hấp áo Vest', N'et venit Et e eggredior. quad eggredior. Longam, quad', N'https://giatui247.vn/web/image/product.template/39/image_512/%5BDVH-01%5D%20Gi%E1%BA%B7t%20h%E1%BA%A5p%20%C3%A1o%20Vest?unique=4a1b53f')
INSERT [dbo].[Services] ([Id], [Name], [Description], [ImgUrl]) VALUES (13, N'Giặt hấp áo Khoác Jacket', N'Id pars pars vantis. quad Longam, eudis non estis gravis', N'https://giatui247.vn/web/image/product.template/43/image_512/%5BDVH-10%5D%20Gi%E1%BA%B7t%20h%E1%BA%A5p%20%C3%A1o%20Kho%C3%A1c%20%28Jacket%29?unique=3ebea88')
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[Staffs] ON 

INSERT [dbo].[Staffs] ([Id], [ApplicationUserId], [Name], [Age], [Address], [JobPosition]) VALUES (1, N'2399f3c2-3367-4e37-ba9e-b4f821bb3211', N'Staff1', 19, N'No edit yet', 1)
INSERT [dbo].[Staffs] ([Id], [ApplicationUserId], [Name], [Age], [Address], [JobPosition]) VALUES (2, N'8db1fc06-e9d7-4270-8e28-d48e36317e02', N'Staff2', 18, N'Dameyo', 1)
SET IDENTITY_INSERT [dbo].[Staffs] OFF
GO
SET IDENTITY_INSERT [dbo].[StoreServices] ON 

INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (1, 4, 2, 2, 85)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (2, 7, 4, 7, 105)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (3, 10, 2, 9, 104)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (4, 7, 3, 5, 69)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (5, 2, 1, 2, 114)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (6, 2, 1, 3, 132)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (7, 2, 1, 4, 16)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (8, 1, 3, 6, 184)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (9, 8, 2, 3, 74)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (10, 12, 1, 4, 18)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (11, 13, 2, 5, 111)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (12, 3, 2, 9, 178)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (13, 7, 2, 5, 102)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (14, 6, 2, 4, 61)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (15, 6, 2, 2, 181)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (16, 13, 4, 8, 122)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (17, 9, 4, 10, 132)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (18, 7, 2, 3, 175)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (19, 5, 2, 1, 150)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (20, 4, 1, 3, 103)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (21, 6, 3, 7, 54)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (22, 4, 1, 8, 40)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (23, 4, 1, 7, 89)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (24, 3, 3, 4, 178)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (25, 13, 3, 4, 156)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (26, 9, 1, 2, 19)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (27, 6, 3, 5, 34)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (28, 10, 2, 7, 156)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (29, 3, 2, 2, 181)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (30, 13, 3, 9, 48)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (31, 1, 3, 8, 59)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (32, 8, 4, 7, 35)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (33, 5, 1, 10, 126)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (34, 3, 1, 5, 110)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (35, 12, 4, 9, 23)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (36, 8, 3, 8, 65)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (37, 9, 2, 6, 47)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (38, 12, 4, 3, 24)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (39, 5, 4, 5, 64)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (40, 2, 3, 9, 176)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (41, 8, 3, 8, 120)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (42, 5, 3, 2, 55)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (43, 11, 3, 8, 22)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (44, 6, 5, 2, 170)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (45, 11, 1, 3, 166)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (46, 7, 5, 6, 162)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (47, 10, 1, 8, 15)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (48, 4, 5, 3, 182)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (49, 2, 5, 7, 108)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (50, 9, 1, 10, 93)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (51, 5, 5, 10, 66)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (52, 1, 4, 9, 21)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (63, 1, 5, NULL, 12)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (64, 3, 5, NULL, 20)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (65, 8, 5, 1, 1)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (66, 9, 5, 1, 1)
INSERT [dbo].[StoreServices] ([Id], [ServiceId], [LaundryStoreId], [Weight], [UnitPrice]) VALUES (67, 10, 5, 1, 1)
SET IDENTITY_INSERT [dbo].[StoreServices] OFF
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [Discriminator]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0)) FOR [StoreServiceId]
GO
ALTER TABLE [dbo].[OrderDetails] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsPaid]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0)) FOR [OrderStatus]
GO
ALTER TABLE [dbo].[Staffs] ADD  DEFAULT ((0)) FOR [JobPosition]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_AspNetUsers_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_AspNetUsers_ApplicationUserId]
GO
ALTER TABLE [dbo].[LaundryStores]  WITH CHECK ADD  CONSTRAINT [FK_LaundryStores_AspNetUsers_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[LaundryStores] CHECK CONSTRAINT [FK_LaundryStores_AspNetUsers_ApplicationUserId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_StoreServices_StoreServiceId] FOREIGN KEY([StoreServiceId])
REFERENCES [dbo].[StoreServices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_StoreServices_StoreServiceId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers_CustomerId]
GO
ALTER TABLE [dbo].[Shippings]  WITH CHECK ADD  CONSTRAINT [FK_Shippings_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shippings] CHECK CONSTRAINT [FK_Shippings_Orders_OrderId]
GO
ALTER TABLE [dbo].[Shippings]  WITH CHECK ADD  CONSTRAINT [FK_Shippings_Staffs_StaffId] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Staffs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shippings] CHECK CONSTRAINT [FK_Shippings_Staffs_StaffId]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_AspNetUsers_ApplicationUserId] FOREIGN KEY([ApplicationUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_AspNetUsers_ApplicationUserId]
GO
ALTER TABLE [dbo].[StoreServices]  WITH CHECK ADD  CONSTRAINT [FK_StoreServices_LaundryStores_LaundryStoreId] FOREIGN KEY([LaundryStoreId])
REFERENCES [dbo].[LaundryStores] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StoreServices] CHECK CONSTRAINT [FK_StoreServices_LaundryStores_LaundryStoreId]
GO
ALTER TABLE [dbo].[StoreServices]  WITH CHECK ADD  CONSTRAINT [FK_StoreServices_Services_ServiceId] FOREIGN KEY([ServiceId])
REFERENCES [dbo].[Services] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StoreServices] CHECK CONSTRAINT [FK_StoreServices_Services_ServiceId]
GO
