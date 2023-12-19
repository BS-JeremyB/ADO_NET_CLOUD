CREATE TABLE [dbo].[Student]
(
	[Id] INT IDENTITY NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [BirthDate] DATETIME2 NOT NULL, 
    [YearResult] INT NULL, 
    [SectionId] INT NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Student] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Student_Section] FOREIGN KEY ([SectionId]) REFERENCES [Section]([Id]),
    CONSTRAINT [CK_Student_YearResult] CHECK ([YearResult] BETWEEN 0 and 20),
    CONSTRAINT [CK_Student_BirthDate] CHECK ([BirthDate] >= '1930-01-01'),
)

GO

CREATE TRIGGER [dbo].[TR_OnDeleteStudent]
    ON [dbo].[Student]
    INSTEAD OF DELETE
    AS
    BEGIN
        SET NoCount ON
        Update [Student] SET [Active] = 0 WHERE [Id] in (SELECT [Id] FROM [deleted] 
        WHERE ACTIVE = 1);
    END