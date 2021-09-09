USE [lavadero2]
GO
/****** Object:  StoredProcedure [dbo].[Comentario_Update]    Script Date: 23/07/2017 22:10:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[Comentario_Update]
 @Comentario_positivo int,
@Comentario_negativo int,  
@comentario_puntaje int,
@comentario_id int 
as
update [dbo].[Dal_Comentario] set  
           Comentario_positivo=@Comentario_positivo,  
           Comentario_negativo =@Comentario_negativo,   
		   comentario_puntaje=@comentario_puntaje
		   where comentario_id=@comentario_id