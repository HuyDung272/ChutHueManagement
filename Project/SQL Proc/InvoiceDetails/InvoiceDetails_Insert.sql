USE [ChutHueManagement]
GO

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
