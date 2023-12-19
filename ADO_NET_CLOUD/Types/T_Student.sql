CREATE TYPE [dbo].[T_Student] As Table
(
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	BirthDATE DATETIME2(7) NOT NULL,
	YearResult INT NULL,
	SectionId INT NOT NULL
)
