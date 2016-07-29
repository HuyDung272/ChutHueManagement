USE [ChutHueManagement]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Invoice_UpDate]
@ID int,
@InvoiceCode nvarchar(15),
@IDTable int,
@DateTime DateTime,
@Note nvarchar(100)

AS
BEGIN
	Update Invoice 
	set 
	InvoiceCode = @InvoiceCode,
	IDTable = @IDTable,
	Invoice.DateTime = @DateTime,
	Note = @Note
	where ID = @ID
end