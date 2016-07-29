USE [ChutHueManagement]
GO
/****** Object:  StoredProcedure [dbo].[FoodMenu_GetAll]    Script Date: 7/26/2016 8:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[FoodMenu_GetAll]
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
