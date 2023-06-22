USE BD_ComidaRapida;

/* El IGNORE evita que se repita la clave única: usuario. */
INSERT IGNORE INTO Usuario(administrador,nombre,apellido,usuario,pass,fechaNacimiento,edad,horaIngreso,horaSalida)
VALUES (1,"Juan","Centurión","jcenturion630","12345678","2000-03-06",23,"08:00:00","16:00:00"),
		(1,"Leandro","Deferrari","ldeferrari999","12345678","1990-01-01",30,"16:00:00","23:59:59"),
		(0,"Diego","Hidalgo","dhidalgo999","12345678","2001/01/01",22,"16:00:00","23:59:59");
SELECT * FROM Usuario;

INSERT INTO Empresa(nombre,CUIT,ingBruto,direccion)
VALUES ("Grupo X S.R.L","20-42429088-1","1017936-4","AV. ZAVALETA 204, PARQUE PATRICIOS, CAP. FED");
SELECT * FROM Empresa;

INSERT INTO FormaPago(tipo) VALUES ("Efectivo"),("Débito"),("Crédito");
SELECT * FROM FormaPago; /* DESCARTADO POR FALTA DE TIEMPO. */

INSERT IGNORE INTO Comida(nombre,precio)
VALUES ("Gaseosa grande",850),("Gaseosa media",350),("Gaseosa chica",250),
		("Carne grande",2000),("Carne media",1600),("Carne chica",1100),
		("Pizza grande",1300),("Pizza media",1000),("Pizza chica",750),
		("Hamburguesa grande",950),("Hamburguesa media",450),("Hamburguesa chica",250);
SELECT * FROM Comida;

ALTER TABLE Comida AUTO_INCREMENT = 1; /* REINICIA EL ID. */

SELECT * FROM DetallesFormaPago;
SELECT * FROM CuerpoTicket;
SELECT * FROM DetallesTicket;

/* JOIN para unificar todas las tablas en un ticket. */
SELECT
	Empresa.nombre AS Empresa, Empresa.CUIT AS CUIT, Empresa.ingBruto AS IngBruto, Empresa.direccion AS Direccion,
	CuerpoTicket.id AS Nro,
	Usuario.usuario AS Emisor,
	CuerpoTicket.fechaEmision AS Emision,
	CuerpoTicket.total AS Total,
	FormaPago.tipo AS Forma_Pago, 
	DetallesFormaPago.monto AS Subtotal,
	Comida.nombre AS Comida, Comida.precio AS Precio_Unitario,
	DetallesTicket.cant AS Cantidad
FROM DetallesTicket
		JOIN Usuario ON Usuario.id = DetallesTicket.idUsuario
		JOIN DetallesFormaPago ON DetallesFormaPago.id = DetallesTicket.idDetallesFormaPago
		JOIN FormaPago ON FormaPago.id = 1 /* Solo "joinea" con la Forma de Pago 1 (Efectivo) porque no temporalmente no hay otras. */
		JOIN Comida ON Comida.id = DetallesTicket.idComida
		JOIN CuerpoTicket ON CuerpoTicket.id = DetallesTicket.idCuerpoTicket
		JOIN Empresa ON Empresa.CUIT = CuerpoTicket.CUIT_Empresa;