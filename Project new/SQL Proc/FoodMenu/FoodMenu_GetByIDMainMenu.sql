USE [ChutHueManagement]
GO
/****** Object:  StoredProcedure [dbo].[FoodMenu_GetAll]    Script Date: 7/26/2016 9:13:03 PM ******/
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
