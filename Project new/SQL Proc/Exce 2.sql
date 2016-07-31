Declare @Start datetime
Declare @End datetime

Set @Start = '07/30/2016'
Set @End = '08/03/2016'

exec [Invoice_GetSalesWithFoodForFoodByDateTime] 3,3,@Start, @End