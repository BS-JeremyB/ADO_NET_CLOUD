CREATE VIEW [dbo].[V_Student]
	AS SELECT [Id], [LastName], [FirstName], [BirthDate], [YearResult], [SectionId]
	FROM Student
	WHERE [Active] = 1;
