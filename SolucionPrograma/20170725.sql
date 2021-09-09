 

alter procedure ProductoListaPrecio_Activar
@productolistaprecio_id int
as
update dal_productolistaprecio set productolistaprecio_activa=0
update dal_productolistaprecio set productolistaprecio_activa=1,productolistaprecio_fechavigencia=getdate() where productolistaprecio_id=@productolistaprecio_id
go

create procedure Categoria_Insert
@categoria_descripcion varchar(50),
@catalogotipo_id int
as
insert into dal_categoria values(@categoria_descripcion,@catalogotipo_id)
go

create procedure SubCategoria_Insert
@categoria_id int,
@subcategoria_detalle varchar(50)
as
insert into dal_subcategoria values(@subcategoria_detalle,@categoria_id)
go
 