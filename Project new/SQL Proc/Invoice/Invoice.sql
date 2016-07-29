USE [ChutHueManagement]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROCEDURE [dbo].[Invoice_Insert]
@IDTable int,
@DateTime DateTime,
@Note nvarchar(100)
AS
BEGIN
	BEGIN TRY
		Declare @id int, @idy nvarchar(4), @InvoiceCode nvarchar(15);

		--set @NgayLapHoaDon = GETDATE();
		set @idy = CAST(YEAR(GETDATE()) as nvarchar(4));
		set @idy = SUBSTRING(@idy,2,len(@idy)-1); -- Nam hi?n t?i
		if((select top(1) Invoice.InvoiceCode from Invoice) is null)
		begin
			set @InvoiceCode = @idy + '-000000001';
		end
		else
		Begin
			Declare @year nvarchar(3); -- Nam cu?i cùng trong hóa don
			Set @year = (select top (1) SUBSTRING(InvoiceCode, 1, 3) from Invoice order by InvoiceCode desc);
			Set @id = (select top (1) cast(SUBSTRING(InvoiceCode,5,len(InvoiceCode)-4) as int) from Invoice order by InvoiceCode desc)+1;
			if(@idy <> @year)
			Begin
				set @InvoiceCode = @idy + '-000000001';
			End
			else
			Begin
				if(@id<10)
					begin
						set @InvoiceCode = @idy+'-00000000'+cast(@id as nvarchar(1));
					end
				else
				begin
					if(@id<100)
					begin
						set @InvoiceCode = @idy+'-0000000'+cast(@id as nvarchar(2));
					end
					else
					Begin
						if(@id<1000)
						begin
							set @InvoiceCode = @idy+'-000000'+cast(@id as nvarchar(3));
						end
						else
						Begin
							if(@id<10000)
							begin
								set @InvoiceCode = @idy+'-00000'+cast(@id as nvarchar(4));
							end
							else
							begin
								if(@id<100000)
								begin
									set @InvoiceCode = @idy+'-0000'+cast(@id as nvarchar(5));
								end
								else
								begin
									if(@id<1000000)
									begin
										set @InvoiceCode = @idy+'-000'+cast(@id as nvarchar(6));
									end
									else
									begin
										set @InvoiceCode = @idy+'-00'+cast(@id as nvarchar(7));
									end
								end
							end
						End
					End
				end
			End
		End
		Set @DateTime = CURRENT_TIMESTAMP
		INSERT INTO Invoice
		VALUES 
		(
			@InvoiceCode, @IDTable, @DateTime, @Note
		)
		Return @@IDENTITY
	END Try
	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(2000)
		SELECT @ErrorMessage = 'Error: ' + ERROR_MESSAGE()
		RAISERROR(@ErrorMessage, 16, 1)
	END CATCH
	
	
end

