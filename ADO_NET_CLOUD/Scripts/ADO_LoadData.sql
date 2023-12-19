/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

use ADO

INSERT INTO section VALUES (1010, N'Informatique de Gestion');
INSERT INTO section VALUES (1020, N'Comptabilité');
INSERT INTO section VALUES (1110, N'Tourisme');
INSERT INTO section VALUES (1120, N'Dessin 3D');
INSERT INTO section VALUES (1310, N'Administrateurs Système');
INSERT INTO section VALUES (1320, N'Secrétariat');

Set Identity_insert Student on;
INSERT INTO student (ID, FirstName, LastName, BirthDate, SectionID, YearResult) VALUES
(1, N'Georges', N'Lucas', '1944-05-17 00:00:00', 1320, 10),
(2, N'Clint', N'Eastwood', '1930-05-31 00:00:00', 1010, 4),
(3, N'Sean', N'Connery', '1930-08-25 00:00:00', 1020, 12),
(4, N'Robert', N'De Niro', '1943-08-17 00:00:00', 1110, 3),
(5, N'Kevin', N'Bacon', '1958-07-08 00:00:00', 1120, 16),
(6, N'Kim', N'Basinger', '1953-12-08 00:00:00', 1310, 19),
(7, N'Johnny', N'Depp', '1963-06-09 00:00:00', 1110, 11),
(8, N'Julia', N'Roberts', '1967-10-28 00:00:00', 1120, 17),
(9, N'Natalie', N'Portman', '1981-06-09 00:00:00', 1010, 4),
(10, N'Georges', N'Clooney', '1961-05-06 00:00:00', 1020, 4),
(11, N'Andy', N'Garcia', '1956-04-12 00:00:00', 1110, 19),
(12, N'Bruce', N'Willis', '1955-03-19 00:00:00', 1010, 6),
(13, N'Tom', N'Cruise', '1962-07-03 00:00:00', 1020, 4),
(14, N'Reese', N'Witherspoon', '1976-03-22 00:00:00', 1020, 7),
(15, N'Sophie', N'Marceau', '1966-11-17 00:00:00', 1110, 6),
(16, N'Sarah', N'Michelle Gellar', '1977-04-14 00:00:00', 1020, 7),
(17, N'Alyssa', N'Milano', '1972-12-19 00:00:00', 1110, 7),
(18, N'Jennifer', N'Garner', '1972-04-17 00:00:00', 1120, 18),
(19, N'Michael J.', N'Fox', '1969-06-20 00:00:00', 1310, 3),
(20, N'Tom', N'Hanks', '1956-07-09 00:00:00', 1020, 8),
(21, N'David', N'Morse', '1953-10-11 00:00:00', 1110, 2),
(22, N'Sandra', N'Bullock', '1964-07-26 00:00:00', 1010, 2),
(23, N'Keanu', N'Reeves', '1964-09-02 00:00:00', 1020,null),
(24, N'Shannen', N'Doherty', '1971-04-12 00:00:00', 1320, null),
(25, N'Halle', N'Berry', '1966-08-14 00:00:00', 1320, 18);
Set Identity_insert Student off;