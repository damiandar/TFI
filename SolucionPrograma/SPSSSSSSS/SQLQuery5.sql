USE [lavadero]
GO
/****** Object:  StoredProcedure [dbo].[Pedido_Update]    Script Date: 07/21/2017 11:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Pedido_Update]
 @pedido_id int,
 @pedido_estado tinyint,
 @FormaPago_id int,
 @FormaEnvio_id int,
 @Pedido_Notas varchar(50),
 @DomicilioEnvio_id int
as
update dal_pedido set 
estadopedido_ID=@pedido_estado,
FormaPago_id=@FormaPago_id, 
FormaEnvio_id=@FormaEnvio_id, 
Pedido_notas=@Pedido_Notas,
DomicilioEnvio_id=@DomicilioEnvio_id
where pedido_id=@pedido_id

