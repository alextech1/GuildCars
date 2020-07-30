USE GuildCarsEF2


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsersSelectAll')
		DROP PROC UsersSelectAll
GO

CREATE PROC UsersSelectAll AS
BEGIN 
	SELECT Id, FirstName, LastName, Email, UserName
	FROM AspNetUsers
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsersSelect')
		DROP PROC UsersSelect
GO

CREATE PROC UsersSelect (
	@Id int
) AS
BEGIN
	SELECT Id, FirstName, LastName, Email, UserName
	FROM AspNetUsers
	WHERE Id = @Id
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsersInsert')
		DROP PROC UsersInsert
GO

CREATE PROC UsersInsert (
	@Id nvarchar(50) output,
	@FirstName nvarchar(25),
	@LastName nvarchar(25),
	@RoleID int,
	@Email nvarchar(100),
	@PasswordHash nvarchar(100),
	@UserName nvarchar(50)
) AS
BEGIN
	INSERT INTO AspNetUsers(FirstName, LastName, RoleID, Email, PasswordHash, UserName)
	VALUES (@FirstName, @LastName, @RoleID, @Email, @PasswordHash, @UserName);

	SET @Id = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsersUpdate')
		DROP PROC UsersUpdate
GO

CREATE PROC UsersUpdate (
	@Id nvarchar(100),
	@FirstName nvarchar(25),
	@LastName nvarchar(25),
	@RoleID int,
	@Email nvarchar(100),
	@PasswordHash nvarchar(100),
	@UserName nvarchar(50)

) AS
BEGIN
	UPDATE AspNetUsers SET
		Id = @Id,
		FirstName = @FirstName,
		LastName = @LastName,
		RoleID = @RoleID,
		Email = @Email,
		PasswordHash = @PasswordHash,
		UserName = @UserName
	WHERE Id = @Id
END
GO




--Cars-------------------------------------------




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarsSelectAll')
		DROP PROC CarsSelectAll
GO

CREATE PROC CarsSelectAll AS
BEGIN 
	SELECT CarID, OnSale, IsInStock, MakeID, ModelID, ConditionID, [Year], BodyStyleID, TransmissionID, 
	ExteriorColorID, InteriorColorID, Mileage, VIN, SalePrice, MSRP, [Description], DateAdded, Photo
	FROM Car
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarsSelect')
		DROP PROC CarsSelect
GO

CREATE PROC CarsSelect (
	@CarID int
) AS
BEGIN
	SELECT CarID, OnSale, IsInStock, MakeID, ModelID, ConditionID, [Year], BodyStyleID, TransmissionID, 
	ExteriorColorID, InteriorColorID, Mileage, VIN, SalePrice, MSRP, [Description], DateAdded, Photo
	FROM Car
	WHERE CarID = @CarID
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarsInsert')
		DROP PROC CarsInsert
GO

CREATE PROC CarsInsert (
	@CarID int output,
	@UserID nvarchar(100),
	@OnSale bit,
	@IsInStock bit,
	@MakeID int,
	@ModelID int,
	@ConditionID int,
	@Year int,
	@BodyStyleID int,
	@TransmissionID int,
	@ExteriorColorID int,
	@InteriorColorID int,
	@Mileage nvarchar(20),
	@VIN nvarchar(35),
	@SalePrice decimal,
	@MSRP decimal,
	@Description nvarchar(500),
	@DateAdded nvarchar(20),
	@Photo nvarchar(30)
) AS
BEGIN
	INSERT INTO Car (OnSale, UserID, IsInStock, MakeID, ModelID, ConditionID, [Year], BodyStyleID, TransmissionID, ExteriorColorID,
	InteriorColorID, Mileage, VIN, SalePrice, MSRP, [Description], DateAdded, Photo)
	VALUES (@OnSale, @UserID, @IsInStock, @MakeID, @ModelID, @ConditionID, @Year, @BodyStyleID, @TransmissionID, @ExteriorColorID,
	@InteriorColorID, @Mileage, @VIN, @SalePrice, @MSRP, @Description, @DateAdded, @Photo);

	SET @CarID = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarsUpdate')
		DROP PROC CarsUpdate
GO

CREATE PROC CarsUpdate (
	@CarID int,
	@OnSale bit,
	@IsInStock bit,
	@MakeID int,
	@ModelID int,
	@ConditionID int,
	@Year int,
	@BodyStyleID int,
	@TransmissionID int,
	@ExteriorColorID int,
	@InteriorColorID int,
	@Mileage nvarchar(20),
	@VIN nvarchar(35),
	@SalePrice decimal,
	@MSRP decimal,
	@Description nvarchar(500),
	@DateAdded nvarchar(20),
	@Photo nvarchar(30)
) AS
BEGIN
	UPDATE Car SET
		OnSale = @OnSale,
		IsInStock = @IsInStock,
		MakeID = @MakeID,
		ModelID = @ModelID,
		ConditionID = @ConditionID,
		[Year] = @Year,
		BodyStyleID = @BodyStyleID,
		TransmissionID = @TransmissionID,
		ExteriorColorID = @ExteriorColorID,
		InteriorColorID = @InteriorColorID,
		Mileage = @Mileage,
		VIN = @VIN,
		SalePrice = @SalePrice,
		MSRP = @MSRP,
		[Description] = @Description,
		DateAdded = @DateAdded,
		Photo = @Photo
	WHERE CarID = @CarID
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CarsDelete')
		DROP PROC CarsDelete
GO

CREATE PROC CarsDelete (
	@CarID int
) AS 
BEGIN 
	BEGIN TRANSACTION

	DELETE FROM Car WHERE CarID = @CarID;

	COMMIT TRANSACTION
END
GO



--BODY STYLE---------------------------------



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodyStylesSelectAll')
		DROP PROC BodyStylesSelectAll
GO

CREATE PROC BodyStylesSelectAll AS
BEGIN 
	SELECT BodyStyleID, BodyStyleName
	FROM BodyStyle
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodyStylesSelect')
		DROP PROC BodyStylesSelect
GO

CREATE PROC BodyStylesSelect (
	@BodyStyleID int
) AS
BEGIN
	SELECT BodyStyleID, BodyStyleName
	FROM BodyStyle
	WHERE BodyStyleID = @BodyStyleID
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodyStylesInsert')
		DROP PROC BodyStylesInsert
GO

CREATE PROC BodyStylesInsert (
	@BodyStyleID int output,
	@BodyStyleName nvarchar(20)
) AS
BEGIN
	INSERT INTO BodyStyle (BodyStyleName)
	VALUES (@BodyStyleName);

	SET @BodyStyleID = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodyStylesUpdate')
		DROP PROC BodyStylesUpdate
GO

CREATE PROC BodyStylesUpdate (
	@BodyStyleID int,
	@BodyStyleName nvarchar(20)
) AS
BEGIN
	UPDATE BodyStyle SET
		BodyStyleName = @BodyStyleName
	WHERE BodyStyleID = @BodyStyleID
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'BodyStylesDelete')
		DROP PROC BodyStylesDelete
GO

CREATE PROC BodyStylesDelete (
	@BodyStyleID int
) AS 
BEGIN 
	BEGIN TRANSACTION

	DELETE FROM BodyStyle WHERE BodyStyleID = @BodyStyleID;

	COMMIT TRANSACTION
END
GO



--Condition---------------------



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ConditionsSelectAll')
		DROP PROC ConditionsSelectAll
GO

CREATE PROC ConditionsSelectAll AS
BEGIN 
	SELECT ConditionID, ConditionType
	FROM Condition
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ConditionsSelect')
		DROP PROC ConditionsSelect
GO

CREATE PROC ConditionsSelect (
	@ConditionID int
) AS
BEGIN
	SELECT ConditionID, ConditionType
	FROM Condition
	WHERE ConditionID = @ConditionID
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ConditionsInsert')
		DROP PROC ConditionsInsert
GO

CREATE PROC ConditionsInsert (
	@ConditionID int output,
	@ConditionType nvarchar(20)
) AS
BEGIN
	INSERT INTO Condition(ConditionType)
	VALUES (@ConditionType);

	SET @ConditionID = SCOPE_IDENTITY();
END
GO





--ExteriorColor---------------------



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ExteriorColorsSelectAll')
		DROP PROC ExteriorColorsSelectAll
GO

CREATE PROC ExteriorColorsSelectAll AS
BEGIN 
	SELECT ExteriorColorID, Color
	FROM ExteriorColor
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ExteriorColorsSelect')
		DROP PROC ExteriorColorsSelect
GO

CREATE PROC ExteriorColorsSelect (
	@ExteriorColorID int
) AS
BEGIN
	SELECT ExteriorColorID, Color
	FROM ExteriorColor
	WHERE ExteriorColorID = @ExteriorColorID
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ExteriorColorsInsert')
		DROP PROC ExteriorColorsInsert
GO

CREATE PROC ExteriorColorsInsert (
	@ExteriorColorID int output,
	@Color nvarchar(20)
) AS
BEGIN
	INSERT INTO ExteriorColor(Color)
	VALUES (@Color);

	SET @ExteriorColorID = SCOPE_IDENTITY();
END
GO




--InteriorColor--------------------------




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InteriorColorsSelectAll')
		DROP PROC InteriorColorsSelectAll
GO

CREATE PROC InteriorColorsSelectAll AS
BEGIN 
	SELECT InteriorColorID, Color
	FROM InteriorColor
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InteriorColorsSelect')
		DROP PROC InteriorColorsSelect
GO

CREATE PROC InteriorColorsSelect (
	@InteriorColorID int
) AS
BEGIN
	SELECT InteriorColorID, Color
	FROM InteriorColor
	WHERE InteriorColorID = @InteriorColorID
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'InteriorColorsInsert')
		DROP PROC InteriorColorsInsert
GO

CREATE PROC InteriorColorsInsert (
	@InteriorColorID int output,
	@Color nvarchar(20)
) AS
BEGIN
	INSERT INTO InteriorColor(Color)
	VALUES (@Color);

	SET @InteriorColorID = SCOPE_IDENTITY();
END
GO



--Make-------------------------------------




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakesSelectAll')
		DROP PROC MakesSelectAll
GO

CREATE PROC MakesSelectAll AS
BEGIN 
	SELECT MakeID, MakeName, UserID, DateAdded
	FROM Make
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakesSelect')
		DROP PROC MakesSelect
GO

CREATE PROC MakesSelect (
	@MakeID int
) AS
BEGIN
	SELECT MakeID, MakeName, UserID, DateAdded
	FROM Make
	WHERE MakeID = @MakeID
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'MakesInsert')
		DROP PROC MakesInsert
GO

CREATE PROC MakesInsert (
	@MakeID int output,
	@MakeName nvarchar(20),
	@UserID nvarchar(50),
	@DateAdded nvarchar(20)
) AS
BEGIN
	INSERT INTO Make (MakeName, UserID, DateAdded)
	VALUES (@MakeName, @UserID, @DateAdded);

	SET @MakeID = SCOPE_IDENTITY();
END
GO




--Model----------------------------



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelsSelectAll')
		DROP PROC ModelsSelectAll
GO

CREATE PROC ModelsSelectAll AS
BEGIN 
	SELECT ModelID, MakeID, ModelName, UserID, DateAdded
	FROM Model
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelsSelect')
		DROP PROC ModelsSelect
GO

CREATE PROC ModelsSelect (
	@ModelID int
) AS
BEGIN
	SELECT ModelID, MakeID, ModelName, UserID, DateAdded
	FROM Model
	WHERE ModelID = @ModelID
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'ModelsInsert')
		DROP PROC ModelsInsert
GO

CREATE PROC ModelsInsert (
	@ModelID int output,
	@MakeID int,
	@ModelName nvarchar(20),
	@UserID nvarchar(50),
	@DateAdded nvarchar(20)
) AS
BEGIN
	INSERT INTO Model (MakeID, ModelName, UserID, DateAdded)
	VALUES (@MakeID, @ModelName, @UserID, @DateAdded);

	SET @ModelID = SCOPE_IDENTITY();
END
GO





--PurchaseType-------------------------------




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseTypesSelectAll')
		DROP PROC PurchaseTypesSelectAll
GO

CREATE PROC PurchaseTypesSelectAll AS
BEGIN 
	SELECT PurchaseTypeID, PurchaseTypeName
	FROM PurchaseType
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'PurchaseTypesSelect')
		DROP PROC PurchaseTypesSelect
GO

CREATE PROC PurchaseTypesSelect (
	@PurchaseTypeID int
) AS
BEGIN
	SELECT PurchaseTypeID, PurchaseTypeName
	FROM PurchaseType
	WHERE PurchaseTypeID = @PurchaseTypeID
END 
GO



--GuildRole----------------------------------




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GuildRolesSelectAll')
		DROP PROC GuildRolesSelectAll
GO

CREATE PROC GuildRolesSelectAll AS
BEGIN 
	SELECT RoleID, RoleName
	FROM GuildRole
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GuildRolesSelect')
		DROP PROC GuildRolesSelect
GO

CREATE PROC GuildRolesSelect (
	@RoleID int
) AS
BEGIN
	SELECT RoleID, RoleName
	FROM GuildRole
	WHERE RoleID = @RoleID
END 
GO



--Specials--------------------------




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsSelectAll')
		DROP PROC SpecialsSelectAll
GO

CREATE PROC SpecialsSelectAll AS
BEGIN 
	SELECT SpecialsID, Title, [Description], ImageFileName
	FROM Specials
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsSelect')
		DROP PROC SpecialsSelect
GO

CREATE PROC SpecialsSelect (
	@SpecialsID int
) AS
BEGIN
	SELECT SpecialsID, Title, [Description], ImageFileName
	FROM Specials
	WHERE SpecialsID = @SpecialsID
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsInsert')
		DROP PROC SpecialsInsert
GO

CREATE PROC SpecialsInsert (
	@SpecialsID int output,
	@Title nvarchar(30),
	@Description nvarchar(500),
	@ImageFileName nvarchar(30)
) AS
BEGIN
	INSERT INTO Specials(Title, [Description], ImageFileName)
	VALUES (@Title, @Description, @ImageFileName);

	SET @SpecialsID = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsUpdate')
		DROP PROC SpecialsUpdate
GO

CREATE PROC SpecialsUpdate (
	@SpecialsID int,
	@Title nvarchar(30),
	@Description nvarchar(500),
	@ImageFileName nvarchar(30)
) AS
BEGIN
	UPDATE Specials SET
		Title = @Title,
		[Description] = @Description,
		ImageFileName = @ImageFileName
	WHERE SpecialsID = @SpecialsID
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SpecialsDelete')
		DROP PROC SpecialsDelete
GO

CREATE PROC SpecialsDelete (
	@SpecialsID int
) AS 
BEGIN 
	BEGIN TRANSACTION

	DELETE FROM Specials WHERE SpecialsID = @SpecialsID;

	COMMIT TRANSACTION
END
GO



--State--------------------------------




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'StatesSelectAll')
		DROP PROC StatesSelectAll
GO

CREATE PROC StatesSelectAll AS
BEGIN 
	SELECT StateID, StateAbbr, StateName
	FROM [State]
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'StatesSelect')
		DROP PROC StatesSelect
GO

CREATE PROC StatesSelect (
	@StateID int
) AS
BEGIN
	SELECT StateID, StateAbbr, StateName
	FROM [State]
	WHERE StateID = @StateID
END 
GO



--Transaction-----------------------------------



IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransactionsSelectAll')
		DROP PROC TransactionsSelectAll
GO

CREATE PROC TransactionsSelectAll AS
BEGIN 
	SELECT TransactionID, CarID, UserID, PurchaseDate, FirstName, LastName, [Role], Email, AddressStreet1,
	AddressStreet2, City, StateID, ZipCode, PurchasePrice, PurchaseTypeID
	FROM [Transaction]
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransactionsSelect')
		DROP PROC TransactionsSelect
GO

CREATE PROC TransactionsSelect (
	@TransactionID int
) AS
BEGIN
	SELECT TransactionID, CarID, UserID, PurchaseDate, FirstName, LastName, [Role], Email, AddressStreet1,
	AddressStreet2, City, StateID, ZipCode, PurchasePrice, PurchaseTypeID
	FROM [Transaction]
	WHERE TransactionID = @TransactionID
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransactionsInsert')
		DROP PROC TransactionsInsert
GO

CREATE PROC TransactionsInsert (
	@TransactionID int output,
	@CarID int,
	@UserID int,
	@PurchaseDate nvarchar(20),
	@FirstName nvarchar(25),
	@LastName nvarchar(25),
	@Role int,
	@Email nvarchar(100),
	@AddressStreet1 nvarchar(100),
	@AddressStreet2 nvarchar(100),
	@City nvarchar(50),
	@StateID int,
	@ZipCode int,
	@PurchasePrice decimal,
	@PurchaseTypeID int
) AS
BEGIN
	INSERT INTO [Transaction] (CarID, UserID, PurchaseDate, FirstName, LastName, [Role], Email, AddressStreet1, AddressStreet2,
	City, StateID, ZipCode, PurchasePrice, PurchaseTypeID)	
	VALUES (@CarID, @UserID, @PurchaseDate, @FirstName, @LastName, @Role, @Email, @AddressStreet1, @AddressStreet2,
	@City, @StateID, @ZipCode, @PurchasePrice, @PurchaseTypeID);

	SET @TransactionID = SCOPE_IDENTITY();
END
GO

--Transmission




IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransmissionsSelectAll')
		DROP PROC TransmissionsSelectAll
GO

CREATE PROC TransmissionsSelectAll AS
BEGIN 
	SELECT TransmissionID, TransmissionType
	FROM Transmission
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransmissionsSelect')
		DROP PROC TransmissionsSelect
GO

CREATE PROC TransmissionsSelect (
	@TransmissionID int
) AS
BEGIN
	SELECT TransmissionID, TransmissionType
	FROM Transmission
	WHERE TransmissionID = @TransmissionID
END 
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TransmissionsInsert')
		DROP PROC TransmissionsInsert
GO

CREATE PROC TransmissionsInsert (
	@TransmissionID int output,
	@TransmissionType nvarchar(20)
) AS
BEGIN
	INSERT INTO Transmission (TransmissionType)
	VALUES (@TransmissionType);

	SET @TransmissionID = SCOPE_IDENTITY();
END
GO

