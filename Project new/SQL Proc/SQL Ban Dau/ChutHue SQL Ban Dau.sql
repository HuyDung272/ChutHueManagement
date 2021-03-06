USE [master]
GO
/****** Object:  Database [ChutHueManagement]    Script Date: 8/6/2016 5:31:54 PM ******/
CREATE DATABASE [ChutHueManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChutHueManagerment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER\MSSQL\DATA\ChutHueManagerment.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ChutHueManagerment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER\MSSQL\DATA\ChutHueManagerment_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
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
/****** Object:  StoredProcedure [dbo].[Account_ChangePass]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Account_LogIn]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[BackupDatabase]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[BackupDatabase]
@strFileName nvarchar(1000)
As
	BEGIN TRY
		Declare @path nvarchar(1000)
		Set @path = @strFileName
		Set @path = 'C:\Backup\' + @strFileName + '.BAK'
		BACKUP DATABASE ChutHueManagement 
		TO DISK =  @path
		ReTurn 1
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH

GO
/****** Object:  StoredProcedure [dbo].[FoodMenu_Delete]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FoodMenu_Delete]
@ID int

AS
BEGIN
	BEGIN TRY
		IF(EXISTS(SELECT * FROM InvoiceDetails WHERE IDFoodMenu = @ID))
		BEGIN
			Declare @NameFood nvarchar(200)
			Set @NameFood = (
				Select NameFood
				from FoodMenu
				where ID = @ID)
			RAISERROR ('Bạn không thể xóa %s', 16,1, @NameFood)
			RETURN
		END
		ELSE
		BEGIN	
			Delete from FoodMenu
			where ID = @ID
		END
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
end


GO
/****** Object:  StoredProcedure [dbo].[FoodMenu_GetAll]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[FoodMenu_GetByID]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[FoodMenu_GetByID]
	@ID int
AS
	select * from FoodMenu WHERE ID = @ID

GO
/****** Object:  StoredProcedure [dbo].[FoodMenu_GetByIDMainMenu]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[FoodMenu_GetNotDelete]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  proc [dbo].[FoodMenu_GetNotDelete]
AS
	select food.* 
	from FoodMenu food, MainMenu main
	WHERE food.IsDelete = 0 and  food.IDMainMenu = main.ID
	and main.IsDelete = 0


GO
/****** Object:  StoredProcedure [dbo].[FoodMenu_Insert]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[FoodMenu_UpDate]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Info_GetInfo]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Info_Insert]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Info_UpDate]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Invoice_GetSalesAll]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Invoice_GetSalesAll]

AS
BEGIN
	BEGIN TRY
		Select *
		From View_GetSalesAll
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
	
End


GO
/****** Object:  StoredProcedure [dbo].[Invoice_GetSalesAllByDateTime]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Invoice_GetSalesAllByDateTime]
@GetFor int,
@DateStart datetime,
@DateEnd datetime
AS
BEGIN
	BEGIN TRY
		IF(@GetFor = 0)
		Begin -- Tim kiem theo ngay
			Select *
			From View_GetSalesAll vi
			where year(vi.DateTime) = year(@DateStart) 
			and month(vi.DateTime) = month(@DateStart) 
			and day(vi.DateTime) = day(@DateStart)
			Return 0
		End

		IF(@GetFor = 1) -- tim kiem theo khoang ngay
		Begin
			Select *
				From View_GetSalesAll vi
				where vi.DateTime >= @DateStart and vi.DateTime <= @DateEnd
				Return 0
				--where year(vi.DateTime) >= year(@DateStart) and year(vi.DateTime) <= year(@DateEnd)
				--and month(vi.DateTime) >= month(@DateStart) and month(vi.DateTime) <= month(@DateEnd)
				--and day(vi.DateTime) >= day(@DateStart) and day(vi.DateTime) <= day(@DateEnd)
				--Return day(@DateStart)
		End
		
		IF(@GetFor = 2) -- tim kiem theo thang
		Begin
			Select *
				From View_GetSalesAll vi
				where year(vi.DateTime) >= year(@DateStart) and year(vi.DateTime) <= year(@DateEnd)
				and month(vi.DateTime) >= month(@DateStart) and month(vi.DateTime) <= month(@DateEnd)
				--and day(vi.DateTime) = day(@DateStart)
				Return 0
		End

		IF(@GetFor = 3) -- tim kiem theo nam
		Begin
			Select *
				From View_GetSalesAll vi
				where year(vi.DateTime) >= year(@DateStart) and year(vi.DateTime) <= year(@DateEnd)
				--and month(vi.DateTime) >= month(@DateStart) and month(vi.DateTime) <= month(@DateEnd)
				--and day(vi.DateTime) = day(@DateStart)
				Return 0
		End
			
		
		
	END Try

	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
	
End


GO
/****** Object:  StoredProcedure [dbo].[Invoice_GetSalesForFoodByDateTime]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Invoice_GetSalesForFoodByDateTime]
@FoodID int,
@GetFor int,
@DateStart datetime,
@DateEnd datetime
AS
BEGIN
	BEGIN TRY
		IF(@GetFor = 0)
		Begin -- Tim kiem theo ngay
			Select *
			From View_GetSalesAll vi
			where year(vi.DateTime) = year(@DateStart) 
			and month(vi.DateTime) = month(@DateStart) 
			and day(vi.DateTime) = day(@DateStart)
			Return 0
		End

		IF(@GetFor = 1) -- tim kiem theo khoang ngay
		Begin
			Select *
				From View_GetSalesAll vi
				where vi.DateTime >= @DateStart and vi.DateTime <= @DateEnd
				Return 0
				--where year(vi.DateTime) >= year(@DateStart) and year(vi.DateTime) <= year(@DateEnd)
				--and month(vi.DateTime) >= month(@DateStart) and month(vi.DateTime) <= month(@DateEnd)
				--and day(vi.DateTime) >= day(@DateStart) and day(vi.DateTime) <= day(@DateEnd)
				--Return day(@DateStart)
		End
		
		IF(@GetFor = 2) -- tim kiem theo thang
		Begin
			Select *
				From View_GetSalesAll vi
				where year(vi.DateTime) >= year(@DateStart) and year(vi.DateTime) <= year(@DateEnd)
				and month(vi.DateTime) >= month(@DateStart) and month(vi.DateTime) <= month(@DateEnd)
				--and day(vi.DateTime) = day(@DateStart)
				Return 0
		End

		IF(@GetFor = 3) -- tim kiem theo nam
		Begin
			Select *
				From View_GetSalesAll vi
				where year(vi.DateTime) >= year(@DateStart) and year(vi.DateTime) <= year(@DateEnd)
				--and month(vi.DateTime) >= month(@DateStart) and month(vi.DateTime) <= month(@DateEnd)
				--and day(vi.DateTime) = day(@DateStart)
				Return 0
		End
			
		
		
	END Try

	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
	
End


GO
/****** Object:  StoredProcedure [dbo].[Invoice_GetSalesWithFoodForFoodByDateTime]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Invoice_GetSalesWithFoodForFoodByDateTime]
@FoodID int,
@GetFor int,
@DateStart datetime,
@DateEnd datetime
AS
BEGIN
	BEGIN TRY
		IF(@GetFor = 0)
		Begin -- Tim kiem theo ngay
			Select *
			From View_GetSalesWithFood vi
			where year(vi.DateTime) = year(@DateStart) 
			and month(vi.DateTime) = month(@DateStart) 
			and day(vi.DateTime) = day(@DateStart)
			and @FoodID = vi.FoodID
			Return 0
		End

		IF(@GetFor = 1) -- tim kiem theo khoang ngay
		Begin
			Select *
			From View_GetSalesWithFood vi
				where vi.DateTime >= @DateStart and vi.DateTime <= @DateEnd
				and @FoodID = vi.FoodID
				Return 0
				--where year(vi.DateTime) >= year(@DateStart) and year(vi.DateTime) <= year(@DateEnd)
				--and month(vi.DateTime) >= month(@DateStart) and month(vi.DateTime) <= month(@DateEnd)
				--and day(vi.DateTime) >= day(@DateStart) and day(vi.DateTime) <= day(@DateEnd)
				--Return day(@DateStart)
		End
		
		IF(@GetFor = 2) -- tim kiem theo thang
		Begin
			Select *
			From View_GetSalesWithFood vi
				where year(vi.DateTime) >= year(@DateStart) and year(vi.DateTime) <= year(@DateEnd)
				and month(vi.DateTime) >= month(@DateStart) and month(vi.DateTime) <= month(@DateEnd)
				and @FoodID = vi.FoodID
				--and day(vi.DateTime) = day(@DateStart)
				Return 0
		End

		IF(@GetFor = 3) -- tim kiem theo nam
		Begin
			Select *
			From View_GetSalesWithFood vi
				where year(vi.DateTime) >= year(@DateStart) and year(vi.DateTime) <= year(@DateEnd)
				and @FoodID = vi.FoodID
				--and month(vi.DateTime) >= month(@DateStart) and month(vi.DateTime) <= month(@DateEnd)
				--and day(vi.DateTime) = day(@DateStart)
				Return 0
		End
			
		
		
	END Try

	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
	
End


GO
/****** Object:  StoredProcedure [dbo].[Invoice_GetSerialCodeMax]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Invoice_GetSerialCodeMax]
AS
BEGIN
	select top(1) Invoice.InvoiceCode from Invoice order by InvoiceCode desc
END


GO
/****** Object:  StoredProcedure [dbo].[Invoice_Insert]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Invoice_Insert]
@InvoiceCode nvarchar(15),
@TableName nvarchar(50),
@DateTime DateTime,
@Note nvarchar(100)
AS
BEGIN
	BEGIN TRY
		Declare @id int, @idy nvarchar(4);

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
/****** Object:  StoredProcedure [dbo].[Invoice_UpDate]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Invoice_UpDateByInvoiceCode]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[InvoiceDetails_Insert]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InvoiceDetails_Insert]
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
		Return @@IDENTITY
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
	
END


GO
/****** Object:  StoredProcedure [dbo].[LogBackupRestore_Delete]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[LogBackupRestore_Delete]
@ID int

AS
BEGIN
	BEGIN TRY
		BEGIN	
			Delete from LogBackupRestore
			where ID = @ID
		END
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
end


GO
/****** Object:  StoredProcedure [dbo].[LogBackupRestore_GetAll]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LogBackupRestore_GetAll]
@IsBackup bit
AS
BEGIN
	select *
	from LogBackupRestore
	where IsBackup = @IsBackup order by ID desc
END

GO
/****** Object:  StoredProcedure [dbo].[LogBackupRestore_Insert]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LogBackupRestore_Insert]
@Name nvarchar(200),
@DateTime datetime,
@IsBackup bit,
@Paths nvarchar(500),
@Note nvarchar(200)
AS
BEGIN
	Declare @ID int;
	--Declare @Date DateTime;
	if((select COUNT(*) from [ChutHueManagement].[dbo].[LogBackupRestore] where Name  = @Name and IsBackup = @IsBackup) = 0)
	Begin
		Set @DateTime = CURRENT_TIMESTAMP
		INSERT INTO LogBackupRestore
		VALUES (@Name, @DateTime, @IsBackup, @Paths, @Note)
		SET @ID = @@IDENTITY
	End
	else
	Begin
		Set @ID = 0
	End
	Return @ID
END


GO
/****** Object:  StoredProcedure [dbo].[LogBackupRestore_InsertGetID]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[LogBackupRestore_InsertGetID]
@Name nvarchar(200),
@DateTime datetime,
@IsBackup bit,
@Paths nvarchar(200),
@Note nvarchar(200)
AS
BEGIN
	Declare @ID int;
	--Declare @Date DateTime;
	if((select COUNT(*) from [ChutHueManagement].[dbo].[LogBackupRestore] where Name  = @Name and IsBackup = @IsBackup) = 0)
	Begin
		Set @DateTime = CURRENT_TIMESTAMP
		INSERT INTO LogBackupRestore
		VALUES (@Name, @DateTime, @IsBackup, @Paths, @Note)
		SET @ID = @@IDENTITY
		Return @ID
	End
	else
	Begin
		Set @ID = 0
	End
	Return @ID
END


GO
/****** Object:  StoredProcedure [dbo].[LogSystem_Insert]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[LogSystem_Insert]
@IDAccount int,
@Event nvarchar(250),
@DateTime datetime

AS
BEGIN
	Set @DateTime = CURRENT_TIMESTAMP
	BEGIN TRY
		INSERT INTO LogSystem
		VALUES (@IDAccount, @Event, @DateTime)
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
End


GO
/****** Object:  StoredProcedure [dbo].[MainMenu_Delete]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MainMenu_Delete]
@ID int

AS
BEGIN
	BEGIN TRY
		IF(EXISTS(SELECT * FROM FoodMenu WHERE IDMainMenu = @ID))
		BEGIN
			Declare @NameEntryMenu nvarchar(200)
			Set @NameEntryMenu = (
				Select NameEntryMenu
				from MainMenu
				where ID = @ID)
			RAISERROR ('Bạn không thể xóa Loại thực đơn %s', 16,1, @NameEntryMenu)
			RETURN
		END
		ELSE
		BEGIN	
			Delete from MainMenu
			where ID = @ID
		END
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
end


GO
/****** Object:  StoredProcedure [dbo].[MainMenu_GetAll]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[MainMenu_GetAllNotDelete]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MainMenu_GetAllNotDelete]

AS
BEGIN
	

	BEGIN TRY
		Select *
		from MainMenu
		Where MainMenu.IsDelete = 0
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
end


GO
/****** Object:  StoredProcedure [dbo].[MainMenu_Insert]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[MainMenu_UpDate]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Reset_Identity]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Reset_Identity]
@ColumnName nvarchar(30)
As
DBCC CHECKIDENT(@ColumnName, RESEED, 0)


GO
/****** Object:  StoredProcedure [dbo].[RestoreDatabase]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[RestoreDatabase]
@paths nvarchar(300)
As
	BEGIN TRY
		ALTER DATABASE ChutHueManagement
		SET OFFLINE WITH ROLLBACK IMMEDIATE

		ALTER DATABASE ChutHueManagement
		SET ONLINE

		RESTORE DATABASE ChutHueManagement FROM DISK = @paths WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 5
		ReTurn 1
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH

GO
/****** Object:  StoredProcedure [dbo].[Tables_Delete]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Tables_Delete]
	@ID int
AS
	DELETE Tables
	WHERE ID =@ID

GO
/****** Object:  StoredProcedure [dbo].[Tables_GetAll]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Tables_GetAll]
AS
Begin

	BEGIN TRY
		Select * from Tables
		ORDER BY TableName ASC
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[Tables_GetByID]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Tables_GetByID]
@ID int
AS
Begin

	BEGIN TRY
		select * from Tables where ID=@ID
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
End

GO
/****** Object:  StoredProcedure [dbo].[Tables_Insert]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[Tables_Insert]
(
	@TableName nvarchar(50)
)
AS
	Insert Into Tables(TableName) Values (@TableName)

GO
/****** Object:  StoredProcedure [dbo].[Tables_UpDate]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Tables_UpDate]
(
	@ID int,
	@TableName nvarchar(50)
)
AS
	UPDATE Tables
	SET TableName=@TableName
	WHERE ID=@ID

GO
/****** Object:  Table [dbo].[Account]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  Table [dbo].[FoodMenu]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  Table [dbo].[Invoice]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  Table [dbo].[LogBackupRestore]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogBackupRestore](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[IsBackup] [bit] NOT NULL,
	[Paths] [nvarchar](500) NOT NULL,
	[Note] [nvarchar](200) NULL,
 CONSTRAINT [PK_LogBackupRestore] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LogSystem]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogSystem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDAccount] [int] NOT NULL,
	[Event] [nvarchar](250) NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_LogSystem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MainMenu]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  Table [dbo].[RestaurantInfo]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  Table [dbo].[Tables]    Script Date: 8/6/2016 5:31:54 PM ******/
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
/****** Object:  View [dbo].[View_GetSalesAll]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[View_GetSalesAll]
AS
select invoice.ID, invoice.InvoiceCode, invoice.DateTime, Sum(details.PriceTotal) as PriceTotal
from Invoice invoice join InvoiceDetails details
on invoice.ID = details.IDInvoice
group by invoice.ID, invoice.InvoiceCode, invoice.DateTime

GO
/****** Object:  View [dbo].[View_GetSalesWithFood]    Script Date: 8/6/2016 5:31:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_GetSalesWithFood]
AS
SELECT        food.NameFood, invoice.InvoiceCode, food.ID AS FoodID, invoice.DateTime, details.Total, SUM(details.PriceTotal) AS PriceTotal
FROM            dbo.FoodMenu AS food INNER JOIN
                         dbo.InvoiceDetails AS details ON food.ID = details.IDFoodMenu INNER JOIN
                         dbo.Invoice AS invoice ON details.IDInvoice = invoice.ID
GROUP BY food.NameFood, invoice.InvoiceCode, details.PriceTotal, food.ID, invoice.DateTime, details.Total

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [UserName], [Password], [FullAccess], [Description]) VALUES (1, N'admin', N'3049a1f0f1c808cdaa4fbed0e01649b1', 1, N'Tài khoản quản trị')
INSERT [dbo].[Account] ([ID], [UserName], [Password], [FullAccess], [Description]) VALUES (3, N'banhang', N'3049a1f0f1c808cdaa4fbed0e01649b1', 0, N'Tài khoản thanh toán')
INSERT [dbo].[Account] ([ID], [UserName], [Password], [FullAccess], [Description]) VALUES (4, N'banhang1', N'1', 0, NULL)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[FoodMenu] ON 

INSERT [dbo].[FoodMenu] ([ID], [NameFood], [IDMainMenu], [Price], [IsDelete], [Description]) VALUES (1, N'Bánh canh cá lóc', 1, 25000, 0, N'')
INSERT [dbo].[FoodMenu] ([ID], [NameFood], [IDMainMenu], [Price], [IsDelete], [Description]) VALUES (2, N'Bánh bèo', 1, 15000, 0, N'')
INSERT [dbo].[FoodMenu] ([ID], [NameFood], [IDMainMenu], [Price], [IsDelete], [Description]) VALUES (3, N'Bánh bột lọc', 1, 15000, 0, N'')
INSERT [dbo].[FoodMenu] ([ID], [NameFood], [IDMainMenu], [Price], [IsDelete], [Description]) VALUES (4, N'Pepsi', 2, 10000, 0, N'')
INSERT [dbo].[FoodMenu] ([ID], [NameFood], [IDMainMenu], [Price], [IsDelete], [Description]) VALUES (5, N'Coca-Cola', 2, 10000, 0, N'')
SET IDENTITY_INSERT [dbo].[FoodMenu] OFF
SET IDENTITY_INSERT [dbo].[LogSystem] ON 

INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (1, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65A011EB66B AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (2, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65A011EBAA3 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (3, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65A011EFB69 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (4, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65A011F3286 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (5, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65A011F8C9D AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (6, 1, N'admin đã thêm mới thực đơn Bánh canh cá lóc', CAST(0x0000A65A011FB20D AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (7, 1, N'admin đã thêm mới thực đơn Bánh bèo', CAST(0x0000A65A011FC081 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (8, 1, N'admin đã thêm mới thực đơn Bánh bột lọc', CAST(0x0000A65A011FD2C7 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (9, 1, N'admin đã thêm mới thực đơn Pepsi', CAST(0x0000A65A01200223 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (10, 1, N'admin đã thêm mới thực đơn Coca-Cola', CAST(0x0000A65A01201107 AS DateTime))
SET IDENTITY_INSERT [dbo].[LogSystem] OFF
SET IDENTITY_INSERT [dbo].[MainMenu] ON 

INSERT [dbo].[MainMenu] ([ID], [NameEntryMenu], [IsDelete], [Description]) VALUES (1, N'Món ăn', 0, N'Danh mục các món ăn')
INSERT [dbo].[MainMenu] ([ID], [NameEntryMenu], [IsDelete], [Description]) VALUES (2, N'Đồ uống', 0, N'Danh mục đồ uống')
SET IDENTITY_INSERT [dbo].[MainMenu] OFF
INSERT [dbo].[RestaurantInfo] ([ID], [NameRestaurant], [Address], [PhoneNumber], [CellPhone], [Email], [Description]) VALUES (1, N'CHÚT HUẾ', N'05 Phạm Ngũ Lão - Phường 3 - Đà Lạt - Lâm Đồng', N'', N'0967221876', N'', N'')
SET IDENTITY_INSERT [dbo].[Tables] ON 

INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (1, N'01')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (2, N'02')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (3, N'03')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (4, N'04')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (5, N'05')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (6, N'06')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (7, N'07')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (8, N'08')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (9, N'09')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (10, N'10')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (11, N'Mang về')
SET IDENTITY_INSERT [dbo].[Tables] OFF
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "food"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "details"
            Begin Extent = 
               Top = 6
               Left = 262
               Bottom = 136
               Right = 448
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "invoice"
            Begin Extent = 
               Top = 6
               Left = 486
               Bottom = 136
               Right = 672
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GetSalesWithFood'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GetSalesWithFood'
GO
USE [master]
GO
ALTER DATABASE [ChutHueManagement] SET  READ_WRITE 
GO
