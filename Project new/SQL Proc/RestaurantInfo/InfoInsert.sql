USE [ChutHueManagement]
GO

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
