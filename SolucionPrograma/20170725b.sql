


create procedure Categoria_Delete
@categoria_id int
as
delete Dal_SubCategoria where categoria_ID=@categoria_id 
delete Dal_Categoria where categoria_ID=@categoria_id
go

create procedure SubCategoria_Delete
@subcategoria_id int
as 
delete Dal_SubCategoria where subcategoria_ID=@subcategoria_id
go

