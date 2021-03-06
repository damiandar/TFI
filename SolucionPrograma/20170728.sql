USE [lavadero]
GO
/****** Object:  StoredProcedure [dbo].[Cotizacion_Show]    Script Date: 07/28/2017 09:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[Cotizacion_Show]
	@PedidoReposicion_id [int]=null,
	@Producto_id [int]=null,
	@Cuenta_ID [int]=null
	as
select * from  Dal_Cotizacion coti 
inner join Dal_Producto prod on prod.Producto_ID=coti.Producto_id
inner join Dal_Proveedor proveedor on coti.proveedor_ID=proveedor.proveedor_ID
inner join dal_iva on dal_iva.iva_id=coti.iva_id
where coti.Producto_id=isnull(@Producto_id,coti.Producto_id)
and coti.proveedor_ID=ISNULL(@Cuenta_ID,coti.proveedor_ID)
and PedidoReposicion_id=ISNULL(@PedidoReposicion_id,PedidoReposicion_id)

create PROCEDURE [dbo].[OrdenItem_Update] 
	-- Add the parameters for the stored procedure here
	@orden_id int,
	@insumo_id int,
	@itemorden_preciounitario Numeric(18,0),
	@itemorden_cantidadpedida int,
	@itemorden_cantidadfacturada int,
	@itemorden_cantidadEntregada int,
	@estadoordenitem_id  int,
	@iva_id int
AS
BEGIN
	update Dal_Ordenitem set 	
	estadoordenitem_id=@estadoordenitem_id ,
	itemorden_preciounitario=@itemorden_preciounitario ,
	itemorden_cantidadpedida=@itemorden_cantidadpedida ,	
	itemorden_cantidadfacturada=@itemorden_cantidadfacturada,
	itemorden_cantidadEntregada=@itemorden_cantidadEntregada,
	iva_id=@iva_id
	where orden_id=@orden_id and insumo_id=@insumo_id 
 END
 
 

ALTER procedure [dbo].[Remito_Insert]
@remito_nro int,
@remito_fecha datetime, 
@remito_recepciono varchar(100),
@remito_fechacarga datetime, 
@orden_id int ,
@remito_notas varchar(150) 
as
insert into 
dal_remito (remito_nro   ,remito_fecha ,remito_recepciono  ,remito_fechacarga  ,orden_id, remito_notas )
values     (@remito_nro ,@remito_fecha ,@remito_recepciono ,getdate(),@orden_id,@remito_notas );select @@IDENTITY
go


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
 