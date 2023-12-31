CREATE DATABASE IF NOT EXISTS BD_ComidaRapida;
USE BD_ComidaRapida;

CREATE TABLE IF NOT EXISTS Usuario (
	/*NO CREEMOS TENER MÁS de 256 USUARIOS.*/
	id TINYINT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	administrador BOOLEAN NOT NULL,
	nombre VARCHAR(25) NOT NULL,
	apellido VARCHAR(25) NOT NULL,
	usuario VARCHAR(25) NOT NULL,
	pass VARCHAR(16) NOT NULL,
	fechaNacimiento DATE NOT NULL,
	edad TINYINT UNSIGNED NOT NULL,
	horaIngreso TIME NOT NULL,
	horaSalida TIME NOT NULL
);

ALTER TABLE Usuario ADD COLUMN recordarUsuario BOOLEAN;
ALTER TABLE Usuario CHANGE recordarUsuario recordarSesion BOOLEAN;
ALTER TABLE Usuario ADD COLUMN borradoLogico BOOLEAN;

CREATE TABLE IF NOT EXISTS Sesion (
	id TINYINT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	idUsuario TINYINT UNSIGNED NOT NULL,
	FOREIGN KEY (idUsuario) REFERENCES Usuario(id),
	ingresioSesion DATETIME,
	salidaSesion DATETIME
);

ALTER TABLE Sesion CHANGE ingresioSesion ingresoSesion DATETIME;

CREATE TABLE IF NOT EXISTS Empresa (
	nombre VARCHAR(25) NOT NULL,
	CUIT VARCHAR(13) PRIMARY KEY,
	ingBruto VARCHAR(9) NOT NULL,
	direccion VARCHAR(40) NOT NULL
);

ALTER TABLE Empresa MODIFY COLUMN direccion VARCHAR(50);

CREATE TABLE IF NOT EXISTS FormaPago (
	id TINYINT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	tipo VARCHAR(10) NOT NULL
);

CREATE TABLE IF NOT EXISTS DetallesFormaPago (
	id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	idFormaPago TINYINT UNSIGNED NOT NULL,
	FOREIGN KEY (idFormaPago) REFERENCES FormaPago(id),
	monto DECIMAL(10,2) UNSIGNED NOT NULL
);

CREATE TABLE IF NOT EXISTS Comida (
	id TINYINT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	nombre VARCHAR(20) NOT NULL,
	precio DECIMAL(6,2) NOT NULL
);

ALTER TABLE Comida ADD COLUMN borradoLogico BOOLEAN;
ALTER TABLE Comida MODIFY COLUMN nombre VARCHAR(40);

CREATE TABLE IF NOT EXISTS CuerpoTicket (
	id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	fechaEmision DATETIME NOT NULL,
	total DECIMAL(10,2) UNSIGNED NOT NULL,
	CUIT_Empresa VARCHAR(13) NOT NULL,
	FOREIGN KEY (CUIT_Empresa) REFERENCES Empresa(CUIT),
	idUsuario TINYINT UNSIGNED NOT NULL,
	FOREIGN KEY (idUsuario) REFERENCES Usuario(id)
);

CREATE TABLE IF NOT EXISTS DetallesTicket (
	id INT UNSIGNED PRIMARY KEY AUTO_INCREMENT,
	idCuerpoTicket INT UNSIGNED NOT NULL,
	idDetallesFormaPago INT UNSIGNED NOT NULL,
	idComida TINYINT UNSIGNED NOT NULL,
	cant TINYINT UNSIGNED NOT NULL,
	FOREIGN KEY (idCuerpoTicket) REFERENCES CuerpoTicket(id),
	FOREIGN KEY (idDetallesFormaPago) REFERENCES DetallesFormaPago(id),
	FOREIGN KEY (idComida) REFERENCES Comida(id)
);

ALTER TABLE DetallesTicket ADD COLUMN importe DECIMAL(10,2) NOT NULL;