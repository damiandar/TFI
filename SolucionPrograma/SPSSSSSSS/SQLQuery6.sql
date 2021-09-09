create procedure DomicilioEnvio_Show
 @DomicilioEnvio_id int,
 @Cuenta_ID int
 as
SELECT [DomicilioEnvio_id]
      ,[DomicilioEnvio_Localidad]
      ,[DomicilioEnvio_CP]
      ,[DomicilioEnvio_Telefono]
      ,[provincia_codigo]
      ,[Cuenta_ID]
      ,[DomicilioEnvio_Direccion]
  FROM [Dal_DomicilioEnvio]
  where DomicilioEnvio_id=isnull(@DomicilioEnvio_id,DomicilioEnvio_id)
  and Cuenta_ID=isnull(@Cuenta_ID,Cuenta_ID)
GO


