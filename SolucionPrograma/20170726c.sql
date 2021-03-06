USE [lavadero2]
GO
/****** Object:  StoredProcedure [dbo].[Remito_Show]    Script Date: 26/07/2017 23:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Remito_Show]
@remito_nro int=null,
@remito_id int=null,
@proveedor_id int=null,
@orden_id int=null
as
select * from dal_remito  
inner join Dal_orden ord on ord.orden_id=dal_remito.orden_id
inner join Dal_Proveedor cuenta on ord.proveedor_id=cuenta.Proveedor_ID
inner join Dal_TipoResponsable tipo on tipo.TipoResponsable_ID=cuenta.TipoResponsable_ID
inner join Dal_Provincia prov on prov.provincia_codigo=cuenta.Provincia_Codigo
where remito_id=isnull(@remito_id,remito_id) and remito_nro=isnull(@remito_nro,remito_nro)
and ord.orden_id=isnull(@orden_id,ord.orden_id)


select * from Dal_Orden