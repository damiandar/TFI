USE [lavadero]
GO
/****** Object:  StoredProcedure [dbo].[Cuenta_Update]    Script Date: 07/18/2017 10:03:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[Cuenta_Update]
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
        @TipoResponsable_ID int 
as
UPDATE [Dal_Cuenta]
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
      [TipoResponsable_ID] = @TipoResponsable_ID 
 WHERE cuenta_id=@cuenta_id

