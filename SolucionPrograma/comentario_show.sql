USE [lavadero2]
GO
/****** Object:  StoredProcedure [dbo].[Comentario_Show]    Script Date: 23/07/2017 22:19:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Comentario_Show]
@producto_id int=null,
@comentario_id int=null
as
SELECT * from Dal_Comentario
  inner join dal_cuenta on dal_cuenta.Cuenta_ID=Dal_Comentario.Cliente_id
  where producto_id=isnull(@producto_id,producto_id) 
  and Comentario_id=ISNULL(@comentario_id,comentario_id)
  order by comentario_fecha