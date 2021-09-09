create procedure DomicilioEnvio_Insert
@DomicilioEnvio_Direccion varchar(50),
@DomicilioEnvio_Localidad varchar(50), 
@DomicilioEnvio_CP Varchar(8),  
@DomicilioEnvio_Telefono varchar(50),  
@provincia_codigo int, 
@Cuenta_ID int
           as
INSERT INTO  Dal_DomicilioEnvio
           (DomicilioEnvio_Direccion,
            DomicilioEnvio_Localidad
           ,DomicilioEnvio_CP
           ,DomicilioEnvio_Telefono
           ,provincia_codigo
           ,Cuenta_ID)
     VALUES
           (@DomicilioEnvio_Direccion,
           @DomicilioEnvio_Localidad, 
           @DomicilioEnvio_CP,  
           @DomicilioEnvio_Telefono,  
           @provincia_codigo, 
           @Cuenta_ID )
GO
create table dal_DomicilioEnvio(
DomicilioEnvio_id int,
DomicilioEnvio_Direccion varchar(50),
DomicilioEnvio_Localidad varchar(50), 
DomicilioEnvio_CP Varchar(8),  
DomicilioEnvio_Telefono varchar(50),  
provincia_codigo int, 
Cuenta_ID int)