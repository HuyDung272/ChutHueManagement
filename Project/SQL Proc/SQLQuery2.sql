USE [ChutHueManagement]
GO

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
