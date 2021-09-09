
alter procedure [dbo].[Producto_Update]
@producto_id int=null,
@mimetype varchar(50)=null,
@imagedata varbinary(max)=null,
@producto_codigointerno varchar(50)=null, 
@producto_NombreCorto varchar(50)=null,
@producto_NombreLargo varchar(50)=null,
@producto_Descripcion varchar(50)=null,
@producto_Estado bit=1,
@producto_destacado bit=1,
@SubCategoria_Id int=null
as
			
Update [dbo].[Dal_Producto] set 
MimeType=isnull(@mimetype,mimetype),
imagedata=isnull(@imagedata,imagedata),
producto_CodigoInterno=@producto_codigointerno,
producto_NombreCorto=@producto_NombreCorto,
producto_NombreLargo=@producto_NombreLargo,
producto_Descripcion=@producto_Descripcion,
producto_Estado=@producto_Estado ,
SubCategoria_Id=@SubCategoria_Id 
where producto_id=@producto_id

go


create procedure [dbo].[PedidoItem_Update]
 @Pedido_id int,
 @producto_id int,
 @pedidoitem_cantidad int
as
update Dal_PedidoItem set
pedidoitem_cantidad=@pedidoitem_cantidad 
where pedido_id=@Pedido_id and producto_id=@producto_id
go