CREATE DATABASE WebFormsBaza

GO

USE WebFormsBaza

GO

CREATE TABLE Grad(
	IDGrad INT PRIMARY KEY IDENTITY NOT NULL,
	Naziv NVARCHAR(50) NOT NULL
)

GO

INSERT INTO Grad VALUES
('Zagreb'),
('Varaždin'),
('Split'),
('Rijeka'),
('Pula'),
('Osijek'),
('Dubrovnik')

GO

CREATE TABLE Status(
	IDStatus INT PRIMARY KEY IDENTITY NOT NULL,
	Naziv NVARCHAR(50) NOT NULL
)

GO

INSERT INTO  Status VALUES
('Korisnik'),
('Administrator')


GO

CREATE TABLE Osoba(
	IDOsoba INT PRIMARY KEY IDENTITY,
	Ime NVARCHAR(50) NOT NULL,
	Prezime NVARCHAR(50) NOT NULL,
	Telefon NVARCHAR(50) NOT NULL,
	Lozinka NVARCHAR(50) NOT NULL,
	StatusID INT NOT NULL,
	GradID INT NOT NULL

	FOREIGN KEY (StatusID) REFERENCES Status(IDStatus),
	FOREIGN KEY (GradID) REFERENCES Grad(IDGrad)
)

GO

INSERT INTO Osoba(Ime, Prezime, Telefon, Lozinka, StatusID, GradID) 
VALUES('Mislav', 'Basic', '0913334444', '123', 2, 1)

GO

CREATE TABLE Email (
	IDEmail INT PRIMARY KEY IDENTITY,
	Naziv NVARCHAR(50) NOT NULL,
	OsobaID INT NOT NULL

	FOREIGN KEY (OsobaID) REFERENCES Osoba(IDOsoba)

)

GO

INSERT INTO Email(Naziv,OsobaID)
values ('admin@email.com', 1)

GO

CREATE PROCEDURE CreateOsoba
	@Ime NVARCHAR(50),
	@Prezime NVARCHAR(50),
	@Telefon NVARCHAR(50),
	@Lozinka NVARCHAR(50),
	@StatusID INT,
	@GradID INT
AS
BEGIN
INSERT INTO Osoba(Ime, Prezime, Telefon, Lozinka, StatusID, GradID)
VALUES (@Ime, @Prezime, @Telefon, @Lozinka, @StatusID, @GradID)
END

GO

CREATE PROCEDURE CreateEmail
	@Naziv NVARCHAR(50),
	@OsobaID INT
AS
BEGIN
INSERT INTO Email(Naziv, OsobaID)
VALUES (@Naziv, @OsobaID)
END

GO

CREATE PROCEDURE EditOsoba
	@IDOsoba INT,
	@Ime NVARCHAR(50),
	@Prezime NVARCHAR(50),
	@Telefon NVARCHAR(50),
	@Lozinka NVARCHAR(50),
	@GradID INT,
	@StatusID INT
AS
BEGIN
	UPDATE Osoba SET Ime = @Ime, Prezime = @Prezime, Telefon = @Telefon, Lozinka = @Lozinka, GradID = @GradID, StatusID = @StatusID WHERE IDOsoba = @IDOsoba
END

GO

CREATE PROCEDURE EditEmail
	@IDEmail INT,
	@Naziv NVARCHAR(50),
	@OsobaID NVARCHAR(50)
AS
BEGIN
	UPDATE Email SET Naziv = @Naziv, OsobaID = @OsobaID WHERE IDEmail = @IDEmail
END

GO

CREATE PROCEDURE DeleteOsoba
	@IDOsoba INT
AS
BEGIN
	DELETE FROM Osoba WHERE IDOsoba = @IDOsoba
END

GO

CREATE PROCEDURE DeleteEmail
	@IDEmail INT
AS
BEGIN
	DELETE FROM Email WHERE IDEmail = @IDEmail
END

GO

CREATE PROCEDURE GetEmails
AS
BEGIN
	SELECT * FROM Email
END

GO

CREATE PROCEDURE GetGradovi
AS
BEGIN
	SELECT * FROM Grad
END

GO

CREATE PROCEDURE GetOsobe
AS
BEGIN
	SELECT * FROM Osoba
END

GO

CREATE PROCEDURE GetStatus
AS
BEGIN
	SELECT * FROM Status
END