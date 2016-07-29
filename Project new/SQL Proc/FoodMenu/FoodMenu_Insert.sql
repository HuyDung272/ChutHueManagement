USE [ChutHueManagement]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[FoodMenu_Insert]
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