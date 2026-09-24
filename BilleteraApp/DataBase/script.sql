
-- es script de postgres
create table Billetera (
	Id Integer generated always as identity primary key,
	Nombres varchar(100),
	Apellidos varchar(100),
	TipoDoc varchar (5),
	Documento Int,
	valorReacarga int,
	FormaPago varchar(20)
)