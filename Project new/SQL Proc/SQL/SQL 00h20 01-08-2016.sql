USE [ChutHueManagement]
GO
/****** Object:  StoredProcedure [dbo].[Account_ChangePass]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Account_LogIn]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[BackupDatabase]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[FoodMenu_Delete]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[FoodMenu_GetAll]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[FoodMenu_GetByID]    Script Date: 8/1/2016 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[FoodMenu_GetByID]
	@ID int
AS
	select * from FoodMenu WHERE ID = @ID

GO
/****** Object:  StoredProcedure [dbo].[FoodMenu_GetByIDMainMenu]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[FoodMenu_Insert]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[FoodMenu_UpDate]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Info_GetInfo]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Info_Insert]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Info_UpDate]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Invoice_GetSalesAll]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Invoice_GetSalesAllByDateTime]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Invoice_GetSalesForFoodByDateTime]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Invoice_GetSalesWithFoodForFoodByDateTime]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Invoice_GetSerialCodeMax]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Invoice_Insert]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Invoice_UpDate]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Invoice_UpDateByInvoiceCode]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[InvoiceDetails_Insert]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[LogBackupRestore_Delete]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[LogBackupRestore_GetAll]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[LogBackupRestore_Insert]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[LogBackupRestore_InsertGetID]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[LogSystem_Insert]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[MainMenu_Delete]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[MainMenu_GetAll]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[MainMenu_GetAllNotDelete]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[MainMenu_Insert]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[MainMenu_UpDate]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Reset_Identity]    Script Date: 8/1/2016 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Reset_Identity]
@ColumnName nvarchar(30)
As
DBCC CHECKIDENT(@ColumnName, RESEED, 0)


GO
/****** Object:  StoredProcedure [dbo].[RestoreDatabase]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Tables_GetAll]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Tables_GetByID]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  Table [dbo].[FoodMenu]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  Table [dbo].[Invoice]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  Table [dbo].[LogBackupRestore]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  Table [dbo].[LogSystem]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  Table [dbo].[MainMenu]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  Table [dbo].[RestaurantInfo]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  Table [dbo].[Tables]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  View [dbo].[View_GetSalesAll]    Script Date: 8/1/2016 12:12:36 AM ******/
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
/****** Object:  View [dbo].[View_GetSalesWithFood]    Script Date: 8/1/2016 12:12:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_GetSalesWithFood]
AS
SELECT        food.NameFood, invoice.InvoiceCode, food.ID AS FoodID, invoice.DateTime, SUM(food.ID) AS Total, SUM(details.PriceTotal) AS PriceTotal
FROM            dbo.FoodMenu AS food INNER JOIN
                         dbo.InvoiceDetails AS details ON food.ID = details.IDFoodMenu INNER JOIN
                         dbo.Invoice AS invoice ON details.IDInvoice = invoice.ID
GROUP BY food.NameFood, invoice.InvoiceCode, details.PriceTotal, food.ID, invoice.DateTime

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [UserName], [Password], [FullAccess], [Description]) VALUES (1, N'admin', N'3049a1f0f1c808cdaa4fbed0e01649b1', 1, N'Tài khoản quản trị')
INSERT [dbo].[Account] ([ID], [UserName], [Password], [FullAccess], [Description]) VALUES (3, N'banhang', N'3049a1f0f1c808cdaa4fbed0e01649b1', 0, N'Tài khoản thanh toán')
INSERT [dbo].[Account] ([ID], [UserName], [Password], [FullAccess], [Description]) VALUES (4, N'banhang1', N'1', 0, NULL)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[FoodMenu] ON 

INSERT [dbo].[FoodMenu] ([ID], [NameFood], [IDMainMenu], [Price], [IsDelete], [Description]) VALUES (1, N'Bánh canh cá lóc', 1, 25000, 0, N'Bánh canh cá lóc')
INSERT [dbo].[FoodMenu] ([ID], [NameFood], [IDMainMenu], [Price], [IsDelete], [Description]) VALUES (3, N'CocaCola', 2, 10000, 0, N'')
INSERT [dbo].[FoodMenu] ([ID], [NameFood], [IDMainMenu], [Price], [IsDelete], [Description]) VALUES (4, N'Pepsi', 2, 10000, 0, N'')
INSERT [dbo].[FoodMenu] ([ID], [NameFood], [IDMainMenu], [Price], [IsDelete], [Description]) VALUES (5, N'Cafe', 2, 7000, 0, N'')
INSERT [dbo].[FoodMenu] ([ID], [NameFood], [IDMainMenu], [Price], [IsDelete], [Description]) VALUES (6, N'Bánh bột lọc ', 1, 20000, 0, N'')
INSERT [dbo].[FoodMenu] ([ID], [NameFood], [IDMainMenu], [Price], [IsDelete], [Description]) VALUES (9, N'Bánh bèo', 1, 20000, 0, N'')
INSERT [dbo].[FoodMenu] ([ID], [NameFood], [IDMainMenu], [Price], [IsDelete], [Description]) VALUES (10, N'Nước khoáng', 2, 5000, 0, N'')
SET IDENTITY_INSERT [dbo].[FoodMenu] OFF
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([ID], [InvoiceCode], [TableName], [DateTime], [Note]) VALUES (8, N'016-000000004', N'6', CAST(0x0000A65300FE2623 AS DateTime), N'121123')
INSERT [dbo].[Invoice] ([ID], [InvoiceCode], [TableName], [DateTime], [Note]) VALUES (9, N'016-000000005', N'8', CAST(0x0000A65300FEB968 AS DateTime), N'111111111')
INSERT [dbo].[Invoice] ([ID], [InvoiceCode], [TableName], [DateTime], [Note]) VALUES (11, N'016-000000006', N'7', CAST(0x0000A65600FF62C4 AS DateTime), N'111111111')
SET IDENTITY_INSERT [dbo].[Invoice] OFF
SET IDENTITY_INSERT [dbo].[InvoiceDetails] ON 

INSERT [dbo].[InvoiceDetails] ([ID], [IDInvoice], [IDFoodMenu], [Total], [PriceTotal]) VALUES (6, 8, 3, 2, 11111)
INSERT [dbo].[InvoiceDetails] ([ID], [IDInvoice], [IDFoodMenu], [Total], [PriceTotal]) VALUES (7, 8, 4, 3, 22222)
INSERT [dbo].[InvoiceDetails] ([ID], [IDInvoice], [IDFoodMenu], [Total], [PriceTotal]) VALUES (8, 9, 1, 2, 22222)
INSERT [dbo].[InvoiceDetails] ([ID], [IDInvoice], [IDFoodMenu], [Total], [PriceTotal]) VALUES (9, 9, 9, 3, 22222)
INSERT [dbo].[InvoiceDetails] ([ID], [IDInvoice], [IDFoodMenu], [Total], [PriceTotal]) VALUES (10, 9, 10, 3, 22222)
INSERT [dbo].[InvoiceDetails] ([ID], [IDInvoice], [IDFoodMenu], [Total], [PriceTotal]) VALUES (13, 11, 1, 2, 77777)
INSERT [dbo].[InvoiceDetails] ([ID], [IDInvoice], [IDFoodMenu], [Total], [PriceTotal]) VALUES (14, 11, 3, 3, 77777)
INSERT [dbo].[InvoiceDetails] ([ID], [IDInvoice], [IDFoodMenu], [Total], [PriceTotal]) VALUES (15, 11, 10, 3, 22222)
SET IDENTITY_INSERT [dbo].[InvoiceDetails] OFF
SET IDENTITY_INSERT [dbo].[LogBackupRestore] ON 

INSERT [dbo].[LogBackupRestore] ([ID], [Name], [DateTime], [IsBackup], [Paths], [Note]) VALUES (1, N'[ 31.07.16 - 17.13.40] 111', CAST(0x0000A654011BE8CF AS DateTime), 1, N'C:\Backup\[ 31.07.16 - 17.13.40] 111', N'')
INSERT [dbo].[LogBackupRestore] ([ID], [Name], [DateTime], [IsBackup], [Paths], [Note]) VALUES (2, N'[ 31.07.16 - 17.13.40] 111', CAST(0x0000A654011BF84A AS DateTime), 0, N'C:\Backup\[ 31.07.16 - 17.13.40] 111.bak', N'Backup từ [ 31.07.16 - 17.13.40] 111')
SET IDENTITY_INSERT [dbo].[LogBackupRestore] OFF
SET IDENTITY_INSERT [dbo].[LogSystem] ON 

INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (1, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65200E672C3 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (2, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65200E70977 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (3, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A65200E70CCC AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (4, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65200E75B98 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (5, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65200E760C2 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (6, 3, N'banhang đã đăng nhập hệ thống', CAST(0x0000A65200E8B04E AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (7, 3, N'banhang đã thoát khỏi chương trình', CAST(0x0000A65200E8CB01 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (8, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65200EAFB74 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (9, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65200EB033D AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (10, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65200EB1547 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (11, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65200EB24D2 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (12, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652010817A8 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (13, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A652010825A3 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (14, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201086A6B AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (15, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65201087FFD AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (16, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201106C16 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (17, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65201107585 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (18, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201112706 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (19, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65201112E10 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (20, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201114AC7 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (21, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65201114E97 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (22, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201183419 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (23, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65201184E55 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (24, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201233FE0 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (25, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A652012363AD AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (26, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652012C4D8E AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (27, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A652012CA134 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (28, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652012D4F06 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (29, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A652012E2170 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (30, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652012E2F9E AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (31, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A652012E3815 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (32, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652012E44A1 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (33, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A652012E4D3B AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (34, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652013049B1 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (35, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65201319EDF AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (36, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6520131DDE1 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (37, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A6520131E6F9 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (38, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A6520131E827 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (39, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201322F3A AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (40, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A65201323252 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (41, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A6520132336E AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (42, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201327B84 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (43, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A652013293CE AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (44, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6520132C201 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (45, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A6520132C5D7 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (46, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A6520132C6D3 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (47, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201332F92 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (48, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6520133418F AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (49, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201346734 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (50, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201369762 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (51, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6520136AA33 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (52, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6520136BD29 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (53, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652013ACDAF AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (54, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A652013AD400 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (55, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652013AD9DB AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (56, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A652013AF28A AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (57, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6520158086C AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (58, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A652015842E1 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (59, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652015B5F58 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (60, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A652015B6563 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (61, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201688B98 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (62, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6520168CFF0 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (63, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201746A1E AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (64, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65201747906 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (65, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201754FAD AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (66, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6520175622E AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (67, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6520175828B AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (68, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652017667EF AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (69, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6520176953A AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (70, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65201770D07 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (71, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6520177F0F7 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (72, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65201781AA6 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (73, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652017906D2 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (74, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65201791663 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (75, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652017A32C9 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (76, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A652017A4CF7 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (77, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652017B4678 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (78, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A652017B58B5 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (79, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652017B6CF9 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (80, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652017BAAD2 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (81, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652017E239D AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (82, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652017E943F AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (83, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652017F66A6 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (84, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6520181510A AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (85, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6520181C30B AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (86, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A652018238E3 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (87, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A652018245F4 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (88, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6530091C6FC AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (89, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6530091CD9C AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (90, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A653009257C0 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (91, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6530092615B AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (92, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6530092A8B0 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (93, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6530092B1B5 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (94, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6530093061D AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (95, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A653009308FF AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (96, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6530093764D AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (97, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A653009393F8 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (98, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6530093BA81 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (99, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65300940955 AS DateTime))
GO
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (100, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65300942DCA AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (101, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65300943438 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (102, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A653009484CC AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (103, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65300954CEC AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (104, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6530095C2A7 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (105, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6530095D17F AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (106, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A653009641B1 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (107, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65300965772 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (108, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A653009676B8 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (109, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6530096F1E9 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (110, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65300AE53B2 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (111, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A65300AE7BDE AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (112, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65300AE8795 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (113, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65300AE8D04 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (114, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65300AEFDE7 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (115, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65300AF722F AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (116, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65301033FD8 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (117, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65301034C98 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (118, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6530105079C AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (119, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6530105149D AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (120, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A653010581BC AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (121, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6530105D8D8 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (122, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65301063475 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (123, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6530106A83A AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (124, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6530107380B AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (125, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65301074F8C AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (126, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A653010AFBDD AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (127, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A653010B00D9 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (128, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A653010E28B3 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (129, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A653016BB74A AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (130, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A653016C289D AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (131, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A653016C8427 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (132, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A653016C9517 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (133, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A653016CC89F AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (134, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A653016CD808 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (135, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A653016CF01F AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (136, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A653016D3D3A AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (137, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65301720CE8 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (138, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A6530172446A AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (139, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6530174212F AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (140, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65301746D6E AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (141, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A653017A12CD AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (142, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A653017A14B9 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (143, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6540076386E AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (144, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6540076E413 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (145, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400770540 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (146, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A6540077239B AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (147, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400B0F884 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (148, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400B111DC AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (149, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400B16BF5 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (150, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400B21A28 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (151, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400B23CE7 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (152, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400B25135 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (153, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400B29D60 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (154, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400B2A7EF AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (155, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400B2DB21 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (156, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400B2F60E AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (157, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400B31B59 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (158, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400B31E29 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (159, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400B33DF8 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (160, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400B3D385 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (161, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400B3EA52 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (162, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400B40864 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (163, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400DAA75C AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (164, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400DADFCC AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (165, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400DB3E94 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (166, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400DB46D2 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (167, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400DB78B2 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (168, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400DB8BEE AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (169, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400DC8C2C AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (170, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400DC96EF AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (171, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400DCB873 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (172, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400DCCF48 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (173, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400DD0288 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (174, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400DD1993 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (175, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400E2D8BD AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (176, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400E2E86A AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (177, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400E300D1 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (178, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400E33090 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (179, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400E349D7 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (180, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400E38EE8 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (181, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400E39BEA AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (182, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400E3B5D1 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (183, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400E3E128 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (184, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400F372C2 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (185, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400F40DF9 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (186, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400F89CA2 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (187, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65400F8EA4A AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (188, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65400FC4F83 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (189, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65401016711 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (190, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6540103DFF6 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (191, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6540103F202 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (192, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6540104627B AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (193, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6540104BA07 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (194, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A654010608D4 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (195, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6540107A55A AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (196, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6540107D072 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (197, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654010897E5 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (198, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6540108A90B AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (199, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6540109B6DB AS DateTime))
GO
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (200, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A6540109C702 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (201, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654010B3D52 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (202, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A654010B505D AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (203, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654010BA2FC AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (204, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A654010BC02D AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (205, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654010C7C36 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (206, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A654010C96C9 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (207, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654010CC0AE AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (208, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A654010D365E AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (209, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654010D4C20 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (210, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A654010D88FC AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (211, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654010DCF89 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (212, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A654010DDCA6 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (213, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654010E7943 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (214, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A654010E8AB7 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (215, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654010ED2C3 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (216, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A654010F1B60 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (217, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654010F3CDD AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (218, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A654010F654E AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (219, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654010F7CC1 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (220, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A654010FBFA8 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (221, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6540111B09E AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (222, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6540111BA94 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (223, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6540115A931 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (224, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65401161EA0 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (225, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65401174511 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (226, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6540117A515 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (227, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6540117F888 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (228, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654011828BF AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (229, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65401184373 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (230, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6540118B34C AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (231, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6540118F7C7 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (232, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6540119176C AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (233, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6540119D2C4 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (234, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654011A24A2 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (235, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A654011A7519 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (236, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654011A7DFC AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (237, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654011ACF5A AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (238, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A654011B0046 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (239, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654011BE1A8 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (240, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A654011C046F AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (241, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654011D11AB AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (242, 1, N'admin đã đăng xuất hệ thống', CAST(0x0000A654011D3D2A AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (243, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65401262DFA AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (244, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65401266366 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (245, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65401277615 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (246, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65401283766 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (247, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A65401346010 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (248, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6540134C508 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (249, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A654013C1462 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (250, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A654013C52ED AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (251, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6550000C116 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (252, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6550001A32D AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (253, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6550001C2E9 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (254, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6550001E1FD AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (255, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6550001FE57 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (256, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A65500021742 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (257, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A6550002B916 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (258, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A6550002D429 AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (259, 1, N'admin đã đăng nhập hệ thống', CAST(0x0000A655000317DC AS DateTime))
INSERT [dbo].[LogSystem] ([ID], [IDAccount], [Event], [DateTime]) VALUES (260, 1, N'admin đã thoát khỏi chương trình', CAST(0x0000A655000335F1 AS DateTime))
SET IDENTITY_INSERT [dbo].[LogSystem] OFF
SET IDENTITY_INSERT [dbo].[MainMenu] ON 

INSERT [dbo].[MainMenu] ([ID], [NameEntryMenu], [IsDelete], [Description]) VALUES (1, N'Món ăn', 0, N'Danh mục các món ăn')
INSERT [dbo].[MainMenu] ([ID], [NameEntryMenu], [IsDelete], [Description]) VALUES (2, N'Đồ uống', 0, N'Danh mục đồ uống')
SET IDENTITY_INSERT [dbo].[MainMenu] OFF
INSERT [dbo].[RestaurantInfo] ([ID], [NameRestaurant], [Address], [PhoneNumber], [CellPhone], [Email], [Description]) VALUES (1, N'Chút Huế', N'05 Phạm Ngũ Lão', N'', N'0967221876', N'', N'')
SET IDENTITY_INSERT [dbo].[Tables] ON 

INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (1, N'1')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (2, N'2')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (3, N'3')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (4, N'4')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (5, N'5')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (6, N'6')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (7, N'7')
INSERT [dbo].[Tables] ([ID], [TableName]) VALUES (8, N'8')
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
            TopColumn = 0
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
