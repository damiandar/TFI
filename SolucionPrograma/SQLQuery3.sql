USE [lavadero]
GO

ALTER procedure [dbo].[Factura_Show]
@factura_id int=null,
@cuenta_id int=null
/*@factura_letra char(3)=null,
@factura_ptoventa smallint=1,
@pedido_id int=null*/
as
select * from dal_factura fac 
inner join dal_pedido ped on ped.pedido_id=fac.pedido_id
inner join dal_cuenta cli  on ped.cuenta_id=cli.cuenta_id
where fac.factura_id=isnull(@factura_id,fac.factura_id)
and cli.cuenta_id=isnull(@cuenta_id,cli.cuenta_id)


ALTER procedure [dbo].[Factura_Insert]
@factura_letra char(3)=null,
@factura_ptoventa smallint=1,
@pedido_id int=null
as
declare @ultimoNro int
declare @cai varchar(20)
declare @cae varchar(20)
select @ultimoNro=max( factura_nro )  from dal_factura where factura_letra=@factura_letra
select  @cai=max(  factura_cai  ) ,@cae=max(   factura_cae  )  from dal_factura  

INSERT INTO [dbo].[Dal_Factura]
			([factura_fecha],
		   [factura_nro],
           [factura_letra],
           [factura_ptoventa],
		   factura_cai,
		   factura_cae,
		   pedido_id)
     VALUES
           ( 
		   getdate(),
		   isnull(@ultimoNro,0)+1 , 
		   @factura_letra ,
		   @factura_ptoventa,
		   isnull(@cai,0)+1,
		   isnull(@cae,0)+1,
		   @pedido_id) ;select @@IDENTITY
		   
		   
		   
create procedure EstadisticaPedido_Show
as
select count(*) as valor ,(    CONVERT(varchar(4), year(pedido_fechacreacion), 101)   +   
         
  RIGHT('00' + CONVERT(NVARCHAR(2), month(pedido_fechacreacion)   ), 2)
   ) as id, 
case month(pedido_fechacreacion)
	when 1 then 'Enero'
	when 2 then 'Febrero'
	when 3 then 'Marzo'	
	when 4 then 'Abril'
	when 5 then 'Mayo'
	when 6 then 'Junio'
	when 7 then 'Julio'
	when 8 then 'Agosto'
	when 9 then 'Septiembre'
	when 10 then 'Octubre'
	when 11 then 'Noviembre'
	when 12 then 'Diciembre'	
end as descripcion
from dal_pedido group by year(pedido_fechacreacion),month(pedido_fechacreacion)
go


USE [lavadero]
GO

/****** Object:  Table [dbo].[Dal_Factura]    Script Date: 05/18/2017 16:55:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Dal_Factura](
	[Factura_ID] [int] IDENTITY(1,1) NOT NULL,
	[Factura_fecha] [datetime] NOT NULL,
	[Factura_nro] [bigint] NOT NULL,
	[Factura_letra] [char](3) NOT NULL,
	[Factura_ptoventa] [smallint] NULL,
	[Factura_CAI] [varchar](20) NULL,
	[Factura_CAE] [varchar](20) NULL,
	[Pedido_id] [int] NULL,
 CONSTRAINT [PK_Dal_Factura] PRIMARY KEY CLUSTERED 
(
	[Factura_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

begin tran
declare @ultimoNro int
declare @cai varchar(20)
declare @cae varchar(20)
select @ultimoNro=max(isnull(factura_nro,0)) ,@cai=max( isnull( factura_cai,0) )+1,@cae=max(  isnull(factura_cae,0) )+1 
from dal_factura o where factura_letra='A'
print @ultimoNro;
commit tran


 


 [Factura_Insert] @factura_letra='A',@factura_ptoventa=1,@pedido_id=1
 
 
 delete dal_factura where factura_id=4
 select * from dal_facturaitem
 
 alter procedure FacturaItem_insert
 @producto_id int=null,
 @factura_id int=null,
 @cantidad int=null,
 @precio decimal(18,2)=null
 as
 insert into dal_facturaitem  values(@factura_id,@producto_id,@cantidad,@precio)
 go
 
  
  
alter procedure FacturaItem_Show
@factura_id int=null,
@producto_id int=null
as
select * from dal_facturaitem item 
inner join dal_producto prod on item.producto_id=prod.producto_id
where item.factura_id=isnull(@factura_id,item.factura_id) and item.producto_id=isnull(@producto_id,item.producto_id)
go

