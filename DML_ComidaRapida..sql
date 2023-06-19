USE BD_ComidaRapida;

/*El IGNORE evita que se repita la clave única: usuario. */
INSERT IGNORE INTO Usuario(administrador,nombre,apellido,usuario,pass,fechaNacimiento,edad,horaIngreso,horaSalida)
VALUES (1,"Juan","Centurión","jcenturion630","12345678","2000-03-06",23,"08:00:00","16:00:00"),
		(1,"Leandro","Deferrari","ldeferrari999","12345678","1990-01-01",30,"16:00:00","23:59:59"),
		(0,"Diego","Hidalgo","dhidalgo999","12345678","2001/01/01",22,"16:00:00","23:59:59");
SELECT * FROM Usuario;

INSERT INTO Empresa(nombre,CUIT,ingBruto,direccion)
VALUES ("Grupo 6 S.R.L","20-42409081-1","1017936-4","AV. ZAVALETA 204, PARQUE PATRICIOS, CAP. FED");
SELECT * FROM Empresa;

INSERT INTO FormaPago(tipo) VALUES ("Efectivo"),("Débito"),("Crédito");
SELECT * FROM FormaPago;

INSERT IGNORE INTO Comida(nombre,precio)
VALUES ("Hamburguesa chica",250),("Hamburguesa media",450),("Hamburguesa grande",950),
		("Pizza chica",250),("Pizza media",450),("Pizza grande",950),
        ("Carne chica",250),("Carne media",450),("Carne grande",950),
        ("Gaseosa chica",250),("Gaseosa media",450),("Gaseosa grande",950);
SELECT * FROM Comida;