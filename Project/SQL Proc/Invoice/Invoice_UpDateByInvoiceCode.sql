USE [ChutHueManagement]
GO
/****** Object:  StoredProcedure [dbo].[Invoice_UpDate]    Script Date: 7/27/2016 6:07:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Invoice_UpDateByInvoiceCode]
@InvoiceCode nvarchar(15),
@IDTable int,
@DateTime DateTime,
@Note nvarchar(100)

AS
BEGIN
	Update Invoice 
	set 	
	IDTable = @IDTable,
	Invoice.DateTime = @DateTime,
	Note = @Note
	where InvoiceCode = @InvoiceCode
end
