USE [master]
GO
/****** Object:  Database [Ciclo8Inventario]    Script Date: 12/11/2024 22:31:25 ******/
CREATE DATABASE [Ciclo8Inventario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ciclo8Inventario', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Ciclo8Inventario.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ciclo8Inventario_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Ciclo8Inventario_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Ciclo8Inventario] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ciclo8Inventario].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ciclo8Inventario] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ciclo8Inventario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ciclo8Inventario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Ciclo8Inventario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ciclo8Inventario] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET RECOVERY FULL 
GO
ALTER DATABASE [Ciclo8Inventario] SET  MULTI_USER 
GO
ALTER DATABASE [Ciclo8Inventario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ciclo8Inventario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ciclo8Inventario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ciclo8Inventario] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Ciclo8Inventario] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Ciclo8Inventario] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Ciclo8Inventario', N'ON'
GO
ALTER DATABASE [Ciclo8Inventario] SET QUERY_STORE = ON
GO
ALTER DATABASE [Ciclo8Inventario] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Ciclo8Inventario]
GO
/****** Object:  Schema [administration]    Script Date: 12/11/2024 22:31:25 ******/
CREATE SCHEMA [administration]
GO
/****** Object:  Schema [catalog]    Script Date: 12/11/2024 22:31:25 ******/
CREATE SCHEMA [catalog]
GO
/****** Object:  Schema [product]    Script Date: 12/11/2024 22:31:25 ******/
CREATE SCHEMA [product]
GO
/****** Object:  Schema [sale]    Script Date: 12/11/2024 22:31:25 ******/
CREATE SCHEMA [sale]
GO
/****** Object:  Table [administration].[permission]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [administration].[permission](
	[id_permission] [int] IDENTITY(1,1) NOT NULL,
	[permission_name] [nvarchar](40) NULL,
	[permission_status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_permission] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [administration].[role]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [administration].[role](
	[id_role] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](40) NOT NULL,
	[role_status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [administration].[role_permission]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [administration].[role_permission](
	[id_role] [int] NOT NULL,
	[id_permission] [int] NOT NULL,
	[role_permission_status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_role] ASC,
	[id_permission] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [administration].[user]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [administration].[user](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[name_user] [nvarchar](40) NOT NULL,
	[user_name] [nvarchar](40) NOT NULL,
	[password] [nvarchar](40) NOT NULL,
	[email] [nvarchar](40) NOT NULL,
	[user_position] [nvarchar](40) NOT NULL,
	[user_status] [bit] NOT NULL,
	[id_user_position] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [catalog].[category]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [catalog].[category](
	[id_category] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](40) NOT NULL,
	[category_status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [catalog].[deparment]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [catalog].[deparment](
	[id_deparment] [int] IDENTITY(1,1) NOT NULL,
	[deparment_name] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_deparment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [catalog].[district]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [catalog].[district](
	[id_district] [int] IDENTITY(1,1) NOT NULL,
	[district_name] [nvarchar](40) NOT NULL,
	[id_municipality] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_district] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [catalog].[municipality]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [catalog].[municipality](
	[id_municipality] [int] IDENTITY(1,1) NOT NULL,
	[id_deparment] [int] NOT NULL,
	[municipality_name] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_municipality] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [catalog].[unit_measure]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [catalog].[unit_measure](
	[id_unit_measure] [int] IDENTITY(1,1) NOT NULL,
	[unit_measure_name] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_unit_measure] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [catalog].[user_position]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [catalog].[user_position](
	[id_user_position] [int] IDENTITY(1,1) NOT NULL,
	[user_position_name] [nvarchar](40) NOT NULL,
	[user_position_status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_user_position] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [catalog].[warehouse]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [catalog].[warehouse](
	[id_warehouse] [int] IDENTITY(1,1) NOT NULL,
	[warehouse_name] [nvarchar](40) NOT NULL,
	[warehouse_location] [nvarchar](40) NOT NULL,
	[warehouse_climate_controlled] [bit] NOT NULL,
	[warehouse_status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_warehouse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_role]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_role](
	[id_user] [int] NOT NULL,
	[id_role] [int] NOT NULL,
	[user_role_status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_user] ASC,
	[id_role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [product].[product]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [product].[product](
	[id_product] [int] IDENTITY(1,1) NOT NULL,
	[id_warehouse] [int] NOT NULL,
	[id_category] [int] NOT NULL,
	[id_brand] [int] NOT NULL,
	[id_unit_measure] [int] NOT NULL,
	[product_reference] [nvarchar](40) NOT NULL,
	[product_name] [nvarchar](40) NULL,
	[product_description] [nvarchar](40) NOT NULL,
	[product_batch] [nvarchar](40) NOT NULL,
	[product_serial] [nvarchar](40) NOT NULL,
	[product_fabrication_date] [date] NOT NULL,
	[product_expiration_date] [date] NOT NULL,
	[product_quantity] [int] NOT NULL,
	[product_status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sale].[brand]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sale].[brand](
	[id_brand] [int] IDENTITY(1,1) NOT NULL,
	[id_supplier] [int] NOT NULL,
	[brand_name] [nvarchar](40) NOT NULL,
	[brand_status] [bit] NOT NULL,
	[brand_country] [nvarchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_brand] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sale].[client]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sale].[client](
	[id_client] [int] IDENTITY(1,1) NOT NULL,
	[client_name] [nvarchar](40) NOT NULL,
	[client_phone] [nvarchar](40) NOT NULL,
	[client_complement_address] [nvarchar](40) NOT NULL,
	[id_district] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sale].[inventory_movement]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sale].[inventory_movement](
	[id_movement] [int] IDENTITY(1,1) NOT NULL,
	[movement_type] [bit] NULL,
	[movement_date] [date] NULL,
	[id_user] [int] NOT NULL,
	[id_supplier] [int] NULL,
	[id_client] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_movement] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sale].[inventory_movent_detail]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sale].[inventory_movent_detail](
	[id_movent_detail] [int] IDENTITY(1,1) NOT NULL,
	[quantity] [float] NULL,
	[unit_cost] [nvarchar](40) NULL,
	[total_cost] [nvarchar](40) NULL,
	[id_movement] [int] NOT NULL,
	[id_product] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_movent_detail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sale].[supplier]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sale].[supplier](
	[id_supplier] [int] IDENTITY(1,1) NOT NULL,
	[supplier_name] [nvarchar](40) NOT NULL,
	[supplier_address] [nvarchar](40) NOT NULL,
	[supplier_phone] [nvarchar](40) NOT NULL,
	[supplier_email] [nvarchar](40) NOT NULL,
	[supplier_country] [nvarchar](40) NULL,
	[supplier_status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_supplier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [sale].[supplier_contact]    Script Date: 12/11/2024 22:31:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sale].[supplier_contact](
	[id_contact_supplier] [int] IDENTITY(1,1) NOT NULL,
	[id_supplier] [int] NOT NULL,
	[contact_supplier_name] [nvarchar](40) NOT NULL,
	[contact_supplier_email] [nvarchar](40) NOT NULL,
	[contact_supplier_phone] [nvarchar](40) NOT NULL,
	[contact_supplier_status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_contact_supplier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [administration].[role_permission]  WITH CHECK ADD  CONSTRAINT [FK_role_permission_permission] FOREIGN KEY([id_permission])
REFERENCES [administration].[permission] ([id_permission])
GO
ALTER TABLE [administration].[role_permission] CHECK CONSTRAINT [FK_role_permission_permission]
GO
ALTER TABLE [administration].[role_permission]  WITH CHECK ADD  CONSTRAINT [FK_role_permission_role] FOREIGN KEY([id_role])
REFERENCES [administration].[role] ([id_role])
GO
ALTER TABLE [administration].[role_permission] CHECK CONSTRAINT [FK_role_permission_role]
GO
ALTER TABLE [administration].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_user_position] FOREIGN KEY([id_user_position])
REFERENCES [catalog].[user_position] ([id_user_position])
GO
ALTER TABLE [administration].[user] CHECK CONSTRAINT [FK_user_user_position]
GO
ALTER TABLE [catalog].[district]  WITH CHECK ADD  CONSTRAINT [FK_district_municipality] FOREIGN KEY([id_municipality])
REFERENCES [catalog].[municipality] ([id_municipality])
GO
ALTER TABLE [catalog].[district] CHECK CONSTRAINT [FK_district_municipality]
GO
ALTER TABLE [catalog].[municipality]  WITH CHECK ADD  CONSTRAINT [FK_municipality_deparment] FOREIGN KEY([id_deparment])
REFERENCES [catalog].[deparment] ([id_deparment])
GO
ALTER TABLE [catalog].[municipality] CHECK CONSTRAINT [FK_municipality_deparment]
GO
ALTER TABLE [dbo].[user_role]  WITH CHECK ADD  CONSTRAINT [FK_user_role_role] FOREIGN KEY([id_role])
REFERENCES [administration].[role] ([id_role])
GO
ALTER TABLE [dbo].[user_role] CHECK CONSTRAINT [FK_user_role_role]
GO
ALTER TABLE [dbo].[user_role]  WITH CHECK ADD  CONSTRAINT [FK_user_role_user] FOREIGN KEY([id_user])
REFERENCES [administration].[user] ([id_user])
GO
ALTER TABLE [dbo].[user_role] CHECK CONSTRAINT [FK_user_role_user]
GO
ALTER TABLE [product].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_brand] FOREIGN KEY([id_brand])
REFERENCES [sale].[brand] ([id_brand])
GO
ALTER TABLE [product].[product] CHECK CONSTRAINT [FK_product_brand]
GO
ALTER TABLE [product].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_category] FOREIGN KEY([id_category])
REFERENCES [catalog].[category] ([id_category])
GO
ALTER TABLE [product].[product] CHECK CONSTRAINT [FK_product_category]
GO
ALTER TABLE [product].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_unit_measure] FOREIGN KEY([id_unit_measure])
REFERENCES [catalog].[unit_measure] ([id_unit_measure])
GO
ALTER TABLE [product].[product] CHECK CONSTRAINT [FK_product_unit_measure]
GO
ALTER TABLE [product].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_warehouse] FOREIGN KEY([id_warehouse])
REFERENCES [catalog].[warehouse] ([id_warehouse])
GO
ALTER TABLE [product].[product] CHECK CONSTRAINT [FK_product_warehouse]
GO
ALTER TABLE [sale].[brand]  WITH CHECK ADD  CONSTRAINT [FK_brand_supplier] FOREIGN KEY([id_supplier])
REFERENCES [sale].[supplier] ([id_supplier])
GO
ALTER TABLE [sale].[brand] CHECK CONSTRAINT [FK_brand_supplier]
GO
ALTER TABLE [sale].[client]  WITH CHECK ADD  CONSTRAINT [FK_client_district] FOREIGN KEY([id_district])
REFERENCES [catalog].[district] ([id_district])
GO
ALTER TABLE [sale].[client] CHECK CONSTRAINT [FK_client_district]
GO
ALTER TABLE [sale].[inventory_movement]  WITH CHECK ADD  CONSTRAINT [FK_inventory_movement_client] FOREIGN KEY([id_client])
REFERENCES [sale].[client] ([id_client])
GO
ALTER TABLE [sale].[inventory_movement] CHECK CONSTRAINT [FK_inventory_movement_client]
GO
ALTER TABLE [sale].[inventory_movement]  WITH CHECK ADD  CONSTRAINT [FK_inventory_movement_supplier] FOREIGN KEY([id_supplier])
REFERENCES [sale].[supplier] ([id_supplier])
GO
ALTER TABLE [sale].[inventory_movement] CHECK CONSTRAINT [FK_inventory_movement_supplier]
GO
ALTER TABLE [sale].[inventory_movement]  WITH CHECK ADD  CONSTRAINT [FK_inventory_movement_user] FOREIGN KEY([id_user])
REFERENCES [administration].[user] ([id_user])
GO
ALTER TABLE [sale].[inventory_movement] CHECK CONSTRAINT [FK_inventory_movement_user]
GO
ALTER TABLE [sale].[inventory_movent_detail]  WITH CHECK ADD  CONSTRAINT [FK_inventory_movent_detail_inventory_movement] FOREIGN KEY([id_movement])
REFERENCES [sale].[inventory_movement] ([id_movement])
GO
ALTER TABLE [sale].[inventory_movent_detail] CHECK CONSTRAINT [FK_inventory_movent_detail_inventory_movement]
GO
ALTER TABLE [sale].[inventory_movent_detail]  WITH CHECK ADD  CONSTRAINT [FK_inventory_movent_detail_product] FOREIGN KEY([id_product])
REFERENCES [product].[product] ([id_product])
GO
ALTER TABLE [sale].[inventory_movent_detail] CHECK CONSTRAINT [FK_inventory_movent_detail_product]
GO
ALTER TABLE [sale].[supplier_contact]  WITH CHECK ADD  CONSTRAINT [FK_supplier_contact_supplier] FOREIGN KEY([id_supplier])
REFERENCES [sale].[supplier] ([id_supplier])
GO
ALTER TABLE [sale].[supplier_contact] CHECK CONSTRAINT [FK_supplier_contact_supplier]
GO
USE [master]
GO
ALTER DATABASE [Ciclo8Inventario] SET  READ_WRITE 
GO
