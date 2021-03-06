USE [lavadero]
GO
/****** Object:  StoredProcedure [dbo].[OrdenItem_Insert]    Script Date: 07/27/2017 08:53:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[OrdenItem_Insert] 
	-- Add the parameters for the stored procedure here
	@orden_id int,
	@insumo_id int,
	@itemorden_preciounitario Numeric(18,0),
	@itemorden_cantidadpedida int,
	@itemorden_cantidadfacturada int,
	@itemorden_cantidadEntregada int,
	@iva_id int
AS
BEGIN
	insert into Dal_Ordenitem(
	orden_id,
	insumo_id,
	estadoordenitem_id,
	itemorden_preciounitario,
	itemorden_cantidadpedida,
	itemorden_cantidadfacturada,
	itemorden_cantidadEntregada,
	iva_id) 
	values(@orden_id,
	@insumo_id ,1,
	@itemorden_preciounitario ,
	@itemorden_cantidadpedida ,	
	@itemorden_cantidadfacturada,	
	@itemorden_cantidadEntregada,
	@iva_id)
END 



select  * from dal_reposicionitem
select  * from dal_ordenitem