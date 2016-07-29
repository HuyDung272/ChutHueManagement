USE [ChutHueManagement]
GO
/****** Object:  StoredProcedure [dbo].[Info_Insert]    Script Date: 7/26/2016 4:57:06 PM ******/
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