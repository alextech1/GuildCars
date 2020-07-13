--should contain the scripts to drop and create the tables for 
--the database as well as configure their foreign key relationships.
USE GuildCars
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
	DROP TABLE Make
GO
CREATE TABLE Make (
	MakeID INT IDENTITY(1,1) PRIMARY KEY,
	MakeName VARCHAR(30) NOT NULL
)

IF EXISTS(SELECT * FROM sys.tables WHERE name='Model')
	DROP TABLE Model
GO
CREATE TABLE Model (
	ModelID INT IDENTITY(1,1) PRIMARY KEY,
	MakeID INT not null foreign key(MakeID) REFERENCES Make(MakeID),
	ModelName VARCHAR(30) NOT NULL
)
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyStyle')
	DROP TABLE BodyStyle
GO
CREATE TABLE BodyStyle (
	BodyStyleID INT IDENTITY(1,1) PRIMARY KEY,
	BodyStyleName VARCHAR(30) NOT NULL
)
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Transmission')
	DROP TABLE Transmission
GO
CREATE TABLE Transmission (
	TransmissionID INT IDENTITY(1,1) PRIMARY KEY,
	TransmissionType VARCHAR(30) NOT NULL
)
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='ExteriorColor')
	DROP TABLE ExteriorColor
GO
CREATE TABLE ExteriorColor (
	ExteriorColorID INT IDENTITY(1,1) PRIMARY KEY,
	Color VARCHAR(30) NOT NULL
)
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='InteriorColor')
	DROP TABLE InteriorColor
GO
CREATE TABLE InteriorColor (
	InteriorColorID INT IDENTITY(1,1) PRIMARY KEY,
	Color VARCHAR(30) NOT NULL
)
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Car')
	DROP TABLE Car
GO
CREATE TABLE Car (
	CarID INT IDENTITY(1,1) PRIMARY KEY,
	OnSale BIT NOT NULL DEFAULT (1),
	IsInStock BIT NOT NULL DEFAULT (1),
	MakeID INT NOT NULL foreign key(MakeID) REFERENCES Make(MakeID),
	ModelID INT NOT NULL foreign key(ModelID) REFERENCES Model(ModelID),
	Condition VARCHAR(15) NOT NULL,
	[Year] int NOT NULL,
	BodyStyleID INT NOT NULL foreign key(BodyStyleID) REFERENCES BodyStyle(BodyStyleID),
	TransmissionID INT NOT NULL foreign key(TransmissionID) REFERENCES Transmission(TransmissionID),	
	ExteriorColorID INT NOT NULL foreign key(ExteriorColorID) REFERENCES ExteriorColor(ExteriorColorID),	
	InteriorColorID INT NOT NULL foreign key(InteriorColorID) REFERENCES InteriorColor(InteriorColorID),
	Mileage VARCHAR(30) NOT NULL,	
	VIN VARCHAR(50) NOT NULL,
	SalePrice money,
	MSRP money,
	[Description] VARCHAR(500) NOT NULL,
	Photo VARCHAR(50) NOT NULL
)
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Transaction')
	DROP TABLE [Transaction]
GO
CREATE TABLE [Transaction] (
	TransactionID INT IDENTITY(1,1) PRIMARY KEY,
	CarID INT not null foreign key(CarID) REFERENCES Car(CarID),
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Phone VARCHAR(50) NOT NULL,
	[Role] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	AddressStreet1 VARCHAR(50) NOT NULL,
	AddressStreet2 VARCHAR(50),
	City VARCHAR(30) NOT NULL,	
	[State] VARCHAR(5) NOT NULL,
	ZipCode INT NOT NULL,
	PurchasePrice money,
	PurchaseType VARCHAR(30) NOT NULL
)
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
	DROP TABLE Specials
GO
CREATE TABLE Specials (
	SpecialsID INT IDENTITY(1,1) PRIMARY KEY,
	Title VARCHAR(50) NOT NULL,
	[Description] VARCHAR(500) NOT NULL
)
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='ContactUs')
	DROP TABLE ContactUs
GO
CREATE TABLE ContactUs (
	ContactUsID INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Phone VARCHAR(20) NOT NULL,
	[Message] VARCHAR(500) NOT NULL
)
GO