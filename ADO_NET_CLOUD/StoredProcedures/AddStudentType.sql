CREATE PROCEDURE [dbo].[AddStudentType]
	@Students T_Student readonly
AS
BEGIN

	INSERT INTO [Student]([FirstName],[LastName],[BirthDate],[YearResult],[SectionId])
	OUTPUT [inserted].Id
	SELECT FirstName,LastName,BirthDate,YearResult,SectionId from @Students;

END