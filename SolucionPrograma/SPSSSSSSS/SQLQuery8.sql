USE [lavadero]
GO
/****** Object:  StoredProcedure [dbo].[DomicilioEnvio_Show]    Script Date: 07/21/2017 13:51:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[DomicilioEnvio_Show]
 @DomicilioEnvio_id int,
 @Cuenta_ID int,
 @pedido_id int
 as
SELECT  Dal_DomicilioEnvio.DomicilioEnvio_id 
      ,[DomicilioEnvio_Localidad]
      ,[DomicilioEnvio_CP]
      ,[DomicilioEnvio_Telefono]
      ,dal_provincia.[provincia_codigo]
      ,Dal_DomicilioEnvio.Cuenta_ID 
      ,[DomicilioEnvio_Direccion]
      ,provincia_nombre
  FROM [Dal_DomicilioEnvio]  
  inner join dal_provincia on [Dal_DomicilioEnvio].provincia_codigo=dal_provincia.provincia_codigo
  inner join dal_pedido on dal_pedido.domicilioenvio_id=dal_domicilioenvio.domicilioenvio_id
  where dal_domicilioenvio.DomicilioEnvio_id=isnull(@DomicilioEnvio_id,dal_domicilioenvio.DomicilioEnvio_id)
  and dal_pedido.pedido_id=isnull(@pedido_id,dal_pedido.pedido_id) 
  and Dal_DomicilioEnvio.Cuenta_ID=isnull(@Cuenta_ID,Dal_DomicilioEnvio.Cuenta_ID)



select * from dal_pedido


update dal_pedido set domicilioenvio_id=4 where pedido_id=9