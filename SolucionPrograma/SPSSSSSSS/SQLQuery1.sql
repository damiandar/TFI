select * from dal_domicilioenvio

@DomicilioEnvio_Localidad varchar(50), 
@DomicilioEnvio_CP Varchar(8),  
@DomicilioEnvio_Telefono varchar(50),  
@provincia_codigo int, 
@Cuenta_ID int

exec DomicilioEnvio_Insert 'Peru 260','CABA','1027','49528189',1,6   
exec DomicilioEnvio_Insert 'Cabello 124','CABA','1121','65153087',1,9
exec DomicilioEnvio_Insert 'Mansilla 163','CABA','1824','1654789223',1,10
exec DomicilioEnvio_Insert 'Jonte 918 1 C','CABA','1027','4625-8758',1,11      

update dal_domicilioenvio set domicilioenvio_direccion='Peru 260'  where domicilioenvio_id=1     


select * from dal_pedido             

update dal_pedido set domicilioenvio_id=4 where cuenta_id=11     