USE [lavadero]
GO
/****** Object:  StoredProcedure [dbo].[Remito_Insert]    Script Date: 07/26/2017 16:21:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
values     (@remito_nro ,@remito_fecha ,@remito_recepciono ,@remito_fechacarga ,@orden_id,@remito_notas );select @@IDENTITY


select * from dal_remito