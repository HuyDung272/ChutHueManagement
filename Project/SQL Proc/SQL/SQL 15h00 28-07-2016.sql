USE [master]
GO
/****** Object:  Database [ChutHueManagement]    Script Date: 7/28/2016 3:09:22 PM ******/
CREATE DATABASE [ChutHueManagement]
 CONTAINMENT = NONE

ALTER DATABASE [ChutHueManagement] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChutHueManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChutHueManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChutHueManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChutHueManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChutHueManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChutHueManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChutHueManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChutHueManagement] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ChutHueManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChutHueManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChutHueManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChutHueManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChutHueManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChutHueManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChutHueManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChutHueManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChutHueManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ChutHueManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChutHueManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChutHueManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChutHueManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChutHueManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChutHueManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChutHueManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChutHueManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [ChutHueManagement] SET  MULTI_USER 
GO
ALTER DATABASE [ChutHueManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChutHueManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChutHueManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChutHueManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ChutHueManagement', N'ON'
GO
USE [ChutHueManagement]
GO
/****** Object:  StoredProcedure [dbo].[Account_ChangePass]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Account_ChangePass]
@UserName nvarchar(50),
@OldPass nvarchar(50),
@NewPass nvarchar(50)
AS
	BEGIN TRY
		IF(EXISTS(SELECT * FROM Account WHERE @UserName = UserName and @OldPass = Account.Password))
		BEGIN
			If(@NewPass = @OldPass)
			Begin
				RAISERROR ('Bạn phải nhập mật khẩu mới không trùng với mật khẩu cũ', 16,1)
				RETURN
			End
			
			Begin
				Update Account 
				Set Password = @NewPass
				Where UserName = @UserName and Password = @OldPass
			End
		END
		ELSE
		Begin
				RAISERROR ( 'Mật khẩu cũ không chính xác', 16,1)
				RETURN
		End
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH

GO
/****** Object:  StoredProcedure [dbo].[Account_LogIn]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Account_LogIn]
@UserName nvarchar(50),
@Password nvarchar(50)
AS
BEGIN
	BEGIN TRY
		IF(EXISTS(SELECT * FROM Account WHERE UserName = @UserName and Account.Password = @Password))
		BEGIN
			Select *
			from Account
			Where UserName = @UserName and Account.Password = @Password
		END
		BEGIN	
			RAISERROR ('Thông Tin Đăng nhập không chính xác', 16,1)
			RETURN
		END
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
	
End

GO
/****** Object:  StoredProcedure [dbo].[FoodMenu_GetAll]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FoodMenu_GetAll]
AS
BEGIN
	BEGIN TRY
		Select * 
		From FoodMenu
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[FoodMenu_GetByIDMainMenu]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[FoodMenu_GetByIDMainMenu]
@IDMainMenu int
AS
BEGIN
	BEGIN TRY
		Select *
		From FoodMenu
		where IDMainMenu = @IDMainMenu
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[FoodMenu_Insert]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FoodMenu_Insert]
@NameFood nvarchar(200),
@IDMainMenu int,
@Price float,
@IsDelete bit,
@Description nvarchar(200)

AS
BEGIN
	BEGIN TRY
		INSERT INTO FoodMenu
		VALUES (@NameFood, @IDMainMenu, @Price, @IsDelete, @Description)
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
End
GO
/****** Object:  StoredProcedure [dbo].[FoodMenu_UpDate]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[FoodMenu_UpDate]
@ID int,
@NameFood nvarchar(200),
@IDMainMenu int,
@Price float,
@IsDelete bit,
@Description nvarchar(200)

AS
BEGIN
	BEGIN TRY
		Update FoodMenu 
		Set NameFood = @NameFood, 
		IDMainMenu = @IDMainMenu,
		Price = @Price,
		IsDelete = @IsDelete, 
		FoodMenu.Description = @Description
		where ID = @ID
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[Info_GetInfo]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Info_GetInfo]
AS
BEGIN
	BEGIN TRY
		Select * 
		From RestaurantInfo
		Where ID = 1
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[Info_Insert]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Info_Insert]
@NameRestaurant nvarchar(200),
@Address nvarchar(200),
@PhoneNumber nvarchar(50),
@CellPhone nvarchar(50),
@Email nvarchar(100),
@Description nvarchar(200)

AS
BEGIN
	BEGIN TRY
		INSERT INTO RestaurantInfo
		VALUES (1, @NameRestaurant, @Address, @PhoneNumber, @CellPhone, @Email, @Description)
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[Info_UpDate]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Info_UpDate]
@NameRestaurant nvarchar(200),
@Address nvarchar(200),
@PhoneNumber nvarchar(50),
@CellPhone nvarchar(50),
@Email nvarchar(100),
@Description nvarchar(200)

AS
BEGIN
	BEGIN TRY
		Update RestaurantInfo 
		Set NameRestaurant = @NameRestaurant, 
		RestaurantInfo.Address = @Address, 
		PhoneNumber = @PhoneNumber,
		CellPhone = @CellPhone,  
		Email = @Email,
		RestaurantInfo.Description = @Description
		where ID = 1
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[Invoice_Insert]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Invoice_Insert]
@TableName nvarchar(50),
@DateTime DateTime,
@Note nvarchar(100)
AS
BEGIN
	BEGIN TRY
		Declare @id int, @idy nvarchar(4), @InvoiceCode nvarchar(15);

		--set @NgayLapHoaDon = GETDATE();
		set @idy = CAST(YEAR(GETDATE()) as nvarchar(4));
		set @idy = SUBSTRING(@idy,2,len(@idy)-1); -- Nam hi?n t?i
		if((select top(1) Invoice.InvoiceCode from Invoice) is null)
		begin
			set @InvoiceCode = @idy + '-000000001';
		end
		else
		Begin
			Declare @year nvarchar(3); -- Nam cu?i cùng trong hóa don
			Set @year = (select top (1) SUBSTRING(InvoiceCode, 1, 3) from Invoice order by InvoiceCode desc);
			Set @id = (select top (1) cast(SUBSTRING(InvoiceCode,5,len(InvoiceCode)-4) as int) from Invoice order by InvoiceCode desc)+1;
			if(@idy <> @year)
			Begin
				set @InvoiceCode = @idy + '-000000001';
			End
			else
			Begin
				if(@id<10)
					begin
						set @InvoiceCode = @idy+'-00000000'+cast(@id as nvarchar(1));
					end
				else
				begin
					if(@id<100)
					begin
						set @InvoiceCode = @idy+'-0000000'+cast(@id as nvarchar(2));
					end
					else
					Begin
						if(@id<1000)
						begin
							set @InvoiceCode = @idy+'-000000'+cast(@id as nvarchar(3));
						end
						else
						Begin
							if(@id<10000)
							begin
								set @InvoiceCode = @idy+'-00000'+cast(@id as nvarchar(4));
							end
							else
							begin
								if(@id<100000)
								begin
									set @InvoiceCode = @idy+'-0000'+cast(@id as nvarchar(5));
								end
								else
								begin
									if(@id<1000000)
									begin
										set @InvoiceCode = @idy+'-000'+cast(@id as nvarchar(6));
									end
									else
									begin
										set @InvoiceCode = @idy+'-00'+cast(@id as nvarchar(7));
									end
								end
							end
						End
					End
				end
			End
		End
		Set @DateTime = CURRENT_TIMESTAMP
		INSERT INTO Invoice
		VALUES 
		(
			@InvoiceCode, @TableName, @DateTime, @Note
		)
		Return @@IDENTITY
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
	
	
end


GO
/****** Object:  StoredProcedure [dbo].[Invoice_UpDate]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Invoice_UpDate]
@ID int,
@InvoiceCode nvarchar(15),
@TableName nvarchar(50),
@DateTime DateTime,
@Note nvarchar(100)

AS
BEGIN
	Update Invoice 
	set 
	InvoiceCode = @InvoiceCode,
	TableName = @TableName,
	Invoice.DateTime = @DateTime,
	Note = @Note
	where ID = @ID
end
GO
/****** Object:  StoredProcedure [dbo].[Invoice_UpDateByInvoiceCode]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Invoice_UpDateByInvoiceCode]
@InvoiceCode nvarchar(15),
@TableName nvarchar(50),
@DateTime DateTime,
@Note nvarchar(100)

AS
BEGIN
	Update Invoice 
	set 	
	TableName = @TableName,
	Invoice.DateTime = @DateTime,
	Note = @Note
	where InvoiceCode = @InvoiceCode
end
GO
/****** Object:  StoredProcedure [dbo].[InvoiceDetails_Insert]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[InvoiceDetails_Insert]
	@IDInvoice int,
	@IDFoodMenu int,
	@Total int,
	@PriceTotal float
	
AS
BEGIN
	BEGIN TRY
		if((select COUNT(id.ID) from InvoiceDetails id
		where id.IDInvoice = @IDInvoice and id.IDFoodMenu = @IDFoodMenu)= 0)
		Begin
			insert into InvoiceDetails 
			values (@IDInvoice, @IDFoodMenu, @Total, @PriceTotal)
		End
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
	
END

GO
/****** Object:  StoredProcedure [dbo].[MainMenu_GetAll]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[MainMenu_GetAll]

AS
BEGIN
	Select *
	from MainMenu
end

GO
/****** Object:  StoredProcedure [dbo].[MainMenu_Insert]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[MainMenu_Insert]
@NameEntryMenu nvarchar(200),
@IsDelete bit,
@Description nvarchar(200)

AS
BEGIN
	BEGIN TRY
		INSERT INTO MainMenu
		VALUES (@NameEntryMenu, @IsDelete, @Description)
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
End
GO
/****** Object:  StoredProcedure [dbo].[MainMenu_UpDate]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MainMenu_UpDate]
@ID int,
@NameEntryMenu nvarchar(200),
@IsDelete bit,
@Description nvarchar(200)

AS
BEGIN
	BEGIN TRY
		Update MainMenu 
		Set NameEntryMenu = @NameEntryMenu, IsDelete = @IsDelete, MainMenu.Description = @Description
		where ID = @ID
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[Tables_GetAll]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Tables_GetAll]
AS
Begin

	BEGIN TRY
		Select * from Tables
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
End
GO
/****** Object:  Table [dbo].[Account]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FullAccess] [bit] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FoodMenu]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodMenu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameFood] [nvarchar](200) NOT NULL,
	[IDMainMenu] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[IsDelete] [bit] NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_FoodMenu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceCode] [nvarchar](15) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Note] [nvarchar](100) NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDInvoice] [int] NOT NULL,
	[IDFoodMenu] [int] NOT NULL,
	[Total] [int] NOT NULL,
	[PriceTotal] [float] NOT NULL,
 CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MainMenu]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MainMenu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NameEntryMenu] [nvarchar](200) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_MainMenu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RestaurantInfo]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantInfo](
	[ID] [int] NOT NULL,
	[NameRestaurant] [nvarchar](200) NULL,
	[Address] [nvarchar](200) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[CellPhone] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_RestaurantInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tables]    Script Date: 7/28/2016 3:09:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tables] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [UserName], [Password], [FullAccess], [Description]) VALUES (1, N'admin', N'3049a1f0f1c808cdaa4fbed0e01649b1', 1, N'Tài khoản quản trị')
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[FoodMenu] ON 

INSERT [dbo].[FoodMenu] ([ID], [NameFood], [IDMainMenu], [Price], [IsDelete], [Description]) VALUES (1, N'Bánh canh cá lóc', 1, 25, 0, N'Bánh canh cá lóc')
INSERT [dbo].[FoodMenu] ([ID], [NameFood], [IDMainMenu], [Price], [IsDelete], [Description]) VALUES (2, N'Bánh bèo', 1, 15, 0, N'Bánh bèo')
SET IDENTITY_INSERT [dbo].[FoodMenu] OFF
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([ID], [InvoiceCode], [TableName], [DateTime], [Note]) VALUES (1, N'016-000000001', N'3', CAST(0x0000A64F016ACDC5 AS DateTime), N'test')
INSERT [dbo].[Invoice] ([ID], [InvoiceCode], [TableName], [DateTime], [Note]) VALUES (2, N'016-000000002', N'4', CAST(0x0000A64F016BBBFB AS DateTime), N'test222')
INSERT [dbo].[Invoice] ([ID], [InvoiceCode], [TableName], [DateTime], [Note]) VALUES (3, N'016-000000003', N'6', CAST(0x0000A64F016C6E27 AS DateTime), N'test232')
SET IDENTITY_INSERT [dbo].[Invoice] OFF
SET IDENTITY_INSERT [dbo].[MainMenu] ON 

INSERT [dbo].[MainMenu] ([ID], [NameEntryMenu], [IsDelete], [Description]) VALUES (1, N'Món ăn', 0, N'Danh mục các món ăn')
INSERT [dbo].[MainMenu] ([ID], [NameEntryMenu], [IsDelete], [Description]) VALUES (2, N'Đồ uống', 0, N'Danh mục đồ uống')
INSERT [dbo].[MainMenu] ([ID], [NameEntryMenu], [IsDelete], [Description]) VALUES (6, N'Test Thêm mới', 0, N'')
INSERT [dbo].[MainMenu] ([ID], [NameEntryMenu], [IsDelete], [Description]) VALUES (7, N'Test Thêm mới 1111', 1, N'UpDate')
SET IDENTITY_INSERT [dbo].[MainMenu] OFF
INSERT [dbo].[RestaurantInfo] ([ID], [NameRestaurant], [Address], [PhoneNumber], [CellPhone], [Email], [Description]) VALUES (1, N'Chút Huế', N'05 Phạm Ngũ Lão', N'123', N'0967221876', N'', N'')
SET IDENTITY_INSERT [dbo].[Tables] ON 

INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (1, N'1')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (2, N'2')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (3, N'3')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (4, N'4')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (5, N'5')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (6, N'6')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (7, N'7')
SET IDENTITY_INSERT [dbo].[Tables] OFF
USE [master]
GO
ALTER DATABASE [ChutHueManagement] SET  READ_WRITE 
GO
