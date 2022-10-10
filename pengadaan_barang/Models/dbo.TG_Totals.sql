Create trigger [dbo].[TG_Totals]
on [dbo].[pengadaan]
	after insert, update

as
begin
	declare @productid int, @harga int, @quantitas int, @totals int, @idpengadaan int
	set nocount on;

	select @idpengadaan = id, @productid = idBarang , @quantitas = kuantitas  from inserted
	select @harga = hargaProduct from Product where id = @productid;

	update pengadaan
	set totals =  @harga* @quantitas where id= @idpengadaan;

end