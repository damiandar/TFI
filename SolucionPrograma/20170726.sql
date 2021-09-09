USE [lavadero]
GO
/****** Object:  StoredProcedure [dbo].[Orden_Insert]    Script Date: 07/26/2017 15:13:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Orden_Insert]
@orden_notas varchar(50),
@orden_fechaCarga datetime=null,
@Orden_Estado int=null,
@proveedor_id int,
@pedidoreposicion_id int
as
INSERT INTO [dbo].[Dal_Orden]
           (Orden_FechaCarga,Orden_Estado,proveedor_id,orden_notas,pedidoreposicion_id)
     VALUES
           (@orden_fechaCarga,@Orden_Estado,@proveedor_id,@orden_notas,@pedidoreposicion_id);select @@IDENTITY

