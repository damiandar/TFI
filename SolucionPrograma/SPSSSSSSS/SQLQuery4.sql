USE [lavadero]
GO
/****** Object:  StoredProcedure [dbo].[Pedido_Show]    Script Date: 07/21/2017 11:17:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[Pedido_Show]
  @cuenta_id int=null,
  @pedido_id int=null,
  @pedido_estado int=null
as
select * from Dal_Pedido ped
inner join Dal_Cuenta cuenta on ped.Cuenta_ID=cuenta.Cuenta_ID
inner join Dal_TipoResponsable resp on resp.TipoResponsable_ID=cuenta.TipoResponsable_ID
inner join Dal_Provincia prov on prov.provincia_codigo=cuenta.Provincia_Codigo
inner join Dal_FormaEnvio on Dal_FormaEnvio.FormaEnvio_id=ped.FormaEnvio_id
inner join Dal_DomicilioEnvio on Dal_DomicilioEnvio.DomicilioEnvio_id=ped.DomicilioEnvio_id 
inner join Dal_FormaPago on Dal_FormaPago.FormaPago_id=ped.FormaPago_id
where ped.Cuenta_ID=ISNULL(@cuenta_id,ped.Cuenta_id) and pedido_id=isnull(@pedido_id,pedido_id) and estadopedido_id=ISNULL(@pedido_estado,estadopedido_id)

