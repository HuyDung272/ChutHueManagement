USE [ChutHueManagement]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[MainMenu_UpDate]
@ID int,
@NameEntryMenu nvarchar(200),
@IsDelete bit,
@Description nvarchar(200)

AS
BEGIN
	BEGIN TRY
		Update MainMenu 
		Set NameEntryMenu = @NameEntryMenu, @IsDelete = @IsDelete, MainMenu.Description = @Description
		where ID = @ID
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
End
