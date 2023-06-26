USE BD_ComidaRapida;

INSERT INTO Usuario(administrador,nombre,apellido,usuario,pass,fechaNacimiento,edad,horaIngreso,horaSalida,borradoLogico)
VALUES (1,"Juan","Centurión","jcenturion630","12345678","2000-03-06",23,"08:00:00","16:00:00",0),
		(1,"Leandro","Deferrari","ldeferrari999","12345678","1990-01-01",30,"16:00:00","23:59:59",0),
		(0,"Diego","Hidalgo","dhidalgo999","12345678","2001/01/01",22,"16:00:00","23:59:59",0);
SELECT * FROM Usuario;

INSERT INTO Empresa(nombre,CUIT,ingBruto,direccion)
VALUES ("Grupo X S.R.L","20-42429088-1","1017936-4","AV. ZAVALETA 204, PARQUE PATRICIOS, CAP. FED");
SELECT * FROM Empresa;

INSERT INTO FormaPago(tipo) VALUES ("Efectivo"),("Débito"),("Crédito");
SELECT * FROM FormaPago; /* DESCARTADO POR FALTA DE TIEMPO. */

INSERT INTO Comida(nombre,precio,borradoLogico)
VALUES ("Gaseosa grande",850,0),("Gaseosa media",350,0),("Gaseosa chica",250,0),
		("Carne grande",2000,0),("Carne media",1600,0),("Carne chica",1100,0),
		("Pizza grande",1300,0),("Pizza media",1000,0),("Pizza chica",750,0),
		("Hamburguesa grande",950,0),("Hamburguesa media",450,0),("Hamburguesa chica",250,0);
SELECT * FROM Comida;

UPDATE Comida SET borradoLogico=0 WHERE borradoLogico=1;
ALTER TABLE Comida AUTO_INCREMENT = 1; /* REINICIA EL ID. */

/* STORE PROCEDURE con JOINs para unificar todas las tablas en un ticket. */
DELIMITER //
CREATE PROCEDURE Crear_Ticket()
BEGIN
	SELECT
		Empresa.nombre AS Empresa, Empresa.CUIT AS CUIT, Empresa.ingBruto AS IngBruto, Empresa.direccion AS Direccion,
		CuerpoTicket.id AS Nro,
		Usuario.usuario AS Emisor,
		CuerpoTicket.fechaEmision AS Emision, CuerpoTicket.total AS Total,
		FormaPago.tipo AS Forma_Pago, 
		DetallesFormaPago.monto AS Subtotal,
		DetallesTicket.cant AS Cantidad,
		Comida.precio AS Precio_Unitario, Comida.nombre AS Descripcion,
		DetallesTicket.importe AS Importe
	FROM DetallesTicket
		JOIN DetallesFormaPago ON DetallesFormaPago.id = DetallesTicket.idDetallesFormaPago
		JOIN FormaPago ON FormaPago.id = DetallesFormaPago.idFormaPago
		JOIN Comida ON Comida.id = DetallesTicket.idComida
		JOIN CuerpoTicket ON CuerpoTicket.id = DetallesTicket.idCuerpoTicket
		JOIN Empresa ON Empresa.CUIT = CuerpoTicket.CUIT_Empresa
		JOIN Usuario ON Usuario.id = CuerpoTicket.idUsuario;
END //
DELIMITER ;
CALL Crear_Ticket();

/* STORE PROCEDURE con JOINs para unificar los datos de usuario y sesión. */
DELIMITER //
CREATE PROCEDURE Mostrar_Sesiones()
BEGIN
	SELECT
		Usuario.usuario AS Usuario,
		Sesion.ingresoSesion AS InicioSesion, Sesion.salidaSesion AS FinSesion
	FROM Usuario 
		JOIN Sesion ON Usuario.id = Sesion.idUsuario
	WHERE Sesion.salidaSesion != '2000/01/01 00:00:00';
END //
DELIMITER ;
CALL Mostrar_Sesiones();

/* STORE PROCEDURE con SUBCONSULTA para actualizar la celda de salidaSesion. */
DELIMITER //
CREATE PROCEDURE Registrar_Cierre_Sesion(horaSalida DATETIME, usuarioLogeado TINYINT UNSIGNED)
BEGIN
	UPDATE Sesion 
	SET salidaSesion=horaSalida 
	WHERE id = (
		SELECT MAX(id) 
		FROM Sesion 
		WHERE salidaSesion='2000/01/01 00:00:00' AND idUsuario=usuarioLogeado);
END //
DELIMITER ;
CALL Registrar_Cierre_Sesion('2050/01/10 00:05:00',2); /* PRUEBO EL STORE PROCEDURE */

select * from cuerpoticket;