CREATE PROCEDURE [dbo].[UpdateStudent]
	@Id INT,
	@SectionId INT,
	@YearResult INT
AS
BEGIN

	UPDATE [Student] SET [SectionId] = @SectionId, [YearResult] = @YearResult
	WHERE Id = @Id

END