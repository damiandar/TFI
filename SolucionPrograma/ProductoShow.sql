USE [lavadero]
GO
/****** Object:  StoredProcedure [dbo].[Producto_Show]    Script Date: 07/19/2017 09:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[Producto_Show]
@producto_id int =null,
@producto_descripcion varchar(50)=null,
@producto_codigointerno varchar(50)=null,
@producto_estado bit=null,
@producto_detalle varchar(150)=null,
@categoria_id int=null,
@SubCategoria_id int=null
as

 select * from   dal_producto  
inner join Dal_SubCategoria on Dal_SubCategoria.SubCategoria_id=Dal_Producto.SubCategoria_Id
inner join Dal_Categoria on Dal_SubCategoria.Categoria_id=Dal_Categoria.categoria_ID  
inner join Dal_ProductoPrecio on Dal_Producto.Producto_id=Dal_ProductoPrecio.Producto_id  
inner join Dal_ProductoListaPrecio  on Dal_ProductoListaPrecio.ProductoListaPrecio_id=Dal_ProductoPrecio.productolistaprecio_id and Dal_ProductoListaPrecio.ProductoListaPrecio_activa=1
inner join DAL_IVA on Dal_ProductoPrecio.IVA_id=DAL_IVA.IVA_id
where  Dal_Categoria.categoria_ID=ISNULL(@categoria_ID,Dal_Categoria.categoria_ID)
and Dal_SubCategoria.SubCategoria_id=isnull(@SubCategoria_id,Dal_SubCategoria.SubCategoria_id)
and Dal_Producto.Producto_ID=ISNULL(@producto_id,Dal_Producto.Producto_ID) 
and (Producto_NombreCorto like  '%' + IsNull( @producto_descripcion,Producto_NombreCorto) + '%'   or
 Producto_NombreLargo like '%' + IsNull(@producto_descripcion,Producto_NombreLargo) +'%'   or
 Producto_Descripcion like  '%' + IsNull(@producto_descripcion,Producto_Descripcion) + '%'     )


  

