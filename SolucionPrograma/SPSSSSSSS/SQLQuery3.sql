USE [lavadero]
GO
/****** Object:  StoredProcedure [dbo].[Pedido_Insert]    Script Date: 07/21/2017 11:16:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Pedido_Insert]
 @Pedido_fechacreacion datetime,
 @pedido_estado tinyint,
 @cuenta_id int,
 @FormaPago_id int,
 @FormaEnvio_id int,
 @Pedido_Notas varchar(50),
 @DomicilioEnvio_id int
as
insert into dal_pedido(Pedido_fechacreacion,estadopedido_id,cuenta_id,FormaPago_id, FormaEnvio_id, Pedido_Notas, DomicilioEnvio_id ) values(@Pedido_fechacreacion,@pedido_estado,@cuenta_id,@FormaPago_id, @FormaEnvio_id, @Pedido_Notas,@DomicilioEnvio_id );select @@IDENTITY

