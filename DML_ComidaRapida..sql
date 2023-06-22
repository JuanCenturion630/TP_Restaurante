USE BD_ComidaRapida;

INSERT INTO Usuario(administrador,nombre,apellido,usuario,pass,fechaNacimiento,edad,horaIngreso,horaSalida,despedido)
VALUES (1,"Juan","Centurión","jcenturion630","12345678","2000-03-06",23,"08:00:00","16:00:00",0),
		(1,"Leandro","Deferrari","ldeferrari999","12345678","1990-01-01",30,"16:00:00","23:59:59",0),
		(0,"Diego","Hidalgo","dhidalgo999","12345678","2001/01/01",22,"16:00:00","23:59:59",0);
SELECT * FROM Usuario;

INSERT INTO Empresa(nombre,CUIT,ingBruto,direccion)
VALUES ("Grupo X S.R.L","20-42429088-1","1017936-4","AV. ZAVALETA 204, PARQUE PATRICIOS, CAP. FED");
SELECT * FROM Empresa;

INSERT INTO FormaPago(tipo) VALUES ("Efectivo"),("Débito"),("Crédito");
SELECT * FROM FormaPago; /* DESCARTADO POR FALTA DE TIEMPO. */

INSERT INTO Comida(nombre,precio,descartado)
VALUES ("Gaseosa grande",850,0),("Gaseosa media",350,0),("Gaseosa chica",250,0),
		("Carne grande",2000,0),("Carne media",1600,0),("Carne chica",1100,0),
		("Pizza grande",1300,0),("Pizza media",1000,0),("Pizza chica",750,0),
		("Hamburguesa grande",950,0),("Hamburguesa media",450,0),("Hamburguesa chica",250,0);
SELECT * FROM Comida;

UPDATE Comida SET descartado=0 WHERE descartado=1;
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

/* JOIN para unificar los datos de usuario y sesión */
SELECT
	Usuario.usuario AS Usuario,
	Sesion.ingresoSesion AS Ultima_Ingreso, Sesion.salidaSesion AS Ultima_Salida
FROM Usuario 
		JOIN Sesion ON Usuario.id = Sesion.idUsuario;
        
SELECT * FROM Sesion;