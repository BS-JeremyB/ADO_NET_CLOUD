CREATE PROCEDURE [dbo].[AddSection]
	@Id INT,
	@SectionName NVARCHAR(50)
AS
BEGIN

	INSERT INTO [Section] ([Id],[SectionName])
	VALUES (@Id,@SectionName)

END
