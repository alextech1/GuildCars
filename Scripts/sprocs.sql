USE GuildCarsEF

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
	INSERT INTO Car (OnSale, IsInStock, MakeID, ModelID, ConditionID, [Year], BodyStyleID, TransmissionID, ExteriorColorID,
	InteriorColorID, Mileage, VIN, SalePrice, MSRP, [Description], DateAdded, Photo)
	VALUES (@OnSale, @IsInStock, @MakeID, @ModelID, @ConditionID, @Year, @BodyStyleID, @TransmissionID, @ExteriorColorID,
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
