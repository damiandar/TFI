USE [lavadero2]
GO
/****** Object:  StoredProcedure [dbo].[Comentario_Insert]    Script Date: 23/07/2017 22:05:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Comentario_Insert]
@Producto_id int,
@Comentario_titulo varchar(50),
@Comentario_descripcion varchar(50),
@Comentario_positivo int,
@Comentario_negativo int,
@Comentario_por varchar(50),
@comentario_fecha datetime,
@comentario_puntaje int,
@cliente_id int
as
INSERT INTO [dbo].[Dal_Comentario]
           (Producto_id
           ,Comentario_titulo
           ,Comentario_descripcion
           ,Comentario_positivo
           ,Comentario_negativo
           ,Comentario_por
		   ,comentario_fecha,comentario_puntaje,Cliente_id)
     VALUES
           (@Producto_id ,
            @Comentario_titulo,  
            @Comentario_descripcion, 
            @Comentario_positivo,  
            @Comentario_negativo, 
            @Comentario_por,
			@comentario_fecha,@comentario_puntaje,@cliente_id)
