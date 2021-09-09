create procedure DomicilioEnvio_Update
@domicilioenvio_id int,
@domicilioEnvio_Localidad varchar(50),
@DomicilioEnvio_CP varchar(8),
@DomicilioEnvio_Telefono  varchar(50), 
@provincia_codigo  int, 
@Cuenta_ID  int, 
@DomicilioEnvio_Direccion  varchar(50)  
as
UPDATE [Dal_DomicilioEnvio]
   SET [DomicilioEnvio_Localidad] = @DomicilioEnvio_Localidad,  
       [DomicilioEnvio_CP] = @DomicilioEnvio_CP,  
      [DomicilioEnvio_Telefono] = @DomicilioEnvio_Telefono,  
      [provincia_codigo] =@provincia_codigo,  
      [Cuenta_ID] = @Cuenta_ID,  
      [DomicilioEnvio_Direccion] = @DomicilioEnvio_Direccion
 WHERE domicilioenvio_id=@domicilioenvio_id
GO


