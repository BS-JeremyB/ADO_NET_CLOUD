CREATE PROCEDURE [dbo].[DeleteStudent]
	@Id INT
AS
BEGIN

	DELETE FROM [Student] WHERE [Id] = @Id

END
