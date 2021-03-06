USE [lavadero2]
GO
/****** Object:  StoredProcedure [dbo].[Categoria_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Categoria_Show]
@CatalogoTipo_id int
as
select * from Dal_Categoria where CatalogoTipo_id=@CatalogoTipo_id

GO
/****** Object:  StoredProcedure [dbo].[Comentario_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Comentario_Insert]
@Producto_id int,
@Comentario_titulo varchar(50),
@Comentario_descripcion varchar(50),
@Comentario_positivo int,
@Comentario_negativo int,
@Comentario_por varchar(50),
@comentario_fecha datetime,
@comentario_puntaje int
as
INSERT INTO [dbo].[Dal_Comentario]
           (Producto_id
           ,Comentario_titulo
           ,Comentario_descripcion
           ,Comentario_positivo
           ,Comentario_negativo
           ,Comentario_por
		   ,comentario_fecha,comentario_puntaje)
     VALUES
           (@Producto_id ,
            @Comentario_titulo,  
            @Comentario_descripcion, 
            @Comentario_positivo,  
            @Comentario_negativo, 
            @Comentario_por,
			@comentario_fecha,@comentario_puntaje)

GO
/****** Object:  StoredProcedure [dbo].[Comentario_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Comentario_Show]
@producto_id int=null
as
SELECT [Producto_id]
      ,[Comentario_id]
      ,[Comentario_titulo]
      ,[Comentario_descripcion]
      ,[Comentario_positivo]
      ,[Comentario_negativo]
      ,[Comentario_por]
	  ,[Comentario_fecha]
	  ,[Comentario_puntaje]
  FROM [dbo].[Dal_Comentario]
  where producto_id=isnull(@producto_id,producto_id)
  order by comentario_fecha

GO
/****** Object:  StoredProcedure [dbo].[Comprobante_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Comprobante_Insert]
@Comprobante_fechaCarga datetime=null,
@Cuenta_ID int=null,
@ComprobanteTipo_id int=null
as
INSERT INTO [dbo].[Dal_Comprobante]
           (Comprobante_fechaCarga,[Cuenta_ID],[ComprobanteTipo_id])
     VALUES
           (@Comprobante_fechaCarga,@Cuenta_ID,@ComprobanteTipo_id);select @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[Comprobante_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Comprobante_Show]
@Comprobante_ID int=null,
@Comprobante_nro bigint=null,
@Cuenta_ID int=null,
@ComprobanteTipo_id int=null
as
select * from Dal_Comprobante comp 
inner join Dal_ComprobanteTipo tipo on comp.ComprobanteTipo_id=tipo.ComprobanteTipo_id
inner join Dal_Cuenta cuenta on cuenta.cuenta_id=comp.Cuenta_ID
where comp.Comprobante_ID=isnull(@Comprobante_ID,comp.Comprobante_ID) 
and comp.Cuenta_ID=isnull(@Cuenta_ID,comp.Cuenta_ID)
and comp.ComprobanteTipo_id=isnull(@ComprobanteTipo_id,comp.ComprobanteTipo_id)

GO
/****** Object:  StoredProcedure [dbo].[Comprobante_Update]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Comprobante_Update]
@Comprobante_ID int,
@Comprobante_fecha datetime,
@Comprobante_nro bigint,
@Comprobante_letra char(1),
@Comprobante_ptoventa smallint,
@Cuenta_ID int,
@ComprobanteTipo_id int
as
UPDATE [Lavadero].[dbo].[Dal_Comprobante]
   SET 
      [Comprobante_fecha] = @Comprobante_fecha, 
      [Comprobante_nro] = @Comprobante_nro, 
      [Comprobante_letra] = @Comprobante_letra, 
      [Comprobante_ptoventa] = @Comprobante_ptoventa ,
      [Cuenta_ID] = @Cuenta_ID, 
	  [ComprobanteTipo_id] = @ComprobanteTipo_id 
 WHERE  [Comprobante_ID] = @Comprobante_ID

GO
/****** Object:  StoredProcedure [dbo].[ComprobanteItem_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ComprobanteItem_Insert] 
	-- Add the parameters for the stored procedure here
	@comprobante_id int,
	@producto_id int,
	@comprobanteitem_preciounitario Numeric(18,0),
	@comprobanteitem_cantidad int,
	@comprobanteitem_cantidadfacturada int,
	@iva_id int
AS
BEGIN
	insert into Dal_ComprobanteItem values(	@comprobante_id,	@producto_id ,	@comprobanteitem_preciounitario ,	@comprobanteitem_cantidad ,	@comprobanteitem_cantidadfacturada,	@iva_id)
END

GO
/****** Object:  StoredProcedure [dbo].[ComprobanteItem_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ComprobanteItem_Show] 
	-- Add the parameters for the stored procedure here
	@comprobante_id int=null,
	@producto_id int=null
AS

select * from Dal_ComprobanteItem item
inner join Dal_Producto prod on item.Producto_id=prod.Producto_ID
inner join dal_iva iva on item.iva_id=iva.IVA_id
where comprobante_id=isnull(@comprobante_id,Comprobante_ID)
and	item.producto_id=isnull(@producto_id,item.Producto_id)

GO
/****** Object:  StoredProcedure [dbo].[Contrato_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Contrato_Insert]
	@Cuenta_id int,
	@Servicio_id int,
	@bonificado bit,
    @DiasDeCorte int,
	@Eventual bit,
	@FechaFinalizado datetime,
	@FechaFirmado datetime,
	@MesesVigencia int
	as
	insert into Dal_Contrato values(@Cuenta_id ,@Servicio_id  ,	@bonificado  ,@DiasDeCorte ,@Eventual,@FechaFinalizado ,	@FechaFirmado ,@MesesVigencia)

GO
/****** Object:  StoredProcedure [dbo].[Contrato_show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Contrato_show] 
		@contrato_id int=null,
		@cuenta_id	int=null,
		@servicio_id int=null 
as

--SELECT [contrato_id]      ,[cuenta_id]      ,[servicio_id]      ,[contrato_bonificado]      ,[contrato_diasdecorte]      ,[contrato_eventual]      ,[contrato_fechaFinalizacion]      ,[contrato_fechaFirmado]      ,[contrato_mesesvigencia] 
select * FROM [Lavadero].[dbo].[Dal_Contrato] contrato
inner join Dal_Cuenta cuenta on cuenta.Cuenta_ID=contrato.cuenta_id
inner join Dal_Servicio serv on serv.servicio_ID=contrato.servicio_id

GO
/****** Object:  StoredProcedure [dbo].[Contrato_Update]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Contrato_Update]
	@Cuenta_id int,
	@Servicio_id int,
	@bonificado bit,
    @DiasDeCorte int,
	@Eventual bit,
	@FechaFinalizado datetime,
	@FechaFirmado datetime,
	@MesesVigencia int
	as
	
UPDATE [Lavadero].[dbo].[Dal_Contrato]
   SET [contrato_bonificado] = @bonificado,
       [contrato_diasdecorte] = @DiasDeCorte,

       [contrato_fechaFinalizacion] =@FechaFinalizado,
       [contrato_fechaFirmado] = @FechaFirmado,
       [contrato_mesesvigencia] = @MesesVigencia 
 WHERE [cuenta_id] = @Cuenta_id and
       [servicio_id] = @Servicio_id

GO
/****** Object:  StoredProcedure [dbo].[Cotizacion_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Cotizacion_Insert]
	@PedidoReposicion_id [int],
	@Producto_id [int],
	@Cuenta_ID [int],
	@Cotizacion_PlazoEntregaDias [int] ,
	@Cotizacion_PlazoPagoDias [int],
	@Cotizacion_FechaHasta [datetime] ,
	@Cotizacion_Descuento [int] ,
	@Cotizacion_ValorUnitario numeric(18, 0) ,
	@IVA_id [int] ,
	@Cotizacion_GarantiaDias [int] ,
	@Cotizacion_Estado  [int]
	as
	insert into Dal_Cotizacion values(@PedidoReposicion_id  ,
	@Producto_id  ,
	@Cuenta_ID  ,
	@Cotizacion_PlazoEntregaDias ,
	@Cotizacion_PlazoPagoDias  ,
	@Cotizacion_FechaHasta  ,
	@Cotizacion_Descuento  ,
	@Cotizacion_ValorUnitario  ,
	@IVA_id   ,
	@Cotizacion_GarantiaDias  ,
	@Cotizacion_Estado)

GO
/****** Object:  StoredProcedure [dbo].[Cotizacion_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Cotizacion_Show]
	@PedidoReposicion_id [int]=null,
	@Producto_id [int]=null,
	@Cuenta_ID [int]=null
	as
select * from  Dal_Cotizacion coti 
inner join Dal_Producto prod on prod.Producto_ID=coti.Producto_id
inner join Dal_Proveedor proveedor on coti.proveedor_ID=proveedor.proveedor_ID
where coti.Producto_id=isnull(@Producto_id,coti.Producto_id)
and coti.proveedor_ID=ISNULL(@Cuenta_ID,coti.proveedor_ID)
and PedidoReposicion_id=ISNULL(@PedidoReposicion_id,PedidoReposicion_id)

GO
/****** Object:  StoredProcedure [dbo].[Cuenta_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Cuenta_Insert]
		@cuenta_RazonSocial  char(50), 
        @Cuenta_DomicilioLegal  char(50), 
        @Cuenta_Telefono  char(50), 
        @Cuenta_Mail  char(50), 
        @Cuenta_Web  varchar(50), 
        @Cuenta_Contacto  varchar(50), 
        @Cuenta_Localidad  char(50), 
        @Cuenta_CP  varchar(8), 
        @Provincia_Codigo  int, 
        @Cuenta_CUIT  varchar(11), 
        @Cuenta_Estado  bit, 
        @CuentaTipo_id  int, 
        @TipoResponsable_ID int 
as

INSERT INTO  [dbo].[Dal_Cuenta]
           ([Cuenta_RazonSocial]
           ,[Cuenta_DomicilioLegal]
           ,[Cuenta_Telefono]
           ,[Cuenta_Mail]
           ,[Cuenta_Web]
           ,[Cuenta_Contacto]
           ,[Cuenta_Localidad]
           ,[Cuenta_CP]
           ,[Provincia_Codigo]
           ,[Cuenta_CUIT]
           ,[Cuenta_Estado]
           ,[TipoResponsable_ID])
     VALUES (@cuenta_RazonSocial,
           @Cuenta_DomicilioLegal, 
           @Cuenta_Telefono, 
           @Cuenta_Mail,  
           @Cuenta_Web,  
           @Cuenta_Contacto,  
           @Cuenta_Localidad,  
           @Cuenta_CP, 
           @Provincia_Codigo, 
           @Cuenta_CUIT,  
           @Cuenta_Estado, 
		   @TipoResponsable_ID )
GO
/****** Object:  StoredProcedure [dbo].[Cuenta_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Cuenta_Show]
		@cuenta_id int=null,
		@cuenta_RazonSocial  char(50)=null, 
        @Cuenta_DomicilioLegal  char(50)=null, 
        @Cuenta_Telefono  char(50)=null, 
        @Cuenta_Mail  char(50)=null, 
        @Cuenta_Web  varchar(50)=null, 
        @Cuenta_Contacto  varchar(50)=null, 
        @Cuenta_Localidad  char(50)=null, 
        @Cuenta_CP  varchar(8)=null, 
        @Provincia_Codigo  int=null, 
        @Cuenta_CUIT  varchar(11)=null, 
        @Cuenta_Estado  bit=null, 
        @CuentaTipo_id  int=null, 
        @TipoResponsable_ID int=null 
as

select * from Dal_Cuenta cuenta 
--inner join Dal_CuentaTipo tipo on tipo.CuentaTipo_id=cuenta.CuentaTipo_id 
inner join Dal_Provincia provincia on provincia.provincia_codigo=cuenta.Provincia_Codigo
inner join Dal_TipoResponsable responsabilidad on responsabilidad.TipoResponsable_ID=cuenta.TipoResponsable_ID
where Cuenta_CUIT=isnull(@Cuenta_CUIT,Cuenta_CUIT)  and Cuenta_ID=ISNULL(@cuenta_id,cuenta_id)
GO
/****** Object:  StoredProcedure [dbo].[Cuenta_Update]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Cuenta_Update]
		@Cuenta_id int,
		@Cuenta_RazonSocial  char(50), 
        @Cuenta_DomicilioLegal  char(50), 
        @Cuenta_Telefono  char(50), 
        @Cuenta_Mail  char(50), 
        @Cuenta_Web  varchar(50), 
        @Cuenta_Contacto  varchar(50), 
        @Cuenta_Localidad  char(50), 
        @Cuenta_CP  varchar(8), 
        @Provincia_Codigo  int, 
        @Cuenta_CUIT  varchar(11), 
        @Cuenta_Estado  bit, 
        @CuentaTipo_id  int, 
        @TipoResponsable_ID int 
as
UPDATE [Lavadero].[dbo].[Dal_Cuenta]
   SET [Cuenta_RazonSocial] = @Cuenta_RazonSocial,  
      [Cuenta_DomicilioLegal] =@Cuenta_DomicilioLegal,  
      [Cuenta_Telefono] = @Cuenta_Telefono,  
      [Cuenta_Mail] = @Cuenta_Mail,  
      [Cuenta_Web] = @Cuenta_Web,  
      [Cuenta_Contacto] = @Cuenta_Contacto, 
      [Cuenta_Localidad] = @Cuenta_Localidad,  
      [Cuenta_CP] = @Cuenta_CP,  
      [Provincia_Codigo] = @Provincia_Codigo,  
      [Cuenta_CUIT] = @Cuenta_CUIT,  
      [Cuenta_Estado] = @Cuenta_Estado,  
      [CuentaTipo_id] = @CuentaTipo_id, 
      [TipoResponsable_ID] = @TipoResponsable_ID 
 WHERE cuenta_id=@cuenta_id

GO
/****** Object:  StoredProcedure [dbo].[CuentaLogin_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[CuentaLogin_Show]
@login varchar(50)
as
select * from Dal_Cuenta where  Cuenta_Mail =@login

GO
/****** Object:  StoredProcedure [dbo].[Encuesta_Ins]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Encuesta_Ins]
@encuesta_descripcion varchar(50)
as
insert into Dal_Encuesta (encuesta_descripcion) values(@encuesta_descripcion);select @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[Encuesta_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Encuesta_Insert]
@encuesta_descripcion varchar(50)
as
insert into Dal_Encuesta (encuesta_descripcion) values(@encuesta_descripcion);select @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[Encuesta_Mostrar_Pendientes]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Encuesta_Mostrar_Pendientes]
@login varchar(50)
as
select * from dal_encuesta left join dal_encuestavoto 
on dal_encuestavoto.encuesta_id=dal_encuesta.encuesta_id
where login<>@login or login is null

GO
/****** Object:  StoredProcedure [dbo].[Encuesta_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Encuesta_Show]
@encuesta_id int=null
as
select * from Dal_Encuesta where encuesta_id=isnull(@encuesta_id,encuesta_id)

GO
/****** Object:  StoredProcedure [dbo].[EncuestaDetalle_Ins]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EncuestaDetalle_Ins]
@encuestadetalle_descripcion varchar(50),
@encuesta_id int
as
insert into Dal_EncuestaDetalle (encuesta_id, encuestadetalle_descripcion) values(@encuesta_id, @encuestadetalle_descripcion)

GO
/****** Object:  StoredProcedure [dbo].[EncuestaDetalle_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EncuestaDetalle_Insert]
@encuestadetalle_descripcion varchar(50),
@encuesta_id int
as
insert into Dal_EncuestaDetalle (encuesta_id, encuestadetalle_descripcion) values(@encuesta_id, @encuestadetalle_descripcion)

GO
/****** Object:  StoredProcedure [dbo].[EncuestaDetalle_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EncuestaDetalle_Show]
@encuesta_id int
as
select * from dal_encuestadetalle where encuesta_id=@encuesta_id

GO
/****** Object:  StoredProcedure [dbo].[EncuestaVoto_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure	 [dbo].[EncuestaVoto_Insert]
		@login nvarchar(50),
		@encuesta_id int,
		@encuestadetalle_id int,
		@encuestavoto_comentario varchar(50)
		as
		insert into dal_encuestavoto (Login,encuesta_id,encuestadetalle_id,encuestavoto_comentario) values(@login,@encuesta_id,@encuestadetalle_id,@encuestavoto_comentario)

GO
/****** Object:  StoredProcedure [dbo].[EstadisticaEncuesta_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EstadisticaEncuesta_Show]
@encuesta_id int=0
as
select  det.encuestadetalle_id,det.encuestadetalle_descripcion, count( login)  as valor 
 from  dal_encuestadetalle det 
inner join dal_encuesta enc on det.encuesta_id=enc.encuesta_id 
left join dal_encuestavoto voto on voto.encuestadetalle_id=det.encuestadetalle_id
where enc.encuesta_id=@encuesta_id
group by  det.encuestadetalle_id,det.encuestadetalle_descripcion

GO
/****** Object:  StoredProcedure [dbo].[Factura_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[Factura_Insert]
@comprobante_id int,
@factura_fecha datetime,
@factura_nro int,
@factura_letra char(3)='A',
@factura_ptoventa smallint=0,
@factura_cai varchar(20),
@factura_cae varchar(20)
as
INSERT INTO [dbo].[Dal_Factura]
			(comprobante_id,
           [factura_fecha],
		   [factura_nro],
           [factura_letra],
           [factura_ptoventa],
		   factura_cai,
		   factura_cae)
     VALUES
           (@comprobante_id,
		   @factura_fecha,
		   @factura_nro, 
		   @factura_letra ,
		   @factura_ptoventa,
		   @factura_cai,
		   @factura_cae)

GO
/****** Object:  StoredProcedure [dbo].[FormaEnvio_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[FormaEnvio_Show]
as

SELECT [FormaEnvio_id]
      ,[FormaEnvio_descripcion]
  FROM [dbo].[Dal_FormaEnvio]

GO
/****** Object:  StoredProcedure [dbo].[Insumo_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insumo_Insert]
@Insumo_id int =null,
@SubCategoria_id int=null, 
@insumo_NombreCorto varchar(50)=null,
@insumo_NombreLargo varchar(50)=null,
@insumo_Descripcion varchar(50)=null,
@insumo_Estado bit=1,
@insumo_StockMin int,
@insumo_StockMax int,
@insumo_StockActual int=null
as


insert into dal_insumo(insumo_StockMin,insumo_StockMax,insumo_StockActual,SubCategoria_id,insumo_NombreCorto,insumo_NombreLargo,insumo_Descripcion,insumo_Estado )
values(@insumo_StockMin,@insumo_StockMax,@insumo_StockActual,@SubCategoria_id,@insumo_NombreCorto,@insumo_NombreLargo,@insumo_Descripcion,@insumo_Estado )

GO
/****** Object:  StoredProcedure [dbo].[insumo_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[insumo_Show]
@insumo_id int =null,
@insumo_descripcion varchar(50)=null, 
@insumo_estado bit=null,
@insumo_detalle varchar(150)=null,
@categoria_id int=null,
@SubCategoria_id int=null
as
select * from   dal_insumo  
inner join Dal_SubCategoria on Dal_SubCategoria.SubCategoria_id=Dal_insumo.SubCategoria_Id
inner join Dal_Categoria on Dal_SubCategoria.Categoria_id=Dal_Categoria.categoria_ID  
--inner join Dal_Stock on Dal_Stock.insumo_id=Dal_Insumo.Insumo_id
where  Dal_Categoria.categoria_ID=ISNULL(@categoria_ID,Dal_Categoria.categoria_ID)
and Dal_SubCategoria.SubCategoria_id=isnull(@SubCategoria_id,Dal_SubCategoria.SubCategoria_id)
and Dal_insumo.insumo_ID=ISNULL(@insumo_id,Dal_insumo.insumo_ID)

GO
/****** Object:  StoredProcedure [dbo].[Insumo_Update]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Insumo_Update]
@Insumo_id int =null,
@SubCategoria_id int=null, 
@insumo_NombreCorto varchar(50)=null,
@insumo_NombreLargo varchar(50)=null,
@insumo_Descripcion varchar(50)=null,
@insumo_Estado bit=1,
@insumo_StockMin int,
@insumo_StockMax int,
@insumo_StockActual int=null
as


update dal_insumo set 
insumo_StockMin=@insumo_StockMin,
insumo_StockMax=@insumo_StockMax,
insumo_StockActual=@insumo_StockActual,
SubCategoria_id=@SubCategoria_id,
insumo_NombreCorto=@insumo_NombreCorto,
insumo_NombreLargo=@insumo_NombreLargo,
insumo_Descripcion=@insumo_Descripcion,
insumo_Estado=@insumo_Estado 
where insumo_id=@insumo_id
GO
/****** Object:  StoredProcedure [dbo].[MostrarNroComprobante]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MostrarNroComprobante]  
@comprobantetipo_id int,
@comprobante_letra char(3)
as
select isnull(MAX(comprobante_nro),0) + 1 from Dal_Comprobante where ComprobanteTipo_id=@comprobantetipo_id and Comprobante_letra=@comprobante_letra

GO
/****** Object:  StoredProcedure [dbo].[Orden_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Orden_Insert]
@orden_notas varchar(50),
@orden_fechaCarga datetime=null,
@Orden_Estado int=null,
@proveedor_id int
as
INSERT INTO [dbo].[Dal_Orden]
           (Orden_FechaCarga,Orden_Estado,proveedor_id,orden_notas)
     VALUES
           (@orden_fechaCarga,@Orden_Estado,@proveedor_id,@orden_notas);select @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[Orden_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Orden_Show]
@orden_ID int=null, 
@proveedor_ID int=null 
as
select * from Dal_Orden comp  
inner join Dal_Proveedor cuenta on cuenta.Proveedor_ID=comp.Proveedor_id
where comp.Orden_ID=isnull(@orden_ID,comp.orden_ID) 
and comp.Proveedor_id=isnull(@proveedor_ID,comp.Proveedor_id)

GO
/****** Object:  StoredProcedure [dbo].[OrdenItem_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrdenItem_Insert] 
	-- Add the parameters for the stored procedure here
	@orden_id int,
	@insumo_id int,
	@itemorden_preciounitario Numeric(18,0),
	@itemorden_cantidadpedida int,
	@itemorden_cantidadfacturada int,
	@iva_id int
AS
BEGIN
	insert into Dal_Ordenitem(orden_id,insumo_id,estadoordenitem_id,itemorden_preciounitario,itemorden_cantidadpedida,itemorden_cantidadfacturada,iva_id) 
						values(@orden_id,@insumo_id ,1,@itemorden_preciounitario ,@itemorden_cantidadpedida ,	@itemorden_cantidadfacturada,	@iva_id)
END

GO
/****** Object:  StoredProcedure [dbo].[OrdenItem_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[OrdenItem_Show] 
	-- Add the parameters for the stored procedure here
	@orden_id int=null,
	@insumo_id int=null
AS

select * from Dal_ordenItem item
inner join Dal_Insumo prod on item.insumo_id=prod.insumo_ID
inner join dal_iva iva on item.iva_id=iva.IVA_id
where orden_id=isnull(@orden_id,orden_ID)
and	item.insumo_id=isnull(@insumo_id,item.insumo_id)

GO
/****** Object:  StoredProcedure [dbo].[Pago_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Pago_Insert]
@comprobante_id int,
@pago_fecha datetime,
@pago_concepto varchar(20),
@formapago_id int
as
insert into Dal_Pago (comprobante_id  ,
pago_fecha  ,
pago_concepto  ,
formapago_id)
values(
@comprobante_id  ,
@pago_fecha  ,
@pago_concepto  ,
@formapago_id)

GO
/****** Object:  StoredProcedure [dbo].[Pago_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Pago_Show]
@cuenta_id int=null,
@pago_id int =null,
@formapago_id int=null 
as
select * from Dal_pago pago 
inner join Dal_Cuenta cuenta on cuenta.cuenta_id=pago.Cuenta_ID 
inner join Dal_FormaPago on Dal_FormaPago.FormaPago_id=pago.formapago_id
where  pago.Cuenta_ID=isnull(@Cuenta_ID,pago.Cuenta_ID) and pago.pago_id=isnull(@pago_id,pago.pago_id) 
and pago.formapago_id=ISNULL(@formapago_id,pago.formapago_id)

GO
/****** Object:  StoredProcedure [dbo].[Pedido_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Pedido_Insert]
 @Pedido_fechacreacion datetime,
 @pedido_estado tinyint,
 @cuenta_id int,
 @FormaPago_id int,
 @FormaEnvio_id int,
 @Pedido_Notas varchar(50)
as
insert into dal_pedido(Pedido_fechacreacion,estadopedido_id,cuenta_id,FormaPago_id, FormaEnvio_id, Pedido_Notas) values(@Pedido_fechacreacion,@pedido_estado,@cuenta_id,@FormaPago_id, @FormaEnvio_id, @Pedido_Notas);select @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[Pedido_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Pedido_Show]
  @cuenta_id int=null,
  @pedido_id int=null,
  @pedido_estado int=null
as
select * from Dal_Pedido ped
inner join Dal_Cuenta cuenta on ped.Cuenta_ID=cuenta.Cuenta_ID
inner join Dal_FormaEnvio on Dal_FormaEnvio.FormaEnvio_id=ped.FormaEnvio_id
inner join Dal_FormaPago on Dal_FormaPago.FormaPago_id=ped.FormaPago_id
where ped.Cuenta_ID=ISNULL(@cuenta_id,ped.Cuenta_id) and pedido_id=isnull(@pedido_id,pedido_id) and estadopedido_id=ISNULL(@pedido_estado,estadopedido_id)

GO
/****** Object:  StoredProcedure [dbo].[Pedido_Update]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Pedido_Update]
 @pedido_id int,
 @pedido_estado tinyint,
 @FormaPago_id int,
 @FormaEnvio_id int,
 @Pedido_Notas varchar(50)
as
update dal_pedido set 
estadopedido_ID=@pedido_estado,
FormaPago_id=@FormaPago_id, 
FormaEnvio_id=@FormaEnvio_id, 
Pedido_notas=@Pedido_Notas
where pedido_id=@pedido_id

GO
/****** Object:  StoredProcedure [dbo].[PedidoItem_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PedidoItem_Insert]
 @Pedido_id int,
 @producto_id int,
 @pedidoitem_cantidad int
as
insert into Dal_PedidoItem values(@Pedido_id,@producto_id,@pedidoitem_cantidad,1,getdate(),GETDATE())

GO
/****** Object:  StoredProcedure [dbo].[PedidoItem_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PedidoItem_Show]
 @Pedido_id int=null,
 @producto_id int=null 
as
select * from Dal_PedidoItem    
inner join dal_producto on Dal_Producto.Producto_ID=Dal_PedidoItem.producto_Id
inner join Dal_SubCategoria on Dal_SubCategoria.SubCategoria_id=Dal_producto.SubCategoria_Id
inner join Dal_Categoria on Dal_SubCategoria.Categoria_id=Dal_Categoria.categoria_ID
inner join (select producto_id, MAX(productoprecio_fechavigencia) as fechamaxima from dal_productoprecio group by Producto_id)  precio on dal_producto.producto_id=precio.Producto_id 
inner join Dal_ProductoPrecio on precio.Producto_id=Dal_ProductoPrecio.Producto_id and Dal_ProductoPrecio.ProductoPrecio_FechaVigencia=precio.fechamaxima
inner join DAL_IVA on Dal_ProductoPrecio.IVA_id=DAL_IVA.IVA_id
inner join Dal_EstadoItemPedido on Dal_EstadoItemPedido.EstadoItemPedido_id=Dal_PedidoItem.EstadoItemPedido_id
where Pedido_ID=isnull(@Pedido_id,Dal_PedidoItem.Pedido_ID) and dal_producto.Producto_ID=isnull(@producto_id,  dal_producto.Producto_ID)

GO
/****** Object:  StoredProcedure [dbo].[Producto_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Producto_Insert]
@producto_id int=null,
@mimetype varchar(50)=null,
@imagedata varbinary(max),
@producto_codigointerno varchar(50)=null, 
@producto_NombreCorto varchar(50)=null,
@producto_NombreLargo varchar(50)=null,
@producto_Descripcion varchar(50)=null,
@producto_Estado bit=1,
@SubCategoria_Id int=null
as
 
 
 
			
INSERT INTO [dbo].[Dal_Producto]
           (Producto_CodigoInterno, imagedata,MimeType ,producto_NombreCorto,producto_NombreLargo,producto_Descripcion ,producto_Estado  ,SubCategoria_Id)
     VALUES
           (@producto_codigointerno,@imagedata,@mimetype,@producto_NombreCorto,@producto_NombreLargo,@producto_Descripcion,  @producto_Estado, @SubCategoria_Id)

select @@identity

GO
/****** Object:  StoredProcedure [dbo].[Producto_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Producto_Show]
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
inner join (select producto_id, MAX(productoprecio_fechavigencia) as fechamaxima from dal_productoprecio group by Producto_id)  precio on dal_producto.producto_id=precio.Producto_id 
inner join Dal_ProductoPrecio on precio.Producto_id=Dal_ProductoPrecio.Producto_id and Dal_ProductoPrecio.ProductoPrecio_FechaVigencia=precio.fechamaxima
inner join DAL_IVA on Dal_ProductoPrecio.IVA_id=DAL_IVA.IVA_id
where  Dal_Categoria.categoria_ID=ISNULL(@categoria_ID,Dal_Categoria.categoria_ID)
and Dal_SubCategoria.SubCategoria_id=isnull(@SubCategoria_id,Dal_SubCategoria.SubCategoria_id)
and Dal_Producto.Producto_ID=ISNULL(@producto_id,Dal_Producto.Producto_ID)

GO
/****** Object:  StoredProcedure [dbo].[ProductoPrecio_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ProductoPrecio_Insert]
 @producto_id int=null,
 @productoprecio_valor decimal(10,2)=null,
 @iva_id int=null
 as 
 insert into dal_ProductoPrecio values(@producto_id,@productoprecio_valor,getdate(),'',@iva_id)

GO
/****** Object:  StoredProcedure [dbo].[Proveedor_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Proveedor_Insert]
		@Proveedor_RazonSocial  char(50), 
        @Proveedor_DomicilioLegal  char(50), 
        @Proveedor_Telefono  char(50), 
        @Proveedor_Mail  char(50), 
        @Proveedor_Web  varchar(50), 
        @Proveedor_Contacto  varchar(50), 
        @Proveedor_Localidad  char(50), 
        @Proveedor_CP  varchar(8), 
        @Provincia_Codigo  int, 
        @Proveedor_CUIT  varchar(11), 
        @Proveedor_Estado  bit,  
        @TipoResponsable_ID int 
as

INSERT INTO  [dbo].[Dal_Proveedor]
           ([Proveedor_RazonSocial]
           ,[Proveedor_DomicilioLegal]
           ,[Proveedor_Telefono]
           ,[Proveedor_Mail]
           ,[Proveedor_Web]
           ,[Proveedor_Contacto]
           ,[Proveedor_Localidad]
           ,[Proveedor_CP]
           ,[Provincia_Codigo]
           ,[Proveedor_CUIT]
           ,[Proveedor_Estado]
           ,[TipoResponsable_ID])
     VALUES (@Proveedor_RazonSocial,
           @Proveedor_DomicilioLegal, 
           @Proveedor_Telefono, 
           @Proveedor_Mail,  
           @Proveedor_Web,  
           @Proveedor_Contacto,  
           @Proveedor_Localidad,  
           @Proveedor_CP, 
           @Provincia_Codigo, 
           @Proveedor_CUIT,  
           @Proveedor_Estado,  
           @TipoResponsable_ID )

GO
/****** Object:  StoredProcedure [dbo].[Proveedor_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Proveedor_Show]
		@Proveedor_id int=null,
		@Proveedor_RazonSocial  char(50)=null, 
        @Proveedor_DomicilioLegal  char(50)=null, 
        @Proveedor_Telefono  char(50)=null, 
        @Proveedor_Mail  char(50)=null, 
        @Proveedor_Web  varchar(50)=null, 
        @Proveedor_Contacto  varchar(50)=null, 
        @Proveedor_Localidad  char(50)=null, 
        @Proveedor_CP  varchar(8)=null, 
        @Provincia_Codigo  int=null, 
        @Proveedor_CUIT  varchar(11)=null, 
        @Proveedor_Estado  bit=null, 
        @TipoResponsable_ID int=null 
as

select * from Dal_Proveedor Proveedor  
inner join Dal_Provincia provincia on provincia.provincia_codigo=Proveedor.Provincia_Codigo
inner join Dal_TipoResponsable responsabilidad on responsabilidad.TipoResponsable_ID=Proveedor.TipoResponsable_ID
where Proveedor_CUIT=isnull(@Proveedor_CUIT,Proveedor_CUIT)  and Proveedor_ID=ISNULL(@Proveedor_id,Proveedor_id)

GO
/****** Object:  StoredProcedure [dbo].[Proveedor_Update]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Proveedor_Update]
		@Proveedor_id int,
		@Proveedor_RazonSocial  char(50), 
        @Proveedor_DomicilioLegal  char(50), 
        @Proveedor_Telefono  char(50), 
        @Proveedor_Mail  char(50), 
        @Proveedor_Web  varchar(50), 
        @Proveedor_Contacto  varchar(50), 
        @Proveedor_Localidad  char(50), 
        @Proveedor_CP  varchar(8), 
        @Provincia_Codigo  int, 
        @Proveedor_CUIT  varchar(11), 
        @Proveedor_Estado  bit,  
        @TipoResponsable_ID int 
as
UPDATE [Lavadero].[dbo].[Dal_Proveedor]
   SET [Proveedor_RazonSocial] = @Proveedor_RazonSocial,  
      [Proveedor_DomicilioLegal] =@Proveedor_DomicilioLegal,  
      [Proveedor_Telefono] = @Proveedor_Telefono,  
      [Proveedor_Mail] = @Proveedor_Mail,  
      [Proveedor_Web] = @Proveedor_Web,  
      [Proveedor_Contacto] = @Proveedor_Contacto, 
      [Proveedor_Localidad] = @Proveedor_Localidad,  
      [Proveedor_CP] = @Proveedor_CP,  
      [Provincia_Codigo] = @Provincia_Codigo,  
      [Proveedor_CUIT] = @Proveedor_CUIT,  
      [Proveedor_Estado] = @Proveedor_Estado,   
      [TipoResponsable_ID] = @TipoResponsable_ID 
 WHERE Proveedor_id=@Proveedor_id

GO
/****** Object:  StoredProcedure [dbo].[Provincia_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Provincia_Show]
@provincia_codigo int=null,
@provincia_nombre varchar(30)=null
as
select * from Dal_Provincia

GO
/****** Object:  StoredProcedure [dbo].[Remito_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Remito_Insert]
@remito_nro int,
@remito_fecha datetime,
@remito_recepciono varchar(20),
@remito_fechacarga datetime,
@proveedor_id int
as
insert into dal_remito (remito_nro ,remito_fecha ,remito_recepciono ,remito_fechacarga ,proveedor_id)
values(@remito_nro ,@remito_fecha ,@remito_recepciono ,@remito_fechacarga ,@proveedor_id);select @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[Remito_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Remito_Show]
@remito_nro int=null,
@remito_id int=null,
@proveedor_id int=null
as
select * from dal_remito 
inner join Dal_Proveedor on dal_remito.proveedor_id=Dal_Proveedor.Proveedor_ID
where remito_id=isnull(@remito_id,remito_id) and remito_nro=isnull(@remito_nro,remito_nro)

GO
/****** Object:  StoredProcedure [dbo].[RemitoItem_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[RemitoItem_Insert] 
	-- Add the parameters for the stored procedure here
	@remito_id int,
	@insumo_id int, 
	@remitoitem_cantidad int 
AS
BEGIN
	insert into Dal_RemitoItem values(	@remito_id,	@insumo_id ,@remitoitem_cantidad)
END

GO
/****** Object:  StoredProcedure [dbo].[RemitoItem_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[RemitoItem_Show] 
	-- Add the parameters for the stored procedure here
	@remito_id int,
	@insumo_id int 
AS
BEGIN
	select * from Dal_RemitoItem 
	inner join Dal_Insumo on Dal_Insumo.Insumo_id=dal_remitoitem.insumo_id
	where remito_id =isnull(	@remito_id,remito_id) and dal_remitoitem.insumo_id=isnull( @insumo_id,dal_remitoitem.insumo_id)
	
END

GO
/****** Object:  StoredProcedure [dbo].[Reposicion_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Reposicion_Insert]
	@PedidoReposicionEstado_id int,
	@PedidoReposicion_fecha datetime,
	@PedidoReposicion_Notas varchar(50) ,
	@Usuario_id int ,
	@PedidoReposicion_Comprado bit
as
insert into Dal_Reposicion (PedidoReposicionEstado_id ,PedidoReposicion_fecha,PedidoReposicion_Notas ,Usuario_id ,PedidoReposicion_Comprado)
values(	@PedidoReposicionEstado_id ,@PedidoReposicion_fecha,	@PedidoReposicion_Notas ,	@Usuario_id ,	@PedidoReposicion_Comprado);select @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[Reposicion_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Reposicion_Show]
	@pedidoReposicion_id int=null,
	@PedidoReposicionEstado_id int=null,
	@PedidoReposicion_Comprado bit =null
as
select * from Dal_Reposicion 
inner join Dal_ReposicionItem on Dal_ReposicionItem.PedidoReposicion_id=Dal_Reposicion.PedidoReposicion_id
where Dal_Reposicion.PedidoReposicion_id=isnull(@pedidoReposicion_id ,Dal_Reposicion.pedidoreposicion_id)
--and PedidoReposicionEstado_id=isnull(@PedidoReposicionEstado_id,PedidoReposicionEstado_id)
--and PedidoReposicion_Comprado=isnull(@PedidoReposicion_Comprado,PedidoReposicion_Comprado)

GO
/****** Object:  StoredProcedure [dbo].[Reposicion_Update]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Reposicion_Update]
	@PedidoReposicion_id int=null,
	@PedidoReposicionEstado_id int=null,
	@PedidoReposicion_Notas varchar(50)=null ,
	@PedidoReposicion_Comprado bit=null
as
update Dal_Reposicion 
set PedidoReposicionEstado_id=@PedidoReposicionEstado_id ,
PedidoReposicion_Notas =@PedidoReposicion_Notas,
PedidoReposicion_Comprado=@PedidoReposicion_Comprado
where PedidoReposicion_id=@pedidoreposicion_id

GO
/****** Object:  StoredProcedure [dbo].[ReposicionItem_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ReposicionItem_Insert]
	@PedidoReposicion_id int ,
	@insumo_ID int,
	@EstadoItemPedido_id int ,
	@ReposicionItem_CantidadPedida int,
	@ReposicionItem_CantidadRestante int ,
	@ReposicionItem_CantidadEntregada int ,
	@ReposicionItem_PrioridadDias int,
	@reposicionitem_especificacion varchar(50)=null
as
insert into Dal_ReposicionItem (PedidoReposicion_id, insumo_ID, reposicionitem_especificacion,   EstadoItemPedido_id  ,	 ReposicionItem_CantidadPedida , ReposicionItem_CantidadRestante, ReposicionItem_CantidadEntregada, ReposicionItem_PrioridadDias )
						values(@PedidoReposicion_id,@insumo_ID,@reposicionitem_especificacion,	@EstadoItemPedido_id  ,	@ReposicionItem_CantidadPedida ,@ReposicionItem_CantidadRestante,@ReposicionItem_CantidadEntregada,@ReposicionItem_PrioridadDias )

GO
/****** Object:  StoredProcedure [dbo].[ReposicionItem_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ReposicionItem_Show]
	@PedidoReposicion_id int=null,
	@Catalogo_ID int=null
as
select * from Dal_ReposicionItem item inner join Dal_Insumo on
item.Insumo_ID=Dal_Insumo.Insumo_id
where PedidoReposicion_id=isnull(@PedidoReposicion_id,PedidoReposicion_id)
and item.Insumo_ID=ISNULL(@catalogo_ID,item.insumo_ID)

GO
/****** Object:  StoredProcedure [dbo].[Servicio_Insert]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Servicio_Insert]
@servicio_id int =null,
@SubCategoria_id int=null,
@servicio_eventual bit=null,
@servicio_condiciones varchar(50)=null,
@servicio_duracion int=null,
@servicio_NombreCorto varchar(50)=null,
@servicio_NombreLargo varchar(50)=null,
@servicio_Descripcion varchar(50)=null,
@servicio_Estado bit=1
as


insert into dal_servicio (SubCategoria_id,servicio_eventual ,servicio_condiciones,servicio_duracion ,servicio_NombreCorto,servicio_NombreLargo,servicio_Descripcion,servicio_Estado )
values(@SubCategoria_id,@servicio_eventual ,@servicio_condiciones,@servicio_duracion ,@servicio_NombreCorto,@servicio_NombreLargo,@servicio_Descripcion,@servicio_Estado )

GO
/****** Object:  StoredProcedure [dbo].[Servicio_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Servicio_Show]
@servicio_id int =null,
@categoria_id int=null,
@SubCategoria_id int=null
as
select * from   dal_servicio  
inner join Dal_SubCategoria on Dal_SubCategoria.SubCategoria_id=Dal_servicio.SubCategoria_Id
inner join Dal_Categoria on Dal_SubCategoria.Categoria_id=Dal_Categoria.categoria_ID
inner join dal_servicioprecio on Dal_servicio.servicio_Id=Dal_servicioprecio.servicio_Id and servicioprecio_fechavigencia=(select MAX(servicioprecio_fechavigencia) from dal_servicioprecio)
inner join dal_iva on dal_iva.IVA_id=dal_servicioprecio.iva_id
where  Dal_Categoria.categoria_ID=ISNULL(@categoria_ID,Dal_Categoria.categoria_ID)
and Dal_SubCategoria.SubCategoria_id=isnull(@SubCategoria_id,Dal_SubCategoria.SubCategoria_id)
and dal_servicio.Servicio_id=ISNULL(@servicio_id,dal_servicio.servicio_ID)
GO
/****** Object:  StoredProcedure [dbo].[SubCategoria_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SubCategoria_Show]
@Categoria_id int
as
select * from Dal_SubCategoria where Categoria_id=@Categoria_id

GO
/****** Object:  StoredProcedure [dbo].[SubCategoriaRuta_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SubCategoriaRuta_Show]
@subcategoria_id int=null,
@categoria_id int=null
as
select * from dal_categoria cat  
inner join dal_subcategoria subcat on cat.categoria_id=subcat.categoria_id
where cat.categoria_id=isnull(@categoria_id,cat.categoria_id) and
subcat.subcategoria_id=isnull(@subcategoria_id,subcat.subcategoria_id)

GO
/****** Object:  StoredProcedure [dbo].[TipoResponsable_Show]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[TipoResponsable_Show]
@tiporesponsable_id int=null,
@tiporesponsable_Descripcion varchar(50)=null
as
select * from Dal_TipoResponsable

GO
/****** Object:  Table [dbo].[Dal_Categoria]    Script Date: 01/03/2017 0:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Categoria](
	[categoria_ID] [int] NOT NULL,
	[categoria_descripcion] [varchar](20) NULL,
	[CatalogoTipo_id] [int] NULL,
 CONSTRAINT [PK_comp_Categoria] PRIMARY KEY CLUSTERED 
(
	[categoria_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Comentario]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Comentario](
	[Comentario_id] [int] IDENTITY(1,1) NOT NULL,
	[Producto_id] [int] NULL,
	[Comentario_titulo] [varchar](50) NULL,
	[Comentario_descripcion] [varchar](50) NULL,
	[Comentario_positivo] [int] NULL,
	[Comentario_negativo] [int] NULL,
	[Comentario_por] [varchar](50) NULL,
	[Comentario_fecha] [datetime] NULL,
	[Comentario_Puntaje] [int] NULL,
 CONSTRAINT [PK_Dal_Comentario] PRIMARY KEY CLUSTERED 
(
	[Comentario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Contrato]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dal_Contrato](
	[contrato_id] [int] IDENTITY(1,1) NOT NULL,
	[cuenta_id] [int] NULL,
	[Servicio_id] [int] NULL,
	[contrato_bonificado] [bit] NULL,
	[contrato_diasdecorte] [int] NULL,
	[contrato_fechaFinalizacion] [datetime] NULL,
	[contrato_fechaFirmado] [datetime] NULL,
	[contrato_mesesvigencia] [int] NULL,
 CONSTRAINT [PK_Dal_Contrato] PRIMARY KEY CLUSTERED 
(
	[contrato_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dal_Cotizacion]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dal_Cotizacion](
	[PedidoReposicion_id] [int] NOT NULL,
	[Producto_id] [int] NOT NULL,
	[Proveedor_ID] [int] NOT NULL,
	[Cotizacion_PlazoEntregaDias] [int] NOT NULL,
	[Cotizacion_PlazoPagoDias] [int] NOT NULL,
	[Cotizacion_FechaHasta] [datetime] NULL,
	[Cotizacion_Descuento] [int] NOT NULL,
	[Cotizacion_ValorUnitario] [decimal](18, 0) NOT NULL,
	[IVA_id] [int] NULL,
	[Cotizacion_GarantiaDias] [int] NOT NULL,
	[Cotizacion_Estado] [int] NOT NULL,
 CONSTRAINT [PK_comp_Cotizacion] PRIMARY KEY CLUSTERED 
(
	[Proveedor_ID] ASC,
	[Producto_id] ASC,
	[PedidoReposicion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dal_CtaCte]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Dal_CtaCte](
	[Cuenta_id] [int] NOT NULL,
	[ComprobanteTipo_id] [int] NOT NULL,
	[Comprobante_id] [int] NOT NULL,
	[comprobante_nro] [int] NULL,
	[ctacte_monto] [numeric](18, 0) NULL,
	[ctacte_notas] [varchar](50) NULL,
	[ctacte_fecha] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Cuenta]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Cuenta](
	[Cuenta_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cuenta_RazonSocial] [char](50) NULL,
	[Cuenta_DomicilioLegal] [char](50) NULL,
	[Cuenta_Telefono] [char](50) NULL,
	[Cuenta_Mail] [char](50) NULL,
	[Cuenta_Web] [varchar](50) NULL,
	[Cuenta_Contacto] [varchar](50) NULL,
	[Cuenta_Localidad] [char](50) NULL,
	[Cuenta_CP] [varchar](8) NULL,
	[Provincia_Codigo] [int] NOT NULL,
	[Cuenta_CUIT] [varchar](11) NULL,
	[Cuenta_Estado] [bit] NULL,
	[CuentaTipo_id] [int] NULL,
	[TipoResponsable_ID] [int] NOT NULL,
 CONSTRAINT [PK_comp_Proveedor] PRIMARY KEY CLUSTERED 
(
	[Cuenta_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_CuentaTipo]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_CuentaTipo](
	[CuentaTipo_id] [int] NOT NULL,
	[CuentaTipo_descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Dal_CuentaTipo] PRIMARY KEY CLUSTERED 
(
	[CuentaTipo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Encuesta]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Encuesta](
	[encuesta_id] [int] IDENTITY(1,1) NOT NULL,
	[encuesta_descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Dal_Encuesta] PRIMARY KEY CLUSTERED 
(
	[encuesta_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_EncuestaDetalle]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_EncuestaDetalle](
	[encuestadetalle_id] [int] IDENTITY(1,1) NOT NULL,
	[encuesta_id] [int] NOT NULL,
	[encuestadetalle_descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Dal_EncuestaDetalle] PRIMARY KEY CLUSTERED 
(
	[encuestadetalle_id] ASC,
	[encuesta_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_EncuestaVoto]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_EncuestaVoto](
	[Login] [nvarchar](50) NOT NULL,
	[Encuesta_id] [int] NOT NULL,
	[EncuestaDetalle_id] [int] NOT NULL,
	[EncuestaVoto_Comentario] [varchar](50) NULL,
 CONSTRAINT [PK_Dal_EncuestaVoto] PRIMARY KEY CLUSTERED 
(
	[Login] ASC,
	[Encuesta_id] ASC,
	[EncuestaDetalle_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Envio]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Envio](
	[Pedido_id] [int] NOT NULL,
	[EstadoEnvio_id] [int] NOT NULL,
	[Envio_estado] [int] NULL,
	[Envio_FechaCarga] [int] NULL,
	[Envio_Nota] [varchar](50) NULL,
 CONSTRAINT [PK_Dal_Envio] PRIMARY KEY CLUSTERED 
(
	[Pedido_id] ASC,
	[EstadoEnvio_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_EstadoEnvio]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_EstadoEnvio](
	[EstadoEnvio_id] [int] NOT NULL,
	[EstadoEnvio_descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Dal_EstadoEnvio] PRIMARY KEY CLUSTERED 
(
	[EstadoEnvio_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_EstadoItemPedido]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_EstadoItemPedido](
	[EstadoItemPedido_id] [int] IDENTITY(1,1) NOT NULL,
	[EstadoItemPedido_descripcion] [varchar](15) NOT NULL,
 CONSTRAINT [PK_comp_EstadoItemPedido] PRIMARY KEY CLUSTERED 
(
	[EstadoItemPedido_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_EstadoPedido]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_EstadoPedido](
	[EstadoPedido_id] [int] NOT NULL,
	[EstadoPedido_descripcion] [varchar](20) NULL,
 CONSTRAINT [PK_comp_EstadoPedido] PRIMARY KEY CLUSTERED 
(
	[EstadoPedido_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Factura]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Factura](
	[Factura_ID] [int] NOT NULL,
	[Factura_fechaEmision] [datetime] NOT NULL,
	[Factura_nro] [bigint] NOT NULL,
	[Factura_letra] [char](3) NOT NULL,
	[Factura_ptoventa] [smallint] NULL,
	[Factura_CAI] [varchar](20) NULL,
	[Factura_CAE] [varchar](20) NULL,
	[Factura_FechaCarga] [datetime] NULL,
	[Factura_Cuenta] [int] NULL,
 CONSTRAINT [PK_Dal_Factura] PRIMARY KEY CLUSTERED 
(
	[Factura_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_FacturaContrato]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dal_FacturaContrato](
	[Factura_id] [int] NOT NULL,
	[Contrato_id] [int] NOT NULL,
	[Cuota_Nro] [int] NOT NULL,
	[Fecha_Creacion] [datetime] NULL,
	[Fecha_Facturacion] [datetime] NULL,
	[FacturaContrato_Vencimiento] [datetime] NULL,
 CONSTRAINT [PK_Dal_FacturaContrato] PRIMARY KEY CLUSTERED 
(
	[Factura_id] ASC,
	[Contrato_id] ASC,
	[Cuota_Nro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dal_FacturaPago]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dal_FacturaPago](
	[Factura_Id] [int] NULL,
	[Pago_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dal_FacturaRemito]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dal_FacturaRemito](
	[Comprobante_id] [int] NOT NULL,
	[Remito_id] [int] NOT NULL,
 CONSTRAINT [PK_Dal_FacturaRemito] PRIMARY KEY CLUSTERED 
(
	[Comprobante_id] ASC,
	[Remito_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dal_FormaEnvio]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_FormaEnvio](
	[FormaEnvio_id] [int] NOT NULL,
	[FormaEnvio_descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Dal_FormaEnvio] PRIMARY KEY CLUSTERED 
(
	[FormaEnvio_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_FormaPago]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_FormaPago](
	[FormaPago_id] [int] NOT NULL,
	[FormaPago_descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Dal_FormaPago] PRIMARY KEY CLUSTERED 
(
	[FormaPago_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Insumo]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Insumo](
	[Insumo_id] [int] IDENTITY(1,1) NOT NULL,
	[Insumo_Ubicacion] [varchar](50) NULL,
	[Insumo_StockMin] [int] NULL,
	[Insumo_StockMax] [int] NULL,
	[Insumo_StockActual] [int] NULL,
	[Insumo_NombreCorto] [varchar](50) NULL,
	[Insumo_NombreLargo] [varchar](50) NULL,
	[Insumo_Descripcion] [varchar](50) NULL,
	[Insumo_Estado] [bit] NULL,
	[SubCategoria_id] [int] NULL,
 CONSTRAINT [PK_Dal_Insumo] PRIMARY KEY CLUSTERED 
(
	[Insumo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DAL_IVA]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DAL_IVA](
	[IVA_id] [int] NOT NULL,
	[IVA_descripcion] [varchar](10) NULL,
	[IVA_multiplicador] [float] NULL,
 CONSTRAINT [PK_DAL_IVA] PRIMARY KEY CLUSTERED 
(
	[IVA_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Orden]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Orden](
	[Orden_ID] [int] IDENTITY(1,1) NOT NULL,
	[Orden_Notas] [varchar](50) NULL,
	[Orden_Estado] [int] NULL,
	[Orden_FechaCarga] [datetime] NULL,
	[Proveedor_id] [int] NULL,
 CONSTRAINT [PK_Dal_Orden] PRIMARY KEY CLUSTERED 
(
	[Orden_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_OrdenItem]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_OrdenItem](
	[orden_ID] [int] NOT NULL,
	[Insumo_ID] [int] NOT NULL,
	[EstadoOrdenItem_id] [int] NOT NULL,
	[ItemOrden_cantidadPedida] [int] NOT NULL,
	[ItemOrden_cantidadAcopiada] [int] NULL,
	[ItemOrden_cantidadEntregada] [int] NULL,
	[ItemOrden_cantidadFacturada] [int] NULL,
	[ItemOrden_fechaPedido] [datetime] NULL,
	[ItemOrden_fechaPrometida] [datetime] NULL,
	[ItemOrden_fechaEntrega] [datetime] NULL,
	[ItemOrden_fechaFacturacion] [datetime] NULL,
	[ItemOrden_preciounitario] [float] NULL,
	[Iva_id] [tinyint] NULL,
	[ItemOrden_lote] [char](1) NULL,
	[ItemOrden_NumeroSerie] [char](1) NULL,
	[ItemOrden_Retirar] [int] NULL,
 CONSTRAINT [PK_comp_ItemOrden] PRIMARY KEY CLUSTERED 
(
	[Insumo_ID] ASC,
	[orden_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Pago]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Pago](
	[pago_id] [int] NOT NULL,
	[pago_fecha] [datetime] NULL,
	[pago_concepto] [varchar](20) NULL,
	[formapago_id] [int] NULL,
	[pago_fechacarga] [datetime] NULL,
	[Cuenta_id] [int] NULL,
 CONSTRAINT [PK_Dal_Pago] PRIMARY KEY CLUSTERED 
(
	[pago_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Pedido]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Pedido](
	[Pedido_ID] [int] IDENTITY(1,1) NOT NULL,
	[Pedido_FechaCreacion] [smalldatetime] NULL,
	[EstadoPedido_id] [int] NOT NULL,
	[Cuenta_ID] [int] NOT NULL,
	[FormaEnvio_id] [int] NULL,
	[Pedido_Notas] [varchar](250) NULL,
	[FormaPago_id] [int] NULL,
 CONSTRAINT [PK_Dal_Pedido] PRIMARY KEY CLUSTERED 
(
	[Pedido_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_PedidoItem]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dal_PedidoItem](
	[Pedido_ID] [int] NOT NULL,
	[Producto_id] [int] NOT NULL,
	[PedidoItem_Cantidad] [int] NOT NULL,
	[EstadoItemPedido_id] [int] NULL,
	[PedidoItemEstado_Fecha] [datetime] NULL,
	[PedidoItem_FechaCreacion] [datetime] NULL,
 CONSTRAINT [PK_Dal_PedidoItem] PRIMARY KEY CLUSTERED 
(
	[Pedido_ID] ASC,
	[Producto_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dal_Producto]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Producto](
	[Producto_ID] [int] IDENTITY(1,1) NOT NULL,
	[Producto_CodigoInterno] [varchar](15) NULL,
	[MimeType] [varchar](50) NULL,
	[ImageData] [varbinary](max) NULL,
	[Producto_TiempoEntrega] [int] NULL,
	[Producto_Destacado] [bit] NULL,
	[Producto_NombreCorto] [varchar](50) NULL,
	[Producto_NombreLargo] [varchar](50) NULL,
	[Producto_Descripcion] [varchar](50) NULL,
	[Producto_Estado] [bit] NULL,
	[SubCategoria_id] [int] NULL,
 CONSTRAINT [PK_comp_insumo] PRIMARY KEY CLUSTERED 
(
	[Producto_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_ProductoPrecio]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_ProductoPrecio](
	[Producto_id] [int] NOT NULL,
	[ProductoPrecio_valor] [numeric](18, 2) NULL,
	[ProductoPrecio_FechaVigencia] [datetime] NULL,
	[ProductoPrecio_Nota] [varchar](50) NULL,
	[IVA_id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Proveedor]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Proveedor](
	[Proveedor_ID] [int] IDENTITY(1,1) NOT NULL,
	[Proveedor_RazonSocial] [char](50) NULL,
	[Proveedor_DomicilioLegal] [char](50) NULL,
	[Proveedor_Telefono] [char](50) NULL,
	[Proveedor_Mail] [char](50) NULL,
	[Proveedor_Web] [varchar](50) NULL,
	[Proveedor_Contacto] [varchar](50) NULL,
	[Proveedor_Localidad] [char](50) NULL,
	[Proveedor_CP] [varchar](8) NULL,
	[Provincia_Codigo] [int] NOT NULL,
	[Proveedor_CUIT] [varchar](11) NULL,
	[Proveedor_Estado] [bit] NULL,
	[TipoResponsable_ID] [int] NOT NULL,
 CONSTRAINT [PK_comp_Proveedor2] PRIMARY KEY CLUSTERED 
(
	[Proveedor_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Provincia]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Provincia](
	[provincia_codigo] [int] NOT NULL,
	[provincia_nombre] [varchar](30) NULL,
 CONSTRAINT [PK_Dal_Provincia] PRIMARY KEY CLUSTERED 
(
	[provincia_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Remito]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Remito](
	[Remito_id] [int] IDENTITY(1,1) NOT NULL,
	[Remito_nro] [int] NULL,
	[Remito_Fecha] [datetime] NULL,
	[Remito_Recepciono] [varchar](50) NULL,
	[Remito_FechaCarga] [datetime] NULL,
	[Proveedor_id] [int] NULL,
 CONSTRAINT [PK_Dal_Remito] PRIMARY KEY CLUSTERED 
(
	[Remito_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_RemitoItem]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dal_RemitoItem](
	[remito_ID] [int] NOT NULL,
	[Insumo_ID] [int] NOT NULL,
	[remitoitem_cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Dal_RemitoItem] PRIMARY KEY CLUSTERED 
(
	[remito_ID] ASC,
	[Insumo_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dal_Reposicion]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Reposicion](
	[PedidoReposicion_id] [int] IDENTITY(1,1) NOT NULL,
	[PedidoReposicionEstado_id] [int] NOT NULL,
	[PedidoReposicion_fecha] [datetime] NULL,
	[PedidoReposicion_Notas] [varchar](50) NULL,
	[Usuario_id] [int] NULL,
	[PedidoReposicion_Comprado] [bit] NULL,
 CONSTRAINT [PK_comp_PedidoReposicion] PRIMARY KEY CLUSTERED 
(
	[PedidoReposicion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_ReposicionItem]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_ReposicionItem](
	[PedidoReposicion_id] [int] NOT NULL,
	[Insumo_ID] [int] NOT NULL,
	[EstadoItemPedido_id] [int] NOT NULL,
	[ReposicionItem_CantidadPedida] [int] NULL,
	[ReposicionItem_CantidadRestante] [int] NULL,
	[ReposicionItem_CantidadEntregada] [int] NULL,
	[ReposicionItem_PrioridadDias] [int] NULL,
	[ReposicionItem_Especificacion] [varchar](50) NULL,
 CONSTRAINT [PK_comp_ItemPedidoReposicion] PRIMARY KEY CLUSTERED 
(
	[PedidoReposicion_id] ASC,
	[Insumo_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Servicio]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_Servicio](
	[Servicio_Id] [int] IDENTITY(1,1) NOT NULL,
	[Servicio_Eventual] [bit] NOT NULL,
	[Servicio_Condiciones] [varchar](50) NULL,
	[Servicio_Duracion] [int] NULL,
	[Servicio_NombreCorto] [varchar](50) NULL,
	[Servicio_NombreLargo] [varchar](50) NULL,
	[Servicio_Descripcion] [varchar](50) NULL,
	[Servicio_Estado] [bit] NULL,
	[SubCategoria_id] [int] NULL,
 CONSTRAINT [PK_Dal_Servicio] PRIMARY KEY CLUSTERED 
(
	[Servicio_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_ServicioPrecio]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_ServicioPrecio](
	[Servicio_id] [int] NOT NULL,
	[ServicioPrecio_valor] [numeric](18, 2) NULL,
	[ServicioPrecio_FechaVigencia] [datetime] NULL,
	[ServicioPrecio_Nota] [varchar](50) NULL,
	[IVA_id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_Stock]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dal_Stock](
	[Insumo_id] [int] NOT NULL,
	[Stock_Actual] [int] NULL,
	[Stock_Minimo] [int] NULL,
	[Stock_UltimoMovimiento] [datetime] NULL,
	[Stock_Maximo] [int] NULL,
 CONSTRAINT [PK_Dal_Stock] PRIMARY KEY CLUSTERED 
(
	[Insumo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dal_SubCategoria]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_SubCategoria](
	[SubCategoria_id] [int] NOT NULL,
	[SubCategoria_detalle] [varchar](50) NULL,
	[Categoria_id] [int] NULL,
 CONSTRAINT [PK_Dal_SubCategoria] PRIMARY KEY CLUSTERED 
(
	[SubCategoria_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dal_TipoResponsable]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dal_TipoResponsable](
	[TipoResponsable_ID] [int] NOT NULL,
	[TipoResponsable_descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TipoResponsable] PRIMARY KEY CLUSTERED 
(
	[TipoResponsable_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Seg_Accion]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Seg_Accion](
	[Accion_Id] [int] IDENTITY(1,1) NOT NULL,
	[Accion_Descripcion] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Seg_Familia]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seg_Familia](
	[familia_id] [int] IDENTITY(1,1) NOT NULL,
	[familia_Nombre] [nvarchar](30) NOT NULL,
	[familia_Estado] [bit] NOT NULL,
	[familia_descripcion] [nvarchar](70) NULL,
 CONSTRAINT [PK_Dal_Familia] PRIMARY KEY CLUSTERED 
(
	[familia_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Seg_FamiliaPatente]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seg_FamiliaPatente](
	[Familia_id] [int] NOT NULL,
	[Patente_id] [int] NOT NULL,
 CONSTRAINT [PK_Seg_FamiliaPatente] PRIMARY KEY CLUSTERED 
(
	[Familia_id] ASC,
	[Patente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Seg_Objeto]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Seg_Objeto](
	[Objeto_ID] [int] IDENTITY(1,1) NOT NULL,
	[Objeto_Descripcion] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Seg_Patente]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Seg_Patente](
	[Patente_id] [int] IDENTITY(1,1) NOT NULL,
	[Patente_descripcion] [varchar](50) NOT NULL,
	[Objeto_id] [int] NOT NULL,
	[Accion_id] [int] NOT NULL,
 CONSTRAINT [PK_Dal_Patente] PRIMARY KEY CLUSTERED 
(
	[Patente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Seg_Usuario]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seg_Usuario](
	[Login] [nvarchar](50) NOT NULL,
	[Contrasenia] [nvarchar](150) NOT NULL,
	[Nombre] [nvarchar](30) NULL,
	[Bloqueo] [bit] NULL,
	[FechaAlta] [datetime] NULL,
	[Estado] [bit] NULL,
	[digitoverificador] [float] NULL,
 CONSTRAINT [PK_Seg_Usuario] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Seg_UsuarioFamilia]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seg_UsuarioFamilia](
	[Login] [nvarchar](50) NOT NULL,
	[Familia_id] [int] NOT NULL,
 CONSTRAINT [PK_Seg_UsuarioXFamilia] PRIMARY KEY CLUSTERED 
(
	[Login] ASC,
	[Familia_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Seg_UsuarioPatente]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seg_UsuarioPatente](
	[Login] [nvarchar](50) NOT NULL,
	[Patente_id] [int] NOT NULL,
 CONSTRAINT [PK_Seg_UsuarioPatente] PRIMARY KEY CLUSTERED 
(
	[Login] ASC,
	[Patente_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sop_Backup]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sop_Backup](
	[Backup_id] [int] IDENTITY(1,1) NOT NULL,
	[Backup_Fecha] [datetime] NOT NULL,
	[Backup_Ruta] [varchar](100) NOT NULL,
	[Backup_Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Sop_Backup] PRIMARY KEY CLUSTERED 
(
	[Backup_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sop_Bitacora]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sop_Bitacora](
	[Bitacora_id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[bitacora_evento] [nvarchar](50) NOT NULL,
	[objeto_id] [int] NOT NULL,
	[accion_id] [int] NOT NULL,
	[bitacora_fecha] [datetime] NOT NULL,
	[bitacora_esError] [bit] NOT NULL,
 CONSTRAINT [PK_Dal_Bitacora] PRIMARY KEY CLUSTERED 
(
	[Bitacora_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sop_DigitoVerificador]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sop_DigitoVerificador](
	[Id_Tabla] [int] NULL,
	[Descripcion] [nchar](40) NULL,
	[DigitoVerificador] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sop_Idioma]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sop_Idioma](
	[id_idioma] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Dal_Idioma] PRIMARY KEY CLUSTERED 
(
	[id_idioma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sop_Traducciones]    Script Date: 01/03/2017 0:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sop_Traducciones](
	[Id_Idioma] [int] NOT NULL,
	[sin_traduccion] [nvarchar](50) NOT NULL,
	[con_traduccion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Sop_IdiomaControl] PRIMARY KEY CLUSTERED 
(
	[Id_Idioma] ASC,
	[sin_traduccion] ASC,
	[con_traduccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Dal_Comentario]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Comentario_Dal_Producto] FOREIGN KEY([Producto_id])
REFERENCES [dbo].[Dal_Producto] ([Producto_ID])
GO
ALTER TABLE [dbo].[Dal_Comentario] CHECK CONSTRAINT [FK_Dal_Comentario_Dal_Producto]
GO
ALTER TABLE [dbo].[Dal_Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Contrato_Dal_Cuenta] FOREIGN KEY([Servicio_id])
REFERENCES [dbo].[Dal_Servicio] ([Servicio_Id])
GO
ALTER TABLE [dbo].[Dal_Contrato] CHECK CONSTRAINT [FK_Dal_Contrato_Dal_Cuenta]
GO
ALTER TABLE [dbo].[Dal_Contrato]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Contrato_Dal_Cuenta1] FOREIGN KEY([cuenta_id])
REFERENCES [dbo].[Dal_Cuenta] ([Cuenta_ID])
GO
ALTER TABLE [dbo].[Dal_Contrato] CHECK CONSTRAINT [FK_Dal_Contrato_Dal_Cuenta1]
GO
ALTER TABLE [dbo].[Dal_Cotizacion]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Cotizacion_Dal_Cuenta] FOREIGN KEY([Proveedor_ID])
REFERENCES [dbo].[Dal_Proveedor] ([Proveedor_ID])
GO
ALTER TABLE [dbo].[Dal_Cotizacion] CHECK CONSTRAINT [FK_Dal_Cotizacion_Dal_Cuenta]
GO
ALTER TABLE [dbo].[Dal_Cotizacion]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Cotizacion_Dal_ReposicionItem] FOREIGN KEY([PedidoReposicion_id], [Producto_id])
REFERENCES [dbo].[Dal_ReposicionItem] ([PedidoReposicion_id], [Insumo_ID])
GO
ALTER TABLE [dbo].[Dal_Cotizacion] CHECK CONSTRAINT [FK_Dal_Cotizacion_Dal_ReposicionItem]
GO
ALTER TABLE [dbo].[Dal_CtaCte]  WITH CHECK ADD  CONSTRAINT [FK_Dal_CtaCte_Dal_Cuenta] FOREIGN KEY([Cuenta_id])
REFERENCES [dbo].[Dal_Cuenta] ([Cuenta_ID])
GO
ALTER TABLE [dbo].[Dal_CtaCte] CHECK CONSTRAINT [FK_Dal_CtaCte_Dal_Cuenta]
GO
ALTER TABLE [dbo].[Dal_Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Cuenta_Dal_CuentaTipo] FOREIGN KEY([CuentaTipo_id])
REFERENCES [dbo].[Dal_CuentaTipo] ([CuentaTipo_id])
GO
ALTER TABLE [dbo].[Dal_Cuenta] CHECK CONSTRAINT [FK_Dal_Cuenta_Dal_CuentaTipo]
GO
ALTER TABLE [dbo].[Dal_Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Cuenta_Dal_Provincia] FOREIGN KEY([Provincia_Codigo])
REFERENCES [dbo].[Dal_Provincia] ([provincia_codigo])
GO
ALTER TABLE [dbo].[Dal_Cuenta] CHECK CONSTRAINT [FK_Dal_Cuenta_Dal_Provincia]
GO
ALTER TABLE [dbo].[Dal_Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Cuenta_Dal_TipoResponsable] FOREIGN KEY([TipoResponsable_ID])
REFERENCES [dbo].[Dal_TipoResponsable] ([TipoResponsable_ID])
GO
ALTER TABLE [dbo].[Dal_Cuenta] CHECK CONSTRAINT [FK_Dal_Cuenta_Dal_TipoResponsable]
GO
ALTER TABLE [dbo].[Dal_EncuestaVoto]  WITH CHECK ADD  CONSTRAINT [FK_Dal_EncuestaVoto_Dal_EncuestaDetalle] FOREIGN KEY([EncuestaDetalle_id], [Encuesta_id])
REFERENCES [dbo].[Dal_EncuestaDetalle] ([encuestadetalle_id], [encuesta_id])
GO
ALTER TABLE [dbo].[Dal_EncuestaVoto] CHECK CONSTRAINT [FK_Dal_EncuestaVoto_Dal_EncuestaDetalle]
GO
ALTER TABLE [dbo].[Dal_EncuestaVoto]  WITH CHECK ADD  CONSTRAINT [FK_Dal_EncuestaVoto_Seg_Usuario] FOREIGN KEY([Login])
REFERENCES [dbo].[Seg_Usuario] ([Login])
GO
ALTER TABLE [dbo].[Dal_EncuestaVoto] CHECK CONSTRAINT [FK_Dal_EncuestaVoto_Seg_Usuario]
GO
ALTER TABLE [dbo].[Dal_Envio]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Envio_Dal_EstadoEnvio] FOREIGN KEY([EstadoEnvio_id])
REFERENCES [dbo].[Dal_EstadoEnvio] ([EstadoEnvio_id])
GO
ALTER TABLE [dbo].[Dal_Envio] CHECK CONSTRAINT [FK_Dal_Envio_Dal_EstadoEnvio]
GO
ALTER TABLE [dbo].[Dal_Envio]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Envio_Dal_Pedido] FOREIGN KEY([Pedido_id])
REFERENCES [dbo].[Dal_Pedido] ([Pedido_ID])
GO
ALTER TABLE [dbo].[Dal_Envio] CHECK CONSTRAINT [FK_Dal_Envio_Dal_Pedido]
GO
ALTER TABLE [dbo].[Dal_FacturaContrato]  WITH CHECK ADD  CONSTRAINT [FK_Dal_FacturaContrato_Dal_Contrato] FOREIGN KEY([Contrato_id])
REFERENCES [dbo].[Dal_Contrato] ([contrato_id])
GO
ALTER TABLE [dbo].[Dal_FacturaContrato] CHECK CONSTRAINT [FK_Dal_FacturaContrato_Dal_Contrato]
GO
ALTER TABLE [dbo].[Dal_FacturaContrato]  WITH CHECK ADD  CONSTRAINT [FK_Dal_FacturaContrato_Dal_Factura] FOREIGN KEY([Factura_id])
REFERENCES [dbo].[Dal_Factura] ([Factura_ID])
GO
ALTER TABLE [dbo].[Dal_FacturaContrato] CHECK CONSTRAINT [FK_Dal_FacturaContrato_Dal_Factura]
GO
ALTER TABLE [dbo].[Dal_FacturaPago]  WITH CHECK ADD  CONSTRAINT [FK_Dal_FacturaPago_Dal_Factura] FOREIGN KEY([Factura_Id])
REFERENCES [dbo].[Dal_Factura] ([Factura_ID])
GO
ALTER TABLE [dbo].[Dal_FacturaPago] CHECK CONSTRAINT [FK_Dal_FacturaPago_Dal_Factura]
GO
ALTER TABLE [dbo].[Dal_FacturaPago]  WITH CHECK ADD  CONSTRAINT [FK_Dal_FacturaPago_Dal_Pago] FOREIGN KEY([Pago_id])
REFERENCES [dbo].[Dal_Pago] ([pago_id])
GO
ALTER TABLE [dbo].[Dal_FacturaPago] CHECK CONSTRAINT [FK_Dal_FacturaPago_Dal_Pago]
GO
ALTER TABLE [dbo].[Dal_FacturaRemito]  WITH CHECK ADD  CONSTRAINT [FK_Dal_FacturaRemito_Dal_Factura] FOREIGN KEY([Comprobante_id])
REFERENCES [dbo].[Dal_Factura] ([Factura_ID])
GO
ALTER TABLE [dbo].[Dal_FacturaRemito] CHECK CONSTRAINT [FK_Dal_FacturaRemito_Dal_Factura]
GO
ALTER TABLE [dbo].[Dal_FacturaRemito]  WITH CHECK ADD  CONSTRAINT [FK_Dal_FacturaRemito_Dal_Remito] FOREIGN KEY([Remito_id])
REFERENCES [dbo].[Dal_Remito] ([Remito_id])
GO
ALTER TABLE [dbo].[Dal_FacturaRemito] CHECK CONSTRAINT [FK_Dal_FacturaRemito_Dal_Remito]
GO
ALTER TABLE [dbo].[Dal_Insumo]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Insumo_Dal_SubCategoria] FOREIGN KEY([SubCategoria_id])
REFERENCES [dbo].[Dal_SubCategoria] ([SubCategoria_id])
GO
ALTER TABLE [dbo].[Dal_Insumo] CHECK CONSTRAINT [FK_Dal_Insumo_Dal_SubCategoria]
GO
ALTER TABLE [dbo].[Dal_Orden]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Orden_Dal_Cuenta] FOREIGN KEY([Proveedor_id])
REFERENCES [dbo].[Dal_Proveedor] ([Proveedor_ID])
GO
ALTER TABLE [dbo].[Dal_Orden] CHECK CONSTRAINT [FK_Dal_Orden_Dal_Cuenta]
GO
ALTER TABLE [dbo].[Dal_OrdenItem]  WITH CHECK ADD  CONSTRAINT [FK_Dal_ItemOrden_Dal_ItemOrden1] FOREIGN KEY([orden_ID])
REFERENCES [dbo].[Dal_Orden] ([Orden_ID])
GO
ALTER TABLE [dbo].[Dal_OrdenItem] CHECK CONSTRAINT [FK_Dal_ItemOrden_Dal_ItemOrden1]
GO
ALTER TABLE [dbo].[Dal_OrdenItem]  WITH CHECK ADD  CONSTRAINT [FK_Dal_ItemOrden_Dal_Producto] FOREIGN KEY([Insumo_ID])
REFERENCES [dbo].[Dal_Insumo] ([Insumo_id])
GO
ALTER TABLE [dbo].[Dal_OrdenItem] CHECK CONSTRAINT [FK_Dal_ItemOrden_Dal_Producto]
GO
ALTER TABLE [dbo].[Dal_Pago]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Pago_Dal_FormaPago] FOREIGN KEY([formapago_id])
REFERENCES [dbo].[Dal_FormaPago] ([FormaPago_id])
GO
ALTER TABLE [dbo].[Dal_Pago] CHECK CONSTRAINT [FK_Dal_Pago_Dal_FormaPago]
GO
ALTER TABLE [dbo].[Dal_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Pedido_Dal_Cuenta] FOREIGN KEY([Cuenta_ID])
REFERENCES [dbo].[Dal_Cuenta] ([Cuenta_ID])
GO
ALTER TABLE [dbo].[Dal_Pedido] CHECK CONSTRAINT [FK_Dal_Pedido_Dal_Cuenta]
GO
ALTER TABLE [dbo].[Dal_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Pedido_Dal_EstadoPedido] FOREIGN KEY([EstadoPedido_id])
REFERENCES [dbo].[Dal_EstadoPedido] ([EstadoPedido_id])
GO
ALTER TABLE [dbo].[Dal_Pedido] CHECK CONSTRAINT [FK_Dal_Pedido_Dal_EstadoPedido]
GO
ALTER TABLE [dbo].[Dal_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Pedido_Dal_FormaEnvio] FOREIGN KEY([FormaEnvio_id])
REFERENCES [dbo].[Dal_FormaEnvio] ([FormaEnvio_id])
GO
ALTER TABLE [dbo].[Dal_Pedido] CHECK CONSTRAINT [FK_Dal_Pedido_Dal_FormaEnvio]
GO
ALTER TABLE [dbo].[Dal_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Pedido_Dal_FormaPago] FOREIGN KEY([FormaPago_id])
REFERENCES [dbo].[Dal_FormaPago] ([FormaPago_id])
GO
ALTER TABLE [dbo].[Dal_Pedido] CHECK CONSTRAINT [FK_Dal_Pedido_Dal_FormaPago]
GO
ALTER TABLE [dbo].[Dal_PedidoItem]  WITH CHECK ADD  CONSTRAINT [FK_Dal_PedidoItem_Dal_EstadoItemPedido] FOREIGN KEY([EstadoItemPedido_id])
REFERENCES [dbo].[Dal_EstadoItemPedido] ([EstadoItemPedido_id])
GO
ALTER TABLE [dbo].[Dal_PedidoItem] CHECK CONSTRAINT [FK_Dal_PedidoItem_Dal_EstadoItemPedido]
GO
ALTER TABLE [dbo].[Dal_PedidoItem]  WITH CHECK ADD  CONSTRAINT [FK_Dal_PedidoItem_Dal_Pedido] FOREIGN KEY([Pedido_ID])
REFERENCES [dbo].[Dal_Pedido] ([Pedido_ID])
GO
ALTER TABLE [dbo].[Dal_PedidoItem] CHECK CONSTRAINT [FK_Dal_PedidoItem_Dal_Pedido]
GO
ALTER TABLE [dbo].[Dal_PedidoItem]  WITH CHECK ADD  CONSTRAINT [FK_Dal_PedidoItem_Dal_Producto] FOREIGN KEY([Producto_id])
REFERENCES [dbo].[Dal_Producto] ([Producto_ID])
GO
ALTER TABLE [dbo].[Dal_PedidoItem] CHECK CONSTRAINT [FK_Dal_PedidoItem_Dal_Producto]
GO
ALTER TABLE [dbo].[Dal_Producto]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Producto_Dal_SubCategoria] FOREIGN KEY([SubCategoria_id])
REFERENCES [dbo].[Dal_SubCategoria] ([SubCategoria_id])
GO
ALTER TABLE [dbo].[Dal_Producto] CHECK CONSTRAINT [FK_Dal_Producto_Dal_SubCategoria]
GO
ALTER TABLE [dbo].[Dal_ProductoPrecio]  WITH CHECK ADD  CONSTRAINT [FK_Dal_CatalogoPrecio_DAL_IVA] FOREIGN KEY([IVA_id])
REFERENCES [dbo].[DAL_IVA] ([IVA_id])
GO
ALTER TABLE [dbo].[Dal_ProductoPrecio] CHECK CONSTRAINT [FK_Dal_CatalogoPrecio_DAL_IVA]
GO
ALTER TABLE [dbo].[Dal_ProductoPrecio]  WITH CHECK ADD  CONSTRAINT [FK_Dal_ProductoPrecio_Dal_Producto] FOREIGN KEY([Producto_id])
REFERENCES [dbo].[Dal_Producto] ([Producto_ID])
GO
ALTER TABLE [dbo].[Dal_ProductoPrecio] CHECK CONSTRAINT [FK_Dal_ProductoPrecio_Dal_Producto]
GO
ALTER TABLE [dbo].[Dal_Remito]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Remito_Dal_Cuenta] FOREIGN KEY([Proveedor_id])
REFERENCES [dbo].[Dal_Proveedor] ([Proveedor_ID])
GO
ALTER TABLE [dbo].[Dal_Remito] CHECK CONSTRAINT [FK_Dal_Remito_Dal_Cuenta]
GO
ALTER TABLE [dbo].[Dal_RemitoItem]  WITH CHECK ADD  CONSTRAINT [FK_Dal_RemitoItem_Dal_Insumo] FOREIGN KEY([Insumo_ID])
REFERENCES [dbo].[Dal_Insumo] ([Insumo_id])
GO
ALTER TABLE [dbo].[Dal_RemitoItem] CHECK CONSTRAINT [FK_Dal_RemitoItem_Dal_Insumo]
GO
ALTER TABLE [dbo].[Dal_RemitoItem]  WITH CHECK ADD  CONSTRAINT [FK_Dal_RemitoItem_Dal_Remito] FOREIGN KEY([remito_ID])
REFERENCES [dbo].[Dal_Remito] ([Remito_id])
GO
ALTER TABLE [dbo].[Dal_RemitoItem] CHECK CONSTRAINT [FK_Dal_RemitoItem_Dal_Remito]
GO
ALTER TABLE [dbo].[Dal_ReposicionItem]  WITH CHECK ADD  CONSTRAINT [FK_Dal_ReposicionItem_Dal_Reposicion] FOREIGN KEY([PedidoReposicion_id])
REFERENCES [dbo].[Dal_Reposicion] ([PedidoReposicion_id])
GO
ALTER TABLE [dbo].[Dal_ReposicionItem] CHECK CONSTRAINT [FK_Dal_ReposicionItem_Dal_Reposicion]
GO
ALTER TABLE [dbo].[Dal_Servicio]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Servicio_Dal_SubCategoria] FOREIGN KEY([SubCategoria_id])
REFERENCES [dbo].[Dal_SubCategoria] ([SubCategoria_id])
GO
ALTER TABLE [dbo].[Dal_Servicio] CHECK CONSTRAINT [FK_Dal_Servicio_Dal_SubCategoria]
GO
ALTER TABLE [dbo].[Dal_Stock]  WITH CHECK ADD  CONSTRAINT [FK_Dal_Stock_Dal_Producto] FOREIGN KEY([Insumo_id])
REFERENCES [dbo].[Dal_Producto] ([Producto_ID])
GO
ALTER TABLE [dbo].[Dal_Stock] CHECK CONSTRAINT [FK_Dal_Stock_Dal_Producto]
GO
ALTER TABLE [dbo].[Dal_SubCategoria]  WITH CHECK ADD  CONSTRAINT [FK_Dal_SubCategoria_Dal_Categoria] FOREIGN KEY([Categoria_id])
REFERENCES [dbo].[Dal_Categoria] ([categoria_ID])
GO
ALTER TABLE [dbo].[Dal_SubCategoria] CHECK CONSTRAINT [FK_Dal_SubCategoria_Dal_Categoria]
GO
ALTER TABLE [dbo].[Seg_UsuarioFamilia]  WITH CHECK ADD  CONSTRAINT [FK_Seg_UsuarioXFamilia_Seg_Familia] FOREIGN KEY([Familia_id])
REFERENCES [dbo].[Seg_Familia] ([familia_id])
GO
ALTER TABLE [dbo].[Seg_UsuarioFamilia] CHECK CONSTRAINT [FK_Seg_UsuarioXFamilia_Seg_Familia]
GO
ALTER TABLE [dbo].[Seg_UsuarioFamilia]  WITH CHECK ADD  CONSTRAINT [FK_Seg_UsuarioXFamilia_Seg_Usuario] FOREIGN KEY([Login])
REFERENCES [dbo].[Seg_Usuario] ([Login])
GO
ALTER TABLE [dbo].[Seg_UsuarioFamilia] CHECK CONSTRAINT [FK_Seg_UsuarioXFamilia_Seg_Usuario]
GO
ALTER TABLE [dbo].[Seg_UsuarioPatente]  WITH CHECK ADD  CONSTRAINT [FK_Seg_UsuarioPatente_Seg_Patente] FOREIGN KEY([Patente_id])
REFERENCES [dbo].[Seg_Patente] ([Patente_id])
GO
ALTER TABLE [dbo].[Seg_UsuarioPatente] CHECK CONSTRAINT [FK_Seg_UsuarioPatente_Seg_Patente]
GO
ALTER TABLE [dbo].[Seg_UsuarioPatente]  WITH CHECK ADD  CONSTRAINT [FK_Seg_UsuarioPatente_Seg_Usuario] FOREIGN KEY([Login])
REFERENCES [dbo].[Seg_Usuario] ([Login])
GO
ALTER TABLE [dbo].[Seg_UsuarioPatente] CHECK CONSTRAINT [FK_Seg_UsuarioPatente_Seg_Usuario]
GO
ALTER TABLE [dbo].[Sop_Traducciones]  WITH CHECK ADD  CONSTRAINT [FK_Sop_Traducciones_Sop_Idioma] FOREIGN KEY([Id_Idioma])
REFERENCES [dbo].[Sop_Idioma] ([id_idioma])
GO
ALTER TABLE [dbo].[Sop_Traducciones] CHECK CONSTRAINT [FK_Sop_Traducciones_Sop_Idioma]
GO
