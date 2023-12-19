CREATE PROCEDURE [dbo].[AddStudent]
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@BirthDate DateTime2(7),
	@YearResult int,
	@SectionId int
AS
BEGIN

	INSERT INTO [Student]([FirstName],[LastName],[BirthDate],[YearResult],[SectionId])
	OUTPUT [inserted].Id
	VALUES(@FirstName,@LastName,@BirthDate,@YearResult,@SectionId)
END
